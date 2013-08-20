using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WMS.MasterData
{
    public partial class frmLoadStock : Form
    {
        public frmLoadStock()
        {
            InitializeComponent();
        }
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection();
        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            NP_Cls.myDecimal(sender, e);
        }

        private void frmLoadStock_Load(object sender, EventArgs e)
        {
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;

            Clear(); DGV(); this.btnEdit.Visible = false; this.txtCode.Select();
        }
        private void DGV()
        {
            NP_Cls.SqlSelect = "SELECT   MaterialCode, BatchNumber, UR, QI, Block FROM t_StockOverview WHERE (1=1) ";
            if (!string.IsNullOrEmpty(this.txtSCode.Text.Trim()))
            {
                NP_Cls.SqlSelect += " AND (MaterialCode LIKE '%" + this.txtSCode.Text.Trim() + "%') ";
            }
            if (!string.IsNullOrEmpty(this.txtSName.Text.Trim()))
            {
                NP_Cls.SqlSelect += " AND (BatchNumber LIKE '%" + this.txtSName.Text.Trim() + "%') ";
            }
            this.dgvView.DataSource = NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0];
        }
        private void Clear()
        {
            this.txtCode.Text = string.Empty; this.txtBatch.Text = string.Empty; this.txtPlant.Text = string.Empty;
            this.txtLocation.Text = string.Empty; this.txtUnit.Text = string.Empty; this.txtUR.Text = string.Empty;
            this.txtQI.Text = string.Empty; this.txtBlock.Text = string.Empty; this.txtCost.Text = string.Empty; 
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
            try
            {
                if (NP.ReqField(this.txtCode, "Please enter Material Code: !!") == false) { return; }
                if (NP.ReqField(this.txtBatch, "Please enter Batch: !!") == false) { return; }
                if (NP.ReqField(this.txtPlant, "Please enter Plant: !!") == false) { return; }
                if (NP.ReqField(this.txtLocation, "Please enter Location: !!") == false) { return; }
                if (NP.ReqField(this.txtUnit, "Please enter Unit: !!") == false) { return; }
                if (NP.ReqField(this.txtUR, "Please enter UR: !!") == false) { return; }
                if (NP.ReqField(this.txtQI, "Please enter QI: !!") == false) { return; }
                if (NP.ReqField(this.txtBlock, "Please enter Block: !!") == false) { return; }
                if (NP.ReqField(this.txtCost, "Please enter Cost: !!") == false) { return; }
                      
                if (IsMaterial())
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Material Code is not in system !!"); this.txtCode.Select(); this.txtCode.SelectAll(); return;
                }

                if (ChkDup())
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Material Code & Batch Duplicated !!"); this.txtCode.Select(); this.txtCode.SelectAll(); return;
                }

                if (NP.MSGB("Do you want to Add Data ?") == DialogResult.Yes)
                {
                    oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                    if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                    oConn.Open();
                    try
                    {
                        SqlCommand cmdIns = new SqlCommand();
                        NP_Cls.SqlInsert = "INSERT INTO t_StockOverview "+
                      "(MaterialCode, BatchNumber, PlantCode, LocCode, UnitCode, UR, QI, Block, Cost, UserCreate, DateCreate) " +
"VALUES     (@MaterialCode,@BatchNumber,@PlantCode,@LocCode,@UnitCode,@UR,@QI,@Block,@Cost,@UC,GETDATE())";
                        cmdIns.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15).Value = this.txtCode.Text.Trim();
                        cmdIns.Parameters.Add("@BatchNumber", SqlDbType.NVarChar, 10).Value = this.txtBatch.Text.Trim();
                        cmdIns.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 4).Value = this.txtPlant.Text.Trim();
                        cmdIns.Parameters.Add("@LocCode", SqlDbType.NVarChar, 2).Value = this.txtLocation.Text.Trim();
                        cmdIns.Parameters.Add("@UnitCode", SqlDbType.NVarChar, 3).Value = this.txtUnit.Text.Trim();
                        cmdIns.Parameters.Add("@UR", SqlDbType.Decimal).Value = Convert.ToDecimal(this.txtUR.Text.Trim());
                        cmdIns.Parameters.Add("@QI", SqlDbType.Decimal).Value = Convert.ToDecimal(this.txtQI.Text.Trim());
                        cmdIns.Parameters.Add("@Block", SqlDbType.Decimal).Value = Convert.ToDecimal(this.txtBlock.Text.Trim());
                        cmdIns.Parameters.Add("@Cost", SqlDbType.Decimal).Value = Convert.ToDecimal(this.txtCost.Text.Trim());
                        cmdIns.Parameters.Add("@UC", SqlDbType.NVarChar, 20).Value = NP_Cls.strUsr;
                        
                        cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert;
                        cmdIns.ExecuteNonQuery();

                        Clear(); DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Add Data Completed !!"); this.txtCode.Focus();
                    }
                    catch (Exception ex)
                    {
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
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Add : " + ex.Message); return;
            }
        }

        private bool IsMaterial()
        {
            try
            {
                NP_Cls.SqlSelect = "SELECT MaterialCode FROM m_Material WHERE (MaterialCode = '" + this.txtCode.Text.Trim().Replace("'", string.Empty) + "') AND (UnitCode = '" + this.txtUnit.Text.Trim() + "') AND (LocCode = '" + this.txtLocation.Text.Trim() + "') AND (PlantCode = '" + this.txtPlant.Text.Trim() + "') WHERE (FileStatus = '1')";
                if (NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private bool ChkDup()
        {
            try
            {
                NP_Cls.SqlSelect = "SELECT MaterialCode FROM t_StockOverview WHERE (MaterialCode = '" + this.txtCode.Text.Trim().Replace("'", string.Empty) + "') AND (BatchNumber = '"+ this.txtBatch.Text.Trim() +"')";
                if (NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void txtSCode_TextChanged(object sender, EventArgs e)
        {
            DGV();
        }
        private void txtSName_TextChanged(object sender, EventArgs e)
        {
            DGV();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string[] strSelect = { this.dgvView["clnMaterialCode", this.dgvView.CurrentRow.Index].Value.ToString(), this.dgvView["clnBatch", this.dgvView.CurrentRow.Index].Value.ToString() };
                NP_Cls.SqlSelect = "SELECT * FROM t_StockOverview WHERE (MaterialCode ='" + strSelect[0].ToString() + "') AND (BatchNumber = '"+ strSelect[1].ToString() +"')";
                DataSet dsEdit = new DataSet(); dsEdit = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (dsEdit.Tables[0].Rows.Count > 0)
                {
                    this.txtCode.Text = dsEdit.Tables[0].Rows[0]["MaterialCode"].ToString();
                    this.txtBatch.Text = dsEdit.Tables[0].Rows[0]["BatchNumber"].ToString();
                    this.txtPlant.Text = dsEdit.Tables[0].Rows[0]["PlantCode"].ToString();
                    this.txtLocation.Text = dsEdit.Tables[0].Rows[0]["LocCode"].ToString();
                    this.txtUnit.Text = dsEdit.Tables[0].Rows[0]["UnitCode"].ToString();
                    this.txtUR.Text = dsEdit.Tables[0].Rows[0]["UR"].ToString();
                    this.txtQI.Text = dsEdit.Tables[0].Rows[0]["QI"].ToString();
                    this.txtBlock.Text = dsEdit.Tables[0].Rows[0]["Block"].ToString();
                    this.txtCost.Text = dsEdit.Tables[0].Rows[0]["Cost"].ToString();

                    this.txtCode.Enabled = false; this.txtBatch.Enabled = false; this.btnAdd.Visible = false; this.btnEdit.Visible = true;
                    this.txtPlant.Select(); this.txtPlant.SelectAll();
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
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NP.MSGB("Do you want to delete ?") == DialogResult.Yes)
            {
                if (this.dgvView.RowCount == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found !!"); return; }
                NP_Cls.SqlDel = "DELETE FROM t_StockOverview WHERE (MaterialCode = '" + this.dgvView["clnMaterialCode", this.dgvView.CurrentRow.Index].Value.ToString() + "') AND (BatchNumber = '" + this.dgvView["clnBatch", this.dgvView.CurrentRow.Index].Value.ToString() + "')";
                string strErr = string.Empty;
                NP.SqlCmd(NP_Cls.SqlDel, ref strErr); Clear(); DGV(); this.btnAdd.Visible = true; this.btnEdit.Visible = false;
                this.txtCode.Enabled = true; this.txtBatch.Enabled = true; NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Delete Completed !!");
            }
            else
            {
                return;
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (NP.ReqField(this.txtCode, "Please enter Material Code: !!") == false) { return; }
            if (NP.ReqField(this.txtBatch, "Please enter Batch: !!") == false) { return; }
            if (NP.ReqField(this.txtPlant, "Please enter Plant: !!") == false) { return; }
            if (NP.ReqField(this.txtLocation, "Please enter Location: !!") == false) { return; }
            if (NP.ReqField(this.txtUnit, "Please enter Unit: !!") == false) { return; }
            if (NP.ReqField(this.txtUR, "Please enter UR: !!") == false) { return; }
            if (NP.ReqField(this.txtQI, "Please enter QI: !!") == false) { return; }
            if (NP.ReqField(this.txtBlock, "Please enter Block: !!") == false) { return; }
            if (NP.ReqField(this.txtCost, "Please enter Cost: !!") == false) { return; }

            if (IsMaterial())
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Material Code is not in system !!"); this.txtCode.Select(); this.txtCode.SelectAll(); return;
            }

            if (NP.MSGB("Do you want to Edit Data ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open();
                try
                {
                    SqlCommand cmdEdit = new SqlCommand();
                    NP_Cls.sqlUpdate = "UPDATE    t_StockOverview "+
"SET              PlantCode = @PlantCode, LocCode = @LocCode, UnitCode = @UnitCode, UR = @UR, QI = @QI, Block = @Block, Cost = @Cost, "+
                    "  UserChange = @UC, DateChange = GETDATE() " +
" WHERE     (MaterialCode = @MaterialCode) AND (BatchNumber = @BatchNumber)";
                    cmdEdit.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15).Value = this.txtCode.Text.Trim();
                    cmdEdit.Parameters.Add("@BatchNumber", SqlDbType.NVarChar, 10).Value = this.txtBatch.Text.Trim();
                    cmdEdit.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 4).Value = this.txtPlant.Text.Trim();
                    cmdEdit.Parameters.Add("@LocCode", SqlDbType.NVarChar, 2).Value = this.txtLocation.Text.Trim();
                    cmdEdit.Parameters.Add("@UnitCode", SqlDbType.NVarChar, 3).Value = this.txtUnit.Text.Trim();
                    cmdEdit.Parameters.Add("@UR", SqlDbType.Decimal).Value = Convert.ToDecimal(this.txtUR.Text.Trim());
                    cmdEdit.Parameters.Add("@QI", SqlDbType.Decimal).Value = Convert.ToDecimal(this.txtQI.Text.Trim());
                    cmdEdit.Parameters.Add("@Block", SqlDbType.Decimal).Value = Convert.ToDecimal(this.txtBlock.Text.Trim());
                    cmdEdit.Parameters.Add("@Cost", SqlDbType.Decimal).Value = Convert.ToDecimal(this.txtCost.Text.Trim());
                    cmdEdit.Parameters.Add("@UC", SqlDbType.NVarChar, 20).Value = NP_Cls.strUsr;
                    cmdEdit.Connection = oConn; cmdEdit.CommandText = NP_Cls.sqlUpdate;
                    cmdEdit.ExecuteNonQuery();

                    Clear(); DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Edit Data Completed !!");
                    this.btnAdd.Visible = true; this.btnEdit.Visible = false; this.txtCode.Enabled = true; this.txtBatch.Enabled = true; this.txtCode.Focus();
                }
                catch (Exception ex)
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Edit : " + ex.Message); return;
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
        private void frmLoadStock_FormClosing(object sender, FormClosingEventArgs e)
        {
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;
        }

    }
}
