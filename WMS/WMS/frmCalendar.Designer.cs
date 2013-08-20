namespace WMS
{
    partial class frmCalendar
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnTime = new WMS.SaleTranSac.frmSaleOrder.CalendarColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnID,
            this.clnTime});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(577, 418);
            this.dataGridView1.TabIndex = 0;
            // 
            // clnID
            // 
            this.clnID.DataPropertyName = "id";
            this.clnID.HeaderText = "ID";
            this.clnID.Name = "clnID";
            // 
            // clnTime
            // 
            this.clnTime.DataPropertyName = "time";
            this.clnTime.HeaderText = "Time";
            this.clnTime.Name = "clnTime";
            // 
            // frmCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 472);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmCalendar";
            this.Text = "frmCalendar";
            this.Load += new System.EventHandler(this.frmCalendar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnID;
        private WMS.SaleTranSac.frmSaleOrder.CalendarColumn clnTime;



    }
}