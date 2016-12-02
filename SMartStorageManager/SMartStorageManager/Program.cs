using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


using Model;
using System.Diagnostics;

namespace SMartStorageManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //禁止启动多个项目进程
            Process[] processArray = Process.GetProcesses();//获取所有进程
            int currentCount = 0;
            foreach(var item in processArray)
            {
                if(item.ProcessName == Process.GetCurrentProcess().ProcessName)
                {
                    currentCount += 1;
                    if(currentCount > 1)
                    {
                        return;
                    }
                }
            }
            //登录窗体
            FormLogin dlg = new FormLogin();
            if(DialogResult.OK == dlg.ShowDialog())
            {
                Application.Run(new FormMain());
            }
        }
        //登录信息
        public static SysAdmins objSysAdmins = new SysAdmins();
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
