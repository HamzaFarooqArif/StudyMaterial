using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace OOAD_lab_3
{
    class User
    {
        private string userName;
        private string password;
        private string secretQuestion;
        private string answer;
        private List<Contact> contacts = new List<Contact>();
        private List<Product> products = new List<Product>();
        private int totalProducts;

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string Answer
        {
            get
            {
                return answer;
            }

            set
            {
                answer = value;
            }
        }

        public string SecretQuestion
        {
            get
            {
                return secretQuestion;
            }

            set
            {
                secretQuestion = value;
            }
        }

        internal List<Contact> Contacts
        {
            get
            {
                return contacts;
            }

            set
            {
                contacts = value;
            }
        }

        internal List<Product> Products
        {
            get
            {
                return products;
            }

            set
            {
                products = value;
            }
        }

        public int TotalProducts
        {
            get
            {
                return totalProducts;
            }

            set
            {
                totalProducts = value;
            }
        }
    }
}
