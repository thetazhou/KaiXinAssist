using System;
using System.Text;
using System.Net;
using System.Web;
using System.IO;

namespace KaiXinAssist
{
    public static class HttpHelper
    {

        /// <summary>
        /// 获取页面
        /// </summary>
        /// <param name="url"></param>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static string GetPage(string url, CookieContainer cookie)
       {
           string strRet = string.Empty;
           HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
           request.CookieContainer = cookie;
           request.Timeout = 2000;
           HttpWebResponse response = (HttpWebResponse)request.GetResponse();
           System.IO.Stream resStream = response.GetResponseStream();
           Encoding encode = System.Text.Encoding.UTF8;
           StreamReader readStream = new StreamReader(resStream, encode);

           strRet = readStream.ReadToEnd();
           resStream.Close();
           return strRet;
       }

        public static string PostPage(string url,string postData, CookieContainer cookie)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest.Create(new Uri(url));
            webRequest2.CookieContainer = cookie;
            webRequest2.Method = "POST";
            webRequest2.ContentType = "application/x-www-form-urlencoded";
            webRequest2.ContentLength = byteArray.Length;
            Stream newStream = webRequest2.GetRequestStream();
            // Send the data.
            newStream.Write(byteArray, 0, byteArray.Length);    //写入参数
            newStream.Close();

            HttpWebResponse response2 = (HttpWebResponse)webRequest2.GetResponse();
            StreamReader sr2 = new StreamReader(response2.GetResponseStream(), Encoding.UTF8);
            string content = sr2.ReadToEnd();
            sr2.Close();

            return content;
        }
    }
}
