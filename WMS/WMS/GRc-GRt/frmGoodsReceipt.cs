using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WMS.GRc_GRt
{
    public partial class frmGoodsReceipt : Form
    {
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection(); private byte bView = 0;
        private string strGNumber = string.Empty; private DataSet dsPR = new DataSet();
        public frmGoodsReceipt()
        {
            InitializeComponent();
        }
        private void MyGrid(DataGridView grid)
        {
            NP_Cls.SqlSelect = "SELECT     1 AS ItemNo, t_PODetail.MaterialCode, t_PODetail.MaterialName, t_PODetail.POQuantity AS GRQty, t_PODetail.UnitCode, t_PODetail.UnitName, t_PODetail.PlantCode,                        t_PODetail.LocCode, '...' AS BatchNumber, t_PODetail.DeliveryDate, t_PO.PONumber, t_PODetail.NetPrice, t_PODetail.POAmount AS GRAmt, t_PODetail.PlantName,                        t_PODetail.LocName, t_PODetail.AutoID, t_PRDetail.QtyConversion AS MasterQty, m_Material.UnitCode AS MasterUnitCode, m_Unit.UnitName AS MasterUnitName FROM         t_PO INNER JOIN                       t_PODetail ON t_PO.PONumber = t_PODetail.PONumber INNER JOIN                       t_PRDetail ON t_PODetail.PRNumber = t_PRDetail.PRNumber AND t_PODetail.MaterialCode = t_PRDetail.MaterialCode INNER JOIN                       m_Material ON t_PRDetail.MaterialCode = m_Material.MaterialCode INNER JOIN                       m_Unit ON m_Material.UnitCode = m_Unit.UnitCode WHERE (t_PO.VendorCode = N'') AND (t_PO.PONumber = N'')";
            this.dsPR = NP.GetClientDataSet(NP_Cls.SqlSelect);
            grid.DataSource = this.dsPR.Tables[0];
        }

        private void frmGoodsReceipt_Load(object sender, EventArgs e)
        {
            try
            {
                WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
                frm.menuStrip1.Enabled = true;

                this.txtDoc.Text = GetNumber(); this.txtDocDate.Text = NP.GetDateServer().ToString("dd/MM/yyyy");

                BindVendor();

                this.MyGrid(dgvView);

                Clear();
                this.cbVendor.Text = string.Empty; this.txtInv.Select();
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Load : " + ex.Message); return;
            }
        }

        private void BindVendor()
        {
            NP_Cls.SqlSelect = "SELECT DISTINCT t_PO.VendorName, t_PO.VendorCode + ':' + t_PO.VendorName AS VendorCode FROM         t_PODetail INNER JOIN                       t_PO ON t_PODetail.PONumber = t_PO.PONumber LEFT OUTER JOIN                           (SELECT     SUM(Quantity) AS Qty, RefNumber, RefAutoID, MaterialCode                             FROM          t_StockMovementDetail                             GROUP BY RefNumber, RefAutoID, MaterialCode) AS GR ON t_PODetail.AutoID = GR.RefAutoID AND t_PODetail.PONumber = GR.RefNumber WHERE     (Isnull(t_PODetail.POQuantity,0) - isnull(t_PODetail.GRQuantity,0) <> 0) AND (t_PO.POApprove = 1)";
            NP.BindCB(this.cbVendor, NP_Cls.SqlSelect, "VendorName", "VendorCode", "((( Select Vendor PO )))");
        }
        private void Clear()
        {
            this.lblVendorName.Text = string.Empty; this.txtInv.Text = string.Empty;
            this.lblPG.Text = string.Empty;
        }
        private string GetNumber()
        {
            try
            {
                NP_Cls.SqlSelect = "SELECT top (1) CONVERT(int, RIGHT(DocNumber, 4)) AS SS, RIGHT(CONVERT(nvarchar, GETDATE(), 112), 6) AS s FROM   t_StockMovement WHERE (RIGHT(CONVERT(nvarchar, GETDATE(), 112), 6) = LEFT(RIGHT(DocNumber, 10), 6)) AND (LEFT(DocNumber, 2) = 'GR') ORDER BY SS DESC";
                DataSet dsGen = new DataSet(); dsGen = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (dsGen.Tables[0].Rows.Count == 0)
                {
                    NP_Cls.SqlSelect = "SELECT  TOP (1) RIGHT(CONVERT(nvarchar, GETDATE(), 112), 6) AS s";
                    return "GR" + NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0].Rows[0][0].ToString() + "0001";
                }
                else
                {
                    //string strCode = (Convert.ToInt16(dsGen.Tables[0].Rows[0][0].ToString()) + 1).ToString().PadLeft(5 - (Convert.ToInt16(dsGen.Tables[0].Rows[0][0].ToString()) + 1).ToString().Length, '0');
                    string strCode = (Convert.ToInt16(dsGen.Tables[0].Rows[0][0].ToString()) + 1).ToString().PadLeft(4, '0');
                    return "GR" + dsGen.Tables[0].Rows[0][1].ToString() + strCode;
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
                    NP_Cls.SqlSelect = "SELECT     VendorCode, VendorName, PurchasingGroup FROM  t_PO WHERE   (VendorCode = N'" + this.cbVendor.Text.Trim().Split(':')[0] + "')";
                    dsDetail = NP.GetClientDataSet(NP_Cls.SqlSelect);
                    this.lblPG.Text = dsDetail.Tables[0].Rows[0]["PurchasingGroup"].ToString();
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
                    if (NP.MSGB("The GR list will be cancel , Do you agree with this ?") == DialogResult.Yes)
                    {
                        // Cancel
                        oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                        if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                        oConn.Open(); SqlTransaction Tr;
                        Tr = oConn.BeginTransaction();

                        try
                        {
                            SqlCommand cmd = new SqlCommand();
                            NP_Cls.SqlDel = "DELETE FROM t_StockMovement WHERE (DocNumber = @DocNumber)";
                            cmd.Parameters.Add("@DocNumber", SqlDbType.NVarChar, 12).Value = this.txtDoc.Text.Trim();
                            cmd.CommandText = NP_Cls.SqlDel; cmd.Connection = oConn; cmd.Transaction = Tr;
                            cmd.ExecuteNonQuery();

                            NP_Cls.SqlDel = "DELETE FROM t_StockMovementDetail WHERE (DocNumber = @DocNumber)";
                            cmd.CommandText = NP_Cls.SqlDel; cmd.Connection = oConn; cmd.Transaction = Tr;
                            cmd.ExecuteNonQuery();

                            Tr.Commit();
                        }
                        catch (Exception ex)
                        {
                            NP.MSGB("Del : " + ex.Message);
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
        private void frmGoodsReceipt_FormClosing(object sender, FormClosingEventArgs e)
        {
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;
        }

        private void btnAddPR_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtInv.Text.Trim())) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please enter Invoice Number first !!"); this.txtInv.Select(); return; }
            if ((!string.IsNullOrEmpty(this.cbVendor.Text.Trim())) && (this.cbVendor.SelectedIndex != 0))
            {
                //
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }

                oConn.Open();
                try
                {
                    SqlCommand cmdIns = new SqlCommand();


                    NP_Cls.SqlInsert = "INSERT INTO t_StockMovement " +
                      "(DocNumber, RefNumber, TranDate, VendorCode, VendorName, PurchasingGroup, MovementType, Remark, UserCreate, DateCreate) " +
"VALUES     (@DocNumber,@Invoice, GETDATE(),@VendorCode,@VendorName,@PurchasingGroup,@MovementType,@Remark,@UC,GETDATE())";
                    this.strGNumber = GetNumber();
                    cmdIns.Parameters.Add("@DocNumber", SqlDbType.NVarChar, 12).Value = this.strGNumber;
                    cmdIns.Parameters.Add("@Invoice", SqlDbType.NVarChar, 20).Value = this.txtInv.Text.Trim();
                    cmdIns.Parameters.Add("@VendorCode", SqlDbType.NVarChar, 10).Value = this.cbVendor.Text.Trim().Split(':')[0];
                    cmdIns.Parameters.Add("@VendorName", SqlDbType.NVarChar, 60).Value = this.lblVendorName.Text.Trim();
                    cmdIns.Parameters.Add("@PurchasingGroup", SqlDbType.NVarChar, 3).Value = this.lblPG.Text.Trim();
                    cmdIns.Parameters.Add("@MovementType", SqlDbType.NVarChar, 3).Value = this.lblMovType.Text.Trim();
                    cmdIns.Parameters.Add("@Remark", SqlDbType.NVarChar, 255).Value = this.txtRemark.Text.Trim();
                    cmdIns.Parameters.Add("@UC", SqlDbType.NVarChar, 50).Value = NP_Cls.strUsr;
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert;
                    cmdIns.ExecuteNonQuery();

                    this.groupPR.Enabled = false; this.btnAddPR.Visible = false; this.btnSave.Visible = true;
                    NP_Cls.SqlSelect = "SELECT DISTINCT t_PO.PONumber, t_PO.PONumber AS PODis FROM t_PO INNER JOIN t_PODetail ON t_PO.PONumber = t_PODetail.PONumber WHERE     (t_PO.POApprove = 1) AND (t_PO.ClosePO = 'P') AND (VendorCode = N'" + this.cbVendor.Text.Trim().Split(':')[0] + "')";
                    NP.BindCB(this.cbPONumber, NP_Cls.SqlSelect, "PONumber", "PODis", "((( Select PO Number )))");


                    this.cbPONumber.Select(); this.cbPONumber.SelectAll();
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
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please select vendor first !!"); this.cbVendor.Select(); return;
            }
        }
        private void btnCancelPR_Click(object sender, EventArgs e)
        {
            if (NP.MSGB("Do you to cancel Goods Receipt ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr;
                Tr = oConn.BeginTransaction();

                try
                {
                    SqlCommand cmd = new SqlCommand();
                    NP_Cls.SqlDel = "DELETE FROM t_StockMovement WHERE (DocNumber = @DocNumber)";
                    cmd.Parameters.Add("@DocNumber", SqlDbType.NVarChar, 12).Value = this.txtDoc.Text.Trim();
                    cmd.CommandText = NP_Cls.SqlDel; cmd.Connection = oConn; cmd.Transaction = Tr;
                    cmd.ExecuteNonQuery();

                    NP_Cls.SqlDel = "DELETE FROM t_StockMovementDetail WHERE (DocNumber = @DocNumber)";
                    cmd.CommandText = NP_Cls.SqlDel; cmd.Connection = oConn; cmd.Transaction = Tr;
                    cmd.ExecuteNonQuery();

                    Tr.Commit();
                }
                catch (Exception ex)
                {
                    NP.MSGB("Del : " + ex.Message);
                }
                finally
                {
                    if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                }
                Clear(); this.groupPR.Enabled = true; this.cbPONumber.Text = string.Empty;
                if (this.dsPR.Tables.Count > 0) { this.dsPR.Tables.Clear(); this.MyGrid(this.dgvView); }
                this.cbPONumber.DataSource = null; this.cbMaterial.Text = string.Empty; this.cbMaterial.DataSource = null;
                this.btnAddPR.Visible = true; this.btnSave.Visible = false;

                BindVendor();
                this.cbVendor.Text = string.Empty; this.txtInv.Select();
            }
            else
            {
                return;
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.cbPONumber.Text.Trim()))
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please add GR Header first !!"); return;
            }
            else
            {
                if (this.cbPONumber.SelectedIndex == 0)
                {
                    NP.ReqField(this.cbPONumber, "Please select PO Number first !!"); return;
                }
                else
                {
                    if (this.cbMaterial.SelectedIndex > 0)
                    {
                        if (this.dsPR.Tables[0].Rows.Count > 0)
                        {
                            for (byte ii = 0; ii < this.dsPR.Tables[0].Rows.Count; ii++)
                            {
                                //TODO RefNumber
                                if ((this.cbPONumber.Text.Trim() == this.dsPR.Tables[0].Rows[ii]["PONumber"].ToString()) && (this.cbMaterial.Text.Trim().Split(':')[0].ToString() == this.dsPR.Tables[0].Rows[ii]["MaterialCode"].ToString()) && (this.cbMaterial.Text.Trim().Split(':')[1].ToString() == this.dsPR.Tables[0].Rows[ii]["GRQty"].ToString()))
                                {
                                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "This PO Number & Material are in GR List !!"); this.cbPONumber.Select(); this.cbPONumber.SelectAll(); return;
                                }
                            }
                        }
                        else if (this.dsPR.Tables[0].Rows.Count == 0)
                        {
                            //
                            //NP_Cls.SqlSelect = "SELECT 1 AS ItemNo, t_PODetail.MaterialCode, t_PODetail.MaterialName, t_PODetail.POQuantity - ISNULL(t_PODetail.GRQuantity, 0) AS GRQty, t_PODetail.UnitCode,                        t_PODetail.UnitName, t_PODetail.PlantCode, t_PODetail.LocCode, '...' AS BatchNumber, t_PODetail.DeliveryDate, t_PO.PONumber, t_PODetail.NetPrice,                        (t_PODetail.POQuantity - ISNULL(t_PODetail.GRQuantity, 0)) * t_PODetail.NetPrice AS GRAmt, t_PODetail.PlantName, t_PODetail.LocName, t_PODetail.AutoID,                        t_PRDetail.QtyConversion AS MasterQty, m_Material.UnitCode AS MasterUnitCode, m_Unit.UnitName AS MasterUnitName, ISNULL(m_Material.StandardCost,0) AS MatCost FROM         t_PO INNER JOIN                       t_PODetail ON t_PO.PONumber = t_PODetail.PONumber INNER JOIN                       t_PRDetail ON t_PODetail.PRNumber = t_PRDetail.PRNumber AND t_PODetail.MaterialCode = t_PRDetail.MaterialCode INNER JOIN                       m_Material ON t_PRDetail.MaterialCode = m_Material.MaterialCode INNER JOIN                       m_Unit ON m_Material.UnitCode = m_Unit.UnitCode WHERE (t_PO.VendorCode = N'" + this.cbVendor.Text.Trim().Split(':')[0] + "') AND (t_PO.PONumber = N'" + this.cbPONumber.Text.Trim() + "') AND (t_PODetail.AutoID = N'" + this.cbMaterial.SelectedValue.ToString() + "')";
                            NP_Cls.SqlSelect = "SELECT  1 AS ItemNo, t_PODetail.MaterialCode, t_PODetail.MaterialName, t_PODetail.POQuantity - ISNULL(t_PODetail.GRQuantity, 0) AS GRQty, t_PODetail.UnitCode, t_PODetail.UnitName, t_PODetail.PlantCode, t_PODetail.LocCode, '...' AS BatchNumber, t_PODetail.DeliveryDate, t_PO.PONumber, t_PODetail.NetPrice,  (t_PODetail.POQuantity - ISNULL(t_PODetail.GRQuantity, 0)) * t_PODetail.NetPrice AS GRAmt, 	t_PODetail.PlantName, t_PODetail.LocName, t_PODetail.AutoID,      	((select distinct QtyConversion from t_VendorInfoRecord where t_VendorInfoRecord.MaterialCode = N'" + this.cbMaterial.Text.Trim().Split(':')[0].ToString() + "')*(t_PODetail.POQuantity - ISNULL(t_PODetail.GRQuantity, 0))) AS MasterQty, m_Material.UnitCode AS MasterUnitCode, m_Unit.UnitName AS MasterUnitName, ISNULL(m_Material.StandardCost,0) AS MatCost FROM  t_PODetail INNER JOIN  t_PO ON t_PO.PONumber = t_PODetail.PONumber INNER JOIN  m_Material ON t_PODetail.MaterialCode = m_Material.MaterialCode INNER JOIN m_Unit ON m_Material.UnitCode = m_Unit.UnitCode  WHERE (t_PO.VendorCode = N'" + this.cbVendor.Text.Trim().Split(':')[0] + "') AND (t_PO.PONumber = N'" + this.cbPONumber.Text.Trim() + "') AND (t_PODetail.AutoID = N'" + this.cbMaterial.SelectedValue.ToString() + "')";
                            this.dsPR = NP.GetClientDataSet(NP_Cls.SqlSelect);
                            for (byte ii = 0; ii < this.dsPR.Tables[0].Rows.Count; ii++)
                            {
                                this.dsPR.Tables[0].Rows[ii]["ItemNo"] = Convert.ToInt32(ii + 1);
                                //this.dsPR.Tables[0].Rows[ii]["BatchNumber"] = NP_Cls._genBatch(this.dsPR.Tables[0].Rows[ii]["MaterialCode"].ToString());
                            }
                            this.dsPR.AcceptChanges();
                            this.dgvView.DataSource = this.dsPR.Tables[0];
                            return;
                            //
                        }

                        // if Row >  1
                        //NP_Cls.SqlSelect = "SELECT     1 AS ItemNo, t_PODetail.MaterialCode, t_PODetail.MaterialName, t_PODetail.POQuantity - ISNULL(t_PODetail.GRQuantity, 0) AS GRQty, t_PODetail.UnitCode,                        t_PODetail.UnitName, t_PODetail.PlantCode, t_PODetail.LocCode, '...' AS BatchNumber, t_PODetail.DeliveryDate, t_PO.PONumber, t_PODetail.NetPrice,                        (t_PODetail.POQuantity - ISNULL(t_PODetail.GRQuantity, 0)) * t_PODetail.NetPrice AS GRAmt, t_PODetail.PlantName, t_PODetail.LocName, t_PODetail.AutoID,                        t_PRDetail.QtyConversion AS MasterQty, m_Material.UnitCode AS MasterUnitCode, m_Unit.UnitName AS MasterUnitName, ISNULL(m_Material.StandardCost,0) AS MatCost FROM         t_PO INNER JOIN                       t_PODetail ON t_PO.PONumber = t_PODetail.PONumber INNER JOIN                       t_PRDetail ON t_PODetail.PRNumber = t_PRDetail.PRNumber AND t_PODetail.MaterialCode = t_PRDetail.MaterialCode INNER JOIN                       m_Material ON t_PRDetail.MaterialCode = m_Material.MaterialCode INNER JOIN                       m_Unit ON m_Material.UnitCode = m_Unit.UnitCode WHERE (t_PO.VendorCode = N'" + this.cbVendor.Text.Trim().Split(':')[0] + "') AND (t_PO.PONumber = N'" + this.cbPONumber.Text.Trim() + "') AND (t_PODetail.AutoID = N'" + this.cbMaterial.SelectedValue.ToString() + "')";
                        NP_Cls.SqlSelect = "SELECT  1 AS ItemNo, t_PODetail.MaterialCode, t_PODetail.MaterialName, t_PODetail.POQuantity - ISNULL(t_PODetail.GRQuantity, 0) AS GRQty, t_PODetail.UnitCode, t_PODetail.UnitName, t_PODetail.PlantCode, t_PODetail.LocCode, '...' AS BatchNumber, t_PODetail.DeliveryDate, t_PO.PONumber, t_PODetail.NetPrice,  (t_PODetail.POQuantity - ISNULL(t_PODetail.GRQuantity, 0)) * t_PODetail.NetPrice AS GRAmt, 	t_PODetail.PlantName, t_PODetail.LocName, t_PODetail.AutoID,      	((select distinct QtyConversion from t_VendorInfoRecord where t_VendorInfoRecord.MaterialCode = N'" + this.cbMaterial.Text.Trim().Split(':')[0].ToString() + "')*(t_PODetail.POQuantity - ISNULL(t_PODetail.GRQuantity, 0))) AS MasterQty, m_Material.UnitCode AS MasterUnitCode, m_Unit.UnitName AS MasterUnitName, ISNULL(m_Material.StandardCost,0) AS MatCost FROM  t_PODetail INNER JOIN  t_PO ON t_PO.PONumber = t_PODetail.PONumber INNER JOIN  m_Material ON t_PODetail.MaterialCode = m_Material.MaterialCode INNER JOIN m_Unit ON m_Material.UnitCode = m_Unit.UnitCode  WHERE (t_PO.VendorCode = N'" + this.cbVendor.Text.Trim().Split(':')[0] + "') AND (t_PO.PONumber = N'" + this.cbPONumber.Text.Trim() + "') AND (t_PODetail.AutoID = N'" + this.cbMaterial.SelectedValue.ToString() + "')";
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
                    }
                    else
                    {
                        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please select Material first !! !!"); this.cbMaterial.Select(); this.cbMaterial.SelectAll(); return;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.dgvView.RowCount == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please select PO number into GR list !!"); this.cbPONumber.Select(); return; }
            this.dgvView.EndEdit();

            if (NP.MSGB("Do you to Save Goods Receipt ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr;
                Tr = oConn.BeginTransaction();

                try
                {
                    SqlCommand cmdIns = new SqlCommand();

                    NP_Cls.SqlInsert = "INSERT INTO t_StockMovementDetail " +
                      "(AutoID, DocNumber, MaterialCode, MaterialName, Quantity, UnitCode, UnitName, NetPrice, Amount, DeliveryDate, PlantCode, PlantName, LocCode, LocName, BatchNumber, CurrentUser, RefNumber, RefAutoID, QtyConversion, RecUnitCode,RecUnitName) " +
"VALUES     (@ID, @GRNumber,@MaterialCode,@MaterialName,@GRQuantity,@UnitCode,@UnitName,@NetPrice,@GRAmount,@DeliveryDate,@PlantCode,@PlantName,@LocCode,@LocName,@BatchNumber,@CurrentUser,@PONumber, @POID, @QtyConversion, @RecUnitCode, @RecUnitName)";
                    cmdIns.Parameters.Add("@ID", SqlDbType.Int);
                    cmdIns.Parameters.Add("@GRNumber", SqlDbType.NVarChar, 12);
                    cmdIns.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15);
                    cmdIns.Parameters.Add("@MaterialName", SqlDbType.NVarChar, 60);
                    cmdIns.Parameters.Add("@GRQuantity", SqlDbType.Decimal);
                    cmdIns.Parameters.Add("@UnitCode", SqlDbType.NVarChar, 3);
                    cmdIns.Parameters.Add("@UnitName", SqlDbType.NVarChar, 20);
                    cmdIns.Parameters.Add("@NetPrice", SqlDbType.Decimal);
                    cmdIns.Parameters.Add("@GRAmount", SqlDbType.Decimal);
                    cmdIns.Parameters.Add("@DeliveryDate", SqlDbType.DateTime);
                    cmdIns.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 4);
                    cmdIns.Parameters.Add("@PlantName", SqlDbType.NVarChar, 20);
                    cmdIns.Parameters.Add("@LocCode", SqlDbType.NVarChar, 2);
                    cmdIns.Parameters.Add("@LocName", SqlDbType.NVarChar, 20);
                    cmdIns.Parameters.Add("@BatchNumber", SqlDbType.NVarChar, 20);
                    cmdIns.Parameters.Add("@PONumber", SqlDbType.NVarChar, 12);
                    cmdIns.Parameters.Add("@CurrentUser", SqlDbType.NVarChar, 50);
                    cmdIns.Parameters.Add("@POID", SqlDbType.Int);

                    cmdIns.Parameters.Add("@QtyConversion", SqlDbType.Decimal);
                    cmdIns.Parameters.Add("@RecUnitCode", SqlDbType.NVarChar, 3);
                    cmdIns.Parameters.Add("@RecUnitName", SqlDbType.NVarChar, 20);

                    string strTmpBatch = string.Empty;
                    List<string> myTmpBatch = new List<string>();
                    
                    // New 25.10.10 // For Stock Overview
                    cmdIns.Parameters.Add("@UR", SqlDbType.Decimal); cmdIns.Parameters.Add("@QI", SqlDbType.Decimal);
                    cmdIns.Parameters.Add("@Block", SqlDbType.Decimal); cmdIns.Parameters.Add("@UserCreate", SqlDbType.NVarChar, 10);

                    cmdIns.Parameters.Add("@Cost", SqlDbType.Decimal);
                    for (byte ins = 0; ins < this.dgvView.RowCount; ins++)
                    {
                        if (Convert.ToInt32(this.dgvView["clnQuantity", ins].Value) != 0)
                        {
                            cmdIns.Parameters["@ID"].Value = this.dgvView["clnItemNo", ins].Value.ToString();
                            cmdIns.Parameters["@GRNumber"].Value = this.strGNumber;
                            cmdIns.Parameters["@MaterialCode"].Value = this.dgvView["clnMaterialCode", ins].Value.ToString();
                            cmdIns.Parameters["@MaterialName"].Value = this.dgvView["clnMaterialName", ins].Value.ToString();
                            cmdIns.Parameters["@GRQuantity"].Value = Convert.ToDecimal(this.dgvView["clnQuantity", ins].Value);
                            cmdIns.Parameters["@UnitCode"].Value = this.dgvView["clnUnitCode", ins].Value.ToString();
                            cmdIns.Parameters["@UnitName"].Value = this.dgvView["clnUnitName", ins].Value.ToString();
                            cmdIns.Parameters["@NetPrice"].Value = Convert.ToDecimal(this.dgvView["clnNetPrice", ins].Value);
                            cmdIns.Parameters["@GRAmount"].Value = Convert.ToDecimal(this.dgvView["clnAmount", ins].Value);
                            cmdIns.Parameters["@DeliveryDate"].Value = Convert.ToDateTime(this.dgvView["clnDeliveryDate", ins].Value);
                            cmdIns.Parameters["@PlantCode"].Value = this.dgvView["clnPlantCode", ins].Value.ToString();
                            cmdIns.Parameters["@PlantName"].Value = this.dgvView["clnPlantName", ins].Value.ToString();
                            cmdIns.Parameters["@LocCode"].Value = this.dgvView["clnLocCode", ins].Value.ToString();
                            cmdIns.Parameters["@LocName"].Value = this.dgvView["clnLocName", ins].Value.ToString();
                            strTmpBatch = NP_Cls._genBatch(this.dgvView["clnMaterialCode", ins].Value.ToString(), oConn, Tr);
                            myTmpBatch.Add(strTmpBatch);
                            cmdIns.Parameters["@BatchNumber"].Value = strTmpBatch;
                            cmdIns.Parameters["@PONumber"].Value = this.dgvView["clnPONumber", ins].Value.ToString();
                            cmdIns.Parameters["@CurrentUser"].Value = NP_Cls.strUsr;
                            cmdIns.Parameters["@POID"].Value = this.dgvView["AutoID", ins].Value.ToString();
                            cmdIns.Parameters["@UR"].Value = 0;
                            cmdIns.Parameters["@QI"].Value = Convert.ToDecimal(this.dgvView["clnQuantity", ins].Value);
                            cmdIns.Parameters["@Block"].Value = 0; cmdIns.Parameters["@UserCreate"].Value = NP_Cls.strUsr;
                            cmdIns.Parameters["@Cost"].Value = Convert.ToDecimal(this.dgvView["MatCost", ins].Value) * Convert.ToDecimal(this.dgvView["clnQuantity", ins].Value);

                            cmdIns.Parameters["@QtyConversion"].Value = Convert.ToDecimal(this.dgvView["clnQuantity", ins].Value);
                            cmdIns.Parameters["@RecUnitCode"].Value = this.dgvView["MasterUnitCode", ins].Value.ToString();
                            cmdIns.Parameters["@RecUnitName"].Value = this.dgvView["MasterUnitName", ins].Value.ToString();

                            cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                            cmdIns.ExecuteNonQuery();

                            NP_Cls.sqlUpdate = "UPDATE t_PODetail SET GRQuantity = GRQuantity + @GRQuantity WHERE (PONumber = @PONumber) AND (AutoID = @POID)";
                            cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.sqlUpdate; cmdIns.Transaction = Tr;
                            cmdIns.ExecuteNonQuery();

                            //TODO Save in Stock Overview // 10.11.10
                            //string strTmp = "INSERT INTO t_StockOverview (MaterialCode, BatchNumber, PlantCode, LocCode, UnitCode, UR, QI, Block, Cost, OrigQty, UserCreate, DateCreate) VALUES (@MaterialCode,@BatchNumber, @PlantCode, @LocCode, @UnitCode,@UR,@QI,@Block,@Cost,@GRQuantity,@UserCreate, GETDATE())";
                            string strTmp = "INSERT INTO t_StockOverview (MaterialCode, BatchNumber, PlantCode, LocCode, UnitCode, UR, QI, Block, Cost, OrigQty, UserCreate, DateCreate) VALUES (@MaterialCode,@BatchNumber, @PlantCode, @LocCode, @UnitCode,@UR,@QI * isnull((select distinct QtyConversion from t_VendorInfoRecord where MaterialCode = @MaterialCode),1),@Block,@Cost,@QI * isnull((select distinct QtyConversion from t_VendorInfoRecord where MaterialCode = @MaterialCode),1),@UserCreate, GETDATE())";
                            cmdIns.Parameters["@MaterialCode"].Value = this.dgvView["clnMaterialCode", ins].Value.ToString();
                            cmdIns.Parameters["@BatchNumber"].Value = strTmpBatch;
                            cmdIns.Parameters["@UR"].Value = 0;
                            cmdIns.Parameters["@QI"].Value = Convert.ToInt32(this.dgvView["clnQuantity", ins].Value);
                            cmdIns.Parameters["@Block"].Value = 0; cmdIns.Parameters["@UserCreate"].Value = NP_Cls.strUsr;
                            cmdIns.Parameters["@Cost"].Value = Convert.ToDecimal(this.dgvView["MatCost", ins].Value) * Convert.ToDecimal(this.dgvView["clnQuantity", ins].Value);
                            //cmdIns.Parameters["@GRQuantity"].Value = Convert.ToInt32(this.dgvView["MasterQty", ins].Value);
                            cmdIns.Parameters["@UnitCode"].Value = this.dgvView["clnUnitCode", ins].Value.ToString();
                            cmdIns.Parameters["@PlantCode"].Value = this.dgvView["clnPlantCode", ins].Value.ToString();
                            cmdIns.Parameters["@LocCode"].Value = this.dgvView["clnLocCode", ins].Value.ToString();

                            cmdIns.Connection = oConn; cmdIns.CommandText = strTmp; cmdIns.Transaction = Tr;
                            cmdIns.ExecuteNonQuery();

                            strTmp = "UPDATE t_MRPTranOrder SET IsCompleted = 1 WHERE (MaterialCode = @MaterialCode) AND (TranOrder = @PONumber)";
                            cmdIns.Connection = oConn; cmdIns.CommandText = strTmp; cmdIns.Transaction = Tr;
                            cmdIns.ExecuteNonQuery();
                        }
                    }

                    // Update Close PO
                    cmdIns.Parameters.Clear(); byte iCheck = 0;
                    for (int i = 0; i < this.dgvView.Rows.Count; i++)
                    {
                        NP_Cls.SqlSelect = "SELECT     PONumber, MaterialCode, POQuantity - GRQuantity AS D FROM t_PODetail WHERE (PONumber = N'" + this.dgvView["clnPONumber", i].Value.ToString() + "') AND (MaterialCode = N'" + this.dgvView["clnMaterialCode", i].Value.ToString() + "') AND (AutoID = N'" + this.dgvView["AutoID", i].Value.ToString() + "')";
                        DataSet dsC = new DataSet(); dsC = NP.GetDataWithTran(NP_Cls.SqlSelect, Tr, oConn);
                        if (dsC.Tables[0].Rows.Count > 0)
                        {
                            if (double.Parse(dsC.Tables[0].Rows[0]["D"].ToString()) <= 0)
                            {
                                iCheck = 1;
                                continue;
                            }
                            else
                            {
                                iCheck = 0;
                                break;
                            }
                        }
                    }


                    if (iCheck == 1)
                    {
                        cmdIns.Parameters.Add("@PONumber", SqlDbType.NVarChar, 50).Value = this.cbPONumber.Text.Trim();
                        cmdIns.Parameters.Add("@UserCreate", SqlDbType.NVarChar, 50).Value = NP_Cls.strUsr;
                        NP_Cls.sqlUpdate = "UPDATE t_PO SET ClosePO = 'C', ClosePOUser = @UserCreate, ClosePODate = GETDATE() WHERE (PONumber = @PONumber)";
                        cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.sqlUpdate; cmdIns.Transaction = Tr;
                        cmdIns.ExecuteNonQuery();
                    }

                    Tr.Commit();

                    //02 July 2013 : Insert To GR and GR Detail
                    InsertToGr(myTmpBatch);

                    NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Save Goods Receipt Completed !!");
                    Clear();
                    this.groupPR.Enabled = true; this.btnAddPR.Visible = true; this.btnSave.Visible = false; this.cbPONumber.Text = string.Empty; this.cbPONumber.DataSource = null;
                    this.MyGrid(dgvView); this.txtDoc.Text = GetNumber();

                    BindVendor();
                    this.cbVendor.Text = string.Empty; this.txtInv.Select();
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
        protected void InsertToGr(List<string> myTmpBatch)
        {
            oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
            if (oConn.State == ConnectionState.Open) { oConn.Close(); }

            oConn.Open(); SqlTransaction Tr;
            Tr = oConn.BeginTransaction();
            try
            {
                SqlCommand cmdIns = new SqlCommand();

                NP_Cls.SqlInsert = "INSERT INTO [t_GR]([GRNumber],[InvoiceNumber],[GRDate] ,[VendorCode] ,[VendorName] ,[PurchasingGroup] ,[MovementType] ,[Remark] ,[UserCreate] ,[DateCreate])         VALUES (@GRNumber ,@InvoiceNumber ,GETDATE() ,@VendorCode ,@VendorName ,@PurchasingGroup ,@MovementType ,@Remark ,@UserCreate ,GETDATE())";
                this.strGNumber = GetNumber();
                cmdIns.Parameters.Add("@GRNumber", SqlDbType.NVarChar, 12).Value = this.strGNumber;
                cmdIns.Parameters.Add("@InvoiceNumber", SqlDbType.NVarChar, 20).Value = this.txtInv.Text.Trim();
                cmdIns.Parameters.Add("@VendorCode", SqlDbType.NVarChar, 10).Value = this.cbVendor.Text.Trim().Split(':')[0];
                cmdIns.Parameters.Add("@VendorName", SqlDbType.NVarChar, 60).Value = this.lblVendorName.Text.Trim();
                cmdIns.Parameters.Add("@PurchasingGroup", SqlDbType.NVarChar, 3).Value = this.lblPG.Text.Trim();
                cmdIns.Parameters.Add("@MovementType", SqlDbType.NVarChar, 3).Value = this.lblMovType.Text.Trim();
                cmdIns.Parameters.Add("@Remark", SqlDbType.NVarChar, 255).Value = this.txtRemark.Text.Trim();
                cmdIns.Parameters.Add("@UserCreate", SqlDbType.NVarChar, 50).Value = NP_Cls.strUsr;
                cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                cmdIns.ExecuteNonQuery();
                cmdIns.Parameters.Clear();
                NP_Cls.SqlInsert = "INSERT INTO [dbo].[t_GRDetail] ([GRNumber] ,[MaterialCode] ,[MaterialName]  ,[GRQuantity]  ,[UnitCode]  ,[UnitName]  ,[NetPrice]  ,[GRAmount]  ,[DeliveryDate]  ,[PlantCode]  ,[PlantName]  ,[LocCode]  ,[LocName]  ,[BatchNumber]  ,[CurrentUser]  ,[LogDate]  ,[PONumber]  ,[POAutoID]  ,[QtyConversion]  ,[RecUnitCode]  ,[RecUnitName])       VALUES  (@GRNumber  ,@MaterialCode  ,@MaterialName  ,@GRQuantity  ,@UnitCode  ,@UnitName  ,@NetPrice  ,@GRAmount  ,@DeliveryDate  ,@PlantCode  ,@PlantName  ,@LocCode  ,@LocName  ,@BatchNumber  ,@CurrentUser  ,GETDATE()  ,@PONumber  ,@POAutoID  ,@QtyConversion  ,@RecUnitCode  ,@RecUnitName)";
                cmdIns.Parameters.Add("@GRNumber", SqlDbType.NVarChar, 12);
                cmdIns.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15);
                cmdIns.Parameters.Add("@MaterialName", SqlDbType.NVarChar, 60);
                cmdIns.Parameters.Add("@GRQuantity", SqlDbType.Decimal);
                cmdIns.Parameters.Add("@UnitCode", SqlDbType.NVarChar, 3);
                cmdIns.Parameters.Add("@UnitName", SqlDbType.NVarChar, 20);
                cmdIns.Parameters.Add("@NetPrice", SqlDbType.Decimal);
                cmdIns.Parameters.Add("@GRAmount", SqlDbType.Decimal);
                cmdIns.Parameters.Add("@DeliveryDate", SqlDbType.DateTime);
                cmdIns.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 4);
                cmdIns.Parameters.Add("@PlantName", SqlDbType.NVarChar, 20);
                cmdIns.Parameters.Add("@LocCode", SqlDbType.NVarChar, 2);
                cmdIns.Parameters.Add("@LocName", SqlDbType.NVarChar, 20);
                cmdIns.Parameters.Add("@BatchNumber", SqlDbType.NVarChar, 20);
                cmdIns.Parameters.Add("@CurrentUser", SqlDbType.NVarChar, 50);

                cmdIns.Parameters.Add("@PONumber", SqlDbType.NVarChar, 12);
                cmdIns.Parameters.Add("@POAutoID", SqlDbType.Int);
                cmdIns.Parameters.Add("@QtyConversion", SqlDbType.Decimal);
                cmdIns.Parameters.Add("@RecUnitCode", SqlDbType.NVarChar, 3);
                cmdIns.Parameters.Add("@RecUnitName", SqlDbType.NVarChar, 20);

                //string strTmpBatch = string.Empty;
                for (byte ins = 0; ins < this.dgvView.RowCount; ins++)
                {
                    if (Convert.ToInt32(this.dgvView["clnQuantity", ins].Value) != 0)
                    {
                        cmdIns.Parameters["@GRNumber"].Value = this.strGNumber;
                        cmdIns.Parameters["@MaterialCode"].Value = this.dgvView["clnMaterialCode", ins].Value.ToString();
                        cmdIns.Parameters["@MaterialName"].Value = this.dgvView["clnMaterialName", ins].Value.ToString();
                        cmdIns.Parameters["@GRQuantity"].Value = Convert.ToDecimal(this.dgvView["clnQuantity", ins].Value);
                        cmdIns.Parameters["@UnitCode"].Value = this.dgvView["clnUnitCode", ins].Value.ToString();
                        cmdIns.Parameters["@UnitName"].Value = this.dgvView["clnUnitName", ins].Value.ToString();
                        cmdIns.Parameters["@NetPrice"].Value = Convert.ToDecimal(this.dgvView["clnNetPrice", ins].Value);
                        cmdIns.Parameters["@GRAmount"].Value = Convert.ToDecimal(this.dgvView["clnAmount", ins].Value);
                        cmdIns.Parameters["@DeliveryDate"].Value = Convert.ToDateTime(this.dgvView["clnDeliveryDate", ins].Value);
                        cmdIns.Parameters["@PlantCode"].Value = this.dgvView["clnPlantCode", ins].Value.ToString();
                        cmdIns.Parameters["@PlantName"].Value = this.dgvView["clnPlantName", ins].Value.ToString();
                        cmdIns.Parameters["@LocCode"].Value = this.dgvView["clnLocCode", ins].Value.ToString();
                        cmdIns.Parameters["@LocName"].Value = this.dgvView["clnLocName", ins].Value.ToString();
                        cmdIns.Parameters["@BatchNumber"].Value = myTmpBatch[ins];
                        cmdIns.Parameters["@PONumber"].Value = this.dgvView["clnPONumber", ins].Value.ToString();
                        cmdIns.Parameters["@CurrentUser"].Value = NP_Cls.strUsr;
                        cmdIns.Parameters["@POAutoID"].Value = this.dgvView["AutoID", ins].Value.ToString();

                        cmdIns.Parameters["@QtyConversion"].Value = Convert.ToDecimal(this.dgvView["clnQuantity", ins].Value);
                        cmdIns.Parameters["@RecUnitCode"].Value = this.dgvView["MasterUnitCode", ins].Value.ToString();
                        cmdIns.Parameters["@RecUnitName"].Value = this.dgvView["MasterUnitName", ins].Value.ToString();

                        cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                        cmdIns.ExecuteNonQuery();
                    }
                }
                Tr.Commit();
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Add GR : " + ex.Message); return;
            }
            finally
            {
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            NP_Cls.myInteger(sender, e);
        }
        private void dgvView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvView.CurrentCell.ColumnIndex == 16)
            {
                TextBox txtBox = e.Control as TextBox;
                txtBox.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
            }
        }
        private void dgvView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvView["clnAmount", this.dgvView.CurrentRow.Index].Value = Convert.ToDecimal(dgvView["clnNetPrice", this.dgvView.CurrentRow.Index].Value) * Convert.ToDecimal(dgvView["clnQuantity", this.dgvView.CurrentRow.Index].Value);
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Edit Cell : " + ex.Message); return;
            }
        }
        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvView.RowCount == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found !!"); return; }
            this.dgvView["clnQuantity", this.dgvView.CurrentRow.Index].Value = 0;
        }

        private void txtDoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NP_Cls.SqlSelect = "SELECT 1 AS ItemNo, t_StockMovementDetail.MaterialCode, t_StockMovementDetail.MaterialName, t_StockMovementDetail.Quantity AS GRQty, t_StockMovementDetail.UnitCode, t_StockMovementDetail.UnitName,  t_StockMovementDetail.PlantCode, t_StockMovementDetail.LocCode, t_StockMovementDetail.BatchNumber, t_StockMovementDetail.DeliveryDate, t_StockMovementDetail.RefNumber AS PONumber, t_StockMovementDetail.NetPrice, t_StockMovementDetail.Amount AS GRAmt, t_StockMovementDetail.PlantName, t_StockMovementDetail.LocName FROM t_StockMovement INNER JOIN t_StockMovementDetail ON t_StockMovement.DocNumber = t_StockMovementDetail.DocNumber WHERE (t_StockMovement.DocNumber = N'" + this.txtDoc.Text.Trim() + "')";
                this.dsPR = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (this.dsPR.Tables[0].Rows.Count == 0) { this.dsPR.Tables.Clear(); this.MyGrid(dgvView); return; }
                bView = 1;
                for (byte ii = 0; ii < this.dsPR.Tables[0].Rows.Count; ii++)
                {
                    this.dsPR.Tables[0].Rows[ii]["ItemNo"] = Convert.ToInt32(ii + 1);
                }
                this.dsPR.AcceptChanges();
                this.dgvView.DataSource = this.dsPR.Tables[0];

                // Head
                this.btnAddPR.Visible = false; this.btnSave.Visible = false;
                // Detail
                this.cbPONumber.DataSource = null; this.cbPONumber.Text = string.Empty;
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Clear(); this.txtDoc.DropDownStyle = ComboBoxStyle.DropDownList; this.txtDoc.Text = string.Empty; this.cbVendor.Text = string.Empty; cbVendor.Enabled = true;
            NP_Cls.SqlSelect = "SELECT DocNumber AS [Value], DocNumber AS [Display] FROM    t_StockMovement WHERE (LEFT(DocNumber,2) = 'GR') AND ((select Count(DocNumber) from t_StockMovementDetail where t_StockMovement.DocNumber = t_StockMovementDetail.DocNumber) > 0)";
            NP.BindCB(this.txtDoc, NP_Cls.SqlSelect, "Value", "Display", "( Select GR Number )");
            this.groupPR.Enabled = true; this.btnAddPR.Visible = true; this.btnSave.Visible = false; this.cbPONumber.Text = string.Empty; this.cbPONumber.DataSource = null;
            this.MyGrid(dgvView); this.txtDoc.Text = GetNumber();
            this.txtDoc.SelectedIndex = 0;
        }
        private void btnGenNew_Click(object sender, EventArgs e)
        {
            Clear(); this.txtDoc.DropDownStyle = ComboBoxStyle.Simple; this.cbVendor.Enabled = true;
            this.groupPR.Enabled = true; this.btnAddPR.Visible = true; this.btnSave.Visible = false; this.cbPONumber.Text = string.Empty; this.cbPONumber.DataSource = null;
            this.dsPR.Tables.Clear(); this.MyGrid(dgvView); this.txtDoc.Text = GetNumber();
            this.cbVendor.Text = string.Empty; this.cbVendor.Select();
        }
        private void txtDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.txtDoc.SelectedIndex != 0)
            {
                NP_Cls.SqlSelect = "SELECT     1 AS ItemNo, t_StockMovementDetail.MaterialCode, t_StockMovementDetail.MaterialName, t_StockMovementDetail.Quantity AS GRQty, t_StockMovementDetail.UnitCode, t_StockMovementDetail.UnitName,  t_StockMovementDetail.PlantCode, t_StockMovementDetail.LocCode, t_StockMovementDetail.BatchNumber,t_StockMovementDetail.DeliveryDate, t_StockMovementDetail.RefNumber AS PONumber, t_StockMovementDetail.NetPrice, t_StockMovementDetail.Amount AS GRAmt, t_StockMovementDetail.PlantName, t_StockMovementDetail.LocName,t_StockMovement.VendorCode, 0 AS MatCost FROM t_StockMovement INNER JOIN t_StockMovementDetail ON t_StockMovement.DocNumber = t_StockMovementDetail.DocNumber WHERE (t_StockMovement.DocNumber = N'" + this.txtDoc.Text.Trim() + "')";
                this.dsPR = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (this.dsPR.Tables[0].Rows.Count == 0) { this.dsPR.Tables.Clear(); this.MyGrid(dgvView); return; }
                bView = 1;
                for (byte ii = 0; ii < this.dsPR.Tables[0].Rows.Count; ii++)
                {
                    this.dsPR.Tables[0].Rows[ii]["ItemNo"] = Convert.ToInt32(ii + 1);
                }
                this.cbVendor.Text = this.dsPR.Tables[0].Rows[0]["VendorCode"].ToString();
                this.dsPR.Tables[0].Columns.Remove("VendorCode"); this.cbVendor.Enabled = false;
                this.dsPR.AcceptChanges();
                this.dgvView.DataSource = this.dsPR.Tables[0];

                // Head
                this.btnAddPR.Visible = false; this.btnSave.Visible = false;
                // Detail
                //this.cbPONumber.DataSource = null; this.cbPONumber.Text = string.Empty;
                BindVendor();
                this.cbPONumber.Select(); this.cbPONumber.SelectAll();
            }
        }
        private void cbPONumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbPONumber.SelectedIndex > 0)
            {
                NP_Cls.SqlSelect = "SELECT     CONVERT(nvarchar, t_PODetail.AutoID) AS AutoID, t_PODetail.MaterialCode + ':' + CAST(t_PODetail.POQuantity - ISNULL(GetGR.Qty, 0) AS nvarchar) AS MatDis FROM         t_PODetail LEFT OUTER JOIN                           (SELECT     SUM(Quantity) AS Qty, RefNumber, RefAutoID, MaterialCode                             FROM          t_StockMovementDetail                             GROUP BY RefNumber, RefAutoID, MaterialCode) AS GetGR ON t_PODetail.PONumber = GetGR.RefNumber AND t_PODetail.AutoID = GetGR.RefAutoID WHERE     (t_PODetail.POQuantity - ISNULL(GetGR.Qty, 0) <> 0)AND (t_PODetail.PONumber = N'" + this.cbPONumber.Text.Trim() + "')";
                NP.BindCB(this.cbMaterial, NP_Cls.SqlSelect, "AutoID", "MatDis", "((( Select Masterial )))");
                this.cbMaterial.Select(); this.cbMaterial.SelectAll();
            }
            else
            {
                this.cbMaterial.Text = string.Empty; this.cbMaterial.DataSource = null;
            }
        }

    }
}
