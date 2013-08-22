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
    public partial class frmComponentRunning : Form
    {
        public frmComponentRunning()
        {
            InitializeComponent();
        }

        public DataSet MyCompView { get; set; }
        public DataSet MyCompRec { get; set; }
        public byte IsComp = 0;
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
        private double GetStockByFG(string FGCode)
        {
            try
            {
                string strTmp = "SELECT   (SELECT sum(isnull(UR,0) + isnull(QI,0)) FROM  t_StockOverview WHERE (MaterialCode = N'" + FGCode + "'))as SumURQI,  t_StockOverview.AutoID, t_StockOverview.MaterialCode, t_StockOverview.BatchNumber, ISNULL(t_StockOverview.UR, 0) + ISNULL(t_StockOverview.QI, 0) AS QI,  t_StockOverview.Block, t_StockOverview.UserCreate, t_StockOverview.DateCreate, t_StockOverview.UserChange, t_StockOverview.DateChange,  t_MRPBOM.RequireDate, t_MRPBOM.SONumber FROM         t_StockOverview LEFT OUTER JOIN  t_MRPBOM ON t_StockOverview.MaterialCode = t_MRPBOM.ComponentCode WHERE  (t_StockOverview.MaterialCode = N'" + FGCode + "') ORDER BY t_MRPBOM.RequireDate";
                DataSet dsTmp = new DataSet(); dsTmp = NP.GetClientDataSet(strTmp); double dMinus = 0;
                if (dsTmp.Tables[0].Rows.Count > 0)
                {
                    //for (int st = 0; st < dsTmp.Tables[0].Rows.Count; st++)
                    //{
                    //    if (dsTmp.Tables[0].Rows[st]["SONumber"].ToString().Trim() == SO)
                    //    {
                    //        return Convert.ToDouble(dsTmp.Tables[0].Rows[0]["QI"].ToString()) - dMinus;
                    //    }
                    //    else
                    //    {
                    //        dMinus += Convert.ToDouble(dsTmp.Tables[0].Rows[st]["QI"]);
                    //    }
                    //}
                    return Convert.ToDouble(dsTmp.Tables[0].Rows[0]["SumURQI"].ToString());
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
        private DataSet GetDS4DGV(DataSet ds)
        {
            ds = new DataSet();
            ds.Tables.Add(new DataTable("dt"));
            ds.Tables[0].Columns.Add(new DataColumn("ReqDate", typeof(System.String)));
            ds.Tables[0].Columns.Add(new DataColumn("MRPType", typeof(System.String)));
            ds.Tables[0].Columns.Add(new DataColumn("MRPElement", typeof(System.String)));
            ds.Tables[0].Columns.Add(new DataColumn("RequireQty", typeof(System.Decimal)));
            ds.Tables[0].Columns.Add(new DataColumn("AvailableQty", typeof(System.Decimal)));
            ds.Tables[0].Columns.Add(new DataColumn("AutoID", typeof(System.Int32)));
            ds.Tables[0].Columns.Add(new DataColumn("PType", typeof(System.String)));
            ds.Tables[0].Columns.Add(new DataColumn("SO", typeof(System.String)));
            ds.Tables[0].Columns.Add(new DataColumn("Unit", typeof(System.String)));
            ds.AcceptChanges();
            ds.AcceptChanges();
            return ds;
        }
        private void frmComponentRunning_Load(object sender, EventArgs e)
        {
            try
            {
                double dTmpStock = 0; double dTmpAva = 0;
                switch (this.IsComp)
                {
                    case 0: // FG
                        //+++++++++++++++++++++++++++++++++++++++++++++ FG
                        DataRow drFG; DataSet dsDep = new DataSet();
                        drFG = this.MyCompRec.Tables[0].Select("HeadBOMCode = '" + this.lblCompCodeName.Text.Trim() + "'")[0];
                        this.MyCompView = GetDS4DGV(this.MyCompView);

                        //TODO CompNew +++++++++++++++++++++++++++++++++++++++++++++

                        // Row 1 ================k
                        DataRow drTmp; drTmp = this.MyCompView.Tables[0].NewRow();
                        dTmpStock = GetStockByFG(drFG["HeadBOMCode"].ToString());
                        dTmpAva = dTmpStock;
                        drTmp["ReqDate"] = DateTime.Now.ToString("dd.MM.yyyy", new System.Globalization.CultureInfo("en-us"));
                        drTmp["MRPType"] = "Stock"; drTmp["MRPElement"] = string.Empty;
                        drTmp["RequireQty"] = DBNull.Value; drTmp["AvailableQty"] = dTmpStock; drTmp["SO"] = string.Empty;
                        this.MyCompView.Tables[0].Rows.Add(drTmp);
                        // Row 1 ==================

                        NP_Cls.SqlSelect = "SELECT  DISTINCT   t_MRPBOM.FGQty, t_MRPBOM.HeadBomCode, DATEADD(dd, 0, DATEDIFF(dd, 0, t_SO.SODate)) as LogDate, t_MRPBOM.SONumber, m_Material.MaterialName, m_Material.ProcurementType,   DATEADD(dd, 0, DATEDIFF(dd, 0, t_MRPBOM.RequireDate)) RequireDate, t_MRPTranOrder.TranOrder AS TranHeadOrder, ISNULL((select t_PrdOrder.PrdQuantity from t_PrdOrder where t_PrdOrder.MaterialCode = t_MRPBOM.HeadBomCode and t_PrdOrder.PrdONumber = t_MRPTranOrder.TranOrder),0) AS HTranQty, t_MRPBOM.FGUnitCode,isnull((select t_PrdOrder.IsPicking from t_PrdOrder where t_PrdOrder.PrdONumber = t_MRPTranOrder.TranOrder),0)IsPicking ,'S' as tbl FROM         t_MRPBOM LEFT OUTER JOIN  t_MRPTranOrder ON t_MRPBOM.SONumber = t_MRPTranOrder.SONumber AND t_MRPBOM.HeadBomCode = t_MRPTranOrder.MaterialCode LEFT OUTER JOIN  m_Material ON t_MRPBOM.FGCode = m_Material.MaterialCode  LEFT OUTER JOIN t_SO ON t_SO.SONumber = t_MRPBOM.SONumber WHERE   (t_MRPBOM.HeadBomCode = N'" + drFG["HeadBOMCode"].ToString() + "') AND (t_MRPBOM.ItemSeq = 1) UNION select PrdQuantity as FGQty,t_PrdOrder.MaterialCode as HeadBomCode,DATEADD(dd, 0, DATEDIFF(dd, 0, LogDate))LogDate,'' as SONumber,m_Material.MaterialName, m_Material.ProcurementType,DATEADD(dd, 0, DATEDIFF(dd, 0, LogDate)) as RequireDate,PrdONumber as TranHeadOrder,0 as HTranQty,m_Material.UnitCode as FGUnitCode,IsPicking	,'O' as tbl from t_PrdOrder LEFT OUTER JOIN m_Material ON t_PrdOrder.MaterialCode = m_Material.MaterialCode where (t_PrdOrder.MaterialCode = N'" + drFG["HeadBOMCode"].ToString() + "') AND OrderStatus is null AND ISGRPrd = 0 AND PrdONumber not in (SELECT Distinct [TranOrder] FROM [t_MRPTranOrder] where [MaterialHeader] = N'" + drFG["HeadBOMCode"].ToString() + "') order by RequireDate asc,tbl asc";
                        dsDep = new DataSet(); dsDep = NP.GetClientDataSet(NP_Cls.SqlSelect);
                        if (dsDep.Tables[0].Rows.Count > 0)
                        {
                            for (int fg = 0; fg < dsDep.Tables[0].Rows.Count; fg++)
                            {
                                //// Row 2 ==================
                                if (dsDep.Tables[0].Rows[fg]["tbl"].ToString() == "S")
                                {
                                    drTmp = this.MyCompView.Tables[0].NewRow();
                                    drTmp["ReqDate"] = Convert.ToDateTime(dsDep.Tables[0].Rows[fg]["RequireDate"]).ToString("dd.MM.yyyy", new System.Globalization.CultureInfo("en-us"));
                                    drTmp["MRPType"] = "SaleOrder";
                                    drTmp["MRPElement"] = dsDep.Tables[0].Rows[fg]["SONumber"].ToString();
                                    drTmp["RequireQty"] = -Convert.ToDouble(dsDep.Tables[0].Rows[fg]["FGQty"]);
                                    drTmp["AvailableQty"] = dTmpStock >= 0 ? dTmpStock - Convert.ToDouble(dsDep.Tables[0].Rows[fg]["FGQty"]) : -Convert.ToDouble(dsDep.Tables[0].Rows[fg]["FGQty"]);
                                    drTmp["SO"] = dsDep.Tables[0].Rows[fg]["SONumber"].ToString();
                                    drTmp["Unit"] = dsDep.Tables[0].Rows[fg]["FGUnitCode"].ToString();
                                    this.MyCompView.Tables[0].Rows.Add(drTmp);
                                    dTmpStock = (dTmpStock - Convert.ToDouble(dsDep.Tables[0].Rows[fg]["FGQty"]));

                                    if (dTmpStock > 0)
                                        continue;
                                }
                                //// Row 3 ==================

                                drTmp = this.MyCompView.Tables[0].NewRow();
                                drTmp["ReqDate"] = Convert.ToDateTime(dsDep.Tables[0].Rows[fg]["RequireDate"]).ToString("dd.MM.yyyy", new System.Globalization.CultureInfo("en-us"));
                                if (dsDep.Tables[0].Rows[fg]["ProcurementType"].ToString().Trim().ToUpper() == "F")
                                {
                                    if (dsDep.Tables[0].Rows[fg]["tbl"].ToString() == "S")
                                    {
                                        drTmp["MRPType"] = "Plan Order";
                                        drTmp["PType"] = dsDep.Tables[0].Rows[fg]["ProcurementType"].ToString().Trim().ToUpper();
                                    }
                                    else
                                    {
                                        drTmp["MRPType"] = "Plan Order : Outside Processing";
                                        drTmp["PType"] = dsDep.Tables[0].Rows[fg]["ProcurementType"].ToString().Trim().ToUpper();
                                    }
                                }
                                else
                                {
                                    if (dsDep.Tables[0].Rows[fg]["tbl"].ToString() == "S")
                                    {
                                        drTmp["MRPType"] = "Prd Order";
                                        drTmp["PType"] = dsDep.Tables[0].Rows[fg]["ProcurementType"].ToString().Trim().ToUpper();
                                    }
                                    else
                                    {
                                        drTmp["MRPType"] = "Prd Order : Outside Processing";
                                        drTmp["PType"] = dsDep.Tables[0].Rows[fg]["ProcurementType"].ToString().Trim().ToUpper();
                                    }
                                }
                                if (dsDep.Tables[0].Rows[fg]["IsPicking"].ToString().Trim() == "True")
                                    drTmp["MRPElement"] = (dsDep.Tables[0].Rows[fg]["TranHeadOrder"].ToString().Trim()) + " : Already Picking";
                                else
                                    drTmp["MRPElement"] = (dsDep.Tables[0].Rows[fg]["TranHeadOrder"].ToString().Trim());
                                if (dsDep.Tables[0].Rows[fg]["tbl"].ToString() == "S")
                                {
                                    if (Convert.ToInt32(dsDep.Tables[0].Rows[fg]["HTranQty"]) > 0)
                                    {
                                        drTmp["RequireQty"] = (dsDep.Tables[0].Rows[fg]["HTranQty"].ToString().Trim());
                                        drTmp["AvailableQty"] = Convert.ToDouble(dsDep.Tables[0].Rows[fg]["HTranQty"].ToString().Trim()) + dTmpStock;
                                        dTmpStock = Convert.ToDouble(dsDep.Tables[0].Rows[fg]["HTranQty"].ToString().Trim()) + dTmpStock;
                                    }
                                    else
                                    {
                                        drTmp["RequireQty"] = Math.Abs(dTmpStock);
                                        drTmp["AvailableQty"] = 0;
                                        dTmpStock = 0;
                                    }
                                }
                                else
                                {
                                    drTmp["RequireQty"] = (dsDep.Tables[0].Rows[fg]["FGQty"].ToString().Trim());
                                    drTmp["AvailableQty"] = Convert.ToDouble(dsDep.Tables[0].Rows[fg]["FGQty"].ToString().Trim()) + dTmpStock;
                                    dTmpStock = Convert.ToDouble(dsDep.Tables[0].Rows[fg]["FGQty"].ToString().Trim()) + dTmpStock;
                                }

                                drTmp["SO"] = dsDep.Tables[0].Rows[fg]["SONumber"].ToString();
                                drTmp["Unit"] = dsDep.Tables[0].Rows[fg]["FGUnitCode"].ToString();
                                this.MyCompView.Tables[0].Rows.Add(drTmp);
                            }
                        }

                        // Row 2 ====

                        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        break;
                    // **********************************************************************************************************************

                    #region Case Component
                    case 1: // Component
                        // +++++++++++++++++++++++++++++++++++++++++++++  Component
                        DataRow drComp;
                        drComp = this.MyCompRec.Tables[0].Select("ComponentCode = '" + this.lblCompCodeName.Text.Trim() + "'")[0];
                        this.MyCompView = GetDS4DGV(this.MyCompView);


                        //TODO CompNew +++++++++++++++++++++++++++++++++++++++++++++

                        // Row 1 ================
                        drTmp = this.MyCompView.Tables[0].NewRow();
                        dTmpStock = GetStockByFG(drComp["ComponentCode"].ToString());
                        drTmp["ReqDate"] = DateTime.Now.ToString("dd.MM.yyyy", new System.Globalization.CultureInfo("en-us"));
                        drTmp["MRPType"] = "Stock";
                        drTmp["MRPElement"] = string.Empty;
                        drTmp["RequireQty"] = DBNull.Value;
                        drTmp["AvailableQty"] = dTmpStock;
                        drTmp["SO"] = string.Empty;
                        this.MyCompView.Tables[0].Rows.Add(drTmp);
                        // Row 1 ==================

                        // Row 2 ==================
                        //NP_Cls.SqlSelect = "SELECT DISTINCT 'S' as tbl,DATEADD(dd, 0, DATEDIFF(dd, 0, t_SO.SODate)) as LogDate, t_MRPBOM.HeadBomCode, CAST(ROUND((t_MRPBOM.ComponentQty / isnull(t_VendorInfoRecord.QtyConversion,1)),3)as Decimal(18,3)) as ComponentQty, DATEADD(dd, 0, DATEDIFF(dd, 0, t_MRPBOM.RequireDate))RequireDate, t_MRPBOM.ComponentCode, t_MRPBOM.SONumber,   CAST(ROUND((isnull(t_MRPTranOrder.TranQty, 0) / isnull(t_VendorInfoRecord.QtyConversion,1)),3)as Decimal(18,3)) as TranQty,  t_MRPTranOrder.TranOrder, isnull(t_VendorInfoRecord.UnitCode,t_MRPBOM.ComponentUnitCode)AS ComponentUnitCode, t_MRPTranOrder.IsCompleted ,t_MRPBOM.ProcurementType FROM   t_MRPBOM LEFT OUTER Join t_SO on t_MRPBOM.SONumber = t_SO.SONumber LEFT OUTER JOIN t_VendorInfoRecord ON t_VendorInfoRecord.MaterialCode = t_MRPBOM.ComponentCode LEFT OUTER JOIN  t_MRPTranOrder ON t_MRPBOM.ComponentCode = t_MRPTranOrder.MaterialCode AND t_MRPBOM.SONumber = t_MRPTranOrder.SONumber  WHERE     (t_MRPBOM.ComponentCode = N'" + drComp["ComponentCode"] + "') UNION SELECT DISTINCT 'Prd' as tbl,DATEADD(dd, 0, DATEDIFF(dd, 0, LogDate)) as LogDate,'' as HeadBomCode,PrdQuantity as ComponentQty,DATEADD(dd, 0, DATEDIFF(dd, 0, LogDate)) as RequireDate,t_PrdOrder.MaterialCode as ComponentCode,'' as SONumber,0 as TranQty,PrdONumber as TranOrder,m_Material.UnitCode as ComponentUnitCode,IsPicking as IsCompleted, m_Material.ProcurementType	FROM t_PrdOrder LEFT OUTER JOIN m_Material ON t_PrdOrder.MaterialCode = m_Material.MaterialCode WHERE (t_PrdOrder.MaterialCode = N'" + drComp["ComponentCode"] + "') AND OrderStatus is null AND ISGRPrd = 0 AND PrdONumber not in (SELECT Distinct [TranOrder] FROM [t_MRPTranOrder] where [MaterialHeader] = N'" + drComp["ComponentCode"] + "') UNION SELECT DISTINCT 'Pr' as tbl,DATEADD(dd, 0, DATEDIFF(dd, 0, LogDate)) as LogDate,'' as HeadBomCode,PRQuantity as ComponentQty,DATEADD(dd, 0, DATEDIFF(dd, 0, LogDate)) as RequireDate,t_PRDetail.MaterialCode as ComponentCode,'' as SONumber,0 as TranQty,t_PRDetail.PRNumber as TranOrder,m_Material.UnitCode as ComponentUnitCode,PRApprove as IsCompleted, m_Material.ProcurementType from t_PRDetail inner join t_PR on t_PR.PRNumber = t_PRDetail.PRNumber LEFT OUTER JOIN m_Material ON t_PRDetail.MaterialCode = m_Material.MaterialCode where t_PRDetail.MaterialCode = N'" + drComp["ComponentCode"] + "' and isPO = 0 AND t_PRDetail.PRNumber not in (SELECT Distinct [TranOrder] FROM [t_MRPTranOrder] where [MaterialHeader] = N'" + drComp["ComponentCode"] + "') UNION SELECT DISTINCT 'Po' as tbl,DATEADD(dd, 0, DATEDIFF(dd, 0, t_PODetail.LogDate)) as LogDate,'' as HeadBomCode,POQuantity as ComponentQty,DATEADD(dd, 0, DATEDIFF(dd, 0, t_PODetail.LogDate)) as RequireDate,t_PODetail.MaterialCode as ComponentCode,'' as SONumber,0 as TranQty,t_PODetail.PONumber as TranOrder,m_Material.UnitCode as ComponentUnitCode, POApprove as IsCompleted  , m_Material.ProcurementType from t_PODetail inner join t_PO on t_PO.PONumber = t_PODetail.PONumber LEFT OUTER JOIN m_Material ON t_PODetail.MaterialCode = m_Material.MaterialCode where t_PODetail.MaterialCode = N'" + drComp["ComponentCode"] + "' and  isnull(ClosePO,'A') <> 'C' AND t_PODetail.PONumber not in (SELECT Distinct [TranOrder] FROM [t_MRPTranOrder] where [MaterialHeader] = N'" + drComp["ComponentCode"] + "') ORDER BY RequireDate asc,tbl asc";
                        NP_Cls.SqlSelect = "SELECT DISTINCT                        'S' AS tbl, DATEADD(dd, 0, DATEDIFF(dd, 0, t_SO.SODate)) AS LogDate, t_MRPBOM.HeadBomCode,                        CAST(ROUND(t_MRPBOM.ComponentQty / ISNULL(t_VendorInfoRecord.QtyConversion, 1), 3) AS Decimal(18, 3)) AS ComponentQty, DATEADD(dd, 0,                        DATEDIFF(dd, 0, t_MRPBOM.RequireDate)) AS RequireDate, t_MRPBOM.ComponentCode, t_MRPBOM.SONumber,                        CAST(ROUND(ISNULL(t_MRPTranOrder.TranQty, 0) / ISNULL(t_VendorInfoRecord.QtyConversion, 1), 3) AS Decimal(18, 3)) AS TranQty,                        t_MRPTranOrder.TranOrder, ISNULL(t_VendorInfoRecord.UnitCode, t_MRPBOM.ComponentUnitCode) AS ComponentUnitCode,                        t_MRPTranOrder.IsCompleted, t_MRPBOM.ProcurementType, t_MRPBOM.AutoID FROM         t_MRPBOM LEFT OUTER JOIN                       t_MRPTranOrder ON t_MRPBOM.AutoID = t_MRPTranOrder.MRPID AND t_MRPBOM.ComponentCode = t_MRPTranOrder.MaterialCode AND                        t_MRPBOM.SONumber = t_MRPTranOrder.SONumber LEFT OUTER JOIN                       t_SO ON t_MRPBOM.SONumber = t_SO.SONumber LEFT OUTER JOIN                       t_VendorInfoRecord ON t_VendorInfoRecord.MaterialCode = t_MRPBOM.ComponentCode WHERE     (t_MRPBOM.ComponentCode = N'" + drComp["ComponentCode"] + "') UNION SELECT DISTINCT                        'Prd' AS tbl, DATEADD(dd, 0, DATEDIFF(dd, 0, t_PrdOrder.LogDate)) AS LogDate, '' AS HeadBomCode, t_PrdOrder.PrdQuantity AS ComponentQty,                        DATEADD(dd, 0, DATEDIFF(dd, 0, t_PrdOrder.LogDate)) AS RequireDate, t_PrdOrder.MaterialCode AS ComponentCode, '' AS SONumber, 0 AS TranQty,                        t_PrdOrder.PrdONumber AS TranOrder, m_Material.UnitCode AS ComponentUnitCode, t_PrdOrder.IsPicking AS IsCompleted,                        m_Material.ProcurementType, '' AS AutoID FROM         t_PrdOrder LEFT OUTER JOIN                       m_Material ON t_PrdOrder.MaterialCode = m_Material.MaterialCode WHERE     (t_PrdOrder.MaterialCode = N'" + drComp["ComponentCode"] + "') AND (t_PrdOrder.OrderStatus IS NULL) AND (t_PrdOrder.ISGRPrd = 0) AND                        (t_PrdOrder.PrdONumber NOT IN                           (SELECT DISTINCT TranOrder                             FROM          t_MRPTranOrder AS t_MRPTranOrder_3                             WHERE      (MaterialHeader = N'" + drComp["ComponentCode"] + "'))) UNION SELECT DISTINCT                        'Pr' AS tbl, DATEADD(dd, 0, DATEDIFF(dd, 0, t_PRDetail.LogDate)) AS LogDate, '' AS HeadBomCode, t_PRDetail.PRQuantity AS ComponentQty,                        DATEADD(dd, 0, DATEDIFF(dd, 0, t_PRDetail.LogDate)) AS RequireDate, t_PRDetail.MaterialCode AS ComponentCode, '' AS SONumber, 0 AS TranQty,                        t_PRDetail.PRNumber AS TranOrder, m_Material_2.UnitCode AS ComponentUnitCode, t_PR.PRApprove AS IsCompleted,                        m_Material_2.ProcurementType, '' AS AutoID FROM         t_PRDetail INNER JOIN                       t_PR ON t_PR.PRNumber = t_PRDetail.PRNumber LEFT OUTER JOIN                       m_Material AS m_Material_2 ON t_PRDetail.MaterialCode = m_Material_2.MaterialCode WHERE     (t_PRDetail.MaterialCode = N'" + drComp["ComponentCode"] + "') AND (t_PRDetail.isPO = 0) AND (t_PRDetail.PRNumber NOT IN                           (SELECT DISTINCT TranOrder                             FROM          t_MRPTranOrder AS t_MRPTranOrder_2                             WHERE      (MaterialHeader = N'" + drComp["ComponentCode"] + "'))) UNION SELECT DISTINCT                        'Po' AS tbl, DATEADD(dd, 0, DATEDIFF(dd, 0, t_PODetail.LogDate)) AS LogDate, '' AS HeadBomCode, t_PODetail.POQuantity AS ComponentQty,                        DATEADD(dd, 0, DATEDIFF(dd, 0, t_PODetail.LogDate)) AS RequireDate, t_PODetail.MaterialCode AS ComponentCode, '' AS SONumber, 0 AS TranQty,                        t_PODetail.PONumber AS TranOrder, m_Material_1.UnitCode AS ComponentUnitCode, t_PO.POApprove AS IsCompleted,                        m_Material_1.ProcurementType, '' AS AutoID FROM         t_PODetail INNER JOIN                       t_PO ON t_PO.PONumber = t_PODetail.PONumber LEFT OUTER JOIN                       m_Material AS m_Material_1 ON t_PODetail.MaterialCode = m_Material_1.MaterialCode WHERE     (t_PODetail.MaterialCode = N'" + drComp["ComponentCode"] + "') AND (ISNULL(t_PO.ClosePO, N'A') <> 'C') AND (t_PODetail.PONumber NOT IN                           (SELECT DISTINCT TranOrder                             FROM          t_MRPTranOrder AS t_MRPTranOrder_1                             WHERE      (MaterialHeader = N'" + drComp["ComponentCode"] + "'))) ORDER BY RequireDate, tbl";
                        dsDep = new DataSet(); dsDep = NP.GetClientDataSet(NP_Cls.SqlSelect);
                        if (dsDep.Tables[0].Rows.Count > 0)
                        {
                            List<String> tmpTest = new List<string>(); int dupID = 0;
                            for (int dep = 0; dep < dsDep.Tables[0].Rows.Count; dep++)
                            {

                                if (dupID == int.Parse(dsDep.Tables[0].Rows[dep]["AutoID"].ToString()))
                                {
                                    //Row 3
                                    DataRow drDepD;
                                    drDepD = this.MyCompView.Tables[0].NewRow();
                                    drDepD["ReqDate"] = Convert.ToDateTime(dsDep.Tables[0].Rows[dep]["RequireDate"]).ToString("dd.MM.yyyy", new System.Globalization.CultureInfo("en-us"));
                                    if (dsDep.Tables[0].Rows[dep]["tbl"].ToString() == "S")
                                    {
                                        if (Convert.ToInt32(dsDep.Tables[0].Rows[dep]["TranQty"]) > 0)
                                        {
                                            drDepD["RequireQty"] = (dsDep.Tables[0].Rows[dep]["TranQty"].ToString().Trim());
                                            drDepD["AvailableQty"] = Convert.ToDouble(dsDep.Tables[0].Rows[dep]["TranQty"].ToString().Trim()) + dTmpStock;
                                            dTmpStock = Convert.ToDouble(dsDep.Tables[0].Rows[dep]["TranQty"].ToString().Trim()) + dTmpStock;
                                        }
                                        else
                                        {
                                            drDepD["RequireQty"] = Math.Abs(dTmpStock);
                                            drDepD["AvailableQty"] = 0;
                                            dTmpStock = 0;
                                        }
                                    }
                                    else
                                    {
                                        drDepD["RequireQty"] = (dsDep.Tables[0].Rows[dep]["ComponentQty"].ToString().Trim());
                                        drDepD["AvailableQty"] = Convert.ToDouble(dsDep.Tables[0].Rows[dep]["ComponentQty"].ToString().Trim()) + dTmpStock;
                                        dTmpStock = Convert.ToDouble(dsDep.Tables[0].Rows[dep]["ComponentQty"].ToString().Trim()) + dTmpStock;
                                    }
                                    if (dsDep.Tables[0].Rows[dep]["ProcurementType"].ToString().Trim().ToUpper() == "F")
                                    {
                                        if (dsDep.Tables[0].Rows[dep]["tbl"].ToString() == "S")
                                        {
                                            drDepD["MRPType"] = "Plan Order";
                                            drDepD["PType"] = dsDep.Tables[0].Rows[dep]["ProcurementType"].ToString().Trim().ToUpper();
                                        }
                                        else
                                        {
                                            drDepD["MRPType"] = "Plan Order : Outside Processing";
                                            drDepD["PType"] = dsDep.Tables[0].Rows[dep]["ProcurementType"].ToString().Trim().ToUpper();
                                        }
                                    }
                                    else
                                    {
                                        if (dsDep.Tables[0].Rows[dep]["tbl"].ToString() == "S")
                                        {
                                            drDepD["MRPType"] = "Prd Order";
                                            drDepD["PType"] = dsDep.Tables[0].Rows[dep]["ProcurementType"].ToString().Trim().ToUpper();
                                        }
                                        else
                                        {
                                            drDepD["MRPType"] = "Prd Order : Outside Processing";
                                            drDepD["PType"] = dsDep.Tables[0].Rows[dep]["ProcurementType"].ToString().Trim().ToUpper();
                                        }
                                    }

                                    drDepD["MRPElement"] = dsDep.Tables[0].Rows[dep]["TranOrder"].ToString().Trim();
                                    if (dsDep.Tables[0].Rows[dep]["IsCompleted"].ToString() == "True")
                                    {
                                        if (dsDep.Tables[0].Rows[dep]["tbl"].ToString() == "Prd")
                                            drDepD["MRPElement"] = (dsDep.Tables[0].Rows[dep]["TranOrder"].ToString().Trim()) + " : Already Picking";
                                        else
                                            drDepD["MRPElement"] = (dsDep.Tables[0].Rows[dep]["TranOrder"].ToString().Trim()) + " : Already Approved";
                                    }

                                    drDepD["SO"] = dsDep.Tables[0].Rows[dep]["SONumber"].ToString();
                                    drDepD["Unit"] = dsDep.Tables[0].Rows[dep]["ComponentUnitCode"].ToString();
                                    drDepD["AutoID"] = dsDep.Tables[0].Rows[dep]["AutoID"].ToString();
                                    dupID = int.Parse(dsDep.Tables[0].Rows[dep]["AutoID"].ToString());
                                    this.MyCompView.Tables[0].Rows.Add(drDepD);
                                    continue;
                                }

                                DataRow drDep;
                                if (dsDep.Tables[0].Rows[dep]["tbl"].ToString() == "S")
                                {
                                    drDep = this.MyCompView.Tables[0].NewRow();
                                    drDep["ReqDate"] = Convert.ToDateTime(dsDep.Tables[0].Rows[dep]["RequireDate"]).ToString("dd.MM.yyyy", new System.Globalization.CultureInfo("en-us"));
                                    drDep["MRPType"] = "DepReq:" + dsDep.Tables[0].Rows[dep]["HeadBOMCode"].ToString();
                                    drDep["MRPElement"] = dsDep.Tables[0].Rows[dep]["SONumber"].ToString();
                                    drDep["RequireQty"] = -Convert.ToDouble(dsDep.Tables[0].Rows[dep]["ComponentQty"]);
                                    drDep["AvailableQty"] = dTmpStock - Convert.ToDouble(dsDep.Tables[0].Rows[dep]["ComponentQty"]);
                                    drDep["SO"] = dsDep.Tables[0].Rows[dep]["SONumber"].ToString();
                                    drDep["Unit"] = dsDep.Tables[0].Rows[dep]["ComponentUnitCode"].ToString();
                                    drDep["AutoID"] = dsDep.Tables[0].Rows[dep]["AutoID"].ToString();
                                    this.MyCompView.Tables[0].Rows.Add(drDep);
                                    dTmpStock = dTmpStock - Convert.ToDouble(dsDep.Tables[0].Rows[dep]["ComponentQty"]);

                                    if (dTmpStock > 0)
                                        continue;


                                    //if (tmpTest.Contains(dsDep.Tables[0].Rows[dep]["TranOrder"].ToString().Trim()))
                                    //    continue;
                                    //else
                                    //    tmpTest.Add(dsDep.Tables[0].Rows[dep]["TranOrder"].ToString().Trim());
                                }

                                //Row 3
                                drDep = this.MyCompView.Tables[0].NewRow();
                                drDep["ReqDate"] = Convert.ToDateTime(dsDep.Tables[0].Rows[dep]["RequireDate"]).ToString("dd.MM.yyyy", new System.Globalization.CultureInfo("en-us"));
                                if (dsDep.Tables[0].Rows[dep]["tbl"].ToString() == "S")
                                {
                                    if (Convert.ToInt32(dsDep.Tables[0].Rows[dep]["TranQty"]) > 0)
                                    {
                                        drDep["RequireQty"] = (dsDep.Tables[0].Rows[dep]["TranQty"].ToString().Trim());
                                        drDep["AvailableQty"] = Convert.ToDouble(dsDep.Tables[0].Rows[dep]["TranQty"].ToString().Trim()) + dTmpStock;
                                        dTmpStock = Convert.ToDouble(dsDep.Tables[0].Rows[dep]["TranQty"].ToString().Trim()) + dTmpStock;
                                    }
                                    else
                                    {
                                        drDep["RequireQty"] = Math.Abs(dTmpStock);
                                        drDep["AvailableQty"] = 0;
                                        dTmpStock = 0;
                                    }
                                }
                                else
                                {
                                    drDep["RequireQty"] = (dsDep.Tables[0].Rows[dep]["ComponentQty"].ToString().Trim());
                                    drDep["AvailableQty"] = Convert.ToDouble(dsDep.Tables[0].Rows[dep]["ComponentQty"].ToString().Trim()) + dTmpStock;
                                    dTmpStock = Convert.ToDouble(dsDep.Tables[0].Rows[dep]["ComponentQty"].ToString().Trim()) + dTmpStock;
                                }
                                if (dsDep.Tables[0].Rows[dep]["ProcurementType"].ToString().Trim().ToUpper() == "F")
                                {
                                    if (dsDep.Tables[0].Rows[dep]["tbl"].ToString() == "S")
                                    {
                                        drDep["MRPType"] = "Plan Order";
                                        drDep["PType"] = dsDep.Tables[0].Rows[dep]["ProcurementType"].ToString().Trim().ToUpper();
                                    }
                                    else
                                    {
                                        drDep["MRPType"] = "Plan Order : Outside Processing";
                                        drDep["PType"] = dsDep.Tables[0].Rows[dep]["ProcurementType"].ToString().Trim().ToUpper();
                                    }
                                }
                                else
                                {
                                    if (dsDep.Tables[0].Rows[dep]["tbl"].ToString() == "S")
                                    {
                                        drDep["MRPType"] = "Prd Order";
                                        drDep["PType"] = dsDep.Tables[0].Rows[dep]["ProcurementType"].ToString().Trim().ToUpper();
                                    }
                                    else
                                    {
                                        drDep["MRPType"] = "Prd Order : Outside Processing";
                                        drDep["PType"] = dsDep.Tables[0].Rows[dep]["ProcurementType"].ToString().Trim().ToUpper();
                                    }
                                }

                                drDep["MRPElement"] = dsDep.Tables[0].Rows[dep]["TranOrder"].ToString().Trim();
                                if (dsDep.Tables[0].Rows[dep]["IsCompleted"].ToString() == "True")
                                {
                                    if (dsDep.Tables[0].Rows[dep]["tbl"].ToString() == "Prd")
                                        drDep["MRPElement"] = (dsDep.Tables[0].Rows[dep]["TranOrder"].ToString().Trim()) + " : Already Picking";
                                    else
                                        drDep["MRPElement"] = (dsDep.Tables[0].Rows[dep]["TranOrder"].ToString().Trim()) + " : Already Approved";
                                }

                                drDep["SO"] = dsDep.Tables[0].Rows[dep]["SONumber"].ToString();
                                drDep["Unit"] = dsDep.Tables[0].Rows[dep]["ComponentUnitCode"].ToString();
                                drDep["AutoID"] = dsDep.Tables[0].Rows[dep]["AutoID"].ToString();
                                dupID = int.Parse(dsDep.Tables[0].Rows[dep]["AutoID"].ToString());
                                this.MyCompView.Tables[0].Rows.Add(drDep);
                            }
                        }
                        // Row 2 ==================

                        break;
                    #endregion

                }
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.ErrorType, "Error : " + ex.Message);
                return;
            }

            this.dataGridView1.DataSource = this.MyCompView.Tables[0];
            this.dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((sender as DataGridView).Columns[e.ColumnIndex].Name == "clnMRPType")
            {
                if (e.Value != null)
                {
                    if ((e.Value.ToString() == "Prd Order") || (e.Value.ToString() == "Plan Order"))
                    {
                        if (!string.IsNullOrEmpty((sender as DataGridView).Rows[e.RowIndex].Cells["clnMRPElement"].Value.ToString()))
                        {
                            e.CellStyle.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            e.CellStyle.BackColor = Color.OrangeRed;
                        }

                        if (Convert.ToDouble((sender as DataGridView).Rows[e.RowIndex - 1].Cells["clnAvaQty"].Value) > 0)
                        {
                            e.CellStyle.BackColor = Color.LightGreen;
                        }
                    }
                    if ((e.Value.ToString() == "Prd Order : Outside Processing") || (e.Value.ToString() == "Plan Order : Outside Processing"))
                    {
                        if (!string.IsNullOrEmpty((sender as DataGridView).Rows[e.RowIndex].Cells["clnMRPElement"].Value.ToString()))
                        {
                            e.CellStyle.BackColor = Color.Navy;
                            e.CellStyle.ForeColor = Color.White;
                        }
                    }
                }
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if ((sender as DataGridView).RowCount == 0) { return; }
                if (!string.IsNullOrEmpty((sender as DataGridView).Rows[e.RowIndex].Cells["clnMRPElement"].Value.ToString()))
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "This Material Code already order !!"); return;
                }
                if ((sender as DataGridView).SelectedRows[0].Cells["clnMRPType"].Value.ToString() == "Prd Order")
                {
                    //24julyFix
                    //if (Convert.ToDouble((sender as DataGridView).SelectedRows[0].Cells["clnReqQty"].Value) == 0)
                    if (string.IsNullOrEmpty((sender as DataGridView).SelectedRows[0].Cells["clnMRPElement"].Value.ToString()))
                    {
                        string strTmp = string.Empty;
                        strTmp = this.lblCompCodeName.Text.Trim(); NP_Cls.MRPSO = (sender as DataGridView).SelectedRows[0].Cells["clnSO"].Value.ToString();
                        if (NP.MSGB("Do you want to open Prd Order : '" + strTmp + "' ?") == DialogResult.Yes)
                        {
                            NP_Cls.FromMRP = 1; NP_Cls.MRPFGSort = strTmp;
                            NP_Cls.MRPQty = (Convert.ToDouble((sender as DataGridView).SelectedRows[0].Cells["clnAvaQty"].Value) < 0 ? -Convert.ToDouble((sender as DataGridView).SelectedRows[0].Cells["clnAvaQty"].Value) : Convert.ToDouble((sender as DataGridView).SelectedRows[0].Cells["clnAvaQty"].Value));
                            //(Convert.ToDouble((sender as DataGridView).SelectedRows[0].Cells["clnAvaQty"].Value) < 0 ? -Convert.ToDouble((sender as DataGridView).SelectedRows[0].Cells["clnReqQty"].Value) : Convert.ToDouble((sender as DataGridView).SelectedRows[0].Cells["clnReqQty"].Value));
                            SaleTranSac.frmPrdOrder frm = new WMS.SaleTranSac.frmPrdOrder();
                            frm.StartPosition = FormStartPosition.CenterParent; frm.Width = 970; frm.Height = 500; frm.FormBorderStyle = FormBorderStyle.Sizable; frm.ControlBox = true;
                            frm.ShowDialog();
                            NP_Cls.FromMRP = 0;
                            this.frmComponentRunning_Load(sender, e); return;
                        }
                        else
                        {
                            return;
                        }
                    }
                }

                if ((sender as DataGridView).SelectedRows[0].Cells["clnMRPType"].Value.ToString() == "Plan Order")
                {
                    //24julyFix
                    //if (Convert.ToDouble((sender as DataGridView).SelectedRows[0].Cells["clnReqQty"].Value) == 0)
                    if (string.IsNullOrEmpty((sender as DataGridView).SelectedRows[0].Cells["clnMRPElement"].Value.ToString()))
                    {
                        string strTmp = string.Empty;
                        strTmp = this.lblCompCodeName.Text.Trim(); NP_Cls.MRPSO = (sender as DataGridView).SelectedRows[0].Cells["clnSO"].Value.ToString();
                        if (NP.MSGB("Do you want to open Plan Pr : '" + strTmp + "' ?") == DialogResult.Yes)
                        {
                            NP_Cls.FromMRP = 1; NP_Cls.MRPFGSort = strTmp; NP_Cls.nAutoID = (sender as DataGridView).SelectedRows[0].Cells["clnAutoID"].Value.ToString();
                            NP_Cls.MRPQty = (Convert.ToDouble((sender as DataGridView).SelectedRows[0].Cells["clnAvaQty"].Value) < 0 ? -Convert.ToDouble((sender as DataGridView).SelectedRows[0].Cells["clnAvaQty"].Value) : Convert.ToDouble((sender as DataGridView).SelectedRows[0].Cells["clnAvaQty"].Value));
                            PR_PO.frmPR frm = new WMS.PR_PO.frmPR();
                            frm.StartPosition = FormStartPosition.CenterParent; frm.FormBorderStyle = FormBorderStyle.Sizable; frm.Width = 970; frm.Height = 500; frm.ControlBox = true;
                            frm.ShowDialog();
                            NP_Cls.FromMRP = 0; NP_Cls.nAutoID = string.Empty;
                            this.frmComponentRunning_Load(sender, e); return;
                        }
                        else
                        {
                            return;
                        }
                    }
                }

            }
            catch
            { }


        }
    }
}
