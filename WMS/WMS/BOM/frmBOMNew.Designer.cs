namespace WMS.BOM
{
    partial class frmBOMNew
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvView = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.setComponentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.PictureBox();
            this.btnEdit = new System.Windows.Forms.PictureBox();
            this.gMaster = new System.Windows.Forms.GroupBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbBOMType = new System.Windows.Forms.ComboBox();
            this.cbUnit = new System.Windows.Forms.ComboBox();
            this.cbPlant = new System.Windows.Forms.ComboBox();
            this.cbMaterial = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtFor = new System.Windows.Forms.TextBox();
            this.btnReport = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnNewVer = new System.Windows.Forms.PictureBox();
            this.lblAppr = new System.Windows.Forms.Label();
            this.btnSetBOMType = new System.Windows.Forms.PictureBox();
            this.pGradientPanel2 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.pGradientPanel1 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnItemNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnBOMCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnMaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnMaterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPlantName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnApproveImg = new System.Windows.Forms.DataGridViewImageColumn();
            this.clnApprove = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPlantCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnBOMType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).BeginInit();
            this.gMaster.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewVer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSetBOMType)).BeginInit();
            this.pGradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvView);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 81);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(898, 382);
            this.panel3.TabIndex = 14;
            // 
            // dgvView
            // 
            this.dgvView.AllowUserToAddRows = false;
            this.dgvView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnItemNo,
            this.clnBOMCode,
            this.clnMaterialCode,
            this.clnMaterialName,
            this.clnPlantName,
            this.clnVersion,
            this.clnApproveImg,
            this.clnApprove,
            this.clnPlantCode,
            this.clnQty,
            this.clnUnitName,
            this.clnBOMType});
            this.dgvView.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvView.Location = new System.Drawing.Point(318, 0);
            this.dgvView.MultiSelect = false;
            this.dgvView.Name = "dgvView";
            this.dgvView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvView.RowHeadersVisible = false;
            this.dgvView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvView.Size = new System.Drawing.Size(580, 382);
            this.dgvView.TabIndex = 3;
            this.dgvView.SelectionChanged += new System.EventHandler(this.dgvView_SelectionChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator2,
            this.setComponentToolStripMenuItem,
            this.toolStripSeparator1,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(221, 112);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.ForestGreen;
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem1.Image = global::WMS.Properties.Resources.auction_hammer;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(220, 24);
            this.toolStripMenuItem1.Text = "Approve BOM";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(217, 6);
            // 
            // setComponentToolStripMenuItem
            // 
            this.setComponentToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.setComponentToolStripMenuItem.Image = global::WMS.Properties.Resources.scroll_add;
            this.setComponentToolStripMenuItem.Name = "setComponentToolStripMenuItem";
            this.setComponentToolStripMenuItem.Size = new System.Drawing.Size(220, 24);
            this.setComponentToolStripMenuItem.Text = "View && Set Component";
            this.setComponentToolStripMenuItem.Click += new System.EventHandler(this.setComponentToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(217, 6);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::WMS.Properties.Resources.edit_2;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(220, 24);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::WMS.Properties.Resources.error;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(220, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Controls.Add(this.gMaster);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(318, 382);
            this.panel2.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAdd);
            this.flowLayoutPanel1.Controls.Add(this.btnEdit);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(219, 327);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(92, 38);
            this.flowLayoutPanel1.TabIndex = 0;
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
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // gMaster
            // 
            this.gMaster.Controls.Add(this.txtFor);
            this.gMaster.Controls.Add(this.txtRemark);
            this.gMaster.Controls.Add(this.label5);
            this.gMaster.Controls.Add(this.label3);
            this.gMaster.Controls.Add(this.cbBOMType);
            this.gMaster.Controls.Add(this.cbUnit);
            this.gMaster.Controls.Add(this.cbPlant);
            this.gMaster.Controls.Add(this.cbMaterial);
            this.gMaster.Controls.Add(this.label7);
            this.gMaster.Controls.Add(this.txtQty);
            this.gMaster.Controls.Add(this.label6);
            this.gMaster.Controls.Add(this.label4);
            this.gMaster.Controls.Add(this.label2);
            this.gMaster.Controls.Add(this.label1);
            this.gMaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gMaster.Location = new System.Drawing.Point(7, 3);
            this.gMaster.Name = "gMaster";
            this.gMaster.Size = new System.Drawing.Size(304, 318);
            this.gMaster.TabIndex = 3;
            this.gMaster.TabStop = false;
            // 
            // txtRemark
            // 
            this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark.Location = new System.Drawing.Point(105, 246);
            this.txtRemark.MaxLength = 255;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(183, 58);
            this.txtRemark.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(37, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Remark :";
            // 
            // cbBOMType
            // 
            this.cbBOMType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBOMType.FormattingEnabled = true;
            this.cbBOMType.Location = new System.Drawing.Point(105, 99);
            this.cbBOMType.Name = "cbBOMType";
            this.cbBOMType.Size = new System.Drawing.Size(183, 24);
            this.cbBOMType.TabIndex = 2;
            this.cbBOMType.SelectedIndexChanged += new System.EventHandler(this.cbBOMType_SelectedIndexChanged);
            // 
            // cbUnit
            // 
            this.cbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnit.FormattingEnabled = true;
            this.cbUnit.Location = new System.Drawing.Point(105, 137);
            this.cbUnit.Name = "cbUnit";
            this.cbUnit.Size = new System.Drawing.Size(183, 24);
            this.cbUnit.TabIndex = 3;
            // 
            // cbPlant
            // 
            this.cbPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlant.FormattingEnabled = true;
            this.cbPlant.Location = new System.Drawing.Point(105, 61);
            this.cbPlant.Name = "cbPlant";
            this.cbPlant.Size = new System.Drawing.Size(183, 24);
            this.cbPlant.TabIndex = 1;
            this.cbPlant.SelectedIndexChanged += new System.EventHandler(this.cbPlant_SelectedIndexChanged);
            // 
            // cbMaterial
            // 
            this.cbMaterial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbMaterial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbMaterial.FormattingEnabled = true;
            this.cbMaterial.Location = new System.Drawing.Point(105, 23);
            this.cbMaterial.Name = "cbMaterial";
            this.cbMaterial.Size = new System.Drawing.Size(183, 24);
            this.cbMaterial.TabIndex = 0;
            this.cbMaterial.SelectedIndexChanged += new System.EventHandler(this.cbMaterial_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(62, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Unit :";
            // 
            // txtQty
            // 
            this.txtQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQty.Location = new System.Drawing.Point(105, 177);
            this.txtQty.MaxLength = 20;
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(183, 22);
            this.txtQty.TabIndex = 4;
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(37, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Quantity :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(14, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "B.O.M Type :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(49, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Plant :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(29, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Material :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnReport);
            this.panel1.Controls.Add(this.btnNewVer);
            this.panel1.Controls.Add(this.lblAppr);
            this.panel1.Controls.Add(this.btnSetBOMType);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(898, 31);
            this.panel1.TabIndex = 13;
            // 
            // txtFor
            // 
            this.txtFor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtFor.Location = new System.Drawing.Point(105, 214);
            this.txtFor.MaxLength = 15;
            this.txtFor.Name = "txtFor";
            this.txtFor.Size = new System.Drawing.Size(183, 21);
            this.txtFor.TabIndex = 14;
            // 
            // btnReport
            // 
            this.btnReport.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnReport.BackgroundImage = global::WMS.Properties.Resources.Report;
            this.btnReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReport.Location = new System.Drawing.Point(318, 2);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(111, 28);
            this.btnReport.TabIndex = 4;
            this.btnReport.TabStop = false;
            this.btnReport.Visible = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(21, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "Formula No :";
            // 
            // btnNewVer
            // 
            this.btnNewVer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnNewVer.BackgroundImage = global::WMS.Properties.Resources.NewVersion;
            this.btnNewVer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNewVer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewVer.Location = new System.Drawing.Point(431, 2);
            this.btnNewVer.Name = "btnNewVer";
            this.btnNewVer.Size = new System.Drawing.Size(119, 28);
            this.btnNewVer.TabIndex = 3;
            this.btnNewVer.TabStop = false;
            this.btnNewVer.Visible = false;
            this.btnNewVer.Click += new System.EventHandler(this.btnNewVer_Click);
            // 
            // lblAppr
            // 
            this.lblAppr.AutoSize = true;
            this.lblAppr.Location = new System.Drawing.Point(13, 7);
            this.lblAppr.Name = "lblAppr";
            this.lblAppr.Size = new System.Drawing.Size(35, 13);
            this.lblAppr.TabIndex = 2;
            this.lblAppr.Text = "label3";
            this.lblAppr.Visible = false;
            // 
            // btnSetBOMType
            // 
            this.btnSetBOMType.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSetBOMType.BackgroundImage = global::WMS.Properties.Resources.SetBOMType;
            this.btnSetBOMType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSetBOMType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetBOMType.Location = new System.Drawing.Point(767, 2);
            this.btnSetBOMType.Name = "btnSetBOMType";
            this.btnSetBOMType.Size = new System.Drawing.Size(131, 28);
            this.btnSetBOMType.TabIndex = 1;
            this.btnSetBOMType.TabStop = false;
            this.btnSetBOMType.Click += new System.EventHandler(this.btnSetBOMType_Click);
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
            this.pGradientPanel2.Location = new System.Drawing.Point(0, 463);
            this.pGradientPanel2.Name = "pGradientPanel2";
            this.pGradientPanel2.Size = new System.Drawing.Size(898, 35);
            this.pGradientPanel2.TabIndex = 12;
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
            this.pGradientPanel1.Caption = "B.O.M";
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
            this.pGradientPanel1.TabIndex = 11;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ItemNo";
            this.dataGridViewTextBoxColumn1.HeaderText = "Item.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "BOMCode";
            this.dataGridViewTextBoxColumn2.HeaderText = "BOMCode";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "MaterialCode";
            this.dataGridViewTextBoxColumn3.HeaderText = "Code";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "MaterialName";
            this.dataGridViewTextBoxColumn4.HeaderText = "Material";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "PlantName";
            this.dataGridViewTextBoxColumn5.HeaderText = "Plant";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 120;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "BOMVersion";
            this.dataGridViewTextBoxColumn6.HeaderText = "Version";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Approve";
            this.dataGridViewTextBoxColumn7.HeaderText = "Approve";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "PlantCode";
            this.dataGridViewTextBoxColumn8.HeaderText = "PlantCode";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            this.dataGridViewTextBoxColumn8.Width = 220;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Quantity";
            this.dataGridViewTextBoxColumn9.HeaderText = "Qty";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "UnitName";
            this.dataGridViewTextBoxColumn10.HeaderText = "Unit";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "BOMType";
            this.dataGridViewTextBoxColumn11.HeaderText = "BOMType";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // clnItemNo
            // 
            this.clnItemNo.DataPropertyName = "ItemNo";
            this.clnItemNo.HeaderText = "Item.";
            this.clnItemNo.Name = "clnItemNo";
            this.clnItemNo.ReadOnly = true;
            this.clnItemNo.Width = 50;
            // 
            // clnBOMCode
            // 
            this.clnBOMCode.DataPropertyName = "BOMCode";
            this.clnBOMCode.HeaderText = "BOMCode";
            this.clnBOMCode.Name = "clnBOMCode";
            this.clnBOMCode.ReadOnly = true;
            this.clnBOMCode.Visible = false;
            // 
            // clnMaterialCode
            // 
            this.clnMaterialCode.DataPropertyName = "MaterialCode";
            this.clnMaterialCode.HeaderText = "Code";
            this.clnMaterialCode.Name = "clnMaterialCode";
            this.clnMaterialCode.ReadOnly = true;
            // 
            // clnMaterialName
            // 
            this.clnMaterialName.DataPropertyName = "MaterialName";
            this.clnMaterialName.HeaderText = "Material";
            this.clnMaterialName.Name = "clnMaterialName";
            this.clnMaterialName.ReadOnly = true;
            this.clnMaterialName.Width = 120;
            // 
            // clnPlantName
            // 
            this.clnPlantName.DataPropertyName = "PlantName";
            this.clnPlantName.HeaderText = "Plant";
            this.clnPlantName.Name = "clnPlantName";
            this.clnPlantName.ReadOnly = true;
            this.clnPlantName.Width = 120;
            // 
            // clnVersion
            // 
            this.clnVersion.DataPropertyName = "BOMVersion";
            this.clnVersion.HeaderText = "Version";
            this.clnVersion.Name = "clnVersion";
            this.clnVersion.ReadOnly = true;
            this.clnVersion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clnVersion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clnVersion.Width = 80;
            // 
            // clnApproveImg
            // 
            this.clnApproveImg.DataPropertyName = "imgAppr";
            this.clnApproveImg.HeaderText = "Approve";
            this.clnApproveImg.Name = "clnApproveImg";
            this.clnApproveImg.ReadOnly = true;
            this.clnApproveImg.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clnApproveImg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clnApproveImg.Width = 150;
            // 
            // clnApprove
            // 
            this.clnApprove.DataPropertyName = "Approve";
            this.clnApprove.HeaderText = "Approve";
            this.clnApprove.Name = "clnApprove";
            this.clnApprove.ReadOnly = true;
            this.clnApprove.Visible = false;
            // 
            // clnPlantCode
            // 
            this.clnPlantCode.DataPropertyName = "PlantCode";
            this.clnPlantCode.HeaderText = "PlantCode";
            this.clnPlantCode.Name = "clnPlantCode";
            this.clnPlantCode.ReadOnly = true;
            this.clnPlantCode.Visible = false;
            this.clnPlantCode.Width = 220;
            // 
            // clnQty
            // 
            this.clnQty.DataPropertyName = "Quantity";
            this.clnQty.HeaderText = "Qty";
            this.clnQty.Name = "clnQty";
            this.clnQty.ReadOnly = true;
            this.clnQty.Visible = false;
            // 
            // clnUnitName
            // 
            this.clnUnitName.DataPropertyName = "UnitName";
            this.clnUnitName.HeaderText = "Unit";
            this.clnUnitName.Name = "clnUnitName";
            this.clnUnitName.ReadOnly = true;
            this.clnUnitName.Visible = false;
            // 
            // clnBOMType
            // 
            this.clnBOMType.DataPropertyName = "BOMType";
            this.clnBOMType.HeaderText = "BOMType";
            this.clnBOMType.Name = "clnBOMType";
            this.clnBOMType.ReadOnly = true;
            this.clnBOMType.Visible = false;
            // 
            // frmBOMNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(898, 498);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pGradientPanel2);
            this.Controls.Add(this.pGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmBOMNew";
            this.Load += new System.EventHandler(this.frmBOMNew_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBOMNew_FormClosing);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).EndInit();
            this.gMaster.ResumeLayout(false);
            this.gMaster.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewVer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSetBOMType)).EndInit();
            this.pGradientPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox btnAdd;
        private System.Windows.Forms.PictureBox btnEdit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnExit;
        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel2;
        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel1;
        private System.Windows.Forms.PictureBox btnSetBOMType;
        private System.Windows.Forms.GroupBox gMaster;
        private System.Windows.Forms.ComboBox cbUnit;
        private System.Windows.Forms.ComboBox cbPlant;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAppr;
        private System.Windows.Forms.ToolStripMenuItem setComponentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ComboBox cbBOMType;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        public System.Windows.Forms.ComboBox cbMaterial;
        private System.Windows.Forms.PictureBox btnNewVer;
        private System.Windows.Forms.PictureBox btnReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.TextBox txtFor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnItemNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnBOMCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnMaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnMaterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPlantName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnVersion;
        private System.Windows.Forms.DataGridViewImageColumn clnApproveImg;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnApprove;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPlantCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnUnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnBOMType;

    }
}