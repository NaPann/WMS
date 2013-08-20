using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;

namespace WMS.SaleTranSac
{
    public partial class frmBorrow : Form
    {
        public frmBorrow()
        {
            InitializeComponent();
        }
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection();
        private byte bView = 0; private string strCurr = string.Empty; private string strGNumber = string.Empty; private string strPlantCode = string.Empty; private string strLocCode = string.Empty; private string strMatCode = string.Empty;
        Hashtable hsTmp = new Hashtable();

        private void frmBorrow_Load(object sender, EventArgs e)
        {
            try
            {
                WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
                frm.menuStrip1.Enabled = true;

                this.txtDocDate.Text = NP.GetDateServer().ToString("dd/MM/yyyy");
                this.MyGrid(dgvView);
                BindCB();
                this.txtQty.Enabled = true;
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Load : " + ex.Message); return;
            }
        }

        private void BindCB()
        {
            NP_Cls.SqlSelect = "SELECT  DISTINCT    m_Material.MaterialName, t_StockOverview.MaterialCode + ':' + m_Material.MaterialName AS MaterialCode FROM         t_StockOverview INNER JOIN                       m_Material ON t_StockOverview.MaterialCode = m_Material.MaterialCode WHERE     (t_StockOverview.UR > 0)";
            NP.BindCB(this.cbMaterialCode, NP_Cls.SqlSelect, "MaterialName", "MaterialCode", "((( Select Material )))"); Clear(); this.cbMaterialCode.Text = string.Empty; this.cbMaterialCode.Select();
        }
        private void Clear()
        {
            this.lblMaterial.Text = string.Empty; this.lblPlant.Text = string.Empty; this.lblLocation.Text = string.Empty;
            this.txtQty.Text = "0";
        }
        private void MyGrid(DataGridView grid)
        {
            NP_Cls.SqlSelect = "SELECT 1 AS ItemNo,    t_StockOverview.MaterialCode, m_Material.MaterialName, t_StockOverview.BatchNumber, t_StockOverview.UR,  0 AS Qty, t_StockOverview.UnitCode,    m_Unit.UnitName, t_StockOverview.PlantCode, m_Plant.PlantName, t_StockOverview.LocCode, m_Location.LocName FROM         m_Material INNER JOIN                       t_StockOverview ON m_Material.MaterialCode = t_StockOverview.MaterialCode INNER JOIN                       m_Unit ON t_StockOverview.UnitCode = m_Unit.UnitCode INNER JOIN                       m_Plant ON t_StockOverview.PlantCode = m_Plant.PlantCode INNER JOIN                       m_Location ON t_StockOverview.LocCode = m_Location.LocCode WHERE   (1=0) ";
            grid.DataSource = NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0];
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            NP_Cls.myDecimal(sender, e);
        }
        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(this.txtQty.Text.Trim()))
                {
                    if (Convert.ToDouble(this.txtQty.Text.Trim()) <= 0)
                    {
                        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please enter Qty: greater than 0 !!");
                        this.txtQty.Select(); this.txtQty.SelectAll(); return;
                    }
                    else
                    {
                        this.MyGrid(this.dgvView);
                        //this.btnRunProd_Click(sender, e);
                    }
                }
                else
                {
                    this.txtQty.Select(); this.txtQty.SelectAll();
                }
            }
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
        private void frmBorrow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (NP_Cls.FromMRP == 0)
            {
                WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
                frm.menuStrip1.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (!NP.ReqField(this.cbMaterialCode, "Please select Material !!")) { return; }
            if (!NP.ReqField(this.txtBatch, "Please entry Batch Number !!")) { return; }
            if (!NP.ReqField(this.txtQty, "Please select Quantity !!")) { return; }

            try
            {
                if (!string.IsNullOrEmpty(this.txtQty.Text.Trim()))
                {
                    if (Convert.ToDouble(this.txtQty.Text.Trim()) <= 0)
                    {
                        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please enter Qty: greater than 0 !!"); this.txtQty.Select(); this.txtQty.SelectAll(); return;
                    }
                    NP_Cls.SqlSelect = "SELECT 0 AS ItemNo,    t_StockOverview.MaterialCode, m_Material.MaterialName, t_StockOverview.BatchNumber,  t_StockOverview.UR, " + this.txtQty.Text.Trim() + " AS Qty, t_StockOverview.UnitCode,                        m_Unit.UnitName, t_StockOverview.PlantCode, m_Plant.PlantName, t_StockOverview.LocCode, m_Location.LocName FROM         m_Material INNER JOIN                       t_StockOverview ON m_Material.MaterialCode = t_StockOverview.MaterialCode INNER JOIN                       m_Unit ON t_StockOverview.UnitCode = m_Unit.UnitCode INNER JOIN                       m_Plant ON t_StockOverview.PlantCode = m_Plant.PlantCode INNER JOIN                       m_Location ON t_StockOverview.LocCode = m_Location.LocCode WHERE     (m_Material.MaterialCode = N'" + this.cbMaterialCode.Text.Trim().Split(':')[0].Trim() + "') AND ( t_StockOverview.BatchNumber = '" + this.txtBatch.Text.Trim() + "')";
                    DataSet dsTmp = new DataSet(); dsTmp = NP.GetClientDataSet(NP_Cls.SqlSelect);
                    if (dsTmp.Tables[0].Rows.Count == 0)
                    {
                        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Not found this Material in Stock .. Cannot Issue !!");
                        this.btnSave.Visible = false; this.cbMaterialCode.Select(); this.cbMaterialCode.SelectAll(); return;
                    }
                    else
                    {
                        if ((double.Parse(dsTmp.Tables[0].Rows[0]["UR"].ToString()) <= 0) || (string.IsNullOrEmpty(dsTmp.Tables[0].Rows[0]["UR"].ToString())))
                        {
                            NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "UR Quantity = 0 .. Cannot Issue !!");
                            this.btnSave.Visible = false; this.cbMaterialCode.Select(); this.cbMaterialCode.SelectAll(); return;
                        }
                        else if (double.Parse(dsTmp.Tables[0].Rows[0]["UR"].ToString()) < double.Parse(this.txtQty.Text.Trim()))
                        {
                            NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "UR Quantity less than Issue Quantity .. Cannot Issue !!");
                            this.btnSave.Visible = false; this.txtQty.Select(); this.txtQty.SelectAll(); return;
                        }


                        this.btnSave.Visible = true;
                    }

                    for (int i = 0; i < dsTmp.Tables[0].Rows.Count; i++)
                    {
                        dsTmp.Tables[0].Rows[i][0] = i + 1;
                    }

                    this.dgvView.DataSource = dsTmp.Tables[0];
                }
                else
                {
                    this.txtQty.Select(); this.txtQty.SelectAll();
                }
            }
            catch (SqlException ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Detail : " + ex.Message); return;
            }
        }
        private void cbMaterialCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.cbMaterialCode.SelectedIndex != 0) && (!string.IsNullOrEmpty(this.cbMaterialCode.Text.Trim())))
            {
                this.lblMaterial.Text = this.cbMaterialCode.SelectedValue.ToString(); hsTmp.Clear();
                DataSet dsDetail = new DataSet();

                NP_Cls.SqlSelect = "SELECT 1 AS ItemNo,    t_StockOverview.MaterialCode, m_Material.MaterialName, t_StockOverview.BatchNumber, 0 AS Qty, t_StockOverview.UR, t_StockOverview.UnitCode,                        m_Unit.UnitName, t_StockOverview.PlantCode, m_Plant.PlantName, t_StockOverview.LocCode, m_Location.LocName FROM         m_Material INNER JOIN                       t_StockOverview ON m_Material.MaterialCode = t_StockOverview.MaterialCode INNER JOIN                       m_Unit ON t_StockOverview.UnitCode = m_Unit.UnitCode INNER JOIN                       m_Plant ON t_StockOverview.PlantCode = m_Plant.PlantCode INNER JOIN                       m_Location ON t_StockOverview.LocCode = m_Location.LocCode WHERE     (t_StockOverview.MaterialCode = N'" + this.cbMaterialCode.Text.Trim().Split(':')[0].Trim() + "')";
                dsDetail = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (dsDetail.Tables[0].Rows.Count == 0)
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Description Not Found .. !!"); Clear(); MyGrid(this.dgvView);
                    this.btnSave.Visible = false; this.cbMaterialCode.Select(); this.cbMaterialCode.SelectAll(); return;
                }
                this.lblPlant.Text = dsDetail.Tables[0].Rows[0]["PlantName"].ToString(); hsTmp.Add("LocCode", dsDetail.Tables[0].Rows[0]["LocCode"].ToString());
                this.lblLocation.Text = dsDetail.Tables[0].Rows[0]["LocName"].ToString(); hsTmp.Add("PlantCode", dsDetail.Tables[0].Rows[0]["PlantCode"].ToString());
                hsTmp.Add("UnitCode", dsDetail.Tables[0].Rows[0]["UnitCode"].ToString()); hsTmp.Add("UnitName", dsDetail.Tables[0].Rows[0]["UnitName"].ToString());
                this.txtBatch.Select(); this.txtBatch.SelectAll();
            }
            else
            {
                Clear(); hsTmp.Clear(); MyGrid(this.dgvView);
                this.cbMaterialCode.Focus();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (NP.MSGB("Do you to Save Production Order no Job ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr;
                Tr = oConn.BeginTransaction();

                try
                {
                    if (!Convert.ToBoolean(bView))
                    {
                        SqlCommand cmdIns = new SqlCommand();
                        NP_Cls.SqlInsert = "INSERT INTO t_Borrow (RefNumber, BorrowDate, MaterialCode, MaterialName, BorrowQuantity, UnitCode, UnitName, PlantCode, PlantName, LocCode, LocName, Remark, UserCreate, DateCreate) VALUES (@RefNumber,GETDATE(),@MaterialCode,@MaterialName,@BorrowQuantity,@UnitCode, @UnitName, @PlantCode,@PlantName,@LocCode,@LocName,@Remark,@UserCreate,  GETDATE())";
                        cmdIns.Parameters.Add("@RefNumber", SqlDbType.NVarChar, 12);
                        cmdIns.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15);
                        cmdIns.Parameters.Add("@MaterialName", SqlDbType.NVarChar, 60);
                        cmdIns.Parameters.Add("@BorrowQuantity", SqlDbType.Decimal);
                        cmdIns.Parameters.Add("@UnitCode", SqlDbType.NVarChar, 4);
                        cmdIns.Parameters.Add("@UnitName", SqlDbType.NVarChar, 20);
                        cmdIns.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 4);
                        cmdIns.Parameters.Add("@PlantName", SqlDbType.NVarChar, 20);
                        cmdIns.Parameters.Add("@LocCode", SqlDbType.NVarChar, 2);
                        cmdIns.Parameters.Add("@LocName", SqlDbType.NVarChar, 20);
                        cmdIns.Parameters.Add("@Remark", SqlDbType.NVarChar, 255);
                        cmdIns.Parameters.Add("@UserCreate", SqlDbType.NVarChar, 50);

                        //SqlCommand cmdInsDetail = new SqlCommand();
                        //NP_Cls.SqlInsert = "INSERT INTO t_PrdOrderDetail (PrdONumber, ComponentCode, ComponentName, PrdOQuantity, UnitCode, UnitName, PlantCode, PlantName, LocCode, LocName, CurrentUser) VALUES     (@PrdONumber,@ComponentCode,@ComponentName,@PrdOQuantity,@UnitCode,@UnitName,@PlantCode,@PlantName,@LocCode,@LocName,@CurrentUser)";
                        //cmdInsDetail.Parameters.Add("@PrdONumber", SqlDbType.NVarChar, 12);
                        //cmdInsDetail.Parameters.Add("@ComponentCode", SqlDbType.NVarChar, 15);
                        //cmdInsDetail.Parameters.Add("@ComponentName", SqlDbType.NVarChar, 60);
                        //cmdInsDetail.Parameters.Add("@PrdOQuantity", SqlDbType.Decimal);
                        //cmdInsDetail.Parameters.Add("@UnitCode", SqlDbType.NVarChar, 3);
                        //cmdInsDetail.Parameters.Add("@UnitName", SqlDbType.NVarChar, 20);
                        //cmdInsDetail.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 4);
                        //cmdInsDetail.Parameters.Add("@PlantName", SqlDbType.NVarChar, 20);
                        //cmdInsDetail.Parameters.Add("@LocCode", SqlDbType.NVarChar, 2);
                        //cmdInsDetail.Parameters.Add("@LocName", SqlDbType.NVarChar, 20);
                        //cmdInsDetail.Parameters.Add("@CurrentUser", SqlDbType.NVarChar, 50);


                        for (byte ins = 0; ins < this.dgvView.RowCount; ins++)
                        {
                            cmdIns.Parameters["@RefNumber"].Value = this.txtPrdOrder.Text.Trim();
                            cmdIns.Parameters["@MaterialCode"].Value = this.dgvView["clnMaterialCode", ins].Value.ToString();
                            cmdIns.Parameters["@MaterialName"].Value = this.dgvView["clnMaterialName", ins].Value.ToString();
                            cmdIns.Parameters["@BorrowQuantity"].Value = Convert.ToDecimal(this.dgvView["clnQuantity", ins].Value);
                            cmdIns.Parameters["@UnitCode"].Value = this.dgvView["clnUnitCode", ins].Value.ToString();
                            cmdIns.Parameters["@UnitName"].Value = this.dgvView["clnUnitName", ins].Value.ToString();
                            cmdIns.Parameters["@UserCreate"].Value = NP_Cls.strUsr;
                            cmdIns.Parameters["@PlantCode"].Value = this.dgvView["clnPlantCode", ins].Value.ToString();
                            cmdIns.Parameters["@PlantName"].Value = this.dgvView["clnPlantName", ins].Value.ToString();
                            cmdIns.Parameters["@LocCode"].Value = this.dgvView["clnLocCode", ins].Value.ToString();
                            cmdIns.Parameters["@LocName"].Value = this.dgvView["clnLocName", ins].Value.ToString();
                            cmdIns.Parameters["@Remark"].Value = this.txtRemark.Text.Trim();
                            cmdIns.Parameters.Add("@BatchNumber", SqlDbType.NVarChar, 10).Value = this.dgvView["clnBatch", ins].Value.ToString();

                            cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                            cmdIns.ExecuteNonQuery();

                            // Stock Overview //
                            NP_Cls.sqlUpdate = "UPDATE   t_StockOverview SET UR = UR - @BorrowQuantity  WHERE (BatchNumber = @BatchNumber)";
                            cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.sqlUpdate; cmdIns.Transaction = Tr;
                            cmdIns.ExecuteNonQuery();
                        }

                        cmdIns.Parameters.Clear();
                        // Master
                        NP_Cls.SqlInsert = "INSERT INTO t_StockMovement " +
                        "(DocNumber, TranDate, MovementType, RefNumber,  Remark, UserCreate,  DateCreate) " +
    "VALUES     (@GINumber, GETDATE(), @MV, @PrdONumber,@Remark,@UD,GETDATE())";
                        Random rnd = new Random();
                        string tmpString = "BR" + DateTime.Now.Year.ToString(NP_Cls.cul) + rnd.Next(1, 99999);
                        cmdIns.Parameters.Add("@GINumber", SqlDbType.NVarChar, 12).Value = tmpString;
                        cmdIns.Parameters.Add("@PrdONumber", SqlDbType.NVarChar, 50).Value = this.txtPrdOrder.Text.Trim();
                        cmdIns.Parameters.Add("@MV", SqlDbType.NVarChar, 3).Value = (!string.IsNullOrEmpty(this.txtPrdOrder.Text.Trim()) ? "261" : "999");
                        cmdIns.Parameters.Add("@Remark", SqlDbType.NVarChar, 500).Value = this.lblPlant.Text.Trim();
                        cmdIns.Parameters.Add("@UD", SqlDbType.NVarChar, 50).Value = NP_Cls.strUsr;
                        cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                        cmdIns.ExecuteNonQuery();


                        // Detail
                        cmdIns.Parameters.Clear();
                        NP_Cls.SqlInsert = "INSERT INTO t_StockMovementDetail " +
                          "(AutoID,DocNumber, MaterialCode, MaterialName, Quantity, UnitCode, UnitName, PlantCode, PlantName, LocCode, LocName, CurrentUser, RefNumber, BatchNumber) " +
    "VALUES     (@AutoID, @DocNumber,@MaterialCode,@MaterialName,@GIQuantity,@UnitCode,@UnitName,@PlantCode,@PlantName,@LocCode,@LocName,@CurrentUser,@PrdONumber, @BatchNumber)";
                        cmdIns.Parameters.Add("@AutoID", SqlDbType.Int);
                        cmdIns.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15);
                        cmdIns.Parameters.Add("@MaterialName", SqlDbType.NVarChar, 60);
                        cmdIns.Parameters.Add("@GIQuantity", SqlDbType.Decimal);
                        cmdIns.Parameters.Add("@UnitCode", SqlDbType.NVarChar, 3);
                        cmdIns.Parameters.Add("@UnitName", SqlDbType.NVarChar, 20);
                        cmdIns.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 4);
                        cmdIns.Parameters.Add("@PlantName", SqlDbType.NVarChar, 20);
                        cmdIns.Parameters.Add("@LocCode", SqlDbType.NVarChar, 4);
                        cmdIns.Parameters.Add("@LocName", SqlDbType.NVarChar, 20);
                        cmdIns.Parameters.Add("@CurrentUser", SqlDbType.NVarChar, 50);
                        cmdIns.Parameters.Add("@BatchNumber", SqlDbType.NVarChar, 10);
                        cmdIns.Parameters.Add("@PrdONumber", SqlDbType.NVarChar, 12);
                        cmdIns.Parameters.Add("@DocNumber", SqlDbType.NVarChar, 12);

                        for (byte ins = 0; ins < this.dgvView.RowCount; ins++)
                        {
                            cmdIns.Parameters["@AutoID"].Value = ins;
                            cmdIns.Parameters["@MaterialCode"].Value = this.dgvView["clnMaterialCode", ins].Value.ToString();
                            cmdIns.Parameters["@MaterialName"].Value = this.dgvView["clnMaterialName", ins].Value.ToString();
                            cmdIns.Parameters["@GIQuantity"].Value = Convert.ToDouble(this.dgvView["clnQuantity", ins].Value.ToString());
                            cmdIns.Parameters["@UnitCode"].Value = this.dgvView["clnUnitCode", ins].Value.ToString();
                            cmdIns.Parameters["@UnitName"].Value = this.dgvView["clnUnitName", ins].Value.ToString();
                            cmdIns.Parameters["@CurrentUser"].Value = NP_Cls.strUsr;
                            cmdIns.Parameters["@PlantCode"].Value = this.dgvView["clnPlantCode", ins].Value.ToString();
                            cmdIns.Parameters["@PlantName"].Value = this.dgvView["clnPlantName", ins].Value.ToString();
                            cmdIns.Parameters["@LocCode"].Value = this.dgvView["clnLocCode", ins].Value.ToString();
                            cmdIns.Parameters["@LocName"].Value = this.dgvView["clnLocName", ins].Value.ToString();
                            cmdIns.Parameters["@PrdONumber"].Value = this.txtPrdOrder.Text.Trim();
                            cmdIns.Parameters["@DocNumber"].Value = tmpString;
                            cmdIns.Parameters["@BatchNumber"].Value = this.dgvView["clnBatch", ins].Value.ToString();

                            cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                            cmdIns.ExecuteNonQuery();
                        }
                        
                        Tr.Commit(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Save Production Order Completed !!");
                        Clear(); this.btnSave.Visible = false;
                        this.MyGrid(dgvView); this.txtPrdOrder.DropDownStyle = ComboBoxStyle.Simple;
                        BindCB();
                        this.cbMaterialCode.Enabled = true;
                        this.cbMaterialCode.Text = string.Empty; this.cbMaterialCode.Select(); this.cbMaterialCode.SelectAll();
                    }
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

    }
}
