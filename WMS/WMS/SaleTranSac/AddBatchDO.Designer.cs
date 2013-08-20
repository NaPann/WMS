namespace WMS.SaleTranSac
{
    partial class AddBatchDO
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clnBatchNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnSONumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnSOAutoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMatType = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBatchNumber = new System.Windows.Forms.TextBox();
            this.btnOverview = new System.Windows.Forms.PictureBox();
            this.lblMatName = new System.Windows.Forms.Label();
            this.pGradientPanel2 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.btnAddManual = new System.Windows.Forms.PictureBox();
            this.pGradientPanel1 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMatCode = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOverview)).BeginInit();
            this.pGradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddManual)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnBatchNumber,
            this.clnSONumber,
            this.clnQty,
            this.clnSOAutoID});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 205);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(555, 169);
            this.dataGridView1.TabIndex = 20;
            // 
            // clnBatchNumber
            // 
            this.clnBatchNumber.DataPropertyName = "BatchNumber";
            this.clnBatchNumber.HeaderText = "BatchNumber";
            this.clnBatchNumber.Name = "clnBatchNumber";
            this.clnBatchNumber.ReadOnly = true;
            // 
            // clnSONumber
            // 
            this.clnSONumber.DataPropertyName = "SONumber";
            this.clnSONumber.HeaderText = "SONumber";
            this.clnSONumber.Name = "clnSONumber";
            this.clnSONumber.ReadOnly = true;
            this.clnSONumber.Visible = false;
            // 
            // clnQty
            // 
            this.clnQty.DataPropertyName = "Qty";
            dataGridViewCellStyle2.Format = "N3";
            dataGridViewCellStyle2.NullValue = null;
            this.clnQty.DefaultCellStyle = dataGridViewCellStyle2;
            this.clnQty.HeaderText = "Quantity";
            this.clnQty.Name = "clnQty";
            this.clnQty.ReadOnly = true;
            this.clnQty.Width = 150;
            // 
            // clnSOAutoID
            // 
            this.clnSOAutoID.DataPropertyName = "SOAutoID";
            this.clnSOAutoID.HeaderText = "ID";
            this.clnSOAutoID.Name = "clnSOAutoID";
            this.clnSOAutoID.ReadOnly = true;
            this.clnSOAutoID.Visible = false;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(236, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 15);
            this.label5.TabIndex = 57;
            this.label5.Text = "Unit of measure :";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblUnit.Location = new System.Drawing.Point(342, 78);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(94, 15);
            this.lblUnit.TabIndex = 52;
            this.lblUnit.Text = "Unit of measure";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(24, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 15);
            this.label3.TabIndex = 55;
            this.label3.Text = "Material type :";
            // 
            // lblMatType
            // 
            this.lblMatType.AutoSize = true;
            this.lblMatType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblMatType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblMatType.Location = new System.Drawing.Point(113, 78);
            this.lblMatType.Name = "lblMatType";
            this.lblMatType.Size = new System.Drawing.Size(77, 15);
            this.lblMatType.TabIndex = 54;
            this.lblMatType.Text = "Material type";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "QI";
            dataGridViewCellStyle3.Format = "N3";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn3.HeaderText = "QI";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "UR";
            dataGridViewCellStyle4.Format = "N3";
            dataGridViewCellStyle4.NullValue = null;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn2.HeaderText = "UR";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "BatchNumber";
            this.dataGridViewTextBoxColumn1.HeaderText = "Batch";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // txtBatchNumber
            // 
            this.txtBatchNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBatchNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(222)));
            this.txtBatchNumber.Location = new System.Drawing.Point(113, 10);
            this.txtBatchNumber.Name = "txtBatchNumber";
            this.txtBatchNumber.Size = new System.Drawing.Size(160, 21);
            this.txtBatchNumber.TabIndex = 0;
            this.txtBatchNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBatchNumber_KeyDown);
            // 
            // btnOverview
            // 
            this.btnOverview.BackColor = System.Drawing.Color.White;
            this.btnOverview.BackgroundImage = global::WMS.Properties.Resources.Overview;
            this.btnOverview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnOverview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOverview.Location = new System.Drawing.Point(279, 10);
            this.btnOverview.Name = "btnOverview";
            this.btnOverview.Size = new System.Drawing.Size(23, 22);
            this.btnOverview.TabIndex = 44;
            this.btnOverview.TabStop = false;
            this.btnOverview.Click += new System.EventHandler(this.btnOverview_Click);
            // 
            // lblMatName
            // 
            this.lblMatName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblMatName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblMatName.Location = new System.Drawing.Point(339, 43);
            this.lblMatName.Name = "lblMatName";
            this.lblMatName.Size = new System.Drawing.Size(184, 32);
            this.lblMatName.TabIndex = 50;
            this.lblMatName.Text = "Material Name";
            // 
            // pGradientPanel2
            // 
            this.pGradientPanel2.Caption = "";
            this.pGradientPanel2.ColorFrom = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pGradientPanel2.ColorTo = System.Drawing.Color.White;
            this.pGradientPanel2.Controls.Add(this.btnExit);
            this.pGradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pGradientPanel2.FontOffset = new System.Drawing.Size(0, 0);
            this.pGradientPanel2.ImageHeader = null;
            this.pGradientPanel2.ImageOffset = new System.Drawing.Size(0, 0);
            this.pGradientPanel2.ImageSize = new System.Drawing.Size(0, 0);
            this.pGradientPanel2.LinearGradientType = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.pGradientPanel2.Location = new System.Drawing.Point(0, 374);
            this.pGradientPanel2.Name = "pGradientPanel2";
            this.pGradientPanel2.Size = new System.Drawing.Size(555, 35);
            this.pGradientPanel2.TabIndex = 18;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackgroundImage = global::WMS.Properties.Resources.Exit;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Location = new System.Drawing.Point(465, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(87, 30);
            this.btnExit.TabIndex = 0;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAddManual
            // 
            this.btnAddManual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddManual.BackgroundImage = global::WMS.Properties.Resources.Add;
            this.btnAddManual.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddManual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddManual.Location = new System.Drawing.Point(291, 114);
            this.btnAddManual.Name = "btnAddManual";
            this.btnAddManual.Size = new System.Drawing.Size(87, 30);
            this.btnAddManual.TabIndex = 1;
            this.btnAddManual.TabStop = false;
            this.btnAddManual.Click += new System.EventHandler(this.btnAddManual_Click);
            // 
            // pGradientPanel1
            // 
            this.pGradientPanel1.Caption = "Add Batch DO";
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
            this.pGradientPanel1.Size = new System.Drawing.Size(555, 50);
            this.pGradientPanel1.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(241, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 51;
            this.label2.Text = "Material Name :";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Block";
            dataGridViewCellStyle5.Format = "N3";
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn4.HeaderText = "Block";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAddManual);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtQuantity);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(555, 155);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.lblMatCode);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lblMatName);
            this.panel2.Controls.Add(this.txtBatchNumber);
            this.panel2.Controls.Add(this.lblUnit);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnOverview);
            this.panel2.Controls.Add(this.lblMatType);
            this.panel2.Location = new System.Drawing.Point(12, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(529, 103);
            this.panel2.TabIndex = 58;
            // 
            // lblMatCode
            // 
            this.lblMatCode.AutoSize = true;
            this.lblMatCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblMatCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblMatCode.Location = new System.Drawing.Point(113, 43);
            this.lblMatCode.Name = "lblMatCode";
            this.lblMatCode.Size = new System.Drawing.Size(84, 15);
            this.lblMatCode.TabIndex = 58;
            this.lblMatCode.Text = "Material Code";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(17, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 15);
            this.label7.TabIndex = 59;
            this.label7.Text = "Material Code :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Batch Number : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(59, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 47;
            this.label4.Text = "Quantity : ";
            // 
            // txtQuantity
            // 
            this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(222)));
            this.txtQuantity.Location = new System.Drawing.Point(125, 118);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(160, 21);
            this.txtQuantity.TabIndex = 0;
            this.txtQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuantity_KeyDown);
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // AddBatchDO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 409);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pGradientPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pGradientPanel1);
            this.Name = "AddBatchDO";
            this.Text = "AddBatchDO";
            this.Load += new System.EventHandler(this.AddBatchDO_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddBatchDO_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnOverview)).EndInit();
            this.pGradientPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddManual)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMatType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.TextBox txtBatchNumber;
        private System.Windows.Forms.PictureBox btnOverview;
        private System.Windows.Forms.Label lblMatName;
        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel2;
        private System.Windows.Forms.PictureBox btnAddManual;
        private System.Windows.Forms.PictureBox btnExit;
        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnBatchNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnSONumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnSOAutoID;
        private System.Windows.Forms.Label lblMatCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;

    }
}