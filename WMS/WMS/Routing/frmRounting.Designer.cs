namespace WMS.Routing
{
    partial class frmRounting
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvView = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtHour = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStdManHour = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbWorkCenter = new System.Windows.Forms.ComboBox();
            this.gDetail = new System.Windows.Forms.GroupBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBaseQuantity = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbPlant = new System.Windows.Forms.ComboBox();
            this.cbMaterial = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.PictureBox();
            this.btnEdit = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pGradientPanel2 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSName = new System.Windows.Forms.TextBox();
            this.txtSCode = new System.Windows.Forms.TextBox();
            this.pGradientPanel1 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.clnNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlantCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnWorkCenterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BaseQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StdManHour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gDetail.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).BeginInit();
            this.pGradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.panel3.TabIndex = 18;
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
            this.clnNo,
            this.MaterialCode,
            this.PlantCode,
            this.clnName,
            this.clnWorkCenterName,
            this.BaseQuantity,
            this.StdManHour,
            this.Hours,
            this.Remark});
            this.dgvView.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvView.Location = new System.Drawing.Point(318, 0);
            this.dgvView.MultiSelect = false;
            this.dgvView.Name = "dgvView";
            this.dgvView.ReadOnly = true;
            this.dgvView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvView.Size = new System.Drawing.Size(580, 382);
            this.dgvView.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.deleteAllToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 70);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::WMS.Properties.Resources.edit_2;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::WMS.Properties.Resources.error;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // deleteAllToolStripMenuItem
            // 
            this.deleteAllToolStripMenuItem.Image = global::WMS.Properties.Resources.folder_forbidden;
            this.deleteAllToolStripMenuItem.Name = "deleteAllToolStripMenuItem";
            this.deleteAllToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.deleteAllToolStripMenuItem.Text = "Delete All";
            this.deleteAllToolStripMenuItem.Click += new System.EventHandler(this.deleteAllToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtHour);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtStdManHour);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cbWorkCenter);
            this.panel2.Controls.Add(this.gDetail);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(318, 382);
            this.panel2.TabIndex = 0;
            // 
            // txtHour
            // 
            this.txtHour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtHour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHour.Location = new System.Drawing.Point(105, 302);
            this.txtHour.MaxLength = 10;
            this.txtHour.Name = "txtHour";
            this.txtHour.Size = new System.Drawing.Size(195, 20);
            this.txtHour.TabIndex = 25;
            this.txtHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(12, 302);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 16);
            this.label6.TabIndex = 26;
            this.label6.Text = "STD Hour(s) :";
            // 
            // txtStdManHour
            // 
            this.txtStdManHour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtStdManHour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStdManHour.Location = new System.Drawing.Point(105, 276);
            this.txtStdManHour.MaxLength = 10;
            this.txtStdManHour.Name = "txtStdManHour";
            this.txtStdManHour.Size = new System.Drawing.Size(195, 20);
            this.txtStdManHour.TabIndex = 23;
            this.txtStdManHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(15, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "STD Man(s) :";
            // 
            // cbWorkCenter
            // 
            this.cbWorkCenter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbWorkCenter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbWorkCenter.FormattingEnabled = true;
            this.cbWorkCenter.Location = new System.Drawing.Point(105, 248);
            this.cbWorkCenter.Name = "cbWorkCenter";
            this.cbWorkCenter.Size = new System.Drawing.Size(193, 21);
            this.cbWorkCenter.TabIndex = 0;
            // 
            // gDetail
            // 
            this.gDetail.Controls.Add(this.txtRemark);
            this.gDetail.Controls.Add(this.label4);
            this.gDetail.Controls.Add(this.txtBaseQuantity);
            this.gDetail.Controls.Add(this.label12);
            this.gDetail.Controls.Add(this.cbPlant);
            this.gDetail.Controls.Add(this.cbMaterial);
            this.gDetail.Controls.Add(this.label2);
            this.gDetail.Controls.Add(this.label1);
            this.gDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gDetail.Location = new System.Drawing.Point(10, 19);
            this.gDetail.Name = "gDetail";
            this.gDetail.Size = new System.Drawing.Size(297, 188);
            this.gDetail.TabIndex = 0;
            this.gDetail.TabStop = false;
            // 
            // txtRemark
            // 
            this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark.Location = new System.Drawing.Point(95, 121);
            this.txtRemark.MaxLength = 255;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(190, 56);
            this.txtRemark.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 24;
            this.label4.Text = "Remark :";
            // 
            // txtBaseQuantity
            // 
            this.txtBaseQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtBaseQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBaseQuantity.Location = new System.Drawing.Point(95, 91);
            this.txtBaseQuantity.MaxLength = 10;
            this.txtBaseQuantity.Name = "txtBaseQuantity";
            this.txtBaseQuantity.Size = new System.Drawing.Size(190, 21);
            this.txtBaseQuantity.TabIndex = 21;
            this.txtBaseQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(1, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 15);
            this.label12.TabIndex = 22;
            this.label12.Text = "Base Quantity :";
            // 
            // cbPlant
            // 
            this.cbPlant.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPlant.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPlant.FormattingEnabled = true;
            this.cbPlant.Location = new System.Drawing.Point(95, 59);
            this.cbPlant.Name = "cbPlant";
            this.cbPlant.Size = new System.Drawing.Size(190, 23);
            this.cbPlant.TabIndex = 1;
            this.cbPlant.SelectedIndexChanged += new System.EventHandler(this.cbPlant_SelectedIndexChanged);
            // 
            // cbMaterial
            // 
            this.cbMaterial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbMaterial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbMaterial.FormattingEnabled = true;
            this.cbMaterial.Location = new System.Drawing.Point(95, 28);
            this.cbMaterial.Name = "cbMaterial";
            this.cbMaterial.Size = new System.Drawing.Size(190, 23);
            this.cbMaterial.TabIndex = 0;
            this.cbMaterial.SelectedIndexChanged += new System.EventHandler(this.cbMaterial_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(45, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Plant :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(27, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Material :";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAdd);
            this.flowLayoutPanel1.Controls.Add(this.btnEdit);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(208, 328);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(13, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Work Center :";
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
            this.pGradientPanel2.TabIndex = 17;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.txtSName);
            this.panel1.Controls.Add(this.txtSCode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(898, 31);
            this.panel1.TabIndex = 15;
            // 
            // txtSName
            // 
            this.txtSName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtSName.Location = new System.Drawing.Point(568, 7);
            this.txtSName.MaxLength = 60;
            this.txtSName.Name = "txtSName";
            this.txtSName.Size = new System.Drawing.Size(203, 22);
            this.txtSName.TabIndex = 1;
            this.txtSName.Visible = false;
            // 
            // txtSCode
            // 
            this.txtSCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtSCode.Location = new System.Drawing.Point(419, 7);
            this.txtSCode.MaxLength = 10;
            this.txtSCode.Name = "txtSCode";
            this.txtSCode.Size = new System.Drawing.Size(150, 22);
            this.txtSCode.TabIndex = 0;
            this.txtSCode.Visible = false;
            // 
            // pGradientPanel1
            // 
            this.pGradientPanel1.Caption = "Routing ..";
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
            this.pGradientPanel1.TabIndex = 16;
            // 
            // clnNo
            // 
            this.clnNo.DataPropertyName = "No";
            this.clnNo.HeaderText = "Item";
            this.clnNo.Name = "clnNo";
            this.clnNo.ReadOnly = true;
            this.clnNo.Width = 60;
            // 
            // MaterialCode
            // 
            this.MaterialCode.DataPropertyName = "MaterialCode";
            this.MaterialCode.HeaderText = "MaterialCode";
            this.MaterialCode.Name = "MaterialCode";
            this.MaterialCode.ReadOnly = true;
            this.MaterialCode.Visible = false;
            // 
            // PlantCode
            // 
            this.PlantCode.DataPropertyName = "PlantCode";
            this.PlantCode.HeaderText = "PlantCode";
            this.PlantCode.Name = "PlantCode";
            this.PlantCode.ReadOnly = true;
            this.PlantCode.Visible = false;
            // 
            // clnName
            // 
            this.clnName.DataPropertyName = "WorkCenterCode";
            this.clnName.HeaderText = "WorkCenter";
            this.clnName.Name = "clnName";
            this.clnName.ReadOnly = true;
            this.clnName.Width = 150;
            // 
            // clnWorkCenterName
            // 
            this.clnWorkCenterName.DataPropertyName = "WorkCenterName";
            this.clnWorkCenterName.HeaderText = "Name";
            this.clnWorkCenterName.Name = "clnWorkCenterName";
            this.clnWorkCenterName.ReadOnly = true;
            this.clnWorkCenterName.Width = 180;
            // 
            // BaseQuantity
            // 
            this.BaseQuantity.DataPropertyName = "BaseQuantity";
            this.BaseQuantity.HeaderText = "Base Quantity";
            this.BaseQuantity.Name = "BaseQuantity";
            this.BaseQuantity.ReadOnly = true;
            this.BaseQuantity.Visible = false;
            this.BaseQuantity.Width = 120;
            // 
            // StdManHour
            // 
            this.StdManHour.DataPropertyName = "STDManHour";
            this.StdManHour.HeaderText = "Std Man(s)";
            this.StdManHour.Name = "StdManHour";
            this.StdManHour.ReadOnly = true;
            // 
            // Hours
            // 
            this.Hours.DataPropertyName = "Hours";
            this.Hours.HeaderText = "Std Hour(s)";
            this.Hours.Name = "Hours";
            this.Hours.ReadOnly = true;
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "Remark";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            this.Remark.Width = 150;
            // 
            // frmRounting
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
            this.Name = "frmRounting";
            this.Load += new System.EventHandler(this.frmRounting_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRounting_FormClosing);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gDetail.ResumeLayout(false);
            this.gDetail.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).EndInit();
            this.pGradientPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox gDetail;
        private System.Windows.Forms.ComboBox cbMaterial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox btnAdd;
        private System.Windows.Forms.PictureBox btnEdit;
        private System.Windows.Forms.PictureBox btnExit;
        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel2;
        private System.Windows.Forms.Panel panel1;
        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel1;
        private System.Windows.Forms.ComboBox cbWorkCenter;
        private System.Windows.Forms.ComboBox cbPlant;
        private System.Windows.Forms.TextBox txtSName;
        private System.Windows.Forms.TextBox txtSCode;
        private System.Windows.Forms.ToolStripMenuItem deleteAllToolStripMenuItem;
        private System.Windows.Forms.TextBox txtBaseQuantity;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStdManHour;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.TextBox txtHour;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlantCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnWorkCenterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BaseQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn StdManHour;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hours;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;

    }
}