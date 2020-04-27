using IbmAdmissions2019.CustomAnnotation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IbmAdmissions2019.Models
{
    public class StudentViewModels
    {
        //[Required]
        [Display(Name = "Select Program")]
        public List<CheckBoxListItem> SelectedPrograms { get; set; }

        public List<ProgramsAppliedFor> programsList { get; set; }
        public String Status { get; set; }
        public int StudentId { get; set; }
        [Required]
        [Display(Name = "Name")]
        [RegularExpression("^[a-zA-Z .]*$", ErrorMessage = "Input must be Alphabets")]
        [MaxLength(50, ErrorMessage = "Field cannot be longer than 50 characters.")]
        public string name { get ; set; }
        [Required]
        [Display(Name = "Gender")]
        public int gender { get; set; }
        [Required]
        [Display(Name = "CNIC/Form-B")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Input must be numeric")]
        [MaxLength(13, ErrorMessage = "Must be a maximum of 13 characters")]
        public string cNIC { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable< DateTime> dOB { get; set; }
        [Required]
        [Display(Name = "Father's Name")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Input must be Alphabets")]
        [MaxLength(50, ErrorMessage = "Field cannot be longer than 50 characters.")]
        public string fatherName { get; set; }
        //[Required]
        [Display(Name = "Father's CNIC")]
        [MaxLength(13, ErrorMessage = "Must be a maximum of 13 characters")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Input must be numeric")]
        public string fatherCNIC { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "Field cannot be longer than 250 characters.")]
        [Display(Name = "Postal Address")]
        public string address { get; set; }
        [Required]
        [Display(Name = "Permanent Address")]
        [MaxLength(250, ErrorMessage = "Field cannot be longer than 250 characters.")]
        public string perAddress { get; set; }
        [Required]
        [Display(Name = "Religion")]
        [MaxLength(50, ErrorMessage = "Field cannot be longer than 50 characters.")]
        public string religion { get; set; }
        [Required]
        [Display(Name = "Province/Area")]
        public int province { get; set; }
        [Required]
        [Display(Name = "District")]
        public int district { get; set; }
        [Required]
        [Display(Name = "City")]
        public int city { get; set; }
        [Display(Name = "City")]
        public string cityName { get; set; }

        [Display(Name = "Gender")]
        public string genderName { get; set; }
        [Display(Name = "District")]
        public string districtName { get; set; }

        [Display(Name = "Province")]
        public string provinceName { get; set; }

        public DateTime DobForReport { get; set; }
       
       // [Required]
        [Display(Name = "Home Phone No.")]
        [RegularExpression(@"^\(?([0-9]{4})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$", ErrorMessage = "Invalid phone. e.g 04212345678")]

        public string homePhone { get; set; }
        [Required]
        [Display(Name = "Cell No.")]
        [RegularExpression(@"^\(?([0-9]{4})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$", ErrorMessage = "Invalid phone. e.g 03001234567")]
        public string cellNo { get; set; }
        [Required]
        [Display(Name = "Degree")]
        public int degree { get; set; }
        
        //[Required]
        //[Display(Name = "Intermediate Education Detail")]
        //public int educationDetailFirst { get; set; }
        //[Required]
        //[Display(Name = "Intermediate Education Detail")]
        //public int educationDetailFinal { get; set; }
        //[Display(Name = "Obtained")]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "Input must be numeric")]
        //public int firstYrMarks { get; set; }
        //[Display(Name = "Total")]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "Input must be numeric")]
        //public int firstYrTotal { get; set; }
        //[Display(Name = "Obtained")]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "Input must be numeric")]
        //public int finalMarks { get; set; }
        //[Display(Name = "Total")]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "Input must be numeric")]
        //public int finalTotal { get; set; }
        //[Required]
        //[Display(Name = "Bachelor Education Detail")]
        //public int bachEducationDetail { get; set; }
        //[Display(Name = "Obtained")]
        //[RegularExpression("^[0-9.]*$", ErrorMessage = "Input must be numeric")]
        //public decimal bachMarks { get; set; }
        //[Display(Name = "Total")]
        //[RegularExpression("^[0-9.]*$", ErrorMessage = "Input must be numeric")]
        //public decimal bachTotal { get; set; }
        //public string degreeDescription { get; set; }
        public String TrackingNumber { get; set; }
        public String RollNumber { get; set; }

        public String PicturePath { get; set; }
        public String DegreeName { get; set; }
        public String ProgramName { get; set; }

        [Display(Name = "Same As Postal Address")]
        public bool SameAddressCheck { get; set; }
        //[Display(Name = "Points Type")]
        //public int firstPointType { get; set; }
        //[Display(Name = "Points Type")]
        //public int finalPointType { get; set; }
        //[Display(Name = "Points Type")]
        //public int bachPointType { get; set; }
        //[Display(Name = "Degree is Complete")]
        //public bool firstDegreeCompleted { get; set; }
        //[Display(Name = "Degree is Complete")]
        //public bool finalDegreeCompleted { get; set; }
        //[Display(Name = "Degree is Complete")]
        //public bool bachDegreeCompleted { get; set; }
        public List<EducationItem> educations { get; set; }

    }

    public class EducationItem
    {
        public bool IsRequired { get;set;} 
        public int Id { get; set; }
        [Display(Name = "Education Detail")]
        public int educationDetail { get; set; }
        [Display(Name = "Points Type")]
        public int pointType { get; set; }
        [RequiredIf("educationDetail",true)]
        [Display(Name = "Obtained")]
        public decimal obtained { get; set; }
       
        [Display(Name = "Total")]
        public decimal total { get; set; }
        [Display(Name = "Degree is Complete")]
        public bool degreeCompleted { get; set; }
        public string label { get; set; }
        public List<SelectListItem> courseList { get; set; }
        public List<SelectListItem> pointTypeList { get; set; }

        public int EducationLevel { get; set; }
        public int EducationOrder { get; set; }

    }
    public class StudentReportViewModels
    {
        public int StudentId { get; set; }
        [Required]
        [Display(Name = "Name")]
        [RegularExpression("^[a-zA-Z .]*$", ErrorMessage = "Input must be Alphabets")]
        [MaxLength(50, ErrorMessage = "Field cannot be longer than 50 characters.")]
        public string name { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public int gender { get; set; }
        [Required]
        [Display(Name = "CNIC/Form-B")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Input must be numeric")]
        [MaxLength(13, ErrorMessage = "Must be a maximum of 13 characters")]
        public string cNIC { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dOB { get; set; }
        [Required]
        [Display(Name = "Father's Name")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Input must be Alphabets")]
        [MaxLength(50, ErrorMessage = "Field cannot be longer than 50 characters.")]
        public string fatherName { get; set; }
        //[Required]
        [Display(Name = "Father's CNIC")]
        [MaxLength(13, ErrorMessage = "Must be a maximum of 13 characters")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Input must be numeric")]
        public string fatherCNIC { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "Field cannot be longer than 250 characters.")]
        [Display(Name = "Postal Address")]
        public string address { get; set; }
        [Required]
        [Display(Name = "Permanent Address")]
        [MaxLength(250, ErrorMessage = "Field cannot be longer than 250 characters.")]
        public string perAddress { get; set; }
        [Required]
        [Display(Name = "Religion")]
        [MaxLength(50, ErrorMessage = "Field cannot be longer than 50 characters.")]
        public string religion { get; set; }
        [Required]
        [Display(Name = "Province/Area")]
        public int province { get; set; }
        [Required]
        [Display(Name = "District")]
        public int district { get; set; }
        [Required]
        [Display(Name = "City")]
        public int city { get; set; }
        [Display(Name = "City")]
        public string cityName { get; set; }

        [Display(Name = "Gender")]
        public string genderName { get; set; }
        [Display(Name = "District")]
        public string districtName { get; set; }

        [Display(Name = "Province")]
        public string provinceName { get; set; }

        public DateTime DobForReport { get; set; }

        // [Required]
        [Display(Name = "Home Phone No.")]
        [RegularExpression(@"^\(?([0-9]{4})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$", ErrorMessage = "Invalid phone. e.g 04212345678")]

        public string homePhone { get; set; }
        [Required]
        [Display(Name = "Cell No.")]
        [RegularExpression(@"^\(?([0-9]{4})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$", ErrorMessage = "Invalid phone. e.g 03001234567")]
        public string cellNo { get; set; }
        [Required]
        [Display(Name = "Degree")]
        public int degree { get; set; }
        [Required]
        [Display(Name = "Program")]
        public int program { get; set; }
        [Required]
        [Display(Name = "Intermediate Education Detail")]
        public int educationDetailFirst { get; set; }
        [Required]
        [Display(Name = "Intermediate Education Detail")]
        public int educationDetailFinal { get; set; }
        [Display(Name = "Obtained Marks in First Year")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Input must be numeric")]
        public int firstYrMarks { get; set; }
        [Display(Name = "Total Marks in First Year")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Input must be numeric")]
        public int firstYrTotal { get; set; }
        [Display(Name = "Obtained Marks in Intermediate")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Input must be numeric")]
        public int finalMarks { get; set; }
        [Display(Name = "Total Marks in Intermediate")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Input must be numeric")]
        public int finalTotal { get; set; }
        [Required]
        [Display(Name = "Bachelor Education Detail")]
        public int bachEducationDetail { get; set; }
        [Display(Name = "Obtained Marks in Bachelor")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Input must be numeric")]
        public int bachMarks { get; set; }
        [Display(Name = "Total Marks in Bachelor")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Input must be numeric")]
        public int bachTotal { get; set; }
        public string degreeDescription { get; set; }
        public String TrackingNumber { get; set; }
        public String RollNumber { get; set; }

        public String PicturePath { get; set; }
        public String DegreeName { get; set; }
        public String ProgramName { get; set; }

        [Display(Name = "Same As Postal Address")]
        public bool SameAddressCheck { get; set; }

        public String Status { get; set; }

    }

    public class QualificationViewModel
    {
        public String Degree { set; get; }
        public int Order { set; get; }
        public String Specialization { set; get; }
        public decimal TotalMarks { set; get; }
        public decimal ObtainedMarks { set; get; }
        public String DisplayTotalMarks { set; get; }
        public String DisplayObtainedMarks { set; get; }
        public int Percentage { set; get; }
    
        public int StudentId { get; set; }
    }

    
}