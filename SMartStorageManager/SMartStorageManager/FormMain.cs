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
    public partial class FormMain:Form
    {
        SysAdminManager objSysAdminManager = new SysAdminManager();
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.lblAdminName.Text += Program.objSysAdmins.AdminName;
        }

        private void SetFormStartPosition(Form objForm)
        {
            objForm.Location = new Point(this.Location.X + this.spContainer.Panel1.Width + ( this.spContainer.Panel2.Width - objForm.Width ) / 2 + 12, this.Location.Y + ( this.spContainer.Panel2.Height - objForm.Height ) / 2 + 50);
        }
        private void CreateForm(Form objForm)
        {
            objForm.ShowInTaskbar = false;
            objForm.Show();
        }

        public static Product.FormAddProduct objFormAddProduct = null;
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if(objFormAddProduct == null)
            {
                objFormAddProduct = new Product.FormAddProduct();
                CreateForm(objFormAddProduct);
            }
            else
            {
                objFormAddProduct.Activate();//激活最小化的窗体
                objFormAddProduct.WindowState = FormWindowState.Normal;//让最小化的窗体正常显示
            }
            SetFormStartPosition(objFormAddProduct);

        }

        public static Product.FormProductStorage objFormProductStorage = null;
        private void btnProductInventory_Click(object sender, EventArgs e)
        {
            if(objFormProductStorage == null)
            {
                objFormProductStorage = new Product.FormProductStorage();
                CreateForm(objFormProductStorage);
            }
            else
            {
                objFormProductStorage.Activate();//激活最小化的窗体
                objFormProductStorage.WindowState = FormWindowState.Normal;//让最小化的窗体正常显示
            }
            SetFormStartPosition(objFormProductStorage);

        }

        public static Product.FormInvertoryManage objFormInvertoryManage = null;
        private void btnInventoryManage_Click(object sender, EventArgs e)
        {
            if(objFormInvertoryManage == null)
            {
                objFormInvertoryManage = new Product.FormInvertoryManage();
                CreateForm(objFormInvertoryManage);
            }
            else
            {
                objFormInvertoryManage.Activate();//激活最小化的窗体
                objFormInvertoryManage.WindowState = FormWindowState.Normal;//让最小化的窗体正常显示
            }
            SetFormStartPosition(objFormInvertoryManage);

        }

        public static Product.FormProductManage objFormProductManage = null;
        private void btnProductManage_Click(object sender, EventArgs e)
        {
            if(objFormProductManage == null)
            {
                objFormProductManage = new Product.FormProductManage();
                CreateForm(objFormProductManage);
            }
            else
            {
                objFormProductManage.Activate();//激活最小化的窗体
                objFormProductManage.WindowState = FormWindowState.Normal;//让最小化的窗体正常显示
            }
            SetFormStartPosition(objFormProductManage);

        }

        public static Product.FormSaleStatistics objFormSaleStatistics = null;
        private void btnSaleAnalasys_Click(object sender, EventArgs e)
        {
            if(objFormSaleStatistics == null)
            {
                objFormSaleStatistics = new Product.FormSaleStatistics();
                CreateForm(objFormSaleStatistics);
            }
            else
            {
                objFormSaleStatistics.Activate();//激活最小化的窗体
                objFormSaleStatistics.WindowState = FormWindowState.Normal;//让最小化的窗体正常显示
            }
            SetFormStartPosition(objFormSaleStatistics);
        }

        public static FormLogQuery objFormLogQuery = null;
        private void btnLogQuery_Click(object sender, EventArgs e)
        {
            if(objFormLogQuery == null)
            {
                objFormLogQuery = new FormLogQuery();
                CreateForm(objFormLogQuery);
            }
            else
            {
                objFormLogQuery.Activate();//激活最小化的窗体
                objFormLogQuery.WindowState = FormWindowState.Normal;//让最小化的窗体正常显示
            }
            SetFormStartPosition(objFormLogQuery);
        }

        public static AdminManager.FormModifyPwd objFormModifyPwd = null;
        private void btnModifyPwd_Click(object sender, EventArgs e)
        {
            if(objFormModifyPwd == null)
            {
                objFormModifyPwd = new AdminManager.FormModifyPwd(Program.objSysAdmins);
                CreateForm(objFormModifyPwd);
            }
            else
            {
                objFormModifyPwd.Activate();//激活最小化的窗体
                objFormModifyPwd.WindowState = FormWindowState.Normal;//让最小化的窗体正常显示
            }
            SetFormStartPosition(objFormModifyPwd);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                objSysAdminManager.WriteExitLog(Program.objSysAdmins.LoginLogId);
            }
            catch(System.Exception ex)
            {
                Common.MessageBoxEx.Show("退出时访问数据库出错！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Error], ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }
    }
}
