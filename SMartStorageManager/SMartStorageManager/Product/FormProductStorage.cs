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
    public partial class FormProductStorage:Form
    {
        ProductManager objProductManager = new ProductManager();
        private Products objProduct = null;

        public FormProductStorage()
        {
            InitializeComponent();
        }
        public FormProductStorage(Products product) : this()
        {
            this.objProduct = product;
            this.txtProductId.ReadOnly = true;
        }

        private void FormProductStorage_Load(object sender, EventArgs e)
        {
            if(objProduct != null)
            {
                this.txtProductId.Text = objProduct.ProductId;
                this.txtProductName.Text = objProduct.ProductName;
                this.txtQuantity.Focus();
            }
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(!ValidateProductId() || !ValidateTotalCount())
            {
                return;
            }
            try
            {
                objProductManager.UpdateInventory(this.txtProductId.Text.Trim(), Convert.ToInt32(this.txtQuantity.Text.Trim()));

                this.txtProductId.Clear();
                this.txtProductName.Clear();
                this.txtQuantity.Clear();
                this.txtProductId.Focus();
            }
            catch(System.Exception ex)
            {
                Common.MessageBoxEx.Show("商品入库时，访问数据库出错！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Error], ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FormProductStorage_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormMain.objFormProductStorage = null;
        }

        /// <summary>
        /// 检验商品编号是否正确
        /// </summary>
        /// <returns></returns>
        private bool ValidateProductId()
        {
            if(this.txtProductId.Text.Trim().Length == 0)
            {
                //Common.MessageBoxEx.Show("请输入商品编号！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], "商品编号不能为空！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtProductId.Focus();
                return false;
            }
            Products objProduct = objProductManager.GetProductById(this.txtProductId.Text.Trim());
            if(objProduct == null)
            {
                Common.MessageBoxEx.Show("商品编号【" + this.txtProductId.Text.Trim() + "】不存在！请添加商品信息或修改当前商品编号！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], "数据库里不存在商品编号【" + this.txtProductId.Text.Trim() + "】！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtProductId.Clear();
                this.txtProductName.Clear();
                this.txtProductId.Focus();
                return false;
            }
            else
            {
                this.txtProductName.Text = objProduct.ProductName;
                this.txtQuantity.Focus();
                return true;
            }
        }

        private bool ValidateTotalCount()
        {
            if(!Common.DataValidate.IsRealNumber(this.txtQuantity.Text.Trim()))
            {
                Common.MessageBoxEx.Show("请输入数字！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtQuantity.Focus();
                return false;
            }
            if(Convert.ToInt32(this.txtQuantity.Text.Trim()) == 0)
            {
                Common.MessageBoxEx.Show("请输入正确的入库数量！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtQuantity.Focus();
                return false;
            }
            return true;
        }

        private void txtProductId_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                ValidateProductId();
            }
        }

        private void txtProductId_MouseLeave(object sender, EventArgs e)
        {
            ValidateProductId();
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.btnConfirm.PerformClick();
            }
        }
    }
}
