namespace SMartStorageManager.Product
{
    partial class FormProductStorage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProductStorage));
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.labelProductId = new System.Windows.Forms.Label();
            this.labelProductName = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.labelIncome = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.labelTip1 = new System.Windows.Forms.Label();
            this.groupBoxProductInfo = new System.Windows.Forms.GroupBox();
            this.labelTip2 = new System.Windows.Forms.Label();
            this.groupBoxProductInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtProductId
            // 
            this.txtProductId.Location = new System.Drawing.Point(85, 31);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(163, 20);
            this.txtProductId.TabIndex = 0;
            this.txtProductId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductId_KeyDown);
            this.txtProductId.MouseLeave += new System.EventHandler(this.txtProductId_MouseLeave);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirm.Image")));
            this.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirm.Location = new System.Drawing.Point(359, 31);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(87, 37);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "确认入库";
            this.btnConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // labelProductId
            // 
            this.labelProductId.AutoSize = true;
            this.labelProductId.Location = new System.Drawing.Point(15, 35);
            this.labelProductId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelProductId.Name = "labelProductId";
            this.labelProductId.Size = new System.Drawing.Size(67, 13);
            this.labelProductId.TabIndex = 0;
            this.labelProductId.Text = "商品编码：";
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Location = new System.Drawing.Point(15, 70);
            this.labelProductName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(67, 13);
            this.labelProductName.TabIndex = 0;
            this.labelProductName.Text = "商品名称：";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(85, 66);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(163, 20);
            this.txtProductName.TabIndex = 1;
            // 
            // labelIncome
            // 
            this.labelIncome.AutoSize = true;
            this.labelIncome.Location = new System.Drawing.Point(15, 105);
            this.labelIncome.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelIncome.Name = "labelIncome";
            this.labelIncome.Size = new System.Drawing.Size(67, 13);
            this.labelIncome.TabIndex = 0;
            this.labelIncome.Text = "入库数量：";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(85, 101);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(84, 20);
            this.txtQuantity.TabIndex = 2;
            this.txtQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuantity_KeyDown);
            // 
            // labelTip1
            // 
            this.labelTip1.AutoSize = true;
            this.labelTip1.ForeColor = System.Drawing.Color.Red;
            this.labelTip1.Location = new System.Drawing.Point(171, 105);
            this.labelTip1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTip1.Name = "labelTip1";
            this.labelTip1.Size = new System.Drawing.Size(67, 13);
            this.labelTip1.TabIndex = 0;
            this.labelTip1.Text = "必须是整数";
            // 
            // groupBoxProductInfo
            // 
            this.groupBoxProductInfo.Controls.Add(this.txtProductId);
            this.groupBoxProductInfo.Controls.Add(this.btnConfirm);
            this.groupBoxProductInfo.Controls.Add(this.labelProductId);
            this.groupBoxProductInfo.Controls.Add(this.labelProductName);
            this.groupBoxProductInfo.Controls.Add(this.labelTip2);
            this.groupBoxProductInfo.Controls.Add(this.txtProductName);
            this.groupBoxProductInfo.Controls.Add(this.labelIncome);
            this.groupBoxProductInfo.Controls.Add(this.txtQuantity);
            this.groupBoxProductInfo.Controls.Add(this.labelTip1);
            this.groupBoxProductInfo.Location = new System.Drawing.Point(12, 12);
            this.groupBoxProductInfo.Name = "groupBoxProductInfo";
            this.groupBoxProductInfo.Size = new System.Drawing.Size(472, 152);
            this.groupBoxProductInfo.TabIndex = 0;
            this.groupBoxProductInfo.TabStop = false;
            this.groupBoxProductInfo.Text = "[商品数据]";
            // 
            // labelTip2
            // 
            this.labelTip2.AutoSize = true;
            this.labelTip2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labelTip2.Location = new System.Drawing.Point(248, 105);
            this.labelTip2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTip2.Name = "labelTip2";
            this.labelTip2.Size = new System.Drawing.Size(211, 13);
            this.labelTip2.TabIndex = 0;
            this.labelTip2.Text = "如果是退货，则将入库数量改为负数。";
            // 
            // FormProductStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 174);
            this.Controls.Add(this.groupBoxProductInfo);
            this.Name = "FormProductStorage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "【商品入库】";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormProductStorage_FormClosing);
            this.Load += new System.EventHandler(this.FormProductStorage_Load);
            this.groupBoxProductInfo.ResumeLayout(false);
            this.groupBoxProductInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label labelProductId;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label labelIncome;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label labelTip1;
        private System.Windows.Forms.GroupBox groupBoxProductInfo;
        private System.Windows.Forms.Label labelTip2;
    }
}