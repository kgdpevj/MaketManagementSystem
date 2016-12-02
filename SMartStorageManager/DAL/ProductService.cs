using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    /// <summary>
    /// 商品数据访问类
    /// </summary>
    public class ProductService
    {
        /// <summary>
        /// 获取所有分类
        /// </summary>
        /// <returns></returns>
        public List<ProductCategory> GetAllCategory()
        {
            string sql = "select CategoryId,CategoryName from ProductCategory";
            SqlDataReader objReader = Helper.SQLHelper.GetReader(sql);
            List<ProductCategory> list = new List<ProductCategory>();
            while(objReader.Read())
            {
                list.Add(new ProductCategory()
                {
                    CategoryId = Convert.ToInt32(objReader["CategoryId"]),
                    CategoryName = objReader["CategoryName"].ToString()
                });
            }
            return list;
        }

        /// <summary>
        /// 获取所有的商品计量单位
        /// </summary>
        /// <returns></returns>
        public List<ProductUnit> GetAllUnit()
        {
            string sql = "select UnitId,UnitName from ProductUnit";
            SqlDataReader objReader = Helper.SQLHelper.GetReader(sql);
            List<ProductUnit> list = new List<ProductUnit>();
            while(objReader.Read())
            {
                list.Add(new ProductUnit()
                {
                    UnitId = Convert.ToInt32(objReader["UnitId"]),
                    UnitName = objReader["UnitName"].ToString()
                });
            }
            return list;
        }

        /// <summary>
        /// 利用存储过程添加商品，添加库存
        /// </summary>
        /// <param name="objProduct"></param>
        /// <returns>返回受影响的行数</returns>
        public int AddProduct(Products objProduct)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ProductId",objProduct.ProductId),
                new SqlParameter("@ProductName",objProduct.ProductName),
                new SqlParameter("@UnitId",objProduct.UnitId),
                new SqlParameter("@UnitPrice",objProduct.UnitPrice),
                new SqlParameter("@CategoryId",objProduct.CategoryId),
                new SqlParameter("@MaxCount",objProduct.MaxCount),
                new SqlParameter("@MinCount",objProduct.MinCount)
            };
            return Helper.SQLHelper.UpdateByProcedure("usp_AddProduct", param);
        }

        /// <summary>
        /// 更改商品信息
        /// </summary>
        /// <param name="objProductNew">新对象</param>
        /// <param name="objProduct">旧对象</param>
        /// <returns></returns>
        public int EditProduct(Products objProductNew, Products objProduct)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ProductId",objProduct.ProductId),
                new SqlParameter("@ProductIdNew",objProductNew.ProductId),
                new SqlParameter("@ProductName",objProductNew.ProductName),
                new SqlParameter("@UnitId",objProductNew.UnitId),
                new SqlParameter("@UnitPrice",objProductNew.UnitPrice),
                new SqlParameter("@CategoryId",objProductNew.CategoryId)
            };
            return Helper.SQLHelper.UpdateByProcedure("usp_EditProduct", param);
        }

        /// <summary>
        /// 获取商品信息
        /// </summary>
        /// <param name="objProduct"></param>
        /// <returns></returns>
        public Products GetProduct(Products objProduct)
        {
            string sql = "select ProductName from Products where ProductId=@ProductId";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ProductId",objProduct.ProductId)
            };
            SqlDataReader objReader = Helper.SQLHelper.GetReader(sql, param);
            Products product = null;
            if(objReader.Read())
            {
                product = new Products()
                {
                    ProductName = objReader["ProductName"].ToString()
                };
            }
            return product;
        }

        /// <summary>
        /// 根据商品编号获取商品信息
        /// </summary>
        /// <param name="objProduct"></param>
        /// <returns></returns>
        public Products GetProductById(string productId)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ProductId",productId)
            };
            SqlDataReader objReader = Helper.SQLHelper.GetReaderByProcedure("usp_GetProductById", param);
            Products product = null;
            if(objReader.Read())
            {
                product = new Products()
                {
                    ProductId = objReader["ProductId"].ToString(),
                    ProductName = objReader["ProductName"].ToString(),
                    UnitName = objReader["UnitName"].ToString(),
                    UnitPrice = Convert.ToInt32(objReader["UnitPrice"]),
                    CategoryName = objReader["CategoryName"].ToString(),
                    Discount = Convert.ToInt32(objReader["Discount"])
                };
            }
            objReader.Close();
            return product;
        }

        /// <summary>
        /// 商品入库（更新商品库存）
        /// </summary>
        /// <param name="productId">商品编号</param>
        /// <param name="addCount">入库数量</param>
        /// <returns></returns>
        public int AddInventory(string productId, string addCount)
        {
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@ProductId",productId),
                new SqlParameter("@AddCount",addCount)
            };
            return Helper.SQLHelper.UpdateByProcedure("usp_AddInventory", param);
        }

        /// <summary>
        /// 商品库存上下限更新
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="maxCount"></param>
        /// <param name="minCount"></param>
        /// <returns></returns>
        public int UpdateMaxMinLimits(string productId, int maxCount, int minCount)
        {
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@ProductId",productId),
                new SqlParameter("@MaxCount",maxCount),
                new SqlParameter("@MinCount",minCount)
            };
            return Helper.SQLHelper.UpdateByProcedure("usp_UpdateMaxMinLimits", param);
        }

        /// <summary>
        /// 商品库存数量修改
        /// </summary>
        /// <param name="productId">商品编号</param>
        /// <param name="inventoryCount">库存数量</param>
        /// <returns></returns>
        public int UpdateInventory(string productId, int inventoryCount)
        {
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@ProductId",productId),
                new SqlParameter("@InventoryCount",inventoryCount)
            };
            return Helper.SQLHelper.UpdateByProcedure("usp_UpdateInventory", param);
        }

        /// <summary>
        /// 商品折扣修改
        /// </summary>
        /// <param name="productId">商品编号</param>
        /// <param name="addCount">折扣信息</param>
        /// <returns></returns>
        public int UpdateDiscount(string productId, int discount)
        {
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@ProductId",productId),
                new SqlParameter("@Discount",discount)
            };
            return Helper.SQLHelper.UpdateByProcedure("usp_UpdateDiscount", param);
        }

        /// <summary>
        /// 根据组合条件查询商品和库存信息
        /// </summary>
        /// <param name="productId">商品编号</param>
        /// <param name="productName">商品名称</param>
        /// <param name="categoryId">分类编号</param>
        /// <returns>返回包含查询结果的DataTable</returns>
        public DataTable QueryInventoryInfo(string productId, string productName, string categoryId)
        {
            string sql = "select ProductId,ProductName,UnitId,UnitName,UnitPrice,Discount,TotalCount,MaxCount,MinCount,StatusId,StatusDescription,CategoryId,CategoryName";
            sql += " from view_QueryInventoryInfo";
            sql += " where 1=1";
            if(productId.Length > 0)
            {
                sql += string.Format(" and ProductId like '%{0}%'", productId);
            }
            if(productName.Length > 0)
            {
                sql += string.Format(" and ProductName like '%{0}%'", productName);
            }
            if(categoryId.Length > 0)
            {
                sql += string.Format(" and CategoryId={0}", categoryId);
            }
            return Helper.SQLHelper.GetDataSet(sql).Tables[0];
        }

        /// <summary>
        /// 查询库存预警数量
        /// </summary>
        /// <param name="totalCount">预警总数</param>
        /// <param name="moreCount">超高预警数</param>
        /// <param name="lessCount">超低预警数</param>
        /// <returns></returns>
        public void QueryWarningCount(out int totalCount, out int moreCount, out int lessCount)
        {
            SqlParameter totalCountParam = new SqlParameter("@TotalCount", SqlDbType.Int);
            totalCountParam.Direction = ParameterDirection.Output;
            SqlParameter moreCountParam = new SqlParameter("@MoreCount", SqlDbType.Int);
            moreCountParam.Direction = ParameterDirection.Output;
            SqlParameter lessCountParam = new SqlParameter("@LessCount", SqlDbType.Int);
            lessCountParam.Direction = ParameterDirection.Output;

            SqlParameter[] param = new SqlParameter[] {
                totalCountParam,moreCountParam,lessCountParam
            };
            Helper.SQLHelper.UpdateByProcedure("usp_QueryWarningCount", param);
            totalCount = Convert.ToInt32(totalCountParam.Value);
            moreCount = Convert.ToInt32(moreCountParam.Value);
            lessCount = Convert.ToInt32(lessCountParam.Value);
        }

        /// <summary>
        /// 查询库存预警详细信息
        /// </summary>
        /// <param name="totalCount">预警总数</param>
        /// <param name="moreCount">超高预警数</param>
        /// <param name="lessCount">超低预警数</param>
        /// <returns></returns>
        public List<Products> QueryWarningInfo()
        {
            return QueryWarningList("usp_QueryWarningInfo");
        }
        /// <summary>
        /// 查询库存超高预警详细信息
        /// </summary>
        /// <returns></returns>
        public List<Products> QueryMoreWarningInfo()
        {
            return QueryWarningList("usp_QueryMoreWarningInfo");
        }

        /// <summary>
        /// 查询库存超低预警详细信息
        /// </summary>
        /// <returns></returns>
        public List<Products> QueryLessWarningInfo()
        {
            return QueryWarningList("usp_QueryLessWarningInfo");
        }

        private List<Products> QueryWarningList(string procedureName)
        {
            SqlDataReader objReader = Helper.SQLHelper.GetReaderByProcedure(procedureName);
            List<Products> list = new List<Products>();
            while(objReader.Read())
            {
                list.Add(new Products()
                {
                    ProductId = objReader["ProductId"].ToString(),
                    ProductName = objReader["ProductName"].ToString(),
                    UnitName = objReader["UnitName"].ToString(),
                    MaxCount = Convert.ToInt32(objReader["MaxCount"]),
                    TotalCount = Convert.ToInt32(objReader["TotalCount"]),
                    MinCount = Convert.ToInt32(objReader["MinCount"]),
                    StatusDescription = objReader["StatusDescription"].ToString()
                });
            }
            return list;
        }

        /// <summary>
        /// 根据商品编号删除库存信息
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public int DelProductInventory(string productId)
        {
            string sql = "delete  ProductInventory where ProductId=@ProductId";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@ProductId",productId)
            };
            return Helper.SQLHelper.Update(sql, param);
        }

        /// <summary>
        /// 根据时间段获取商品销售数据
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataTable GetSaleStatistics(DateTime start, DateTime end)
        {
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@StartTime",start),
                new SqlParameter("@EndTime",end)
            };
            return Helper.SQLHelper.GetDataSetByProcedure("usp_QuerySaleStatistics", param).Tables[0];
        }
    }
}
