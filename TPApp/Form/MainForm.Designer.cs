namespace Translao
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.titlePanel = new System.Windows.Forms.Panel();
            this.btnResize = new FontAwesome.Sharp.IconButton();
            this.btnTask = new FontAwesome.Sharp.IconButton();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.cmbOut = new MetroFramework.Controls.MetroComboBox();
            this.btnENOut = new MetroFramework.Controls.MetroButton();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.btnOpen = new MetroFramework.Controls.MetroButton();
            this.btnENIn = new MetroFramework.Controls.MetroButton();
            this.btnROIn = new MetroFramework.Controls.MetroButton();
            this.btnSPIn = new MetroFramework.Controls.MetroButton();
            this.cmbIn = new MetroFramework.Controls.MetroComboBox();
            this.tbIn = new MetroFramework.Controls.MetroTextBox();
            this.tbOut = new MetroFramework.Controls.MetroTextBox();
            this.labelIn = new MetroFramework.Controls.MetroLabel();
            this.labelOut = new MetroFramework.Controls.MetroLabel();
            this.btnSwitch = new FontAwesome.Sharp.IconButton();
            this.btnFRIn = new MetroFramework.Controls.MetroButton();
            this.btnROOut = new MetroFramework.Controls.MetroButton();
            this.btnSPOut = new MetroFramework.Controls.MetroButton();
            this.btnFROut = new MetroFramework.Controls.MetroButton();
            this.titlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titlePanel.BackColor = System.Drawing.Color.Transparent;
            this.titlePanel.Controls.Add(this.btnResize);
            this.titlePanel.Controls.Add(this.btnTask);
            this.titlePanel.Controls.Add(this.btnClose);
            this.titlePanel.ForeColor = System.Drawing.Color.Transparent;
            this.titlePanel.Location = new System.Drawing.Point(-5, -6);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(1096, 50);
            this.titlePanel.TabIndex = 0;
            this.titlePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlePanel_MouseDown);
            // 
            // btnResize
            // 
            this.btnResize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResize.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnResize.BackColor = System.Drawing.Color.Silver;
            this.btnResize.BackgroundImage = global::Translao.Properties.Resources.maximize;
            this.btnResize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnResize.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResize.ForeColor = System.Drawing.Color.Transparent;
            this.btnResize.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnResize.IconColor = System.Drawing.Color.Transparent;
            this.btnResize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnResize.Location = new System.Drawing.Point(1000, 15);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(50, 30);
            this.btnResize.TabIndex = 4;
            this.btnResize.UseVisualStyleBackColor = false;
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // btnTask
            // 
            this.btnTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTask.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTask.BackColor = System.Drawing.Color.Silver;
            this.btnTask.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTask.BackgroundImage")));
            this.btnTask.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTask.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTask.ForeColor = System.Drawing.Color.Transparent;
            this.btnTask.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnTask.IconColor = System.Drawing.Color.Transparent;
            this.btnTask.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTask.Location = new System.Drawing.Point(950, 15);
            this.btnTask.Name = "btnTask";
            this.btnTask.Size = new System.Drawing.Size(50, 30);
            this.btnTask.TabIndex = 3;
            this.btnTask.UseVisualStyleBackColor = false;
            this.btnTask.Click += new System.EventHandler(this.btnTask_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.BackColor = System.Drawing.Color.IndianRed;
            this.btnClose.BackgroundImage = global::Translao.Properties.Resources.exit;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.ForeColor = System.Drawing.Color.Transparent;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnClose.IconColor = System.Drawing.Color.Transparent;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClose.Location = new System.Drawing.Point(1050, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(50, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbOut
            // 
            this.cmbOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbOut.FormattingEnabled = true;
            this.cmbOut.ItemHeight = 24;
            this.cmbOut.Location = new System.Drawing.Point(570, 412);
            this.cmbOut.Name = "cmbOut";
            this.cmbOut.Size = new System.Drawing.Size(173, 30);
            this.cmbOut.TabIndex = 10;
            // 
            // btnENOut
            // 
            this.btnENOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnENOut.Location = new System.Drawing.Point(995, 412);
            this.btnENOut.Name = "btnENOut";
            this.btnENOut.Size = new System.Drawing.Size(76, 35);
            this.btnENOut.TabIndex = 7;
            this.btnENOut.Text = "English";
            this.btnENOut.Click += new System.EventHandler(this.btnENOut_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(990, 521);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 35);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(904, 521);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(80, 35);
            this.btnOpen.TabIndex = 12;
            this.btnOpen.Text = "Open";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnENIn
            // 
            this.btnENIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnENIn.Location = new System.Drawing.Point(15, 412);
            this.btnENIn.Name = "btnENIn";
            this.btnENIn.Size = new System.Drawing.Size(76, 35);
            this.btnENIn.TabIndex = 3;
            this.btnENIn.Text = "English";
            this.btnENIn.Click += new System.EventHandler(this.btnENIn_Click);
            // 
            // btnROIn
            // 
            this.btnROIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnROIn.Location = new System.Drawing.Point(97, 412);
            this.btnROIn.Name = "btnROIn";
            this.btnROIn.Size = new System.Drawing.Size(76, 35);
            this.btnROIn.TabIndex = 4;
            this.btnROIn.Text = "Romanian";
            this.btnROIn.Click += new System.EventHandler(this.btnROIn_Click);
            // 
            // btnSPIn
            // 
            this.btnSPIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSPIn.Location = new System.Drawing.Point(179, 412);
            this.btnSPIn.Name = "btnSPIn";
            this.btnSPIn.Size = new System.Drawing.Size(76, 35);
            this.btnSPIn.TabIndex = 5;
            this.btnSPIn.Text = "Spanish";
            this.btnSPIn.Click += new System.EventHandler(this.btnSPIn_Click);
            // 
            // cmbIn
            // 
            this.cmbIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbIn.FormattingEnabled = true;
            this.cmbIn.ItemHeight = 24;
            this.cmbIn.Location = new System.Drawing.Point(343, 412);
            this.cmbIn.Name = "cmbIn";
            this.cmbIn.Size = new System.Drawing.Size(172, 30);
            this.cmbIn.TabIndex = 6;
            // 
            // tbIn
            // 
            this.tbIn.AllowDrop = true;
            this.tbIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbIn.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.tbIn.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.tbIn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbIn.Location = new System.Drawing.Point(15, 56);
            this.tbIn.Multiline = true;
            this.tbIn.Name = "tbIn";
            this.tbIn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbIn.Size = new System.Drawing.Size(500, 350);
            this.tbIn.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbIn.TabIndex = 1;
            this.tbIn.UseStyleColors = true;
            // 
            // tbOut
            // 
            this.tbOut.AllowDrop = true;
            this.tbOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOut.CustomBackground = true;
            this.tbOut.CustomForeColor = true;
            this.tbOut.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.tbOut.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.tbOut.Location = new System.Drawing.Point(570, 56);
            this.tbOut.Multiline = true;
            this.tbOut.Name = "tbOut";
            this.tbOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOut.Size = new System.Drawing.Size(500, 350);
            this.tbOut.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbOut.TabIndex = 13;
            this.tbOut.UseStyleColors = true;
            // 
            // labelIn
            // 
            this.labelIn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelIn.AutoSize = true;
            this.labelIn.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.labelIn.Location = new System.Drawing.Point(15, 30);
            this.labelIn.Name = "labelIn";
            this.labelIn.Size = new System.Drawing.Size(54, 20);
            this.labelIn.TabIndex = 15;
            this.labelIn.Text = "labelIn";
            this.labelIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelOut
            // 
            this.labelOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelOut.AutoSize = true;
            this.labelOut.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.labelOut.Location = new System.Drawing.Point(570, 30);
            this.labelOut.Name = "labelOut";
            this.labelOut.Size = new System.Drawing.Size(66, 20);
            this.labelOut.TabIndex = 16;
            this.labelOut.Text = "labelOut";
            this.labelOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSwitch
            // 
            this.btnSwitch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSwitch.BackColor = System.Drawing.Color.Silver;
            this.btnSwitch.BackgroundImage = global::Translao.Properties.Resources.swich;
            this.btnSwitch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSwitch.ForeColor = System.Drawing.Color.Transparent;
            this.btnSwitch.IconChar = FontAwesome.Sharp.IconChar.Nimblr;
            this.btnSwitch.IconColor = System.Drawing.Color.Transparent;
            this.btnSwitch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSwitch.Location = new System.Drawing.Point(519, 412);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(45, 35);
            this.btnSwitch.TabIndex = 4;
            this.btnSwitch.UseVisualStyleBackColor = false;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // btnFRIn
            // 
            this.btnFRIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFRIn.Location = new System.Drawing.Point(261, 412);
            this.btnFRIn.Name = "btnFRIn";
            this.btnFRIn.Size = new System.Drawing.Size(76, 35);
            this.btnFRIn.TabIndex = 17;
            this.btnFRIn.Text = "French";
            this.btnFRIn.Click += new System.EventHandler(this.btnFRIn_Click);
            // 
            // btnROOut
            // 
            this.btnROOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnROOut.Location = new System.Drawing.Point(913, 412);
            this.btnROOut.Name = "btnROOut";
            this.btnROOut.Size = new System.Drawing.Size(76, 35);
            this.btnROOut.TabIndex = 8;
            this.btnROOut.Text = "Romanian";
            this.btnROOut.Click += new System.EventHandler(this.btnROOut_Click);
            // 
            // btnSPOut
            // 
            this.btnSPOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSPOut.Location = new System.Drawing.Point(831, 412);
            this.btnSPOut.Name = "btnSPOut";
            this.btnSPOut.Size = new System.Drawing.Size(76, 35);
            this.btnSPOut.TabIndex = 9;
            this.btnSPOut.Text = "Spanish";
            this.btnSPOut.Click += new System.EventHandler(this.btnSPOut_Click);
            // 
            // btnFROut
            // 
            this.btnFROut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFROut.Location = new System.Drawing.Point(749, 412);
            this.btnFROut.Name = "btnFROut";
            this.btnFROut.Size = new System.Drawing.Size(76, 35);
            this.btnFROut.TabIndex = 18;
            this.btnFROut.Text = "French";
            this.btnFROut.Click += new System.EventHandler(this.btnFROut_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 553);
            this.Controls.Add(this.btnFROut);
            this.Controls.Add(this.btnFRIn);
            this.Controls.Add(this.btnSwitch);
            this.Controls.Add(this.labelOut);
            this.Controls.Add(this.labelIn);
            this.Controls.Add(this.tbOut);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbOut);
            this.Controls.Add(this.btnSPOut);
            this.Controls.Add(this.btnROOut);
            this.Controls.Add(this.btnENOut);
            this.Controls.Add(this.cmbIn);
            this.Controls.Add(this.btnSPIn);
            this.Controls.Add(this.btnROIn);
            this.Controls.Add(this.btnENIn);
            this.Controls.Add(this.tbIn);
            this.Controls.Add(this.titlePanel);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.titlePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel titlePanel;
        private FontAwesome.Sharp.IconButton btnClose;
        private FontAwesome.Sharp.IconButton btnTask;
        private MetroFramework.Controls.MetroComboBox cmbOut;
        private MetroFramework.Controls.MetroButton btnENOut;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroButton btnOpen;
        private MetroFramework.Controls.MetroButton btnROIn;
        private MetroFramework.Controls.MetroButton btnSPIn;
        private MetroFramework.Controls.MetroComboBox cmbIn;
        private MetroFramework.Controls.MetroButton btnENIn;
        private MetroFramework.Controls.MetroTextBox tbIn;
        private MetroFramework.Controls.MetroTextBox tbOut;
        private MetroFramework.Controls.MetroLabel labelIn;
        private MetroFramework.Controls.MetroLabel labelOut;
        private FontAwesome.Sharp.IconButton btnSwitch;
        private FontAwesome.Sharp.IconButton btnResize;
        private MetroFramework.Controls.MetroButton btnFRIn;
        private MetroFramework.Controls.MetroButton btnROOut;
        private MetroFramework.Controls.MetroButton btnSPOut;
        private MetroFramework.Controls.MetroButton btnFROut;
    }
}