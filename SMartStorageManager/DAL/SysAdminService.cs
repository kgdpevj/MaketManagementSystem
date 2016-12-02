using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Model;

namespace DAL
{
    public class SysAdminService
    {

        /// <summary>
        /// 根据登录账号和密码查询管理员信息
        /// </summary>
        /// <param name="objSysAdmin"></param>
        /// <returns></returns>
        public SysAdmins UserLogin(SysAdmins objSysAdmin)
        {
            string sql = "select LoginId, AdminName, AdminStatus, RoleId from SysAdmins where LoginId=@LoginId and LoginPassword=@LoginPassword";

            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@LoginId",objSysAdmin.LoginId),
                new SqlParameter("@LoginPassword",objSysAdmin.LoginPassword)
            };
            SqlDataReader reader = Helper.SQLHelper.GetReader(sql, param);
            SysAdmins objAdmin = null;
            if(reader.Read())
            {
                objAdmin = new SysAdmins()
                {
                    LoginId = Convert.ToInt32(reader["LoginId"]),
                    AdminName = reader["AdminName"].ToString(),
                    AdminStatus = Convert.ToByte(reader["AdminStatus"]),
                    RoleId = Convert.ToInt32(reader["RoleId"])
                };
            }
            return objAdmin;
        }
        public int WriteLoginLog(LoginLogs objLoginLog)
        {
            string sql = "insert into LoginLogs(LoginId, LoginName, ServerName, LoginTime) values(@LoginId,@LoginName,@LoginName,getdate());select @@identity;";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@LoginId",objLoginLog.LoginId),
                new SqlParameter("@LoginName",objLoginLog.LoginName),
                new SqlParameter("@ServerName",Dns.GetHostName())
            };
            return Convert.ToInt32(Helper.SQLHelper.GetSingleResult(sql, param));
        }
        public int WriteExitLog(int logId)
        {
            string sql = "update LoginLogs set ExitTime=getdate() where LogId=@LogId";
            SqlParameter[] param = new SqlParameter[] {
                 new SqlParameter("@LogId",logId)
            };
            return Helper.SQLHelper.Update(sql, param);
        }
        /// <summary>
        /// 查找是否有包含给定密码的用户
        /// </summary>
        /// <param name="objAdmin"></param>
        /// <returns></returns>
        public int IsRightPassword(SysAdmins objAdmin)
        {
            string sql = "select count(*) from SysAdmins where LoginId=@LoginId and LoginPassword=@LoginPassword";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@LoginId",objAdmin.LoginId),
                new SqlParameter("@LoginPassword",objAdmin.LoginPassword)
            };
            object result = Helper.SQLHelper.GetSingleResult(sql, param);
            return Convert.ToInt32(result);
        }
        public int ModifyPassword(SysAdmins objAdmin, string newPassword)
        {
            string sql = "update SysAdmins set LoginPassword=@NewPassword where LoginId=@LoginId";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@LoginId",objAdmin.LoginId),
                new SqlParameter("@NewPassword",newPassword)
            };
            object result = Helper.SQLHelper.Update(sql, param);
            return Convert.ToInt32(result);
        }
    }
}
