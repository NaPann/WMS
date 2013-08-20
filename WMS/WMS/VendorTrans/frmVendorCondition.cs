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
    public partial class frmVendorCondition : Form
    {
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection();
        private DateTime dDefault = new DateTime(9999, 12, 31);
        public frmVendorCondition()
        {
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("Th-th");
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;
        }
        public void GenVCode()
        {
            try
            {
                NP_Cls.SqlSelect = "SELECT TmpValidPeriodsCode FROM tmp_GenCode";
                Int64 iCode = Convert.ToInt64(NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0].Rows[0][0].ToString());
                iCode += 1; string strErr = string.Empty;
                if (NP.SqlCmd("UPDATE tmp_GenCode SET TmpValidPeriodsCode = " + iCode, ref strErr))
                {
                    NP_Cls.strValidCode = iCode.ToString();
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
        private void frmVendorCondition_Load(object sender, EventArgs e)
        {        
           DGV(); Clear(); this.lblVendor.Text = NP_Cls.hVendorInfo["VendorName"].ToString(); this.lblMaterial.Text = NP_Cls.hVendorInfo["MaterialName"].ToString();
            this.dtpOn.Select();
            //this.dtpTo.Value = this.dtpTo.MaxDate;
        }
        private void Clear()
        {
            if (this.dgvView.RowCount == 0)
            {
                this.dtpOn.MinDate = DateTime.Now; this.dtpTo.MinDate = DateTime.Now;
                this.dtpOn.Value = DateTime.Now;  //this.dtpOn.MinDate = DateTime.Now;
                this.dtpTo.Value = DateTime.Now; //this.dtpTo.MinDate = DateTime.Now;
            }
            else
            {
                if (((DateTime)this.dgvView[2, this.dgvView.RowCount - 1].Value) == this.dtpTo.MaxDate)
                {
                    this.dtpOn.Value = ((DateTime)this.dgvView[1, this.dgvView.RowCount - 1].Value).AddDays(1);
                    this.dtpTo.Value = dtpOn.Value; 
                    this.dtpOn.MinDate = ((DateTime)this.dgvView[1, this.dgvView.RowCount - 1].Value).AddDays(1);
                    this.dtpTo.MinDate = ((DateTime)this.dgvView[1, this.dgvView.RowCount - 1].Value).AddDays(1);
                }
                else
                {
                    this.dtpOn.MinDate = ((DateTime)this.dgvView[2, this.dgvView.RowCount - 1].Value).AddDays(1);
                    this.dtpTo.MinDate = ((DateTime)this.dgvView[2, this.dgvView.RowCount - 1].Value).AddDays(1);
                    this.dtpOn.Value = ((DateTime)this.dgvView[2, this.dgvView.RowCount - 1].Value).AddDays(1);
                    this.dtpTo.Value = this.dtpOn.Value;
                    this.dtpOn.MinDate = ((DateTime)this.dgvView[2, this.dgvView.RowCount - 1].Value).AddDays(1);
                    this.dtpTo.MinDate = ((DateTime)this.dgvView[2, this.dgvView.RowCount - 1].Value).AddDays(1);
                }
            }
        }
        private void DGV()
        {
            NP_Cls.SqlSelect = "SELECT ValidPeriodCode, ValidOn, ValidTo FROM t_VendorInfoRecordPeriods WHERE  (VendorCode = N'"+ NP_Cls.hVendorInfo["Vendor"].ToString() +"') AND (MaterialCode = N'"+ NP_Cls.hVendorInfo["Material"].ToString() +"') ";
            if (this.dtpSValidOn.Checked)
            {
                NP_Cls.SqlSelect += " AND (ValidOn = CONVERT(DATETIME, '" + this.dtpSValidOn.Value.ToString("yyyy-MM-dd", NP_Cls.cul) + "', 102))";
            }
        
            this.dgvView.DataSource = NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0];
            if (this.dgvView.RowCount == 0) { this.contextMenuStrip1.Enabled = false; } else { this.contextMenuStrip1.Enabled = true; }
            
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
        private void btnAddVaidPeriod_Click(object sender, EventArgs e)
        {
            if (this.dtpTo.Value < this.dtpOn.Value)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Valid To: must be more than Valid On: !!"); this.dtpTo.Select(); return;
            }

            if (this.dtpTo.Value == this.dtpOn.Value)
            {
                if (NP.MSGB("Do you want to save and use Valid To: for unlimit date !!") == DialogResult.Yes)
                {
                    this.dtpTo.Value = this.dtpTo.MaxDate;

                    oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                    if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                    oConn.Open(); SqlTransaction Tr;
                    Tr = oConn.BeginTransaction();
                    try
                    {
                        SqlCommand cmdIns = new SqlCommand();
                        cmdIns.Parameters.Add("@ValidTo", SqlDbType.Date);
                       
                        if (this.dgvView.RowCount > 0)
                        {
                            if (Convert.ToDateTime(this.dgvView[2, this.dgvView.RowCount - 1].Value) == this.dtpTo.MaxDate)
                            {
                                 NP_Cls.sqlUpdate = "UPDATE t_VendorInfoRecordPeriods SET ValidTo = @ValidTo WHERE (ValidPeriodCode = @ValidPeriodCode)";
                                 cmdIns.Parameters["@ValidTo"].Value = this.dtpOn.Value.AddDays(-1);
                                 cmdIns.Parameters.Add("@ValidPeriodCode", SqlDbType.NVarChar, 20).Value = this.dgvView["clnValidPeriodCode", this.dgvView.RowCount - 1].Value.ToString();
                                 cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.sqlUpdate; cmdIns.Transaction = Tr; 
                                 cmdIns.ExecuteNonQuery();
                            }
                        }

                        //if (this.dgvView.RowCount == 0) { GenVCode(); }
                        NP_Cls.SqlInsert = "INSERT INTO t_VendorInfoRecordPeriods " +
                          "(VendorCode, MaterialCode, ValidOn, ValidTo, UserCreate, DateCreate, FileStatus) " +
    "VALUES (@VendorCode,@MaterialCode,@ValidOn,@ValidTo,@UC, GETDATE(), N'1')";
                        //cmdIns.Parameters.Add("@ValidPeriodCode", SqlDbType.Int).Value = Convert.ToInt64(NP_Cls.strValidCode);
                        cmdIns.Parameters.Add("@VendorCode", SqlDbType.NVarChar, 10).Value = NP_Cls.hVendorInfo["Vendor"].ToString();
                        cmdIns.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15).Value = NP_Cls.hVendorInfo["Material"].ToString();
                        cmdIns.Parameters.Add("@ValidOn", SqlDbType.Date).Value = this.dtpOn.Value;
                        cmdIns.Parameters["@ValidTo"].Value = this.dtpTo.Value;
                        cmdIns.Parameters.Add("@UC", SqlDbType.NVarChar, 10).Value = NP_Cls.strUsr;
                        cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                        cmdIns.ExecuteNonQuery();

                        Tr.Commit();
                        DGV(); Clear(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Add Data Completed !!"); this.dtpOn.Select(); return;
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
                    this.dtpTo.Select(); return;
                }
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
                    cmdIns.Parameters.Add("@ValidTo", SqlDbType.Date);                   
                    if (this.dgvView.RowCount > 0)
                    {
                        if (Convert.ToDateTime(this.dgvView[2, this.dgvView.RowCount - 1].Value) == this.dtpTo.MaxDate)
                        {
                            NP_Cls.sqlUpdate = "UPDATE t_VendorInfoRecordPeriods SET ValidTo = @ValidTo WHERE (ValidPeriodCode = @ValidPeriodCode)";
                            cmdIns.Parameters["@ValidTo"].Value = this.dtpOn.Value.AddDays(-1);
                            cmdIns.Parameters.Add("@ValidPeriodCode", SqlDbType.NVarChar, 20).Value = this.dgvView["clnValidPeriodCode", this.dgvView.RowCount - 1].Value.ToString();
                            cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.sqlUpdate; cmdIns.Transaction = Tr;
                            cmdIns.ExecuteNonQuery();
                        }
                    }
                    //if (this.dgvView.RowCount == 0) { GenVCode(); }
                    NP_Cls.SqlInsert = "INSERT INTO t_VendorInfoRecordPeriods "+
                      "(VendorCode, MaterialCode, ValidOn, ValidTo, UserCreate, DateCreate, FileStatus) " +
"VALUES (@VendorCode,@MaterialCode,@ValidOn,@ValidTo,@UC, GETDATE(), N'1')";
                    //cmdIns.Parameters.Add("@ValidPeriodCode", SqlDbType.Int).Value = Convert.ToInt64(NP_Cls.strValidCode);
                    cmdIns.Parameters.Add("@VendorCode", SqlDbType.NVarChar, 10).Value = NP_Cls.hVendorInfo["Vendor"].ToString();
                    cmdIns.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15).Value = NP_Cls.hVendorInfo["Material"].ToString();
                    cmdIns.Parameters.Add("@ValidOn", SqlDbType.Date).Value = this.dtpOn.Value;
                    cmdIns.Parameters["@ValidTo"].Value = this.dtpTo.Value;
                    cmdIns.Parameters.Add("@UC", SqlDbType.NVarChar, 10).Value = NP_Cls.strUsr;
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                    cmdIns.ExecuteNonQuery();

                    Tr.Commit();
                    DGV(); Clear(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Add Data Completed !!"); this.dtpOn.Select();
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
        private void dtpSValidOn_ValueChanged(object sender, EventArgs e)
        {
            DGV();
        }
        private void addScaleQtyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NP_Cls.strValidCode = this.dgvView["clnValidPeriodCode", this.dgvView.CurrentRow.Index].Value.ToString();
            WMS.VendorTrans.frmPeriodsScaleQty frm = new frmPeriodsScaleQty();
            frm.ShowDialog();
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
                    SqlCommand cmdDel = new SqlCommand();
                    NP_Cls.SqlDel = "DELETE FROM t_VendorInfoRecordPeriods WHERE (MaterialCode = @MaterialCode) AND (ValidPeriodCode = @ValidPeriodCode) AND (VendorCode = @VendorCode)";
                    cmdDel.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15).Value = NP_Cls.hVendorInfo["Material"].ToString();
                    cmdDel.Parameters.Add("@ValidPeriodCode", SqlDbType.Int).Value = this.dgvView["clnValidPeriodCode", this.dgvView.CurrentRow.Index].Value.ToString();
                    cmdDel.Parameters.Add("@VendorCode", SqlDbType.NVarChar, 10).Value = NP_Cls.hVendorInfo["Vendor"].ToString();
                    cmdDel.Connection = oConn; cmdDel.CommandText = NP_Cls.SqlDel; cmdDel.Transaction = Tr;
                    cmdDel.ExecuteNonQuery();

                    NP_Cls.SqlDel = "DELETE FROM t_VendorInfoRecordPeriodsDetail WHERE (ValidPeriodCode = @ValidPeriodCode)";
                    cmdDel.Connection = oConn; cmdDel.CommandText = NP_Cls.SqlDel; cmdDel.Transaction = Tr;
                    cmdDel.ExecuteNonQuery();

                    if (NP._TRanSave(oConn, Tr, NP_Cls.NPTranType.Delete, "t_VendorInfoRecordPeriods:t_VendorInfoRecordPeriodsDetail", NP_Cls.strUsr))
                    {
                        Tr.Commit();                      
                    }
                    else
                    {
                        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Try agian !!"); return;
                    }
                    DGV(); Clear(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Delete Completed !!");
                }
                catch (Exception ex)
                {
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
