namespace SMartStorageManager
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && ( components != null ))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.monthCalendarMain = new System.Windows.Forms.MonthCalendar();
            this.btnModifyPwd = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnInventoryManage = new System.Windows.Forms.Button();
            this.btnLogQuery = new System.Windows.Forms.Button();
            this.btnProductInventory = new System.Windows.Forms.Button();
            this.btnSaleAnalasys = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.spContainer = new System.Windows.Forms.SplitContainer();
            this.btnProductManage = new System.Windows.Forms.Button();
            this.lblAdminName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.tsmiSaleStat = new System.Windows.Forms.ToolStripMenuItem();
            this.销售管理XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiProductManage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiProductStorage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.商品管理PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiInventoryManage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiModifyPwd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUserManage = new System.Windows.Forms.ToolStripMenuItem();
            this.系统SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.spContainer)).BeginInit();
            this.spContainer.Panel1.SuspendLayout();
            this.spContainer.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // monthCalendarMain
            // 
            this.monthCalendarMain.Location = new System.Drawing.Point(6, 7);
            this.monthCalendarMain.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.monthCalendarMain.Name = "monthCalendarMain";
            this.monthCalendarMain.TabIndex = 8;
            // 
            // btnModifyPwd
            // 
            this.btnModifyPwd.Image = ((System.Drawing.Image)(resources.GetObject("btnModifyPwd.Image")));
            this.btnModifyPwd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModifyPwd.Location = new System.Drawing.Point(26, 553);
            this.btnModifyPwd.Name = "btnModifyPwd";
            this.btnModifyPwd.Size = new System.Drawing.Size(82, 44);
            this.btnModifyPwd.TabIndex = 6;
            this.btnModifyPwd.Text = "密码修改";
            this.btnModifyPwd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModifyPwd.UseVisualStyleBackColor = true;
            this.btnModifyPwd.Click += new System.EventHandler(this.btnModifyPwd_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(126, 553);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(82, 44);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "退出系统";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnInventoryManage
            // 
            this.btnInventoryManage.Image = ((System.Drawing.Image)(resources.GetObject("btnInventoryManage.Image")));
            this.btnInventoryManage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventoryManage.Location = new System.Drawing.Point(26, 263);
            this.btnInventoryManage.Name = "btnInventoryManage";
            this.btnInventoryManage.Size = new System.Drawing.Size(82, 44);
            this.btnInventoryManage.TabIndex = 2;
            this.btnInventoryManage.Text = "库存管理";
            this.btnInventoryManage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInventoryManage.UseVisualStyleBackColor = true;
            this.btnInventoryManage.Click += new System.EventHandler(this.btnInventoryManage_Click);
            // 
            // btnLogQuery
            // 
            this.btnLogQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnLogQuery.Image")));
            this.btnLogQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogQuery.Location = new System.Drawing.Point(126, 334);
            this.btnLogQuery.Name = "btnLogQuery";
            this.btnLogQuery.Size = new System.Drawing.Size(82, 44);
            this.btnLogQuery.TabIndex = 5;
            this.btnLogQuery.Text = "日志查询";
            this.btnLogQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogQuery.UseVisualStyleBackColor = true;
            this.btnLogQuery.Click += new System.EventHandler(this.btnLogQuery_Click);
            // 
            // btnProductInventory
            // 
            this.btnProductInventory.Image = ((System.Drawing.Image)(resources.GetObject("btnProductInventory.Image")));
            this.btnProductInventory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductInventory.Location = new System.Drawing.Point(126, 192);
            this.btnProductInventory.Name = "btnProductInventory";
            this.btnProductInventory.Size = new System.Drawing.Size(82, 44);
            this.btnProductInventory.TabIndex = 1;
            this.btnProductInventory.Text = "商品入库";
            this.btnProductInventory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProductInventory.UseVisualStyleBackColor = true;
            this.btnProductInventory.Click += new System.EventHandler(this.btnProductInventory_Click);
            // 
            // btnSaleAnalasys
            // 
            this.btnSaleAnalasys.Image = ((System.Drawing.Image)(resources.GetObject("btnSaleAnalasys.Image")));
            this.btnSaleAnalasys.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaleAnalasys.Location = new System.Drawing.Point(26, 334);
            this.btnSaleAnalasys.Name = "btnSaleAnalasys";
            this.btnSaleAnalasys.Size = new System.Drawing.Size(82, 44);
            this.btnSaleAnalasys.TabIndex = 4;
            this.btnSaleAnalasys.Text = "销售统计";
            this.btnSaleAnalasys.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaleAnalasys.UseVisualStyleBackColor = true;
            this.btnSaleAnalasys.Click += new System.EventHandler(this.btnSaleAnalasys_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Image = ((System.Drawing.Image)(resources.GetObject("btnAddProduct.Image")));
            this.btnAddProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddProduct.Location = new System.Drawing.Point(26, 192);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(82, 44);
            this.btnAddProduct.TabIndex = 0;
            this.btnAddProduct.Text = "新增商品";
            this.btnAddProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // spContainer
            // 
            this.spContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spContainer.Location = new System.Drawing.Point(0, 24);
            this.spContainer.Name = "spContainer";
            // 
            // spContainer.Panel1
            // 
            this.spContainer.Panel1.Controls.Add(this.monthCalendarMain);
            this.spContainer.Panel1.Controls.Add(this.btnModifyPwd);
            this.spContainer.Panel1.Controls.Add(this.btnExit);
            this.spContainer.Panel1.Controls.Add(this.btnInventoryManage);
            this.spContainer.Panel1.Controls.Add(this.btnLogQuery);
            this.spContainer.Panel1.Controls.Add(this.btnProductInventory);
            this.spContainer.Panel1.Controls.Add(this.btnSaleAnalasys);
            this.spContainer.Panel1.Controls.Add(this.btnProductManage);
            this.spContainer.Panel1.Controls.Add(this.btnAddProduct);
            // 
            // spContainer.Panel2
            // 
            this.spContainer.Panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("spContainer.Panel2.BackgroundImage")));
            this.spContainer.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.spContainer.Size = new System.Drawing.Size(1184, 620);
            this.spContainer.SplitterDistance = 243;
            this.spContainer.TabIndex = 1;
            // 
            // btnProductManage
            // 
            this.btnProductManage.Image = ((System.Drawing.Image)(resources.GetObject("btnProductManage.Image")));
            this.btnProductManage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductManage.Location = new System.Drawing.Point(126, 263);
            this.btnProductManage.Name = "btnProductManage";
            this.btnProductManage.Size = new System.Drawing.Size(82, 44);
            this.btnProductManage.TabIndex = 3;
            this.btnProductManage.Text = "商品维护";
            this.btnProductManage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProductManage.UseVisualStyleBackColor = true;
            this.btnProductManage.Click += new System.EventHandler(this.btnProductManage_Click);
            // 
            // lblAdminName
            // 
            this.lblAdminName.Name = "lblAdminName";
            this.lblAdminName.Size = new System.Drawing.Size(85, 17);
            this.lblAdminName.Text = "【管理员】：";
            // 
            // toolStripStatusLabelVersion
            // 
            this.toolStripStatusLabelVersion.Name = "toolStripStatusLabelVersion";
            this.toolStripStatusLabelVersion.Size = new System.Drawing.Size(124, 17);
            this.toolStripStatusLabelVersion.Text = "[超市管理系统]  V2.0 ";
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelVersion,
            this.lblAdminName});
            this.statusStripMain.Location = new System.Drawing.Point(0, 644);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(1184, 22);
            this.statusStripMain.TabIndex = 12;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // tsmiSaleStat
            // 
            this.tsmiSaleStat.Image = ((System.Drawing.Image)(resources.GetObject("tsmiSaleStat.Image")));
            this.tsmiSaleStat.Name = "tsmiSaleStat";
            this.tsmiSaleStat.Size = new System.Drawing.Size(140, 22);
            this.tsmiSaleStat.Text = "销售统计(&S)";
            // 
            // 销售管理XToolStripMenuItem
            // 
            this.销售管理XToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSaleStat});
            this.销售管理XToolStripMenuItem.Name = "销售管理XToolStripMenuItem";
            this.销售管理XToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.销售管理XToolStripMenuItem.Text = "销售管理(&X)";
            // 
            // tsmiProductManage
            // 
            this.tsmiProductManage.Image = ((System.Drawing.Image)(resources.GetObject("tsmiProductManage.Image")));
            this.tsmiProductManage.Name = "tsmiProductManage";
            this.tsmiProductManage.Size = new System.Drawing.Size(145, 22);
            this.tsmiProductManage.Text = "商品维护(&M)";
            // 
            // tsmiProductStorage
            // 
            this.tsmiProductStorage.Image = ((System.Drawing.Image)(resources.GetObject("tsmiProductStorage.Image")));
            this.tsmiProductStorage.Name = "tsmiProductStorage";
            this.tsmiProductStorage.Size = new System.Drawing.Size(145, 22);
            this.tsmiProductStorage.Text = "商品入库(&I)";
            // 
            // tsmiAddProduct
            // 
            this.tsmiAddProduct.Image = ((System.Drawing.Image)(resources.GetObject("tsmiAddProduct.Image")));
            this.tsmiAddProduct.Name = "tsmiAddProduct";
            this.tsmiAddProduct.Size = new System.Drawing.Size(145, 22);
            this.tsmiAddProduct.Text = "添加商品(&A)";
            // 
            // 商品管理PToolStripMenuItem
            // 
            this.商品管理PToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddProduct,
            this.tsmiProductStorage,
            this.toolStripSeparator1,
            this.tsmiProductManage,
            this.tsmiInventoryManage});
            this.商品管理PToolStripMenuItem.Name = "商品管理PToolStripMenuItem";
            this.商品管理PToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.商品管理PToolStripMenuItem.Text = "商品管理(&P)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(142, 6);
            // 
            // tsmiInventoryManage
            // 
            this.tsmiInventoryManage.Image = ((System.Drawing.Image)(resources.GetObject("tsmiInventoryManage.Image")));
            this.tsmiInventoryManage.Name = "tsmiInventoryManage";
            this.tsmiInventoryManage.Size = new System.Drawing.Size(145, 22);
            this.tsmiInventoryManage.Text = "库存管理(&K)";
            // 
            // tsmiExit
            // 
            this.tsmiExit.Image = ((System.Drawing.Image)(resources.GetObject("tsmiExit.Image")));
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(142, 22);
            this.tsmiExit.Text = "退出系统(&E)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(139, 6);
            // 
            // tsmiLogs
            // 
            this.tsmiLogs.Image = ((System.Drawing.Image)(resources.GetObject("tsmiLogs.Image")));
            this.tsmiLogs.Name = "tsmiLogs";
            this.tsmiLogs.Size = new System.Drawing.Size(142, 22);
            this.tsmiLogs.Text = "日志查询(&L)";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(139, 6);
            // 
            // tsmiModifyPwd
            // 
            this.tsmiModifyPwd.Image = ((System.Drawing.Image)(resources.GetObject("tsmiModifyPwd.Image")));
            this.tsmiModifyPwd.Name = "tsmiModifyPwd";
            this.tsmiModifyPwd.Size = new System.Drawing.Size(142, 22);
            this.tsmiModifyPwd.Text = "修改密码(&P)";
            // 
            // tsmiUserManage
            // 
            this.tsmiUserManage.Image = ((System.Drawing.Image)(resources.GetObject("tsmiUserManage.Image")));
            this.tsmiUserManage.Name = "tsmiUserManage";
            this.tsmiUserManage.Size = new System.Drawing.Size(142, 22);
            this.tsmiUserManage.Text = "用户管理(&U)";
            // 
            // 系统SToolStripMenuItem
            // 
            this.系统SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUserManage,
            this.tsmiModifyPwd,
            this.toolStripSeparator3,
            this.tsmiLogs,
            this.toolStripSeparator2,
            this.tsmiExit});
            this.系统SToolStripMenuItem.Name = "系统SToolStripMenuItem";
            this.系统SToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.系统SToolStripMenuItem.Text = "系统(&S)";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统SToolStripMenuItem,
            this.商品管理PToolStripMenuItem,
            this.销售管理XToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 666);
            this.Controls.Add(this.spContainer);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "超市库存管理系统";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.spContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spContainer)).EndInit();
            this.spContainer.ResumeLayout(false);
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendarMain;
        private System.Windows.Forms.Button btnModifyPwd;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnInventoryManage;
        private System.Windows.Forms.Button btnLogQuery;
        private System.Windows.Forms.Button btnProductInventory;
        private System.Windows.Forms.Button btnSaleAnalasys;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.SplitContainer spContainer;
        private System.Windows.Forms.Button btnProductManage;
        private System.Windows.Forms.ToolStripStatusLabel lblAdminName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelVersion;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaleStat;
        private System.Windows.Forms.ToolStripMenuItem 销售管理XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiProductManage;
        private System.Windows.Forms.ToolStripMenuItem tsmiProductStorage;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddProduct;
        private System.Windows.Forms.ToolStripMenuItem 商品管理PToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiInventoryManage;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiLogs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiModifyPwd;
        private System.Windows.Forms.ToolStripMenuItem tsmiUserManage;
        private System.Windows.Forms.ToolStripMenuItem 系统SToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}