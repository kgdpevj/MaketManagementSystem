using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 商品库存信息表
    /// </summary>
    public class ProductInventory
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        public string ProductId { get; set; }
        /// <summary>
        /// 总数量
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 维持正常运营的最小库存
        /// </summary>
        public int MinCount { get; set; }
        /// <summary>
        /// 维持正常运营的最大库存
        /// </summary>
        public int MaxCount { get; set; }
        /// <summary>
        /// 库存状态（外键）
        /// </summary>
        public int StatusId { get; set; }
    }
}
