namespace SMartStorageManager.AdminManager
{
    partial class FormModifyPwd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormModifyPwd));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.txtOldPwd = new System.Windows.Forms.TextBox();
            this.labelOriginalPwd = new System.Windows.Forms.Label();
            this.txtConfirmPwd = new System.Windows.Forms.TextBox();
            this.labelComfirmNewPwd = new System.Windows.Forms.Label();
            this.txtNewPwd = new System.Windows.Forms.TextBox();
            this.labelNewPwd = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(254, 99);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 33);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭窗口";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnModify
            // 
            this.btnModify.Image = ((System.Drawing.Image)(resources.GetObject("btnModify.Image")));
            this.btnModify.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModify.Location = new System.Drawing.Point(254, 21);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(78, 33);
            this.btnModify.TabIndex = 3;
            this.btnModify.Text = "提交修改";
            this.btnModify.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // txtOldPwd
            // 
            this.txtOldPwd.Location = new System.Drawing.Point(84, 27);
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.PasswordChar = '*';
            this.txtOldPwd.Size = new System.Drawing.Size(140, 20);
            this.txtOldPwd.TabIndex = 0;
            this.txtOldPwd.UseSystemPasswordChar = true;
            // 
            // labelOriginalPwd
            // 
            this.labelOriginalPwd.AutoSize = true;
            this.labelOriginalPwd.Location = new System.Drawing.Point(25, 31);
            this.labelOriginalPwd.Name = "labelOriginalPwd";
            this.labelOriginalPwd.Size = new System.Drawing.Size(55, 13);
            this.labelOriginalPwd.TabIndex = 0;
            this.labelOriginalPwd.Text = "原密码：";
            // 
            // txtConfirmPwd
            // 
            this.txtConfirmPwd.Location = new System.Drawing.Point(84, 105);
            this.txtConfirmPwd.Name = "txtConfirmPwd";
            this.txtConfirmPwd.PasswordChar = '*';
            this.txtConfirmPwd.Size = new System.Drawing.Size(140, 20);
            this.txtConfirmPwd.TabIndex = 2;
            this.txtConfirmPwd.UseSystemPasswordChar = true;
            // 
            // labelComfirmNewPwd
            // 
            this.labelComfirmNewPwd.AutoSize = true;
            this.labelComfirmNewPwd.ForeColor = System.Drawing.Color.Red;
            this.labelComfirmNewPwd.Location = new System.Drawing.Point(13, 109);
            this.labelComfirmNewPwd.Name = "labelComfirmNewPwd";
            this.labelComfirmNewPwd.Size = new System.Drawing.Size(67, 13);
            this.labelComfirmNewPwd.TabIndex = 0;
            this.labelComfirmNewPwd.Text = "确认密码：";
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.Location = new System.Drawing.Point(83, 66);
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.PasswordChar = '*';
            this.txtNewPwd.Size = new System.Drawing.Size(141, 20);
            this.txtNewPwd.TabIndex = 1;
            this.txtNewPwd.UseSystemPasswordChar = true;
            // 
            // labelNewPwd
            // 
            this.labelNewPwd.AutoSize = true;
            this.labelNewPwd.ForeColor = System.Drawing.Color.Red;
            this.labelNewPwd.Location = new System.Drawing.Point(24, 70);
            this.labelNewPwd.Name = "labelNewPwd";
            this.labelNewPwd.Size = new System.Drawing.Size(55, 13);
            this.labelNewPwd.TabIndex = 0;
            this.labelNewPwd.Text = "新密码：";
            // 
            // FormModifyPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 152);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.txtOldPwd);
            this.Controls.Add(this.labelOriginalPwd);
            this.Controls.Add(this.txtConfirmPwd);
            this.Controls.Add(this.labelComfirmNewPwd);
            this.Controls.Add(this.txtNewPwd);
            this.Controls.Add(this.labelNewPwd);
            this.Name = "FormModifyPwd";
            this.Text = "【修改密码】";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormModifyPwd_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.TextBox txtOldPwd;
        private System.Windows.Forms.Label labelOriginalPwd;
        private System.Windows.Forms.TextBox txtConfirmPwd;
        private System.Windows.Forms.Label labelComfirmNewPwd;
        private System.Windows.Forms.TextBox txtNewPwd;
        private System.Windows.Forms.Label labelNewPwd;
    }
}