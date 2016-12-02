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

namespace SMartStorageManager.Product
{
    public partial class FormEditProduct:Form
    {
        /// <summary>
        /// 创建业务逻辑对象
        /// </summary>
        private ProductManager objProductManager = new ProductManager();
        private Products objProduct = null;

        public FormEditProduct()
        {
            InitializeComponent();
        }
        public FormEditProduct(Products objPro) : this()
        {
            objProduct = objPro;
        }

        private void FormEditProduct_Load(object sender, EventArgs e)
        {
            //初始化商品分类下拉框
            this.cboCategory.DataSource = objProductManager.GetAllCategory();
            this.cboCategory.DisplayMember = "CategoryName";
            this.cboCategory.ValueMember = "CategoryId";
            this.cboCategory.SelectedValue = objProduct.CategoryId;

            //初始化商品计量单位下拉框
            this.cboUnit.DataSource = objProductManager.GetAllUnit();
            this.cboUnit.DisplayMember = "UnitName";
            this.cboUnit.ValueMember = "UnitId";
            this.cboUnit.SelectedValue = objProduct.UnitId;

            this.txtProductId.Text = objProduct.ProductId;
            this.txtProductName.Text = objProduct.ProductName;
            this.txtUnitPrice.Text = Common.Numeric.ToMoneyFormat(objProduct.UnitPrice);
            this.txtProductId.Focus();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            #region 数据验证
            if(!VerifyInput())
            {
                return;
            }
            #endregion

            #region 封装商品对象
            Products objProductNew = new Products()
            {
                ProductId = this.txtProductId.Text.Trim(),
                ProductName = this.txtProductName.Text.Trim(),
                UnitPrice = Convert.ToDouble(this.txtUnitPrice.Text.Trim()),
                CategoryId = this.cboCategory.SelectedIndex,
                UnitId = this.cboUnit.SelectedIndex
            };
            #endregion
            #region 提交修改
            //执行修改商品
            try
            {
                objProductManager.EditProduct(objProductNew, objProduct);
                DialogResult result =
                Common.MessageBoxEx.Show("商品修改成功！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Question], string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Question);
                this.Close();
            }
            catch(System.Exception ex)
            {
                Common.MessageBoxEx.Show("添加商品时访问数据库出错！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Error], ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
        }
        private bool VerifyInput()
        {
            if(this.cboCategory.SelectedIndex < 0)
            {
                Common.MessageBoxEx.Show("请为商品选择一个分类！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if(this.cboUnit.SelectedIndex < 0)
            {
                Common.MessageBoxEx.Show("请为商品选择一个计量单位！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if(this.txtProductId.Text.Trim().Length == 0)
            {
                Common.MessageBoxEx.Show("请为填写商品编码！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtProductId.Focus();
                return false;
            }
            if(this.txtProductName.Text.Trim().Length == 0)
            {
                Common.MessageBoxEx.Show("请为填写商品名称！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtProductName.Focus();
                return false;
            }
            if(this.txtUnitPrice.Text.Trim().Length == 0)
            {
                Common.MessageBoxEx.Show("请为填写商品单价！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtUnitPrice.Focus();
                return false;
            }
            if(!Common.DataValidate.IsNonNegativeReal(this.txtUnitPrice.Text.Trim()))
            {
                Common.MessageBoxEx.Show("请为填写正确的商品单价！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], "商品单价应是正实数！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtUnitPrice.Focus();
                return false;
            }
            return true;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
