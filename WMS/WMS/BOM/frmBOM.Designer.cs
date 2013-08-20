namespace WMS.BOM
{
    partial class frmBOM
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
            this.dgvView = new System.Windows.Forms.DataGridView();
            this.clnCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnAppr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnComponent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnComponentDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnBOMCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnBOMDetailCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnVer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnApprove = new System.Windows.Forms.PictureBox();
            this.btnDelAll = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbComponent = new System.Windows.Forms.ComboBox();
            this.txtQtyComp = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblRemain = new System.Windows.Forms.Label();
            this.gMaster = new System.Windows.Forms.GroupBox();
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.PictureBox();
            this.btnEdit = new System.Windows.Forms.PictureBox();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVersion = new System.Windows.Forms.PictureBox();
            this.btnSetBOMType = new System.Windows.Forms.PictureBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.pGradientPanel2 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.pGradientPanel1 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnVerAppr = new System.Windows.Forms.PictureBox();
            this.btnVerNot = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnApprove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelAll)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.gMaster.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnVersion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSetBOMType)).BeginInit();
            this.pGradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.pGradientPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnVerAppr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVerNot)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvView
            // 
            this.dgvView.AllowUserToAddRows = false;
            this.dgvView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnCode,
            this.clnAppr,
            this.clnCategory,
            this.clnComponent,
            this.clnComponentDesc,
            this.clnQty,
            this.clnUnit,
            this.clnBOMCode,
            this.clnBOMDetailCode,
            this.clnVer});
            this.dgvView.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvView.Location = new System.Drawing.Point(0, 200);
            this.dgvView.MultiSelect = false;
            this.dgvView.Name = "dgvView";
            this.dgvView.ReadOnly = true;
            this.dgvView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvView.Size = new System.Drawing.Size(898, 282);
            this.dgvView.TabIndex = 3;
            // 
            // clnCode
            // 
            this.clnCode.DataPropertyName = "ItemNo";
            this.clnCode.HeaderText = "Item.";
            this.clnCode.Name = "clnCode";
            this.clnCode.ReadOnly = true;
            this.clnCode.Width = 60;
            // 
            // clnAppr
            // 
            this.clnAppr.DataPropertyName = "Approve";
            this.clnAppr.HeaderText = "Approve";
            this.clnAppr.Name = "clnAppr";
            this.clnAppr.ReadOnly = true;
            this.clnAppr.Visible = false;
            // 
            // clnCategory
            // 
            this.clnCategory.DataPropertyName = "Category";
            this.clnCategory.HeaderText = "Category";
            this.clnCategory.Name = "clnCategory";
            this.clnCategory.ReadOnly = true;
            // 
            // clnComponent
            // 
            this.clnComponent.DataPropertyName = "MaterialCode";
            this.clnComponent.HeaderText = "Component";
            this.clnComponent.Name = "clnComponent";
            this.clnComponent.ReadOnly = true;
            this.clnComponent.Width = 170;
            // 
            // clnComponentDesc
            // 
            this.clnComponentDesc.DataPropertyName = "MaterialName";
            this.clnComponentDesc.HeaderText = "Component Description";
            this.clnComponentDesc.Name = "clnComponentDesc";
            this.clnComponentDesc.ReadOnly = true;
            this.clnComponentDesc.Width = 250;
            // 
            // clnQty
            // 
            this.clnQty.DataPropertyName = "Quantity";
            this.clnQty.HeaderText = "Qty.";
            this.clnQty.Name = "clnQty";
            this.clnQty.ReadOnly = true;
            // 
            // clnUnit
            // 
            this.clnUnit.DataPropertyName = "UnitName";
            this.clnUnit.HeaderText = "Unit";
            this.clnUnit.Name = "clnUnit";
            this.clnUnit.ReadOnly = true;
            // 
            // clnBOMCode
            // 
            this.clnBOMCode.DataPropertyName = "BOMCode";
            this.clnBOMCode.HeaderText = "BOMCode";
            this.clnBOMCode.Name = "clnBOMCode";
            this.clnBOMCode.ReadOnly = true;
            this.clnBOMCode.Visible = false;
            // 
            // clnBOMDetailCode
            // 
            this.clnBOMDetailCode.DataPropertyName = "BOMDetailCode";
            this.clnBOMDetailCode.HeaderText = "BOMDetailCode";
            this.clnBOMDetailCode.Name = "clnBOMDetailCode";
            this.clnBOMDetailCode.ReadOnly = true;
            this.clnBOMDetailCode.Visible = false;
            // 
            // clnVer
            // 
            this.clnVer.DataPropertyName = "BOMVersion";
            this.clnVer.HeaderText = "Ver";
            this.clnVer.Name = "clnVer";
            this.clnVer.ReadOnly = true;
            this.clnVer.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::WMS.Properties.Resources.edit_2;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::WMS.Properties.Resources.error;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvView);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 81);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(898, 482);
            this.panel3.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnApprove);
            this.panel2.Controls.Add(this.btnDelAll);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.gMaster);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(898, 200);
            this.panel2.TabIndex = 4;
            // 
            // btnApprove
            // 
            this.btnApprove.BackgroundImage = global::WMS.Properties.Resources.Approve;
            this.btnApprove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnApprove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApprove.Location = new System.Drawing.Point(478, 119);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(106, 29);
            this.btnApprove.TabIndex = 17;
            this.btnApprove.TabStop = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnDelAll
            // 
            this.btnDelAll.BackgroundImage = global::WMS.Properties.Resources.DelAll;
            this.btnDelAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDelAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelAll.Location = new System.Drawing.Point(768, 119);
            this.btnDelAll.Name = "btnDelAll";
            this.btnDelAll.Size = new System.Drawing.Size(94, 29);
            this.btnDelAll.TabIndex = 15;
            this.btnDelAll.TabStop = false;
            this.btnDelAll.Click += new System.EventHandler(this.btnDelAll_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbComponent);
            this.groupBox2.Controls.Add(this.txtQtyComp);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lblRemain);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox2.Location = new System.Drawing.Point(478, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(384, 96);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detail";
            // 
            // cbComponent
            // 
            this.cbComponent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbComponent.FormattingEnabled = true;
            this.cbComponent.Location = new System.Drawing.Point(160, 23);
            this.cbComponent.Name = "cbComponent";
            this.cbComponent.Size = new System.Drawing.Size(183, 24);
            this.cbComponent.TabIndex = 0;
            // 
            // txtQtyComp
            // 
            this.txtQtyComp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtQtyComp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQtyComp.Location = new System.Drawing.Point(160, 53);
            this.txtQtyComp.MaxLength = 20;
            this.txtQtyComp.Name = "txtQtyComp";
            this.txtQtyComp.Size = new System.Drawing.Size(84, 22);
            this.txtQtyComp.TabIndex = 1;
            this.txtQtyComp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQtyComp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQtyComp_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(34, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Qty of Component :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(71, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "Component :";
            // 
            // lblRemain
            // 
            this.lblRemain.AutoSize = true;
            this.lblRemain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblRemain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblRemain.Location = new System.Drawing.Point(252, 57);
            this.lblRemain.Name = "lblRemain";
            this.lblRemain.Size = new System.Drawing.Size(54, 15);
            this.lblRemain.TabIndex = 11;
            this.lblRemain.Text = "Remain:";
            // 
            // gMaster
            // 
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
            this.gMaster.Location = new System.Drawing.Point(13, 6);
            this.gMaster.Name = "gMaster";
            this.gMaster.Size = new System.Drawing.Size(384, 180);
            this.gMaster.TabIndex = 0;
            this.gMaster.TabStop = false;
            // 
            // cbBOMType
            // 
            this.cbBOMType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBOMType.FormattingEnabled = true;
            this.cbBOMType.Location = new System.Drawing.Point(141, 80);
            this.cbBOMType.Name = "cbBOMType";
            this.cbBOMType.Size = new System.Drawing.Size(183, 24);
            this.cbBOMType.TabIndex = 2;
            this.cbBOMType.SelectedIndexChanged += new System.EventHandler(this.cbBOMType_SelectedIndexChanged);
            // 
            // cbUnit
            // 
            this.cbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnit.FormattingEnabled = true;
            this.cbUnit.Location = new System.Drawing.Point(141, 110);
            this.cbUnit.Name = "cbUnit";
            this.cbUnit.Size = new System.Drawing.Size(183, 24);
            this.cbUnit.TabIndex = 3;
            // 
            // cbPlant
            // 
            this.cbPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlant.FormattingEnabled = true;
            this.cbPlant.Location = new System.Drawing.Point(141, 50);
            this.cbPlant.Name = "cbPlant";
            this.cbPlant.Size = new System.Drawing.Size(183, 24);
            this.cbPlant.TabIndex = 1;
            this.cbPlant.SelectedIndexChanged += new System.EventHandler(this.cbPlant_SelectedIndexChanged);
            // 
            // cbMaterial
            // 
            this.cbMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaterial.FormattingEnabled = true;
            this.cbMaterial.Location = new System.Drawing.Point(141, 20);
            this.cbMaterial.Name = "cbMaterial";
            this.cbMaterial.Size = new System.Drawing.Size(183, 24);
            this.cbMaterial.TabIndex = 0;
            this.cbMaterial.SelectedIndexChanged += new System.EventHandler(this.cbMaterial_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(96, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Unit :";
            // 
            // txtQty
            // 
            this.txtQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQty.Location = new System.Drawing.Point(141, 142);
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
            this.label6.Location = new System.Drawing.Point(71, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Quantity :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(48, 83);
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
            this.label2.Location = new System.Drawing.Point(89, 53);
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
            this.label1.Location = new System.Drawing.Point(69, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Material :";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAdd);
            this.flowLayoutPanel1.Controls.Add(this.btnEdit);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(670, 116);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(92, 38);
            this.flowLayoutPanel1.TabIndex = 6;
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
            // txtVersion
            // 
            this.txtVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtVersion.Location = new System.Drawing.Point(66, 4);
            this.txtVersion.MaxLength = 20;
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.ReadOnly = true;
            this.txtVersion.Size = new System.Drawing.Size(68, 22);
            this.txtVersion.TabIndex = 5;
            this.txtVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(7, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Version :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnVersion);
            this.panel1.Controls.Add(this.btnSetBOMType);
            this.panel1.Controls.Add(this.lblCode);
            this.panel1.Controls.Add(this.txtVersion);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(898, 31);
            this.panel1.TabIndex = 13;
            // 
            // btnVersion
            // 
            this.btnVersion.BackgroundImage = global::WMS.Properties.Resources.NewVersion;
            this.btnVersion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVersion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVersion.Location = new System.Drawing.Point(139, 2);
            this.btnVersion.Name = "btnVersion";
            this.btnVersion.Size = new System.Drawing.Size(116, 28);
            this.btnVersion.TabIndex = 20;
            this.btnVersion.TabStop = false;
            this.btnVersion.Visible = false;
            this.btnVersion.Click += new System.EventHandler(this.btnVersion_Click);
            // 
            // btnSetBOMType
            // 
            this.btnSetBOMType.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSetBOMType.BackgroundImage = global::WMS.Properties.Resources.SetBOMType;
            this.btnSetBOMType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSetBOMType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetBOMType.Location = new System.Drawing.Point(766, 2);
            this.btnSetBOMType.Name = "btnSetBOMType";
            this.btnSetBOMType.Size = new System.Drawing.Size(131, 28);
            this.btnSetBOMType.TabIndex = 0;
            this.btnSetBOMType.TabStop = false;
            this.btnSetBOMType.Click += new System.EventHandler(this.btnSetBOMType_Click);
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(723, 9);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(35, 13);
            this.lblCode.TabIndex = 16;
            this.lblCode.Text = "label3";
            this.lblCode.Visible = false;
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
            this.pGradientPanel1.Controls.Add(this.flowLayoutPanel3);
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
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.flowLayoutPanel3.Controls.Add(this.btnVerAppr);
            this.flowLayoutPanel3.Controls.Add(this.btnVerNot);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(750, -3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel3.Size = new System.Drawing.Size(148, 31);
            this.flowLayoutPanel3.TabIndex = 19;
            // 
            // btnVerAppr
            // 
            this.btnVerAppr.BackgroundImage = global::WMS.Properties.Resources.VerAp;
            this.btnVerAppr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVerAppr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerAppr.Location = new System.Drawing.Point(3, 3);
            this.btnVerAppr.Name = "btnVerAppr";
            this.btnVerAppr.Size = new System.Drawing.Size(142, 29);
            this.btnVerAppr.TabIndex = 18;
            this.btnVerAppr.TabStop = false;
            this.btnVerAppr.Visible = false;
            // 
            // btnVerNot
            // 
            this.btnVerNot.BackgroundImage = global::WMS.Properties.Resources.NotAppr;
            this.btnVerNot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVerNot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerNot.Location = new System.Drawing.Point(3, 38);
            this.btnVerNot.Name = "btnVerNot";
            this.btnVerNot.Size = new System.Drawing.Size(142, 29);
            this.btnVerNot.TabIndex = 19;
            this.btnVerNot.TabStop = false;
            // 
            // frmBOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(898, 598);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pGradientPanel2);
            this.Controls.Add(this.pGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmBOM";
            this.Load += new System.EventHandler(this.frmBOM_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBOM_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnApprove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelAll)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gMaster.ResumeLayout(false);
            this.gMaster.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnVersion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSetBOMType)).EndInit();
            this.pGradientPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.pGradientPanel1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnVerAppr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVerNot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox btnExit;
        private System.Windows.Forms.DataGridView dgvView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.PictureBox btnAdd;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox gMaster;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox btnEdit;
        private System.Windows.Forms.Panel panel1;
        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel2;
        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel1;
        private System.Windows.Forms.ComboBox cbMaterial;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbPlant;
        private System.Windows.Forms.ComboBox cbUnit;
        private System.Windows.Forms.PictureBox btnSetBOMType;
        private System.Windows.Forms.ComboBox cbBOMType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbComponent;
        private System.Windows.Forms.TextBox txtQtyComp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox btnDelAll;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblRemain;
        private System.Windows.Forms.PictureBox btnApprove;
        private System.Windows.Forms.PictureBox btnVerAppr;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.PictureBox btnVerNot;
        private System.Windows.Forms.PictureBox btnVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnAppr;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnComponent;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnComponentDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnBOMCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnBOMDetailCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnVer;
    }
}