namespace Translao
{
    partial class appearanceForm
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
            this.cmbColorOne = new MetroFramework.Controls.MetroComboBox();
            this.cmbColorTwo = new MetroFramework.Controls.MetroComboBox();
            this.btnApply = new MetroFramework.Controls.MetroButton();
            this.cmbGradientType = new MetroFramework.Controls.MetroComboBox();
            this.rbMale = new MetroFramework.Controls.MetroRadioButton();
            this.rbFemale = new MetroFramework.Controls.MetroRadioButton();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.tbMaxShapes = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.titlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbColorOne
            // 
            this.cmbColorOne.FormattingEnabled = true;
            this.cmbColorOne.ItemHeight = 24;
            this.cmbColorOne.Location = new System.Drawing.Point(12, 87);
            this.cmbColorOne.Name = "cmbColorOne";
            this.cmbColorOne.Size = new System.Drawing.Size(150, 30);
            this.cmbColorOne.Style = MetroFramework.MetroColorStyle.Black;
            this.cmbColorOne.TabIndex = 0;
            this.cmbColorOne.SelectedIndexChanged += new System.EventHandler(this.cmbColorOne_SelectedIndexChanged);
            // 
            // cmbColorTwo
            // 
            this.cmbColorTwo.FormattingEnabled = true;
            this.cmbColorTwo.ItemHeight = 24;
            this.cmbColorTwo.Location = new System.Drawing.Point(168, 87);
            this.cmbColorTwo.Name = "cmbColorTwo";
            this.cmbColorTwo.Size = new System.Drawing.Size(150, 30);
            this.cmbColorTwo.Style = MetroFramework.MetroColorStyle.Black;
            this.cmbColorTwo.TabIndex = 1;
            this.cmbColorTwo.SelectedIndexChanged += new System.EventHandler(this.cmbColorTwo_SelectedIndexChanged);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(510, 160);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(84, 38);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Apply";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // cmbGradientType
            // 
            this.cmbGradientType.FormattingEnabled = true;
            this.cmbGradientType.ItemHeight = 24;
            this.cmbGradientType.Location = new System.Drawing.Point(324, 87);
            this.cmbGradientType.Name = "cmbGradientType";
            this.cmbGradientType.Size = new System.Drawing.Size(150, 30);
            this.cmbGradientType.Style = MetroFramework.MetroColorStyle.Black;
            this.cmbGradientType.TabIndex = 3;
            this.cmbGradientType.SelectedIndexChanged += new System.EventHandler(this.cmbGradientType_SelectedIndexChanged);
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.rbMale.ForeColor = System.Drawing.Color.Transparent;
            this.rbMale.Location = new System.Drawing.Point(162, 131);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(66, 25);
            this.rbMale.TabIndex = 4;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            this.rbMale.CheckedChanged += new System.EventHandler(this.rbMale_CheckedChanged);
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.BackColor = System.Drawing.Color.White;
            this.rbFemale.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rbFemale.CustomBackground = true;
            this.rbFemale.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.rbFemale.ForeColor = System.Drawing.Color.Transparent;
            this.rbFemale.Location = new System.Drawing.Point(243, 131);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(84, 25);
            this.rbFemale.TabIndex = 5;
            this.rbFemale.TabStop = true;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = false;
            this.rbFemale.CheckedChanged += new System.EventHandler(this.rbFemale_CheckedChanged);
            // 
            // titlePanel
            // 
            this.titlePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titlePanel.BackColor = System.Drawing.Color.Transparent;
            this.titlePanel.Controls.Add(this.btnClose);
            this.titlePanel.ForeColor = System.Drawing.Color.Transparent;
            this.titlePanel.Location = new System.Drawing.Point(-148, 7);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(742, 42);
            this.titlePanel.TabIndex = 6;
            this.titlePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlePanel_MouseDown);
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
            this.btnClose.Location = new System.Drawing.Point(689, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(50, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(12, 52);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(93, 25);
            this.metroLabel1.TabIndex = 7;
            this.metroLabel1.Text = "Color One";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(168, 52);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(92, 25);
            this.metroLabel2.TabIndex = 8;
            this.metroLabel2.Text = "Color Two";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(324, 52);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(84, 25);
            this.metroLabel3.TabIndex = 9;
            this.metroLabel3.Text = "Gradient ";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(12, 131);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(116, 25);
            this.metroLabel4.TabIndex = 10;
            this.metroLabel4.Text = "Voice Gender";
            this.metroLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbMaxShapes
            // 
            this.tbMaxShapes.Location = new System.Drawing.Point(480, 87);
            this.tbMaxShapes.Multiline = true;
            this.tbMaxShapes.Name = "tbMaxShapes";
            this.tbMaxShapes.PromptText = "Max 100";
            this.tbMaxShapes.Size = new System.Drawing.Size(100, 35);
            this.tbMaxShapes.TabIndex = 11;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(480, 52);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(69, 25);
            this.metroLabel5.TabIndex = 12;
            this.metroLabel5.Text = "Shapes";
            // 
            // appearanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 173);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.tbMaxShapes);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.titlePanel);
            this.Controls.Add(this.rbFemale);
            this.Controls.Add(this.rbMale);
            this.Controls.Add(this.cmbGradientType);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.cmbColorTwo);
            this.Controls.Add(this.cmbColorOne);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "appearanceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "appearanceForm";
            this.titlePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox cmbColorOne;
        private MetroFramework.Controls.MetroComboBox cmbColorTwo;
        private MetroFramework.Controls.MetroButton btnApply;
        private MetroFramework.Controls.MetroComboBox cmbGradientType;
        private MetroFramework.Controls.MetroRadioButton rbMale;
        private MetroFramework.Controls.MetroRadioButton rbFemale;
        private System.Windows.Forms.Panel titlePanel;
        private FontAwesome.Sharp.IconButton btnClose;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox tbMaxShapes;
        private MetroFramework.Controls.MetroLabel metroLabel5;
    }
}