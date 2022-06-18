namespace TrainProjectWorkApp
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.formPanel = new System.Windows.Forms.Panel();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.creditLabel = new System.Windows.Forms.Label();
            this.fillPanel = new System.Windows.Forms.Panel();
            this.loginButton = new ReaLTaiizor.Controls.ParrotButton();
            this.passwordPanel = new System.Windows.Forms.Panel();
            this.passwordCenterPanel = new System.Windows.Forms.Panel();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.seepasswordCheckBox = new System.Windows.Forms.CheckBox();
            this.passwordTextBox = new ReaLTaiizor.Controls.SmallTextBox();
            this.userPanel = new System.Windows.Forms.Panel();
            this.userCenterPanel = new System.Windows.Forms.Panel();
            this.userTextBox = new ReaLTaiizor.Controls.SmallTextBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.userPictureBox = new System.Windows.Forms.PictureBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.resizeButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.logoHeaderPanel = new System.Windows.Forms.Panel();
            this.appPictureBox = new System.Windows.Forms.PictureBox();
            this.headerTitleLabel = new System.Windows.Forms.Label();
            this.checkConnectionLabel = new System.Windows.Forms.Label();
            this.checkConnectionPictureBox = new System.Windows.Forms.PictureBox();
            this.formPanel.SuspendLayout();
            this.footerPanel.SuspendLayout();
            this.fillPanel.SuspendLayout();
            this.passwordPanel.SuspendLayout();
            this.passwordCenterPanel.SuspendLayout();
            this.userPanel.SuspendLayout();
            this.userCenterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPictureBox)).BeginInit();
            this.headerPanel.SuspendLayout();
            this.logoHeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkConnectionPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // formPanel
            // 
            this.formPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.formPanel.Controls.Add(this.footerPanel);
            this.formPanel.Controls.Add(this.fillPanel);
            this.formPanel.Controls.Add(this.headerPanel);
            this.formPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formPanel.Location = new System.Drawing.Point(2, 2);
            this.formPanel.Name = "formPanel";
            this.formPanel.Size = new System.Drawing.Size(1076, 696);
            this.formPanel.TabIndex = 0;
            // 
            // footerPanel
            // 
            this.footerPanel.Controls.Add(this.checkConnectionPictureBox);
            this.footerPanel.Controls.Add(this.checkConnectionLabel);
            this.footerPanel.Controls.Add(this.creditLabel);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 626);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(1076, 70);
            this.footerPanel.TabIndex = 2;
            // 
            // creditLabel
            // 
            this.creditLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.creditLabel.ForeColor = System.Drawing.Color.Silver;
            this.creditLabel.Location = new System.Drawing.Point(0, 0);
            this.creditLabel.Name = "creditLabel";
            this.creditLabel.Size = new System.Drawing.Size(1076, 70);
            this.creditLabel.TabIndex = 0;
            this.creditLabel.Text = "Created by Jellow Jellyfish Team";
            this.creditLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fillPanel
            // 
            this.fillPanel.Controls.Add(this.loginButton);
            this.fillPanel.Controls.Add(this.passwordPanel);
            this.fillPanel.Controls.Add(this.userPanel);
            this.fillPanel.Controls.Add(this.userPictureBox);
            this.fillPanel.Controls.Add(this.loginLabel);
            this.fillPanel.Controls.Add(this.titleLabel);
            this.fillPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fillPanel.Location = new System.Drawing.Point(0, 70);
            this.fillPanel.Name = "fillPanel";
            this.fillPanel.Size = new System.Drawing.Size(1076, 626);
            this.fillPanel.TabIndex = 1;
            // 
            // loginButton
            // 
            this.loginButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loginButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(70)))), ((int)(((byte)(75)))));
            this.loginButton.ButtonImage = ((System.Drawing.Image)(resources.GetObject("loginButton.ButtonImage")));
            this.loginButton.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.Dark;
            this.loginButton.ButtonText = "Login";
            this.loginButton.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(75)))), ((int)(((byte)(80)))));
            this.loginButton.ClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.loginButton.CornerRadius = 5;
            this.loginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginButton.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.loginButton.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.loginButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.loginButton.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            this.loginButton.Location = new System.Drawing.Point(497, 404);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(101, 51);
            this.loginButton.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.loginButton.TabIndex = 11;
            this.loginButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(200)))), ((int)(((byte)(185)))));
            this.loginButton.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.loginButton.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // passwordPanel
            // 
            this.passwordPanel.Controls.Add(this.passwordCenterPanel);
            this.passwordPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.passwordPanel.Location = new System.Drawing.Point(0, 312);
            this.passwordPanel.Name = "passwordPanel";
            this.passwordPanel.Size = new System.Drawing.Size(1076, 71);
            this.passwordPanel.TabIndex = 10;
            // 
            // passwordCenterPanel
            // 
            this.passwordCenterPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.passwordCenterPanel.Controls.Add(this.passwordLabel);
            this.passwordCenterPanel.Controls.Add(this.seepasswordCheckBox);
            this.passwordCenterPanel.Controls.Add(this.passwordTextBox);
            this.passwordCenterPanel.Location = new System.Drawing.Point(364, 6);
            this.passwordCenterPanel.Name = "passwordCenterPanel";
            this.passwordCenterPanel.Size = new System.Drawing.Size(396, 49);
            this.passwordCenterPanel.TabIndex = 10;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.passwordLabel.Location = new System.Drawing.Point(3, 11);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(84, 23);
            this.passwordLabel.TabIndex = 9;
            this.passwordLabel.Text = "Password:";
            // 
            // seepasswordCheckBox
            // 
            this.seepasswordCheckBox.AutoSize = true;
            this.seepasswordCheckBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.seepasswordCheckBox.ForeColor = System.Drawing.Color.DarkGray;
            this.seepasswordCheckBox.Location = new System.Drawing.Point(262, 11);
            this.seepasswordCheckBox.Name = "seepasswordCheckBox";
            this.seepasswordCheckBox.Size = new System.Drawing.Size(134, 27);
            this.seepasswordCheckBox.TabIndex = 8;
            this.seepasswordCheckBox.Text = "See Password";
            this.seepasswordCheckBox.UseVisualStyleBackColor = true;
            this.seepasswordCheckBox.CheckedChanged += new System.EventHandler(this.seepasswordCheckBox_CheckedChanged);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BackColor = System.Drawing.Color.Transparent;
            this.passwordTextBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.passwordTextBox.CustomBGColor = System.Drawing.Color.White;
            this.passwordTextBox.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.passwordTextBox.Location = new System.Drawing.Point(106, 5);
            this.passwordTextBox.MaxLength = 32767;
            this.passwordTextBox.Multiline = false;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.ReadOnly = false;
            this.passwordTextBox.Size = new System.Drawing.Size(138, 33);
            this.passwordTextBox.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.passwordTextBox.TabIndex = 7;
            this.passwordTextBox.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.passwordTextBox.UseSystemPasswordChar = true;
            this.passwordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordTextBox_KeyDown);
            // 
            // userPanel
            // 
            this.userPanel.Controls.Add(this.userCenterPanel);
            this.userPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.userPanel.Location = new System.Drawing.Point(0, 233);
            this.userPanel.Name = "userPanel";
            this.userPanel.Size = new System.Drawing.Size(1076, 79);
            this.userPanel.TabIndex = 9;
            // 
            // userCenterPanel
            // 
            this.userCenterPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.userCenterPanel.Controls.Add(this.userTextBox);
            this.userCenterPanel.Controls.Add(this.userLabel);
            this.userCenterPanel.Location = new System.Drawing.Point(383, 13);
            this.userCenterPanel.Name = "userCenterPanel";
            this.userCenterPanel.Size = new System.Drawing.Size(250, 63);
            this.userCenterPanel.TabIndex = 8;
            // 
            // userTextBox
            // 
            this.userTextBox.BackColor = System.Drawing.Color.Transparent;
            this.userTextBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.userTextBox.CustomBGColor = System.Drawing.Color.White;
            this.userTextBox.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.userTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.userTextBox.Location = new System.Drawing.Point(87, 17);
            this.userTextBox.MaxLength = 32767;
            this.userTextBox.Multiline = false;
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.ReadOnly = false;
            this.userTextBox.Size = new System.Drawing.Size(138, 33);
            this.userTextBox.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.userTextBox.TabIndex = 6;
            this.userTextBox.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.userTextBox.UseSystemPasswordChar = false;
            this.userTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userTextBox_KeyDown);
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.userLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.userLabel.Location = new System.Drawing.Point(19, 21);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(48, 23);
            this.userLabel.TabIndex = 7;
            this.userLabel.Text = "User:";
            // 
            // userPictureBox
            // 
            this.userPictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.userPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("userPictureBox.Image")));
            this.userPictureBox.Location = new System.Drawing.Point(0, 119);
            this.userPictureBox.Name = "userPictureBox";
            this.userPictureBox.Size = new System.Drawing.Size(1076, 114);
            this.userPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userPictureBox.TabIndex = 4;
            this.userPictureBox.TabStop = false;
            // 
            // loginLabel
            // 
            this.loginLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.loginLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loginLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.loginLabel.Location = new System.Drawing.Point(0, 54);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(1076, 65);
            this.loginLabel.TabIndex = 3;
            this.loginLabel.Text = "Login";
            this.loginLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(1076, 54);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "Project Work Train\'s App";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.minimizeButton);
            this.headerPanel.Controls.Add(this.resizeButton);
            this.headerPanel.Controls.Add(this.closeButton);
            this.headerPanel.Controls.Add(this.logoHeaderPanel);
            this.headerPanel.Controls.Add(this.headerTitleLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1076, 70);
            this.headerPanel.TabIndex = 0;
            // 
            // minimizeButton
            // 
            this.minimizeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.minimizeButton.ForeColor = System.Drawing.Color.Silver;
            this.minimizeButton.Location = new System.Drawing.Point(845, 0);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(77, 70);
            this.minimizeButton.TabIndex = 14;
            this.minimizeButton.Text = "–";
            this.minimizeButton.UseVisualStyleBackColor = true;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // resizeButton
            // 
            this.resizeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.resizeButton.FlatAppearance.BorderSize = 0;
            this.resizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resizeButton.Font = new System.Drawing.Font("Segoe UI", 16.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.resizeButton.ForeColor = System.Drawing.Color.Silver;
            this.resizeButton.Location = new System.Drawing.Point(922, 0);
            this.resizeButton.Name = "resizeButton";
            this.resizeButton.Size = new System.Drawing.Size(77, 70);
            this.resizeButton.TabIndex = 13;
            this.resizeButton.Text = "◻";
            this.resizeButton.UseVisualStyleBackColor = true;
            this.resizeButton.Click += new System.EventHandler(this.resizeButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.closeButton.ForeColor = System.Drawing.Color.Silver;
            this.closeButton.Location = new System.Drawing.Point(999, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(77, 70);
            this.closeButton.TabIndex = 12;
            this.closeButton.Text = "❌";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // logoHeaderPanel
            // 
            this.logoHeaderPanel.Controls.Add(this.appPictureBox);
            this.logoHeaderPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.logoHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.logoHeaderPanel.Name = "logoHeaderPanel";
            this.logoHeaderPanel.Size = new System.Drawing.Size(77, 70);
            this.logoHeaderPanel.TabIndex = 4;
            // 
            // appPictureBox
            // 
            this.appPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("appPictureBox.Image")));
            this.appPictureBox.Location = new System.Drawing.Point(-4, 8);
            this.appPictureBox.Name = "appPictureBox";
            this.appPictureBox.Size = new System.Drawing.Size(81, 56);
            this.appPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.appPictureBox.TabIndex = 0;
            this.appPictureBox.TabStop = false;
            // 
            // headerTitleLabel
            // 
            this.headerTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerTitleLabel.ForeColor = System.Drawing.Color.Silver;
            this.headerTitleLabel.Location = new System.Drawing.Point(0, 0);
            this.headerTitleLabel.Name = "headerTitleLabel";
            this.headerTitleLabel.Size = new System.Drawing.Size(1076, 70);
            this.headerTitleLabel.TabIndex = 1;
            this.headerTitleLabel.Text = "Project Work Train\'s App";
            this.headerTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.headerTitleLabel.DoubleClick += new System.EventHandler(this.resizeButton_Click);
            this.headerTitleLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headerTitleLabel_MouseMove);
            // 
            // checkConnectionLabel
            // 
            this.checkConnectionLabel.AutoSize = true;
            this.checkConnectionLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkConnectionLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.checkConnectionLabel.Location = new System.Drawing.Point(25, 23);
            this.checkConnectionLabel.Name = "checkConnectionLabel";
            this.checkConnectionLabel.Size = new System.Drawing.Size(107, 23);
            this.checkConnectionLabel.TabIndex = 29;
            this.checkConnectionLabel.Text = "Connection :";
            // 
            // checkConnectionPictureBox
            // 
            this.checkConnectionPictureBox.Image = global::TrainProjectWorkApp.Properties.Resources._true;
            this.checkConnectionPictureBox.Location = new System.Drawing.Point(138, 12);
            this.checkConnectionPictureBox.Name = "checkConnectionPictureBox";
            this.checkConnectionPictureBox.Size = new System.Drawing.Size(46, 48);
            this.checkConnectionPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.checkConnectionPictureBox.TabIndex = 30;
            this.checkConnectionPictureBox.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 700);
            this.Controls.Add(this.formPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.formPanel.ResumeLayout(false);
            this.footerPanel.ResumeLayout(false);
            this.footerPanel.PerformLayout();
            this.fillPanel.ResumeLayout(false);
            this.passwordPanel.ResumeLayout(false);
            this.passwordCenterPanel.ResumeLayout(false);
            this.passwordCenterPanel.PerformLayout();
            this.userPanel.ResumeLayout(false);
            this.userCenterPanel.ResumeLayout(false);
            this.userCenterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPictureBox)).EndInit();
            this.headerPanel.ResumeLayout(false);
            this.logoHeaderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.appPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkConnectionPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Label creditLabel;
        private System.Windows.Forms.Panel fillPanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label headerTitleLabel;
        private System.Windows.Forms.Panel logoHeaderPanel;
        private System.Windows.Forms.PictureBox userPictureBox;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.PictureBox appPictureBox;
        private ReaLTaiizor.Controls.SmallTextBox passwordTextBox;
        private ReaLTaiizor.Controls.SmallTextBox userTextBox;
        private System.Windows.Forms.Panel passwordPanel;
        private System.Windows.Forms.CheckBox seepasswordCheckBox;
        private System.Windows.Forms.Panel userPanel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label userLabel;
        private ReaLTaiizor.Controls.ParrotButton loginButton;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Button resizeButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Panel userCenterPanel;
        private System.Windows.Forms.Panel passwordCenterPanel;
        private System.Windows.Forms.Label checkConnectionLabel;
        private System.Windows.Forms.PictureBox checkConnectionPictureBox;
    }
}
