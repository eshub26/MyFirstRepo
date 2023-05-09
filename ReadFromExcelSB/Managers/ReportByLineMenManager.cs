using ReadFromExcelSB.DTO;
using ReadFromExcelSB.Helpers;
using System.Globalization;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Drawing.Charts;
using System.Configuration;

namespace ReadFromExcelSB.Managers
{
    internal class ReportByLineMenManager
    {
        private readonly ExcelManager _excelManager;
        private readonly List<DcDto> _dcList;
        private OpenxmlFacade _openxmlFacade;

        public ReportByLineMenManager()
        {
            _excelManager = new ExcelManager();
            _dcList = new List<DcDto>();
        }

        public string GetReport(string filePath)
        {
            string reportHtml, rowValue, rowData;
            var dataTable = _excelManager.GetDataTable(filePath, 2);
            ParseDataTable(dataTable.Rows);

            var groupByList= _dcList.GroupBy(g => g.LineMenName);
            reportHtml = Utilities.ReadResourceContent("ReportByLineMen");
            rowValue = Utilities.ReadResourceContent("ReportByLineMenRow");
            rowData = string.Empty;
            foreach (var groupBy in groupByList)
            {
                rowData = $"{rowData}{string.Format(rowValue, groupBy.Key, groupBy.Count(), groupBy.Sum(lm => lm.ServiceAmount).ToString("#,#.##", CultureInfo.CreateSpecificCulture("hi-IN")))}";
            }
            return string.Format(reportHtml, rowData);
        }

        public string DownloadExcel(string filePath)
        {
            List<string> columns = new List<string>()
            {
                "Line Men Name",
                "Count",
                "Amount"
            };

            var dataTable = _excelManager.GetDataTable(filePath, 2);
            ParseDataTable(dataTable.Rows);
           
            _openxmlFacade = new OpenxmlFacade(Filldata, columns);
            var outputFolder = ConfigurationManager.AppSettings["ReportOutputFilePath"];
            return _openxmlFacade.CreateExcelFile(outputFolder);
        }

        private void Filldata(SheetData sheet)
        {
            var groupByList = _dcList.GroupBy(g => g.LineMenName);
            foreach (var groupBy in groupByList)
            {
                Row tRow = new Row();
                var dto = new LineMenReportDto()
                {
                    Amount = groupBy.Sum(lm => lm.ServiceAmount).ToString("#,#.##", CultureInfo.CreateSpecificCulture("hi-IN")),
                    LineMenName = groupBy.Key,
                    Count = groupBy.Count()
                };

                tRow.Append(_openxmlFacade.CreateCell(dto.LineMenName));
                tRow.Append(_openxmlFacade.CreateCell(dto.Count.ToString()));
                tRow.Append(_openxmlFacade.CreateCell(dto.Amount.ToString()));
                sheet.Append(tRow);
            }
        }

        private void ParseDataTable(System.Data.DataRowCollection allRows)
        {
            // Skip first two rows
            for (int i = 4; i < allRows.Count; i++)
            {
                _dcList.Add(new DcDto()
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

    public class LineMenReportDto
    {
        public string? LineMenName { set; get; }

        public int Count { set; get; }

        public string Amount { set; get; }

    }

}
