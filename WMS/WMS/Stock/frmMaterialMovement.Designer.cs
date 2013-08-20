namespace WMS.Stock
{
    partial class frmMaterialMovement
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
            this.btnReport = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pDesc = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMatName = new System.Windows.Forms.Label();
            this.btnOverview = new System.Windows.Forms.PictureBox();
            this.txtMatCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnDocNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnMaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnMatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnRef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pGradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.panel1.SuspendLayout();
            this.pDesc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOverview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pGradientPanel1
            // 
            this.pGradientPanel1.Caption = "Material Movement";
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
            this.pGradientPanel1.TabIndex = 14;
            // 
            // pGradientPanel2
            // 
            this.pGradientPanel2.Caption = "";
            this.pGradientPanel2.ColorFrom = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pGradientPanel2.ColorTo = System.Drawing.Color.White;
            this.pGradientPanel2.Controls.Add(this.btnReport);
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
            this.pGradientPanel2.TabIndex = 15;
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReport.BackColor = System.Drawing.Color.Transparent;
            this.btnReport.BackgroundImage = global::WMS.Properties.Resources.StockReport;
            this.btnReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReport.Location = new System.Drawing.Point(3, 2);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(104, 30);
            this.btnReport.TabIndex = 2;
            this.btnReport.TabStop = false;
            this.btnReport.Visible = false;
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
            this.panel1.Controls.Add(this.pDesc);
            this.panel1.Controls.Add(this.btnOverview);
            this.panel1.Controls.Add(this.txtMatCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(898, 74);
            this.panel1.TabIndex = 16;
            // 
            // pDesc
            // 
            this.pDesc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pDesc.Controls.Add(this.label2);
            this.pDesc.Controls.Add(this.lblMatName);
            this.pDesc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pDesc.Location = new System.Drawing.Point(0, 44);
            this.pDesc.Name = "pDesc";
            this.pDesc.Size = new System.Drawing.Size(898, 30);
            this.pDesc.TabIndex = 45;
            this.pDesc.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(22, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 51;
            this.label2.Text = "Material Name :";
            // 
            // lblMatName
            // 
            this.lblMatName.AutoSize = true;
            this.lblMatName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblMatName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblMatName.Location = new System.Drawing.Point(123, 6);
            this.lblMatName.Name = "lblMatName";
            this.lblMatName.Size = new System.Drawing.Size(89, 15);
            this.lblMatName.TabIndex = 50;
            this.lblMatName.Text = "Material Name";
            // 
            // btnOverview
            // 
            this.btnOverview.BackColor = System.Drawing.Color.White;
            this.btnOverview.BackgroundImage = global::WMS.Properties.Resources.Overview;
            this.btnOverview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnOverview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOverview.Location = new System.Drawing.Point(286, 4);
            this.btnOverview.Name = "btnOverview";
            this.btnOverview.Size = new System.Drawing.Size(98, 30);
            this.btnOverview.TabIndex = 44;
            this.btnOverview.TabStop = false;
            this.btnOverview.Click += new System.EventHandler(this.btnOverview_Click);
            // 
            // txtMatCode
            // 
            this.txtMatCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMatCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtMatCode.Location = new System.Drawing.Point(120, 8);
            this.txtMatCode.Name = "txtMatCode";
            this.txtMatCode.Size = new System.Drawing.Size(160, 24);
            this.txtMatCode.TabIndex = 1;
            this.txtMatCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMatCode_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(11, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Material Code : ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnDocNumber,
            this.clnDate,
            this.clnMT,
            this.clnQuantity,
            this.clnUnit,
            this.clnMaterialCode,
            this.clnMatName,
            this.clnCL,
            this.clnRef});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 124);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(898, 339);
            this.dataGridView1.TabIndex = 17;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "DocNumber";
            this.dataGridViewTextBoxColumn1.HeaderText = "DocNumber";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TranDate";
            this.dataGridViewTextBoxColumn2.HeaderText = "Date";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "MovementType";
            this.dataGridViewTextBoxColumn3.HeaderText = "MovementType";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Quantity";
            this.dataGridViewTextBoxColumn4.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "UnitCode";
            this.dataGridViewTextBoxColumn5.HeaderText = "Unit";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "MaterialCode";
            this.dataGridViewTextBoxColumn6.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "MaterialName";
            this.dataGridViewTextBoxColumn7.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "CL";
            this.dataGridViewTextBoxColumn8.HeaderText = "clnCL";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "RefNumber";
            this.dataGridViewTextBoxColumn9.HeaderText = "Ref";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // clnDocNumber
            // 
            this.clnDocNumber.DataPropertyName = "DocNumber";
            this.clnDocNumber.HeaderText = "DocNumber";
            this.clnDocNumber.Name = "clnDocNumber";
            this.clnDocNumber.ReadOnly = true;
            this.clnDocNumber.Width = 150;
            // 
            // clnDate
            // 
            this.clnDate.DataPropertyName = "TranDate";
            this.clnDate.HeaderText = "Date";
            this.clnDate.Name = "clnDate";
            this.clnDate.ReadOnly = true;
            // 
            // clnMT
            // 
            this.clnMT.DataPropertyName = "MovementType";
            this.clnMT.HeaderText = "MovementType";
            this.clnMT.Name = "clnMT";
            this.clnMT.ReadOnly = true;
            this.clnMT.Width = 150;
            // 
            // clnQuantity
            // 
            this.clnQuantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle2.Format = "N3";
            this.clnQuantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.clnQuantity.HeaderText = "Quantity";
            this.clnQuantity.Name = "clnQuantity";
            this.clnQuantity.ReadOnly = true;
            this.clnQuantity.Width = 150;
            // 
            // clnUnit
            // 
            this.clnUnit.DataPropertyName = "UnitCode";
            this.clnUnit.HeaderText = "Unit";
            this.clnUnit.Name = "clnUnit";
            this.clnUnit.ReadOnly = true;
            // 
            // clnMaterialCode
            // 
            this.clnMaterialCode.DataPropertyName = "MaterialCode";
            this.clnMaterialCode.HeaderText = "MatCode";
            this.clnMaterialCode.Name = "clnMaterialCode";
            this.clnMaterialCode.ReadOnly = true;
            this.clnMaterialCode.Visible = false;
            // 
            // clnMatName
            // 
            this.clnMatName.DataPropertyName = "MaterialName";
            this.clnMatName.HeaderText = "MatName";
            this.clnMatName.Name = "clnMatName";
            this.clnMatName.ReadOnly = true;
            this.clnMatName.Visible = false;
            // 
            // clnCL
            // 
            this.clnCL.DataPropertyName = "CL";
            this.clnCL.HeaderText = "CL";
            this.clnCL.Name = "clnCL";
            this.clnCL.ReadOnly = true;
            // 
            // clnRef
            // 
            this.clnRef.DataPropertyName = "RefNumber";
            this.clnRef.HeaderText = "Ref";
            this.clnRef.Name = "clnRef";
            this.clnRef.ReadOnly = true;
            this.clnRef.Visible = false;
            // 
            // frmMaterialMovement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(898, 498);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pGradientPanel2);
            this.Controls.Add(this.pGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMaterialMovement";
            this.Load += new System.EventHandler(this.frmMaterialMovement_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMaterialMovement_FormClosing);
            this.pGradientPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pDesc.ResumeLayout(false);
            this.pDesc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOverview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel1;
        private Pick.Windows.UI.Controls.PGradientPanel pGradientPanel2;
        private System.Windows.Forms.PictureBox btnReport;
        private System.Windows.Forms.PictureBox btnExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMatName;
        private System.Windows.Forms.PictureBox btnOverview;
        private System.Windows.Forms.TextBox txtMatCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnDocNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnMaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnMatName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCL;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnRef;
    }
}