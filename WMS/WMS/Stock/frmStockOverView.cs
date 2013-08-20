using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WMS.Stock
{
    public partial class frmStockOverView : Form
    {
        public DataSet MyGridSet { get; set; }
        public DataSet MyTmpView { get; set; }
        public byte MyAtFirstRow { get; set; }
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection();
        public frmStockOverView()
        {
            InitializeComponent();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (NP.MSGB("Do you want to exit this screen ?") == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }
        private void frmStockOverView_Load(object sender, EventArgs e)
        {
            LoginSystem.frmMainMenu frm = ((LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"]);
            frm.menuStrip1.Enabled = true; this.txtMatCode.Select();
        }
        private void frmStockOverView_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoginSystem.frmMainMenu frm = ((LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"]);
            frm.menuStrip1.Enabled = true;
        }
        private void txtMatCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnOverview_Click(sender, e);
            }
        }
        private void btnOverview_Click(object sender, EventArgs e)
        {
            if (!NP.ReqField(this.txtMatCode, "Please enter Material Code !!")) { return; }
            NP_Cls.SqlSelect = "SELECT     m_Material.MaterialCode, m_Material.MaterialName, m_Material.MaterialTypeName, m_Unit.UnitName FROM         m_Material INNER JOIN                       m_Unit ON m_Material.UnitCode = m_Unit.UnitCode WHERE     (m_Material.MaterialCode = N'"+ this.txtMatCode.Text.Trim() +"') AND (m_Material.FileStatus = N'1')"; DataSet ds = new DataSet(); ds = NP.GetClientDataSet(NP_Cls.SqlSelect);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.pDesc.Visible = true; this.lblMatName.Text = ds.Tables[0].Rows[0]["MaterialName"].ToString();
                this.lblMatType.Text = ds.Tables[0].Rows[0]["MaterialTypeName"].ToString(); this.lblUnit.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();
                NP_Cls.SqlSelect = "SELECT BatchNumber, UR , QI, Block FROM  t_StockOverview WHERE (MaterialCode = N'" + this.txtMatCode.Text.Trim() + "')";
                this.dataGridView1.DataSource = NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0];
            }
            else
            {
                this.pDesc.Visible = false; NP_Cls.SqlSelect = "SELECT BatchNumber, UR, QI, Block FROM  t_StockOverview WHERE (MaterialCode = N'" + this.txtMatCode.Text.Trim() + "')";
                this.dataGridView1.DataSource = NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0];
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found !!"); this.txtMatCode.Select(); this.txtMatCode.SelectAll(); return;
            }
        }
        private void btnAddManual_Click(object sender, EventArgs e)
        {
            WMS.MasterData.frmLoadStock frm = new WMS.MasterData.frmLoadStock();
            frm.ShowDialog(); frm.Dispose(); this.Refresh();
        }
        private void btnReport_Click(object sender, EventArgs e)
        {

        }
     
    }
}
