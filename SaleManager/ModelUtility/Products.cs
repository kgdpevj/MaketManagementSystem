using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 商品信息表
    /// </summary>
    public class Products
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        public string ProductId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public double UnitPrice { get; set; }
        /// <summary>
        /// 商品计量单位编号（外键）
        /// </summary>
        public int UnitId { get; set; }
        /// <summary>
        /// 折扣百分比
        /// </summary>
        public int Discount { get; set; }
        /// <summary>
        /// 商品分类编号
        /// </summary>
        public int CategoryId { get; set; }
        // 扩展属性
        /// <summary>
        /// 商品计量单位名称
        /// </summary>
        public string UnitName { get; set; }
        /// <summary>
        /// 商品分类名称
        /// </summary>
        public string CategoryName { get; set; }

    }
}
