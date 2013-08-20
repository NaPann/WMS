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
    public partial class frmCustomerMaster : Form
    {
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection();
        public frmCustomerMaster()
        {
            InitializeComponent();
        }
        private void frmCustomerMaster_Load(object sender, EventArgs e)
        {
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;

            NP_Cls.SqlSelect = "SELECT CurrencyCode, CurrencyName FROM m_Currency WHERE (FileStatus = '1')";
            NP.BindCB(this.cbCurrencyCode, NP_Cls.SqlSelect, "CurrencyCode", "CurrencyName", "((( Select Currency )))");

            Clear(); DGV(); this.btnEdit.Visible = false; this.txtCode.Select();
        }
        private void DGV()
        {
            NP_Cls.SqlSelect = "SELECT CustomerCode, CustomerName, CustomerTelephone FROM m_Customer WHERE (FileStatus = N'1') ";
            if (!string.IsNullOrEmpty(this.txtSCode.Text.Trim()))
            {
                NP_Cls.SqlSelect += " AND (CustomerCode LIKE '%" + this.txtSCode.Text.Trim() + "%') ";
            }
            if (!string.IsNullOrEmpty(this.txtSName.Text.Trim()))
            {
                NP_Cls.SqlSelect += " AND (CustomerName LIKE '%" + this.txtSName.Text.Trim() + "%') ";
            }
            this.dgvView.DataSource = NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0];
        }
        private void Clear()
        {
            this.txtCode.Text = string.Empty; this.txtName.Text = string.Empty; this.txtAddress.Text = string.Empty; this.txtPostal.Text = string.Empty;
            this.txtTele.Text = string.Empty; this.txtFax.Text = string.Empty; this.cbCurrencyCode.SelectedIndex = 0; this.txtTerm.Text = string.Empty;
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
            if (NP.ReqField(this.txtTerm, "Please enter Term of Payment : !!") == false) { return; }

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
                    NP_Cls.SqlInsert = "INSERT INTO m_Customer (CustomerCode, CustomerName, CustomerAddress, CustomerPostalCode, CustomerTelephone, CustomerFax, CurrencyCode, TermsOfPayment, UserCreate, DateCreate, FileStatus) VALUES (@Code,@Name,@Address,@PostalCode,@Tel,@Fax,@OrderCurr,@Terms,@UC,getdate(),@St)";
                    cmdIns.Parameters.Add("@Code", SqlDbType.NVarChar, 10).Value = this.txtCode.Text.Trim();
                    cmdIns.Parameters.Add("@Name", SqlDbType.NVarChar, 60).Value = this.txtName.Text.Trim();
                    cmdIns.Parameters.Add("@Address", SqlDbType.NVarChar, 120).Value = this.txtAddress.Text.Trim();
                    cmdIns.Parameters.Add("@PostalCode", SqlDbType.NVarChar, 20).Value = this.txtPostal.Text.Trim();
                    cmdIns.Parameters.Add("@Tel", SqlDbType.NVarChar, 30).Value = this.txtTele.Text.Trim();
                    cmdIns.Parameters.Add("@Fax", SqlDbType.NVarChar, 20).Value = this.txtFax.Text.Trim();
                    cmdIns.Parameters.Add("@OrderCurr", SqlDbType.NVarChar, 3).Value = this.cbCurrencyCode.SelectedValue;
                    cmdIns.Parameters.Add("@Terms", SqlDbType.NVarChar, 20).Value = this.txtTerm.Text.Trim();
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
                NP_Cls.SqlSelect = "SELECT CustomerCode FROM m_Customer WHERE (CustomerCode = '" + this.txtCode.Text.Trim().Replace("'", string.Empty) + "') AND (FileStatus = '1')";
                if (NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    //TODO New 03/02/2012 Reverse filestatus = 0
                    NP_Cls.SqlSelect = "SELECT CustomerCode FROM m_Customer WHERE (CustomerCode = '" + this.txtCode.Text.Trim().Replace("'", string.Empty) + "') AND (FileStatus = '0')";
                    if (NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0].Rows.Count > 0)
                    {
                        if (NP.MSGB("This Code. is unused, Do you want to re-used this Code. ? ") == DialogResult.Yes)
                        {
                            NP_Cls.sqlUpdate = "UPDATE m_Customer SET filestatus = '1' WHERE (CustomerCode = '" + this.txtCode.Text.Trim().Replace("'", string.Empty) + "')"; string strErr = string.Empty;
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
                NP_Cls.SqlSelect = "SELECT * FROM m_Customer WHERE (CustomerCode ='" + strSelect + "')";
                DataSet dsEdit = new DataSet(); dsEdit = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (dsEdit.Tables[0].Rows.Count > 0)
                {
                    this.txtCode.Text = dsEdit.Tables[0].Rows[0]["CustomerCode"].ToString();
                    this.txtName.Text = dsEdit.Tables[0].Rows[0]["CustomerName"].ToString();
                    this.txtAddress.Text = dsEdit.Tables[0].Rows[0]["CustomerAddress"].ToString();
                    this.txtPostal.Text = dsEdit.Tables[0].Rows[0]["CustomerPostalCode"].ToString();
                    this.txtTele.Text = dsEdit.Tables[0].Rows[0]["CustomerTelephone"].ToString();
                    this.txtFax.Text = dsEdit.Tables[0].Rows[0]["CustomerFax"].ToString();
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
            if (NP.ReqField(this.txtTerm, "Please enter Term of Payment : !!") == false) { return; }

            //if (ChkDup())
            //{
            //    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Code Duplicated !!"); this.txtCode.Select(); this.txtCode.SelectAll(); return;
            //}

            if (NP.MSGB("Do you want to Edit Data ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(Application.StartupPath + @"\DB\DB.ini"));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open();
                try
                {
                    SqlCommand cmdEdit = new SqlCommand();
                    NP_Cls.sqlUpdate = "UPDATE    m_Customer " +
"SET              CustomerName = @Name, CustomerAddress = @Address, CustomerPostalCode = @PostalCode, CustomerTelephone = @Tel, CustomerFax = @Fax, CurrencyCode = @OrderCurr, TermsOfPayment = @Terms, UserChange = @UC, DateChange = GETDATE() WHERE     (CustomerCode = @Code)";
                    cmdEdit.Parameters.Add("@Code", SqlDbType.NVarChar, 10).Value = this.txtCode.Text.Trim();
                    cmdEdit.Parameters.Add("@Name", SqlDbType.NVarChar, 60).Value = this.txtName.Text.Trim();
                    cmdEdit.Parameters.Add("@Address", SqlDbType.NVarChar, 120).Value = this.txtAddress.Text.Trim();
                    cmdEdit.Parameters.Add("@PostalCode", SqlDbType.NVarChar, 20).Value = this.txtPostal.Text.Trim();
                    cmdEdit.Parameters.Add("@Tel", SqlDbType.NVarChar, 30).Value = this.txtTele.Text.Trim();
                    cmdEdit.Parameters.Add("@Fax", SqlDbType.NVarChar, 20).Value = this.txtFax.Text.Trim();
                    cmdEdit.Parameters.Add("@OrderCurr", SqlDbType.NVarChar, 3).Value = this.cbCurrencyCode.SelectedValue;
                    cmdEdit.Parameters.Add("@Terms", SqlDbType.NVarChar, 20).Value = this.txtTerm.Text.Trim();
                    cmdEdit.Parameters.Add("@UC", SqlDbType.NVarChar, 10).Value = NP_Cls.strUsr;
                    cmdEdit.Parameters.Add("@St", SqlDbType.NVarChar, 1).Value = "1";
                    cmdEdit.Connection = oConn; cmdEdit.CommandText = NP_Cls.sqlUpdate;
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
            if (this.dgvView.RowCount == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found !!"); return; }
            if (NP.MSGB("Do you want to delete ?") == DialogResult.Yes)
            {
                NP_Cls.SqlDel = "UPDATE m_Customer SET FileStatus = '0',UserChange = '" + NP_Cls.strUsr + "', DateChange = GETDATE()  WHERE (CustomerCode = '" + this.dgvView[0, this.dgvView.CurrentRow.Index].Value.ToString() + "')";
                string strErr = string.Empty;
                NP.SqlCmd(NP_Cls.SqlDel, ref strErr); Clear(); DGV(); this.btnAdd.Visible = true; this.btnEdit.Visible = false;
                this.txtCode.Enabled = true; NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Delete Completed !!");
            }
            else
            {
                return;
            }
        }
        private void frmCustomerMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;
        }
    }
}
