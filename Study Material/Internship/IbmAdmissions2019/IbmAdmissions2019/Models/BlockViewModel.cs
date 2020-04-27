using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IbmAdmissions2019.Models
{
    public class BlockViewModel
    {
        public int BlockId { get; set; }
        [Required]
        public string BlockName { get; set; }
        public int TestId { get; set; }
        public int RollNumberStart { get; set; }
        public int RollNumberEnd { get; set; }
        public string Directions { get; set; }
        public int Capacity { get; set; }
    }
}