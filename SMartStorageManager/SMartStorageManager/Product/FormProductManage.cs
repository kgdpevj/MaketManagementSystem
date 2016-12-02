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
    public partial class FormProductManage:Form
    {
        private ProductManager objProductManager = new ProductManager();

        private DataTable objDataTable = new DataTable();

        private int currentRowIndex = -1;
        public FormProductManage()
        {
            InitializeComponent();
        }

        private void FormProductManage_Load(object sender, EventArgs e)
        {
            List<ProductCategory> categoryList = objProductManager.GetAllCategory();
            categoryList.Insert(0, new ProductCategory()
            {
                CategoryId = -1,
                CategoryName = string.Empty
            });
            this.cboCategory.DataSource = categoryList;
            this.cboCategory.DisplayMember = "CategoryName";
            this.cboCategory.ValueMember = "CategoryId";
            this.cboCategory.SelectedValue = -1;

            this.dgvProduct.AutoGenerateColumns = false;
            this.dgvProduct.DataSource = this.objDataTable;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                currentRowIndex = -1;
                this.objDataTable = objProductManager.QueryInventoryInfo(this.txtProductId.Text.Trim(), this.txtProductName.Text.Trim(), Convert.ToInt32(this.cboCategory.SelectedValue));
            }
            catch(System.Exception ex)
            {
                Common.MessageBoxEx.Show("查询库存信息时，访问数据库出现错误！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Error], ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.dgvProduct.DataSource = this.objDataTable;
            if(currentRowIndex != -1)
            {
                int lastIndex = currentRowIndex;
                if(lastIndex < objDataTable.Rows.Count)
                {
                    this.dgvProduct.CurrentCell = this.dgvProduct.Rows[lastIndex].Cells[0];
                }
            }
            else
            {
                currentRowIndex = 0;
            }
        }

        private void btnStorage_Click(object sender, EventArgs e)
        {
            if(this.dgvProduct.CurrentRow == null)
            {
                return;
            }
            DataRow dr = this.objDataTable.Rows[this.dgvProduct.CurrentRow.Index];

            Products objpro = new Products()
            {
                ProductId = dr["ProductId"].ToString(),
                ProductName = dr["ProductName"].ToString(),
                UnitId = Convert.ToInt32(dr["UnitId"]),
                UnitName = dr["UnitName"].ToString(),
                UnitPrice = Convert.ToDouble(dr["UnitPrice"]),
                Discount = Convert.ToInt32(dr["Discount"]),
                TotalCount = Convert.ToInt32(dr["TotalCount"]),
                MaxCount = Convert.ToInt32(dr["MaxCount"]),
                MinCount = Convert.ToInt32(dr["MinCount"]),
                StatusId = Convert.ToInt32(dr["StatusId"]),
                StatusDescription = dr["StatusDescription"].ToString(),
                CategoryId = Convert.ToInt32(dr["CategoryId"]),
                CategoryName = dr["CategoryName"].ToString()
            };
            FormProductStorage objFormProductStorage = new FormProductStorage(objpro);
            objFormProductStorage.ShowDialog();
            btnQuery.PerformClick();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAddProduct objFormAddProduct = new FormAddProduct();
            objFormAddProduct.ShowInTaskbar = false;
            objFormAddProduct.ShowDialog();
            btnQuery.PerformClick();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if(this.dgvProduct.CurrentRow == null)
            {
                return;
            }
            DataRow dr = this.objDataTable.Rows[this.dgvProduct.CurrentRow.Index];

            Products objpro = new Products()
            {
                ProductId = dr["ProductId"].ToString(),
                ProductName = dr["ProductName"].ToString(),
                UnitId = Convert.ToInt32(dr["UnitId"]),
                UnitName = dr["UnitName"].ToString(),
                UnitPrice = Convert.ToDouble(dr["UnitPrice"]),
                Discount = Convert.ToInt32(dr["Discount"]),
                TotalCount = Convert.ToInt32(dr["TotalCount"]),
                MaxCount = Convert.ToInt32(dr["MaxCount"]),
                MinCount = Convert.ToInt32(dr["MinCount"]),
                StatusId = Convert.ToInt32(dr["StatusId"]),
                StatusDescription = dr["StatusDescription"].ToString(),
                CategoryId = Convert.ToInt32(dr["CategoryId"]),
                CategoryName = dr["CategoryName"].ToString()
            };
            FormEditProduct objFormEditProduct = new FormEditProduct(objpro);
            objFormEditProduct.ShowInTaskbar = false;
            objFormEditProduct.ShowDialog();
            btnQuery.PerformClick();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if(this.dgvProduct.CurrentRow == null)
            {
                return;
            }
            try
            {
                if(1 == objProductManager.DelProductInventory(this.dgvProduct.CurrentRow.Cells["ProductId"].Value.ToString()))
                {
                    btnQuery.PerformClick();
                }
            }
            catch(System.Exception ex)
            {
                Common.MessageBoxEx.Show("删除商品【" + this.dgvProduct.CurrentRow.Cells["ProductId"].Value.ToString() + "】时，访问数据库出现错误！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Error], ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateDiscount_Click(object sender, EventArgs e)
        {
            if(this.dgvProduct.CurrentRow != null)
            {
                if(!Common.DataValidate.IsNonNegativeReal(this.txtDiscount.Text.Trim()))
                {
                    Common.MessageBoxEx.Show("请输入非负数字！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Question], "折扣信息是百分比数字，如 九折：90,八五折：85", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
                else
                {
                    try
                    {
                        if(1 == objProductManager.UpdateDiscount(this.dgvProduct.CurrentRow.Cells["ProductId"].Value.ToString(), Convert.ToInt32(this.txtDiscount.Text.Trim())))
                        {
                            btnQuery.PerformClick();
                        }
                    }
                    catch(System.Exception ex)
                    {
                        Common.MessageBoxEx.Show("更新商品【" + this.dgvProduct.CurrentRow.Cells["ProductId"].Value.ToString() + "】折扣信息时，访问数据库出现错误！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Error], ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormProductManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormMain.objFormProductManage = null;
        }

        private void dgvProduct_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Common.ControlDecoration.SetDataGridViewRowNumber(sender, e);
        }

        private void dgvProduct_CurrentCellChanged(object sender, EventArgs e)
        {
            if(this.dgvProduct.CurrentCell != null)
            {
                this.txtDiscount.Text = this.dgvProduct.CurrentRow.Cells["Discount"].Value.ToString();
                currentRowIndex = this.dgvProduct.CurrentRow.Index;
            }
        }

        private void txtProductId_TextChanged(object sender, EventArgs e)
        {
            if(currentRowIndex == -1)
            {
                return;
            }
            btnQuery.PerformClick();
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            if(currentRowIndex == -1)
            {
                return;
            }
            btnQuery.PerformClick();
        }

        private void cboCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            if(currentRowIndex == -1)
            {
                return;
            }
            btnQuery.PerformClick();
        }
    }
}
