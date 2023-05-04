using ExcelDataReader;
using ExcelDataReader.Exceptions;
using Microsoft.VisualBasic;
using ReadFromExcelSB.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFromExcelSB.Managers
{
    internal class ExcelManager
    {

        List<DcDto> dcList = new List<DcDto>();

        public List<LineMenReport> ProcessData(string filePath)
        {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                {


                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        // Gets or sets a value indicating whether to set the DataColumn.DataType 
                        // property in a second pass.
                        UseColumnDataType = true,

                        // Gets or sets a callback to determine whether to include the current sheet
                        // in the DataSet. Called once per sheet before ConfigureDataTable.
                        FilterSheet = (tableReader, sheetIndex) => true,

                        // Gets or sets a callback to obtain configuration options for a DataTable. 
                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            // Gets or sets a value indicating the prefix of generated column names.
                            EmptyColumnNamePrefix = "Column",

                            // Gets or sets a value indicating whether to use a row from the 
                            // data as column names.
                            UseHeaderRow = false,

                            // Gets or sets a callback to determine which row is the header row. 
                            // Only called when UseHeaderRow = true.
                            ReadHeaderRow = (rowReader) =>
                            {
                                // Skip first two rows.
                                rowReader.Read();
                                rowReader.Read();
                            },

                            // Gets or sets a callback to determine whether to include the 
                            // current row in the DataTable.
                            FilterRow = (rowReader) =>
                            {
                                return true;
                            },

                            // Gets or sets a callback to determine whether to include the specific
                            // column in the DataTable. Called once per column after reading the 
                            // headers.
                            FilterColumn = (rowReader, columnIndex) =>
                            {
                                return true;
                            }
                        }
                    });

                    var allRows = result.Tables[0].Rows;

                    ParseDataTable(allRows);

                    Console.WriteLine(result.Tables.Count);


                    ReportByLineMenManager reportByLineMenManager = new ReportByLineMenManager();

                   return reportByLineMenManager.GetReport(dcList);



                }
            }
        }

        private void ParseDataTable(System.Data.DataRowCollection allRows)
        {
            // Skip first two rows
            for (int i = 4; i < allRows.Count; i++)
            {
                dcList.Add(new DcDto()
                {
                    SlNumber = Convert.ToInt32(allRows[i][0].ToString()),
                    Section = allRows[i][1].ToString(),
                    LineMenName = allRows[i][2].ToString(),
                    Location = allRows[i][3].ToString(),
                    ServiceNumber = allRows[i][4].ToString(),
                    Category = allRows[i][5].ToString(),
                    ServiceAmount = Convert.ToDouble(allRows[i][6].ToString()),
                    PaidDate = DateTime.ParseExact(allRows[i][7].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    PaidAmount = Convert.ToDouble(allRows[i][8].ToString()),
                    PaidPRNumner = allRows[i][9].ToString(),
                    Remarks = allRows[i][10].ToString()
                });
            }
        }

    }
}
