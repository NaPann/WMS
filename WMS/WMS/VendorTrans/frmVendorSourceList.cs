using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WMS.VendorTrans
{
    public partial class frmVendorSourceList : Form
    {
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection();
        public frmVendorSourceList()
        {
            InitializeComponent();
        }
        private void frmVendorSourceList_Load(object sender, EventArgs e)
        {
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;

            //NP_Cls.SqlSelect = "SELECT t_VendorInfoRecord.MaterialCode, m_Material.MaterialName FROM t_VendorInfoRecord INNER JOIN m_Material ON t_VendorInfoRecord.MaterialCode = m_Material.MaterialCode"; 
            //NP.BindCB(this.cbMaterial, NP_Cls.SqlSelect, "MaterialCode", "MaterialName", "((( Select Material )))");

            Clear(); DGV(string.Empty); this.txtMaterialCode.Select(); this.lblWarn.Visible = false;
        }
        private void DGV(string strSerach)
        {
            NP_Cls.SqlSelect = "SELECT     t_VendorInfoRecord.VendorCode, m_Vendor.VendorName, t_VendorSourceList.Fix, t_VendorInfoRecord.Block, m_Vendor.PurchasingGroup, "+
                      "m_Material.MaterialName FROM         t_VendorInfoRecord INNER JOIN "+
                      "m_Material ON t_VendorInfoRecord.MaterialCode = m_Material.MaterialCode INNER JOIN "+
                      "m_Vendor ON t_VendorInfoRecord.VendorCode = m_Vendor.VendorCode INNER JOIN "+
                      "t_VendorSourceList ON t_VendorInfoRecord.VendorCode = t_VendorSourceList.VendorCode AND  "+
                      "t_VendorInfoRecord.MaterialCode = t_VendorSourceList.MaterialCode "+
"WHERE     (1 = 1)";
            if (!string.IsNullOrEmpty(this.txtMaterialCode.Text.Trim()))
            {
                NP_Cls.SqlSelect += " AND (t_VendorInfoRecord.MaterialCode + m_Material.MaterialName LIKE '%" + this.txtMaterialCode.Text.Trim() + "%') ";
            }
            else
            {
                NP_Cls.SqlSelect += " AND (t_VendorInfoRecord.MaterialCode = '') ";
            }

            DataSet dsSerach = new DataSet(); dsSerach = NP.GetClientDataSet(NP_Cls.SqlSelect);
            if (dsSerach.Tables[0].Rows.Count == 0)
            { this.lblWarn.Visible = true; this.lblMaterial.Text = string.Empty; }
            else { this.lblWarn.Visible = false; this.lblMaterial.Text = "Material Name : " + dsSerach.Tables[0].Rows[0]["MaterialName"].ToString(); } 
            this.dgvView.DataSource = dsSerach.Tables[0]; this.dgvView.ClearSelection();

            SetBlockColor();
        }
        private void SetBlockColor()
        {
            if (this.dgvView.RowCount == 0) { return; }
            for (Int32 i = 0; i < this.dgvView.RowCount; i++)
            {
                if (!((bool)this.dgvView["clnBlockChk", i].Value))
                {
                    //this.dgvView["clnBShow", i].Style.BackColor = Color.Gray; 
                    this.dgvView["clnFix", i].ReadOnly = false;
                }
                else
                {
                    this.dgvView["clnFix", i].ReadOnly = true; ;
                }
            }
        }
        private void Clear()
        {
            this.txtMaterialCode.Text = string.Empty; this.lblWarn.Visible = false;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DGV(string.Empty);
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
        private void frmVendorSourceList_FormClosing(object sender, FormClosingEventArgs e)
        {
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;
        }

        private void txtMaterialCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSearch_Click(sender, e);
            }
        }
        private void btnSaveChange_Click(object sender, EventArgs e)
        {
            if (this.dgvView.RowCount == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found !!"); return; }
            this.dgvView.EndEdit();
            if (NP.MSGB("Do you want to Save Change Data ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); } SqlTransaction Tr;
                oConn.Open(); Tr = oConn.BeginTransaction(); this.dgvView.EndEdit();
                try
                {
                    SqlCommand cmdEdit = new SqlCommand();
                    NP_Cls.SqlInsert = "UPDATE    t_VendorSourceList " +
"SET              Fix = @Fix " +
"WHERE     (VendorCode = @VendorCode) AND (MaterialCode = @MaterialCode)";
                    cmdEdit.Parameters.Add("@VendorCode", SqlDbType.NVarChar, 10);
                    cmdEdit.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15);
                    cmdEdit.Parameters.Add("@Fix", SqlDbType.Bit);

                    for (Int32 i = 0; i < this.dgvView.RowCount; i++)
                    {
                        cmdEdit.Parameters["@VendorCode"].Value = this.dgvView["clnVendorCode", i].Value.ToString();
                        cmdEdit.Parameters["@MaterialCode"].Value = this.txtMaterialCode.Text.Trim();
                        cmdEdit.Parameters["@Fix"].Value = ((bool)this.dgvView["clnFix", i].Value);

                        cmdEdit.Connection = oConn; cmdEdit.CommandText = NP_Cls.SqlInsert; cmdEdit.Transaction = Tr;
                        cmdEdit.ExecuteNonQuery();
                    }
                    Tr.Commit();
                    DGV(string.Empty); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Save Change Completed !!"); this.txtMaterialCode.Select();
                }
                catch (Exception ex)
                {
                    if (oConn.State == ConnectionState.Open) { Tr.Rollback(); }
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Save : " + ex.Message); return;
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
