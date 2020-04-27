using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PersonViewModels
    {
        public int ID { get; set; }
        [Required]
        [RegularExpression("^[0-9+]{5}-[0-9+]{7}-[0-9]{1}$", ErrorMessage = "Invalid CNIC e.g.12345-6789012-3")]
        public string CNIC { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Input must be Alphabets")]
        public string Name { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Input must be Alphabets")]
        [Display(Name ="Father Name")]
        public string FatherName { get; set; }
        public string Address { get; set; }

        [Required]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Enter Valid Conact")]
        public string Contact { get; set; }

    }
}