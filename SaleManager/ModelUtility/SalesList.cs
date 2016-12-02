using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 销售流水账表
    /// </summary>
    public class SalesList
    {
        /// <summary>
        /// 流水账号（系统自动生成）
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// 该流水单的总价
        /// </summary>
        public double TotalMoney { get; set; }
        /// <summary>
        /// 实收款
        /// </summary>
        public double RealReceive { get; set; }
        /// <summary>
        /// 找零款
        /// </summary>
        public double ReturnMoney { get; set; }
        /// <summary>
        /// 销售员编号（外键）
        /// </summary>
        public int SalesPersonId { get; set; }
        /// <summary>
        /// 流水单创建时间（默认服务器操作系统时间）
        /// </summary>
        public DateTime CreateTime { get; set; }

        // 扩展属性
        /// <summary>
        /// 流水单创建时间（默认服务器操作系统时间）
        /// </summary>
        public int VipCardNo { get; set; }

    }
}
