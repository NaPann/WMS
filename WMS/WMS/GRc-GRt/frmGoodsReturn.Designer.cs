namespace WMS.GRc_GRt
{
    partial class frmGoodsReturn
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.delToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvView = new System.Windows.Forms.DataGridView();
            this.clnItemNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnMaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnMaterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnUnitCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPlantCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnLocCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnBatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnDeliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPONumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnNetPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPlantName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnLocName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnAutoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pGradientPanel1 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.groupPR = new System.Windows.Forms.GroupBox();
            this.txtInv = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblVendorName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbVendor = new System.Windows.Forms.ComboBox();
            this.lblPG = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDocDate = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddPR = new System.Windows.Forms.PictureBox();
            this.btnCancelPR = new System.Windows.Forms.PictureBox();
            this.lblMovType = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.PictureBox();
            this.cbPONumber = new System.Windows.Forms.ComboBox();
            this.pGradientPanel2 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.btnSave = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.btnGenNew = new System.Windows.Forms.PictureBox();
            this.btnRefresh = new System.Windows.Forms.PictureBox();
            this.txtDoc = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.groupPR.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddPR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelPR)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).BeginInit();
            this.pGradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.delToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 26);
            // 
            // delToolStripMenuItem
            // 
            this.delToolStripMenuItem.Image = global::WMS.Properties.Resources.edit_2;
            this.delToolStripMenuItem.Name = "delToolStripMenuItem";
            this.delToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.delToolStripMenuItem.Text = "Set Quantity 0";
            this.delToolStripMenuItem.Click += new System.EventHandler(this.delToolStripMenuItem_Click);
            // 
            // dgvView
            // 
            this.dgvView.AllowUserToAddRows = false;
            this.dgvView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnItemNo,
            this.clnMaterialCode,
            this.clnMaterialName,
            this.clnQuantity,
            this.clnUnitName,
            this.clnUnitCode,
            this.clnPlantCode,
            this.clnLocCode,
            this.clnBatch,
            this.clnDeliveryDate,
            this.clnPONumber,
            this.clnNetPrice,
            this.clnAmount,
            this.clnPlantName,
            this.clnLocName,
            this.clnAutoID});
            this.dgvView.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvView.Location = new System.Drawing.Point(0, 264);
            this.dgvView.MultiSelect = false;
            this.dgvView.Name = "dgvView";
            this.dgvView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvView.Size = new System.Drawing.Size(683, 256);
            this.dgvView.TabIndex = 36;
            this.dgvView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvView_CellEndEdit);
            this.dgvView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvView_EditingControlShowing);
            // 
            // clnItemNo
            // 
            this.clnItemNo.DataPropertyName = "ItemNo";
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = "0";
            this.clnItemNo.DefaultCellStyle = dataGridViewCellStyle8;
            this.clnItemNo.HeaderText = "Item";
            this.clnItemNo.Name = "clnItemNo";
            this.clnItemNo.ReadOnly = true;
            this.clnItemNo.Width = 50;
            // 
            // clnMaterialCode
            // 
            this.clnMaterialCode.DataPropertyName = "MaterialCode";
            this.clnMaterialCode.HeaderText = "Material Code";
            this.clnMaterialCode.Name = "clnMaterialCode";
            this.clnMaterialCode.ReadOnly = true;
            this.clnMaterialCode.Width = 150;
            // 
            // clnMaterialName
            // 
            this.clnMaterialName.DataPropertyName = "MaterialName";
            this.clnMaterialName.HeaderText = "Description";
            this.clnMaterialName.Name = "clnMaterialName";
            this.clnMaterialName.ReadOnly = true;
            this.clnMaterialName.Width = 140;
            // 
            // clnQuantity
            // 
            this.clnQuantity.DataPropertyName = "GTQty";
            this.clnQuantity.HeaderText = "Quantity";
            this.clnQuantity.Name = "clnQuantity";
            // 
            // clnUnitName
            // 
            this.clnUnitName.DataPropertyName = "UnitName";
            this.clnUnitName.HeaderText = "Unit";
            this.clnUnitName.Name = "clnUnitName";
            this.clnUnitName.ReadOnly = true;
            this.clnUnitName.Width = 85;
            // 
            // clnUnitCode
            // 
            this.clnUnitCode.DataPropertyName = "UnitCode";
            this.clnUnitCode.HeaderText = "UnitCode";
            this.clnUnitCode.Name = "clnUnitCode";
            this.clnUnitCode.ReadOnly = true;
            this.clnUnitCode.Visible = false;
            // 
            // clnPlantCode
            // 
            this.clnPlantCode.DataPropertyName = "PlantCode";
            this.clnPlantCode.HeaderText = "Plant";
            this.clnPlantCode.Name = "clnPlantCode";
            this.clnPlantCode.ReadOnly = true;
            // 
            // clnLocCode
            // 
            this.clnLocCode.DataPropertyName = "LocCode";
            this.clnLocCode.HeaderText = "Location";
            this.clnLocCode.Name = "clnLocCode";
            this.clnLocCode.ReadOnly = true;
            // 
            // clnBatch
            // 
            this.clnBatch.DataPropertyName = "BatchNumber";
            this.clnBatch.HeaderText = "Batch";
            this.clnBatch.Name = "clnBatch";
            this.clnBatch.ReadOnly = true;
            // 
            // clnDeliveryDate
            // 
            this.clnDeliveryDate.DataPropertyName = "DeliveryDate";
            this.clnDeliveryDate.HeaderText = "Delivery Date";
            this.clnDeliveryDate.Name = "clnDeliveryDate";
            this.clnDeliveryDate.ReadOnly = true;
            this.clnDeliveryDate.Width = 120;
            // 
            // clnPONumber
            // 
            this.clnPONumber.DataPropertyName = "GRNumber";
            this.clnPONumber.HeaderText = "GRNumber";
            this.clnPONumber.Name = "clnPONumber";
            this.clnPONumber.ReadOnly = true;
            // 
            // clnNetPrice
            // 
            this.clnNetPrice.DataPropertyName = "NetPrice";
            this.clnNetPrice.HeaderText = "Net Price";
            this.clnNetPrice.Name = "clnNetPrice";
            this.clnNetPrice.ReadOnly = true;
            this.clnNetPrice.Visible = false;
            // 
            // clnAmount
            // 
            this.clnAmount.DataPropertyName = "GTAmt";
            this.clnAmount.HeaderText = "Amount";
            this.clnAmount.Name = "clnAmount";
            this.clnAmount.ReadOnly = true;
            this.clnAmount.Visible = false;
            // 
            // clnPlantName
            // 
            this.clnPlantName.DataPropertyName = "PlantName";
            this.clnPlantName.HeaderText = "PlantName";
            this.clnPlantName.MinimumWidth = 2;
            this.clnPlantName.Name = "clnPlantName";
            this.clnPlantName.ReadOnly = true;
            this.clnPlantName.Visible = false;
            this.clnPlantName.Width = 2;
            // 
            // clnLocName
            // 
            this.clnLocName.DataPropertyName = "LocName";
            this.clnLocName.HeaderText = "LocName";
            this.clnLocName.MinimumWidth = 2;
            this.clnLocName.Name = "clnLocName";
            this.clnLocName.ReadOnly = true;
            this.clnLocName.Visible = false;
            this.clnLocName.Width = 2;
            // 
            // clnAutoID
            // 
            this.clnAutoID.DataPropertyName = "AutoID";
            this.clnAutoID.HeaderText = "GRID";
            this.clnAutoID.Name = "clnAutoID";
            this.clnAutoID.ReadOnly = true;
            this.clnAutoID.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(560, 87);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 13;
            this.textBox1.Visible = false;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // pGradientPanel1
            // 
            this.pGradientPanel1.Caption = "Goods Return ...";
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
            this.pGradientPanel1.Size = new System.Drawing.Size(683, 50);
            this.pGradientPanel1.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "GR Number :";
            // 
            // groupPR
            // 
            this.groupPR.Controls.Add(this.txtDoc);
            this.groupPR.Controls.Add(this.btnGenNew);
            this.groupPR.Controls.Add(this.btnRefresh);
            this.groupPR.Controls.Add(this.txtInv);
            this.groupPR.Controls.Add(this.label5);
            this.groupPR.Controls.Add(this.txtRemark);
            this.groupPR.Controls.Add(this.label8);
            this.groupPR.Controls.Add(this.lblVendorName);
            this.groupPR.Controls.Add(this.label1);
            this.groupPR.Controls.Add(this.label2);
            this.groupPR.Controls.Add(this.cbVendor);
            this.groupPR.Controls.Add(this.lblPG);
            this.groupPR.Controls.Add(this.label4);
            this.groupPR.Location = new System.Drawing.Point(3, 1);
            this.groupPR.Name = "groupPR";
            this.groupPR.Size = new System.Drawing.Size(534, 175);
            this.groupPR.TabIndex = 12;
            this.groupPR.TabStop = false;
            // 
            // txtInv
            // 
            this.txtInv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtInv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtInv.Location = new System.Drawing.Point(272, 29);
            this.txtInv.Name = "txtInv";
            this.txtInv.Size = new System.Drawing.Size(255, 22);
            this.txtInv.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(272, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Invoice Number :";
            // 
            // txtRemark
            // 
            this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRemark.Location = new System.Drawing.Point(272, 128);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(255, 41);
            this.txtRemark.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(269, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 16);
            this.label8.TabIndex = 13;
            this.label8.Text = "Remark :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVendorName
            // 
            this.lblVendorName.BackColor = System.Drawing.Color.Khaki;
            this.lblVendorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblVendorName.ForeColor = System.Drawing.Color.Black;
            this.lblVendorName.Location = new System.Drawing.Point(15, 108);
            this.lblVendorName.Name = "lblVendorName";
            this.lblVendorName.Size = new System.Drawing.Size(243, 37);
            this.lblVendorName.TabIndex = 12;
            this.lblVendorName.Text = "VendorName :";
            this.lblVendorName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Doc.Number :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Vendor :";
            // 
            // cbVendor
            // 
            this.cbVendor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbVendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbVendor.FormattingEnabled = true;
            this.cbVendor.Location = new System.Drawing.Point(15, 80);
            this.cbVendor.Name = "cbVendor";
            this.cbVendor.Size = new System.Drawing.Size(243, 21);
            this.cbVendor.TabIndex = 1;
            this.cbVendor.SelectedIndexChanged += new System.EventHandler(this.cbVendor_SelectedIndexChanged);
            // 
            // lblPG
            // 
            this.lblPG.BackColor = System.Drawing.Color.Khaki;
            this.lblPG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPG.ForeColor = System.Drawing.Color.Black;
            this.lblPG.Location = new System.Drawing.Point(272, 76);
            this.lblPG.Name = "lblPG";
            this.lblPG.Size = new System.Drawing.Size(255, 24);
            this.lblPG.TabIndex = 9;
            this.lblPG.Text = "Purchasing Group :";
            this.lblPG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(269, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Purchasing Group :";
            // 
            // txtDocDate
            // 
            this.txtDocDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtDocDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtDocDate.Location = new System.Drawing.Point(550, 8);
            this.txtDocDate.Name = "txtDocDate";
            this.txtDocDate.Size = new System.Drawing.Size(128, 26);
            this.txtDocDate.TabIndex = 5;
            this.txtDocDate.Text = "dd/MM/yyyy";
            this.txtDocDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Controls.Add(this.txtDocDate);
            this.panel2.Controls.Add(this.groupPR);
            this.panel2.Controls.Add(this.lblMovType);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(683, 181);
            this.panel2.TabIndex = 34;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAddPR);
            this.flowLayoutPanel1.Controls.Add(this.btnCancelPR);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(543, 140);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(130, 33);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnAddPR
            // 
            this.btnAddPR.BackColor = System.Drawing.Color.White;
            this.btnAddPR.BackgroundImage = global::WMS.Properties.Resources.AddHeaderGRt;
            this.btnAddPR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddPR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddPR.Location = new System.Drawing.Point(3, 3);
            this.btnAddPR.Name = "btnAddPR";
            this.btnAddPR.Size = new System.Drawing.Size(130, 30);
            this.btnAddPR.TabIndex = 1;
            this.btnAddPR.TabStop = false;
            this.btnAddPR.Click += new System.EventHandler(this.btnAddPR_Click);
            // 
            // btnCancelPR
            // 
            this.btnCancelPR.BackColor = System.Drawing.Color.White;
            this.btnCancelPR.BackgroundImage = global::WMS.Properties.Resources.CancelGRt;
            this.btnCancelPR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelPR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelPR.Location = new System.Drawing.Point(3, 39);
            this.btnCancelPR.Name = "btnCancelPR";
            this.btnCancelPR.Size = new System.Drawing.Size(130, 30);
            this.btnCancelPR.TabIndex = 13;
            this.btnCancelPR.TabStop = false;
            this.btnCancelPR.Click += new System.EventHandler(this.btnCancelPR_Click);
            // 
            // lblMovType
            // 
            this.lblMovType.BackColor = System.Drawing.Color.Khaki;
            this.lblMovType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblMovType.ForeColor = System.Drawing.Color.Black;
            this.lblMovType.Location = new System.Drawing.Point(577, 66);
            this.lblMovType.Name = "lblMovType";
            this.lblMovType.Size = new System.Drawing.Size(73, 16);
            this.lblMovType.TabIndex = 11;
            this.lblMovType.Text = "121";
            this.lblMovType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMovType.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cbPONumber);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 231);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(683, 33);
            this.panel1.TabIndex = 35;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnUpdate.BackgroundImage = global::WMS.Properties.Resources.Update;
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Location = new System.Drawing.Point(594, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(86, 29);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cbPONumber
            // 
            this.cbPONumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPONumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPONumber.FormattingEnabled = true;
            this.cbPONumber.Location = new System.Drawing.Point(100, 6);
            this.cbPONumber.Name = "cbPONumber";
            this.cbPONumber.Size = new System.Drawing.Size(154, 21);
            this.cbPONumber.TabIndex = 0;
            // 
            // pGradientPanel2
            // 
            this.pGradientPanel2.Caption = null;
            this.pGradientPanel2.ColorFrom = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pGradientPanel2.ColorTo = System.Drawing.Color.White;
            this.pGradientPanel2.Controls.Add(this.btnSave);
            this.pGradientPanel2.Controls.Add(this.btnExit);
            this.pGradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pGradientPanel2.FontOffset = new System.Drawing.Size(0, 0);
            this.pGradientPanel2.ImageHeader = null;
            this.pGradientPanel2.ImageOffset = new System.Drawing.Size(0, 0);
            this.pGradientPanel2.ImageSize = new System.Drawing.Size(0, 0);
            this.pGradientPanel2.LinearGradientType = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.pGradientPanel2.Location = new System.Drawing.Point(0, 520);
            this.pGradientPanel2.Name = "pGradientPanel2";
            this.pGradientPanel2.Size = new System.Drawing.Size(683, 35);
            this.pGradientPanel2.TabIndex = 33;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.BackgroundImage = global::WMS.Properties.Resources.Save;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Location = new System.Drawing.Point(505, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 29);
            this.btnSave.TabIndex = 16;
            this.btnSave.TabStop = false;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackgroundImage = global::WMS.Properties.Resources.Exit;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Location = new System.Drawing.Point(593, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(87, 30);
            this.btnExit.TabIndex = 0;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnGenNew
            // 
            this.btnGenNew.BackColor = System.Drawing.Color.White;
            this.btnGenNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGenNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenNew.Image = global::WMS.Properties.Resources.add2;
            this.btnGenNew.Location = new System.Drawing.Point(219, 9);
            this.btnGenNew.Name = "btnGenNew";
            this.btnGenNew.Size = new System.Drawing.Size(18, 19);
            this.btnGenNew.TabIndex = 30;
            this.btnGenNew.TabStop = false;
            this.btnGenNew.Click += new System.EventHandler(this.btnGenNew_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Image = global::WMS.Properties.Resources.refresh;
            this.btnRefresh.Location = new System.Drawing.Point(241, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(18, 19);
            this.btnRefresh.TabIndex = 29;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtDoc
            // 
            this.txtDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.txtDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtDoc.FormattingEnabled = true;
            this.txtDoc.Location = new System.Drawing.Point(17, 29);
            this.txtDoc.Name = "txtDoc";
            this.txtDoc.Size = new System.Drawing.Size(243, 22);
            this.txtDoc.TabIndex = 31;
            this.txtDoc.SelectedIndexChanged += new System.EventHandler(this.txtDoc_SelectedIndexChanged);
            // 
            // frmGoodsReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(683, 555);
            this.ControlBox = false;
            this.Controls.Add(this.dgvView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pGradientPanel1);
            this.Controls.Add(this.pGradientPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmGoodsReturn";
            this.Load += new System.EventHandler(this.frmGoodsReturn_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGoodsReturn_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.groupPR.ResumeLayout(false);
            this.groupPR.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAddPR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelPR)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).EndInit();
            this.pGradientPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem delToolStripMenuItem;
        private System.Windows.Forms.PictureBox btnSave;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridView dgvView;
        private System.Windows.Forms.TextBox textBox1;
        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel1;
        private System.Windows.Forms.PictureBox btnUpdate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox btnAddPR;
        private System.Windows.Forms.GroupBox groupPR;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblVendorName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbVendor;
        private System.Windows.Forms.Label lblPG;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDocDate;
        private System.Windows.Forms.PictureBox btnCancelPR;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblMovType;
        private System.Windows.Forms.PictureBox btnExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbPONumber;
        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel2;
        private System.Windows.Forms.TextBox txtInv;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnItemNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnMaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnMaterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnUnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnUnitCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPlantCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnLocCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnBatch;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnDeliveryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPONumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNetPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPlantName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnLocName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnAutoID;
        private System.Windows.Forms.PictureBox btnGenNew;
        private System.Windows.Forms.PictureBox btnRefresh;
        private System.Windows.Forms.ComboBox txtDoc;

    }
}