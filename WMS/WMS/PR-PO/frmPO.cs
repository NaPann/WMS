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
    public partial class frmPO : Form
    {
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection(); private byte bView = 0; private string strCurr = string.Empty;
        private string strGNumber = string.Empty; private DataSet dsPR = new DataSet(); private string strPRref = string.Empty;
        private void MyGrid(DataGridView grid)
        {
            NP_Cls.SqlSelect = "SELECT     t_PRDetail.AutoID,1 AS ItemNo, t_PRDetail.MaterialCode, t_PRDetail.MaterialName, t_PRDetail.PRQuantity AS Qty, t_PRDetail.UnitCode, t_PRDetail.UnitName, t_PRDetail.NetPrice, t_PRDetail.PRAmount AS Amt, t_PRDetail.DeliveryDate, t_PR.PRNumber, t_PRDetail.PlantCode, t_PRDetail.PlantName, t_PRDetail.LocCode, t_PRDetail.LocName FROM t_PRDetail INNER JOIN t_PR ON t_PRDetail.PRNumber = t_PR.PRNumber WHERE     (t_PRDetail.MaterialCode = N'') AND (t_PR.VendorCode = N'')";
            this.dsPR = NP.GetClientDataSet(NP_Cls.SqlSelect);
            grid.DataSource = this.dsPR.Tables[0];
        }
        public frmPO()
        {
            InitializeComponent();
        }
        private void frmPO_Load(object sender, EventArgs e)
        {
            try
            {
                //WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
                //frm.menuStrip1.Enabled = true;

                this.txtPR.Text = GetNumber(); this.txtDocDate.Text = NP.GetDateServer().ToString("dd/MM/yyyy");

                BindVendor();

                this.MyGrid(dgvView);
                Clear();
                this.cbVendor.Text = string.Empty; this.cbVendor.Select();
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Load : " + ex.Message); return;
            }
        }
        private void Clear()
        {
            this.lblVendorName.Text = string.Empty; this.lblCurrency.Text = string.Empty; this.lblMaterialName.Text = string.Empty;
            this.lblPG.Text = string.Empty; this.lblTerm.Text = string.Empty; this.lblUserCreate.Text = string.Empty;
            this.btnClosePO.Visible = false;
        }
        private string GetNumber()
        {
            try
            {
                bView = 0; 
                NP_Cls.SqlSelect = "SELECT top (1) CONVERT(int, RIGHT(PONumber, 4)) AS SS, RIGHT(CONVERT(nvarchar, GETDATE(), 112), 6) AS s FROM   t_PO WHERE (RIGHT(CONVERT(nvarchar, GETDATE(), 112), 6) = LEFT(RIGHT(PONumber, 10), 6)) ORDER BY SS DESC";
                DataSet dsGen = new DataSet(); dsGen = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (dsGen.Tables[0].Rows.Count == 0)
                {
                    NP_Cls.SqlSelect = "SELECT  TOP (1) RIGHT(CONVERT(nvarchar, GETDATE(), 112), 6) AS s";
                    return "PO" + NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0].Rows[0][0].ToString() + "0001";
                }
                else
                {
                    //string strCode = (Convert.ToInt16(dsGen.Tables[0].Rows[0][0].ToString()) + 1).ToString().PadLeft(5 - (Convert.ToInt16(dsGen.Tables[0].Rows[0][0].ToString()) + 1).ToString().Length, '0');
                    string strCode = (Convert.ToInt16(dsGen.Tables[0].Rows[0][0].ToString()) + 1).ToString().PadLeft(4, '0');
                    return "PO" + dsGen.Tables[0].Rows[0][1].ToString() + strCode;
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
                    NP_Cls.SqlSelect = "SELECT     m_Vendor.VendorCode, m_Vendor.PurchasingGroup, m_Vendor.TermsOfPayment, m_Currency.CurrencyName, t_PR.UserCreate,m_Vendor.CurrencyCode FROM         m_Vendor INNER JOIN m_Currency ON m_Vendor.CurrencyCode = m_Currency.CurrencyCode INNER JOIN t_PR ON m_Vendor.VendorCode = t_PR.VendorCode WHERE (m_Vendor.VendorCode = N'" + this.cbVendor.Text.Trim().Split(':')[0] +"')";
                    dsDetail = NP.GetClientDataSet(NP_Cls.SqlSelect);
                    this.lblCurrency.Text = dsDetail.Tables[0].Rows[0]["CurrencyName"].ToString();
                    this.lblPG.Text = dsDetail.Tables[0].Rows[0]["PurchasingGroup"].ToString();
                    this.lblTerm.Text = dsDetail.Tables[0].Rows[0]["TermsOfPayment"].ToString();
                    this.lblUserCreate.Text = dsDetail.Tables[0].Rows[0]["UserCreate"].ToString();
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
                    if (NP.MSGB("The PO list will be cancel , Do you agree with this ?") == DialogResult.Yes)
                    {
                        // Cancel
                        oConn = new SqlConnection(NP.ReadFileDB(Application.StartupPath + @"\DB\DB.ini"));
                        if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                        oConn.Open(); SqlTransaction Tr;
                        Tr = oConn.BeginTransaction();

                        try
                        {
                            SqlCommand cmd = new SqlCommand();
                            NP_Cls.SqlDel = "DELETE FROM t_PO WHERE (PONumber = @DocNumber)";
                            cmd.Parameters.Add("@DocNumber", SqlDbType.NVarChar, 12).Value = this.txtPR.Text.Trim();
                            cmd.CommandText = NP_Cls.SqlDel; cmd.Connection = oConn; cmd.Transaction = Tr;
                            cmd.ExecuteNonQuery();

                            NP_Cls.SqlDel = "DELETE FROM t_PODetail WHERE (PONumber = @DocNumber)";
                            cmd.CommandText = NP_Cls.SqlDel; cmd.Connection = oConn; cmd.Transaction = Tr;
                            cmd.ExecuteNonQuery();

                            Tr.Commit();
                        }
                        catch (Exception ex)
                        {
                            NP.MSGB(NP_Cls.NPMgsStyle.ErrorType, "Del : " + ex.Message);
                        }
                        finally
                        {
                            if (oConn.State == ConnectionState.Open) { oConn.Close(); }
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
        private void frmPO_FormClosing(object sender, FormClosingEventArgs e)
        {
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.cbMaterial.Text.Trim()))
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please add PO Header first !!"); return;
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
                        for (byte ii = 0; ii < this.dsPR.Tables[0].Rows.Count; ii++)
                        {
                            if ((this.cbMaterial.Text.Trim().Split(':')[1].ToString() == this.dsPR.Tables[0].Rows[ii]["MaterialCode"].ToString()) && (this.cbMaterial.Text.Trim().Split(':')[0].ToString() == this.dsPR.Tables[0].Rows[ii]["PRNumber"].ToString()))
                            {
                                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "This material is in PO List !!"); this.cbMaterial.Select(); return;
                            }
                        }
                    }
                    else if (this.dsPR.Tables[0].Rows.Count == 0)
                    {
                        //
                        NP_Cls.SqlSelect = "SELECT     t_PRDetail.AutoID,1 AS ItemNo, t_PRDetail.MaterialCode, t_PRDetail.MaterialName, t_PRDetail.PRQuantity AS Qty, t_PRDetail.UnitCode, t_PRDetail.UnitName, t_PRDetail.NetPrice, t_PRDetail.PRAmount AS Amt, t_PRDetail.DeliveryDate, t_PR.PRNumber, t_PRDetail.PlantCode, t_PRDetail.PlantName, t_PRDetail.LocCode, t_PRDetail.LocName FROM t_PRDetail INNER JOIN t_PR ON t_PRDetail.PRNumber = t_PR.PRNumber WHERE  (t_PRDetail.MaterialCode = N'" + this.cbMaterial.Text.Trim().Split(':')[1].ToString() + "') AND (t_PR.VendorCode = N'" + this.cbVendor.Text.Trim().Split(':')[0] + "') AND (t_PR.PRNumber = N'" + this.cbMaterial.Text.Trim().Split(':')[0].ToString() + "')";
                        DataSet ds = new DataSet(); ds = NP.GetClientDataSet(NP_Cls.SqlSelect);
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            this.dsPR.Tables[0].ImportRow(item);
                        }
                        for (byte ii = 0; ii < this.dsPR.Tables[0].Rows.Count; ii++)
                        {
                            this.dsPR.Tables[0].Rows[ii]["ItemNo"] = Convert.ToInt32(ii + 1);
                        }
                        this.dsPR.AcceptChanges();                     
                        this.dgvView.DataSource = this.dsPR.Tables[0];
                        return;
                        //
                    }

                    // if Row >  1
                    DataRow dr; dr = this.dsPR.Tables[0].NewRow();
                    NP_Cls.SqlSelect = "SELECT     t_PRDetail.AutoID,1 AS ItemNo, t_PRDetail.MaterialCode, t_PRDetail.MaterialName, t_PRDetail.PRQuantity AS Qty, t_PRDetail.UnitCode, t_PRDetail.UnitName, t_PRDetail.NetPrice, t_PRDetail.PRAmount AS Amt, t_PRDetail.DeliveryDate, t_PR.PRNumber, t_PRDetail.PlantCode, t_PRDetail.PlantName, t_PRDetail.LocCode, t_PRDetail.LocName FROM t_PRDetail INNER JOIN t_PR ON t_PRDetail.PRNumber = t_PR.PRNumber WHERE  (t_PRDetail.MaterialCode = N'" + this.cbMaterial.Text.Trim().Split(':')[1].ToString() + "') AND (t_PR.VendorCode = N'" + this.cbVendor.Text.Trim().Split(':')[0] + "') AND (t_PR.PRNumber = N'" + this.cbMaterial.Text.Trim().Split(':')[0].ToString() + "')";
                    DataSet ds2 = new DataSet(); ds2 = NP.GetClientDataSet(NP_Cls.SqlSelect);
                    foreach (DataRow item in ds2.Tables[0].Rows)
                    {
                        this.dsPR.Tables[0].ImportRow(item);
                    }
                    for (byte ii = 0; ii < this.dsPR.Tables[0].Rows.Count; ii++)
                    {
                        this.dsPR.Tables[0].Rows[ii]["ItemNo"] = Convert.ToInt32(ii + 1);
                    }
                    this.dsPR.AcceptChanges();
                    this.dgvView.DataSource = this.dsPR.Tables[0];
                }
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

                //NP_Cls.SqlSelect = "SELECT PRNumber FROM t_PR WHERE (VendorCode)"

                try
                {
                    SqlCommand cmdIns = new SqlCommand();
                    NP_Cls.SqlInsert = "INSERT INTO t_PO "+
                      "(PONumber, PODate, VendorCode, VendorName, PurchasingGroup, Terms, CurrencyCode, CurrencyName, Remark, UserCreate, DateCreate) "+
"VALUES     (@PONumber, GETDATE(),@VendorCode,@VendorName,@PurchasingGroup,@Terms,@CurrencyCode,@CurrencyName,@Remark,@UD, GETDATE())";
                    this.strGNumber = GetNumber();
                    cmdIns.Parameters.Add("@PONumber", SqlDbType.NVarChar, 12).Value = this.strGNumber;
                    cmdIns.Parameters.Add("@VendorCode", SqlDbType.NVarChar, 10).Value = this.cbVendor.Text.Trim().Split(':')[0];
                    cmdIns.Parameters.Add("@VendorName", SqlDbType.NVarChar, 60).Value = this.lblVendorName.Text.Trim();
                    cmdIns.Parameters.Add("@PurchasingGroup", SqlDbType.NVarChar, 3).Value = this.lblPG.Text.Trim();
                    cmdIns.Parameters.Add("@Terms", SqlDbType.Decimal).Value = Convert.ToDouble(this.lblTerm.Text.Trim());
                    cmdIns.Parameters.Add("@CurrencyCode", SqlDbType.NVarChar, 3).Value = this.strCurr;
                    cmdIns.Parameters.Add("@CurrencyName", SqlDbType.NVarChar, 20).Value = this.lblCurrency.Text.Trim();
                    cmdIns.Parameters.Add("@Remark", SqlDbType.NVarChar, 255).Value = this.txtRemark.Text.Trim();
                    cmdIns.Parameters.Add("@UD", SqlDbType.NVarChar, 50).Value = NP_Cls.strUsr;
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert;
                    cmdIns.ExecuteNonQuery();

                    this.groupPR.Enabled = false; this.btnAddPR.Visible = false; this.btnSave.Visible = true;
                    NP_Cls.SqlSelect = "SELECT     m_Material.MaterialName, t_PRDetail.PRNumber + ':' + t_PRDetail.MaterialCode AS MaterialCode FROM m_Material INNER JOIN             t_PRDetail ON m_Material.MaterialCode = t_PRDetail.MaterialCode INNER JOIN t_PR ON t_PRDetail.PRNumber = t_PR.PRNumber WHERE     (t_PR.VendorCode = N'" + this.cbVendor.Text.Trim().Split(':')[0] + "') AND (t_PR.PRApprove = 1) except SELECT     m_Material.MaterialName, t_PODetail.PRNumber + ':' + t_PODetail.MaterialCode AS MaterialCode FROM         t_PODetail INNER JOIN                      m_Material ON t_PODetail.MaterialCode = m_Material.MaterialCode INNER JOIN  t_PO ON t_PODetail.PONumber = t_PO.PONumber WHERE     (t_PO.VendorCode = N'" + this.cbVendor.Text.Trim().Split(':')[0] + "')";
                    NP.BindCB(this.cbMaterial, NP_Cls.SqlSelect, "MaterialName", "MaterialCode", "((( Select Material )))");
                    this.cbMaterial.Select(); this.cbMaterial.SelectAll();
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

        void BindVendor()
        {
             NP_Cls.SqlSelect = "SELECT DISTINCT   m_Vendor.VendorName, t_PR.VendorCode + ':' + m_Vendor.VendorName AS VendorCode  FROM         t_PR INNER JOIN                       m_Vendor ON t_PR.VendorCode = m_Vendor.VendorCode INNER JOIN                       t_PRDetail ON t_PR.PRNumber = t_PRDetail.PRNumber WHERE     (t_PRDetail.isPO = 0) AND (t_PR.PRApprove = 1)";
                NP.BindCB(this.cbVendor, NP_Cls.SqlSelect, "VendorName", "VendorCode", "((( Select Vendor PR )))");

        }

        private void btnCancelPR_Click(object sender, EventArgs e)
        {
            try
            {
                if (NP.MSGB("Do you to cancel Purchase Order ?") == DialogResult.Yes)
                {
                    NP_Cls.SqlDel = "DELETE FROM t_PO WHERE (PONumber = '" + this.txtPR.Text.Trim() + "')"; string strErr = string.Empty;
                    if (!NP.SqlCmd(NP_Cls.SqlDel, ref strErr))
                    {
                        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Delete : " + strErr); return;
                    }
                    else
                    {
                        NP_Cls.SqlDel = "DELETE FROM t_PODetail WHERE (PONumber = '" + this.txtPR.Text.Trim() + "')";
                        if (!NP.SqlCmd(NP_Cls.SqlDel, ref strErr))
                        {
                            NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Delete Detail : " + strErr); return;
                        }
                    }
                    Clear(); this.groupPR.Enabled = true; this.cbMaterial.Text = string.Empty;
                    if (this.dsPR.Tables.Count > 0) { this.dsPR.Tables.Clear(); this.MyGrid(this.dgvView); }
                    this.cbMaterial.DataSource = null; 
                    this.btnAddPR.Visible = true; this.btnSave.Visible = false;

                    BindVendor();
                    this.cbVendor.Text = string.Empty; this.cbVendor.Select();


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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.dgvView.RowCount == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please select material into PO list !!"); this.cbMaterial.Select(); return; }
            this.dgvView.EndEdit();
            for (byte ii = 0; ii < this.dgvView.RowCount; ii++)
            {
                if (Convert.ToInt32(this.dgvView["clnQuantity", ii].Value) == 0)
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Quantity for purchase more than 0 !!"); return;
                }
            }

            if (NP.MSGB("Do you to Save Purchase Order ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(Application.StartupPath + @"\DB\DB.ini"));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr;
                Tr = oConn.BeginTransaction();

                try
                {
                    SqlCommand cmdIns = new SqlCommand();
                    NP_Cls.SqlInsert = "INSERT INTO t_PODetail (PONumber, MaterialCode, MaterialName, POQuantity, UnitCode, UnitName, NetPrice, POAmount, DeliveryDate, PlantCode, PlantName, LocCode, LocName, CurrentUser, PRNumber) "+
"VALUES     (@PONumber,@MaterialCode,@MaterialName,@POQuantity,@UnitCode,@UnitName,@NetPrice,@POAmount,@DeliveryDate,@PlantCode,@PlantName,@LocCode,@LocName,@CurrentUser,@refPR)";
                    cmdIns.Parameters.Add("@PONumber", SqlDbType.NVarChar, 12);
                    cmdIns.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15);
                    cmdIns.Parameters.Add("@MaterialName", SqlDbType.NVarChar, 60);
                    cmdIns.Parameters.Add("@POQuantity", SqlDbType.Decimal);
                    cmdIns.Parameters.Add("@UnitCode", SqlDbType.NVarChar, 3);
                    cmdIns.Parameters.Add("@UnitName", SqlDbType.NVarChar, 20);
                    cmdIns.Parameters.Add("@NetPrice", SqlDbType.Decimal);
                    cmdIns.Parameters.Add("@POAmount", SqlDbType.Decimal);
                    cmdIns.Parameters.Add("@DeliveryDate", SqlDbType.DateTime);
                    cmdIns.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 4);
                    cmdIns.Parameters.Add("@PlantName", SqlDbType.NVarChar, 20);
                    cmdIns.Parameters.Add("@LocCode", SqlDbType.NVarChar, 2);
                    cmdIns.Parameters.Add("@LocName", SqlDbType.NVarChar, 20);
                    cmdIns.Parameters.Add("@CurrentUser", SqlDbType.NVarChar, 50);
                    cmdIns.Parameters.Add("@refPR", SqlDbType.NVarChar, 12);
                    
                                    
                    for (byte ins = 0; ins < this.dgvView.RowCount; ins++)
                    {
                        cmdIns.Parameters["@PONumber"].Value = this.strGNumber;
                        cmdIns.Parameters["@MaterialCode"].Value = this.dgvView["clnMaterialCode", ins].Value.ToString();
                        cmdIns.Parameters["@MaterialName"].Value = this.dgvView["clnMaterialName", ins].Value.ToString();
                        cmdIns.Parameters["@POQuantity"].Value = Convert.ToDouble(this.dgvView["clnQuantity", ins].Value);
                        cmdIns.Parameters["@UnitCode"].Value = this.dgvView["clnUnitCode", ins].Value.ToString();
                        cmdIns.Parameters["@UnitName"].Value = this.dgvView["clnUnitName", ins].Value.ToString();
                        cmdIns.Parameters["@NetPrice"].Value = Convert.ToDouble(this.dgvView["clnNetPrice", ins].Value);
                        cmdIns.Parameters["@POAmount"].Value = Convert.ToDouble(this.dgvView["clnAmount", ins].Value);
                        cmdIns.Parameters["@CurrentUser"].Value = NP_Cls.strUsr;
                        cmdIns.Parameters["@DeliveryDate"].Value = Convert.ToDateTime(this.dgvView["clnDeliveryDate", ins].Value);
                        cmdIns.Parameters["@PlantCode"].Value = this.dgvView["clnPlantCode", ins].Value.ToString();
                        cmdIns.Parameters["@PlantName"].Value = this.dgvView["clnPlantName", ins].Value.ToString();
                        cmdIns.Parameters["@LocCode"].Value = this.dgvView["clnLocCode", ins].Value.ToString();
                        cmdIns.Parameters["@LocName"].Value = this.dgvView["clnLocName", ins].Value.ToString();
                        cmdIns.Parameters["@refPR"].Value = this.dgvView["clnPRNumber", ins].Value.ToString();

                        cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                        cmdIns.ExecuteNonQuery();
                    }
                    cmdIns.Parameters.Add("@AutoID", SqlDbType.Int);
                    NP_Cls.sqlUpdate = "UPDATE t_PRDetail SET isPO = 1 WHERE (PRNumber = @refPR) AND (MaterialCode = @MaterialCode) AND (AutoID = @AutoID)";
                    for (byte upd = 0; upd < this.dgvView.RowCount; upd++)
                    {
                        cmdIns.Parameters["@refPR"].Value = this.dgvView["clnPRNumber", upd].Value.ToString();
                        cmdIns.Parameters["@MaterialCode"].Value = this.dgvView["clnMaterialCode", upd].Value.ToString();
                        cmdIns.Parameters["@AutoID"].Value = this.dgvView["AutoID", upd].Value.ToString();
                        cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.sqlUpdate; cmdIns.Transaction = Tr;
                        cmdIns.ExecuteNonQuery();
                    }
                    Tr.Commit(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Save Purchase Order Completed !!");
                    Clear();
                    this.groupPR.Enabled = true; this.btnAddPR.Visible = true; this.btnSave.Visible = false; this.cbMaterial.Text = string.Empty; this.cbMaterial.DataSource = null;
                    this.dsPR.Tables.Clear(); this.MyGrid(dgvView); this.txtPR.Text = GetNumber();
                    
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
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Clear(); this.txtPR.DropDownStyle = ComboBoxStyle.DropDownList; this.txtPR.Text = string.Empty; this.cbVendor.Text = string.Empty; cbVendor.Enabled = true;
            NP_Cls.SqlSelect = "SELECT PONumber, PONumber AS PODis FROM t_PO WHERE ClosePO = 'P'";
            NP.BindCB(this.txtPR, NP_Cls.SqlSelect, "PONumber", "PODis", "( Select PO Number )");
            this.groupPR.Enabled = true; this.btnAddPR.Visible = true; this.btnSave.Visible = false; this.cbMaterial.Text = string.Empty; this.cbMaterial.DataSource = null;
            this.MyGrid(dgvView); this.txtPR.Text = GetNumber(); this.btnAppr.Visible = false;
            this.txtPR.SelectedIndex = 0; 
        }
        private void txtPR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NP_Cls.SqlSelect = "SELECT     0 AS ItemNo, t_PODetail.MaterialCode, t_PODetail.MaterialName, t_PODetail.POQuantity AS Qty, t_PODetail.UnitCode, t_PODetail.UnitName,         t_PODetail.NetPrice, t_PODetail.POAmount AS Amt, t_PODetail.DeliveryDate, t_PODetail.PRNumber, t_PO.POApprove, t_PODetail.PlantCode, t_PODetail.PlantName, t_PODetail.LocCode, t_PODetail.LocName, t_PODetail.GRQuantity AS GRQty, t_PO.VendorCode FROM  t_PO INNER JOIN  t_PODetail ON t_PO.PONumber = t_PODetail.PONumber WHERE     (t_PO.PONumber = N'" + this.txtPR.Text.Trim() + "')";
                this.dsPR = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (this.dsPR.Tables[0].Rows.Count == 0) { this.dsPR.Tables.Clear(); this.MyGrid(dgvView); this.cbVendor.Enabled = true; this.cbVendor.Text = string.Empty; return; }
                bView = 1;
                for (byte ii = 0; ii < this.dsPR.Tables[0].Rows.Count; ii++)
                {
                    this.dsPR.Tables[0].Rows[ii]["ItemNo"] = Convert.ToInt32(ii + 1);
                }
                this.cbVendor.Text = this.dsPR.Tables[0].Rows[0]["VendorCode"].ToString();
                this.dsPR.Tables[0].Columns.Remove("VendorCode"); this.cbVendor.Enabled = false;
                if (!Convert.ToBoolean(this.dsPR.Tables[0].Rows[0]["POApprove"]))
                {
                    this.btnAppr.Visible = true; this.btnCancelPR.Visible = true;
                }
                else
                {
                    this.btnAppr.Visible = false; this.btnCancelPR.Visible = false;
                }

                //Approve 
                if (NP_Cls.AppPO == 1) { this.btnAppr.Visible = true; } else { this.btnAppr.Visible = false; }

                this.dsPR.Tables[0].Columns.Remove("POApprove");
                this.dsPR.AcceptChanges();
                this.dgvView.DataSource = this.dsPR.Tables[0];

                // Head
                this.btnAddPR.Visible = false; this.btnSave.Visible = false;
                // Detail
                this.cbMaterial.DataSource = null; this.cbMaterial.Text = string.Empty;

                this.dgvView.ClearSelection();
                this.dgvView.Columns["GRQty"].DefaultCellStyle.BackColor = Color.Orange;
            }
        }
        private void btnAppr_Click(object sender, EventArgs e)
        {
            if (NP.MSGB("Do you want Approve Purchase Order ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(Application.StartupPath + @"\DB\DB.ini"));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr;
                Tr = oConn.BeginTransaction();
                try
                {
                    SqlCommand cmdUp = new SqlCommand();
                    NP_Cls.sqlUpdate = "UPDATE t_PO SET POApprove = 1, UserUpdate = @strUser, DateUpdate = GETDATE() WHERE (PONumber = @PONumber)";
                    cmdUp.Parameters.Add("@strUser", SqlDbType.NVarChar, 50).Value = NP_Cls.strUsr;
                    cmdUp.Parameters.Add("@PONumber", SqlDbType.NVarChar, 50).Value = this.txtPR.Text.Trim();
                    cmdUp.Connection = oConn; cmdUp.CommandText = NP_Cls.sqlUpdate; cmdUp.Transaction = Tr;
                    cmdUp.ExecuteNonQuery();

                    cmdUp.Parameters.Add("@refPR", SqlDbType.NVarChar, 20); cmdUp.Parameters.Add("@TranID", SqlDbType.NVarChar, 100);
                    for (int k = 0; k < this.dgvView.RowCount; k++)
                    {
                        NP_Cls.SqlSelect = "SELECT TranID FROM t_MRPTranOrder WHERE (TranOrder = @refPR)";
                        cmdUp.Parameters["@refPR"].Value = this.dgvView[9, k].Value.ToString(); cmdUp.Parameters["@TranID"].Value = string.Empty;
                        cmdUp.Connection = oConn; cmdUp.CommandText = NP_Cls.SqlSelect; cmdUp.Transaction = Tr;
                        SqlDataAdapter da = new SqlDataAdapter(cmdUp); DataSet dsTran = new DataSet(); da.Fill(dsTran);string strTmpID = string.Empty;
                        if (dsTran.Tables[0].Rows.Count > 0)
                        {
                            strTmpID = dsTran.Tables[0].Rows[0][0].ToString();
                        }
                        else { strTmpID = string.Empty; }
                        if (!string.IsNullOrEmpty(strTmpID))
                        {
                            NP_Cls.sqlUpdate = "UPDATE t_MRPTranOrder SET TranOrder = @PONumber WHERE (TranID = @TranID)";
                            cmdUp.Parameters["@TranID"].Value = strTmpID; cmdUp.Parameters["@refPR"].Value = string.Empty;
                            cmdUp.Connection = oConn; cmdUp.CommandText = NP_Cls.sqlUpdate; cmdUp.Transaction = Tr;
                            cmdUp.ExecuteNonQuery();
                        }
                    }
                    Tr.Commit();
                    Clear(); this.txtPR.DropDownStyle = ComboBoxStyle.Simple; this.cbVendor.Enabled = true;
                    this.groupPR.Enabled = true; this.btnAddPR.Visible = true; this.btnSave.Visible = false; this.cbMaterial.Text = string.Empty; this.cbMaterial.DataSource = null;
                    this.dsPR.Tables.Clear(); this.MyGrid(dgvView); this.txtPR.Text = GetNumber(); this.btnAppr.Visible = false;
                    this.cbVendor.Text = string.Empty; this.cbVendor.Select();
                }
                catch (Exception ex)
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Approve : " + ex.Message); return;
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
        private void btnGenNew_Click(object sender, EventArgs e)
        {
            Clear(); this.txtPR.DropDownStyle = ComboBoxStyle.Simple; this.cbVendor.Enabled = true;
            this.groupPR.Enabled = true; this.btnAddPR.Visible = true; this.btnSave.Visible = false; this.cbMaterial.Text = string.Empty; this.cbMaterial.DataSource = null;
            this.dsPR.Tables.Clear(); this.MyGrid(dgvView); this.txtPR.Text = GetNumber();
            this.cbVendor.Text = string.Empty; this.cbVendor.Select();
        }
        private void txtPR_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.txtPR.SelectedIndex != 0)
            {
                NP_Cls.SqlSelect = "SELECT     0 AS ItemNo, t_PODetail.MaterialCode, t_PODetail.MaterialName, t_PODetail.POQuantity AS Qty, t_PODetail.UnitCode, t_PODetail.UnitName, t_PODetail.NetPrice, t_PODetail.POAmount AS Amt, t_PODetail.DeliveryDate, t_PODetail.PRNumber, t_PO.POApprove, t_PODetail.PlantCode, t_PODetail.PlantName, t_PODetail.LocCode,  t_PODetail.LocName, t_PODetail.GRQuantity AS GR, t_PO.VendorCode, t_PO.VendorName, t_PO.PurchasingGroup, t_PO.Terms, t_PO.CurrencyCode,  t_PO.CurrencyName, t_PO.Remark, t_PO.UserCreate,  t_PO.ClosePO FROM  t_PO INNER JOIN  t_PODetail ON t_PO.PONumber = t_PODetail.PONumber WHERE (t_PO.PONumber = N'" + this.txtPR.Text.Trim() + "')";
                this.dsPR = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (this.dsPR.Tables[0].Rows.Count == 0) { this.dsPR.Tables.Clear(); this.MyGrid(dgvView); this.cbVendor.Enabled = true; this.cbVendor.Text = string.Empty; return; }
                bView = 1;
                for (byte ii = 0; ii < this.dsPR.Tables[0].Rows.Count; ii++)
                {
                    this.dsPR.Tables[0].Rows[ii]["ItemNo"] = Convert.ToInt32(ii + 1);
                }
                this.cbVendor.Text = this.dsPR.Tables[0].Rows[0]["VendorCode"].ToString() + ":" + this.dsPR.Tables[0].Rows[0]["VendorName"].ToString();
                this.lblCurrency.Text = this.dsPR.Tables[0].Rows[0]["CurrencyName"].ToString();
                this.lblPG.Text = this.dsPR.Tables[0].Rows[0]["PurchasingGroup"].ToString();
                this.lblTerm.Text = this.dsPR.Tables[0].Rows[0]["Terms"].ToString(); this.lblVendorName.Text = this.dsPR.Tables[0].Rows[0]["VendorName"].ToString(); 
                this.lblUserCreate.Text = this.dsPR.Tables[0].Rows[0]["UserCreate"].ToString();
                this.strCurr = this.dsPR.Tables[0].Rows[0]["CurrencyCode"].ToString(); this.txtRemark.Text = this.dsPR.Tables[0].Rows[0]["Remark"].ToString();
                this.dsPR.Tables[0].Columns.Remove("VendorCode"); this.dsPR.Tables[0].Columns.Remove("VendorName");

                this.btnClosePO.Visible = (this.dsPR.Tables[0].Rows[0]["ClosePO"].ToString().Trim() == "C" ? false : true); 

                // Remove Column
                this.dsPR.Tables[0].Columns.Remove("CurrencyName"); this.dsPR.Tables[0].Columns.Remove("PurchasingGroup");
                this.dsPR.Tables[0].Columns.Remove("Terms"); this.dsPR.Tables[0].Columns.Remove("UserCreate");
                this.dsPR.Tables[0].Columns.Remove("CurrencyCode"); this.dsPR.Tables[0].Columns.Remove("Remark"); this.dsPR.Tables[0].Columns.Remove("ClosePO"); 
                this.cbVendor.Enabled = false;
                if (!Convert.ToBoolean(this.dsPR.Tables[0].Rows[0]["POApprove"]))
                {
                    this.btnAppr.Visible = true; this.btnCancelPR.Visible = true; this.btnClosePO.Visible = false;
                    //Approve 
                    if (NP_Cls.AppPO == 1) { this.btnAppr.Visible = true; } else { this.btnAppr.Visible = false; }
                    NP_Cls.SqlSelect = "SELECT     m_Material.MaterialName, t_PRDetail.PRNumber + ':' + t_PRDetail.MaterialCode AS MaterialCode FROM m_Material INNER JOIN             t_PRDetail ON m_Material.MaterialCode = t_PRDetail.MaterialCode INNER JOIN t_PR ON t_PRDetail.PRNumber = t_PR.PRNumber WHERE     (t_PR.VendorCode = N'" + this.cbVendor.Text.Trim().Split(':')[0] + "') AND (t_PR.PRApprove = 1) except SELECT     m_Material.MaterialName, t_PODetail.PRNumber + ':' + t_PODetail.MaterialCode AS MaterialCode FROM         t_PODetail INNER JOIN  m_Material ON t_PODetail.MaterialCode = m_Material.MaterialCode INNER JOIN  t_PO ON t_PODetail.PONumber = t_PO.PONumber WHERE     (t_PO.VendorCode = N'" + this.cbVendor.Text.Trim().Split(':')[0] + "')";
                    NP.BindCB(this.cbMaterial, NP_Cls.SqlSelect, "MaterialName", "MaterialCode", "((( Select Material )))");
                    this.cbMaterial.Select();
                }
                else
                {
                    this.btnAppr.Visible = false; this.btnCancelPR.Visible = false;
                   // this.btnClosePO.Visible = true;
                }

                

                this.dsPR.Tables[0].Columns.Remove("POApprove");
                this.dsPR.AcceptChanges();
                this.dgvView.DataSource = this.dsPR.Tables[0];

                // Head
                this.btnAddPR.Visible = false; this.btnSave.Visible = false;
                // Detail
                //this.cbMaterial.DataSource = null; this.cbMaterial.Text = string.Empty;
          
                this.dgvView.ClearSelection();
                this.dgvView.Columns["GR"].DefaultCellStyle.BackColor = Color.Orange;
            }
        }

        private void dgvView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvView.CurrentCell.ColumnIndex == 8)
            {
                ((DateTimePicker)e.Control).Value = ((DateTime)this.dgvView[8, this.dgvView.CurrentRow.Index].Value);
            }
        }

        private void btnClosePO_Click(object sender, EventArgs e)
        {
            if (NP.MSGB("Do you want Close Purchase Order ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(Application.StartupPath + @"\DB\DB.ini"));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr;
                Tr = oConn.BeginTransaction();
                try
                {
                    SqlCommand cmdUp = new SqlCommand();
                    NP_Cls.sqlUpdate = "UPDATE t_PO SET ClosePO = 'C', ClosePOUser = @strUser, ClosePODate = GETDATE() WHERE (PONumber = @PONumber)";
                    cmdUp.Parameters.Add("@strUser", SqlDbType.NVarChar, 50).Value = NP_Cls.strUsr;
                    cmdUp.Parameters.Add("@PONumber", SqlDbType.NVarChar, 50).Value = this.txtPR.Text.Trim();
                    cmdUp.Connection = oConn; cmdUp.CommandText = NP_Cls.sqlUpdate; cmdUp.Transaction = Tr;
                    cmdUp.ExecuteNonQuery();

                    //cmdUp.Parameters.Add("@refPR", SqlDbType.NVarChar, 20); cmdUp.Parameters.Add("@TranID", SqlDbType.NVarChar, 100);
                    //for (int k = 0; k < this.dgvView.RowCount; k++)
                    //{
                    //    NP_Cls.SqlSelect = "SELECT TranID FROM t_MRPTranOrder WHERE (TranOrder = @refPR)";
                    //    cmdUp.Parameters["@refPR"].Value = this.dgvView[9, k].Value.ToString(); cmdUp.Parameters["@TranID"].Value = string.Empty;
                    //    cmdUp.Connection = oConn; cmdUp.CommandText = NP_Cls.SqlSelect; cmdUp.Transaction = Tr;
                    //    SqlDataAdapter da = new SqlDataAdapter(cmdUp); DataSet dsTran = new DataSet(); da.Fill(dsTran); string strTmpID = string.Empty;
                    //    if (dsTran.Tables[0].Rows.Count > 0)
                    //    {
                    //        strTmpID = dsTran.Tables[0].Rows[0][0].ToString();
                    //    }
                    //    else { strTmpID = string.Empty; }
                    //    if (!string.IsNullOrEmpty(strTmpID))
                    //    {
                    //        NP_Cls.sqlUpdate = "UPDATE t_MRPTranOrder SET TranOrder = @PONumber WHERE (TranID = @TranID)";
                    //        cmdUp.Parameters["@TranID"].Value = strTmpID; cmdUp.Parameters["@refPR"].Value = string.Empty;
                    //        cmdUp.Connection = oConn; cmdUp.CommandText = NP_Cls.sqlUpdate; cmdUp.Transaction = Tr;
                    //        cmdUp.ExecuteNonQuery();
                    //    }
                    //}
                    Tr.Commit();
                    Clear(); this.txtPR.DropDownStyle = ComboBoxStyle.Simple; this.cbVendor.Enabled = true;
                    this.groupPR.Enabled = true; this.btnAddPR.Visible = true; this.btnSave.Visible = false; this.cbMaterial.Text = string.Empty; this.cbMaterial.DataSource = null;
                    this.dsPR.Tables.Clear(); this.MyGrid(dgvView); this.txtPR.Text = GetNumber(); this.btnAppr.Visible = false;
                    this.cbVendor.Text = string.Empty; this.cbVendor.Select();
                }
                catch (Exception ex)
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Close PO : " + ex.Message); return;
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
