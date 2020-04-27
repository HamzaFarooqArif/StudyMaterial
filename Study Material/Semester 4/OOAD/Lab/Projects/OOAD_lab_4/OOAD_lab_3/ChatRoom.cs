using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAD_lab_3
{
    class ChatRoom
    {
        private User GroupAdmin;
        private List<User> UserList;
        private int UserLimit;

        internal User GroupAdmin1
        {
            get
            {
                return GroupAdmin;
            }

            set
            {
                GroupAdmin = value;
            }
        }

        internal List<User> UserList1
        {
            get
            {
                return UserList;
            }

            set
            {
                UserList = value;
            }
        }

        public int UserLimit1
        {
            get
            {
                return UserLimit;
            }

            set
            {
                UserLimit = value;
            }
        }
    }
}
