using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Helper
{
    public class LogHelper
    {
        /// <summary>
        /// 日志文件全名
        /// </summary>
        private static string logFileFullName = string.Empty;
        private static string LogFileFullName
        {
            get
            {
                return logFileFullName;
            }
            set
            {
                string fullPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData) + @"\" + System.Diagnostics.Process.GetCurrentProcess().ProcessName + @"\";
                string strPath = Path.GetDirectoryName(fullPath);
                if(!Directory.Exists(strPath))
                {
                    Directory.CreateDirectory(strPath);
                }
                logFileFullName = fullPath + value;
            }
        }

        /// <summary>
        /// 获取数据库服务器时间
        /// </summary>
        public static DateTime ServerTime
        {
            get
            {
                return SQLHelper.GetServerTime();
            }
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="msg"></param>
        public static void WriteLog(string msg)
        {
            LogFileFullName = System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".log";

            FileStream fs = new FileStream(logFileFullName, FileMode.OpenOrCreate | FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            string strMethodName = string.Empty;
            //获取调用栈对象
            StackTrace ss = new StackTrace(true);
            //取栈中第一个函数对象
            MethodBase mb = ss.GetFrame(1).GetMethod();
            //取得父方法类全名
            strMethodName += mb.DeclaringType.FullName + ".";
            //取得父方法名
            strMethodName += mb.Name;
            sw.WriteLine(string.Format("[{0}] 调用{1}时出错：{2}", ServerTime.ToString(), strMethodName, msg));
            sw.Close();
            fs.Close();
        }
    }
}
