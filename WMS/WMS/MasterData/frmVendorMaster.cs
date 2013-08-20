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
    public partial class frmVendorMaster : Form
    {
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection();
        public frmVendorMaster()
        {
            InitializeComponent();
        }
        private void frmVendorMaster_Load(object sender, EventArgs e)
        {
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;

            DataSet dsPG = new DataSet(); dsPG.ReadXml(NP_Cls.PathPG); DataRow dr = dsPG.Tables[0].NewRow();
            dr[0] = 0; dr[1] = "((( Select Purchasing group )))";
            for (byte i = 0; i < dsPG.Tables[0].Rows.Count; i++)
            {
                dsPG.Tables[0].Rows[i][1] = dsPG.Tables[0].Rows[i][0].ToString() + " - " + dsPG.Tables[0].Rows[i][1].ToString();
            }
            dsPG.Tables[0].Rows.InsertAt(dr, 0);
            dsPG.AcceptChanges();
            this.cbPG.DataSource = dsPG.Tables[0];
            this.cbPG.DisplayMember = "PGDesc"; this.cbPG.ValueMember = "PGCode";

            NP_Cls.SqlSelect = "SELECT CurrencyCode, CurrencyName FROM m_Currency WHERE (FileStatus = '1')";
            NP.BindCB(this.cbCurrencyCode, NP_Cls.SqlSelect, "CurrencyCode", "CurrencyName", "((( Select Currency )))");

            Clear(); DGV(); this.btnEdit.Visible = false; this.txtCode.Select();
        }
        private void DGV()
        {
            NP_Cls.SqlSelect = "SELECT VendorCode, VendorName, VendorTelephone FROM m_Vendor WHERE (FileStatus = N'1') ";
            if (!string.IsNullOrEmpty(this.txtSCode.Text.Trim()))
            {
                NP_Cls.SqlSelect += " AND (VendorCode LIKE '%" + this.txtSCode.Text.Trim() + "%') ";
            }
            if (!string.IsNullOrEmpty(this.txtSName.Text.Trim()))
            {
                NP_Cls.SqlSelect += " AND (VendorName LIKE '%" + this.txtSName.Text.Trim() + "%') ";
            }
            this.dgvView.DataSource = NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0];
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
            if (NP.ReqField(this.cbPG, "Please enter Purchasing group: !!") == false) { return; }
            if (NP.ReqField(this.cbCurrencyCode, "Please enter Currency: !!") == false) { return; }
            if (NP.ReqField(this.txtTerm, "Please enter Term of patment: !!") == false) { return; }
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
                    NP_Cls.SqlInsert = "INSERT INTO m_Vendor (Remark,VendorCode, VendorName, PurchasingGroup,VendorAddress, VendorPostalCode, VendorTelephone, VendorFax, CurrencyCode, TermsOfPayment, UserCreate, DateCreate, FileStatus, VendorContactPerson, VendorMobile, VendorEmail) VALUES (@Remark,@Code,@Name,@PG,@Address,@PostalCode,@Tel,@Fax,@OrderCurr,@Terms,@UC,getdate(),@St,@ContactP,@Mobile,@Email)";
                    cmdIns.Parameters.Add("@Code", SqlDbType.NVarChar, 10).Value = this.txtCode.Text.Trim();
                    cmdIns.Parameters.Add("@Name", SqlDbType.NVarChar, 60).Value = this.txtName.Text.Trim();
                    cmdIns.Parameters.Add("@PG", SqlDbType.NVarChar, 3).Value = this.cbPG.SelectedValue;
                    cmdIns.Parameters.Add("@Address", SqlDbType.NVarChar, 120).Value = this.txtAddress.Text.Trim();
                    cmdIns.Parameters.Add("@PostalCode", SqlDbType.NVarChar, 20).Value = this.txtPostal.Text.Trim();
                    cmdIns.Parameters.Add("@Tel", SqlDbType.NVarChar, 30).Value = this.txtTele.Text.Trim();
                    cmdIns.Parameters.Add("@Fax", SqlDbType.NVarChar, 20).Value = this.txtFax.Text.Trim();
                    cmdIns.Parameters.Add("@OrderCurr", SqlDbType.NVarChar, 3).Value = this.cbCurrencyCode.SelectedValue;
                    cmdIns.Parameters.Add("@Terms", SqlDbType.NVarChar, 20).Value = this.txtTerm.Text.Trim();
                    cmdIns.Parameters.Add("@UC", SqlDbType.NVarChar, 10).Value = NP_Cls.strUsr;
                    cmdIns.Parameters.Add("@St", SqlDbType.NVarChar, 1).Value = "1";
                    cmdIns.Parameters.Add("@ContactP", SqlDbType.NVarChar, 50).Value = this.txtContactNo.Text.Trim();
                    cmdIns.Parameters.Add("@Mobile", SqlDbType.NVarChar, 60).Value = this.txtMobileNo.Text.Trim();
                    cmdIns.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = this.txtEmail.Text.Trim();
                    cmdIns.Parameters.Add("@Remark", SqlDbType.NVarChar, 200).Value = this.txtRemark.Text.Trim();
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert;
                    cmdIns.ExecuteNonQuery();

                    Clear(); DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Add Data Completed !!"); this.txtCode.Focus();
                }
                catch (Exception ex)
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Add : " + ex.Message);
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

        private void Clear()
        {
            this.txtCode.Text = string.Empty; this.txtName.Text = string.Empty; this.txtAddress.Text = string.Empty; this.txtPostal.Text = string.Empty;
            this.txtTele.Text = string.Empty; this.txtFax.Text = string.Empty; this.cbCurrencyCode.SelectedIndex = 0; this.txtTerm.Text = string.Empty;
            this.txtContactNo.Text = string.Empty; this.txtMobileNo.Text = string.Empty; this.txtEmail.Text = string.Empty; this.cbPG.SelectedIndex = 0;
            this.txtRemark.Text = string.Empty;
        }
        private bool ChkDup(ref byte bRe)
        {
            try
            {
                NP_Cls.SqlSelect = "SELECT VendorCode FROM m_Vendor WHERE (VendorCode = '" + this.txtCode.Text.Trim().Replace("'", string.Empty) + "') AND (FileStatus = '1')";
                if (NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    //TODO New 03/02/2012 Reverse filestatus = 0
                    NP_Cls.SqlSelect = "SELECT VendorCode FROM m_Vendor WHERE (VendorCode = '" + this.txtCode.Text.Trim().Replace("'", string.Empty) + "') AND (FileStatus = '0')";
                    if (NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0].Rows.Count > 0)
                    {
                        if (NP.MSGB("This Code. is unused, Do you want to re-used this Code. ? ") == DialogResult.Yes)
                        {
                            NP_Cls.sqlUpdate = "UPDATE m_Vendor SET filestatus = '1' WHERE (VendorCode = '" + this.txtCode.Text.Trim().Replace("'", string.Empty) + "')"; string strErr = string.Empty;
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
                NP_Cls.SqlSelect = "SELECT * FROM m_Vendor WHERE (VendorCode ='" + strSelect + "')";
                DataSet dsEdit = new DataSet(); dsEdit = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (dsEdit.Tables[0].Rows.Count > 0)
                {
                    this.txtCode.Text = dsEdit.Tables[0].Rows[0]["VendorCode"].ToString();
                    this.txtName.Text = dsEdit.Tables[0].Rows[0]["VendorName"].ToString();
                    this.cbPG.SelectedValue = dsEdit.Tables[0].Rows[0]["PurchasingGroup"].ToString();
                    this.txtAddress.Text = dsEdit.Tables[0].Rows[0]["VendorAddress"].ToString();
                    this.txtPostal.Text = dsEdit.Tables[0].Rows[0]["VendorPostalCode"].ToString();
                    this.txtTele.Text = dsEdit.Tables[0].Rows[0]["VendorTelephone"].ToString();
                    this.txtFax.Text = dsEdit.Tables[0].Rows[0]["VendorFax"].ToString();
                    this.txtContactNo.Text = dsEdit.Tables[0].Rows[0]["VendorContactPerson"].ToString();
                    this.txtMobileNo.Text = dsEdit.Tables[0].Rows[0]["VendorMobile"].ToString();
                    this.txtEmail.Text = dsEdit.Tables[0].Rows[0]["VendorEmail"].ToString();
                    this.txtRemark.Text = dsEdit.Tables[0].Rows[0]["Remark"].ToString();
                    this.cbCurrencyCode.SelectedValue = dsEdit.Tables[0].Rows[0]["CurrencyCode"].ToString();
                    this.txtTerm.Text = dsEdit.Tables[0].Rows[0]["TermsOfPayment"].ToString();
                    this.txtCode.Enabled = false; this.btnAdd.Visible = false; this.btnEdit.Visible = true;
                    this.txtName.Select(); this.txtName.SelectAll();
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
            if (NP.ReqField(this.cbPG, "Please enter Purchasing group: !!") == false) { return; }
            if (NP.ReqField(this.cbCurrencyCode, "Please enter Currency: !!") == false) { return; }
            if (NP.ReqField(this.txtTerm, "Please enter Term of patment: !!") == false) { return; }

            if (NP.MSGB("Do you want to Edit Data ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(Application.StartupPath + @"\DB\DB.ini"));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open();
                try
                {
                    SqlCommand cmdEdit = new SqlCommand();
                    NP_Cls.sqlUpdate = "UPDATE    m_Vendor "+
"SET              VendorName = @Name, VendorAddress = @Address, PurchasingGroup = @PG, VendorPostalCode = @PostalCode, VendorTelephone = @Tel, VendorFax = @Fax, CurrencyCode = @OrderCurr, TermsOfPayment = @Terms, UserChange = @UC, DateChange = GETDATE(), VendorContactPerson = @ContactP, VendorMobile = @Mobile, VendorEmail = @Email, Remark = @Remark WHERE     (VendorCode = @Code)";
                    cmdEdit.Parameters.Add("@Code", SqlDbType.NVarChar, 10).Value = this.txtCode.Text.Trim();
                    cmdEdit.Parameters.Add("@Name", SqlDbType.NVarChar, 60).Value = this.txtName.Text.Trim();
                    cmdEdit.Parameters.Add("@PG", SqlDbType.NVarChar, 3).Value = this.cbPG.SelectedValue;
                    cmdEdit.Parameters.Add("@Address", SqlDbType.NVarChar, 120).Value = this.txtAddress.Text.Trim();
                    cmdEdit.Parameters.Add("@PostalCode", SqlDbType.NVarChar, 20).Value = this.txtPostal.Text.Trim();
                    cmdEdit.Parameters.Add("@Tel", SqlDbType.NVarChar, 30).Value = this.txtTele.Text.Trim();
                    cmdEdit.Parameters.Add("@Fax", SqlDbType.NVarChar, 20).Value = this.txtFax.Text.Trim();
                    cmdEdit.Parameters.Add("@OrderCurr", SqlDbType.NVarChar, 3).Value = this.cbCurrencyCode.SelectedValue;
                    cmdEdit.Parameters.Add("@Terms", SqlDbType.NVarChar, 20).Value = this.txtTerm.Text.Trim();
                    cmdEdit.Parameters.Add("@UC", SqlDbType.NVarChar, 10).Value = NP_Cls.strUsr;
                    cmdEdit.Parameters.Add("@St", SqlDbType.NVarChar, 1).Value = "1";
                    cmdEdit.Parameters.Add("@ContactP", SqlDbType.NVarChar, 50).Value = this.txtContactNo.Text.Trim();
                    cmdEdit.Parameters.Add("@Mobile", SqlDbType.NVarChar, 60).Value = this.txtMobileNo.Text.Trim();
                    cmdEdit.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = this.txtEmail.Text.Trim();
                    cmdEdit.Parameters.Add("@Remark", SqlDbType.NVarChar, 200).Value = this.txtRemark.Text.Trim();
                    cmdEdit.Connection = oConn; cmdEdit.CommandText = NP_Cls.sqlUpdate;
                    cmdEdit.ExecuteNonQuery();

                    Clear(); DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Edit Data Completed !!"); 
                    this.btnAdd.Visible = true; this.btnEdit.Visible = false; this.txtCode.Enabled = true; this.txtCode.Focus();
                }
                catch (Exception ex)
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Edit : " + ex.Message);
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
                NP_Cls.SqlDel = "UPDATE m_Vendor SET FileStatus = '0', UserChange = '" + NP_Cls.strUsr + "', DateChange = GETDATE()  WHERE (VendorCode = '" + this.dgvView[0, this.dgvView.CurrentRow.Index].Value.ToString() + "')";
                string strErr = string.Empty;
                NP.SqlCmd(NP_Cls.SqlDel, ref strErr); Clear(); DGV(); this.btnAdd.Visible = true; this.btnEdit.Visible = false;
                this.txtCode.Enabled = true; NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Delete Completed !!");
            }
            else
            {
                return;
            }
        }
        private void frmVendorMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;
        }
        private void txtTerm_KeyPress(object sender, KeyPressEventArgs e)
        {
            NP_Cls.myInteger(sender, e);
        }
        private void btnPG_Click(object sender, EventArgs e)
        {
            WMS.VendorTrans.frmPGMaster frm = new WMS.VendorTrans.frmPGMaster();
            frm.ShowDialog();
            DataSet dsPG = new DataSet(); dsPG.ReadXml(NP_Cls.PathPG); DataRow dr = dsPG.Tables[0].NewRow();
            for (byte i = 0; i < dsPG.Tables[0].Rows.Count; i++)
            {
                dsPG.Tables[0].Rows[i][1] = dsPG.Tables[0].Rows[i][0].ToString() + " - " + dsPG.Tables[0].Rows[i][1].ToString();
            }
            dr[0] = 0; dr[1] = "((( Select Purchasing group )))";
            dsPG.Tables[0].Rows.InsertAt(dr, 0);
            dsPG.AcceptChanges();
            this.cbPG.DataSource = dsPG.Tables[0];
            this.cbPG.DisplayMember = "PGDesc"; this.cbPG.ValueMember = "PGCode";
        }
    }
}
