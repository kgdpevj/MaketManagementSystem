using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 商品分类表
    /// </summary>
    public class ProductCategory
    {
        /// <summary>
        /// 商品分类编号
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// 商品分类名称
        /// </summary>
        public string CategoryNmae { get; set; }
    }
}
