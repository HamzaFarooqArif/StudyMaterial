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
    public partial class ChatRoom : Form
    {
        public static ChatRoom chatroom = null;
        public ChatRoom()
        {
            InitializeComponent();


        }

        public void setname(string name)
        {
            lbl_me.Text = name;
        }

        private void ChatRoom_Load(object sender, EventArgs e)
        {
            ChatRoom.chatroom = this;

            Timer timer = new Timer();
            timer.Interval = (1 * 1000); // 10 secs
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            List<string> strnamer = new List<string>();
            Server.Service1 server = new Server.Service1();
            string[] strnamer1 = strnamer.ToArray();
            server.getUsersgroupContacts(EnterUser.EnterUserForm.email, ref strnamer1);
            int i = strnamer1.Length;
          
            if(i > 0 && strnamer1[0] != "\0")
            {
                lbl1_Email.Text = strnamer1[0];
                if (i > 1 && strnamer1[1] != "\0")
                {
                    lbl2_Email.Text = strnamer1[1];
                    if (i > 2 && strnamer1[2] != "\0")
                    {
                        lbl3_Email.Text = strnamer1[2];
                        if (i > 3 && strnamer1[3] != "\0")
                        {
                            lbl4_Email.Text = strnamer1[3];
                        }
                        else
                        {
                            lbl4_Email.Text = " ";
                        }
                    }
                    else
                    {
                        lbl3_Email.Text = " ";
                        lbl4_Email.Text = " ";
                    }

                }
                else
                {
                    lbl2_Email.Text = " ";
                    lbl3_Email.Text = " ";
                    lbl4_Email.Text = " ";
                }

            }
            else
            {
                lbl1_Email.Text = " ";
                lbl2_Email.Text = " ";
                lbl3_Email.Text = " ";
                lbl4_Email.Text = " ";
            }

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Server.Service1 server = new Server.Service1();
            server.setConnected(lbl_me.Text, true, true);
            List<string> messagesList = new List<string>();
            string[] messagesArray = messagesList.ToArray();
            server.getGroupChatText(lbl_me.Text, ref messagesArray);

            foreach(string message in messagesArray)
            {
                string actualMessage = "";
                string userName = "";
                bool flipFlag = false;
                
                foreach(char chr in message)
                {
                    if (flipFlag) userName += chr;
                    if (chr == '^') flipFlag = true;
                    if(!flipFlag) actualMessage += chr;
                }

                msg n = new msg(actualMessage, userName);
                flowLayoutPanel1.Controls.Add(n);
                flowLayoutPanel1.ScrollControlIntoView(n);
            }
            server.setGroupChatToEmpty(lbl_me.Text);
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            if(EnterUser.EnterUserForm == null)
            {
                EnterUser n = new EnterUser();
                EnterUser.EnterUserForm = n;
            }
            EnterUser.EnterUserForm.Show();
            this.Hide();
        }

        private void btn_AddUsers_Click(object sender, EventArgs e)
        {
            if (UsersForGroupChat.usersforgroupchat == null)
            {
                UsersForGroupChat n = new UsersForGroupChat();
                UsersForGroupChat.usersforgroupchat = n;
            }
            UsersForGroupChat.usersforgroupchat.Show();
            this.Hide();
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            if(txt_Message.Text != "")
            {
                string message = txt_Message.Text;
                message += "^";
                message += lbl_me.Text;

                Server.Service1 server = new Server.Service1();

                if (lbl1_Email.Text != "")
                {
                    server.setGroupChatText(lbl1_Email.Text, message);
                }

                if (lbl2_Email.Text != "")
                {
                    server.setGroupChatText(lbl2_Email.Text, message);
                }

                if (lbl3_Email.Text != "")
                {
                    server.setGroupChatText(lbl3_Email.Text, message);
                }

                if (lbl4_Email.Text != "")
                {
                    server.setGroupChatText(lbl4_Email.Text, message);
                }



                msg my = new msg(txt_Message.Text, EnterUser.EnterUserForm.email);
                flowLayoutPanel1.Controls.Add(my);
                flowLayoutPanel1.ScrollControlIntoView(my);
                txt_Message.Clear();  
            }

        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            List<string> strnamer = new List<string>();
            Server.Service1 server = new Server.Service1();
            string[] strnamer1 = strnamer.ToArray();
            server.getUsersgroupContacts(EnterUser.EnterUserForm.email, ref strnamer1);
            int i = strnamer1.Length;

            if (i > 0 && strnamer1[0] != "\0")
            {
                lbl1_Email.Text = strnamer1[0];
                if (i > 1 && strnamer1[1] != "\0")
                {
                    lbl2_Email.Text = strnamer1[1];
                    if (i > 2 && strnamer1[2] != "\0")
                    {
                        lbl3_Email.Text = strnamer1[2];
                        if (i > 3 && strnamer1[3] != "\0")
                        {
                            lbl4_Email.Text = strnamer1[3];
                        }
                        else
                        {
                            lbl4_Email.Text = " ";
                        }
                    }
                    else
                    {
                        lbl3_Email.Text = " ";
                        lbl4_Email.Text = " ";
                    }

                }
                else
                {
                    lbl2_Email.Text = " ";
                    lbl3_Email.Text = " ";
                    lbl4_Email.Text = " ";
                }

            }
            else
            {
                lbl1_Email.Text = " ";
                lbl2_Email.Text = " ";
                lbl3_Email.Text = " ";
                lbl4_Email.Text = " ";
            }
        }
    }
}
