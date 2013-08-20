using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WMS.Authorization
{
    public partial class frmAuthLevel : Form
    {
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection();
        public frmAuthLevel()
        {
            InitializeComponent();
        }
        private void frmAuthLevel_Load(object sender, EventArgs e)
        {
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;

            NP_Cls.SqlSelect = "SELECT DepartmentCode, DepartmentCode + '-' + DepartmentName AS DepartmentName FROM m_Department WHERE (FileStatus = '1')";
            NP.BindCB(this.cbDepartment, NP_Cls.SqlSelect, "DepartmentCode", "DepartmentName", "((( Select Department )))");

            Clear(); DGV(); this.btnEdit.Visible = false; this.cbDepartment.Select();
        }
        private void DGV()
        {
            NP_Cls.SqlSelect = "SELECT  DepartmentCode, AuthLevel, Per FROM s_Level WHERE (FileStatus = N'1') ";
                NP_Cls.SqlSelect += " AND (DepartmentCode = '" + this.cbDepartment.SelectedValue + "') ";
                NP_Cls.SqlSelect += " AND (AuthLevel = '" + this.cbLevel.Text.Trim() + "') ";
            DataSet ds = new DataSet(); ds = NP.GetClientDataSet(NP_Cls.SqlSelect);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string[] strPer = ds.Tables[0].Rows[0]["Per"].ToString().Split(':');

                this.chkVendorMaster.Checked = Convert.ToBoolean(strPer[0].ToString()); this.chkCurrencyMaster.Checked = Convert.ToBoolean(strPer[1].ToString()); this.chkLocationMaster.Checked = Convert.ToBoolean(strPer[2].ToString()); this.chkUnit.Checked = Convert.ToBoolean(strPer[3].ToString()); this.chkDepartment.Checked = Convert.ToBoolean(strPer[4].ToString()); this.chkCustomerMaster.Checked = Convert.ToBoolean(strPer[5].ToString()); this.chkPlantMaster.Checked = Convert.ToBoolean(strPer[6].ToString()); this.chkMaterialMaster.Checked = Convert.ToBoolean(strPer[7].ToString()); this.chkMaterialGroupMaster.Checked = Convert.ToBoolean(strPer[8].ToString()); this.chkEmpUser.Checked = Convert.ToBoolean(strPer[9].ToString()); this.chkManageLevel.Checked = Convert.ToBoolean(strPer[10].ToString()); this.chkInfoRec.Checked = Convert.ToBoolean(strPer[11].ToString()); this.chkSourceList.Checked = Convert.ToBoolean(strPer[12].ToString()); this.chkWorkCenter.Checked = Convert.ToBoolean(strPer[13].ToString()); this.chkRouting.Checked = Convert.ToBoolean(strPer[14]);

                try
                {

                    this.chkProductionOrder.Checked = Convert.ToBoolean(strPer[15].ToString()); this.chkGoodsIssue.Checked = Convert.ToBoolean(strPer[16].ToString());
                    this.chkGRProduction.Checked = Convert.ToBoolean(strPer[17].ToString()); this.chkProductionCost.Checked = Convert.ToBoolean(strPer[18].ToString());
                    this.chkBOM.Checked = Convert.ToBoolean(strPer[19]);

                    this.chkPR.Checked = Convert.ToBoolean(strPer[20].ToString()); this.chkPO.Checked = Convert.ToBoolean(strPer[21].ToString());
                    this.chkGR.Checked = Convert.ToBoolean(strPer[22].ToString()); this.chkGRT.Checked = Convert.ToBoolean(strPer[23].ToString());
                    this.chkSO.Checked = Convert.ToBoolean(strPer[24].ToString()); this.chkDO.Checked = Convert.ToBoolean(strPer[25].ToString());
                    this.chkMRP.Checked = Convert.ToBoolean(strPer[26].ToString()); this.chkOverview.Checked = Convert.ToBoolean(strPer[27].ToString());
                    this.chkTransfer.Checked = Convert.ToBoolean(strPer[28].ToString()); this.chkMM.Checked = Convert.ToBoolean(strPer[29].ToString());


                    this.chkAppBOM.Checked = Convert.ToBoolean(strPer[30]); this.chkAppPR.Checked = Convert.ToBoolean(strPer[31]);
                    this.chkAppPO.Checked = Convert.ToBoolean(strPer[32]); this.chkAppSO.Checked = Convert.ToBoolean(strPer[33]); 
                    
                    
                }
                catch
                {
                    this.chkProductionOrder.Checked = false; this.chkGoodsIssue.Checked = false;
                    this.chkGRProduction.Checked = false; this.chkProductionCost.Checked = false;
                    this.chkBOM.Checked = false;

                    this.chkPR.Checked = false; this.chkPO.Checked = false;
                    this.chkGR.Checked = false; this.chkGRT.Checked = false;
                    this.chkSO.Checked = false; this.chkDO.Checked = false;
                    this.chkMRP.Checked = false; this.chkOverview.Checked = false;
                    this.chkTransfer.Checked = false; this.chkMM.Checked = false;

                    this.chkAppBOM.Checked = false; this.chkAppPR.Checked = false;
                    this.chkAppPO.Checked = false; this.chkAppSO.Checked = false;
                }
      
                this.btnAdd.Visible = false; this.btnEdit.Visible = true; this.btnDelete.Visible = true;
            }
            else
            {
                this.chkVendorMaster.Checked = false; this.chkCurrencyMaster.Checked = false; this.chkLocationMaster.Checked = false; this.chkUnit.Checked = false; this.chkDepartment.Checked = false; this.chkCustomerMaster.Checked = false; this.chkPlantMaster.Checked = false; this.chkMaterialMaster.Checked = false; this.chkMaterialGroupMaster.Checked = false; this.chkEmpUser.Checked = false; this.chkManageLevel.Checked = false; this.chkInfoRec.Checked = false; this.chkSourceList.Checked = false; this.chkWorkCenter.Checked = false; this.chkRouting.Checked = false;

                this.chkProductionOrder.Checked = false; this.chkGoodsIssue.Checked = false; this.chkGRProduction.Checked = false; this.chkProductionCost.Checked = false; this.chkPO.Checked = false; this.chkPR.Checked = false;
                this.chkGR.Checked = false; this.chkGRT.Checked = false; this.chkSO.Checked = false; this.chkDO.Checked = false; this.chkMRP.Checked = false; this.chkOverview.Checked = false; this.chkTransfer.Checked = false;
                this.chkMM.Checked = false;

                this.chkBOM.Checked = false; this.chkAppBOM.Checked = false; this.chkAppPR.Checked = false; this.chkAppPO.Checked = false; this.chkAppSO.Checked = false;

                this.btnAdd.Visible = true; this.btnEdit.Visible = false; this.btnDelete.Visible = false;
            }
            
        }
        private void Clear()
        {
            this.chkVendorMaster.Checked = false; this.chkCurrencyMaster.Checked = false; this.chkLocationMaster.Checked = false; this.chkUnit.Checked = false; this.chkDepartment.Checked = false; this.chkCustomerMaster.Checked = false; this.chkPlantMaster.Checked = false; this.chkMaterialMaster.Checked = false; this.chkMaterialGroupMaster.Checked = false; this.chkEmpUser.Checked = false; this.chkManageLevel.Checked = false; this.chkInfoRec.Checked = false; this.chkSourceList.Checked = false; this.chkWorkCenter.Checked = false; this.chkRouting.Checked = false;

            this.chkProductionOrder.Checked = false; this.chkGoodsIssue.Checked = false; this.chkGRProduction.Checked = false; this.chkProductionCost.Checked = false; this.chkPO.Checked = false; this.chkPR.Checked = false;
            this.chkGR.Checked = false; this.chkGRT.Checked = false; this.chkSO.Checked = false; this.chkDO.Checked = false; this.chkMRP.Checked = false; this.chkOverview.Checked = false; this.chkTransfer.Checked = false;
            this.chkMM.Checked = false;

            this.chkBOM.Checked = false; this.chkAppBOM.Checked = false; this.chkAppPR.Checked = false; this.chkAppPO.Checked = false; this.chkAppSO.Checked = false;
            
            this.cbDepartment.SelectedIndex = 0; this.cbLevel.SelectedIndex = 0; 
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
                if (NP.ReqField(this.cbDepartment, "Please enter Department: !!") == false) { return; }
                if (NP.ReqField(this.cbLevel, "Please enter Level: !!") == false) { return; }

                if (NP.MSGB("Do you want to Add Data ?") == DialogResult.Yes)
                {
                    oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                    if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                    oConn.Open();
                    try
                    {
                        SqlCommand cmdIns = new SqlCommand();
                        NP_Cls.SqlInsert = "INSERT INTO s_Level "+
                      "(DepartmentCode, AuthLevel, Per, UserCreate, DateCreate, FileStatus) "+
"VALUES     (@DepartmentCode,@AuthLevel,@Per,@UC, GETDATE(),@St)";
                        cmdIns.Parameters.Add("@DepartmentCode", SqlDbType.NVarChar, 3).Value = this.cbDepartment.SelectedValue;
                        cmdIns.Parameters.Add("@AuthLevel", SqlDbType.NVarChar, 1).Value = this.cbLevel.Text.Trim();
                        cmdIns.Parameters.Add("@Per", SqlDbType.NVarChar).Value = ((string)GenPer());
                        cmdIns.Parameters.Add("@UC", SqlDbType.NVarChar, 10).Value = NP_Cls.strUsr;
                        cmdIns.Parameters.Add("@St", SqlDbType.NVarChar, 1).Value = "1";
                        cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert;
                        cmdIns.ExecuteNonQuery();

                        Clear(); DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Add Data Completed !!"); this.cbDepartment.Select();
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

        private string GenPer()
        {
            try
            {
                return (this.chkVendorMaster.Checked == false ? "false:" : "true:") + (this.chkCurrencyMaster.Checked == false ? "false:" : "true:") + (this.chkLocationMaster.Checked == false ? "false:" : "true:") + (this.chkUnit.Checked == false ? "false:" : "true:") + (this.chkDepartment.Checked == false ? "false:" : "true:") + (this.chkCustomerMaster.Checked == false ? "false:" : "true:") + (this.chkPlantMaster.Checked == false ? "false:" : "true:") + (this.chkMaterialMaster.Checked == false ? "false:" : "true:") + (this.chkMaterialGroupMaster.Checked == false ? "false:" : "true:") + (this.chkEmpUser.Checked == false ? "false:" : "true:") + (this.chkManageLevel.Checked == false ? "false:" : "true:") + (this.chkInfoRec.Checked == false ? "false:" : "true:") + (this.chkSourceList.Checked == false ? "false:" : "true:") + (this.chkWorkCenter.Checked == false ? "false:" : "true:") + (this.chkRouting.Checked == false ? "false:" : "true:") + (this.chkProductionOrder.Checked == false ? "false:" : "true:") + (this.chkGoodsIssue.Checked == false ? "false:" : "true:") + (this.chkGRProduction.Checked == false ? "false:" : "true:") + (this.chkProductionCost.Checked == false ? "false:" : "true:") + (this.chkBOM.Checked == false ? "false:" : "true:") + (this.chkPR.Checked == false ? "false:" : "true:") + (this.chkPO.Checked == false ? "false:" : "true:") + (this.chkGR.Checked == false ? "false:" : "true:") + (this.chkGRT.Checked == false ? "false:" : "true:") + (this.chkSO.Checked == false ? "false:" : "true:") + (this.chkDO.Checked == false ? "false:" : "true:") + (this.chkMRP.Checked == false ? "false:" : "true:") + (this.chkOverview.Checked == false ? "false:" : "true:") + (this.chkTransfer.Checked == false ? "false:" : "true:") + (this.chkMM.Checked == false ? "false:" : "true:") + (this.chkAppBOM.Checked == false ? "false:" : "true:") + (this.chkAppPR.Checked == false ? "false:" : "true:") + (this.chkAppPO.Checked == false ? "false:" : "true:") + (this.chkAppSO.Checked == false ? "false" : "true"); 
                
   
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void cbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbDepartment.SelectedIndex == 0)
            {
                this.cbDepartment.Select();
            }
            else
            {
                if (this.cbLevel.SelectedIndex == 0)
                {
                    this.cbLevel.Select();
                }
                else
                {
                    DGV();
                }
            }
        }
        private void cbLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbLevel.SelectedIndex == 0)
            {
                this.cbLevel.Select();
            }
            else
            {
                if (this.cbDepartment.SelectedIndex == 0)
                {
                    this.cbDepartment.Select();
                }
                else
                {
                    DGV();
                }
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (NP.ReqField(this.cbDepartment, "Please enter Department: !!") == false) { return; }
                if (NP.ReqField(this.cbLevel, "Please enter Level: !!") == false) { return; }

                if (NP.MSGB("Do you want to Edit Data ?") == DialogResult.Yes)
                {
                    oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                    if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                    oConn.Open();
                    try
                    {
                        SqlCommand cmdEdit = new SqlCommand();
                        NP_Cls.sqlUpdate = "UPDATE s_Level " +
                      "SET Per = @Per, UserChange = @UC, DateChange = GETDATE() " +
"WHERE (DepartmentCode = @DepartmentCode) AND (AuthLevel = @AuthLevel)";
                        cmdEdit.Parameters.Add("@DepartmentCode", SqlDbType.NVarChar, 3).Value = this.cbDepartment.SelectedValue;
                        cmdEdit.Parameters.Add("@AuthLevel", SqlDbType.NVarChar, 1).Value = this.cbLevel.Text.Trim();
                        cmdEdit.Parameters.Add("@Per", SqlDbType.NVarChar).Value = ((string)GenPer());
                        cmdEdit.Parameters.Add("@UC", SqlDbType.NVarChar, 10).Value = NP_Cls.strUsr;
                        cmdEdit.Connection = oConn; cmdEdit.CommandText = NP_Cls.sqlUpdate;
                        cmdEdit.ExecuteNonQuery();

                        Clear(); DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Edit Data Completed !!"); this.cbDepartment.Select();
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
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Edit : " + ex.Message); return;
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (NP.ReqField(this.cbDepartment, "Please enter Department: !!") == false) { return; }
                if (NP.ReqField(this.cbLevel, "Please enter Level: !!") == false) { return; }

                if (NP.MSGB("Do you want to Delete Data ?") == DialogResult.Yes)
                {
                    oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                    if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                    oConn.Open(); SqlTransaction Tr; Tr = oConn.BeginTransaction();
                    try
                    {
                        SqlCommand cmdEdit = new SqlCommand();
                        NP_Cls.sqlUpdate = "DELETE FROM s_Level " +
"WHERE (DepartmentCode = @DepartmentCode) AND (AuthLevel = @AuthLevel)";
                        cmdEdit.Parameters.Add("@DepartmentCode", SqlDbType.NVarChar, 3).Value = this.cbDepartment.SelectedValue;
                        cmdEdit.Parameters.Add("@AuthLevel", SqlDbType.NVarChar, 1).Value = this.cbLevel.Text.Trim();

                        cmdEdit.Connection = oConn; cmdEdit.CommandText = NP_Cls.sqlUpdate; cmdEdit.Transaction = Tr;
                        cmdEdit.ExecuteNonQuery();

                        if (NP._TRanSave(oConn, Tr, NP_Cls.NPTranType.Delete, "s_Level", NP_Cls.strUsr))
                        {
                            Tr.Commit();
                            DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Delete Completed !!");
                        }
                        else
                        {
                            NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Try agian !!"); return;
                        }

                        Clear(); DGV(); this.cbDepartment.Select();
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
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Edit : " + ex.Message); return;
            }
        }
        private void frmAuthLevel_FormClosing(object sender, FormClosingEventArgs e)
        {
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;

            NP_Cls.SqlSelect = "SELECT     s_User.UserName, s_User.EmployeeFirstName, s_User.EmployeeLastName, s_User.DepartmentCode, s_User.AuthLevel, s_Level.Per, " +
                  "m_Department.DepartmentName FROM         s_User INNER JOIN " +
                  "s_Level ON s_User.DepartmentCode = s_Level.DepartmentCode AND s_User.AuthLevel = s_Level.AuthLevel INNER JOIN " +
                  "m_Department ON s_User.DepartmentCode = m_Department.DepartmentCode " +
"WHERE     (s_User.UserName = N'" + NP_Cls.dsAuth.Tables[0].Rows[0]["UserName"].ToString() + "')";
            NP_Cls.dsAuth = new DataSet(); NP_Cls.dsAuth = NP.GetClientDataSet(NP_Cls.SqlSelect);
            frm.ManageMenu();
        }
     
    }
}
