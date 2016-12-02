using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models;
using CommonUtility;
namespace SaleManager
{
    public class USBPrint
    {
        public static void Print(System.Drawing.Printing.PrintPageEventArgs e, SalesList salesList, List<SalesListDetail> detailList, SalesPerson sp)
        {
            //生成票据
            float left = 2;//打印区域的左边界
            float top = 10;//打印区域的上边界
            Font titleFont = new Font("楷体_gb2312", 12);//标题字体
            Font contentFont = new Font("仿宋", 8);//正文字体
            e.Graphics.DrawString("  实惠到家超市", titleFont, Brushes.Blue, left + 10, top - 5, new StringFormat());//打印标题
            e.Graphics.DrawString("    购物凭证", titleFont, Brushes.Blue, left + 10, top + 15, new StringFormat());//打印标题
            //画一条分界线
            Pen pen = new Pen(Color.Green, 1);
            e.Graphics.DrawLine(pen, new Point((int)left - 2, (int)top + 35), new Point((int)left + 180, (int)top + 36));
            //打印内容
            double totalMoney = 0;//商品总计金额
            e.Graphics.DrawString("商品名称          单价     数量      金额", contentFont, Brushes.Blue, left, top + titleFont.GetHeight(e.Graphics) + 12 + 12, new StringFormat());//打印内容表头标题
            for(int i = 1;i <= detailList.Count;i++)
            {
                //调整间距
                string sp1 = string.Empty;
                if(detailList[i - 1].ProductName.Length == 4)
                {
                    sp1 = "    ";
                }
                else if(detailList[i - 1].ProductName.Length == 3)
                {
                    sp1 = "      ";
                }
                else if(detailList[i - 1].ProductName.Length == 5)
                {
                    sp1 = "  ";
                }
                string sp2 = string.Empty;
                if(detailList[i - 1].UnitPrice.ToString().Length == 3)
                {
                    sp1 = "     ";
                }
                else if(detailList[i - 1].UnitPrice.ToString().Length == 4)
                {
                    sp1 = "    ";
                }
                else if(detailList[i - 1].UnitPrice.ToString().Length == 5)
                {
                    sp1 = "   ";
                }
                string sp3 = string.Empty;
                if(detailList[i - 1].Quantity.ToString().Length == 1)
                {
                    sp1 = "     ";
                }
                else if(detailList[i - 1].Quantity.ToString().Length == 2)
                {
                    sp1 = "    ";
                }
                else if(detailList[i - 1].Quantity.ToString().Length == 3)
                {
                    sp1 = "   ";
                }
                e.Graphics.DrawString(detailList[i - 1].ProductName + sp1 + NumericUtility.ToMoneyFormat(detailList[i - 1].UnitPrice) + sp2 + detailList[i - 1].Quantity.ToString() + sp3 + NumericUtility.ToMoneyFormat(detailList[i - 1].SubTotalMoney), contentFont, Brushes.Blue, left, top + titleFont.GetHeight(e.Graphics) + contentFont.GetHeight(e.Graphics) * i + 12 + 12, new StringFormat());//打印明细内容
            }
            //画一条分界线
            e.Graphics.DrawLine(pen, new Point((int)left - 2, (int)top + 125), new Point((int)left + 180, (int)top + 36));

            //打印备注
            e.Graphics.DrawString("总计： ", contentFont, Brushes.Blue, left + 10, top + 15, new StringFormat());
            e.Graphics.DrawString("实收： ", contentFont, Brushes.Blue, left + 10, top + 15, new StringFormat());
            e.Graphics.DrawString("找零： ", contentFont, Brushes.Blue, left + 10, top + 15, new StringFormat());
            e.Graphics.DrawString("流水号： ", contentFont, Brushes.Blue, left + 10, top + 15, new StringFormat());
            e.Graphics.DrawString("收银员", contentFont, Brushes.Blue, left + 10, top + 15, new StringFormat());
            e.Graphics.DrawString("在30日内凭小票可开具购物发票", contentFont, Brushes.Blue, left + 10, top + 15, new StringFormat());
            e.Graphics.DrawString("          欢迎再次光临", contentFont, Brushes.Blue, left + 10, top + 15, new StringFormat());
        }
    }
}
