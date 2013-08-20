namespace WMS.VendorTrans
{
    partial class frmVendorSourceList
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
            this.pGradientPanel1 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.pGradientPanel2 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.btnSaveChange = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.txtMaterialCode = new System.Windows.Forms.TextBox();
            this.lblWarn = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvView = new System.Windows.Forms.DataGridView();
            this.clnVendorCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnVendorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnFix = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clnBlockChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pGradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveChange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.SuspendLayout();
            // 
            // pGradientPanel1
            // 
            this.pGradientPanel1.Caption = "Source List ..";
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
            this.pGradientPanel1.Size = new System.Drawing.Size(798, 50);
            this.pGradientPanel1.TabIndex = 252;
            // 
            // pGradientPanel2
            // 
            this.pGradientPanel2.Caption = null;
            this.pGradientPanel2.ColorFrom = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pGradientPanel2.ColorTo = System.Drawing.Color.White;
            this.pGradientPanel2.Controls.Add(this.btnSaveChange);
            this.pGradientPanel2.Controls.Add(this.btnExit);
            this.pGradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pGradientPanel2.FontOffset = new System.Drawing.Size(0, 0);
            this.pGradientPanel2.ImageHeader = null;
            this.pGradientPanel2.ImageOffset = new System.Drawing.Size(0, 0);
            this.pGradientPanel2.ImageSize = new System.Drawing.Size(0, 0);
            this.pGradientPanel2.LinearGradientType = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.pGradientPanel2.Location = new System.Drawing.Point(0, 463);
            this.pGradientPanel2.Name = "pGradientPanel2";
            this.pGradientPanel2.Size = new System.Drawing.Size(798, 35);
            this.pGradientPanel2.TabIndex = 253;
            // 
            // btnSaveChange
            // 
            this.btnSaveChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnSaveChange.BackgroundImage = global::WMS.Properties.Resources.SaveChange;
            this.btnSaveChange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSaveChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveChange.Location = new System.Drawing.Point(3, 3);
            this.btnSaveChange.Name = "btnSaveChange";
            this.btnSaveChange.Size = new System.Drawing.Size(114, 30);
            this.btnSaveChange.TabIndex = 1;
            this.btnSaveChange.TabStop = false;
            this.btnSaveChange.Click += new System.EventHandler(this.btnSaveChange_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackgroundImage = global::WMS.Properties.Resources.Exit;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Location = new System.Drawing.Point(708, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(87, 30);
            this.btnExit.TabIndex = 0;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblMaterial);
            this.panel1.Controls.Add(this.txtMaterialCode);
            this.panel1.Controls.Add(this.lblWarn);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 45);
            this.panel1.TabIndex = 254;
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblMaterial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblMaterial.Location = new System.Drawing.Point(411, 14);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(0, 16);
            this.lblMaterial.TabIndex = 5;
            // 
            // txtMaterialCode
            // 
            this.txtMaterialCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtMaterialCode.Location = new System.Drawing.Point(176, 10);
            this.txtMaterialCode.Name = "txtMaterialCode";
            this.txtMaterialCode.Size = new System.Drawing.Size(174, 24);
            this.txtMaterialCode.TabIndex = 4;
            this.txtMaterialCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaterialCode_KeyDown);
            // 
            // lblWarn
            // 
            this.lblWarn.AutoSize = true;
            this.lblWarn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblWarn.ForeColor = System.Drawing.Color.Red;
            this.lblWarn.Location = new System.Drawing.Point(411, 15);
            this.lblWarn.Name = "lblWarn";
            this.lblWarn.Size = new System.Drawing.Size(121, 16);
            this.lblWarn.TabIndex = 3;
            this.lblWarn.Text = "Not found Vendor !!";
            this.lblWarn.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Image = global::WMS.Properties.Resources.OK;
            this.btnSearch.Location = new System.Drawing.Point(358, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(35, 35);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.TabStop = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Material Code / Name :";
            // 
            // dgvView
            // 
            this.dgvView.AllowUserToAddRows = false;
            this.dgvView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgvView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnVendorCode,
            this.clnVendorName,
            this.clnPG,
            this.clnFix,
            this.clnBlockChk,
            this.Column1});
            this.dgvView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvView.Location = new System.Drawing.Point(0, 95);
            this.dgvView.MultiSelect = false;
            this.dgvView.Name = "dgvView";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgvView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvView.Size = new System.Drawing.Size(798, 368);
            this.dgvView.TabIndex = 255;
            // 
            // clnVendorCode
            // 
            this.clnVendorCode.DataPropertyName = "VendorCode";
            this.clnVendorCode.HeaderText = "Vendor";
            this.clnVendorCode.Name = "clnVendorCode";
            this.clnVendorCode.ReadOnly = true;
            this.clnVendorCode.Width = 120;
            // 
            // clnVendorName
            // 
            this.clnVendorName.DataPropertyName = "VendorName";
            this.clnVendorName.HeaderText = "Name";
            this.clnVendorName.Name = "clnVendorName";
            this.clnVendorName.ReadOnly = true;
            this.clnVendorName.Width = 200;
            // 
            // clnPG
            // 
            this.clnPG.DataPropertyName = "PurchasingGroup";
            this.clnPG.HeaderText = "Purchasing group";
            this.clnPG.Name = "clnPG";
            this.clnPG.ReadOnly = true;
            this.clnPG.Width = 150;
            // 
            // clnFix
            // 
            this.clnFix.DataPropertyName = "Fix";
            this.clnFix.FalseValue = "False";
            this.clnFix.HeaderText = "Fix";
            this.clnFix.Name = "clnFix";
            this.clnFix.ReadOnly = true;
            this.clnFix.TrueValue = "True";
            this.clnFix.Width = 80;
            // 
            // clnBlockChk
            // 
            this.clnBlockChk.DataPropertyName = "Block";
            this.clnBlockChk.HeaderText = "Block";
            this.clnBlockChk.Name = "clnBlockChk";
            this.clnBlockChk.ReadOnly = true;
            this.clnBlockChk.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MaterialName";
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // frmVendorSourceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(798, 498);
            this.ControlBox = false;
            this.Controls.Add(this.dgvView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pGradientPanel2);
            this.Controls.Add(this.pGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmVendorSourceList";
            this.Load += new System.EventHandler(this.frmVendorSourceList_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVendorSourceList_FormClosing);
            this.pGradientPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveChange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel1;
        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel2;
        private System.Windows.Forms.PictureBox btnExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btnSearch;
        private System.Windows.Forms.Label lblWarn;
        private System.Windows.Forms.TextBox txtMaterialCode;
        private System.Windows.Forms.PictureBox btnSaveChange;
        private System.Windows.Forms.DataGridView dgvView;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnVendorCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnVendorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPG;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clnFix;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clnBlockChk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;

    }
}