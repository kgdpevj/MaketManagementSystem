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
    public partial class FormAddProduct:Form
    {
        /// <summary>
        /// 创建业务逻辑对象
        /// </summary>
        ProductManager objProductManager = new ProductManager();

        public FormAddProduct()
        {
            InitializeComponent();
        }

        private void FormAddProduct_Load(object sender, EventArgs e)
        {
            //初始化商品分类下拉框
            this.cboCategory.DataSource = objProductManager.GetAllCategory();
            this.cboCategory.DisplayMember = "CategoryName";
            this.cboCategory.ValueMember = "CategoryId";
            this.cboCategory.SelectedIndex = -1;

            //初始化商品计量单位下拉框
            this.cboUnit.DataSource = objProductManager.GetAllUnit();
            this.cboUnit.DisplayMember = "UnitName";
            this.cboUnit.ValueMember = "UnitId";
            this.cboUnit.SelectedIndex = -1;
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            if(this.btnLock.Text == "锁定")
            {
                if(( this.cboCategory.SelectedIndex >= 0 )
                    && ( this.cboUnit.SelectedIndex >= 0 ))
                {
                    SetLock();
                }
            }
            else
            {
                SetUnlock();
            }
        }

        private void SetLock()
        {
            this.cboCategory.Enabled = false;
            this.cboUnit.Enabled = false;
            this.btnLock.Text = "解锁";
        }

        private void SetUnlock()
        {
            this.cboCategory.Enabled = true;
            this.cboUnit.Enabled = true;
            this.btnLock.Text = "锁定";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            #region 数据验证
            if(!VerifyInput())
            {
                return;
            }
            #endregion

            //封装商品对象
            Products objProduct = new Products()
            {
                ProductId = this.txtProductId.Text.Trim(),
                ProductName = this.txtProductName.Text.Trim(),
                UnitId = Convert.ToInt32(this.cboUnit.SelectedValue),
                CategoryId = Convert.ToInt32(this.cboCategory.SelectedValue),
                UnitPrice = Convert.ToDouble(this.txtUnitPrice.Text.Trim()),
                MaxCount = Convert.ToInt32(this.txtMaxCount.Text.Trim()),
                MinCount = Convert.ToInt32(this.txtMinCount.Text.Trim())
            };
            //执行添加商品
            try
            {
                objProductManager.AddProduct(objProduct);
                DialogResult result =
                Common.MessageBoxEx.Show("添加商品成功，是否继续添加？", Program.MessageBoxTitle[Program.MessageBoxTitleType.Question], string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    ResetControls(this);
                    this.txtProductId.Focus();
                }
                else
                {
                    this.btnClose.PerformClick();
                }
            }
            catch(System.Exception ex)
            {
                Common.MessageBoxEx.Show("添加商品时访问数据库出错！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Error], ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if(this.txtMaxCount.Text.Trim().Length == 0)
            {
                Common.MessageBoxEx.Show("请为填写最大库存！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtMaxCount.Focus();
                return false;
            }
            if(!Common.DataValidate.IsNonNegativeIntegers(this.txtMaxCount.Text.Trim()))
            {
                Common.MessageBoxEx.Show("请为填写正确的最大库存！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], "最大库存应是正整数！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtMaxCount.Focus();
                return false;
            }
            if(this.txtMinCount.Text.Trim().Length == 0)
            {
                Common.MessageBoxEx.Show("请为填写最小库存！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtMinCount.Focus();
                return false;
            }
            if(!Common.DataValidate.IsNonNegativeIntegers(this.txtMinCount.Text.Trim()))
            {
                Common.MessageBoxEx.Show("请为填写正确的最小库存！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], "最小库存应是正整数！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtMinCount.Focus();
                return false;
            }
            return true;
        }
        private void ResetControls(Control control)
        {
            foreach(Control item in control.Controls)
            {
                if(item is TextBox)
                {
                    item.Text = "";
                }
                else if(item is ComboBox)
                {
                    if(this.btnLock.Text == "锁定")
                    {
                        ( (ComboBox)item ).SelectedIndex = -1;
                    }
                }
                else
                {
                    ResetControls(item);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAddProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormMain.objFormAddProduct = null;
        }
    }
}
