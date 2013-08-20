namespace WMS.SaleTranSac
{
    partial class frmSaleOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtDocDate = new System.Windows.Forms.TextBox();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.groupPR = new System.Windows.Forms.GroupBox();
            this.txtSO = new System.Windows.Forms.ComboBox();
            this.btnGenNew = new System.Windows.Forms.PictureBox();
            this.btnRefresh = new System.Windows.Forms.PictureBox();
            this.txtCustPO = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTerm = new System.Windows.Forms.Label();
            this.cbCustomer = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAppr = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddSO = new System.Windows.Forms.PictureBox();
            this.btnCancelSO = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pGradientPanel1 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.pGradientPanel2 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.btnSave = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.pMaterial = new System.Windows.Forms.Panel();
            this.btnAddDetail = new System.Windows.Forms.PictureBox();
            this.lblMaterialName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbMaterial = new System.Windows.Forms.ComboBox();
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeletetoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupPR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAppr)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddSO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelSO)).BeginInit();
            this.pGradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.pMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCustomer
            // 
            this.lblCustomer.BackColor = System.Drawing.Color.Khaki;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblCustomer.ForeColor = System.Drawing.Color.Black;
            this.lblCustomer.Location = new System.Drawing.Point(103, 68);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(430, 39);
            this.lblCustomer.TabIndex = 12;
            this.lblCustomer.Text = "Customer Name :";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDocDate
            // 
            this.txtDocDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtDocDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtDocDate.Location = new System.Drawing.Point(858, 6);
            this.txtDocDate.Name = "txtDocDate";
            this.txtDocDate.Size = new System.Drawing.Size(128, 26);
            this.txtDocDate.TabIndex = 5;
            this.txtDocDate.Text = "dd/MM/yyyy";
            this.txtDocDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCurrency
            // 
            this.lblCurrency.BackColor = System.Drawing.Color.Khaki;
            this.lblCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblCurrency.ForeColor = System.Drawing.Color.Black;
            this.lblCurrency.Location = new System.Drawing.Point(690, 87);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(139, 16);
            this.lblCurrency.TabIndex = 11;
            this.lblCurrency.Text = "Currency :";
            this.lblCurrency.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupPR
            // 
            this.groupPR.Controls.Add(this.txtSO);
            this.groupPR.Controls.Add(this.btnGenNew);
            this.groupPR.Controls.Add(this.btnRefresh);
            this.groupPR.Controls.Add(this.txtCustPO);
            this.groupPR.Controls.Add(this.label8);
            this.groupPR.Controls.Add(this.txtRemark);
            this.groupPR.Controls.Add(this.label3);
            this.groupPR.Controls.Add(this.lblCustomer);
            this.groupPR.Controls.Add(this.label1);
            this.groupPR.Controls.Add(this.lblCurrency);
            this.groupPR.Controls.Add(this.label2);
            this.groupPR.Controls.Add(this.lblTerm);
            this.groupPR.Controls.Add(this.cbCustomer);
            this.groupPR.Controls.Add(this.label6);
            this.groupPR.Controls.Add(this.label5);
            this.groupPR.Location = new System.Drawing.Point(3, 1);
            this.groupPR.Name = "groupPR";
            this.groupPR.Size = new System.Drawing.Size(847, 170);
            this.groupPR.TabIndex = 12;
            this.groupPR.TabStop = false;
            // 
            // txtSO
            // 
            this.txtSO.BackColor = System.Drawing.SystemColors.Info;
            this.txtSO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.txtSO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtSO.FormattingEnabled = true;
            this.txtSO.Location = new System.Drawing.Point(103, 12);
            this.txtSO.Name = "txtSO";
            this.txtSO.Size = new System.Drawing.Size(157, 22);
            this.txtSO.TabIndex = 29;
            this.txtSO.SelectedIndexChanged += new System.EventHandler(this.txtSO_SelectedIndexChanged);
            // 
            // btnGenNew
            // 
            this.btnGenNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGenNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenNew.Image = global::WMS.Properties.Resources.add2;
            this.btnGenNew.Location = new System.Drawing.Point(265, 14);
            this.btnGenNew.Name = "btnGenNew";
            this.btnGenNew.Size = new System.Drawing.Size(18, 19);
            this.btnGenNew.TabIndex = 28;
            this.btnGenNew.TabStop = false;
            this.btnGenNew.Click += new System.EventHandler(this.btnGenNew_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Image = global::WMS.Properties.Resources.refresh;
            this.btnRefresh.Location = new System.Drawing.Point(287, 14);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(18, 19);
            this.btnRefresh.TabIndex = 27;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtCustPO
            // 
            this.txtCustPO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCustPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtCustPO.Location = new System.Drawing.Point(568, 33);
            this.txtCustPO.MaxLength = 20;
            this.txtCustPO.Name = "txtCustPO";
            this.txtCustPO.Size = new System.Drawing.Size(261, 22);
            this.txtCustPO.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(34, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 16);
            this.label8.TabIndex = 13;
            this.label8.Text = "Remark :";
            // 
            // txtRemark
            // 
            this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRemark.Location = new System.Drawing.Point(103, 113);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(726, 51);
            this.txtRemark.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(565, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Purchase Order :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sales Order :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(25, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Customer :";
            // 
            // lblTerm
            // 
            this.lblTerm.BackColor = System.Drawing.Color.Khaki;
            this.lblTerm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblTerm.ForeColor = System.Drawing.Color.Black;
            this.lblTerm.Location = new System.Drawing.Point(690, 65);
            this.lblTerm.Name = "lblTerm";
            this.lblTerm.Size = new System.Drawing.Size(139, 16);
            this.lblTerm.TabIndex = 10;
            this.lblTerm.Text = "Terms of payment :";
            this.lblTerm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbCustomer
            // 
            this.cbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCustomer.DropDownWidth = 500;
            this.cbCustomer.FormattingEnabled = true;
            this.cbCustomer.Location = new System.Drawing.Point(103, 40);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(430, 21);
            this.cbCustomer.TabIndex = 0;
            this.cbCustomer.SelectedIndexChanged += new System.EventHandler(this.cbCustomer_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(620, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Currency :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(565, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Terms of payment :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAppr);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.txtDocDate);
            this.panel2.Controls.Add(this.groupPR);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(998, 175);
            this.panel2.TabIndex = 39;
            // 
            // btnAppr
            // 
            this.btnAppr.BackColor = System.Drawing.Color.White;
            this.btnAppr.BackgroundImage = global::WMS.Properties.Resources.Approve;
            this.btnAppr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAppr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAppr.Location = new System.Drawing.Point(869, 61);
            this.btnAppr.Name = "btnAppr";
            this.btnAppr.Size = new System.Drawing.Size(106, 30);
            this.btnAppr.TabIndex = 43;
            this.btnAppr.TabStop = false;
            this.btnAppr.Visible = false;
            this.btnAppr.Click += new System.EventHandler(this.btnAppr_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAddSO);
            this.flowLayoutPanel1.Controls.Add(this.btnCancelSO);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(856, 106);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(130, 33);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // btnAddSO
            // 
            this.btnAddSO.BackColor = System.Drawing.Color.White;
            this.btnAddSO.BackgroundImage = global::WMS.Properties.Resources.AddSaleOrder;
            this.btnAddSO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddSO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddSO.Location = new System.Drawing.Point(3, 3);
            this.btnAddSO.Name = "btnAddSO";
            this.btnAddSO.Size = new System.Drawing.Size(130, 30);
            this.btnAddSO.TabIndex = 1;
            this.btnAddSO.TabStop = false;
            this.btnAddSO.Click += new System.EventHandler(this.btnAddSO_Click);
            // 
            // btnCancelSO
            // 
            this.btnCancelSO.BackColor = System.Drawing.Color.White;
            this.btnCancelSO.BackgroundImage = global::WMS.Properties.Resources.CancelOrder;
            this.btnCancelSO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelSO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelSO.Location = new System.Drawing.Point(3, 39);
            this.btnCancelSO.Name = "btnCancelSO";
            this.btnCancelSO.Size = new System.Drawing.Size(130, 30);
            this.btnCancelSO.TabIndex = 13;
            this.btnCancelSO.TabStop = false;
            this.btnCancelSO.Click += new System.EventHandler(this.btnCancelSO_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(858, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(128, 20);
            this.textBox1.TabIndex = 42;
            this.textBox1.Visible = false;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // pGradientPanel1
            // 
            this.pGradientPanel1.Caption = "Sales Order ...";
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
            this.pGradientPanel1.TabIndex = 37;
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
            this.pGradientPanel2.TabIndex = 38;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.BackgroundImage = global::WMS.Properties.Resources.Save;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Location = new System.Drawing.Point(820, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 29);
            this.btnSave.TabIndex = 45;
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
            this.btnExit.Location = new System.Drawing.Point(908, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(87, 30);
            this.btnExit.TabIndex = 0;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pMaterial
            // 
            this.pMaterial.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pMaterial.Controls.Add(this.btnAddDetail);
            this.pMaterial.Controls.Add(this.lblMaterialName);
            this.pMaterial.Controls.Add(this.label7);
            this.pMaterial.Controls.Add(this.cbMaterial);
            this.pMaterial.Dock = System.Windows.Forms.DockStyle.Top;
            this.pMaterial.Location = new System.Drawing.Point(0, 225);
            this.pMaterial.Name = "pMaterial";
            this.pMaterial.Size = new System.Drawing.Size(998, 33);
            this.pMaterial.TabIndex = 44;
            // 
            // btnAddDetail
            // 
            this.btnAddDetail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAddDetail.BackgroundImage = global::WMS.Properties.Resources.Add;
            this.btnAddDetail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddDetail.Location = new System.Drawing.Point(879, -2);
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
            this.lblMaterialName.Location = new System.Drawing.Point(315, 9);
            this.lblMaterialName.Name = "lblMaterialName";
            this.lblMaterialName.Size = new System.Drawing.Size(517, 16);
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
            this.cbMaterial.DropDownWidth = 200;
            this.cbMaterial.FormattingEnabled = true;
            this.cbMaterial.Location = new System.Drawing.Point(75, 6);
            this.cbMaterial.Name = "cbMaterial";
            this.cbMaterial.Size = new System.Drawing.Size(233, 21);
            this.cbMaterial.TabIndex = 3;
            this.cbMaterial.SelectedIndexChanged += new System.EventHandler(this.cbMaterial_SelectedIndexChanged);
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
            this.clnLocName});
            this.dgvView.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvView.Location = new System.Drawing.Point(0, 258);
            this.dgvView.MultiSelect = false;
            this.dgvView.Name = "dgvView";
            this.dgvView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvView.Size = new System.Drawing.Size(998, 355);
            this.dgvView.TabIndex = 45;
            this.dgvView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvView_CellEndEdit);
            this.dgvView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvView_EditingControlShowing);
            // 
            // clnItemNo
            // 
            this.clnItemNo.DataPropertyName = "ItemNo";
            dataGridViewCellStyle15.Format = "N0";
            dataGridViewCellStyle15.NullValue = "0";
            this.clnItemNo.DefaultCellStyle = dataGridViewCellStyle15;
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
            dataGridViewCellStyle16.Format = "N2";
            dataGridViewCellStyle16.NullValue = null;
            this.clnQuantity.DefaultCellStyle = dataGridViewCellStyle16;
            this.clnQuantity.HeaderText = "Quantity";
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
            dataGridViewCellStyle17.NullValue = null;
            this.clnUnitCode.DefaultCellStyle = dataGridViewCellStyle17;
            this.clnUnitCode.HeaderText = "UnitCode";
            this.clnUnitCode.Name = "clnUnitCode";
            this.clnUnitCode.ReadOnly = true;
            this.clnUnitCode.Visible = false;
            // 
            // clnNetPrice
            // 
            this.clnNetPrice.DataPropertyName = "NetPrice";
            dataGridViewCellStyle18.Format = "N2";
            dataGridViewCellStyle18.NullValue = null;
            this.clnNetPrice.DefaultCellStyle = dataGridViewCellStyle18;
            this.clnNetPrice.HeaderText = "Net Price";
            this.clnNetPrice.Name = "clnNetPrice";
            this.clnNetPrice.ReadOnly = true;
            // 
            // clnAmount
            // 
            this.clnAmount.DataPropertyName = "Amt";
            dataGridViewCellStyle19.Format = "N2";
            dataGridViewCellStyle19.NullValue = null;
            this.clnAmount.DefaultCellStyle = dataGridViewCellStyle19;
            this.clnAmount.HeaderText = "Amount";
            this.clnAmount.Name = "clnAmount";
            this.clnAmount.ReadOnly = true;
            // 
            // clnDeliveryDate
            // 
            this.clnDeliveryDate.DataPropertyName = "DeliveryDate";
            dataGridViewCellStyle20.Format = "dd/MM/yyyy";
            this.clnDeliveryDate.DefaultCellStyle = dataGridViewCellStyle20;
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeletetoolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 26);
            // 
            // DeletetoolStripMenuItem1
            // 
            this.DeletetoolStripMenuItem1.Image = global::WMS.Properties.Resources.error;
            this.DeletetoolStripMenuItem1.Name = "DeletetoolStripMenuItem1";
            this.DeletetoolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.DeletetoolStripMenuItem1.Text = "Delete";
            this.DeletetoolStripMenuItem1.Click += new System.EventHandler(this.DeletetoolStripMenuItem1_Click);
            // 
            // frmSaleOrder
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
            this.Name = "frmSaleOrder";
            this.Load += new System.EventHandler(this.frmSaleOrder_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSaleOrder_FormClosing);
            this.groupPR.ResumeLayout(false);
            this.groupPR.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAppr)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAddSO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelSO)).EndInit();
            this.pGradientPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.pMaterial.ResumeLayout(false);
            this.pMaterial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtDocDate;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.GroupBox groupPR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTerm;
        private System.Windows.Forms.ComboBox cbCustomer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRemark;
        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel2;
        private System.Windows.Forms.PictureBox btnExit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustPO;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox btnAddSO;
        private System.Windows.Forms.PictureBox btnCancelSO;
        private System.Windows.Forms.PictureBox btnAppr;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel pMaterial;
        private System.Windows.Forms.PictureBox btnAddDetail;
        private System.Windows.Forms.Label lblMaterialName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbMaterial;
        private System.Windows.Forms.PictureBox btnGenNew;
        private System.Windows.Forms.PictureBox btnRefresh;
        private System.Windows.Forms.PictureBox btnSave;
        private System.Windows.Forms.ComboBox txtSO;
        private System.Windows.Forms.DataGridView dgvView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem DeletetoolStripMenuItem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnItemNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnMaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnMaterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnUnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnUnitCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNetPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnAmount;
        private frmSaleOrder.CalendarColumn clnDeliveryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPRNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPlantCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPlantName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnLocCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnLocName;
    }
}