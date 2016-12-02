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
using System.Threading;

namespace SaleManager
{
    public partial class FormMain:Form
    {
        private UserLoginManager objUserLoginManager = new UserLoginManager();
        private SalesManager objSalesManager = new SalesManager();
        private ProductsManager objProductManager = new ProductsManager();

        private List<SalesListDetail> salesListDetailList = new List<SalesListDetail>();
        private BindingSource bs = new BindingSource();

        private int tipsTimerCount = 0;
        private string tipsStr = string.Empty;
        private string tipsStrOld = string.Empty;

        public FormMain()
        {
            InitializeComponent();
            this.dataGridViewMain.AutoGenerateColumns = false;
            this.bs.DataSource = this.salesListDetailList;
            this.dataGridViewMain.DataSource = bs;
            //new DataGridViewStyleUtility().DgvStyle2(dataGridViewMain);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // 显示登录的用户名
            this.toolStripStatusLabelLoginName.Text = "收款员：" + Program.LoginSalePerson.SalesPersonName;
            // 生成流水号
            this.textBoxSerialNumber.Text = GetNewSerialNumber();
        }
        /// <summary>
        /// 获取生成的流水号
        /// </summary>
        /// <returns></returns>
        private string GetNewSerialNumber()
        {
            // 生成流水账号
            return objSalesManager.GetSerialNumber();
        }
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 退出提示
            if(DialogResult.No == MessageBoxEx.Show("确认退出【实惠到家收银系统V2.0】吗？",
                Program.MessageBoxTitle[Program.MessageBoxTitleType.Question], "",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2))
            {
                e.Cancel = true;
                return;
            }
            // 退出时间写入数据库记录
            objUserLoginManager.SalePersonLogout(Program.LoginSalePerson.LogId);
        }

        private void textBoxProductId_KeyDown(object sender, KeyEventArgs e)
        {
            //按下了回车键
            if(e.KeyCode == Keys.Enter)
            {
                // 验证输入
                if(!VlidateInput())
                {
                    return;
                }
                // 添加到明细列表
                AddOrUpdateList();
                // 更新界面信息
                // 更新单价、折扣、总价信息
                AdjustUi();
            }
            // 按下向右箭头键
            else if(e.KeyCode == Keys.Right)
            {
                //this.ActiveControl = this.textBoxCount;
                // 激活数量输入框
                this.textBoxCount.Focus();
            }
            // 按下向上箭头键
            else if(e.KeyCode == Keys.Up)
            {
                if(this.dataGridViewMain.RowCount < 2)
                    return;
                this.bs.MovePrevious();
            }
            // 按下向下箭头键
            else if(e.KeyCode == Keys.Down)
            {
                if(this.dataGridViewMain.RowCount < 2)
                    return;
                this.bs.MoveNext();
            }
            // 按下del键 
            else if(e.KeyCode == Keys.Delete)
            {
                if(this.dataGridViewMain.RowCount == 0)
                    return;
                if(bs.Current != null)
                {
                    bs.RemoveCurrent();
                }
                AdjustTotal();
            }
            // 按下F1
            else if(e.KeyCode == Keys.F1)
            {
                // 触发结算
                this.FormMain_KeyDown(sender, e);
            }
        }
        /// <summary>
        /// 验证输入
        /// </summary>
        private bool VlidateInput()
        {
            // 验证商品条码
            if(this.textBoxProductId.Text.Trim().Length == 0)
            {
                SetNewTip("提示：其扫描或输入商品条码！", this.toolStripStatusLabelTips.Text);
                return false;
            }
            // 验证数量
            int count = 0;
            if(!int.TryParse(this.textBoxCount.Text.Trim(), out count))
            {
                SetNewTip("提示：请在数量栏输入数字！", this.toolStripStatusLabelTips.Text);
                return false;
            }
            // 验证单价
            double price = 0;
            if(!double.TryParse(this.textBoxPrice.Text.Trim(), out price))
            {
                SetNewTip("提示：请在单价栏输入数字！", this.toolStripStatusLabelTips.Text);
                return false;
            }
            // 验证折扣
            int discount = 0;
            if(!int.TryParse(this.textBoxDiscount.Text.Trim(), out discount))
            {
                SetNewTip("提示：请在折扣栏输入数字！", this.toolStripStatusLabelTips.Text);
                return false;
            }
            return true;
        }

        private void AddOrUpdateList()
        {
            // 商品明细中没有找到
            if(!IsExisted())
            {
                NotExisted();
            }
        }

        private bool IsExisted()
        {
            SalesListDetail salesListDetail = null;
            // linq查询判断商品明细中是否已经存在跟商品条码相同的商品
            var pList = from p in salesListDetailList
                        where string.Equals(p.ProductId, this.textBoxProductId.Text.Trim())
                        select p;
            // 在明细列表中找到了与添加的商品
            if(pList.Count() > 0)
            {
                salesListDetail = pList.First();
                // 数量累加
                salesListDetail.Quantity += Convert.ToInt32(this.textBoxCount.Text.Trim());
                // 计算合计
                salesListDetail.SubTotalMoney = CalculateSubTotal(salesListDetail.UnitPrice,
                    salesListDetail.Discount,
                    salesListDetail.Quantity);
                this.bs.ResetBindings(true);
                return true;
            }
            else
                return false;
        }

