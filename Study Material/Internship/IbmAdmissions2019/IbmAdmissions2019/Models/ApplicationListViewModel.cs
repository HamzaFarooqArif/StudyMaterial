using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IbmAdmissions2019.Models
{
    public class ApplicationListViewModel
    {

        public string CNIC { get; set; }
        public string Program { get; set; }

        [Display(Name="Tracking Number")]
        public int TrackingNumber { get; set; }
        public int id { get; set; }
        public string Name { get; set; }
        [Display(Name="Payment Status")]
        public string PaymentStatus { get; set; }
    }
}