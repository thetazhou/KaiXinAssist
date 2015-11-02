using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;
using System.IO;
using System.Configuration;
using System.Text.RegularExpressions;

namespace KaiXinAssist
{
    class KaixinHelper
    {
        private static int _userid;
        private static string _username;
        private static string _password;
        private static CookieContainer _cookie;

        public static int userid
        {
            get { return _userid; }
            set { _userid = value; }
        }

        public static string username
        {
            get { return _username; }
            set { _username = value; }
        }

        public static string password
        {
            get { return _password; }
            set { _password = value; }
        }

        public static CookieContainer cookie
        {
            get { return _cookie; }
            set { _cookie = value; }
        }


        public KaixinHelper()
        {

        }

        public void Dispose()
        {
            cookie = null;
        }



        /// <summary>
        /// 初始化连接，以方便以后连接速度
        /// </summary>
        /// <returns></returns>
        public static bool Init()
        {
            string strRet = null;
            bool isInitSuccess = false;
            try
            {
                CookieContainer cc = new CookieContainer();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.kaixin001.com/");
                request.CookieContainer = cc;
                request.Timeout = 2000;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                System.IO.Stream resStream = response.GetResponseStream();
                Encoding encode = System.Text.Encoding.UTF8;
                StreamReader readStream = new StreamReader(resStream, encode);

                strRet = readStream.ReadToEnd();
                resStream.Close();

                if (strRet.IndexOf("<title>开心网</title>") > -1)
                {
                    isInitSuccess = true;
                    
                }
                else
                {
                    isInitSuccess = false;
                }

            }
            catch 
            {
                isInitSuccess = false;
            }

            return isInitSuccess;
        

        }

        /// <summary>
        /// 登录开心网
        /// </summary>
        /// <param name="strUsername"></param>
        /// <param name="strPassword"></param>
        public bool LoginIndex()
        {
            bool isLoginSuccess = false;

            CookieContainer cc = new CookieContainer();
            string postData = string.Empty;
            postData += "url=%2F";
            postData += "&email=" + username;
            postData += ("&password=" + password);

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest.Create(new Uri("http://www.kaixin001.com/login/login.php"));
            webRequest2.CookieContainer = cc;
            webRequest2.Method = "POST";
            webRequest2.ContentType = "application/x-www-form-urlencoded";
            webRequest2.ContentLength = byteArray.Length;
            Stream newStream = webRequest2.GetRequestStream();
            // Send the data.
            newStream.Write(byteArray, 0, byteArray.Length);    //写入参数
            newStream.Close();

            HttpWebResponse response2 = (HttpWebResponse)webRequest2.GetResponse();
            StreamReader sr2 = new StreamReader(response2.GetResponseStream(), Encoding.UTF8);
             
            string strIndex = sr2.ReadToEnd();
            sr2.Close();
            cookie = cc;
            if (strIndex.IndexOf("<title>我的首页 - 开心网</title>") > -1)
            {
                isLoginSuccess = true;

                string regStr = @"我的开心网ID:(?<text1>[\d]*?)""";
                Regex rx = new Regex(regStr);
                if (rx.IsMatch(strIndex))
                {
                    Match m = Regex.Match(strIndex, regStr, RegexOptions.IgnoreCase);
                    userid = int.Parse(m.Groups["text1"].Value);
                }
                
            }
            else
            {
                isLoginSuccess = false;
            }
            return isLoginSuccess;

        }




        public string[] GetFriends(int m_id)
        {
            string[] arrResult = null;
            string strRet = null;
            string[] friends = null;
            try
            {
                strRet = HttpHelper.GetPage("http://www.kaixin001.com/friend/?uid=" + m_id.ToString(), cookie);
                friends = GetMatchs(@"<a href=""/home/\?uid=(?<text1>[\d]*?)"" title=""(?<text2>[^<>]*?)"">", strRet);

                string[] pages = GetMatchs(@"<a href=""\?uid=(?<text1>[\d]*?)&viewtype=&start=(?<text2>[\d]*?)"" class=fy onfocus=""this.blur\(\);"">(?<text3>[\d]*?)</a>", strRet);

                System.Collections.ArrayList sc = new System.Collections.ArrayList();
                sc.AddRange(friends);

                if (pages.Length > 0)
                { 
                    for(int linki=0;linki<pages.Length;linki++)
                    {
                        string link = "http://www.kaixin001.com/friend/?uid=" + m_id.ToString() + "&viewtype=&start=" + pages[linki].Substring(pages[linki].IndexOf('_') + 1, pages[linki].Length - (pages[linki].IndexOf('_') + 1));
                        string pageContent = HttpHelper.GetPage(link, cookie);
                        sc.AddRange(GetMatchs(@"<a href=""/home/\?uid=(?<text1>[\d]*?)"" title=""(?<text2>[^<>]*?)"">", pageContent));
                    
                    }

                }
                arrResult = (String[])sc.ToArray(typeof(string));
            }
            catch 
            {
                arrResult = null;
            }
            return arrResult;
        }


