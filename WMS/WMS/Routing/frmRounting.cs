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
    public partial class frmRounting : Form
    {
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection();
        public frmRounting()
        {
            InitializeComponent();
        }
        private void frmRounting_Load(object sender, EventArgs e)
        {
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;

            NP_Cls.SqlSelect = "SELECT MaterialCode, MaterialCode AS MaterialName FROM m_Material WHERE (FileStatus = '1')";
            NP.BindCB(this.cbMaterial, NP_Cls.SqlSelect, "MaterialCode", "MaterialName", "((( Select Material )))");

            NP_Cls.SqlSelect = "SELECT PlantCode, PlantCode AS PlantName FROM m_Plant WHERE (FileStatus = '1')";
            NP.BindCB(this.cbPlant, NP_Cls.SqlSelect, "PlantCode", "PlantName", "((( Select Plant )))");

            NP_Cls.SqlSelect = "SELECT WorkCenterCode, WorkCenterCode AS WorkCenterName FROM m_WorkCenter WHERE (FileStatus = '1')";
            NP.BindCB(this.cbWorkCenter, NP_Cls.SqlSelect, "WorkCenterCode", "WorkCenterName", "((( Select WorkCenter )))");

            Clear(); DGV(); this.btnEdit.Visible = false;
            this.cbMaterial.Text = string.Empty;
            this.cbMaterial.Select();
        }
        private void DGV()
        {
            NP_Cls.SqlSelect = "SELECT 0 AS No,    t_RoutingDetail.WorkCenterCode, m_WorkCenter.WorkCenterName,  t_Routing.BaseQuantity,t_RoutingDetail.STDManHour,t_Routing.Remark ,t_Routing.MaterialCode,t_Routing.PlantCode,t_RoutingDetail.Hours " +
"FROM         t_Routing INNER JOIN t_RoutingDetail ON t_Routing.MaterialCode = t_RoutingDetail.MaterialCode AND t_Routing.PlantCode = t_RoutingDetail.PlantCode INNER JOIN m_WorkCenter ON t_RoutingDetail.WorkCenterCode = m_WorkCenter.WorkCenterCode " +
            "WHERE (t_Routing.MaterialCode = '" + this.cbMaterial.SelectedValue + "') AND (t_Routing.PlantCode = '" + this.cbPlant.SelectedValue + "') ORDER BY t_RoutingDetail.WorkCenterCode";
            DataSet dsSerach = new DataSet(); dsSerach = NP.GetClientDataSet(NP_Cls.SqlSelect);
            for (Int32 i = 0; i < dsSerach.Tables[0].Rows.Count; i++)
            {
                txtBaseQuantity.Text = dsSerach.Tables[0].Rows[0]["BaseQuantity"].ToString();
                dsSerach.Tables[0].Rows[i][0] = i + 1;
            }
            this.dgvView.DataSource = dsSerach.Tables[0];
            if (dsSerach.Tables[0].Rows.Count > 0)
            {
                //gDetail.Enabled = false;
                if (dsSerach.Tables[0].Rows.Count == 1) { this.contextMenuStrip1.Items[1].Enabled = false; } else { this.contextMenuStrip1.Items[1].Enabled = true; }
            }
            else { gDetail.Enabled = true; }
        }
        private void Clear()
        {
            this.cbMaterial.SelectedIndex = 0; this.cbPlant.SelectedIndex = 0; this.cbWorkCenter.SelectedIndex = 0;
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            if ((string.IsNullOrEmpty((this.cbMaterial.Text.Trim()))) || (this.cbMaterial.Text.Trim() == "((( Select Material )))")) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please enter Material: !!"); this.cbMaterial.Select(); return; }
            if ((string.IsNullOrEmpty((this.cbPlant.Text.Trim()))) || (this.cbPlant.Text.Trim() == "((( Select Plant )))")) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please enter Plant: !!"); this.cbPlant.Select(); return; }
            if (NP.ReqField(this.txtBaseQuantity, "Please enter Base Quantity !!") == false) { return; }
            if (NP.ReqField(this.txtStdManHour, "Please enter Standard Man Hour !!") == false) { return; }
            if (NP.ReqField(this.txtHour, "Please enter Hours !!") == false) { return; }
            if ((string.IsNullOrEmpty((this.cbWorkCenter.Text.Trim()))) || (this.cbWorkCenter.Text.Trim() == "((( Select WorkCenter )))")) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please enter Work Center: !!"); this.cbWorkCenter.Select(); return; }

            if (ChkDup())
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Work Center Duplicated !!"); this.cbWorkCenter.Select(); this.cbWorkCenter.SelectAll(); return;
            }

            if (NP.MSGB("Do you want to Add Data ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr; Tr = oConn.BeginTransaction();
                try
                {
                    SqlCommand cmdIns = new SqlCommand();
                    NP_Cls.SqlSelect = "SELECT MaterialCode, PlantCode FROM t_Routing WHERE (MaterialCode = @MaterialCode) AND (PlantCode = @PlantCode)";
                    cmdIns.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15).Value = this.cbMaterial.SelectedValue;
                    cmdIns.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 4).Value = this.cbPlant.SelectedValue;
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlSelect; cmdIns.Transaction = Tr;
                    SqlDataAdapter da = new SqlDataAdapter(cmdIns); DataSet ds = new DataSet(); da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        NP_Cls.SqlInsert = "INSERT INTO t_RoutingDetail (MaterialCode, PlantCode, WorkCenterCode, LogDate,STDManHour,Hours) VALUES (@MaterialCode,@PlantCode,@WorkCenterCode,GETDATE(),@STDManHour,@Hours)";
                        cmdIns.Parameters.Add("@WorkCenterCode", SqlDbType.NVarChar, 10).Value = this.cbWorkCenter.SelectedValue;
                        cmdIns.Parameters.Add("@STDManHour", SqlDbType.Decimal).Value = Convert.ToDecimal(this.txtStdManHour.Text.Trim());
                        cmdIns.Parameters.Add("@Hours", SqlDbType.Decimal).Value = Convert.ToDecimal(this.txtHour.Text.Trim());
                        cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                        cmdIns.ExecuteNonQuery();
                    }
                    else
                    {
                        NP_Cls.SqlInsert = "INSERT INTO t_Routing (MaterialCode, PlantCode,Remark,BaseQuantity) VALUES (@MaterialCode,@PlantCode,@Remark,@BaseQuantity)";
                        cmdIns.Parameters.Add("@Remark", SqlDbType.NVarChar, 255).Value = this.txtRemark.Text.Trim();
                        cmdIns.Parameters.Add("@BaseQuantity", SqlDbType.Decimal).Value = Convert.ToDecimal(this.txtBaseQuantity.Text.Trim());
                        cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                        cmdIns.ExecuteNonQuery();

                        NP_Cls.SqlInsert = "INSERT INTO t_RoutingDetail (MaterialCode, PlantCode, WorkCenterCode, LogDate,STDManHour,Hours) VALUES (@MaterialCode,@PlantCode,@WorkCenterCode,GETDATE(),@STDManHour,@Hours)";
                        cmdIns.Parameters.Add("@WorkCenterCode", SqlDbType.NVarChar, 10).Value = this.cbWorkCenter.SelectedValue;
                        cmdIns.Parameters.Add("@STDManHour", SqlDbType.Decimal).Value = Convert.ToDecimal(this.txtStdManHour.Text.Trim());
                        cmdIns.Parameters.Add("@Hours", SqlDbType.Decimal).Value = Convert.ToDecimal(this.txtHour.Text.Trim());
                        cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                        cmdIns.ExecuteNonQuery();
                    }

                    Tr.Commit();
                    DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Add Data Completed !!");
                    this.cbWorkCenter.Text = string.Empty; this.cbWorkCenter.Select();
                    this.txtStdManHour.Text = string.Empty; this.txtRemark.Text = string.Empty; this.txtHour.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    if (oConn.State == ConnectionState.Open) { Tr.Rollback(); }
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Add : " + ex.Message); return;
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

        private bool ChkDup()
        {
            try
            {
                NP_Cls.SqlSelect = "SELECT 0 AS No,    t_RoutingDetail.WorkCenterCode, m_WorkCenter.WorkCenterName " +
               "FROM         t_Routing INNER JOIN t_RoutingDetail ON t_Routing.MaterialCode = t_RoutingDetail.MaterialCode AND t_Routing.PlantCode = " + "t_RoutingDetail.PlantCode INNER JOIN m_WorkCenter ON t_RoutingDetail.WorkCenterCode = m_WorkCenter.WorkCenterCode " +
                          "WHERE (t_Routing.MaterialCode = '" + this.cbMaterial.SelectedValue + "') AND (t_Routing.PlantCode = '" + this.cbPlant.SelectedValue + "') AND (t_RoutingDetail.WorkCenterCode = '" + this.cbWorkCenter.SelectedValue + "')";
                if (NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        private void frmRounting_FormClosing(object sender, FormClosingEventArgs e)
        {
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;
        }
        private void cbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbMaterial.SelectedIndex == 0)
            {
                this.cbMaterial.Select();
            }
            else
            {
                if (this.cbPlant.SelectedIndex == 0)
                {
                    this.cbPlant.Select();
                }
                else { DGV(); }
            }
        }
        private void cbPlant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbPlant.SelectedIndex == 0)
            {
                this.cbPlant.Select();
            }
            else
            {
                if (this.cbMaterial.SelectedIndex == 0)
                {
                    this.cbMaterial.Select();
                }
                else { DGV(); }
            }
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
                    NP_Cls.SqlDel = "DELETE FROM t_RoutingDetail WHERE (MaterialCode = @MaterialCode) AND (PlantCode = @PlantCode) AND (WorkCenterCode = @WorkCenterCode)";
                    cmdDel.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15).Value = this.cbMaterial.SelectedValue;
                    cmdDel.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 4).Value = this.cbPlant.SelectedValue;
                    cmdDel.Parameters.Add("@WorkCenterCode", SqlDbType.NVarChar, 10).Value = this.dgvView["clnName", this.dgvView.CurrentRow.Index].Value;
                    cmdDel.Connection = oConn; cmdDel.CommandText = NP_Cls.SqlDel; cmdDel.Transaction = Tr;
                    cmdDel.ExecuteNonQuery();

                    if (NP._TRanSave(oConn, Tr, NP_Cls.NPTranType.Delete, "t_RoutingDetail", NP_Cls.strUsr))
                    {
                        Tr.Commit();
                        DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Delete Completed !!");
                    }
                    else
                    {
                        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Try agian !!"); return;
                    }

                }
                catch (Exception ex)
                {
                    if (oConn.State == ConnectionState.Open) { Tr.Rollback(); }
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
        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NP.MSGB("Do you want to delete all ?") == DialogResult.Yes)
            {
                if (this.dgvView.RowCount == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found !!"); return; }

                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr; Tr = oConn.BeginTransaction();
                try
                {
                    SqlCommand cmdDel = new SqlCommand();
                    NP_Cls.SqlDel = "DELETE FROM t_Routing WHERE (MaterialCode = @MaterialCode) AND (PlantCode = @PlantCode)";
                    cmdDel.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15).Value = this.cbMaterial.SelectedValue;
                    cmdDel.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 4).Value = this.cbPlant.SelectedValue;
                    cmdDel.Connection = oConn; cmdDel.CommandText = NP_Cls.SqlDel; cmdDel.Transaction = Tr;
                    cmdDel.ExecuteNonQuery();

                    NP_Cls.SqlDel = "DELETE FROM t_RoutingDetail WHERE (MaterialCode = @MaterialCode) AND (PlantCode = @PlantCode) AND (WorkCenterCode = @WorkCenterCode)";
                    cmdDel.Parameters.Add("@WorkCenterCode", SqlDbType.NVarChar, 10).Value = this.dgvView["clnName", this.dgvView.CurrentRow.Index].Value;
                    cmdDel.Connection = oConn; cmdDel.CommandText = NP_Cls.SqlDel; cmdDel.Transaction = Tr;
                    cmdDel.ExecuteNonQuery();

                    if (NP._TRanSave(oConn, Tr, NP_Cls.NPTranType.Delete, "t_Routing:t_RoutingDetail", NP_Cls.strUsr))
                    {
                        Tr.Commit();
                        DGV(); Clear(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Delete All Completed !!");
                    }
                    else
                    {
                        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Try agian !!"); return;
                    }

                }
                catch (Exception ex)
                {
                    if (oConn.State == ConnectionState.Open) { Tr.Rollback(); }
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Add : " + ex.Message); return;
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

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string MatCode = this.dgvView["MaterialCode", this.dgvView.CurrentRow.Index].Value.ToString();
                string PlantCode = this.dgvView["PlantCode", this.dgvView.CurrentRow.Index].Value.ToString();
                string WorkCenter = this.dgvView["clnName", this.dgvView.CurrentRow.Index].Value.ToString();
                NP_Cls.SqlSelect = "SELECT 0 AS No,    t_RoutingDetail.WorkCenterCode, m_WorkCenter.WorkCenterName,  t_Routing.BaseQuantity,t_RoutingDetail.STDManHour,t_Routing.Remark,t_Routing.MaterialCode,t_Routing.PlantCode,t_RoutingDetail.Hours  " +
"FROM         t_Routing INNER JOIN t_RoutingDetail ON t_Routing.MaterialCode = t_RoutingDetail.MaterialCode AND t_Routing.PlantCode = t_RoutingDetail.PlantCode INNER JOIN m_WorkCenter ON t_RoutingDetail.WorkCenterCode = m_WorkCenter.WorkCenterCode " +
            "WHERE (t_Routing.MaterialCode = '" + MatCode + "') AND (t_Routing.PlantCode = '" + PlantCode + "' AND (t_RoutingDetail.WorkCenterCode = '" + WorkCenter + "')) ORDER BY t_RoutingDetail.LogDate";
                DataSet dsEdit = new DataSet(); dsEdit = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (dsEdit.Tables[0].Rows.Count > 0)
                {
                    this.cbMaterial.Text = dsEdit.Tables[0].Rows[0]["MaterialCode"].ToString();
                    this.cbPlant.Text = dsEdit.Tables[0].Rows[0]["PlantCode"].ToString();
                    this.txtBaseQuantity.Text = dsEdit.Tables[0].Rows[0]["BaseQuantity"].ToString();
                    this.txtRemark.Text = dsEdit.Tables[0].Rows[0]["Remark"].ToString();
                    this.cbWorkCenter.Text = dsEdit.Tables[0].Rows[0]["WorkCenterCode"].ToString();
                    this.txtStdManHour.Text = dsEdit.Tables[0].Rows[0]["STDManHour"].ToString();
                    this.txtHour.Text = dsEdit.Tables[0].Rows[0]["Hours"].ToString();
                    this.cbMaterial.Enabled = false; this.cbPlant.Enabled = false; this.cbWorkCenter.Enabled = false;
                    this.btnAdd.Visible = false; this.btnEdit.Visible = true;
                }
                else
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found !!"); return;
                }
            }
            catch
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found !!"); return;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty((this.cbMaterial.Text.Trim()))) || (this.cbMaterial.Text.Trim() == "((( Select Material )))")) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please enter Material: !!"); this.cbMaterial.Select(); return; }
            if ((string.IsNullOrEmpty((this.cbPlant.Text.Trim()))) || (this.cbPlant.Text.Trim() == "((( Select Plant )))")) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please enter Plant: !!"); this.cbPlant.Select(); return; }
            if (NP.ReqField(this.txtBaseQuantity, "Please enter Base Quantity !!") == false) { return; }
            if (NP.ReqField(this.txtStdManHour, "Please enter Standard Man Hour !!") == false) { return; }
            if (NP.ReqField(this.txtHour, "Please enter Hours !!") == false) { return; }
            if ((string.IsNullOrEmpty((this.cbWorkCenter.Text.Trim()))) || (this.cbWorkCenter.Text.Trim() == "((( Select WorkCenter )))")) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please enter Work Center: !!"); this.cbWorkCenter.Select(); return; }


            if (NP.MSGB("Do you want to Edit Data ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr; Tr = oConn.BeginTransaction();
                try
                {
                    SqlCommand cmdIns = new SqlCommand();
                    NP_Cls.sqlUpdate = "UPDATE [dbo].[t_Routing] SET [Remark] = @Remark ,[BaseQuantity] = @BaseQuantity WHERE (t_Routing.MaterialCode = '" + cbMaterial.SelectedValue + "') AND (t_Routing.PlantCode = '" + cbPlant.SelectedValue + "') ";
                    cmdIns.Parameters.Add("@Remark", SqlDbType.NVarChar, 255).Value = this.txtRemark.Text.Trim();
                    cmdIns.Parameters.Add("@BaseQuantity", SqlDbType.Decimal).Value = Convert.ToDecimal(this.txtBaseQuantity.Text.Trim());
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.sqlUpdate; cmdIns.Transaction = Tr;
                    cmdIns.ExecuteNonQuery();
                    cmdIns.Parameters.Clear();

                    NP_Cls.sqlUpdate = "UPDATE [dbo].[t_RoutingDetail] SET [LogDate] = GetDate() ,[STDManHour] = @STDManHour ,[Hours] = @Hours WHERE (t_RoutingDetail.MaterialCode = '" + cbMaterial.SelectedValue + "') AND (t_RoutingDetail.PlantCode = '" + cbPlant.SelectedValue + "') AND (t_RoutingDetail.WorkCenterCode = '" + cbWorkCenter.SelectedValue + "')";
                    cmdIns.Parameters.Add("@STDManHour", SqlDbType.Decimal).Value = Convert.ToDecimal(this.txtStdManHour.Text.Trim());
                    cmdIns.Parameters.Add("@Hours", SqlDbType.Decimal).Value = Convert.ToDecimal(this.txtHour.Text.Trim());
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.sqlUpdate; cmdIns.Transaction = Tr;
                    cmdIns.ExecuteNonQuery();

                    Tr.Commit();
                    DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Edit Data Completed !!");
                    this.cbWorkCenter.Text = string.Empty; this.cbWorkCenter.Select();
                    this.txtStdManHour.Text = string.Empty; this.txtBaseQuantity.Text = string.Empty; this.txtRemark.Text = string.Empty; this.txtHour.Text = string.Empty; 
                    this.btnAdd.Visible = true; this.btnEdit.Visible = false;
                    this.cbMaterial.Enabled = true; this.cbPlant.Enabled = true; this.cbWorkCenter.Enabled = true;
                }
                catch (Exception ex)
                {
                    if (oConn.State == ConnectionState.Open) { Tr.Rollback(); }
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Add : " + ex.Message); return;
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
    }
}
