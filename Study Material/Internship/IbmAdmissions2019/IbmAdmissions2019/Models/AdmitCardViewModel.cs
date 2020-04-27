using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IbmAdmissions2019.Models
{
    public class AdmitCardViewModel
    {
        public String Name { get; set; }
        public String Cnic { get; set; }
        public String FatherName { get; set; }
        public String PhotoPath { get; set; }
        public String Degree { get; set; }
        public String Program { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String TestCenter { get; set; }
        public String Block { get; set; }
        public DateTime Slot { get; set; }
        public String TrackingNumber { get; set; }
        public String RollNumber { get; set; }
    }
}