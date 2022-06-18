namespace TrainProjectWorkApp
{
    partial class SeeTrainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeeTrainForm));
            this.formPanel = new System.Windows.Forms.Panel();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.fillPanel = new System.Windows.Forms.Panel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.headerTitleLabel = new System.Windows.Forms.Label();
            this.logoHeaderPanel = new System.Windows.Forms.Panel();
            this.appPictureBox = new System.Windows.Forms.PictureBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.resizeButton = new System.Windows.Forms.Button();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.creditLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.trainLabel = new System.Windows.Forms.Label();
            this.trainDataGridViewPanel = new System.Windows.Forms.Panel();
            this.trainDataGridView = new System.Windows.Forms.DataGridView();
            this.nrTrainColum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrWagonColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stationmasterColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formPanel.SuspendLayout();
            this.footerPanel.SuspendLayout();
            this.fillPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.logoHeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appPictureBox)).BeginInit();
            this.trainDataGridViewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trainDataGridView)).BeginInit();
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
            this.formPanel.Size = new System.Drawing.Size(1058, 649);
            this.formPanel.TabIndex = 0;
            // 
            // footerPanel
            // 
            this.footerPanel.Controls.Add(this.creditLabel);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 579);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(1058, 70);
            this.footerPanel.TabIndex = 2;
            // 
            // fillPanel
            // 
            this.fillPanel.Controls.Add(this.trainDataGridViewPanel);
            this.fillPanel.Controls.Add(this.trainLabel);
            this.fillPanel.Controls.Add(this.titleLabel);
            this.fillPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fillPanel.Location = new System.Drawing.Point(0, 70);
            this.fillPanel.Name = "fillPanel";
            this.fillPanel.Size = new System.Drawing.Size(1058, 579);
            this.fillPanel.TabIndex = 1;
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
            this.headerPanel.Size = new System.Drawing.Size(1058, 70);
            this.headerPanel.TabIndex = 0;
            // 
            // headerTitleLabel
            // 
            this.headerTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerTitleLabel.ForeColor = System.Drawing.Color.Silver;
            this.headerTitleLabel.Location = new System.Drawing.Point(0, 0);
            this.headerTitleLabel.Name = "headerTitleLabel";
            this.headerTitleLabel.Size = new System.Drawing.Size(1058, 70);
            this.headerTitleLabel.TabIndex = 4;
            this.headerTitleLabel.Text = "Project Work Train\'s App";
            this.headerTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.headerTitleLabel.DoubleClick += new System.EventHandler(this.resizeButton_Click);
            this.headerTitleLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headerTitleLabel_MouseMove);
            // 
            // logoHeaderPanel
            // 
            this.logoHeaderPanel.Controls.Add(this.appPictureBox);
            this.logoHeaderPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.logoHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.logoHeaderPanel.Name = "logoHeaderPanel";
            this.logoHeaderPanel.Size = new System.Drawing.Size(77, 70);
            this.logoHeaderPanel.TabIndex = 19;
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
            // closeButton
            // 
            this.closeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.closeButton.ForeColor = System.Drawing.Color.Silver;
            this.closeButton.Location = new System.Drawing.Point(981, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(77, 70);
            this.closeButton.TabIndex = 20;
            this.closeButton.Text = "❌";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // resizeButton
            // 
            this.resizeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.resizeButton.FlatAppearance.BorderSize = 0;
            this.resizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resizeButton.Font = new System.Drawing.Font("Segoe UI", 16.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.resizeButton.ForeColor = System.Drawing.Color.Silver;
            this.resizeButton.Location = new System.Drawing.Point(904, 0);
            this.resizeButton.Name = "resizeButton";
            this.resizeButton.Size = new System.Drawing.Size(77, 70);
            this.resizeButton.TabIndex = 21;
            this.resizeButton.Text = "◻";
            this.resizeButton.UseVisualStyleBackColor = true;
            this.resizeButton.Click += new System.EventHandler(this.resizeButton_Click);
            // 
            // minimizeButton
            // 
            this.minimizeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.minimizeButton.ForeColor = System.Drawing.Color.Silver;
            this.minimizeButton.Location = new System.Drawing.Point(827, 0);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(77, 70);
            this.minimizeButton.TabIndex = 22;
            this.minimizeButton.Text = "–";
            this.minimizeButton.UseVisualStyleBackColor = true;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // creditLabel
            // 
            this.creditLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.creditLabel.ForeColor = System.Drawing.Color.Silver;
            this.creditLabel.Location = new System.Drawing.Point(0, 0);
            this.creditLabel.Name = "creditLabel";
            this.creditLabel.Size = new System.Drawing.Size(1058, 70);
            this.creditLabel.TabIndex = 2;
            this.creditLabel.Text = "Created by Jellow Jellyfish Team";
            this.creditLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(1058, 54);
            this.titleLabel.TabIndex = 6;
            this.titleLabel.Text = "Project Work Train\'s App";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trainLabel
            // 
            this.trainLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.trainLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.trainLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.trainLabel.Location = new System.Drawing.Point(0, 54);
            this.trainLabel.Name = "trainLabel";
            this.trainLabel.Size = new System.Drawing.Size(1058, 65);
            this.trainLabel.TabIndex = 7;
            this.trainLabel.Text = "Train";
            this.trainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trainDataGridViewPanel
            // 
            this.trainDataGridViewPanel.Controls.Add(this.trainDataGridView);
            this.trainDataGridViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trainDataGridViewPanel.Location = new System.Drawing.Point(0, 119);
            this.trainDataGridViewPanel.Name = "trainDataGridViewPanel";
            this.trainDataGridViewPanel.Size = new System.Drawing.Size(1058, 460);
            this.trainDataGridViewPanel.TabIndex = 8;
            // 
            // trainDataGridView
            // 
            this.trainDataGridView.AllowUserToDeleteRows = false;
            this.trainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.trainDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nrTrainColum,
            this.nrWagonColumn,
            this.stationmasterColumn});
            this.trainDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trainDataGridView.Location = new System.Drawing.Point(0, 0);
            this.trainDataGridView.Name = "trainDataGridView";
            this.trainDataGridView.ReadOnly = true;
            this.trainDataGridView.RowHeadersWidth = 51;
            this.trainDataGridView.RowTemplate.Height = 29;
            this.trainDataGridView.Size = new System.Drawing.Size(1058, 460);
            this.trainDataGridView.TabIndex = 0;
            this.trainDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.trainDataGridView_CellClick);
            // 
            // nrTrainColum
            // 
            this.nrTrainColum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nrTrainColum.HeaderText = "Train";
            this.nrTrainColum.MinimumWidth = 6;
            this.nrTrainColum.Name = "nrTrainColum";
            this.nrTrainColum.ReadOnly = true;
            this.nrTrainColum.Width = 80;
            // 
            // nrWagonColumn
            // 
            this.nrWagonColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nrWagonColumn.HeaderText = "Nr° Wagon";
            this.nrWagonColumn.MinimumWidth = 6;
            this.nrWagonColumn.Name = "nrWagonColumn";
            this.nrWagonColumn.ReadOnly = true;
            this.nrWagonColumn.Width = 120;
            // 
            // stationmasterColumn
            // 
            this.stationmasterColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.stationmasterColumn.HeaderText = "Stationmaster";
            this.stationmasterColumn.MinimumWidth = 6;
            this.stationmasterColumn.Name = "stationmasterColumn";
            this.stationmasterColumn.ReadOnly = true;
            this.stationmasterColumn.Width = 140;
            // 
            // SeeTrainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 653);
            this.Controls.Add(this.formPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SeeTrainForm";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SeeTrainForm";
            this.formPanel.ResumeLayout(false);
            this.footerPanel.ResumeLayout(false);
            this.fillPanel.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.logoHeaderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.appPictureBox)).EndInit();
            this.trainDataGridViewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trainDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Panel fillPanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label headerTitleLabel;
        private System.Windows.Forms.Panel logoHeaderPanel;
        private System.Windows.Forms.PictureBox appPictureBox;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button resizeButton;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Label creditLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label trainLabel;
        private System.Windows.Forms.Panel trainDataGridViewPanel;
        private System.Windows.Forms.DataGridView trainDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrTrainColum;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrWagonColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stationmasterColumn;
    }
}