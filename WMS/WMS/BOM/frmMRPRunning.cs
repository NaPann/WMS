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

namespace WMS.BOM
{
    public partial class frmMRPRunning : Form
    {
        public frmMRPRunning()
        {
            InitializeComponent();
        }

        public DataSet MyGridSet { get; set; }
        public DataSet MyTmpView { get; set; }
        public byte MyAtFirstRow { get; set; }
        private Hashtable hsTmp = new Hashtable(); byte intTmp = 0;
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection(); 
     
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
                    NP_Cls.SqlSelect = "SELECT     GRProcessingTime, DeliveryTime FROM m_Material WHERE (MaterialCode = N'" + strMCode + "')";
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
        
        private void btnMRP_Click(object sender, EventArgs e)
        {
            if (!NP.ReqField(txtMatCode, "Please enter Material Code:")) { return; }

            oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
            if (oConn.State == ConnectionState.Open) { oConn.Close(); }
            oConn.Open(); SqlTransaction Tr;
            Tr = oConn.BeginTransaction();
            SqlCommand cmdUp = new SqlCommand();
            try
            {
                string strErr = string.Empty;
                NP_Cls.SqlDel = "DELETE FROM t_MRPBOM WHERE (FGCode = @DelFGCode)";
                cmdUp.Parameters.Add("@DelFGCode", SqlDbType.NVarChar, 15).Value = this.txtMatCode.Text.Trim();
                cmdUp.Connection = oConn; cmdUp.CommandText = NP_Cls.SqlDel; cmdUp.Transaction = Tr;
                cmdUp.ExecuteNonQuery();

                //TODO New 28-08 MRP Running
                // Get Material from SONumber & Check that Material in BOM Process
                //NP_Cls.SqlSelect = "SELECT DISTINCT t_SODetail.MaterialCode, t_SODetail.SOQuantity, t_BOM.BOMCode, t_SODetail.UnitCode, t_SODetail.DeliveryDate  FROM t_SODetail INNER JOIN t_SO ON t_SODetail.SONumber = t_SO.SONumber INNER JOIN  t_BOM ON t_SODetail.MaterialCod e = t_BOM.MaterialCode WHERE  (t_BOM.FileStatus = N'1') AND (t_BOM.Approve = 1) AND  (t_SO.SOApprove = 1) AND (t_SODetail.SONumber = N'" + this.txtSO.Text.Trim() + "')";
                NP_Cls.SqlSelect = "SELECT DISTINCT t_SODetail.SONumber, t_SODetail.MaterialCode, t_SODetail.SOQuantity, t_SODetail.UnitCode, t_SODetail.DeliveryDate FROM t_SODetail INNER JOIN t_SO ON t_SODetail.SONumber = t_SO.SONumber WHERE (t_SO.SOApprove = 1) AND (t_SODetail.MaterialCode = N'" + this.txtMatCode.Text.Trim() + "')";
                DataSet dsFBom = new DataSet(); dsFBom = NP.GetDataWithTran(NP_Cls.SqlSelect, Tr, oConn);
                if (dsFBom.Tables[0].Rows.Count > 0)
                {
                    cmdUp.Parameters.Add("@ItemSeq", SqlDbType.Int);
                    cmdUp.Parameters.Add("@FGCode", SqlDbType.NVarChar, 12);
                    cmdUp.Parameters.Add("@FGQty", SqlDbType.Decimal);
                    cmdUp.Parameters.Add("@FGUnitCode", SqlDbType.NVarChar, 3);
                    cmdUp.Parameters.Add("@HeadBomCode", SqlDbType.NVarChar, 12);
                    cmdUp.Parameters.Add("@ComponentCode", SqlDbType.NVarChar, 12);
                    cmdUp.Parameters.Add("@ProcurementType", SqlDbType.NVarChar, 1);
                    cmdUp.Parameters.Add("@ComponentQty", SqlDbType.Decimal);
                    cmdUp.Parameters.Add("@ComponentUnitCode", SqlDbType.NVarChar, 3);
                    cmdUp.Parameters.Add("@DeliveryDate", SqlDbType.DateTime);
                    cmdUp.Parameters.Add("@SONumber", SqlDbType.NVarChar, 12);

                    for (int i = 0; i < dsFBom.Tables[0].Rows.Count; i++)
                    {
                        //New 29-08 SONumber
                        cmdUp.Parameters["@SONumber"].Value = dsFBom.Tables[0].Rows[i]["SONumber"].ToString();
                        GenBOMNCate(dsFBom, i, dsFBom.Tables[0].Rows[i]["MaterialCode"].ToString(), cmdUp, oConn, Tr, Convert.ToDateTime(dsFBom.Tables[0].Rows[i]["DeliveryDate"]));
                    }
                    Tr.Commit();
                }
                else //TODO 19.11.10 Mat is PR
                { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found , please check !!"); this.txtMatCode.Select(); this.txtMatCode.SelectAll(); return; }
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Create MRP : " + ex.Message); return;
            }
            finally
            {
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
            }
            //End of create MRP Running from SO 

            //TODO MRP Tran Order 09.09
            if (oConn.State == ConnectionState.Open) { oConn.Close(); }
            oConn.Open();
            Tr = oConn.BeginTransaction();
            cmdUp = new SqlCommand();

            //NP_Cls.SqlDel = "DELETE FROM t_MRPTranOrder WHERE (MaterialCode = @DelMaterialCode)";
            //NP_Cls.SqlDel = "UPDATE t_MRPTranOrder SET   WHERE (MaterialCode = @DelMaterialCode)";
            //cmdUp.Parameters.Add("@DelMaterialCode", SqlDbType.NVarChar, 15).Value = this.txtMatCode.Text.Trim();
            //cmdUp.Connection = oConn; cmdUp.CommandText = NP_Cls.SqlDel; cmdUp.Transaction = Tr;
            //cmdUp.ExecuteNonQuery();

            try
            {
                //TODO New 28-08 MRP Running
                // First Step Check at PR,PO,GR
                NP_Cls.SqlSelect = "SELECT   t_BOMDetail.MaterialCode AS CompCode FROM t_BOM INNER JOIN t_BOMDetail ON t_BOM.BOMCode = t_BOMDetail.BOMCode WHERE  (t_BOM.MaterialCode = N'" + this.txtMatCode.Text.Trim() + "')";
                DataSet dsComp = new DataSet(); dsComp = NP.GetDataWithTran(NP_Cls.SqlSelect, Tr, oConn);
                for (int cp = 0; cp < dsComp.Tables[0].Rows.Count; cp++)
                {          
                    //NP_Cls.SqlSelect = "SELECT t_PRDetail.PRNumber, t_PRDetail.PRQuantity, ISNULL(t_PODetail.POQuantity, 0) AS POQuantity, ISNULL(t_PODetail.GRQuantity, 0) AS GRQuantity, t_PRDetail.MaterialCode, t_PRDetail.MaterialName FROM  t_PO RIGHT OUTER JOIN t_PODetail ON t_PO.PONumber = t_PODetail.PONumber RIGHT OUTER JOIN t_PRDetail ON t_PODetail.PRNumber = t_PRDetail.PRNumber AND t_PODetail.MaterialCode = t_PRDetail.MaterialCode WHERE (t_PRDetail.MaterialCode = N'" + dsComp.Tables[0].Rows[cp]["CompCode"].ToString() + "') AND (t_PO.POApprove = 0 OR t_PO.POApprove IS NULL)";
                    NP_Cls.SqlSelect = "SELECT     CASE WHEN (t_PODetail.PONumber IS NULL) AND ((t_PO.POApprove = 0) OR (t_PO.POApprove IS NULL)) THEN t_PRDetail.PRNumber ELSE t_PODetail.PONumber END AS PRNumber, t_PRDetail.PRQuantity, ISNULL(t_PODetail.POQuantity, 0) AS POQuantity, ISNULL(t_PODetail.GRQuantity, 0) AS GRQuantity, t_PRDetail.MaterialCode, t_PRDetail.MaterialName FROM t_PO RIGHT OUTER JOIN                       t_PODetail ON t_PO.PONumber = t_PODetail.PONumber RIGHT OUTER JOIN  t_PRDetail ON t_PODetail.PRNumber = t_PRDetail.PRNumber AND t_PODetail.MaterialCode = t_PRDetail.MaterialCode WHERE (t_PRDetail.MaterialCode = N'" + dsComp.Tables[0].Rows[cp]["CompCode"].ToString() + "')";
                    DataSet dsFBom = new DataSet(); dsFBom = NP.GetDataWithTran(NP_Cls.SqlSelect, Tr, oConn);
                    if (dsFBom.Tables[0].Rows.Count > 0)
                    {
                        NP_Cls.SqlSelect = "SELECT ISNULL(SUM(ComponentQty),0) AS SumQtyNeed FROM t_MRPBOM WHERE (ComponentCode = N'" + dsComp.Tables[0].Rows[cp]["CompCode"].ToString() + "')";
                        decimal dSumNeed = Convert.ToDecimal(NP.GetDataWithTran(NP_Cls.SqlSelect, Tr, oConn).Tables[0].Rows[0][0]);
                        try
                        {
                            if (cmdUp.Parameters["@MaterialCode"] == null)
                            {
                            }
                        }
                        catch
                        {
                            cmdUp.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15);
                            cmdUp.Parameters.Add("@SONumber", SqlDbType.NVarChar, 20);
                            cmdUp.Parameters.Add("@TranOrder", SqlDbType.NVarChar, 50);
                            cmdUp.Parameters.Add("@TranQty", SqlDbType.Decimal);
                            cmdUp.Parameters.Add("@MaterialHeader", SqlDbType.NVarChar, 20);
                        }
                        //New 12.09 Insert MRP Tran Order
                        NP_Cls.SqlInsert = "UPDATE t_MRPTranOrder " +
           "SET  TranOrder = @TranOrder, TranQty = @TranQty, MaterialHeader = @MaterialHeader, SumNeedQty = " + dSumNeed + " " +
    "WHERE (MaterialCode = @MaterialCode)";
                        cmdUp.Parameters["@MaterialCode"].Value = dsFBom.Tables[0].Rows[0]["MaterialCode"].ToString();
                        cmdUp.Parameters["@SONumber"].Value = string.Empty;
                        cmdUp.Parameters["@TranOrder"].Value = dsFBom.Tables[0].Rows[0]["PRNumber"].ToString();
                        if (Convert.ToDecimal(dsFBom.Tables[0].Rows[0]["POQuantity"].ToString()) == 0)
                        {
                            cmdUp.Parameters["@TranQty"].Value = Convert.ToDecimal(dsFBom.Tables[0].Rows[0]["PRQuantity"].ToString());
                        }
                        else if (Convert.ToDecimal(dsFBom.Tables[0].Rows[0]["GRQuantity"].ToString()) == 0)
                        {
                            cmdUp.Parameters["@TranQty"].Value = Convert.ToDecimal(dsFBom.Tables[0].Rows[0]["POQuantity"].ToString());
                        }
                        else
                        {
                            cmdUp.Parameters["@TranQty"].Value = (Convert.ToDecimal(dsFBom.Tables[0].Rows[0]["POQuantity"].ToString()) - Convert.ToDecimal(dsFBom.Tables[0].Rows[0]["GRQuantity"].ToString()));
                        }

                        cmdUp.Parameters["@MaterialHeader"].Value = dsFBom.Tables[0].Rows[0]["MaterialCode"].ToString();
                        cmdUp.Connection = oConn; cmdUp.CommandText = NP_Cls.SqlInsert; cmdUp.Transaction = Tr;
                        cmdUp.ExecuteNonQuery();
                    }
                    else
                    {
                        NP_Cls.SqlSelect = "SELECT ISNULL(SUM(ComponentQty),0) AS SumQtyNeed FROM t_MRPBOM WHERE (ComponentCode = N'" + dsComp.Tables[0].Rows[cp]["CompCode"].ToString() + "')";
                        decimal dSumNeed = Convert.ToDecimal(NP.GetDataWithTran(NP_Cls.SqlSelect, Tr, oConn).Tables[0].Rows[0][0]);
                        if (dSumNeed > 0)
                        {
                            //New 12.09 Insert MRP Tran Order
                            NP_Cls.SqlInsert = "UPDATE t_MRPTranOrder " +
               "SET  SumNeedQty = @TranQtyNP " +
        "WHERE (MaterialCode = @MaterialCodeNP)";
                            cmdUp.Parameters.Add("@MaterialCodeNP", SqlDbType.NVarChar, 15).Value = dsComp.Tables[0].Rows[cp]["CompCode"].ToString();
                            cmdUp.Parameters.Add("@TranQtyNP", SqlDbType.Decimal).Value = dSumNeed;
                            
                            cmdUp.Connection = oConn; cmdUp.CommandText = NP_Cls.SqlInsert; cmdUp.Transaction = Tr;
                            cmdUp.ExecuteNonQuery();
                            cmdUp.Parameters.RemoveAt("@MaterialCodeNP"); cmdUp.Parameters.RemoveAt("@TranQtyNP");
                        }
                        else
                        {

                            NP_Cls.SqlDel = "DELETE FROM t_MRPTranOrder WHERE (MaterialCode = @DelMaterialCode)";
                            try
                            {
                                if (cmdUp.Parameters["@DelMaterialCode"] == null)
                                {
                                    cmdUp.Parameters.Add("@DelMaterialCode", SqlDbType.NVarChar, 20);
                                }
                            }
                            catch
                            {
                                cmdUp.Parameters.Add("@DelMaterialCode", SqlDbType.NVarChar, 20);
                            }

                            cmdUp.Parameters["@DelMaterialCode"].Value = dsComp.Tables[0].Rows[cp]["CompCode"].ToString();
                            cmdUp.Connection = oConn; cmdUp.CommandText = NP_Cls.SqlDel; cmdUp.Transaction = Tr;
                            cmdUp.ExecuteNonQuery();
                        }
                    }
                    //Component in material
                    GenComp(cmdUp, Tr, dsComp.Tables[0].Rows[cp]["CompCode"].ToString());
                }

                //Head Mat
               // NP_Cls.SqlSelect = "SELECT t_PRDetail.PRNumber, t_PRDetail.PRQuantity, ISNULL(t_PODetail.POQuantity, 0) AS POQuantity, ISNULL(t_PODetail.GRQuantity, 0) AS GRQuantity, t_PRDetail.MaterialCode, t_PRDetail.MaterialName FROM  t_PO RIGHT OUTER JOIN t_PODetail ON t_PO.PONumber = t_PODetail.PONumber RIGHT OUTER JOIN t_PRDetail ON t_PODetail.PRNumber = t_PRDetail.PRNumber AND t_PODetail.MaterialCode = t_PRDetail.MaterialCode WHERE (t_PRDetail.MaterialCode = N'" + this.txtMatCode.Text.Trim() + "') AND (t_PO.POApprove = 0 OR t_PO.POApprove IS NULL)";
                NP_Cls.SqlSelect = "SELECT     CASE WHEN (t_PODetail.PONumber IS NULL) AND ((t_PO.POApprove = 0) OR (t_PO.POApprove IS NULL)) THEN t_PRDetail.PRNumber ELSE t_PODetail.PONumber END AS PRNumber, t_PRDetail.PRQuantity, ISNULL(t_PODetail.POQuantity, 0) AS POQuantity, ISNULL(t_PODetail.GRQuantity, 0) AS GRQuantity, t_PRDetail.MaterialCode, t_PRDetail.MaterialName FROM t_PO RIGHT OUTER JOIN                       t_PODetail ON t_PO.PONumber = t_PODetail.PONumber RIGHT OUTER JOIN  t_PRDetail ON t_PODetail.PRNumber = t_PRDetail.PRNumber AND t_PODetail.MaterialCode = t_PRDetail.MaterialCode WHERE (t_PRDetail.MaterialCode = N'" + this.txtMatCode.Text.Trim() + "')";
                DataSet dsFBom2 = new DataSet(); dsFBom2 = NP.GetDataWithTran(NP_Cls.SqlSelect, Tr, oConn);
                if (dsFBom2.Tables[0].Rows.Count > 0)
                {
                    if (cmdUp.Parameters.Count < 2)
                    {
                        cmdUp.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15);
                        cmdUp.Parameters.Add("@SONumber", SqlDbType.NVarChar, 20);
                        cmdUp.Parameters.Add("@TranOrder", SqlDbType.NVarChar, 50);
                        cmdUp.Parameters.Add("@TranQty", SqlDbType.Decimal);
                        cmdUp.Parameters.Add("@MaterialHeader", SqlDbType.NVarChar, 20);
                    }
                    else
                    {
                        cmdUp.Parameters["@MaterialCode"].Value = string.Empty;
                        cmdUp.Parameters["@SONumber"].Value = string.Empty;
                        cmdUp.Parameters["@TranOrder"].Value = string.Empty;
                        cmdUp.Parameters["@TranQty"].Value = 0;
                        cmdUp.Parameters["@MaterialHeader"].Value = string.Empty;
                    }
                    //NP_Cls.SqlSelect = "SELECT ISNULL(SUM(ComponentQty),0) AS SumQtyNeed FROM t_MRPBOM WHERE (ComponentCode = N'" + this.txtMatCode.Text.Trim() + "')";
                    //decimal dSumNeed = Convert.ToDecimal(NP.GetDataWithTran(NP_Cls.SqlSelect, Tr, oConn).Tables[0].Rows[0][0]);
                    //New 12.09 Insert MRP Tran Order
                    NP_Cls.SqlInsert = "UPDATE t_MRPTranOrder " +
       "SET  TranOrder = @TranOrder, TranQty = @TranQty, MaterialHeader = @MaterialHeader " +
"WHERE (MaterialCode = @MaterialCode)";
                    cmdUp.Parameters["@MaterialCode"].Value = dsFBom2.Tables[0].Rows[0]["MaterialCode"].ToString();
                    cmdUp.Parameters["@SONumber"].Value = string.Empty;
                    cmdUp.Parameters["@TranOrder"].Value = dsFBom2.Tables[0].Rows[0]["PRNumber"].ToString();
                    if (Convert.ToDecimal(dsFBom2.Tables[0].Rows[0]["POQuantity"].ToString()) == 0)
                    {
                        cmdUp.Parameters["@TranQty"].Value = Convert.ToDecimal(dsFBom2.Tables[0].Rows[0]["PRQuantity"].ToString());
                    }
                    else if (Convert.ToDecimal(dsFBom2.Tables[0].Rows[0]["GRQuantity"].ToString()) == 0)
                    {
                        cmdUp.Parameters["@TranQty"].Value = Convert.ToDecimal(dsFBom2.Tables[0].Rows[0]["POQuantity"].ToString());
                    }
                    else
                    {
                        cmdUp.Parameters["@TranQty"].Value = (Convert.ToDecimal(dsFBom2.Tables[0].Rows[0]["POQuantity"].ToString()) - Convert.ToDecimal(dsFBom2.Tables[0].Rows[0]["GRQuantity"].ToString()));
                    }
                    cmdUp.Parameters["@MaterialHeader"].Value = dsFBom2.Tables[0].Rows[0]["MaterialCode"].ToString();
                    cmdUp.Connection = oConn; cmdUp.CommandText = NP_Cls.SqlInsert; cmdUp.Transaction = Tr;
                    cmdUp.ExecuteNonQuery();
                }
                else
                {

                    NP_Cls.SqlDel = "DELETE FROM t_MRPTranOrder WHERE (MaterialCode = @DelMaterialCode)";
                    try
                    {
                        if (cmdUp.Parameters["@DelMaterialCode"] == null)
                        {
                            cmdUp.Parameters.Add("@DelMaterialCode", SqlDbType.NVarChar, 20);
                        }
                    }
                    catch
                    {
                        cmdUp.Parameters.Add("@DelMaterialCode", SqlDbType.NVarChar, 20);
                    }
                    cmdUp.Parameters["@DelMaterialCode"].Value = this.txtMatCode.Text.Trim();
                    cmdUp.Connection = oConn; cmdUp.CommandText = NP_Cls.SqlDel; cmdUp.Transaction = Tr;
                    cmdUp.ExecuteNonQuery();
                }
                Tr.Commit();
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Create MRP : " + ex.Message); return;
            }
            finally
            {
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
            }
            //End

