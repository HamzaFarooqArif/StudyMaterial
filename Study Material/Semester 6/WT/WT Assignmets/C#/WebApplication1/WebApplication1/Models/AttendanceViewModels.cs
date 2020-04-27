using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class AttendanceViewModels
    {
        public int ID { get; set; }
        [Required]
        [Display(Name ="Batch")]
        public int BatchID { get; set; }
        [Display(Name ="Students List")]
        public int StudentID { get; set; }

        [Required]
        [Display(Name ="Attendance Date")]
        [DataType(DataType.DateTime)]
        public DateTime AtdDate { get; set; }
        public string AtdStatus { get; set; }
        public int CourseSemesterID { get; set; }
        public bool IsChecked { get; set; }
        [Display(Name ="Course")]
        public int course { get; set; }
        [Display(Name ="Semester")]
        public int semester { get; set; }
    }
}