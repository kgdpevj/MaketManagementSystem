namespace SMartStorageManager.Product
{
    partial class FormAddProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddProduct));
            this.groupBoxInventory = new System.Windows.Forms.GroupBox();
            this.txtMinCount = new System.Windows.Forms.TextBox();
            this.txtMaxCount = new System.Windows.Forms.TextBox();
            this.labelMinInventory = new System.Windows.Forms.Label();
            this.labelMaxInventory = new System.Windows.Forms.Label();
            this.btnLock = new System.Windows.Forms.Button();
            this.cboUnit = new System.Windows.Forms.ComboBox();
            this.labelUintName = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.labelProductId = new System.Windows.Forms.Label();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.labelProductName = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelProductCategory = new System.Windows.Forms.Label();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.groupBoxInventory.SuspendLayout();
            this.gbInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxInventory
            // 
            this.groupBoxInventory.Controls.Add(this.txtMinCount);
            this.groupBoxInventory.Controls.Add(this.txtMaxCount);
            this.groupBoxInventory.Controls.Add(this.labelMinInventory);
            this.groupBoxInventory.Controls.Add(this.labelMaxInventory);
            this.groupBoxInventory.Location = new System.Drawing.Point(14, 184);
            this.groupBoxInventory.Name = "groupBoxInventory";
            this.groupBoxInventory.Size = new System.Drawing.Size(519, 68);
            this.groupBoxInventory.TabIndex = 1;
            this.groupBoxInventory.TabStop = false;
            this.groupBoxInventory.Text = "[库存预设]";
            // 
            // txtMinCount
            // 
            this.txtMinCount.Location = new System.Drawing.Point(352, 29);
            this.txtMinCount.MaxLength = 9;
            this.txtMinCount.Name = "txtMinCount";
            this.txtMinCount.Size = new System.Drawing.Size(156, 20);
            this.txtMinCount.TabIndex = 1;
            // 
            // txtMaxCount
            // 
            this.txtMaxCount.Location = new System.Drawing.Point(87, 29);
            this.txtMaxCount.MaxLength = 9;
            this.txtMaxCount.Name = "txtMaxCount";
            this.txtMaxCount.Size = new System.Drawing.Size(177, 20);
            this.txtMaxCount.TabIndex = 0;
            // 
            // labelMinInventory
            // 
            this.labelMinInventory.AutoSize = true;
            this.labelMinInventory.Location = new System.Drawing.Point(281, 33);
            this.labelMinInventory.Name = "labelMinInventory";
            this.labelMinInventory.Size = new System.Drawing.Size(67, 13);
            this.labelMinInventory.TabIndex = 0;
            this.labelMinInventory.Text = "最小库存：";
            // 
            // labelMaxInventory
            // 
            this.labelMaxInventory.AutoSize = true;
            this.labelMaxInventory.Location = new System.Drawing.Point(16, 33);
            this.labelMaxInventory.Name = "labelMaxInventory";
            this.labelMaxInventory.Size = new System.Drawing.Size(67, 13);
            this.labelMaxInventory.TabIndex = 0;
            this.labelMaxInventory.Text = "最大库存：";
            // 
            // btnLock
            // 
            this.btnLock.Location = new System.Drawing.Point(212, 28);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(54, 25);
            this.btnLock.TabIndex = 1;
            this.btnLock.Text = "锁定";
            this.btnLock.UseVisualStyleBackColor = true;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // cboUnit
            // 
            this.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnit.FormattingEnabled = true;
            this.cboUnit.Location = new System.Drawing.Point(354, 30);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(87, 21);
            this.cboUnit.TabIndex = 2;
            // 
            // labelUintName
            // 
            this.labelUintName.AutoSize = true;
            this.labelUintName.Location = new System.Drawing.Point(283, 34);
            this.labelUintName.Name = "labelUintName";
            this.labelUintName.Size = new System.Drawing.Size(67, 13);
            this.labelUintName.TabIndex = 0;
            this.labelUintName.Text = "计量单位：";
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(453, 270);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 36);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭窗口";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.btnLock);
            this.gbInfo.Controls.Add(this.labelProductId);
            this.gbInfo.Controls.Add(this.txtProductId);
            this.gbInfo.Controls.Add(this.labelProductName);
            this.gbInfo.Controls.Add(this.txtProductName);
            this.gbInfo.Controls.Add(this.cboUnit);
            this.gbInfo.Controls.Add(this.cboCategory);
            this.gbInfo.Controls.Add(this.labelUintName);
            this.gbInfo.Controls.Add(this.labelPrice);
            this.gbInfo.Controls.Add(this.labelProductCategory);
            this.gbInfo.Controls.Add(this.txtUnitPrice);
            this.gbInfo.Location = new System.Drawing.Point(12, 12);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(521, 156);
            this.gbInfo.TabIndex = 0;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "[商品信息]";
            // 
            // labelProductId
            // 
            this.labelProductId.AutoSize = true;
            this.labelProductId.Location = new System.Drawing.Point(18, 75);
            this.labelProductId.Name = "labelProductId";
            this.labelProductId.Size = new System.Drawing.Size(67, 13);
            this.labelProductId.TabIndex = 0;
            this.labelProductId.Text = "商品编码：";
            // 
            // txtProductId
            // 
            this.txtProductId.Location = new System.Drawing.Point(89, 71);
            this.txtProductId.MaxLength = 50;
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(177, 20);
            this.txtProductId.TabIndex = 3;
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Location = new System.Drawing.Point(18, 115);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(67, 13);
            this.labelProductName.TabIndex = 0;
            this.labelProductName.Text = "商品名称：";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(89, 111);
            this.txtProductName.MaxLength = 50;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(177, 20);
            this.txtProductName.TabIndex = 4;
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(89, 30);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(116, 21);
            this.cboCategory.TabIndex = 0;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(283, 115);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(67, 13);
            this.labelPrice.TabIndex = 0;
            this.labelPrice.Text = "销售单价：";
            // 
            // labelProductCategory
            // 
            this.labelProductCategory.AutoSize = true;
            this.labelProductCategory.Location = new System.Drawing.Point(18, 34);
            this.labelProductCategory.Name = "labelProductCategory";
            this.labelProductCategory.Size = new System.Drawing.Size(67, 13);
            this.labelProductCategory.TabIndex = 0;
            this.labelProductCategory.Text = "商品分类：";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtUnitPrice.Location = new System.Drawing.Point(354, 111);
            this.txtUnitPrice.MaxLength = 11;
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(85, 20);
            this.txtUnitPrice.TabIndex = 5;
            // 
            // btnSubmit
            // 
            this.btnSubmit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSubmit.Image = ((System.Drawing.Image)(resources.GetObject("btnSubmit.Image")));
            this.btnSubmit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubmit.Location = new System.Drawing.Point(351, 270);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(80, 36);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "添加商品";
            this.btnSubmit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // FormAddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 325);
            this.Controls.Add(this.groupBoxInventory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbInfo);
            this.Controls.Add(this.btnSubmit);
            this.Name = "FormAddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "【添加商品】";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAddProduct_FormClosing);
            this.Load += new System.EventHandler(this.FormAddProduct_Load);
            this.groupBoxInventory.ResumeLayout(false);
            this.groupBoxInventory.PerformLayout();
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxInventory;
        private System.Windows.Forms.TextBox txtMinCount;
        private System.Windows.Forms.TextBox txtMaxCount;
        private System.Windows.Forms.Label labelMinInventory;
        private System.Windows.Forms.Label labelMaxInventory;
        private System.Windows.Forms.Button btnLock;
        private System.Windows.Forms.ComboBox cboUnit;
        private System.Windows.Forms.Label labelUintName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.Label labelProductId;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelProductCategory;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Button btnSubmit;
    }
}