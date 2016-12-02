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
    public partial class FormInvertoryManage:Form
    {
        ProductManager objProductManager = new ProductManager();
        BindingSource bs = new BindingSource();
        int currentRowIndex = -1;
        int totalCount = 0, moreCount = 0, lessCount = 0;
        public FormInvertoryManage()
        {
            InitializeComponent();
        }

        private void FormInvertoryManage_Load(object sender, EventArgs e)
        {
            this.dgvProduct.AutoGenerateColumns = false;
            this.dgvProduct.DataSource = bs;

            DoWarningInfoQuery();
        }

        private void DoWarningInfoQuery()
        {
            try
            {
                objProductManager.QueryWarningCount(out totalCount, out moreCount, out lessCount);
                this.bs.DataSource = objProductManager.QueryWarningInfo();
            }
            catch(System.Exception ex)
            {
                Common.MessageBoxEx.Show("查询预警信息时，访问数据库出现错误！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Error], ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if(currentRowIndex != -1)
            {
                int lastIndex = currentRowIndex;
                if(lastIndex < bs.Count)
                {
                    this.dgvProduct.CurrentCell = this.dgvProduct.Rows[lastIndex].Cells[0];
                }
            }
            AdjustUI();
        }

        private void linkLabelRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DoWarningInfoQuery();
        }

        private void btnShowMax_Click(object sender, EventArgs e)
        {
            try
            {
                objProductManager.QueryWarningCount(out totalCount, out moreCount, out lessCount);
                this.bs.DataSource = objProductManager.QueryMoreWarningInfo();
            }
            catch(System.Exception ex)
            {
                Common.MessageBoxEx.Show("查询超低预警信息时，访问数据库出现错误！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Error], ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            currentRowIndex = 0;
            AdjustUI();
        }

        private void btnShowMin_Click(object sender, EventArgs e)
        {
            try
            {
                objProductManager.QueryWarningCount(out totalCount, out moreCount, out lessCount);
                this.bs.DataSource = objProductManager.QueryLessWarningInfo();
            }
            catch(System.Exception ex)
            {
                Common.MessageBoxEx.Show("查询预警信息时，访问数据库出现错误！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Error], ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            currentRowIndex = 0;
            AdjustUI();
        }
        private void AdjustUI()
        {
            this.lblCount.Text = totalCount.ToString();
            this.lblMaxCount.Text = moreCount.ToString();
            this.lblMinCount.Text = lessCount.ToString();
        }

        private void btnUpdateSet_Click(object sender, EventArgs e)
        {
            if(this.dgvProduct.CurrentRow == null)
            {
                return;
            }
            if(!Common.DataValidate.IsInteger(this.txtMaxCount.Text.Trim()))
            {
                Common.MessageBoxEx.Show("请输入正确的库存上限数量！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], "库存上限需要是正整数！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(!Common.DataValidate.IsInteger(this.txtMinCount.Text.Trim()))
            {
                Common.MessageBoxEx.Show("请输入正确的库存下限数量！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], "库存下限需要是正整数！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                objProductManager.UpdateMaxMinLimits(this.dgvProduct.CurrentRow.Cells["ProductId"].Value.ToString(), Convert.ToInt32(this.txtMaxCount.Text), Convert.ToInt32(this.txtMinCount.Text));
                DoWarningInfoQuery();
            }
            catch(System.Exception ex)
            {
                Common.MessageBoxEx.Show("更最大库存、最小库存时，访问数据库出现错误！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Error], ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateInventory_Click(object sender, EventArgs e)
        {
            if(this.dgvProduct.CurrentRow == null)
            {
                return;
            }
            if(!Common.DataValidate.IsInteger(this.txtTotalCount.Text.Trim()))
            {
                Common.MessageBoxEx.Show("请输入正确的库存数量！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], "库存数量需要是正整数！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                objProductManager.UpdateInventory(this.dgvProduct.CurrentRow.Cells["ProductId"].Value.ToString(), Convert.ToInt32(this.txtTotalCount.Text));
                DoWarningInfoQuery();
            }
            catch(System.Exception ex)
            {
                Common.MessageBoxEx.Show("更新库存时，访问数据库出现错误！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Error], ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormInvertoryManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormMain.objFormInvertoryManage = null;
        }

        private void txtProductId_TextChanged(object sender, EventArgs e)
        {
            DoWarningInfoQuery();
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            DoWarningInfoQuery();
        }

        private void cboCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            DoWarningInfoQuery();
        }

        private void dgvProduct_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Common.ControlDecoration.SetDataGridViewRowNumber(sender, e);
        }

        private void dgvProduct_CurrentCellChanged(object sender, EventArgs e)
        {
            if(this.dgvProduct.CurrentRow == null)
            {
                return;
            }
            currentRowIndex = this.dgvProduct.CurrentRow.Index;
            this.txtTotalCount.Text = this.dgvProduct.CurrentRow.Cells["TotalCount"].Value.ToString();
            this.txtMaxCount.Text = this.dgvProduct.CurrentRow.Cells["MaxCount"].Value.ToString();
            this.txtMinCount.Text = this.dgvProduct.CurrentRow.Cells["MinCount"].Value.ToString();
        }
    }
}
