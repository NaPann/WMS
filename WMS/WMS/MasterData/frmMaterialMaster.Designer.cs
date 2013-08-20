namespace WMS.MasterData
{
    partial class frmMaterialMaster
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtStandardCost = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtProcureType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbLoc = new System.Windows.Forms.ComboBox();
            this.cbPlant = new System.Windows.Forms.ComboBox();
            this.cbMT = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCustProduct = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMovAvg = new System.Windows.Forms.TextBox();
            this.txtShelfLife = new System.Windows.Forms.TextBox();
            this.txtInHouse = new System.Windows.Forms.TextBox();
            this.txtDelivery = new System.Windows.Forms.TextBox();
            this.txtGR = new System.Windows.Forms.TextBox();
            this.cbMaterialGroup = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbUnit = new System.Windows.Forms.ComboBox();
            this.txtChemicalName = new System.Windows.Forms.TextBox();
            this.lblChem = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.PictureBox();
            this.btnEdit = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSetMaterialType = new System.Windows.Forms.PictureBox();
            this.txtSName = new System.Windows.Forms.TextBox();
            this.txtSCode = new System.Windows.Forms.TextBox();
            this.pGradientPanel2 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.pGradientPanel1 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.clnCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSetMaterialType)).BeginInit();
            this.pGradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvView
            // 
            this.dgvView.AllowUserToAddRows = false;
            this.dgvView.AllowUserToDeleteRows = false;
            this.dgvView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnCode,
            this.clnName});
            this.dgvView.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvView.Location = new System.Drawing.Point(344, 0);
            this.dgvView.MultiSelect = false;
            this.dgvView.Name = "dgvView";
            this.dgvView.ReadOnly = true;
            this.dgvView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvView.Size = new System.Drawing.Size(554, 570);
            this.dgvView.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 48);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::WMS.Properties.Resources.edit_2;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::WMS.Properties.Resources.error;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
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
            this.panel3.Size = new System.Drawing.Size(898, 570);
            this.panel3.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(344, 570);
            this.panel2.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtStandardCost);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtProcureType);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbLoc);
            this.groupBox1.Controls.Add(this.cbPlant);
            this.groupBox1.Controls.Add(this.cbMT);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCustProduct);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtMovAvg);
            this.groupBox1.Controls.Add(this.txtShelfLife);
            this.groupBox1.Controls.Add(this.txtInHouse);
            this.groupBox1.Controls.Add(this.txtDelivery);
            this.groupBox1.Controls.Add(this.txtGR);
            this.groupBox1.Controls.Add(this.cbMaterialGroup);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cbUnit);
            this.groupBox1.Controls.Add(this.txtChemicalName);
            this.groupBox1.Controls.Add(this.lblChem);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(10, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 512);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detail";
            // 
            // txtStandardCost
            // 
            this.txtStandardCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtStandardCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStandardCost.Location = new System.Drawing.Point(133, 479);
            this.txtStandardCost.MaxLength = 10;
            this.txtStandardCost.Name = "txtStandardCost";
            this.txtStandardCost.Size = new System.Drawing.Size(171, 21);
            this.txtStandardCost.TabIndex = 15;
            this.txtStandardCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtStandardCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMovAvg_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 481);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 15);
            this.label7.TabIndex = 38;
            this.label7.Text = "Standard Cost :";
            // 
            // txtProcureType
            // 
            this.txtProcureType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtProcureType.FormattingEnabled = true;
            this.txtProcureType.Items.AddRange(new object[] {
            "E",
            "F"});
            this.txtProcureType.Location = new System.Drawing.Point(134, 266);
            this.txtProcureType.Name = "txtProcureType";
            this.txtProcureType.Size = new System.Drawing.Size(121, 23);
            this.txtProcureType.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(68, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "Location :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(87, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 35;
            this.label3.Text = "Plant :";
            // 
            // cbLoc
            // 
            this.cbLoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoc.FormattingEnabled = true;
            this.cbLoc.Location = new System.Drawing.Point(133, 234);
            this.cbLoc.Name = "cbLoc";
            this.cbLoc.Size = new System.Drawing.Size(171, 23);
            this.cbLoc.TabIndex = 7;
            // 
            // cbPlant
            // 
            this.cbPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlant.FormattingEnabled = true;
            this.cbPlant.Location = new System.Drawing.Point(133, 205);
            this.cbPlant.Name = "cbPlant";
            this.cbPlant.Size = new System.Drawing.Size(171, 23);
            this.cbPlant.TabIndex = 6;
            // 
            // cbMT
            // 
            this.cbMT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMT.FormattingEnabled = true;
            this.cbMT.Location = new System.Drawing.Point(133, 144);
            this.cbMT.Name = "cbMT";
            this.cbMT.Size = new System.Drawing.Size(171, 23);
            this.cbMT.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(44, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 33;
            this.label5.Text = "Material Type :";
            // 
            // txtCustProduct
            // 
            this.txtCustProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustProduct.Location = new System.Drawing.Point(133, 298);
            this.txtCustProduct.MaxLength = 15;
            this.txtCustProduct.Name = "txtCustProduct";
            this.txtCustProduct.Size = new System.Drawing.Size(171, 21);
            this.txtCustProduct.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 15);
            this.label4.TabIndex = 31;
            this.label4.Text = "Customer Item Code :";
            // 
            // txtMovAvg
            // 
            this.txtMovAvg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtMovAvg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMovAvg.Location = new System.Drawing.Point(133, 452);
            this.txtMovAvg.MaxLength = 10;
            this.txtMovAvg.Name = "txtMovAvg";
            this.txtMovAvg.Size = new System.Drawing.Size(171, 21);
            this.txtMovAvg.TabIndex = 14;
            this.txtMovAvg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMovAvg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMovAvg_KeyPress);
            // 
            // txtShelfLife
            // 
            this.txtShelfLife.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtShelfLife.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShelfLife.Location = new System.Drawing.Point(133, 421);
            this.txtShelfLife.MaxLength = 10;
            this.txtShelfLife.Name = "txtShelfLife";
            this.txtShelfLife.Size = new System.Drawing.Size(171, 21);
            this.txtShelfLife.TabIndex = 13;
            this.txtShelfLife.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtShelfLife.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtShelfLife_KeyPress);
            // 
            // txtInHouse
            // 
            this.txtInHouse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtInHouse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInHouse.Location = new System.Drawing.Point(133, 390);
            this.txtInHouse.MaxLength = 10;
            this.txtInHouse.Name = "txtInHouse";
            this.txtInHouse.Size = new System.Drawing.Size(171, 21);
            this.txtInHouse.TabIndex = 12;
            this.txtInHouse.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInHouse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInHouse_KeyPress);
            // 
            // txtDelivery
            // 
            this.txtDelivery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtDelivery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDelivery.Location = new System.Drawing.Point(133, 359);
            this.txtDelivery.MaxLength = 10;
            this.txtDelivery.Name = "txtDelivery";
            this.txtDelivery.Size = new System.Drawing.Size(171, 21);
            this.txtDelivery.TabIndex = 11;
            this.txtDelivery.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDelivery.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDelivery_KeyPress);
            // 
            // txtGR
            // 
            this.txtGR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtGR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGR.Location = new System.Drawing.Point(133, 328);
            this.txtGR.MaxLength = 10;
            this.txtGR.Name = "txtGR";
            this.txtGR.Size = new System.Drawing.Size(171, 21);
            this.txtGR.TabIndex = 10;
            this.txtGR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGR_KeyPress);
            // 
            // cbMaterialGroup
            // 
            this.cbMaterialGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaterialGroup.FormattingEnabled = true;
            this.cbMaterialGroup.Location = new System.Drawing.Point(133, 112);
            this.cbMaterialGroup.Name = "cbMaterialGroup";
            this.cbMaterialGroup.Size = new System.Drawing.Size(171, 23);
            this.cbMaterialGroup.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 392);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(125, 15);
            this.label16.TabIndex = 23;
            this.label16.Text = "In-House Production :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(67, 423);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 15);
            this.label15.TabIndex = 22;
            this.label15.Text = "Shelf Life :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(62, 454);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 15);
            this.label14.TabIndex = 21;
            this.label14.Text = "Sale Price :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(59, 361);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 15);
            this.label12.TabIndex = 20;
            this.label12.Text = "Lead Time :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(36, 115);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 15);
            this.label13.TabIndex = 19;
            this.label13.Text = "Material Group :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(64, 179);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 15);
            this.label11.TabIndex = 17;
            this.label11.Text = "Base unit :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(15, 270);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 15);
            this.label10.TabIndex = 16;
            this.label10.Text = "Procurement Type :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 330);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "GR Processing Time :";
            // 
            // cbUnit
            // 
            this.cbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnit.FormattingEnabled = true;
            this.cbUnit.Location = new System.Drawing.Point(133, 176);
            this.cbUnit.Name = "cbUnit";
            this.cbUnit.Size = new System.Drawing.Size(171, 23);
            this.cbUnit.TabIndex = 5;
            // 
            // txtChemicalName
            // 
            this.txtChemicalName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChemicalName.Location = new System.Drawing.Point(133, 83);
            this.txtChemicalName.MaxLength = 60;
            this.txtChemicalName.Name = "txtChemicalName";
            this.txtChemicalName.Size = new System.Drawing.Size(171, 21);
            this.txtChemicalName.TabIndex = 2;
            this.txtChemicalName.Visible = false;
            // 
            // lblChem
            // 
            this.lblChem.AutoSize = true;
            this.lblChem.Location = new System.Drawing.Point(29, 85);
            this.lblChem.Name = "lblChem";
            this.lblChem.Size = new System.Drawing.Size(102, 15);
            this.lblChem.TabIndex = 4;
            this.lblChem.Text = "Chemical Name :";
            this.lblChem.Visible = false;
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(133, 52);
            this.txtName.MaxLength = 60;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(171, 21);
            this.txtName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(84, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name :";
            // 
            // txtCode
            // 
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Location = new System.Drawing.Point(133, 21);
            this.txtCode.MaxLength = 15;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(171, 21);
            this.txtCode.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(89, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Code :";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAdd);
            this.flowLayoutPanel1.Controls.Add(this.btnEdit);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(236, 521);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSetMaterialType);
            this.panel1.Controls.Add(this.txtSName);
            this.panel1.Controls.Add(this.txtSCode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(898, 31);
            this.panel1.TabIndex = 13;
            // 
            // btnSetMaterialType
            // 
            this.btnSetMaterialType.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSetMaterialType.BackgroundImage = global::WMS.Properties.Resources.SetMaterialType;
            this.btnSetMaterialType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSetMaterialType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetMaterialType.Location = new System.Drawing.Point(750, 1);
            this.btnSetMaterialType.Name = "btnSetMaterialType";
            this.btnSetMaterialType.Size = new System.Drawing.Size(146, 30);
            this.btnSetMaterialType.TabIndex = 1;
            this.btnSetMaterialType.TabStop = false;
            this.btnSetMaterialType.Click += new System.EventHandler(this.btnSetMaterialType_Click);
            // 
            // txtSName
            // 
            this.txtSName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtSName.Location = new System.Drawing.Point(533, 7);
            this.txtSName.MaxLength = 500;
            this.txtSName.Name = "txtSName";
            this.txtSName.Size = new System.Drawing.Size(303, 22);
            this.txtSName.TabIndex = 1;
            this.txtSName.TextChanged += new System.EventHandler(this.txtSName_TextChanged);
            // 
            // txtSCode
            // 
            this.txtSCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtSCode.Location = new System.Drawing.Point(385, 7);
            this.txtSCode.MaxLength = 15;
            this.txtSCode.Name = "txtSCode";
            this.txtSCode.Size = new System.Drawing.Size(149, 22);
            this.txtSCode.TabIndex = 0;
            this.txtSCode.TextChanged += new System.EventHandler(this.txtSCode_TextChanged);
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
            this.pGradientPanel2.Location = new System.Drawing.Point(0, 651);
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
            this.pGradientPanel1.Caption = "Material Master";
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
            // clnCode
            // 
            this.clnCode.DataPropertyName = "MaterialCode";
            this.clnCode.HeaderText = "Code";
            this.clnCode.Name = "clnCode";
            this.clnCode.ReadOnly = true;
            this.clnCode.Width = 150;
            // 
            // clnName
            // 
            this.clnName.DataPropertyName = "MaterialName";
            this.clnName.HeaderText = "Name";
            this.clnName.Name = "clnName";
            this.clnName.ReadOnly = true;
            this.clnName.Width = 300;
            // 
            // frmMaterialMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(898, 686);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pGradientPanel2);
            this.Controls.Add(this.pGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMaterialMaster";
            this.Load += new System.EventHandler(this.frmMaterialMaster_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMaterialMaster_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSetMaterialType)).EndInit();
            this.pGradientPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtChemicalName;
        private System.Windows.Forms.Label lblChem;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox btnEdit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSName;
        private System.Windows.Forms.TextBox txtSCode;
        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel2;
        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbUnit;
        private System.Windows.Forms.TextBox txtMovAvg;
        private System.Windows.Forms.TextBox txtShelfLife;
        private System.Windows.Forms.TextBox txtInHouse;
        private System.Windows.Forms.TextBox txtDelivery;
        private System.Windows.Forms.TextBox txtGR;
        private System.Windows.Forms.ComboBox cbMaterialGroup;
        private System.Windows.Forms.TextBox txtCustProduct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbMT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox btnSetMaterialType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbLoc;
        private System.Windows.Forms.ComboBox cbPlant;
        private System.Windows.Forms.ComboBox txtProcureType;
        private System.Windows.Forms.TextBox txtStandardCost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnName;
    }
}