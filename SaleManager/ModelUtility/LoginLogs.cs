using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 登录日志表
    /// </summary>
    public class LoginLogs
    {
        /// <summary>
        /// 编号（表主键）
        /// </summary>
        public int LogId { get; set; }
        /// <summary>
        /// 登录人员的ID
        /// </summary>
        public int LoginId { get; set; }
        /// <summary>
        /// 登录人员的姓名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 登录的服务器名
        /// </summary>
        public string ServerName { get; set; }
        /// <summary>
        /// 登入时间
        /// </summary>
        public DateTime LoginTime { get; set; }
        /// <summary>
        /// 退出时间
        /// </summary>
        public DateTime ExitTime { get; set; }
    }
}
