using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data;
using System.Data.SqlClient;
using Models;
using System.Net;

namespace DAL
{
    /// <summary>
    /// 登录数据访问类
    /// </summary>
    public class UserLoginService
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="sp"></param>
        /// <returns></returns>
        public SalesPerson UserLogin(SalesPerson sp)
        {
            string sql = "select SalesPersonId,SalesPersonName from SalesPerson where SalesPersonId=@SalesPersonId and LoginPassword=@LoginPassword";
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@SalesPersonId",sp.SalesPersonId),
                new SqlParameter("@LoginPassword",sp.LoginPassword)};
            SqlDataReader reader = null;
            try
            {
                reader = Helper.SqlHelper.GetReader(sql, param);
            }
            catch(Exception ex)
            {
                Helper.LogHelper.WriteLog(ex.Message);
                throw ex;
            }
            if(reader.Read())
            {
                SalesPerson objSP = new SalesPerson()
                {
                    SalesPersonName = reader["SalesPersonName"].ToString(),
                    SalesPersonId = Convert.ToInt32(reader["SalesPersonId"])
                };

                // 添加登录日志
                LoginLogs log = new LoginLogs()
                {
                    LoginId = objSP.SalesPersonId,
                    LoginName = objSP.SalesPersonName,
                    LoginTime = DateTime.Now,
                    ServerName = Dns.GetHostName()
                };
                objSP.LogId = WriteLoginLog(log);

                return objSP;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 用户登出
        /// </summary>
        /// <param name="logId"></param>
        public bool UserLogout(int logId)
        {
            if(1 == WriteExitLog(logId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 写入登录日志
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        private int WriteLoginLog(LoginLogs log)
        {
            string sql = "insert into LoginLogs (LoginId,LoginName,ServerName,LoginTime) values (@LoginId,@LoginName,@ServerName,@LoginTime);select @@identity;";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@LoginId",log.LoginId),
                new SqlParameter("@LoginName",log.LoginName),
                new SqlParameter("@ServerName",log.ServerName),
                new SqlParameter("@LoginTime",log.LoginTime)
            };
            return Convert.ToInt32(Helper.SqlHelper.GetSingleResult(sql, param));
        }

        /// <summary>
        /// 写入退出日志
        /// </summary>
        /// <param name="logId"></param>
        /// <returns></returns>
        private int WriteExitLog(int logId)
        {
            string sql = "update LoginLogs set ExitTime=getdate() where LogId=@LogId";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@LogId",logId)
            };
            return Helper.SqlHelper.Update(sql, param);
        }
    }
}
