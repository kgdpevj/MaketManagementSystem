using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;
using Models;
namespace BLL
{
    public class ProductsManager
    {
        ProductsService objProductsService = new ProductsService();
        public Products GetProductByProductId(string productId)
        {
            return objProductsService.GetProductByProductId(productId);
        }
    }
}
