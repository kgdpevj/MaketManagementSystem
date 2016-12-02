using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 商品库存状态表
    /// </summary>
    public class InventoryStatus
    {
        /// <summary>
        /// 库存状态类别编号（表主键）
        /// </summary>
        public int StatusId { get; set; }
        /// <summary>
        /// 库存状态描述
        /// 0：正常
        /// -1：低于库存
        /// 1：高于库存
        /// 2：已清仓
        /// </summary>
        public string StatusDescription { get; set; }
    }
}
