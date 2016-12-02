namespace SMartStorageManager.AdminManager
{
    partial class FormEditAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditAdmin));
            this.txtLoginId = new System.Windows.Forms.TextBox();
            this.labelUserType = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.labelUserId = new System.Windows.Forms.Label();
            this.txtAdminName = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBoxUserInfo = new System.Windows.Forms.GroupBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.groupBoxUserInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLoginId
            // 
            this.txtLoginId.Location = new System.Drawing.Point(91, 34);
            this.txtLoginId.Name = "txtLoginId";
            this.txtLoginId.Size = new System.Drawing.Size(100, 20);
            this.txtLoginId.TabIndex = 0;
            // 
            // labelUserType
            // 
            this.labelUserType.AutoSize = true;
            this.labelUserType.Location = new System.Drawing.Point(20, 118);
            this.labelUserType.Name = "labelUserType";
            this.labelUserType.Size = new System.Drawing.Size(67, 13);
            this.labelUserType.TabIndex = 0;
            this.labelUserType.Text = "用户类型：";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(20, 78);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(67, 13);
            this.labelUserName.TabIndex = 0;
            this.labelUserName.Text = "用户名称：";
            // 
            // cboRole
            // 
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Items.AddRange(new object[] {
            "一般管理员",
            "超级管理员"});
            this.cboRole.Location = new System.Drawing.Point(92, 114);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(99, 21);
            this.cboRole.TabIndex = 2;
            // 
            // labelUserId
            // 
            this.labelUserId.AutoSize = true;
            this.labelUserId.Location = new System.Drawing.Point(20, 38);
            this.labelUserId.Name = "labelUserId";
            this.labelUserId.Size = new System.Drawing.Size(67, 13);
            this.labelUserId.TabIndex = 0;
            this.labelUserId.Text = "登录账号：";
            // 
            // txtAdminName
            // 
            this.txtAdminName.Location = new System.Drawing.Point(91, 74);
            this.txtAdminName.Name = "txtAdminName";
            this.txtAdminName.Size = new System.Drawing.Size(100, 20);
            this.txtAdminName.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(263, 136);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 33);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "关闭窗口";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBoxUserInfo
            // 
            this.groupBoxUserInfo.Controls.Add(this.txtLoginId);
            this.groupBoxUserInfo.Controls.Add(this.labelUserType);
            this.groupBoxUserInfo.Controls.Add(this.labelUserName);
            this.groupBoxUserInfo.Controls.Add(this.cboRole);
            this.groupBoxUserInfo.Controls.Add(this.labelUserId);
            this.groupBoxUserInfo.Controls.Add(this.txtAdminName);
            this.groupBoxUserInfo.Location = new System.Drawing.Point(12, 12);
            this.groupBoxUserInfo.Name = "groupBoxUserInfo";
            this.groupBoxUserInfo.Size = new System.Drawing.Size(232, 157);
            this.groupBoxUserInfo.TabIndex = 0;
            this.groupBoxUserInfo.TabStop = false;
            this.groupBoxUserInfo.Text = "[用户信息]";
            // 
            // btnSubmit
            // 
            this.btnSubmit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSubmit.Image = ((System.Drawing.Image)(resources.GetObject("btnSubmit.Image")));
            this.btnSubmit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubmit.Location = new System.Drawing.Point(263, 12);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(80, 33);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "添加用户";
            this.btnSubmit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // FormEditAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 182);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBoxUserInfo);
            this.Controls.Add(this.btnSubmit);
            this.Name = "FormEditAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "【修改用户信息】";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditAdmin_FormClosing);
            this.Load += new System.EventHandler(this.FormEditAdmin_Load);
            this.groupBoxUserInfo.ResumeLayout(false);
            this.groupBoxUserInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtLoginId;
        private System.Windows.Forms.Label labelUserType;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Label labelUserId;
        private System.Windows.Forms.TextBox txtAdminName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBoxUserInfo;
        private System.Windows.Forms.Button btnSubmit;
    }
}