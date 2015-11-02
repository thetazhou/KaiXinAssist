using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KaiXinAssist
{
    static class Program
    {
       public static FormLogin formLogin; //登录入口窗体，事先声明

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
       [STAThread]
       static void Main()
       {
           Application.EnableVisualStyles();
           Application.SetCompatibleTextRenderingDefault(false);
           formLogin = new FormLogin();
           Application.Run(formLogin);
       }
    }
}
