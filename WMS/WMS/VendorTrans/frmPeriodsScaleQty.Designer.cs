namespace WMS.VendorTrans
{
    partial class frmPeriodsScaleQty
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.PictureBox();
            this.btnEdit = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtScaleQty = new System.Windows.Forms.TextBox();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtCurrency = new System.Windows.Forms.TextBox();
            this.dgvView = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clnCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnValidPeriodCodeDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnValidPeriodCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightYellow;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(691, 42);
            this.panel1.TabIndex = 245;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Periods Scale Qty ..";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightYellow;
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 382);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(691, 36);
            this.panel2.TabIndex = 246;
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Image = global::WMS.Properties.Resources.Exit;
            this.btnExit.Location = new System.Drawing.Point(610, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(81, 28);
            this.btnExit.TabIndex = 243;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCurrency);
            this.groupBox1.Controls.Add(this.txtUnit);
            this.groupBox1.Controls.Add(this.txtRate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtScaleQty);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(15, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 89);
            this.groupBox1.TabIndex = 247;
            this.groupBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAdd);
            this.flowLayoutPanel1.Controls.Add(this.btnEdit);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(192, 143);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(92, 38);
            this.flowLayoutPanel1.TabIndex = 242;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.BackgroundImage = global::WMS.Properties.Resources.Add;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 30);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.TabStop = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.White;
            this.btnEdit.BackgroundImage = global::WMS.Properties.Resources.Edit;
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Location = new System.Drawing.Point(3, 39);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(87, 30);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(10, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Scale Qty. :";
            // 
            // txtScaleQty
            // 
            this.txtScaleQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtScaleQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtScaleQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtScaleQty.Location = new System.Drawing.Point(80, 20);
            this.txtScaleQty.Name = "txtScaleQty";
            this.txtScaleQty.Size = new System.Drawing.Size(125, 21);
            this.txtScaleQty.TabIndex = 1;
            this.txtScaleQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtScaleQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtScaleQty_KeyPress);
            // 
            // txtRate
            // 
            this.txtRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRate.Location = new System.Drawing.Point(80, 47);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(125, 21);
            this.txtRate.TabIndex = 3;
            this.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRate_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(38, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rate :";
            // 
            // txtUnit
            // 
            this.txtUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtUnit.Location = new System.Drawing.Point(211, 20);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.ReadOnly = true;
            this.txtUnit.Size = new System.Drawing.Size(38, 21);
            this.txtUnit.TabIndex = 5;
            this.txtUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCurrency
            // 
            this.txtCurrency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCurrency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtCurrency.Location = new System.Drawing.Point(211, 47);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.ReadOnly = true;
            this.txtCurrency.Size = new System.Drawing.Size(38, 21);
            this.txtCurrency.TabIndex = 7;
            this.txtCurrency.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvView
            // 
            this.dgvView.AllowUserToAddRows = false;
            this.dgvView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvView.BackgroundColor = System.Drawing.Color.White;
            this.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnCode,
            this.clnName,
            this.clnRate,
            this.clnCurrency,
            this.clnValidPeriodCodeDetail,
            this.clnValidPeriodCode});
            this.dgvView.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvView.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvView.Location = new System.Drawing.Point(285, 42);
            this.dgvView.MultiSelect = false;
            this.dgvView.Name = "dgvView";
            this.dgvView.ReadOnly = true;
            this.dgvView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvView.Size = new System.Drawing.Size(406, 340);
            this.dgvView.TabIndex = 248;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::WMS.Properties.Resources.error;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // clnCode
            // 
            this.clnCode.DataPropertyName = "ScaleQty";
            this.clnCode.HeaderText = "Scale Qty.";
            this.clnCode.Name = "clnCode";
            this.clnCode.ReadOnly = true;
            this.clnCode.Width = 120;
            // 
            // clnName
            // 
            this.clnName.DataPropertyName = "UnitName";
            this.clnName.HeaderText = "Unit";
            this.clnName.Name = "clnName";
            this.clnName.ReadOnly = true;
            this.clnName.Width = 80;
            // 
            // clnRate
            // 
            this.clnRate.DataPropertyName = "Rate";
            this.clnRate.HeaderText = "Rate";
            this.clnRate.Name = "clnRate";
            this.clnRate.ReadOnly = true;
            this.clnRate.Width = 75;
            // 
            // clnCurrency
            // 
            this.clnCurrency.DataPropertyName = "CurrencyName";
            this.clnCurrency.HeaderText = "Currency";
            this.clnCurrency.Name = "clnCurrency";
            this.clnCurrency.ReadOnly = true;
            this.clnCurrency.Width = 65;
            // 
            // clnValidPeriodCodeDetail
            // 
            this.clnValidPeriodCodeDetail.DataPropertyName = "ValidPeriodDetailCode";
            this.clnValidPeriodCodeDetail.HeaderText = "ValidPeriodDetailCode";
            this.clnValidPeriodCodeDetail.Name = "clnValidPeriodCodeDetail";
            this.clnValidPeriodCodeDetail.ReadOnly = true;
            this.clnValidPeriodCodeDetail.Visible = false;
            // 
            // clnValidPeriodCode
            // 
            this.clnValidPeriodCode.DataPropertyName = "ValidPeriodCode";
            this.clnValidPeriodCode.HeaderText = "ValidPeriodCode";
            this.clnValidPeriodCode.Name = "clnValidPeriodCode";
            this.clnValidPeriodCode.ReadOnly = true;
            this.clnValidPeriodCode.Visible = false;
            // 
            // frmPeriodsScaleQty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(691, 418);
            this.ControlBox = false;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.dgvView);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(693, 420);
            this.MinimumSize = new System.Drawing.Size(693, 420);
            this.Name = "frmPeriodsScaleQty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmPeriodsScaleQty_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox btnExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox btnAdd;
        private System.Windows.Forms.PictureBox btnEdit;
        private System.Windows.Forms.TextBox txtScaleQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCurrency;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnValidPeriodCodeDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnValidPeriodCode;
    }
}