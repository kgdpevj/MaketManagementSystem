using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BLL;
using Model;

namespace SMartStorageManager
{
    public partial class FormLogin:Form
    {
        //用户登录业务处理对象
        SysAdminManager objSysAdminManager = new SysAdminManager();
        public FormLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //验证用户输入的信息
            string loginId = this.txtLoginId.Text.Trim();
            string loginPwd = this.txtLoginPwd.Text.Trim();
            if(loginId.Length == 0)
            {
                Common.MessageBoxEx.Show("请输入用户名！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], "用户名不能为空！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(!Common.DataValidate.IsInteger(loginId))
            {
                Common.MessageBoxEx.Show("请输入正确的用户名！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], "用户名只能是数字！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(loginPwd.Length == 0)
            {
                Common.MessageBoxEx.Show("请输入密码！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], "密码不能为空！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //调用登录逻辑
            SysAdmins objAdmin = new SysAdmins()
            {
                LoginId = Convert.ToInt32(loginId),
                LoginPassword = loginPwd
            };
            try
            {
                objAdmin = objSysAdminManager.UserLogin(objAdmin);
            }
            catch(System.Exception ex)
            {
                Common.MessageBoxEx.Show("登录时访问数据库出错！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Error], ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //根据登录是否成功执行相关任务
            if(null != objAdmin)
            {
                if(objAdmin.AdminStatus == 1)//用户账号有效
                {
                    Program.objSysAdmins = objAdmin;//保存用户登录信息
                    this.DialogResult = DialogResult.OK;//返回正确的登录结果
                }
                else//账户已被禁用
                {
                    Common.MessageBoxEx.Show("账号【" + objAdmin.LoginId + ":" + objAdmin.AdminName + "】已被禁用！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Error], string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //账号和密码不正确
            else
            {
                Common.MessageBoxEx.Show("用户名或密码错误！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Error], string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if(keyData == Keys.Escape)
            {
                btnCancel.PerformClick();
                return false;
            }
            else
                return base.ProcessDialogKey(keyData);
        }

        private void txtLoginId_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtLoginPwd.Focus();
            }
        }

        private void txtLoginPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
    }
}
