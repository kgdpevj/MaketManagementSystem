using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;
using Models;

namespace BLL
{
    /// <summary>
    /// 用户登录业务管理类
    /// </summary>
    public class UserLoginManager
    {
        // 用户登录数据访问类
        UserLoginService objUserLoginService = new UserLoginService();

        //销售员登录
        public SalesPerson SalePersonLogin(SalesPerson sp)
        {
            return objUserLoginService.UserLogin(sp);
        }

        //销售员登出
        public void SalePersonLogout(int logId)
        {
            objUserLoginService.UserLogout(logId);
        }
    }
}
