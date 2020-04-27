using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ResultViewModels
    {
        public int ID { get; set; }
        [Required]
        [Display(Name="Batch")]
        public int BatchID { get; set; }
        [Display(Name ="Semester")]
        public int semesterID { get; set; }

        [Display(Name ="Course")]
        public int courseID { get; set; }

        [Display(Name ="Registration Number")]
        public int StudentID { get; set; }
        public int  CourseSemesterID { get; set; }

        public string Semester { get; set; }

        
        public string RegNo { get; set; }
        public string Name { get; set; }

        public string Batch { get; set; }

        public string Course { get; set; }
        [Required]
        [Display(Name ="Total Marks")]
        public string TotalMarks { get; set; }
        [Required]
        [Display(Name ="Obtained Marks")]
        public string ObtainedMarks { get; set; }
        
    }
}