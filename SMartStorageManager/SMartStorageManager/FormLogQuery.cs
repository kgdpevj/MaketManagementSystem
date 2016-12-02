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
    public partial class FormLogQuery:Form
    {
        private DataPagerManager objDataPagerManager = new DataPagerManager();
        private DataTable dt = null;
        public FormLogQuery()
        {
            InitializeComponent();
        }

        private void FormLogQuery_Load(object sender, EventArgs e)
        {
            //List<string> numPerPageList = new List<string>() { "5", "10", "15", "20", "30", "50", "100", };
            //foreach(var item in numPerPageList)
            //{
            //    this.cbbPageSize.Items.Insert(this.cbbPageSize.Items.Count, item);
            //}
            //}
            this.dgvLogs.AutoGenerateColumns = false;

            this.cbbPageSize.SelectedIndex = 0;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            DoQuery(Convert.ToInt32(this.cbbPageSize.Text), 1, this.dtpStart.Text, this.dtpEnd.Text);
        }
        private void DoQuery(int pageSize, int currentPage, string startTime, string endTime)
        {
            objDataPagerManager.PageSize = pageSize;
            objDataPagerManager.CurrentPage = currentPage;
            try
            {

                this.dgvLogs.DataSource = objDataPagerManager.QueryLog(startTime, endTime);
            }
            catch(System.Exception ex)
            {
                Common.MessageBoxEx.Show("查询日志时，访问数据库出错！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Error], ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SetUI();
        }

        private void SetUI()
        {
            this.lblRecordCount.Text = objDataPagerManager.RecordCount.ToString();
            this.lblPageCount.Text = objDataPagerManager.PageCount.ToString();
            this.lblCurrentPage.Text = objDataPagerManager.CurrentPage.ToString();

            if(objDataPagerManager.CurrentPage == 1)
            {
                this.btnFirst.Enabled = false;
                this.btnPrevious.Enabled = false;
                this.btnLast.Enabled = true;
                this.btnNext.Enabled = true;
            }
            else if(objDataPagerManager.CurrentPage == objDataPagerManager.PageCount)
            {
                this.btnFirst.Enabled = true;
                this.btnPrevious.Enabled = true;
                this.btnLast.Enabled = false;
                this.btnNext.Enabled = false;
            }
            else
            {
                this.btnFirst.Enabled = true;
                this.btnPrevious.Enabled = true;
                this.btnLast.Enabled = true;
                this.btnNext.Enabled = true;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormLogQuery_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormMain.objFormLogQuery = null;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            btnQuery.PerformClick();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            DoQuery(Convert.ToInt32(this.cbbPageSize.Text), Convert.ToInt32(this.lblCurrentPage.Text.Trim()) - 1, this.dtpStart.Text, this.dtpEnd.Text);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            DoQuery(Convert.ToInt32(this.cbbPageSize.Text), Convert.ToInt32(this.lblCurrentPage.Text.Trim()) + 1, this.dtpStart.Text, this.dtpEnd.Text);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            DoQuery(Convert.ToInt32(this.cbbPageSize.Text), Convert.ToInt32(this.lblPageCount.Text.Trim()), this.dtpStart.Text, this.dtpEnd.Text);
        }

        private void btnGoTo_Click(object sender, EventArgs e)
        {
            if(!VerifyGotoPage())
            {
                return;
            }
            DoQuery(Convert.ToInt32(this.cbbPageSize.Text), Convert.ToInt32(this.txtGoTo.Text.Trim()), this.dtpStart.Text, this.dtpEnd.Text);
        }
        private bool VerifyGotoPage()
        {
            if(Convert.ToInt32(this.txtGoTo.Text.Trim()) <= 0 || Convert.ToInt32(this.txtGoTo.Text.Trim()) > Convert.ToInt32(this.lblPageCount.Text))
            {
                Common.MessageBoxEx.Show("请输入正确的页码！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtGoTo.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void dtpStart_MouseLeave(object sender, EventArgs e)
        {
            if(Convert.ToDateTime(this.dtpStart.Text) > Convert.ToDateTime(this.dtpEnd.Text))
            {
                Common.MessageBoxEx.Show("请选择结束时间之前的时间！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.dtpStart.Focus();
            }
        }

        private void dtpEnd_MouseLeave(object sender, EventArgs e)
        {
            if(Convert.ToDateTime(this.dtpStart.Text) > Convert.ToDateTime(this.dtpEnd.Text))
            {
                Common.MessageBoxEx.Show("请选择开始时间之后的时间！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.dtpEnd.Focus();
            }
        }

        private void dgvLogs_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Common.ControlDecoration.SetDataGridViewRowNumber(sender, e);
        }

        private void cbbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnQuery.PerformClick();
        }

        private void txtGoTo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnGoTo.PerformClick();
            }
        }
    }
}
