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
    public partial class frmGoodsReturn : Form
    {
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection(); private byte bView = 0;
        private string strGNumber = string.Empty; private DataSet dsPR = new DataSet();   
        public frmGoodsReturn()
        {
            InitializeComponent();
        }
        private void MyGrid(DataGridView grid)
        {
            NP_Cls.SqlSelect = "SELECT     0 AS ItemNo, t_GRDetail.MaterialCode, t_GRDetail.MaterialName, t_GRDetail.GRQuantity AS GTQty, t_GRDetail.UnitCode, t_GRDetail.UnitName,  t_GRDetail.PlantCode, t_GRDetail.LocCode, t_GRDetail.BatchNumber, t_GRDetail.DeliveryDate, t_GRDetail.GRNumber, t_GRDetail.NetPrice,  t_GRDetail.GRAmount AS GTAmt, t_GRDetail.PlantName, t_GRDetail.LocName, t_GRDetail.AutoID FROM t_GR INNER JOIN  t_GRDetail ON t_GR.GRNumber = t_GRDetail.GRNumber WHERE     (t_GRDetail.GRNumber = N'') AND (t_GR.VendorCode = N'') AND (t_GR.MovementType = N'101')";
            this.dsPR = NP.GetClientDataSet(NP_Cls.SqlSelect);
            grid.DataSource = this.dsPR.Tables[0];
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
                NP_Cls.SqlSelect = "SELECT top (1) CONVERT(int, RIGHT(GTNumber, 4)) AS SS, RIGHT(CONVERT(nvarchar, GETDATE(), 112), 6) AS s FROM   t_GT WHERE (RIGHT(CONVERT(nvarchar, GETDATE(), 112), 6) = LEFT(RIGHT(GTNumber, 10), 6)) ORDER BY SS DESC";
                DataSet dsGen = new DataSet(); dsGen = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (dsGen.Tables[0].Rows.Count == 0)
                {
                    NP_Cls.SqlSelect = "SELECT  TOP (1) RIGHT(CONVERT(nvarchar, GETDATE(), 112), 6) AS s";
                    return "GT" + NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0].Rows[0][0].ToString() + "0001";
                }
                else
                {
                   // string strCode = (Convert.ToInt16(dsGen.Tables[0].Rows[0][0].ToString()) + 1).ToString().PadLeft(5 - (Convert.ToInt16(dsGen.Tables[0].Rows[0][0].ToString()) + 1).ToString().Length, '0');
                    string strCode = (Convert.ToInt16(dsGen.Tables[0].Rows[0][0].ToString()) + 1).ToString().PadLeft(4, '0');
                    return "GT" + dsGen.Tables[0].Rows[0][1].ToString() + strCode;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void frmGoodsReturn_Load(object sender, EventArgs e)
        {
            try
            {
                WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
                frm.menuStrip1.Enabled = true;

                this.txtDoc.Text = GetNumber(); this.txtDocDate.Text = NP.GetDateServer().ToString("dd/MM/yyyy");

                NP_Cls.SqlSelect = "SELECT DISTINCT VendorName, VendorCode FROM  t_GR WHERE (MovementType = N'101')";
                NP.BindCB(this.cbVendor, NP_Cls.SqlSelect, "VendorName", "VendorCode", "((( Select Vendor GR )))");

                this.MyGrid(dgvView);

                Clear();
                this.cbVendor.Text = string.Empty; this.cbVendor.Select();
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Load : " + ex.Message); return;
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
                    NP_Cls.SqlSelect = "SELECT     VendorCode, VendorName, PurchasingGroup FROM  t_PO WHERE   (VendorCode = N'" + this.cbVendor.Text.Trim() + "')";
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
                    if (NP.MSGB("The GT list will be cancel , Do you agree with this ?") == DialogResult.Yes)
                    {
                        // Cancel
                        NP_Cls.SqlDel = "DELETE FROM t_GT WHERE (GTNumber = '" + this.txtDoc.Text.Trim() + "')"; string strErr = string.Empty;
                        if (!NP.SqlCmd(NP_Cls.SqlDel, ref strErr))
                        {
                            NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Delete : " + strErr); return;
                        }
                        else
                        {
                            NP_Cls.SqlDel = "DELETE FROM t_GTDetail WHERE (GTNumber = '" + this.txtDoc.Text.Trim() + "')";
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
        private void frmGoodsReturn_FormClosing(object sender, FormClosingEventArgs e)
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
                    NP_Cls.SqlInsert = "INSERT INTO t_GT " +
                      "(GTNumber, InvoiceNumber, GTDate, VendorCode, VendorName, PurchasingGroup, MovementType, Remark, UserCreate, DateCreate) " +
"VALUES     (@GTNumber,@Invoice, GETDATE(),@VendorCode,@VendorName,@PurchasingGroup,@MovementType,@Remark,@UC,GETDATE())";
                    this.strGNumber = GetNumber();
                    cmdIns.Parameters.Add("@GTNumber", SqlDbType.NVarChar, 12).Value = this.strGNumber;
                    cmdIns.Parameters.Add("@Invoice", SqlDbType.NVarChar, 20).Value = this.txtInv.Text.Trim();
                    cmdIns.Parameters.Add("@VendorCode", SqlDbType.NVarChar, 10).Value = this.cbVendor.Text.Trim();
                    cmdIns.Parameters.Add("@VendorName", SqlDbType.NVarChar, 60).Value = this.lblVendorName.Text.Trim();
                    cmdIns.Parameters.Add("@PurchasingGroup", SqlDbType.NVarChar, 3).Value = this.lblPG.Text.Trim();
                    cmdIns.Parameters.Add("@MovementType", SqlDbType.NVarChar, 3).Value = this.lblMovType.Text.Trim();
                    cmdIns.Parameters.Add("@Remark", SqlDbType.NVarChar, 255).Value = this.txtRemark.Text.Trim();
                    cmdIns.Parameters.Add("@UC", SqlDbType.NVarChar, 50).Value = NP_Cls.strUsr;
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert;
                    cmdIns.ExecuteNonQuery();

                    this.groupPR.Enabled = false; this.btnAddPR.Visible = false; this.btnSave.Visible = true;
                    NP_Cls.SqlSelect = "SELECT     GRNumber, GRNumber AS GRDis FROM t_GR WHERE (VendorCode = N'" + this.cbVendor.Text.Trim() + "') AND (MovementType = '101')";
                    NP.BindCB(this.cbPONumber, NP_Cls.SqlSelect, "GRNumber", "GRDis", "((( Select GR Number )))");
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
            if (NP.MSGB("Do you to cancel Goods Return ?") == DialogResult.Yes)
            {
                NP_Cls.SqlDel = "DELETE FROM t_GT WHERE (GTNumber = '" + this.txtDoc.Text.Trim() + "')"; string strErr = string.Empty;
                if (!NP.SqlCmd(NP_Cls.SqlDel, ref strErr))
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Delete : " + strErr); return;
                }
                else
                {
                    NP_Cls.SqlDel = "DELETE FROM t_GTDetail WHERE (GTNumber = '" + this.txtDoc.Text.Trim() + "')";
                    if (!NP.SqlCmd(NP_Cls.SqlDel, ref strErr))
                    {
                        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Delete Detail : " + strErr); return;
                    }
                }
                Clear(); this.groupPR.Enabled = true; this.cbPONumber.Text = string.Empty;
                if (this.dsPR.Tables.Count > 0) { this.dsPR.Tables.Clear(); this.MyGrid(this.dgvView); }
                this.cbPONumber.DataSource = null;
                this.btnAddPR.Visible = true; this.btnSave.Visible = false;

                NP_Cls.SqlSelect = "SELECT DISTINCT VendorName, VendorCode FROM t_PO WHERE (POApprove = 1)";
                NP.BindCB(this.cbVendor, NP_Cls.SqlSelect, "VendorName", "VendorCode", "((( Select Vendor PO )))");
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
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please add GT Header first !!"); return;
            }
            else
            {
                if (this.cbPONumber.SelectedIndex == 0)
                {
                    NP.ReqField(this.cbPONumber, "Please select GR Number first !!"); return;
                }
                else
                {
                    if (this.dsPR.Tables[0].Rows.Count > 0)
                    {
                        for (byte ii = 0; ii < this.dsPR.Tables[0].Rows.Count; ii++)
                        {
                            if (this.cbPONumber.Text.Trim() == this.dsPR.Tables[0].Rows[ii]["GRNumber"].ToString())
                            {
                                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "This GR Number is in GT List !!"); this.cbPONumber.Select(); return;
                            }
                        }
                    }
                    else if (this.dsPR.Tables[0].Rows.Count == 0)
                    {
                        //
                        NP_Cls.SqlSelect = "SELECT     0 AS ItemNo, t_GRDetail.MaterialCode, t_GRDetail.MaterialName, t_GRDetail.GRQuantity AS GTQty, t_GRDetail.UnitCode, t_GRDetail.UnitName,  t_GRDetail.PlantCode, t_GRDetail.LocCode, t_GRDetail.BatchNumber, t_GRDetail.DeliveryDate, t_GRDetail.GRNumber, t_GRDetail.NetPrice,  t_GRDetail.GRAmount AS GTAmt, t_GRDetail.PlantName, t_GRDetail.LocName, t_GRDetail.AutoID FROM t_GR INNER JOIN  t_GRDetail ON t_GR.GRNumber = t_GRDetail.GRNumber WHERE     (t_GRDetail.GRNumber = N'"+ this.cbPONumber.Text.Trim() +"') AND (t_GR.VendorCode = N'"+ this.cbVendor.Text.Trim() +"') AND (t_GR.MovementType = N'101')";
                        this.dsPR = NP.GetClientDataSet(NP_Cls.SqlSelect);
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
                    NP_Cls.SqlSelect = "SELECT     0 AS ItemNo, t_GRDetail.MaterialCode, t_GRDetail.MaterialName, t_GRDetail.GRQuantity AS GTQty, t_GRDetail.UnitCode, t_GRDetail.UnitName,  t_GRDetail.PlantCode, t_GRDetail.LocCode, t_GRDetail.BatchNumber, t_GRDetail.DeliveryDate, t_GRDetail.GRNumber, t_GRDetail.NetPrice,  t_GRDetail.GRAmount AS GTAmt, t_GRDetail.PlantName, t_GRDetail.LocName, t_GRDetail.AutoID FROM t_GR INNER JOIN  t_GRDetail ON t_GR.GRNumber = t_GRDetail.GRNumber WHERE     (t_GRDetail.GRNumber = N'" + this.cbPONumber.Text.Trim() + "') AND (t_GR.VendorCode = N'" + this.cbVendor.Text.Trim() + "') AND (t_GR.MovementType = N'101')";
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
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            NP_Cls.myInteger(sender, e);
        }
        private void dgvView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvView.CurrentCell.ColumnIndex == 3)
            {
                TextBox txtBox = e.Control as TextBox;
                txtBox.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
            }
        }
        private void dgvView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.dgvView.CurrentRow.Cells[12].Value = Convert.ToInt32(this.dgvView.CurrentRow.Cells[11].Value) * Convert.ToInt32(this.dgvView.CurrentRow.Cells[3].Value);
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Edit Cell : " + ex.Message); return;
            }            
        }
        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvView.RowCount == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found !!"); return; }
            this.dgvView[3, this.dgvView.CurrentRow.Index].Value = 0;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.dgvView.RowCount == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please select GR number into GR list !!"); this.cbPONumber.Select(); return; }
            this.dgvView.EndEdit();

            if (NP.MSGB("Do you to Save Goods Return ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr;
                Tr = oConn.BeginTransaction();

                try
                {
                    SqlCommand cmdIns = new SqlCommand();
                    NP_Cls.SqlInsert = "INSERT INTO t_GTDetail " +
                      "(GTNumber, MaterialCode, MaterialName, GTQuantity, UnitCode, UnitName, NetPrice, GTAmount, DeliveryDate, PlantCode, PlantName, LocCode, LocName, BatchNumber, CurrentUser, GRNumber, GRAutoID) " +
"VALUES     (@GTNumber,@MaterialCode,@MaterialName,@GTQuantity,@UnitCode,@UnitName,@NetPrice,@GTAmount,@DeliveryDate,@PlantCode,@PlantName,@LocCode,@LocName,@BatchNumber,@CurrentUser,@GRNumber, @GRID)";
                    cmdIns.Parameters.Add("@GTNumber", SqlDbType.NVarChar, 12);
                    cmdIns.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15);
                    cmdIns.Parameters.Add("@MaterialName", SqlDbType.NVarChar, 60);
                    cmdIns.Parameters.Add("@GTQuantity", SqlDbType.Decimal);
                    cmdIns.Parameters.Add("@UnitCode", SqlDbType.NVarChar, 3);
                    cmdIns.Parameters.Add("@UnitName", SqlDbType.NVarChar, 20);
                    cmdIns.Parameters.Add("@NetPrice", SqlDbType.Decimal);
                    cmdIns.Parameters.Add("@GTAmount", SqlDbType.Decimal);
                    cmdIns.Parameters.Add("@DeliveryDate", SqlDbType.DateTime);
                    cmdIns.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 4);
                    cmdIns.Parameters.Add("@PlantName", SqlDbType.NVarChar, 20);
                    cmdIns.Parameters.Add("@LocCode", SqlDbType.NVarChar, 2);
                    cmdIns.Parameters.Add("@LocName", SqlDbType.NVarChar, 20);
                    cmdIns.Parameters.Add("@BatchNumber", SqlDbType.NVarChar, 20);
                    cmdIns.Parameters.Add("@GRNumber", SqlDbType.NVarChar, 12);
                    cmdIns.Parameters.Add("@CurrentUser", SqlDbType.NVarChar, 50);
                    cmdIns.Parameters.Add("@GRID", SqlDbType.Int);
                    for (byte ins = 0; ins < this.dgvView.RowCount; ins++)
                    {
                        if (Convert.ToInt32(this.dgvView[3, ins].Value) != 0)
                        {
                            cmdIns.Parameters["@GTNumber"].Value = this.strGNumber;
                            cmdIns.Parameters["@MaterialCode"].Value = this.dgvView[1, ins].Value.ToString();
                            cmdIns.Parameters["@MaterialName"].Value = this.dgvView[2, ins].Value.ToString();
                            cmdIns.Parameters["@GTQuantity"].Value = Convert.ToInt32(this.dgvView[3, ins].Value);
                            cmdIns.Parameters["@UnitCode"].Value = this.dgvView[5, ins].Value.ToString();
                            cmdIns.Parameters["@UnitName"].Value = this.dgvView[4, ins].Value.ToString();
                            cmdIns.Parameters["@NetPrice"].Value = Convert.ToInt32(this.dgvView[11, ins].Value);
                            cmdIns.Parameters["@GTAmount"].Value = Convert.ToInt32(this.dgvView[12, ins].Value);
                            cmdIns.Parameters["@DeliveryDate"].Value = Convert.ToDateTime(this.dgvView[9, ins].Value);
                            cmdIns.Parameters["@PlantCode"].Value = this.dgvView[6, ins].Value.ToString();
                            cmdIns.Parameters["@PlantName"].Value = this.dgvView[13, ins].Value.ToString();
                            cmdIns.Parameters["@LocCode"].Value = this.dgvView[7, ins].Value.ToString();
                            cmdIns.Parameters["@LocName"].Value = this.dgvView[14, ins].Value.ToString();
                            cmdIns.Parameters["@BatchNumber"].Value = this.dgvView[8, ins].Value.ToString();
                            cmdIns.Parameters["@GRNumber"].Value = this.dgvView[10, ins].Value.ToString();
                            cmdIns.Parameters["@CurrentUser"].Value = NP_Cls.strUsr;
                            cmdIns.Parameters["@GRID"].Value = this.dgvView[15, ins].Value.ToString();

                            cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                            cmdIns.ExecuteNonQuery();

                            //NP_Cls.sqlUpdate = "UPDATE t_PODetail SET GRQuantity = @GRQuantity WHERE (PONumber = @PONumber) AND (AutoID = @POID)";
                            //cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.sqlUpdate; cmdIns.Transaction = Tr;
                            //cmdIns.ExecuteNonQuery();
                        }
                    }

                    Tr.Commit(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Save Goods Return Completed !!");
                    Clear();
                    this.groupPR.Enabled = true; this.btnAddPR.Visible = true; this.btnSave.Visible = false; this.cbPONumber.Text = string.Empty; this.cbPONumber.DataSource = null;
                    this.MyGrid(dgvView); this.txtDoc.Text = GetNumber();

                    NP_Cls.SqlSelect = "SELECT DISTINCT VendorName, VendorCode FROM  t_GR WHERE (MovementType = N'101')";
                    NP.BindCB(this.cbVendor, NP_Cls.SqlSelect, "VendorName", "VendorCode", "((( Select Vendor GR )))");
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

        private void txtDoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //MessageBox.Show("Yo");
                NP_Cls.SqlSelect = "SELECT     0 AS ItemNo, t_GTDetail.MaterialCode, t_GTDetail.MaterialName, t_GTDetail.GTQuantity AS GTQty, t_GTDetail.UnitCode, t_GTDetail.UnitName,  t_GTDetail.PlantCode, t_GTDetail.LocCode, t_GTDetail.BatchNumber, t_GTDetail.DeliveryDate, t_GTDetail.GRNumber, t_GTDetail.NetPrice, t_GTDetail.GTAmount AS GTAmt, t_GTDetail.PlantName, t_GTDetail.LocName, t_GTDetail.GRAutoID AS AutoID FROM t_GT INNER JOIN t_GTDetail ON t_GT.GTNumber = t_GTDetail.GTNumber WHERE (t_GT.GTNumber = N'"+ this.txtDoc.Text.Trim() +"')";
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

                //for (byte col = 0; col < this.dgvView.RowCount; col++)
                //{
                //    if (Convert.ToBoolean(this.dsPR.Tables[0].Rows[col]["isPO"]))
                //    {
                //        this.dgvView.Rows[col].DefaultCellStyle.BackColor = Color.LightBlue;
                //    }
                //}
                //this.dgvView.ClearSelection();
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Clear(); this.txtDoc.DropDownStyle = ComboBoxStyle.DropDownList; this.txtDoc.Text = string.Empty; this.cbVendor.Text = string.Empty; cbVendor.Enabled = true;
            NP_Cls.SqlSelect = "SELECT     GTNumber, GTNumber AS GTDis FROM         t_GT";
            NP.BindCB(this.txtDoc, NP_Cls.SqlSelect, "GTNumber", "GTDis", "( Select GT Number )");
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
                NP_Cls.SqlSelect = "SELECT 0 AS ItemNo, t_GTDetail.MaterialCode, t_GTDetail.MaterialName, t_GTDetail.GTQuantity AS GTQty, t_GTDetail.UnitCode, t_GTDetail.UnitName,  t_GTDetail.PlantCode, t_GTDetail.LocCode, t_GTDetail.BatchNumber, t_GTDetail.DeliveryDate, t_GTDetail.GRNumber, t_GTDetail.NetPrice, t_GTDetail.GTAmount AS GTAmt, t_GTDetail.PlantName, t_GTDetail.LocName, t_GTDetail.GRAutoID AS AutoID, t_GT.VendorCode FROM t_GT INNER JOIN t_GTDetail ON t_GT.GTNumber = t_GTDetail.GTNumber WHERE (t_GT.GTNumber = N'" + this.txtDoc.Text.Trim() + "')";
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
                NP_Cls.SqlSelect = "SELECT     GRNumber, GRNumber AS GRDis FROM t_GR WHERE (VendorCode = N'" + this.cbVendor.Text.Trim() + "') AND (MovementType = '101')";
                NP.BindCB(this.cbPONumber, NP_Cls.SqlSelect, "GRNumber", "GRDis", "((( Select GR Number )))"); this.cbPONumber.Select(); this.cbPONumber.SelectAll();
            }
        }
    }
}
