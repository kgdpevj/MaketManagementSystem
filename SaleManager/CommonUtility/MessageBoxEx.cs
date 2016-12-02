using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace CommonUtility
{
    /// <summary>
    /// 可以携带详细信息的消息框
    /// </summary>
    public static class MessageBoxEx
    {
        //异常消息文本
        private const string InvalidButtonExString = "按钮参数不是有效的枚举项！";
        private const string InvalidIconExString = "图标参数不是有效的枚举项！";
        private const string InvalidDfButtonExString = "默认按钮参数不是有效的枚举项！";

        /// <summary>
        /// 是否启用动画效果
        /// </summary>
        public static bool EnableAnimate { get; set; }

        /// <summary>
        /// 是否启用声音反馈
        /// </summary>
        public static bool EnableSound { get; set; }

        //静态构造
        static MessageBoxEx()
        {
            //默认启用动画+声音
            EnableAnimate = true;
            EnableSound = true;
        }

        #region 公开方法

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="message">消息文本</param>
        /// <param name="caption">消息框标题</param>
        /// <param name="attachMessage">附加消息</param>
        public static DialogResult Show(string message, string caption = null, string attachMessage = null)
        {
            return ShowCore(message, caption, attachMessage, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        /*下面这仨弄成重载而不是可选方法是为了避免不必要的参数检查*/

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="message">消息文本</param>
        /// <param name="caption">消息框标题</param>
        /// <param name="attachMessage">附加消息</param>
        /// <param name="buttons">按钮组合</param>
        public static DialogResult Show(string message, string caption, string attachMessage, MessageBoxButtons buttons)
        {
            if (!Enum.IsDefined(typeof(MessageBoxButtons), buttons)) { throw new InvalidEnumArgumentException(InvalidButtonExString); }

            return ShowCore(message, caption, attachMessage, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="message">消息文本</param>
        /// <param name="caption">消息框标题</param>
        /// <param name="attachMessage">附加消息</param>
        /// <param name="buttons">按钮组合</param>
        /// <param name="icon">图标</param>
        public static DialogResult Show(string message, string caption, string attachMessage, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            if (!Enum.IsDefined(typeof(MessageBoxButtons), buttons)) { throw new InvalidEnumArgumentException(InvalidButtonExString); }
            if (!Enum.IsDefined(typeof(MessageBoxIcon), icon)) { throw new InvalidEnumArgumentException(InvalidIconExString); }

            return ShowCore(message, caption, attachMessage, buttons, icon, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="message">消息文本</param>
        /// <param name="caption">消息框标题</param>
        /// <param name="attachMessage">附加消息</param>
        /// <param name="buttons">按钮组合</param>
        /// <param name="icon">图标</param>
        /// <param name="defaultButton">默认按钮</param>
        public static DialogResult Show(string message, string caption, string attachMessage, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            if (!Enum.IsDefined(typeof(MessageBoxButtons), buttons)) { throw new InvalidEnumArgumentException(InvalidButtonExString); }
            if (!Enum.IsDefined(typeof(MessageBoxIcon), icon)) { throw new InvalidEnumArgumentException(InvalidIconExString); }
            if (!Enum.IsDefined(typeof(MessageBoxDefaultButton), defaultButton)) { throw new InvalidEnumArgumentException(InvalidDfButtonExString); }

            return ShowCore(message, caption, attachMessage, buttons, icon, defaultButton);
        }

        /********传入异常的重载********/

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="message">消息文本</param>
        /// <param name="caption">消息框标题</param>
        /// <param name="exception">异常实例</param>
        public static DialogResult Show(string message, string caption, Exception exception)
        {
            return Show(message, caption, exception == null ? string.Empty : exception.ToString());
        }

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="message">消息文本</param>
        /// <param name="caption">消息框标题</param>
        /// <param name="exception">异常实例</param>
        /// <param name="buttons">按钮组合</param>
        public static DialogResult Show(string message, string caption, Exception exception, MessageBoxButtons buttons)
        {
            return Show(message, caption, exception == null ? string.Empty : exception.ToString(), buttons);
        }

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="message">消息文本</param>
        /// <param name="caption">消息框标题</param>
        /// <param name="exception">异常实例</param>
        /// <param name="buttons">按钮组合</param>
        /// <param name="icon">图标</param>
        public static DialogResult Show(string message, string caption, Exception exception, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return Show(message, caption, exception == null ? string.Empty : exception.ToString(), buttons, icon);
        }

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="message">消息文本</param>
        /// <param name="caption">消息框标题</param>
        /// <param name="exception">异常实例</param>
        /// <param name="buttons">按钮组合</param>
        /// <param name="icon">图标</param>
        /// <param name="defaultButton">默认按钮</param>
        public static DialogResult Show(string message, string caption, Exception exception, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return Show(message, caption, exception == null ? string.Empty : exception.ToString(), buttons, icon, defaultButton);
        }

        #endregion

        //内部方法，不检查参数有效性
        private static DialogResult ShowCore(string message, string caption, string attachMessage, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            using (MessageForm f = new MessageForm(message, caption, buttons, icon, defaultButton, attachMessage, EnableAnimate, EnableSound))
            {
                return f.ShowDialog();
            }
        }


        /*----------------
         下面是消息窗体相关
         ---------------*/

        /// <summary>
        /// 消息窗体
        /// </summary>
        /// <remarks>参数有效性由MessageBoxEx负责</remarks>
        private class MessageForm : Form
        {
            /* todo 存在问题：
             * 当消息区文本非常非常多时，且反复进行改变消息框窗口大小、位置、展开收起的操作，那么在某次展开时
               详细信息文本框可能会在原位置（即消息区内某rect）瞬闪一下，
               原因是文本框控件在显示时总会在原位置WM_NCPAINT + WM_ERASEBKGND一下，暂无解决办法。
               实际应用中碰到的几率很小，就算碰到，影响也可以忽略。
             */

            #region 控件初始化

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
                if (disposing && (components != null))
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
                this.button3 = new System.Windows.Forms.Button();
                this.txbAttach = new TextBoxUnSelectAllable();
                this.button2 = new System.Windows.Forms.Button();
                this.button1 = new System.Windows.Forms.Button();
                this.plButtonsZone = new MessageBoxEx.MessageForm.PanelBasic();
                this.ckbToggle = new MessageBoxEx.MessageForm.ToggleButton(this.UseAnimate);
                this.plAttachZone = new MessageBoxEx.MessageForm.PanelBasic();
                this.lbMsg = new MessageBoxEx.MessageForm.MessageViewer();
                this.plButtonsZone.SuspendLayout();
                this.plAttachZone.SuspendLayout();
                this.SuspendLayout();
                // 
                // button3
                // 
                this.button3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
                this.button3.Location = new System.Drawing.Point(320, 8);
                this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
                this.button3.Name = "button3";
                this.button3.Size = new System.Drawing.Size(85, 27);
                this.button3.TabIndex = 2;
                // 
                // txbAttach
                // 
                this.txbAttach.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                         | System.Windows.Forms.AnchorStyles.Left)
                                         | System.Windows.Forms.AnchorStyles.Right;
                this.txbAttach.Location = new System.Drawing.Point(10, 7);
                this.txbAttach.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
                this.txbAttach.Name = "txbAttach";
                this.txbAttach.ReadOnly = true;
                this.txbAttach.Multiline = true;
                this.txbAttach.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
                this.txbAttach.Size = new System.Drawing.Size(395, 105);
                this.txbAttach.TabIndex = 0;
                // 
                // button2
                // 
                this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
                this.button2.Location = new System.Drawing.Point(229, 8);
                this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
                this.button2.Name = "button2";
                this.button2.Size = new System.Drawing.Size(85, 27);
                this.button2.TabIndex = 1;
                // 
                // button1
                // 
                this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
                this.button1.Location = new System.Drawing.Point(138, 8);
                this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(85, 27);
                this.button1.TabIndex = 0;
                // 
                // plButtonsZone
                // 
                this.plButtonsZone.Controls.Add(this.ckbToggle);
                this.plButtonsZone.Controls.Add(this.button1);
                this.plButtonsZone.Controls.Add(this.button2);
                this.plButtonsZone.Controls.Add(this.button3);
                this.plButtonsZone.Dock = System.Windows.Forms.DockStyle.Bottom;
                this.plButtonsZone.Location = new System.Drawing.Point(0, 96);
                this.plButtonsZone.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
                this.plButtonsZone.Name = "plButtonsZone";
                this.plButtonsZone.Size = new System.Drawing.Size(415, 36);
                this.plButtonsZone.TabIndex = 1;
                // 
                // ckbToggle
                // 
                this.ckbToggle.Location = new System.Drawing.Point(10, 8);
                this.ckbToggle.Name = "ckbToggle";
                this.ckbToggle.Size = new System.Drawing.Size(93, 27);
                this.ckbToggle.TabIndex = 3;
                this.ckbToggle.Text = "详细信息(&D)";
                this.ckbToggle.CheckedChanged += this.ckbToggle_CheckedChanged;
                // 
                // plAttachZone
                // 
                this.plAttachZone.Controls.Add(this.txbAttach);
                this.plAttachZone.Dock = System.Windows.Forms.DockStyle.Fill;
                this.plAttachZone.Location = new System.Drawing.Point(0, 130);
                this.plAttachZone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
                this.plAttachZone.Name = "plAttachZone";
                this.plAttachZone.Size = new System.Drawing.Size(415, 114);
                this.plAttachZone.TabIndex = 2;
                this.plAttachZone.Visible = false;
                // 
                // lbMsg
                // 
                this.lbMsg.Dock = System.Windows.Forms.DockStyle.Fill;
                this.lbMsg.Icon = null;
                this.lbMsg.Location = new System.Drawing.Point(0, 0);
                this.lbMsg.Name = "lbMsg";
                this.lbMsg.Padding = new System.Windows.Forms.Padding(21, 18, 21, 18);
                //this.lbMsg.Size = new System.Drawing.Size(415, 96);
                this.lbMsg.TabIndex = 0;
                // 
                // FmMsg
                // 
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
                //this.ClientSize = new System.Drawing.Size(415, 261);
                this.Controls.Add(this.lbMsg);
                this.Controls.Add(this.plButtonsZone);
                this.Controls.Add(this.plAttachZone);
                this.DoubleBuffered = true;
                this.MaximizeBox = false;
                this.Name = "MessageForm";
                this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 17);
                this.ShowIcon = false;
                this.ShowInTaskbar = false;
                this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
                this.plButtonsZone.ResumeLayout(false);
                this.plAttachZone.ResumeLayout(false);
                this.plAttachZone.PerformLayout();
                this.ResumeLayout(false);
            }

            #endregion

            private ToggleButton ckbToggle;
            private TextBoxUnSelectAllable txbAttach;
            private MessageViewer lbMsg;
            private System.Windows.Forms.Button button2;
            private System.Windows.Forms.Button button1;
            private PanelBasic plButtonsZone;
            private PanelBasic plAttachZone;
            private System.Windows.Forms.Button button3;

            #endregion

            /// <summary>
            /// 最大默认窗体客户区宽度
            /// </summary>
            const int MaxClientWidth = 700;

            int expandHeight;
            /// <summary>
            /// 详细信息区展开高度
            /// </summary>
            private int ExpandHeight
            {
                get { return expandHeight < 150 ? 150 : expandHeight; }
                set { expandHeight = value; }
            }

            #region 属性

            /// <summary>
            /// 是否启用动画效果
            /// </summary>
            /// <remarks>此处还弄该属性是为了保证窗体类的独立性</remarks>
            private bool UseAnimate { get; set; }

            /// <summary>
            /// 是否启用声音反馈
            /// </summary>
            /// <remarks>此处还弄该属性是为了保证窗体类的独立性</remarks>
            private bool UseSound { get; set; }

            /// <summary>
            /// 消息按钮
            /// </summary>
            private MessageBoxButtons MessageButtons { get; set; }

            /// <summary>
            /// 消息图标
            /// </summary>
            private MessageBoxIcon MessageIcon { get; set; }

            /// <summary>
            /// 默认按钮
            /// </summary>
            private MessageBoxDefaultButton DefaultButton { get; set; }

            #endregion

            /// <summary>
            /// 创建消息窗体
            /// </summary>
            private MessageForm(bool enableAnimate)
            {
                this.UseAnimate = enableAnimate;//须尽早设置，要供展开按钮初始化用
                InitializeComponent();
                this.StartPosition = Form.ActiveForm == null ? FormStartPosition.CenterScreen : FormStartPosition.CenterParent;
                this.Font = SystemFonts.MessageBoxFont;

                //注册事件
                this.button1.Click += button_Click;
                this.button2.Click += button_Click;
                this.button3.Click += button_Click;
                this.plAttachZone.Resize += plAttachZone_Resize;
            }

            /// <summary>
            /// 创建消息窗体
            /// </summary>
            public MessageForm(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, string attachMessage, bool enableAnimate, bool enableSound)
                : this(enableAnimate)
            {
                this.lbMsg.Text = message;
                this.Text = caption;
                this.txbAttach.Text = attachMessage;
                this.MessageButtons = buttons;
                this.MessageIcon = icon;
                this.DefaultButton = defaultButton;
                this.UseSound = enableSound;
            }

            #region 重写基类方法

            protected override void OnLoad(EventArgs e)
            {
                //须在计算各种尺寸前搞掂
                ProcessIcon();
                ProcessButtons();

                this.MinimumSize = SizeFromClientSize(new Size(GetPanelButtonMinWidth(), GetClientMinHeight()));

                //参数意义定为客户区最大大小，所以需刨掉非客户区高度后传入
                this.ClientSize = this.GetPreferredSize(new Size(MaxClientWidth, Screen.PrimaryScreen.WorkingArea.Height - (this.Height - this.ClientSize.Height)));

                base.OnLoad(e);
            }

            protected override void OnShown(EventArgs e)
            {
                //设置默认按钮焦点。须在OnShown中设置按钮焦点才有用
                Button dfBtn;
                if ((dfBtn = this.AcceptButton as Button) != null)
                {
                    dfBtn.Focus();
                }

                //播放消息提示音
                if (this.UseSound) { PlayMessageSound(this.MessageIcon); }

                base.OnShown(e);
            }

            //重写窗体参数
            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams prms = base.CreateParams;

                    if ((Convert.ToInt32(this.MessageButtons) & 1) == 0) //没有Cancel按钮时屏蔽关闭按钮，刚好在偶数项
                    {
                        prms.ClassStyle |= 0x200;
                    }

                    return prms;
                }
            }

            /// <summary>
            /// 计算合适的窗口尺寸
            /// </summary>
            /// <param name="proposedSize">该参数此处定义为客户区可设置的最大尺寸</param>
            public override Size GetPreferredSize(Size proposedSize)
            {
                int reservedHeight = plButtonsZone.Height + Padding.Bottom;
                Size size = lbMsg.GetPreferredSize(new Size(proposedSize.Width, proposedSize.Height - reservedHeight));
                size.Height += reservedHeight;
                return size;
            }

            #endregion

            #region 事件处理方法

            //展开收起
            private void ckbToggle_CheckedChanged(object sender, EventArgs e)
            {
                this.SuspendLayout();

                if (ckbToggle.Checked)
                {
                    plButtonsZone.SendToBack();
                    lbMsg.SendToBack();

                    lbMsg.Dock = DockStyle.Top;
                    plButtonsZone.Dock = DockStyle.Top;

                    ChangeFormHeight(ExpandHeight);
                    plAttachZone.Visible = true;
                }
                else
                {
                    ExpandHeight = plAttachZone.Height;//记忆展开高度
                    plAttachZone.Visible = false;
                    ChangeFormHeight(-ExpandHeight);

                    plButtonsZone.SendToBack();

                    plButtonsZone.Dock = DockStyle.Bottom;
                    lbMsg.Dock = DockStyle.Fill;
                }

                this.ResumeLayout();
            }

            //按钮事件
            private void button_Click(object sender, EventArgs e)
            {
                this.DialogResult = (DialogResult)((sender as Button).Tag);
            }

            //用户手工收完详细区则触发折叠
            private void plAttachZone_Resize(object sender, EventArgs e)
            {
                if (ckbToggle.Checked && plAttachZone.Height == 0)
                {
                    ckbToggle.Checked = false;
                }
            }

            #endregion

            #region 辅助+私有方法

            /// <summary>
            /// 处理按钮相关
            /// </summary>
            private void ProcessButtons()
            {
                this.ckbToggle.Visible = txbAttach.Text.Trim().Length != 0; //无详细信息就不显示展开按钮

                int btnCount = 3; //按钮数量

                switch (MessageButtons) //老实用case，可读点
                {
                    case MessageBoxButtons.AbortRetryIgnore:
                        button1.Text = "中止(&A)";
                        button1.Tag = DialogResult.Abort;
                        button2.Text = "重试(&R)";
                        button2.Tag = DialogResult.Retry;
                        button3.Text = "忽略(&I)";
                        button3.Tag = DialogResult.Ignore;
                        break;
                    case MessageBoxButtons.OK:
                        button1.Visible = false;
                        button2.Visible = false;
                        button3.Text = "确定";
                        button3.Tag = DialogResult.OK;
                        btnCount = 1;
                        break;
                    case MessageBoxButtons.OKCancel:
                        button1.Visible = false;
                        button2.Text = "确定";
                        button2.Tag = DialogResult.OK;
                        button3.Text = "取消";
                        button3.Tag = DialogResult.Cancel;
                        btnCount = 2;
                        break;
                    case MessageBoxButtons.RetryCancel:
                        button1.Visible = false;
                        button2.Text = "重试(&R)";
                        button2.Tag = DialogResult.Retry;
                        button3.Text = "取消";
                        button3.Tag = DialogResult.Cancel;
                        btnCount = 2;
                        break;
                    case MessageBoxButtons.YesNo:
                        button1.Visible = false;
                        button2.Text = "是(&Y)";
                        button2.Tag = DialogResult.Yes;
                        button3.Text = "否(&N)";
                        button3.Tag = DialogResult.No;
                        btnCount = 2;
                        break;
                    case MessageBoxButtons.YesNoCancel:
                        button1.Text = "是(&Y)";
                        button1.Tag = DialogResult.Yes;
                        button2.Text = "否(&N)";
                        button2.Tag = DialogResult.No;
                        button3.Text = "取消";
                        button3.Tag = DialogResult.Cancel;
                        break;
                    default:
                        break;
                }

                //仅有OK和有取消按钮时设CancelButton
                if ((int)MessageButtons == 0 || ((int)MessageButtons & 1) == 1)
                {
                    this.CancelButton = button3;
                }

                //处理默认按钮
                if (btnCount == 1)
                {
                    this.AcceptButton = button3;
                }
                else if (btnCount == 2)
                {
                    this.AcceptButton = DefaultButton == MessageBoxDefaultButton.Button2 ? button3 : button2;
                }
                else
                {
                    Button[] btnArray = { button1, button2, button3 };
                    this.AcceptButton = btnArray[Convert.ToInt32(DefaultButton) / 0x100];
                }
            }

            /// <summary>
            /// 处理图标
            /// </summary>
            /// <remarks>之所以不在此处顺便把Sound处理了是为了松耦合</remarks>
            private void ProcessIcon()
            {
                switch (MessageIcon)
                {
                    //MessageBoxIcon.Information同样
                    case MessageBoxIcon.Asterisk:
                        lbMsg.Icon = SystemIcons.Information;
                        break;

                    //MessageBoxIcon.Hand、MessageBoxIcon.Stop同样
                    case MessageBoxIcon.Error:
                        lbMsg.Icon = SystemIcons.Error;
                        break;

                    //MessageBoxIcon.Warning同样
                    case MessageBoxIcon.Exclamation:
                        lbMsg.Icon = SystemIcons.Warning;
                        break;

                    case MessageBoxIcon.Question:
                        lbMsg.Icon = SystemIcons.Question;
                        break;

                    default:
                        lbMsg.Icon = null;
                        break;
                }
            }

            /// <summary>
            /// 计算窗体客户区最小高度
            /// </summary>
            private int GetClientMinHeight()
            {
                return lbMsg.MinimumHeight + plButtonsZone.Height + Padding.Bottom;
            }

            /// <summary>
            /// 计算按钮区最小宽度
            /// </summary>
            private int GetPanelButtonMinWidth()
            {
                int r = 20 /*左右Padding*/, visibleCount = -1 /*因为两个以上才会有间距*/;
                if (ckbToggle.Visible)
                {
                    r += ckbToggle.Width;
                    visibleCount++;
                }
                if (button1.Visible)
                {
                    r += button1.Width * 3;
                    visibleCount += 3;
                }
                else if (button2.Visible)
                {
                    r += button2.Width * 2;
                    visibleCount += 2;
                }
                else
                {
                    r += button3.Width;
                    visibleCount++;
                }

                if (visibleCount != -1)
                {
                    r += visibleCount * 6;
                } //按钮间距

                return r;
            }

            /// <summary>
            /// 改变窗体高度。内部有动画处理
            /// </summary>
            /// <param name="increment">增量（负数即为减小高度）</param>
            private void ChangeFormHeight(int increment)
            {
                int finalHeight = this.Height + increment; //正确的目标高度

                if (!this.UseAnimate) //不使用动画
                {
                    this.Height = finalHeight;
                    return;
                }

                const int step = 8; //帧数

                for (int i = 0; i < step; i++)
                {
                    if (i == step - 1) //最后一步直达目标
                    {
                        this.Height = finalHeight;
                        return;
                    }

                    this.Height += increment / step;

                    Application.DoEvents(); //必要
                    Thread.Sleep(10);
                }
            }

            /// <summary>
            /// 播放系统事件声音
            /// </summary>
            /// <remarks>之所以不用MessageBeep API是因为这货在NT6上不出声，所以用PlaySound代替</remarks>
            private static void PlayMessageSound(MessageBoxIcon msgType)
            {
                string eventString;
                switch (msgType)
                {
                    case MessageBoxIcon.None:
                        eventString = "SystemDefault";
                        break;

                    //Question原本是没声音的，此实现让它蹭一下Information的
                    case MessageBoxIcon.Question:

                    //MessageBoxIcon.Information同样
                    case MessageBoxIcon.Asterisk:
                        eventString = "SystemAsterisk";
                        break;

                    //MessageBoxIcon.Hand、MessageBoxIcon.Stop同样
                    case MessageBoxIcon.Error:
                        eventString = "SystemHand";
                        break;

                    //MessageBoxIcon.Warning同样
                    case MessageBoxIcon.Exclamation:
                        eventString = "SystemExclamation";
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                PlaySound(eventString, IntPtr.Zero, 0x10000 /*SND_ALIAS*/| 0x1 /*SND_ASYNC*/);
            }

            [DllImport("winmm.dll", CharSet = CharSet.Auto)]
            private static extern bool PlaySound([MarshalAs(UnmanagedType.LPWStr)] string soundName, IntPtr hmod, int soundFlags);

            #endregion

            #region 嵌套类

            /// <summary>
            /// 基础面板
            /// </summary>
            private class PanelBasic : Control
            {
                public PanelBasic()
                {
                    SetStyle(ControlStyles.AllPaintingInWmPaint, false);//关键，不要设置双缓冲，不然其上的ToolBar不正常
                    SetStyle(ControlStyles.OptimizedDoubleBuffer, true);//重要。不设置的话控件绘制不正常
                    SetStyle(ControlStyles.ContainerControl, true);
                    SetStyle(ControlStyles.Selectable, false);
                }

                protected override void WndProc(ref Message m)
                {
                    //屏蔽WM_ERASEBKGND。防止显示时在原位置快闪
                    //不能通过ControlStyles.AllPaintingInWmPaint=true屏蔽
                    //会影响其上的ToolBar
                    if (m.Msg == 0x14) { return; }

                    base.WndProc(ref m);
                }

                protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
                {
                    //防Dock时面板短暂滞留在原位置
                    base.SetBoundsCore(x, y, width, height, specified | BoundsSpecified.Y | BoundsSpecified.Width);
                }
            }

            /// <summary>
            /// 消息呈现控件
            /// </summary>
            private class MessageViewer : Control
            {
                const TextFormatFlags textFlags = TextFormatFlags.EndEllipsis //未完省略号
                                                  | TextFormatFlags.WordBreak //允许换行
                                                  | TextFormatFlags.NoPadding //无边距
                                                  | TextFormatFlags.ExternalLeading //行间空白。NT5必须，不然文字挤在一起
                                                  | TextFormatFlags.TextBoxControl; //避免半行

                const int IconSpace = 5; //图标与文本间距

                const float PreferredScale = 13;//最佳文本区块比例（宽/高）

                /// <summary>
                /// 最小高度。不要重写MinimumSize，那会在窗体移动和缩放时都会执行
                /// </summary>
                public int MinimumHeight
                {
                    get
                    {
                        return (this.Icon != null ? Math.Max(this.Icon.Height, this.Font.Height) : this.Font.Height) + Padding.Vertical;
                    }
                }

                /// <summary>
                /// 获取或设置图标
                /// </summary>
                public Icon Icon { get; set; }

                public MessageViewer()
                {
                    this.SetStyle(ControlStyles.CacheText, true);
                    this.SetStyle(ControlStyles.UserPaint, true);
                    this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                    this.SetStyle(ControlStyles.Selectable, false);
                    this.SetStyle(ControlStyles.ResizeRedraw, true); //重要

                    this.DoubleBuffered = true; //双缓冲
                    BackColor = Environment.OSVersion.Version.Major == 5 ? SystemColors.Control : Color.White;
                }

                //防Dock改变尺寸
                protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
                {
                    base.SetBoundsCore(x, y, width, height, specified | BoundsSpecified.Size);
                }

                /// <summary>
                /// 计算合适的消息区尺寸
                /// </summary>
                /// <param name="proposedSize">该参数此处定义为此控件可设置的最大尺寸</param>
                /// <remarks>该方法对太长的单行文本有做比例优化处理，避免用户摆头幅度过大扭到脖子</remarks>
                public override Size GetPreferredSize(Size proposedSize)
                {
                    if (proposedSize.Width < 10) { proposedSize.Width = int.MaxValue; }
                    if (proposedSize.Height < 10) { proposedSize.Height = int.MaxValue; }

                    int reservedWidth = Padding.Horizontal + (this.Icon == null ? 0 : (this.Icon.Width + IconSpace));

                    Size wellSize = Size.Empty;
                    if (!string.IsNullOrEmpty(this.Text))
                    {
                        //用指定宽度测量文本面积
                        Size size = TextRenderer.MeasureText(this.Text, this.Font, new Size(proposedSize.Width - reservedWidth, 0), textFlags);
                        int lineHeight = TextRenderer.MeasureText(" ", this.Font, new Size(int.MaxValue, 0), textFlags).Height;//单行高，Font.Height不靠谱

                        wellSize = Convert.ToSingle(size.Width) / size.Height > PreferredScale //过于宽扁的情况
                            ? Size.Ceiling(GetSameSizeWithNewScale(size, PreferredScale))
                            : size;

                        //凑齐整行高，确保尾行显示
                        wellSize.Height = Convert.ToInt32(Math.Ceiling(wellSize.Height / Convert.ToDouble(lineHeight))) * lineHeight;
                    }
                    if (this.Icon != null)
                    {
                        wellSize.Width += this.Icon.Width + IconSpace;
                        wellSize.Height = Math.Max(this.Icon.Height, wellSize.Height);
                    }
                    wellSize += Padding.Size;

                    //不应超过指定尺寸。宽度在上面已确保不会超过
                    if (wellSize.Height > proposedSize.Height) { wellSize.Height = proposedSize.Height; }

                    return wellSize;
                }

                /// <summary>
                /// 重绘
                /// </summary>
                protected override void OnPaint(PaintEventArgs e)
                {
                    Graphics g = e.Graphics;
                    Rectangle rect = GetPaddedRectangle();

                    //绘制图标
                    if (this.Icon != null)
                    {
                        g.DrawIcon(this.Icon, Padding.Left, Padding.Top);

                        //右移文本区
                        rect.X += this.Icon.Width + IconSpace;
                        rect.Width -= this.Icon.Width + IconSpace;

                        //若文字太少，则与图标垂直居中
                        if (this.Text.Length < 100)
                        {
                            Size textSize = TextRenderer.MeasureText(g, this.Text, this.Font, rect.Size, textFlags);
                            if (textSize.Height <= this.Icon.Height)
                            {
                                rect.Y += (this.Icon.Height - textSize.Height) / 2;
                            }
                        }
                    }

                    //g.FillRectangle(Brushes.Gainsboro, rect);//test

                    //绘制文本
                    TextRenderer.DrawText(g, this.Text, this.Font, rect, Color.Black, textFlags);

                    base.OnPaint(e);
                }

                /// <summary>
                /// 根据原尺寸，得到相同面积、且指定比例的新尺寸
                /// </summary>
                /// <param name="src">原尺寸</param>
                /// <param name="scale">新尺寸比例。需是width/height</param>
                private static SizeF GetSameSizeWithNewScale(Size src, float scale)
                {
                    int sqr = src.Width * src.Height;//原面积
                    double w = Math.Sqrt(sqr * scale);//新面积宽
                    return new SizeF(Convert.ToSingle(w), Convert.ToSingle(sqr / w));
                }

                /// <summary>
                /// 获取刨去Padding的内容区
                /// </summary>
                private Rectangle GetPaddedRectangle()
                {
                    Rectangle r = this.ClientRectangle;
                    r.X += this.Padding.Left;
                    r.Y += this.Padding.Top;
                    r.Width -= this.Padding.Horizontal;
                    r.Height -= this.Padding.Vertical;
                    return r;
                }
            }

            /// <summary>
            /// 屏蔽全选消息的文本框
            /// </summary>
            private class TextBoxUnSelectAllable : TextBox
            {
                protected override void WndProc(ref Message m)
                {
                    //EM_SETSEL
                    if (m.Msg == 0xB1) { return; }

                    base.WndProc(ref m);
                }
            }

            /// <summary>
            /// 包装ToolBarButton为单一控件
            /// </summary>
            private class ToggleButton : Control
            {
                /// <summary>
                /// 展开/收起图标数据
                /// </summary>
                const string ImgDataBase64 =
@"iVBORw0KGgoAAAANSUhEUgAAACAAAAAQCAYAAAB3AH1ZAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJ
bWFnZVJlYWR5ccllPAAAA3NJREFUeNqklVlPFEEQx/8zPccue6gorMd6gBegeCAQD4w+oCx+AInx
IB4EfTK8+g2MQUUTcBU8En0wmvigEkyMxgcTjRrUqHFVUBRQQaJGl2WPmbG6dzCLWUiESf7T0739
666urqqVDjVcxT9PAWkfqZKUY491ktpIzaRXGPv5L15J+dZIRx26dqAwf56c48+Cx+1CzDDR//13
/seevvx3HZ8OxmLxMzSvjhT5Z+Nx8UoKfHOu31e+qWwZPBkOMBkwTAvRuAE21QuvJwNz5s6U25++
rv365dtC+4SxifJsfeVWvsCJ2TOzqyo2FsHt1OBSFeiqTItIsOhHw7JgGBZM+s72TcOvX+GccHgw
k7qttgHj5slOLNE0tXZNSQGYJEEhiDEJusLoW4ZMfZnGJVv0QmHhYuiaup+zE+W5Aftyc/xMURRh
acJIKpowqDVhkhu5LCspiY6k0OIL5s9mdrCNyp9sDKL+6PExeW5AwOebigRNiiVMkoFIPIFwlLcG
huIm4mRI3DRpAQg38oPMmD6Nuz4wGn+koRGH64/hxr1HuHjl2qg8D8JcZ4ZTRCtLSDjT1Ijz51rS
5lfVzj2o2rWXXCzDPcnNh3L5K5WntdHYdAqng6cwa/EK+AuK8SDUSx65gUAlxR1ZkcqLLDBpkJ+S
R8yOvbXw+vx4GOoZsXlZyQqsK10pNlDpjlVZDPMs0FL55mATLl04C39+EWblFf3l2zs+w7jZii1b
Kkfw3IDOcDiS5/G4yLjknQcCAbrPW3j8plvMWlu8XGwOsblMASYjFh3i3S4SS+W3Vddg++6apJ8t
OwN4HHH/p+G5AW3f+gbyvB632DwGHigSyjdvpn4b9ElZWF9aJE6uMAanJsOlK3jdNcAXuE2y0vEQ
rcXfyeCT0vPcES0funoNRTJpgixSRUQsLbapogIbVq8S47rKCORShQvbX7437NI6Km8Ol9sxeG7A
i2g0Fnz2PAQ3TcjQGBw02UGWOqig8L7bweB1qCSFxHD3/nMMDkWDnJ0oP1yK6z529y1i8ovydaVL
wXOaXxl3W7K4yKKykY/Rdq8dofe9d+x6jonyw6WYu+Pyj5/hzLedPcU61dDJLh1T3E4BRgYjCHV0
4/qdJ+bn/h+naW41KZpiwLh5Kc3fMS+vNXaRybVT7YMdcM2228d6/ov/I8AAPfkI7yO+mM8AAAAA
SUVORK5CYII=";

                readonly bool isToggleMode;
                bool isChecked;
                bool useAnimate;
                readonly ImageList imgList;

                /// <summary>
                /// Checked改变后
                /// </summary>
                public event EventHandler CheckedChanged;

                /// <summary>
                /// 使用动画按钮效果
                /// </summary>
                private bool UseAnimate
                {
                    get { return useAnimate; }
                    set
                    {
                        if (useAnimate == value) { return; }

                        useAnimate = value;
                        if (IsHandleCreated) { this.CreateHandle(); }
                    }
                }

                /// <summary>
                /// 获取或设置按钮是否处于按下状态
                /// </summary>
                [Description("获取或设置按钮是否处于按下状态"), DefaultValue(false)]
                public bool Checked
                {
                    get
                    {
                        if (IsHandleCreated)
                        {
                            //保证isChecked与实情吻合。TB_ISBUTTONCHECKED
                            isChecked = Convert.ToBoolean(SendMessage(this.Handle, 0x40A, IntPtr.Zero, IntPtr.Zero).ToInt32());
                        }
                        return isChecked;
                    }
                    set
                    {
                        if (isChecked == value || !isToggleMode) { return; }

                        isChecked = value;

                        if (IsHandleCreated)
                        {
                            //TB_CHECKBUTTON
                            SendMessage(this.Handle, 0x402, IntPtr.Zero, new IntPtr(Convert.ToInt32(value)));
                        }

                        OnCheckedChanged(EventArgs.Empty);
                    }
                }

                /// <summary>
                /// 创建ToolBarButtonControl
                /// </summary>
                public ToggleButton(bool useAnimate)
                {
                    SetStyle(ControlStyles.UserPaint, false);
                    SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                    SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                    SetStyle(ControlStyles.ResizeRedraw, true);

                    this.isToggleMode = true;//写死好了，独立版才提供设置
                    this.UseAnimate = useAnimate;

                    //将图标加入imageList
                    imgList = new ImageList { ImageSize = new System.Drawing.Size(16, 16), ColorDepth = ColorDepth.Depth32Bit };
                    using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(ImgDataBase64)))
                    {
                        imgList.Images.AddStrip(Image.FromStream(ms));
                    }
                }

                /// <summary>
                /// 执行左键单击
                /// </summary>
                public void PerformClick()
                {
                    SendMessage(this.Handle, 0x201, new IntPtr(0x1), IntPtr.Zero);//WM_LBUTTONDOWN
                    Application.DoEvents();
                    SendMessage(this.Handle, 0x202, IntPtr.Zero, IntPtr.Zero);    //WM_LBUTTONUP
                }

                protected override void WndProc(ref Message m)
                {
                    //有节操的响应鼠标动作
                    if ((m.Msg == 0x201 || m.Msg == 0x202) && (!this.Enabled || !this.Visible))
                    {
                        return;
                    }
                    base.WndProc(ref m);
                }


                //创建ToolBar
                protected override CreateParams CreateParams
                {
                    get
                    {
                        CreateParams prms = base.CreateParams;
                        prms.ClassName = "ToolbarWindow32";
                        prms.Style = 0x40000000
                            | 0x10000000
                            //| 0x2000000 //WS_CLIPCHILDREN
                            //| 0x8000
                            | 0x1
                            | 0x4
                            | 0x8
                            | 0x40
                            | 0x1000 //TBSTYLE_LIST，图标文本横排
                            ;
                        if (UseAnimate) { prms.Style |= 0x800; }//TBSTYLE_FLAT。flat模式在NT6.x下，按钮按下会有动画效果

                        prms.ExStyle = 0;

                        return prms;
                    }
                }

                protected override void OnHandleCreated(EventArgs e)
                {
                    base.OnHandleCreated(e);

                    //设置imgList
                    SendMessage(this.Handle, 0x430, IntPtr.Zero, imgList.Handle);//TB_SETIMAGELIST

                    //准备添加按钮
                    int btnStructSize = Marshal.SizeOf(typeof(TBBUTTON));
                    SendMessage(this.Handle, 0x41E, new IntPtr(btnStructSize), IntPtr.Zero);//TB_BUTTONSTRUCTSIZE，必须在添加按钮前

                    //构建按钮信息
                    TBBUTTON btnStruct = new TBBUTTON
                    {
                        //iBitmap = 0,
                        //idCommand = 0,
                        fsState = 0x4, //TBSTATE_ENABLED
                        iString = SendMessage(this.Handle, 0x44D, 0, this.Text + '\0')//TB_ADDSTRING
                    };
                    if (this.isToggleMode) { btnStruct.fsStyle = 0x2; }//BTNS_CHECK。作为切换按钮时

                    IntPtr btnStructStart = IntPtr.Zero;
                    try
                    {
                        btnStructStart = Marshal.AllocHGlobal(btnStructSize);//在非托管区创建一个指针
                        Marshal.StructureToPtr(btnStruct, btnStructStart, true);//把结构体塞到上述指针

                        //添加按钮
                        SendMessage(this.Handle, 0x444, new IntPtr(1)/*按钮数量*/, btnStructStart);//TB_ADDBUTTONS。从指针取按钮信息

                        //设置按钮尺寸刚好为ToolBar尺寸
                        AdjustButtonSize();
                    }
                    finally
                    {
                        if (btnStructStart != IntPtr.Zero) { Marshal.FreeHGlobal(btnStructStart); }
                    }
                }

                protected override bool ProcessCmdKey(ref Message m, Keys keyData)
                {
                    //将空格和回车作为鼠标单击处理
                    if (m.Msg == 0x100 && (keyData == Keys.Enter || keyData == Keys.Space))
                    {
                        PerformClick();
                        return true;
                    }

                    return base.ProcessCmdKey(ref m, keyData);
                }

                /// <summary>
                /// 处理助记键
                /// </summary>
                protected override bool ProcessMnemonic(char charCode)
                {
                    if (IsMnemonic(charCode, this.Text))
                    {
                        PerformClick();
                        return true;
                    }

                    return base.ProcessMnemonic(charCode);
                }

                protected override void OnClick(EventArgs e)
                {
                    //忽略鼠标右键
                    MouseEventArgs me = e as MouseEventArgs;
                    if (me != null && me.Button != System.Windows.Forms.MouseButtons.Left)
                    { return; }

                    //若是切换模式，直接引发Checked事件（不要通过设置Checked属性引发，因为OnClick发送之前就已经Check了）
                    //存在理论上的不可靠，但暂无更好办法
                    if (isToggleMode)
                    { this.OnCheckedChanged(EventArgs.Empty); }

                    base.OnClick(e);
                }

                //重绘后重设按钮尺寸
                protected override void OnInvalidated(InvalidateEventArgs e)
                {
                    base.OnInvalidated(e);
                    AdjustButtonSize();
                }

                /// <summary>
                /// 引发CheckedChanged事件
                /// </summary>
                protected virtual void OnCheckedChanged(EventArgs e)
                {
                    SetImageIndex(this.Checked ? 1 : 0);

                    if (CheckedChanged != null) { CheckedChanged(this, e); }
                }

                /// <summary>
                /// 设置图标索引
                /// </summary>
                private void SetImageIndex(int index)
                {
                    //TB_CHANGEBITMAP
                    SendMessage(this.Handle, 0x42B, IntPtr.Zero, new IntPtr(index));
                }

                /// <summary>
                /// 调整按钮尺寸刚好为ToolBar尺寸
                /// </summary>
                private void AdjustButtonSize()
                {
                    IntPtr lParam = new IntPtr((this.Width & 0xFFFF) | (this.Height << 0x10)); //MakeLParam手法
                    SendMessage(this.Handle, 0x41F, IntPtr.Zero, lParam); //TB_SETBUTTONSIZE
                }

                #region Win32 API

                [DllImport("user32.dll", CharSet = CharSet.Auto)]
                private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

                [DllImport("user32.dll", CharSet = CharSet.Auto)]
                private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);

                [StructLayout(LayoutKind.Sequential)]
                private struct TBBUTTON
                {
                    public int iBitmap;
                    public int idCommand;
                    public byte fsState;
                    public byte fsStyle;
                    public byte bReserved0;
                    public byte bReserved1;
                    public IntPtr dwData;
                    public IntPtr iString;
                }

                #endregion
            }

            #endregion
        }
    }
}
