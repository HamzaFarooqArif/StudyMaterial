using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVWebApp.Models
{
    public class PhotoClassViewModels
    {
        public string path { get; set; }
        public String imageData { get; set; }
        public ParameterItem parameters { get; set; }
    }

    public class ParameterItem
    {
        public int param1 { get; set; }
        public int param2 { get; set; }
        public int param3 { get; set; }
    }
}