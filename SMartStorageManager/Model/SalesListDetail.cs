using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 销售流水账明细表
    /// </summary>
    public class SalesListDetail
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 销售流水单表流水号
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        public string ProductId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 销售时的单价
        /// </summary>
        public double UnitPrice { get; set; }
        /// <summary>
        /// 折扣百分比
        /// </summary>
        public int Discount { get; set; }
        /// <summary>
        /// 该商品的数量
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 该商品小计金额
        /// </summary>
        public double SubTotalMoney { get; set; }
    }
}
