using ReadFromExcelSB.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace ReadFromExcelSB.Managers
{
    internal class ReportByLineMenManager
    {
        public List<LineMenReport> GetReport(List<DcDto> dcList)
        {
            var groupByList = dcList.GroupBy(g => g.LineMenName);
            var reportData = new List<LineMenReport>();
            foreach (var groupBy in groupByList)
            {
                reportData.Add(new LineMenReport()
                {
                    LineMenName = groupBy.Key,
                    TotalAmount = groupBy.Sum(lm => lm.ServiceAmount),
                    NumberOfServices = groupBy.Count()
                });
            }

            return reportData;

        }

    }

    public class LineMenReport
    {
        public string? LineMenName { get; set; }

        public double TotalAmount { set; get; }

        public int NumberOfServices { get; set; }
    }
}
