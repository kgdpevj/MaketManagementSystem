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
using Models;
using CommonUtility;

namespace SaleManager
{
    public partial class FormBalance:Form
    {
        private SalesManager objSaleManager = new SalesManager();

        private string tipsStrOld = string.Empty;
        private string tipsStr = string.Empty;
        private bool bComplete = false;
        private int timerTipsTick = 0;

        public SalesList salesList = null;

        public FormBalance()
        {
            InitializeComponent();
            this.toolStripStatusLabelTip.Text = tipsStrOld = "提示：结算完成后，可按F4返回";
        }
        public FormBalance(SalesList objSalesList) : this()
        {
            salesList = objSalesList;
            this.textBoxTotal.Text = NumericUtility.ToMoneyFormat(salesList.TotalMoney);
        }

        private void textBoxRealReceived_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                double total = salesList.TotalMoney;
                double paied = 0;
                if(!double.TryParse(this.textBoxRealReceived.Text.Trim(), out paied))
                {
                    SetNewTip("提示：请在实收款栏输入数字！", this.toolStripStatusLabelTip.Text);
                    return;
                }
                paied = Convert.ToDouble(this.textBoxRealReceived.Text);
                double shouldreturn = paied - total;
                if(paied >= total)
                {
                    this.textBoxRealReceived.Text = NumericUtility.ToMoneyFormat(paied);
                    this.textBoxReturnChange.Text = NumericUtility.ToMoneyFormat(shouldreturn);
                    if(this.textBoxVIPCardNo.Text.Trim().Length > 0)
                    {
                        salesList.VipCardNo = Convert.ToInt32(this.textBoxVIPCardNo.Text.Trim());
                    }
                    salesList.RealReceive = paied;
                    salesList.ReturnMoney = shouldreturn;
                    bComplete = true;
                }
            }
            else if(( e.KeyCode == Keys.F4 ) || ( e.KeyCode == Keys.F5 ))
            {
                FormBalance_KeyDown(sender, e);
            }
        }

        private void timerTips_Tick(object sender, EventArgs e)
        {
            timerTipsTick++;
            if(timerTipsTick == 1)
            {
                this.toolStripStatusLabelTip.Text = this.tipsStr;
            }
            else if(timerTipsTick > 5)
            {
                timerTips.Enabled = false;
                this.toolStripStatusLabelTip.Text = this.tipsStrOld;
            }
        }

        private void SetNewTip(string newtip, string oldtip)
        {
            tipsStrOld = oldtip;
            tipsStr = newtip;
            timerTipsTick = 0;
            timerTips.Enabled = true;
        }

        private void FormBalance_KeyDown(object sender, KeyEventArgs e)
        {
            this.Tag = e;
            if(e.KeyCode == Keys.F4)
            {
                this.Tag = e.KeyCode;
                if(bComplete)
                {
                    // 验证卡号是否存在，状态是否正常
                    // TODO
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    SetNewTip("提示：请结算完成后再返回！", this.toolStripStatusLabelTip.Text);
                }
            }
            else if(e.KeyCode == Keys.F5)
            {
                this.Close();
            }
        }
    }
}
