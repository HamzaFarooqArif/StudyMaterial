using System;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace OrSunao
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public void addusertogroup(string myemail, string hisemail)
        {
            User u = new User();
            u = u.getUserByEmail(myemail);
            User k = new User();
            k = k.getUserByEmail(hisemail);
            u.groupUsers.Add(k);
        }
        public void getUsersgroupContacts(string email, ref List<string> str)
        {
            User k = new User();
            k = k.getUserByEmail(email);
            foreach(User u in k.groupUsers)
            {
                str.Add(u.getEmail());
            }
        }
        
        public bool SIsOfflineUser(string myemail)
        {
            User k = new User();
            k = k.getUserByEmail(myemail);
            return !k.Isonline;
        }
        public void SOfflineUser(string myemail)
        {
            User k = new User();
            k = k.getUserByEmail(myemail);
            k.Isonline = false;
        }
        public bool SConnectwithuser(string myemail,string hisemail)
        {
            User n = new User();
            n = n.getUserByEmail(hisemail);
            if(n.Isonline == true)
            {
                User k = new User();
                k = k.getUserByEmail(myemail);
                k.contacts.Add(n);
                return true;
            }
            return false;
        }
        public void getUsersContacts(string email, ref List<string> str)
        {
            string p = "";
            foreach(User k in UserDl.orSunaoMembers)
            {
                p = k.getEmail();
                if (p != email)
                {
                    str.Add(p);
                }
            }
            User i = new User();
            i = i.getUserByEmail(email);
            foreach(User l in i.blockedUsers)
            {
                str.Remove(l.getEmail());
            }
        }

        public bool SSuspendUser(string email, string password)
        {
            User k = new User();
            k = k.getuserfromr(email, password);
            return UserDl.adminUtill.suspenduser(k);
        }
        public bool SDeleteUser(string email, string password)
        {
            User k = new User();
            k = k.getuserfromr(email, password);
            return UserDl.adminUtill.DeleteUser(k);
        }
        public bool SPassUser(string email, string password)
        {
            User k = new User();
            k = k.getuser(email, password);
            return UserDl.adminUtill.ApproveRegistration(k);
        }
        public void SPassRegisteredUsersname(ref List<string> str)
        {
            
           
            foreach(User u in UserDl.orSunaoMembers)
            {
                str.Add(u.getEmail());
            }
            return;
        }
        public void SPassRegisteredUserspassword(ref List<string> str)
        {
            

            foreach (User u in UserDl.orSunaoMembers)
            {
                str.Add(u.getPassword());
            }
            return;
        }



        public void SPassSuspendedUsersname(ref List<string> str)
        {
          

            foreach (User u in UserDl.suspendedUsers)
            {
                str.Add(u.getEmail());
            }
            return;
        }
        public void SPassSuspendedUserspassword(ref List<string> str)
        {

            foreach (User u in UserDl.suspendedUsers)
            {
                str.Add(u.getPassword());
            }
            return;
        }


        public void SPassToBeRegisteredUsersname(ref List<string> str)
        {
            foreach (User u in UserDl.registrationRequests)
            {
                str.Add(u.getEmail());
            }
            return;
        }
        public void SPassToBeRegisteredUserspassword(ref List<string> str)
        {
          

            foreach (User u in UserDl.registrationRequests)
            {
                str.Add(u.getPassword());
            }
            return;
        }
        public bool SRegisterUser(string firstname, string lastname, string password, string email, string contact, string cnic, string secretq, string ans)
        {
            bool isregister;
            User u = new User();
            isregister = u.registeruser(firstname, lastname, password, email, contact, cnic, secretq, ans);
            return isregister;
        }
        public bool SLoginUser(string email, string password)
        {
            User n = new User();
            return n.loginuser(email, password);
        }

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

        public bool SRegisterAdmin(string UserFirstName, string UserLastName, string Password, string Email, string CNIC, string Contact)
        {
            if (UserDl.adminExist == false)
            {
                bool isregister;
                Admin a = new Admin();
                isregister = a.RegisterAdmin(UserFirstName, UserFirstName, Password, Email, CNIC, Contact);
                return isregister;
            }
            return false;
           
        }

        public bool SLoginAdmin(string Email, string Password)
        {
            bool isregister;
   
            Admin a1 = new Admin();
            isregister = a1.LoginAdmin(Email, Password);
            if(isregister)
            {
           
                    return true;
       
            }
            return false;
        }

        public bool DeactivateMyAccount(string email, string password)
        {
            User k = new User();
            k = k.getuserfromr(email, password);
            UserDl.orSunaoMembers.Remove(k);
            return true;
        //    foreach (User u in UserDl.orSunaoMembers)
        //    {
        //        if (u.getEmail() == email && u.getPassword() == password)
        //        {
        //            break;
        //        }
        //        idx++;
        //    }

        //    if (idx > 0)
        //    {
        //        UserDl.orSunaoMembers.RemoveAt(idx);
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        }

        public void AddToContacts(string myEmail, string myPassword, string hisEmail, string hisPassword)
        {
            User me = new User();
            me = me.getuserfromr(myEmail, myPassword);

            User he = new User();
            he = he.getuserfromr(hisEmail, hisPassword);

            me.contacts.Add(he);

        }

        public void AddToBlockedUsers(string myEmail, string hisEmail)
        {
            User me = new User();
            me = me.getUserByEmail(myEmail);

            User he = new User();
            he = he.getUserByEmail(hisEmail);

            me.blockedUsers.Add(he);
        }

        public void setChatToText(string Email, string msg)
        {
            User u = new User();
            u = u.getUserByEmail(Email);
            u.CurrentText = msg;
        }

        public void setChatToEmpty(string Email)
        {
            User u = new User();
            u = u.getUserByEmail(Email);
            u.CurrentText = "";
        }

        public void getChatText(string Email, ref string msg)
        {
            User u = new User();
            u = u.getUserByEmail(Email);
            msg = u.CurrentText;
        }

        public void isConnected(string Email, ref bool connected)
        {
            User u = new User();
            u = u.getUserByEmail(Email);
            connected = u.IsConnected;
        }

        public void setConnected(string Email, bool connected)
        {
            User u = new User();
            u = u.getUserByEmail(Email);
            u.IsConnected = connected;


            bool test = u.IsConnected;

        }


        public void setChatToImage(string Email, byte[] img, int length)
        {
            User u = new User();
            u = u.getUserByEmail(Email);
            u.Image = new byte[length];
            u.Image = img;
        }
        public int getimagelength(string email)
        {
            User u = new User();
            u = u.getUserByEmail(email);
            return u.Image.Length;
        }
        public void setImageToEmpty(string Email)
        {
            User u = new User();
            u = u.getUserByEmail(Email);
            u.Image = null;
        }

        public void getChatImage(string Email, ref byte[] img)
        {
            User u = new User();
            u = u.getUserByEmail(Email);
            img = u.Image;
        }
        public bool checkimage(string email)
        {
            User u = new User();
            u = u.getUserByEmail(email);
            if(u.Image != null)
            {
                return true;
            }
            return false;
        }

        public void setGroupChatText(string Email, string msg)
        {
            User u = new User();
            u = u.getUserByEmail(Email);
            u.CurrentChatRoomText.Add(msg);
        }

        public void setGroupChatToEmpty(string Email)
        {
            User u = new User();
            u = u.getUserByEmail(Email);
            u.CurrentChatRoomText.Clear();
        }

        public void getGroupChatText(string Email, ref List<string> str)
        {
            foreach(User u in UserDl.orSunaoMembers)
            {
                if(u.getEmail() == Email)
                {
                    str = u.CurrentChatRoomText;
                }
            }
        }

    }
}
