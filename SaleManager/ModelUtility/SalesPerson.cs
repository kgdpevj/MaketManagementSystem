using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 销售员表
    /// </summary>
    public class SalesPerson
    {
        /// <summary>
        /// 销售员编号
        /// </summary>
        public int SalesPersonId { get; set; }
        /// <summary>
        /// 销售员姓名
        /// </summary>
        public string SalesPersonName { get; set; }
        /// <summary>
        /// 销售员登录密码
        /// </summary>
        public string LoginPassword { get; set; }

        //扩展属性
        // 登录日志ID
        public int LogId { get; set; }
    }
}
