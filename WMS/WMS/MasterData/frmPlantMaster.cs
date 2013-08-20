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
    public partial class frmPlantMaster : Form
    {
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection();
        public frmPlantMaster()
        {
            InitializeComponent();
        }
        private void frmPlant_Load(object sender, EventArgs e)
        {
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;

            Clear(); DGV(); this.btnEdit.Visible = false; this.txtCode.Select();
        }

        private void DGV()
        {
            NP_Cls.SqlSelect = "SELECT PlantCode, PlantName FROM m_Plant WHERE (FileStatus = N'1') ";
            if (!string.IsNullOrEmpty(this.txtSCode.Text.Trim()))
            {
                NP_Cls.SqlSelect += " AND (PlantCode LIKE '%" + this.txtSCode.Text.Trim() + "%') ";
            }
            if (!string.IsNullOrEmpty(this.txtSName.Text.Trim()))
            {
                NP_Cls.SqlSelect += " AND (PlantName LIKE '%" + this.txtSName.Text.Trim() + "%') ";
            }
            this.dgvView.DataSource = NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0];
        }
        private void Clear()
        {
            this.txtCode.Text = string.Empty; this.txtName.Text = string.Empty; this.txtRemark.Text = string.Empty; 
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
            if (NP.ReqField(this.txtName, "Please enter Plant: !!") == false) { return; }

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
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open();
                try
                {
                    SqlCommand cmdIns = new SqlCommand();
                    NP_Cls.SqlInsert = "INSERT INTO m_Plant (PlantCode, PlantName, Remark, UserCreate, DateCreate, FileStatus) VALUES (@Code,@Name,@Remark,@UC,getdate(),@St)";
                    cmdIns.Parameters.Add("@Code", SqlDbType.NVarChar, 10).Value = this.txtCode.Text.Trim();
                    cmdIns.Parameters.Add("@Name", SqlDbType.NVarChar, 60).Value = this.txtName.Text.Trim();
                    cmdIns.Parameters.Add("@Remark", SqlDbType.NVarChar, 255).Value = this.txtRemark.Text.Trim();
                    cmdIns.Parameters.Add("@UC", SqlDbType.NVarChar, 10).Value = NP_Cls.strUsr;
                    cmdIns.Parameters.Add("@St", SqlDbType.NVarChar, 1).Value = "1";
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert;
                    cmdIns.ExecuteNonQuery();

                    Clear(); DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Add Data Completed !!"); this.txtCode.Focus();
                }
                catch (Exception ex)
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Add :" + ex.Message);
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
                NP_Cls.SqlSelect = "SELECT PlantCode FROM m_Plant WHERE (PlantCode = '" + this.txtCode.Text.Trim().Replace("'", string.Empty) + "') AND (FileStatus = '1')";
                if (NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    //TODO New 03/02/2012 Reverse filestatus = 0
                    NP_Cls.SqlSelect = "SELECT PlantCode FROM m_Plant WHERE (PlantCode = '" + this.txtCode.Text.Trim().Replace("'", string.Empty) + "') AND (FileStatus = '0')";
                    if (NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0].Rows.Count > 0)
                    {
                        if (NP.MSGB("This Code. is unused, Do you want to re-used this Code. ? ") == DialogResult.Yes)
                        {
                            NP_Cls.sqlUpdate = "UPDATE m_Plant SET filestatus = '1' WHERE (PlantCode = '" + this.txtCode.Text.Trim().Replace("'", string.Empty) + "')"; string strErr = string.Empty;
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
                NP_Cls.SqlSelect = "SELECT * FROM m_Plant WHERE (PlantCode ='" + strSelect + "')";
                DataSet dsEdit = new DataSet(); dsEdit = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (dsEdit.Tables[0].Rows.Count > 0)
                {
                    this.txtCode.Text = dsEdit.Tables[0].Rows[0]["PlantCode"].ToString();
                    this.txtName.Text = dsEdit.Tables[0].Rows[0]["PlantName"].ToString();
                    this.txtRemark.Text = dsEdit.Tables[0].Rows[0]["Remark"].ToString();

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
            if (NP.ReqField(this.txtName, "Please enter Plant: !!") == false) { return; }

            if (NP.MSGB("Do you want to Edit Data ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open();
                try
                {
                    SqlCommand cmdEdit = new SqlCommand();
                    NP_Cls.sqlUpdate = "UPDATE    m_Plant" +
" SET              PlantName = @Name, Remark = @Remark WHERE (PlantCode = @Code)";
                    cmdEdit.Parameters.Add("@Code", SqlDbType.NVarChar, 10).Value = this.txtCode.Text.Trim();
                    cmdEdit.Parameters.Add("@Name", SqlDbType.NVarChar, 60).Value = this.txtName.Text.Trim();
                    cmdEdit.Parameters.Add("@Remark", SqlDbType.NVarChar, 255).Value = this.txtRemark.Text.Trim();
                    cmdEdit.Connection = oConn; cmdEdit.CommandText = NP_Cls.sqlUpdate;
                    cmdEdit.ExecuteNonQuery();

                    Clear(); DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Edit Data Completed !!");
                    this.btnAdd.Visible = true; this.btnEdit.Visible = false; this.txtCode.Enabled = true; this.txtCode.Focus();
                }
                catch (Exception ex)
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Edit :" + ex.Message);
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
                NP_Cls.SqlDel = "UPDATE m_Plant SET FileStatus = '0', UserChange = '" + NP_Cls.strUsr + "', DateChange = GETDATE() WHERE (PlantCode = '" + this.dgvView[0, this.dgvView.CurrentRow.Index].Value.ToString() + "')";
                string strErr = string.Empty;
                NP.SqlCmd(NP_Cls.SqlDel, ref strErr); Clear(); DGV(); this.btnAdd.Visible = true; this.btnEdit.Visible = false;
                this.txtCode.Enabled = true; NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Delete Completed !!");
            }
            else
            {
                return;
            }
        }
        private void frmPlant_FormClosing(object sender, FormClosingEventArgs e)
        {
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;
        }

    }
}
