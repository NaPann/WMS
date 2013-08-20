namespace WMS.BOM
{
    partial class frmBOMNewDetail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pGradientPanel1 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.pGradientPanel2 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.btnSuccess = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCompUnit = new System.Windows.Forms.Label();
            this.txtLoss = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbComponent = new System.Windows.Forms.ComboBox();
            this.txtQtyComp = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblRemain = new System.Windows.Forms.Label();
            this.dgvView = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.PictureBox();
            this.btnEdit = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSum = new System.Windows.Forms.Label();
            this.lblSumUnit = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblCompUnitCode = new System.Windows.Forms.Label();
            this.lblSCode = new System.Windows.Forms.Label();
            this.lblSName = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.clnCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnUnitCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnBOMDetailCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnBOMCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnComponent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnComponentDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnLoss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pGradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSuccess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // pGradientPanel1
            // 
            this.pGradientPanel1.Caption = "B.O.M Component";
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
            this.pGradientPanel1.Size = new System.Drawing.Size(709, 50);
            this.pGradientPanel1.TabIndex = 12;
            // 
            // pGradientPanel2
            // 
            this.pGradientPanel2.Caption = null;
            this.pGradientPanel2.ColorFrom = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pGradientPanel2.ColorTo = System.Drawing.Color.White;
            this.pGradientPanel2.Controls.Add(this.btnSuccess);
            this.pGradientPanel2.Controls.Add(this.btnExit);
            this.pGradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pGradientPanel2.FontOffset = new System.Drawing.Size(0, 0);
            this.pGradientPanel2.ImageHeader = null;
            this.pGradientPanel2.ImageOffset = new System.Drawing.Size(0, 0);
            this.pGradientPanel2.ImageSize = new System.Drawing.Size(0, 0);
            this.pGradientPanel2.LinearGradientType = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.pGradientPanel2.Location = new System.Drawing.Point(0, 469);
            this.pGradientPanel2.Name = "pGradientPanel2";
            this.pGradientPanel2.Size = new System.Drawing.Size(709, 35);
            this.pGradientPanel2.TabIndex = 13;
            // 
            // btnSuccess
            // 
            this.btnSuccess.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSuccess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnSuccess.BackgroundImage = global::WMS.Properties.Resources.Complete;
            this.btnSuccess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSuccess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuccess.Location = new System.Drawing.Point(2, 3);
            this.btnSuccess.Name = "btnSuccess";
            this.btnSuccess.Size = new System.Drawing.Size(99, 30);
            this.btnSuccess.TabIndex = 1;
            this.btnSuccess.TabStop = false;
            this.btnSuccess.Visible = false;
            this.btnSuccess.Click += new System.EventHandler(this.btnSuccess_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackgroundImage = global::WMS.Properties.Resources.Exit;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Location = new System.Drawing.Point(619, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(87, 30);
            this.btnExit.TabIndex = 0;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtIndex);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtRemark);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblCompUnit);
            this.groupBox2.Controls.Add(this.txtLoss);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbComponent);
            this.groupBox2.Controls.Add(this.txtQtyComp);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lblRemain);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox2.Location = new System.Drawing.Point(11, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(365, 188);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detail";
            // 
            // txtRemark
            // 
            this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark.Location = new System.Drawing.Point(160, 131);
            this.txtRemark.MaxLength = 255;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(183, 43);
            this.txtRemark.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(92, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Remark :";
            // 
            // lblCompUnit
            // 
            this.lblCompUnit.AutoSize = true;
            this.lblCompUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblCompUnit.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCompUnit.Location = new System.Drawing.Point(251, 77);
            this.lblCompUnit.Name = "lblCompUnit";
            this.lblCompUnit.Size = new System.Drawing.Size(27, 15);
            this.lblCompUnit.TabIndex = 2;
            this.lblCompUnit.Text = ". . .";
            // 
            // txtLoss
            // 
            this.txtLoss.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtLoss.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLoss.Location = new System.Drawing.Point(160, 103);
            this.txtLoss.MaxLength = 5;
            this.txtLoss.Name = "txtLoss";
            this.txtLoss.Size = new System.Drawing.Size(44, 22);
            this.txtLoss.TabIndex = 3;
            this.txtLoss.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLoss.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLoss_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(96, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "% Loss :";
            // 
            // cbComponent
            // 
            this.cbComponent.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbComponent.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbComponent.FormattingEnabled = true;
            this.cbComponent.Location = new System.Drawing.Point(160, 43);
            this.cbComponent.Name = "cbComponent";
            this.cbComponent.Size = new System.Drawing.Size(183, 24);
            this.cbComponent.TabIndex = 0;
            this.cbComponent.SelectedIndexChanged += new System.EventHandler(this.cbComponent_SelectedIndexChanged);
            // 
            // txtQtyComp
            // 
            this.txtQtyComp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtQtyComp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQtyComp.Location = new System.Drawing.Point(160, 73);
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
            this.label8.Location = new System.Drawing.Point(34, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Qty of Component :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(71, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "Component :";
            // 
            // lblRemain
            // 
            this.lblRemain.AutoSize = true;
            this.lblRemain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblRemain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblRemain.Location = new System.Drawing.Point(89, 18);
            this.lblRemain.Name = "lblRemain";
            this.lblRemain.Size = new System.Drawing.Size(65, 16);
            this.lblRemain.TabIndex = 11;
            this.lblRemain.Text = "Remain:";
            // 
            // dgvView
            // 
            this.dgvView.AllowUserToAddRows = false;
            this.dgvView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnCode,
            this.clnUnitCode,
            this.clnBOMDetailCode,
            this.clnBOMCode,
            this.clnCategory,
            this.clnComponent,
            this.clnComponentDesc,
            this.clnQty,
            this.clnUnit,
            this.clnLoss,
            this.clnIndex});
            this.dgvView.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvView.Location = new System.Drawing.Point(0, 255);
            this.dgvView.MultiSelect = false;
            this.dgvView.Name = "dgvView";
            this.dgvView.ReadOnly = true;
            this.dgvView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvView.Size = new System.Drawing.Size(699, 214);
            this.dgvView.TabIndex = 15;
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAdd);
            this.flowLayoutPanel1.Controls.Add(this.btnEdit);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(382, 205);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(488, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Sum Qty :";
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblSum.ForeColor = System.Drawing.Color.Red;
            this.lblSum.Location = new System.Drawing.Point(567, 219);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(43, 16);
            this.lblSum.TabIndex = 19;
            this.lblSum.Text = "99999";
            this.lblSum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSumUnit
            // 
            this.lblSumUnit.AutoSize = true;
            this.lblSumUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblSumUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblSumUnit.Location = new System.Drawing.Point(616, 219);
            this.lblSumUnit.Name = "lblSumUnit";
            this.lblSumUnit.Size = new System.Drawing.Size(32, 16);
            this.lblSumUnit.TabIndex = 20;
            this.lblSumUnit.Text = "unit";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(634, 53);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(35, 13);
            this.lblCode.TabIndex = 21;
            this.lblCode.Text = "label3";
            this.lblCode.Visible = false;
            // 
            // lblCompUnitCode
            // 
            this.lblCompUnitCode.AutoSize = true;
            this.lblCompUnitCode.Location = new System.Drawing.Point(675, 53);
            this.lblCompUnitCode.Name = "lblCompUnitCode";
            this.lblCompUnitCode.Size = new System.Drawing.Size(35, 13);
            this.lblCompUnitCode.TabIndex = 22;
            this.lblCompUnitCode.Text = "label3";
            this.lblCompUnitCode.Visible = false;
            // 
            // lblSCode
            // 
            this.lblSCode.AutoSize = true;
            this.lblSCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblSCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblSCode.Location = new System.Drawing.Point(395, 101);
            this.lblSCode.Name = "lblSCode";
            this.lblSCode.Size = new System.Drawing.Size(58, 18);
            this.lblSCode.TabIndex = 23;
            this.lblSCode.Text = "lblCode";
            // 
            // lblSName
            // 
            this.lblSName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblSName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblSName.Location = new System.Drawing.Point(395, 120);
            this.lblSName.Name = "lblSName";
            this.lblSName.Size = new System.Drawing.Size(306, 38);
            this.lblSName.TabIndex = 24;
            this.lblSName.Text = "lblName";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ItemNo";
            this.dataGridViewTextBoxColumn1.HeaderText = "Item.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "UnitCode";
            this.dataGridViewTextBoxColumn2.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "BOMDetailCode";
            this.dataGridViewTextBoxColumn3.HeaderText = "BOMDetailCode";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "BOMCode";
            this.dataGridViewTextBoxColumn4.HeaderText = "BOMCode";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Category";
            this.dataGridViewTextBoxColumn5.HeaderText = "Category";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "MaterialCode";
            this.dataGridViewTextBoxColumn6.HeaderText = "Component";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "MaterialName";
            this.dataGridViewTextBoxColumn7.HeaderText = "Component Description";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 150;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Quantity";
            dataGridViewCellStyle4.Format = "N3";
            dataGridViewCellStyle4.NullValue = null;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn8.HeaderText = "Qty.";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 80;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "UnitName";
            this.dataGridViewTextBoxColumn9.HeaderText = "Unit";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 80;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "LossPercentage";
            this.dataGridViewTextBoxColumn10.HeaderText = "%Loss";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 80;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(395, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 18);
            this.label3.TabIndex = 25;
            this.label3.Text = "B.O.M for ..";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(255, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Sort :";
            // 
            // txtIndex
            // 
            this.txtIndex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIndex.Location = new System.Drawing.Point(299, 103);
            this.txtIndex.MaxLength = 5;
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(44, 22);
            this.txtIndex.TabIndex = 17;
            this.txtIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIndex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLoss_KeyPress);
            // 
            // clnCode
            // 
            this.clnCode.DataPropertyName = "ItemNo";
            this.clnCode.HeaderText = "Item.";
            this.clnCode.Name = "clnCode";
            this.clnCode.ReadOnly = true;
            this.clnCode.Width = 60;
            // 
            // clnUnitCode
            // 
            this.clnUnitCode.DataPropertyName = "UnitCode";
            this.clnUnitCode.HeaderText = "Column1";
            this.clnUnitCode.Name = "clnUnitCode";
            this.clnUnitCode.ReadOnly = true;
            this.clnUnitCode.Visible = false;
            // 
            // clnBOMDetailCode
            // 
            this.clnBOMDetailCode.DataPropertyName = "BOMDetailCode";
            this.clnBOMDetailCode.HeaderText = "BOMDetailCode";
            this.clnBOMDetailCode.Name = "clnBOMDetailCode";
            this.clnBOMDetailCode.ReadOnly = true;
            this.clnBOMDetailCode.Visible = false;
            // 
            // clnBOMCode
            // 
            this.clnBOMCode.DataPropertyName = "BOMCode";
            this.clnBOMCode.HeaderText = "BOMCode";
            this.clnBOMCode.Name = "clnBOMCode";
            this.clnBOMCode.ReadOnly = true;
            this.clnBOMCode.Visible = false;
            // 
            // clnCategory
            // 
            this.clnCategory.DataPropertyName = "Category";
            this.clnCategory.HeaderText = "Category";
            this.clnCategory.Name = "clnCategory";
            this.clnCategory.ReadOnly = true;
            this.clnCategory.Width = 80;
            // 
            // clnComponent
            // 
            this.clnComponent.DataPropertyName = "MaterialCode";
            this.clnComponent.HeaderText = "Component";
            this.clnComponent.Name = "clnComponent";
            this.clnComponent.ReadOnly = true;
            // 
            // clnComponentDesc
            // 
            this.clnComponentDesc.DataPropertyName = "MaterialName";
            this.clnComponentDesc.HeaderText = "Component Description";
            this.clnComponentDesc.Name = "clnComponentDesc";
            this.clnComponentDesc.ReadOnly = true;
            this.clnComponentDesc.Width = 150;
            // 
            // clnQty
            // 
            this.clnQty.DataPropertyName = "Quantity";
            dataGridViewCellStyle2.Format = "N3";
            dataGridViewCellStyle2.NullValue = null;
            this.clnQty.DefaultCellStyle = dataGridViewCellStyle2;
            this.clnQty.HeaderText = "Qty.";
            this.clnQty.Name = "clnQty";
            this.clnQty.ReadOnly = true;
            this.clnQty.Width = 80;
            // 
            // clnUnit
            // 
            this.clnUnit.DataPropertyName = "UnitName";
            this.clnUnit.HeaderText = "Unit";
            this.clnUnit.Name = "clnUnit";
            this.clnUnit.ReadOnly = true;
            this.clnUnit.Width = 80;
            // 
            // clnLoss
            // 
            this.clnLoss.DataPropertyName = "LossPercentage";
            this.clnLoss.HeaderText = "%Loss";
            this.clnLoss.Name = "clnLoss";
            this.clnLoss.ReadOnly = true;
            this.clnLoss.Width = 80;
            // 
            // clnIndex
            // 
            this.clnIndex.DataPropertyName = "SortIndex";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clnIndex.DefaultCellStyle = dataGridViewCellStyle3;
            this.clnIndex.HeaderText = "Sort";
            this.clnIndex.Name = "clnIndex";
            this.clnIndex.ReadOnly = true;
            this.clnIndex.Width = 50;
            // 
            // frmBOMNewDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(709, 504);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCompUnitCode);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.lblSName);
            this.Controls.Add(this.dgvView);
            this.Controls.Add(this.lblSCode);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pGradientPanel2);
            this.Controls.Add(this.lblSumUnit);
            this.Controls.Add(this.lblSum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pGradientPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(715, 520);
            this.Name = "frmBOMNewDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmBOMNewDetail_Load);
            this.pGradientPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSuccess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel1;
        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel2;
        private System.Windows.Forms.PictureBox btnExit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbComponent;
        private System.Windows.Forms.TextBox txtQtyComp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblRemain;
        private System.Windows.Forms.DataGridView dgvView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox btnAdd;
        private System.Windows.Forms.PictureBox btnEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.Label lblSumUnit;
        private System.Windows.Forms.PictureBox btnSuccess;
        private System.Windows.Forms.TextBox txtLoss;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCompUnit;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblCompUnitCode;
        public System.Windows.Forms.Label lblSCode;
        public System.Windows.Forms.Label lblSName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIndex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnUnitCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnBOMDetailCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnBOMCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnComponent;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnComponentDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnLoss;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnIndex;
    }
}