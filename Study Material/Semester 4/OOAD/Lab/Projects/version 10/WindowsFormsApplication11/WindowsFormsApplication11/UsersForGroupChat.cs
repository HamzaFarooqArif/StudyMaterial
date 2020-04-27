using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication11
{
    public partial class UsersForGroupChat : Form
    {
        public static UsersForGroupChat usersforgroupchat = null;
        public UsersForGroupChat()
        {
            InitializeComponent();
        }

        private void UsersForGroupChat_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            List<string> strnamer = new List<string>();
            Server.Service1 server = new Server.Service1();
            string[] strnamer1 = strnamer.ToArray();
            server.getUsersContacts(EnterUser.EnterUserForm.email, ref strnamer1);
            foreach(string s in strnamer1)
            {
                if (s != "")
                {
                    GroupUsers n = new GroupUsers(s);
                    flowLayoutPanel1.Controls.Add(n);
                }
            }
        }

        public void setname(string name)
        {
            lbl_me.Text = name;
        }

        private void btn_StartGroupChat_Click(object sender, EventArgs e)
        {
            if(ChatRoom.chatroom == null)
            {
                ChatRoom n = new ChatRoom();
                ChatRoom.chatroom = n;
            }
            ChatRoom.chatroom.setname(lbl_me.Text);
            ChatRoom.chatroom.Show();
            this.Hide();
        }

        private void lbl_EnterUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(EnterUser.EnterUserForm == null)
            {
                EnterUser n = new EnterUser();
                EnterUser.EnterUserForm = n;
            }
            EnterUser.EnterUserForm.Show();
            this.Hide();
        }
    }
}
