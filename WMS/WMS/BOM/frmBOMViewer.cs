using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMS.BOM
{
    public partial class frmBOMViewer : Form
    {
        public DataSet dsReportA; public byte bType;
        public string strFor;
        public frmBOMViewer()
        {
            InitializeComponent();
        }

        private void frmBOMViewer_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < dsReportA.Tables[0].Rows.Count; i++)
            {
                dsReportA.Tables[0].Rows[i][0] = i + 1;
            }

            switch (this.bType)
            {
                case 0:
                    rptBOM rptJ = new rptBOM();
                    rptJ.txtFor.Value = strFor;
                    rptJ.DataSource = dsReportA.Tables[0];
                    this.reportViewer3.Report = rptJ;
                    this.reportViewer3.RefreshReport();
                    break;
                case 1:
                    rptBOMFG rptJFG = new rptBOMFG();
                    rptJFG.DataSource = dsReportA.Tables[0];
                    this.reportViewer3.Report = rptJFG;
                    this.reportViewer3.RefreshReport();
                    break;
            }

        }
    }
}