            //************************************************************************************** START ..
            double dTmpStock = 0; double dTmpAva = 0;
            try
            {
                NP_Cls.SqlSelect = "SELECT  t_MRPBOM.HeadBomCode, m_Material.MaterialName FROM t_MRPBOM LEFT OUTER JOIN   m_Material ON t_MRPBOM.FGCode = m_Material.MaterialCode WHERE (t_MRPBOM.FGCode = N'" + this.txtMatCode.Text.Trim() + "') GROUP BY t_MRPBOM.HeadBomCode, m_Material.MaterialName, t_MRPBOM.AutoID ORDER BY t_MRPBOM.AutoID"; this.MyGridSet = new DataSet(); this.MyGridSet = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (this.MyGridSet.Tables[0].Rows.Count == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found this material code for MRP !!"); this.txtMatCode.Select(); this.txtMatCode.SelectAll(); return; }

                this.lblMatName.Text = this.MyGridSet.Tables[0].Rows[0]["MaterialName"].ToString();
                DataTable dtTmp = this.MyGridSet.Tables[0].DefaultView.ToTable(true, "HeadBomCode");
                this.MyGridSet.Tables.Clear(); this.MyGridSet.Tables.Add(dtTmp); 
                for (int i = 0; i < this.MyGridSet.Tables[0].Rows.Count; i++)
                {
                    //NP_Cls.SqlSelect = "SELECT     t_MRPBOM.AutoID, t_MRPBOM.FGQty, t_MRPBOM.HeadBomCode, t_MRPBOM.ComponentCode, t_MRPBOM.ProcurementType,  t_MRPBOM.ComponentQty, t_MRPBOM.RequireDate, t_MRPBOM.LogDate, t_MRPBOM.SONumber, m_Material_1.MaterialName, m_Material_1.InHouseProduction, m_Material_1.DeliveryTime, m_Material_1.GRProcessingTime, m_Material.MaterialName AS CompName,  t_MRPTranOrder_1.TranOrder AS TranHeadOrder, t_MRPTranOrder.TranOrder AS TranCompOrder, m_Material_1.ProcurementType AS OtherPType,   t_MRPTranOrder.IsCompleted, t_MRPTranOrder.IsComponent, ISNULL(t_MRPTranOrder.TranQty,0) AS TranQty, ISNULL(t_MRPTranOrder.SumNeedQty, 0) AS SumNeedQty FROM   t_MRPBOM LEFT OUTER JOIN  t_MRPTranOrder ON t_MRPBOM.ComponentCode = t_MRPTranOrder.MaterialCode AND t_MRPBOM.SONumber = t_MRPTranOrder.SONumber LEFT OUTER JOIN  t_MRPTranOrder AS t_MRPTranOrder_1 ON t_MRPBOM.SONumber = t_MRPTranOrder_1.SONumber AND  t_MRPBOM.HeadBomCode = t_MRPTranOrder_1.MaterialCode LEFT OUTER JOIN  m_Material ON t_MRPBOM.ComponentCode = m_Material.MaterialCode LEFT OUTER JOIN  m_Material AS m_Material_1 ON t_MRPBOM.HeadBomCode = m_Material_1.MaterialCode WHERE     (t_MRPBOM.HeadBomCode = N'" + this.MyGridSet.Tables[0].Rows[i]["HeadBomCode"].ToString() + "') ORDER BY t_MRPBOM.AutoID ";
                    NP_Cls.SqlSelect = "SELECT     t_MRPBOM.AutoID, t_MRPBOM.FGQty, t_MRPBOM.HeadBomCode, t_MRPBOM.ComponentCode, t_MRPBOM.ProcurementType, t_MRPBOM.ComponentQty,  t_MRPBOM.RequireDate, t_MRPBOM.LogDate, t_MRPBOM.SONumber, m_Material_1.MaterialName, m_Material_1.InHouseProduction, m_Material_1.DeliveryTime,  m_Material_1.GRProcessingTime, m_Material.MaterialName AS CompName, t_MRPTranOrder_1.TranOrder AS TranHeadOrder,  t_MRPTranOrder.TranOrder AS TranCompOrder, m_Material_1.ProcurementType AS OtherPType, t_MRPTranOrder.IsCompleted, t_MRPTranOrder.IsComponent, ISNULL(t_MRPTranOrder.TranQty, 0) AS TranQty, ISNULL(t_MRPTranOrder.SumNeedQty, 0) AS SumNeedQty FROM         t_MRPBOM LEFT OUTER JOIN  t_MRPTranOrder ON t_MRPBOM.ComponentCode = t_MRPTranOrder.MaterialCode LEFT OUTER JOIN   t_MRPTranOrder AS t_MRPTranOrder_1 ON t_MRPBOM.HeadBomCode = t_MRPTranOrder_1.MaterialCode LEFT OUTER JOIN  m_Material ON t_MRPBOM.ComponentCode = m_Material.MaterialCode LEFT OUTER JOIN     m_Material AS m_Material_1 ON t_MRPBOM.HeadBomCode = m_Material_1.MaterialCode WHERE  (t_MRPBOM.HeadBomCode = N'" + this.MyGridSet.Tables[0].Rows[i]["HeadBomCode"].ToString() + "') ORDER BY t_MRPBOM.AutoID";
                    DataSet dsTmp = new DataSet(); dsTmp = NP.GetClientDataSet(NP_Cls.SqlSelect); 
                    if (dsTmp.Tables[0].Rows.Count == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found , please check !!"); this.txtMatCode.Select(); this.txtMatCode.SelectAll(); return; }

                    if (i == 0)
                    {
                        if (this.MyTmpView.Tables.Count > 0) { this.MyTmpView.Tables.Clear(); this.tcMain.TabPages.Clear(); }
                        MyCreateSet(this.MyTmpView, dsTmp.Tables[0].Rows[0]["HeadBomCode"].ToString() + "_" + i.ToString()); // --------------------------- Create DataSet 
                        
                        // Create Control
                        // Tap Page
                        TabPage tp = new TabPage();
                        tp.Text = dsTmp.Tables[0].Rows[0]["HeadBomCode"].ToString(); tp.BackColor = Color.White;
                        tp.Name = "tp_M" + i.ToString();

                        // Panel
                        Panel pn = new Panel();
                        pn.BackColor = Color.LemonChiffon; pn.Name = "pn_M" + i.ToString();
                        pn.Dock = DockStyle.Top; pn.Size = new Size(884, 44); pn.Location = new Point(3, 3);
                        tp.Controls.Add(pn);

                        // Label : Show
                        Label lbSh = new Label();
                        lbSh.Text = "Description : "; lbSh.Name = "lbSh_M" + i.ToString(); lbSh.ForeColor = Color.Black;
                        lbSh.Location = new Point(5, 13); lbSh.Size = new Size(82, 16);

                        // Label : Variable
                        Label lbVar = new Label();
                        lbVar.Text = dsTmp.Tables[0].Rows[0]["MaterialName"].ToString(); lbVar.Name = "lbVar_M" + i.ToString();
                        lbVar.Location = new Point(90, 13); lbVar.Size = new Size(82, 16); lbVar.AutoSize = true; lbVar.ForeColor = Color.Navy;

                        // DataGridView
                        DataGridView dgv = new DataGridView(); dgv.Name = "dgv_M" + i.ToString();
                        dgv.BackgroundColor = Color.LightGray; dgv.Dock = DockStyle.Bottom; dgv.RowHeadersVisible = false; dgv.Location = new Point(3, 47);
                        dgv.Size = new Size(884, 450); dgv.ReadOnly = true; dgv.AllowUserToAddRows = false; dgv.AllowUserToDeleteRows = false;
                        dgv.AllowUserToResizeColumns = false; dgv.AllowUserToResizeRows = false;
                        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; dgv.MultiSelect = false;
                        dgv.CellDoubleClick += new DataGridViewCellEventHandler(dgv_CellDoubleClick);
                        dgv.CellFormatting += new DataGridViewCellFormattingEventHandler(dgv_CellFormatting);
                        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
                        DGV(dgv);

                        pn.Controls.Add(lbSh);
                        pn.Controls.Add(lbVar);
                        tp.Controls.Add(dgv);
                        //
                        this.tcMain.TabPages.Add(tp);
                                               
                        for (int x = 0; x < 3; x++)
                        {
                            DataRow drTmp; drTmp = this.MyTmpView.Tables[dsTmp.Tables[0].Rows[0]["HeadBomCode"].ToString() + "_" + i.ToString()].NewRow();
                            if (x == 0)
                            {
                                dTmpStock = GetStockByFG(dsTmp.Tables[0].Rows[0]["HeadBomCode"].ToString(), dsTmp.Tables[0].Rows[0]["SONumber"].ToString());
                                drTmp["TranDate"] = DateTime.Now; drTmp["MRPType"] = "Stock"; drTmp["MRPElement"] = string.Empty;
                                drTmp["RequireQty"] = DBNull.Value; drTmp["AvailableQty"] = dTmpStock; drTmp["SO"] = dsTmp.Tables[0].Rows[0]["SONumber"].ToString();
                            }
                            else if (x == 1)
                            {
                                dTmpAva = dTmpStock - Convert.ToDouble(dsTmp.Tables[0].Rows[0]["FGQty"]);

                                //TODO New 08-09 Update Stock Qty
                                if (dTmpStock != 0)
                                {
                                    dTmpStock = dTmpStock - (dTmpAva < 0 ? -dTmpAva : dTmpAva);
                                }
                                //

                                drTmp["TranDate"] = Convert.ToDateTime(dsTmp.Tables[0].Rows[0]["LogDate"]);
                                drTmp["MRPType"] = "SaleOrder"; drTmp["MRPElement"] = dsTmp.Tables[0].Rows[0]["SONumber"].ToString();
                                drTmp["RequireQty"] = Convert.ToDouble(dsTmp.Tables[0].Rows[0]["FGQty"]); drTmp["AvailableQty"] = dTmpAva; 
                                drTmp["SO"] = dsTmp.Tables[0].Rows[0]["SONumber"].ToString();
                            }
                            else
                            {
                                drTmp["TranDate"] = Convert.ToDateTime(dsTmp.Tables[0].Rows[0]["RequireDate"]);
                                if (dsTmp.Tables[0].Rows[0]["OtherPType"].ToString().Trim().ToUpper() == "F")
                                {
                                    drTmp["MRPType"] = "Plan Order"; drTmp["PType"] = dsTmp.Tables[0].Rows[0]["ProcurementType"].ToString().Trim().ToUpper();                                   
                                }
                                else
                                {
                                    drTmp["MRPType"] = "Prd Order"; drTmp["PType"] = dsTmp.Tables[0].Rows[0]["ProcurementType"].ToString().Trim().ToUpper();                                    
                                }
                                drTmp["MRPElement"] = (dTmpStock > 0 ? string.Empty : dsTmp.Tables[0].Rows[0]["TranHeadOrder"].ToString().Trim());
                                if (dTmpAva < 0)
                                {
                                    //TODO 22/09
                                    if (Convert.ToDouble(dsTmp.Tables[0].Rows[0]["TranQty"]) != 0)
                                    {
                                        drTmp["RequireQty"] = Convert.ToDouble(dsTmp.Tables[0].Rows[0]["TranQty"]);
                                        drTmp["AvailableQty"] = Convert.ToDouble(dsTmp.Tables[0].Rows[0]["TranQty"]) - (dTmpAva < 0 ? -dTmpAva : dTmpAva);
                                    }
                                    else
                                    {
                                        drTmp["RequireQty"] = dTmpAva;
                                        drTmp["AvailableQty"] = 0;
                                    }
                                    //drTmp["RequireQty"] = dTmpAva; drTmp["AvailableQty"] = 0;
                                }
                                else
                                {
                                    if (dTmpAva == 0)
                                    {
                                        break;
                                    }
                                    drTmp["RequireQty"] = dTmpAva; drTmp["AvailableQty"] = dTmpAva;
                                }
                                drTmp["SO"] = dsTmp.Tables[0].Rows[0]["SONumber"].ToString();
                            }
                            this.MyTmpView.Tables[dsTmp.Tables[0].Rows[0]["HeadBomCode"].ToString() + "_" + i.ToString()].Rows.Add(drTmp);
                        }

                        if (dsTmp.Tables[0].Rows[0]["HeadBomCode"].ToString() == dsTmp.Tables[0].Rows[0]["ComponentCode"].ToString())
                        {
                            this.MyTmpView.AcceptChanges();
                            dgv.DataSource = this.MyTmpView.Tables[dsTmp.Tables[0].Rows[0]["HeadBomCode"].ToString() + "_" + i.ToString()];
                            this.hsTmp.Add(this.MyTmpView.Tables[dsTmp.Tables[0].Rows[0]["HeadBomCode"].ToString() + "_" + i.ToString()], dgv.Name);
                            return;
                        }
                        //TODO Add More SO in da first tab
                        NP_Cls.SqlSelect = "SELECT     t_MRPBOM.FGQty, t_MRPBOM.HeadBomCode, t_MRPBOM.LogDate, t_MRPBOM.SONumber, m_Material.MaterialName, m_Material.ProcurementType,  t_MRPBOM.RequireDate, t_MRPTranOrder.TranOrder AS TranHeadOrder FROM         t_MRPBOM LEFT OUTER JOIN t_MRPTranOrder ON t_MRPBOM.SONumber = t_MRPTranOrder.SONumber AND t_MRPBOM.FGCode = t_MRPTranOrder.MaterialCode LEFT OUTER JOIN m_Material ON t_MRPBOM.FGCode = m_Material.MaterialCode WHERE     (t_MRPBOM.HeadBomCode = N'" + dsTmp.Tables[0].Rows[0]["HeadBomCode"].ToString() + "')  AND (t_MRPBOM.ItemSeq = 1) GROUP BY t_MRPBOM.FGQty, t_MRPBOM.HeadBomCode, t_MRPBOM.LogDate, t_MRPBOM.SONumber, m_Material.MaterialName, m_Material.ProcurementType, t_MRPBOM.RequireDate, t_MRPTranOrder.TranOrder ORDER BY t_MRPBOM.SONumber ";
                        DataSet dsTmp4New = new DataSet(); dsTmp4New = NP.GetClientDataSet(NP_Cls.SqlSelect);
                        dTmpStock = (dTmpStock < 0 ? -dTmpStock : dTmpStock);
                        for (int np = 1; np < dsTmp4New.Tables[0].Rows.Count; np++)
                        {
                            for (int x = 0; x < 2; x++)
                            {
                                DataRow drTmp; drTmp = this.MyTmpView.Tables[dsTmp.Tables[0].Rows[0]["HeadBomCode"].ToString() + "_" + i.ToString()].NewRow();
                                if (x == 0)
                                {
                                    dTmpAva = dTmpStock - Convert.ToDouble(dsTmp4New.Tables[0].Rows[np]["FGQty"]);

                                    //TODO New 08-09 Update Stock Qty
                                    if (dTmpStock != 0)
                                    {
                                        dTmpStock = dTmpStock - (dTmpAva < 0 ? -dTmpAva : dTmpAva);
                                    }
                                    //

                                    drTmp["TranDate"] = Convert.ToDateTime(dsTmp4New.Tables[0].Rows[np]["LogDate"]);
                                    drTmp["MRPType"] = "SaleOrder"; drTmp["MRPElement"] = dsTmp4New.Tables[0].Rows[np]["SONumber"].ToString();
                                    drTmp["RequireQty"] = Convert.ToDouble(dsTmp4New.Tables[0].Rows[np]["FGQty"]); drTmp["AvailableQty"] = dTmpAva;
                                    drTmp["SO"] = dsTmp4New.Tables[0].Rows[np]["SONumber"].ToString();
                                }
                                else
                                {
                                    drTmp["TranDate"] = Convert.ToDateTime(dsTmp4New.Tables[0].Rows[np]["RequireDate"]);
                                    if (dsTmp4New.Tables[0].Rows[np]["ProcurementType"].ToString().Trim().ToUpper() == "F")
                                    {
                                        drTmp["MRPType"] = "Plan Order"; drTmp["PType"] = dsTmp4New.Tables[0].Rows[np]["ProcurementType"].ToString().Trim().ToUpper();
                                    }
                                    else
                                    {
                                        drTmp["MRPType"] = "Prd Order"; drTmp["PType"] = dsTmp4New.Tables[0].Rows[np]["ProcurementType"].ToString().Trim().ToUpper();
                                    }
                                    drTmp["MRPElement"] = (dTmpStock > 0 ? string.Empty :dsTmp4New.Tables[0].Rows[np]["TranHeadOrder"].ToString().Trim());
                                    if (dTmpAva < 0)
                                    {
                                        //TODO 22/09
                                        if (Convert.ToDouble(dsTmp.Tables[0].Rows[0]["TranQty"]) != 0)
                                        {
                                            drTmp["RequireQty"] = Convert.ToDouble(dsTmp.Tables[0].Rows[np]["TranQty"]);
                                            drTmp["AvailableQty"] = Convert.ToDouble(dsTmp.Tables[0].Rows[np]["TranQty"]) - (dTmpAva < 0 ? -dTmpAva : dTmpAva);
                                        }
                                        else
                                        {
                                            drTmp["RequireQty"] = dTmpAva;
                                            drTmp["AvailableQty"] = 0;
                                        }
                                        //drTmp["RequireQty"] = dTmpAva; drTmp["AvailableQty"] = 0;
                                    }
                                    else
                                    {
                                        if (dTmpAva == 0)
                                        {
                                            break;
                                        }
                                        drTmp["RequireQty"] = dTmpAva; drTmp["AvailableQty"] = dTmpAva;
                                    }
                                    drTmp["SO"] = dsTmp4New.Tables[0].Rows[np]["SONumber"].ToString();
                                }
                                this.MyTmpView.Tables[0].Rows.Add(drTmp);
                            }
                        }
                        //

                        this.MyTmpView.AcceptChanges();
                        dgv.DataSource = this.MyTmpView.Tables[dsTmp.Tables[0].Rows[0]["HeadBomCode"].ToString() + "_" + i.ToString()];
                        this.hsTmp.Add(this.MyTmpView.Tables[dsTmp.Tables[0].Rows[0]["HeadBomCode"].ToString() + "_" + i.ToString()], dgv.Name);
                        // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ //

                        // Add more on first loop  //
                        for (int xx = 0; xx < dsTmp.Tables[0].Rows.Count; xx++)
                        {
                            //TODO - if duplicate add more record -- 5.11.10 
                            //TODO 0809 
                            dTmpStock = (dTmpStock < 0 ? -dTmpStock : dTmpStock);
                            for (int dup = 0; dup < this.MyTmpView.Tables.Count; dup++)
                            {
                                if (this.MyTmpView.Tables[dup].TableName.StartsWith(dsTmp.Tables[0].Rows[xx]["ComponentCode"].ToString()))
                                {
                                    intTmp = 1;
                                    for (int ss = 0; ss < 2; ss++)
                                    {
                                        //dTmpStock = GetStockByFG(dsTmp.Tables[0].Rows[xx]["ComponentCode"].ToString());
                                        dTmpStock = Convert.ToDouble(this.MyTmpView.Tables[dup].Rows[this.MyTmpView.Tables[dup].Rows.Count - 1]["AvailableQty"].ToString());
                                        DataRow drTmp; drTmp = this.MyTmpView.Tables[dup].NewRow();
                                        if (ss == 0)
                                        {
                                            dTmpAva = dTmpStock - Convert.ToDouble(dsTmp.Tables[0].Rows[xx]["ComponentQty"]);
                                            drTmp["TranDate"] = Convert.ToDateTime(dsTmp.Tables[0].Rows[xx]["RequireDate"]);
                                            drTmp["MRPType"] = "DepReq"; drTmp["MRPElement"] = "Element Test";
                                            drTmp["RequireQty"] = Convert.ToDouble(dsTmp.Tables[0].Rows[xx]["ComponentQty"]);
                                            drTmp["AvailableQty"] = dTmpAva; drTmp["SO"] = dsTmp.Tables[0].Rows[xx]["SONumber"].ToString();
                                        }
                                        else
                                        {
                                            drTmp["TranDate"] = Convert.ToDateTime(dsTmp.Tables[0].Rows[xx]["RequireDate"]);
                                            if (dsTmp.Tables[0].Rows[xx]["ProcurementType"].ToString().Trim().ToUpper() == "F")
                                            { drTmp["MRPType"] = "Plan Order"; }
                                            else { drTmp["MRPType"] = "Prd Order"; }
                                            drTmp["MRPElement"] = (dTmpStock > 0 ? string.Empty : dsTmp.Tables[0].Rows[xx]["TranCompOrder"].ToString().Trim());
                                            if (dsTmp.Tables[0].Rows[xx]["IsComponent"].ToString() == "True")
                                            {
                                                drTmp["MRPElement"] = (Convert.ToBoolean(dsTmp.Tables[0].Rows[xx]["IsCompleted"]) == true ? "Completed !!" : drTmp["MRPElement"].ToString());
                                            }

                                            if (dTmpAva < 0)
                                            {
                                                //TODO 22/09
                                                if (Convert.ToDouble(dsTmp.Tables[0].Rows[0]["TranQty"]) != 0)
                                                {
                                                    drTmp["RequireQty"] = Convert.ToDouble(dsTmp.Tables[0].Rows[xx]["TranQty"]);
                                                    drTmp["AvailableQty"] = Convert.ToDouble(dsTmp.Tables[0].Rows[xx]["TranQty"]) - (dTmpAva < 0 ? -dTmpAva : dTmpAva);
                                                }
                                                else
                                                {
                                                    drTmp["RequireQty"] = dTmpAva;
                                                    drTmp["AvailableQty"] = 0;
                                                }
                                                //drTmp["RequireQty"] = dTmpAva; drTmp["AvailableQty"] = 0;
                                            }
                                            else
                                            {
                                                if (dTmpAva == 0)
                                                {
                                                    break;
                                                }
                                                drTmp["RequireQty"] = dTmpAva; drTmp["AvailableQty"] = dTmpAva;
                                            }
                                            if (Convert.ToDecimal(dsTmp.Tables[0].Rows[xx]["ComponentQty"]) > 0)
                                            {
                                                // Btn Order
                                                //btn = new Button(); btn.Name = "btn_tmp" + xx.ToString(); btn.BackColor = Color.LemonChiffon;
                                                //intTmpLoc = (((this.tcMain.Controls.Find(this.hsTmp[this.MyTmpView.Tables[dup]].ToString(), true)[0] as System.Windows.Forms.DataGridView).RowCount - 1) / 2) * intTmpLoc;
                                                //btn.Location = new Point(199, 67 + intTmpLoc); btn.Size = new Size(71, 23); btn.Text = "Order"; btn.ForeColor = Color.Red;

                                                //(this.tcMain.Controls.Find(this.hsTmp[this.MyTmpView.Tables[dup]].ToString(), true)[0] as System.Windows.Forms.DataGridView).Controls.Add(btn);
                                            }
                                            drTmp["SO"] = dsTmp.Tables[0].Rows[xx]["SONumber"].ToString();
                                        }
                                        this.MyTmpView.Tables[dup].Rows.Add(drTmp);
                                    }
                                    this.MyTmpView.AcceptChanges();

                                    (this.tcMain.Controls.Find(this.hsTmp[this.MyTmpView.Tables[dup]].ToString(), true)[0] as System.Windows.Forms.DataGridView).DataSource = this.MyTmpView.Tables[dup];
                                    break;
                                }                                
                            }

                            if (intTmp != 1)
                            {
                                // Create Control
                                // Tap Page
                                tp = new TabPage();
                                tp.Text = dsTmp.Tables[0].Rows[xx]["ComponentCode"].ToString(); tp.BackColor = Color.White;
                                tp.Name = "tp_lp" + xx.ToString();

                                // Panel
                                pn = new Panel();
                                pn.BackColor = Color.LemonChiffon; pn.Name = "pn_lp" + xx.ToString();
                                pn.Dock = DockStyle.Top; pn.Size = new Size(884, 44); pn.Location = new Point(3, 3);
                                tp.Controls.Add(pn);

                                // Label : Show
                                lbSh = new Label();
                                lbSh.Text = "Description : "; lbSh.Name = "lbSh_lp" + xx.ToString(); lbSh.ForeColor = Color.Black;
                                lbSh.Location = new Point(5, 13); lbSh.Size = new Size(82, 16);

                                // Label : Variable
                                lbVar = new Label();
                                lbVar.Text = dsTmp.Tables[0].Rows[xx]["CompName"].ToString(); lbVar.Name = "lbVar_lp" + xx.ToString();
                                lbVar.Location = new Point(90, 13); lbVar.Size = new Size(82, 16); lbVar.AutoSize = true; lbVar.ForeColor = Color.Navy;

                                // DataGridView
                                dgv = new DataGridView();
                                dgv.Name = "dgv_lp" + xx.ToString();
                                dgv.BackgroundColor = Color.LightGray; dgv.Dock = DockStyle.Bottom; dgv.RowHeadersVisible = false; dgv.Location = new Point(3, 47);
                                dgv.Size = new Size(884, 450); dgv.ReadOnly = true; dgv.AllowUserToAddRows = false; dgv.AllowUserToDeleteRows = false;
                                dgv.AllowUserToResizeColumns = false; dgv.AllowUserToResizeRows = false;
                                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; dgv.MultiSelect = false;
                                dgv.CellDoubleClick += new DataGridViewCellEventHandler(dgv_CellDoubleClick);
                                dgv.CellFormatting += new DataGridViewCellFormattingEventHandler(dgv_CellFormatting);
                                dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
                                DGV(dgv);

                                pn.Controls.Add(lbSh);
                                pn.Controls.Add(lbVar);
                                tp.Controls.Add(dgv);
                                //
                                this.tcMain.TabPages.Add(tp);

                                // ----
                                MyCreateSet(this.MyTmpView, dsTmp.Tables[0].Rows[xx]["ComponentCode"].ToString() + "_" + xx.ToString()); // --------------------- Create DataSet     
                                byte byNP_ex = 0; double dNPMoreDep = 0.0;
                                for (int ss = 0; ss < 3; ss++)
                                {
                                    DataRow drTmp; drTmp = this.MyTmpView.Tables[dsTmp.Tables[0].Rows[xx]["ComponentCode"].ToString() + "_" + xx.ToString()].NewRow();
                                    if (ss == 0)
                                    {
                                        dTmpStock = GetStockByFG(dsTmp.Tables[0].Rows[xx]["ComponentCode"].ToString(), dsTmp.Tables[0].Rows[0]["SONumber"].ToString());
                                        drTmp["TranDate"] = DateTime.Now; drTmp["MRPType"] = "Stock"; drTmp["MRPElement"] = string.Empty;
                                        drTmp["RequireQty"] = DBNull.Value; drTmp["AvailableQty"] = dTmpStock; drTmp["SO"] = dsTmp.Tables[0].Rows[xx]["SONumber"].ToString();
                                    }
                                    else if (ss == 1)
                                    {
                                        dTmpAva = dTmpStock - (Convert.ToDouble(dsTmp.Tables[0].Rows[xx]["SumNeedQty"]) == 0 ? Convert.ToDouble(dsTmp.Tables[0].Rows[xx]["ComponentQty"]) : Convert.ToDouble(dsTmp.Tables[0].Rows[xx]["SumNeedQty"]));

                                        //TODO New 08-09 Update Stock Qty
                                        if (dTmpStock != 0)
                                        {
                                            if (dTmpAva >= 0)
                                            {
                                                dTmpStock = dTmpAva;
                                            }
                                            else
                                            {
                                                dTmpStock = dTmpStock - (dTmpAva < 0 ? -dTmpAva : dTmpAva);
                                            }
                                        }
                                        //
                                        NP_Cls.SqlSelect = "SELECT  HeadBOMCode ,ComponentQty, RequireDate, ComponentCode FROM  t_MRPBOM WHERE     (ComponentCode = N'" + dsTmp.Tables[0].Rows[xx]["ComponentCode"].ToString() + "') ORDER BY RequireDate";
                                        DataSet dsDep = new DataSet(); dsDep = NP.GetDataWithTran(NP_Cls.SqlSelect, Tr, oConn);
                                        if (dsDep.Tables[0].Rows.Count > 0)
                                        {
                                            byNP_ex = 1;
                                            for (int dep = 0; dep < dsDep.Tables[0].Rows.Count; dep++)
                                            {
                                                DataRow drDep; drDep = this.MyTmpView.Tables[dsTmp.Tables[0].Rows[xx]["ComponentCode"].ToString() + "_" + xx.ToString()].NewRow();
                                                drDep["TranDate"] = Convert.ToDateTime(dsDep.Tables[0].Rows[dep]["RequireDate"]);
                                                drDep["MRPType"] = "DepReq:" + dsDep.Tables[0].Rows[dep]["HeadBOMCode"].ToString(); drDep["MRPElement"] = "Element Test";
                                                drDep["RequireQty"] = Convert.ToDouble(dsDep.Tables[0].Rows[dep]["ComponentQty"]);
                                                drDep["AvailableQty"] = -Convert.ToDouble(dsDep.Tables[0].Rows[dep]["ComponentQty"]); ; drTmp["SO"] = dsTmp.Tables[0].Rows[xx]["SONumber"].ToString();
                                                this.MyTmpView.Tables[dsTmp.Tables[0].Rows[xx]["ComponentCode"].ToString() + "_" + xx.ToString()].Rows.Add(drDep);
                                                dNPMoreDep += Convert.ToDouble(dsDep.Tables[0].Rows[dep]["ComponentQty"]);
                                            }
                                        }
                                        else
                                        {
                                            byNP_ex = 0;
                                            drTmp["TranDate"] = Convert.ToDateTime(dsTmp.Tables[0].Rows[xx]["RequireDate"]);
                                            drTmp["MRPType"] = "DepReq"; drTmp["MRPElement"] = "Element Test";
                                            drTmp["RequireQty"] = Convert.ToDouble(dsTmp.Tables[0].Rows[xx]["ComponentQty"]);
                                            //(Convert.ToDouble(dsTmp.Tables[0].Rows[xx]["TranQty"]) == 0 ? Convert.ToDouble(dsTmp.Tables[0].Rows[xx]["ComponentQty"]) : Convert.ToDouble(dsTmp.Tables[0].Rows[xx]["TranQty"])); 
                                            drTmp["AvailableQty"] = dTmpAva; drTmp["SO"] = dsTmp.Tables[0].Rows[xx]["SONumber"].ToString();
                                            dNPMoreDep += Convert.ToDouble(dsDep.Tables[0].Rows[xx]["ComponentQty"]);
                                        }
                                    }
                                    else
                                    {
                                        byNP_ex = 1;
                                        //TODO //------------------------------------------------- Check Plan date
                                        DateTime dtNP_Comp = new DateTime();
                                        Int32 iNP_Loop = 0;
                                        iNP_Loop = this.MyTmpView.Tables[dsTmp.Tables[0].Rows[xx]["ComponentCode"].ToString() + "_" + xx.ToString()].Rows.Count;
                                        for (int dReq = 0; dReq < iNP_Loop; dReq++)
                                        {
                                            if (dReq > 0)
                                            {
                                                DataRow drDep; drDep = this.MyTmpView.Tables[dsTmp.Tables[0].Rows[xx]["ComponentCode"].ToString() + "_" + xx.ToString()].NewRow();
                                                drDep["RequireQty"] = -Convert.ToDouble(this.MyTmpView.Tables[dsTmp.Tables[0].Rows[xx]["ComponentCode"].ToString() + "_" + xx.ToString()].Rows[dReq]["RequireQty"]);
                                                drDep["AvailableQty"] = Convert.ToDouble(this.MyTmpView.Tables[dsTmp.Tables[0].Rows[xx]["ComponentCode"].ToString() + "_" + xx.ToString()].Rows[dReq]["AvailableQty"]);
                                                //============================================================
                                                ////if (dTmpAva < 0)
                                                ////{
                                                ////    //TODO 22/09
                                                ////    if (Convert.ToDouble(dsTmp.Tables[0].Rows[xx]["TranQty"]) != 0)
                                                ////    {
                                                ////        drTmp["RequireQty"] = Convert.ToDouble(dsTmp.Tables[0].Rows[xx]["TranQty"]);
                                                ////        drTmp["AvailableQty"] = Convert.ToDouble(dsTmp.Tables[0].Rows[xx]["TranQty"]) - dNPMoreDep;
                                                ////        //drTmp["RequireQty"] = Convert.ToDouble(dsTmp.Tables[0].Rows[xx]["TranQty"]);
                                                ////        //drTmp["AvailableQty"] = Convert.ToDouble(dsTmp.Tables[0].Rows[xx]["TranQty"]) - (dTmpAva < 0 ? -dTmpAva : dTmpAva);
                                                ////    }
                                                ////    else
                                                ////    {
                                                ////        drTmp["RequireQty"] = -dNPMoreDep;
                                                ////        drTmp["AvailableQty"] = dNPMoreDep;
                                                ////    }
                                                ////}
                                                ////else
                                                ////{
                                                ////    if (dTmpAva == 0)
                                                ////    {
                                                ////        break;
                                                ////    }
                                                ////    drTmp["RequireQty"] = dTmpAva; drTmp["AvailableQty"] = dTmpAva;
                                                ////}
                                                drDep["TranDate"] = Convert.ToDateTime(this.MyTmpView.Tables[dsTmp.Tables[0].Rows[xx]["ComponentCode"].ToString() + "_" + xx.ToString()].Rows[dReq]["TranDate"]);
                                                if (dsTmp.Tables[0].Rows[xx]["ProcurementType"].ToString().Trim().ToUpper() == "F")
                                                { drDep["MRPType"] = "Plan Order"; }
                                                else { drDep["MRPType"] = "Prd Order"; }
                                                drDep["MRPElement"] = (dTmpStock > 0 ? string.Empty : dsTmp.Tables[0].Rows[xx]["TranCompOrder"].ToString().Trim());
                                                if (dsTmp.Tables[0].Rows[xx]["IsComponent"].ToString() == "True")
                                                {
                                                    drDep["MRPElement"] = (Convert.ToBoolean(dsTmp.Tables[0].Rows[xx]["IsCompleted"]) == true ? "Completed !!" : drDep["MRPElement"].ToString());
                                                }
                                                drDep["PType"] = dsTmp.Tables[0].Rows[xx]["ProcurementType"].ToString().Trim().ToUpper();
                                                drDep["SO"] = dsTmp.Tables[0].Rows[xx]["SONumber"].ToString();
                                                this.MyTmpView.Tables[dsTmp.Tables[0].Rows[xx]["ComponentCode"].ToString() + "_" + xx.ToString()].Rows.Add(drDep);
                                                //============================================================
                                            }
                                        }
                                        //------------------------------------------------- Check Plan date

                                       
                                    }
                                        
                                    if (byNP_ex == 0)
                                    {
                                        this.MyTmpView.Tables[dsTmp.Tables[0].Rows[xx]["ComponentCode"].ToString() + "_" + xx.ToString()].Rows.Add(drTmp);
                                    }
                                }
                                this.MyTmpView.AcceptChanges();
                                dgv.DataSource = this.MyTmpView.Tables[dsTmp.Tables[0].Rows[xx]["ComponentCode"].ToString() + "_" + xx.ToString()];
                                this.hsTmp.Add(this.MyTmpView.Tables[dsTmp.Tables[0].Rows[xx]["ComponentCode"].ToString() + "_" + xx.ToString()], dgv.Name);
                                //-----
                                //intTmp = Convert.ToInt16(intTmp + 1 + xx); 
                            }
                            else
                            {
                                intTmp = 0;
                            }
                        }
                    }
                    else // ---------------------------------------------------------------------------------------------------------------------------- // Another Tab will released here
                    {
                        //double dTmpStock = 0; double dTmpAva = 0;
                        for (int xx = 0; xx < dsTmp.Tables[0].Rows.Count; xx++)
                        {
                            //TODO More Duplicate 9.11.10
                            dTmpStock = (dTmpStock < 0 ? -dTmpStock : dTmpStock);
                            for (int dup = 0; dup < this.MyTmpView.Tables.Count; dup++)
                            {
                                if (this.MyTmpView.Tables[dup].TableName.StartsWith(dsTmp.Tables[0].Rows[xx]["ComponentCode"].ToString()))
                                {
                                    intTmp = 1;
                                    for (int ss = 0; ss < 2; ss++)
                                    {
                                        //dTmpStock = GetStockByFG(dsTmp.Tables[0].Rows[xx]["ComponentCode"].ToString());
                                        dTmpStock = Convert.ToDouble(this.MyTmpView.Tables[dup].Rows[this.MyTmpView.Tables[dup].Rows.Count - 1]["AvailableQty"].ToString());
                                        DataRow drTmp; drTmp = this.MyTmpView.Tables[dup].NewRow();
                                        if (ss == 0)
                                        {
                                            dTmpAva = dTmpStock - Convert.ToDouble(dsTmp.Tables[0].Rows[xx]["ComponentQty"]);
                                            drTmp["TranDate"] = Convert.ToDateTime(dsTmp.Tables[0].Rows[xx]["RequireDate"]);
                                            drTmp["MRPType"] = "DepReq"; drTmp["MRPElement"] = "Element Test";
                                            drTmp["RequireQty"] = Convert.ToDecimal(dsTmp.Tables[0].Rows[xx]["ComponentQty"]);
                                            drTmp["AvailableQty"] = dTmpAva; drTmp["SO"] = dsTmp.Tables[0].Rows[xx]["SONumber"].ToString();
                                        }
                                        else
                                        {
                                            drTmp["TranDate"] = Convert.ToDateTime(dsTmp.Tables[0].Rows[xx]["RequireDate"]);
                                            if (dsTmp.Tables[0].Rows[xx]["ProcurementType"].ToString().Trim().ToUpper() == "F")
                                            { drTmp["MRPType"] = "Plan Order"; }
                                            else { drTmp["MRPType"] = "Prd Order"; }
                                            drTmp["MRPElement"] = (dTmpStock > 0 ? string.Empty : dsTmp.Tables[0].Rows[xx]["TranCompOrder"].ToString().Trim());
                                            if (dsTmp.Tables[0].Rows[xx]["IsComponent"].ToString() == "True")
                                            {
                                                drTmp["MRPElement"] = (Convert.ToBoolean(dsTmp.Tables[0].Rows[xx]["IsCompleted"]) == true ? "Completed !!" : drTmp["MRPElement"].ToString());
                                            }
                                            if (dTmpAva < 0)
                                            {
                                                //TODO 22/09
                                                if (Convert.ToDouble(dsTmp.Tables[0].Rows[0]["TranQty"]) != 0)
                                                {
                                                    drTmp["RequireQty"] = Convert.ToDouble(dsTmp.Tables[0].Rows[xx]["TranQty"]);
                                                    drTmp["AvailableQty"] = Convert.ToDouble(dsTmp.Tables[0].Rows[xx]["TranQty"]) - (dTmpAva < 0 ? -dTmpAva : dTmpAva);
                                                }
                                                else
                                                {
                                                    drTmp["RequireQty"] = dTmpAva;
                                                    drTmp["AvailableQty"] = 0;
                                                }
                                             //   drTmp["RequireQty"] = dTmpAva; drTmp["AvailableQty"] = 0;
                                            }
                                            else
                                            {
                                                if (dTmpAva == 0)
                                                {
                                                    break;
                                                }
                                                drTmp["RequireQty"] = dTmpAva; drTmp["AvailableQty"] = dTmpAva;
                                            }
                                            if (Convert.ToDecimal(dsTmp.Tables[0].Rows[xx]["ComponentQty"]) > 0)
                                            {
                                                // Btn Order
                                                //btn = new Button(); btn.Name = "btn_tmp" + xx.ToString(); btn.BackColor = Color.LemonChiffon;
                                                //intTmpLoc = (((this.tcMain.Controls.Find(this.hsTmp[this.MyTmpView.Tables[dup]].ToString(), true)[0] as System.Windows.Forms.DataGridView).RowCount - 1) / 2) * intTmpLoc;
                                                //btn.Location = new Point(199, 67 + intTmpLoc); btn.Size = new Size(71, 23); btn.Text = "Order"; btn.ForeColor = Color.Red;

                                                //(this.tcMain.Controls.Find(this.hsTmp[this.MyTmpView.Tables[dup]].ToString(), true)[0] as System.Windows.Forms.DataGridView).Controls.Add(btn);
                                            }
                                            drTmp["SO"] = dsTmp.Tables[0].Rows[xx]["SONumber"].ToString();
                                        }
                                        this.MyTmpView.Tables[dup].Rows.Add(drTmp);
                                    }
                                    this.MyTmpView.AcceptChanges();
                                    (this.tcMain.Controls.Find(this.hsTmp[this.MyTmpView.Tables[dup]].ToString(), true)[0] as System.Windows.Forms.DataGridView).DataSource = this.MyTmpView.Tables[dup];
                                    break;
                                }
                            }
                            //

                            if (intTmp != 1)
                            {
                                // Create Control
                                // Tap Page
                                TabPage tp = new TabPage(); 
                                tp.Text = dsTmp.Tables[0].Rows[xx]["ComponentCode"].ToString(); tp.BackColor = Color.White;
                                tp.Name = "tp_" + xx.ToString();

                                // Panel
                                Panel pn = new Panel();
                                pn.BackColor = Color.LemonChiffon; pn.Name = "pn_" + xx.ToString();
                                pn.Dock = DockStyle.Top; pn.Size = new Size(884, 44); pn.Location = new Point(3, 3);
                                tp.Controls.Add(pn);

                                // Label : Show
                                Label lbSh = new Label();
                                lbSh.Text = "Description : "; lbSh.Name = "lbSh_" + xx.ToString(); lbSh.ForeColor = Color.Black;
                                lbSh.Location = new Point(5, 13); lbSh.Size = new Size(82, 16);

                                // Label : Variable
                                Label lbVar = new Label();
                                lbVar.Text = dsTmp.Tables[0].Rows[xx]["CompName"].ToString(); lbVar.Name = "lbVar_" + xx.ToString();
                                lbVar.Location = new Point(90, 13); lbVar.Size = new Size(82, 16); lbVar.AutoSize = true; lbVar.ForeColor = Color.Navy;

                                // DataGridView
                                DataGridView dgv = new DataGridView();
                                dgv.Name = "dgv_" + xx.ToString();
                                dgv.BackgroundColor = Color.LightGray; dgv.Dock = DockStyle.Bottom; dgv.RowHeadersVisible = false; dgv.Location = new Point(3, 47);
                                dgv.Size = new Size(884, 450); dgv.ReadOnly = true; dgv.AllowUserToAddRows = false; dgv.AllowUserToDeleteRows = false;
                                dgv.AllowUserToResizeColumns = false; dgv.AllowUserToResizeRows = false;
                                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; dgv.MultiSelect = false;
                                dgv.CellDoubleClick += new DataGridViewCellEventHandler(dgv_CellDoubleClick);
                                dgv.CellFormatting += new DataGridViewCellFormattingEventHandler(dgv_CellFormatting);
                                dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
                                DGV(dgv);

                                pn.Controls.Add(lbSh);
                                pn.Controls.Add(lbVar); 
                                tp.Controls.Add(dgv);
                                //
                                this.tcMain.TabPages.Add(tp);

                                // ----
                                MyCreateSet(this.MyTmpView, dsTmp.Tables[0].Rows[xx]["ComponentCode"].ToString() + "_" + xx.ToString()); // ---------------------- Create DataSet 

                                for (int ss = 0; ss < 3; ss++)
                                {
                                    DataRow drTmp; drTmp = this.MyTmpView.Tables[dsTmp.Tables[0].Rows[xx]["ComponentCode"].ToString() + "_" + xx.ToString()].NewRow();
                                    if (ss == 0)
                                    {
                                        dTmpStock = GetStockByFG(dsTmp.Tables[0].Rows[xx]["ComponentCode"].ToString(), dsTmp.Tables[0].Rows[0]["SONumber"].ToString());
                                        drTmp["TranDate"] = DateTime.Now; drTmp["MRPType"] = "Stock"; drTmp["MRPElement"] = string.Empty;
                                        drTmp["RequireQty"] = DBNull.Value; drTmp["AvailableQty"] = dTmpStock; drTmp["SO"] = dsTmp.Tables[0].Rows[xx]["SONumber"].ToString();
                                    }
                                    else if (ss == 1)
                                    {
                                        //dTmpAva = dTmpStock - Convert.ToDouble(dsTmp.Tables[0].Rows[xx]["ComponentQty"]);
                                        dTmpAva = dTmpStock - (Convert.ToDouble(dsTmp.Tables[0].Rows[xx]["TranQty"]) == 0 ? Convert.ToDouble(dsTmp.Tables[0].Rows[xx]["ComponentQty"]) : Convert.ToDouble(dsTmp.Tables[0].Rows[xx]["TranQty"]));

                                        //TODO New 08-09 Update Stock Qty
                                        if (dTmpStock != 0)
                                        {
                                            dTmpStock = dTmpStock - (dTmpAva < 0 ? -dTmpAva : dTmpAva);
                                        }
                                        //

                                        drTmp["TranDate"] = Convert.ToDateTime(dsTmp.Tables[0].Rows[xx]["RequireDate"]);
                                        drTmp["MRPType"] = "DepReq"; drTmp["MRPElement"] = "Element Test";
                                        drTmp["RequireQty"] = Convert.ToDouble(dsTmp.Tables[0].Rows[xx]["ComponentQty"]);
                                        drTmp["AvailableQty"] = dTmpAva; drTmp["SO"] = dsTmp.Tables[0].Rows[xx]["SONumber"].ToString();
                                    }
                                    else
                                    {
                                        drTmp["TranDate"] = Convert.ToDateTime(dsTmp.Tables[0].Rows[xx]["RequireDate"]); 
                                        if (dsTmp.Tables[0].Rows[xx]["ProcurementType"].ToString().Trim().ToUpper() == "F")
                                        { drTmp["MRPType"] = "Plan Order"; }
                                        else { drTmp["MRPType"] = "Prd Order"; }
                                        drTmp["MRPElement"] = (dTmpStock > 0 ? string.Empty : dsTmp.Tables[0].Rows[xx]["TranCompOrder"].ToString().Trim());
                                        if (dsTmp.Tables[0].Rows[xx]["IsComponent"].ToString() == "True")
                                        {
                                            drTmp["MRPElement"] = (Convert.ToBoolean(dsTmp.Tables[0].Rows[xx]["IsCompleted"]) == true ? "Completed !!" : drTmp["MRPElement"].ToString());
                                        }
                                        if (dTmpAva < 0)
                                        {
                                            //TODO 22/09
                                            if (Convert.ToDouble(dsTmp.Tables[0].Rows[0]["TranQty"]) != 0)
                                            {
                                                drTmp["RequireQty"] = Convert.ToDouble(dsTmp.Tables[0].Rows[xx]["TranQty"]);
                                                drTmp["AvailableQty"] = Convert.ToDouble(dsTmp.Tables[0].Rows[xx]["TranQty"]) - (dTmpAva < 0 ? -dTmpAva : dTmpAva);
                                            }
                                            else
                                            {
                                                drTmp["RequireQty"] = dTmpAva;
                                                drTmp["AvailableQty"] = 0;
                                            }
                                        }
                                        else
                                        {
                                            if (dTmpAva == 0)
                                            {
                                                break;
                                            }
                                            drTmp["RequireQty"] = dTmpAva; drTmp["AvailableQty"] = dTmpAva;
                                        }
                                        drTmp["PType"] = dsTmp.Tables[0].Rows[xx]["ProcurementType"].ToString().Trim().ToUpper();
                                        drTmp["SO"] = dsTmp.Tables[0].Rows[xx]["SONumber"].ToString();
                                    }
                                    this.MyTmpView.Tables[dsTmp.Tables[0].Rows[xx]["ComponentCode"].ToString() + "_" + xx.ToString()].Rows.Add(drTmp);
                                }
                                this.MyTmpView.AcceptChanges();
                                dgv.DataSource = this.MyTmpView.Tables[dsTmp.Tables[0].Rows[xx]["ComponentCode"].ToString() + "_" + xx.ToString()];
                                this.hsTmp.Add(this.MyTmpView.Tables[dsTmp.Tables[0].Rows[xx]["ComponentCode"].ToString() + "_" + xx.ToString()], dgv.Name);
                                //-----
                            }
                            else
                            {
                                intTmp = 0;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Running : " + ex.Message); return;
            }
        }

        private void GenComp(SqlCommand cmdUp, SqlTransaction Tr, string strMat)
        {
            //TODO New 28-08 MRP Running
            //First Step Check at PR,PO,GR
            NP_Cls.SqlSelect = "SELECT     t_BOMDetail.MaterialCode AS CompCode FROM t_BOM INNER JOIN t_BOMDetail ON t_BOM.BOMCode = t_BOMDetail.BOMCode WHERE     (t_BOM.MaterialCode = N'" + strMat + "')";
            DataSet dsComp = new DataSet(); dsComp = NP.GetDataWithTran(NP_Cls.SqlSelect, Tr, oConn);
            for (int cp = 0; cp < dsComp.Tables[0].Rows.Count; cp++)
            {
                NP_Cls.SqlSelect = "SELECT t_PRDetail.PRNumber, t_PRDetail.PRQuantity, ISNULL(t_PODetail.POQuantity, 0) AS POQuantity, ISNULL(t_PODetail.GRQuantity, 0) AS GRQuantity, t_PRDetail.MaterialCode, t_PRDetail.MaterialName FROM  t_PO RIGHT OUTER JOIN t_PODetail ON t_PO.PONumber = t_PODetail.PONumber RIGHT OUTER JOIN t_PRDetail ON t_PODetail.PRNumber = t_PRDetail.PRNumber AND t_PODetail.MaterialCode = t_PRDetail.MaterialCode WHERE (t_PRDetail.MaterialCode = N'" + dsComp.Tables[0].Rows[cp]["CompCode"].ToString() + "') AND (t_PO.POApprove = 0 OR t_PO.POApprove IS NULL)";
                DataSet dsFBom = new DataSet(); dsFBom = NP.GetDataWithTran(NP_Cls.SqlSelect, Tr, oConn);
                if (dsFBom.Tables[0].Rows.Count > 0)
                {
                    if (cmdUp.Parameters.Count < 2)
                    {
                        cmdUp.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15);
                        cmdUp.Parameters.Add("@SONumber", SqlDbType.NVarChar, 20);
                        cmdUp.Parameters.Add("@TranOrder", SqlDbType.NVarChar, 50);
                        cmdUp.Parameters.Add("@TranQty", SqlDbType.Decimal);
                        cmdUp.Parameters.Add("@MaterialHeader", SqlDbType.NVarChar, 20);
                    }
                    else
                    {
                        for (int pp = 0; pp < cmdUp.Parameters.Count; pp++)
                        {
                            if (cmdUp.Parameters[pp].DbType == DbType.String)
                            {
                                cmdUp.Parameters[pp].Value = string.Empty;
                            }
                            else
                            {
                                cmdUp.Parameters[pp].Value = 0;
                            }
                        }
                    }

                    //New 12.09 Insert MRP Tran Order
                    NP_Cls.SqlInsert = "UPDATE t_MRPTranOrder " +
       "SET  TranOrder = @TranOrder, TranQty = @TranQty, MaterialHeader = @MaterialHeader " +
"WHERE (MaterialCode = @MaterialCode)";
                    cmdUp.Parameters["@MaterialCode"].Value = dsFBom.Tables[0].Rows[0]["MaterialCode"].ToString();
                    cmdUp.Parameters["@SONumber"].Value = string.Empty;
                    cmdUp.Parameters["@TranOrder"].Value = dsFBom.Tables[0].Rows[0]["PRNumber"].ToString();
                    if (Convert.ToDecimal(dsFBom.Tables[0].Rows[0]["POQuantity"].ToString()) == 0)
                    {
                        cmdUp.Parameters["@TranQty"].Value = Convert.ToDecimal(dsFBom.Tables[0].Rows[0]["PRQuantity"].ToString());
                    }
                    else if (Convert.ToDecimal(dsFBom.Tables[0].Rows[0]["GRQuantity"].ToString()) == 0)
                    {
                        cmdUp.Parameters["@TranQty"].Value = Convert.ToDecimal(dsFBom.Tables[0].Rows[0]["POQuantity"].ToString());
                    }
                    else
                    {
                        cmdUp.Parameters["@TranQty"].Value = Convert.ToDecimal(dsFBom.Tables[0].Rows[0]["POQuantity"].ToString()) - Convert.ToDecimal(dsFBom.Tables[0].Rows[0]["GRQuantity"].ToString());
                    }
                    cmdUp.Parameters["@MaterialHeader"].Value = dsFBom.Tables[0].Rows[0]["MaterialCode"].ToString();
                    cmdUp.Connection = oConn; cmdUp.CommandText = NP_Cls.SqlInsert; cmdUp.Transaction = Tr;
                    cmdUp.ExecuteNonQuery();
                }
                else
                {
                    NP_Cls.SqlDel = "DELETE FROM t_MRPTranOrder WHERE (MaterialCode = @DelMaterialCode)";
                    try
                    {
                        if (cmdUp.Parameters["@DelMaterialCode"] == null)
                        {
                            cmdUp.Parameters.Add("@DelMaterialCode", SqlDbType.NVarChar, 20);
                        }
                    }
                    catch
                    {
                        cmdUp.Parameters.Add("@DelMaterialCode", SqlDbType.NVarChar, 20);
                    }

                    for (int pp = 0; pp < cmdUp.Parameters.Count; pp++)
                    {                      
                        if (cmdUp.Parameters[pp].DbType == DbType.String)
                        {
                            cmdUp.Parameters[pp].Value = string.Empty;
                        }
                        else
                        {
                            cmdUp.Parameters[pp].Value = 0;
                        }
                    }
                    cmdUp.Parameters["@DelMaterialCode"].Value = dsComp.Tables[0].Rows[cp]["CompCode"].ToString();
                    cmdUp.Connection = oConn; cmdUp.CommandText = NP_Cls.SqlDel; cmdUp.Transaction = Tr;
                    cmdUp.ExecuteNonQuery();
                }
            }

          
        }

        private double GetStockByFG(string FGCode, string SO)
        {
            try
            {
                string strTmp = "SELECT     t_StockOverview.AutoID, t_StockOverview.MaterialCode, t_StockOverview.BatchNumber, ISNULL(t_StockOverview.UR, 0) + ISNULL(t_StockOverview.QI, 0) AS QI,  t_StockOverview.Block, t_StockOverview.UserCreate, t_StockOverview.DateCreate, t_StockOverview.UserChange, t_StockOverview.DateChange,  t_MRPBOM.RequireDate, t_MRPBOM.SONumber FROM         t_StockOverview LEFT OUTER JOIN  t_MRPBOM ON t_StockOverview.MaterialCode = t_MRPBOM.ComponentCode WHERE  (t_StockOverview.MaterialCode = N'" + FGCode + "') ORDER BY t_MRPBOM.RequireDate";
                DataSet dsTmp = new DataSet(); dsTmp = NP.GetClientDataSet(strTmp); double dMinus = 0;
                if (dsTmp.Tables[0].Rows.Count > 0)
                {
                    for (int st = 0; st < dsTmp.Tables[0].Rows.Count; st++)
                    {
                        if (dsTmp.Tables[0].Rows[st]["SONumber"].ToString().Trim() == SO)
                        {
                            return Convert.ToDouble(dsTmp.Tables[0].Rows[0]["QI"].ToString()) - dMinus;
                        }
                        else
                        {
                            dMinus += Convert.ToDouble(dsTmp.Tables[0].Rows[st]["QI"]);
                        }
                    }                    
                    return Convert.ToDouble(dsTmp.Tables[0].Rows[0]["QI"].ToString());
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((sender as DataGridView).Columns[e.ColumnIndex].Name == "clnMRPType")
            {
                if (e.Value != null)
                {
                    if ((e.Value.ToString() == "Prd Order") || (e.Value.ToString() == "Plan Order"))
                    {
                        if (Convert.ToDouble((sender as DataGridView).Rows[e.RowIndex].Cells["clnRequireQty"].Value) < 0)
                        {
                            if (!string.IsNullOrEmpty((sender as DataGridView).Rows[e.RowIndex].Cells["clnMRPElement"].Value.ToString()))
                            {
                                e.CellStyle.BackColor = Color.LightGreen;
                            }
                            else
                            {
                                e.CellStyle.BackColor = Color.OrangeRed;
                            }
                        }
                    }
                }
            }
        }
        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((sender as DataGridView).RowCount == 0) { return; }
            if (!string.IsNullOrEmpty((sender as DataGridView).Rows[e.RowIndex].Cells["clnMRPElement"].Value.ToString()))
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "This Material Code already order !!"); return;
            }
            if ((sender as DataGridView).SelectedRows[0].Cells["clnMRPType"].Value.ToString() == "Prd Order")
            {
                if (Convert.ToDouble((sender as DataGridView).SelectedRows[0].Cells["clnRequireQty"].Value) <= 0)
                {
                    string strTmp = string.Empty;
                    foreach (object item in this.hsTmp.Keys)
                    {
                        if ((sender as DataGridView).Name.Trim() == this.hsTmp[item].ToString())
                        {
                            strTmp = item.ToString(); NP_Cls.MRPSO = (sender as DataGridView).SelectedRows[0].Cells["clnSO"].Value.ToString(); break;
                        }
                    }
                    if (NP.MSGB("Do you want to open Prd Order : '" + strTmp.Split('_')[0].ToString() + "' ?") == DialogResult.Yes)
                    {
                        NP_Cls.FromMRP = 1; NP_Cls.MRPFGSort = strTmp.Split('_')[0].ToString();
                        NP_Cls.MRPQty = (Convert.ToDouble((sender as DataGridView).SelectedRows[0].Cells["clnRequireQty"].Value) < 0 ? -Convert.ToDouble((sender as DataGridView).SelectedRows[0].Cells["clnRequireQty"].Value) : Convert.ToDouble((sender as DataGridView).SelectedRows[0].Cells["clnRequireQty"].Value));
                        SaleTranSac.frmPrdOrder frm = new WMS.SaleTranSac.frmPrdOrder();
                        frm.StartPosition = FormStartPosition.CenterParent; frm.Width = 950; frm.Height = 500; frm.FormBorderStyle = FormBorderStyle.SizableToolWindow;
                        frm.ShowDialog();
                        NP_Cls.FromMRP = 0;
                        this.btnMRP_Click(sender, e); return;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            if ((sender as DataGridView).SelectedRows[0].Cells["clnMRPType"].Value.ToString() == "Plan Order")
            {
                if (Convert.ToDouble((sender as DataGridView).SelectedRows[0].Cells["clnRequireQty"].Value) <= 0)
                {
                    string strTmp = string.Empty;
                    foreach (object item in this.hsTmp.Keys)
                    {
                        if ((sender as DataGridView).Name.Trim() == this.hsTmp[item].ToString())
                        {
                            strTmp = item.ToString(); NP_Cls.MRPSO = (sender as DataGridView).SelectedRows[0].Cells["clnSO"].Value.ToString(); break;
                        }
                    }
                    if (NP.MSGB("Do you want to open Plan Pr : '" + strTmp.Split('_')[0].ToString() +  "' ?") == DialogResult.Yes)
                    {
                        NP_Cls.FromMRP = 1; NP_Cls.MRPFGSort = strTmp.Split('_')[0].ToString();
                        NP_Cls.MRPQty = (Convert.ToDouble((sender as DataGridView).SelectedRows[0].Cells["clnRequireQty"].Value) < 0 ? -Convert.ToDouble((sender as DataGridView).SelectedRows[0].Cells["clnRequireQty"].Value) : Convert.ToDouble((sender as DataGridView).SelectedRows[0].Cells["clnRequireQty"].Value));
                        PR_PO.frmPR frm = new WMS.PR_PO.frmPR();
                        frm.StartPosition = FormStartPosition.CenterParent; frm.FormBorderStyle = FormBorderStyle.SizableToolWindow; frm.Width = 950; frm.Height = 500;
                        frm.ShowDialog();
                        NP_Cls.FromMRP = 0;
                        this.btnMRP_Click(sender, e);
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
       
        private void frmMRPRunning_Load(object sender, EventArgs e)
        {
            LoginSystem.frmMainMenu frm = ((LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"]);
            frm.menuStrip1.Enabled = true;
            //MyCreateSet(this.MyTmpView, "MatCode");
            //DGV(this.dgvView);
            this.MyTmpView = new DataSet();
            this.txtMatCode.Text = string.Empty; this.txtMatCode.Select(); 
        }
        private void MyCreateSet(DataSet dataSet, string TableName)
        {
            dataSet.Tables.Add(new DataTable(TableName));
            dataSet.Tables[TableName].Columns.Add(new DataColumn("TranDate", typeof(System.DateTime)));
            dataSet.Tables[TableName].Columns.Add(new DataColumn("MRPType", typeof(System.String)));
            dataSet.Tables[TableName].Columns.Add(new DataColumn("MRPElement", typeof(System.String)));
            dataSet.Tables[TableName].Columns.Add(new DataColumn("RequireQty", typeof(System.Decimal)));
            dataSet.Tables[TableName].Columns.Add(new DataColumn("AvailableQty", typeof(System.Decimal)));
            dataSet.Tables[TableName].Columns.Add(new DataColumn("AutoID", typeof(System.Int32)));
            dataSet.Tables[TableName].Columns.Add(new DataColumn("PType", typeof(System.String)));
            dataSet.Tables[TableName].Columns.Add(new DataColumn("SO", typeof(System.String)));
            dataSet.AcceptChanges();
        }
        private void DGV(DataGridView dataGridView)
        {
            DataGridViewTextBoxColumn dateColumn = new DataGridViewTextBoxColumn();
            dateColumn.HeaderText = "date"; dateColumn.Name = "clnDate"; dateColumn.Visible = true;
            dateColumn.DataPropertyName = "TranDate"; dateColumn.ReadOnly = true; dateColumn.Width = 120;
            dateColumn.DefaultCellStyle.Format = "dd.MM.yyyy"; dateColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            
            DataGridViewTextBoxColumn MRPTypeColumn = new DataGridViewTextBoxColumn();
            MRPTypeColumn.HeaderText = "MRP Type"; MRPTypeColumn.Name = "clnMRPType"; MRPTypeColumn.Visible = true;
            MRPTypeColumn.DataPropertyName = "MRPType"; MRPTypeColumn.ReadOnly = true; MRPTypeColumn.Width = 150;
            MRPTypeColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            //MRPTypeColumn.DefaultCellStyle.BackColor = Color.OrangeRed;

            DataGridViewTextBoxColumn MRPElementColumn = new DataGridViewTextBoxColumn();
            MRPElementColumn.HeaderText = "MRP Element"; MRPElementColumn.Name = "clnMRPElement"; MRPElementColumn.Visible = true;
            MRPElementColumn.DataPropertyName = "MRPElement"; MRPElementColumn.ReadOnly = true; MRPElementColumn.Width = 150;
            MRPElementColumn.SortMode = DataGridViewColumnSortMode.NotSortable;

            DataGridViewTextBoxColumn reqQtyColumn = new DataGridViewTextBoxColumn();
            reqQtyColumn.HeaderText = "require qty"; reqQtyColumn.Name = "clnRequireQty"; reqQtyColumn.Visible = true; reqQtyColumn.DefaultCellStyle.NullValue = string.Empty;
            reqQtyColumn.DataPropertyName = "RequireQty"; reqQtyColumn.ReadOnly = true; reqQtyColumn.Width = 150; reqQtyColumn.DefaultCellStyle.Format = "N3";
            reqQtyColumn.SortMode = DataGridViewColumnSortMode.NotSortable;

            DataGridViewTextBoxColumn AvaQtyColumn = new DataGridViewTextBoxColumn();
            AvaQtyColumn.HeaderText = "available qty"; AvaQtyColumn.Name = "clnAvailableQty"; AvaQtyColumn.Visible = true;
            AvaQtyColumn.DataPropertyName = "AvailableQty"; AvaQtyColumn.ReadOnly = true; AvaQtyColumn.Width = 150;
            AvaQtyColumn.DefaultCellStyle.Format = "N3"; AvaQtyColumn.SortMode = DataGridViewColumnSortMode.NotSortable; 

            DataGridViewTextBoxColumn AutoIDColumn = new DataGridViewTextBoxColumn();
            AutoIDColumn.HeaderText = "AutoID"; AutoIDColumn.Name = "clnAutoID"; AutoIDColumn.Visible = false;
            AutoIDColumn.DataPropertyName = "AutoID"; AutoIDColumn.ReadOnly = true; AutoIDColumn.SortMode = DataGridViewColumnSortMode.NotSortable;

            DataGridViewTextBoxColumn PTypeColumn = new DataGridViewTextBoxColumn();
            PTypeColumn.HeaderText = "PType"; PTypeColumn.Name = "clnPType"; PTypeColumn.Visible = false;
            PTypeColumn.DataPropertyName = "PType"; PTypeColumn.ReadOnly = true; PTypeColumn.SortMode = DataGridViewColumnSortMode.NotSortable;

            DataGridViewTextBoxColumn SOColumn = new DataGridViewTextBoxColumn();
            SOColumn.HeaderText = "SO"; SOColumn.Name = "clnSO"; SOColumn.Visible = false;
            SOColumn.DataPropertyName = "SO"; SOColumn.ReadOnly = true;

            dataGridView.Columns.Clear();
            dataGridView.Columns.Add(dateColumn); dataGridView.Columns.Add(MRPTypeColumn); dataGridView.Columns.Add(MRPElementColumn);
            dataGridView.Columns.Add(reqQtyColumn); dataGridView.Columns.Add(AvaQtyColumn); dataGridView.Columns.Add(AutoIDColumn); dataGridView.Columns.Add(PTypeColumn);
            dataGridView.Columns.Add(SOColumn);

        }
        private void txtMatCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnMRP_Click(sender, e);
            }
        }
        private void frmMRPRunning_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoginSystem.frmMainMenu frm = ((LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"]);
            frm.menuStrip1.Enabled = true;
        }
    }
}
