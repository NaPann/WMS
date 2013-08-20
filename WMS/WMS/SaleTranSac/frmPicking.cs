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
    public partial class frmPicking : Form
    {
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection();
        public frmPicking()
        {
            InitializeComponent();
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
        private void frmPicking_Load(object sender, EventArgs e)
        {
            NP_Cls.SqlSelect = "SELECT     0 AS ItemNo, t_PrdOrderDetail.ComponentCode AS MaterialCode, t_PrdOrderDetail.ComponentName AS MaterialName,  t_PrdOrderDetail.PrdOQuantity AS Qty, SUM((ISNULL(t_StockOverview.UR, 0) + ISNULL(t_StockOverview.QI,0)) * isnull(t_VendorInfoRecord.QtyConversion,1)) AS StockQty, SUM(0.000) AS Diff, t_StockOverview.BatchNumber, t_PrdOrderDetail.PrdOQuantity AS CurQty,  t_PrdOrderDetail.UnitCode, t_PrdOrderDetail.UnitName, t_PrdOrderDetail.PlantCode, t_PrdOrderDetail.PlantName, t_PrdOrderDetail.LocCode, t_PrdOrderDetail.LocName FROM   t_PrdOrderDetail LEFT OUTER JOIN  t_StockOverview ON t_PrdOrderDetail.ComponentCode = t_StockOverview.MaterialCode LEFT OUTER JOIN t_VendorInfoRecord ON t_VendorInfoRecord.MaterialCode = t_PrdOrderDetail.ComponentCode  WHERE     (t_PrdOrderDetail.PrdONumber = N'" + this.txtProdOrder.Text.Trim() + "')  GROUP BY t_PrdOrderDetail.ComponentCode, t_PrdOrderDetail.ComponentName, t_PrdOrderDetail.PrdOQuantity,t_StockOverview.BatchNumber,  t_PrdOrderDetail.UnitCode, t_PrdOrderDetail.UnitName, t_PrdOrderDetail.PlantCode, t_PrdOrderDetail.PlantName, t_PrdOrderDetail.LocCode,                   t_PrdOrderDetail.LocName ORDER BY MaterialCode";
            DataSet ds = new DataSet(); ds = NP.GetClientDataSet(NP_Cls.SqlSelect);
            Double DiffBefore = 0;
            bool IsManyBatch = false;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["ItemNo"] = i + 1;
                
                if (i != ds.Tables[0].Rows.Count - 1)
                {
                    if (ds.Tables[0].Rows[i]["MaterialCode"].ToString().Trim() == ds.Tables[0].Rows[i + 1]["MaterialCode"].ToString().Trim())
                    {
                        if (IsManyBatch && DiffBefore == 0)
                        {
                            ds.Tables[0].Rows[i]["Qty"] = 0;
                            ds.Tables[0].Rows[i]["Diff"] = Convert.ToDouble(ds.Tables[0].Rows[i]["StockQty"]);
                        }
                        else if (Convert.ToDouble(ds.Tables[0].Rows[i]["StockQty"]) < Convert.ToDouble(ds.Tables[0].Rows[i]["Qty"]))
                        {
                            DiffBefore = (Convert.ToDouble(ds.Tables[0].Rows[i]["Qty"]) - Convert.ToDouble(ds.Tables[0].Rows[i]["StockQty"]));
                            ds.Tables[0].Rows[i]["Diff"] = 0;
                            ds.Tables[0].Rows[i]["Qty"] = ds.Tables[0].Rows[i]["StockQty"];
                        }
                        else
                        {
                            ds.Tables[0].Rows[i]["Diff"] = (Convert.ToDouble(ds.Tables[0].Rows[i]["StockQty"]) - Convert.ToDouble(ds.Tables[0].Rows[i]["Qty"]));
                            DiffBefore = 0;
                        }
                        IsManyBatch = true;
                    }
                    else
                    {
                        if (DiffBefore > 0)
                        {
                            ds.Tables[0].Rows[i]["Diff"] = Convert.ToDouble(ds.Tables[0].Rows[i]["StockQty"]) - DiffBefore;
                        }
                        else if (IsManyBatch)
                        {
                            ds.Tables[0].Rows[i]["Qty"] = 0;
                            ds.Tables[0].Rows[i]["Diff"] = Convert.ToDouble(ds.Tables[0].Rows[i]["StockQty"]);
                        }
                        else
                        {
                            ds.Tables[0].Rows[i]["Diff"] = Convert.ToDouble(ds.Tables[0].Rows[i]["StockQty"]) - Convert.ToDouble(ds.Tables[0].Rows[i]["Qty"]);
                        }
                        IsManyBatch = false;
                        DiffBefore = 0;
                    }
                }
                else
                {
                    ds.Tables[0].Rows[i]["Diff"] = Convert.ToDouble(ds.Tables[0].Rows[i]["StockQty"]) - Convert.ToDouble(ds.Tables[0].Rows[i]["Qty"]);
                }
            }
            DataRow[] rows = ds.Tables[0].Select("Qty <= 0");
            foreach (DataRow row in rows)
            {
                ds.Tables[0].Rows.Remove(row);
            }
            this.dgvView.DataSource = ds.Tables[0]; ; this.dgvView.ClearSelection();
        }
        private void dgvView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((sender as DataGridView).Columns[e.ColumnIndex].Name == "clnDiff")
            {
                if (e.Value != null)
                {

                    if (Convert.ToDouble((sender as DataGridView).Rows[e.RowIndex].Cells["clnDiff"].Value) >= 0)
                    {
                        e.CellStyle.BackColor = Color.PaleGreen;
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.PaleVioletRed;
                    }

                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //for (byte ii = 0; ii < this.dgvView.RowCount; ii++)
            //{
            //    if (Convert.ToDouble(this.dgvView["clnDiff", ii].Value) < 0)
            //    {
            //        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Save with warning !!"); return;
            //    }
            //}

            if (NP.MSGB("Do you to Save Picking ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr;
                Tr = oConn.BeginTransaction();

                try
                {
                    SqlCommand cmdIns = new SqlCommand();
                    // Master
                    NP_Cls.SqlInsert = "INSERT INTO t_StockMovement " +
                    "( DocNumber, TranDate, RefNumber, PlantCode, PlantName,  LocCode, LocName, UserCreate, DateCreate,BomVersion) " +
"VALUES     (@GINumber, GETDATE(),@PrdONumber,@PlantCode,@PlantName,@LocCode,@LocName,@UD,GETDATE(),@BomVersion)";
                    cmdIns.Parameters.Add("@GINumber", SqlDbType.NVarChar, 12).Value = this.txtProdOrder.Text.Trim();
                    cmdIns.Parameters.Add("@BomVersion", SqlDbType.Int).Value = Convert.ToInt32(this.lblBOMVer.Text.Trim());
                    cmdIns.Parameters.Add("@PrdONumber", SqlDbType.NVarChar, 50).Value = this.txtProdOrder.Text.Trim();
                    cmdIns.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 50).Value = this.lblPlantCode.Text.Trim();
                    cmdIns.Parameters.Add("@PlantName", SqlDbType.NVarChar, 50).Value = this.lblPlant.Text.Trim();
                    cmdIns.Parameters.Add("@LocCode", SqlDbType.NVarChar, 50).Value = this.lblLocCode.Text.Trim();
                    cmdIns.Parameters.Add("@LocName", SqlDbType.NVarChar, 50).Value = this.lblLoc.Text.Trim();
                    cmdIns.Parameters.Add("@UD", SqlDbType.NVarChar, 50).Value = NP_Cls.strUsr;
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                    cmdIns.ExecuteNonQuery();

                    // Detail
                    NP_Cls.SqlInsert = "INSERT INTO t_StockMovementDetail " +
                      "(AutoID,DocNumber, MaterialCode, MaterialName, Quantity, UnitCode, UnitName, PlantCode, PlantName, LocCode, LocName, CurrentUser, RefNumber, BatchNumber) " +
"VALUES     (@AutoID, @GINumber,@MaterialCode,@MaterialName,@GIQuantity,@UnitCode,@UnitName,@PlantCode,@PlantName,@LocCode,@LocName,@CurrentUser,@PrdONumber, @BatchNumber)";
                    cmdIns.Parameters.Add("@AutoID", SqlDbType.Int);
                    cmdIns.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15);
                    cmdIns.Parameters.Add("@MaterialName", SqlDbType.NVarChar, 60);
                    cmdIns.Parameters.Add("@GIQuantity", SqlDbType.Decimal);
                    cmdIns.Parameters.Add("@UnitCode", SqlDbType.NVarChar, 3);
                    cmdIns.Parameters.Add("@UnitName", SqlDbType.NVarChar, 20);
                    //cmdIns.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 4);
                    //cmdIns.Parameters.Add("@PlantName", SqlDbType.NVarChar, 20);
                    //cmdIns.Parameters.Add("@LocCode", SqlDbType.NVarChar, 2);
                    //cmdIns.Parameters.Add("@LocName", SqlDbType.NVarChar, 20);
                    cmdIns.Parameters.Add("@CurrentUser", SqlDbType.NVarChar, 50);
                    cmdIns.Parameters.Add("@BatchNumber", SqlDbType.NVarChar, 10);
                    //cmdIns.Parameters.Add("@PrdONumber", SqlDbType.NVarChar, 12);

                    //Fixed Issue 27/04/2013
                    //double clnQuantityValue = 0.000;
                    for (byte ins = 0; ins < this.dgvView.RowCount; ins++)
                    {
                        //For Stock Overview
                        AddDetail(oConn, Tr, cmdIns, (this.dgvView["clnQuantity", ins].Value == DBNull.Value ? 0.000 : Convert.ToDouble(this.dgvView["clnQuantity", ins].Value)), this.dgvView["clnMaterialCode", ins].Value.ToString(), ins);
                        //if (this.dgvView["clnQuantity", ins].Value != DBNull.Value)
                        //    clnQuantityValue = Convert.ToDouble(this.dgvView["clnQuantity", ins].Value);
                    }

                    cmdIns.Parameters.Clear();

                    //ToDo 0510
                    NP_Cls.sqlUpdate = "UPDATE t_PrdOrder SET IsPicking = 1 WHERE (PrdONumber = '" + this.txtProdOrder.Text.Trim() + "')";
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.sqlUpdate; cmdIns.Transaction = Tr;
                    cmdIns.ExecuteNonQuery();

                    //ToDo 0710
                    NP_Cls.SqlSelect = "SELECT     PrdONumber, PrdOQuantity - GIQty AS Diff, ComponentCode FROM  t_PrdOrderDetail WHERE  (PrdONumber = N'" + this.txtProdOrder.Text.Trim() + "')";
                    DataSet dsFIS = new DataSet(); dsFIS = NP.GetDataWithTran(NP_Cls.SqlSelect, Tr, oConn);
                    for (int fis = 0; fis < dsFIS.Tables[0].Rows.Count; fis++)
                    {
                        if (Convert.ToDouble(dsFIS.Tables[0].Rows[fis][1]) == 0)
                        {
                            NP_Cls.sqlUpdate = "UPDATE t_PrdOrderDetail SET FIS = 1 WHERE (ComponentCode = '" + dsFIS.Tables[0].Rows[fis][2].ToString() + "')";
                            cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.sqlUpdate; cmdIns.Transaction = Tr;
                            cmdIns.ExecuteNonQuery();
                        }
                    }

                    //TODO 28082012 Save Picking tbl
                    cmdIns.Parameters.Clear();

                    NP_Cls.SqlInsert = "INSERT INTO t_Picking (PrdONumber, PickingDate, MaterialCode, MaterialName, PrdQuantity, PlantCode, PlantName, BOMVersion, LocCode, LocName, UserCreate, DateCreate) VALUES (@PrdONumber, GETDATE(), @MaterialCode, @MaterialName, @PrdQuantity, @PlantCode, @PlantName, @BOMVersion, @LocCode, @LocName, @UC, GETDATE())";
                    cmdIns.Parameters.Add("@PrdONumber", SqlDbType.NVarChar, 50).Value = this.txtProdOrder.Text.Trim();
                    cmdIns.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15).Value = this.lblMatCode.Text.Trim();
                    cmdIns.Parameters.Add("@MaterialName", SqlDbType.NVarChar, 60).Value = this.lblMatName.Text.Trim();
                    cmdIns.Parameters.Add("@PrdQuantity", SqlDbType.Decimal).Value = Decimal.Parse(this.lblPrdQty.Text.Trim());
                    cmdIns.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 10).Value = this.lblPlantCode.Text.Trim();
                    cmdIns.Parameters.Add("@PlantName", SqlDbType.NVarChar, 50).Value = this.lblPlant.Text.Trim();
                    cmdIns.Parameters.Add("@LocCode", SqlDbType.NVarChar, 2).Value = this.lblLocCode.Text.Trim();
                    cmdIns.Parameters.Add("@LocName", SqlDbType.NVarChar, 50).Value = this.lblLoc.Text.Trim();
                    cmdIns.Parameters.Add("@BOMVersion", SqlDbType.NVarChar, 10).Value = this.lblBOMVer.Text.Trim();
                    cmdIns.Parameters.Add("@UC", SqlDbType.NVarChar, 50).Value = NP_Cls.strUsr;
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                    cmdIns.ExecuteNonQuery();

                    cmdIns.Parameters.Clear();
                    cmdIns.Parameters.Add("@PickingID", SqlDbType.Int);
                    cmdIns.Parameters.Add("@PickingDetailID", SqlDbType.Int);
                    cmdIns.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15);
                    cmdIns.Parameters.Add("@MaterialName", SqlDbType.NVarChar, 60);
                    cmdIns.Parameters.Add("@PickingQuantity", SqlDbType.Decimal);
                    cmdIns.Parameters.Add("@ShortQuantity", SqlDbType.Decimal);
                    cmdIns.Parameters.Add("@UnitCode", SqlDbType.NVarChar, 10);
                    cmdIns.Parameters.Add("@UnitName", SqlDbType.NVarChar, 50);
                    cmdIns.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 10);
                    cmdIns.Parameters.Add("@PlantName", SqlDbType.NVarChar, 50);
                    cmdIns.Parameters.Add("@LocCode", SqlDbType.NVarChar, 2);
                    cmdIns.Parameters.Add("@LocName", SqlDbType.NVarChar, 50);
                    cmdIns.Parameters.Add("@BatchNumber", SqlDbType.NVarChar, 50);
                    cmdIns.Parameters.Add("@UC", SqlDbType.NVarChar, 50);

                    //Fixed Issue 27/04/2013
                    decimal QuantityValue = 0.00M;
                    //Get PickingID 
                    int iPickingID = int.Parse(NP.GetDataWithTran("SELECT ISNULL(PickingID,0) AS PickingID FROM t_Picking ORDER BY PickingID DESC", Tr, oConn).Tables[0].Rows[0][0].ToString());
                    for (byte ins = 0; ins < this.dgvView.RowCount; ins++)
                    {
                        NP_Cls.SqlInsert = "INSERT INTO t_PickingDetail (PickingID, PickingDetailID, ComponentCode, ComponentName, PickingQuantity, ShortQuantity, UnitCode, UnitName, PlantCode, PlantName, LocCode, LocName, BatchNumber, CurrentUser) VALUES (@PickingID,  @PickingDetailID, @MaterialCode, @MaterialName, @PickingQuantity, @ShortQuantity, @UnitCode, @UnitName, @PlantCode, @PlantName, @LocCode, @LocName, @BatchNumber, @UC)";
                        cmdIns.Parameters["@PickingID"].Value = iPickingID;
                        cmdIns.Parameters["@PickingDetailID"].Value = ins + 1;
                        cmdIns.Parameters["@MaterialCode"].Value = this.dgvView["clnMaterialCode", ins].Value.ToString();
                        cmdIns.Parameters["@MaterialName"].Value = this.dgvView["clnMaterialName", ins].Value.ToString();
                        cmdIns.Parameters["@PickingQuantity"].Value = (string.IsNullOrEmpty(this.dgvView["clnQuantity", ins].Value.ToString()) ? QuantityValue.ToString() : this.dgvView["clnQuantity", ins].Value.ToString());
                        if (this.dgvView["clnQuantity", ins].Value != DBNull.Value)
                            QuantityValue = Convert.ToDecimal(this.dgvView["clnQuantity", ins].Value);
                        cmdIns.Parameters["@ShortQuantity"].Value = decimal.Parse(this.dgvView["clnCurQty", ins].Value.ToString()) - decimal.Parse((this.dgvView["clnStockQty", ins].Value.ToString() == string.Empty ? "0" : this.dgvView["clnStockQty", ins].Value.ToString()));
                        cmdIns.Parameters["@UnitCode"].Value = this.dgvView["clnUnitCode", ins].Value.ToString();
                        cmdIns.Parameters["@UnitName"].Value = this.dgvView["clnUnitName", ins].Value.ToString();
                        cmdIns.Parameters["@PlantCode"].Value = this.dgvView["clnPlantCode", ins].Value.ToString();
                        cmdIns.Parameters["@PlantName"].Value = this.dgvView["clnPlantName", ins].Value.ToString();
                        cmdIns.Parameters["@LocCode"].Value = this.dgvView["clnLocCode", ins].Value.ToString();
                        cmdIns.Parameters["@LocName"].Value = this.dgvView["clnLocName", ins].Value.ToString();
                        cmdIns.Parameters["@BatchNumber"].Value = this.dgvView["clnBatch", ins].Value.ToString();
                        cmdIns.Parameters["@UC"].Value = NP_Cls.strUsr;

                        cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                        cmdIns.ExecuteNonQuery();
                    }
                    Tr.Commit(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Save Picking Completed !!");
                    btnAdd.Visible = false;
                    //TODO Picking 2809
                    //Report
                    NP_Cls.SqlSelect = "SELECT  0 AS ItemNo,   t_Picking.PrdONumber, t_Picking.PickingDate, t_Picking.MaterialCode, t_Picking.MaterialName, t_Picking.PrdQuantity, t_Picking.PlantCode, t_Picking.PlantName,                        t_Picking.BOMVersion, t_Picking.LocCode, t_Picking.LocName, t_Picking.PickingID, t_PickingDetail.PickingDetailID, t_PickingDetail.ComponentCode,                        t_PickingDetail.ComponentName, t_PickingDetail.PickingQuantity, t_PickingDetail.ShortQuantity, t_PickingDetail.UnitCode, t_PickingDetail.UnitName,                        t_PickingDetail.PlantCode AS cPlantCode, t_PickingDetail.PlantName AS cPlantName, t_PickingDetail.LocCode AS cLocCode, t_PickingDetail.LocName AS cLocName,                        t_PickingDetail.BatchNumber,CASE WHEN t_PickingDetail.ShortQuantity = 0 THEN '' WHEN t_PickingDetail.ShortQuantity > 0 THEN '***' END AS SH FROM         t_Picking INNER JOIN                       t_PickingDetail ON t_Picking.PickingID = t_PickingDetail.PickingID WHERE  (t_Picking.PrdONumber = N'" + this.txtProdOrder.Text.Trim() + "')";
                    DataSet ds = new DataSet();
                    ds = NP.GetClientDataSet(NP_Cls.SqlSelect);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            ds.Tables[0].Rows[i][0] = i + 1;
                        }
                        frmRptViewer rptV = new frmRptViewer();
                        rptV.dsReportA = ds.Copy();

                        NP_Cls.SqlSelect = "SELECT t_Picking.PrdONumber, t_Picking.PickingDate, t_Picking.MaterialCode, t_Picking.MaterialName, t_Picking.PrdQuantity,t_RoutingDetail.WorkCenterCode FROM   t_Picking INNER JOIN  t_RoutingDetail ON t_Picking.MaterialCode = t_RoutingDetail.MaterialCode  WHERE  (t_Picking.PrdONumber = N'" + this.txtProdOrder.Text.Trim() + "')";
                        ds = new DataSet();
                        ds = NP.GetClientDataSet(NP_Cls.SqlSelect);
                        rptV.dsReportB = ds.Copy();

                        rptV.ShowDialog();
                    }
                    else
                    {
                        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found !! Report !!"); return;
                    }
                    //this.Close();
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
        private void AddDetail(SqlConnection oConn, SqlTransaction Tr, SqlCommand cmdIns, double dQty, string strMatCode, int ii)
        {
            NP_Cls.SqlSelect = "SELECT     t_StockOverview.MaterialCode, t_StockOverview.BatchNumber, t_StockOverview.UR, ISNULL(t_StockOverview.Cost,0) AS Cost, m_Material.MaterialName FROM  t_StockOverview INNER JOIN m_Material ON t_StockOverview.MaterialCode = m_Material.MaterialCode WHERE ( t_StockOverview.MaterialCode = N'" + strMatCode + "') AND (UR > 0)  ORDER BY BatchNumber";
            DataSet dsTmp = new DataSet(); dsTmp = NP.GetDataWithTran(NP_Cls.SqlSelect, Tr, oConn);
            if (dsTmp.Tables[0].Rows.Count > 0)
            {
                //for (int i = 0; i < dsTmp.Tables[0].Rows.Count; i++)
                //{
                if ((dQty == Convert.ToDouble(dsTmp.Tables[0].Rows[0]["UR"])) || (dQty < Convert.ToDouble(dsTmp.Tables[0].Rows[0]["UR"])))
                {
                    cmdIns.Parameters["@AutoID"].Value = ii;
                    cmdIns.Parameters["@GINumber"].Value = this.txtProdOrder.Text.Trim();
                    cmdIns.Parameters["@MaterialCode"].Value = dsTmp.Tables[0].Rows[0]["MaterialCode"].ToString();
                    cmdIns.Parameters["@MaterialName"].Value = dsTmp.Tables[0].Rows[0]["MaterialName"].ToString();
                    cmdIns.Parameters["@GIQuantity"].Value = dQty; //Convert.ToDouble(dsTmp.Tables[0].Rows[0]["UR"].ToString());
                    cmdIns.Parameters["@UnitCode"].Value = string.Empty; //this.dgvView["clnUnitCode", ins].Value.ToString();
                    cmdIns.Parameters["@UnitName"].Value = string.Empty; //this.dgvView["clnUnitName", ins].Value.ToString();
                    cmdIns.Parameters["@CurrentUser"].Value = NP_Cls.strUsr;
                    cmdIns.Parameters["@PlantCode"].Value = this.lblPlantCode.Text.Trim(); //this.dgvView["clnPlantCode", ins].Value.ToString();
                    cmdIns.Parameters["@PlantName"].Value = this.lblPlant.Text.Trim(); //this.dgvView["clnPlantName", ins].Value.ToString();
                    cmdIns.Parameters["@LocCode"].Value = this.lblLocCode.Text.Trim(); //this.dgvView["clnLocCode", ins].Value.ToString();
                    cmdIns.Parameters["@LocName"].Value = this.lblLoc.Text.Trim(); //this.dgvView["clnLocName", ins].Value.ToString();
                    cmdIns.Parameters["@PrdONumber"].Value = this.txtProdOrder.Text.Trim();
                    cmdIns.Parameters["@BatchNumber"].Value = dsTmp.Tables[0].Rows[0]["BatchNumber"].ToString();

                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                    cmdIns.ExecuteNonQuery();

                    NP_Cls.sqlUpdate = "UPDATE t_StockOverview SET UR = UR - @GIQuantity WHERE (BatchNumber = @BatchNumber)";
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.sqlUpdate; cmdIns.Transaction = Tr;
                    cmdIns.ExecuteNonQuery();

                    NP_Cls.sqlUpdate = "UPDATE  t_PrdOrderDetail  SET GIQty = " + dQty + " WHERE (ComponentCode = '" + dsTmp.Tables[0].Rows[0]["MaterialCode"].ToString() + "')";
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.sqlUpdate; cmdIns.Transaction = Tr;
                    cmdIns.ExecuteNonQuery();

                    //TODO -- 24.07.2012 -- Add Material Cost
                    NP_Cls.SqlInsert = "INSERT INTO t_MaterialCost (ItemNo, PrdONumber, MaterialCode, MaterialName, PlantCode, PlantName, LocCode, LocName, Quantity, Amount, LogDate, LogUser) VALUES ('" + ii + "', @PrdONumber, @MaterialCode, @MaterialName, @PlantCode, @PlantName, @LocCode, @LocName, @GIQuantity, '" + Convert.ToDecimal(dsTmp.Tables[0].Rows[0]["Cost"].ToString()) + "', GETDATE(), @CurrentUser)";
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                    cmdIns.ExecuteNonQuery();
                }
                else if (dQty > Convert.ToDouble(dsTmp.Tables[0].Rows[0]["UR"]))
                {
                    cmdIns.Parameters["@AutoID"].Value = ii;
                    cmdIns.Parameters["@GINumber"].Value = this.txtProdOrder.Text.Trim();
                    cmdIns.Parameters["@MaterialCode"].Value = this.dgvView["clnMaterialCode", 0].Value.ToString();
                    cmdIns.Parameters["@MaterialName"].Value = this.dgvView["clnMaterialName", 0].Value.ToString();
                    cmdIns.Parameters["@GIQuantity"].Value = Convert.ToDouble(dsTmp.Tables[0].Rows[0]["UR"].ToString());
                    cmdIns.Parameters["@UnitCode"].Value = string.Empty; //this.dgvView["clnUnitCode", ins].Value.ToString();
                    cmdIns.Parameters["@UnitName"].Value = string.Empty; //this.dgvView["clnUnitName", ins].Value.ToString();
                    cmdIns.Parameters["@CurrentUser"].Value = NP_Cls.strUsr;
                    cmdIns.Parameters["@PlantCode"].Value = this.lblPlantCode.Text.Trim(); //this.dgvView["clnPlantCode", ins].Value.ToString();
                    cmdIns.Parameters["@PlantName"].Value = this.lblPlant.Text.Trim(); //this.dgvView["clnPlantName", ins].Value.ToString();
                    cmdIns.Parameters["@LocCode"].Value = this.lblLocCode.Text.Trim(); //this.dgvView["clnLocCode", ins].Value.ToString();
                    cmdIns.Parameters["@LocName"].Value = this.lblLoc.Text.Trim(); //this.dgvView["clnLocName", ins].Value.ToString();
                    cmdIns.Parameters["@PrdONumber"].Value = this.txtProdOrder.Text.Trim();
                    cmdIns.Parameters["@BatchNumber"].Value = dsTmp.Tables[0].Rows[0]["BatchNumber"].ToString();

                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                    cmdIns.ExecuteNonQuery();

                    NP_Cls.sqlUpdate = "UPDATE t_StockOverview SET UR = UR - @GIQuantity WHERE (BatchNumber = @BatchNumber)";
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.sqlUpdate; cmdIns.Transaction = Tr;
                    cmdIns.ExecuteNonQuery();

                    NP_Cls.sqlUpdate = "UPDATE  t_PrdOrderDetail  SET GIQty = GIQty + " + Convert.ToDouble(dsTmp.Tables[0].Rows[0]["UR"].ToString()) + " WHERE (ComponentCode = '" + dsTmp.Tables[0].Rows[0]["MaterialCode"].ToString() + "')";
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.sqlUpdate; cmdIns.Transaction = Tr;
                    cmdIns.ExecuteNonQuery();

                    //TODO -- 24.07.2012 -- Add Material Cost
                    NP_Cls.SqlInsert = "INSERT INTO t_MaterialCost (ItemNo, PrdONumber, MaterialCode, MaterialName, PlantCode, PlantName, LocCode, LocName, Quantity, Amount, LogDate, LogUser) VALUES ('" + ii + "', @PrdONumber, @MaterialCode, @MaterialName, @PlantCode, @PlantName, @LocCode, @LocName, @GIQuantity, '" + Convert.ToDecimal(dsTmp.Tables[0].Rows[0]["Cost"].ToString()) + "', GETDATE(), @CurrentUser)";
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                    cmdIns.ExecuteNonQuery();

                    AddDetail(oConn, Tr, cmdIns, dQty - Convert.ToDouble(dsTmp.Tables[0].Rows[0]["UR"]), strMatCode, ii);
                }
                else
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Miss Loop");
                }
            }
            //else
            //{

            //}
        }

        private void btnReport_Click(object sender, EventArgs e)
        {

        }

        private void dgvView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvView.CurrentCell.ColumnIndex == 3)
            {
                TextBox txtBox = e.Control as TextBox;
                txtBox.KeyPress += new KeyPressEventHandler(txtBox_KeyPress);
            }
        }
        void txtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            NP_Cls.myDecimal(sender, e);
        }

        private void dgvView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (decimal.Parse(this.dgvView.CurrentRow.Cells["clnCurQty"].Value.ToString()) < decimal.Parse(this.dgvView.CurrentRow.Cells["clnQuantity"].Value.ToString()))
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Cannot Picking Over Required !!");
                    this.dgvView.CancelEdit();
                    return;
                }
                this.dgvView.CurrentRow.Cells["clnDiff"].Value = decimal.Parse(this.dgvView.CurrentRow.Cells["clnStockQty"].Value.ToString()) - decimal.Parse(this.dgvView.CurrentRow.Cells["clnQuantity"].Value.ToString());
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.ErrorType, "Cell Edit : " + ex.Message); return;
            }
        }
    }
}
