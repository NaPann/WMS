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
    public partial class frmGRProduction : Form
    {
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection(); private byte bView = 0;
        private string strGNumber = string.Empty; private DataSet dsPR = new DataSet(); private double PrdQty = 0;

        public frmGRProduction()
        {
            InitializeComponent();
        }
        private void MyGrid(DataGridView grid)
        {
            NP_Cls.SqlSelect = "SELECT     1 AS ItemNo, t_BOMDetail.MaterialCode, m_Material.MaterialName, t_BOMDetail.Quantity AS Qty, m_Material.UnitCode, m_Unit.UnitName,                  m_Location.LocName, m_Plant.PlantName FROM m_Location RIGHT OUTER JOIN t_BOM INNER JOIN t_BOMDetail ON t_BOM.BOMCode = t_BOMDetail.BOMCode LEFT OUTER JOIN              m_Plant RIGHT OUTER JOIN  m_Material ON m_Plant.PlantCode = m_Material.PlantCode LEFT OUTER JOIN m_Unit ON m_Material.UnitCode = m_Unit.UnitCode ON t_BOMDetail.MaterialCode = m_Material.MaterialCode ON     m_Location.LocCode = m_Material.LocCode WHERE     (t_BOM.MaterialCode = N'') AND (t_BOM.FileStatus = N'1') AND (t_BOM.Approve = 1)";
            grid.DataSource = NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0];
        }
        private void frmGRProduction_Load(object sender, EventArgs e)
        {
            try
            {
                WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
                frm.menuStrip1.Enabled = true;

                this.txtDocNo.Text = GetNumber(); this.txtDocDate.Text = NP.GetDateServer().ToString("dd/MM/yyyy");

                BindMat();

                Clear();
                this.cbPrdOrder.Text = string.Empty; this.cbPrdOrder.Select();
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Load : " + ex.Message); return;
            }
        }

        private void Clear()
        {
            this.lblMaterialName.Text = string.Empty; this.txtQty.Text = string.Empty; this.lblBatch.Text = string.Empty;
            this.lblPlant.Text = string.Empty; this.lblUnit.Text = string.Empty; this.lblLoc.Text = string.Empty; this.lblMatCode.Text = string.Empty; this.lblLastGP.Text = "-";
        }
        private string GetNumber()
        {
            try
            {
                NP_Cls.SqlSelect = "SELECT top (1) CONVERT(int, RIGHT(DocNumber, 4)) AS SS, RIGHT(CONVERT(nvarchar, GETDATE(), 112), 6) AS s FROM   t_StockMovement WHERE (RIGHT(CONVERT(nvarchar, GETDATE(), 112), 6) = LEFT(RIGHT(DocNumber, 10), 6))  AND (LEFT(DocNumber, 2) = 'GP') ORDER BY SS DESC";
                DataSet dsGen = new DataSet(); dsGen = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (dsGen.Tables[0].Rows.Count == 0)
                {
                    NP_Cls.SqlSelect = "SELECT  TOP (1) RIGHT(CONVERT(nvarchar, GETDATE(), 112), 6) AS s";
                    return "GP" + NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0].Rows[0][0].ToString() + "0001";
                }
                else
                {
                    //string strCode = (Convert.ToInt16(dsGen.Tables[0].Rows[0][0].ToString()) + 1).ToString().PadLeft(5 - (Convert.ToInt16(dsGen.Tables[0].Rows[0][0].ToString()) + 1).ToString().Length, '0');
                    string strCode = (Convert.ToInt16(dsGen.Tables[0].Rows[0][0].ToString()) + 1).ToString().PadLeft(4, '0');
                    return "GP" + dsGen.Tables[0].Rows[0][1].ToString() + strCode;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void cbPrdOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.cbPrdOrder.SelectedIndex != 0) && (!string.IsNullOrEmpty(this.cbPrdOrder.Text.Trim())))
            {
                this.lblMaterialName.Text = this.cbPrdOrder.SelectedValue.ToString();
                DataSet dsDetail = new DataSet();
                try
                {
                    NP_Cls.SqlSelect = "SELECT t_PrdOrder.MaterialCode, t_PrdOrder.MaterialName, PrdQuantity,isnull(GrPrdQuantity,0)GrPrdQuantity, t_PrdOrder.PlantCode, PlantName, BOMVersion, t_PrdOrder.LocCode, LocName,m_Material.UnitCode,m_Unit.UnitName,LastGP.DocNumber FROM  t_PrdOrder inner join m_Material on t_PrdOrder.MaterialCode = m_Material.MaterialCode inner join m_Unit on m_Unit.UnitCode =m_Material.UnitCode left join (Select Top(1) DocNumber,RefNumber from [t_StockMovement] where DocNumber like 'GP%' order by DateCreate DESC)as LastGP on LastGP.RefNumber = t_PrdOrder.PrdONumber WHERE  (PrdONumber = N'" + this.cbPrdOrder.Text.Trim() + "')";
                    dsDetail = NP.GetClientDataSet(NP_Cls.SqlSelect);
                    this.lblUnit.Text = dsDetail.Tables[0].Rows[0]["UnitCode"].ToString();
                    this.lblLastGP.Text = dsDetail.Tables[0].Rows[0]["DocNumber"].ToString() != "" ? dsDetail.Tables[0].Rows[0]["DocNumber"].ToString() : "-";
                    this.lblUnitName.Text = dsDetail.Tables[0].Rows[0]["UnitName"].ToString();
                    this.lblUnitCode.Text = dsDetail.Tables[0].Rows[0]["UnitCode"].ToString();
                    this.lblPlantCode.Text = dsDetail.Tables[0].Rows[0]["PlantCode"].ToString();
                    this.lblLocCode.Text = dsDetail.Tables[0].Rows[0]["LocCode"].ToString();
                    this.lblBomVer.Text = dsDetail.Tables[0].Rows[0]["BOMVersion"].ToString();
                    this.lblPlant.Text = dsDetail.Tables[0].Rows[0]["PlantName"].ToString();
                    this.lblLoc.Text = dsDetail.Tables[0].Rows[0]["LocName"].ToString();
                    this.lblMatCode.Text = dsDetail.Tables[0].Rows[0]["MaterialCode"].ToString();
                    this.lblBatch.Text = NP_Cls._genSelectBatch(dsDetail.Tables[0].Rows[0]["MaterialCode"].ToString());
                    this.txtQty.Text = (Convert.ToDouble(dsDetail.Tables[0].Rows[0]["PrdQuantity"].ToString()) - Convert.ToDouble(dsDetail.Tables[0].Rows[0]["GrPrdQuantity"].ToString())).ToString();
                    this.lblGrPrdQty.Text = dsDetail.Tables[0].Rows[0]["GrPrdQuantity"].ToString();
                    this.lblPrdQty.Text = dsDetail.Tables[0].Rows[0]["PrdQuantity"].ToString();
                    this.PrdQty = Convert.ToDouble(dsDetail.Tables[0].Rows[0]["PrdQuantity"].ToString());
                    this.txtQty.Select(); this.txtQty.SelectAll();
                }
                catch (SqlException ex)
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Detail : " + ex.Message); return;
                }
            }
            else
            {
                Clear();
                this.cbPrdOrder.Focus();
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
        private void frmGRProduction_FormClosing(object sender, FormClosingEventArgs e)
        {
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!NP.ReqField(this.cbPrdOrder, "Please select Production Order first !!")) { return; }
            if (!NP.ReqField(this.txtQty, "Please enter Qty !!")) { return; }
            //if (decimal.Parse(lblPrdQty.Text.Trim()) < decimal.Parse(lblGrPrdQty.Text.Trim()) + decimal.Parse(txtQty.Text.Trim()))
            //{
            //    MessageBox.Show("Quantity must less than " + (decimal.Parse(lblPrdQty.Text.Trim()) - decimal.Parse(lblGrPrdQty.Text.Trim())).ToString(), "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1); 
            //    txtQty.Focus();
            //    txtQty.Text = (decimal.Parse(lblPrdQty.Text.Trim()) - decimal.Parse(lblGrPrdQty.Text.Trim())).ToString();
            //    return;
            //}
            if (NP.MSGB("Do you to Save GR Production ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr;
                Tr = oConn.BeginTransaction(); 

                try
                {
                    SqlCommand cmdIns = new SqlCommand(); string strTmpBatch = NP_Cls._genBatch(this.lblMatCode.Text.Trim(), oConn, Tr);
                    NP_Cls.SqlInsert = "INSERT INTO t_StockMovement " +
                      "(DocNumber, TranDate, MovementType,RefNumber, Remark, UserCreate, DateCreate,PlantCode,PlantName,BOMVersion,LocCode,LocName) " +
"VALUES     (@GRPrdNumber,GETDATE(),@MovementType,@PrdONumber,@Remark,@UC,GETDATE(),@PlantCode,@PlantName,@BOMVersion,@LocCode,@LocName)";
                    cmdIns.Parameters.Add("@GRPrdNumber", SqlDbType.NVarChar, 12).Value = this.txtDocNo.Text.Trim();
                    cmdIns.Parameters.Add("@PrdONumber", SqlDbType.NVarChar, 12).Value = this.cbPrdOrder.Text.Trim();
                    cmdIns.Parameters.Add("@MovementType", SqlDbType.NVarChar, 3).Value = this.lblMoveType.Text.Trim();
                    cmdIns.Parameters.Add("@GRPrdQty", SqlDbType.Decimal).Value = Convert.ToDecimal(this.txtQty.Text.Trim());
                    cmdIns.Parameters.Add("@BatchNumber", SqlDbType.NVarChar, 10).Value = strTmpBatch;
                    cmdIns.Parameters.Add("@Remark", SqlDbType.NVarChar, 255).Value = this.txtRemark.Text.Trim();
                    cmdIns.Parameters.Add("@UC", SqlDbType.NVarChar, 50).Value = NP_Cls.strUsr;
                    cmdIns.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 4).Value = this.lblPlantCode.Text.Trim();
                    cmdIns.Parameters.Add("@PlantName", SqlDbType.NVarChar, 20).Value = this.lblPlant.Text.Trim();
                    cmdIns.Parameters.Add("@LocCode", SqlDbType.NVarChar, 2).Value = this.lblLocCode.Text.Trim();
                    cmdIns.Parameters.Add("@LocName", SqlDbType.NVarChar, 20).Value = this.lblLoc.Text.Trim();
                    cmdIns.Parameters.Add("@BOMVersion", SqlDbType.Int).Value = Convert.ToInt32(this.lblBomVer.Text.Trim());
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                    cmdIns.ExecuteNonQuery();

                    NP_Cls.SqlInsert = "INSERT INTO t_StockMovementDetail " +
                                "(AutoID, DocNumber, RefNumber, MaterialCode, MaterialName, Quantity, BatchNumber, CurrentUser, LogDate,PlantCode,PlantName,LocCode,LocName,UnitCode,UnitName) " +
            "VALUES     (1, @GRPrdNumber,@PrdONumber,@MaterialCode, @MaterialName,@GRPrdQty,@BatchNumber, @UC, GETDATE(),@PlantCode,@PlantName,@LocCode,@LocName,@UnitCode,@UnitName)";
                    cmdIns.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15).Value = this.lblMatCode.Text.Trim();
                    cmdIns.Parameters.Add("@MaterialName", SqlDbType.NVarChar, 60).Value = this.lblMaterialName.Text.Trim();
                    cmdIns.Parameters.Add("@UnitCode", SqlDbType.NVarChar, 3).Value = this.lblUnitCode.Text.Trim();
                    cmdIns.Parameters.Add("@UnitName", SqlDbType.NVarChar, 20).Value = this.lblUnitName.Text.Trim();
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                    cmdIns.ExecuteNonQuery();

                    NP_Cls.SqlInsert = "INSERT INTO [dbo].[t_GRPrd] ([GRPrdNumber]  ,[PrdONumber]  ,[GRPrdDate]  ,[MovementType]  ,[GRPrdQty]  ,[BatchNumber]  ,[Remark]  ,[UserCreate]  ,[DateCreate]  )       VALUES  (@GRPrdNumber  ,@PrdONumber  ,GETDATE()  ,@MovementType  ,@GRPrdQty  ,@BatchNumber  ,@Remark  ,@UC  ,GetDate())";
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                    cmdIns.ExecuteNonQuery();

                    //TODO Save in Stock Overview // 16.11.10
                    string strTmp = "INSERT INTO t_StockOverview (MaterialCode, BatchNumber, UR, QI, Block, UserCreate, DateCreate, Cost,PlantCode,LocCode,OrigQty,UnitCode) VALUES (@MaterialCode,@BatchNumber,@UR,@QI,@Block,@UC, GETDATE(), @Cost,@PlantCode,@LocCode,@OrigQty,@UnitCode)";

                    //cmdIns.Parameters["@BatchNumber"].Value = strTmpBatch;
                    cmdIns.Parameters.Add("@UR", SqlDbType.Decimal).Value = 0;
                    cmdIns.Parameters.Add("@QI", SqlDbType.Decimal).Value = Convert.ToDecimal(this.txtQty.Text.Trim());
                    cmdIns.Parameters.Add("@Block", SqlDbType.Decimal).Value = 0;
                    cmdIns.Parameters.Add("@Cost", SqlDbType.Decimal).Value = getCost(oConn, Tr, this.lblMatCode.Text.Trim());
                    cmdIns.Parameters.Add("@OrigQty", SqlDbType.Decimal).Value = Convert.ToDecimal(this.txtQty.Text.Trim());
                    cmdIns.Connection = oConn; cmdIns.CommandText = strTmp; cmdIns.Transaction = Tr;
                    cmdIns.ExecuteNonQuery();



                    strTmp = "UPDATE t_PrdOrder SET GrPrdQuantity = Isnull(GrPrdQuantity,0) + @QI WHERE (PrdONumber = @PrdONumber)";
                    cmdIns.Connection = oConn; cmdIns.CommandText = strTmp; cmdIns.Transaction = Tr;
                    cmdIns.ExecuteNonQuery();

                    if (decimal.Parse(lblPrdQty.Text.Trim()) <= decimal.Parse(lblGrPrdQty.Text.Trim()) + decimal.Parse(txtQty.Text.Trim()))
                    {
                        strTmp = "UPDATE t_MRPTranOrder SET IsCompleted = 1 WHERE (MaterialHeader = @MaterialCode) AND (TranOrder = @PrdONumber)";
                        cmdIns.Connection = oConn; cmdIns.CommandText = strTmp; cmdIns.Transaction = Tr;
                        cmdIns.ExecuteNonQuery();

                        strTmp = "UPDATE t_PrdOrder SET ISGRPrd = 1 WHERE (PrdONumber = @PrdONumber)";
                        cmdIns.Connection = oConn; cmdIns.CommandText = strTmp; cmdIns.Transaction = Tr;
                        cmdIns.ExecuteNonQuery();
                    }

                    Tr.Commit(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Save GR Production Completed !!");
                    Clear();

                    this.txtDocNo.Text = GetNumber();
                    BindMat();
                    this.cbPrdOrder.Text = string.Empty; this.cbPrdOrder.Select();
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

        private void BindMat()
        {
            this.lblLastGP.Text = "-";
            NP_Cls.SqlSelect = "SELECT DISTINCT MaterialName, PrdONumber FROM t_PrdOrder WHERE (IsGRPrd <> 1) AND (isnull(GrPrdQuantity,0) < PrdQuantity) AND OrderStatus Is Null";
            NP.BindCB(this.cbPrdOrder, NP_Cls.SqlSelect, "MaterialName", "PrdONumber", "((( Select Prd Order )))");
        }

        private decimal getCost(SqlConnection oConn, SqlTransaction Tr, string strMatCode)
        {
            try
            {
                return decimal.Parse(NP.GetDataWithTran("SELECT ISNULL(StandardCost,0) AS sCost FROM m_Material WHERE (MaterialCode = '" + strMatCode + "') AND (FileStatus = 1)", Tr, oConn).Tables[0].Rows[0][0].ToString());
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
        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnAdd_Click(sender, e);
            }
        }

        private void btnPicking_Click(object sender, EventArgs e)
        {

        }



    }
}
