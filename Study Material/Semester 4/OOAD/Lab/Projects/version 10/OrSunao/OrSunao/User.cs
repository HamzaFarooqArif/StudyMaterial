using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace OrSunao
{
    public class User: Person
    {
        private string secretQuestion;
        private string answer;
        private string message;
        private bool isonline = false;
        private bool isBlocked;
        private bool isConnected;
        private string currentText;
        private byte[] image;
        private List<string> currentChatRoomText = new List<string>();
        public List<User> contacts = new List<User>();
        public List<User> blockedUsers = new List<User>();
        public List<User> groupUsers = new List<User>();




        public string getPassword()
        {
            return this.Password;
        }

        public string getEmail()
        {
            return this.Email;
        }
        public User getuserfromr(string email, string password)
        {
            User p = new User();
            foreach (User k in UserDl.orSunaoMembers)
            {
                if (k.Email == email && k.Password == password)
                {
                    p = k;
                    break;
                }
            }
            return p;
        }
        public User getuser(string email, string password)
        {
            User p = new User();
            foreach(User k in UserDl.registrationRequests)
            {
                if(k.Email == email && k.Password == password)
                {
                    p = k;
                    break;
                }
            }
            return p;
        }

        public bool registeruser(string firstname, string lastname,string password, string email, string contact, string cnic, string secretq, string ans)
        {
            foreach(User u in UserDl.suspendedUsers)
            {
                if(u.Email == email && u.Password == password)
                {
                    return false;
                }
            }
            if (UserDl.orSunaoMembers != null)
            {
                foreach (User k in UserDl.orSunaoMembers)
                {
                    if (k.Email == email || k.Password == password)
                    {
                        return false;
                    }
                }
            }
            if (UserDl.registrationRequests != null)
            {
                foreach (User k in UserDl.registrationRequests)
                {
                    if (k.Email == email || k.Password == password)
                    {
                        return false;
                    }
                }
            }

            this.FirstName = firstname;
            this.LastName = lastname;
            this.Password = password;
            this.Email = email;
            this.ContactNumber = contact;
            this.CNIC = cnic;
            this.SecretQuestion = secretq;
            this.Answer = ans;
            UserDl.registrationRequests.Add(this);
            return true;
        }
        public bool loginuser(string email, string password)
        {
            foreach (User u in UserDl.orSunaoMembers)
            {
                if (u.Password == password && u.Email == email)
                {
                    this.FirstName = u.FirstName;
                    this.LastName = u.LastName;
                    this.Password = u.Password;
                    this.Email = u.Email;
                    this.ContactNumber = u.ContactNumber;
                    this.CNIC = u.CNIC;
                    this.SecretQuestion = u.SecretQuestion;
                    this.Answer = u.Answer;
                    u.Isonline = true;
                    this.Isonline = u.Isonline;
                    return true;
                }
            }
            return false;
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

        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
            }
        }

        public bool IsBlocked
        {
            get
            {
                return isBlocked;
            }

            set
            {
                isBlocked = value;
            }
        }

        public bool Isonline
        {
            get
            {
                return isonline;
            }

            set
            {
                isonline = value;
            }
        }

        public string CurrentText
        {
            get
            {
                return currentText;
            }

            set
            {
                currentText = value;
            }
        }

        public bool IsConnected
        {
            get
            {
                return isConnected;
            }

            set
            {
                isConnected = value;
            }
        }

        public byte[] Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
            }
        }

        public List<string> CurrentChatRoomText
        {
            get
            {
                return currentChatRoomText;
            }

            set
            {
                currentChatRoomText = value;
            }
        }

        public User getUserByEmail(string email)
        {
            User p = new User();
            foreach (User k in UserDl.orSunaoMembers)
            {
                if (k.Email == email)
                {
                    p = k;
                    break;
                }
            }
            return p;
        }

     
    }
}