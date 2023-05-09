using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
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
using DocumentFormat.OpenXml.Spreadsheet;

namespace ReadFromExcelSB.Managers
{
    internal class ExcelManager
    {

        List<DcDto> dcList = new List<DcDto>();
        ReportByLineMenManager reportByLineMenManager = new ReportByLineMenManager();

        public string ProcessData(string filePath)
        {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
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

                   return reportByLineMenManager.GetReport(dcList);
                }
            }
        }

        public void CreateExcelFile()
        {
            CreateSpreadsheetWorkbook(@"C:\source\Eswar\temp\Sheet2.xlsx");
        }

        public static void CreateSpreadsheetWorkbook(string filepath)
        {
            // Create a spreadsheet document by supplying the filepath.
            // By default, AutoSave = true, Editable = true, and Type = xlsx.
            SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.
                Create(filepath, SpreadsheetDocumentType.Workbook);

            // Add a WorkbookPart to the document.
            WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
            workbookpart.Workbook = new Workbook();

            // Add a WorksheetPart to the WorkbookPart.
            WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());

            // Add Sheets to the Workbook.
            Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.
                AppendChild<Sheets>(new Sheets());

            // Append a new worksheet and associate it with the workbook.
            Sheet sheet = new Sheet()
            {
                Id = spreadsheetDocument.WorkbookPart.
                GetIdOfPart(worksheetPart),
                SheetId = 1,
                Name = "mySheet"
            };
            sheets.Append(sheet);

            workbookpart.Workbook.Save();

            // Close the document.
            spreadsheetDocument.Close();
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
