using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WMS.SaleTranSac
{
    public partial class AddBatchDO : Form
    {
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection();
        Decimal LimitQty = 0M;

        public DataSet dsOverview;
        public AddBatchDO()
        {
            InitializeComponent();
        }

        private void AddBatchDO_Load(object sender, EventArgs e)
        {
            DGV();
            txtBatchNumber.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            this.txtBatchNumber.Select();
        }

        private void DGV()
        {
            DataTable dt = new DataTable();
            dt = dsOverview.Tables[0].Clone();
            foreach (DataRow item in this.dsOverview.Tables[0].Rows)
            {
                if (item["SOAutoID"].ToString().Trim() == NP_Cls.autoIDDO.Trim())
                {
                    dt.ImportRow(item);
                }
            }
            dt.AcceptChanges();
            this.dataGridView1.DataSource = dt;
            this.dataGridView1.ClearSelection();
        }
        private void getOldData()
        {
            NP_Cls.SqlSelect = "SELECT SOAutoID , BatchNumber, Qty , SONumber FROM tmp_DOforApprove WHERE (SOAutoID = '"+ NP_Cls.autoIDDO +"')";
            this.dataGridView1.DataSource = NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0];
        }

        private void btnOverview_Click(object sender, EventArgs e)
        {
            if (!NP.ReqField(this.txtBatchNumber, "Please enter Batch Number !!")) { return; }

            NP_Cls.SqlSelect = "SELECT     m_Material.MaterialCode, m_Material.MaterialName, m_Material.MaterialTypeName, m_Unit.UnitName FROM         m_Material INNER JOIN                       m_Unit ON m_Material.UnitCode = m_Unit.UnitCode WHERE     (m_Material.MaterialCode = (select MaterialCode from t_StockOverview where t_StockOverview.BatchNumber = N'" + this.txtBatchNumber.Text.Trim() + "')) AND (m_Material.FileStatus = N'1')"; 
            DataSet ds = new DataSet(); 
            ds = NP.GetClientDataSet(NP_Cls.SqlSelect);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (!ds.Tables[0].Rows[0]["MaterialCode"].ToString().Contains(NP_Cls.MatCodeForDO))
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "BacthNumber Not Match With MaterialCode !!");
                    this.lblMatCode.Text = string.Empty;
                    this.lblMatName.Text = string.Empty;
                    this.lblMatType.Text = string.Empty;
                    this.lblUnit.Text = string.Empty; 
                    this.txtQuantity.Text = string.Empty;
                    this.txtBatchNumber.Select(); this.txtBatchNumber.SelectAll(); 
                    return;
                }

                this.lblMatCode.Text = ds.Tables[0].Rows[0]["MaterialCode"].ToString();
                this.lblMatName.Text = ds.Tables[0].Rows[0]["MaterialName"].ToString();
                this.lblMatType.Text = ds.Tables[0].Rows[0]["MaterialTypeName"].ToString();
                this.lblUnit.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();
                
                NP_Cls.SqlSelect = "SELECT MaterialCode,BatchNumber, UR FROM  t_StockOverview WHERE (BatchNumber = N'" + this.txtBatchNumber.Text.Trim() + "')";
                DataSet ds1 = new DataSet();
                ds1 = NP.GetClientDataSet(NP_Cls.SqlSelect);
                
                //LimitQty = Convert.ToDecimal(ds1.Tables[0].Rows[0]["UR"].ToString());
                
                this.txtQuantity.Text = Convert.ToDecimal(ds1.Tables[0].Rows[0]["UR"].ToString()).ToString("#,#0.000");
                this.txtQuantity.Select(); this.txtQuantity.SelectAll();
            }
            else
            {
                this.lblMatCode.Text = string.Empty;
                this.lblMatName.Text = string.Empty;
                this.lblMatType.Text = string.Empty;
                this.lblUnit.Text = string.Empty;
                this.txtQuantity.Text = string.Empty;
                this.dataGridView1.DataSource = null;
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found !!"); this.txtBatchNumber.Select(); this.txtBatchNumber.SelectAll(); return;
            }
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.RowCount == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found !!"); return; }
            if (NP.MSGB("Do you want to delete ?") == DialogResult.Yes)
            {
                //for (int lm = 0; lm < this.dataGridView1.RowCount; lm++)
                //{
                //    if (this.dataGridView1["clnBatchNumber", lm].Value.ToString().Contains(this.txtBatchNumber.Text.Trim()))
                //    {
                //        LimitQty += decimal.Parse(this.dataGridView1["clnQty", lm].Value.ToString());
                //    }
                //}
                //string qty = this.dataGridView1["clnValidPeriodCode", this.dataGridView1.CurrentRow.Index].Value.ToString();
                //string batch = this.dataGridView1["clnValidPeriodCode", this.dataGridView1.CurrentRow.Index].Value.ToString();
                dsOverview.Tables[0].Rows.RemoveAt(this.dataGridView1.CurrentRow.Index);
            }
        }
        private void txtBatchNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnOverview_Click(sender, e);
            }
        }
        private void MyGrid(DataGridView grid)
        {
            NP_Cls.SqlSelect = "SELECT BatchNumber, 0 AS Qty, '' as SOAutoID, '' as SONumber FROM t_StockOverview WHERE (BatchNumber = N' ')";
            this.dsOverview = NP.GetClientDataSet(NP_Cls.SqlSelect);
            grid.DataSource = this.dsOverview.Tables[0];
        }
        private void btnAddManual_Click(object sender, EventArgs e)
        {
            if (!NP.ReqField(this.txtBatchNumber, "Please enter Batch Number !!")) { return; }
            if (!NP.ReqField(this.txtQuantity, "Please enter Quantity !!")) { return; }

            //for (int lm = 0; lm < this.dataGridView1.RowCount; lm++)
            //{
            //    if (this.dataGridView1["clnBatchNumber", lm].Value.ToString().Contains(this.txtBatchNumber.Text.Trim()))
            //    {
            //        LimitQty -= decimal.Parse(this.dataGridView1["clnQty", lm].Value.ToString());
            //    }
            //}

            //if (LimitQty < Convert.ToDecimal(txtQuantity.Text.Trim()))
            //{
            //    txtQuantity.Select();
            //    txtQuantity.SelectAll();
            //    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Quantity Over Limit !!");
            //    return;
            //}

            if (this.dsOverview.Tables[0].Rows.Count == 0)
            {
                NP_Cls.SqlSelect = "SELECT BatchNumber, UR AS Qty, '" + NP_Cls.autoIDDO + "' as SOAutoID, '" + NP_Cls.SONumberForDO + "' AS SONumber FROM t_StockOverview WHERE (BatchNumber = N'" + this.txtBatchNumber.Text.Trim() + "')";
                dsOverview = NP.GetClientDataSet(NP_Cls.SqlSelect);
                dsOverview.Tables[0].Rows[0]["Qty"] = txtQuantity.Text.Trim();
                dsOverview.Tables[0].Rows[0]["SOAutoID"] = NP_Cls.autoIDDO;
                dsOverview.Tables[0].Rows[0]["SONumber"] = NP_Cls.SONumberForDO;
                dsOverview.Tables[0].Rows[0]["BatchNumber"] = this.txtBatchNumber.Text.Trim();

                dsOverview.AcceptChanges();
            }
            else
            {
                NP_Cls.SqlSelect = "SELECT BatchNumber, UR AS Qty, '" + NP_Cls.autoIDDO + "' as SOAutoID, '" + NP_Cls.SONumberForDO + "' AS SONumber FROM t_StockOverview WHERE (BatchNumber = N'" + this.txtBatchNumber.Text.Trim() + "')";
                DataSet ds2 = new DataSet(); ds2 = NP.GetClientDataSet(NP_Cls.SqlSelect);
                ds2.Tables[0].Rows[0]["Qty"] = txtQuantity.Text.Trim();
                ds2.Tables[0].Rows[0]["SOAutoID"] = NP_Cls.autoIDDO;
                ds2.Tables[0].Rows[0]["SONumber"] = NP_Cls.SONumberForDO;
                ds2.Tables[0].Rows[0]["BatchNumber"] = this.txtBatchNumber.Text.Trim();

                ds2.AcceptChanges();
                foreach (DataRow item in ds2.Tables[0].Rows)
                {
                    this.dsOverview.Tables[0].ImportRow(item);
                }
                dsOverview.AcceptChanges();
            }
            DGV();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AddBatchDO_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            NP_Cls.myDecimal(sender, e);
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.btnAddManual_Click(sender, e);
        }
    }
}
