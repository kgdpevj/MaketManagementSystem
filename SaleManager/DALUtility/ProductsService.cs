using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using Models;
namespace DAL
{
    /// <summary>
    /// 商品数据访问类
    /// </summary>
    public class ProductsService
    {
        public Products GetProductByProductId(string productId)
        {
            string sql = "select [ProductId],[ProductName],[UnitPrice],ProductUnit.[UnitId],[UnitName],[Discount],ProductCategory.[CategoryId],[CategoryName]";
            sql += " from Products";
            sql += " inner join ProductUnit on Products.UnitId = ProductUnit.UnitId";
            sql += " inner join ProductCategory on Products.CategoryId = ProductCategory.CategoryId";
            sql += " where ProductId = @ProductId";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ProductId",productId)
            };
            SqlDataReader reader = Helper.SqlHelper.GetReader(sql, param);
            if(reader.Read())
            {
                return new Products()
                {
                    ProductId = reader["ProductId"].ToString(),
                    ProductName = reader["ProductName"].ToString(),
                    UnitPrice = Convert.ToDouble(reader["UnitPrice"]),
                    UnitName = reader["UnitName"].ToString(),
                    Discount = Convert.ToInt32(reader["Discount"]),
                    CategoryName = reader["CategoryName"].ToString()
                };
            }
            else
            {
                return null;
            }
        }
    }
}
