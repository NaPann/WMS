using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace WMS.SaleTranSac
{
    public partial class frmGI : Form
    {
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection(); private byte bView = 0; private string strPlant = string.Empty; private string strLoc = string.Empty;
        private string strGNumber = string.Empty; private DataSet dsPR = new DataSet(); private string strPRref = string.Empty; string strMRP = string.Empty; private byte lessStock = 0;
        private byte moreMat = 0;
        public frmGI()
        {
            InitializeComponent();
        }
        private void MyGrid(DataGridView grid)
        {
            NP_Cls.SqlSelect = "SELECT     1 AS ItemNo, t_PrdOrderDetail.UnitCode, t_PrdOrderDetail.UnitName, t_PrdOrderDetail.PlantCode, t_PrdOrderDetail.PlantName,                   t_PrdOrderDetail.LocCode, t_PrdOrderDetail.LocName, t_PrdOrderDetail.PrdONumber, t_PrdOrderDetail.ComponentCode AS MaterialCode, t_PrdOrderDetail.ComponentName AS MaterialName, t_PrdOrderDetail.PrdOQuantity AS Qty, t_PrdOrderDetail.PrdOQuantity AS PrdOQty, ISNULL(t_StockOverview.QI,0) AS QI, t_StockOverview.BatchNumber FROM t_PrdOrder INNER JOIN t_PrdOrderDetail ON t_PrdOrder.PrdONumber = t_PrdOrderDetail.PrdONumber LEFT OUTER JOIN  t_StockOverview ON t_PrdOrderDetail.ComponentCode = t_StockOverview.MaterialCode WHERE     (t_PrdOrderDetail.ComponentCode = N'') AND (t_PrdOrderDetail.PrdONumber = N'')";
            this.dsPR = NP.GetClientDataSet(NP_Cls.SqlSelect);
            grid.DataSource = this.dsPR.Tables[0];
        }
        private void frmGI_Load(object sender, EventArgs e)
        {
            try
            {
                WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
                frm.menuStrip1.Enabled = true;

                this.txtGI.Text = GetNumber(); this.txtDocDate.Text = NP.GetDateServer().ToString("dd/MM/yyyy");
                this.MyGrid(dgvView);

                NP_Cls.SqlSelect = "SELECT     MaterialCode + ':' + MaterialName AS MatCode, PrdONumber FROM  t_PrdOrder WHERE (IsGI = 0)";
                NP.BindCB(this.cbPrdoOrder, NP_Cls.SqlSelect, "MatCode", "PrdONumber", "((( Select Prd Number )))"); Clear(); this.cbPrdoOrder.Text = string.Empty;
                this.cbPrdoOrder.Select();
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Load : " + ex.Message); return;
            }
        }
        private void Clear()
        {
            this.lblMaterialName.Text = string.Empty; this.lblHeadMaterial.Text = string.Empty; 
            this.lblPlant.Text = string.Empty; this.lblLocation.Text = string.Empty; this.lblBOMVer.Text = string.Empty;
        }
        private string GetNumber()
        {
            try
            {
                bView = 0;
                NP_Cls.SqlSelect = "SELECT top (1) CONVERT(int, RIGHT(DocNumber, 4)) AS SS, RIGHT(CONVERT(nvarchar, GETDATE(), 112), 6) AS s FROM t_StockMovement WHERE (RIGHT(CONVERT(nvarchar, GETDATE(), 112), 6) = LEFT(RIGHT(DocNumber, 10), 6)) AND (LEFT(DocNumber, 2) = 'GI') ORDER BY SS DESC";
                DataSet dsGen = new DataSet(); dsGen = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (dsGen.Tables[0].Rows.Count == 0)
                {
                    NP_Cls.SqlSelect = "SELECT  TOP (1) RIGHT(CONVERT(nvarchar, GETDATE(), 112), 6) AS s";
                    return "GI" + NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0].Rows[0][0].ToString() + "0001";
                }
                else
                {
                    //string strCode = (Convert.ToInt16(dsGen.Tables[0].Rows[0][0].ToString()) + 1).ToString().PadLeft(5 - (Convert.ToInt16(dsGen.Tables[0].Rows[0][0].ToString()) + 1).ToString().Length, '0');
                    string strCode = (Convert.ToInt16(dsGen.Tables[0].Rows[0][0].ToString()) + 1).ToString().PadLeft(4, '0');
                    return "GI" + dsGen.Tables[0].Rows[0][1].ToString() + strCode;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            NP_Cls.myDecimal(sender, e);
        }

        private void cbPrdoOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.cbPrdoOrder.SelectedIndex != 0) && (!string.IsNullOrEmpty(this.cbPrdoOrder.Text.Trim())))
            {
                this.lblHeadMaterial.Text = this.cbPrdoOrder.SelectedValue.ToString();
                DataSet dsDetail = new DataSet();
                try
                {
                    NP_Cls.SqlSelect = "SELECT     PrdQuantity, PlantCode, PlantName, BOMVersion, LocCode, LocName, MRPOrder FROM  t_PrdOrder WHERE  (PrdONumber = N'"+ this.cbPrdoOrder.Text.Trim() +"')";
                    dsDetail = NP.GetClientDataSet(NP_Cls.SqlSelect);
                    this.lblBOMVer.Text = dsDetail.Tables[0].Rows[0]["BOMVersion"].ToString();
                    this.lblLocation.Text = dsDetail.Tables[0].Rows[0]["LocName"].ToString();
                    this.lblPlant.Text = dsDetail.Tables[0].Rows[0]["PlantName"].ToString();
                    this.strPlant = dsDetail.Tables[0].Rows[0]["PlantCode"].ToString(); this.strLoc = dsDetail.Tables[0].Rows[0]["LocCode"].ToString();
                    strMRP  = dsDetail.Tables[0].Rows[0]["MRPOrder"].ToString();
                }
                catch (SqlException ex)
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Detail : " + ex.Message); return;
                }
            }
            else
            {
                Clear();
                this.cbPrdoOrder.Focus();
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(this.bView))
            {
                if ((this.dsPR.Tables[0].Rows.Count > 0) || (this.groupPR.Enabled == false))
                {
                    if (NP.MSGB("The GI list will be cancel , Do you agree with this ?") == DialogResult.Yes)
                    {
                        // Cancel
                        NP_Cls.SqlDel = "DELETE FROM t_GI WHERE (GINumber = '" + this.txtGI.Text.Trim() + "')"; string strErr = string.Empty;
                        if (!NP.SqlCmd(NP_Cls.SqlDel, ref strErr))
                        {
                            NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Delete : " + strErr); return;
                        }
                        else
                        {
                            NP_Cls.SqlDel = "DELETE FROM t_GIDetail WHERE (GINumber = '" + this.txtGI.Text.Trim() + "')";
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
        private void frmGI_FormClosing(object sender, FormClosingEventArgs e)
        {
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;
        }

        private void btnAddGI_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(this.cbPrdoOrder.Text.Trim())) && (this.cbPrdoOrder.SelectedIndex != 0))
            {

                //
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open();

                try
                {
                    SqlCommand cmdIns = new SqlCommand();
                    NP_Cls.SqlInsert = "INSERT INTO t_StockMovement "+
                      "(DocNumber, TranDate, RefNumber, PlantCode, PlantName, BOMVersion, LocCode, LocName, Remark, UserCreate, DateCreate) "+
"VALUES     (@GINumber, GETDATE(),@PrdONumber,@PlantCode,@PlantName,@BOMVersion,@LocCode,@LocName,@Remark,@UD,GETDATE())";
                    this.strGNumber = GetNumber();
                    cmdIns.Parameters.Add("@GINumber", SqlDbType.NVarChar, 12).Value = this.strGNumber;
                    //cmdIns.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15).Value = this.lblHeadMaterial.Text.Trim().Split(':')[0].ToString();
                    //cmdIns.Parameters.Add("@MaterialName", SqlDbType.NVarChar, 60).Value = this.lblHeadMaterial.Text.Trim().Split(':')[1].ToString();
                    cmdIns.Parameters.Add("@PrdONumber", SqlDbType.NVarChar, 50).Value = this.cbPrdoOrder.Text.Trim();
                    cmdIns.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 50).Value = this.strPlant;
                    cmdIns.Parameters.Add("@PlantName", SqlDbType.NVarChar, 50).Value = this.lblPlant.Text.Trim();
                    cmdIns.Parameters.Add("@BOMVersion", SqlDbType.NVarChar, 5).Value = this.lblBOMVer.Text.Trim();
                    cmdIns.Parameters.Add("@LocCode", SqlDbType.NVarChar, 50).Value = this.strLoc;
                    cmdIns.Parameters.Add("@LocName", SqlDbType.NVarChar, 50).Value = this.lblLocation.Text.Trim();
                    cmdIns.Parameters.Add("@Remark", SqlDbType.NVarChar, 255).Value = this.txtRemark.Text.Trim();
                    cmdIns.Parameters.Add("@UD", SqlDbType.NVarChar, 50).Value = NP_Cls.strUsr;
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert;
                    cmdIns.ExecuteNonQuery();

                    this.groupPR.Enabled = false; this.btnAddGI.Visible = false; this.btnSave.Visible = true;
                    NP_Cls.SqlSelect = "SELECT  DISTINCT     t_PrdOrderDetail.ComponentName AS MaterialName, t_PrdOrderDetail.ComponentCode + ':' + t_PrdOrderDetail.ComponentName AS MaterialName AS MaterialCode FROM   t_PrdOrder INNER JOIN                    t_PrdOrderDetail ON t_PrdOrder.PrdONumber = t_PrdOrderDetail.PrdONumber LEFT OUTER JOIN   t_StockMovement ON t_PrdOrder.PrdONumber = t_StockMovement.RefNumber WHERE     (t_PrdOrder.PrdONumber = N'" + this.cbPrdoOrder.Text.Trim() + "') AND (t_PrdOrderDetail.IsGIClose = 0) AND (t_StockMovement.IsClose = 0)";
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
        private void btnCancelGI_Click(object sender, EventArgs e)
        {
            try
            {
                if (NP.MSGB("Do you to cancel Goods Issue ?") == DialogResult.Yes)
                {
                    oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                    if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                    oConn.Open(); SqlTransaction Tr;
                    Tr = oConn.BeginTransaction();

                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        NP_Cls.SqlDel = "DELETE FROM t_StockMovement WHERE (DocNumber = @DocNumber)";
                        cmd.Parameters.Add("@DocNumber", SqlDbType.NVarChar, 12).Value = this.txtGI.Text.Trim();
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
                    this.btnAddGI.Visible = true; this.btnSave.Visible = false; strMRP = string.Empty;

                    NP_Cls.SqlSelect = "SELECT     MaterialCode + ':' + MaterialName AS MatCode, PrdONumber FROM  t_PrdOrder WHERE (IsGI = 0)";
                    NP.BindCB(this.cbPrdoOrder, NP_Cls.SqlSelect, "MatCode", "PrdONumber", "((( Select Prd Number )))");
                    this.cbPrdoOrder.Text = string.Empty; this.cbPrdoOrder.Select();
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
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please add GI Header first !!"); return;
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
                        //if (this.moreMat == 0)
                        //{
                        //    for (byte ii = 0; ii < this.dsPR.Tables[0].Rows.Count; ii++)
                        //    {
                        //        if (this.cbMaterial.Text.Trim() == this.dsPR.Tables[0].Rows[ii]["MaterialCode"].ToString())
                        //        {
                        //            NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "This material is in GI List !!"); this.cbMaterial.Select(); return;
                        //        }
                        //    }
                        //}
                    }
                    else if (this.dsPR.Tables[0].Rows.Count == 0)
                    {
                        //
                        NP_Cls.SqlSelect = "SELECT top(1) 1 AS ItemNo, t_PrdOrderDetail.UnitCode, t_PrdOrderDetail.UnitName, t_PrdOrderDetail.PlantCode, t_PrdOrderDetail.PlantName,                   t_PrdOrderDetail.LocCode, t_PrdOrderDetail.LocName, t_PrdOrderDetail.PrdONumber, t_PrdOrderDetail.ComponentCode AS MaterialCode, t_PrdOrderDetail.ComponentName AS MaterialName, t_PrdOrderDetail.PrdOQuantity AS Qty, t_PrdOrderDetail.PrdOQuantity AS PrdOQty, ISNULL(t_StockOverview.QI,0) AS QI, t_StockOverview.BatchNumber  FROM t_PrdOrder INNER JOIN t_PrdOrderDetail ON t_PrdOrder.PrdONumber = t_PrdOrderDetail.PrdONumber LEFT OUTER JOIN  t_StockOverview ON t_PrdOrderDetail.ComponentCode = t_StockOverview.MaterialCode WHERE     (t_PrdOrderDetail.ComponentCode = N'" + this.cbMaterial.Text.Trim().Split(':')[0] + "') AND (t_PrdOrderDetail.PrdONumber = N'" + this.cbPrdoOrder.Text.Trim() + "') Order By BatchNumber ";
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
                    for (int mm = 0; mm < this.dgvView.RowCount; mm++)
                    {
                        if (this.dgvView["clnMaterialCode", mm].Value.ToString() == this.cbMaterial.Text.Trim().Split(':')[0])
                        {
                            if (Convert.ToDouble(this.dgvView["clnFGStock", mm].Value) >= Convert.ToDouble(this.dgvView["clnQuantity", mm].Value))
                            {
                                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "This material is in GI List and enough for GI."); this.cbMaterial.Select(); return;
                            }
                            else { this.moreMat = 1; }
                        }
                    }
                    if (this.moreMat == 0)
                    {
                        NP_Cls.SqlSelect = "SELECT Top(1) 1 AS ItemNo, t_PrdOrderDetail.UnitCode, t_PrdOrderDetail.UnitName, t_PrdOrderDetail.PlantCode, t_PrdOrderDetail.PlantName,                   t_PrdOrderDetail.LocCode, t_PrdOrderDetail.LocName, t_PrdOrderDetail.PrdONumber, t_PrdOrderDetail.ComponentCode AS MaterialCode, t_PrdOrderDetail.ComponentName AS MaterialName, t_PrdOrderDetail.PrdOQuantity AS Qty, t_PrdOrderDetail.PrdOQuantity AS PrdOQty, ISNULL(t_StockOverview.QI,0) AS QI, t_StockOverview.BatchNumber FROM t_PrdOrder INNER JOIN t_PrdOrderDetail ON t_PrdOrder.PrdONumber = t_PrdOrderDetail.PrdONumber LEFT OUTER JOIN  t_StockOverview ON t_PrdOrderDetail.ComponentCode = t_StockOverview.MaterialCode WHERE     (t_PrdOrderDetail.ComponentCode = N'" + this.cbMaterial.Text.Trim().Split(':')[0] + "') AND (t_PrdOrderDetail.PrdONumber = N'" + this.cbPrdoOrder.Text.Trim() + "') Order By BatchNumber";
                    }
                    else
                    {
                        string strTmpB = string.Empty;
                        for (int m = 0; m < this.dgvView.RowCount; m++)
                        {
                            if (this.cbMaterial.Text.Trim().Split(':')[0] == dgvView["clnMaterialCode", m].Value.ToString())
                            {
                                if (string.IsNullOrEmpty(strTmpB))
                                {
                                    strTmpB = dgvView["clnBatchNumber", m].Value.ToString();
                                }
                                else
                                {
                                    strTmpB = "," + dgvView["clnBatchNumber", m].Value.ToString();
                                }
                            }
                        }
                        NP_Cls.SqlSelect = "SELECT     1 AS ItemNo, t_PrdOrderDetail.UnitCode, t_PrdOrderDetail.UnitName, t_PrdOrderDetail.PlantCode, t_PrdOrderDetail.PlantName,                   t_PrdOrderDetail.LocCode, t_PrdOrderDetail.LocName, t_PrdOrderDetail.PrdONumber, t_PrdOrderDetail.ComponentCode AS MaterialCode, t_PrdOrderDetail.ComponentName AS MaterialName, t_PrdOrderDetail.PrdOQuantity AS Qty, t_PrdOrderDetail.PrdOQuantity AS PrdOQty, ISNULL(t_StockOverview.QI,0) AS QI,  t_StockOverview.BatchNumber FROM t_PrdOrder INNER JOIN t_PrdOrderDetail ON t_PrdOrder.PrdONumber = t_PrdOrderDetail.PrdONumber LEFT OUTER JOIN  t_StockOverview ON t_PrdOrderDetail.ComponentCode = t_StockOverview.MaterialCode WHERE     (t_PrdOrderDetail.ComponentCode = N'" + this.cbMaterial.Text.Trim().Split(':')[0] + "') AND (t_PrdOrderDetail.PrdONumber = N'" + this.cbPrdoOrder.Text.Trim() + "') AND (t_StockOverview.BatchNumber NOT IN ('" + strTmpB + "'))";
                    } 
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            NP_Cls.myDecimal(sender, e);
        }
        private void dgvView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvView.CurrentCell.ColumnIndex == 10)
            {
                TextBox txtBox = e.Control as TextBox;
                txtBox.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
            }
        }
        private void dgvView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Convert.ToDouble(this.dgvView.Rows[e.RowIndex].Cells["clnQuantity"].Value) > Convert.ToDouble(this.dgvView.Rows[e.RowIndex].Cells["clnPrdOQty"].Value))
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Can not Goods Issue more than Prd order Qty !!"); this.dgvView.CancelEdit(); this.dgvView.ClearSelection(); return;
                }
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Edit Cell : " + ex.Message); return;
            }            
        }
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.dgvView.RowCount == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please select material into GI list !!"); this.cbMaterial.Select(); return; }
            this.dgvView.EndEdit(); this.dgvView.Sort(this.dgvView.Columns["clnMaterialCode"], ListSortDirection.Ascending);
            for (byte ii = 0; ii < this.dgvView.RowCount; ii++)
            {
                if (Convert.ToDouble(this.dgvView["clnQuantity", ii].Value) == 0)
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Quantity for GI must more than 0 !!"); return;
                }
            }
            
            this.dgvView.EndEdit(); this.lessStock = 0; double dTmp = 0;
            DataTable dtTmp = new DataTable(); dtTmp = this.dsPR.Tables[0].Clone();
            dtTmp.Columns.Remove("ItemNo"); dtTmp.Columns.Remove("UnitCode"); dtTmp.Columns.Remove("UnitName"); dtTmp.Columns.Remove("PlantCode");
            dtTmp.Columns.Remove("PlantName"); dtTmp.Columns.Remove("LocCode"); dtTmp.Columns.Remove("LocName"); dtTmp.Columns.Remove("PrdONumber");
            dtTmp.Columns.Remove("MaterialName");  dtTmp.Columns.Remove("BatchNumber");

            Hashtable hsTmp = new Hashtable();
            for (int mm = 0; mm < this.dgvView.RowCount; mm++)
            {
                try
                {
                    hsTmp.Add(this.dsPR.Tables[0].Rows[mm]["MaterialCode"].ToString(), dsPR.Tables[0].Compute("SUM(Qty)", "MaterialCode = " + dsPR.Tables[0].Rows[mm]["MaterialCode"].ToString()));
                    DataRow dr; dr = dtTmp.NewRow();
                    dr[0] = this.dsPR.Tables[0].Rows[mm]["MaterialCode"].ToString(); dr[1] = hsTmp[this.dsPR.Tables[0].Rows[mm]["MaterialCode"].ToString()];
                    dr[2] = Convert.ToDouble(this.dsPR.Tables[0].Rows[mm]["PrdOQty"]); dr[3] = dsPR.Tables[0].Compute("SUM(QI)", "MaterialCode = " + dsPR.Tables[0].Rows[mm]["MaterialCode"].ToString()); dtTmp.Rows.Add(dr);
                }
                catch
                { }
            }
            dtTmp.AcceptChanges();

            for (int ii = 0; ii < dtTmp.Rows.Count; ii++)
            {
                if (Convert.ToDouble(dtTmp.Rows[ii]["Qty"]) > Convert.ToDouble(dtTmp.Rows[ii]["PrdOQty"]))
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Mat.Code : " + this.dgvView["clnMaterialCode", ii].Value.ToString() + " is over Prod.Order Qty !!\nCan not GI. !!"); return;
                }
                else
                {
                    if (Convert.ToDouble(dtTmp.Rows[ii]["Qty"]) > Convert.ToDouble(dtTmp.Rows[ii]["QI"]))
                    {
                        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Mat.Code : " + this.dgvView["clnMaterialCode", ii].Value.ToString() + " is over Stock !!\nCan not GI. !!"); return;
                    }
                    else if (Convert.ToDouble(dtTmp.Rows[ii]["QI"]) == 0)
                    {
                        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Mat.Code : " + this.dgvView["clnMaterialCode", ii].Value.ToString() + " Stock is 0 !!\nCan not GI. !!"); return;
                    }
                    else if (Convert.ToDouble(dtTmp.Rows[ii]["Qty"]) < Convert.ToDouble(dtTmp.Rows[ii]["QI"]))
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

            if (NP.MSGB("Do you to Save Goods Issue ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr;
                Tr = oConn.BeginTransaction();

                try
                {
                    SqlCommand cmdIns = new SqlCommand();
                    NP_Cls.SqlInsert = "INSERT INTO t_StockMovementDetail "+
                      "(AutoID, DocNumber, MaterialCode, MaterialName, Quantity, UnitCode, UnitName, PlantCode, PlantName, LocCode, LocName, CurrentUser, RefNumber, BatchNumber) "+
"VALUES     (@ID, @GINumber,@MaterialCode,@MaterialName,@GIQuantity,@UnitCode,@UnitName,@PlantCode,@PlantName,@LocCode,@LocName,@CurrentUser,@PrdONumber, @BatchNumber)";
                    cmdIns.Parameters.Add("@ID", SqlDbType.Int);
                    cmdIns.Parameters.Add("@GINumber", SqlDbType.NVarChar, 12);
                    cmdIns.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15);
                    cmdIns.Parameters.Add("@MaterialName", SqlDbType.NVarChar, 60);
                    cmdIns.Parameters.Add("@GIQuantity", SqlDbType.Decimal);
                    cmdIns.Parameters.Add("@UnitCode", SqlDbType.NVarChar, 3);
                    cmdIns.Parameters.Add("@UnitName", SqlDbType.NVarChar, 20);
                    cmdIns.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 4);
                    cmdIns.Parameters.Add("@PlantName", SqlDbType.NVarChar, 20);
                    cmdIns.Parameters.Add("@LocCode", SqlDbType.NVarChar, 2);
                    cmdIns.Parameters.Add("@LocName", SqlDbType.NVarChar, 20);
                    cmdIns.Parameters.Add("@CurrentUser", SqlDbType.NVarChar, 50); cmdIns.Parameters.Add("@BatchNumber", SqlDbType.NVarChar, 10);
                    cmdIns.Parameters.Add("@PrdONumber", SqlDbType.NVarChar, 12); cmdIns.Parameters.Add("@MRPOrder", SqlDbType.NVarChar, 12);
                    cmdIns.Parameters.Add("@IsGIClose", SqlDbType.Bit); cmdIns.Parameters.Add("@MatHead", SqlDbType.NVarChar, 15);
                   

                    for (byte ins = 0; ins < this.dgvView.RowCount; ins++)
                    {
                        cmdIns.Parameters["@ID"].Value = ins + 1;
                        cmdIns.Parameters["@GINumber"].Value = this.strGNumber;
                        cmdIns.Parameters["@MaterialCode"].Value = this.dgvView["clnMaterialCode", ins].Value.ToString();
                        cmdIns.Parameters["@MaterialName"].Value = this.dgvView["clnMaterialName", ins].Value.ToString();
                        cmdIns.Parameters["@GIQuantity"].Value = Convert.ToDouble(this.dgvView["clnQuantity", ins].Value);
                        cmdIns.Parameters["@UnitCode"].Value = this.dgvView["clnUnitCode", ins].Value.ToString();
                        cmdIns.Parameters["@UnitName"].Value = this.dgvView["clnUnitName", ins].Value.ToString();
                        cmdIns.Parameters["@CurrentUser"].Value = NP_Cls.strUsr;
                        cmdIns.Parameters["@PlantCode"].Value = this.dgvView["clnPlantCode", ins].Value.ToString();
                        cmdIns.Parameters["@PlantName"].Value = this.dgvView["clnPlantName", ins].Value.ToString();
                        cmdIns.Parameters["@LocCode"].Value = this.dgvView["clnLocCode", ins].Value.ToString();
                        cmdIns.Parameters["@LocName"].Value = this.dgvView["clnLocName", ins].Value.ToString();
                        cmdIns.Parameters["@PrdONumber"].Value = this.cbPrdoOrder.Text.Trim();
                        cmdIns.Parameters["@IsGIClose"].Value = 0; cmdIns.Parameters["@MRPOrder"].Value = strMRP;
                        cmdIns.Parameters["@MatHead"].Value = this.lblHeadMaterial.Text.Trim().Split(':')[0].ToString();
                        cmdIns.Parameters["@BatchNumber"].Value = this.dgvView["clnBatchNumber", ins].Value.ToString();
                       

                        cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                        cmdIns.ExecuteNonQuery();

                        // Update Stock
                        NP_Cls.sqlUpdate = "UPDATE t_StockOverview SET QI = QI - @GIQuantity WHERE (BatchNumber = @BatchNumber)";
                        cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.sqlUpdate; cmdIns.Transaction = Tr;
                        cmdIns.ExecuteNonQuery();

                        //TODO 22.11.10 Prd Order from MRP
                        if (!string.IsNullOrEmpty(strMRP))
                        {
                            string strTR = "INSERT INTO t_MRPTranOrder (MaterialCode,TranOrder,TranQty,SONumber,IsComponent,MaterialHeader) VALUES (@MaterialCode,@GINumber,@GIQuantity,@MRPOrder,1,@MatHead)";
                            cmdIns.CommandText = strTR; cmdIns.Connection = oConn;
                            cmdIns.Transaction = Tr; cmdIns.ExecuteNonQuery();
                        }
                        //
                    }

         //           NP_Cls.sqlUpdate = "UPDATE t_PrdOrderDetail SET GIQty = GIQty + @GIQuantity, IsGIClose = @IsGIClose WHERE (PrdONumber = @PrdONumber) AND (ComponentCode = @MaterialCode)";
                    SqlCommand cmdSP = new SqlCommand();
                    cmdSP.Parameters.Add("@PrdOQty", SqlDbType.Decimal); cmdSP.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15);
                    cmdSP.Parameters.Add("@GIQuantity", SqlDbType.Decimal); cmdSP.Parameters.Add("@IsGIClose", SqlDbType.Bit); cmdSP.Parameters.Add("@PrdONumber", SqlDbType.NVarChar, 12);
                    for (byte up = 0; up < this.dgvView.RowCount; up++)
                    {
                        cmdSP.Parameters["@MaterialCode"].Value = this.dgvView["clnMaterialCode", up].Value.ToString();
                        cmdSP.Parameters["@GIQuantity"].Value = Convert.ToDouble(this.dgvView["clnQuantity", up].Value);
                        cmdSP.Parameters["@IsGIClose"].Value = 0; //(Convert.ToDouble(this.dgvView["clnQuantity", up].Value) == ? 1 : 0);
                        cmdSP.Parameters["@PrdOQty"].Value = Convert.ToDouble(this.dgvView["clnPrdOQty", up].Value);
                        cmdSP.Parameters["@PrdONumber"].Value = this.cbPrdoOrder.Text.Trim();

                        cmdSP.Connection = oConn; cmdSP.CommandType = CommandType.StoredProcedure; cmdSP.CommandText = "sp_GI_Save"; cmdSP.Transaction = Tr;
                        cmdSP.ExecuteNonQuery();                                              
                    }

                    NP_Cls.SqlSelect = "SELECT IsGIClose FROM t_PrdOrderDetail WHERE (PrdONumber = @PrdONumber)"; 
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlSelect; cmdIns.Transaction = Tr;
                    SqlDataAdapter da = new SqlDataAdapter(cmdIns); DataSet ds = new DataSet(); da.Fill(ds); bool bTmp = true;
                    for (int cp = 0; cp < ds.Tables[0].Rows.Count; cp++)
                    {
                        bTmp = bTmp && Convert.ToBoolean(ds.Tables[0].Rows[cp][0]);
                    }

                    NP_Cls.sqlUpdate = "UPDATE t_PrdOrder SET IsGI = @IsGI WHERE (PrdONumber = @PrdONumber)";
                    cmdIns.Parameters.Add("@IsGI", SqlDbType.Bit).Value = bTmp;
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.sqlUpdate; cmdIns.Transaction = Tr;
                    cmdIns.ExecuteNonQuery();

                   

                    Tr.Commit(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Save Goods Issue Completed !!");
                    Clear();
                    this.groupPR.Enabled = true; this.btnAddGI.Visible = true; this.btnSave.Visible = false; this.cbMaterial.Text = string.Empty; this.cbMaterial.DataSource = null;
                    this.dsPR.Tables.Clear(); this.MyGrid(dgvView); this.txtGI.Text = GetNumber();

                    NP_Cls.SqlSelect = "SELECT     MaterialCode + ':' + MaterialName AS MatCode, PrdONumber FROM  t_PrdOrder WHERE (IsGI = 0)";
                    NP.BindCB(this.cbPrdoOrder, NP_Cls.SqlSelect, "MatCode", "PrdONumber", "((( Select Prd Number )))"); 
                    this.cbPrdoOrder.Text = string.Empty; this.cbPrdoOrder.Select();
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
        private void btnClose_Click(object sender, EventArgs e)
        {

        }
        private void btnGenNew_Click(object sender, EventArgs e)
        {
            Clear(); this.txtGI.DropDownStyle = ComboBoxStyle.Simple; this.cbPrdoOrder.Enabled = true; this.dgvView.Columns["clnPrdOQty"].Visible = true;
            this.groupPR.Enabled = true; this.btnAddGI.Visible = true; this.btnSave.Visible = false; this.cbMaterial.Text = string.Empty; this.cbMaterial.DataSource = null;
            this.dsPR.Tables.Clear(); this.MyGrid(dgvView); this.txtGI.Text = GetNumber();
            this.cbPrdoOrder.Text = string.Empty; this.cbPrdoOrder.Select();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Clear(); this.txtGI.DropDownStyle = ComboBoxStyle.DropDownList; this.txtGI.Text = string.Empty; this.cbPrdoOrder.Text = string.Empty;
            NP_Cls.SqlSelect = "SELECT DocNumber, DocNumber AS GIDis FROM  t_StockMovement";
            NP.BindCB(this.txtGI, NP_Cls.SqlSelect, "DocNumber", "GIDis", "((( Select Goods Issue )))");
            this.groupPR.Enabled = true; this.btnAddGI.Visible = true; this.btnSave.Visible = false; this.cbMaterial.Text = string.Empty; this.cbMaterial.DataSource = null;
            this.MyGrid(dgvView); this.txtGI.Text = GetNumber(); this.txtGI.SelectedIndex = 0;
        }
        private void txtGI_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.txtGI.SelectedIndex != 0)
            {
                NP_Cls.SqlSelect = "SELECT     0 AS ItemNo, t_GI.GIDate, t_GI.PrdONumber, t_GI.MaterialCode AS HMatCode, t_GI.MaterialName AS HMatName, t_GI.PlantName AS HPlantName, t_GI.BOMVersion, t_GI.LocName AS HLocName, t_GI.Remark, t_GIDetail.MaterialCode, t_GIDetail.MaterialName, t_GIDetail.GIQuantity AS Qty, t_GIDetail.UnitCode, t_GIDetail.UnitName, t_GIDetail.PlantCode, t_GIDetail.PlantName, t_GIDetail.LocCode, t_GIDetail.LocName, 0 AS PrdoQty FROM t_GI INNER JOIN t_GIDetail ON t_GI.GINumber = t_GIDetail.GINumber WHERE     (t_GI.GINumber = N'"+ this.txtGI.Text.Trim() +"')";
                this.dsPR = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (this.dsPR.Tables[0].Rows.Count == 0) { this.dsPR.Tables.Clear(); this.MyGrid(dgvView); this.cbPrdoOrder.Enabled = true; this.cbPrdoOrder.Text = string.Empty; return; }
                bView = 1;
                for (byte ii = 0; ii < this.dsPR.Tables[0].Rows.Count; ii++)
                {
                    this.dsPR.Tables[0].Rows[ii]["ItemNo"] = Convert.ToInt32(ii + 1);
                }
                this.cbPrdoOrder.Text = this.dsPR.Tables[0].Rows[0]["PrdONumber"].ToString(); 
                this.txtDocDate.Text = Convert.ToDateTime(this.dsPR.Tables[0].Rows[0]["GIDate"]).ToString("dd/MM/yyyy");
                this.lblBOMVer.Text = this.dsPR.Tables[0].Rows[0]["BOMVersion"].ToString();
                this.lblHeadMaterial.Text = this.dsPR.Tables[0].Rows[0]["HMatCode"].ToString() + ":" + this.dsPR.Tables[0].Rows[0]["HMatName"].ToString();
                this.lblLocation.Text = this.dsPR.Tables[0].Rows[0]["HLocName"].ToString();
                this.lblPlant.Text = this.dsPR.Tables[0].Rows[0]["HPlantName"].ToString(); this.txtRemark.Text = this.dsPR.Tables[0].Rows[0]["Remark"].ToString();
                this.dsPR.Tables[0].Columns.Remove("PrdONumber"); this.cbPrdoOrder.Enabled = false;
                this.dsPR.Tables[0].Columns.Remove("GIDate"); this.dsPR.Tables[0].Columns.Remove("HMatCode");
                this.dsPR.Tables[0].Columns.Remove("HMatName"); this.dsPR.Tables[0].Columns.Remove("HPlantName");
                this.dsPR.Tables[0].Columns.Remove("BOMVersion"); this.dsPR.Tables[0].Columns.Remove("HLocName");
                this.dsPR.Tables[0].Columns.Remove("Remark"); this.dgvView.Columns["clnPrdOQty"].Visible = false;
                this.btnCancelGI.Visible = true;
               NP_Cls.SqlSelect = "SELECT    t_PrdOrderDetail.ComponentName AS MaterialName, t_PrdOrderDetail.ComponentCode AS MaterialCode FROM  t_PrdOrder INNER JOIN          t_PrdOrderDetail ON t_PrdOrder.PrdONumber = t_PrdOrderDetail.PrdONumber LEFT OUTER JOIN  t_GI ON t_PrdOrder.PrdONumber = t_GI.PrdONumber WHERE     (t_GI.IsClose = 0) AND (t_PrdOrder.PrdONumber = N'" + this.cbPrdoOrder.Text.Trim() + "') AND (t_PrdOrderDetail.IsGIClose = 0)";
               NP.BindCB(this.cbMaterial, NP_Cls.SqlSelect, "MaterialName", "MaterialCode", "((( Select Material )))");
                this.cbMaterial.Select();
                this.dgvView.DataSource = this.dsPR.Tables[0];

                // Head
                this.btnAddGI.Visible = false; this.btnSave.Visible = false;
                this.dgvView.ClearSelection();
            }
        }

        private void dgvView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((sender as DataGridView).Columns[e.ColumnIndex].Name == "clnQuantity")
            {
                if (e.Value != null)
                {
                    if (Convert.ToDouble((sender as DataGridView).Rows[e.RowIndex].Cells["clnQuantity"].Value) > Convert.ToDouble((sender as DataGridView).Rows[e.RowIndex].Cells["clnFGStock"].Value))
                    {
                        e.CellStyle.BackColor = Color.OrangeRed; 
                    }
                    else
                    {
                        if (Convert.ToDouble((sender as DataGridView).Rows[e.RowIndex].Cells["clnQuantity"].Value) > Convert.ToDouble((sender as DataGridView).Rows[e.RowIndex].Cells["clnPrdOQty"].Value))
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
    }
}
