using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WMS.Stock
{
    public partial class frmTransferStatus : Form
    {
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection(); private byte bView = 0; private string strCurr = string.Empty;
        private string strGNumber = string.Empty; private DataSet dsPR = new DataSet(); private string strPRref = string.Empty;
        private string strTranfer = string.Empty;
        //321  โอนจาก QI ไป UR
        //322  โอนจาก UR กลับ QI
        //349  โอนจาก Block กลับ QI
        //350  โอนจาก QI ไป Block
        public frmTransferStatus()
        {
            InitializeComponent();
        }
        private void MyGrid(DataGridView grid)
        {
            NP_Cls.SqlSelect = "SELECT 1 AS ItemNo, t_StockOverview.MaterialCode, m_Material.MaterialName, t_StockOverview.BatchNumber, t_StockOverview.UR, t_StockOverview.QI, t_StockOverview.Block,  t_StockMovementDetail.PlantCode, t_StockMovementDetail.PlantName, t_StockMovementDetail.LocCode, t_StockMovementDetail.LocName, 0 AS TranQuantity, t_StockMovementDetail.UnitCode, t_StockMovementDetail.UnitName, '' as Remark , '' as MovementType FROM         t_StockOverview INNER JOIN   m_Material ON t_StockOverview.MaterialCode = m_Material.MaterialCode LEFT OUTER JOIN t_StockMovementDetail ON t_StockOverview.AutoID = t_StockMovementDetail.AutoID WHERE     (t_StockOverview.MaterialCode = '')";
            this.dsPR = NP.GetClientDataSet(NP_Cls.SqlSelect);
            grid.DataSource = this.dsPR.Tables[0];
        }
        private void frmTransferStatus_Load(object sender, EventArgs e)
        {
            try
            {
                WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
                frm.menuStrip1.Enabled = true;

                this.txtPR.Text = GetNumber(); this.txtDocDate.Text = NP.GetDateServer().ToString("dd/MM/yyyy");
                this.MyGrid(dgvView);
                CreateMovType();
                Clear(); this.lblUserCreate.Text = NP_Cls.strUsr;
                this.cbMovType.Text = string.Empty; this.cbMovType.Select();
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Load : " + ex.Message); return;
            }
        }
        private void CreateMovType()
        {
            DataSet dsMov = new DataSet(); dsMov.Tables.Add(new DataTable("DT"));
            dsMov.Tables[0].Columns.Add(new DataColumn("display", typeof(System.String))); dsMov.Tables[0].Columns.Add(new DataColumn("value", typeof(System.String)));
            DataRow dr;
            dr = dsMov.Tables[0].NewRow(); dr[0] = "(( Select Mov.Type ))"; dr[1] = "0"; dsMov.Tables[0].Rows.Add(dr);
            dr = dsMov.Tables[0].NewRow(); dr[0] = "321:QI >> UR"; dr[1] = "QI >> UR"; dsMov.Tables[0].Rows.Add(dr);
            dr = dsMov.Tables[0].NewRow(); dr[0] = "322:UR >> QI"; dr[1] = "UR >> QI"; dsMov.Tables[0].Rows.Add(dr);
            dr = dsMov.Tables[0].NewRow(); dr[0] = "349:Block >> QI"; dr[1] = "Block >> QI"; dsMov.Tables[0].Rows.Add(dr);
            dr = dsMov.Tables[0].NewRow(); dr[0] = "350:QI >> Block"; dr[1] = "QI >> Block"; dsMov.Tables[0].Rows.Add(dr);
            dsMov.AcceptChanges();
            this.cbMovType.DataSource = dsMov.Tables[0]; this.cbMovType.DisplayMember = "display"; this.cbMovType.ValueMember = "value";
        }
        private void Clear()
        {
            this.lblMovDesc.Text = string.Empty; this.lblMaterialName.Text = string.Empty;
        }
        private string GetNumber()
        {
            try
            {
                bView = 0;
                NP_Cls.SqlSelect = "SELECT top (1) CONVERT(int, RIGHT(DocNumber, 4)) AS SS, RIGHT(CONVERT(nvarchar, GETDATE(), 112), 6) AS s FROM   t_StockMovement WHERE (RIGHT(CONVERT(nvarchar, GETDATE(), 112), 6) = LEFT(RIGHT(DocNumber, 10), 6)) AND (LEFT(DocNumber,2) = 'TR') ORDER BY SS DESC";
                DataSet dsGen = new DataSet(); dsGen = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (dsGen.Tables[0].Rows.Count == 0)
                {
                    NP_Cls.SqlSelect = "SELECT  TOP (1) RIGHT(CONVERT(nvarchar, GETDATE(), 112), 6) AS s";
                    return "TR" + NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0].Rows[0][0].ToString() + "0001";
                }
                else
                {
                    //string strCode = (Convert.ToInt16(dsGen.Tables[0].Rows[0][0].ToString()) + 1).ToString().PadLeft(5 - (Convert.ToInt16(dsGen.Tables[0].Rows[0][0].ToString()) + 1).ToString().Length, '0');
                    string strCode = (Convert.ToInt16(dsGen.Tables[0].Rows[0][0].ToString()) + 1).ToString().PadLeft(4, '0');
                    return "TR" + dsGen.Tables[0].Rows[0][1].ToString() + strCode;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void    cbMovType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((sender as ComboBox).SelectedIndex != 0) && (!string.IsNullOrEmpty((sender as ComboBox).Text.Trim())))
            {
                this.lblMovDesc.Text = (sender as ComboBox).SelectedValue.ToString();
            }
            else
            {
                Clear();
                (sender as ComboBox).Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(this.bView))
            {
                if ((this.dsPR.Tables[0].Rows.Count > 0) || (this.groupPR.Enabled == false))
                {
                    if (NP.MSGB("The Transfer list will be cancel , Do you agree with this ?") == DialogResult.Yes)
                    {
                        oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                        if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                        oConn.Open(); SqlTransaction Tr;
                        Tr = oConn.BeginTransaction();

                        try
                        {
                            SqlCommand cmd = new SqlCommand();
                            NP_Cls.SqlDel = "DELETE FROM t_StockMovement WHERE (DocNumber = @DocNumber)";
                            cmd.Parameters.Add("@DocNumber", SqlDbType.NVarChar, 12).Value = this.txtPR.Text.Trim();
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
                        return; // Click No
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
        private void frmTransferStatus_FormClosing(object sender, FormClosingEventArgs e)
        {
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;
        }
        private void btnAddHeader_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(this.cbMovType.Text.Trim())) && (this.cbMovType.SelectedIndex != 0))
            {

                if (!CheckStatus4Tran()) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Not enough quantity to transfer !!"); this.cbMovType.Select(); return; }

                //
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open();

                try
                {
                    SqlCommand cmdIns = new SqlCommand();
                    NP_Cls.SqlInsert = "INSERT INTO t_StockMovement " +
                      "(DocNumber, TranDate, MovementType, Remark, UserCreate, DateCreate) " +
"VALUES     (@DocNumber,GetDate(),@MovementType,@Remark,@UC,GetDate())";
                    this.strGNumber = GetNumber();
                    cmdIns.Parameters.Add("@DocNumber", SqlDbType.NVarChar, 12).Value = this.strGNumber;
                    cmdIns.Parameters.Add("@MovementType", SqlDbType.NVarChar, 3).Value = this.cbMovType.Text.Trim().Split(':')[0];
                    cmdIns.Parameters.Add("@Remark", SqlDbType.NVarChar, 255).Value = this.txtRemark.Text.Trim();
                    cmdIns.Parameters.Add("@UC", SqlDbType.NVarChar, 50).Value = NP_Cls.strUsr;
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert;
                    cmdIns.ExecuteNonQuery();

                    this.groupPR.Enabled = false; this.btnAddHeader.Visible = false; this.btnSave.Visible = true;

                    // Case Transfer
                    switch (this.cbMovType.Text.Trim().Split(':')[0])
                    {
                        case "321":
                            // QI > UR
                            NP_Cls.SqlSelect = "SELECT m_Material.MaterialName, t_StockOverview.MaterialCode + ':' +  t_StockOverview.BatchNumber AS MaterialCode FROM  t_StockOverview INNER JOIN m_Material ON t_StockOverview.MaterialCode = m_Material.MaterialCode WHERE (t_StockOverview.QI > 0)";
                            //this.dgvView.Columns["clnUR"].ReadOnly = false; this.dgvView.Columns["clnQI"].ReadOnly = true; this.dgvView.Columns["clnBlock"].ReadOnly = true;
                            break;
                        case "322":
                            // UR > QI
                            NP_Cls.SqlSelect = "SELECT m_Material.MaterialName,  t_StockOverview.MaterialCode + ':' +  t_StockOverview.BatchNumber AS MaterialCode FROM  t_StockOverview INNER JOIN m_Material ON t_StockOverview.MaterialCode = m_Material.MaterialCode WHERE (t_StockOverview.UR > 0)";
                            //this.dgvView.Columns["clnQI"].ReadOnly = false; this.dgvView.Columns["clnUR"].ReadOnly = true; this.dgvView.Columns["clnBlock"].ReadOnly = true;
                            break;
                        case "349":
                            // Block > QI
                            NP_Cls.SqlSelect = "SELECT m_Material.MaterialName,  t_StockOverview.MaterialCode + ':' +  t_StockOverview.BatchNumber AS MaterialCode FROM  t_StockOverview INNER JOIN m_Material ON t_StockOverview.MaterialCode = m_Material.MaterialCode WHERE (t_StockOverview.Block > 0)";
                            //this.dgvView.Columns["clnQI"].ReadOnly = false; this.dgvView.Columns["clnUR"].ReadOnly = true; this.dgvView.Columns["clnBlock"].ReadOnly = true;
                            break;
                        case "350":
                            // QI > Block
                            NP_Cls.SqlSelect = "SELECT m_Material.MaterialName, t_StockOverview.MaterialCode + ':' +  t_StockOverview.BatchNumber AS MaterialCode FROM  t_StockOverview INNER JOIN m_Material ON t_StockOverview.MaterialCode = m_Material.MaterialCode WHERE (t_StockOverview.QI > 0)";
                            //this.dgvView.Columns["clnBlock"].ReadOnly = false; this.dgvView.Columns["clnQI"].ReadOnly = true; this.dgvView.Columns["clnUR"].ReadOnly = true;
                            break;
                        default:
                            NP.MSGB(NP_Cls.NPMgsStyle.Invalid, "Not found type to transfer !!");
                            break;
                    }
                    try
                    {
                        NP.BindCB(this.cbMaterial, NP_Cls.SqlSelect, "MaterialName", "MaterialCode", "((( Select Material )))");
                        this.cbMaterial.Select(); this.cbMaterial.SelectAll();
                    }
                    catch (SqlException)
                    {
                        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Not found material for transfer !!"); return;
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
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please select movement tpye first !!"); return;
            }
        }
        private bool CheckStatus4Tran()
        {
            switch (this.cbMovType.Text.Trim().Split(':')[0])
            {
                case "321":
                case "350":
                    // QI > UR
                    NP_Cls.SqlSelect = "SELECT MaterialCode FROM t_StockOverview WHERE (QI > 0)";
                    break;
                case "322":
                    // UR > QI
                    NP_Cls.SqlSelect = "SELECT MaterialCode FROM t_StockOverview WHERE (UR > 0)";
                    break;
                case "349":
                    // Block > QI
                    NP_Cls.SqlSelect = "SELECT MaterialCode FROM t_StockOverview WHERE (Block > 0)";
                    break;
                default:
                    NP.MSGB(NP_Cls.NPMgsStyle.Invalid, "Not found type to transfer !!");
                    break;
            }
            if (NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0].Rows.Count == 0) { return false; } else { return true; }
        }
        private void cbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((sender as ComboBox).SelectedIndex != 0) && (!string.IsNullOrEmpty((sender as ComboBox).Text.Trim())))
            {
                this.lblMaterialName.Text = (sender as ComboBox).SelectedValue.ToString();
            }
            else
            {
                this.lblMaterialName.Text = string.Empty;
                (sender as ComboBox).Focus();
            }
        }
        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.cbMaterial.Text.Trim()))
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please add Transfer Header first !!"); return;
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
                            if ((this.cbMaterial.Text.Trim().Split(':')[0].ToString() == this.dsPR.Tables[0].Rows[ii]["MaterialCode"].ToString()) && (this.cbMaterial.Text.Trim().Split(':')[1].ToString() == this.dsPR.Tables[0].Rows[ii]["BatchNumber"].ToString()))
                            {
                                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "This material is in Transfer List !!"); this.cbMaterial.Select(); return;
                            }
                        }
                    }
                    else if (this.dsPR.Tables[0].Rows.Count == 0)
                    {
                        //
                        NP_Cls.SqlSelect = "SELECT     1 AS ItemNo, t_StockOverview.MaterialCode, m_Material.MaterialName, t_StockOverview.BatchNumber, t_StockOverview.UR, t_StockOverview.QI,                        t_StockOverview.Block, 0 AS TranQuantity, m_Unit.UnitName, m_Plant.PlantName, m_Location.LocName, t_StockOverview.PlantCode, t_StockOverview.LocCode,                        t_StockOverview.UnitCode FROM         t_StockOverview INNER JOIN                       m_Material ON t_StockOverview.MaterialCode = m_Material.MaterialCode INNER JOIN                       m_Unit ON t_StockOverview.UnitCode = m_Unit.UnitCode INNER JOIN                       m_Plant ON t_StockOverview.PlantCode = m_Plant.PlantCode INNER JOIN                       m_Location ON t_StockOverview.LocCode = m_Location.LocCode WHERE  (t_StockOverview.MaterialCode = '" + this.cbMaterial.Text.Trim().Split(':')[0].Trim() + "') AND (t_StockOverview.BatchNumber = '" + this.cbMaterial.Text.Trim().Split(':')[1].Trim() + "')";
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
                        this.dgvView.DataSource = this.dsPR.Tables[0]; this.dgvView.ClearSelection();
                        return;
                        //
                    }

                    // if Row >  1
                    DataRow dr; dr = this.dsPR.Tables[0].NewRow();
                    NP_Cls.SqlSelect = "SELECT     1 AS ItemNo, t_StockOverview.MaterialCode, m_Material.MaterialName, t_StockOverview.BatchNumber, t_StockOverview.UR, t_StockOverview.QI,                        t_StockOverview.Block, 0 AS TranQuantity, m_Unit.UnitName, m_Plant.PlantName, m_Location.LocName, t_StockOverview.PlantCode, t_StockOverview.LocCode,                        t_StockOverview.UnitCode FROM         t_StockOverview INNER JOIN                       m_Material ON t_StockOverview.MaterialCode = m_Material.MaterialCode INNER JOIN                       m_Unit ON t_StockOverview.UnitCode = m_Unit.UnitCode INNER JOIN                       m_Plant ON t_StockOverview.PlantCode = m_Plant.PlantCode INNER JOIN                       m_Location ON t_StockOverview.LocCode = m_Location.LocCode WHERE  (t_StockOverview.MaterialCode = '" + this.cbMaterial.Text.Trim().Split(':')[0].Trim() + "') AND (t_StockOverview.BatchNumber = '" + this.cbMaterial.Text.Trim().Split(':')[1].Trim() + "')";
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
                    this.dgvView.DataSource = this.dsPR.Tables[0]; this.dgvView.ClearSelection();
                }
            }
        }
        private void btnCancelPR_Click(object sender, EventArgs e)
        {
            try
            {
                if (NP.MSGB("Do you to cancel Transfer Stock ?") == DialogResult.Yes)
                {
                    oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                    if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                    oConn.Open(); SqlTransaction Tr;
                    Tr = oConn.BeginTransaction();

                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        NP_Cls.SqlDel = "DELETE FROM t_StockMovement WHERE (DocNumber = @DocNumber)";
                        cmd.Parameters.Add("@DocNumber", SqlDbType.NVarChar, 12).Value = this.txtPR.Text.Trim();
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

                    Clear(); this.groupPR.Enabled = true; this.cbMaterial.Text = string.Empty;
                    if (this.dsPR.Tables.Count > 0) { this.dsPR.Tables.Clear(); this.MyGrid(this.dgvView); }
                    this.cbMaterial.DataSource = null;
                    this.btnAddHeader.Visible = true; this.btnSave.Visible = false;

                    CreateMovType(); this.cbMovType.Select();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.dgvView.RowCount == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please select material into transfer list !!"); this.cbMaterial.Select(); return; }
            this.dgvView.EndEdit();

            // Check Transfer
            for (int i = 0; i < this.dgvView.Rows.Count; i++)
            {
                if (Convert.ToDecimal(dgvView["clnTranQuantity", i].Value) <= 0)
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Transfer Quantity must be more than 0 !!"); return;
                }
            }

            for (int i = 0; i < this.dgvView.RowCount; i++)
            {
                switch (this.cbMovType.Text.Trim().Split(':')[0])
                {
                    case "321":
                        // QI > UR
                        if (double.Parse(this.dgvView["clnTranQuantity", i].Value.ToString()) > double.Parse(this.dgvView["clnQI", i].Value.ToString()))
                        {
                            NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Transfet Quantity more than QI !!"); this.dgvView.CancelEdit(); return;
                        }
                        break;
                    case "322":
                        // UR > QI
                        if (double.Parse(this.dgvView["clnTranQuantity", i].Value.ToString()) > double.Parse(this.dgvView["clnUR", i].Value.ToString()))
                        {
                            NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Transfet Quantity more than UR !!"); this.dgvView.CancelEdit(); return;
                        }
                        break;
                    case "349":
                        // Block > QI
                        if (double.Parse(this.dgvView["clnTranQuantity", i].Value.ToString()) > double.Parse(this.dgvView["clnBlock", i].Value.ToString()))
                        {
                            NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Transfet Quantity more than Block !!"); this.dgvView.CancelEdit(); return;
                        }
                        break;
                    case "350":
                        // QI > Block
                        if (double.Parse(this.dgvView["clnTranQuantity", i].Value.ToString()) > double.Parse(this.dgvView["clnQI", i].Value.ToString()))
                        {
                            NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Transfet Quantity more than QI !!"); this.dgvView.CancelEdit(); return;
                        }
                        break;
                    default:
                        NP.MSGB(NP_Cls.NPMgsStyle.Invalid, "Not found type to transfer !!");
                        break;
                }

            }

            if (NP.MSGB("Do you to Save Transfer Stock ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr;
                Tr = oConn.BeginTransaction();

                try
                {
                    SqlCommand cmdIns = new SqlCommand();

                    //if (ad == 0)
                    //{
                    NP_Cls.SqlInsert = "INSERT INTO t_StockMovementDetail (AutoID, DocNumber, MaterialCode, MaterialName, Quantity, UnitCode, UnitName, NetPrice, Amount, DeliveryDate, PlantCode, PlantName, LocCode, LocName, CurrentUser, RefNumber, BatchNumber) " +
"VALUES     (@ID,@PONumber,@MaterialCode,@MaterialName,@POQuantity,@UnitCode,@UnitName,@NetPrice,@POAmount,GETDATE(),@PlantCode,@PlantName,@LocCode,@LocName,@CurrentUser,@refPR,@BatchNumber)";
                    cmdIns.Parameters.Add("@ID", SqlDbType.Int);
                    cmdIns.Parameters.Add("@PONumber", SqlDbType.NVarChar, 12);
                    cmdIns.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15);
                    cmdIns.Parameters.Add("@MaterialName", SqlDbType.NVarChar, 60);
                    cmdIns.Parameters.Add("@POQuantity", SqlDbType.Decimal);
                    cmdIns.Parameters.Add("@UnitCode", SqlDbType.NVarChar, 3);
                    cmdIns.Parameters.Add("@UnitName", SqlDbType.NVarChar, 20);
                    cmdIns.Parameters.Add("@NetPrice", SqlDbType.Decimal);
                    cmdIns.Parameters.Add("@POAmount", SqlDbType.Decimal);
                    //cmdIns.Parameters.Add("@DeliveryDate", SqlDbType.DateTime);
                    cmdIns.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 4);
                    cmdIns.Parameters.Add("@PlantName", SqlDbType.NVarChar, 20);
                    cmdIns.Parameters.Add("@LocCode", SqlDbType.NVarChar, 2);
                    cmdIns.Parameters.Add("@LocName", SqlDbType.NVarChar, 20);
                    cmdIns.Parameters.Add("@CurrentUser", SqlDbType.NVarChar, 50);
                    cmdIns.Parameters.Add("@refPR", SqlDbType.NVarChar, 12);
                    cmdIns.Parameters.Add("@BatchNumber", SqlDbType.NVarChar, 10);
                    for (int ad = 0; ad < 2; ad++)
                    {
                        for (byte ins = 0; ins < this.dgvView.RowCount; ins++)
                        {
                            cmdIns.Parameters["@ID"].Value = Convert.ToInt32(this.dgvView["clnItemNo", ins].Value) + (ad * this.dgvView.RowCount);
                            cmdIns.Parameters["@PONumber"].Value = this.strGNumber;
                            cmdIns.Parameters["@MaterialCode"].Value = this.dgvView["clnMaterialCode", ins].Value.ToString();
                            cmdIns.Parameters["@MaterialName"].Value = this.dgvView["clnMaterialName", ins].Value.ToString();
                            switch (this.cbMovType.Text.Trim().Split(':')[0])
                            {
                                case "321":
                                    // QI > UR
                                    cmdIns.Parameters["@refPR"].Value = (ad == 0 ? "QI X" : "UR");
                                    cmdIns.Parameters["@POQuantity"].Value = Convert.ToDouble(this.dgvView["clnTranQuantity", ins].Value);
                                    break;
                                case "322":
                                    // UR > QI
                                    cmdIns.Parameters["@refPR"].Value = (ad == 0 ? "UR X" : "QI");
                                    cmdIns.Parameters["@POQuantity"].Value = Convert.ToDouble(this.dgvView["clnTranQuantity", ins].Value);
                                    break;
                                case "349":
                                    // Block > QI
                                    cmdIns.Parameters["@refPR"].Value = (ad == 0 ? "Block X" : "QI");
                                    cmdIns.Parameters["@POQuantity"].Value = Convert.ToDouble(this.dgvView["clnTranQuantity", ins].Value);
                                    break;
                                case "350":
                                    // QI > Block
                                    cmdIns.Parameters["@refPR"].Value = (ad == 0 ? "QI X" : "Block");
                                    cmdIns.Parameters["@POQuantity"].Value = Convert.ToDouble(this.dgvView["clnTranQuantity", ins].Value);
                                    break;
                                default:
                                    NP.MSGB(NP_Cls.NPMgsStyle.Invalid, "Not found type to transfer !!");
                                    break;
                            }

                            cmdIns.Parameters["@UnitCode"].Value = this.dgvView["clnUnitCode", ins].Value.ToString();
                            cmdIns.Parameters["@UnitName"].Value = this.dgvView["clnUnitName", ins].Value.ToString();
                            cmdIns.Parameters["@NetPrice"].Value = 0; //Convert.ToDouble(this.dgvView[6, ins].Value);
                            cmdIns.Parameters["@POAmount"].Value = 0; //Convert.ToDouble(this.dgvView[7, ins].Value);
                            cmdIns.Parameters["@CurrentUser"].Value = NP_Cls.strUsr;
                            cmdIns.Parameters["@BatchNumber"].Value = this.dgvView["clnBatchNumber", ins].Value.ToString();
                            cmdIns.Parameters["@PlantCode"].Value = this.dgvView["clnPlantCode", ins].Value.ToString();
                            cmdIns.Parameters["@PlantName"].Value = this.dgvView["clnPlantName", ins].Value.ToString();
                            cmdIns.Parameters["@LocCode"].Value = this.dgvView["clnLocCode", ins].Value.ToString();
                            cmdIns.Parameters["@LocName"].Value = this.dgvView["clnLocName", ins].Value.ToString();

                            cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                            cmdIns.ExecuteNonQuery();

                            if (ad == 0)
                            {
                                switch (this.cbMovType.Text.Trim().Split(':')[0])
                                {
                                    case "321":
                                        // QI > UR
                                        NP_Cls.sqlUpdate = "UPDATE t_StockOverview SET UR = UR + @POQuantity, QI = QI - @POQuantity  WHERE (BatchNumber = @BatchNumber) AND (MaterialCode = @MaterialCode)";
                                        break;
                                    case "322":
                                        // UR > QI
                                        NP_Cls.sqlUpdate = "UPDATE t_StockOverview SET QI = QI + @POQuantity, UR = UR - @POQuantity WHERE (BatchNumber = @BatchNumber) AND (MaterialCode = @MaterialCode)";
                                        break;
                                    case "349":
                                        // Block > QI
                                        NP_Cls.sqlUpdate = "UPDATE t_StockOverview SET QI = QI + @POQuantity, Block = Block - @POQuantity WHERE (BatchNumber = @BatchNumber) AND (MaterialCode = @MaterialCode)";
                                        break;
                                    case "350":
                                        // QI > Block
                                        NP_Cls.sqlUpdate = "UPDATE t_StockOverview SET Block = Block + @POQuantity, QI = QI - @POQuantity WHERE (BatchNumber = @BatchNumber) AND (MaterialCode = @MaterialCode)";
                                        break;
                                    default:
                                        NP.MSGB(NP_Cls.NPMgsStyle.Invalid, "Not found type to transfer !!");
                                        break;
                                }

                                cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.sqlUpdate; cmdIns.Transaction = Tr;
                                cmdIns.ExecuteNonQuery();
                            }
                        }
                    }

                    Tr.Commit(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Save Transfer Order Completed !!");
                    Clear();
                    this.groupPR.Enabled = true; this.btnAddHeader.Visible = true; this.btnSave.Visible = false; this.cbMaterial.Text = string.Empty; this.cbMaterial.DataSource = null;
                    this.dsPR.Tables.Clear(); this.MyGrid(dgvView); this.txtPR.Text = GetNumber();

                    this.cbMovType.SelectedIndex = 0; this.cbMovType.Text = string.Empty; this.cbMovType.Select();
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
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            NP_Cls.myInteger(sender, e);
        }
        private void dgvView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvView.CurrentCell.ColumnIndex == 11) 
            {
                TextBox txtBox = e.Control as TextBox;
                txtBox.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
            }
        }

        private void btnGenNew_Click(object sender, EventArgs e)
        {
            bView = 0;
            Clear(); this.txtPR.DropDownStyle = ComboBoxStyle.Simple; this.cbMovType.Enabled = true;
            this.groupPR.Enabled = true; this.btnAddDetail.Visible = true; this.btnAddHeader.Visible = true; this.btnSave.Visible = false; this.cbMaterial.Text = string.Empty; this.cbMaterial.DataSource = null;
            this.dsPR.Tables.Clear(); this.MyGrid(dgvView); this.txtPR.Text = GetNumber(); this.cbMaterial.Enabled = true;
            this.cbMovType.Text = string.Empty; this.cbMovType.Select(); this.cbMovType.SelectedIndex = 0;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Clear(); this.txtPR.DropDownStyle = ComboBoxStyle.DropDownList; this.txtPR.Text = string.Empty; this.cbMovType.Text = string.Empty; cbMovType.Enabled = false;
            NP_Cls.SqlSelect = "SELECT  DocNumber, DocNumber as DocDis  FROM t_StockMovement where DocNumber like 'TR%'";
            NP.BindCB(this.txtPR, NP_Cls.SqlSelect, "DocNumber", "DocDis", "( Select Doc Number )");
            this.groupPR.Enabled = true; this.btnAddDetail.Visible = false; this.btnAddHeader.Visible = false; this.btnSave.Visible = false; this.cbMaterial.Text = string.Empty; this.cbMaterial.DataSource = null;
            this.MyGrid(dgvView); this.txtPR.Text = GetNumber(); this.btnAppr.Visible = false; this.txtRemark.Enabled = false; this.cbMaterial.Enabled = false;
            this.txtPR.SelectedIndex = 0; 
        }
        private void txtPR_SelectedIndexChanged(object sender, EventArgs e)
        {
            bView = 1;
            this.dsPR.Tables.Clear();
            this.MyGrid(dgvView);
            if (this.txtPR.SelectedIndex != 0)
            {
                NP_Cls.SqlSelect = "SELECT   distinct 0 AS ItemNo, t_StockMovementDetail.MaterialCode, m_Material.MaterialName, t_StockMovementDetail.BatchNumber, (select t_StockOverview.UR from t_StockOverview where t_StockOverview.MaterialCode =t_StockMovementDetail.MaterialCode and t_StockOverview.BatchNumber = t_StockMovementDetail.BatchNumber)UR, (select t_StockOverview.QI from t_StockOverview where t_StockOverview.MaterialCode =t_StockMovementDetail.MaterialCode and t_StockOverview.BatchNumber = t_StockMovementDetail.BatchNumber)QI, (select t_StockOverview.Block from t_StockOverview where t_StockOverview.MaterialCode =t_StockMovementDetail.MaterialCode and t_StockOverview.BatchNumber = t_StockMovementDetail.BatchNumber)Block, t_StockMovementDetail.Quantity AS TranQuantity, m_Unit.UnitName, m_Plant.PlantName, m_Location.LocName, t_StockMovementDetail.PlantCode, t_StockMovementDetail.LocCode, t_StockMovementDetail.UnitCode,(select t_StockMovement.MovementType from t_StockMovement where t_StockMovement.DocNumber = t_StockMovementDetail.DocNumber)MovementType,(select t_StockMovement.Remark from t_StockMovement where t_StockMovement.DocNumber = t_StockMovementDetail.DocNumber)Remark FROM t_StockMovementDetail INNER JOIN   m_Material ON t_StockMovementDetail.MaterialCode = m_Material.MaterialCode INNER JOIN  m_Unit ON t_StockMovementDetail.UnitCode = m_Unit.UnitCode INNER JOIN m_Plant ON t_StockMovementDetail.PlantCode = m_Plant.PlantCode INNER JOIN  m_Location ON t_StockMovementDetail.LocCode = m_Location.LocCode   WHERE (t_StockMovementDetail.DocNumber = N'" + this.txtPR.Text.Trim() + "')";
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

                txtRemark.Text = this.dsPR.Tables[0].Rows[0]["Remark"].ToString();
                switch (this.dsPR.Tables[0].Rows[0]["MovementType"].ToString())
                {
                    case "321":
                        // QI > UR
                        cbMovType.Text = "321:QI >> UR";
                        break;
                    case "322":
                        // UR > QI
                        cbMovType.Text = "322:UR >> QI";
                        break;
                    case "349":
                        // Block > QI
                        cbMovType.Text = "349:Block >> QI";
                        break;
                    case "350":
                        // QI > Block
                        cbMovType.Text = "350:QI >> Block";
                        break;
                    default:
                        
                        break;
                }
                this.dgvView.DataSource = this.dsPR.Tables[0]; this.dgvView.ClearSelection();
                return;
            }
        }

        private void dgvView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvView.EndEdit();
            for (int i = 0; i < this.dgvView.RowCount; i++)
            {        
                switch (this.cbMovType.Text.Trim().Split(':')[0])
                {
                    case "321":
                        // QI > UR
                        if (double.Parse(this.dgvView["clnTranQuantity", i].Value.ToString()) > double.Parse(this.dgvView["clnQI", i].Value.ToString()))
                        {
                            NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Transfet Quantity more than QI !!"); this.dgvView.CancelEdit(); return;
                        }
                        break;
                    case "322":
                        // UR > QI
                        if (double.Parse(this.dgvView["clnTranQuantity", i].Value.ToString()) > double.Parse(this.dgvView["clnUR", i].Value.ToString()))
                        {
                            NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Transfet Quantity more than UR !!"); this.dgvView.CancelEdit(); return;
                        }
                        break;
                    case "349":
                        // Block > QI
                        if (double.Parse(this.dgvView["clnTranQuantity", i].Value.ToString()) > double.Parse(this.dgvView["clnBlock", i].Value.ToString()))
                        {
                            NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Transfet Quantity more than Block !!"); this.dgvView.CancelEdit(); return;
                        }
                        break;
                    case "350":
                        // QI > Block
                        if (double.Parse(this.dgvView["clnTranQuantity", i].Value.ToString()) > double.Parse(this.dgvView["clnQI", i].Value.ToString()))
                        {
                            NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Transfet Quantity more than QI !!"); this.dgvView.CancelEdit(); return;
                        }
                        break;
                    default:
                        NP.MSGB(NP_Cls.NPMgsStyle.Invalid, "Not found type to transfer !!");
                        break;
                }

            }
        }

    }
}