        public string[] GetOnlineFriends()
        {
            string[] arrResult = null;
            string strRet = null;
            string[] friends = null;
            try
            {
                strRet = HttpHelper.GetPage("http://www.kaixin001.com/friend/?viewtype=online", cookie);

                friends = GetMatchs(@"<a href=""/home/\?uid=(?<text1>[\d]*?)"" class=""sl"" title=""(?<text2>[^<> ]*?)"" >", strRet);
                arrResult = friends;
            }
            catch
            {
                arrResult = null;
            }
            return arrResult;
        }

        public string[] GetMessage()
        {
            string[] arrResult = null;
            string strRet = null;
            string[] friends = null;
            try
            {
                strRet = HttpHelper.GetPage("http://www.kaixin001.com/msg/inbox.php",cookie);
                //Debug(strRet);
                strRet = strRet.Replace("\r\n", "").Replace("\n","").Replace("\t","") ;

                friends = GetMatchs5(@" <a href=""/home/\?uid=(?<text1>[\d]*?)"" class=""sl"" title=""(?<text2>[^""]*?)"">(?<oter0>[\s\S]*?)<div class=""c9 f10"">(?<texttime>[^<>]*?)</div>(?<oter1>[\s\S]*?)<td valign=""top"" >(?<text3>[\s\S]*?)<div>(?<other2>[\s\S]*?)href=""/msg/view.php\?thread_mid=(?<text4>[\d]*?)&pos=(?<text5>[\d]*?)""", strRet);
                arrResult = friends;
                //for (int i = 0; i < friends.Length; i++)
                //{
                //    Debug(friends[i]+"\n");
                //}
            }
            catch
            {
                arrResult = null;
            }
            return arrResult;
        }

        public bool PostMessage(string toId, string message)
        {
            bool isPostSuccess=false;
            string postData = string.Empty;
            postData = "uids=" + toId;
            postData += "&group=&content=" + message;
            postData += "&texttype=html";

            string content = HttpHelper.PostPage("http://www.kaixin001.com/msg/post.php", postData, cookie);

            if (content.IndexOf(message) > -1)
            { 
                isPostSuccess = true; 
            }
            else
            {
                isPostSuccess = false;
            }

            return isPostSuccess;
            
        }


        public bool PostComment(string toId, string comment)
        {
            //type=0&id=309863&ouid=309863&texttype=html&content=%E8%B4%B1%E4%BA%BA&title=&hidden=0&ispwd=0&_=
            bool isPostSuccess = false;
            string postData = string.Empty;
            postData = "type=0&id=" + toId + "&ouid=" + toId;
            postData += "&texttype=html&content=" + comment;
            postData += "&title=&hidden=0&ispwd=0&_=";

            string content = HttpHelper.PostPage("http://www.kaixin001.com/comment/post.php", postData, cookie);

            if (content.IndexOf(comment) > -1)
            {
                isPostSuccess = true;
            }
            else
            {
                isPostSuccess = false;
            }
            System.Windows.Forms.MessageBox.Show(content);
            return isPostSuccess;

        }

        private string[] GetMatchs(string regStr, string content)
        {
            try
            {
                List<string> strReturn = new List<string>();
                //string regStr = @"uid=(?<uid>[\s\S]*?)"" class=""sl""  >(?<text>[\s\S]*?)</a>";
                MatchCollection mc = Regex.Matches(content, regStr, RegexOptions.IgnoreCase);
                foreach (Match m in mc)
                {
                    if (strReturn.Contains(m.Groups["text1"].Value + "_" + m.Groups["text2"].Value) == false)
                    {
                        strReturn.Add(m.Groups["text1"].Value + "_" + m.Groups["text2"].Value);
                    }
                }
                return strReturn.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

        }

        private string[] GetMatchs5(string regStr, string content)
        {
            try
            {
                List<string> strReturn = new List<string>();
                //string regStr = @"uid=(?<uid>[\s\S]*?)"" class=""sl""  >(?<text>[\s\S]*?)</a>";
                MatchCollection mc = Regex.Matches(content, regStr, RegexOptions.IgnoreCase);
                foreach (Match m in mc)
                {
                    if (strReturn.Contains(m.Groups["text1"].Value + "_" + m.Groups["text2"].Value + "_" + m.Groups["text3"].Value + "_" + m.Groups["text4"].Value + "_" + m.Groups["text5"].Value) == false)
                    {
                        strReturn.Add(m.Groups["text1"].Value + "_" + m.Groups["text2"].Value + "_" + m.Groups["text3"].Value + "_" + m.Groups["text4"].Value + "_" + m.Groups["text5"].Value);
                    }
                }
                return strReturn.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

        }

        public string GetMatch(string regStr, string content)
        {
            string tempContent = content.ToString().ToLower();
            Regex rx = new Regex(regStr);
            if (rx.IsMatch(tempContent))
            {
                Match m = Regex.Match(tempContent, regStr, RegexOptions.IgnoreCase);
                return m.Groups["text1"].Value;
            }
            else
            {
                return "";
            }

        }


        public static void Debug(object message)
        {
            StreamWriter sw = new StreamWriter(System.Windows.Forms.Application.StartupPath + "\\log.txt", true, System.Text.Encoding.UTF8);
            sw.Write(message.ToString());
            sw.Close();
            sw.Dispose();

        }
        

    }
}
