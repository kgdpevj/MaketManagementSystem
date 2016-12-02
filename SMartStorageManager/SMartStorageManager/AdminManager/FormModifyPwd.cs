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

namespace SMartStorageManager.AdminManager
{
    public partial class FormModifyPwd:Form
    {
        private SysAdminManager objSysAdminManager = new SysAdminManager();

        private SysAdmins objAdmin = null;
        public FormModifyPwd()
        {
            InitializeComponent();
        }
        public FormModifyPwd(SysAdmins objAdmin) : this()
        {
            this.objAdmin = objAdmin;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if(this.objAdmin == null)
            {
                return;
            }
            //验证输入
            if(!VerifyInput())
            {
                return;
            }
            //验证旧密码
            this.objAdmin.LoginPassword = this.txtOldPwd.Text.Trim();
            if(!objSysAdminManager.IsRightPassword(this.objAdmin))
            {
                Common.MessageBoxEx.Show("原密码不正确！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Error], string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!objSysAdminManager.ModifyPassword(this.objAdmin, this.txtNewPwd.Text.Trim()))
            {
                Common.MessageBoxEx.Show("修改密码是失败！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Common.MessageBoxEx.Show("密码修改成功，请重新登录！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Restart();
            }
        }
        private bool VerifyInput()
        {
            if(this.txtOldPwd.Text.Trim().Length == 0)
            {
                Common.MessageBoxEx.Show("请输入原密码！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if(this.txtNewPwd.Text.Trim().Length == 0)
            {
                Common.MessageBoxEx.Show("请输入新密码！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if(this.txtConfirmPwd.Text.Trim().Length == 0)
            {
                Common.MessageBoxEx.Show("请再次输入新密码！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if(!this.txtConfirmPwd.Text.Trim().Equals(this.txtNewPwd.Text.Trim()))
            {
                Common.MessageBoxEx.Show("两次输入的新密码不一致！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormModifyPwd_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormMain.objFormModifyPwd = null;
        }
    }
}
