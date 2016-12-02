using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 商品计量单位表
    /// </summary>
    public class ProductUnit
    {
        /// <summary>
        /// 编号(表主键)
        /// </summary>
        public int UnitId { get; set; }
        /// <summary>
        /// 商品计量单位
        /// </summary>
        public string UnitName { get; set; }
    }
}
