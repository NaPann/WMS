namespace WMS.VendorTrans
{
    partial class frmVendorCondition
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addScaleQtyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pGradientPanel1 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.pGradientPanel2 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpSValidOn = new System.Windows.Forms.DateTimePicker();
            this.dgvView = new System.Windows.Forms.DataGridView();
            this.clnValidPeriodCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.lblVendor = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddVaidPeriod = new System.Windows.Forms.PictureBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpOn = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1.SuspendLayout();
            this.pGradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddVaidPeriod)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addScaleQtyToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(152, 48);
            // 
            // addScaleQtyToolStripMenuItem
            // 
            this.addScaleQtyToolStripMenuItem.Image = global::WMS.Properties.Resources.add2;
            this.addScaleQtyToolStripMenuItem.Name = "addScaleQtyToolStripMenuItem";
            this.addScaleQtyToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.addScaleQtyToolStripMenuItem.Text = "Add Scale Qty.";
            this.addScaleQtyToolStripMenuItem.Click += new System.EventHandler(this.addScaleQtyToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::WMS.Properties.Resources.error;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // pGradientPanel1
            // 
            this.pGradientPanel1.Caption = "Valid Periods Condition ..";
            this.pGradientPanel1.ColorFrom = System.Drawing.Color.White;
            this.pGradientPanel1.ColorTo = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pGradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pGradientPanel1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.pGradientPanel1.FontOffset = new System.Drawing.Size(5, 10);
            this.pGradientPanel1.ForeColor = System.Drawing.Color.Maroon;
            this.pGradientPanel1.ImageHeader = null;
            this.pGradientPanel1.ImageOffset = new System.Drawing.Size(0, 0);
            this.pGradientPanel1.ImageSize = new System.Drawing.Size(0, 0);
            this.pGradientPanel1.LinearGradientType = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.pGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.pGradientPanel1.Name = "pGradientPanel1";
            this.pGradientPanel1.Size = new System.Drawing.Size(407, 50);
            this.pGradientPanel1.TabIndex = 15;
            // 
            // pGradientPanel2
            // 
            this.pGradientPanel2.Caption = null;
            this.pGradientPanel2.ColorFrom = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pGradientPanel2.ColorTo = System.Drawing.Color.White;
            this.pGradientPanel2.Controls.Add(this.btnExit);
            this.pGradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pGradientPanel2.FontOffset = new System.Drawing.Size(0, 0);
            this.pGradientPanel2.ImageHeader = null;
            this.pGradientPanel2.ImageOffset = new System.Drawing.Size(0, 0);
            this.pGradientPanel2.ImageSize = new System.Drawing.Size(0, 0);
            this.pGradientPanel2.LinearGradientType = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.pGradientPanel2.Location = new System.Drawing.Point(0, 563);
            this.pGradientPanel2.Name = "pGradientPanel2";
            this.pGradientPanel2.Size = new System.Drawing.Size(407, 35);
            this.pGradientPanel2.TabIndex = 16;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackgroundImage = global::WMS.Properties.Resources.Exit;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Location = new System.Drawing.Point(320, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(87, 30);
            this.btnExit.TabIndex = 0;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtpSValidOn);
            this.panel2.Controls.Add(this.dgvView);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(407, 509);
            this.panel2.TabIndex = 4;
            // 
            // dtpSValidOn
            // 
            this.dtpSValidOn.Checked = false;
            this.dtpSValidOn.CustomFormat = "dd.MM.yyyy";
            this.dtpSValidOn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSValidOn.Location = new System.Drawing.Point(60, 211);
            this.dtpSValidOn.Name = "dtpSValidOn";
            this.dtpSValidOn.ShowCheckBox = true;
            this.dtpSValidOn.Size = new System.Drawing.Size(152, 20);
            this.dtpSValidOn.TabIndex = 4;
            this.dtpSValidOn.ValueChanged += new System.EventHandler(this.dtpSValidOn_ValueChanged);
            // 
            // dgvView
            // 
            this.dgvView.AllowUserToAddRows = false;
            this.dgvView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnValidPeriodCode,
            this.Column1,
            this.Column2});
            this.dgvView.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvView.Location = new System.Drawing.Point(20, 234);
            this.dgvView.MultiSelect = false;
            this.dgvView.Name = "dgvView";
            this.dgvView.ReadOnly = true;
            this.dgvView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvView.Size = new System.Drawing.Size(365, 270);
            this.dgvView.TabIndex = 1;
            // 
            // clnValidPeriodCode
            // 
            this.clnValidPeriodCode.DataPropertyName = "ValidPeriodCode";
            this.clnValidPeriodCode.HeaderText = "Column3";
            this.clnValidPeriodCode.Name = "clnValidPeriodCode";
            this.clnValidPeriodCode.ReadOnly = true;
            this.clnValidPeriodCode.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ValidOn";
            dataGridViewCellStyle5.Format = "dd.MM.yyyy";
            this.Column1.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column1.HeaderText = "Valid On";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ValidTo";
            dataGridViewCellStyle6.Format = "dd.MM.yyyy";
            this.Column2.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column2.HeaderText = "Valid To";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMaterial);
            this.groupBox1.Controls.Add(this.lblVendor);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnAddVaidPeriod);
            this.groupBox1.Controls.Add(this.dtpTo);
            this.groupBox1.Controls.Add(this.dtpOn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(20, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 199);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblMaterial
            // 
            this.lblMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblMaterial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblMaterial.Location = new System.Drawing.Point(120, 45);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(199, 49);
            this.lblMaterial.TabIndex = 8;
            this.lblMaterial.Text = "xxxx";
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblVendor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblVendor.Location = new System.Drawing.Point(120, 18);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(36, 17);
            this.lblVendor.TabIndex = 7;
            this.lblVendor.Text = "xxxx";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(50, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Material :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(54, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Vendor :";
            // 
            // btnAddVaidPeriod
            // 
            this.btnAddVaidPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddVaidPeriod.BackgroundImage = global::WMS.Properties.Resources.AddValidPeriods;
            this.btnAddVaidPeriod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddVaidPeriod.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddVaidPeriod.Location = new System.Drawing.Point(174, 158);
            this.btnAddVaidPeriod.Name = "btnAddVaidPeriod";
            this.btnAddVaidPeriod.Size = new System.Drawing.Size(145, 30);
            this.btnAddVaidPeriod.TabIndex = 2;
            this.btnAddVaidPeriod.TabStop = false;
            this.btnAddVaidPeriod.Click += new System.EventHandler(this.btnAddVaidPeriod_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtpTo.CustomFormat = "dd.MM.yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(119, 128);
            this.dtpTo.MaxDate = new System.DateTime(9456, 12, 31, 0, 0, 0, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 21);
            this.dtpTo.TabIndex = 4;
            // 
            // dtpOn
            // 
            this.dtpOn.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtpOn.CustomFormat = "dd.MM.yyyy";
            this.dtpOn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOn.Location = new System.Drawing.Point(119, 101);
            this.dtpOn.Name = "dtpOn";
            this.dtpOn.Size = new System.Drawing.Size(200, 21);
            this.dtpOn.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(56, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Valid To :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(54, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valid On :";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(407, 513);
            this.panel3.TabIndex = 18;
            // 
            // frmVendorCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(407, 598);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pGradientPanel1);
            this.Controls.Add(this.pGradientPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(409, 500);
            this.Name = "frmVendorCondition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmVendorCondition_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.pGradientPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddVaidPeriod)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel1;
        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel2;
        private System.Windows.Forms.PictureBox btnExit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpOn;
        private System.Windows.Forms.DataGridView dgvView;
        private System.Windows.Forms.PictureBox btnAddVaidPeriod;
        private System.Windows.Forms.DateTimePicker dtpSValidOn;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.ToolStripMenuItem addScaleQtyToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnValidPeriodCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;

    }
}