using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Models;
using BLL;
using CommonUtility;

namespace SaleManager
{
    public partial class FormLogin:Form
    {
        UserLoginManager objUserLoginManager = new UserLoginManager();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            #region 1.输入验证
            // 用户名为空验证
            if(this.textBoxUserName.Text.Trim().Length == 0)
            {
                MessageBoxEx.Show("请输入用户名！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], "用户名不能为空！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //密码为空验证
            if(this.textBoxPassword.Text.Trim().Length == 0)
            {
                MessageBoxEx.Show("请输入密码！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], "密码不能为空！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            #endregion
            #region 2.封装登录对象
            SalesPerson sp = new SalesPerson();
            sp.SalesPersonId = Convert.ToInt32(this.textBoxUserName.Text.Trim());
            sp.LoginPassword = this.textBoxPassword.Text.Trim();
            #endregion
            #region 3.查询登录对象并保存查询到的
            try
            {
                sp = objUserLoginManager.SalePersonLogin(sp);
            }
            catch(Exception ex)
            {
                MessageBoxEx.Show("登录时访问数据库出错！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Error], "请检查数据库服务是否可用！\r" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if(null != sp)
            {
                Program.LoginSalePerson = sp;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBoxEx.Show("登录失败！\r用户名或密码错误", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], "用户名或密码错误！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            #endregion
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.textBoxPassword.Focus();
            }
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.buttonLogin.PerformClick();
            }
        }
    }
}
