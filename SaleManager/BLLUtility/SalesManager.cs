using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
    public class SalesManager
    {
        SalesListService objSalesListService = new SalesListService();
        //生成流水账号（年月日时分秒+两位随机数）
        public string GetSerialNumber()
        {
            DateTime dt = objSalesListService.GetServerDateTime();
            return dt.ToString("yyyyMMddHHmmssms") + new Random().Next(10, 99).ToString();
        }
        public bool SaveSaleInfo(SalesList objSaleList, List<SalesListDetail> objDetailList)
        {
            return objSalesListService.SaveSaleInfo(objSaleList, objDetailList);
        }
        public int UpdateVipPoint(int memberId, int points)
        {
            return objSalesListService.UpdateVipPoint(memberId, points);
        }
    }
}
