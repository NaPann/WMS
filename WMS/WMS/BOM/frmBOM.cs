using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WMS.BOM
{
    public partial class frmBOM : Form
    {
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection();
       public frmBOM()
        {
            InitializeComponent();
        }

        public void GenVCode()
        {
            try
            {
                NP_Cls.SqlSelect = "SELECT TmpBOMCode FROM tmp_GenCode";
                Int64 iCode = Convert.ToInt64(NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0].Rows[0][0].ToString());
                iCode += 1; string strErr = string.Empty;
                if (NP.SqlCmd("UPDATE tmp_GenCode SET TmpBOMCode = " + iCode, ref strErr))
                {
                    NP_Cls.strBOMCode = iCode.ToString();
                }
                else
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, strErr);
                    return;
                }
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, ex.Message); return;
            }
        }
        private void btnSetBOMType_Click(object sender, EventArgs e)
        {
            WMS.BOM.frmBOMTypeMaster frm = new frmBOMTypeMaster();
            frm.ShowDialog();
            DataSet dsBT = new DataSet(); dsBT.ReadXml(NP_Cls.PathBT); DataRow dr = dsBT.Tables[0].NewRow();
            dr[0] = 0; dr[1] = "((( Select B.O.M Type )))";
            dsBT.Tables[0].Rows.InsertAt(dr, 0);
            dsBT.AcceptChanges();
            this.cbBOMType.DataSource = dsBT.Tables[0];
            this.cbBOMType.DisplayMember = "BTDesc"; this.cbBOMType.ValueMember = "BTCode";
        }
        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            NP_Cls.myInteger(sender, e);
        }

        private void frmBOM_Load(object sender, EventArgs e)
        {
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;

            DataSet dsBT = new DataSet(); dsBT.ReadXml(NP_Cls.PathBT); DataRow dr = dsBT.Tables[0].NewRow();
            dr[0] = 0; dr[1] = "((( Select B.O.M Type )))";
            dsBT.Tables[0].Rows.InsertAt(dr, 0);
            dsBT.AcceptChanges();
            this.cbBOMType.DataSource = dsBT.Tables[0];
            this.cbBOMType.DisplayMember = "BTDesc"; this.cbBOMType.ValueMember = "BTCode";

            NP_Cls.SqlSelect = "SELECT MaterialCode, MaterialName FROM m_Material WHERE (FileStatus = '1')";
            NP.BindCB(this.cbMaterial, NP_Cls.SqlSelect, "MaterialCode", "MaterialName", "((( Select Material )))");

            NP.BindCB(this.cbComponent, NP_Cls.SqlSelect, "MaterialCode", "MaterialName", "((( Select Component )))");

            NP_Cls.SqlSelect = "SELECT PlantCode, PlantName FROM m_Plant WHERE (FileStatus = '1')";
            NP.BindCB(this.cbPlant, NP_Cls.SqlSelect, "PlantCode", "PlantName", "((( Select Plant )))");

            NP_Cls.SqlSelect = "SELECT UnitCode, UnitName FROM m_Unit WHERE (FileStatus = '1')";
            NP.BindCB(this.cbUnit, NP_Cls.SqlSelect, "UnitCode", "UnitName", "((( Select Unit )))");
            this.txtVersion.Text = "1";
            Clear(); DGV(); this.btnEdit.Visible = false; this.cbMaterial.Select();
        }
        private void DGV()
        {
            this.lblRemain.Text = string.Empty;

            NP_Cls.SqlSelect = "SELECT 0 as ItemNo,    m_Unit.UnitName, t_BOMDetail.Category, t_BOMDetail.MaterialCode, m_Material.MaterialName, t_BOMDetail.Quantity, t_BOM.BOMCode,  t_BOMDetail.BOMDetailCode, t_BOM.Approve, t_BOM.BOMVersion " +
           "FROM         t_BOM INNER JOIN " +
                     "m_Unit ON t_BOM.UnitCode = m_Unit.UnitCode INNER JOIN " +
                     "t_BOMDetail ON t_BOM.BOMCode = t_BOMDetail.BOMCode INNER JOIN " +
                     "m_Material ON t_BOMDetail.MaterialCode = m_Material.MaterialCode " +
"WHERE     (t_BOM.FileStatus = N'1') AND (t_BOM.PlantCode = N'" + this.cbPlant.SelectedValue + "') AND (t_BOM.MaterialCode = N'" + this.cbMaterial.SelectedValue + "') AND (Approve = 0) ORDER BY BOMVERSION DESC"; DataSet ds = new DataSet();
            ds = NP.GetClientDataSet(NP_Cls.SqlSelect);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.txtVersion.ReadOnly = false;
                for (Int32 i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ds.Tables[0].Rows[i]["ItemNo"] = i + 1;
                }
                //GetData(false); this.gMaster.Enabled = false; this.btnUnLock.Visible = true; this.btnLock.Visible = false;
                this.lblCode.Text = ds.Tables[0].Rows[0]["BOMCode"].ToString() + ":" + ds.Tables[0].Rows[0]["BOMDetailCode"].ToString();
                NP_Cls.strBOMCode = ds.Tables[0].Rows[0]["BOMCode"].ToString();
                this.btnVerAppr.Visible = ((bool)ds.Tables[0].Rows[0]["Approve"]);
                this.btnVerNot.Visible = (!(bool)ds.Tables[0].Rows[0]["Approve"]); this.txtVersion.Text = ds.Tables[0].Rows[0]["BOMVersion"].ToString();
                if (this.btnVerAppr.Visible)
                {
                    //this.gMaster.Enabled = false; this.cbComponent.Enabled = false; this.txtQtyComp.Enabled = false; this.btnUnLock.Visible = true;
                    this.btnApprove.Visible = false; this.btnAdd.Visible = false; this.btnDelAll.Visible = false; this.btnVersion.Visible = true;
                    this.contextMenuStrip1.Enabled = false;
                }
                else { this.btnApprove.Visible = true; this.btnAdd.Visible = true; this.btnDelAll.Visible = true; this.btnVersion.Visible = false; }
                this.dgvView.DataSource = ds.Tables[0]; this.dgvView.ClearSelection();
                if (this.cbBOMType.SelectedValue.ToString().ToUpper() == "M")
                {
                    Double bQty = 0;
                    for (byte i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        bQty += Convert.ToDouble(this.dgvView["clnQty", i].Value);
                    }
                    this.lblRemain.Text = "Remain: " + (100 - bQty).ToString();
                }
            }
            else
            {
                NP_Cls.SqlSelect = "SELECT 0 as ItemNo,    m_Unit.UnitName, t_BOMDetail.Category, t_BOMDetail.MaterialCode, m_Material.MaterialName, t_BOMDetail.Quantity, t_BOM.BOMCode,  t_BOMDetail.BOMDetailCode, t_BOM.Approve, t_BOM.BOMVersion " +
                "FROM         t_BOM INNER JOIN " +
                          "m_Unit ON t_BOM.UnitCode = m_Unit.UnitCode INNER JOIN " +
                          "t_BOMDetail ON t_BOM.BOMCode = t_BOMDetail.BOMCode INNER JOIN " +
                          "m_Material ON t_BOMDetail.MaterialCode = m_Material.MaterialCode " +
    "WHERE     (t_BOM.FileStatus = N'1') AND (t_BOM.PlantCode = N'" + this.cbPlant.SelectedValue + "') AND (t_BOM.MaterialCode = N'" + this.cbMaterial.SelectedValue + "') AND (Approve = 1) ORDER BY BOMVERSION DESC";

                ds = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.txtVersion.ReadOnly = true;
                    for (Int32 i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ds.Tables[0].Rows[i]["ItemNo"] = i + 1;
                    }
                    GetData(true); this.gMaster.Enabled = false;//this.btnUnLock.Visible = true; this.btnLock.Visible = false;
                    this.lblCode.Text = ds.Tables[0].Rows[0]["BOMCode"].ToString() + ":" + ds.Tables[0].Rows[0]["BOMDetailCode"].ToString();
                    NP_Cls.strBOMCode = ds.Tables[0].Rows[0]["BOMCode"].ToString();
                    this.btnVerAppr.Visible = ((bool)ds.Tables[0].Rows[0]["Approve"]);
                    this.btnVerNot.Visible = (!(bool)ds.Tables[0].Rows[0]["Approve"]); this.txtVersion.Text = ds.Tables[0].Rows[0]["BOMVersion"].ToString();
                    if (this.btnVerAppr.Visible)
                    {
                        //this.gMaster.Enabled = false; this.cbComponent.Enabled = false; this.txtQtyComp.Enabled = false; this.btnUnLock.Visible = true;
                        this.btnApprove.Visible = false; this.btnAdd.Visible = false; this.btnDelAll.Visible = false; this.btnVersion.Visible = true;
                        this.contextMenuStrip1.Enabled = false;
                    }
                    else { this.btnApprove.Visible = true; this.btnAdd.Visible = true; this.btnDelAll.Visible = true; this.btnVersion.Visible = false; }
                }
                else {/* this.btnUnLock.Visible = false; this.btnVerAppr.Visible = false; this.btnVerNot.Visible = false; this.btnLock.Visible = true;*/ }
                this.dgvView.DataSource = ds.Tables[0]; this.dgvView.ClearSelection();
                if (this.cbBOMType.SelectedValue.ToString().ToUpper() == "M")
                {
                    Double bQty = 0;
                    for (byte i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        bQty += Convert.ToDouble(this.dgvView["clnQty", i].Value);
                    }
                    this.lblRemain.Text = "Remain: " + (100 - bQty).ToString();
                }
            }
        }

        private void GetData(bool Appr)
        {
            try
            {
                NP_Cls.SqlSelect = "SELECT     BOMType, UnitCode, Quantity, BOMVersion FROM  t_BOM WHERE (MaterialCode = N'"+ this.cbMaterial.SelectedValue +"') AND (PlantCode = N'"+ this.cbPlant.SelectedValue +"') AND (Approve = "+ Convert.ToByte(Appr) +")";
                DataSet ds = new DataSet(); ds = NP.GetClientDataSet(NP_Cls.SqlSelect);
                this.cbBOMType.SelectedValue = ds.Tables[0].Rows[0]["BOMType"].ToString();
                this.cbUnit.SelectedValue = ds.Tables[0].Rows[0]["UnitCode"].ToString();
                this.txtQty.Text = ds.Tables[0].Rows[0]["Quantity"].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void BuildVersion(string strMaterialCode, string strPlant)
        {
            try
            {
                NP_Cls.SqlSelect = "SELECT  BOMVersion, BOMVersion AS V FROM   t_BOM WHERE     (FileStatus = N'1')";

                DataSet ds = new DataSet(); ds.Tables.Add(new DataTable("dtV"));
                ds.Tables[0].Columns.Add(new DataColumn("V", typeof(System.String))); ds.Tables[0].Columns.Add(new DataColumn("BOMVersion", typeof(System.String)));
                DataRow dr; dr = ds.Tables[0].NewRow();
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Ver : " + ex.Message); return;
            }
        }  
        private void Clear()
        {
            this.cbMaterial.SelectedIndex = 0; this.cbPlant.SelectedIndex = 0; this.cbBOMType.SelectedIndex = 0; this.cbUnit.SelectedIndex = 0;
            this.txtQty.Text = string.Empty;
        }

        private void cbBOMType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbBOMType.SelectedIndex == 0)
            {
                this.cbBOMType.Select();
            }
            else
            {
                if (this.cbBOMType.SelectedValue.ToString() == "M")
                {
                    this.txtQty.Text = "100"; this.txtQty.ReadOnly = true;
                }
                else
                {
                    this.txtQty.Text = string.Empty; this.txtQty.ReadOnly = false;
                }
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (NP.ReqField(this.cbMaterial, "Please enter Material: !!") == false) { return; }
            if (NP.ReqField(this.cbPlant, "Please enter Plant: !!") == false) { return; }
            if (NP.ReqField(this.cbBOMType, "Please enter B.O.M Type: !!") == false) { return; }
            if (NP.ReqField(this.cbUnit, "Please enter Unit: !!") == false) { return; }
            if (NP.ReqField(this.txtQty, "Please enter Quantity: !!") == false) { return; }
            if (NP.ReqField(this.cbComponent, "Please enter Component: !!") == false) { return; }
            if (NP.ReqField(this.txtQtyComp, "Please enter Qty of Component: !!") == false) { return; }

            if (ChkDup())
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Code Duplicated !!"); this.cbComponent.Select(); return;
            }

            if (this.dgvView.RowCount != 0)
            {
                Double bChk = 0;
                for (byte i = 0; i < this.dgvView.RowCount; i++)
                {
                    bChk += Convert.ToDouble(this.dgvView["clnQty", i].Value);
                }
                if ((Convert.ToDouble(this.txtQtyComp.Text.Trim()) + bChk) > 100)
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Qty of Component is over 100 !!"); this.txtQtyComp.Select(); this.txtQtyComp.SelectAll(); return;
                }
            }
            else
            {
                if (this.cbBOMType.SelectedValue.ToString().ToUpper() == "M")
                {
                    if (Convert.ToDouble(this.txtQtyComp.Text.Trim()) > 100)
                    {
                        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Qty of Component is over 100 !!"); this.txtQtyComp.Select(); this.txtQtyComp.SelectAll(); return;
                    }
                }
            }

            if (NP.MSGB("Do you want to Add Data ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr; Tr = oConn.BeginTransaction();
                try
                {
                    SqlCommand cmdIns = new SqlCommand();
                    NP_Cls.SqlSelect = "SELECT MaterialCode, PlantCode FROM t_BOM WHERE (MaterialCode = @MaterialCode) AND (PlantCode = @PlantCode) AND (BOMVersion = @Ver)";
                    cmdIns.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15).Value = this.cbMaterial.SelectedValue;
                    cmdIns.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 4).Value = this.cbPlant.SelectedValue;
                    cmdIns.Parameters.Add("@Ver", SqlDbType.NVarChar, 20).Value = this.txtVersion.Text.Trim();
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlSelect; cmdIns.Transaction = Tr;
                    SqlDataAdapter da = new SqlDataAdapter(cmdIns); DataSet ds = new DataSet(); da.Fill(ds);

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        GenVCode();
                        NP_Cls.SqlInsert = "INSERT INTO t_BOM " +
                          "(BOMCode, MaterialCode, PlantCode, BOMType, UnitCode, Quantity, BOMVersion, UserCreate, DateCreate, FileStatus, Approve) " +
    "VALUES     (@BOMCode,@MaterialCode,@PlantCode,@BOMType,@UnitCode,@Quantity,@BOMVersion,@UC, GETDATE(),@St,@Appr)";
                        cmdIns.Parameters.Add("@BOMCode", SqlDbType.Int).Value = NP_Cls.strBOMCode;
                        cmdIns.Parameters.Add("@BOMType", SqlDbType.NVarChar, 1).Value = this.cbBOMType.SelectedValue;
                        cmdIns.Parameters.Add("@UnitCode", SqlDbType.NVarChar, 3).Value = this.cbUnit.SelectedValue;
                        cmdIns.Parameters.Add("@Quantity", SqlDbType.Int).Value = Convert.ToInt32(this.txtQty.Text.Trim());
                        cmdIns.Parameters.Add("@BOMVersion", SqlDbType.Int).Value = this.txtVersion.Text.Trim();
                        cmdIns.Parameters.Add("@UC", SqlDbType.NVarChar, 10).Value = NP_Cls.strUsr;
                        cmdIns.Parameters.Add("@St", SqlDbType.NVarChar, 1).Value = "1";
                        cmdIns.Parameters.Add("@Appr", SqlDbType.Bit).Value = 0;
                        cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                        cmdIns.ExecuteNonQuery();

                        NP_Cls.SqlInsert = "INSERT INTO t_BOMDetail " +
                      "(BOMCode, Category, MaterialCode, Quantity) " +
"VALUES     (@BOMCode,@Category,@CompCode,@QtyComp)";
                        cmdIns.Parameters.Add("@CompCode", SqlDbType.NVarChar, 15).Value = this.cbComponent.SelectedValue;
                        cmdIns.Parameters.Add("@Category", SqlDbType.NVarChar, 1).Value = ChkCategory(oConn, Tr, this.cbComponent.SelectedValue.ToString());
                        cmdIns.Parameters.Add("@QtyComp", SqlDbType.Decimal).Value = Convert.ToDouble(this.txtQtyComp.Text.Trim());
                        cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                        cmdIns.ExecuteNonQuery();

                        Tr.Commit();
                        this.cbComponent.SelectedIndex = 0; this.txtQtyComp.Text = string.Empty;
                        DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Add Data Completed !!"); this.cbMaterial.Select();
                    }
                    else
                    {
                        NP_Cls.strBOMCode = this.dgvView["clnBOMCode", 0].Value.ToString();
                        NP_Cls.SqlInsert = "INSERT INTO t_BOMDetail " +
                  "(BOMCode, Category, MaterialCode, Quantity) " +
"VALUES     (@BOMCode,@Category,@CompCode,@QtyComp)";
                        cmdIns.Parameters.Add("@BOMCode", SqlDbType.Int).Value = NP_Cls.strBOMCode;
                        cmdIns.Parameters.Add("@CompCode", SqlDbType.NVarChar, 15).Value = this.cbComponent.SelectedValue;
                        cmdIns.Parameters.Add("@Category", SqlDbType.NVarChar, 1).Value = ChkCategory(oConn, Tr, this.cbComponent.SelectedValue.ToString());
                        cmdIns.Parameters.Add("@QtyComp", SqlDbType.Decimal).Value = Convert.ToDouble(this.txtQtyComp.Text.Trim());
                        cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                        cmdIns.ExecuteNonQuery();

                        Tr.Commit();
                        this.cbComponent.SelectedIndex = 0; this.txtQtyComp.Text = string.Empty;
                        DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Add Data Completed !!"); this.cbMaterial.Select();
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
        private string ChkCategory(SqlConnection oConn,SqlTransaction Tr, string strComp)
        {
            try
            {
                    SqlCommand cmdSe = new SqlCommand();
                    NP_Cls.SqlSelect = "SELECT MaterialCode FROM t_BOM WHERE (MaterialCode = @MaterialCode)";
                    cmdSe.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15).Value = this.cbComponent.SelectedValue;
                    cmdSe.Connection = oConn; cmdSe.CommandText = NP_Cls.SqlSelect; cmdSe.Transaction = Tr;
                    SqlDataAdapter da = new SqlDataAdapter(cmdSe); DataSet ds = new DataSet(); da.Fill(ds);
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return "M";
                    }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private bool ChkDup()
        {           
              try
            {
                NP_Cls.SqlSelect = " SELECT BOMCode, MaterialCode FROM t_BOMDetail WHERE (BOMCode = '"+ NP_Cls.strBOMCode +"') AND (MaterialCode = N'"+ this.cbComponent.SelectedValue +"') AND (BOMVersion = '"+ this.txtVersion.Text.Trim() +"')";
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
        private void txtQtyComp_KeyPress(object sender, KeyPressEventArgs e)
        {
            NP_Cls.myDecimal(sender, e);
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
                else
                {
                    DGV();
                }
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
                else
                {
                    DGV();
                }
            }
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            //this.gMaster.Enabled = false; this.btnUnLock.Visible = true; this.btnLock.Visible = false;
        }
        private void btnUnLock_Click(object sender, EventArgs e)
        {
            //this.gMaster.Enabled = true; this.btnUnLock.Visible = false; /*this.btnLock.Visible = true;*/ this.btnVersion.Visible = false;
            this.cbComponent.Enabled = true; this.cbComponent.SelectedIndex = 0; this.lblCode.Text = string.Empty; this.txtQtyComp.Text = string.Empty;
            this.Clear(); DGV();
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
                    NP_Cls.SqlDel = "DELETE FROM t_BOMDetail WHERE (BOMCode = @BOMCode) AND (BOMDetailCode = @BOMDetailCode)";
                    cmdDel.Parameters.Add("@BOMCode", SqlDbType.Int).Value = this.dgvView["clnBOMCode", this.dgvView.CurrentRow.Index].Value;
                    cmdDel.Parameters.Add("@BOMDetailCode", SqlDbType.Int).Value = this.dgvView["clnBOMDetailCode", this.dgvView.CurrentRow.Index].Value;
                    cmdDel.Connection = oConn; cmdDel.CommandText = NP_Cls.SqlDel; cmdDel.Transaction = Tr;
                    cmdDel.ExecuteNonQuery();

                    if (NP._TRanSave(oConn, Tr, NP_Cls.NPTranType.Delete, "t_BOMDetail", NP_Cls.strUsr))
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
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string strSelect = this.dgvView["clnBOMCode", this.dgvView.CurrentRow.Index].Value.ToString(); 
                string strSelect2 = this.dgvView["clnBOMDetailCode", this.dgvView.CurrentRow.Index].Value.ToString();
                NP_Cls.SqlSelect = "SELECT * FROM  t_BOMDetail WHERE (BOMCode ='" + strSelect + "') AND (BOMDetailCode = '"+ strSelect2 +"')";
                DataSet dsEdit = new DataSet(); dsEdit = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (dsEdit.Tables[0].Rows.Count > 0)
                {
                    this.cbComponent.SelectedValue = dsEdit.Tables[0].Rows[0]["MaterialCode"].ToString();
                    this.txtQtyComp.Text = dsEdit.Tables[0].Rows[0]["Quantity"].ToString();
                    this.lblCode.Text = this.dgvView["clnBOMCode", this.dgvView.CurrentRow.Index].Value.ToString() + ":" + this.dgvView["clnBOMDetailCode", this.dgvView.CurrentRow.Index].Value.ToString();
                    this.cbComponent.Enabled = false; this.btnAdd.Visible = false; this.btnEdit.Visible = true;
                    this.txtQtyComp.Select(); this.txtQtyComp.SelectAll();
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
        private void btnDelAll_Click(object sender, EventArgs e)
        {
            if (this.dgvView.RowCount == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found !!"); return; }
            if (NP.MSGB("Do you want to delete all data ?") == DialogResult.Yes)
            {

                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr; Tr = oConn.BeginTransaction();
                try
                {
                    SqlCommand cmdDel = new SqlCommand();
                    NP_Cls.SqlDel = "DELETE FROM t_BOMDetail WHERE (BOMCode = @BOMCode)";
                    cmdDel.Parameters.Add("@BOMCode", SqlDbType.Int).Value = NP_Cls.strBOMCode;
                    cmdDel.Connection = oConn; cmdDel.CommandText = NP_Cls.SqlDel; cmdDel.Transaction = Tr;
                    cmdDel.ExecuteNonQuery();

                    NP_Cls.SqlDel = "DELETE FROM t_BOM WHERE (BOMCode = @BOMCode)";
                    cmdDel.Connection = oConn; cmdDel.CommandText = NP_Cls.SqlDel; cmdDel.Transaction = Tr;
                    cmdDel.ExecuteNonQuery();

                    if (NP._TRanSave(oConn, Tr, NP_Cls.NPTranType.Delete, "t_BOM:t_BOMDetail", NP_Cls.strUsr))
                    {
                        //Tr.Commit(); this.gMaster.Enabled = true; this.btnUnLock.Visible = false; /*this.btnLock.Visible = true;*/
                        this.cbComponent.Enabled = true; this.cbComponent.SelectedIndex = 0; this.lblCode.Text = string.Empty; this.txtQtyComp.Text = string.Empty;
                        this.Clear(); DGV();
                        NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Delete All Completed !!");
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
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (NP.ReqField(this.cbComponent, "Please enter Component: !!") == false) { return; }
            if (NP.ReqField(this.txtQtyComp, "Please enter Qty of Component: !!") == false) { return; }
    
            if (NP.MSGB("Do you want to Edit Data ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open();
                try
                {
                    SqlCommand cmdEdit = new SqlCommand(); string[] strCode = this.lblCode.Text.Trim().Split(':');
                    NP_Cls.sqlUpdate = "UPDATE   t_BOMDetail " +
"SET    Quantity = @Qty WHERE  (BOMCode = @BOMCode) AND (BOMDetailCode = @BOMDetailCode)";
                    cmdEdit.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDouble(this.txtQtyComp.Text.Trim());
                    cmdEdit.Parameters.Add("@BOMCode", SqlDbType.Int).Value = strCode[0].ToString();
                    cmdEdit.Parameters.Add("@BOMDetailCode", SqlDbType.Int).Value = strCode[1].ToString();
                   
                    cmdEdit.Connection = oConn; cmdEdit.CommandText = NP_Cls.sqlUpdate;
                    cmdEdit.ExecuteNonQuery();

                    this.cbComponent.SelectedIndex = 0; this.txtQtyComp.Text = string.Empty;
                    DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Edit Data Completed !!");
                    this.btnAdd.Visible = true; this.btnEdit.Visible = false; this.cbComponent.Enabled = true; this.cbComponent.Select();
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

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (this.dgvView.RowCount == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found to Approve !!"); return; }
            if (this.btnVerAppr.Visible) { NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "This BOM is Approve already !!"); return; }
            if (this.cbBOMType.SelectedValue.ToString().ToUpper() == "M")
            {
                Double bQty = 0;
                for (byte i = 0; i < this.dgvView.RowCount; i++)
                {
                    bQty += Convert.ToDouble(this.dgvView["clnQty", i].Value);
                }
                if (bQty < 100) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Qty of Component must equal 100 !!"); return; }
            }

            if (NP.MSGB("Do you want to Approve this BOM ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr; Tr = oConn.BeginTransaction();
                try
                {
                    SqlCommand cmdEdit = new SqlCommand(); string[] strCode = this.lblCode.Text.Trim().Split(':');
                    NP_Cls.sqlUpdate = "UPDATE   t_BOM SET Approve = @Appr WHERE (BOMCode = @BOMCode)";
                    cmdEdit.Parameters.Add("@BOMCode", SqlDbType.Int).Value = NP_Cls.strBOMCode;
                    cmdEdit.Parameters.Add("@Appr", SqlDbType.Bit).Value = 1;

                    cmdEdit.Connection = oConn; cmdEdit.CommandText = NP_Cls.sqlUpdate; cmdEdit.Transaction = Tr;
                    cmdEdit.ExecuteNonQuery();

                    if (NP._TRanSave(oConn, Tr, NP_Cls.NPTranType.Update, "t_BOM:Approve", NP_Cls.strUsr))
                    {
                        Tr.Commit();
                        this.cbComponent.SelectedIndex = 0; this.txtQtyComp.Text = string.Empty;
                        DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Approve Completed !!");
                        this.btnAdd.Visible = true; this.btnEdit.Visible = false; this.cbComponent.Enabled = false; this.txtQtyComp.Enabled = false;
                    }
                    else
                    {
                        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Try Again !!"); return;
                    }
                }
                catch (Exception ex)
                {
                    if (oConn.State == ConnectionState.Open) { Tr.Rollback(); }
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Approve : " + ex.Message); return;
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
        private void btnVersion_Click(object sender, EventArgs e)
        {
            if (NP.MSGB("Do you want to Create New Version ?") == DialogResult.Yes)
            {
                this.cbComponent.SelectedIndex = 0; this.txtQtyComp.Text = string.Empty;
                DGV();
                //this.gMaster.Enabled = true; this.cbComponent.Enabled = true; this.txtQtyComp.Enabled = true; this.btnUnLock.Visible = false;
                this.btnApprove.Visible = false; this.btnAdd.Visible = true; this.btnDelAll.Visible = true; this.btnVersion.Visible = false;
                this.txtVersion.Text = (Convert.ToInt16(this.txtVersion.Text.Trim()) + 1).ToString();
                this.cbBOMType.SelectedIndex = 0; this.cbUnit.SelectedIndex = 0;
                this.txtQty.Text = string.Empty; this.cbMaterial.Enabled = false; this.cbPlant.Enabled = false;

                this.lblRemain.Text = string.Empty;
                NP_Cls.SqlSelect = "SELECT 0 as ItemNo,    m_Unit.UnitName, t_BOMDetail.Category, t_BOMDetail.MaterialCode, m_Material.MaterialName, t_BOMDetail.Quantity, t_BOM.BOMCode,  t_BOMDetail.BOMDetailCode, t_BOM.Approve, t_BOM.BOMVersion " +
                "FROM         t_BOM INNER JOIN " +
                          "m_Unit ON t_BOM.UnitCode = m_Unit.UnitCode INNER JOIN " +
                          "t_BOMDetail ON t_BOM.BOMCode = t_BOMDetail.BOMCode INNER JOIN " +
                          "m_Material ON t_BOMDetail.MaterialCode = m_Material.MaterialCode " +
    "WHERE     (t_BOM.FileStatus = N'1') AND (t_BOM.PlantCode = N'') AND (t_BOM.MaterialCode = N'')";
                this.dgvView.DataSource = NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0]; this.btnVerAppr.Visible = false; this.btnVerNot.Visible = false;
                
 
                //oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                //if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                //oConn.Open(); SqlTransaction Tr; Tr = oConn.BeginTransaction();
                //try
                //{
                //    SqlCommand cmdEdit = new SqlCommand(); string[] strCode = this.lblCode.Text.Trim().Split(':');
                //    NP_Cls.sqlUpdate = "UPDATE   t_BOM SET FileStatus = @St WHERE (BOMCode = @BOMCode)";
                //    cmdEdit.Parameters.Add("@BOMCode", SqlDbType.Int).Value = NP_Cls.strBOMCode;
                //    cmdEdit.Parameters.Add("@St", SqlDbType.Bit).Value = "D";

                //    cmdEdit.Connection = oConn; cmdEdit.CommandText = NP_Cls.sqlUpdate; cmdEdit.Transaction = Tr;
                //    cmdEdit.ExecuteNonQuery();

                //    if (NP._TRanSave(oConn, Tr, NP_Cls.NPTranType.Update, "t_BOM:NewVersion", NP_Cls.strUsr))
                //    {
                //        Tr.Commit();
                //        this.cbComponent.SelectedIndex = 0; this.txtQtyComp.Text = string.Empty;
                //        DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Clear Version Completed !!");
                //        this.btnAdd.Visible = true; this.btnEdit.Visible = false; this.cbComponent.Enabled = false; this.txtQtyComp.Enabled = false;
                //    }
                //    else
                //    {
                //        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Try Again !!"); return;
                //    }
                //}
                //catch (Exception ex)
                //{
                //    if (oConn.State == ConnectionState.Open) { Tr.Rollback(); }
                //    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Approve : " + ex.Message); return;
                //}
                //finally
                //{
                //    if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                //}
            }
            else
            {
                return;
            }
        }

        private void frmBOM_FormClosing(object sender, FormClosingEventArgs e)
        {
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;
        }
     
    }
}
