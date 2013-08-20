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
    public partial class frmVendorInfo : Form
    {
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection();
        public frmVendorInfo()
        {
            InitializeComponent();
        }

        private void frmVendorInfo_Load(object sender, EventArgs e)
        {
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;

            NP_Cls.SqlSelect = "SELECT VendorCode, VendorCode + ':' + VendorName AS VendorName FROM m_Vendor WHERE (FileStatus = '1')";
            NP.BindCB(this.cbVendor, NP_Cls.SqlSelect, "VendorCode", "VendorName", "((( Select Vendor )))");

            NP_Cls.SqlSelect = "SELECT MaterialCode, MaterialCode + ':' + MaterialName AS MaterialName FROM m_Material WHERE (FileStatus = '1')";
            NP.BindCB(this.cbMaterial, NP_Cls.SqlSelect, "MaterialCode", "MaterialName", "((( Select Material )))");

            NP_Cls.SqlSelect = "SELECT UnitCode, UnitName FROM m_Unit WHERE (FileStatus = '1')";
            NP.BindCB(this.cbOrderUnit, NP_Cls.SqlSelect, "UnitCode", "UnitName", "((( Select Unit )))");

            Clear(); DGV(); this.btnEdit.Visible = false; this.cbVendor.Text = string.Empty; this.cbMaterial.Text = string.Empty;
            this.cbVendor.Select();
        }
        private void DGV()
        {
            NP_Cls.SqlSelect = "SELECT     t_VendorInfoRecord.VendorCode, t_VendorInfoRecord.MaterialCode, t_VendorInfoRecord.DeliveryTime, "+
                      "t_VendorInfoRecord.Block, m_Vendor.VendorName, m_Material.MaterialName "+
"FROM         t_VendorInfoRecord INNER JOIN "+
                      "m_Vendor ON t_VendorInfoRecord.VendorCode = m_Vendor.VendorCode INNER JOIN "+
                      "m_Material ON t_VendorInfoRecord.MaterialCode = m_Material.MaterialCode WHERE (1=1) ";
            if (!string.IsNullOrEmpty(this.txtSCode.Text.Trim()))
            {
                NP_Cls.SqlSelect += " AND (m_Vendor.VendorCode LIKE '%" + this.txtSCode.Text.Trim() + "%') ";
            }
            if (!string.IsNullOrEmpty(this.txtSName.Text.Trim()))
            {
                NP_Cls.SqlSelect += " AND (m_Material.MaterialCode LIKE '%" + this.txtSName.Text.Trim() + "%') ";
            }
            //if (!string.IsNullOrEmpty(this.txtSPG.Text.Trim()))
            //{
            //    NP_Cls.SqlSelect += " AND (t_VendorInfoRecord.PurchasingGroup LIKE '%" + this.txtSPG.Text.Trim() + "%') ";
            //}
            this.dgvView.DataSource = NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0];
        }
        private void Clear()
        {
            this.cbVendor.SelectedIndex = 0; this.cbMaterial.SelectedIndex = 0; this.lblPG.Text = string.Empty;
            this.txtDelivery.Text = string.Empty; this.txtMinQty.Text = string.Empty; this.txtNetPrice.Text = string.Empty;
            this.txtQtyCon.Text = string.Empty; this.chkBlock.Checked = false; this.cbOrderUnit.SelectedIndex = 0;
            this.txtInfoUnit.Text = string.Empty;
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
            //if (NP.ReqField(this.cbVendor, "Please enter Vendor: !!") == false) { return; }
            //if (NP.ReqField(this.cbMaterial, "Please enter Material: !!") == false) { return; }
            if ((string.IsNullOrEmpty((this.cbVendor.Text.Trim()))) || (this.cbVendor.Text.Trim() == "((( Select Vendor )))")) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please enter Vendor: !!"); this.cbVendor.Select(); return; }
            if ((string.IsNullOrEmpty((this.cbMaterial.Text.Trim()))) || (this.cbMaterial.Text.Trim() == "((( Select Material )))")) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please enter Material: !!"); this.cbMaterial.Select(); return; }
            //if (NP.ReqField(this.cbPG, "Please enter Purchasing group: !!") == false) { return; }
            if (NP.ReqField(this.txtDelivery, "Please enter Delivery time: !!") == false) { return; }
            if (NP.ReqField(this.txtMinQty, "Please enter Minimum Qty.: !!") == false) { return; }
            if (NP.ReqField(this.txtNetPrice, "Please enter Net Price: !!") == false) { return; }
            if (NP.ReqField(this.cbOrderUnit, "Please enter Order Unit: !!") == false) { return; }
            if (NP.ReqField(this.txtQtyCon, "Please enter Qty.Conversion: !!") == false) { return; }

            if (ChkDup())
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Code Duplicated !!"); this.cbVendor.Select(); return;
            }

            if (NP.MSGB("Do you want to Add Data ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr;
                Tr = oConn.BeginTransaction();
                try
                {
                    SqlCommand cmdIns = new SqlCommand();
                    NP_Cls.SqlInsert = "INSERT INTO t_VendorInfoRecord "+
                      "(VendorCode, MaterialCode, DeliveryTime, MinimumQty, NetPrice, UnitCode, QtyConversion, Block) " +
"VALUES     (@VendorCode,@MaterialCode,@DeliveryTime,@MinimumQty,@NetPrice,@UnitCode,@QtyConversion,@Block)";
                    cmdIns.Parameters.Add("@VendorCode", SqlDbType.NVarChar, 10).Value = this.cbVendor.SelectedValue;
                    cmdIns.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15).Value = this.cbMaterial.SelectedValue;
                    //cmdIns.Parameters.Add("@PurchasingGroup", SqlDbType.NVarChar, 3).Value = this.cbPG.SelectedValue;
                    cmdIns.Parameters.Add("@DeliveryTime", SqlDbType.Int).Value = Convert.ToInt32(string.IsNullOrEmpty(this.txtDelivery.Text.Trim()) ? "0" : this.txtDelivery.Text.Trim());
                    cmdIns.Parameters.Add("@MinimumQty", SqlDbType.Decimal).Value = Convert.ToDecimal(string.IsNullOrEmpty(this.txtMinQty.Text.Trim()) ? "0" : this.txtMinQty.Text.Trim());
                    cmdIns.Parameters.Add("@NetPrice", SqlDbType.Decimal).Value = Convert.ToDecimal(string.IsNullOrEmpty(this.txtNetPrice.Text.Trim()) ? "0" : this.txtNetPrice.Text.Trim());
                    cmdIns.Parameters.Add("@UnitCode", SqlDbType.NVarChar, 3).Value = this.cbOrderUnit.SelectedValue;
                    cmdIns.Parameters.Add("@QtyConversion", SqlDbType.Int).Value = Convert.ToInt32(string.IsNullOrEmpty(this.txtQtyCon.Text.Trim()) ? "0" : this.txtQtyCon.Text.Trim());
                    cmdIns.Parameters.Add("@Block", SqlDbType.Bit).Value = this.chkBlock.Checked;
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                    cmdIns.ExecuteNonQuery();

                    NP_Cls.SqlInsert = "INSERT INTO t_VendorSourceList (VendorCode, MaterialCode, Fix) VALUES (@VendorCode,@MaterialCode,@Fix)";
                    cmdIns.Parameters.Add("@Fix", SqlDbType.Bit).Value = 0;
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                    cmdIns.ExecuteNonQuery();

                    Tr.Commit();
                    Clear(); DGV(); this.cbMaterial.Enabled = true; this.cbVendor.Enabled = true; this.btnAdd.Visible = true; this.btnEdit.Visible = false;
                    this.cbVendor.Text = string.Empty; this.cbMaterial.Text = string.Empty; this.cbVendor.Select();
                    NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Add Data Completed !!"); 
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
                NP_Cls.SqlSelect = "SELECT VendorCode FROM t_VendorInfoRecord WHERE (VendorCode = '" + this.cbVendor.SelectedValue + "') AND " +
                    "(MaterialCode = '"+ this.cbMaterial.SelectedValue +"')";
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

        private void txtDelivery_KeyPress(object sender, KeyPressEventArgs e)
        {
            NP_Cls.myInteger(sender, e);
        }
        private void txtMinQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            NP_Cls.myDecimal(sender, e);
        }
        private void txtNetPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            NP_Cls.myDecimal(sender, e);
        }
        private void txtQtyCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            NP_Cls.myInteger(sender, e);
        }

        private void txtSCode_TextChanged(object sender, EventArgs e)
        {
            DGV();
        }
        private void txtSName_TextChanged(object sender, EventArgs e)
        {
            DGV();
        }
        private void txtSPG_TextChanged(object sender, EventArgs e)
        {
            DGV();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string strSelect = this.dgvView[0, this.dgvView.CurrentRow.Index].Value.ToString(); string strSelect2 = this.dgvView[1, this.dgvView.CurrentRow.Index].Value.ToString();
                NP_Cls.SqlSelect = "SELECT  VendorCode, MaterialCode, DeliveryTime, MinimumQty, NetPrice, UnitCode, QtyConversion, Block "+
"FROM         t_VendorInfoRecord WHERE (VendorCode ='" + strSelect + "') AND (MaterialCode = '"+ strSelect2 +"')"; 
                DataSet dsEdit = new DataSet(); dsEdit = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (dsEdit.Tables[0].Rows.Count > 0)
                {
                    this.cbVendor.SelectedValue = dsEdit.Tables[0].Rows[0]["VendorCode"].ToString();
                    this.cbMaterial.SelectedValue = dsEdit.Tables[0].Rows[0]["MaterialCode"].ToString();
                    //this.cbPG.SelectedValue = dsEdit.Tables[0].Rows[0]["PurchasingGroup"].ToString();
                    this.txtDelivery.Text = dsEdit.Tables[0].Rows[0]["DeliveryTime"].ToString();
                    this.txtMinQty.Text = dsEdit.Tables[0].Rows[0]["MinimumQty"].ToString();
                    this.txtNetPrice.Text = dsEdit.Tables[0].Rows[0]["NetPrice"].ToString();
                    this.cbOrderUnit.SelectedValue = dsEdit.Tables[0].Rows[0]["UnitCode"].ToString();
                    this.txtQtyCon.Text = dsEdit.Tables[0].Rows[0]["QtyConversion"].ToString();
                    this.chkBlock.Checked = Convert.ToBoolean(dsEdit.Tables[0].Rows[0]["Block"]);
                    this.cbVendor.Enabled = false; this.cbMaterial.Enabled = false; this.btnAdd.Visible = false; this.btnEdit.Visible = true;
                    this.txtDelivery.Select(); this.txtDelivery.SelectAll();
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
            //if (NP.ReqField(this.cbVendor, "Please enter Vendor: !!") == false) { return; }
            //if (NP.ReqField(this.cbMaterial, "Please enter Material: !!") == false) { return; }
            if ((string.IsNullOrEmpty((this.cbVendor.Text.Trim()))) || (this.cbVendor.Text.Trim() == "((( Select Vendor )))")) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please enter Vendor: !!"); this.cbVendor.Select(); return; }
            if ((string.IsNullOrEmpty((this.cbMaterial.Text.Trim()))) || (this.cbMaterial.Text.Trim() == "((( Select Material )))")) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please enter Material: !!"); this.cbMaterial.Select(); return; }
            if (NP.ReqField(this.txtDelivery, "Please enter Delivery time: !!") == false) { return; }
            if (NP.ReqField(this.txtMinQty, "Please enter Minimum Qty.: !!") == false) { return; }
            if (NP.ReqField(this.txtNetPrice, "Please enter Net Price: !!") == false) { return; }
            if (NP.ReqField(this.cbOrderUnit, "Please enter Order Unit: !!") == false) { return; }
            if (NP.ReqField(this.txtQtyCon, "Please enter Qty.Conversion: !!") == false) { return; }

            if (NP.MSGB("Do you want to Edit Data ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open();
                try
                {
                    SqlCommand cmdEdit = new SqlCommand();
                    NP_Cls.SqlInsert = "UPDATE    t_VendorInfoRecord " +
"SET        DeliveryTime = @DeliveryTime, MinimumQty = @MinimumQty, NetPrice = @NetPrice, QtyConversion = @QtyConversion, " +
                      "Block = @Block WHERE     (VendorCode = @VendorCode) AND (MaterialCode = @MaterialCode)";
                    cmdEdit.Parameters.Add("@VendorCode", SqlDbType.NVarChar, 10).Value = this.cbVendor.SelectedValue;
                    cmdEdit.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15).Value = this.cbMaterial.SelectedValue;
                    //cmdEdit.Parameters.Add("@PurchasingGroup", SqlDbType.NVarChar, 3).Value = this.cbPG.SelectedValue;
                    cmdEdit.Parameters.Add("@DeliveryTime", SqlDbType.Int).Value = Convert.ToInt32(string.IsNullOrEmpty(this.txtDelivery.Text.Trim()) ? "0" : this.txtDelivery.Text.Trim());
                    cmdEdit.Parameters.Add("@MinimumQty", SqlDbType.Decimal).Value = Convert.ToDecimal(string.IsNullOrEmpty(this.txtMinQty.Text.Trim()) ? "0" : this.txtMinQty.Text.Trim());
                    cmdEdit.Parameters.Add("@NetPrice", SqlDbType.Decimal).Value = Convert.ToDecimal(string.IsNullOrEmpty(this.txtNetPrice.Text.Trim()) ? "0" : this.txtNetPrice.Text.Trim());
                    cmdEdit.Parameters.Add("@UnitCode", SqlDbType.NVarChar, 3).Value = this.cbOrderUnit.SelectedValue;
                    cmdEdit.Parameters.Add("@QtyConversion", SqlDbType.Int).Value = Convert.ToInt32(string.IsNullOrEmpty(this.txtQtyCon.Text.Trim()) ? "0" : this.txtQtyCon.Text.Trim());
                    cmdEdit.Parameters.Add("@Block", SqlDbType.Bit).Value = this.chkBlock.Checked;
                    cmdEdit.Connection = oConn; cmdEdit.CommandText = NP_Cls.SqlInsert;
                    cmdEdit.ExecuteNonQuery();

                    Clear(); DGV(); this.cbMaterial.Enabled = true; this.cbVendor.Enabled = true; this.btnAdd.Visible = true; this.btnEdit.Visible = false;
                    this.cbVendor.Text = string.Empty; this.cbMaterial.Text = string.Empty; this.cbVendor.Select();
                    NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Edit Data Completed !!");
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

                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr; Tr = oConn.BeginTransaction();
                try
                {
                    SqlCommand cmdEdit = new SqlCommand();
                    NP_Cls.SqlDel = "DELETE FROM t_VendorInfoRecord WHERE (VendorCode = @VendorCode) AND (MaterialCode = @MaterialCode)";
                    cmdEdit.Parameters.Add("@VendorCode", SqlDbType.NVarChar, 10).Value = this.dgvView[0, this.dgvView.CurrentRow.Index].Value.ToString();
                    cmdEdit.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15).Value = this.dgvView[1, this.dgvView.CurrentRow.Index].Value.ToString();
                    cmdEdit.Connection = oConn; cmdEdit.CommandText = NP_Cls.SqlDel; cmdEdit.Transaction = Tr;
                    cmdEdit.ExecuteNonQuery();

                    NP_Cls.SqlDel = "DELETE FROM t_VendorSourceList WHERE (VendorCode = @VendorCode) AND (MaterialCode = @MaterialCode)";
                    cmdEdit.Connection = oConn; cmdEdit.CommandText = NP_Cls.SqlDel; cmdEdit.Transaction = Tr;
                    cmdEdit.ExecuteNonQuery();

                    Tr.Commit();
                    Clear(); DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Delete Data Completed !!"); this.cbVendor.Select();
                    this.btnAdd.Visible = true; this.btnEdit.Visible = false; this.cbVendor.Enabled = true; this.cbMaterial.Enabled = true; this.cbVendor.Select();
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
        private void frmVendorInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;
        }

        private void cbVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex == 0)
            {
                //this.btnSetCond.Visible = false;
                ((ComboBox)sender).Select();
                this.lblPG.Text = string.Empty;
            }
            else
            {
                if (this.cbMaterial.SelectedIndex == 0)
                {
                  //  this.btnSetCond.Visible = false;
                    this.cbMaterial.Select();
                }
                else
                {
                    //this.btnSetCond.Visible = true;
                }
                GenPG();
            }
        }

        private void GenPG()
        {
            NP_Cls.SqlSelect = "SELECT PurchasingGroup FROM m_Vendor WHERE (VendorCode = '"+ this.cbVendor.SelectedValue +"')";
            this.lblPG.Text = NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0].Rows[0][0].ToString();
        }
        private void cbMatrial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex == 0)
            {
                this.txtMaterialUnit.Text = string.Empty;
                //this.btnSetCond.Visible = false;
                ((ComboBox)sender).Select();
            }
            else
            {
                this.txtMaterialUnit.Text = GetMTUnit(this.cbMaterial.SelectedValue.ToString());
                if (this.cbVendor.SelectedIndex == 0)
                {
                    //this.btnSetCond.Visible = false;
                    this.cbVendor.Select();
                }
                else
                {
                    //this.btnSetCond.Visible = true;
                }
            }
        }
        private string GetMTUnit(string strS)
        {
            try
            {
                NP_Cls.SqlSelect = "SELECT m_Unit.UnitName FROM m_Material INNER JOIN m_Unit ON m_Material.UnitCode = m_Unit.UnitCode WHERE     (m_Material.MaterialCode = N'"+ strS +"')";
                return NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0].Rows[0][0].ToString();
            }
            catch
            {
                return string.Empty;
            }
        }
        private void btnSetCond_Click(object sender, EventArgs e)
        {
            if (NP.ReqField(this.cbVendor, "Please enter Vendor: before Set Condition !!") == false) { return; }
            if (NP.ReqField(this.cbMaterial, "Please enter Material: before Set Condition !!") == false) { return; }

            NP_Cls.hVendorInfo = new System.Collections.Hashtable();
            NP_Cls.hVendorInfo.Add("Vendor", this.cbVendor.SelectedValue); NP_Cls.hVendorInfo.Add("Material", this.cbMaterial.SelectedValue);
            NP_Cls.hVendorInfo.Add("VendorName", this.cbVendor.Text); NP_Cls.hVendorInfo.Add("MaterialName", this.cbMaterial.Text);

            this.pOpcity.BringToFront();
            WMS.VendorTrans.frmVendorCondition frm = new frmVendorCondition();
            frm.ShowDialog(); this.pOpcity.SendToBack();
        }
        private void txtQtyCovert_KeyPress(object sender, KeyPressEventArgs e)
        {
            NP_Cls.myInteger(sender, e);
        }
        private void cbOrderUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbOrderUnit.SelectedIndex == 0)
            {
                this.txtInfoUnit.Text = string.Empty; this.cbOrderUnit.Select();
            }
            else
            {
                this.txtInfoUnit.Text = cbOrderUnit.Text; this.txtQtyCon.Text = "1"; this.txtQtyCon.Select(); this.txtQtyCon.SelectAll();
            }
        }

        private void setPeriodsConditionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NP_Cls.hVendorInfo = new System.Collections.Hashtable();
            NP_Cls.hVendorInfo.Add("Vendor", this.dgvView["clnVendorCode", this.dgvView.CurrentRow.Index].Value.ToString()); 
            NP_Cls.hVendorInfo.Add("Material", this.dgvView["clnMaterialCode", this.dgvView.CurrentRow.Index].Value.ToString());
            NP_Cls.hVendorInfo.Add("VendorName", this.dgvView["clnVendorName",this.dgvView.CurrentRow.Index].Value.ToString()); 
            NP_Cls.hVendorInfo.Add("MaterialName", this.dgvView["clnMaterialName",this.dgvView.CurrentRow.Index].Value.ToString());

            this.pOpcity.BringToFront();
            WMS.VendorTrans.frmVendorCondition frm = new frmVendorCondition();
            frm.ShowDialog(); this.pOpcity.SendToBack();
        }

    }
}
