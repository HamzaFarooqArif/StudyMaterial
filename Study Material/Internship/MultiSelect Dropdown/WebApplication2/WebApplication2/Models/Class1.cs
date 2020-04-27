using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    public class Class1
    {
        public List<CheckBoxListItem> program { get; set; }
        public List<SampleItem> samples { get; set; }
        public int val { get; set; }
        public bool Ischange { get; set; }

        public String data { get; set; }
        public String button { get; set; }
        public List<SelectListItem> Select { get; set; }

    }

    public class CheckBoxListItem
    {
      
        public int ID { get; set; }
        public string Display { get; set; }
        public bool IsChecked { get; set; }
    }

    public class SampleItem
    {
        public int Id { get; set; }
        public String first { get; set; }
        public string second { get; set; }
        public string third { get; set; }
    }
}