using System;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication11
{
    public partial class chatbox : Form
    {
        public static chatbox chatboxform = null;
        public chatbox()
        {
            InitializeComponent();
        }
        public void setmyname(string m)
        {
            lbl_me.Text = m;
        }
        public void sethisname(string m)
        {
            lbl_connecteduser.Text = m; 
        }
        //----------------------------------------------------------------
        private void chatbox_Load(object sender, EventArgs e)
        {
            chatbox.chatboxform = this;
            

            Timer timer = new Timer();
            timer.Interval = (1 * 1000); // 10 secs
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            string message = "";
            Server.Service1 server = new Server.Service1();
            server.setConnected(lbl_me.Text, true, true);
            server.getChatText(lbl_me.Text, ref message);
            if (!(message == ""))
            {
                msg n = new msg(message, lbl_connecteduser.Text);
                flowLayoutPanel1.Controls.Add(n);
                flowLayoutPanel1.ScrollControlIntoView(n);
                server.setChatToEmpty(lbl_me.Text);
            }
            bool ispassed;
            bool passed;
            server.checkimage(lbl_me.Text, out passed, out ispassed);
            if (passed)
            {
                int length;
                server.getimagelength(lbl_me.Text, out length, out ispassed);
                byte[] array = new byte[length];
                server.getChatImage(lbl_me.Text,ref array);
                Image img = byteArrayToImage(array);
                imagemsg p = new imagemsg(lbl_connecteduser.Text, img);
                flowLayoutPanel1.Controls.Add(p);
                flowLayoutPanel1.ScrollControlIntoView(p);
                server.setImageToEmpty(lbl_me.Text);
            }
        }
        //----------------------------------------------------------------

        private void btn_send_Click(object sender, EventArgs e)
        {
            Server.Service1 server = new Server.Service1();
            bool ispassed, passed;
            server.SIsOfflineUser(lbl_connecteduser.Text, out passed, out ispassed);
            if(ispassed)
            {
                if(passed)
                {
                    MessageBox.Show("oops your friend has gone ! talk to u later :'D");
                    EnterUser.EnterUserForm.Show();
                    this.Hide();
                }
                else
                {
                    bool isHeConnected = false;
                    bool isHeConnectedPassed = false;
                    server.isConnected(lbl_connecteduser.Text, ref isHeConnected, ref isHeConnectedPassed);
                    if(isHeConnected)
                    {
                        server.setChatToText(lbl_connecteduser.Text, txt_message.Text);
                        if(!(txt_message.Text == ""))
                        {
                            msg n = new msg(txt_message.Text, lbl_me.Text);
                            flowLayoutPanel1.Controls.Add(n);
                            flowLayoutPanel1.ScrollControlIntoView(n);
                        }

                    }
                    else
                    {
                        MessageBox.Show("User not connected");
                    }
                    
                    /*msg n = new msg(txt_message.Text);
                    flowLayoutPanel1.Controls.Add(n);*/
                    txt_message.Clear();

                    
                }
            }
           
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
           
            EnterUser.EnterUserForm.Show();
            this.Hide();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            
        }

        private void btn_sendimage_Click(object sender, EventArgs e)
        {
            opendirectory.ShowDialog();
        }

        private void opendirectory_FileOk(object sender, CancelEventArgs e)
        {
            Image img = Image.FromStream(opendirectory.OpenFile());
            byte[] myarray = imageToByteArray(img);
            int i = myarray.Length;
            Server.Service1 server = new Server.Service1();
            try
            {
                server.setChatToImage(lbl_connecteduser.Text, myarray, i, true);
                imagemsg n = new imagemsg(lbl_me.Text, img);
                flowLayoutPanel1.Controls.Add(n);
                flowLayoutPanel1.ScrollControlIntoView(n);
            }
            catch(Exception)
            {
                MessageBox.Show("too big file !");
                this.Show();
            }
                
            
        }
        public byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
