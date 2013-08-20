using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WMS.Routing
{
    public partial class frmProductionCost : Form
    {
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection();
        public frmProductionCost()
        {
            InitializeComponent();
        }

        private void frmProductionCost_Load(object sender, EventArgs e)
        {
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;

            NP_Cls.SqlSelect = "SELECT     PrdONumber, PrdONumber + ':' + MaterialCode AS DC FROM         t_PrdOrder WHERE     (IsPicking = 1) AND (OrderStatus IS NULL) OR                       (OrderStatus <> N'Close')";
            NP.BindCB(this.cbProdOrder, NP_Cls.SqlSelect, "PrdONumber", "DC", "((( Select Production Order )))");

            NP_Cls.SqlSelect = "SELECT WorkCenterCode, WorkCenterCode AS WorkCenterName FROM m_WorkCenter WHERE (FileStatus = '1')";
            NP.BindCB(this.cbWorkCenter, NP_Cls.SqlSelect, "WorkCenterCode", "WorkCenterName", "((( Select WorkCenter )))");

            Clear(); DGV(); this.btnEdit.Visible = false; 
            this.cbProdOrder.Select();
        }
        private void DGV()
        {
            NP_Cls.SqlSelect = "SELECT  0 as ItemNo, AutoID, PrdONumber, MaterialCode, PlantCode, WorkCenterCode, UsedMachine, UsedSetup, UsedLabor, UsedOT FROM  t_ProductionCost WHERE (1=1)  ";
            if (!string.IsNullOrEmpty(this.txtSCode.Text.Trim()))
            {
                NP_Cls.SqlSelect += " AND (PrdONumber LIKE N'%" + this.txtSCode.Text.Trim() + "%') ";
            }
            if (!string.IsNullOrEmpty(this.txtSName.Text.Trim()))
            {
                NP_Cls.SqlSelect += " AND (MaterialCode LIKE N'%" + this.txtSName.Text.Trim() + "%') ";
            }
            NP_Cls.SqlSelect += " ORDER BY PrdONumber";
            DataSet dsSerach = new DataSet(); dsSerach = NP.GetClientDataSet(NP_Cls.SqlSelect);
            
            for (Int32 i = 0; i < dsSerach.Tables[0].Rows.Count; i++)
            {
                dsSerach.Tables[0].Rows[i][0] = i + 1;
            }
            this.dgvView.DataSource = dsSerach.Tables[0];
        }
        private void Clear()
        {
            this.txtMachine.Text = string.Empty; this.txtSetup.Text = string.Empty; this.txtLabor.Text = string.Empty;
            this.txtOT.Text = string.Empty;
        }

        private void cbProdOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbProdOrder.SelectedIndex > 0)
            {
                NP_Cls.SqlSelect = "SELECT     PrdONumber, PrdODate, MaterialCode, MaterialName, PrdQuantity, PlantCode, PlantName, BOMVersion, LocCode, LocName, Remark, UserCreate,       DateCreate, UserUpdate, DateUpdate, IsGI, MRPOrder, ISGRPrd, LogDate, IsPicking FROM         t_PrdOrder WHERE  (PrdONumber = N'"+ this.cbProdOrder.SelectedValue.ToString() +"')";
                DataSet dsTmp = new DataSet(); dsTmp = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (dsTmp.Tables[0].Rows.Count > 0)
                {
                    this.lblMaterialCode.Text = dsTmp.Tables[0].Rows[0]["MaterialCode"].ToString();
                    this.lblPlantCode.Text = dsTmp.Tables[0].Rows[0]["PlantCode"].ToString();

                    NP_Cls.SqlSelect = "SELECT WorkCenterCode, WorkCenterCode AS WorkCenterName FROM m_WorkCenter WHERE (FileStatus = '1') OR (PlantCode = N'"+ this.lblPlantCode.Text.Trim() +"')";
                    NP.BindCB(this.cbWorkCenter, NP_Cls.SqlSelect, "WorkCenterCode", "WorkCenterName", "((( Select WorkCenter )))");

                    this.cbWorkCenter.Select();
                }
                else
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found !!"); return;
                }
            }
            else
            {
                Clear(); this.cbProdOrder.SelectedIndex = 0;
                this.cbProdOrder.Select();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty((this.cbProdOrder.Text.Trim()))) || (this.cbProdOrder.Text.Trim() == "((( Select Production Order )))")) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please select Production Order: !!"); this.cbProdOrder.Select(); return; }
            if ((string.IsNullOrEmpty((this.cbWorkCenter.Text.Trim()))) || (this.cbWorkCenter.Text.Trim() == "((( Select WorkCenter )))")) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please select Work Center: !!"); this.cbWorkCenter.Select(); return; }
            if (!NP.ReqField(this.txtMachine, "Please enter Used Machine !!")) { return; }
            if (!NP.ReqField(this.txtSetup, "Please enter Used Setup !!")) { return; }
            if (!NP.ReqField(this.txtLabor, "Please enter Used Labor !!")) { return; }
            if (!NP.ReqField(this.txtOT, "Please enter Used OT !!")) { return; }

            if (NP.MSGB("Do you want to Close Production Order ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr; Tr = oConn.BeginTransaction();
                try
                {
                    SqlCommand cmdIns = new SqlCommand();

                    NP_Cls.SqlInsert = "INSERT INTO t_ProductionCost  (PrdONumber, MaterialCode, PlantCode, WorkCenterCode, UsedMachine, UsedSetup, UsedLabor, UsedOT, UserCreate, DateCreate) VALUES (@PrdONumber, @MaterialCode, @PlantCode, @WorkCenterCode, @UsedMachine, @UsedSetup, @UsedLabor, @UsedOT, @UserCreate, GETDATE())";
                    cmdIns.Parameters.Add("@PrdONumber", SqlDbType.NVarChar, 12).Value = this.cbProdOrder.SelectedValue;
                    cmdIns.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15).Value = this.lblMaterialCode.Text.Trim();
                    cmdIns.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 4).Value = this.lblPlantCode.Text.Trim();
                    cmdIns.Parameters.Add("@WorkCenterCode", SqlDbType.NVarChar, 10).Value = this.cbWorkCenter.SelectedValue;
                    cmdIns.Parameters.Add("@UsedMachine", SqlDbType.Decimal).Value = decimal.Parse(this.txtMachine.Text.Trim());
                    cmdIns.Parameters.Add("@UsedSetup", SqlDbType.Decimal).Value = decimal.Parse(this.txtSetup.Text.Trim());
                    cmdIns.Parameters.Add("@UsedLabor", SqlDbType.Decimal).Value = decimal.Parse(this.txtLabor.Text.Trim());
                    cmdIns.Parameters.Add("@UsedOT", SqlDbType.Decimal).Value = decimal.Parse(this.txtOT.Text.Trim());
                    cmdIns.Parameters.Add("@UserCreate", SqlDbType.NVarChar, 50).Value = NP_Cls.strUsr;
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                    cmdIns.ExecuteNonQuery();

                    // By NP - 2.7.13 - No reason to flag GI Change to OrderStatus = Close 
                    NP_Cls.sqlUpdate = "UPDATE t_PrdOrderDetail SET IsGIClose = 1 WHERE (PrdONumber = @PrdONumber)";
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.sqlUpdate; cmdIns.Transaction = Tr;
                    cmdIns.ExecuteNonQuery();

                    NP_Cls.sqlUpdate = "UPDATE t_PrdOrder SET OrderStatus = 'Close' WHERE (PrdONumber = @PrdONumber)";
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.sqlUpdate; cmdIns.Transaction = Tr;
                    cmdIns.ExecuteNonQuery();

                    Tr.Commit();
                    Clear(); DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Close Completed !!");
                    this.cbProdOrder.Select();
                }
                catch (Exception ex)
                {
                    if (oConn.State == ConnectionState.Open) { Tr.Rollback(); }
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Close : " + ex.Message); return;
                }
                finally
                {
                    if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                }
            }
            else
            {
                return;
            }
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
        private void frmProductionCost_FormClosing(object sender, FormClosingEventArgs e)
        {
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvView.RowCount == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found !!"); return; }
            if (NP.MSGB("Do you want to delete ?") == DialogResult.Yes)
            {

                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr; Tr = oConn.BeginTransaction();
                try
                {
                    SqlCommand cmdDel = new SqlCommand();
                    NP_Cls.SqlDel = "DELETE FROM   t_ProductionCost WHERE (AutoID = @AutoID)";
                    cmdDel.Parameters.Add("@AutoID", SqlDbType.NVarChar, 10).Value = this.dgvView["clnAutoID", this.dgvView.CurrentRow.Index].Value;
                    cmdDel.Connection = oConn; cmdDel.CommandText = NP_Cls.SqlDel; cmdDel.Transaction = Tr;
                    cmdDel.ExecuteNonQuery();

                    NP_Cls.sqlUpdate = "UPDATE t_PrdOrderDetail SET IsGIClose = 0 WHERE (PrdONumber = @PrdONumber)";
                    cmdDel.Parameters.Add("@PrdONumber", SqlDbType.NVarChar, 12).Value = this.cbProdOrder.SelectedValue;
                    cmdDel.Connection = oConn; cmdDel.CommandText = NP_Cls.sqlUpdate; cmdDel.Transaction = Tr;
                    cmdDel.ExecuteNonQuery();

                    //By NP For OrderStatus = string.emtpt
                    NP_Cls.sqlUpdate = "UPDATE t_PrdOrder SET OrderStatus = '' WHERE (PrdONumber = @PrdONumber)";
                    cmdDel.Connection = oConn; cmdDel.CommandText = NP_Cls.sqlUpdate; cmdDel.Transaction = Tr;
                    cmdDel.ExecuteNonQuery();

                    Tr.Commit();

                    DGV();
                    NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Delete Completed !!");

                    //if (NP._TRanSave(oConn, Tr, NP_Cls.NPTranType.Delete, "t_RoutingDetail", NP_Cls.strUsr))
                    //{
                    //    Tr.Commit();
                    //    DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Delete Completed !!");
                    //}
                    //else
                    //{
                    //    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Try agian !!"); return;
                    //}

                }
                catch (Exception ex)
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Delete : " + ex.Message); return;
                }
                finally
                {
                    if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                }
            }
            else
            {
                return;
            }
        }

        private void txtMachine_KeyPress(object sender, KeyPressEventArgs e)
        {
            NP_Cls.myDecimal(sender, e);
        }
    }
}
