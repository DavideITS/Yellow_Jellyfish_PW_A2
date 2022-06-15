namespace TrainProjectWorkApp
{
    partial class SeeWagonForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeeWagonForm));
            this.formPanel = new System.Windows.Forms.Panel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.fillPanel = new System.Windows.Forms.Panel();
            this.headerTitleLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.resizeButton = new System.Windows.Forms.Button();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.logoHeaderPanel = new System.Windows.Forms.Panel();
            this.appPictureBox = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.wagonLabel = new System.Windows.Forms.Label();
            this.wagonDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewPanel = new System.Windows.Forms.Panel();
            this.formPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.fillPanel.SuspendLayout();
            this.logoHeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wagonDataGridView)).BeginInit();
            this.dataGridViewPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // formPanel
            // 
            this.formPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.formPanel.Controls.Add(this.fillPanel);
            this.formPanel.Controls.Add(this.footerPanel);
            this.formPanel.Controls.Add(this.headerPanel);
            this.formPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formPanel.Location = new System.Drawing.Point(2, 2);
            this.formPanel.Name = "formPanel";
            this.formPanel.Size = new System.Drawing.Size(1076, 696);
            this.formPanel.TabIndex = 0;
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.logoHeaderPanel);
            this.headerPanel.Controls.Add(this.minimizeButton);
            this.headerPanel.Controls.Add(this.resizeButton);
            this.headerPanel.Controls.Add(this.closeButton);
            this.headerPanel.Controls.Add(this.headerTitleLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1076, 70);
            this.headerPanel.TabIndex = 1;
            // 
            // footerPanel
            // 
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 626);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(1076, 70);
            this.footerPanel.TabIndex = 2;
            // 
            // fillPanel
            // 
            this.fillPanel.Controls.Add(this.dataGridViewPanel);
            this.fillPanel.Controls.Add(this.wagonLabel);
            this.fillPanel.Controls.Add(this.titleLabel);
            this.fillPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fillPanel.Location = new System.Drawing.Point(0, 70);
            this.fillPanel.Name = "fillPanel";
            this.fillPanel.Size = new System.Drawing.Size(1076, 556);
            this.fillPanel.TabIndex = 3;
            // 
            // headerTitleLabel
            // 
            this.headerTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerTitleLabel.ForeColor = System.Drawing.Color.Silver;
            this.headerTitleLabel.Location = new System.Drawing.Point(0, 0);
            this.headerTitleLabel.Name = "headerTitleLabel";
            this.headerTitleLabel.Size = new System.Drawing.Size(1076, 70);
            this.headerTitleLabel.TabIndex = 3;
            this.headerTitleLabel.Text = "Project Work Train\'s App";
            this.headerTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.closeButton.TabIndex = 15;
            this.closeButton.Text = "❌";
            this.closeButton.UseVisualStyleBackColor = true;
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
            this.resizeButton.TabIndex = 16;
            this.resizeButton.Text = "◻";
            this.resizeButton.UseVisualStyleBackColor = true;
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
            this.minimizeButton.TabIndex = 17;
            this.minimizeButton.Text = "–";
            this.minimizeButton.UseVisualStyleBackColor = true;
            // 
            // logoHeaderPanel
            // 
            this.logoHeaderPanel.Controls.Add(this.appPictureBox);
            this.logoHeaderPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.logoHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.logoHeaderPanel.Name = "logoHeaderPanel";
            this.logoHeaderPanel.Size = new System.Drawing.Size(77, 70);
            this.logoHeaderPanel.TabIndex = 18;
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
            // titleLabel
            // 
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(1076, 54);
            this.titleLabel.TabIndex = 5;
            this.titleLabel.Text = "Project Work Train\'s App";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wagonLabel
            // 
            this.wagonLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.wagonLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.wagonLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.wagonLabel.Location = new System.Drawing.Point(0, 54);
            this.wagonLabel.Name = "wagonLabel";
            this.wagonLabel.Size = new System.Drawing.Size(1076, 65);
            this.wagonLabel.TabIndex = 6;
            this.wagonLabel.Text = "Wagon";
            this.wagonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wagonDataGridView
            // 
            this.wagonDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.wagonDataGridView.Location = new System.Drawing.Point(428, 65);
            this.wagonDataGridView.Name = "wagonDataGridView";
            this.wagonDataGridView.RowHeadersWidth = 51;
            this.wagonDataGridView.RowTemplate.Height = 29;
            this.wagonDataGridView.Size = new System.Drawing.Size(325, 310);
            this.wagonDataGridView.TabIndex = 7;
            // 
            // dataGridViewPanel
            // 
            this.dataGridViewPanel.Controls.Add(this.wagonDataGridView);
            this.dataGridViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPanel.Location = new System.Drawing.Point(0, 119);
            this.dataGridViewPanel.Name = "dataGridViewPanel";
            this.dataGridViewPanel.Size = new System.Drawing.Size(1076, 437);
            this.dataGridViewPanel.TabIndex = 8;
            // 
            // SeeWagonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 700);
            this.Controls.Add(this.formPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SeeWagonForm";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SeeWagonForm";
            this.formPanel.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.fillPanel.ResumeLayout(false);
            this.logoHeaderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.appPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wagonDataGridView)).EndInit();
            this.dataGridViewPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel fillPanel;
        private System.Windows.Forms.Label headerTitleLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button resizeButton;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Panel logoHeaderPanel;
        private System.Windows.Forms.PictureBox appPictureBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label wagonLabel;
        private System.Windows.Forms.DataGridView wagonDataGridView;
        private System.Windows.Forms.Panel dataGridViewPanel;
    }
}