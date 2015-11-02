using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

/*
 * 子线程的问题　没有完
 * 
 * 多线程改变控件时，会发生掉死的现象，待解决。
 * 
 * 增加根据某人ID查找他的好友列表
 * 
 */
namespace KaiXinAssist
{
    public delegate void LoadFriendsDelegate(string text); 
    public delegate void LoadFriendsOnlineDelegate(string text); 
    public delegate void ClearFriendDelegate(); 

    public delegate void GetJiPiao(); //获取机票信息

    public partial class FormFriend : Form
    {
        private Thread LoadFriendsThread = null;

        private static bool isAllSelect = false; //全选标记，默认全不选
        private static bool isAllList = true; //显示全部好友
        private static string[] arrReceiveMessage;
        KaixinHelper kh;

        public FormFriend()
        {
            InitializeComponent();

            LoadFriendsThread = new Thread(new ThreadStart(ByFriendsThreadHandle));　//此线程中指定执行的函数
            LoadFriendsThread.IsBackground = true;
        }


        private void FormFriend_Load(object sender, EventArgs e)
        {
            Program.formLogin.Hide(); //隐藏登录窗体
            kh = new KaixinHelper();
            LoadFriendsThread.Start();

            //if ((LoadFriendsThread.ThreadState & ThreadState.Running) == ThreadState.Running)
            //    LoadFriendsThread.Abort();

            //LoadFriendsThread = null;

        }

        public void ByFriendsThreadHandle() //线程调用的函数
        {
            try
            {
                string[] arrFriend = kh.GetFriends(KaixinHelper.userid);//获取指定用户好友列表
                //string[] arrFriend = kh.GetFriends(1044978);

                BeginInvoke(new ClearFriendDelegate(ClearFriends));
                for (int i = 0; i < arrFriend.Length; i++)
                {
                    string tempFriendId = arrFriend[i].Substring(0, arrFriend[i].IndexOf('_'));
                    string tempFriendName = arrFriend[i].Substring(arrFriend[i].IndexOf('_') + 1, arrFriend[i].Length - (arrFriend[i].IndexOf('_') + 1));
                    if (tempFriendName.Length < 3 && tempFriendName.Length > 1)
                    {
                        tempFriendName = tempFriendName.Substring(0, 1) + "  " + tempFriendName.Substring(1, 1);
                    }
                    // chklstFriend.Items.Add(tempFriendName + "  (" + tempFriendId + ")");
                    BeginInvoke(new LoadFriendsDelegate(LoadFriendsListCotrol), new object[] { tempFriendName + "  (" + tempFriendId + ")" });
                    //Thread.Sleep(50);
                }
            }
            catch
            {

            }
        }


        public void ByFriendsOnlineThreadHandle() //线程调用的函数
        {
            try
            {
                string[] arrFriend = kh.GetOnlineFriends();
                BeginInvoke(new ClearFriendDelegate(ClearFriends));
                for (int i = 0; i < arrFriend.Length; i++)
                {
                    string tempFriendId = arrFriend[i].Substring(0, arrFriend[i].IndexOf('_'));
                    string tempFriendName = arrFriend[i].Substring(arrFriend[i].IndexOf('_') + 1, arrFriend[i].Length - (arrFriend[i].IndexOf('_') + 1));
                    if (tempFriendName.Length < 3 && tempFriendName.Length > 1)
                    {
                        tempFriendName = tempFriendName.Substring(0, 1) + "  " + tempFriendName.Substring(1, 1);
                    }
                    BeginInvoke(new LoadFriendsDelegate(LoadFriendsListCotrol), new object[] { tempFriendName + "  (" + tempFriendId + ")" });
                }
            }
            catch
            {

            }
        }


        #region method for Delegate

        private void ClearFriends()　//被委托调用的函数
        {
            chklstFriend.Items.Clear();
        }


        private void LoadFriendsListCotrol(string text)　//被委托调用的函数
        {
            chklstFriend.Items.Add(text);
        }
 

        #endregion

        private void ClearSelect()
        {
            txtBoxReceive.Text = "";
            lblReceive.Text = "接收者";
            btnAllSelect.Text = "全　选";
            isAllSelect = false;
            for (int i = 0; i < chklstFriend.Items.Count; i++)
            {
                chklstFriend.SetItemChecked(i, false);
            }

        }

        private void SelectEvent()
        {
            lblReceive.Text = "接收者　共" + chklstFriend.CheckedItems.Count.ToString() + "人";
            txtBoxReceive.Text = "";
            txtReceiverID.Text = "";
            for (int i = 0; i < chklstFriend.CheckedItems.Count; i++)
            {
                string tempFriendName = kh.GetMatch(@"(?<text1>[\s\S]*?)  \(", chklstFriend.CheckedItems[i].ToString());
                tempFriendName = tempFriendName.Replace(" ", "");
                txtBoxReceive.Text += tempFriendName + ";";
                txtReceiverID.Text += kh.GetMatch(@"\((?<text1>[\d]*?)\)", chklstFriend.CheckedItems[i].ToString())+",";
            }
            if(txtReceiverID.Text.Length>0)
            {
                txtReceiverID.Text = txtReceiverID.Text.Substring(0, txtReceiverID.Text.Length - 1);
            }
        }

        /// <summary>
        /// 选中好友
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chklstFriend_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectEvent();
        }

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAllSelect_Click(object sender, EventArgs e)
        {
            isAllSelect = !isAllSelect;
            if (isAllSelect)
            {
                btnAllSelect.Text = "清　除";
            }
            else
            {
                btnAllSelect.Text = "全　选";
            }

            for (int i = 0; i < chklstFriend.Items.Count; i++)
            {
                chklstFriend.SetItemChecked(i, isAllSelect);
            }
            SelectEvent();
        }
　

