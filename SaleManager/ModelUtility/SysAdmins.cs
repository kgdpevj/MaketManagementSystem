using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
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
    }
}
