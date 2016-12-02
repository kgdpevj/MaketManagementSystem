using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using Models;

namespace DAL
{

    public class SalesListService
    {
        public DateTime GetServerDateTime()
        {
            return Helper.SqlHelper.GetServerTime();
        }

        //结算时需要更新的数据
        //1.在销售主表中添加一条记录
        //2.在销售明细表中添加若干条记录
        //3.更新库存
        public bool SaveSaleInfo(SalesList objSaleList, List<SalesListDetail> objDetailList)
        {
            //定义一个结合，用来存储多条SQL语句
            List<string> sqlList = new List<string>();
            List<SqlParameter[]> paramList = new List<SqlParameter[]>();

            //【1】组合插入主表的SQL语句
            string sql = "insert into SalesList";
            sql += " (SerialNumber,TotalMoney,RealReceive,ReturnMone,SalesPersonId)";
            sql += " values(@SerialNumber,@TotalMoney,@RealReceive,@ReturnMone,@SalesPersonId);";
            SqlParameter[] param = new SqlParameter[] {
            new SqlParameter("@SerialNumber",objSaleList.SerialNumber ),
            new SqlParameter("@TotalMoney", objSaleList.TotalMoney),
            new SqlParameter("@RealReceive" , objSaleList.RealReceive),
            new SqlParameter("@ReturnMone" , objSaleList.ReturnMoney),
            new SqlParameter("@SalesPersonId", objSaleList.SalesPersonId)
        };
            sqlList.Add(sql);
            paramList.Add(param);

            //【2】组合插入明细表的SQL语句
            foreach(var item in objDetailList)
            {
                string sqlDetail = "insert into SalesListDetail";
                sqlDetail += " (SerialNumber,ProductId,ProductName,UnitPrice,Discount,Quantity,SubTotalMoney)";
                sqlDetail += " values(@SerialNumber,@ProductId,@ProductName,@UnitPrice,@Discount,@Quantity,@SubTotalMoney);";
                SqlParameter[] paramDetail = new SqlParameter[] {
                new SqlParameter("@SerialNumber",item.SerialNumber ),
                new SqlParameter("@ProductId", item.ProductId),
                new SqlParameter("@ProductName" , item.ProductName),
                new SqlParameter("@UnitPrice" , item.UnitPrice),
                new SqlParameter("@Discount", item.Discount),
                new SqlParameter("@Quantity", item.Quantity),
                new SqlParameter("@SubTotalMoney", item.SubTotalMoney)
            };
                sqlList.Add(sqlDetail);
                paramList.Add(paramDetail);


                //更新库存信息
                string sqlInventory = "update ProductInventory set TotalCount=TotalCount-@Quantity where ProductId=@ProductId;";
                SqlParameter[] paramInventory = new SqlParameter[] {
                new SqlParameter("@Quantity",item.Quantity ),
                new SqlParameter("@ProductId", item.ProductId)
            };
                sqlList.Add(sqlInventory);
                paramList.Add(paramInventory);
            }
            //【3】启用事务并执行放回结果
            return Helper.SqlHelper.UpdateByTran(sqlList, paramList);
        }

        //4.更新会员积分
        public int UpdateVipPoint(int memberId, int points)
        {
            string sql = "update VIPMembers set Points=Points+@Points where MemberId=@MemberId";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@Points",points),
                new SqlParameter("@MemberId",memberId)
            };
            return Helper.SqlHelper.Update(sql, param);
        }
    }
}
