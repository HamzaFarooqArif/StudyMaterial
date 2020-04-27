using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MyServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public bool isValidUser(string userName, string password)
        {
            bool isFound = false;
            foreach (MyUser u in MyUtil.users) {
                if (u.Password == password && u.UserName == userName) {
                    isFound = true;
                }
            }
            return isFound;
        }

        public bool registerUser(string userName, string password)
        {
            MyUser u = new MyUser();
            u.UserName = userName;
            u.Password = password;
            MyUtil.users.Add(u);
            return true;
        }

        public void AddProduct(string productName, string price, bool isEnabled)
        {
            Product p = new Product();
            p.ProductName = productName;
            p.Price = price;
            p.IsEnabled = isEnabled;

            Products.productList.Add(p);
        }

        public void GetProductList(ref List<string> prodctsName, ref List<string> prodctsPrice, ref List<string> productsIsEnabled)
        {
            foreach(Product p in Products.productList)
            {
                prodctsName.Add(p.ProductName);
                prodctsPrice.Add(p.Price);
                if(p.IsEnabled)
                {
                    productsIsEnabled.Add("1");
                }
                else
                {
                    productsIsEnabled.Add("0");
                }
            }
        }
    }
}
