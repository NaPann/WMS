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
    public partial class frmPeriodsScaleQty : Form
    {
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection();
        public frmPeriodsScaleQty()
        {
            InitializeComponent();
        }
        private void frmPeriodsScaleQty_Load(object sender, EventArgs e)
        {
            Clear(); DGV(); this.btnEdit.Visible = false; this.txtScaleQty.Select();
        }
        private void DGV()
        {
            //NP_Cls.SqlSelect = "SELECT    t_VendorInfoRecordPeriodsDetail.ValidPeriodDetailCode,  t_VendorInfoRecordPeriods.ValidPeriodCode, m_Currency.CurrencyName, m_Unit.UnitName, t_VendorInfoRecordPeriodsDetail.ScaleQty,  t_VendorInfoRecordPeriodsDetail.Rate FROM t_VendorInfoRecordPeriods INNER JOIN " +
            //          "m_Material ON t_VendorInfoRecordPeriods.MaterialCode = m_Material.MaterialCode INNER JOIN " +
            //          "m_Vendor ON t_VendorInfoRecordPeriods.VendorCode = m_Vendor.VendorCode INNER JOIN " +
            //          "m_Currency ON m_Vendor.CurrencyCode = m_Currency.CurrencyCode INNER JOIN " +
            //          "m_Unit ON m_Material.UnitCode = m_Unit.UnitCode INNER JOIN " +
            //          "t_VendorInfoRecordPeriodsDetail ON t_VendorInfoRecordPeriods.ValidPeriodCode = t_VendorInfoRecordPeriodsDetail.ValidPeriodCode WHERE     (t_VendorInfoRecordPeriods.VendorCode = N'" + NP_Cls.hVendorInfo["Vendor"].ToString() + "') AND (t_VendorInfoRecordPeriods.MaterialCode = N'" + NP_Cls.hVendorInfo["Material"].ToString() +"')";
            NP_Cls.SqlSelect = "SELECT     t_VendorInfoRecordPeriodsDetail.ValidPeriodDetailCode, t_VendorInfoRecordPeriods.ValidPeriodCode, m_Currency.CurrencyName, m_Unit.UnitName, t_VendorInfoRecordPeriodsDetail.ScaleQty, t_VendorInfoRecordPeriodsDetail.Rate "+
"FROM         t_VendorInfoRecordPeriods INNER JOIN "+
                      "m_Material ON t_VendorInfoRecordPeriods.MaterialCode = m_Material.MaterialCode INNER JOIN "+
                      "m_Vendor ON m_Vendor.VendorCode = t_VendorInfoRecordPeriods.VendorCode INNER JOIN "+
                      "m_Currency ON m_Currency.CurrencyCode = m_Vendor.CurrencyCode INNER JOIN "+
                      "m_Unit ON m_Unit.UnitCode = m_Material.UnitCode LEFT OUTER JOIN "+
                      "t_VendorInfoRecordPeriodsDetail ON t_VendorInfoRecordPeriods.ValidPeriodCode = t_VendorInfoRecordPeriodsDetail.ValidPeriodCode "+
"WHERE     (t_VendorInfoRecordPeriods.VendorCode = N'" + NP_Cls.hVendorInfo["Vendor"].ToString() + "') AND (t_VendorInfoRecordPeriods.MaterialCode = N'" + NP_Cls.hVendorInfo["Material"].ToString() + "') AND  (t_VendorInfoRecordPeriods.ValidPeriodCode = '"+ NP_Cls.strValidCode +"')";
            DataSet ds = new DataSet(); ds = NP.GetClientDataSet(NP_Cls.SqlSelect);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.txtCurrency.Text = ds.Tables[0].Rows[0]["CurrencyName"].ToString(); this.txtUnit.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();
            }
            else
            {
                this.txtCurrency.Text = string.Empty; this.txtUnit.Text = string.Empty;
            }
            this.dgvView.DataSource = ds.Tables[0];
        }
        private void Clear()
        {
            this.txtScaleQty.Text = string.Empty; this.txtRate.Text = string.Empty;
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
                if (NP.ReqField(this.txtScaleQty, "Please enter Scale Qty: !!") == false) { return; }
                if (NP.ReqField(this.txtRate, "Please enter Unit of Rate: !!") == false) { return; }

                if (ChkDup())
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Code Duplicated !!"); this.txtScaleQty.Select(); this.txtScaleQty.SelectAll(); return;
                }

                if (NP.MSGB("Do you want to Add Data ?") == DialogResult.Yes)
                {
                    oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                    if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                    oConn.Open();
                    try
                    {
                        SqlCommand cmdIns = new SqlCommand();
                        NP_Cls.SqlInsert = "INSERT INTO t_VendorInfoRecordPeriodsDetail "+
                      "(ValidPeriodCode, ScaleQty, Rate, UserCreate, DateCreate, FileStatus) " +
"VALUES     (@ValidPeriodCode,@ScaleQty,@Rate,@UC, GETDATE(), @St)";
                        cmdIns.Parameters.Add("@ValidPeriodCode", SqlDbType.Int).Value = NP_Cls.strValidCode;
                        cmdIns.Parameters.Add("@ValidPeriodDetailCode", SqlDbType.Int).Value = NP_Cls.strValidCode;
                        cmdIns.Parameters.Add("@ScaleQty", SqlDbType.Decimal).Value = Convert.ToDecimal(this.txtScaleQty.Text.Trim() == string.Empty ? "0" : this.txtScaleQty.Text.Trim());
                        cmdIns.Parameters.Add("@Rate", SqlDbType.Decimal).Value = Convert.ToDecimal(this.txtRate.Text.Trim() == string.Empty ? "0" : this.txtRate.Text.Trim());
                        cmdIns.Parameters.Add("@UC", SqlDbType.NVarChar, 10).Value = NP_Cls.strUsr;
                        cmdIns.Parameters.Add("@St", SqlDbType.NVarChar, 1).Value = "1";
                        cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert;
                        cmdIns.ExecuteNonQuery();

                        Clear(); DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Add Data Completed !!"); this.txtScaleQty.Select();
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
                NP_Cls.SqlSelect = "SELECT ScaleQty FROM t_VendorInfoRecordPeriodsDetail WHERE (ValidPeriodCode = '" + NP_Cls.strValidCode + "') AND (ScaleQty = " + this.txtScaleQty.Text.Trim().Replace("'", string.Empty) + ")";
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

        private void txtScaleQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            NP_Cls.myDecimal(sender, e);
        }
        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            NP_Cls.myDecimal(sender, e);
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
                    NP_Cls.SqlDel = "DELETE FROM t_VendorInfoRecordPeriodsDetail WHERE (ValidPeriodDetailCode = @ValidPeriodDetailCode) AND (ValidPeriodCode = @ValidPeriodCode)";
                    cmdEdit.Parameters.Add("@ValidPeriodDetailCode", SqlDbType.Int).Value = this.dgvView[0, this.dgvView.CurrentRow.Index].Value.ToString();
                    cmdEdit.Parameters.Add("@ValidPeriodCode", SqlDbType.Int).Value = this.dgvView[1, this.dgvView.CurrentRow.Index].Value.ToString();
                    cmdEdit.Connection = oConn; cmdEdit.CommandText = NP_Cls.SqlDel; cmdEdit.Transaction = Tr;
                    cmdEdit.ExecuteNonQuery();

                    if (NP._TRanSave(oConn, Tr, NP_Cls.NPTranType.Delete, "t_VendorInfoRecordPeriodsDetail", NP_Cls.strUsr))
                    {
                        Tr.Commit();
                        Clear(); DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Delete Data Completed !!");
                        this.btnAdd.Visible = true; this.btnEdit.Visible = false; this.txtScaleQty.Select();
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
    }
}
