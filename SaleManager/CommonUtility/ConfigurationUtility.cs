using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtility
{
    public class ConfigurationUtility
    {
        /// <summary>
        /// 添加节点
        /// </summary>
        private static Action<Configuration, string, string> actionAdd = (c, n, v) =>
        {
            if (!isExist(n))
            {
                //增加<add>元素
                c.AppSettings.Settings.Add(n, v);
            }
            else
            {
                throw new Exception(string.Format("名为{0}的节点已存在。", n));
            }
        };
        /// <summary>
        /// 修改节点
        /// </summary>
        private static Action<Configuration, string, string> actionModify = (c, n, v) =>
        {
            if (isExist(n))
            {
                //根据Key读取<add>元素的Value
                c.AppSettings.Settings[n].Value = v;
            }
            else
            {
                throw new Exception(string.Format("名为{0}的节点不存在。", n));
            }
        };
        /// <summary>
        /// 删除节点
        /// </summary>
        private static Action<Configuration, string, string> actionDel = (c, n, v) =>
        {
            if (isExist(n))
            {
                //删除元素
                c.AppSettings.Settings.Remove(n);
            }
            else
            {
                throw new Exception(string.Format("名为{0}的节点不存在。", n));
            }
        };

        private static Func<Configuration, string, string> fucnGetValue = (c, n) =>
        {
            if (isExist(n))
            {
                // 取得值
                string v = c.AppSettings.Settings[n].Value;
                if (string.IsNullOrEmpty(v) || !string.IsNullOrWhiteSpace(v))
                {
                    v = string.Empty;
                }
                return v;
            }
            else
            {
                throw new Exception(string.Format("名为{0}的节点不存在。", n));
            }
        };
        /// <summary>
        /// 按不同的操作方式，进行操作
        /// </summary>
        /// <param name="action">操作方式的委托</param>
        /// <param name="name">节点名称</param>
        /// <param name="value">节点值</param>
        private static void DoAction(Action<Configuration, string, string> action, string name, string value = "")
        {
            //获取Configuration对象
            Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // 按不同的操作方式，进行操作
            action(config, name, value);
            //一定要记得保存，写不带参数的config.Save()也可以
            config.Save(ConfigurationSaveMode.Modified);
            //刷新，否则程序读取的还是之前的值（可能已装入内存）
            System.Configuration.ConfigurationManager.RefreshSection("appSettings");
        }

        private static string DoFunc(Func<Configuration, string, string> func, string name)
        {
            //获取Configuration对象
            Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // 按不同的操作方式，进行操作
            // 读取key为name的节点对应的value
            return func(config, name);
        }
        public static bool isExist(string name)
        {
            //获取Configuration对象
            Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            return config.AppSettings.Settings.AllKeys.Contains(name);
        }
        public static void AddSettingNode(string name, string value)
        {
            //增加<add>元素
            DoAction(actionAdd, name, value);
        }

        public static void ModifySettingNode(string name, string value)
        {
            //根据Key读取<add>元素的Value
            DoAction(actionModify, name, value);
        }

        public static void DeleteSettingNode(string name)
        {
            //删除元素
            DoAction(actionDel, name);
        }
        public static string GetSettingNodeValue(string name)
        {
            // 读取key为name的节点对应的value
            return DoFunc(fucnGetValue, name);
        }
    }
}
