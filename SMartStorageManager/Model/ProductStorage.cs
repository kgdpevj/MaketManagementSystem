using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 商品入库表
    /// </summary>
    public class ProductStorage
    {
        /// <summary>
        /// 编号（表主键）
        /// </summary>
        public int StorageId { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        public string ProductId { get; set; }
        /// <summary>
        /// 入库数量
        /// </summary>
        public int AddedCount { get; set; }
        /// <summary>
        /// 入库时间
        /// </summary>
        public DateTime StorageTime { get; set; }
    }
}