        /// <summary>
        /// 退出应用程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormFriend_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtContent.Text = "";
        }

        #region 备用
        /*
        private void btnSend_Click(object sender,EventArgs e)
        {

            bool msgReturn = false;
            string[] arrUserId = txtReceiverID.Text.Split(',');

            if (chkComment.Checked) //如果留言复选框被选中，则仅当作留言发送。
            {
                for (int i = 0; i < arrUserId.Length; i++)
                {
                    string tempFriendId = arrUserId[i];
                    MessageBox.Show(tempFriendId + "\n" + txtContent.Text);
                    msgReturn = kh.PostComment(tempFriendId, txtContent.Text);
                    if (msgReturn == false)
                    {
                        MessageBox.Show(tempFriendId.ToString()+": send failed ");
                        break;
                    }
                }
            }
            else
            {

                msgReturn = kh.PostMessage(txtReceiverID.Text, txtContent.Text);
                if (!msgReturn)
                {
                    MessageBox.Show("发送失败，请重新发送！");
                }

            }

            if (msgReturn)
            {
                MessageBox.Show("OK,发送完成！");
            }
            else
            {
                MessageBox.Show("OK,发送失败！");
            }
        }
                */
        #endregion

        private void btnSend_Click(object sender, EventArgs e)
        {
            bool msgReturn = false;

            if (chkComment.Checked) //如果留言复选框被选中，则仅当作留言发送。
            {
                for (int i = 0; i < chklstFriend.CheckedItems.Count; i++)
                {
                    string tempFriendId = kh.GetMatch(@"\((?<text1>[\d]*?)\)", chklstFriend.CheckedItems[i].ToString());
                   //MessageBox.Show(tempFriendId + "\n" + txtContent.Text);
                    msgReturn = kh.PostComment(tempFriendId, txtContent.Text);
                    if (msgReturn == false)
                    {
                        break;
                    }

                }

            }
            else
            {

               // if (chkGroupSend.Checked) //是否群发
                {
                    string strReceiveIds = string.Empty;//群发时接收的ID组

                    for (int i = 0; i < chklstFriend.CheckedItems.Count; i++)
                    {
                        string tempFriendId = kh.GetMatch(@"\((?<text1>[\d]*?)\)", chklstFriend.CheckedItems[i].ToString());
                        if (i < chklstFriend.CheckedItems.Count - 1)
                        {
                            strReceiveIds += tempFriendId + ",";
                        }
                        else
                        {
                            strReceiveIds += tempFriendId;
                        }

                    }
                    msgReturn = kh.PostMessage(strReceiveIds, txtContent.Text);
                    if (!msgReturn)
                    {
                        MessageBox.Show("发送给失败，请重新发送！");
                    }
                }
                //else
                //{
                //    for (int i = 0; i < chklstFriend.CheckedItems.Count; i++)
                //    {
                //        string tempFriendName = kh.GetMatch(@"(?<text1>[\s\S]*?)  \(", chklstFriend.CheckedItems[i].ToString());
                //        tempFriendName = tempFriendName.Replace(" ", "");

                //        string tempFriendId = kh.GetMatch(@"\((?<text1>[\d]*?)\)", chklstFriend.CheckedItems[i].ToString());
                //        //txtContent.Text += tempFriendId + ";";
                //        msgReturn = kh.PostMessage(tempFriendId.ToString(), txtContent.Text);
                //        if (!msgReturn)
                //        {
                //            MessageBox.Show("发送给" + tempFriendName + "时失败，请重新发送！");
                //            break;
                //        }

                //    }
                //}
            }

            if (msgReturn)
            {
                MessageBox.Show("OK,发送完成！");
            }
            else
            {
                MessageBox.Show("OK,发送失败！");
            }
        }


        private void btnFriendList_Click(object sender, EventArgs e)
        {

        }

        private void chkDispOnline_CheckedChanged(object sender, EventArgs e)
        {

            ClearSelect();
            if (isAllList)
            {
                LoadFriendsThread = new Thread(new ThreadStart(ByFriendsOnlineThreadHandle));　//此线程中指定执行的函数
                LoadFriendsThread.IsBackground = true;
                LoadFriendsThread.Start();

                chkDispOnline.Checked = true;
                isAllList = !isAllList;
            }
            else
            {
                LoadFriendsThread = new Thread(new ThreadStart(ByFriendsThreadHandle));　//此线程中指定执行的函数
                LoadFriendsThread.IsBackground = true;
                LoadFriendsThread.Start();
 
                chkDispOnline.Checked = false;
                isAllList = !isAllList;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                arrReceiveMessage = kh.GetMessage();
                chklstReceiveList.Items.Clear();

                for (int i = 0; i < arrReceiveMessage.Length; i++)
                {
                    string[] tempArrOneMessage = arrReceiveMessage[i].Split('_');

                    string m_Id = tempArrOneMessage[0];
                    string m_Name = tempArrOneMessage[1];
                    string m_Content = tempArrOneMessage[2];

                    chklstReceiveList.Items.Add(m_Name + "  (" + m_Id + ")");
                }
            }
            catch
            {

            }

        }

        private void chklstReceiveList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] tempArrOneMessage = arrReceiveMessage[chklstReceiveList.SelectedIndex].Split('_');
                string m_Content = tempArrOneMessage[2];
                txtReceiveContent.Text = m_Content;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
 
    }
}
