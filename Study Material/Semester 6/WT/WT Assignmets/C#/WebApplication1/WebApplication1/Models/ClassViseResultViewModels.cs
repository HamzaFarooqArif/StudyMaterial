using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ClassViseResultViewModels
    {

        [Required]
        [Display(Name ="Batch")]
        public int BatchID { get; set; }
        public string Batch { get; set; }
        [Display(Name = "Semester")]
        public int SemesterID { get; set; }

        public string Semester { get; set; }

        [Display(Name = "Course")]
        public int CourseID { get; set; }




    }
}