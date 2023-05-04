using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFromExcelSB.DTO
{
    internal class DcDto
    {
        public int SlNumber { set; get; }

        public string? Section { set; get; }

        public string? LineMenName { set; get; }

        public string? Location { set; get; }

        public string? ServiceNumber { set; get; }

        public string? Category { set; get; }

        public double ServiceAmount { set; get; }


        public DateTime? PaidDate { set; get; }

        public double PaidAmount { set; get; }

        public string? PaidPRNumner { set; get; }

        public string? Remarks { set; get; }




    }
}
