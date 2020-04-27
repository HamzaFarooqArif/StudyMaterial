using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IbmAdmissions2019.Models
{
    public class TestCenterViewModel
    {
        public int CenterId { get; set; }
        public string CenterName { get; set; }
        public int BlockId { get; set; }
        public string Directions { get; set; }
        public int Capacity { get; set; }
    }
}