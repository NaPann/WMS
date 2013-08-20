namespace WMS.BOM
{
    partial class frmBOMViewer
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
            this.reportViewer3 = new Telerik.ReportViewer.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewer3
            // 
            this.reportViewer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer3.Location = new System.Drawing.Point(0, 0);
            this.reportViewer3.Name = "reportViewer3";
            this.reportViewer3.Size = new System.Drawing.Size(734, 458);
            this.reportViewer3.TabIndex = 3;
            // 
            // frmBOMViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 458);
            this.Controls.Add(this.reportViewer3);
            this.Name = "frmBOMViewer";
            this.Text = "BOM report Viewer";
            this.Load += new System.EventHandler(this.frmBOMViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.ReportViewer.WinForms.ReportViewer reportViewer3;
    }
}