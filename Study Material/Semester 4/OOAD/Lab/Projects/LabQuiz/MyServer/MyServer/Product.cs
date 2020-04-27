using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyServer
{
    public class Product
    {
        private string productName;
        private string price;
        private bool isEnabled;

        public string ProductName
        {
            get
            {
                return productName;
            }

            set
            {
                productName = value;
            }
        }

        public string Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }

            set
            {
                isEnabled = value;
            }
        }
    }
}