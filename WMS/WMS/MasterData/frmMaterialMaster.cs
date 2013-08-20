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
    public partial class frmMaterialMaster : Form
    {
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection();
        public frmMaterialMaster()
        {
            InitializeComponent();
        }
        private void frmMaterialMaster_Load(object sender, EventArgs e)
        {
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;

            DataSet dsMT = new DataSet(); dsMT.ReadXml(NP_Cls.PathMT); dsMT.Tables[0].Columns.Add("V", typeof(System.String));
            for (byte i = 0; i < dsMT.Tables[0].Rows.Count; i++)
            {
                dsMT.Tables[0].Rows[i][1] = dsMT.Tables[0].Rows[i][0].ToString();
            }
            DataView dv = new DataView(dsMT.Tables[0]);

            //if (NP_Cls.dsAuth.Tables[0].Rows[0]["DepartmentCode"].ToString().ToUpper() == NP_Cls.pRD)
            //{
            //    this.lblChem.Visible = true; this.txtChemicalName.Visible = true;
            //    dv.RowFilter  = "V IN ('RM', 'PK')";
              
            //}
            //else { this.lblChem.Visible = false; this.txtChemicalName.Visible = false; }

            //if (NP_Cls.dsAuth.Tables[0].Rows[0]["DepartmentCode"].ToString().ToUpper() == NP_Cls.pLT)
            //{
            //    this.lblChem.Visible = true; this.txtChemicalName.Visible = true;
            //    dv.RowFilter  = "V IN ('WIP')";              
            //}

            //if (NP_Cls.dsAuth.Tables[0].Rows[0]["DepartmentCode"].ToString().ToUpper() == NP_Cls.pCS)
            //{
            //    this.lblChem.Visible = true; this.txtChemicalName.Visible = true;
            //   dv.RowFilter  = "V IN ('FG', 'SET')";         
            //}

            //if ((NP_Cls.dsAuth.Tables[0].Rows[0]["DepartmentCode"].ToString().ToUpper() == NP_Cls.pAMT) && (NP_Cls.dsAuth.Tables[0].Rows[0]["AuthLevel"].ToString() == "5"))
            //{
            //    this.lblChem.Visible = true; this.txtChemicalName.Visible = true;
            //}

            this.lblChem.Visible = true; this.txtChemicalName.Visible = true;

            NP_Cls.SqlSelect = "SELECT MaterialGroupCode, MaterialGroupCode+ ':' + MaterialGroupName AS MaterialGroupName FROM m_MaterialGroup WHERE (FileStatus = '1')";
            NP.BindCB(this.cbMaterialGroup, NP_Cls.SqlSelect, "MaterialGroupCode", "MaterialGroupName", "((( Select Material Group )))");

            NP_Cls.SqlSelect = "SELECT UnitCode, UnitName FROM m_Unit WHERE (FileStatus = '1')";
            NP.BindCB(this.cbUnit, NP_Cls.SqlSelect, "UnitCode", "UnitName", "((( Select Unit )))");

            //
            NP_Cls.SqlSelect = "SELECT     PlantCode, PlantName FROM m_Plant WHERE     (FileStatus = N'1')";
            NP.BindCB(this.cbPlant, NP_Cls.SqlSelect, "PlantCode", "PlantName", "((( Select Plant )))");

            NP_Cls.SqlSelect = "SELECT     LocCode, LocName FROM   m_Location WHERE     (FileStatus = N'1')";
            NP.BindCB(this.cbLoc, NP_Cls.SqlSelect, "LocCode", "LocName", "((( Select Location )))");
            //

            dsMT.Tables.Clear();
            dsMT.Tables.Add(dv.ToTable());
            DataRow dr = dsMT.Tables[0].NewRow();
            dr[1] = 0; dr[0] = "((( Select Material Type )))";
            dsMT.Tables[0].Rows.InsertAt(dr, 0);
            dsMT.AcceptChanges();
            this.cbMT.DataSource = dsMT.Tables[0];
            this.cbMT.DisplayMember = "MTName"; this.cbMT.ValueMember = "V";

            Clear(); DGV(); this.btnEdit.Visible = false; this.txtCode.Select();
        }
        private void DGV()
        {
            NP_Cls.SqlSelect = "SELECT     MaterialCode, MaterialName FROM    m_Material WHERE (FileStatus = N'1') ";
            if (!string.IsNullOrEmpty(this.txtSCode.Text.Trim()))
            {
                NP_Cls.SqlSelect += " AND (MaterialCode LIKE '%" + this.txtSCode.Text.Trim() + "%') ";
            }
            if (!string.IsNullOrEmpty(this.txtSName.Text.Trim()))
            {
                NP_Cls.SqlSelect += " AND (MaterialName LIKE '%" + this.txtSName.Text.Trim() + "%') ";
            }
            this.dgvView.DataSource = NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0];
        }
        private void Clear()
        {
            this.txtCode.Text = string.Empty; this.txtName.Text = string.Empty; this.txtChemicalName.Text = string.Empty; this.txtCustProduct.Text = string.Empty; this.txtProcureType.Text = string.Empty; this.txtGR.Text = string.Empty; this.cbMaterialGroup.SelectedIndex = 0; this.cbUnit.SelectedIndex = 0; this.txtDelivery.Text = string.Empty; this.txtInHouse.Text = string.Empty; this.txtShelfLife.Text = string.Empty; this.txtMovAvg.Text = string.Empty; this.cbMT.SelectedIndex = 0; this.cbLoc.SelectedIndex = 0; this.cbPlant.SelectedIndex = 0; this.txtStandardCost.Text = string.Empty;
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
            if (NP.ReqField(this.txtCode, "Please enter Code: !!") == false) { return; }
            if (NP.ReqField(this.txtName, "Please enter Name: !!") == false) { return; }

            if (NP.ReqField(this.cbUnit, "Please choose Unit: !!") == false) { return; }
            if (NP.ReqField(this.cbPlant, "Please choose Plant: !!") == false) { return; }
            if (NP.ReqField(this.cbLoc, "Please choose Location: !!") == false) { return; }
            if (this.cbMT.SelectedIndex == -1) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please choose Material Type: !!"); this.cbMT.Select(); return; }
            if (this.txtProcureType.SelectedIndex == -1) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please choose Procurement Type: !!"); this.txtProcureType.Select(); return; }


            try
            {
                byte bRe = 0;
                if (ChkDup(ref bRe))
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Code Duplicated !!"); this.txtCode.Select(); this.txtCode.SelectAll(); return;
                }
                else
                {
                    if (bRe == 1)
                    {
                        Clear(); DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Update Data Completed !!"); this.txtCode.Focus(); return;
                    }
                }
            }
            catch (Exception ex)
            {
                NP.MSGB("Erro Dup : " + ex.Message); return;
            }
          

            if (NP.MSGB("Do you want to Add Data ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(Application.StartupPath + @"\DB\DB.ini"));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open();
                try
                {
                    SqlCommand cmdIns = new SqlCommand();
                    NP_Cls.SqlInsert = "INSERT INTO m_Material "+
                      "(MaterialCode, MaterialName, ChemicalName, MaterialTypeName, MaterialGroupCode, UnitCode, PlantCode, LocCode, CustomerProduct, ProcurementType, GRProcessingTime, "+
                    "DeliveryTime, InHouseProduction, ShelfLife, MovAvgPrice, StandardCost, UserCreate, DateCreate, FileStatus) " +
"VALUES     (@MaterialCode,@MaterialName,@ChemicalName,@MaterialTypeName,@MaterialGroupCode,@UnitCode,@PlantCode,@LocCode,@CustomerProduct,@ProcurementType," +
                    "@GRProcessingTime,@DeliveryTime,@InHouseProduction,@ShelfLife,@MovAvgPrice,@StandardCost,@UC, GETDATE(),@St)";
                    cmdIns.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15).Value = this.txtCode.Text.Trim();
                    cmdIns.Parameters.Add("@MaterialName", SqlDbType.NVarChar, 60).Value = this.txtName.Text.Trim();
                    cmdIns.Parameters.Add("@ChemicalName", SqlDbType.NVarChar, 60).Value = this.txtChemicalName.Text.Trim();
                    cmdIns.Parameters.Add("@MaterialTypeName", SqlDbType.NVarChar, 20).Value = this.cbMT.Text.Trim();
                    cmdIns.Parameters.Add("@MaterialGroupCode", SqlDbType.NVarChar, 3).Value = this.cbMaterialGroup.SelectedValue;
                    cmdIns.Parameters.Add("@UnitCode", SqlDbType.NVarChar, 3).Value = this.cbUnit.SelectedValue;
                    cmdIns.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 4).Value = this.cbPlant.SelectedValue;
                    cmdIns.Parameters.Add("@LocCode", SqlDbType.NVarChar, 2).Value = this.cbLoc.SelectedValue;
                    cmdIns.Parameters.Add("@CustomerProduct", SqlDbType.NVarChar, 15).Value = this.txtCustProduct.Text.Trim();
                    cmdIns.Parameters.Add("@ProcurementType", SqlDbType.NVarChar, 1).Value = this.txtProcureType.Text.Trim();
                    cmdIns.Parameters.Add("@GRProcessingTime", SqlDbType.Decimal).Value = Convert.ToDecimal(string.IsNullOrEmpty(this.txtGR.Text.Trim()) ? "0" : this.txtGR.Text.Trim());
                    cmdIns.Parameters.Add("@DeliveryTime", SqlDbType.Decimal).Value = Convert.ToDecimal(string.IsNullOrEmpty(this.txtDelivery.Text.Trim()) ? "0" : this.txtDelivery.Text.Trim());
                    cmdIns.Parameters.Add("@InHouseProduction", SqlDbType.Decimal).Value = Convert.ToDecimal(string.IsNullOrEmpty(this.txtInHouse.Text.Trim()) ? "0" : this.txtInHouse.Text.Trim());
                    cmdIns.Parameters.Add("@ShelfLife", SqlDbType.Decimal).Value = Convert.ToDecimal(string.IsNullOrEmpty(this.txtShelfLife.Text.Trim()) ? "0" : this.txtShelfLife.Text.Trim());
                    cmdIns.Parameters.Add("@MovAvgPrice", SqlDbType.Decimal).Value = Convert.ToDecimal(string.IsNullOrEmpty(this.txtMovAvg.Text.Trim()) ? "0" : this.txtMovAvg.Text.Trim());
                    cmdIns.Parameters.Add("@StandardCost", SqlDbType.Decimal).Value = Convert.ToDecimal(string.IsNullOrEmpty(this.txtStandardCost.Text.Trim()) ? "0" : this.txtStandardCost.Text.Trim());
                    cmdIns.Parameters.Add("@UC", SqlDbType.NVarChar, 10).Value = NP_Cls.strUsr;
                    cmdIns.Parameters.Add("@St", SqlDbType.NVarChar, 1).Value = "1";
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert;
                    cmdIns.ExecuteNonQuery();

                    Clear(); DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Add Data Completed !!"); this.txtCode.Focus();
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
        private bool ChkDup(ref byte bRe)
        {
            try
            {
                bRe = 0;
                NP_Cls.SqlSelect = "SELECT MaterialCode FROM m_Material WHERE (MaterialCode = '" + this.txtCode.Text.Trim().Replace("'", string.Empty) + "') AND (FileStatus = '1')";
                if (NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {  
                    //TODO New 03/02/2012 Reverse filestatus = 0
                    NP_Cls.SqlSelect = "SELECT MaterialCode FROM m_Material WHERE (MaterialCode = '" + this.txtCode.Text.Trim().Replace("'", string.Empty) + "') AND (FileStatus = '0')";
                    if (NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0].Rows.Count > 0)
                    {
                        if (NP.MSGB("This Code. is unused, Do you want to re-used this Code. ? ") == DialogResult.Yes)
                        {
                            NP_Cls.sqlUpdate = "UPDATE m_Material SET filestatus = '1' WHERE (MaterialCode = '" + this.txtCode.Text.Trim().Replace("'", string.Empty) + "')"; string strErr = string.Empty;
                            if (NP.SqlCmd(NP_Cls.sqlUpdate, ref strErr))
                            {
                                bRe = 1;
                                return false;
                            }
                            else
                            {
                                throw new Exception(strErr);
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
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
                string strSelect = this.dgvView[0, this.dgvView.CurrentRow.Index].Value.ToString();
                NP_Cls.SqlSelect = "SELECT     AutoID, MaterialCode, MaterialName, ChemicalName, MaterialTypeName, MaterialGroupCode, UnitCode, PlantCode, LocCode, CustomerProduct, ProcurementType, GRProcessingTime, DeliveryTime,  InHouseProduction, ShelfLife, MovAvgPrice, StandardCost, UserCreate, DateCreate, UserChange, DateChange, FileStatus  FROM m_Material WHERE (MaterialCode ='" + strSelect + "')";
                DataSet dsEdit = new DataSet(); dsEdit = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (dsEdit.Tables[0].Rows.Count > 0)
                {
                    this.txtCode.Text = dsEdit.Tables[0].Rows[0]["MaterialCode"].ToString();
                    this.txtName.Text = dsEdit.Tables[0].Rows[0]["MaterialName"].ToString();
                    this.txtChemicalName.Text = dsEdit.Tables[0].Rows[0]["ChemicalName"].ToString();
                    this.cbMT.SelectedValue = dsEdit.Tables[0].Rows[0]["MaterialTypeName"].ToString();
                    this.cbMaterialGroup.SelectedValue = dsEdit.Tables[0].Rows[0]["MaterialGroupCode"].ToString();
                    this.cbUnit.SelectedValue = dsEdit.Tables[0].Rows[0]["UnitCode"].ToString();
                    this.cbPlant.SelectedValue = dsEdit.Tables[0].Rows[0]["PlantCode"].ToString();
                    this.cbLoc.SelectedValue = dsEdit.Tables[0].Rows[0]["LocCode"].ToString();
                    this.txtCustProduct.Text = dsEdit.Tables[0].Rows[0]["CustomerProduct"].ToString();
                    this.txtProcureType.Text = dsEdit.Tables[0].Rows[0]["ProcurementType"].ToString();
                    this.txtGR.Text = dsEdit.Tables[0].Rows[0]["GRProcessingTime"].ToString();
                    this.txtDelivery.Text = dsEdit.Tables[0].Rows[0]["DeliveryTime"].ToString();
                    this.txtInHouse.Text = dsEdit.Tables[0].Rows[0]["InHouseProduction"].ToString();
                    this.txtShelfLife.Text = dsEdit.Tables[0].Rows[0]["ShelfLife"].ToString();
                    this.txtMovAvg.Text = dsEdit.Tables[0].Rows[0]["MovAvgPrice"].ToString();
                    this.txtStandardCost.Text = dsEdit.Tables[0].Rows[0]["StandardCost"].ToString();
                    this.txtCode.Enabled = false; this.btnAdd.Visible = false; this.btnEdit.Visible = true;
                    this.txtName.Select(); this.txtName.SelectAll();
                    this.cbUnit.Enabled = false;
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
            if (NP.ReqField(this.txtCode, "Please enter Code: !!") == false) { return; }
            if (NP.ReqField(this.txtName, "Please enter Name: !!") == false) { return; }

            if (NP.ReqField(this.cbUnit, "Please choose Unit: !!") == false) { return; }
            if (NP.ReqField(this.cbPlant, "Please choose Plant: !!") == false) { return; }
            if (NP.ReqField(this.cbLoc, "Please choose Location: !!") == false) { return; }
            if (this.cbMT.SelectedIndex == -1) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please choose Material Type: !!"); this.cbMT.Select(); return; }
            if (this.txtProcureType.SelectedIndex == -1) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please choose Procurement Type: !!"); this.txtProcureType.Select(); return; }

            if (NP.MSGB("Do you want to Edit Data ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(Application.StartupPath + @"\DB\DB.ini"));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open();
                try
                {
                    SqlCommand cmdEdit = new SqlCommand();
                    NP_Cls.sqlUpdate = "UPDATE    m_Material "+
"SET              MaterialName = @MaterialName, ChemicalName = @ChemicalName, MaterialTypeName = @MaterialTypeName, MaterialGroupCode = @MaterialGroupCode, " +
                    "UnitCode = @UnitCode, PlantCode = @PlantCode, LocCode = @LocCode, CustomerProduct = @CustomerProduct, ProcurementType = @ProcurementType, GRProcessingTime = @GRProcessingTime, DeliveryTime = @DeliveryTime, InHouseProduction = @InHouseProduction, ShelfLife = @ShelfLife, MovAvgPrice = @MovAvgPrice, StandardCost = @StandardCost, UserChange = @UC, DateChange = GETDATE() "+
"WHERE     (MaterialCode = @MaterialCode)";
                   
                    cmdEdit.Connection = oConn; cmdEdit.CommandText = NP_Cls.sqlUpdate;
                  
                    cmdEdit.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15).Value = this.txtCode.Text.Trim();
                    cmdEdit.Parameters.Add("@MaterialName", SqlDbType.NVarChar, 60).Value = this.txtName.Text.Trim();
                    cmdEdit.Parameters.Add("@ChemicalName", SqlDbType.NVarChar, 60).Value = this.txtChemicalName.Text.Trim();
                    cmdEdit.Parameters.Add("@MaterialTypeName", SqlDbType.NVarChar, 20).Value = this.cbMT.Text.Trim();
                    cmdEdit.Parameters.Add("@MaterialGroupCode", SqlDbType.NVarChar, 3).Value = this.cbMaterialGroup.SelectedValue;
                    cmdEdit.Parameters.Add("@UnitCode", SqlDbType.NVarChar, 3).Value = this.cbUnit.SelectedValue;
                    cmdEdit.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 4).Value = this.cbPlant.SelectedValue;
                    cmdEdit.Parameters.Add("@LocCode", SqlDbType.NVarChar, 2).Value = this.cbLoc.SelectedValue;
                    cmdEdit.Parameters.Add("@CustomerProduct", SqlDbType.NVarChar, 15).Value = this.txtCustProduct.Text.Trim();
                    cmdEdit.Parameters.Add("@ProcurementType", SqlDbType.NVarChar, 1).Value = this.txtProcureType.Text.Trim();
                    cmdEdit.Parameters.Add("@GRProcessingTime", SqlDbType.Decimal).Value = Convert.ToDecimal(string.IsNullOrEmpty(this.txtGR.Text.Trim()) ? "0" : this.txtGR.Text.Trim());
                    cmdEdit.Parameters.Add("@DeliveryTime", SqlDbType.Decimal).Value = Convert.ToDecimal(string.IsNullOrEmpty(this.txtDelivery.Text.Trim()) ? "0" : this.txtDelivery.Text.Trim());
                    cmdEdit.Parameters.Add("@InHouseProduction", SqlDbType.Decimal).Value = Convert.ToDecimal(string.IsNullOrEmpty(this.txtInHouse.Text.Trim()) ? "0" : this.txtInHouse.Text.Trim());
                    cmdEdit.Parameters.Add("@ShelfLife", SqlDbType.Decimal).Value = Convert.ToDecimal(string.IsNullOrEmpty(this.txtShelfLife.Text.Trim()) ? "0" : this.txtShelfLife.Text.Trim());
                    cmdEdit.Parameters.Add("@MovAvgPrice", SqlDbType.Decimal).Value = Convert.ToDecimal(string.IsNullOrEmpty(this.txtMovAvg.Text.Trim()) ? "0" : this.txtMovAvg.Text.Trim());
                    cmdEdit.Parameters.Add("@StandardCost", SqlDbType.Decimal).Value = Convert.ToDecimal(string.IsNullOrEmpty(this.txtStandardCost.Text.Trim()) ? "0" : this.txtStandardCost.Text.Trim());
                    cmdEdit.Parameters.Add("@UC", SqlDbType.NVarChar, 10).Value = NP_Cls.strUsr;
                    cmdEdit.ExecuteNonQuery();
                    Clear(); DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Edit Data Completed !!");
                    this.btnAdd.Visible = true; this.btnEdit.Visible = false; this.txtCode.Enabled = true; this.txtCode.Focus();
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
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NP.MSGB("Do you want to delete ?") == DialogResult.Yes)
            {
                if (this.dgvView.RowCount == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found !!"); return; }
                NP_Cls.SqlDel = "UPDATE m_Material SET FileStatus = '0' WHERE (MaterialCode = '" + this.dgvView[0, this.dgvView.CurrentRow.Index].Value.ToString() + "')";
                string strErr = string.Empty;
                NP.SqlCmd(NP_Cls.SqlDel, ref strErr); Clear(); DGV(); this.btnAdd.Visible = true; this.btnEdit.Visible = false;
                this.txtCode.Enabled = true; NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Delete Completed !!");
            }
            else
            {
                return;
            }
        }

        private void frmMaterialMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;
        }
        private void txtGR_KeyPress(object sender, KeyPressEventArgs e)
        {
            NP_Cls.myInteger(sender, e);
        }
        private void txtDelivery_KeyPress(object sender, KeyPressEventArgs e)
        {
            NP_Cls.myInteger(sender, e);
        }
        private void txtInHouse_KeyPress(object sender, KeyPressEventArgs e)
        {
            NP_Cls.myInteger(sender, e);
        }
        private void txtShelfLife_KeyPress(object sender, KeyPressEventArgs e)
        {
            NP_Cls.myInteger(sender, e);
        }
        private void txtMovAvg_KeyPress(object sender, KeyPressEventArgs e)
        {
            NP_Cls.myDecimal(sender, e);
        }

        private void btnSetMaterialType_Click(object sender, EventArgs e)
        {
            WMS.MasterData.frmMaterialTypeMaster frm = new frmMaterialTypeMaster();
            frm.ShowDialog();
            DataSet dsMT = new DataSet(); dsMT.ReadXml(NP_Cls.PathMT); dsMT.Tables[0].Columns.Add("V", typeof(System.String));
            for (byte i = 0; i < dsMT.Tables[0].Rows.Count; i++)
            {
                dsMT.Tables[0].Rows[i][1] = dsMT.Tables[0].Rows[i][0].ToString();
            }
            DataRow dr = dsMT.Tables[0].NewRow();
            dr[1] = 0; dr[0] = "((( Select Material Type )))";
            dsMT.Tables[0].Rows.InsertAt(dr, 0);
            dsMT.AcceptChanges();
            this.cbMT.DataSource = dsMT.Tables[0];
            this.cbMT.DisplayMember = "MTName"; this.cbMT.ValueMember = "V";

        }


    }
}
