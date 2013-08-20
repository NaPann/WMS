namespace WMS.Routing
{
    partial class frmProductionCost
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvView = new System.Windows.Forms.DataGridView();
            this.clnAutoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnProdOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnMaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPlantCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnWorkCenterCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnMachine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnSetup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnLabor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbProdOrder = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtOT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLabor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSetup = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMachine = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gDetail = new System.Windows.Forms.GroupBox();
            this.lblPlantCode = new System.Windows.Forms.Label();
            this.lblMaterialCode = new System.Windows.Forms.Label();
            this.cbWorkCenter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.PictureBox();
            this.btnEdit = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSName = new System.Windows.Forms.TextBox();
            this.txtSCode = new System.Windows.Forms.TextBox();
            this.pGradientPanel2 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.pGradientPanel1 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gDetail.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.panel3.TabIndex = 22;
            // 
            // dgvView
            // 
            this.dgvView.AllowUserToAddRows = false;
            this.dgvView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnAutoID,
            this.clnNo,
            this.clnProdOrder,
            this.clnMaterialCode,
            this.clnPlantCode,
            this.clnWorkCenterCode,
            this.clnMachine,
            this.clnSetup,
            this.clnLabor,
            this.clnOT});
            this.dgvView.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvView.Location = new System.Drawing.Point(318, 0);
            this.dgvView.MultiSelect = false;
            this.dgvView.Name = "dgvView";
            this.dgvView.ReadOnly = true;
            this.dgvView.RowHeadersVisible = false;
            this.dgvView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvView.Size = new System.Drawing.Size(580, 382);
            this.dgvView.TabIndex = 3;
            // 
            // clnAutoID
            // 
            this.clnAutoID.DataPropertyName = "AutoID";
            this.clnAutoID.HeaderText = "AutoID";
            this.clnAutoID.Name = "clnAutoID";
            this.clnAutoID.ReadOnly = true;
            this.clnAutoID.Visible = false;
            // 
            // clnNo
            // 
            this.clnNo.DataPropertyName = "ItemNo";
            this.clnNo.HeaderText = "Item";
            this.clnNo.Name = "clnNo";
            this.clnNo.ReadOnly = true;
            this.clnNo.Width = 60;
            // 
            // clnProdOrder
            // 
            this.clnProdOrder.DataPropertyName = "PrdONumber";
            this.clnProdOrder.HeaderText = "Prod.Order";
            this.clnProdOrder.Name = "clnProdOrder";
            this.clnProdOrder.ReadOnly = true;
            this.clnProdOrder.Width = 120;
            // 
            // clnMaterialCode
            // 
            this.clnMaterialCode.DataPropertyName = "MaterialCode";
            this.clnMaterialCode.HeaderText = "MaterialCode";
            this.clnMaterialCode.Name = "clnMaterialCode";
            this.clnMaterialCode.ReadOnly = true;
            // 
            // clnPlantCode
            // 
            this.clnPlantCode.DataPropertyName = "PlantCode";
            this.clnPlantCode.HeaderText = "PlantCode";
            this.clnPlantCode.Name = "clnPlantCode";
            this.clnPlantCode.ReadOnly = true;
            // 
            // clnWorkCenterCode
            // 
            this.clnWorkCenterCode.DataPropertyName = "WorkCenterCode";
            this.clnWorkCenterCode.HeaderText = "WorkCenter";
            this.clnWorkCenterCode.Name = "clnWorkCenterCode";
            this.clnWorkCenterCode.ReadOnly = true;
            // 
            // clnMachine
            // 
            this.clnMachine.DataPropertyName = "UsedMachine";
            this.clnMachine.HeaderText = "Machine";
            this.clnMachine.Name = "clnMachine";
            this.clnMachine.ReadOnly = true;
            this.clnMachine.Width = 70;
            // 
            // clnSetup
            // 
            this.clnSetup.DataPropertyName = "UsedSetup";
            this.clnSetup.HeaderText = "Setup";
            this.clnSetup.Name = "clnSetup";
            this.clnSetup.ReadOnly = true;
            this.clnSetup.Width = 70;
            // 
            // clnLabor
            // 
            this.clnLabor.DataPropertyName = "UsedLabor";
            this.clnLabor.HeaderText = "Labor";
            this.clnLabor.Name = "clnLabor";
            this.clnLabor.ReadOnly = true;
            this.clnLabor.Width = 70;
            // 
            // clnOT
            // 
            this.clnOT.DataPropertyName = "UsedOT";
            this.clnOT.HeaderText = "OT";
            this.clnOT.Name = "clnOT";
            this.clnOT.ReadOnly = true;
            this.clnOT.Width = 70;
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
            // panel2
            // 
            this.panel2.Controls.Add(this.cbProdOrder);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.gDetail);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(318, 382);
            this.panel2.TabIndex = 0;
            // 
            // cbProdOrder
            // 
            this.cbProdOrder.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbProdOrder.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbProdOrder.FormattingEnabled = true;
            this.cbProdOrder.Location = new System.Drawing.Point(12, 33);
            this.cbProdOrder.Name = "cbProdOrder";
            this.cbProdOrder.Size = new System.Drawing.Size(279, 21);
            this.cbProdOrder.TabIndex = 0;
            this.cbProdOrder.SelectedIndexChanged += new System.EventHandler(this.cbProdOrder_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(12, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "Production Order :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtOT);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtLabor);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtSetup);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMachine);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(10, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 135);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Used";
            // 
            // txtOT
            // 
            this.txtOT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtOT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOT.Location = new System.Drawing.Point(104, 97);
            this.txtOT.MaxLength = 10;
            this.txtOT.Name = "txtOT";
            this.txtOT.Size = new System.Drawing.Size(177, 20);
            this.txtOT.TabIndex = 3;
            this.txtOT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMachine_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(68, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "OT :";
            // 
            // txtLabor
            // 
            this.txtLabor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtLabor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLabor.Location = new System.Drawing.Point(104, 71);
            this.txtLabor.MaxLength = 10;
            this.txtLabor.Name = "txtLabor";
            this.txtLabor.Size = new System.Drawing.Size(177, 20);
            this.txtLabor.TabIndex = 2;
            this.txtLabor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMachine_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(56, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Labor :";
            // 
            // txtSetup
            // 
            this.txtSetup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSetup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSetup.Location = new System.Drawing.Point(104, 45);
            this.txtSetup.MaxLength = 10;
            this.txtSetup.Name = "txtSetup";
            this.txtSetup.Size = new System.Drawing.Size(177, 20);
            this.txtSetup.TabIndex = 1;
            this.txtSetup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMachine_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(55, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Setup :";
            // 
            // txtMachine
            // 
            this.txtMachine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMachine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMachine.Location = new System.Drawing.Point(104, 19);
            this.txtMachine.MaxLength = 10;
            this.txtMachine.Name = "txtMachine";
            this.txtMachine.Size = new System.Drawing.Size(177, 20);
            this.txtMachine.TabIndex = 0;
            this.txtMachine.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMachine_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(42, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Machine :";
            // 
            // gDetail
            // 
            this.gDetail.Controls.Add(this.lblPlantCode);
            this.gDetail.Controls.Add(this.lblMaterialCode);
            this.gDetail.Controls.Add(this.cbWorkCenter);
            this.gDetail.Controls.Add(this.label2);
            this.gDetail.Controls.Add(this.label3);
            this.gDetail.Controls.Add(this.label1);
            this.gDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gDetail.Location = new System.Drawing.Point(10, 55);
            this.gDetail.Name = "gDetail";
            this.gDetail.Size = new System.Drawing.Size(297, 116);
            this.gDetail.TabIndex = 0;
            this.gDetail.TabStop = false;
            // 
            // lblPlantCode
            // 
            this.lblPlantCode.AutoSize = true;
            this.lblPlantCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPlantCode.ForeColor = System.Drawing.Color.DimGray;
            this.lblPlantCode.Location = new System.Drawing.Point(101, 51);
            this.lblPlantCode.Name = "lblPlantCode";
            this.lblPlantCode.Size = new System.Drawing.Size(43, 16);
            this.lblPlantCode.TabIndex = 6;
            this.lblPlantCode.Text = "Plant";
            // 
            // lblMaterialCode
            // 
            this.lblMaterialCode.AutoSize = true;
            this.lblMaterialCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblMaterialCode.ForeColor = System.Drawing.Color.DimGray;
            this.lblMaterialCode.Location = new System.Drawing.Point(101, 21);
            this.lblMaterialCode.Name = "lblMaterialCode";
            this.lblMaterialCode.Size = new System.Drawing.Size(72, 16);
            this.lblMaterialCode.TabIndex = 5;
            this.lblMaterialCode.Text = "Material :";
            // 
            // cbWorkCenter
            // 
            this.cbWorkCenter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbWorkCenter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbWorkCenter.FormattingEnabled = true;
            this.cbWorkCenter.Location = new System.Drawing.Point(104, 80);
            this.cbWorkCenter.Name = "cbWorkCenter";
            this.cbWorkCenter.Size = new System.Drawing.Size(177, 23);
            this.cbWorkCenter.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(56, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Plant :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(12, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Work Center :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(38, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Material :";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAdd);
            this.flowLayoutPanel1.Controls.Add(this.btnEdit);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(215, 321);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(92, 38);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.BackgroundImage = global::WMS.Properties.Resources.Add;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Image = global::WMS.Properties.Resources.Close;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.txtSName);
            this.panel1.Controls.Add(this.txtSCode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(898, 31);
            this.panel1.TabIndex = 19;
            // 
            // txtSName
            // 
            this.txtSName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtSName.Location = new System.Drawing.Point(500, 7);
            this.txtSName.MaxLength = 60;
            this.txtSName.Name = "txtSName";
            this.txtSName.Size = new System.Drawing.Size(100, 22);
            this.txtSName.TabIndex = 1;
            this.txtSName.Visible = false;
            // 
            // txtSCode
            // 
            this.txtSCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtSCode.Location = new System.Drawing.Point(379, 7);
            this.txtSCode.MaxLength = 10;
            this.txtSCode.Name = "txtSCode";
            this.txtSCode.Size = new System.Drawing.Size(122, 22);
            this.txtSCode.TabIndex = 0;
            this.txtSCode.Visible = false;
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
            this.pGradientPanel2.TabIndex = 21;
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
            this.pGradientPanel1.Caption = "Production Cost ..";
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
            this.pGradientPanel1.TabIndex = 20;
            // 
            // frmProductionCost
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
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "frmProductionCost";
            this.Load += new System.EventHandler(this.frmProductionCost_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProductionCost_FormClosing);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gDetail.ResumeLayout(false);
            this.gDetail.PerformLayout();
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

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbWorkCenter;
        private System.Windows.Forms.GroupBox gDetail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox btnAdd;
        private System.Windows.Forms.PictureBox btnEdit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSName;
        private System.Windows.Forms.TextBox txtSCode;
        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel2;
        private System.Windows.Forms.PictureBox btnExit;
        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMachine;
        private System.Windows.Forms.TextBox txtOT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLabor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSetup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbProdOrder;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblPlantCode;
        private System.Windows.Forms.Label lblMaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnAutoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnProdOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnMaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPlantCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnWorkCenterCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnMachine;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnSetup;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnLabor;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnOT;
    }
}