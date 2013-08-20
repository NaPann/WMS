namespace WMS.PR_PO
{
    partial class frmPO
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvView = new System.Windows.Forms.DataGridView();
            this.clnItemNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnMaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnMaterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnUnitCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnNetPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnDeliveryDate = new WMS.SaleTranSac.frmSaleOrder.CalendarColumn();
            this.clnPRNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPlantCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPlantName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnLocCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnLocName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AutoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pGradientPanel2 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.btnSave = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClosePO = new System.Windows.Forms.PictureBox();
            this.btnAppr = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddPR = new System.Windows.Forms.PictureBox();
            this.btnCancelPR = new System.Windows.Forms.PictureBox();
            this.txtDocDate = new System.Windows.Forms.TextBox();
            this.groupPR = new System.Windows.Forms.GroupBox();
            this.txtPR = new System.Windows.Forms.ComboBox();
            this.btnGenNew = new System.Windows.Forms.PictureBox();
            this.btnRefresh = new System.Windows.Forms.PictureBox();
            this.lblUserCreate = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblVendorName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTerm = new System.Windows.Forms.Label();
            this.cbVendor = new System.Windows.Forms.ComboBox();
            this.lblPG = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMaterialName = new System.Windows.Forms.Label();
            this.cbMaterial = new System.Windows.Forms.ComboBox();
            this.pMaterial = new System.Windows.Forms.Panel();
            this.btnAddDetail = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pGradientPanel1 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.pGradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClosePO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAppr)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddPR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelPR)).BeginInit();
            this.groupPR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            this.pMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvView
            // 
            this.dgvView.AllowUserToAddRows = false;
            this.dgvView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnItemNo,
            this.clnMaterialCode,
            this.clnMaterialName,
            this.clnQuantity,
            this.clnUnitName,
            this.clnUnitCode,
            this.clnNetPrice,
            this.clnAmount,
            this.clnDeliveryDate,
            this.clnPRNumber,
            this.clnPlantCode,
            this.clnPlantName,
            this.clnLocCode,
            this.clnLocName,
            this.AutoID});
            this.dgvView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvView.Location = new System.Drawing.Point(0, 274);
            this.dgvView.MultiSelect = false;
            this.dgvView.Name = "dgvView";
            this.dgvView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvView.Size = new System.Drawing.Size(998, 339);
            this.dgvView.TabIndex = 31;
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
            this.clnMaterialName.Width = 150;
            // 
            // clnQuantity
            // 
            this.clnQuantity.DataPropertyName = "Qty";
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = "0";
            this.clnQuantity.DefaultCellStyle = dataGridViewCellStyle9;
            this.clnQuantity.HeaderText = "Quantity";
            this.clnQuantity.Name = "clnQuantity";
            this.clnQuantity.ReadOnly = true;
            // 
            // clnUnitName
            // 
            this.clnUnitName.DataPropertyName = "UnitName";
            this.clnUnitName.HeaderText = "Unit";
            this.clnUnitName.Name = "clnUnitName";
            this.clnUnitName.ReadOnly = true;
            // 
            // clnUnitCode
            // 
            this.clnUnitCode.DataPropertyName = "UnitCode";
            this.clnUnitCode.HeaderText = "UnitCode";
            this.clnUnitCode.Name = "clnUnitCode";
            this.clnUnitCode.ReadOnly = true;
            this.clnUnitCode.Visible = false;
            // 
            // clnNetPrice
            // 
            this.clnNetPrice.DataPropertyName = "NetPrice";
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = "0";
            this.clnNetPrice.DefaultCellStyle = dataGridViewCellStyle10;
            this.clnNetPrice.HeaderText = "Net Price";
            this.clnNetPrice.Name = "clnNetPrice";
            this.clnNetPrice.ReadOnly = true;
            // 
            // clnAmount
            // 
            this.clnAmount.DataPropertyName = "Amt";
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = "0";
            this.clnAmount.DefaultCellStyle = dataGridViewCellStyle11;
            this.clnAmount.HeaderText = "Amount";
            this.clnAmount.Name = "clnAmount";
            this.clnAmount.ReadOnly = true;
            // 
            // clnDeliveryDate
            // 
            this.clnDeliveryDate.DataPropertyName = "DeliveryDate";
            dataGridViewCellStyle12.Format = "d";
            this.clnDeliveryDate.DefaultCellStyle = dataGridViewCellStyle12;
            this.clnDeliveryDate.HeaderText = "Delivery Date";
            this.clnDeliveryDate.Name = "clnDeliveryDate";
            this.clnDeliveryDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clnDeliveryDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clnDeliveryDate.Width = 120;
            // 
            // clnPRNumber
            // 
            this.clnPRNumber.DataPropertyName = "PRNumber";
            this.clnPRNumber.HeaderText = "PRNumber";
            this.clnPRNumber.Name = "clnPRNumber";
            this.clnPRNumber.ReadOnly = true;
            this.clnPRNumber.Visible = false;
            // 
            // clnPlantCode
            // 
            this.clnPlantCode.DataPropertyName = "PlantCode";
            this.clnPlantCode.HeaderText = "PlantCode";
            this.clnPlantCode.Name = "clnPlantCode";
            this.clnPlantCode.ReadOnly = true;
            this.clnPlantCode.Visible = false;
            // 
            // clnPlantName
            // 
            this.clnPlantName.DataPropertyName = "PlantName";
            this.clnPlantName.HeaderText = "PlantName";
            this.clnPlantName.Name = "clnPlantName";
            this.clnPlantName.ReadOnly = true;
            this.clnPlantName.Visible = false;
            // 
            // clnLocCode
            // 
            this.clnLocCode.DataPropertyName = "LocCode";
            this.clnLocCode.HeaderText = "LocCode";
            this.clnLocCode.Name = "clnLocCode";
            this.clnLocCode.ReadOnly = true;
            this.clnLocCode.Visible = false;
            // 
            // clnLocName
            // 
            this.clnLocName.DataPropertyName = "LocName";
            this.clnLocName.HeaderText = "LocName";
            this.clnLocName.Name = "clnLocName";
            this.clnLocName.ReadOnly = true;
            this.clnLocName.Visible = false;
            // 
            // AutoID
            // 
            this.AutoID.DataPropertyName = "AutoID";
            this.AutoID.HeaderText = "AutoID";
            this.AutoID.Name = "AutoID";
            this.AutoID.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(840, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(128, 20);
            this.textBox1.TabIndex = 15;
            this.textBox1.Visible = false;
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
            this.pGradientPanel2.Location = new System.Drawing.Point(0, 613);
            this.pGradientPanel2.Name = "pGradientPanel2";
            this.pGradientPanel2.Size = new System.Drawing.Size(998, 35);
            this.pGradientPanel2.TabIndex = 28;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.BackgroundImage = global::WMS.Properties.Resources.Save;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Location = new System.Drawing.Point(824, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 29);
            this.btnSave.TabIndex = 15;
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
            this.btnExit.Location = new System.Drawing.Point(913, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(82, 30);
            this.btnExit.TabIndex = 0;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClosePO);
            this.panel2.Controls.Add(this.btnAppr);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Controls.Add(this.txtDocDate);
            this.panel2.Controls.Add(this.groupPR);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(998, 191);
            this.panel2.TabIndex = 29;
            // 
            // btnClosePO
            // 
            this.btnClosePO.BackColor = System.Drawing.Color.White;
            this.btnClosePO.BackgroundImage = global::WMS.Properties.Resources.ClosePO;
            this.btnClosePO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClosePO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClosePO.Location = new System.Drawing.Point(842, 111);
            this.btnClosePO.Name = "btnClosePO";
            this.btnClosePO.Size = new System.Drawing.Size(127, 30);
            this.btnClosePO.TabIndex = 18;
            this.btnClosePO.TabStop = false;
            this.btnClosePO.Visible = false;
            this.btnClosePO.Click += new System.EventHandler(this.btnClosePO_Click);
            // 
            // btnAppr
            // 
            this.btnAppr.BackColor = System.Drawing.Color.White;
            this.btnAppr.BackgroundImage = global::WMS.Properties.Resources.Approve;
            this.btnAppr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAppr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAppr.Location = new System.Drawing.Point(851, 77);
            this.btnAppr.Name = "btnAppr";
            this.btnAppr.Size = new System.Drawing.Size(106, 30);
            this.btnAppr.TabIndex = 17;
            this.btnAppr.TabStop = false;
            this.btnAppr.Visible = false;
            this.btnAppr.Click += new System.EventHandler(this.btnAppr_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAddPR);
            this.flowLayoutPanel1.Controls.Add(this.btnCancelPR);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(836, 144);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(130, 33);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // btnAddPR
            // 
            this.btnAddPR.BackColor = System.Drawing.Color.White;
            this.btnAddPR.BackgroundImage = global::WMS.Properties.Resources.AddHeaderPO;
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
            this.btnCancelPR.BackgroundImage = global::WMS.Properties.Resources.CancelPO;
            this.btnCancelPR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelPR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelPR.Location = new System.Drawing.Point(3, 39);
            this.btnCancelPR.Name = "btnCancelPR";
            this.btnCancelPR.Size = new System.Drawing.Size(130, 30);
            this.btnCancelPR.TabIndex = 13;
            this.btnCancelPR.TabStop = false;
            this.btnCancelPR.Click += new System.EventHandler(this.btnCancelPR_Click);
            // 
            // txtDocDate
            // 
            this.txtDocDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtDocDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtDocDate.Location = new System.Drawing.Point(840, 8);
            this.txtDocDate.Name = "txtDocDate";
            this.txtDocDate.Size = new System.Drawing.Size(128, 26);
            this.txtDocDate.TabIndex = 5;
            this.txtDocDate.Text = "dd/MM/yyyy";
            this.txtDocDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupPR
            // 
            this.groupPR.Controls.Add(this.txtPR);
            this.groupPR.Controls.Add(this.btnGenNew);
            this.groupPR.Controls.Add(this.btnRefresh);
            this.groupPR.Controls.Add(this.lblUserCreate);
            this.groupPR.Controls.Add(this.label10);
            this.groupPR.Controls.Add(this.txtRemark);
            this.groupPR.Controls.Add(this.label8);
            this.groupPR.Controls.Add(this.lblVendorName);
            this.groupPR.Controls.Add(this.label1);
            this.groupPR.Controls.Add(this.lblCurrency);
            this.groupPR.Controls.Add(this.label2);
            this.groupPR.Controls.Add(this.lblTerm);
            this.groupPR.Controls.Add(this.cbVendor);
            this.groupPR.Controls.Add(this.lblPG);
            this.groupPR.Controls.Add(this.label6);
            this.groupPR.Controls.Add(this.label4);
            this.groupPR.Controls.Add(this.label5);
            this.groupPR.Location = new System.Drawing.Point(3, 1);
            this.groupPR.Name = "groupPR";
            this.groupPR.Size = new System.Drawing.Size(813, 182);
            this.groupPR.TabIndex = 12;
            this.groupPR.TabStop = false;
            // 
            // txtPR
            // 
            this.txtPR.BackColor = System.Drawing.SystemColors.Info;
            this.txtPR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.txtPR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtPR.FormattingEnabled = true;
            this.txtPR.Location = new System.Drawing.Point(108, 12);
            this.txtPR.Name = "txtPR";
            this.txtPR.Size = new System.Drawing.Size(194, 22);
            this.txtPR.TabIndex = 27;
            this.txtPR.SelectedIndexChanged += new System.EventHandler(this.txtPR_SelectedIndexChanged);
            // 
            // btnGenNew
            // 
            this.btnGenNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGenNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenNew.Image = global::WMS.Properties.Resources.add2;
            this.btnGenNew.Location = new System.Drawing.Point(308, 14);
            this.btnGenNew.Name = "btnGenNew";
            this.btnGenNew.Size = new System.Drawing.Size(18, 19);
            this.btnGenNew.TabIndex = 26;
            this.btnGenNew.TabStop = false;
            this.btnGenNew.Click += new System.EventHandler(this.btnGenNew_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Image = global::WMS.Properties.Resources.refresh;
            this.btnRefresh.Location = new System.Drawing.Point(330, 14);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(18, 19);
            this.btnRefresh.TabIndex = 25;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblUserCreate
            // 
            this.lblUserCreate.BackColor = System.Drawing.Color.Orange;
            this.lblUserCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblUserCreate.ForeColor = System.Drawing.Color.Black;
            this.lblUserCreate.Location = new System.Drawing.Point(659, 88);
            this.lblUserCreate.Name = "lblUserCreate";
            this.lblUserCreate.Size = new System.Drawing.Size(139, 18);
            this.lblUserCreate.TabIndex = 24;
            this.lblUserCreate.Text = "User Create :";
            this.lblUserCreate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(548, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 16);
            this.label10.TabIndex = 23;
            this.label10.Text = "User Create PR :";
            // 
            // txtRemark
            // 
            this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRemark.Location = new System.Drawing.Point(104, 117);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(694, 47);
            this.txtRemark.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(36, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "Remark :";
            // 
            // lblVendorName
            // 
            this.lblVendorName.BackColor = System.Drawing.Color.Khaki;
            this.lblVendorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblVendorName.ForeColor = System.Drawing.Color.Black;
            this.lblVendorName.Location = new System.Drawing.Point(108, 68);
            this.lblVendorName.Name = "lblVendorName";
            this.lblVendorName.Size = new System.Drawing.Size(404, 39);
            this.lblVendorName.TabIndex = 12;
            this.lblVendorName.Text = "VendorName :";
            this.lblVendorName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(2, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Doc Number :";
            // 
            // lblCurrency
            // 
            this.lblCurrency.BackColor = System.Drawing.Color.Khaki;
            this.lblCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblCurrency.ForeColor = System.Drawing.Color.Black;
            this.lblCurrency.Location = new System.Drawing.Point(659, 64);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(139, 16);
            this.lblCurrency.TabIndex = 11;
            this.lblCurrency.Text = "Currency :";
            this.lblCurrency.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(47, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Vendor :";
            // 
            // lblTerm
            // 
            this.lblTerm.BackColor = System.Drawing.Color.Khaki;
            this.lblTerm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblTerm.ForeColor = System.Drawing.Color.Black;
            this.lblTerm.Location = new System.Drawing.Point(659, 40);
            this.lblTerm.Name = "lblTerm";
            this.lblTerm.Size = new System.Drawing.Size(139, 16);
            this.lblTerm.TabIndex = 10;
            this.lblTerm.Text = "Terms of payment :";
            this.lblTerm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbVendor
            // 
            this.cbVendor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbVendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbVendor.DropDownWidth = 500;
            this.cbVendor.FormattingEnabled = true;
            this.cbVendor.Location = new System.Drawing.Point(108, 40);
            this.cbVendor.Name = "cbVendor";
            this.cbVendor.Size = new System.Drawing.Size(404, 21);
            this.cbVendor.TabIndex = 0;
            this.cbVendor.SelectedIndexChanged += new System.EventHandler(this.cbVendor_SelectedIndexChanged);
            // 
            // lblPG
            // 
            this.lblPG.BackColor = System.Drawing.Color.Khaki;
            this.lblPG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPG.ForeColor = System.Drawing.Color.Black;
            this.lblPG.Location = new System.Drawing.Point(659, 15);
            this.lblPG.Name = "lblPG";
            this.lblPG.Size = new System.Drawing.Size(139, 16);
            this.lblPG.TabIndex = 9;
            this.lblPG.Text = "Purchasing Group :";
            this.lblPG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(589, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Currency :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(535, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Purchasing Group :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(534, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Terms of payment :";
            // 
            // lblMaterialName
            // 
            this.lblMaterialName.BackColor = System.Drawing.Color.Khaki;
            this.lblMaterialName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblMaterialName.ForeColor = System.Drawing.Color.Black;
            this.lblMaterialName.Location = new System.Drawing.Point(315, 9);
            this.lblMaterialName.Name = "lblMaterialName";
            this.lblMaterialName.Size = new System.Drawing.Size(501, 16);
            this.lblMaterialName.TabIndex = 13;
            this.lblMaterialName.Text = "Material Name";
            // 
            // cbMaterial
            // 
            this.cbMaterial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbMaterial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbMaterial.DropDownWidth = 500;
            this.cbMaterial.FormattingEnabled = true;
            this.cbMaterial.Location = new System.Drawing.Point(75, 6);
            this.cbMaterial.Name = "cbMaterial";
            this.cbMaterial.Size = new System.Drawing.Size(234, 21);
            this.cbMaterial.TabIndex = 3;
            this.cbMaterial.SelectedIndexChanged += new System.EventHandler(this.cbMaterial_SelectedIndexChanged);
            // 
            // pMaterial
            // 
            this.pMaterial.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pMaterial.Controls.Add(this.btnAddDetail);
            this.pMaterial.Controls.Add(this.lblMaterialName);
            this.pMaterial.Controls.Add(this.label7);
            this.pMaterial.Controls.Add(this.cbMaterial);
            this.pMaterial.Dock = System.Windows.Forms.DockStyle.Top;
            this.pMaterial.Location = new System.Drawing.Point(0, 241);
            this.pMaterial.Name = "pMaterial";
            this.pMaterial.Size = new System.Drawing.Size(998, 33);
            this.pMaterial.TabIndex = 30;
            // 
            // btnAddDetail
            // 
            this.btnAddDetail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAddDetail.BackgroundImage = global::WMS.Properties.Resources.Update;
            this.btnAddDetail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddDetail.Location = new System.Drawing.Point(860, 1);
            this.btnAddDetail.Name = "btnAddDetail";
            this.btnAddDetail.Size = new System.Drawing.Size(86, 29);
            this.btnAddDetail.TabIndex = 14;
            this.btnAddDetail.TabStop = false;
            this.btnAddDetail.Click += new System.EventHandler(this.btnAddDetail_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Material :";
            // 
            // pGradientPanel1
            // 
            this.pGradientPanel1.Caption = "Purchase Order ...";
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
            this.pGradientPanel1.Size = new System.Drawing.Size(998, 50);
            this.pGradientPanel1.TabIndex = 27;
            // 
            // frmPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(998, 648);
            this.ControlBox = false;
            this.Controls.Add(this.dgvView);
            this.Controls.Add(this.pMaterial);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pGradientPanel2);
            this.Controls.Add(this.pGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(777, 550);
            this.Name = "frmPO";
            this.Load += new System.EventHandler(this.frmPO_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPO_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.pGradientPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClosePO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAppr)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAddPR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelPR)).EndInit();
            this.groupPR.ResumeLayout(false);
            this.groupPR.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            this.pMaterial.ResumeLayout(false);
            this.pMaterial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox btnExit;
        private System.Windows.Forms.DataGridView dgvView;
        private System.Windows.Forms.PictureBox btnSave;
        private System.Windows.Forms.TextBox textBox1;
        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel2;
        private System.Windows.Forms.PictureBox btnAddPR;
        private System.Windows.Forms.PictureBox btnCancelPR;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txtDocDate;
        private System.Windows.Forms.GroupBox groupPR;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblVendorName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTerm;
        private System.Windows.Forms.ComboBox cbVendor;
        private System.Windows.Forms.Label lblPG;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMaterialName;
        private System.Windows.Forms.PictureBox btnAddDetail;
        private System.Windows.Forms.ComboBox cbMaterial;
        private System.Windows.Forms.Panel pMaterial;
        private System.Windows.Forms.Label label7;
        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel1;
        private System.Windows.Forms.Label lblUserCreate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox btnAppr;
        private System.Windows.Forms.PictureBox btnGenNew;
        private System.Windows.Forms.PictureBox btnRefresh;
        private System.Windows.Forms.ComboBox txtPR;
        private System.Windows.Forms.PictureBox btnClosePO;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnItemNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnMaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnMaterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnUnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnUnitCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNetPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnAmount;
        private WMS.SaleTranSac.frmSaleOrder.CalendarColumn clnDeliveryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPRNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPlantCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPlantName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnLocCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnLocName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AutoID;

    }
}