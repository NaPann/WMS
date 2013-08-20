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
    public partial class frmSaleOrder : Form
    {
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection(); private byte bView = 0; private string strCurr = string.Empty;
        private string strGNumber = string.Empty; private DataSet dsPR = new DataSet(); private string strPRref = string.Empty;
        public frmSaleOrder()
        {
            InitializeComponent();
        }
        private void MyGrid(DataGridView grid)
        {
            NP_Cls.SqlSelect = "SELECT     1 AS ItemNo, m_Material.MaterialCode, m_Material.MaterialName, 0 AS Qty, m_Material.UnitCode, m_Unit.UnitName,   m_Material.MovAvgPrice AS NetPrice, 0 AS Amt, GETDATE() + m_Material.DeliveryTime AS DeliveryDate, m_Material.PlantCode, m_Plant.PlantName, m_Material.LocCode, m_Location.LocName FROM         m_Material INNER JOIN  m_Unit ON m_Material.UnitCode = m_Unit.UnitCode INNER JOIN  m_Plant ON m_Material.PlantCode = m_Plant.PlantCode INNER JOIN m_Location ON m_Material.LocCode = m_Location.LocCode WHERE (m_Material.MaterialCode = N'')";
            this.dsPR = NP.GetClientDataSet(NP_Cls.SqlSelect);
            grid.DataSource = this.dsPR.Tables[0];
        }
        private void frmSaleOrder_Load(object sender, EventArgs e)
        {
            try
            {
                WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
                frm.menuStrip1.Enabled = true;

                this.txtSO.Text = GetNumber(); this.txtDocDate.Text = NP.GetDateServer().ToString("dd/MM/yyyy");

                NP_Cls.SqlSelect = "SELECT CustomerName, CustomerCode + ':' + CustomerName AS CustomerCode FROM m_Customer WHERE     (FileStatus = N'1')";
                NP.BindCB(this.cbCustomer, NP_Cls.SqlSelect, "CustomerName", "CustomerCode", "((( Select Customer SO )))");

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
            this.lblCustomer.Text = string.Empty; this.lblCurrency.Text = string.Empty; this.lblMaterialName.Text = string.Empty;
            this.txtCustPO.Text = string.Empty; this.lblTerm.Text = string.Empty;
        }
        private string GetNumber()
        {
            try
            {
                bView = 0;
                NP_Cls.SqlSelect = "SELECT top (1) CONVERT(int, RIGHT(SONumber, 4)) AS SS, RIGHT(CONVERT(nvarchar, GETDATE(), 112), 6) AS s FROM   t_SO WHERE (RIGHT(CONVERT(nvarchar, GETDATE(), 112), 6) = LEFT(RIGHT(SONumber, 10), 6)) ORDER BY SS DESC";
                DataSet dsGen = new DataSet(); dsGen = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (dsGen.Tables[0].Rows.Count == 0)
                {
                    NP_Cls.SqlSelect = "SELECT  TOP (1) RIGHT(CONVERT(nvarchar, GETDATE(), 112), 6) AS s";
                    return "SO" + NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0].Rows[0][0].ToString() + "0001";
                }
                else
                {
                    string strCode = (Convert.ToInt16(dsGen.Tables[0].Rows[0][0].ToString()) + 1).ToString().PadLeft(5 - (Convert.ToInt16(dsGen.Tables[0].Rows[0][0].ToString()) + 1).ToString().Length, '0');
                    return "SO" + dsGen.Tables[0].Rows[0][1].ToString() + strCode;
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
                    NP_Cls.SqlSelect = "SELECT     m_Customer.CustomerName, m_Customer.CustomerCode, m_Currency.CurrencyName, m_Customer.CurrencyCode, m_Customer.TermsOfPayment FROM m_Customer INNER JOIN m_Currency ON m_Customer.CurrencyCode = m_Currency.CurrencyCode WHERE  (m_Customer.FileStatus = N'1') AND (m_Customer.CustomerCode = N'" + this.cbCustomer.Text.Trim().Split(':')[0] + "')";
                    dsDetail = NP.GetClientDataSet(NP_Cls.SqlSelect);  
                    this.lblCurrency.Text = dsDetail.Tables[0].Rows[0]["CurrencyName"].ToString();
                    this.lblTerm.Text = dsDetail.Tables[0].Rows[0]["TermsOfPayment"].ToString();
                    this.strCurr = dsDetail.Tables[0].Rows[0]["CurrencyCode"].ToString();
                }
                catch (Exception ex)
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
                if (!NP.ReqField(this.txtCustPO, "Please enter Customer PO Number !!")) { return; }
                //
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open();

                try
                {
                    SqlCommand cmdIns = new SqlCommand();
                    NP_Cls.SqlInsert = "INSERT INTO t_SO " +
                      "(SONumber, SODate, CustomerCode, CustomerName, CustPOOrder, Terms, CurrencyCode, CurrencyName, Remark, UserCreate, DateCreate) " +
"VALUES     (@SONumber, GETDATE(),@CustomerCode,@CustomerName,@CustPOOrder,@Terms,@CurrencyCode,@CurrencyName,@Remark,@UD, GETDATE())";
                    this.strGNumber = GetNumber();
                    cmdIns.Parameters.Add("@SONumber", SqlDbType.NVarChar, 12).Value = this.strGNumber;
                    cmdIns.Parameters.Add("@CustomerCode", SqlDbType.NVarChar, 10).Value = this.cbCustomer.Text.Trim().Split(':')[0];
                    cmdIns.Parameters.Add("@CustomerName", SqlDbType.NVarChar, 60).Value = this.lblCustomer.Text.Trim();
                    cmdIns.Parameters.Add("@CustPOOrder", SqlDbType.NVarChar, 20).Value = this.txtCustPO.Text.Trim();
                    cmdIns.Parameters.Add("@Terms", SqlDbType.Decimal).Value = Convert.ToDecimal(this.lblTerm.Text.Trim());
                    cmdIns.Parameters.Add("@CurrencyCode", SqlDbType.NVarChar, 3).Value = this.strCurr;
                    cmdIns.Parameters.Add("@CurrencyName", SqlDbType.NVarChar, 20).Value = this.lblCurrency.Text.Trim();
                    cmdIns.Parameters.Add("@Remark", SqlDbType.NVarChar, 255).Value = this.txtRemark.Text.Trim();
                    cmdIns.Parameters.Add("@UD", SqlDbType.NVarChar, 50).Value = NP_Cls.strUsr;
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert;
                    cmdIns.ExecuteNonQuery();

                    this.groupPR.Enabled = false; this.btnAddSO.Visible = false; this.btnSave.Visible = true;
                    if (NP_Cls.FromMRP == 1)
                    {
                        NP_Cls.SqlSelect = "SELECT MaterialName, MaterialCode FROM  m_Material WHERE (FileStatus = N'1') AND (MaterialCode = '" + NP_Cls.MRPFGSort + "')";
                    }
                    else
                    {
                        NP_Cls.SqlSelect = "SELECT MaterialName, MaterialCode FROM  m_Material WHERE (FileStatus = N'1')";
                    }
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
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(this.bView))
            {
                if ((this.dsPR.Tables[0].Rows.Count > 0) || (this.groupPR.Enabled == false))
                {
                    if (NP.MSGB("The SO list will be cancel , Do you agree with this ?") == DialogResult.Yes)
                    {
                        // Cancel
                        NP_Cls.SqlDel = "DELETE FROM t_SO WHERE (SONumber = '" + this.txtSO.Text.Trim() + "')"; string strErr = string.Empty;
                        if (!NP.SqlCmd(NP_Cls.SqlDel, ref strErr))
                        {
                            NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Delete : " + strErr); return;
                        }
                        else
                        {
                            NP_Cls.SqlDel = "DELETE FROM t_SODetail WHERE (SONumber = '" + this.txtSO.Text.Trim() + "')";
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
        private void frmSaleOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (NP_Cls.FromMRP == 0)
            {
                WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
                frm.menuStrip1.Enabled = true;
            }
        }
        private void btnCancelSO_Click(object sender, EventArgs e)
        {
            try
            {
                if (NP.MSGB("Do you to cancel Sale Order ?") == DialogResult.Yes)
                {
                    NP_Cls.SqlDel = "DELETE FROM t_SO WHERE (SONumber = '" + this.txtSO.Text.Trim() + "')"; string strErr = string.Empty;
                    if (!NP.SqlCmd(NP_Cls.SqlDel, ref strErr))
                    {
                        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Delete : " + strErr); return;
                    }
                    else
                    {
                        NP_Cls.SqlDel = "DELETE FROM t_SODetail WHERE (SONumber = '" + this.txtSO.Text.Trim() + "')";
                        if (!NP.SqlCmd(NP_Cls.SqlDel, ref strErr))
                        {
                            NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Delete Detail : " + strErr); return;
                        }
                    }
                    Clear(); this.groupPR.Enabled = true; this.cbMaterial.Text = string.Empty;
                    if (this.dsPR.Tables.Count > 0) { this.dsPR.Tables.Clear(); this.MyGrid(this.dgvView); }
                    this.cbMaterial.DataSource = null;
                    this.btnAddSO.Visible = true; this.btnSave.Visible = false;


                    NP_Cls.SqlSelect = "SELECT CustomerName, CustomerCode + ':' + CustomerName AS CustomerCode FROM m_Customer WHERE     (FileStatus = N'1')";
                    NP.BindCB(this.cbCustomer, NP_Cls.SqlSelect, "CustomerName", "CustomerCode", "((( Select Customer SO )))");
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

        private void cbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.cbMaterial.SelectedIndex != 0) && (!string.IsNullOrEmpty(this.cbMaterial.Text.Trim())))
            {
                this.lblMaterialName.Text = this.cbMaterial.SelectedValue.ToString();
            }
            else
            {
                this.lblMaterialName.Text = string.Empty;
                this.cbMaterial.Select();
            }
        }
        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.cbMaterial.Text.Trim()))
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please add SO Header first !!"); return;
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
                        //    if ((this.cbMaterial.Text.Trim().Split(':')[1].ToString() == this.dsPR.Tables[0].Rows[ii]["MaterialCode"].ToString()) && (this.cbMaterial.Text.Trim().Split(':')[0].ToString() == this.dsPR.Tables[0].Rows[ii]["PRNumber"].ToString()))
                        //    {
                        //        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "This material is in PO List !!"); this.cbMaterial.Select(); return;
                        //    }
                        //}
                    }
                    else if (this.dsPR.Tables[0].Rows.Count == 0)
                    {
                        //
                        NP_Cls.SqlSelect = "SELECT     1 AS ItemNo, m_Material.MaterialCode, m_Material.MaterialName, 0 AS Qty, m_Material.UnitCode, m_Unit.UnitName,   m_Material.MovAvgPrice AS NetPrice, 0 AS Amt, GETDATE() + m_Material.DeliveryTime AS DeliveryDate, m_Material.PlantCode, m_Plant.PlantName, m_Material.LocCode, m_Location.LocName FROM         m_Material LEFT OUTER JOIN  m_Unit ON m_Material.UnitCode = m_Unit.UnitCode LEFT OUTER JOIN  m_Plant ON m_Material.PlantCode = m_Plant.PlantCode LEFT OUTER JOIN m_Location ON m_Material.LocCode = m_Location.LocCode WHERE (m_Material.MaterialCode = N'" + this.cbMaterial.Text.Trim() + "')";
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
                    NP_Cls.SqlSelect = "SELECT     1 AS ItemNo, m_Material.MaterialCode, m_Material.MaterialName, 0 AS Qty, m_Material.UnitCode, m_Unit.UnitName,   m_Material.MovAvgPrice AS NetPrice, 0 AS Amt, GETDATE() + m_Material.DeliveryTime AS DeliveryDate, m_Material.PlantCode, m_Plant.PlantName, m_Material.LocCode, m_Location.LocName FROM         m_Material LEFT OUTER JOIN  m_Unit ON m_Material.UnitCode = m_Unit.UnitCode LEFT OUTER JOIN  m_Plant ON m_Material.PlantCode = m_Plant.PlantCode LEFT OUTER JOIN m_Location ON m_Material.LocCode = m_Location.LocCode WHERE (m_Material.MaterialCode = N'" + this.cbMaterial.Text.Trim() + "')";
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.dgvView.RowCount == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please select material into SO list !!"); this.cbMaterial.Select(); return; }
            this.dgvView.EndEdit();
            for (byte ii = 0; ii < this.dgvView.RowCount; ii++)
            {
                if (Convert.ToInt32(this.dgvView[4, ii].Value) == 0)
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Quantity for purchase more than 0 !!"); return;
                }
            }

            if (NP.MSGB("Do you to Save Sale Order ?") == DialogResult.Yes)
            {

                if (Convert.ToBoolean(bView))
                {
                    this.strGNumber = this.txtSO.Text.Trim();
                    NP_Cls.SqlDel = "DELETE FROM t_SODetail WHERE (SONumber = '" + this.strGNumber + "')"; string strErr = string.Empty;
                    if (!NP.SqlCmd(NP_Cls.SqlDel, ref strErr))
                    {
                        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Update : " + strErr); return;
                    }
                }

                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr;
                Tr = oConn.BeginTransaction();

                try
                {
                    SqlCommand cmdIns = new SqlCommand();
                    NP_Cls.SqlInsert = "INSERT INTO t_SODetail (SONumber, MaterialCode, MaterialName, SOQuantity, UnitCode, UnitName, NetPrice, SOAmount, DeliveryDate, PlantCode, PlantName, LocCode, LocName, CurrentUser) " +
"VALUES     (@SONumber,@MaterialCode,@MaterialName,@SOQuantity,@UnitCode,@UnitName,@NetPrice,@SOAmount,@DeliveryDate,@PlantCode,@PlantName,@LocCode,@LocName,@CurrentUser)";
                    cmdIns.Parameters.Add("@SONumber", SqlDbType.NVarChar, 12);
                    cmdIns.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15);
                    cmdIns.Parameters.Add("@MaterialName", SqlDbType.NVarChar, 60);
                    cmdIns.Parameters.Add("@SOQuantity", SqlDbType.Decimal);
                    cmdIns.Parameters.Add("@UnitCode", SqlDbType.NVarChar, 3);
                    cmdIns.Parameters.Add("@UnitName", SqlDbType.NVarChar, 20);
                    cmdIns.Parameters.Add("@NetPrice", SqlDbType.Decimal);
                    cmdIns.Parameters.Add("@SOAmount", SqlDbType.Decimal);
                    cmdIns.Parameters.Add("@DeliveryDate", SqlDbType.DateTime);
                    cmdIns.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 4);
                    cmdIns.Parameters.Add("@PlantName", SqlDbType.NVarChar, 20);
                    cmdIns.Parameters.Add("@LocCode", SqlDbType.NVarChar, 2);
                    cmdIns.Parameters.Add("@LocName", SqlDbType.NVarChar, 20);
                    cmdIns.Parameters.Add("@CurrentUser", SqlDbType.NVarChar, 50);

                    for (byte ins = 0; ins < this.dgvView.RowCount; ins++)
                    {
                        cmdIns.Parameters["@SONumber"].Value = this.strGNumber;
                        cmdIns.Parameters["@MaterialCode"].Value = this.dgvView["clnMaterialCode", ins].Value.ToString();
                        cmdIns.Parameters["@MaterialName"].Value = this.dgvView["clnMaterialName", ins].Value.ToString();
                        cmdIns.Parameters["@SOQuantity"].Value = Convert.ToDecimal(this.dgvView["clnQuantity", ins].Value);
                        cmdIns.Parameters["@UnitCode"].Value = this.dgvView["clnUnitCode", ins].Value.ToString();
                        cmdIns.Parameters["@UnitName"].Value = this.dgvView["clnUnitName", ins].Value.ToString();
                        cmdIns.Parameters["@NetPrice"].Value = Convert.ToDecimal(this.dgvView["clnNetPrice", ins].Value);
                        cmdIns.Parameters["@SOAmount"].Value = Convert.ToDecimal(this.dgvView["clnAmount", ins].Value);
                        cmdIns.Parameters["@CurrentUser"].Value = NP_Cls.strUsr;
                        cmdIns.Parameters["@DeliveryDate"].Value = Convert.ToDateTime(this.dgvView["clnDeliveryDate", ins].Value);
                        cmdIns.Parameters["@PlantCode"].Value = this.dgvView["clnPlantCode", ins].Value.ToString();
                        cmdIns.Parameters["@PlantName"].Value = this.dgvView["clnPlantName", ins].Value.ToString();
                        cmdIns.Parameters["@LocCode"].Value = this.dgvView["clnLocCode", ins].Value.ToString();
                        cmdIns.Parameters["@LocName"].Value = this.dgvView["clnLocName", ins].Value.ToString();

                        cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                        cmdIns.ExecuteNonQuery();
                    }


                    if (NP_Cls.FromMRP == 1)
                    {
                        SqlCommand cmdMRP = new SqlCommand();
                        cmdMRP.Parameters.Add("@MatCode", SqlDbType.NVarChar, 15).Value = NP_Cls.MRPFGSort;
                        cmdMRP.Parameters.Add("@TranOrder", SqlDbType.NVarChar, 50).Value = this.strGNumber;
                        cmdMRP.Parameters.Add("@TranQty", SqlDbType.Decimal).Value = NP_Cls.MRPQty;
                        cmdMRP.Parameters.Add("@SONumber", SqlDbType.NVarChar, 50).Value = NP_Cls.MRPSO;
                        NP_Cls.SqlInsert = "INSERT INTO t_MRPTranOrder (MaterialCode,TranOrder,TranQty,SONumber) VALUES (@MatCode,@TranOrder,@TranQty,@SONumber)";
                        cmdMRP.CommandText = NP_Cls.SqlInsert; cmdMRP.Connection = oConn;
                        cmdMRP.Transaction = Tr; cmdMRP.ExecuteNonQuery();

                        Tr.Commit();
                        NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Save Sale Order Completed !! this screen will be close ..");
                        NP_Cls.MRPTranOrder = this.txtSO.Text.Trim(); this.Close(); return;
                    }
                    Tr.Commit();
                    NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Save Sale Order Completed !!");
                    Clear();
                    this.groupPR.Enabled = true; this.btnAddSO.Visible = true; this.btnSave.Visible = false; this.cbMaterial.Text = string.Empty; this.cbMaterial.DataSource = null;
                    this.dsPR.Tables.Clear(); this.MyGrid(dgvView); this.txtSO.DropDownStyle = ComboBoxStyle.Simple;
                    NP_Cls.SqlSelect = "SELECT CustomerName, CustomerCode + ':' + CustomerName AS CustomerCode FROM m_Customer WHERE     (FileStatus = N'1')";
                    NP.BindCB(this.cbCustomer, NP_Cls.SqlSelect, "CustomerName", "CustomerCode", "((( Select Customer SO )))");
                    this.cbCustomer.Enabled = true; this.txtSO.Text = GetNumber(); this.btnAppr.Visible = false;
                    this.txtRemark.Text = string.Empty;
                    this.cbCustomer.Text = string.Empty; this.cbCustomer.Select(); this.cbCustomer.SelectAll();
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
            Clear(); this.txtSO.DropDownStyle = ComboBoxStyle.DropDownList; this.txtSO.Text = string.Empty; this.cbCustomer.Text = string.Empty; cbCustomer.Enabled = true;
            NP_Cls.SqlSelect = "SELECT SONumber, SONumber AS SODis FROM t_SO";
            NP.BindCB(this.txtSO, NP_Cls.SqlSelect, "SONumber", "SODis", "( Select SO Number )");
            this.groupPR.Enabled = true; this.btnAddSO.Visible = true; this.btnSave.Visible = false; this.cbMaterial.Text = string.Empty; this.cbMaterial.DataSource = null;
            this.MyGrid(dgvView); this.txtSO.Text = GetNumber(); this.btnAppr.Visible = false;
            this.txtSO.SelectedIndex = 0; 
        }
        private void btnGenNew_Click(object sender, EventArgs e)
        {
            Clear(); this.txtSO.DropDownStyle = ComboBoxStyle.Simple; this.cbCustomer.Enabled = true;
            this.groupPR.Enabled = true; this.btnAddSO.Visible = true; this.btnSave.Visible = false; this.cbMaterial.Text = string.Empty; this.cbMaterial.DataSource = null;
            this.dsPR.Tables.Clear(); this.MyGrid(dgvView); this.txtSO.Text = GetNumber();
            this.cbCustomer.Text = string.Empty; this.cbCustomer.Select();
        }

        private void txtSO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.txtSO.SelectedIndex != 0)
            {
                NP_Cls.SqlSelect = "SELECT     1 AS ItemNo, t_SODetail.MaterialCode, t_SODetail.MaterialName, t_SODetail.SOQuantity AS Qty, t_SODetail.UnitCode, t_SODetail.UnitName,  t_SODetail.NetPrice, t_SODetail.SOAmount AS Amt, t_SODetail.DeliveryDate, t_SODetail.PlantCode, t_SODetail.PlantName, t_SODetail.LocCode, t_SODetail.LocName, t_SO.CustomerCode, t_SO.SOApprove, t_SO.CustPOOrder, t_SODetail.DOQuantity AS [DO Qty]  FROM     t_SO INNER JOIN    t_SODetail ON t_SO.SONumber = t_SODetail.SONumber WHERE     (t_SO.SONumber = N'" + this.txtSO.Text.Trim() + "')";
                this.dsPR = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (this.dsPR.Tables[0].Rows.Count == 0) { this.dsPR.Tables.Clear(); this.MyGrid(dgvView); this.cbCustomer.Enabled = true; this.cbCustomer.Text = string.Empty; return; }
                bView = 1;
                for (byte ii = 0; ii < this.dsPR.Tables[0].Rows.Count; ii++)
                {
                    this.dsPR.Tables[0].Rows[ii]["ItemNo"] = Convert.ToInt32(ii + 1);
                }


                for (int i = 0; i < this.cbCustomer.Items.Count; i++)
                {
                    if ((this.cbCustomer.Items[i] as DataRowView).Row[1].ToString().Contains(this.dsPR.Tables[0].Rows[0]["CustomerCode"].ToString()))
                    {
                        this.cbCustomer.SelectedIndex = i; break;
                    }
                }
               
                this.txtCustPO.Text = this.dsPR.Tables[0].Rows[0]["CustPOOrder"].ToString();
                this.dsPR.Tables[0].Columns.Remove("CustomerCode"); this.dsPR.Tables[0].Columns.Remove("CustPOOrder");
                this.cbCustomer.Enabled = false; this.txtRemark.Enabled = false; this.txtCustPO.Enabled = false;
                if (!Convert.ToBoolean(this.dsPR.Tables[0].Rows[0]["SOApprove"]))
                {
                    this.btnAppr.Visible = true; this.btnCancelSO.Visible = true; this.btnSave.Visible = true;

                    //Approve
                    if (NP_Cls.AppSO == 1) { this.btnAppr.Visible = true; } else { this.btnAppr.Visible = false; }

                    NP_Cls.SqlSelect = "SELECT MaterialName, MaterialCode FROM  m_Material WHERE (FileStatus = N'1')";
                    NP.BindCB(this.cbMaterial, NP_Cls.SqlSelect, "MaterialName", "MaterialCode", "((( Select Material )))");
                    this.cbMaterial.Select(); this.cbMaterial.SelectAll();
                }
                else
                {
                    this.btnAppr.Visible = false; this.btnCancelSO.Visible = false; this.btnSave.Visible = false;
                }

            

                this.dsPR.Tables[0].Columns.Remove("SOApprove");
                this.dsPR.AcceptChanges();
                this.dgvView.DataSource = this.dsPR.Tables[0];

                // Head
                this.btnAddSO.Visible = false; 
                // Detail
                this.dgvView.ClearSelection();
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            NP_Cls.myInteger(sender, e);
        }

        private void dgvView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.dgvView.CurrentRow.Cells[8].Value = Convert.ToInt32(this.dgvView.CurrentRow.Cells[7].Value) * Convert.ToInt32(this.dgvView.CurrentRow.Cells[4].Value);
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Edit Cell : " + ex.Message); return;
            }            
        }
        private void dgvView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvView.CurrentCell.ColumnIndex == 4)
            {
                TextBox txtBox = e.Control as TextBox;
                txtBox.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
            }
        }
        private void DeletetoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.dgvView.Rows.Count == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data not found !!"); return; }
            this.dsPR.Tables[0].Rows.RemoveAt(this.dgvView.CurrentRow.Index);
            this.dgvView.DataSource = this.dsPR.Tables[0];
        }
        private void btnAppr_Click(object sender, EventArgs e)
        {
            if (NP.MSGB("Do you want Approve Sale Order ?") == DialogResult.Yes)
            {
                try
                {
                    oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                    if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                    oConn.Open(); SqlTransaction Tr;
                    Tr = oConn.BeginTransaction();

                    SqlCommand cmdUp = new SqlCommand();
                    string strErr = string.Empty;
                    NP_Cls.sqlUpdate = "UPDATE t_SO SET SOApprove = 1, UserUpdate = @UserUpdate, DateUpdate = GETDATE() WHERE (SONumber = @SONumber)";
                    cmdUp.Parameters.Add("@UserUpdate", SqlDbType.NVarChar, 100).Value = NP_Cls.strUsr;
                    cmdUp.Parameters.Add("@SONumber", SqlDbType.NVarChar, 100).Value = this.txtSO.Text.Trim();
                    cmdUp.Connection = oConn; cmdUp.CommandText = NP_Cls.sqlUpdate; cmdUp.Transaction = Tr;
                    cmdUp.ExecuteNonQuery();

                    ////TODO For BOM
                    //// Get Material from SONumber & Check that Material in BOM Process
                    ////NP_Cls.SqlSelect = "SELECT DISTINCT t_SODetail.MaterialCode, t_SODetail.SOQuantity, t_BOM.BOMCode, t_SODetail.UnitCode, t_SODetail.DeliveryDate  FROM t_SODetail INNER JOIN t_SO ON t_SODetail.SONumber = t_SO.SONumber INNER JOIN  t_BOM ON t_SODetail.MaterialCode = t_BOM.MaterialCode WHERE  (t_BOM.FileStatus = N'1') AND (t_BOM.Approve = 1) AND  (t_SO.SOApprove = 1) AND (t_SODetail.SONumber = N'" + this.txtSO.Text.Trim() + "')";
                    //NP_Cls.SqlSelect = "SELECT DISTINCT t_SODetail.MaterialCode, t_SODetail.SOQuantity, t_SODetail.UnitCode, t_SODetail.DeliveryDate FROM t_SODetail INNER JOIN t_SO ON t_SODetail.SONumber = t_SO.SONumber WHERE (t_SO.SOApprove = 1) AND (t_SODetail.SONumber = N'"+ this.txtSO.Text.Trim() +"')";
                    //DataSet dsFBom = new DataSet(); dsFBom = NP.GetDataWithTran(NP_Cls.SqlSelect, Tr, oConn);
                    //if (dsFBom.Tables[0].Rows.Count > 0)
                    //{
                    //    cmdUp.Parameters.Add("@ItemSeq", SqlDbType.Int);
                    //    cmdUp.Parameters.Add("@FGCode", SqlDbType.NVarChar, 12);
                    //    cmdUp.Parameters.Add("@FGQty", SqlDbType.Decimal);
                    //    cmdUp.Parameters.Add("@FGUnitCode", SqlDbType.NVarChar, 3);
                    //    cmdUp.Parameters.Add("@HeadBomCode", SqlDbType.NVarChar, 12);
                    //    cmdUp.Parameters.Add("@ComponentCode", SqlDbType.NVarChar, 12);
                    //    cmdUp.Parameters.Add("@ProcurementType", SqlDbType.NVarChar, 1);
                    //    cmdUp.Parameters.Add("@ComponentQty", SqlDbType.Decimal);
                    //    cmdUp.Parameters.Add("@ComponentUnitCode", SqlDbType.NVarChar, 3);
                    //    cmdUp.Parameters.Add("@DeliveryDate", SqlDbType.DateTime);

                    //    for (int i = 0; i < dsFBom.Tables[0].Rows.Count; i++)
                    //    {
                    //        GenBOMNCate(dsFBom, i, dsFBom.Tables[0].Rows[i]["MaterialCode"].ToString(), cmdUp, oConn, Tr, Convert.ToDateTime(dsFBom.Tables[0].Rows[i]["DeliveryDate"]));
                    //    }
                    //}
                    //else //TODO 19.11.10 Mat is PR
                    //{ }               
                    
                    //
                    Tr.Commit();
                    Clear(); this.txtSO.DropDownStyle = ComboBoxStyle.Simple; this.cbCustomer.Enabled = true;
                    this.groupPR.Enabled = true; this.btnAddSO.Visible = true; this.btnSave.Visible = false; this.cbMaterial.Text = string.Empty; this.cbMaterial.DataSource = null;
                    this.MyGrid(dgvView); this.txtSO.Text = GetNumber(); this.btnAppr.Visible = false;
                    this.cbCustomer.Text = string.Empty; this.cbCustomer.Select(); this.cbCustomer.SelectAll();
                }
                catch (Exception ex)
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Approve : " + ex.Message); return;
                }
            }
            else
            {
                return;
            }
        }
        private void GenBOMNCate(DataSet dsFBom, int i, string strMCode, SqlCommand cmdUp, SqlConnection oConn, SqlTransaction Tr, DateTime dDelivery)
        {
            try
            {
                NP_Cls.SqlSelect = "SELECT     t_BOM.BOMCode, t_BOM.MaterialCode, t_BOM.Quantity AS BOMQty, t_BOM.UnitCode AS BOMUnit, t_BOMDetail.MaterialCode AS Comp,   t_BOMDetail.Quantity AS CompQty, t_BOMDetail.LossPercentage,  t_BOMDetail.Quantity + t_BOMDetail.Quantity * t_BOMDetail.LossPercentage / 100 AS MLoss, m_Material.ProcurementType, m_Material.UnitCode, t_BOMDetail.Category, m_Material.GRProcessingTime, m_Material.DeliveryTime, m_Material.InHouseProduction, m_Material.ShelfLife,                       m_Material.MovAvgPrice  FROM  t_BOM INNER JOIN    t_BOMDetail ON t_BOM.BOMCode = t_BOMDetail.BOMCode LEFT OUTER JOIN m_Material ON t_BOMDetail.MaterialCode = m_Material.MaterialCode WHERE     (t_BOM.MaterialCode = N'" + strMCode + "') AND (t_BOM.FileStatus = N'1') AND (t_BOM.Approve = 1)";
                DataSet dsB = new DataSet();
                dsB = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (dsB.Tables[0].Rows.Count > 0)
                {
                    for (int j = 0; j < dsB.Tables[0].Rows.Count; j++)
                    {
                        // Trimatic
                        double dBomQty = Convert.ToDouble(dsFBom.Tables[0].Rows[i]["SOQuantity"]);
                        double dMLoss = Convert.ToDouble(dsB.Tables[0].Rows[j]["MLoss"]);
                        double dBomMasterQty = Convert.ToDouble(dsB.Tables[0].Rows[j]["BOMQty"]);
                        double dComReq = (dBomQty * dMLoss) / dBomMasterQty;

                        // Require Date
                        DateTime dMatReq = Convert.ToDateTime(dDelivery);
                        Int32 SubtrDate = 0;
                        if (!string.IsNullOrEmpty((dsB.Tables[0].Rows[j]["ProcurementType"].ToString())))
                        {
                            if (dsB.Tables[0].Rows[j]["ProcurementType"].ToString().ToUpper() == "F")
                            {
                                // Buy Cal about GR, InHouse
                                SubtrDate = Convert.ToInt32(dsB.Tables[0].Rows[j]["GRProcessingTime"]) + Convert.ToInt32(dsB.Tables[0].Rows[j]["InHouseProduction"]);
                            }
                            else
                            {
                                // Sell Cal about GR, Lead time
                                SubtrDate = Convert.ToInt32(dsB.Tables[0].Rows[j]["GRProcessingTime"]) + Convert.ToInt32(dsB.Tables[0].Rows[j]["DeliveryTime"]);
                            }
                        }
                        else
                        { } // Nothin to do right now


                        NP_Cls.SqlInsert = "INSERT INTO t_MRPBOM " +
                  "(SONumber, ItemSeq, FGCode, FGQty, FGUnitCode, HeadBomCode, ComponentCode, ProcurementType, ComponentQty, ComponentUnitCode, RequireDate) " +
        "VALUES     (@SONumber,@ItemSeq,@FGCode,@FGQty,@FGUnitCode,@HeadBomCode,@ComponentCode,@ProcurementType,@ComponentQty,@ComponentUnitCode,@DeliveryDate)";
                        cmdUp.Parameters["@ItemSeq"].Value = j + 1;
                        cmdUp.Parameters["@FGCode"].Value = dsFBom.Tables[0].Rows[i]["MaterialCode"].ToString();
                        cmdUp.Parameters["@FGQty"].Value = dBomQty;
                        cmdUp.Parameters["@FGUnitCode"].Value = dsFBom.Tables[0].Rows[i]["UnitCode"].ToString();
                        cmdUp.Parameters["@HeadBomCode"].Value = dsB.Tables[0].Rows[j]["MaterialCode"].ToString();
                        cmdUp.Parameters["@ComponentCode"].Value = dsB.Tables[0].Rows[j]["Comp"].ToString();
                        cmdUp.Parameters["@ProcurementType"].Value = dsB.Tables[0].Rows[j]["ProcurementType"].ToString();
                        cmdUp.Parameters["@ComponentQty"].Value = dComReq;
                        cmdUp.Parameters["@ComponentUnitCode"].Value = dsB.Tables[0].Rows[j]["UnitCode"].ToString();
                        cmdUp.Parameters["@DeliveryDate"].Value = Convert.ToDateTime(dDelivery).AddDays(-SubtrDate);
                        cmdUp.Connection = oConn; cmdUp.CommandText = NP_Cls.SqlInsert; cmdUp.Transaction = Tr;
                        cmdUp.ExecuteNonQuery();

                        if (!string.IsNullOrEmpty(dsB.Tables[0].Rows[j]["Category"].ToString()))
                        {
                            GenBOMNCate(dsFBom, i, dsB.Tables[0].Rows[j]["Comp"].ToString(), cmdUp, oConn, Tr, dDelivery);
                        }
                    }
                }
                else // If 'F' 
                {
                    NP_Cls.SqlSelect = "SELECT     GRProcessingTime, DeliveryTime FROM m_Material WHERE (MaterialCode = N'"+ strMCode +"')";
                    DataSet dsT = new DataSet(); dsT = NP.GetDataWithTran(NP_Cls.SqlSelect, Tr, oConn);
                    // Require Date
                    DateTime dMatReq = Convert.ToDateTime(dDelivery);
                    Int32 SubtrDate = 0;

                    // Sell Cal about GR, Lead time
                    SubtrDate = Convert.ToInt32(dsT.Tables[0].Rows[0]["GRProcessingTime"]) + Convert.ToInt32(dsT.Tables[0].Rows[0]["DeliveryTime"]);

                    NP_Cls.SqlInsert = "INSERT INTO t_MRPBOM " +
                "(SONumber, ItemSeq, FGCode, FGQty, FGUnitCode, HeadBomCode, ComponentCode, ProcurementType, ComponentQty, ComponentUnitCode, RequireDate) " +
      "VALUES     (@SONumber,@ItemSeq,@FGCode,@FGQty,@FGUnitCode,@HeadBomCode,@ComponentCode,@ProcurementType,@ComponentQty,@ComponentUnitCode,@DeliveryDate)";
                    cmdUp.Parameters["@ItemSeq"].Value = 1;
                    cmdUp.Parameters["@FGCode"].Value = dsFBom.Tables[0].Rows[i]["MaterialCode"].ToString();
                    cmdUp.Parameters["@FGQty"].Value = Convert.ToDecimal(dsFBom.Tables[0].Rows[i]["SOQuantity"].ToString());
                    cmdUp.Parameters["@FGUnitCode"].Value = dsFBom.Tables[0].Rows[i]["UnitCode"].ToString();
                    cmdUp.Parameters["@HeadBomCode"].Value = dsFBom.Tables[0].Rows[i]["MaterialCode"].ToString();
                    cmdUp.Parameters["@ComponentCode"].Value = dsFBom.Tables[0].Rows[i]["MaterialCode"].ToString();
                    cmdUp.Parameters["@ProcurementType"].Value = "F";
                    cmdUp.Parameters["@ComponentQty"].Value = Convert.ToDecimal(dsFBom.Tables[0].Rows[i]["SOQuantity"].ToString());
                    cmdUp.Parameters["@ComponentUnitCode"].Value = dsFBom.Tables[0].Rows[i]["UnitCode"].ToString();
                    cmdUp.Parameters["@DeliveryDate"].Value = Convert.ToDateTime(dDelivery).AddDays(-SubtrDate);
                    cmdUp.Connection = oConn; cmdUp.CommandText = NP_Cls.SqlInsert; cmdUp.Transaction = Tr;
                    cmdUp.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //
        #region "ClassForDateColumn"
        public class CalendarColumn : DataGridViewColumn
        {
            public CalendarColumn()
                : base(new CalendarCell())
            {
            }

            public override DataGridViewCell CellTemplate
            {
                get
                {
                    return base.CellTemplate;
                }
                set
                {
                    // Ensure that the cell used for the template is a CalendarCell.
                    if (value != null &&
                        !value.GetType().IsAssignableFrom(typeof(CalendarCell)))
                    {
                        throw new InvalidCastException("Must be a CalendarCell");
                    }
                    base.CellTemplate = value;
                }
            }
        }

        public class CalendarCell : DataGridViewTextBoxCell
        {

            public CalendarCell()
                : base()
            {
                // Use the short date format.
                this.Style.Format = "d";
            }

            public override void InitializeEditingControl(int rowIndex, object
                initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
            {
                // Set the value of the editing control to the current cell value.
                base.InitializeEditingControl(rowIndex, initialFormattedValue,
                    dataGridViewCellStyle);
                CalendarEditingControl ctl =
                    DataGridView.EditingControl as CalendarEditingControl;
                // Use the default row value when Value property is null.
                try
                {
                    if (this.Value == null)
                    {
                        ctl.Value = (DateTime)this.DefaultNewRowValue;
                    }
                    else
                    {
                        ctl.Value = (DateTime)this.Value;
                    }
                }
                catch
                { }
            }

            public override Type EditType
            {
                get
                {
                    // Return the type of the editing control that CalendarCell uses.
                    return typeof(CalendarEditingControl);
                }
            }

            public override Type ValueType
            {
                get
                {
                    // Return the type of the value that CalendarCell contains.

                    return typeof(DateTime);
                }
            }

            public override object DefaultNewRowValue
            {
                get
                {
                    // Use the current date and time as the default value.
                    return DateTime.Now;
                }
            }
        }

        class CalendarEditingControl : DateTimePicker, IDataGridViewEditingControl
        {
            DataGridView dataGridView;
            private bool valueChanged = false;
            int rowIndex;

            public CalendarEditingControl()
            {
                this.Format = DateTimePickerFormat.Short;
            }

            // Implements the IDataGridViewEditingControl.EditingControlFormattedValue 
            // property.
            public object EditingControlFormattedValue
            {
                get
                {
                    return this.Value.ToShortDateString();
                }
                set
                {
                    if (value is String)
                    {
                        try
                        {
                            // This will throw an exception of the string is 
                            // null, empty, or not in the format of a date.
                            this.Value = DateTime.Parse((String)value);
                        }
                        catch
                        {
                            // In the case of an exception, just use the 
                            // default value so we're not left with a null
                            // value.
                            this.Value = DateTime.Now;
                        }
                    }
                }
            }

            // Implements the 
            // IDataGridViewEditingControl.GetEditingControlFormattedValue method.
            public object GetEditingControlFormattedValue(
                DataGridViewDataErrorContexts context)
            {
                return EditingControlFormattedValue;
            }

            // Implements the 
            // IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
            public void ApplyCellStyleToEditingControl(
                DataGridViewCellStyle dataGridViewCellStyle)
            {
                this.Font = dataGridViewCellStyle.Font;
                this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
                this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
            }

            // Implements the IDataGridViewEditingControl.EditingControlRowIndex 
            // property.
            public int EditingControlRowIndex
            {
                get
                {
                    return rowIndex;
                }
                set
                {
                    rowIndex = value;
                }
            }

            // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey 
            // method.
            public bool EditingControlWantsInputKey(
                Keys key, bool dataGridViewWantsInputKey)
            {
                // Let the DateTimePicker handle the keys listed.
                switch (key & Keys.KeyCode)
                {
                    case Keys.Left:
                    case Keys.Up:
                    case Keys.Down:
                    case Keys.Right:
                    case Keys.Home:
                    case Keys.End:
                    case Keys.PageDown:
                    case Keys.PageUp:
                        return true;
                    default:
                        return !dataGridViewWantsInputKey;
                }
            }

            // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit 
            // method.
            public void PrepareEditingControlForEdit(bool selectAll)
            {
                // No preparation needs to be done.
            }

            // Implements the IDataGridViewEditingControl
            // .RepositionEditingControlOnValueChange property.
            public bool RepositionEditingControlOnValueChange
            {
                get
                {
                    return false;
                }
            }

            // Implements the IDataGridViewEditingControl
            // .EditingControlDataGridView property.
            public DataGridView EditingControlDataGridView
            {
                get
                {
                    return dataGridView;
                }
                set
                {
                    dataGridView = value;
                }
            }

            // Implements the IDataGridViewEditingControl
            // .EditingControlValueChanged property.
            public bool EditingControlValueChanged
            {
                get
                {
                    return valueChanged;
                }
                set
                {
                    valueChanged = value;
                }
            }

            // Implements the IDataGridViewEditingControl
            // .EditingPanelCursor property.
            public Cursor EditingPanelCursor
            {
                get
                {
                    return base.Cursor;
                }
            }

            protected override void OnValueChanged(EventArgs eventargs)
            {
                // Notify the DataGridView that the contents of the cell
                // have changed.
                valueChanged = true;
                this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
                base.OnValueChanged(eventargs);
            }
        }
        #endregion
        //
    }
}
