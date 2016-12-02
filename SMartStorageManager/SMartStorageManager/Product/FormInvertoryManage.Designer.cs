namespace SMartStorageManager.Product
{
    partial class FormInvertoryManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInvertoryManage));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelTotalWarning = new System.Windows.Forms.Label();
            this.txtMinCount = new System.Windows.Forms.TextBox();
            this.btnUpdateInventory = new System.Windows.Forms.Button();
            this.labelCurrentStorage = new System.Windows.Forms.Label();
            this.txtTotalCount = new System.Windows.Forms.TextBox();
            this.btnUpdateSet = new System.Windows.Forms.Button();
            this.groupBoxStorageWarning = new System.Windows.Forms.GroupBox();
            this.linkLabelRefresh = new System.Windows.Forms.LinkLabel();
            this.btnShowMin = new System.Windows.Forms.Button();
            this.btnShowMax = new System.Windows.Forms.Button();
            this.lblMinCount = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblMaxCount = new System.Windows.Forms.Label();
            this.labelAboveWarning = new System.Windows.Forms.Label();
            this.labelUnderWarning = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBoxModifyStorage = new System.Windows.Forms.GroupBox();
            this.groupBoxWarningSetting = new System.Windows.Forms.GroupBox();
            this.labelMinStorage = new System.Windows.Forms.Label();
            this.txtMaxCount = new System.Windows.Forms.TextBox();
            this.labelMaxStorage = new System.Windows.Forms.Label();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxStorageWarning.SuspendLayout();
            this.groupBoxModifyStorage.SuspendLayout();
            this.groupBoxWarningSetting.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.dgvProduct ) ).BeginInit();
            this.SuspendLayout();
            // 
            // labelTotalWarning
            // 
            this.labelTotalWarning.AutoSize = true;
            this.labelTotalWarning.Location = new System.Drawing.Point(18, 39);
            this.labelTotalWarning.Name = "labelTotalWarning";
            this.labelTotalWarning.Size = new System.Drawing.Size(67, 13);
            this.labelTotalWarning.TabIndex = 0;
            this.labelTotalWarning.Text = "预警总数：";
            // 
            // txtMinCount
            // 
            this.txtMinCount.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ));
            this.txtMinCount.Location = new System.Drawing.Point(209, 31);
            this.txtMinCount.Name = "txtMinCount";
            this.txtMinCount.Size = new System.Drawing.Size(69, 21);
            this.txtMinCount.TabIndex = 1;
            // 
            // btnUpdateInventory
            // 
            this.btnUpdateInventory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 255 ) ) ) ), ( (int)( ( (byte)( 128 ) ) ) ), ( (int)( ( (byte)( 0 ) ) ) ));
            this.btnUpdateInventory.Image = ( (System.Drawing.Image)( resources.GetObject("btnUpdateInventory.Image") ) );
            this.btnUpdateInventory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateInventory.Location = new System.Drawing.Point(170, 21);
            this.btnUpdateInventory.Name = "btnUpdateInventory";
            this.btnUpdateInventory.Size = new System.Drawing.Size(82, 41);
            this.btnUpdateInventory.TabIndex = 1;
            this.btnUpdateInventory.Text = "修改库存";
            this.btnUpdateInventory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateInventory.UseVisualStyleBackColor = true;
            this.btnUpdateInventory.Click += new System.EventHandler(this.btnUpdateInventory_Click);
            // 
            // labelCurrentStorage
            // 
            this.labelCurrentStorage.AutoSize = true;
            this.labelCurrentStorage.Location = new System.Drawing.Point(10, 35);
            this.labelCurrentStorage.Name = "labelCurrentStorage";
            this.labelCurrentStorage.Size = new System.Drawing.Size(67, 13);
            this.labelCurrentStorage.TabIndex = 0;
            this.labelCurrentStorage.Text = "当前库存：";
            // 
            // txtTotalCount
            // 
            this.txtTotalCount.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ));
            this.txtTotalCount.Location = new System.Drawing.Point(75, 31);
            this.txtTotalCount.Name = "txtTotalCount";
            this.txtTotalCount.Size = new System.Drawing.Size(69, 21);
            this.txtTotalCount.TabIndex = 0;
            // 
            // btnUpdateSet
            // 
            this.btnUpdateSet.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 255 ) ) ) ), ( (int)( ( (byte)( 128 ) ) ) ), ( (int)( ( (byte)( 0 ) ) ) ));
            this.btnUpdateSet.Image = ( (System.Drawing.Image)( resources.GetObject("btnUpdateSet.Image") ) );
            this.btnUpdateSet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateSet.Location = new System.Drawing.Point(293, 21);
            this.btnUpdateSet.Name = "btnUpdateSet";
            this.btnUpdateSet.Size = new System.Drawing.Size(83, 41);
            this.btnUpdateSet.TabIndex = 2;
            this.btnUpdateSet.Text = "更新设置";
            this.btnUpdateSet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateSet.UseVisualStyleBackColor = true;
            this.btnUpdateSet.Click += new System.EventHandler(this.btnUpdateSet_Click);
            // 
            // groupBoxStorageWarning
            // 
            this.groupBoxStorageWarning.Controls.Add(this.linkLabelRefresh);
            this.groupBoxStorageWarning.Controls.Add(this.btnShowMin);
            this.groupBoxStorageWarning.Controls.Add(this.btnShowMax);
            this.groupBoxStorageWarning.Controls.Add(this.lblMinCount);
            this.groupBoxStorageWarning.Controls.Add(this.lblCount);
            this.groupBoxStorageWarning.Controls.Add(this.lblMaxCount);
            this.groupBoxStorageWarning.Controls.Add(this.labelTotalWarning);
            this.groupBoxStorageWarning.Controls.Add(this.labelAboveWarning);
            this.groupBoxStorageWarning.Controls.Add(this.labelUnderWarning);
            this.groupBoxStorageWarning.Location = new System.Drawing.Point(12, 12);
            this.groupBoxStorageWarning.Name = "groupBoxStorageWarning";
            this.groupBoxStorageWarning.Size = new System.Drawing.Size(789, 79);
            this.groupBoxStorageWarning.TabIndex = 1;
            this.groupBoxStorageWarning.TabStop = false;
            this.groupBoxStorageWarning.Text = "[库存预警信息]";
            // 
            // linkLabelRefresh
            // 
            this.linkLabelRefresh.AutoSize = true;
            this.linkLabelRefresh.Location = new System.Drawing.Point(107, 0);
            this.linkLabelRefresh.Name = "linkLabelRefresh";
            this.linkLabelRefresh.Size = new System.Drawing.Size(109, 13);
            this.linkLabelRefresh.TabIndex = 0;
            this.linkLabelRefresh.TabStop = true;
            this.linkLabelRefresh.Text = "[刷新库存预警信息]";
            this.linkLabelRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRefresh_LinkClicked);
            // 
            // btnShowMin
            // 
            this.btnShowMin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 255 ) ) ) ), ( (int)( ( (byte)( 128 ) ) ) ), ( (int)( ( (byte)( 0 ) ) ) ));
            this.btnShowMin.Image = ( (System.Drawing.Image)( resources.GetObject("btnShowMin.Image") ) );
            this.btnShowMin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowMin.Location = new System.Drawing.Point(692, 25);
            this.btnShowMin.Name = "btnShowMin";
            this.btnShowMin.Size = new System.Drawing.Size(91, 41);
            this.btnShowMin.TabIndex = 5;
            this.btnShowMin.Text = "显示低库存";
            this.btnShowMin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShowMin.UseVisualStyleBackColor = true;
            this.btnShowMin.Click += new System.EventHandler(this.btnShowMin_Click);
            // 
            // btnShowMax
            // 
            this.btnShowMax.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 255 ) ) ) ), ( (int)( ( (byte)( 128 ) ) ) ), ( (int)( ( (byte)( 0 ) ) ) ));
            this.btnShowMax.Image = ( (System.Drawing.Image)( resources.GetObject("btnShowMax.Image") ) );
            this.btnShowMax.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowMax.Location = new System.Drawing.Point(359, 25);
            this.btnShowMax.Name = "btnShowMax";
            this.btnShowMax.Size = new System.Drawing.Size(93, 41);
            this.btnShowMax.TabIndex = 3;
            this.btnShowMax.Text = "显示超库存";
            this.btnShowMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShowMax.UseVisualStyleBackColor = true;
            this.btnShowMax.Click += new System.EventHandler(this.btnShowMax_Click);
            // 
            // lblMinCount
            // 
            this.lblMinCount.BackColor = System.Drawing.Color.White;
            this.lblMinCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMinCount.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ));
            this.lblMinCount.ForeColor = System.Drawing.Color.Red;
            this.lblMinCount.Location = new System.Drawing.Point(598, 33);
            this.lblMinCount.Name = "lblMinCount";
            this.lblMinCount.Size = new System.Drawing.Size(76, 24);
            this.lblMinCount.TabIndex = 4;
            this.lblMinCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCount
            // 
            this.lblCount.BackColor = System.Drawing.Color.White;
            this.lblCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCount.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ));
            this.lblCount.Location = new System.Drawing.Point(85, 33);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(76, 24);
            this.lblCount.TabIndex = 1;
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaxCount
            // 
            this.lblMaxCount.BackColor = System.Drawing.Color.White;
            this.lblMaxCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMaxCount.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ));
            this.lblMaxCount.ForeColor = System.Drawing.Color.Blue;
            this.lblMaxCount.Location = new System.Drawing.Point(262, 33);
            this.lblMaxCount.Name = "lblMaxCount";
            this.lblMaxCount.Size = new System.Drawing.Size(76, 24);
            this.lblMaxCount.TabIndex = 2;
            this.lblMaxCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAboveWarning
            // 
            this.labelAboveWarning.AutoSize = true;
            this.labelAboveWarning.Location = new System.Drawing.Point(171, 39);
            this.labelAboveWarning.Name = "labelAboveWarning";
            this.labelAboveWarning.Size = new System.Drawing.Size(91, 13);
            this.labelAboveWarning.TabIndex = 0;
            this.labelAboveWarning.Text = "超出库存上限：";
            // 
            // labelUnderWarning
            // 
            this.labelUnderWarning.AutoSize = true;
            this.labelUnderWarning.Location = new System.Drawing.Point(509, 39);
            this.labelUnderWarning.Name = "labelUnderWarning";
            this.labelUnderWarning.Size = new System.Drawing.Size(91, 13);
            this.labelUnderWarning.TabIndex = 0;
            this.labelUnderWarning.Text = "低于库存下限：";
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 255 ) ) ) ), ( (int)( ( (byte)( 128 ) ) ) ), ( (int)( ( (byte)( 0 ) ) ) ));
            this.btnClose.Image = ( (System.Drawing.Image)( resources.GetObject("btnClose.Image") ) );
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(722, 474);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 41);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "关闭窗口";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBoxModifyStorage
            // 
            this.groupBoxModifyStorage.Controls.Add(this.btnUpdateInventory);
            this.groupBoxModifyStorage.Controls.Add(this.txtTotalCount);
            this.groupBoxModifyStorage.Controls.Add(this.labelCurrentStorage);
            this.groupBoxModifyStorage.Location = new System.Drawing.Point(433, 456);
            this.groupBoxModifyStorage.Name = "groupBoxModifyStorage";
            this.groupBoxModifyStorage.Size = new System.Drawing.Size(272, 76);
            this.groupBoxModifyStorage.TabIndex = 4;
            this.groupBoxModifyStorage.TabStop = false;
            this.groupBoxModifyStorage.Text = "[调整商品库存]";
            // 
            // groupBoxWarningSetting
            // 
            this.groupBoxWarningSetting.Controls.Add(this.txtMinCount);
            this.groupBoxWarningSetting.Controls.Add(this.btnUpdateSet);
            this.groupBoxWarningSetting.Controls.Add(this.labelMinStorage);
            this.groupBoxWarningSetting.Controls.Add(this.txtMaxCount);
            this.groupBoxWarningSetting.Controls.Add(this.labelMaxStorage);
            this.groupBoxWarningSetting.Location = new System.Drawing.Point(12, 456);
            this.groupBoxWarningSetting.Name = "groupBoxWarningSetting";
            this.groupBoxWarningSetting.Size = new System.Drawing.Size(406, 76);
            this.groupBoxWarningSetting.TabIndex = 3;
            this.groupBoxWarningSetting.TabStop = false;
            this.groupBoxWarningSetting.Text = "[库存预警设置]";
            // 
            // labelMinStorage
            // 
            this.labelMinStorage.AutoSize = true;
            this.labelMinStorage.Location = new System.Drawing.Point(149, 35);
            this.labelMinStorage.Name = "labelMinStorage";
            this.labelMinStorage.Size = new System.Drawing.Size(67, 13);
            this.labelMinStorage.TabIndex = 0;
            this.labelMinStorage.Text = "最小库存：";
            // 
            // txtMaxCount
            // 
            this.txtMaxCount.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ));
            this.txtMaxCount.Location = new System.Drawing.Point(73, 31);
            this.txtMaxCount.Name = "txtMaxCount";
            this.txtMaxCount.Size = new System.Drawing.Size(69, 21);
            this.txtMaxCount.TabIndex = 0;
            // 
            // labelMaxStorage
            // 
            this.labelMaxStorage.AutoSize = true;
            this.labelMaxStorage.Location = new System.Drawing.Point(8, 35);
            this.labelMaxStorage.Name = "labelMaxStorage";
            this.labelMaxStorage.Size = new System.Drawing.Size(67, 13);
            this.labelMaxStorage.TabIndex = 0;
            this.labelMaxStorage.Text = "最大库存：";
            // 
            // dgvProduct
            // 
            this.dgvProduct.AllowUserToAddRows = false;
            this.dgvProduct.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 192 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.dgvProduct.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProduct.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvProduct.ColumnHeadersHeight = 25;
            this.dgvProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductId,
            this.ProductName,
            this.UnitName,
            this.MaxCount,
            this.TotalCount,
            this.MinCount,
            this.StatusDescription});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProduct.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvProduct.EnableHeadersVisualStyles = false;
            this.dgvProduct.GridColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 128 ) ) ) ), ( (int)( ( (byte)( 128 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.dgvProduct.Location = new System.Drawing.Point(13, 103);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 255 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ), ( (int)( ( (byte)( 128 ) ) ) ));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProduct.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgvProduct.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvProduct.RowTemplate.Height = 23;
            this.dgvProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProduct.Size = new System.Drawing.Size(789, 345);
            this.dgvProduct.TabIndex = 2;
            this.dgvProduct.CurrentCellChanged += new System.EventHandler(this.dgvProduct_CurrentCellChanged);
            this.dgvProduct.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvProduct_RowPostPaint);
            // 
            // ProductId
            // 
            this.ProductId.DataPropertyName = "ProductId";
            this.ProductId.HeaderText = "商品编号";
            this.ProductId.Name = "ProductId";
            this.ProductId.ReadOnly = true;
            this.ProductId.Width = 120;
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "商品名称";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            this.ProductName.Width = 180;
            // 
            // UnitName
            // 
            this.UnitName.DataPropertyName = "UnitName";
            this.UnitName.HeaderText = "计量单位";
            this.UnitName.Name = "UnitName";
            this.UnitName.ReadOnly = true;
            this.UnitName.Width = 80;
            // 
            // MaxCount
            // 
            this.MaxCount.DataPropertyName = "MaxCount";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ));
            this.MaxCount.DefaultCellStyle = dataGridViewCellStyle2;
            this.MaxCount.HeaderText = "最大库存";
            this.MaxCount.Name = "MaxCount";
            this.MaxCount.ReadOnly = true;
            this.MaxCount.Width = 80;
            // 
            // TotalCount
            // 
            this.TotalCount.DataPropertyName = "TotalCount";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ));
            this.TotalCount.DefaultCellStyle = dataGridViewCellStyle2;
            this.TotalCount.HeaderText = "当前库存";
            this.TotalCount.Name = "TotalCount";
            this.TotalCount.ReadOnly = true;
            this.TotalCount.Width = 80;
            // 
            // MinCount
            // 
            this.MinCount.DataPropertyName = "MinCount";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 134 ) ));
            this.MinCount.DefaultCellStyle = dataGridViewCellStyle3;
            this.MinCount.HeaderText = "最小库存";
            this.MinCount.Name = "MinCount";
            this.MinCount.ReadOnly = true;
            // 
            // StatusDescription
            // 
            this.StatusDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StatusDescription.DataPropertyName = "StatusDescription";
            this.StatusDescription.HeaderText = "库存状态";
            this.StatusDescription.Name = "StatusDescription";
            this.StatusDescription.ReadOnly = true;
            // 
            // FormInvertoryManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 544);
            this.Controls.Add(this.groupBoxStorageWarning);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBoxModifyStorage);
            this.Controls.Add(this.groupBoxWarningSetting);
            this.Controls.Add(this.dgvProduct);
            this.Name = "FormInvertoryManage";
            this.Text = "【库存管理】";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormInvertoryManage_FormClosing);
            this.Load += new System.EventHandler(this.FormInvertoryManage_Load);
            this.groupBoxStorageWarning.ResumeLayout(false);
            this.groupBoxStorageWarning.PerformLayout();
            this.groupBoxModifyStorage.ResumeLayout(false);
            this.groupBoxModifyStorage.PerformLayout();
            this.groupBoxWarningSetting.ResumeLayout(false);
            this.groupBoxWarningSetting.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.dgvProduct ) ).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTotalWarning;
        private System.Windows.Forms.TextBox txtMinCount;
        private System.Windows.Forms.Button btnUpdateInventory;
        private System.Windows.Forms.Label labelCurrentStorage;
        private System.Windows.Forms.TextBox txtTotalCount;
        private System.Windows.Forms.Button btnUpdateSet;
        private System.Windows.Forms.GroupBox groupBoxStorageWarning;
        private System.Windows.Forms.LinkLabel linkLabelRefresh;
        private System.Windows.Forms.Label labelUnderWarning;
        private System.Windows.Forms.Button btnShowMin;
        private System.Windows.Forms.Button btnShowMax;
        private System.Windows.Forms.Label lblMinCount;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblMaxCount;
        private System.Windows.Forms.Label labelAboveWarning;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBoxModifyStorage;
        private System.Windows.Forms.GroupBox groupBoxWarningSetting;
        private System.Windows.Forms.Label labelMinStorage;
        private System.Windows.Forms.Label labelMaxStorage;
        private System.Windows.Forms.TextBox txtMaxCount;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusDescription;
    }
}