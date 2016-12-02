using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Model;
using BLL;

namespace SMartStorageManager.Product
{
    public partial class FormSaleStatistics:Form
    {
        private ProductManager objProductManager = new ProductManager();
        public FormSaleStatistics()
        {
            InitializeComponent();
            this.dgvProductStat.AutoGenerateColumns = false;
        }

        private void btnStat_Click(object sender, EventArgs e)
        {
            if(!VerifyInput())
            {
                return;
            }
            DateTime start = Convert.ToDateTime(this.dtpStart.Text);
            DateTime end = Convert.ToDateTime(this.dtpEnd.Text).AddDays(1);
            this.dgvProductStat.DataSource = objProductManager.GetSaleStatistics(start, end);
        }
        private bool VerifyInput()
        {
            DateTime start = Convert.ToDateTime(this.dtpStart.Text);
            DateTime end = Convert.ToDateTime(this.dtpEnd.Text);
            if(start > end)
            {
                Common.MessageBoxEx.Show("开始时间不能晚于截止时间！", Program.MessageBoxTitle[Program.MessageBoxTitleType.Tips], string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSaleStatistics_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormMain.objFormSaleStatistics = null;
        }
    }
}
