namespace WMS.Stock
{
    partial class frmTransferStatus
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtPR = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblMovDesc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddHeader = new System.Windows.Forms.PictureBox();
            this.btnCancelPR = new System.Windows.Forms.PictureBox();
            this.lblUserCreate = new System.Windows.Forms.Label();
            this.dgvView = new System.Windows.Forms.DataGridView();
            this.clnItemNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnMaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnMaterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnBatchNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnUR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnQI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnBlock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MovementType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnTranQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPlantCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPlantName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnLocCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnLocName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnUnitCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pMaterial = new System.Windows.Forms.Panel();
            this.btnAddDetail = new System.Windows.Forms.PictureBox();
            this.lblMaterialName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbMaterial = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMovType = new System.Windows.Forms.ComboBox();
            this.groupPR = new System.Windows.Forms.GroupBox();
            this.btnGenNew = new System.Windows.Forms.PictureBox();
            this.btnRefresh = new System.Windows.Forms.PictureBox();
            this.txtDocDate = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAppr = new System.Windows.Forms.PictureBox();
            this.pGradientPanel2 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.btnSave = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.pGradientPanel1 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelPR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.pMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddDetail)).BeginInit();
            this.groupPR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAppr)).BeginInit();
            this.pGradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPR
            // 
            this.txtPR.BackColor = System.Drawing.SystemColors.Info;
            this.txtPR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.txtPR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtPR.FormattingEnabled = true;
            this.txtPR.Location = new System.Drawing.Point(124, 12);
            this.txtPR.Name = "txtPR";
            this.txtPR.Size = new System.Drawing.Size(187, 22);
            this.txtPR.TabIndex = 27;
            this.txtPR.SelectedIndexChanged += new System.EventHandler(this.txtPR_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(373, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 16);
            this.label10.TabIndex = 23;
            this.label10.Text = "User Transfer :";
            // 
            // txtRemark
            // 
            this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRemark.Location = new System.Drawing.Point(122, 116);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(481, 48);
            this.txtRemark.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(54, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "Remark :";
            // 
            // lblMovDesc
            // 
            this.lblMovDesc.BackColor = System.Drawing.Color.Khaki;
            this.lblMovDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblMovDesc.ForeColor = System.Drawing.Color.Black;
            this.lblMovDesc.Location = new System.Drawing.Point(123, 69);
            this.lblMovDesc.Name = "lblMovDesc";
            this.lblMovDesc.Size = new System.Drawing.Size(479, 39);
            this.lblMovDesc.TabIndex = 12;
            this.lblMovDesc.Text = "Mov Desc :";
            this.lblMovDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Doc.Number :";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAddHeader);
            this.flowLayoutPanel1.Controls.Add(this.btnCancelPR);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(624, 138);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(130, 33);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // btnAddHeader
            // 
            this.btnAddHeader.BackColor = System.Drawing.Color.White;
            this.btnAddHeader.BackgroundImage = global::WMS.Properties.Resources.AddHeaderTR;
            this.btnAddHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddHeader.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddHeader.Location = new System.Drawing.Point(3, 3);
            this.btnAddHeader.Name = "btnAddHeader";
            this.btnAddHeader.Size = new System.Drawing.Size(130, 30);
            this.btnAddHeader.TabIndex = 1;
            this.btnAddHeader.TabStop = false;
            this.btnAddHeader.Click += new System.EventHandler(this.btnAddHeader_Click);
            // 
            // btnCancelPR
            // 
            this.btnCancelPR.BackColor = System.Drawing.Color.White;
            this.btnCancelPR.BackgroundImage = global::WMS.Properties.Resources.CancelHeaderTR;
            this.btnCancelPR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelPR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelPR.Location = new System.Drawing.Point(3, 39);
            this.btnCancelPR.Name = "btnCancelPR";
            this.btnCancelPR.Size = new System.Drawing.Size(130, 30);
            this.btnCancelPR.TabIndex = 13;
            this.btnCancelPR.TabStop = false;
            this.btnCancelPR.Visible = false;
            this.btnCancelPR.Click += new System.EventHandler(this.btnCancelPR_Click);
            // 
            // lblUserCreate
            // 
            this.lblUserCreate.BackColor = System.Drawing.Color.Orange;
            this.lblUserCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblUserCreate.ForeColor = System.Drawing.Color.Black;
            this.lblUserCreate.Location = new System.Drawing.Point(376, 37);
            this.lblUserCreate.Name = "lblUserCreate";
            this.lblUserCreate.Size = new System.Drawing.Size(226, 21);
            this.lblUserCreate.TabIndex = 24;
            this.lblUserCreate.Text = "User Create :";
            this.lblUserCreate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.clnItemNo,
            this.Remark,
            this.clnMaterialCode,
            this.clnMaterialName,
            this.clnBatchNumber,
            this.clnUR,
            this.clnQI,
            this.clnBlock,
            this.MovementType,
            this.clnTranQuantity,
            this.clnPlantCode,
            this.clnPlantName,
            this.clnLocCode,
            this.clnLocName,
            this.clnUnitCode,
            this.clnUnitName});
            this.dgvView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvView.Location = new System.Drawing.Point(0, 261);
            this.dgvView.MultiSelect = false;
            this.dgvView.Name = "dgvView";
            this.dgvView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvView.Size = new System.Drawing.Size(759, 237);
            this.dgvView.TabIndex = 36;
            this.dgvView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvView_CellEndEdit);
            this.dgvView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvView_EditingControlShowing);
            // 
            // clnItemNo
            // 
            this.clnItemNo.DataPropertyName = "ItemNo";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = "0";
            this.clnItemNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.clnItemNo.HeaderText = "Item";
            this.clnItemNo.Name = "clnItemNo";
            this.clnItemNo.ReadOnly = true;
            this.clnItemNo.Width = 50;
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "Remark";
            this.Remark.Name = "Remark";
            this.Remark.Visible = false;
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
            // clnBatchNumber
            // 
            this.clnBatchNumber.DataPropertyName = "BatchNumber";
            this.clnBatchNumber.HeaderText = "BatchNumber";
            this.clnBatchNumber.Name = "clnBatchNumber";
            this.clnBatchNumber.ReadOnly = true;
            this.clnBatchNumber.Width = 120;
            // 
            // clnUR
            // 
            this.clnUR.DataPropertyName = "UR";
            dataGridViewCellStyle3.Format = "N3";
            this.clnUR.DefaultCellStyle = dataGridViewCellStyle3;
            this.clnUR.HeaderText = "UR";
            this.clnUR.Name = "clnUR";
            this.clnUR.ReadOnly = true;
            // 
            // clnQI
            // 
            this.clnQI.DataPropertyName = "QI";
            dataGridViewCellStyle4.Format = "N3";
            this.clnQI.DefaultCellStyle = dataGridViewCellStyle4;
            this.clnQI.HeaderText = "QI";
            this.clnQI.Name = "clnQI";
            this.clnQI.ReadOnly = true;
            // 
            // clnBlock
            // 
            this.clnBlock.DataPropertyName = "Block";
            dataGridViewCellStyle5.Format = "N3";
            this.clnBlock.DefaultCellStyle = dataGridViewCellStyle5;
            this.clnBlock.HeaderText = "Block";
            this.clnBlock.Name = "clnBlock";
            this.clnBlock.ReadOnly = true;
            // 
            // MovementType
            // 
            this.MovementType.DataPropertyName = "MovementType";
            this.MovementType.HeaderText = "MovementType";
            this.MovementType.Name = "MovementType";
            this.MovementType.ReadOnly = true;
            this.MovementType.Visible = false;
            // 
            // clnTranQuantity
            // 
            this.clnTranQuantity.DataPropertyName = "TranQuantity";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.Format = "N3";
            this.clnTranQuantity.DefaultCellStyle = dataGridViewCellStyle6;
            this.clnTranQuantity.HeaderText = "Transfer Qty";
            this.clnTranQuantity.Name = "clnTranQuantity";
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
            // 
            // clnUnitCode
            // 
            this.clnUnitCode.DataPropertyName = "UnitCode";
            this.clnUnitCode.HeaderText = "UnitCode";
            this.clnUnitCode.Name = "clnUnitCode";
            this.clnUnitCode.ReadOnly = true;
            this.clnUnitCode.Visible = false;
            // 
            // clnUnitName
            // 
            this.clnUnitName.DataPropertyName = "UnitName";
            this.clnUnitName.HeaderText = "UnitName";
            this.clnUnitName.Name = "clnUnitName";
            this.clnUnitName.ReadOnly = true;
            this.clnUnitName.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(628, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(128, 20);
            this.textBox1.TabIndex = 15;
            this.textBox1.Visible = false;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // pMaterial
            // 
            this.pMaterial.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pMaterial.Controls.Add(this.btnAddDetail);
            this.pMaterial.Controls.Add(this.lblMaterialName);
            this.pMaterial.Controls.Add(this.label7);
            this.pMaterial.Controls.Add(this.cbMaterial);
            this.pMaterial.Dock = System.Windows.Forms.DockStyle.Top;
            this.pMaterial.Location = new System.Drawing.Point(0, 228);
            this.pMaterial.Name = "pMaterial";
            this.pMaterial.Size = new System.Drawing.Size(759, 33);
            this.pMaterial.TabIndex = 35;
            // 
            // btnAddDetail
            // 
            this.btnAddDetail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAddDetail.BackgroundImage = global::WMS.Properties.Resources.Update;
            this.btnAddDetail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddDetail.Location = new System.Drawing.Point(673, 2);
            this.btnAddDetail.Name = "btnAddDetail";
            this.btnAddDetail.Size = new System.Drawing.Size(86, 29);
            this.btnAddDetail.TabIndex = 14;
            this.btnAddDetail.TabStop = false;
            this.btnAddDetail.Click += new System.EventHandler(this.btnAddDetail_Click);
            // 
            // lblMaterialName
            // 
            this.lblMaterialName.BackColor = System.Drawing.Color.Khaki;
            this.lblMaterialName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblMaterialName.ForeColor = System.Drawing.Color.Black;
            this.lblMaterialName.Location = new System.Drawing.Point(235, 9);
            this.lblMaterialName.Name = "lblMaterialName";
            this.lblMaterialName.Size = new System.Drawing.Size(182, 16);
            this.lblMaterialName.TabIndex = 13;
            this.lblMaterialName.Text = "Material Name";
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
            // cbMaterial
            // 
            this.cbMaterial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbMaterial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbMaterial.FormattingEnabled = true;
            this.cbMaterial.Location = new System.Drawing.Point(75, 6);
            this.cbMaterial.Name = "cbMaterial";
            this.cbMaterial.Size = new System.Drawing.Size(154, 21);
            this.cbMaterial.TabIndex = 3;
            this.cbMaterial.SelectedIndexChanged += new System.EventHandler(this.cbMaterial_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Movement Type :";
            // 
            // cbMovType
            // 
            this.cbMovType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbMovType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbMovType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMovType.FormattingEnabled = true;
            this.cbMovType.Location = new System.Drawing.Point(124, 40);
            this.cbMovType.Name = "cbMovType";
            this.cbMovType.Size = new System.Drawing.Size(188, 21);
            this.cbMovType.TabIndex = 0;
            this.cbMovType.SelectedIndexChanged += new System.EventHandler(this.cbMovType_SelectedIndexChanged);
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
            this.groupPR.Controls.Add(this.lblMovDesc);
            this.groupPR.Controls.Add(this.label1);
            this.groupPR.Controls.Add(this.label2);
            this.groupPR.Controls.Add(this.cbMovType);
            this.groupPR.Location = new System.Drawing.Point(3, 1);
            this.groupPR.Name = "groupPR";
            this.groupPR.Size = new System.Drawing.Size(618, 171);
            this.groupPR.TabIndex = 12;
            this.groupPR.TabStop = false;
            // 
            // btnGenNew
            // 
            this.btnGenNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGenNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenNew.Image = global::WMS.Properties.Resources.add2;
            this.btnGenNew.Location = new System.Drawing.Point(317, 14);
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
            this.btnRefresh.Location = new System.Drawing.Point(339, 14);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(18, 19);
            this.btnRefresh.TabIndex = 25;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtDocDate
            // 
            this.txtDocDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtDocDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtDocDate.Location = new System.Drawing.Point(628, 8);
            this.txtDocDate.Name = "txtDocDate";
            this.txtDocDate.Size = new System.Drawing.Size(128, 26);
            this.txtDocDate.TabIndex = 5;
            this.txtDocDate.Text = "dd/MM/yyyy";
            this.txtDocDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAppr);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Controls.Add(this.txtDocDate);
            this.panel2.Controls.Add(this.groupPR);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(759, 178);
            this.panel2.TabIndex = 34;
            // 
            // btnAppr
            // 
            this.btnAppr.BackColor = System.Drawing.Color.White;
            this.btnAppr.BackgroundImage = global::WMS.Properties.Resources.Approve;
            this.btnAppr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAppr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAppr.Location = new System.Drawing.Point(639, 76);
            this.btnAppr.Name = "btnAppr";
            this.btnAppr.Size = new System.Drawing.Size(106, 30);
            this.btnAppr.TabIndex = 17;
            this.btnAppr.TabStop = false;
            this.btnAppr.Visible = false;
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
            this.pGradientPanel2.Location = new System.Drawing.Point(0, 498);
            this.pGradientPanel2.Name = "pGradientPanel2";
            this.pGradientPanel2.Size = new System.Drawing.Size(759, 35);
            this.pGradientPanel2.TabIndex = 33;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.BackgroundImage = global::WMS.Properties.Resources.Save;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Location = new System.Drawing.Point(585, 3);
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
            this.btnExit.Location = new System.Drawing.Point(674, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(82, 30);
            this.btnExit.TabIndex = 0;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pGradientPanel1
            // 
            this.pGradientPanel1.Caption = "Transfer Stock ...";
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
            this.pGradientPanel1.Size = new System.Drawing.Size(759, 50);
            this.pGradientPanel1.TabIndex = 32;
            // 
            // frmTransferStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(759, 533);
            this.ControlBox = false;
            this.Controls.Add(this.dgvView);
            this.Controls.Add(this.pMaterial);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pGradientPanel2);
            this.Controls.Add(this.pGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTransferStatus";
            this.Load += new System.EventHandler(this.frmTransferStatus_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTransferStatus_FormClosing);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAddHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelPR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.pMaterial.ResumeLayout(false);
            this.pMaterial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddDetail)).EndInit();
            this.groupPR.ResumeLayout(false);
            this.groupPR.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAppr)).EndInit();
            this.pGradientPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox txtPR;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblMovDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btnAppr;
        private System.Windows.Forms.PictureBox btnGenNew;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox btnAddHeader;
        private System.Windows.Forms.PictureBox btnCancelPR;
        private System.Windows.Forms.Label lblUserCreate;
        private System.Windows.Forms.DataGridView dgvView;
        private System.Windows.Forms.PictureBox btnRefresh;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox btnAddDetail;
        private System.Windows.Forms.Panel pMaterial;
        private System.Windows.Forms.Label lblMaterialName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbMaterial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMovType;
        private System.Windows.Forms.GroupBox groupPR;
        private System.Windows.Forms.PictureBox btnSave;
        private System.Windows.Forms.TextBox txtDocDate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox btnExit;
        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel2;
        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnItemNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnMaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnMaterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnBatchNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnUR;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnQI;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnBlock;
        private System.Windows.Forms.DataGridViewTextBoxColumn MovementType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnTranQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPlantCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPlantName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnLocCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnLocName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnUnitCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnUnitName;

    }
}