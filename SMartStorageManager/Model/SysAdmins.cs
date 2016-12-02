using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 管理员表
    /// </summary>
    public class SysAdmins
    {
        /// <summary>
        /// 登录人员的ID
        /// </summary>
        public int LoginId { get; set; }
        /// <summary>
        /// 登录人员密码
        /// </summary>
        public string LoginPassword { get; set; }
        /// <summary>
        /// 登录人员的姓名
        /// </summary>
        public string AdminName { get; set; }
        /// <summary>
        /// 管理员账号的状态
        /// 0：禁用
        /// 1：启用
        /// </summary>
        public byte AdminStatus { get; set; }
        /// <summary>
        /// 角色编号
        /// </summary>
        public int RoleId { get; set; }

        //扩展属性
        /// <summary>
        /// 登录时登录日志的登录ID
        /// </summary>
        public int LoginLogId { get; set; }
    }
}
