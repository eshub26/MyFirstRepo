using ReadFromExcelSB.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using ReadFromExcelSB.Helpers;
using System.Globalization;

namespace ReadFromExcelSB.Managers
{
    internal class ReportByLineMenManager
    {
        public string GetReport(List<DcDto> dcList)
        {
            string reportHtml = Utilities.ReadResourceContent("ReportByLineMen");
            string rowValue = Utilities.ReadResourceContent("ReportByLineMenRow");
            string rowData = string.Empty;
            var groupByList = dcList.GroupBy(g => g.LineMenName);
            foreach (var groupBy in groupByList)
            {
                rowData =$"{rowData}{string.Format(rowValue, groupBy.Key, groupBy.Count(), groupBy.Sum(lm => lm.ServiceAmount).ToString("#,#.##", CultureInfo.CreateSpecificCulture("hi-IN")))}" ;
            }

            return string.Format( reportHtml, rowData);

        }

    }

    //public class LineMenReport
    //{
    //    public string? LineMenName { get; set; }

    //    public double TotalAmount { set; get; }

    //    public int NumberOfServices { get; set; }
    //}
}