        private void NotExisted()
        {
            Products product = null;
            try
            {
                // 数据库中查找
                product = objProductManager.GetProductByProductId(this.textBoxProductId.Text.Trim());
            }
            catch(Exception ex)
            {
                MessageBoxEx.Show("查询商品时出错！",
                    Program.MessageBoxTitle[Program.MessageBoxTitleType.Error],
                    ex.Message,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            if(product != null)
            {
                AddtoDetailList(product, Convert.ToInt32(this.textBoxCount.Text.Trim()));
            }
            // 数据库中也没有找到
            else
            {
                AddtoDetailList(GenerateNewProduct(), Convert.ToInt32(this.textBoxCount.Text.Trim()));
                return;
            }
        }
        private void AddtoDetailList(Products objProduct, int count)
        {
            // 封装
            SalesListDetail salesListDetail = new SalesListDetail()
            {
                // 封装流水号
                SerialNumber = this.textBoxSerialNumber.Text,
                ProductId = objProduct.ProductId,
                ProductName = objProduct.ProductName,
                UnitPrice = objProduct.UnitPrice,
                Discount = objProduct.Discount,
                Quantity = count
            };
            // 计算合计
            salesListDetail.SubTotalMoney = CalculateSubTotal(salesListDetail.UnitPrice,
                salesListDetail.Discount,
                salesListDetail.Quantity);
            this.salesListDetailList.Add(salesListDetail);

            this.bs.ResetBindings(true);
        }
        private Products GenerateNewProduct()
        {
            return new Products()
            {
                ProductId = this.textBoxProductId.Text.Trim(),
                ProductName = "自制商品",
                UnitPrice = Convert.ToDouble(this.textBoxPrice.Text.Trim()),
                Discount = Convert.ToInt32(this.textBoxDiscount.Text.Trim())
            };
        }
        /// <summary>
        /// 新商品输入时，数量变为1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxProductId_TextChanged(object sender, EventArgs e)
        {
            this.textBoxCount.Text = "1";
        }
        /// <summary>
        /// 计算每种商品小计
        /// </summary>
        /// <param name="price"></param>
        /// <param name="discount"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        private double CalculateSubTotal(double price, int discount, int quantity)
        {
            return price * quantity * ( 1 - discount / 100.0 );
        }
        /// <summary>
        /// 更新UI
        /// </summary>
        /// <param name="salesListDetail"></param>
        private void AdjustUi()
        {
            // 更新总价
            AdjustTotal();
            // 商品条码全选中
            this.textBoxProductId.Text = string.Empty;
            this.textBoxCount.Text = "1";
            this.textBoxPrice.Text = "0.00";
            this.textBoxDiscount.Text = "0";
        }

        /// <summary>
        /// 更新总价
        /// </summary>
        private void AdjustTotal()
        {
            // 更新总价
            this.textBoxShouldPay.Text = NumericUtility.ToMoneyFormat(( from p in this.salesListDetailList select p.SubTotalMoney ).Sum());
        }

        /// <summary>
        /// 在数量框里按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxCount_KeyDown(object sender, KeyEventArgs e)
        {
            // 按下回车
            if(e.KeyCode == Keys.Enter)
            {
                // 触发商品条码框按键
                this.textBoxProductId_KeyDown(sender, e);
            }
            // 按下左键
            else if(e.KeyCode == Keys.Left)
            {
                // 激活商品框
                //this.ActiveControl = this.textBoxProductId;
                this.textBoxProductId.Focus();
            }
            // 按下右键
            else if(e.KeyCode == Keys.Right)
            {
                // 激活单价框
                //this.ActiveControl = this.textBoxPrice;
                this.textBoxPrice.Focus();
            }
        }

        /// <summary>
        /// 在单价框里按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPrice_KeyDown(object sender, KeyEventArgs e)
        {
            // 按下回车键
            if(e.KeyCode == Keys.Enter)
            {
                // 触发商品条码框按键
                this.textBoxProductId_KeyDown(sender, e);
            }
            // 按下左键
            else if(e.KeyCode == Keys.Left)
            {
                // 激活数量框
                //this.ActiveControl = this.textBoxCount;
                this.textBoxCount.Focus();
            }
            // 按下右键
            else if(e.KeyCode == Keys.Right)
            {
                // 激活折扣框
                //this.ActiveControl = this.textBoxDiscount;
                this.textBoxDiscount.Focus();
            }
        }
        /// <summary>
        /// 在折扣框里按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            // 按下回车键
            if(e.KeyCode == Keys.Enter)
            {
                // 触发商品条码框按键
                this.textBoxProductId_KeyDown(sender, e);
            }
            // 按下左键
            else if(e.KeyCode == Keys.Left)
            {
                // 激活单价框
                //this.ActiveControl = this.textBoxPrice; 
                this.textBoxPrice.Focus();
            }
            // 按下右键
            else if(e.KeyCode == Keys.Right)
            {
                // 激活商品条形码框
                //this.ActiveControl = this.textBoxProductId;
                this.textBoxProductId.Focus();
            }
        }
        /// <summary>
        /// 提示语计时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerTips_Tick(object sender, EventArgs e)
        {
            // 刚进来时
            if(tipsTimerCount == 0)
            {
                // 修改提示信息
                this.toolStripStatusLabelTips.Text = tipsStr;
            }
            else if(tipsTimerCount == 1)
            { }
            else if(tipsTimerCount == 2)
            { }
            else if(tipsTimerCount == 3)
            { }
            else if(tipsTimerCount == 4)
            { }
            // 5秒
            else if(tipsTimerCount == 5)
            {
                // 时间清零、关闭定时器、改回原来的提示信息
                tipsTimerCount = 0;
                timerTips.Enabled = false;
                this.toolStripStatusLabelTips.Text = tipsStrOld;
                return;
            }
            tipsTimerCount++;
        }
        /// <summary>
        /// 设置新的提示信息
        /// </summary>
        /// <param name="newtip"></param>
        /// <param name="oldtip"></param>
        private void SetNewTip(string newtip, string oldtip)
        {
            tipsStrOld = oldtip;
            tipsStr = newtip;
            tipsTimerCount = 0;
            timerTips.Enabled = true;
        }

        /// <summary>
        /// 在主窗口里按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            // 按下F1
            if(e.KeyCode == Keys.F1)
            {
                // 封装销售对象
                SalesList saleList = new SalesList()
                {
                    SerialNumber = this.textBoxSerialNumber.Text,
                    TotalMoney = Convert.ToDouble(this.textBoxShouldPay.Text),
                    SalesPersonId = Program.LoginSalePerson.SalesPersonId
                };
                // 打开结算对象窗口
                FormBalance dlg = new FormBalance(saleList);
                if(DialogResult.OK != dlg.ShowDialog())
                {
                    if(( (KeyEventArgs)dlg.Tag ).KeyCode == Keys.F4)
                    {
                        ResetForm();
                        // 更新主窗口的实收、找零
                        this.textBoxRealReceived.Text = NumericUtility.ToMoneyFormat(saleList.RealReceive);
                        this.textBoxReturnChange.Text =
                            NumericUtility.ToMoneyFormat(saleList.ReturnMoney);
                    }
                    return;
                }

                saleList = dlg.salesList;
                try
                {
                    // 保存销售信息、明细
                    objSalesManager.SaveSaleInfo(saleList, salesListDetailList);
                }
                // 访问数据库出错
                catch(Exception ex)
                {
                    MessageBoxEx.Show("保存商品明细时出错！",
                        Program.MessageBoxTitle[Program.MessageBoxTitleType.Error],
                        ex.Message,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                // 有会员卡，则更新积分
                if(dlg.salesList.VipCardNo != 0)
                {
                    try
                    {
                        objSalesManager.UpdateVipPoint(dlg.salesList.VipCardNo,
                            (int)( Math.Floor(Convert.ToDouble(this.textBoxShouldPay.Text) / 10) ));
                    }
                    // 更新积分时，数据库出错
                    catch(Exception ex)
                    {
                        MessageBoxEx.Show("更新会员积分时出错！",
                            Program.MessageBoxTitle[Program.MessageBoxTitleType.Error],
                            ex.Message,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }

                // 打印小票
                // TODO
                //printDocumentMain.Print();

                ResetForm();
                // 更新主窗口的实收、找零
                this.textBoxRealReceived.Text = NumericUtility.ToMoneyFormat(saleList.RealReceive);
                this.textBoxReturnChange.Text =
                    NumericUtility.ToMoneyFormat(saleList.ReturnMoney);
            }
        }

        private void ResetForm()
        {
            // 清空原来的
            this.bs.Clear();
            // 重新生成一个流水号
            this.textBoxSerialNumber.Text = GetNewSerialNumber();
            // 清空商品条码、数量、单价、折扣
            this.textBoxProductId.Text = string.Empty;
            this.textBoxCount.Text = "0";
            this.textBoxPrice.Text = NumericUtility.ToMoneyFormat(0);
            this.textBoxDiscount.Text = "0";
        }
        /// <summary>
        /// 根据商品条码获取明细列表的index
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        private int GetListIndexOfProductId(string productId)
        {
            return this.salesListDetailList.FindIndex(x => string.Equals(x.ProductId, productId));
        }

        private void dataGridViewMain_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var dataGridＶiew = sender as DataGridView;
            var rowIndex = ( e.RowIndex + 1 ).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers  
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dataGridＶiew.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIndex, dataGridＶiew.DefaultCellStyle.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void printDocumentMain_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //USBPrint.Print();
        }
    }
}
