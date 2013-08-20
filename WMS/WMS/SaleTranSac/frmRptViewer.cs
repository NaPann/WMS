using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMS.SaleTranSac
{
    public partial class frmRptViewer : Form
    {
        public DataSet dsReportA;
        public DataSet dsReportB;
        public frmRptViewer()
        {
            InitializeComponent();
        }

        private void frmRptViewer_Load(object sender, EventArgs e)
        {
            rptJobSheet rptJ = new rptJobSheet();
            rptJ.DataSource = dsReportA.Tables[0];
            this.reportViewer1.Report = rptJ;
            this.reportViewer1.RefreshReport();

            rptJobSheetB rptJB = new rptJobSheetB();
            rptJB.DataSource = dsReportB.Tables[0];
            this.reportViewer2.Report = rptJB;
            this.reportViewer2.RefreshReport();
        }

    }
}
