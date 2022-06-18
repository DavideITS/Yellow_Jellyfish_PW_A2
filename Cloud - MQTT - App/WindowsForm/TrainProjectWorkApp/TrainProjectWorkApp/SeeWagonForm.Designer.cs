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
            this.fillPanel = new System.Windows.Forms.Panel();
            this.dataUpadatePanel = new System.Windows.Forms.Panel();
            this.dateLabel = new System.Windows.Forms.Label();
            this.LastDataReceivedLabel = new System.Windows.Forms.Label();
            this.wagonDataGridViewPanel = new System.Windows.Forms.Panel();
            this.wagonDataGridView = new System.Windows.Forms.DataGridView();
            this.nrWagonColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TemperatureColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HumidityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SmokeColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.ToiletteColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.Port1Column = new System.Windows.Forms.DataGridViewImageColumn();
            this.Port2Column = new System.Windows.Forms.DataGridViewImageColumn();
            this.Port3Column = new System.Windows.Forms.DataGridViewImageColumn();
            this.Port4Column = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wagonLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.checkConnectionPictureBox = new System.Windows.Forms.PictureBox();
            this.checkConnectionLabel = new System.Windows.Forms.Label();
            this.creditLabel = new System.Windows.Forms.Label();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.logoHeaderPanel = new System.Windows.Forms.Panel();
            this.appPictureBox = new System.Windows.Forms.PictureBox();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.resizeButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.headerTitleLabel = new System.Windows.Forms.Label();
            this.formPanel.SuspendLayout();
            this.fillPanel.SuspendLayout();
            this.dataUpadatePanel.SuspendLayout();
            this.wagonDataGridViewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wagonDataGridView)).BeginInit();
            this.footerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkConnectionPictureBox)).BeginInit();
            this.headerPanel.SuspendLayout();
            this.logoHeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appPictureBox)).BeginInit();
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
            this.formPanel.Size = new System.Drawing.Size(1196, 696);
            this.formPanel.TabIndex = 0;
            // 
            // fillPanel
            // 
            this.fillPanel.Controls.Add(this.dataUpadatePanel);
            this.fillPanel.Controls.Add(this.wagonDataGridViewPanel);
            this.fillPanel.Controls.Add(this.wagonLabel);
            this.fillPanel.Controls.Add(this.titleLabel);
            this.fillPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fillPanel.Location = new System.Drawing.Point(0, 70);
            this.fillPanel.Name = "fillPanel";
            this.fillPanel.Size = new System.Drawing.Size(1196, 556);
            this.fillPanel.TabIndex = 3;
            // 
            // dataUpadatePanel
            // 
            this.dataUpadatePanel.Controls.Add(this.dateLabel);
            this.dataUpadatePanel.Controls.Add(this.LastDataReceivedLabel);
            this.dataUpadatePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataUpadatePanel.Location = new System.Drawing.Point(0, 503);
            this.dataUpadatePanel.Name = "dataUpadatePanel";
            this.dataUpadatePanel.Size = new System.Drawing.Size(1196, 53);
            this.dataUpadatePanel.TabIndex = 9;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.dateLabel.Location = new System.Drawing.Point(178, 16);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(112, 23);
            this.dateLabel.TabIndex = 32;
            this.dateLabel.Text = "Not Available";
            // 
            // LastDataReceivedLabel
            // 
            this.LastDataReceivedLabel.AutoSize = true;
            this.LastDataReceivedLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LastDataReceivedLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.LastDataReceivedLabel.Location = new System.Drawing.Point(19, 16);
            this.LastDataReceivedLabel.Name = "LastDataReceivedLabel";
            this.LastDataReceivedLabel.Size = new System.Drawing.Size(162, 23);
            this.LastDataReceivedLabel.TabIndex = 31;
            this.LastDataReceivedLabel.Text = "Last Received Data :";
            // 
            // wagonDataGridViewPanel
            // 
            this.wagonDataGridViewPanel.Controls.Add(this.wagonDataGridView);
            this.wagonDataGridViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wagonDataGridViewPanel.Location = new System.Drawing.Point(0, 119);
            this.wagonDataGridViewPanel.Name = "wagonDataGridViewPanel";
            this.wagonDataGridViewPanel.Size = new System.Drawing.Size(1196, 437);
            this.wagonDataGridViewPanel.TabIndex = 8;
            // 
            // wagonDataGridView
            // 
            this.wagonDataGridView.AllowUserToDeleteRows = false;
            this.wagonDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.wagonDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.wagonDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nrWagonColumn,
            this.TemperatureColumn,
            this.HumidityColumn,
            this.SmokeColumn,
            this.ToiletteColumn,
            this.Port1Column,
            this.Port2Column,
            this.Port3Column,
            this.Port4Column,
            this.dataColumn});
            this.wagonDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wagonDataGridView.Location = new System.Drawing.Point(0, 0);
            this.wagonDataGridView.Name = "wagonDataGridView";
            this.wagonDataGridView.ReadOnly = true;
            this.wagonDataGridView.RowHeadersWidth = 51;
            this.wagonDataGridView.RowTemplate.Height = 29;
            this.wagonDataGridView.ShowCellToolTips = false;
            this.wagonDataGridView.Size = new System.Drawing.Size(1196, 437);
            this.wagonDataGridView.TabIndex = 7;
            this.wagonDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.wagonDataGridView_CellClick);
            // 
            // nrWagonColumn
            // 
            this.nrWagonColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nrWagonColumn.HeaderText = "nrWagon";
            this.nrWagonColumn.MinimumWidth = 6;
            this.nrWagonColumn.Name = "nrWagonColumn";
            this.nrWagonColumn.ReadOnly = true;
            this.nrWagonColumn.Width = 125;
            // 
            // TemperatureColumn
            // 
            this.TemperatureColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TemperatureColumn.HeaderText = "Temperature";
            this.TemperatureColumn.MinimumWidth = 6;
            this.TemperatureColumn.Name = "TemperatureColumn";
            this.TemperatureColumn.ReadOnly = true;
            this.TemperatureColumn.Width = 120;
            // 
            // HumidityColumn
            // 
            this.HumidityColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.HumidityColumn.HeaderText = "Humidity";
            this.HumidityColumn.MinimumWidth = 6;
            this.HumidityColumn.Name = "HumidityColumn";
            this.HumidityColumn.ReadOnly = true;
            this.HumidityColumn.Width = 125;
            // 
            // SmokeColumn
            // 
            this.SmokeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SmokeColumn.HeaderText = "Smoke";
            this.SmokeColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.SmokeColumn.MinimumWidth = 6;
            this.SmokeColumn.Name = "SmokeColumn";
            this.SmokeColumn.ReadOnly = true;
            this.SmokeColumn.Width = 125;
            // 
            // ToiletteColumn
            // 
            this.ToiletteColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ToiletteColumn.HeaderText = "Toilette";
            this.ToiletteColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ToiletteColumn.MinimumWidth = 6;
            this.ToiletteColumn.Name = "ToiletteColumn";
            this.ToiletteColumn.ReadOnly = true;
            this.ToiletteColumn.Width = 125;
            // 
            // Port1Column
            // 
            this.Port1Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Port1Column.HeaderText = "Port 1";
            this.Port1Column.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Port1Column.MinimumWidth = 6;
            this.Port1Column.Name = "Port1Column";
            this.Port1Column.ReadOnly = true;
            this.Port1Column.Width = 80;
            // 
            // Port2Column
            // 
            this.Port2Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Port2Column.HeaderText = "Port 2";
            this.Port2Column.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Port2Column.MinimumWidth = 6;
            this.Port2Column.Name = "Port2Column";
            this.Port2Column.ReadOnly = true;
            this.Port2Column.Width = 80;
            // 
            // Port3Column
            // 
            this.Port3Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Port3Column.HeaderText = "Port 3";
            this.Port3Column.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Port3Column.MinimumWidth = 6;
            this.Port3Column.Name = "Port3Column";
            this.Port3Column.ReadOnly = true;
            this.Port3Column.Width = 80;
            // 
            // Port4Column
            // 
            this.Port4Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Port4Column.HeaderText = "Port 4";
            this.Port4Column.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Port4Column.MinimumWidth = 6;
            this.Port4Column.Name = "Port4Column";
            this.Port4Column.ReadOnly = true;
            this.Port4Column.Width = 80;
            // 
            // dataColumn
            // 
            this.dataColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataColumn.HeaderText = "Last Data Received";
            this.dataColumn.MinimumWidth = 6;
            this.dataColumn.Name = "dataColumn";
            this.dataColumn.ReadOnly = true;
            // 
            // wagonLabel
            // 
            this.wagonLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.wagonLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.wagonLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.wagonLabel.Location = new System.Drawing.Point(0, 54);
            this.wagonLabel.Name = "wagonLabel";
            this.wagonLabel.Size = new System.Drawing.Size(1196, 65);
            this.wagonLabel.TabIndex = 6;
            this.wagonLabel.Text = "Wagon";
            this.wagonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(1196, 54);
            this.titleLabel.TabIndex = 5;
            this.titleLabel.Text = "Project Work Train\'s App";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // footerPanel
            // 
            this.footerPanel.Controls.Add(this.checkConnectionPictureBox);
            this.footerPanel.Controls.Add(this.checkConnectionLabel);
            this.footerPanel.Controls.Add(this.creditLabel);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 626);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(1196, 70);
            this.footerPanel.TabIndex = 2;
            // 
            // checkConnectionPictureBox
            // 
            this.checkConnectionPictureBox.Image = global::TrainProjectWorkApp.Properties.Resources._true;
            this.checkConnectionPictureBox.Location = new System.Drawing.Point(132, 12);
            this.checkConnectionPictureBox.Name = "checkConnectionPictureBox";
            this.checkConnectionPictureBox.Size = new System.Drawing.Size(46, 48);
            this.checkConnectionPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.checkConnectionPictureBox.TabIndex = 29;
            this.checkConnectionPictureBox.TabStop = false;
            // 
            // checkConnectionLabel
            // 
            this.checkConnectionLabel.AutoSize = true;
            this.checkConnectionLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkConnectionLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.checkConnectionLabel.Location = new System.Drawing.Point(19, 23);
            this.checkConnectionLabel.Name = "checkConnectionLabel";
            this.checkConnectionLabel.Size = new System.Drawing.Size(107, 23);
            this.checkConnectionLabel.TabIndex = 28;
            this.checkConnectionLabel.Text = "Connection :";
            // 
            // creditLabel
            // 
            this.creditLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.creditLabel.ForeColor = System.Drawing.Color.Silver;
            this.creditLabel.Location = new System.Drawing.Point(0, 0);
            this.creditLabel.Name = "creditLabel";
            this.creditLabel.Size = new System.Drawing.Size(1196, 70);
            this.creditLabel.TabIndex = 2;
            this.creditLabel.Text = "Created by Jellow Jellyfish Team";
            this.creditLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.headerPanel.Size = new System.Drawing.Size(1196, 70);
            this.headerPanel.TabIndex = 1;
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
            // minimizeButton
            // 
            this.minimizeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.minimizeButton.ForeColor = System.Drawing.Color.Silver;
            this.minimizeButton.Location = new System.Drawing.Point(965, 0);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(77, 70);
            this.minimizeButton.TabIndex = 17;
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
            this.resizeButton.Location = new System.Drawing.Point(1042, 0);
            this.resizeButton.Name = "resizeButton";
            this.resizeButton.Size = new System.Drawing.Size(77, 70);
            this.resizeButton.TabIndex = 16;
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
            this.closeButton.Location = new System.Drawing.Point(1119, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(77, 70);
            this.closeButton.TabIndex = 15;
            this.closeButton.Text = "❌";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // headerTitleLabel
            // 
            this.headerTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerTitleLabel.ForeColor = System.Drawing.Color.Silver;
            this.headerTitleLabel.Location = new System.Drawing.Point(0, 0);
            this.headerTitleLabel.Name = "headerTitleLabel";
            this.headerTitleLabel.Size = new System.Drawing.Size(1196, 70);
            this.headerTitleLabel.TabIndex = 3;
            this.headerTitleLabel.Text = "Project Work Train\'s App";
            this.headerTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.headerTitleLabel.DoubleClick += new System.EventHandler(this.resizeButton_Click);
            this.headerTitleLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headerTitleLabel_MouseMove);
            // 
            // SeeWagonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.formPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SeeWagonForm";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SeeWagonForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SeeWagonForm_FormClosing);
            this.formPanel.ResumeLayout(false);
            this.fillPanel.ResumeLayout(false);
            this.dataUpadatePanel.ResumeLayout(false);
            this.dataUpadatePanel.PerformLayout();
            this.wagonDataGridViewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wagonDataGridView)).EndInit();
            this.footerPanel.ResumeLayout(false);
            this.footerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkConnectionPictureBox)).EndInit();
            this.headerPanel.ResumeLayout(false);
            this.logoHeaderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.appPictureBox)).EndInit();
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
        private System.Windows.Forms.Panel wagonDataGridViewPanel;
        private System.Windows.Forms.Label creditLabel;
        private System.Windows.Forms.Label checkConnectionLabel;
        private System.Windows.Forms.PictureBox checkConnectionPictureBox;
        private System.Windows.Forms.Panel dataUpadatePanel;
        private System.Windows.Forms.Label LastDataReceivedLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrWagonColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TemperatureColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HumidityColumn;
        private System.Windows.Forms.DataGridViewImageColumn SmokeColumn;
        private System.Windows.Forms.DataGridViewImageColumn ToiletteColumn;
        private System.Windows.Forms.DataGridViewImageColumn Port1Column;
        private System.Windows.Forms.DataGridViewImageColumn Port2Column;
        private System.Windows.Forms.DataGridViewImageColumn Port3Column;
        private System.Windows.Forms.DataGridViewImageColumn Port4Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataColumn;
    }
}