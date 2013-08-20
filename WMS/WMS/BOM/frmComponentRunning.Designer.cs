namespace WMS.BOM
{
    partial class frmComponentRunning
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pGradientPanel1 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.pGradientPanel2 = new Pick.Windows.UI.Controls.PGradientPanel(this.components);
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCompCodeName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clnReqDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnMRPType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnMRPElement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnReqQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnAvaQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnAutoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pGradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pGradientPanel1
            // 
            this.pGradientPanel1.Caption = "Component Running";
            this.pGradientPanel1.ColorFrom = System.Drawing.Color.White;
            this.pGradientPanel1.ColorTo = System.Drawing.Color.PaleGreen;
            this.pGradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pGradientPanel1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.pGradientPanel1.FontOffset = new System.Drawing.Size(5, 10);
            this.pGradientPanel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.pGradientPanel1.ImageHeader = null;
            this.pGradientPanel1.ImageOffset = new System.Drawing.Size(0, 0);
            this.pGradientPanel1.ImageSize = new System.Drawing.Size(0, 0);
            this.pGradientPanel1.LinearGradientType = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.pGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.pGradientPanel1.Name = "pGradientPanel1";
            this.pGradientPanel1.Size = new System.Drawing.Size(930, 50);
            this.pGradientPanel1.TabIndex = 17;
            // 
            // pGradientPanel2
            // 
            this.pGradientPanel2.Caption = "";
            this.pGradientPanel2.ColorFrom = System.Drawing.Color.PaleGreen;
            this.pGradientPanel2.ColorTo = System.Drawing.Color.White;
            this.pGradientPanel2.Controls.Add(this.btnExit);
            this.pGradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pGradientPanel2.FontOffset = new System.Drawing.Size(0, 0);
            this.pGradientPanel2.ImageHeader = null;
            this.pGradientPanel2.ImageOffset = new System.Drawing.Size(0, 0);
            this.pGradientPanel2.ImageSize = new System.Drawing.Size(0, 0);
            this.pGradientPanel2.LinearGradientType = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.pGradientPanel2.Location = new System.Drawing.Point(0, 427);
            this.pGradientPanel2.Name = "pGradientPanel2";
            this.pGradientPanel2.Size = new System.Drawing.Size(930, 35);
            this.pGradientPanel2.TabIndex = 18;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackgroundImage = global::WMS.Properties.Resources.Exit;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Location = new System.Drawing.Point(840, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(87, 30);
            this.btnExit.TabIndex = 0;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCompCodeName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(930, 37);
            this.panel1.TabIndex = 19;
            // 
            // lblCompCodeName
            // 
            this.lblCompCodeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblCompCodeName.ForeColor = System.Drawing.Color.Green;
            this.lblCompCodeName.Location = new System.Drawing.Point(149, 10);
            this.lblCompCodeName.Name = "lblCompCodeName";
            this.lblCompCodeName.Size = new System.Drawing.Size(297, 20);
            this.lblCompCodeName.TabIndex = 3;
            this.lblCompCodeName.Text = ".. Component Code Name .. ";
            this.lblCompCodeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(11, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Component Code : ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 87);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(930, 340);
            this.panel2.TabIndex = 20;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnReqDate,
            this.clnMRPType,
            this.clnMRPElement,
            this.clnReqQty,
            this.clnAvaQty,
            this.clnAutoID,
            this.clnPType,
            this.clnSo,
            this.clnUnit});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(930, 340);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // clnReqDate
            // 
            this.clnReqDate.DataPropertyName = "ReqDate";
            this.clnReqDate.HeaderText = "Date";
            this.clnReqDate.Name = "clnReqDate";
            this.clnReqDate.ReadOnly = true;
            this.clnReqDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clnMRPType
            // 
            this.clnMRPType.DataPropertyName = "MRPType";
            this.clnMRPType.HeaderText = "MRPType";
            this.clnMRPType.Name = "clnMRPType";
            this.clnMRPType.ReadOnly = true;
            this.clnMRPType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clnMRPType.Width = 220;
            // 
            // clnMRPElement
            // 
            this.clnMRPElement.DataPropertyName = "MRPElement";
            this.clnMRPElement.HeaderText = "MRP Element";
            this.clnMRPElement.Name = "clnMRPElement";
            this.clnMRPElement.ReadOnly = true;
            this.clnMRPElement.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clnMRPElement.Width = 250;
            // 
            // clnReqQty
            // 
            this.clnReqQty.DataPropertyName = "RequireQty";
            dataGridViewCellStyle3.Format = "N3";
            this.clnReqQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.clnReqQty.HeaderText = "Require Qty";
            this.clnReqQty.Name = "clnReqQty";
            this.clnReqQty.ReadOnly = true;
            this.clnReqQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clnReqQty.Width = 120;
            // 
            // clnAvaQty
            // 
            this.clnAvaQty.DataPropertyName = "AvailableQty";
            dataGridViewCellStyle4.Format = "N3";
            this.clnAvaQty.DefaultCellStyle = dataGridViewCellStyle4;
            this.clnAvaQty.HeaderText = "Available Qty";
            this.clnAvaQty.Name = "clnAvaQty";
            this.clnAvaQty.ReadOnly = true;
            this.clnAvaQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clnAvaQty.Width = 120;
            // 
            // clnAutoID
            // 
            this.clnAutoID.DataPropertyName = "AutoID";
            this.clnAutoID.HeaderText = "AutoID";
            this.clnAutoID.Name = "clnAutoID";
            this.clnAutoID.ReadOnly = true;
            this.clnAutoID.Visible = false;
            // 
            // clnPType
            // 
            this.clnPType.DataPropertyName = "PType";
            this.clnPType.HeaderText = "PType";
            this.clnPType.Name = "clnPType";
            this.clnPType.ReadOnly = true;
            this.clnPType.Visible = false;
            // 
            // clnSo
            // 
            this.clnSo.DataPropertyName = "SO";
            this.clnSo.HeaderText = "SO";
            this.clnSo.Name = "clnSo";
            this.clnSo.ReadOnly = true;
            this.clnSo.Visible = false;
            // 
            // clnUnit
            // 
            this.clnUnit.DataPropertyName = "Unit";
            this.clnUnit.HeaderText = "Unit";
            this.clnUnit.Name = "clnUnit";
            this.clnUnit.ReadOnly = true;
            this.clnUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clnUnit.Width = 80;
            // 
            // frmComponentRunning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(930, 462);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pGradientPanel2);
            this.Controls.Add(this.pGradientPanel1);
            this.Name = "frmComponentRunning";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Component";
            this.Load += new System.EventHandler(this.frmComponentRunning_Load);
            this.pGradientPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox btnExit;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblCompCodeName;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        public Pick.Windows.UI.Controls.PGradientPanel pGradientPanel1;
        public Pick.Windows.UI.Controls.PGradientPanel pGradientPanel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnReqDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnMRPType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnMRPElement;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnReqQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnAvaQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnAutoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnUnit;
    }
}