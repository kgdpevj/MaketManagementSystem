using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;
using Model;

namespace BLL
{
    /// <summary>
    /// 商品业务逻辑类
    /// </summary>
    public class ProductManager
    {
        //创建数据访问对象
        private ProductService objProductService = new ProductService();

        /// <summary>
        /// 获取所有分类
        /// </summary>
        /// <returns></returns>
        public List<ProductCategory> GetAllCategory()
        {
            return objProductService.GetAllCategory();
        }

        /// <summary>
        /// 获取所有的商品计量单位
        /// </summary>
        /// <returns></returns>
        public List<ProductUnit> GetAllUnit()
        {
            return objProductService.GetAllUnit();
        }

        /// <summary>
        /// 利用存储过程添加商品，添加库存
        /// </summary>
        /// <param name="objProduct"></param>
        /// <returns>返回受影响的行数</returns>
        public int AddProduct(Products objProduct)
        {
            return objProductService.AddProduct(objProduct);
        }

        /// <summary>
        /// 更改商品信息
        /// </summary>
        /// <param name="objProductNew">新对象</param>
        /// <param name="objProduct">旧对象</param>
        /// <returns></returns>
        public int EditProduct(Products objProductNew, Products objProduct)
        {
            return objProductService.EditProduct(objProductNew, objProduct);
        }

        /// <summary>
        /// 根据商品编号获取商品信息
        /// </summary>
        /// <param name="objProduct"></param>
        /// <returns></returns>
        public Products GetProductById(string productId)
        {
            return objProductService.GetProductById(productId);
        }

        /// <summary>
        /// 商品入库（更新商品库存）
        /// </summary>
        /// <param name="productId">商品编号</param>
        /// <param name="addCount">入库数量</param>
        /// <returns></returns>
        public int AddInventory(string productId, string addCount)
        {
            return objProductService.AddInventory(productId, addCount);
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
            return objProductService.UpdateMaxMinLimits(productId, maxCount, minCount);
        }

        /// <summary>
        /// 商品库存数量修改
        /// </summary>
        /// <param name="productId">商品编号</param>
        /// <param name="inventoryCount">库存数量</param>
        /// <returns></returns>
        public int UpdateInventory(string productId, int inventoryCount)
        {
            return objProductService.UpdateInventory(productId, inventoryCount);
        }

        /// <summary>
        /// 商品折扣修改
        /// </summary>
        /// <param name="productId">商品编号</param>
        /// <param name="addCount">折扣信息</param>
        /// <returns></returns>
        public int UpdateDiscount(string productId, int discount)
        {
            return objProductService.UpdateDiscount(productId, discount);
        }
        /// <summary>
        /// 根据组合条件查询商品和库存信息
        /// </summary>
        /// <param name="productId">商品编号</param>
        /// <param name="productName">商品名称</param>
        /// <param name="categoryId">分类编号</param>
        /// <returns>返回包含查询结果的DataTable</returns>
        public DataTable QueryInventoryInfo(string productId, string productName, int categoryId)
        {
            if(categoryId != -1)
            {
                return objProductService.QueryInventoryInfo(productId, productName, categoryId.ToString());
            }
            else
            {
                return objProductService.QueryInventoryInfo(productId, productName, string.Empty);
            }
        }

        /// <summary>
        /// 查询库存预警详细信息
        /// </summary>
        /// <param name="totalCount">预警总数</param>
        /// <param name="moreCount">超高预警数</param>
        /// <param name="lessCount">超低预警数</param>
        /// <returns></returns>
        public void QueryWarningCount(out int totalCount, out int moreCount, out int lessCount)
        {
            objProductService.QueryWarningCount(out totalCount, out moreCount, out lessCount);
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
            return objProductService.QueryWarningInfo();
        }

        /// <summary>
        /// 查询库存超高预警详细信息
        /// </summary>
        /// <returns></returns>
        public List<Products> QueryMoreWarningInfo()
        {
            return objProductService.QueryMoreWarningInfo();
        }

        /// <summary>
        /// 查询库存超低预警详细信息
        /// </summary>
        /// <returns></returns>
        public List<Products> QueryLessWarningInfo()
        {
            return objProductService.QueryLessWarningInfo();
        }

        /// <summary>
        /// 根据商品编号删除库存信息
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public int DelProductInventory(string productId)
        {
            return objProductService.DelProductInventory(productId);
        }
        
        /// <summary>
        /// 根据时间段获取商品销售数据
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataTable GetSaleStatistics(DateTime start, DateTime end)
        {
            return objProductService.GetSaleStatistics(start, end);
        }
    }
}
