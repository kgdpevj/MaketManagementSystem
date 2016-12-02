namespace SaleManager
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && ( components != null ))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelLoginName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTips = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSystemName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelCopyRight = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotalMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelProductId = new System.Windows.Forms.Label();
            this.textBoxProductId = new System.Windows.Forms.TextBox();
            this.labelCount = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.labelDiscount = new System.Windows.Forms.Label();
            this.textBoxDiscount = new System.Windows.Forms.TextBox();
            this.labelSerialNumber = new System.Windows.Forms.Label();
            this.labelShouldPay = new System.Windows.Forms.Label();
            this.textBoxSerialNumber = new System.Windows.Forms.TextBox();
            this.labelRealReceived = new System.Windows.Forms.Label();
            this.textBoxShouldPay = new System.Windows.Forms.TextBox();
            this.labelReturnChange = new System.Windows.Forms.Label();
            this.textBoxRealReceived = new System.Windows.Forms.TextBox();
            this.textBoxReturnChange = new System.Windows.Forms.TextBox();
            this.timerTips = new System.Windows.Forms.Timer(this.components);
            this.printDocumentMain = new System.Drawing.Printing.PrintDocument();
            this.statusStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelLoginName,
            this.toolStripStatusLabelTips,
            this.toolStripStatusLabelSystemName,
            this.toolStripStatusLabelVersion,
            this.toolStripStatusLabelCopyRight});
            this.statusStripMain.Location = new System.Drawing.Point(0, 825);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(1184, 36);
            this.statusStripMain.TabIndex = 0;
            this.statusStripMain.Text = "statusStripMain";
            // 
            // toolStripStatusLabelLoginName
            // 
            this.toolStripStatusLabelLoginName.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripStatusLabelLoginName.ForeColor = System.Drawing.Color.LimeGreen;
            this.toolStripStatusLabelLoginName.Name = "toolStripStatusLabelLoginName";
            this.toolStripStatusLabelLoginName.Size = new System.Drawing.Size(230, 31);
            this.toolStripStatusLabelLoginName.Text = "收款员：【王某某】";
            // 
            // toolStripStatusLabelTips
            // 
            this.toolStripStatusLabelTips.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripStatusLabelTips.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelTips.Name = "toolStripStatusLabelTips";
            this.toolStripStatusLabelTips.Size = new System.Drawing.Size(430, 31);
            this.toolStripStatusLabelTips.Spring = true;
            this.toolStripStatusLabelTips.Text = "提示：按F1可进入结算";
            this.toolStripStatusLabelTips.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabelSystemName
            // 
            this.toolStripStatusLabelSystemName.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripStatusLabelSystemName.Name = "toolStripStatusLabelSystemName";
            this.toolStripStatusLabelSystemName.Size = new System.Drawing.Size(270, 31);
            this.toolStripStatusLabelSystemName.Text = "[实惠到家超市收银系统]";
            // 
            // toolStripStatusLabelVersion
            // 
            this.toolStripStatusLabelVersion.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripStatusLabelVersion.Name = "toolStripStatusLabelVersion";
            this.toolStripStatusLabelVersion.Size = new System.Drawing.Size(64, 31);
            this.toolStripStatusLabelVersion.Text = "V2.0";
            // 
            // toolStripStatusLabelCopyRight
            // 
            this.toolStripStatusLabelCopyRight.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripStatusLabelCopyRight.Name = "toolStripStatusLabelCopyRight";
            this.toolStripStatusLabelCopyRight.Size = new System.Drawing.Size(175, 31);
            this.toolStripStatusLabelCopyRight.Text = "©AnyDao .Inc";
            // 
            // dataGridViewMain
            // 
            this.dataGridViewMain.AllowUserToAddRows = false;
            this.dataGridViewMain.AllowUserToOrderColumns = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductId,
            this.ProductName,
            this.UnitPrice,
            this.Discount,
            this.Quantity,
            this.SubTotalMoney});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewMain.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewMain.Location = new System.Drawing.Point(0, 3);
            this.dataGridViewMain.MultiSelect = false;
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewMain.RowHeadersWidth = 60;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewMain.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewMain.RowTemplate.Height = 30;
            this.dataGridViewMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMain.Size = new System.Drawing.Size(1184, 691);
            this.dataGridViewMain.TabIndex = 0;
            this.dataGridViewMain.TabStop = false;
            this.dataGridViewMain.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridViewMain_RowPostPaint);
            // 
            // ProductId
            // 
            this.ProductId.DataPropertyName = "ProductId";
            this.ProductId.HeaderText = "商品编号";
            this.ProductId.Name = "ProductId";
            this.ProductId.ReadOnly = true;
            this.ProductId.Width = 250;
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "商品名称";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            this.ProductName.Width = 400;
            // 
            // UnitPrice
            // 
            this.UnitPrice.DataPropertyName = "UnitPrice";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = "0";
            this.UnitPrice.DefaultCellStyle = dataGridViewCellStyle10;
            this.UnitPrice.HeaderText = "单价";
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.ReadOnly = true;
            // 
            // Discount
            // 
            this.Discount.DataPropertyName = "Discount";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Discount.DefaultCellStyle = dataGridViewCellStyle11;
            this.Discount.HeaderText = "折扣";
            this.Discount.Name = "Discount";
            this.Discount.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle12;
            this.Quantity.HeaderText = "数量";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // SubTotalMoney
            // 
            this.SubTotalMoney.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SubTotalMoney.DataPropertyName = "SubTotalMoney";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N2";
            dataGridViewCellStyle13.NullValue = "0";
            this.SubTotalMoney.DefaultCellStyle = dataGridViewCellStyle13;
            this.SubTotalMoney.HeaderText = "小计";
            this.SubTotalMoney.Name = "SubTotalMoney";
            this.SubTotalMoney.ReadOnly = true;
            // 
            // labelProductId
            // 
            this.labelProductId.AutoSize = true;
            this.labelProductId.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProductId.Location = new System.Drawing.Point(7, 716);
            this.labelProductId.Name = "labelProductId";
            this.labelProductId.Size = new System.Drawing.Size(133, 39);
            this.labelProductId.TabIndex = 0;
            this.labelProductId.Text = "商品条码";
            // 
            // textBoxProductId
            // 
            this.textBoxProductId.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxProductId.Location = new System.Drawing.Point(137, 710);
            this.textBoxProductId.Name = "textBoxProductId";
            this.textBoxProductId.Size = new System.Drawing.Size(352, 44);
            this.textBoxProductId.TabIndex = 1;
            this.textBoxProductId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxProductId.TextChanged += new System.EventHandler(this.textBoxProductId_TextChanged);
            this.textBoxProductId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxProductId_KeyDown);
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCount.Location = new System.Drawing.Point(494, 716);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(75, 39);
            this.labelCount.TabIndex = 0;
            this.labelCount.Text = "数量";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxCount.Location = new System.Drawing.Point(564, 710);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(161, 44);
            this.textBoxCount.TabIndex = 2;
            this.textBoxCount.Text = "1";
            this.textBoxCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxCount_KeyDown);
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrice.Location = new System.Drawing.Point(730, 716);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(75, 39);
            this.labelPrice.TabIndex = 0;
            this.labelPrice.Text = "价格";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxPrice.Location = new System.Drawing.Point(800, 710);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(161, 44);
            this.textBoxPrice.TabIndex = 3;
            this.textBoxPrice.Text = "0.00";
            this.textBoxPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPrice_KeyDown);
            // 
            // labelDiscount
            // 
            this.labelDiscount.AutoSize = true;
            this.labelDiscount.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDiscount.Location = new System.Drawing.Point(966, 716);
            this.labelDiscount.Name = "labelDiscount";
            this.labelDiscount.Size = new System.Drawing.Size(75, 39);
            this.labelDiscount.TabIndex = 0;
            this.labelDiscount.Text = "折扣";
            // 
            // textBoxDiscount
            // 
            this.textBoxDiscount.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxDiscount.Location = new System.Drawing.Point(1036, 710);
            this.textBoxDiscount.Name = "textBoxDiscount";
            this.textBoxDiscount.Size = new System.Drawing.Size(135, 44);
            this.textBoxDiscount.TabIndex = 4;
            this.textBoxDiscount.Text = "0";
            this.textBoxDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxDiscount_KeyDown);
            // 
            // labelSerialNumber
            // 
            this.labelSerialNumber.AutoSize = true;
            this.labelSerialNumber.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSerialNumber.Location = new System.Drawing.Point(7, 772);
            this.labelSerialNumber.Name = "labelSerialNumber";
            this.labelSerialNumber.Size = new System.Drawing.Size(133, 39);
            this.labelSerialNumber.TabIndex = 0;
            this.labelSerialNumber.Text = "流水帐号";
            // 
            // labelShouldPay
            // 
            this.labelShouldPay.AutoSize = true;
            this.labelShouldPay.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelShouldPay.Location = new System.Drawing.Point(494, 772);
            this.labelShouldPay.Name = "labelShouldPay";
            this.labelShouldPay.Size = new System.Drawing.Size(75, 39);
            this.labelShouldPay.TabIndex = 0;
            this.labelShouldPay.Text = "应付";
            // 
            // textBoxSerialNumber
            // 
            this.textBoxSerialNumber.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxSerialNumber.Location = new System.Drawing.Point(137, 766);
            this.textBoxSerialNumber.Name = "textBoxSerialNumber";
            this.textBoxSerialNumber.ReadOnly = true;
            this.textBoxSerialNumber.Size = new System.Drawing.Size(352, 44);
            this.textBoxSerialNumber.TabIndex = 0;
            this.textBoxSerialNumber.TabStop = false;
            this.textBoxSerialNumber.Text = "20161231154626412547";
            this.textBoxSerialNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelRealReceived
            // 
            this.labelRealReceived.AutoSize = true;
            this.labelRealReceived.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRealReceived.Location = new System.Drawing.Point(730, 772);
            this.labelRealReceived.Name = "labelRealReceived";
            this.labelRealReceived.Size = new System.Drawing.Size(75, 39);
            this.labelRealReceived.TabIndex = 0;
            this.labelRealReceived.Text = "实收";
            // 
            // textBoxShouldPay
            // 
            this.textBoxShouldPay.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxShouldPay.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxShouldPay.ForeColor = System.Drawing.Color.Red;
            this.textBoxShouldPay.Location = new System.Drawing.Point(564, 768);
            this.textBoxShouldPay.Name = "textBoxShouldPay";
            this.textBoxShouldPay.ReadOnly = true;
            this.textBoxShouldPay.Size = new System.Drawing.Size(161, 44);
            this.textBoxShouldPay.TabIndex = 0;
            this.textBoxShouldPay.TabStop = false;
            this.textBoxShouldPay.Text = "0.00";
            this.textBoxShouldPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelReturnChange
            // 
            this.labelReturnChange.AutoSize = true;
            this.labelReturnChange.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReturnChange.Location = new System.Drawing.Point(966, 772);
            this.labelReturnChange.Name = "labelReturnChange";
            this.labelReturnChange.Size = new System.Drawing.Size(75, 39);
            this.labelReturnChange.TabIndex = 0;
            this.labelReturnChange.Text = "找零";
            // 
            // textBoxRealReceived
            // 
            this.textBoxRealReceived.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxRealReceived.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRealReceived.ForeColor = System.Drawing.Color.Blue;
            this.textBoxRealReceived.Location = new System.Drawing.Point(800, 768);
            this.textBoxRealReceived.Name = "textBoxRealReceived";
            this.textBoxRealReceived.ReadOnly = true;
            this.textBoxRealReceived.Size = new System.Drawing.Size(161, 44);
            this.textBoxRealReceived.TabIndex = 0;
            this.textBoxRealReceived.TabStop = false;
            this.textBoxRealReceived.Text = "0.00";
            this.textBoxRealReceived.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxReturnChange
            // 
            this.textBoxReturnChange.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxReturnChange.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxReturnChange.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.textBoxReturnChange.Location = new System.Drawing.Point(1036, 768);
            this.textBoxReturnChange.Name = "textBoxReturnChange";
            this.textBoxReturnChange.ReadOnly = true;
            this.textBoxReturnChange.Size = new System.Drawing.Size(135, 44);
            this.textBoxReturnChange.TabIndex = 0;
            this.textBoxReturnChange.TabStop = false;
            this.textBoxReturnChange.Text = "0.00";
            this.textBoxReturnChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timerTips
            // 
            this.timerTips.Interval = 1000;
            this.timerTips.Tick += new System.EventHandler(this.timerTips_Tick);
            // 
            // printDocumentMain
            // 
            this.printDocumentMain.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocumentMain_PrintPage);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 861);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxReturnChange);
            this.Controls.Add(this.textBoxDiscount);
            this.Controls.Add(this.textBoxRealReceived);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.labelReturnChange);
            this.Controls.Add(this.labelDiscount);
            this.Controls.Add(this.textBoxShouldPay);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.labelRealReceived);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.textBoxSerialNumber);
            this.Controls.Add(this.labelShouldPay);
            this.Controls.Add(this.textBoxProductId);
            this.Controls.Add(this.labelSerialNumber);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelProductId);
            this.Controls.Add(this.dataGridViewMain);
            this.Controls.Add(this.statusStripMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "超市前台结算系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSystemName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelVersion;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCopyRight;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTips;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLoginName;
        private System.Windows.Forms.DataGridView dataGridViewMain;
        private System.Windows.Forms.Label labelProductId;
        private System.Windows.Forms.TextBox textBoxProductId;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label labelDiscount;
        private System.Windows.Forms.TextBox textBoxDiscount;
        private System.Windows.Forms.Label labelSerialNumber;
        private System.Windows.Forms.Label labelShouldPay;
        private System.Windows.Forms.TextBox textBoxSerialNumber;
        private System.Windows.Forms.Label labelRealReceived;
        private System.Windows.Forms.TextBox textBoxShouldPay;
        private System.Windows.Forms.Label labelReturnChange;
        private System.Windows.Forms.TextBox textBoxRealReceived;
        private System.Windows.Forms.TextBox textBoxReturnChange;
        private System.Windows.Forms.Timer timerTips;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotalMoney;
        private System.Drawing.Printing.PrintDocument printDocumentMain;
    }
}

