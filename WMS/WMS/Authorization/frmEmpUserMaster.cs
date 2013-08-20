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
    public partial class frmEmpUserMaster : Form
    {
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection();
        public frmEmpUserMaster()
        {
            InitializeComponent();
        }
        private void frmEmpUserMaster_Load(object sender, EventArgs e)
        {
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;

            if ((NP_Cls.dsAuth.Tables[0].Rows[0]["DepartmentCode"].ToString().ToUpper() == NP_Cls.pAMT) && ((NP_Cls.dsAuth.Tables[0].Rows[0]["AuthLevel"].ToString() == "5")))
            {
                NP_Cls.SqlSelect = "SELECT DepartmentCode, DepartmentCode + '-' + DepartmentName AS DepartmentName FROM m_Department WHERE (FileStatus = '1')";
            }
            else
            {
                NP_Cls.SqlSelect = "SELECT DepartmentCode, DepartmentCode + '-' + DepartmentName AS DepartmentName FROM m_Department WHERE (FileStatus = '1') AND (DepartmentCode = '" + NP_Cls.dsAuth.Tables[0].Rows[0]["DepartmentCode"].ToString() + "')";
                this.cbLevel.Items.RemoveAt(2); this.cbLevel.Items.RemoveAt(2); this.cbLevel.Items.RemoveAt(2); this.cbLevel.Items.RemoveAt(2);
            }
            NP.BindCB(this.cbDepartment, NP_Cls.SqlSelect, "DepartmentCode", "DepartmentName", "((( Select Department )))");

            Clear(); DGV(); this.btnEdit.Visible = false; this.txtEmpCode.Select();
        }

        private void DGV()
        {
            NP_Cls.SqlSelect = "SELECT     s_User.EmployeeCode, s_User.EmployeeFirstName, m_Department.DepartmentName, s_User.AuthLevel "+
"FROM         s_User INNER JOIN m_Department ON s_User.DepartmentCode = m_Department.DepartmentCode "+
"WHERE     (s_User.FileStatus = N'1') ";
            if (!string.IsNullOrEmpty(this.txtSCode.Text.Trim()))
            {
                NP_Cls.SqlSelect += " AND (s_User.EmployeeCode LIKE '%" + this.txtSCode.Text.Trim() + "%') ";
            }
            if (!string.IsNullOrEmpty(this.txtSName.Text.Trim()))
            {
                NP_Cls.SqlSelect += " AND (s_User.EmployeeFirstName LIKE '%" + this.txtSName.Text.Trim() + "%') ";
            }
            NP_Cls.SqlSelect += " Order By s_User.DepartmentCode";
            this.dgvView.DataSource = NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0];
        }
        private void Clear()
        {
            this.txtEmpCode.Text = string.Empty; this.txtFirstName.Text = string.Empty; this.txtLastName.Text = string.Empty;
            this.cbDepartment.SelectedIndex = 0; this.cbLevel.SelectedIndex = 0;
            this.txtUserName.Text = string.Empty; this.txtPass.Text = string.Empty; this.txtConf.Text = string.Empty;
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
                if (NP.ReqField(this.txtEmpCode, "Please enter EmployeeCode: !!") == false) { return; }
                if (NP.ReqField(this.txtFirstName, "Please enter FirstName: !!") == false) { return; }
                if (NP.ReqField(this.txtLastName, "Please enter LastName: !!") == false) { return; }
                if (NP.ReqField(this.cbDepartment, "Please enter Department: !!") == false) { return; }
                if (NP.ReqField(this.cbLevel, "Please enter Level: !!") == false) { return; }
                if (NP.ReqField(this.txtUserName, "Please enter UserName: !!") == false) { return; }
                if (NP.ReqField(this.txtPass, "Please enter Password: !!") == false) { return; }
                if (NP.ReqField(this.txtConf, "Please enter Confirm: !!") == false) { return; }
                if (this.txtPass.Text.Trim() != this.txtConf.Text.Trim()) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Miss match password !!"); return; }

                if (ChkDup())
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Employee Code Or UserName Duplicated !!"); this.txtEmpCode.Select(); this.txtEmpCode.SelectAll(); return;
                }

                if (NP.MSGB("Do you want to Add User Data ?") == DialogResult.Yes)
                {
                    oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                    if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                    oConn.Open();
                    try
                    {
                        SqlCommand cmdIns = new SqlCommand();
                        NP_Cls.SqlInsert = "INSERT INTO s_User "+
                      "(EmployeeCode, EmployeeFirstName, EmployeeLastName, DepartmentCode, AuthLevel, UserName, Password, UserCreate, DateCreate, FileStatus) "+
"VALUES     (@EmployeeCode,@EmployeeFirstName,@EmployeeLastName,@DepartmentCode,@AuthLevel,@UserName,@Password,@UC, GETDATE(),@St)";
                        cmdIns.Parameters.Add("@EmployeeCode", SqlDbType.NVarChar, 10).Value = this.txtEmpCode.Text.Trim();
                        cmdIns.Parameters.Add("@EmployeeFirstName", SqlDbType.NVarChar, 20).Value = this.txtFirstName.Text.Trim();
                        cmdIns.Parameters.Add("@EmployeeLastName", SqlDbType.NVarChar, 20).Value = this.txtLastName.Text.Trim();
                        cmdIns.Parameters.Add("@DepartmentCode", SqlDbType.NVarChar, 3).Value = this.cbDepartment.SelectedValue;
                        cmdIns.Parameters.Add("@AuthLevel", SqlDbType.NVarChar, 1).Value = this.cbLevel.Text; ;
                        cmdIns.Parameters.Add("@UserName", SqlDbType.NVarChar, 10).Value = this.txtUserName.Text.Trim();
                        cmdIns.Parameters.Add("@Password", SqlDbType.NVarChar, 10).Value = this.txtPass.Text.Trim();
                        cmdIns.Parameters.Add("@UC", SqlDbType.NVarChar, 10).Value = NP_Cls.strUsr;
                        cmdIns.Parameters.Add("@St", SqlDbType.NVarChar, 1).Value = "1";
                        cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert;
                        cmdIns.ExecuteNonQuery();

                        Clear(); DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Add Data Completed !!"); this.txtEmpCode.Focus();
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
        private bool ChkDup()
        {
            try
            {
                NP_Cls.SqlSelect = "SELECT EmployeeCode FROM s_User WHERE (EmployeeCode = '" + this.txtEmpCode.Text.Trim().Replace("'", string.Empty) + "') AND (FileStatus = '1')";
                if (NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    NP_Cls.SqlSelect = "SELECT UserName FROM s_User WHERE (UserName = '" + this.txtUserName.Text.Trim().Replace("'", string.Empty) + "') AND (FileStatus = '1')";
                    if (NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0].Rows.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
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
                NP_Cls.SqlSelect = "SELECT * FROM s_User WHERE (EmployeeCode ='" + strSelect + "')";
                DataSet dsEdit = new DataSet(); dsEdit = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (dsEdit.Tables[0].Rows.Count > 0)
                {
                    this.txtEmpCode.Text = dsEdit.Tables[0].Rows[0]["EmployeeCode"].ToString();
                    this.txtFirstName.Text = dsEdit.Tables[0].Rows[0]["EmployeeFirstName"].ToString();
                    this.txtLastName.Text = dsEdit.Tables[0].Rows[0]["EmployeeLastName"].ToString();
                    this.cbDepartment.SelectedValue = dsEdit.Tables[0].Rows[0]["DepartmentCode"].ToString();
                    this.cbLevel.Text = dsEdit.Tables[0].Rows[0]["AuthLevel"].ToString();
                    this.txtUserName.Text = dsEdit.Tables[0].Rows[0]["UserName"].ToString();
                    this.lblPass.Text = dsEdit.Tables[0].Rows[0]["Password"].ToString();
                    this.btnChangePass.Visible = true;

                    this.txtEmpCode.Enabled = false; this.txtUserName.Enabled = false; this.btnAdd.Visible = false; this.btnEdit.Visible = true;
                    this.txtConf.Enabled = false; this.txtPass.Enabled = false;
                    this.txtFirstName.Select(); this.txtUserName.SelectAll();
                }
                else
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found !!"); return;
                }
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Edit : " + ex.Message); return;
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (NP.ReqField(this.txtEmpCode, "Please enter EmployeeCode: !!") == false) { return; }
            if (NP.ReqField(this.txtFirstName, "Please enter FirstName: !!") == false) { return; }
            if (NP.ReqField(this.txtLastName, "Please enter LastName: !!") == false) { return; }
            if (NP.ReqField(this.cbDepartment, "Please enter Department: !!") == false) { return; }
            if (NP.ReqField(this.cbLevel, "Please enter Level: !!") == false) { return; }
            if (NP.ReqField(this.txtUserName, "Please enter UserName: !!") == false) { return; }
            if (this.txtPass.Enabled)
            {
                if (NP.ReqField(this.txtPass, "Please enter Password: !!") == false) { return; }
                if (NP.ReqField(this.txtConf, "Please enter Confirm: !!") == false) { return; }
            }
            if (!string.IsNullOrEmpty(this.txtPass.Text.Trim()))
            {
                if (NP.ReqField(this.txtConf, "Please enter Confirm: !!") == false) { return; }
                if (this.txtPass.Text.Trim() != this.txtConf.Text.Trim()) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Miss match password !!"); return; }
            }
         
            if (NP.MSGB("Do you want to Edit User Data ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open();
                try
                {
                    SqlCommand cmdEdit = new SqlCommand();
                    NP_Cls.sqlUpdate = "UPDATE    s_User "+
"SET              EmployeeFirstName = @EmployeeFirstName, EmployeeLastName = @EmployeeLastName, DepartmentCode = @DepartmentCode, AuthLevel = @AuthLevel, "+
                      "Password = @Password, UserChange = @UC, DateChange = GETDATE() "+
"WHERE     (EmployeeCode = @EmployeeCode)";
                    cmdEdit.Parameters.Add("@EmployeeCode", SqlDbType.NVarChar, 10).Value = this.txtEmpCode.Text.Trim();
                    cmdEdit.Parameters.Add("@EmployeeFirstName", SqlDbType.NVarChar, 20).Value = this.txtFirstName.Text.Trim();
                    cmdEdit.Parameters.Add("@EmployeeLastName", SqlDbType.NVarChar, 20).Value = this.txtLastName.Text.Trim();
                    cmdEdit.Parameters.Add("@DepartmentCode", SqlDbType.NVarChar, 3).Value = this.cbDepartment.SelectedValue;
                    cmdEdit.Parameters.Add("@AuthLevel", SqlDbType.NVarChar, 1).Value = this.cbLevel.Text; ;
                    cmdEdit.Parameters.Add("@UserName", SqlDbType.NVarChar, 10).Value = this.txtUserName.Text.Trim();
                    cmdEdit.Parameters.Add("@Password", SqlDbType.NVarChar, 10).Value = (this.txtPass.Enabled == true ? this.txtPass.Text.Trim() : this.lblPass.Text.Trim());
                    cmdEdit.Parameters.Add("@UC", SqlDbType.NVarChar, 10).Value = NP_Cls.strUsr;
                    cmdEdit.Parameters.Add("@St", SqlDbType.NVarChar, 1).Value = "1";
                    cmdEdit.Connection = oConn; cmdEdit.CommandText = NP_Cls.sqlUpdate;
                    cmdEdit.ExecuteNonQuery();

                    Clear(); DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Edit User Data Completed !!"); this.txtConf.Enabled = true; this.txtPass.Enabled = true;
                    this.btnChangePass.Visible = false;
                    this.btnAdd.Visible = true; this.btnEdit.Visible = false; this.txtEmpCode.Enabled = true; this.txtUserName.Enabled = true; this.txtEmpCode.Focus();
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
            if (this.dgvView.RowCount == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found !!"); return; }
            if (NP.MSGB("Do you want to delete user ?") == DialogResult.Yes)
            {
                NP_Cls.SqlDel = "UPDATE s_User SET FileStatus = 'D', UserChange = '" + NP_Cls.strUsr + "', DateChange = GETDATE() WHERE (EmployeeCode = '" + this.dgvView["clnEmployeeCode", this.dgvView.CurrentRow.Index].Value.ToString() + "')";
                string strErr = string.Empty;
                NP.SqlCmd(NP_Cls.SqlDel, ref strErr); Clear(); DGV(); this.btnAdd.Visible = true; this.btnEdit.Visible = false; this.txtConf.Enabled = true; this.txtPass.Enabled = true;
                this.txtEmpCode.Enabled = true; this.txtUserName.Enabled = true; NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Delete user Completed !!");
            }
            else
            {
                return;
            }
        }
        private void frmEmpUserMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;
        }
        private void btnChangePass_Click(object sender, EventArgs e)
        {
            this.txtPass.Enabled = (!this.txtPass.Enabled);
            this.txtConf.Enabled = (!this.txtConf.Enabled);
            this.txtConf.Text = string.Empty; this.txtPass.Text = string.Empty;
        }
    }
}
