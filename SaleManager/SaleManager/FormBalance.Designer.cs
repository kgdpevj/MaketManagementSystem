namespace SaleManager
{
    partial class FormBalance
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
            if (disposing && (components != null))
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
            this.components = new System.ComponentModel.Container();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelRealReceived = new System.Windows.Forms.Label();
            this.labelReturnChange = new System.Windows.Forms.Label();
            this.labelVIPCardNo = new System.Windows.Forms.Label();
            this.textBoxRealReceived = new System.Windows.Forms.TextBox();
            this.textBoxTotal = new System.Windows.Forms.TextBox();
            this.textBoxReturnChange = new System.Windows.Forms.TextBox();
            this.textBoxVIPCardNo = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelTip = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerTips = new System.Windows.Forms.Timer(this.components);
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTotal.Location = new System.Drawing.Point(44, 33);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(114, 42);
            this.labelTotal.TabIndex = 0;
            this.labelTotal.Text = "应收款";
            this.labelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRealReceived
            // 
            this.labelRealReceived.AutoSize = true;
            this.labelRealReceived.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelRealReceived.Location = new System.Drawing.Point(44, 87);
            this.labelRealReceived.Name = "labelRealReceived";
            this.labelRealReceived.Size = new System.Drawing.Size(114, 42);
            this.labelRealReceived.TabIndex = 0;
            this.labelRealReceived.Text = "实收款";
            this.labelRealReceived.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelReturnChange
            // 
            this.labelReturnChange.AutoSize = true;
            this.labelReturnChange.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelReturnChange.Location = new System.Drawing.Point(44, 141);
            this.labelReturnChange.Name = "labelReturnChange";
            this.labelReturnChange.Size = new System.Drawing.Size(114, 42);
            this.labelReturnChange.TabIndex = 0;
            this.labelReturnChange.Text = "找零款";
            this.labelReturnChange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVIPCardNo
            // 
            this.labelVIPCardNo.AutoSize = true;
            this.labelVIPCardNo.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelVIPCardNo.Location = new System.Drawing.Point(45, 223);
            this.labelVIPCardNo.Name = "labelVIPCardNo";
            this.labelVIPCardNo.Size = new System.Drawing.Size(110, 31);
            this.labelVIPCardNo.TabIndex = 0;
            this.labelVIPCardNo.Text = "会员卡号";
            this.labelVIPCardNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxRealReceived
            // 
            this.textBoxRealReceived.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRealReceived.ForeColor = System.Drawing.Color.Blue;
            this.textBoxRealReceived.Location = new System.Drawing.Point(164, 84);
            this.textBoxRealReceived.Name = "textBoxRealReceived";
            this.textBoxRealReceived.Size = new System.Drawing.Size(212, 48);
            this.textBoxRealReceived.TabIndex = 0;
            this.textBoxRealReceived.Text = "0.00";
            this.textBoxRealReceived.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxRealReceived.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxRealReceived_KeyDown);
            // 
            // textBoxTotal
            // 
            this.textBoxTotal.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxTotal.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTotal.ForeColor = System.Drawing.Color.Red;
            this.textBoxTotal.Location = new System.Drawing.Point(164, 30);
            this.textBoxTotal.Name = "textBoxTotal";
            this.textBoxTotal.ReadOnly = true;
            this.textBoxTotal.Size = new System.Drawing.Size(212, 48);
            this.textBoxTotal.TabIndex = 1;
            this.textBoxTotal.Text = "0.00";
            this.textBoxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxReturnChange
            // 
            this.textBoxReturnChange.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxReturnChange.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxReturnChange.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.textBoxReturnChange.Location = new System.Drawing.Point(164, 138);
            this.textBoxReturnChange.Name = "textBoxReturnChange";
            this.textBoxReturnChange.ReadOnly = true;
            this.textBoxReturnChange.Size = new System.Drawing.Size(212, 48);
            this.textBoxReturnChange.TabIndex = 1;
            this.textBoxReturnChange.Text = "0.00";
            this.textBoxReturnChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxVIPCardNo
            // 
            this.textBoxVIPCardNo.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxVIPCardNo.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxVIPCardNo.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.textBoxVIPCardNo.Location = new System.Drawing.Point(164, 224);
            this.textBoxVIPCardNo.Name = "textBoxVIPCardNo";
            this.textBoxVIPCardNo.ReadOnly = true;
            this.textBoxVIPCardNo.Size = new System.Drawing.Size(212, 28);
            this.textBoxVIPCardNo.TabIndex = 1;
            this.textBoxVIPCardNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelTip});
            this.statusStrip.Location = new System.Drawing.Point(0, 285);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(449, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabelTip
            // 
            this.toolStripStatusLabelTip.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelTip.Name = "toolStripStatusLabelTip";
            this.toolStripStatusLabelTip.Size = new System.Drawing.Size(0, 17);
            // 
            // timerTips
            // 
            this.timerTips.Interval = 1000;
            this.timerTips.Tick += new System.EventHandler(this.timerTips_Tick);
            // 
            // FormBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 307);
            this.ControlBox = false;
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.textBoxVIPCardNo);
            this.Controls.Add(this.textBoxReturnChange);
            this.Controls.Add(this.textBoxTotal);
            this.Controls.Add(this.textBoxRealReceived);
            this.Controls.Add(this.labelVIPCardNo);
            this.Controls.Add(this.labelReturnChange);
            this.Controls.Add(this.labelRealReceived);
            this.Controls.Add(this.labelTotal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBalance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "【结算】";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormBalance_KeyDown);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelRealReceived;
        private System.Windows.Forms.Label labelReturnChange;
        private System.Windows.Forms.Label labelVIPCardNo;
        private System.Windows.Forms.TextBox textBoxRealReceived;
        private System.Windows.Forms.TextBox textBoxTotal;
        private System.Windows.Forms.TextBox textBoxReturnChange;
        private System.Windows.Forms.TextBox textBoxVIPCardNo;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTip;
        private System.Windows.Forms.Timer timerTips;
    }
}