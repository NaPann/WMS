namespace WMS.VendorTrans
{
    partial class frmVendorInfo
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
            this.clnVendorCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnVendorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnMaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnMaterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setPeriodsConditionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPG = new System.Windows.Forms.Label();
            this.cbOrderUnit = new System.Windows.Forms.ComboBox();
            this.txtQtyCovert = new System.Windows.Forms.TextBox();
            this.txtMaterialUnit = new System.Windows.Forms.TextBox();
            this.txtInfoUnit = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chkBlock = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMaterial = new System.Windows.Forms.ComboBox();
            this.cbVendor = new System.Windows.Forms.ComboBox();
            this.txtQtyCon = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNetPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMinQty = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDelivery = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.PictureBox();
            this.btnEdit = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSName = new System.Windows.Forms.TextBox();
            this.txtSCode = new System.Windows.Forms.TextBox();
            this.pGradientPanel2 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.pGradientPanel1 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.pOpcity = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).BeginInit();
            this.panel1.SuspendLayout();
            this.pGradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
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
            this.clnVendorCode,
            this.clnVendorName,
            this.clnMaterialCode,
            this.clnMaterialName});
            this.dgvView.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvView.Location = new System.Drawing.Point(373, 0);
            this.dgvView.MultiSelect = false;
            this.dgvView.Name = "dgvView";
            this.dgvView.ReadOnly = true;
            this.dgvView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvView.Size = new System.Drawing.Size(525, 382);
            this.dgvView.TabIndex = 3;
            // 
            // clnVendorCode
            // 
            this.clnVendorCode.DataPropertyName = "VendorCode";
            this.clnVendorCode.HeaderText = "V. Code";
            this.clnVendorCode.Name = "clnVendorCode";
            this.clnVendorCode.ReadOnly = true;
            // 
            // clnVendorName
            // 
            this.clnVendorName.DataPropertyName = "VendorName";
            this.clnVendorName.HeaderText = "Vendor";
            this.clnVendorName.Name = "clnVendorName";
            this.clnVendorName.ReadOnly = true;
            this.clnVendorName.Width = 150;
            // 
            // clnMaterialCode
            // 
            this.clnMaterialCode.DataPropertyName = "MaterialCode";
            this.clnMaterialCode.HeaderText = "M. Code";
            this.clnMaterialCode.Name = "clnMaterialCode";
            this.clnMaterialCode.ReadOnly = true;
            // 
            // clnMaterialName
            // 
            this.clnMaterialName.DataPropertyName = "MaterialName";
            this.clnMaterialName.HeaderText = "Material";
            this.clnMaterialName.Name = "clnMaterialName";
            this.clnMaterialName.ReadOnly = true;
            this.clnMaterialName.Width = 150;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setPeriodsConditionToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(189, 70);
            // 
            // setPeriodsConditionToolStripMenuItem
            // 
            this.setPeriodsConditionToolStripMenuItem.Image = global::WMS.Properties.Resources.scroll_add;
            this.setPeriodsConditionToolStripMenuItem.Name = "setPeriodsConditionToolStripMenuItem";
            this.setPeriodsConditionToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.setPeriodsConditionToolStripMenuItem.Text = "Set Periods Condition";
            this.setPeriodsConditionToolStripMenuItem.Click += new System.EventHandler(this.setPeriodsConditionToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::WMS.Properties.Resources.edit_2;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::WMS.Properties.Resources.error;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
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
            this.panel3.Size = new System.Drawing.Size(898, 382);
            this.panel3.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(373, 382);
            this.panel2.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPG);
            this.groupBox1.Controls.Add(this.cbOrderUnit);
            this.groupBox1.Controls.Add(this.txtQtyCovert);
            this.groupBox1.Controls.Add(this.txtMaterialUnit);
            this.groupBox1.Controls.Add(this.txtInfoUnit);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.chkBlock);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbMaterial);
            this.groupBox1.Controls.Add(this.cbVendor);
            this.groupBox1.Controls.Add(this.txtQtyCon);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtNetPrice);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtMinQty);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtDelivery);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(10, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 319);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detail";
            // 
            // lblPG
            // 
            this.lblPG.AutoSize = true;
            this.lblPG.Location = new System.Drawing.Point(133, 92);
            this.lblPG.Name = "lblPG";
            this.lblPG.Size = new System.Drawing.Size(0, 15);
            this.lblPG.TabIndex = 24;
            // 
            // cbOrderUnit
            // 
            this.cbOrderUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrderUnit.FormattingEnabled = true;
            this.cbOrderUnit.Location = new System.Drawing.Point(133, 195);
            this.cbOrderUnit.Name = "cbOrderUnit";
            this.cbOrderUnit.Size = new System.Drawing.Size(149, 23);
            this.cbOrderUnit.TabIndex = 6;
            this.cbOrderUnit.SelectedIndexChanged += new System.EventHandler(this.cbOrderUnit_SelectedIndexChanged);
            // 
            // txtQtyCovert
            // 
            this.txtQtyCovert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtQtyCovert.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQtyCovert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtQtyCovert.Location = new System.Drawing.Point(134, 224);
            this.txtQtyCovert.MaxLength = 18;
            this.txtQtyCovert.Name = "txtQtyCovert";
            this.txtQtyCovert.ReadOnly = true;
            this.txtQtyCovert.Size = new System.Drawing.Size(68, 21);
            this.txtQtyCovert.TabIndex = 7;
            this.txtQtyCovert.TabStop = false;
            this.txtQtyCovert.Text = "1";
            this.txtQtyCovert.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQtyCovert.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQtyCovert_KeyPress);
            // 
            // txtMaterialUnit
            // 
            this.txtMaterialUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMaterialUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtMaterialUnit.Location = new System.Drawing.Point(208, 250);
            this.txtMaterialUnit.MaxLength = 300;
            this.txtMaterialUnit.Name = "txtMaterialUnit";
            this.txtMaterialUnit.ReadOnly = true;
            this.txtMaterialUnit.Size = new System.Drawing.Size(74, 21);
            this.txtMaterialUnit.TabIndex = 10;
            this.txtMaterialUnit.TabStop = false;
            this.txtMaterialUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtInfoUnit
            // 
            this.txtInfoUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtInfoUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInfoUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtInfoUnit.Location = new System.Drawing.Point(208, 223);
            this.txtInfoUnit.MaxLength = 18;
            this.txtInfoUnit.Name = "txtInfoUnit";
            this.txtInfoUnit.ReadOnly = true;
            this.txtInfoUnit.Size = new System.Drawing.Size(74, 21);
            this.txtInfoUnit.TabIndex = 8;
            this.txtInfoUnit.TabStop = false;
            this.txtInfoUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(61, 198);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 15);
            this.label10.TabIndex = 21;
            this.label10.Text = "Order Unit :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(244, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 15);
            this.label9.TabIndex = 19;
            this.label9.Text = "Day(s)";
            // 
            // chkBlock
            // 
            this.chkBlock.AutoSize = true;
            this.chkBlock.Location = new System.Drawing.Point(134, 278);
            this.chkBlock.Name = "chkBlock";
            this.chkBlock.Size = new System.Drawing.Size(26, 19);
            this.chkBlock.TabIndex = 11;
            this.chkBlock.Text = "\r\n";
            this.chkBlock.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(90, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Block :";
            // 
            // cbMaterial
            // 
            this.cbMaterial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbMaterial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbMaterial.FormattingEnabled = true;
            this.cbMaterial.Location = new System.Drawing.Point(133, 59);
            this.cbMaterial.Name = "cbMaterial";
            this.cbMaterial.Size = new System.Drawing.Size(183, 23);
            this.cbMaterial.TabIndex = 1;
            this.cbMaterial.SelectedIndexChanged += new System.EventHandler(this.cbMatrial_SelectedIndexChanged);
            // 
            // cbVendor
            // 
            this.cbVendor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbVendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbVendor.FormattingEnabled = true;
            this.cbVendor.Location = new System.Drawing.Point(133, 30);
            this.cbVendor.Name = "cbVendor";
            this.cbVendor.Size = new System.Drawing.Size(183, 23);
            this.cbVendor.TabIndex = 0;
            this.cbVendor.SelectedIndexChanged += new System.EventHandler(this.cbVendor_SelectedIndexChanged);
            // 
            // txtQtyCon
            // 
            this.txtQtyCon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtQtyCon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQtyCon.ForeColor = System.Drawing.Color.Black;
            this.txtQtyCon.Location = new System.Drawing.Point(134, 251);
            this.txtQtyCon.MaxLength = 18;
            this.txtQtyCon.Name = "txtQtyCon";
            this.txtQtyCon.Size = new System.Drawing.Size(68, 21);
            this.txtQtyCon.TabIndex = 9;
            this.txtQtyCon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQtyCon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQtyCon_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(42, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Qty. Conversion :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(20, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Purchasing group :";
            // 
            // txtNetPrice
            // 
            this.txtNetPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtNetPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNetPrice.Location = new System.Drawing.Point(133, 169);
            this.txtNetPrice.MaxLength = 18;
            this.txtNetPrice.Name = "txtNetPrice";
            this.txtNetPrice.Size = new System.Drawing.Size(109, 21);
            this.txtNetPrice.TabIndex = 5;
            this.txtNetPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNetPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNetPrice_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(67, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Net Price :";
            // 
            // txtMinQty
            // 
            this.txtMinQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtMinQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinQty.Location = new System.Drawing.Point(133, 144);
            this.txtMinQty.MaxLength = 21;
            this.txtMinQty.Name = "txtMinQty";
            this.txtMinQty.Size = new System.Drawing.Size(109, 21);
            this.txtMinQty.TabIndex = 4;
            this.txtMinQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMinQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMinQty_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(41, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Minimum Qty. :";
            // 
            // txtDelivery
            // 
            this.txtDelivery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtDelivery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDelivery.Location = new System.Drawing.Point(133, 117);
            this.txtDelivery.MaxLength = 18;
            this.txtDelivery.Name = "txtDelivery";
            this.txtDelivery.Size = new System.Drawing.Size(109, 21);
            this.txtDelivery.TabIndex = 3;
            this.txtDelivery.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDelivery.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDelivery_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(58, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Lead Time :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(72, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Material :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(81, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vendor :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::WMS.Properties.Resources.navigate_down2;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(284, 234);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 28);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAdd);
            this.flowLayoutPanel1.Controls.Add(this.btnEdit);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(261, 344);
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
            this.panel1.Controls.Add(this.txtSName);
            this.panel1.Controls.Add(this.txtSCode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(898, 31);
            this.panel1.TabIndex = 13;
            // 
            // txtSName
            // 
            this.txtSName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtSName.Location = new System.Drawing.Point(663, 7);
            this.txtSName.MaxLength = 60;
            this.txtSName.Name = "txtSName";
            this.txtSName.Size = new System.Drawing.Size(102, 22);
            this.txtSName.TabIndex = 1;
            this.txtSName.TextChanged += new System.EventHandler(this.txtSName_TextChanged);
            // 
            // txtSCode
            // 
            this.txtSCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtSCode.Location = new System.Drawing.Point(416, 7);
            this.txtSCode.MaxLength = 10;
            this.txtSCode.Name = "txtSCode";
            this.txtSCode.Size = new System.Drawing.Size(99, 22);
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
            this.pGradientPanel1.Caption = "Vendor Info Record ..";
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
            // pOpcity
            // 
            this.pOpcity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pOpcity.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pOpcity.Location = new System.Drawing.Point(0, 0);
            this.pOpcity.Name = "pOpcity";
            this.pOpcity.Size = new System.Drawing.Size(900, 500);
            this.pOpcity.TabIndex = 2;
            // 
            // frmVendorInfo
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
            this.Controls.Add(this.pOpcity);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmVendorInfo";
            this.Load += new System.EventHandler(this.frmVendorInfo_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVendorInfo_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.TextBox txtQtyCon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNetPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDelivery;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox btnEdit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSName;
        private System.Windows.Forms.TextBox txtSCode;
        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel2;
        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel1;
        private System.Windows.Forms.ComboBox cbVendor;
        private System.Windows.Forms.ComboBox cbMaterial;
        private System.Windows.Forms.CheckBox chkBlock;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMinQty;
        private System.Windows.Forms.Panel pOpcity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtInfoUnit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtQtyCovert;
        private System.Windows.Forms.TextBox txtMaterialUnit;
        private System.Windows.Forms.ComboBox cbOrderUnit;
        private System.Windows.Forms.ToolStripMenuItem setPeriodsConditionToolStripMenuItem;
        private System.Windows.Forms.Label lblPG;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnVendorCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnVendorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnMaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnMaterialName;

    }
}