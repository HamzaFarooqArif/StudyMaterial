using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WebApplication1.Models
{
    public class StudentViewModels:PersonViewModels
    {
        public int PersonID { get; set; }
        [Required]
        
        [Display(Name = "Registration Number")]
       //[RegularExpression("^(?([1-9]{1}))?([0-9]{3})[-]([A-Z]{2,3})[-]([0-9]{1,4})$", ErrorMessage ="Enter valid registration number e.g. 1234-CS-123" )]
        public string RegNo { get; set; }
        [Required]
        [StringLength(6, ErrorMessage ="Enter Valid Fee")]
        public string Fee { get; set; }
        [Required]
        public int Batch { get; set; }
        [Required]
        public int Semester { get; set; }

        public string BatchName { get; set; }

        public string SemesterNo { get; set; }

        public static bool validateRegistration(string Registration)
        {
            if (string.IsNullOrEmpty(Registration))
                return false;
            var r = new Regex(@"^\(?([1-9]{1})\)?([0-9]{3})[-]([A-Z]{2,3})[-]([0-9]{1,4})$");
            return r.IsMatch(Registration);
        }    /// <summary>
             /// Check for the validity of the Registration Number.
             /// </summary>
             /// <param name="value"> String in string.Format style. It is the string whose format is checked. </param>
             /// <returns> return true or false </returns>
        public bool IsValidRegNumber(string value)
        {
            if (value.Length == 11)
            {
                string first = value.Substring(0, 4);
                string second = value.Substring(4, 1);
                string third = value.Substring(5, 2);
                string fourth = value.Substring(7, 1);
                string fifth = value.Substring(8, 3);
                foreach (char c in first)
                {
                    if (!char.IsDigit(c))
                    {
                        return false;
                    }
                }
                foreach (char c in third)
                {
                    if (!char.IsLetter(c))
                    {
                        return false;
                    }
                }
                foreach (char c in fifth)
                {
                    if (!char.IsDigit(c))
                    {
                        return false;
                    }
                }
                if (second != "-" && fourth != "-")
                {
                    return false;
                }
                return true;
            }
            return false;
        }

    }
}