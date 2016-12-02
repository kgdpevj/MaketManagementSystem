using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using Model;
using DAL;

namespace BLL
{
    public class SysAdminManager
    {
        /// <summary>
        /// 管理员表数据访问对象
        /// </summary>
        private SysAdminService objSysAdminService = new SysAdminService();

        /// <summary>
        /// 根据登录账号和密码查询管理员信息
        /// </summary>
        /// <param name="objSysAdmin"></param>
        /// <returns></returns>
        public SysAdmins UserLogin(SysAdmins objSysAdmin)
        {
            //数据传递 + 业务内容
            //【1】根据用户账号和密码调用后台方法查询
            objSysAdmin = objSysAdminService.UserLogin(objSysAdmin);
            //【2】判断用户状态是否为【启用】
            if(null != objSysAdmin && objSysAdmin.AdminStatus == 1)
            {
                //【3】写入登录日志表，并保存用户的登录日志ID
                LoginLogs objLoginLog = new LoginLogs()
                {
                    LoginId = objSysAdmin.LoginId,
                    LoginName = objSysAdmin.AdminName,
                    ServerName = Dns.GetHostName()
                };
                //【4】保存当前管理员登录日志的ID（为后面退出系统，写入推出时间日志做准备）
                objSysAdmin.LoginLogId = objSysAdminService.WriteLoginLog(objLoginLog);
                // 【5】如果有权限管理，可以在这里编写调用数据访问对象中的权限查询，并封装
            }
            return objSysAdmin;
        }
        public int WriteExitLog(int logId)
        {
            return objSysAdminService.WriteExitLog(logId);
        }


        /// <summary>
        /// 查找是否有包含给定密码的用户
        /// </summary>
        /// <param name="objAdmin"></param>
        /// <returns></returns>
        public bool IsRightPassword(SysAdmins objAdmin)
        {
            int result = objSysAdminService.IsRightPassword(objAdmin);
            if(result != 0)
            {
                return true;
            }
            return false;
        }

        public bool ModifyPassword(SysAdmins objAdmin, string newPassword)
        {
            if(1 == objSysAdminService.ModifyPassword(objAdmin, newPassword))
            {
                return true;
            }
            return false;
        }
    }
}
