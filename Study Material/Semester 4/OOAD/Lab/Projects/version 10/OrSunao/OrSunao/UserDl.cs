using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrSunao
{
    public class UserDl
    {
        public static bool adminExist = false;
        public static Admin adminUtill = null;
        public static List<User> orSunaoMembers = new List<User>();
        public static List<User> registrationRequests = new List<User>();
        public static List<User> suspendedUsers = new List<User>();
        
    }
}