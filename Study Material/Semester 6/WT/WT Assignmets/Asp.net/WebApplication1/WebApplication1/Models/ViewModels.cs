using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BatchViewModels
    {
        [Required]
        [RegularExpression("^[12][0-9]{3}$", ErrorMessage = "Batch must be numeric")]
        public string BatchName { get; set; }
    }
    public class CourseViewModels
    {
        [Required]
        [RegularExpression("^[a-zA-Z0-9_]{1,10}$", ErrorMessage = "Input must be alphanumeric")]
        public string CourseName { get; set; }
    }
    public class PersonEmployeeViewModels
    {
        public int ID { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Input must be Alphabets")]
        public string Name { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Input must be Alphabets")]
        public string FatherName { get; set; }
        [Required]
        [RegularExpression("^[0-9+]{5}-[0-9+]{7}-[0-9]{1}$", ErrorMessage = "Invalid CNIC e.g.12345-6789012-3")]
        public string CNIC { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"^\(?([0-9]{4})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$", ErrorMessage = "Invalid contact e.g.03001234567")]
        public string Contact { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Input must be Alphabets")]
        public string Designation { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Input must be numeric")]
        public string Salary { get; set; }

    }
    public class EmployeeCourseSemesterViewModels
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Input must be numeric")]
        public string Batch;
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Input must be numeric")]
        public string Semester { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Input must be Alphabets")]
        public string Course { get; set; }
        public int BatchID { get; set; }
        public int SemesterID { get; set; }
        public int CourseID { get; set; }

    }

    public class TimetableViewModels
    {
        public int ID { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Input must be numeric")]
        public string Semester { get; set; }
        public string Batch { get; set; }
        public string isDatesheet { get; set; }
        public int BatchID { get; set; }
        public int SemesterID { get; set; }
    }
    public class TimeslotViewModels
    {
        public int ID { get; set; }
        public int WorkingDayID { get; set; }
        public int StartEndTime { get; set; }

        public int BatchID { get; set; }
        public int SemesterID { get; set; }
        public int CourseID { get; set; }
        [Required]
        public int EmployeeID { get; set; }
        public int TimetableID { get; set; }


    }
    public class TimeslotDeleteViewModels
    {
        public string Batch { get; set; }
        public string Semester { get; set; }
        public string Course { get; set; }
        public string Employee { get; set; }
        public string WorkingDay { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int TimetableID { get; set; }
    }
    public class ReportViewModels
    {
        public int ID { get; set; }
        public string ReportName { get; set; }
        public string param { get; set; }

        public ReportViewModels(int id, string ReportName)
        {
            this.ID = id;
            this.ReportName = ReportName;
        }

        public ReportViewModels()
        {
            this.ID = 0;
            this.ReportName = "";

        }
    }
}