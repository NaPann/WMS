using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WMS.PR_PO
{
    public partial class frmPR : Form
    {
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection(); private byte bView = 0;
        private string strGNumber = string.Empty; private DataSet dsPR = new DataSet(); private string strCurr = string.Empty;
        private void MyGrid(DataGridView grid)
        {
            NP_Cls.SqlSelect = "SELECT     1 AS ItemNo, t_VendorInfoRecord.MaterialCode, m_Material.MaterialName, 0 AS Qty, m_Unit.UnitName, t_VendorInfoRecord.NetPrice, 0.0 AS Amt, GETDATE()                        + t_VendorInfoRecord.DeliveryTime AS DeliveryDate, m_Material.PlantCode, m_Material.LocCode, CONVERT(bit, 0) AS PRApprove, CONVERT(bit, 0) AS isPO,                        m_Plant.PlantName, m_Location.LocName, t_VendorInfoRecord.QtyConversion, t_VendorInfoRecord.UnitCode, 0.0 AS QtyC FROM         t_VendorInfoRecord INNER JOIN                       m_Material ON t_VendorInfoRecord.MaterialCode = m_Material.MaterialCode INNER JOIN                       m_Unit ON t_VendorInfoRecord.UnitCode = m_Unit.UnitCode LEFT OUTER JOIN                       m_Plant ON m_Material.PlantCode = m_Plant.PlantCode LEFT OUTER JOIN                       m_Location ON m_Material.LocCode = m_Location.LocCode WHERE (t_VendorInfoRecord.VendorCode = N'') AND (t_VendorInfoRecord.MaterialCode = N'')";
            this.dsPR = NP.GetClientDataSet(NP_Cls.SqlSelect);
            grid.DataSource = this.dsPR.Tables[0];
        }
        public frmPR()
        {
            InitializeComponent();
        }

        private void frmPR_Load(object sender, EventArgs e)
        {
            try
            {
                WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
                //frm.menuStrip1.Enabled = true;


                this.txtPR.Text = GetNumber(); this.txtDocDate.Text = NP.GetDateServer().ToString("dd/MM/yyyy");
                this.MyGrid(dgvView);
                Clear();
                if (NP_Cls.FromMRP == 1)
                {
                    try
                    {
                        BindVendor();
                        this.cbVendor.SelectedIndex = 1; this.cbVendor.Select();
                    }
                    catch
                    {
                        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Cannot find this vendor info record !! Please entry ..."); return;
                    }
                }
                else
                {
                    BindVendor();
                    this.cbVendor.Text = string.Empty; this.cbVendor.Select();
                }

            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Load : " + ex.Message); return;
            }
        }

        private void BindVendor()
        {
            if (NP_Cls.FromMRP == 1)
            {
                NP_Cls.SqlSelect = "SELECT DISTINCT m_Vendor.VendorName, t_VendorInfoRecord.VendorCode + ':' + m_Vendor.VendorName AS VendorCode  FROM t_VendorInfoRecord INNER JOIN m_Vendor ON t_VendorInfoRecord.VendorCode = m_Vendor.VendorCode WHERE     (t_VendorInfoRecord.MaterialCode = N'" + NP_Cls.MRPFGSort + "')";
                NP.BindCB(this.cbVendor, NP_Cls.SqlSelect, "VendorName", "VendorCode", "((( Select Vendor Info )))");
            }
            else
            {
                NP_Cls.SqlSelect = "SELECT DISTINCT m_Vendor.VendorName, t_VendorInfoRecord.VendorCode +':' + m_Vendor.VendorName AS VendorCode  FROM t_VendorInfoRecord INNER JOIN m_Vendor ON t_VendorInfoRecord.VendorCode = m_Vendor.VendorCode"; NP.BindCB(this.cbVendor, NP_Cls.SqlSelect, "VendorName", "VendorCode", "((( Select Vendor Info )))");
            }
        }
        private void Clear()
        {
            this.lblVendorName.Text = string.Empty; this.lblCurrency.Text = string.Empty; this.lblMaterialName.Text = string.Empty;
            this.lblPG.Text = string.Empty; this.lblTerm.Text = string.Empty; this.strCurr = string.Empty;
        }
        private string GetNumber()
        {
            try
            {
                bView = 0;
                NP_Cls.SqlSelect = "SELECT top (1) CONVERT(int, RIGHT(PRNumber, 4)) AS SS, RIGHT(CONVERT(nvarchar, GETDATE(), 112), 6) AS s FROM   t_PR WHERE (RIGHT(CONVERT(nvarchar, GETDATE(), 112), 6) = LEFT(RIGHT(PRNumber, 10), 6)) ORDER BY SS DESC";
                DataSet dsGen = new DataSet(); dsGen = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (dsGen.Tables[0].Rows.Count == 0)
                {
                    NP_Cls.SqlSelect = "SELECT  TOP (1) RIGHT(CONVERT(nvarchar, GETDATE(), 112), 6) AS s";
                    return "PR" + NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0].Rows[0][0].ToString() + "0001";
                }
                else
                {
                    string strCode = (Convert.ToInt16(dsGen.Tables[0].Rows[0][0].ToString()) + 1).ToString().PadLeft(4, '0');
                    return "PR" + dsGen.Tables[0].Rows[0][1].ToString() + strCode;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void cbVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.cbVendor.SelectedIndex != 0) && (!string.IsNullOrEmpty(this.cbVendor.Text.Trim())))
            {
                this.lblVendorName.Text = this.cbVendor.SelectedValue.ToString();
                DataSet dsDetail = new DataSet();
                try
                {
                    NP_Cls.SqlSelect = "SELECT m_Vendor.VendorCode, m_Vendor.PurchasingGroup, m_Vendor.TermsOfPayment, m_Currency.CurrencyName, m_Vendor.CurrencyCode FROM   m_Vendor INNER JOIN m_Currency ON m_Vendor.CurrencyCode = m_Currency.CurrencyCode WHERE     (m_Vendor.VendorCode = N'" + this.cbVendor.Text.Trim().Split(':')[0] + "')";
                    dsDetail = NP.GetClientDataSet(NP_Cls.SqlSelect);
                    this.lblCurrency.Text = dsDetail.Tables[0].Rows[0]["CurrencyName"].ToString();
                    this.lblPG.Text = dsDetail.Tables[0].Rows[0]["PurchasingGroup"].ToString();
                    this.lblTerm.Text = dsDetail.Tables[0].Rows[0]["TermsOfPayment"].ToString();
                    this.strCurr = dsDetail.Tables[0].Rows[0]["CurrencyCode"].ToString();
                }
                catch (SqlException ex)
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Detail : " + ex.Message); return;
                }
            }
            else
            {
                Clear();
                this.cbVendor.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(this.bView))
            {
                if ((this.dsPR.Tables[0].Rows.Count > 0) || (this.groupPR.Enabled == false))
                {
                    if (NP.MSGB("The PR list will be cancel , Do you agree with this ?") == DialogResult.Yes)
                    {
                        // Cancel
                        NP_Cls.SqlDel = "DELETE FROM t_PR WHERE (PRNumber = '" + this.txtPR.Text.Trim() + "')"; string strErr = string.Empty;
                        if (!NP.SqlCmd(NP_Cls.SqlDel, ref strErr))
                        {
                            NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Delete : " + strErr); return;
                        }
                        else
                        {
                            NP_Cls.SqlDel = "DELETE FROM t_PRDetail WHERE (PRNumber = '" + this.txtPR.Text.Trim() + "')";
                            if (!NP.SqlCmd(NP_Cls.SqlDel, ref strErr))
                            {
                                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Delete Detail : " + strErr); return;
                            }
                        }
                        this.Close(); return;
                    }
                    else
                    {
                        return;
                    }
                }
            }


            if (NP.MSGB("Do you want to exit this screen ?") == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }
        private void frmPR_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (NP_Cls.FromMRP == 0)
            {
                WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
                frm.menuStrip1.Enabled = true;
            }
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.cbMaterial.Text.Trim()))
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please add PR Header first !!"); return;
            }
            else
            {
                if (this.cbMaterial.SelectedIndex == 0)
                {
                    NP.ReqField(this.cbMaterial, "Please select material first !!"); return;
                }
                else
                {
                    if (this.dsPR.Tables[0].Rows.Count > 0)
                    {
                        //for (byte ii = 0; ii < this.dsPR.Tables[0].Rows.Count; ii++)
                        //{
                        //    if (this.cbMaterial.Text.Trim() == this.dsPR.Tables[0].Rows[ii]["MaterialCode"].ToString())
                        //    {
                        //        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "This material is in PR List !!"); this.cbMaterial.Select(); return;
                        //    }
                        //}
                    }
                    else if (this.dsPR.Tables[0].Rows.Count == 0)
                    {
                        //
                        if (NP_Cls.FromMRP == 1)
                        {
                            NP_Cls.SqlSelect = "SELECT     1 AS ItemNo, t_VendorInfoRecord.MaterialCode, m_Material.MaterialName, 0 AS Qty, m_Unit.UnitName, t_VendorInfoRecord.NetPrice, 0.0 AS Amt, GETDATE()                        + t_VendorInfoRecord.DeliveryTime AS DeliveryDate, m_Material.PlantCode, m_Material.LocCode, CONVERT(bit, 0) AS PRApprove, CONVERT(bit, 0) AS isPO,                        m_Plant.PlantName, m_Location.LocName, t_VendorInfoRecord.QtyConversion, t_VendorInfoRecord.UnitCode, 0.0 AS QtyC FROM         t_VendorInfoRecord INNER JOIN                       m_Material ON t_VendorInfoRecord.MaterialCode = m_Material.MaterialCode INNER JOIN                       m_Unit ON t_VendorInfoRecord.UnitCode = m_Unit.UnitCode LEFT OUTER JOIN                       m_Plant ON m_Material.PlantCode = m_Plant.PlantCode LEFT OUTER JOIN                       m_Location ON m_Material.LocCode = m_Location.LocCode WHERE (t_VendorInfoRecord.VendorCode = N'" + this.cbVendor.Text.Trim().Split(':')[0] + "') AND (t_VendorInfoRecord.MaterialCode = N'" + this.cbMaterial.Text.Trim() + "')";
                        }
                        else
                        {
                            NP_Cls.SqlSelect = "SELECT     1 AS ItemNo, t_VendorInfoRecord.MaterialCode, m_Material.MaterialName, 0 AS Qty, m_Unit.UnitName, t_VendorInfoRecord.NetPrice, 0.0 AS Amt, GETDATE()                        + t_VendorInfoRecord.DeliveryTime AS DeliveryDate, m_Material.PlantCode, m_Material.LocCode, CONVERT(bit, 0) AS PRApprove, CONVERT(bit, 0) AS isPO,                        m_Plant.PlantName, m_Location.LocName, t_VendorInfoRecord.QtyConversion, t_VendorInfoRecord.UnitCode, 0.0 AS QtyC FROM         t_VendorInfoRecord INNER JOIN                       m_Material ON t_VendorInfoRecord.MaterialCode = m_Material.MaterialCode INNER JOIN                       m_Unit ON t_VendorInfoRecord.UnitCode = m_Unit.UnitCode LEFT OUTER JOIN                       m_Plant ON m_Material.PlantCode = m_Plant.PlantCode LEFT OUTER JOIN                       m_Location ON m_Material.LocCode = m_Location.LocCode WHERE (t_VendorInfoRecord.VendorCode = N'" + this.cbVendor.Text.Trim().Split(':')[0] + "') AND (t_VendorInfoRecord.MaterialCode = N'" + this.cbMaterial.Text.Trim() + "')";
                        }
                        this.dsPR = NP.GetClientDataSet(NP_Cls.SqlSelect);
                        //this.dsPR = CompareCondition(this.dsPR);

                        //TODO 31.07.2012 QtyConvertion
                        for (int i = 0; i < dsPR.Tables[0].Rows.Count; i++)
                        {
                            this.dsPR.Tables[0].Rows[i]["QtyC"] = decimal.Parse(this.dsPR.Tables[0].Rows[i]["QtyConversion"].ToString()) * decimal.Parse(this.dsPR.Tables[0].Rows[i]["Qty"].ToString());
                        }


                        //this.dsPR.Tables[0].Columns.Remove("QtyConversion");
                        this.dsPR.AcceptChanges();
                        this.dgvView.DataSource = this.dsPR.Tables[0];
                        return;
                        //
                    }

                    // if Row >  1
                    DataRow dr; dr = this.dsPR.Tables[0].NewRow();
                    NP_Cls.SqlSelect = "SELECT     1 AS ItemNo, t_VendorInfoRecord.MaterialCode, m_Material.MaterialName, 0 AS Qty, m_Unit.UnitName, t_VendorInfoRecord.NetPrice, 0.0 AS Amt, GETDATE()                        + t_VendorInfoRecord.DeliveryTime AS DeliveryDate, m_Material.PlantCode, m_Material.LocCode, CONVERT(bit, 0) AS PRApprove, CONVERT(bit, 0) AS isPO,                        m_Plant.PlantName, m_Location.LocName, t_VendorInfoRecord.QtyConversion, t_VendorInfoRecord.UnitCode, 0.0 AS QtyC FROM         t_VendorInfoRecord INNER JOIN                       m_Material ON t_VendorInfoRecord.MaterialCode = m_Material.MaterialCode INNER JOIN                       m_Unit ON t_VendorInfoRecord.UnitCode = m_Unit.UnitCode LEFT OUTER JOIN                       m_Plant ON m_Material.PlantCode = m_Plant.PlantCode LEFT OUTER JOIN                       m_Location ON m_Material.LocCode = m_Location.LocCode WHERE (t_VendorInfoRecord.VendorCode = N'" + this.cbVendor.Text.Trim().Split(':')[0] + "') AND (t_VendorInfoRecord.MaterialCode = N'" + this.cbMaterial.Text.Trim() + "')";
                    DataSet ds = new DataSet(); ds = NP.GetClientDataSet(NP_Cls.SqlSelect);
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        this.dsPR.Tables[0].ImportRow(item);
                    }

                    for (byte ii = 0; ii < this.dsPR.Tables[0].Rows.Count; ii++)
                    {
                        this.dsPR.Tables[0].Rows[ii]["ItemNo"] = Convert.ToInt32(ii + 1);
                        //this.dsPR.Tables[0].Rows[ii]["Qty"] = decimal.Parse(this.dsPR.Tables[0].Rows[ii]["QtyConversion"].ToString()) * decimal.Parse(this.dsPR.Tables[0].Rows[ii]["Qty"].ToString());
                        this.dsPR.Tables[0].Rows[ii]["QtyC"] = decimal.Parse(this.dsPR.Tables[0].Rows[ii]["QtyConversion"].ToString()) * decimal.Parse(this.dsPR.Tables[0].Rows[ii]["Qty"].ToString());
                    }
                    //this.dsPR.Tables[0].Columns.Remove("QtyConversion");
                    this.dsPR.AcceptChanges();
                    this.dgvView.DataSource = this.dsPR.Tables[0];
                }
            }
        }
        private DataSet CompareCondition(DataSet dataSet, Int32 ind)
        {
            try
            {
                NP_Cls.SqlSelect = "SELECT     t_VendorInfoRecordPeriodsDetail.ScaleQty, t_VendorInfoRecordPeriodsDetail.Rate FROM t_VendorInfoRecordPeriods INNER JOIN                    t_VendorInfoRecordPeriodsDetail ON t_VendorInfoRecordPeriods.ValidPeriodCode = t_VendorInfoRecordPeriodsDetail.ValidPeriodCode WHERE  (GETDATE() BETWEEN t_VendorInfoRecordPeriods.ValidOn AND t_VendorInfoRecordPeriods.ValidTo) AND  (t_VendorInfoRecordPeriods.FileStatus = N'1') AND (t_VendorInfoRecordPeriods.MaterialCode = N'" + this.dsPR.Tables[0].Rows[ind]["MaterialCode"].ToString() + "') AND (t_VendorInfoRecordPeriods.VendorCode = N'" + this.cbVendor.Text.Trim().Split(':')[0] + "') ORDER BY t_VendorInfoRecordPeriodsDetail.ScaleQty";
                DataSet ds = new DataSet();
                Double inQty = Convert.ToDouble(dataSet.Tables[0].Rows[ind]["Qty"].ToString());
                ds = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (i == ds.Tables[0].Rows.Count - 1)
                        {
                            if (inQty >= Convert.ToDouble(ds.Tables[0].Rows[i]["ScaleQty"].ToString()))
                            {
                                dataSet.Tables[0].Rows[ind]["NetPrice"] = Convert.ToDouble(ds.Tables[0].Rows[i]["Rate"].ToString()); break;
                            }
                        }
                        else
                        {
                            if (inQty <= Convert.ToInt32(ds.Tables[0].Rows[i]["ScaleQty"].ToString()))
                            {
                                dataSet.Tables[0].Rows[ind]["NetPrice"] = Convert.ToDouble(ds.Tables[0].Rows[i]["Rate"].ToString()); break;
                            }
                        }

                        if (inQty < Convert.ToDouble(ds.Tables[0].Rows[i]["ScaleQty"].ToString()))
                        {
                            dataSet.Tables[0].Rows[ind]["NetPrice"] = Convert.ToDouble(ds.Tables[0].Rows[i]["Rate"].ToString()); break;
                        }
                    }
                }
                return dataSet;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void btnAddPR_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(this.cbVendor.Text.Trim())) && (this.cbVendor.SelectedIndex != 0))
            {
                //
                oConn = new SqlConnection(NP.ReadFileDB(Application.StartupPath + @"\DB\DB.ini"));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open();

                try
                {
                    SqlCommand cmdIns = new SqlCommand();
                    NP_Cls.SqlInsert = "INSERT INTO t_PR " +
                      "(PRNumber, PRDate, VendorCode, VendorName, PurchasingGroup, Terms, CurrencyCode, CurrencyName, Remark, UserCreate, DateCreate) " +
"VALUES     (@PRNumber,GETDATE(),@VendorCode,@VendorName,@PurchasingGroup,@Terms,@CurrencyCode,@CurrencyName,@Remark,@UD, GETDATE())";
                    this.strGNumber = GetNumber();
                    cmdIns.Parameters.Add("@PRNumber", SqlDbType.NVarChar, 12).Value = this.strGNumber;
                    cmdIns.Parameters.Add("@VendorCode", SqlDbType.NVarChar, 10).Value = this.cbVendor.Text.Trim().Split(':')[0];
                    cmdIns.Parameters.Add("@VendorName", SqlDbType.NVarChar, 60).Value = this.lblVendorName.Text.Trim();
                    cmdIns.Parameters.Add("@PurchasingGroup", SqlDbType.NVarChar, 3).Value = this.lblPG.Text.Trim();
                    cmdIns.Parameters.Add("@Terms", SqlDbType.Decimal).Value = Convert.ToDecimal(this.lblTerm.Text.Trim());
                    cmdIns.Parameters.Add("@CurrencyCode", SqlDbType.NVarChar, 3).Value = this.strCurr;
                    cmdIns.Parameters.Add("@CurrencyName", SqlDbType.NVarChar, 20).Value = this.lblCurrency.Text.Trim();
                    cmdIns.Parameters.Add("@Remark", SqlDbType.NVarChar, 255).Value = this.txtRemark.Text.Trim();
                    cmdIns.Parameters.Add("@UD", SqlDbType.NVarChar, 50).Value = NP_Cls.strUsr;
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert;
                    cmdIns.ExecuteNonQuery();

                    this.groupPR.Enabled = false; this.btnAddPR.Visible = false; this.btnSave.Visible = true;

                    if (NP_Cls.FromMRP == 1)
                    {
                        NP_Cls.SqlSelect = "SELECT   m_Material.MaterialName, t_VendorInfoRecord.MaterialCode FROM t_VendorInfoRecord INNER JOIN m_Material ON t_VendorInfoRecord.MaterialCode = m_Material.MaterialCode WHERE  (t_VendorInfoRecord.VendorCode = N'" + this.cbVendor.Text.Trim().Split(':')[0] + "') AND ( t_VendorInfoRecord.MaterialCode = '" + NP_Cls.MRPFGSort + "')";
                        NP.BindCB(this.cbMaterial, NP_Cls.SqlSelect, "MaterialName", "MaterialCode", "((( Select Material )))"); this.cbMaterial.SelectedIndex = 1;
                        this.cbMaterial.Select(); this.cbMaterial.SelectAll();
                    }
                    else
                    {
                        NP_Cls.SqlSelect = "SELECT   m_Material.MaterialName, t_VendorInfoRecord.MaterialCode FROM t_VendorInfoRecord INNER JOIN m_Material ON t_VendorInfoRecord.MaterialCode = m_Material.MaterialCode WHERE  (t_VendorInfoRecord.VendorCode = N'" + this.cbVendor.Text.Trim().Split(':')[0] + "') ";
                        NP.BindCB(this.cbMaterial, NP_Cls.SqlSelect, "MaterialName", "MaterialCode", "((( Select Material )))");
                        this.cbMaterial.Select(); this.cbMaterial.SelectAll();
                    }
                }
                catch (Exception ex)
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Add Header : " + ex.Message); return;
                }
                finally
                {
                    if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                }
                //
            }
            else
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please select vendor first !!"); return;
            }
        }
        private void btnCancelPR_Click(object sender, EventArgs e)
        {
            if (NP.MSGB("Do you to cancel Purchase Request ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(Application.StartupPath + @"\DB\DB.ini"));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr;
                Tr = oConn.BeginTransaction();

                try
                {
                    SqlCommand cmdDel = new SqlCommand();
                    NP_Cls.SqlDel = "DELETE FROM t_PR WHERE (PRNumber = @PRNumber)";
                    cmdDel.Parameters.Add("@PRNumber", SqlDbType.NVarChar, 100).Value = this.txtPR.Text.Trim();
                    cmdDel.CommandText = NP_Cls.SqlDel; cmdDel.Connection = oConn; cmdDel.Transaction = Tr;
                    cmdDel.ExecuteNonQuery();

                    NP_Cls.SqlDel = "DELETE FROM t_PRDetail WHERE (PRNumber = @PRNumber)";
                    cmdDel.CommandText = NP_Cls.SqlDel; cmdDel.Connection = oConn; cmdDel.Transaction = Tr;
                    cmdDel.ExecuteNonQuery();

                    NP_Cls.SqlDel = "DELETE FROM t_MRPTranOrder WHERE (TranOrder = @PRNumber)";
                    cmdDel.CommandText = NP_Cls.SqlDel; cmdDel.Connection = oConn; cmdDel.Transaction = Tr;
                    cmdDel.ExecuteNonQuery();

                    Tr.Commit();
                    Clear(); this.groupPR.Enabled = true; this.cbMaterial.Text = string.Empty;
                    if (this.dsPR.Tables.Count > 0) { this.dsPR.Tables.Clear(); this.MyGrid(this.dgvView); }
                    this.cbMaterial.DataSource = null; this.btnAppr.Visible = false;
                    this.btnAddPR.Visible = true; this.btnSave.Visible = false;

                    BindVendor();
                    this.btnGenNew_Click(sender, e);
                    this.cbVendor.Text = string.Empty; this.cbVendor.Select();
                }
                catch (Exception ex)
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Delete : " + ex.Message);
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
        private void cbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.cbMaterial.SelectedIndex != 0) && (!string.IsNullOrEmpty(this.cbMaterial.Text.Trim())))
            {
                //NP_Cls.SqlSelect = "SELECT     t_VendorInfoRecord.MaterialCode, m_Material.MaterialName, m_Unit.UnitName, t_VendorInfoRecord.NetPrice, GETDATE() + t_VendorInfoRecord.DeliveryTime AS DeliveryDate, t_VendorInfoRecord.QtyConversion, m_Material.PlantCode, m_Material.LocCode, t_VendorInfoRecord.DeliveryTime FROM         t_VendorInfoRecord INNER JOIN m_Material ON t_VendorInfoRecord.MaterialCode = m_Material.MaterialCode INNER JOIN m_Unit ON t_VendorInfoRecord.UnitCode = m_Unit.UnitCode WHERE (t_VendorInfoRecord.VendorCode = N'" + this.cbVendor.Text.Trim() + "') AND (t_VendorInfoRecord.MaterialCode = N'" + this.cbMaterial.Text.Trim() +"')";
                //this.dsPR = NP.GetClientDataSet(NP_Cls.SqlSelect);
                //this.dgvView.DataSource = this.dsPR.Tables[0];
                this.lblMaterialName.Text = this.cbMaterial.SelectedValue.ToString();
            }
            else
            {
                this.lblMaterialName.Text = string.Empty;
                this.cbMaterial.Select();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            NP_Cls.myDecimal(sender, e);
        }
        private void dgvView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //if ((myDataGridView.Columns(e.ColumnIndex).Name == "ColumnName") 
            if (dgvView.CurrentCell.ColumnIndex == 3)
            {
                TextBox txtBox = e.Control as TextBox;
                txtBox.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
            }

            if (dgvView.CurrentCell.ColumnIndex == 8)
            {
                ((DateTimePicker)e.Control).Value = ((DateTime)this.dgvView[8, this.dgvView.CurrentRow.Index].Value);
            }
        }
        private void dgvView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.dsPR = CompareCondition(this.dsPR, this.dgvView.CurrentRow.Index); this.dgvView.DataSource = this.dsPR.Tables[0];
                this.dgvView.CurrentRow.Cells["clnQtyC"].Value = Convert.ToDecimal(this.dgvView.CurrentRow.Cells["clnQuantity"].Value) * decimal.Parse(this.dgvView.CurrentRow.Cells["clnQtyConversion"].Value.ToString());

                // Default NetPrice
                double dNetPrice = double.Parse(this.dgvView.CurrentRow.Cells["clnNetPrice"].Value.ToString());

                //Check Vendor
                NP_Cls.SqlSelect = "SELECT   t_VendorInfoRecord.VendorCode, t_VendorInfoRecord.MaterialCode, t_VendorInfoRecordPeriods.ValidOn, t_VendorInfoRecordPeriods.ValidTo,   t_VendorInfoRecordPeriodsDetail.ScaleQty, t_VendorInfoRecordPeriodsDetail.Rate FROM         t_VendorInfoRecord INNER JOIN   t_VendorInfoRecordPeriods ON t_VendorInfoRecord.VendorCode = t_VendorInfoRecordPeriods.VendorCode AND                        t_VendorInfoRecord.MaterialCode = t_VendorInfoRecordPeriods.MaterialCode INNER JOIN  t_VendorInfoRecordPeriodsDetail ON t_VendorInfoRecordPeriods.ValidPeriodCode = t_VendorInfoRecordPeriodsDetail.ValidPeriodCode WHERE     (t_VendorInfoRecord.VendorCode = N'" + this.cbVendor.Text.Trim().Split(':')[0] + "') AND (t_VendorInfoRecord.MaterialCode = N'" + this.dgvView.CurrentRow.Cells["clnMaterialCode"].Value.ToString() + "') AND  (CAST(CONVERT(nvarchar, t_VendorInfoRecordPeriods.ValidOn, 112) AS int) <= CAST(CONVERT(nvarchar, GETDATE(), 112) AS int)) AND (CAST(CONVERT(nvarchar, t_VendorInfoRecordPeriods.ValidTo, 112) AS int) >= CAST(CONVERT(nvarchar, GETDATE(), 112) AS int))  AND ('" + this.dgvView.CurrentRow.Cells["clnQuantity"].Value.ToString() + "' >= t_VendorInfoRecordPeriodsDetail.ScaleQty) ORDER BY t_VendorInfoRecordPeriodsDetail.ScaleQty DESC";

                DataSet dsPeriod = new DataSet();
                dsPeriod = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (dsPeriod.Tables[0].Rows.Count > 0)
                {
                    this.dgvView.CurrentRow.Cells["clnNetPrice"].Value = dsPeriod.Tables[0].Rows[0]["Rate"].ToString();
                }
                else
                {
                    this.dgvView.CurrentRow.Cells["clnNetPrice"].Value = dNetPrice;
                }

                this.dgvView.CurrentRow.Cells["clnAmount"].Value = (Convert.ToDecimal(this.dgvView.CurrentRow.Cells["clnNetPrice"].Value) * Convert.ToDecimal(this.dgvView.CurrentRow.Cells["clnQuantity"].Value));
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Edit Cell : " + ex.Message); return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.dgvView.RowCount == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please select material into PR list !!"); this.cbMaterial.Select(); return; }
            this.dgvView.EndEdit();
            for (byte ii = 0; ii < this.dgvView.RowCount; ii++)
            {
                if (Convert.ToInt32(this.dgvView["clnQuantity", ii].Value) == 0)
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Quantity for purchase more than 0 !!"); return;
                }
                if (String.IsNullOrEmpty(this.dgvView["clnPlantCode", ii].Value.ToString()) ||
                    String.IsNullOrEmpty(this.dgvView["clnPlantName", ii].Value.ToString()) ||
                    String.IsNullOrEmpty(this.dgvView["clnLocCode", ii].Value.ToString()) ||
                    String.IsNullOrEmpty(this.dgvView["clnLocName", ii].Value.ToString()))
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Plant and location require !!"); return;
                }
            }
            if (NP.MSGB("Do you to Save Purchase Request ?") == DialogResult.Yes)
            {
                if (Convert.ToBoolean(bView))
                {
                    this.strGNumber = this.txtPR.Text.Trim();
                    NP_Cls.SqlDel = "DELETE FROM t_PRDetail WHERE (PRNumber = '" + this.strGNumber + "')"; string strErr = string.Empty;
                    if (!NP.SqlCmd(NP_Cls.SqlDel, ref strErr))
                    {
                        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Update : " + strErr); return;
                    }
                }

                oConn = new SqlConnection(NP.ReadFileDB(Application.StartupPath + @"\DB\DB.ini"));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr;
                Tr = oConn.BeginTransaction();

                try
                {
                    SqlCommand cmdIns = new SqlCommand();
                    cmdIns.Parameters.Add("@PRNumber", SqlDbType.NVarChar, 12);
                    //if (Convert.ToBoolean(bView))
                    //{
                    //    this.strGNumber = this.txtPR.Text.Trim();
                    //    NP_Cls.SqlDel = "DELETE FROM t_PRDetail WHERE (PRNumber = @PRNumber)";
                    //    cmdIns.Parameters["@PRNumber"].Value = this.strGNumber;
                    //    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlDel; cmdIns.Transaction = Tr;
                    //    cmdIns.ExecuteNonQuery();
                    //}

                    NP_Cls.SqlInsert = "INSERT INTO t_PRDetail " +
                      "(PRNumber, MaterialCode, MaterialName, PRQuantity, UnitCode, UnitName, NetPrice, PRAmount, DeliveryDate, PlantCode, PlantName, LocCode, LocName, CurrentUser, QtyConversion) " +
"VALUES     (@PRNumber,@MaterialCode,@MaterialName,@PRQuantity,@UnitCode,@UnitName,@NetPrice,@PRAmount,@DeliveryDate,@PlantCode,@PlantName,@LocCode,@LocName,@CurrentUser,@QtyConversion)";

                    cmdIns.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15);
                    cmdIns.Parameters.Add("@MaterialName", SqlDbType.NVarChar, 60);
                    cmdIns.Parameters.Add("@PRQuantity", SqlDbType.Decimal);
                    cmdIns.Parameters.Add("@UnitCode", SqlDbType.NVarChar, 3);
                    cmdIns.Parameters.Add("@UnitName", SqlDbType.NVarChar, 20);
                    cmdIns.Parameters.Add("@NetPrice", SqlDbType.Decimal);
                    cmdIns.Parameters.Add("@PRAmount", SqlDbType.Decimal);
                    cmdIns.Parameters.Add("@DeliveryDate", SqlDbType.DateTime);
                    cmdIns.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 4);
                    cmdIns.Parameters.Add("@PlantName", SqlDbType.NVarChar, 20);
                    cmdIns.Parameters.Add("@LocCode", SqlDbType.NVarChar, 2);
                    cmdIns.Parameters.Add("@LocName", SqlDbType.NVarChar, 20);
                    cmdIns.Parameters.Add("@CurrentUser", SqlDbType.NVarChar, 50);
                    cmdIns.Parameters.Add("@QtyConversion", SqlDbType.Decimal);
                    for (byte ins = 0; ins < this.dgvView.RowCount; ins++)
                    {
                        cmdIns.Parameters["@PRNumber"].Value = this.strGNumber;
                        cmdIns.Parameters["@MaterialCode"].Value = this.dgvView["clnMaterialCode", ins].Value.ToString();
                        cmdIns.Parameters["@MaterialName"].Value = this.dgvView["clnMaterialName", ins].Value.ToString();
                        cmdIns.Parameters["@PRQuantity"].Value = Convert.ToDouble(this.dgvView["clnQuantity", ins].Value);
                        cmdIns.Parameters["@UnitCode"].Value = this.dgvView["clnUnitCode", ins].Value.ToString();
                        cmdIns.Parameters["@UnitName"].Value = this.dgvView["clnUnitName", ins].Value.ToString();
                        cmdIns.Parameters["@NetPrice"].Value = Convert.ToDouble(this.dgvView["clnNetPrice", ins].Value);
                        cmdIns.Parameters["@PRAmount"].Value = Convert.ToDouble(this.dgvView["clnAmount", ins].Value);
                        cmdIns.Parameters["@DeliveryDate"].Value = Convert.ToDateTime(this.dgvView["clnDeliveryDate", ins].Value);
                        cmdIns.Parameters["@PlantCode"].Value = this.dgvView["clnPlantCode", ins].Value.ToString();
                        cmdIns.Parameters["@PlantName"].Value = this.dgvView["clnPlantName", ins].Value.ToString();
                        cmdIns.Parameters["@LocCode"].Value = this.dgvView["clnLocCode", ins].Value.ToString();
                        cmdIns.Parameters["@LocName"].Value = this.dgvView["clnLocName", ins].Value.ToString();
                        cmdIns.Parameters["@CurrentUser"].Value = NP_Cls.strUsr;
                        cmdIns.Parameters["@QtyConversion"].Value = decimal.Parse(this.dgvView["clnQtyC", ins].Value.ToString());

                        cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                        cmdIns.ExecuteNonQuery();
                    }

                    //
                    if (NP_Cls.FromMRP == 1)
                    {
                        SqlCommand cmdMRP = new SqlCommand();
                        cmdMRP.Parameters.Add("@MatCode", SqlDbType.NVarChar, 15).Value = NP_Cls.MRPFGSort;
                        cmdMRP.Parameters.Add("@TranOrder", SqlDbType.NVarChar, 50).Value = this.txtPR.Text.Trim();
                        cmdMRP.Parameters.Add("@TranQty", SqlDbType.Decimal).Value = Convert.ToDouble(this.dgvView["clnQuantity", 0].Value);//NP_Cls.MRPQty;
                        cmdMRP.Parameters.Add("@SONumber", SqlDbType.NVarChar, 50).Value = NP_Cls.MRPSO;
                        NP_Cls.SqlInsert = "INSERT INTO t_MRPTranOrder (MaterialCode,TranOrder,TranQty,SONumber,MaterialHeader) VALUES (@MatCode,@TranOrder,@TranQty,@SONumber,@MatCode)";
                        cmdMRP.CommandText = NP_Cls.SqlInsert; cmdMRP.Connection = oConn;
                        cmdMRP.Transaction = Tr; cmdMRP.ExecuteNonQuery();

                        Tr.Commit();
                        NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Save Purchase Request Completed !! this screen will be close ..");
                        NP_Cls.MRPTranOrder = this.txtPR.Text.Trim(); this.Close(); return;
                    }
                    //

                    Tr.Commit(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Save Purchase Request Completed !!");
                    Clear();
                    this.groupPR.Enabled = true; this.btnAddPR.Visible = true; this.btnSave.Visible = false; this.cbMaterial.Text = string.Empty; this.cbMaterial.DataSource = null;
                    this.MyGrid(dgvView); this.txtPR.Text = GetNumber();

                    BindVendor();
                    this.cbVendor.Text = string.Empty; this.cbVendor.Select();
                }
                catch (Exception ex)
                {
                    if (oConn.State == ConnectionState.Open) { Tr.Rollback(); }
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Add Detail : " + ex.Message); return;
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
        protected Boolean CheckLocPlantIsNull()
        {
            for (byte ins = 0; ins < this.dgvView.RowCount; ins++)
            {
                if (String.IsNullOrEmpty(this.dgvView["clnPlantCode", ins].Value.ToString()) ||
                String.IsNullOrEmpty(this.dgvView["clnPlantName", ins].Value.ToString()) ||
                String.IsNullOrEmpty(this.dgvView["clnLocCode", ins].Value.ToString()) ||
                String.IsNullOrEmpty(this.dgvView["clnLocName", ins].Value.ToString()))
                {
                    return true;
                }
            }
            return false;
        }
        private void txtPR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //MessageBox.Show("Yo");
                NP_Cls.SqlSelect = "SELECT     0 AS ItemNo, t_PRDetail.MaterialCode, m_Material.MaterialName, t_PRDetail.PRQuantity AS Qty, m_Unit.UnitName, t_PRDetail.UnitCode,  t_PRDetail.NetPrice,  t_PRDetail.PRAmount AS Amt, t_PRDetail.DeliveryDate, m_Material.PlantCode, m_Material.LocCode, t_PR.PRApprove, t_PRDetail.isPO, t_PR.VendorCode FROM t_PR INNER JOIN t_PRDetail ON t_PR.PRNumber = t_PRDetail.PRNumber INNER JOIN  m_Unit ON t_PRDetail.UnitCode = m_Unit.UnitCode INNER JOIN  m_Material ON t_PRDetail.MaterialCode = m_Material.MaterialCode WHERE (t_PR.PRNumber = N'" + this.txtPR.Text.Trim() + "')";
                this.dsPR = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (this.dsPR.Tables[0].Rows.Count == 0) { this.dsPR.Tables.Clear(); this.MyGrid(dgvView); this.cbVendor.Enabled = true; this.cbVendor.Text = string.Empty; return; }
                bView = 1;
                for (byte ii = 0; ii < this.dsPR.Tables[0].Rows.Count; ii++)
                {
                    this.dsPR.Tables[0].Rows[ii]["ItemNo"] = Convert.ToInt32(ii + 1);
                }

                for (int i = 0; i < this.cbVendor.Items.Count; i++)
                {
                    if ((this.cbVendor.Items[i] as DataRowView).Row[1].ToString().Contains(this.dsPR.Tables[0].Rows[0]["VendorCode"].ToString()))
                    {
                        this.cbVendor.SelectedIndex = i; break;
                    }
                }

                this.dsPR.Tables[0].Columns.Remove("VendorCode"); this.cbVendor.Enabled = false;
                this.dsPR.AcceptChanges();
                this.dgvView.DataSource = this.dsPR.Tables[0];

                // Head
                this.btnAddPR.Visible = false; this.btnSave.Visible = false;
                // Detail
                this.cbMaterial.DataSource = null; this.cbMaterial.Text = string.Empty;

                if (Convert.ToBoolean(this.dsPR.Tables[0].Rows[0]["PRApprove"]))
                {
                    this.btnAppr.Visible = false; this.btnCancelPR.Visible = false;
                }
                else { this.btnAppr.Visible = true; this.btnCancelPR.Visible = true; }

                if (NP_Cls.AppPR == 1) { this.btnAppr.Visible = true; } else { this.btnAppr.Visible = false; }

                for (byte col = 0; col < this.dgvView.RowCount; col++)
                {
                    if (Convert.ToBoolean(this.dsPR.Tables[0].Rows[col]["isPO"]))
                    {
                        this.dgvView.Rows[col].DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                }
                this.dgvView.ClearSelection();
            }
        }
        private void btnAppr_Click(object sender, EventArgs e)
        {
            if (NP.MSGB("Do you want Approve Purchase Request ?") == DialogResult.Yes)
            {
                NP_Cls.sqlUpdate = "UPDATE t_PR SET PRApprove = 1, UserUpdate = '" + NP_Cls.strUsr + "', DateUpdate = GETDATE() WHERE (PRNumber = '" + this.txtPR.Text.Trim() + "')"; string strErr = string.Empty;
                if (!NP.SqlCmd(NP_Cls.sqlUpdate, ref strErr))
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Approve : " + strErr); return;
                }
                Clear(); this.txtPR.DropDownStyle = ComboBoxStyle.Simple; this.cbVendor.Enabled = true;
                this.groupPR.Enabled = true; this.btnAddPR.Visible = true; this.btnSave.Visible = false; this.cbMaterial.Text = string.Empty; this.cbMaterial.DataSource = null;
                this.MyGrid(dgvView); this.txtPR.Text = GetNumber(); this.btnAppr.Visible = false;
                this.cbVendor.Text = string.Empty; this.cbVendor.Select();

                //TODO 2013-02-02 Report PR


            }
            else
            {
                return;
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Clear(); this.txtPR.DropDownStyle = ComboBoxStyle.DropDownList; this.txtPR.Text = string.Empty; this.cbVendor.Text = string.Empty; cbVendor.Enabled = true;
            NP_Cls.SqlSelect = "SELECT DISTINCT t_PR.PRNumber, t_PR.PRNumber AS PRDis FROM    t_PR INNER JOIN  t_PRDetail ON t_PR.PRNumber = t_PRDetail.PRNumber WHERE     (t_PRDetail.isPO = 0)";
            NP.BindCB(this.txtPR, NP_Cls.SqlSelect, "PRNumber", "PRDis", "( Select PR Number )");
            this.groupPR.Enabled = true; this.btnAddPR.Visible = true; this.btnSave.Visible = false; this.cbMaterial.Text = string.Empty; this.cbMaterial.DataSource = null;
            this.MyGrid(dgvView); this.txtPR.Text = GetNumber(); this.btnAppr.Visible = false;
            this.txtPR.SelectedIndex = 0;
        }

        private void setQuatityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvView.Rows.Count == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data not found !!"); return; }
            this.dgvView.BeginEdit(true);
            this.dgvView.CurrentRow.Cells[4].Selected = true;
        }
        private void DeletetoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.dgvView.Rows.Count == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data not found !!"); return; }
            this.dsPR.Tables[0].Rows.RemoveAt(this.dgvView.CurrentRow.Index);
            this.dgvView.DataSource = this.dsPR.Tables[0];
        }
        private void btnGenNew_Click(object sender, EventArgs e)
        {
            Clear(); this.txtPR.DropDownStyle = ComboBoxStyle.Simple; this.cbVendor.Enabled = true;
            this.groupPR.Enabled = true; this.btnAddPR.Visible = true; this.btnSave.Visible = false; this.cbMaterial.Text = string.Empty; this.cbMaterial.DataSource = null;
            this.MyGrid(dgvView); this.txtPR.Text = GetNumber(); this.btnAppr.Visible = false;
            this.cbVendor.Text = string.Empty; this.cbVendor.Select();
        }
        private void txtPR_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.txtPR.SelectedIndex != 0)
            {
                NP_Cls.SqlSelect = "SELECT     0 AS ItemNo, t_PRDetail.MaterialCode, t_PRDetail.MaterialName, t_PRDetail.PRQuantity AS Qty, t_PRDetail.UnitCode, t_PRDetail.UnitName, t_PRDetail.NetPrice,                        t_PRDetail.PRAmount AS Amt, t_PRDetail.DeliveryDate, t_PRDetail.PlantCode, t_PRDetail.LocCode, t_PR.PRApprove, t_PRDetail.isPO, t_PRDetail.PlantName,                        t_PRDetail.LocName, t_PR.VendorCode, t_PR.VendorName, t_VendorInfoRecord.QtyConversion, 0.0 AS QtyC FROM         t_PR INNER JOIN                       t_PRDetail ON t_PR.PRNumber = t_PRDetail.PRNumber INNER JOIN                       t_VendorInfoRecord ON t_PR.VendorCode = t_VendorInfoRecord.VendorCode AND t_PRDetail.MaterialCode = t_VendorInfoRecord.MaterialCode  WHERE (t_PR.PRNumber = N'" + this.txtPR.Text.Trim() + "')";
                this.dsPR = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (this.dsPR.Tables[0].Rows.Count == 0) { this.dsPR.Tables.Clear(); this.MyGrid(dgvView); this.cbVendor.Enabled = true; this.cbVendor.Text = string.Empty; return; }
                bView = 1;
                for (byte ii = 0; ii < this.dsPR.Tables[0].Rows.Count; ii++)
                {
                    this.dsPR.Tables[0].Rows[ii]["ItemNo"] = Convert.ToInt32(ii + 1);
                }
                this.cbVendor.Text = this.dsPR.Tables[0].Rows[0]["VendorCode"].ToString() + ":" + this.dsPR.Tables[0].Rows[0]["VendorName"].ToString();
                this.dsPR.Tables[0].Columns.Remove("VendorCode"); this.dsPR.Tables[0].Columns.Remove("VendorName"); this.cbVendor.Enabled = false;
                this.dsPR.AcceptChanges();
                this.dgvView.DataSource = this.dsPR.Tables[0];

                // Head
                this.btnAddPR.Visible = false; this.btnSave.Visible = false;
                // Detail
                this.cbMaterial.DataSource = null; this.cbMaterial.Text = string.Empty;

                if (Convert.ToBoolean(this.dsPR.Tables[0].Rows[0]["PRApprove"]))
                {
                    this.btnAppr.Visible = false; this.btnCancelPR.Visible = false; this.btnSave.Visible = false;
                }
                else
                {
                    this.btnAppr.Visible = true; this.btnCancelPR.Visible = true; this.btnSave.Visible = true;
                    if (NP_Cls.AppPR == 1) { this.btnAppr.Visible = true; } else { this.btnAppr.Visible = false; }
                    NP_Cls.SqlSelect = "SELECT     m_Material.MaterialName, t_VendorInfoRecord.MaterialCode FROM t_VendorInfoRecord INNER JOIN m_Material ON t_VendorInfoRecord.MaterialCode = m_Material.MaterialCode WHERE  (t_VendorInfoRecord.VendorCode = N'" + this.cbVendor.Text.Trim().Split(':')[0] + "')";
                    NP.BindCB(this.cbMaterial, NP_Cls.SqlSelect, "MaterialName", "MaterialCode", "((( Select Material )))");
                    this.cbMaterial.Select();
                }


                for (byte col = 0; col < this.dgvView.RowCount; col++)
                {
                    if (Convert.ToBoolean(this.dsPR.Tables[0].Rows[col]["isPO"]))
                    {
                        this.dgvView.Rows[col].DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                }
                this.dgvView.ClearSelection();
            }
            else
            {
                this.groupPR.Enabled = true; this.btnAddPR.Visible = true; this.btnSave.Visible = false; this.cbMaterial.Text = string.Empty; this.cbMaterial.DataSource = null;
                this.MyGrid(dgvView); this.txtPR.Text = GetNumber(); this.btnAppr.Visible = false;
                this.txtPR.SelectedIndex = 0;
            }
        }

    }
}
