using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IbmAdmissions2019.Utilities
{
    public class PlaceUtility
    {
        private static PlaceUtility _instance;
        public static PlaceUtility getInstance()
        {
            if (_instance == null)
                _instance = new PlaceUtility();
            return _instance;
        }

        
    }
}