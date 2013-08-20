namespace WMS.BOM
{
    partial class frmMRPRunningNew
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblMatName = new System.Windows.Forms.Label();
            this.txtMatCode = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMRP = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pGradientPanel2 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.pGradientPanel1 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clnNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnHeadBOMCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnHeadQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnFGUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCompCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCompQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCompUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnHeadBOMCode_Hide = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.componentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMRP)).BeginInit();
            this.pGradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMatName
            // 
            this.lblMatName.AutoSize = true;
            this.lblMatName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblMatName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblMatName.Location = new System.Drawing.Point(123, 36);
            this.lblMatName.Name = "lblMatName";
            this.lblMatName.Size = new System.Drawing.Size(132, 18);
            this.lblMatName.TabIndex = 2;
            this.lblMatName.Text = ".. Material Name .. ";
            // 
            // txtMatCode
            // 
            this.txtMatCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMatCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtMatCode.Location = new System.Drawing.Point(120, 7);
            this.txtMatCode.Name = "txtMatCode";
            this.txtMatCode.Size = new System.Drawing.Size(160, 24);
            this.txtMatCode.TabIndex = 1;
            this.txtMatCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMatCode_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMRP);
            this.panel1.Controls.Add(this.lblMatName);
            this.panel1.Controls.Add(this.txtMatCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(898, 61);
            this.panel1.TabIndex = 18;
            // 
            // btnMRP
            // 
            this.btnMRP.BackColor = System.Drawing.Color.White;
            this.btnMRP.BackgroundImage = global::WMS.Properties.Resources.MRP;
            this.btnMRP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMRP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMRP.Location = new System.Drawing.Point(286, 4);
            this.btnMRP.Name = "btnMRP";
            this.btnMRP.Size = new System.Drawing.Size(126, 30);
            this.btnMRP.TabIndex = 44;
            this.btnMRP.TabStop = false;
            this.btnMRP.Click += new System.EventHandler(this.btnMRP_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(11, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Material Code : ";
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
            this.pGradientPanel2.Location = new System.Drawing.Point(0, 463);
            this.pGradientPanel2.Name = "pGradientPanel2";
            this.pGradientPanel2.Size = new System.Drawing.Size(898, 35);
            this.pGradientPanel2.TabIndex = 17;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackgroundImage = global::WMS.Properties.Resources.Exit;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Location = new System.Drawing.Point(808, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(87, 30);
            this.btnExit.TabIndex = 0;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pGradientPanel1
            // 
            this.pGradientPanel1.Caption = "MRP Running";
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
            this.pGradientPanel1.Size = new System.Drawing.Size(898, 50);
            this.pGradientPanel1.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 111);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(898, 352);
            this.panel2.TabIndex = 19;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnNo,
            this.clnHeadBOMCode,
            this.clnHeadQty,
            this.clnFGUnit,
            this.clnCompCode,
            this.clnCompQty,
            this.clnCompUnit,
            this.clnHeadBOMCode_Hide});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(898, 352);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // clnNo
            // 
            this.clnNo.DataPropertyName = "ItemNo";
            this.clnNo.HeaderText = "No.";
            this.clnNo.Name = "clnNo";
            this.clnNo.ReadOnly = true;
            this.clnNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clnNo.Width = 50;
            // 
            // clnHeadBOMCode
            // 
            this.clnHeadBOMCode.DataPropertyName = "HeadBOMCode";
            this.clnHeadBOMCode.HeaderText = "FG Code";
            this.clnHeadBOMCode.Name = "clnHeadBOMCode";
            this.clnHeadBOMCode.ReadOnly = true;
            this.clnHeadBOMCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clnHeadBOMCode.Width = 250;
            // 
            // clnHeadQty
            // 
            this.clnHeadQty.DataPropertyName = "FGQty";
            dataGridViewCellStyle9.Format = "N3";
            dataGridViewCellStyle9.NullValue = null;
            this.clnHeadQty.DefaultCellStyle = dataGridViewCellStyle9;
            this.clnHeadQty.HeaderText = "Qty";
            this.clnHeadQty.Name = "clnHeadQty";
            this.clnHeadQty.ReadOnly = true;
            this.clnHeadQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clnFGUnit
            // 
            this.clnFGUnit.DataPropertyName = "FGUnit";
            this.clnFGUnit.HeaderText = "FGUnit";
            this.clnFGUnit.Name = "clnFGUnit";
            this.clnFGUnit.ReadOnly = true;
            this.clnFGUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clnCompCode
            // 
            this.clnCompCode.DataPropertyName = "ComponentCode";
            this.clnCompCode.HeaderText = "Component ";
            this.clnCompCode.Name = "clnCompCode";
            this.clnCompCode.ReadOnly = true;
            this.clnCompCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clnCompCode.Width = 250;
            // 
            // clnCompQty
            // 
            this.clnCompQty.DataPropertyName = "ComponentQty";
            dataGridViewCellStyle10.Format = "N3";
            this.clnCompQty.DefaultCellStyle = dataGridViewCellStyle10;
            this.clnCompQty.HeaderText = "Qty";
            this.clnCompQty.Name = "clnCompQty";
            this.clnCompQty.ReadOnly = true;
            this.clnCompQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clnCompUnit
            // 
            this.clnCompUnit.DataPropertyName = "CompUnit";
            this.clnCompUnit.HeaderText = "CompUnit";
            this.clnCompUnit.Name = "clnCompUnit";
            this.clnCompUnit.ReadOnly = true;
            this.clnCompUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clnHeadBOMCode_Hide
            // 
            this.clnHeadBOMCode_Hide.DataPropertyName = "HeadBOMCode_Hide";
            this.clnHeadBOMCode_Hide.HeaderText = "Hide";
            this.clnHeadBOMCode_Hide.Name = "clnHeadBOMCode_Hide";
            this.clnHeadBOMCode_Hide.ReadOnly = true;
            this.clnHeadBOMCode_Hide.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fGToolStripMenuItem,
            this.componentToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(148, 52);
            // 
            // fGToolStripMenuItem
            // 
            this.fGToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.fGToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fGToolStripMenuItem.Name = "fGToolStripMenuItem";
            this.fGToolStripMenuItem.Size = new System.Drawing.Size(147, 24);
            this.fGToolStripMenuItem.Text = "FG";
            this.fGToolStripMenuItem.Click += new System.EventHandler(this.fGToolStripMenuItem_Click);
            // 
            // componentToolStripMenuItem
            // 
            this.componentToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.componentToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.componentToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.componentToolStripMenuItem.Name = "componentToolStripMenuItem";
            this.componentToolStripMenuItem.Size = new System.Drawing.Size(147, 24);
            this.componentToolStripMenuItem.Text = "Component";
            this.componentToolStripMenuItem.Click += new System.EventHandler(this.componentToolStripMenuItem_Click);
            // 
            // frmMRPRunningNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(898, 498);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pGradientPanel2);
            this.Controls.Add(this.pGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMRPRunningNew";
            this.Load += new System.EventHandler(this.frmMRPRunningNew_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMRPRunningNew_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMRP)).EndInit();
            this.pGradientPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox btnMRP;
        private System.Windows.Forms.Label lblMatName;
        private System.Windows.Forms.TextBox txtMatCode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel2;
        private System.Windows.Forms.PictureBox btnExit;
        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem componentToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnHeadBOMCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnHeadQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnFGUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCompCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCompQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCompUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnHeadBOMCode_Hide;
    }
}