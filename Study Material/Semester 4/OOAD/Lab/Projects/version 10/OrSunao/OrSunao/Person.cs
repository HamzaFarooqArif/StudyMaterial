using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrSunao
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private string password;
        private string contactNumber;
        private string cNIC;
        private string email;

        protected string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        protected string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        protected string ContactNumber
        {
            get
            {
                return contactNumber;
            }

            set
            {
                contactNumber = value;
            }
        }

        protected string CNIC
        {
            get
            {
                return cNIC;
            }

            set
            {
                cNIC = value;
            }
        }

        protected string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
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
    }
}