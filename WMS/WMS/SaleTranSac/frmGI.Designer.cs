namespace WMS.SaleTranSac
{
    partial class frmGI
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
            this.txtGI = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.groupPR = new System.Windows.Forms.GroupBox();
            this.lblBOMVer = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblPlant = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGenNew = new System.Windows.Forms.PictureBox();
            this.btnRefresh = new System.Windows.Forms.PictureBox();
            this.lblHeadMaterial = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPrdoOrder = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbMaterial = new System.Windows.Forms.ComboBox();
            this.pMaterial = new System.Windows.Forms.Panel();
            this.btnAddDetail = new System.Windows.Forms.PictureBox();
            this.lblMaterialName = new System.Windows.Forms.Label();
            this.txtDocDate = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddGI = new System.Windows.Forms.PictureBox();
            this.btnCancelGI = new System.Windows.Forms.PictureBox();
            this.pGradientPanel2 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.pGradientPanel1 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.dgvView = new System.Windows.Forms.DataGridView();
            this.clnItemNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnMaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnMaterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnBatchNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnUnitCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPRNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPlantCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPlantName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnLocCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnLocName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPrdOQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnFGStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupPR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            this.pMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddDetail)).BeginInit();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddGI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelGI)).BeginInit();
            this.pGradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.SuspendLayout();
            // 
            // txtGI
            // 
            this.txtGI.BackColor = System.Drawing.SystemColors.Info;
            this.txtGI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.txtGI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtGI.FormattingEnabled = true;
            this.txtGI.Location = new System.Drawing.Point(104, 12);
            this.txtGI.Name = "txtGI";
            this.txtGI.Size = new System.Drawing.Size(153, 22);
            this.txtGI.TabIndex = 27;
            this.txtGI.SelectedIndexChanged += new System.EventHandler(this.txtGI_SelectedIndexChanged);
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
            // txtRemark
            // 
            this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRemark.Location = new System.Drawing.Point(104, 117);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(428, 21);
            this.txtRemark.TabIndex = 18;
            // 
            // groupPR
            // 
            this.groupPR.Controls.Add(this.lblBOMVer);
            this.groupPR.Controls.Add(this.label5);
            this.groupPR.Controls.Add(this.label3);
            this.groupPR.Controls.Add(this.lblLocation);
            this.groupPR.Controls.Add(this.lblPlant);
            this.groupPR.Controls.Add(this.label6);
            this.groupPR.Controls.Add(this.txtGI);
            this.groupPR.Controls.Add(this.btnGenNew);
            this.groupPR.Controls.Add(this.btnRefresh);
            this.groupPR.Controls.Add(this.txtRemark);
            this.groupPR.Controls.Add(this.label8);
            this.groupPR.Controls.Add(this.lblHeadMaterial);
            this.groupPR.Controls.Add(this.label1);
            this.groupPR.Controls.Add(this.label2);
            this.groupPR.Controls.Add(this.cbPrdoOrder);
            this.groupPR.Location = new System.Drawing.Point(3, 1);
            this.groupPR.Name = "groupPR";
            this.groupPR.Size = new System.Drawing.Size(540, 148);
            this.groupPR.TabIndex = 12;
            this.groupPR.TabStop = false;
            // 
            // lblBOMVer
            // 
            this.lblBOMVer.BackColor = System.Drawing.Color.Orange;
            this.lblBOMVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblBOMVer.ForeColor = System.Drawing.Color.Black;
            this.lblBOMVer.Location = new System.Drawing.Point(374, 79);
            this.lblBOMVer.Name = "lblBOMVer";
            this.lblBOMVer.Size = new System.Drawing.Size(157, 23);
            this.lblBOMVer.TabIndex = 42;
            this.lblBOMVer.Text = "BOM Ver";
            this.lblBOMVer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(292, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 18);
            this.label5.TabIndex = 41;
            this.label5.Text = "BOM Ver :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(327, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 40;
            this.label3.Text = "Plant :";
            // 
            // lblLocation
            // 
            this.lblLocation.BackColor = System.Drawing.Color.Khaki;
            this.lblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblLocation.ForeColor = System.Drawing.Color.Black;
            this.lblLocation.Location = new System.Drawing.Point(374, 53);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(157, 16);
            this.lblLocation.TabIndex = 39;
            this.lblLocation.Text = "Location :";
            this.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlant
            // 
            this.lblPlant.BackColor = System.Drawing.Color.Khaki;
            this.lblPlant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPlant.ForeColor = System.Drawing.Color.Black;
            this.lblPlant.Location = new System.Drawing.Point(374, 25);
            this.lblPlant.Name = "lblPlant";
            this.lblPlant.Size = new System.Drawing.Size(157, 16);
            this.lblPlant.TabIndex = 38;
            this.lblPlant.Text = "Plant";
            this.lblPlant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(304, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 16);
            this.label6.TabIndex = 37;
            this.label6.Text = "Location :";
            // 
            // btnGenNew
            // 
            this.btnGenNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGenNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenNew.Image = global::WMS.Properties.Resources.add2;
            this.btnGenNew.Location = new System.Drawing.Point(263, 14);
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
            this.btnRefresh.Location = new System.Drawing.Point(285, 14);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(18, 19);
            this.btnRefresh.TabIndex = 25;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblHeadMaterial
            // 
            this.lblHeadMaterial.BackColor = System.Drawing.Color.Khaki;
            this.lblHeadMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblHeadMaterial.ForeColor = System.Drawing.Color.Black;
            this.lblHeadMaterial.Location = new System.Drawing.Point(104, 68);
            this.lblHeadMaterial.Name = "lblHeadMaterial";
            this.lblHeadMaterial.Size = new System.Drawing.Size(153, 39);
            this.lblHeadMaterial.TabIndex = 12;
            this.lblHeadMaterial.Text = "MaterialName :";
            this.lblHeadMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "GI Number :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(18, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Prod Order :";
            // 
            // cbPrdoOrder
            // 
            this.cbPrdoOrder.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPrdoOrder.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPrdoOrder.FormattingEnabled = true;
            this.cbPrdoOrder.Location = new System.Drawing.Point(104, 40);
            this.cbPrdoOrder.Name = "cbPrdoOrder";
            this.cbPrdoOrder.Size = new System.Drawing.Size(154, 21);
            this.cbPrdoOrder.TabIndex = 0;
            this.cbPrdoOrder.SelectedIndexChanged += new System.EventHandler(this.cbPrdoOrder_SelectedIndexChanged);
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
            this.cbMaterial.DropDownWidth = 500;
            this.cbMaterial.FormattingEnabled = true;
            this.cbMaterial.Location = new System.Drawing.Point(75, 6);
            this.cbMaterial.Name = "cbMaterial";
            this.cbMaterial.Size = new System.Drawing.Size(154, 21);
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
            this.pMaterial.Location = new System.Drawing.Point(0, 209);
            this.pMaterial.Name = "pMaterial";
            this.pMaterial.Size = new System.Drawing.Size(683, 33);
            this.pMaterial.TabIndex = 35;
            // 
            // btnAddDetail
            // 
            this.btnAddDetail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAddDetail.BackgroundImage = global::WMS.Properties.Resources.Add;
            this.btnAddDetail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddDetail.Location = new System.Drawing.Point(594, 2);
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
            this.lblMaterialName.Size = new System.Drawing.Size(237, 16);
            this.lblMaterialName.TabIndex = 13;
            this.lblMaterialName.Text = "Material Name";
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
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(683, 159);
            this.panel2.TabIndex = 34;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(550, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(128, 20);
            this.textBox1.TabIndex = 15;
            this.textBox1.Visible = false;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAddGI);
            this.flowLayoutPanel1.Controls.Add(this.btnCancelGI);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(546, 114);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(130, 33);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // btnAddGI
            // 
            this.btnAddGI.BackColor = System.Drawing.Color.White;
            this.btnAddGI.BackgroundImage = global::WMS.Properties.Resources.AddHeaderGI;
            this.btnAddGI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddGI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddGI.Location = new System.Drawing.Point(3, 3);
            this.btnAddGI.Name = "btnAddGI";
            this.btnAddGI.Size = new System.Drawing.Size(130, 30);
            this.btnAddGI.TabIndex = 1;
            this.btnAddGI.TabStop = false;
            this.btnAddGI.Click += new System.EventHandler(this.btnAddGI_Click);
            // 
            // btnCancelGI
            // 
            this.btnCancelGI.BackColor = System.Drawing.Color.White;
            this.btnCancelGI.BackgroundImage = global::WMS.Properties.Resources.CancelGI;
            this.btnCancelGI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelGI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelGI.Location = new System.Drawing.Point(3, 39);
            this.btnCancelGI.Name = "btnCancelGI";
            this.btnCancelGI.Size = new System.Drawing.Size(130, 30);
            this.btnCancelGI.TabIndex = 13;
            this.btnCancelGI.TabStop = false;
            this.btnCancelGI.Click += new System.EventHandler(this.btnCancelGI_Click);
            // 
            // pGradientPanel2
            // 
            this.pGradientPanel2.Caption = null;
            this.pGradientPanel2.ColorFrom = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pGradientPanel2.ColorTo = System.Drawing.Color.White;
            this.pGradientPanel2.Controls.Add(this.label9);
            this.pGradientPanel2.Controls.Add(this.btnSave);
            this.pGradientPanel2.Controls.Add(this.label4);
            this.pGradientPanel2.Controls.Add(this.label10);
            this.pGradientPanel2.Controls.Add(this.btnExit);
            this.pGradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pGradientPanel2.FontOffset = new System.Drawing.Size(0, 0);
            this.pGradientPanel2.ImageHeader = null;
            this.pGradientPanel2.ImageOffset = new System.Drawing.Size(0, 0);
            this.pGradientPanel2.ImageSize = new System.Drawing.Size(0, 0);
            this.pGradientPanel2.LinearGradientType = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.pGradientPanel2.Location = new System.Drawing.Point(0, 498);
            this.pGradientPanel2.Name = "pGradientPanel2";
            this.pGradientPanel2.Size = new System.Drawing.Size(683, 35);
            this.pGradientPanel2.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.PaleGreen;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.Location = new System.Drawing.Point(225, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 19);
            this.label9.TabIndex = 50;
            this.label9.Text = "*Normal";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.BackgroundImage = global::WMS.Properties.Resources.Save;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Location = new System.Drawing.Point(509, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 29);
            this.btnSave.TabIndex = 15;
            this.btnSave.TabStop = false;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.PaleVioletRed;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(126, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 18);
            this.label4.TabIndex = 49;
            this.label4.Text = "*Over SO Qty";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.OrangeRed;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label10.Location = new System.Drawing.Point(10, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 18);
            this.label10.TabIndex = 48;
            this.label10.Text = "*Over Stock Qty";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackgroundImage = global::WMS.Properties.Resources.Exit;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Location = new System.Drawing.Point(598, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(82, 30);
            this.btnExit.TabIndex = 0;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pGradientPanel1
            // 
            this.pGradientPanel1.Caption = "Goods Issue ...";
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
            this.clnMaterialCode,
            this.clnMaterialName,
            this.clnBatchNumber,
            this.clnQuantity,
            this.clnUnitName,
            this.clnUnitCode,
            this.clnPRNumber,
            this.clnPlantCode,
            this.clnPlantName,
            this.clnLocCode,
            this.clnLocName,
            this.clnPrdOQty,
            this.clnFGStock});
            this.dgvView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvView.Location = new System.Drawing.Point(0, 242);
            this.dgvView.MultiSelect = false;
            this.dgvView.Name = "dgvView";
            this.dgvView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvView.Size = new System.Drawing.Size(683, 256);
            this.dgvView.TabIndex = 36;
            this.dgvView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvView_CellFormatting);
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
            // clnQuantity
            // 
            this.clnQuantity.DataPropertyName = "Qty";
            this.clnQuantity.HeaderText = "GI Quantity";
            this.clnQuantity.Name = "clnQuantity";
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
            // clnPRNumber
            // 
            this.clnPRNumber.DataPropertyName = "PrdONumber";
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
            // clnPrdOQty
            // 
            this.clnPrdOQty.DataPropertyName = "PrdOQty";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.clnPrdOQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.clnPrdOQty.HeaderText = "Prd Order Qty";
            this.clnPrdOQty.Name = "clnPrdOQty";
            this.clnPrdOQty.ReadOnly = true;
            this.clnPrdOQty.Width = 120;
            // 
            // clnFGStock
            // 
            this.clnFGStock.DataPropertyName = "QI";
            dataGridViewCellStyle4.Format = "N3";
            this.clnFGStock.DefaultCellStyle = dataGridViewCellStyle4;
            this.clnFGStock.HeaderText = "Stock Qty";
            this.clnFGStock.Name = "clnFGStock";
            this.clnFGStock.ReadOnly = true;
            // 
            // frmGI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(683, 533);
            this.ControlBox = false;
            this.Controls.Add(this.dgvView);
            this.Controls.Add(this.pMaterial);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pGradientPanel2);
            this.Controls.Add(this.pGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmGI";
            this.Load += new System.EventHandler(this.frmGI_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGI_FormClosing);
            this.groupPR.ResumeLayout(false);
            this.groupPR.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            this.pMaterial.ResumeLayout(false);
            this.pMaterial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddDetail)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAddGI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelGI)).EndInit();
            this.pGradientPanel2.ResumeLayout(false);
            this.pGradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox txtGI;
        private System.Windows.Forms.PictureBox btnGenNew;
        private System.Windows.Forms.PictureBox btnRefresh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.GroupBox groupPR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPrdoOrder;
        private System.Windows.Forms.PictureBox btnAddGI;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbMaterial;
        private System.Windows.Forms.Panel pMaterial;
        private System.Windows.Forms.PictureBox btnAddDetail;
        private System.Windows.Forms.Label lblMaterialName;
        private System.Windows.Forms.TextBox txtDocDate;
        private System.Windows.Forms.PictureBox btnCancelGI;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel2;
        private System.Windows.Forms.PictureBox btnSave;
        private System.Windows.Forms.PictureBox btnExit;
        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel1;
        private System.Windows.Forms.Label lblHeadMaterial;
        private System.Windows.Forms.Label lblBOMVer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblPlant;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvView;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnItemNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnMaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnMaterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnBatchNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnUnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnUnitCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPRNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPlantCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPlantName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnLocCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnLocName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPrdOQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnFGStock;
    }
}