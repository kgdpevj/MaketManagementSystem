using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Models;

namespace SaleManager
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormLogin loginDlg = new FormLogin();
            if(DialogResult.OK == loginDlg.ShowDialog())
            {
                Application.Run(new FormMain());
            }
        }

        //已登录的销售员
        public static SalesPerson LoginSalePerson = new SalesPerson();
        // messagebox的Title
        public enum MessageBoxTitleType { Null, Warning, Information, Tips, Question, Error, Exit }
        public static Dictionary<MessageBoxTitleType, string> MessageBoxTitle = new Dictionary<MessageBoxTitleType, string>(){
                {MessageBoxTitleType.Null, "" },
                {MessageBoxTitleType.Warning,"警告"},
                {MessageBoxTitleType.Information,"消息"},
                {MessageBoxTitleType.Tips,"提示"},
                {MessageBoxTitleType.Question,"询问"},
                {MessageBoxTitleType.Error,"错误"},
                {MessageBoxTitleType.Exit,"退出"}
        };
    }
}
