using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WMS.SaleTranSac
{
    public partial class frmDO : Form
    {
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection(); private byte bView = 0; private string strCurr = string.Empty;
        private string strGNumber = string.Empty; private DataSet dsPR = new DataSet(); private DataSet cloneDataSetFormAddBatch = new DataSet(); private string strPRref = string.Empty; private byte lessStock = 0;

        public DataSet dsBatch;

        public frmDO()
        {
            InitializeComponent();
        }
        private void MyGrid(DataGridView grid)
        {
            NP_Cls.SqlSelect = "SELECT     1 AS ItemNo,'' as BatchNumber,t_SODetail.DOQuantity, t_SODetail.MaterialCode, t_SODetail.MaterialName, t_SODetail.SOQuantity AS Qty, t_SODetail.UnitCode, t_SODetail.UnitName, t_SODetail.NetPrice, t_SODetail.SOAmount AS Amt, t_SODetail.DeliveryDate, t_SODetail.PlantCode, t_SODetail.PlantName, t_SODetail.LocCode, t_SODetail.LocName, t_SO.SONumber, t_SODetail.AutoID, t_StockOverview.UR, 0 as TmpSO FROM  t_SO INNER JOIN                       t_SODetail ON t_SO.SONumber = t_SODetail.SONumber LEFT OUTER JOIN t_StockOverview ON t_SODetail.MaterialCode = t_StockOverview.MaterialCode WHERE  (t_SO.SONumber = N'')";
            this.dsPR = NP.GetClientDataSet(NP_Cls.SqlSelect);
            grid.DataSource = this.dsPR.Tables[0];
        }
        protected void BindCBCustomer()
        {
            NP_Cls.SqlSelect = "SELECT     CustomerName, CustomerCode + ':' + CustomerName  AS CustomerCode  FROM   m_Customer WHERE (FileStatus = N'1') AND (CustomerCode IN (SELECT     CustomerCode                             FROM          t_SO   WHERE      (SOApprove = 1)))";
            NP.BindCB(this.cbCustomer, NP_Cls.SqlSelect, "CustomerName", "CustomerCode", "((( Select Customer SO )))");
        }
        protected void BindCBSONumber()
        {
            NP_Cls.SqlSelect = "SELECT SONumber, SONumber AS SODis FROM  t_SO WHERE  (SOApprove = N'1') AND (CustomerCode = '" + this.cbCustomer.Text.Trim().Split(':')[0].Trim() + "')";
            NP.BindCB(this.cbSO, NP_Cls.SqlSelect, "SONumber", "SODis", "((( Select SO Number )))");
        }
        private void frmDO_Load(object sender, EventArgs e)
        {
            try
            {
                this.dsBatch = new DataSet();
                
                WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
                frm.menuStrip1.Enabled = true;

                this.txtDO.Text = GetNumber(); this.txtDocDate.Text = NP.GetDateServer().ToString("dd/MM/yyyy");

                BindCBCustomer();

                this.MyGrid(dgvView);
                Clear();
                this.cbCustomer.Text = string.Empty; this.cbCustomer.Select();
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Load : " + ex.Message); return;
            }
        }
        private void Clear()
        {
            this.lblCustomer.Text = string.Empty; this.lblCurrency.Text = string.Empty;
            this.lblTerm.Text = string.Empty;
        }
        private string GetNumber()
        {
            try
            {
                bView = 0;
                NP_Cls.SqlSelect = "SELECT top (1) CONVERT(int, RIGHT(DONumber, 4)) AS SS, RIGHT(CONVERT(nvarchar, GETDATE(), 112), 6) AS s FROM   t_DO WHERE (RIGHT(CONVERT(nvarchar, GETDATE(), 112), 6) = LEFT(RIGHT(DONumber, 10), 6)) ORDER BY SS DESC";
                DataSet dsGen = new DataSet(); dsGen = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (dsGen.Tables[0].Rows.Count == 0)
                {
                    NP_Cls.SqlSelect = "SELECT  TOP (1) RIGHT(CONVERT(nvarchar, GETDATE(), 112), 6) AS s";
                    return "DO" + NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0].Rows[0][0].ToString() + "0001";
                }
                else
                {
                    string strCode = (Convert.ToInt16(dsGen.Tables[0].Rows[0][0].ToString()) + 1).ToString().PadLeft(4, '0');
                    return "DO" + dsGen.Tables[0].Rows[0][1].ToString() + strCode;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void cbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.cbCustomer.SelectedIndex != 0) && (!string.IsNullOrEmpty(this.cbCustomer.Text.Trim())))
            {
                this.lblCustomer.Text = this.cbCustomer.SelectedValue.ToString();
                DataSet dsDetail = new DataSet();
                try
                {
                    NP_Cls.SqlSelect = "SELECT     m_Customer.CustomerName, m_Customer.CustomerCode, m_Currency.CurrencyName, m_Customer.CurrencyCode, m_Customer.TermsOfPayment FROM m_Customer INNER JOIN m_Currency ON m_Customer.CurrencyCode = m_Currency.CurrencyCode WHERE  (m_Customer.FileStatus = N'1') AND (m_Customer.CustomerCode = N'" + this.cbCustomer.Text.Trim().Split(':')[0].Trim() + "')";
                    dsDetail = NP.GetClientDataSet(NP_Cls.SqlSelect);
                    this.lblCurrency.Text = dsDetail.Tables[0].Rows[0]["CurrencyName"].ToString();
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
                this.cbCustomer.Focus();
            }
        }
        private void btnAddSO_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(this.cbCustomer.Text.Trim())) && (this.cbCustomer.SelectedIndex != 0))
            {
                //
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open();

                try
                {
                    SqlCommand cmdIns = new SqlCommand();
                    NP_Cls.SqlInsert = "INSERT INTO t_DO " +
                      "(DONumber, DODate, CustomerCode, CustomerName, Terms, CurrencyCode, CurrencyName, Remark, UserCreate, DateCreate) " +
"VALUES     (@DONumber, GETDATE(),@CustomerCode,@CustomerName,@Terms,@CurrencyCode,@CurrencyName,@Remark,@UD, GETDATE())";
                    this.strGNumber = GetNumber();
                    cmdIns.Parameters.Add("@DONumber", SqlDbType.NVarChar, 12).Value = this.strGNumber;
                    cmdIns.Parameters.Add("@CustomerCode", SqlDbType.NVarChar, 10).Value = this.cbCustomer.Text.Trim().Split(':')[0].Trim();
                    cmdIns.Parameters.Add("@CustomerName", SqlDbType.NVarChar, 60).Value = this.lblCustomer.Text.Trim();
                    cmdIns.Parameters.Add("@Terms", SqlDbType.Decimal).Value = Convert.ToDecimal(this.lblTerm.Text.Trim());
                    cmdIns.Parameters.Add("@CurrencyCode", SqlDbType.NVarChar, 3).Value = this.strCurr;
                    cmdIns.Parameters.Add("@CurrencyName", SqlDbType.NVarChar, 20).Value = this.lblCurrency.Text.Trim();
                    cmdIns.Parameters.Add("@Remark", SqlDbType.NVarChar, 255).Value = this.txtRemark.Text.Trim();
                    cmdIns.Parameters.Add("@UD", SqlDbType.NVarChar, 50).Value = NP_Cls.strUsr;
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert;
                    cmdIns.ExecuteNonQuery();

                    this.groupPR.Enabled = false; this.btnAddSO.Visible = false; this.btnSave.Visible = true;
                    BindCBSONumber();
                    this.cbSO.Select(); this.cbSO.SelectAll();
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
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(this.bView))
            {
                if ((this.dsPR.Tables[0].Rows.Count > 0) || (this.groupPR.Enabled == false))
                {
                    if (NP.MSGB("The DO list will be cancel , Do you agree with this ?") == DialogResult.Yes)
                    {
                        // Cancel
                        NP_Cls.SqlDel = "DELETE FROM t_DO WHERE (DONumber = '" + this.txtDO.Text.Trim() + "')"; string strErr = string.Empty;
                        if (!NP.SqlCmd(NP_Cls.SqlDel, ref strErr))
                        {
                            NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Delete : " + strErr); return;
                        }
                        else
                        {
                            NP_Cls.SqlDel = "DELETE FROM t_DODetail WHERE (DONumber = '" + this.txtDO.Text.Trim() + "')";
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
                else
                {
                    if (NP.MSGB("Do you want to exit this screen ?") == DialogResult.Yes)
                    {
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
        private void frmDO_FormClosing(object sender, FormClosingEventArgs e)
        {
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;
        }
        private void btnCancelSO_Click(object sender, EventArgs e)
        {
            try
            {
                if (NP.MSGB("Do you to cancel Delivery Order ?") == DialogResult.Yes)
                {
                    NP_Cls.SqlDel = "DELETE FROM t_DO WHERE (DONumber = '" + this.txtDO.Text.Trim() + "')"; string strErr = string.Empty;
                    if (!NP.SqlCmd(NP_Cls.SqlDel, ref strErr))
                    {
                        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Delete : " + strErr); return;
                    }
                    else
                    {
                        NP_Cls.SqlDel = "DELETE FROM t_DODetail WHERE (DONumber = '" + this.txtDO.Text.Trim() + "')";
                        if (!NP.SqlCmd(NP_Cls.SqlDel, ref strErr))
                        {
                            NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Delete Detail : " + strErr); return;
                        }
                    }
                    for (byte ins = 0; ins < this.dgvView.RowCount; ins++)
                    {
                        string getSONumberID = this.dgvView["clnAutoID", ins].Value.ToString();
                        NP_Cls.SqlDel = "DELETE FROM tmp_DOforApprove WHERE (SONumber = '" + getSONumberID + "')"; string strErr1 = string.Empty;
                        if (!NP.SqlCmd(NP_Cls.SqlDel, ref strErr1))
                        {
                            NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Delete : " + strErr1); return;
                        }
                    }
                    Clear(); this.groupPR.Enabled = true; this.cbSO.Text = string.Empty;
                    if (this.dsPR.Tables.Count > 0) { this.dsPR.Tables.Clear(); this.MyGrid(this.dgvView); }
                    this.cbSO.DataSource = null;
                    this.btnAddSO.Visible = true; this.btnSave.Visible = false;
                    this.cbMaterial.DataSource = null; this.cbMaterial.Text = string.Empty;

                    BindCBCustomer();
                    this.cbCustomer.Text = string.Empty; this.cbCustomer.Select();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Cancel : " + ex.Message); return;
            }
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.cbSO.Text.Trim()) || (this.cbSO.SelectedIndex == 0))
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please add DO Header first !!");
                this.cbSO.Select(); this.cbSO.SelectAll();
                return;
            }
            else if (string.IsNullOrEmpty(this.cbMaterial.Text.Trim()) || (this.cbMaterial.SelectedIndex == 0))
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please select material first !!");
                this.cbMaterial.Select(); this.cbMaterial.SelectAll();
                return;
            }
            else
            {
                string strTmpCode = string.Empty; double dStock = 0.0;
                if (this.cbSO.SelectedIndex == 0)
                {
                    NP.ReqField(this.cbSO, "Please select SO Number first !!"); return;
                }
                else
                {
                    if (this.dsPR.Tables[0].Rows.Count > 0)
                    {
                        for (byte ii = 0; ii < this.dsPR.Tables[0].Rows.Count; ii++)
                        {
                            if (this.cbMaterial.SelectedValue.ToString() == this.dsPR.Tables[0].Rows[ii]["AutoID"].ToString())
                            {
                                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "This SO Number is in DO List !!"); this.cbSO.Select(); return;
                            }
                        }
                    }
                    else if (this.dsPR.Tables[0].Rows.Count == 0)
                    {
                        //
                        NP_Cls.SqlSelect = "SELECT     1 AS ItemNo,'' as BatchNumber,t_SODetail.DOQuantity, t_SODetail.MaterialCode, t_SODetail.MaterialName, isnull(t_SODetail.SOQuantity,0) - isnull(t_SODetail.DOQuantity,0) AS Qty, t_SODetail.UnitCode, t_SODetail.UnitName, t_SODetail.NetPrice, t_SODetail.SOAmount AS Amt, t_SODetail.DeliveryDate, t_SODetail.PlantCode, t_SODetail.PlantName, t_SODetail.LocCode, t_SODetail.LocName, t_SO.SONumber, t_SODetail.AutoID, ISNULL(t_StockOverview.UR,0) AS UR,t_SODetail.SOQuantity AS TmpSO FROM  t_SO INNER JOIN                       t_SODetail ON t_SO.SONumber = t_SODetail.SONumber LEFT OUTER JOIN t_StockOverview ON t_SODetail.MaterialCode = t_StockOverview.MaterialCode WHERE     (t_SODetail.AutoID = N'" + this.cbMaterial.SelectedValue + "') ORDER BY t_SODetail.MaterialCode, t_SODetail.DeliveryDate";
                        DataSet ds = new DataSet(); ds = NP.GetClientDataSet(NP_Cls.SqlSelect);
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            this.dsPR.Tables[0].ImportRow(item);
                        }
                        
                        //strTmpCode = string.Empty; dStock = 0.0;
                        //for (byte ii = 0; ii < this.dsPR.Tables[0].Rows.Count; ii++)
                        //{
                        //    this.dsPR.Tables[0].Rows[ii]["ItemNo"] = Convert.ToInt32(ii + 1);
                        //    //this.dsPR.Tables[0].Rows[ii]["Qty"] = Convert.ToDecimal(this.dsPR.Tables[0].Rows[ii]["Qty"]) - Convert.ToDecimal(this.dsPR.Tables[0].Rows[ii]["DOQuantity"]);
                        //    if (ii > 0)
                        //    {
                        //        if (this.dsPR.Tables[0].Rows[ii]["MaterialCode"].ToString().Trim().Contains(strTmpCode))
                        //        {
                        //            if (dStock > 0)
                        //            {
                        //                dStock -= double.Parse(this.dsPR.Tables[0].Rows[ii]["Qty"].ToString());
                        //            }
                        //            this.dsPR.Tables[0].Rows[ii]["UR"] = dStock;

                        //        }
                        //        else
                        //        {
                        //            dStock = double.Parse(this.dsPR.Tables[0].Rows[ii]["UR"].ToString());
                        //        }
                        //    }
                        //}
                        this.dsPR.AcceptChanges();
                        this.dgvView.DataSource = this.dsPR.Tables[0]; this.dgvView.ClearSelection();
                        return;
                        //
                    }

                    // if Row >  1
                    DataRow dr; dr = this.dsPR.Tables[0].NewRow();
                    NP_Cls.SqlSelect = "SELECT     1 AS ItemNo,'' as BatchNumber,t_SODetail.DOQuantity, t_SODetail.MaterialCode, t_SODetail.MaterialName, isnull(t_SODetail.SOQuantity,0) - isnull(t_SODetail.DOQuantity,0) AS Qty, t_SODetail.UnitCode, t_SODetail.UnitName, t_SODetail.NetPrice, t_SODetail.SOAmount AS Amt, t_SODetail.DeliveryDate, t_SODetail.PlantCode, t_SODetail.PlantName, t_SODetail.LocCode, t_SODetail.LocName, t_SO.SONumber, t_SODetail.AutoID, ISNULL(t_StockOverview.UR,0) AS UR,t_SODetail.SOQuantity AS TmpSO FROM  t_SO INNER JOIN                       t_SODetail ON t_SO.SONumber = t_SODetail.SONumber LEFT OUTER JOIN t_StockOverview ON t_SODetail.MaterialCode = t_StockOverview.MaterialCode WHERE     (t_SODetail.AutoID = N'" + this.cbMaterial.SelectedValue + "') ORDER BY t_SODetail.MaterialCode, t_SODetail.DeliveryDate";
                    DataSet ds2 = new DataSet(); ds2 = NP.GetClientDataSet(NP_Cls.SqlSelect);
                    foreach (DataRow item in ds2.Tables[0].Rows)
                    {
                        this.dsPR.Tables[0].ImportRow(item);
                    }
                    //strTmpCode = string.Empty; dStock = 0.0;
                    //for (byte ii = 0; ii < this.dsPR.Tables[0].Rows.Count; ii++)
                    //{
                    //    this.dsPR.Tables[0].Rows[ii]["ItemNo"] = Convert.ToInt32(ii + 1);
                    //    //this.dsPR.Tables[0].Rows[ii]["Qty"] = Convert.ToDecimal(this.dsPR.Tables[0].Rows[ii]["Qty"]) - Convert.ToDecimal(this.dsPR.Tables[0].Rows[ii]["DOQuantity"]);
                    //    if (ii > 0)
                    //    {
                    //        if (this.dsPR.Tables[0].Rows[ii]["MaterialCode"].ToString().Trim().Contains(strTmpCode))
                    //        {
                    //            if (dStock > 0)
                    //            {
                    //                dStock -= double.Parse(this.dsPR.Tables[0].Rows[ii]["Qty"].ToString());
                    //            }
                    //            this.dsPR.Tables[0].Rows[ii]["UR"] = dStock;

                    //        }
                    //        else
                    //        {
                    //            dStock = double.Parse(this.dsPR.Tables[0].Rows[ii]["UR"].ToString());
                    //        }
                    //    }
                    //}
                    this.dsPR.AcceptChanges();
                    this.dgvView.DataSource = this.dsPR.Tables[0]; this.dgvView.ClearSelection();
                }
            }
        }
        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvView.RowCount == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found !!"); return; }
            this.dgvView["clnQuantity", this.dgvView.CurrentRow.Index].Value = 0;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.dgvView.RowCount == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please select SO Number into DO list !!"); this.cbSO.Select(); return; }
            this.dgvView.EndEdit(); this.lessStock = 0;
                       
            for (byte ii = 0; ii < this.dgvView.RowCount; ii++)
            {
                // Check Not add batch number
                if (string.IsNullOrEmpty(this.dgvView["clnBatchNumber", ii].Value.ToString()))
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Mat.Code : " + this.dgvView["clnMaterialCode", ii].Value.ToString() + " dose not add Batch Number !!\nCannot DO. !!"); return;
                }

                // Check Quantity
                if (Convert.ToDouble(this.dgvView["clnQuantity", ii].Value) > Convert.ToDouble(this.dgvView["clnTmpSO", ii].Value))
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Mat.Code : " + this.dgvView["clnMaterialCode", ii].Value.ToString() + " is over SO Qty !!\nCannot DO. !!"); return;
                }
                else
                {
                    if (Convert.ToDouble(this.dgvView["clnQuantity", ii].Value) > Convert.ToDouble(this.dgvView["clnFGStock", ii].Value))
                    {
                        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Mat.Code : " + this.dgvView["clnMaterialCode", ii].Value.ToString() + " is over Stock !!\nCannot DO. !!"); return;
                    }
                    else if (Convert.ToDouble(this.dgvView["clnQuantity", ii].Value) <= Convert.ToDouble(this.dgvView["clnFGStock", ii].Value))
                    {
                        this.lessStock = 1;
                    }
                }                            

            }



            string strQuestion = string.Empty;
            if (this.lessStock == 0)
            {
                strQuestion = "Do you want to Save Delivery Order ?";
            }
            else
            {
                strQuestion = "Do you want to Save Delivery Order with less stock Material ?";
            }

            if (NP.MSGB(strQuestion) == DialogResult.Yes)
            {

                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr;
                Tr = oConn.BeginTransaction();

                try
                {
                    SqlCommand cmdIns = new SqlCommand(); SqlCommand cmdInsertTmpStock = new SqlCommand();
                    NP_Cls.SqlInsert = "INSERT INTO t_DODetail (DONumber, MaterialCode, MaterialName, DOQuantity, UnitCode, UnitName, NetPrice, DOAmount, DeliveryDate, PlantCode, PlantName, LocCode, LocName, CurrentUser, SONumber, SOAutoID) " +
"VALUES     (@DONumber,@MaterialCode,@MaterialName,@DOQuantity,@UnitCode,@UnitName,@NetPrice,@DOAmount,@DeliveryDate,@PlantCode,@PlantName,@LocCode,@LocName,@CurrentUser,@SONumber,@SOID)";
                    cmdIns.Parameters.Add("@DONumber", SqlDbType.NVarChar, 12);
                    cmdIns.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15);
                    cmdIns.Parameters.Add("@MaterialName", SqlDbType.NVarChar, 60);
                    cmdIns.Parameters.Add("@DOQuantity", SqlDbType.Decimal);
                    cmdIns.Parameters.Add("@UnitCode", SqlDbType.NVarChar, 3);
                    cmdIns.Parameters.Add("@UnitName", SqlDbType.NVarChar, 20);
                    cmdIns.Parameters.Add("@NetPrice", SqlDbType.Decimal);
                    cmdIns.Parameters.Add("@DOAmount", SqlDbType.Decimal);
                    cmdIns.Parameters.Add("@DeliveryDate", SqlDbType.DateTime);
                    cmdIns.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 4);
                    cmdIns.Parameters.Add("@PlantName", SqlDbType.NVarChar, 20);
                    cmdIns.Parameters.Add("@LocCode", SqlDbType.NVarChar, 2);
                    cmdIns.Parameters.Add("@LocName", SqlDbType.NVarChar, 20);
                    cmdIns.Parameters.Add("@CurrentUser", SqlDbType.NVarChar, 50);
                    cmdIns.Parameters.Add("@SONumber", SqlDbType.NVarChar, 12);
                    cmdIns.Parameters.Add("@SOID", SqlDbType.Int);

                    for (byte ins = 0; ins < this.dgvView.RowCount; ins++)
                    {
                        if (Convert.ToDecimal(this.dgvView["clnQuantity", ins].Value) <= Convert.ToDecimal(this.dgvView["clnFGStock", ins].Value))
                        {
                            cmdIns.Parameters["@DONumber"].Value = this.strGNumber;
                            cmdIns.Parameters["@MaterialCode"].Value = this.dgvView["clnMaterialCode", ins].Value.ToString();
                            cmdIns.Parameters["@MaterialName"].Value = this.dgvView["clnMaterialName", ins].Value.ToString();
                            cmdIns.Parameters["@DOQuantity"].Value = Convert.ToInt32(this.dgvView["clnQuantity", ins].Value);
                            cmdIns.Parameters["@UnitCode"].Value = this.dgvView["clnUnitCode", ins].Value.ToString();
                            cmdIns.Parameters["@UnitName"].Value = this.dgvView["clnUnitName", ins].Value.ToString();
                            cmdIns.Parameters["@NetPrice"].Value = Convert.ToDecimal(this.dgvView["clnNetPrice", ins].Value);
                            cmdIns.Parameters["@DOAmount"].Value = Convert.ToDecimal(this.dgvView["clnAmount", ins].Value);
                            cmdIns.Parameters["@CurrentUser"].Value = NP_Cls.strUsr;
                            cmdIns.Parameters["@DeliveryDate"].Value = Convert.ToDateTime(this.dgvView["clnDeliveryDate", ins].Value);
                            cmdIns.Parameters["@PlantCode"].Value = this.dgvView["clnPlantCode", ins].Value.ToString();
                            cmdIns.Parameters["@PlantName"].Value = this.dgvView["clnPlantName", ins].Value.ToString();
                            cmdIns.Parameters["@LocCode"].Value = this.dgvView["clnLocCode", ins].Value.ToString();
                            cmdIns.Parameters["@LocName"].Value = this.dgvView["clnLocName", ins].Value.ToString();
                            cmdIns.Parameters["@SONumber"].Value = this.dgvView["clnSONumber", ins].Value.ToString();
                            cmdIns.Parameters["@SOID"].Value = this.dgvView["clnAutoID", ins].Value.ToString();


                            cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                            cmdIns.ExecuteNonQuery();

                            NP_Cls.sqlUpdate = "UPDATE t_SODetail SET DOQuantity = DOQuantity + @DOQuantity WHERE (SONumber = @SONumber) AND (AutoID = @SOID)";
                            cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.sqlUpdate; cmdIns.Transaction = Tr;
                            cmdIns.ExecuteNonQuery();

                        }
                    }
                    #region Insert tmp for do
                    NP_Cls.SqlInsert = "INSERT INTO [tmp_DOforApprove] (SONumber ,BatchNumber ,Qty, SOAutoID) VALUES (@SONumber, @BatchNumber, @Qty, @SOAutoID)";
                    cmdInsertTmpStock.Parameters.Add("@SONumber", SqlDbType.NVarChar, 12);
                    cmdInsertTmpStock.Parameters.Add("@BatchNumber", SqlDbType.NVarChar, 10);
                    cmdInsertTmpStock.Parameters.Add("@SOAutoID", SqlDbType.Int);
                    cmdInsertTmpStock.Parameters.Add("@Qty", SqlDbType.Decimal);
                    for (int i = 0; i < this.dsBatch.Tables[0].Rows.Count; i++)
                    {
                        cmdInsertTmpStock.Parameters["@SONumber"].Value = this.dsBatch.Tables[0].Rows[i]["SONumber"].ToString();
                        cmdInsertTmpStock.Parameters["@BatchNumber"].Value = this.dsBatch.Tables[0].Rows[i]["BatchNumber"].ToString();
                        cmdInsertTmpStock.Parameters["@SOAutoID"].Value = this.dsBatch.Tables[0].Rows[i]["SOAutoID"].ToString();
                        cmdInsertTmpStock.Parameters["@Qty"].Value = Convert.ToDecimal(this.dsBatch.Tables[0].Rows[i]["Qty"]);
                        cmdInsertTmpStock.Connection = oConn; cmdInsertTmpStock.CommandText = NP_Cls.SqlInsert; cmdInsertTmpStock.Transaction = Tr;
                        cmdInsertTmpStock.ExecuteNonQuery();
                    }
                    #endregion


                    if (this.lessStock == 0)
                    {
                        strQuestion = "Save Delivery Order Completed !!";
                    }
                    else
                    {
                        strQuestion = "Save Delivery Order with less stock Material Completed !!";
                    }
                    Tr.Commit(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, strQuestion);
                    Clear();
                    this.groupPR.Enabled = true; this.btnAddSO.Visible = true; this.btnSave.Visible = false; this.cbSO.Text = string.Empty; this.cbSO.DataSource = null; this.cbMaterial.DataSource = null; this.cbMaterial.Text = string.Empty;
                    this.dsPR.Tables.Clear(); this.MyGrid(dgvView); this.txtDO.DropDownStyle = ComboBoxStyle.Simple;
                    BindCBCustomer();
                    this.cbCustomer.Enabled = true; this.txtDO.Text = GetNumber(); this.btnAppr.Visible = false;
                    this.cbCustomer.Text = string.Empty; this.cbCustomer.Select(); this.cbCustomer.SelectAll();
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Clear(); this.txtDO.DropDownStyle = ComboBoxStyle.DropDownList; this.txtDO.Text = string.Empty; this.cbCustomer.Text = string.Empty; cbCustomer.Enabled = true;
            NP_Cls.SqlSelect = "SELECT DONumber, DONumber AS DODis FROM t_DO";
            NP.BindCB(this.txtDO, NP_Cls.SqlSelect, "DONumber", "DODis", "( Select DO Number )");
            this.groupPR.Enabled = true; this.btnAddSO.Visible = false; this.btnSave.Visible = false; this.cbSO.Text = string.Empty; this.cbSO.DataSource = null; this.cbMaterial.DataSource = null; this.cbMaterial.Text = string.Empty;
            this.MyGrid(dgvView); this.txtDO.Text = GetNumber(); this.btnAppr.Visible = false;
            this.txtDO.SelectedIndex = 0;
        }
        private void btnGenNew_Click(object sender, EventArgs e)
        {
            Clear(); this.txtDO.DropDownStyle = ComboBoxStyle.Simple; this.cbCustomer.Enabled = true;
            this.groupPR.Enabled = true; this.btnAddSO.Visible = true; this.btnSave.Visible = false; this.cbSO.Text = string.Empty; this.cbSO.DataSource = null; this.cbMaterial.DataSource = null; this.cbMaterial.Text = string.Empty;
            this.dsPR.Tables.Clear(); this.MyGrid(dgvView); this.txtDO.Text = GetNumber();
            this.cbCustomer.Text = string.Empty; this.cbCustomer.Select();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            NP_Cls.myInteger(sender, e);

        }

        private void dgvView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.dgvView.CurrentRow.Cells["clnAmount"].Value = Convert.ToInt32(this.dgvView.CurrentRow.Cells["clnNetPrice"].Value) * Convert.ToInt32(this.dgvView.CurrentRow.Cells["clnQuantity"].Value); (sender as DataGridView).ClearSelection();
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Edit Cell : " + ex.Message); return;
            }
        }
        private void dgvView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvView.CurrentCell.ColumnIndex == 3)
            {
                TextBox txtBox = e.Control as TextBox;
                txtBox.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
            }
        }
        private void txtDO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.txtDO.SelectedIndex != 0)
            {
                NP_Cls.SqlSelect = "SELECT     1 AS ItemNo,'' as BatchNumber,t_SODetail.DOQuantity, t_DODetail.MaterialCode, t_DODetail.MaterialName, t_DODetail.DOQuantity AS Qty, t_DODetail.UnitCode, t_DODetail.UnitName,           t_DODetail.NetPrice, t_DODetail.DOAmount AS Amt, t_DODetail.DeliveryDate, t_DODetail.PlantCode, t_DODetail.PlantName, t_DODetail.LocCode, t_DODetail.LocName, t_DODetail.SONumber, t_DODetail.SOAutoID AS AutoID, t_DO.DOApprove, t_DO.CustomerCode, ISNULL(t_StockOverview.UR, 0) AS UR, t_SODetail.SOQuantity AS TmpSO FROM   t_DO INNER JOIN       t_DODetail ON t_DO.DONumber = t_DODetail.DONumber INNER JOIN    t_StockOverview ON t_DODetail.MaterialCode = t_StockOverview.MaterialCode INNER JOIN              t_SODetail ON t_DODetail.SONumber = t_SODetail.SONumber AND t_DODetail.SOAutoID = t_SODetail.AutoID WHERE (t_DO.DONumber = N'" + this.txtDO.Text.Trim() + "')";
                this.dsPR = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (this.dsPR.Tables[0].Rows.Count == 0) { this.dsPR.Tables.Clear(); this.MyGrid(dgvView); this.cbCustomer.Enabled = true; this.cbCustomer.Text = string.Empty; return; }
                bView = 1;
                for (byte ii = 0; ii < this.dsPR.Tables[0].Rows.Count; ii++)
                {
                    this.dsPR.Tables[0].Rows[ii]["ItemNo"] = Convert.ToInt32(ii + 1);
                }
                this.cbCustomer.Text = this.dsPR.Tables[0].Rows[0]["CustomerCode"].ToString();
                this.dsPR.Tables[0].Columns.Remove("CustomerCode"); this.cbCustomer.Enabled = false;
                bool bTmp = Convert.ToBoolean(this.dsPR.Tables[0].Rows[0]["DOApprove"]);
                this.dsPR.Tables[0].Columns.Remove("DOApprove");
                this.dsPR.AcceptChanges();
                DataSet dsTmp = new DataSet(); dsTmp = this.dsPR;
                if (!bTmp)
                {
                    this.btnAppr.Visible = true; this.btnCancelSO.Visible = true; this.btnSave.Visible = true;
                    BindCBSONumber();
                    this.cbSO.Select(); this.cbSO.SelectAll();
                }
                else
                {
                    this.btnAppr.Visible = false; this.btnCancelSO.Visible = false; this.btnSave.Visible = false;
                }
                this.dgvView.DataSource = dsTmp.Tables[0];

                // Head
                this.btnAddSO.Visible = false;
                // Detail
            }
        }
        private void btnAppr_Click(object sender, EventArgs e)
        {
            if (NP.MSGB("Do you want Approve Delivery Order ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr;
                Tr = oConn.BeginTransaction();

                try
                {
                    SqlCommand cmdUpdateStock = new SqlCommand();
                    cmdUpdateStock.Parameters.Add("@Qty", SqlDbType.Decimal);
                    cmdUpdateStock.Parameters.Add("@BatchNumber", SqlDbType.NVarChar, 15);
                    cmdUpdateStock.Parameters.Add("@outputInt", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cmdUpdateStock.Connection = oConn;
                    cmdUpdateStock.CommandType = CommandType.StoredProcedure;
                    
                    for (byte ins = 0; ins < this.dgvView.RowCount; ins++)
                    {
                        string getSONumberID = this.dgvView["clnAutoID", ins].Value.ToString();

                        NP_Cls.SqlSelect = "SELECT SONumber, BatchNumber, Qty FROM tmp_DOforApprove WHERE (SOAutoID = N'" + getSONumberID + "')";
                        DataSet ds = new DataSet(); ds = NP.GetClientDataSet(NP_Cls.SqlSelect);

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            cmdUpdateStock.Parameters["@Qty"].Value = ds.Tables[0].Rows[i]["Qty"].ToString();
                            cmdUpdateStock.Parameters["@BatchNumber"].Value = ds.Tables[0].Rows[i]["BatchNumber"].ToString();
                            cmdUpdateStock.CommandText = "UpdateStockWhenApproveDO";
                            cmdUpdateStock.Transaction = Tr;
                            cmdUpdateStock.ExecuteNonQuery();
                            if (Convert.ToInt32(cmdUpdateStock.Parameters["@OutputInt"].Value) != 1)
                            {
                                Tr.Rollback();
                            }
                        }
                        NP_Cls.SqlDel = "DELETE FROM tmp_DOforApprove WHERE (SOAutoID = '" + getSONumberID + "')"; string strErr1 = string.Empty;
                        if (!NP.SqlCmd(NP_Cls.SqlDel, ref strErr1))
                        {
                            NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Delete : " + strErr1); return;
                        }
                    }

                    Tr.Commit();
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

                NP_Cls.sqlUpdate = "UPDATE t_DO SET DOApprove = 1, UserUpdate = '" + NP_Cls.strUsr + "', DateUpdate = GETDATE() WHERE (DONumber = '" + this.txtDO.Text.Trim() + "')"; string strErr = string.Empty;
                if (!NP.SqlCmd(NP_Cls.sqlUpdate, ref strErr))
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Approve : " + strErr); return;
                }

                Clear(); this.txtDO.DropDownStyle = ComboBoxStyle.Simple; this.cbCustomer.Enabled = true;
                this.groupPR.Enabled = true; this.btnAddSO.Visible = true; this.btnSave.Visible = false; this.cbSO.Text = string.Empty; this.cbSO.DataSource = null; this.cbMaterial.DataSource = null; this.cbMaterial.Text = string.Empty;
                this.MyGrid(dgvView); this.txtDO.Text = GetNumber(); this.btnAppr.Visible = false;
                this.cbCustomer.Text = string.Empty; this.cbCustomer.Select(); this.cbCustomer.SelectAll();
            }
            else
            {
                return;
            }
        }

        private void dgvView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((sender as DataGridView).Columns[e.ColumnIndex].Name == "clnQuantity")
            {
                if (e.Value != null)
                {
                    if (!string.IsNullOrEmpty((sender as DataGridView).Rows[e.RowIndex].Cells["clnBatchNumber"].Value.ToString().Trim()))
                        if (Convert.ToDouble((sender as DataGridView).Rows[e.RowIndex].Cells["clnQuantity"].Value) > Convert.ToDouble((sender as DataGridView).Rows[e.RowIndex].Cells["clnFGStock"].Value))
                        {
                            e.CellStyle.BackColor = Color.OrangeRed;
                        }
                        else
                        {
                            if (Convert.ToDouble((sender as DataGridView).Rows[e.RowIndex].Cells["clnQuantity"].Value) > Convert.ToDouble((sender as DataGridView).Rows[e.RowIndex].Cells["clnTmpSO"].Value))
                            {
                                e.CellStyle.BackColor = Color.PaleVioletRed;
                            }
                            else
                            {
                                e.CellStyle.BackColor = Color.PaleGreen;
                            }
                        }
                }
            }
        }
        private void cbSO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbSO.SelectedIndex > 0)
            {
                NP_Cls.SqlSelect = "select  CONVERT(nvarchar, AutoID) as AValue,[MaterialCode] + ' : ' + CONVERT(VARCHAR(10), [DeliveryDate], 104) as AText from  [t_SODetail] where [SONumber] = N'" + this.cbSO.Text.Trim() + "' And DOQuantity < SOQuantity";
                NP.BindCB(this.cbMaterial, NP_Cls.SqlSelect, "AValue", "AText", "((( Select Masterial )))");
            }
        }

        // Selected Batch to DO.
        private void dgvView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((sender as DataGridView).RowCount == 0) { return; }

            NP_Cls.autoIDDO = (sender as DataGridView).SelectedRows[0].Cells["clnAutoID"].Value.ToString();
            NP_Cls.SONumberForDO = (sender as DataGridView).SelectedRows[0].Cells["clnSONumber"].Value.ToString();
            NP_Cls.MatCodeForDO = (sender as DataGridView).SelectedRows[0].Cells["clnMaterialCode"].Value.ToString();
            SaleTranSac.AddBatchDO frm = new WMS.SaleTranSac.AddBatchDO();
            frm.StartPosition = FormStartPosition.CenterParent; frm.FormBorderStyle = FormBorderStyle.Sizable; frm.ControlBox = true;

            if (this.dsBatch.Tables.Count == 0)
            {
                dsBatch = MyGrid().Clone();
            }

            frm.dsOverview = this.dsBatch.Copy(); 
            frm.ShowDialog();
            this.dsBatch = new DataSet();
            this.dsBatch = frm.dsOverview.Copy();

            if (this.dsBatch.Tables[0].Rows.Count > 0)
            {
                decimal SumQty = 0M;
                for (int i = 0; i < this.dsBatch.Tables[0].Rows.Count; i++)
                {
                    if (this.dsBatch.Tables[0].Rows[i]["SOAutoID"].ToString() == NP_Cls.autoIDDO)
                    {
                        SumQty = SumQty + Convert.ToDecimal(this.dsBatch.Tables[0].Rows[i]["Qty"]);
                    }
                }
                for (int i = 0; i < dsPR.Tables[0].Rows.Count; i++)
                {
                    if (dsPR.Tables[0].Rows[i]["AutoID"].ToString() == NP_Cls.autoIDDO)
                    {
                        dsPR.Tables[0].Rows[i]["Qty"] = SumQty.ToString("#.###");
                        dsPR.Tables[0].Rows[i]["BatchNumber"] = "Already Selected";
                        break;
                    }
                }

                //cloneDataSetFormAddBatch = this.dsBatch.Clone();
                //foreach (DataRow item in frm.dsOverview.Tables[0].Rows)
                //{
                //    this.cloneDataSetFormAddBatch.Tables[0].ImportRow(item);
                //}
                dsPR.AcceptChanges();

                this.dgvView.DataSource = dsPR.Tables[0];
                this.dgvView.ClearSelection();
            }
        }

        //Add Batch
        private DataSet MyGrid()
        {
            DataSet ds = new DataSet();
            NP_Cls.SqlSelect = "SELECT BatchNumber, 0 AS Qty, '' as SOAutoID, '' as SONumber FROM t_StockOverview WHERE (BatchNumber = N' ')";
            ds = NP.GetClientDataSet(NP_Cls.SqlSelect);
            return ds;
        }
    }
}
