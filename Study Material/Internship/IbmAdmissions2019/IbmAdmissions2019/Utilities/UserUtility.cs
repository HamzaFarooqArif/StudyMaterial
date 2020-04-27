using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IbmAdmissions2019.Utilities
{
    public class UserUtility
    {
        private IbmAdmissions2019Entities db;
        private static UserUtility _instance;

        private UserUtility()
        {
            db = new IbmAdmissions2019Entities();
        }
        public static UserUtility getInstance()
        {
            if (_instance == null)
                _instance = new UserUtility();
            return _instance;
        }

        public String getUserRole(String userName)
        {
            var user = db.AspNetUsers.Where(a => a.UserName.Equals(userName)).FirstOrDefault();

            if (user != null)
            {
                var role = user.AspNetRoles.First();
                return role.Name;
            }


            return "";
        }

        public String getUserEmail(String userName)
        {
            var user = db.AspNetUsers.Where(a => a.UserName.Equals(userName)).FirstOrDefault();

            if (user != null)
            {
                return user.Email;
            }


            return "";
        }

        public void UserLogin(String userName)
        {
            String userId = db.AspNetUsers.Where(a => a.UserName.Equals(userName)).FirstOrDefault().Id;
            UserLoginHistory hist = new UserLoginHistory();
            hist.LoginTime = DateTime.Now;
            hist.UserId = userId;
            db.UserLoginHistories.Add(hist);
            db.SaveChanges();
        }
    }
}