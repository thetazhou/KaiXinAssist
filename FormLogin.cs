using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace KaiXinAssist
{
    public partial class FormLogin : Form
    {
        KaixinHelper　kh = new KaixinHelper(); //声明全局性的开心网连接对象

        public FormLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 取消登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoginCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

　
        /// <summary>
        /// 拖动效果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0); 
        }

        /// <summary>
        /// 初始化连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormLogin_Load(object sender, EventArgs e)
        {
            KaixinHelper.Init();
           // System.Threading.Thread.Sleep(3000);
            bool isInit = KaixinHelper.Init();
            if (isInit == false)
            {
                MessageBox.Show("连接网络出错，请确认网络正常！");
                this.Dispose();
            }
            else
            {
                StreamReader sr = new StreamReader(Application.StartupPath + "\\user", System.Text.Encoding.UTF8);
                string content = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();
                content = Encrypt.DecryptDES(content, "19880808");
                if (content != "")
                {
                    txtUserName.Text = content.Substring(0, content.IndexOf("\n"));
                    txtPassword.Text = content.Substring(content.IndexOf("\n") + 1, content.Length - (content.IndexOf("\n") + 1));
                    chkSave.Checked = true;
                }
            }
        }


        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoginOk_Click(object sender, EventArgs e)
        {
            try
            {

                KaixinHelper.username = txtUserName.Text;
                KaixinHelper.password = txtPassword.Text;
                bool isLoginSuccess = kh.LoginIndex();

                if (isLoginSuccess)
                {
                    SaveLoginMessage();
                    FormFriend formFriend = new FormFriend();
                    formFriend.Show();
                }
                else
                {
                    MessageBox.Show("登录失败，请确认用户名及密码是否正确！");
                  
                }

            }
            catch
            {

            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnLoginOk_Click(this, e);
            }
        }


        private void SaveLoginMessage()
        {
            if (chkSave.Checked)
            {

                StreamWriter sw = new StreamWriter(Application.StartupPath + "\\user", false, System.Text.Encoding.UTF8);
                sw.Write(Encrypt.EncryptDES(txtUserName.Text + "\n" + txtPassword.Text, "19880808"));
                sw.Close();
                sw.Dispose();
            }
            else
            {
                StreamWriter sw = new StreamWriter(Application.StartupPath + "\\user", false, System.Text.Encoding.UTF8);
                sw.Write(Encrypt.EncryptDES("", "19880808"));
                sw.Close();
                sw.Dispose();
            }

        }

        private void chkSave_CheckedChanged(object sender, EventArgs e)
        {
            //SaveLoginMessage();
        }

　
    }
}
