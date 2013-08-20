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
    public partial class frmMRPRunningNew : Form
    {
        public frmMRPRunningNew()
        {
            InitializeComponent();
            this.dRealComReq = 0;
        }

        public DataSet MyGridSet { get; set; }
        public DataSet MyCompSend { get; set; }
        public DataSet MyTmpView { get; set; }
        public byte MyAtFirstRow { get; set; }
        private Hashtable hsTmp = new Hashtable(); byte intTmp = 0; private double dRealComReq = 0;
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection(); 

        private void btnExit_Click(object sender, EventArgs e)
        {
            //if (NP.MSGB("Do you want to exit this screen ?") == DialogResult.Yes)
            //{
            //    this.Close();
            //}
            //else
            //{
            //    return;
            //}
            this.Close();
        }
        private void frmMRPRunningNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoginSystem.frmMainMenu frm = ((LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"]);
            frm.menuStrip1.Enabled = true;
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

                //TODO+++++++++++++++++ New 24-09 MRP Running
                NP_Cls.SqlSelect = "SELECT t_SODetail.SONumber AS SONumber, t_SODetail.MaterialCode, t_SODetail.SOQuantity AS SOQuantity, t_SODetail.UnitCode, t_SODetail.DeliveryDate  AS DeliveryDate FROM         t_SODetail INNER JOIN t_SO ON t_SODetail.SONumber = t_SO.SONumber WHERE     (t_SO.SOApprove = 1) AND (t_SODetail.MaterialCode = N'" + this.txtMatCode.Text.Trim() + "') ";
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
                        cmdUp.Parameters["@SONumber"].Value = dsFBom.Tables[0].Rows[i]["SONumber"].ToString();
                        GenBOMNCate(dsFBom, i, dsFBom.Tables[0].Rows[i]["MaterialCode"].ToString(), cmdUp, oConn, Tr, Convert.ToDateTime(dsFBom.Tables[0].Rows[i]["DeliveryDate"]),1);
                    }
                    Tr.Commit();
                }
                else
                { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found , please check !!"); this.txtMatCode.Select(); this.txtMatCode.SelectAll(); return; }
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Create MRP 1 : " + ex.Message); return;
            }
            finally
            {
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
            }
            //End of create MRP Running from SO 

            //TODO+++++++++++++++++++ MRP Tran Order 24.09
            if (oConn.State == ConnectionState.Open) { oConn.Close(); }
            oConn.Open();
            Tr = oConn.BeginTransaction();
            cmdUp = new SqlCommand();
            try
            {
                NP_Cls.SqlSelect = "SELECT   t_BOMDetail.MaterialCode AS CompCode FROM t_BOM INNER JOIN t_BOMDetail ON t_BOM.BOMCode = t_BOMDetail.BOMCode WHERE  (t_BOM.MaterialCode = N'" + this.txtMatCode.Text.Trim() + "')";
                DataSet dsComp = new DataSet(); dsComp = NP.GetDataWithTran(NP_Cls.SqlSelect, Tr, oConn);
                for (int cp = 0; cp < dsComp.Tables[0].Rows.Count; cp++)
                {
                    NP_Cls.SqlSelect = "SELECT     t_PRDetail.PRQuantity, ISNULL(t_PODetail.POQuantity, 0) AS POQuantity, ISNULL(t_PODetail.GRQuantity, 0) AS GRQuantity, t_PRDetail.MaterialCode,  t_PRDetail.MaterialName, t_PRDetail.PRNumber, t_PODetail.PONumber FROM  t_PRDetail LEFT OUTER JOIN  t_PO RIGHT OUTER JOIN  t_PODetail ON t_PO.PONumber = t_PODetail.PONumber ON t_PRDetail.PRNumber = t_PODetail.PRNumber AND        t_PRDetail.MaterialCode = t_PODetail.MaterialCode WHERE   (t_PRDetail.MaterialCode = N'" + dsComp.Tables[0].Rows[cp]["CompCode"].ToString() + "')";
                    DataSet dsFBom = new DataSet(); dsFBom = NP.GetDataWithTran(NP_Cls.SqlSelect, Tr, oConn);
                    if (dsFBom.Tables[0].Rows.Count > 0)
                    {
                        //NP_Cls.SqlSelect = "SELECT ISNULL(SUM(ComponentQty),0) AS SumQtyNeed FROM t_MRPBOM WHERE (ComponentCode = N'" + dsComp.Tables[0].Rows[cp]["CompCode"].ToString() + "')";
                        //decimal dSumNeed = Convert.ToDecimal(NP.GetDataWithTran(NP_Cls.SqlSelect, Tr, oConn).Tables[0].Rows[0][0]);
                        for (int mr = 0; mr < dsFBom.Tables[0].Rows.Count; mr++)
                        {
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
                            if (dsFBom.Tables[0].Rows[mr]["PONumber"].ToString() == string.Empty)
                            {
                                NP_Cls.SqlInsert = "UPDATE t_MRPTranOrder " +
               "SET  TranQty = @TranQty, MaterialHeader = @MaterialHeader " +
        "WHERE (MaterialCode = @MaterialCode) AND (TranOrder = @TranOrder)";
                                cmdUp.Parameters["@MaterialCode"].Value = dsFBom.Tables[0].Rows[mr]["MaterialCode"].ToString();
                                cmdUp.Parameters["@SONumber"].Value = string.Empty;
                                cmdUp.Parameters["@TranOrder"].Value = dsFBom.Tables[0].Rows[mr]["PRNumber"].ToString();
                                if (Convert.ToDecimal(dsFBom.Tables[0].Rows[mr]["POQuantity"].ToString()) == 0)
                                {
                                    cmdUp.Parameters["@TranQty"].Value = Convert.ToDecimal(dsFBom.Tables[0].Rows[mr]["PRQuantity"].ToString());
                                }
                                else if (Convert.ToDecimal(dsFBom.Tables[0].Rows[mr]["GRQuantity"].ToString()) == 0)
                                {
                                    cmdUp.Parameters["@TranQty"].Value = Convert.ToDecimal(dsFBom.Tables[0].Rows[mr]["POQuantity"].ToString());
                                }
                                else
                                {
                                    cmdUp.Parameters["@TranQty"].Value = (Convert.ToDecimal(dsFBom.Tables[0].Rows[mr]["POQuantity"].ToString()) - Convert.ToDecimal(dsFBom.Tables[0].Rows[mr]["GRQuantity"].ToString()));
                                }

                                cmdUp.Parameters["@MaterialHeader"].Value = dsFBom.Tables[0].Rows[mr]["MaterialCode"].ToString();
                                cmdUp.Connection = oConn; cmdUp.CommandText = NP_Cls.SqlInsert; cmdUp.Transaction = Tr;
                                cmdUp.ExecuteNonQuery();
                            }
                            else
                            {
                                NP_Cls.SqlInsert = "UPDATE t_MRPTranOrder " +
               "SET  TranOrder = '" + dsFBom.Tables[0].Rows[mr]["PONumber"].ToString() + "', TranQty = @TranQty, MaterialHeader = @MaterialHeader " +
        "WHERE (MaterialCode = @MaterialCode) AND ( TranOrder = @TranOrder)";
                                cmdUp.Parameters["@MaterialCode"].Value = dsFBom.Tables[0].Rows[mr]["MaterialCode"].ToString();
                                cmdUp.Parameters["@SONumber"].Value = string.Empty;
                                cmdUp.Parameters["@TranOrder"].Value = dsFBom.Tables[0].Rows[mr]["PRNumber"].ToString();
                                if (Convert.ToDecimal(dsFBom.Tables[0].Rows[mr]["POQuantity"].ToString()) == 0)
                                {
                                    cmdUp.Parameters["@TranQty"].Value = Convert.ToDecimal(dsFBom.Tables[0].Rows[mr]["PRQuantity"].ToString());
                                }
                                else if (Convert.ToDecimal(dsFBom.Tables[0].Rows[mr]["GRQuantity"].ToString()) == 0)
                                {
                                    cmdUp.Parameters["@TranQty"].Value = Convert.ToDecimal(dsFBom.Tables[0].Rows[mr]["POQuantity"].ToString());
                                }
                                else
                                {
                                    cmdUp.Parameters["@TranQty"].Value = (Convert.ToDecimal(dsFBom.Tables[0].Rows[mr]["POQuantity"].ToString()) - Convert.ToDecimal(dsFBom.Tables[0].Rows[mr]["GRQuantity"].ToString()));
                                }

                                cmdUp.Parameters["@MaterialHeader"].Value = dsFBom.Tables[0].Rows[mr]["MaterialCode"].ToString();
                                cmdUp.Connection = oConn; cmdUp.CommandText = NP_Cls.SqlInsert; cmdUp.Transaction = Tr;
                                cmdUp.ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {
                        //TODO Dose this mat is PrdOrder ?
                        NP_Cls.SqlSelect = "SELECT     t_PrdOrderDetail.PrdONumber, t_PrdOrderDetail.ComponentCode, t_PrdOrderDetail.ComponentName, t_PrdOrderDetail.PrdOQuantity AS PrdQty,  t_PrdOrderDetail.IsGIClose, t_GI.GINumber, ISNULL(t_GIDetail.GIQuantity, 0) AS GIQty, t_PrdOrder.MaterialCode FROM t_PrdOrder INNER JOIN  t_PrdOrderDetail ON t_PrdOrder.PrdONumber = t_PrdOrderDetail.PrdONumber LEFT OUTER JOIN              t_GIDetail INNER JOIN t_GI ON t_GIDetail.GINumber = t_GI.GINumber ON t_PrdOrderDetail.PrdONumber = t_GI.PrdONumber WHERE (t_PrdOrder.MaterialCode = N'" + dsComp.Tables[0].Rows[cp]["CompCode"].ToString() + "')";
                        dsFBom = new DataSet(); dsFBom = NP.GetDataWithTran(NP_Cls.SqlSelect, Tr, oConn);
                        if (dsFBom.Tables[0].Rows.Count > 0)
                        {
                            // Prd Order
                            for (int mr = 0; mr < dsFBom.Tables[0].Rows.Count; mr++)
                            {
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
                                if (dsFBom.Tables[0].Rows[mr]["GINumber"].ToString() == string.Empty)
                                {
                                    NP_Cls.SqlInsert = "UPDATE t_MRPTranOrder " +
                   "SET  TranQty = @TranQty, MaterialHeader = @MaterialHeader " +
            "WHERE (MaterialCode = @MaterialCode) AND (TranOrder = @TranOrder)";
                                    cmdUp.Parameters["@MaterialCode"].Value = dsFBom.Tables[0].Rows[mr]["MaterialCode"].ToString();
                                    cmdUp.Parameters["@SONumber"].Value = string.Empty;
                                    cmdUp.Parameters["@TranOrder"].Value = dsFBom.Tables[0].Rows[mr]["PrdONumber"].ToString();
                                    cmdUp.Parameters["@TranQty"].Value = (Convert.ToDecimal(dsFBom.Tables[0].Rows[mr]["PrdQty"].ToString()) - Convert.ToDecimal(dsFBom.Tables[0].Rows[mr]["GIQty"].ToString()));
                                    cmdUp.Parameters["@MaterialHeader"].Value = dsFBom.Tables[0].Rows[mr]["MaterialCode"].ToString();
                                    cmdUp.Connection = oConn; cmdUp.CommandText = NP_Cls.SqlInsert; cmdUp.Transaction = Tr;
                                    cmdUp.ExecuteNonQuery();
                                }
                                else
                                {
                                    NP_Cls.SqlInsert = "UPDATE t_MRPTranOrder " +
                   "SET  TranOrder = '" + dsFBom.Tables[0].Rows[mr]["GINumber"].ToString() + "', TranQty = @TranQty, MaterialHeader = @MaterialHeader " +
            "WHERE (MaterialCode = @MaterialCode) AND ( TranOrder = @TranOrder)";
                                    cmdUp.Parameters["@MaterialCode"].Value = dsFBom.Tables[0].Rows[mr]["MaterialCode"].ToString();
                                    cmdUp.Parameters["@SONumber"].Value = string.Empty;
                                    cmdUp.Parameters["@TranOrder"].Value = (dsFBom.Tables[0].Rows[mr]["GINumber"].ToString() == string.Empty ? dsFBom.Tables[0].Rows[mr]["PrdONumber"].ToString() : dsFBom.Tables[0].Rows[mr]["GINumber"].ToString());

                                    cmdUp.Parameters["@TranQty"].Value = (Convert.ToDecimal(dsFBom.Tables[0].Rows[mr]["PrdQty"].ToString()) - Convert.ToDecimal(dsFBom.Tables[0].Rows[mr]["GIQty"].ToString()));
                                    cmdUp.Parameters["@MaterialHeader"].Value = dsFBom.Tables[0].Rows[mr]["MaterialCode"].ToString();
                                    cmdUp.Connection = oConn; cmdUp.CommandText = NP_Cls.SqlInsert; cmdUp.Transaction = Tr;
                                    cmdUp.ExecuteNonQuery();
                                }
                            }
                            //
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
                NP_Cls.SqlSelect = "SELECT     t_PRDetail.PRQuantity, ISNULL(t_PODetail.POQuantity, 0) AS POQuantity, ISNULL(t_PODetail.GRQuantity, 0) AS GRQuantity, t_PRDetail.MaterialCode,  t_PRDetail.MaterialName, t_PRDetail.PRNumber, t_PODetail.PONumber FROM  t_PRDetail LEFT OUTER JOIN  t_PO RIGHT OUTER JOIN  t_PODetail ON t_PO.PONumber = t_PODetail.PONumber ON t_PRDetail.PRNumber = t_PODetail.PRNumber AND        t_PRDetail.MaterialCode = t_PODetail.MaterialCode WHERE   (t_PRDetail.MaterialCode = N'" + this.txtMatCode.Text.Trim() + "')";
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

                    //====
                    if (dsFBom2.Tables[0].Rows[0]["PONumber"].ToString() == string.Empty)
                    {
                        NP_Cls.SqlInsert = "UPDATE t_MRPTranOrder " +
       "SET  TranQty = @TranQty, MaterialHeader = @MaterialHeader " +
"WHERE (MaterialCode = @MaterialCode) AND (TranOrder = @TranOrder)";
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
                        NP_Cls.SqlInsert = "UPDATE t_MRPTranOrder " +
       "SET  TranOrder = '" + dsFBom2.Tables[0].Rows[0]["PONumber"].ToString() + "', TranQty = @TranQty, MaterialHeader = @MaterialHeader " +
"WHERE (MaterialCode = @MaterialCode) AND ( TranOrder = @TranOrder)";
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
                    //====

//                    NP_Cls.SqlInsert = "UPDATE t_MRPTranOrder " +
//       "SET  TranOrder = @TranOrder, TranQty = @TranQty, MaterialHeader = @MaterialHeader " +
//"WHERE (MaterialCode = @MaterialCode)";
//                    cmdUp.Parameters["@MaterialCode"].Value = dsFBom2.Tables[0].Rows[0]["MaterialCode"].ToString();
//                    cmdUp.Parameters["@SONumber"].Value = string.Empty;
//                    cmdUp.Parameters["@TranOrder"].Value = dsFBom2.Tables[0].Rows[0]["PRNumber"].ToString();
//                    if (Convert.ToDecimal(dsFBom2.Tables[0].Rows[0]["POQuantity"].ToString()) == 0)
//                    {
//                        cmdUp.Parameters["@TranQty"].Value = Convert.ToDecimal(dsFBom2.Tables[0].Rows[0]["PRQuantity"].ToString());
//                    }
//                    else if (Convert.ToDecimal(dsFBom2.Tables[0].Rows[0]["GRQuantity"].ToString()) == 0)
//                    {
//                        cmdUp.Parameters["@TranQty"].Value = Convert.ToDecimal(dsFBom2.Tables[0].Rows[0]["POQuantity"].ToString());
//                    }
//                    else
//                    {
//                        cmdUp.Parameters["@TranQty"].Value = (Convert.ToDecimal(dsFBom2.Tables[0].Rows[0]["POQuantity"].ToString()) - Convert.ToDecimal(dsFBom2.Tables[0].Rows[0]["GRQuantity"].ToString()));
//                    }
//                    cmdUp.Parameters["@MaterialHeader"].Value = dsFBom2.Tables[0].Rows[0]["MaterialCode"].ToString();
//                    cmdUp.Connection = oConn; cmdUp.CommandText = NP_Cls.SqlInsert; cmdUp.Transaction = Tr;
//                    cmdUp.ExecuteNonQuery();
                }
                else
                {
                    //TODO Dose this mat is PrdOrder ?
                    NP_Cls.SqlSelect = "SELECT     t_PrdOrderDetail.PrdONumber, t_PrdOrderDetail.ComponentCode, t_PrdOrderDetail.ComponentName, t_PrdOrderDetail.PrdOQuantity AS PrdQty,  t_PrdOrderDetail.IsGIClose, t_GI.GINumber, ISNULL(t_GIDetail.GIQuantity, 0) AS GIQty, t_PrdOrder.MaterialCode FROM t_PrdOrder INNER JOIN  t_PrdOrderDetail ON t_PrdOrder.PrdONumber = t_PrdOrderDetail.PrdONumber LEFT OUTER JOIN              t_GIDetail INNER JOIN t_GI ON t_GIDetail.GINumber = t_GI.GINumber ON t_PrdOrderDetail.PrdONumber = t_GI.PrdONumber WHERE (t_PrdOrder.MaterialCode = N'" + this.txtMatCode.Text.Trim() + "')";
                    DataSet  dsFBom = new DataSet(); dsFBom = NP.GetDataWithTran(NP_Cls.SqlSelect, Tr, oConn);
                    if (dsFBom.Tables[0].Rows.Count > 0)
                    {
                        // Prd Order
                        for (int mr = 0; mr < dsFBom.Tables[0].Rows.Count; mr++)
                        {
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
                            if (dsFBom.Tables[0].Rows[mr]["GINumber"].ToString() == string.Empty)
                            {
                                NP_Cls.SqlInsert = "UPDATE t_MRPTranOrder " +
               "SET  TranQty = @TranQty, MaterialHeader = @MaterialHeader " +
        "WHERE (MaterialCode = @MaterialCode) AND (TranOrder = @TranOrder)";
                                cmdUp.Parameters["@MaterialCode"].Value = dsFBom.Tables[0].Rows[mr]["MaterialCode"].ToString();
                                cmdUp.Parameters["@SONumber"].Value = string.Empty;
                                cmdUp.Parameters["@TranOrder"].Value = dsFBom.Tables[0].Rows[mr]["PrdONumber"].ToString();
                                cmdUp.Parameters["@TranQty"].Value = (Convert.ToDecimal(dsFBom.Tables[0].Rows[mr]["PrdQty"].ToString()) - Convert.ToDecimal(dsFBom.Tables[0].Rows[mr]["GIQty"].ToString()));
                                cmdUp.Parameters["@MaterialHeader"].Value = dsFBom.Tables[0].Rows[mr]["MaterialCode"].ToString();
                                cmdUp.Connection = oConn; cmdUp.CommandText = NP_Cls.SqlInsert; cmdUp.Transaction = Tr;
                                cmdUp.ExecuteNonQuery();
                            }
                            else
                            {
                                NP_Cls.SqlInsert = "UPDATE t_MRPTranOrder " +
               "SET  TranOrder = '" + dsFBom.Tables[0].Rows[mr]["GINumber"].ToString() + "', TranQty = @TranQty, MaterialHeader = @MaterialHeader " +
        "WHERE (MaterialCode = @MaterialCode) AND ( TranOrder = @TranOrder)";
                                cmdUp.Parameters["@MaterialCode"].Value = dsFBom.Tables[0].Rows[mr]["MaterialCode"].ToString();
                                cmdUp.Parameters["@SONumber"].Value = string.Empty;
                                cmdUp.Parameters["@TranOrder"].Value = dsFBom.Tables[0].Rows[mr]["PrdONumber"].ToString();

                                cmdUp.Parameters["@TranQty"].Value = (Convert.ToDecimal(dsFBom.Tables[0].Rows[mr]["PrdQty"].ToString()) - Convert.ToDecimal(dsFBom.Tables[0].Rows[mr]["GIQty"].ToString()));
                                cmdUp.Parameters["@MaterialHeader"].Value = dsFBom.Tables[0].Rows[mr]["MaterialCode"].ToString();
                                cmdUp.Connection = oConn; cmdUp.CommandText = NP_Cls.SqlInsert; cmdUp.Transaction = Tr;
                                cmdUp.ExecuteNonQuery();
                            }
                        }
                        //
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
                }
                Tr.Commit();
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Create MRP 2 : " + ex.Message); return;
            }
            finally
            {
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
            }
            //End

            double dTmpStock = 0; double dTmpAva = 0; this.MyCompSend = new DataSet();
            //this.MyCompSend.Tables.Add(new DataTable("dtComp"));
            try
            {
                NP_Cls.SqlSelect = "SELECT  t_MRPBOM.HeadBomCode, m_Material.MaterialName FROM t_MRPBOM LEFT OUTER JOIN   m_Material ON t_MRPBOM.FGCode = m_Material.MaterialCode WHERE (t_MRPBOM.FGCode = N'" + this.txtMatCode.Text.Trim() + "') GROUP BY t_MRPBOM.HeadBomCode, m_Material.MaterialName, t_MRPBOM.AutoID ORDER BY t_MRPBOM.AutoID"; 
                this.MyGridSet = new DataSet(); this.MyGridSet = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (this.MyGridSet.Tables[0].Rows.Count == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found this material code for MRP !!"); this.txtMatCode.Select(); this.txtMatCode.SelectAll(); return; }

                this.lblMatName.Text = this.MyGridSet.Tables[0].Rows[0]["MaterialName"].ToString();
                DataTable dtTmp = this.MyGridSet.Tables[0].DefaultView.ToTable(true, "HeadBomCode");
                this.MyGridSet.Tables.Clear(); this.MyGridSet.Tables.Add(dtTmp);
                this.MyTmpView = GetDS4DGV(this.MyTmpView);
                for (int i = 0; i < this.MyGridSet.Tables[0].Rows.Count; i++)
                {
                    NP_Cls.SqlSelect = "SELECT        SUM(t_MRPBOM.FGQty) AS FGQty, t_MRPBOM.HeadBomCode, t_MRPBOM.ComponentCode, t_MRPBOM.ProcurementType, m_Material_1.MaterialName,                              m_Material.MaterialName AS CompName, m_Material_1.UnitCode AS FGUnitCode, t_MRPBOM.FGCode, getBOM.SortIndex,                              SUM(CAST(ROUND(t_MRPBOM.ComponentQty / ISNULL(t_VendorInfoRecord.QtyConversion, 1), 3) AS Decimal(18, 3))) AS ComponentQty,ISNULL(t_VendorInfoRecord.UnitCode, t_MRPBOM.ComponentUnitCode) AS ComponentUnitCode    FROM            t_MRPBOM INNER JOIN                                 (SELECT        t_BOM.BOMCode, t_BOM.MaterialCode, t_BOMDetail.SortIndex, t_BOMDetail.MaterialCode AS CompCode                                   FROM            t_BOM INNER JOIN                                                             t_BOMDetail ON t_BOM.BOMCode = t_BOMDetail.BOMCode                                   WHERE        (t_BOM.Approve = 1)) AS getBOM ON t_MRPBOM.HeadBomCode = getBOM.MaterialCode AND                              t_MRPBOM.ComponentCode = getBOM.CompCode LEFT OUTER JOIN                             t_VendorInfoRecord ON t_MRPBOM.ComponentCode = t_VendorInfoRecord.MaterialCode LEFT OUTER JOIN                             m_Material ON t_MRPBOM.ComponentCode = m_Material.MaterialCode LEFT OUTER JOIN                             m_Material AS m_Material_1 ON t_MRPBOM.HeadBomCode = m_Material_1.MaterialCode    GROUP BY t_MRPBOM.HeadBomCode, t_MRPBOM.ComponentCode, t_MRPBOM.ProcurementType, m_Material_1.MaterialName, m_Material.MaterialName,                              m_Material_1.UnitCode, t_MRPBOM.FGCode, getBOM.SortIndex,ISNULL(t_VendorInfoRecord.UnitCode, t_MRPBOM.ComponentUnitCode)       HAVING        (t_MRPBOM.HeadBomCode = N'" + this.MyGridSet.Tables[0].Rows[i]["HeadBomCode"].ToString() + "') AND (t_MRPBOM.FGCode = N'" + this.txtMatCode.Text.Trim() + "')   ORDER BY getBOM.SortIndex";
                    //NP_Cls.SqlSelect = "SELECT DISTINCT t_MRPBOM.AutoID, t_MRPBOM.FGQty, t_MRPBOM.HeadBomCode, t_MRPBOM.ComponentCode, t_MRPBOM.ProcurementType, CAST(ROUND((t_MRPBOM.ComponentQty / isnull(t_VendorInfoRecord.QtyConversion,1)),3)as Decimal(18,3)) as ComponentQty, t_MRPBOM.RequireDate, t_MRPBOM.LogDate, t_MRPBOM.SONumber, m_Material_1.MaterialName, m_Material_1.InHouseProduction, m_Material_1.DeliveryTime, m_Material_1.GRProcessingTime, m_Material.MaterialName AS CompName, t_MRPTranOrder_1.TranOrder AS TranHeadOrder, t_MRPTranOrder.TranOrder AS TranCompOrder, m_Material_1.ProcurementType AS OtherPType, t_MRPTranOrder.IsCompleted, t_MRPTranOrder.IsComponent,                      ISNULL(t_MRPTranOrder.TranQty, 0) AS TranQty, ISNULL(t_MRPTranOrder.SumNeedQty, 0) AS SumNeedQty,m_Material_1.UnitCode AS FGUnitCode,   isnull(t_VendorInfoRecord.UnitCode,t_MRPBOM.ComponentUnitCode)AS ComponentUnitCode FROM     t_MRPBOM LEFT OUTER JOIN t_VendorInfoRecord ON t_VendorInfoRecord.MaterialCode = t_MRPBOM.ComponentCode LEFT OUTER JOIN  t_MRPTranOrder AS t_MRPTranOrder_1 ON t_MRPBOM.SONumber = t_MRPTranOrder_1.SONumber AND  t_MRPBOM.HeadBomCode = t_MRPTranOrder_1.MaterialCode LEFT OUTER JOIN  t_MRPTranOrder ON t_MRPBOM.SONumber = t_MRPTranOrder.SONumber AND t_MRPBOM.ComponentCode = t_MRPTranOrder.MaterialCode LEFT OUTER JOIN  m_Material ON t_MRPBOM.ComponentCode = m_Material.MaterialCode LEFT OUTER JOIN  m_Material AS m_Material_1 ON t_MRPBOM.HeadBomCode = m_Material_1.MaterialCode WHERE     (t_MRPBOM.HeadBomCode = N'" + this.MyGridSet.Tables[0].Rows[i]["HeadBomCode"].ToString() + "') AND (t_MRPBOM.FGCode = N'" + this.txtMatCode.Text.Trim() + "') ORDER BY t_MRPBOM.AutoID";
                   
                    DataSet dsTmp = new DataSet(); dsTmp = NP.GetClientDataSet(NP_Cls.SqlSelect);
                    if (i == 0) { this.MyCompSend.Tables.Add(dsTmp.Tables[0].Clone()); }
                    if (dsTmp.Tables[0].Rows.Count == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found , please check !!"); this.txtMatCode.Select(); this.txtMatCode.SelectAll(); return; }
                    for (int xx = 0; xx < dsTmp.Tables[0].Rows.Count; xx++)
                    {
                        DataRow drTmp; drTmp = this.MyTmpView.Tables[0].NewRow();
                        drTmp["ItemNo"] = (i == 0 ? (xx + 1) : (xx + 1));
                        if (xx == 0)
                        {
                            //TODO ***********
                            drTmp["HeadBOMCode"] = dsTmp.Tables[0].Rows[xx]["HeadBomCode"].ToString();
                            drTmp["FGQty"] = dsTmp.Tables[0].Rows[xx]["FGQty"].ToString();  
                            drTmp["FGUnit"] = dsTmp.Tables[0].Rows[xx]["FGUnitCode"].ToString();
                        }
                        drTmp["ComponentCode"] = dsTmp.Tables[0].Rows[xx]["ComponentCode"].ToString(); 
                        drTmp["ComponentQty"] = dsTmp.Tables[0].Rows[xx]["ComponentQty"].ToString();
                        drTmp["HeadBOMCode_Hide"] = dsTmp.Tables[0].Rows[xx]["HeadBomCode"].ToString();

                     
                        drTmp["CompUnit"] = dsTmp.Tables[0].Rows[xx]["ComponentUnitCode"].ToString();

                        this.MyTmpView.Tables[0].Rows.Add(drTmp);
                        this.MyCompSend.Tables[0].ImportRow(dsTmp.Tables[0].Rows[xx]);
                    }
                    
                }
                this.dataGridView1.DataSource = this.MyTmpView.Tables[0];
                this.dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Running : " + ex.Message); return;
            }
        }
        private void GenBOMNCate(DataSet dsFBom, int i, string strMCode, SqlCommand cmdUp, SqlConnection oConn, SqlTransaction Tr, DateTime dDelivery, byte isMaster)
        {
            try
            {
                NP_Cls.SqlSelect = "SELECT     t_BOM.BOMCode, t_BOM.MaterialCode, t_BOM.Quantity AS BOMQty, t_BOM.UnitCode AS BOMUnit, t_BOMDetail.MaterialCode AS Comp,   t_BOMDetail.Quantity AS CompQty, t_BOMDetail.LossPercentage, ISNULL(t_BOMDetail.LossPercentage, 0) / 100   AS MLoss, m_Material.ProcurementType, m_Material.UnitCode, t_BOMDetail.Category, m_Material.GRProcessingTime, m_Material.DeliveryTime, m_Material.InHouseProduction, m_Material.ShelfLife,                       m_Material.MovAvgPrice  FROM  t_BOM INNER JOIN    t_BOMDetail ON t_BOM.BOMCode = t_BOMDetail.BOMCode LEFT OUTER JOIN m_Material ON t_BOMDetail.MaterialCode = m_Material.MaterialCode WHERE     (t_BOM.MaterialCode = N'" + strMCode + "') AND (t_BOM.FileStatus = N'1') AND (t_BOM.Approve = 1)";
                DataSet dsB = new DataSet();
                dsB = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (dsB.Tables[0].Rows.Count > 0)
                {
                    for (int j = 0; j < dsB.Tables[0].Rows.Count; j++)
                    {
                        // Trimatic
                        double dBomQty = (isMaster == 1 ? (string.IsNullOrEmpty(dsFBom.Tables[0].Rows[i]["SOQuantity"].ToString()) ? 0 : Convert.ToDouble(dsFBom.Tables[0].Rows[i]["SOQuantity"])) : (this.dRealComReq));
                        double dMLoss = (string.IsNullOrEmpty(dsB.Tables[0].Rows[j]["MLoss"].ToString()) ? 0 : Convert.ToDouble(dsB.Tables[0].Rows[j]["MLoss"]));
                        double dBomMasterQty = (string.IsNullOrEmpty(dsB.Tables[0].Rows[j]["BOMQty"].ToString()) ? 0 : Convert.ToDouble(dsB.Tables[0].Rows[j]["BOMQty"]));
                        double dCompQty = (string.IsNullOrEmpty(dsB.Tables[0].Rows[j]["CompQty"].ToString()) ? 0 : Convert.ToDouble(dsB.Tables[0].Rows[j]["CompQty"]));
                        double dComReq = ((dCompQty * (1+ dMLoss)) * dBomQty) / dBomMasterQty;  //(dBomQty * dMLoss) / dBomMasterQty;

                        // Require Date
                        DateTime dMatReq = Convert.ToDateTime(dDelivery);
                        Int32 SubtrDate = 0;
                        if (!string.IsNullOrEmpty((dsB.Tables[0].Rows[j]["ProcurementType"].ToString())))
                        {
                            if (dsB.Tables[0].Rows[j]["ProcurementType"].ToString().ToUpper() == "F")
                            {
                                // Buy Cal about GR, InHouse
                                if (!string.IsNullOrEmpty(dsB.Tables[0].Rows[j]["GRProcessingTime"].ToString()) && !string.IsNullOrEmpty(dsB.Tables[0].Rows[j]["InHouseProduction"].ToString()))
                                {
                                    SubtrDate = Convert.ToInt32(dsB.Tables[0].Rows[j]["GRProcessingTime"]) + Convert.ToInt32(dsB.Tables[0].Rows[j]["InHouseProduction"]);
                                }
                            }
                            else
                            {
                                // Sell Cal about GR, Lead time
                                if (!string.IsNullOrEmpty(dsB.Tables[0].Rows[j]["GRProcessingTime"].ToString()) && !string.IsNullOrEmpty(dsB.Tables[0].Rows[j]["DeliveryTime"].ToString()))
                                {
                                    SubtrDate = Convert.ToInt32(dsB.Tables[0].Rows[j]["GRProcessingTime"]) + Convert.ToInt32(dsB.Tables[0].Rows[j]["DeliveryTime"]);
                                }
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
                            this.dRealComReq = dComReq;
                            GenBOMNCate(dsFBom, i, dsB.Tables[0].Rows[j]["Comp"].ToString(), cmdUp, oConn, Tr, dDelivery, 0);
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
        private void GenComp(SqlCommand cmdUp, SqlTransaction Tr, string strMat)
        {
            //TODO New 28-08 MRP Running
            //First Step Check at PR,PO,GR
            NP_Cls.SqlSelect = "SELECT     t_BOMDetail.MaterialCode AS CompCode FROM t_BOM INNER JOIN t_BOMDetail ON t_BOM.BOMCode = t_BOMDetail.BOMCode WHERE     (t_BOM.MaterialCode = N'" + strMat + "')";
            DataSet dsComp = new DataSet(); dsComp = NP.GetDataWithTran(NP_Cls.SqlSelect, Tr, oConn);
            for (int cp = 0; cp < dsComp.Tables[0].Rows.Count; cp++)
            {
                NP_Cls.SqlSelect = "SELECT t_PRDetail.PRNumber, t_PRDetail.PRQuantity, ISNULL(t_PODetail.POQuantity, 0) AS POQuantity, ISNULL(t_PODetail.GRQuantity, 0) AS GRQuantity, t_PRDetail.MaterialCode, t_PRDetail.MaterialName, t_PODetail.PONumber FROM  t_PO RIGHT OUTER JOIN t_PODetail ON t_PO.PONumber = t_PODetail.PONumber RIGHT OUTER JOIN t_PRDetail ON t_PODetail.PRNumber = t_PRDetail.PRNumber AND t_PODetail.MaterialCode = t_PRDetail.MaterialCode WHERE (t_PRDetail.MaterialCode = N'" + dsComp.Tables[0].Rows[cp]["CompCode"].ToString() + "') AND (t_PO.POApprove = 0 OR t_PO.POApprove IS NULL)";
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
                    // Prd Order
                    //TODO Dose this mat is PrdOrder ?
                    NP_Cls.SqlSelect = "SELECT     t_PrdOrderDetail.PrdONumber, t_PrdOrderDetail.ComponentCode, t_PrdOrderDetail.ComponentName, t_PrdOrderDetail.PrdOQuantity AS PrdQty,  t_PrdOrderDetail.IsGIClose, t_GI.GINumber, ISNULL(t_GIDetail.GIQuantity, 0) AS GIQty, t_PrdOrder.MaterialCode FROM t_PrdOrder INNER JOIN  t_PrdOrderDetail ON t_PrdOrder.PrdONumber = t_PrdOrderDetail.PrdONumber LEFT OUTER JOIN              t_GIDetail INNER JOIN t_GI ON t_GIDetail.GINumber = t_GI.GINumber ON t_PrdOrderDetail.PrdONumber = t_GI.PrdONumber WHERE (t_PrdOrder.MaterialCode = N'" + dsComp.Tables[0].Rows[cp]["CompCode"].ToString() + "')";
                    dsFBom = new DataSet(); dsFBom = NP.GetDataWithTran(NP_Cls.SqlSelect, Tr, oConn);
                    if (dsFBom.Tables[0].Rows.Count > 0)
                    {
                        // Prd Order
                        for (int mr = 0; mr < dsFBom.Tables[0].Rows.Count; mr++)
                        {
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
                            if (dsFBom.Tables[0].Rows[mr]["GINumber"].ToString() == string.Empty)
                            {
                                NP_Cls.SqlInsert = "UPDATE t_MRPTranOrder " +
               "SET  TranQty = @TranQty, MaterialHeader = @MaterialHeader " +
        "WHERE (MaterialCode = @MaterialCode) AND (TranOrder = @TranOrder)";
                                cmdUp.Parameters["@MaterialCode"].Value = dsFBom.Tables[0].Rows[mr]["MaterialCode"].ToString();
                                cmdUp.Parameters["@SONumber"].Value = string.Empty;
                                cmdUp.Parameters["@TranOrder"].Value = dsFBom.Tables[0].Rows[mr]["PrdONumber"].ToString();
                                cmdUp.Parameters["@TranQty"].Value = (Convert.ToDecimal(dsFBom.Tables[0].Rows[mr]["PrdQty"].ToString()) - Convert.ToDecimal(dsFBom.Tables[0].Rows[mr]["GIQty"].ToString()));
                                cmdUp.Parameters["@MaterialHeader"].Value = dsFBom.Tables[0].Rows[mr]["MaterialCode"].ToString();
                                cmdUp.Connection = oConn; cmdUp.CommandText = NP_Cls.SqlInsert; cmdUp.Transaction = Tr;
                                cmdUp.ExecuteNonQuery();
                            }
                            else
                            {
                                NP_Cls.SqlInsert = "UPDATE t_MRPTranOrder " +
               "SET  TranOrder = '" + dsFBom.Tables[0].Rows[mr]["GINumber"].ToString() + "', TranQty = @TranQty, MaterialHeader = @MaterialHeader " +
        "WHERE (MaterialCode = @MaterialCode) AND ( TranOrder = @TranOrder)";
                                cmdUp.Parameters["@MaterialCode"].Value = dsFBom.Tables[0].Rows[mr]["MaterialCode"].ToString();
                                cmdUp.Parameters["@SONumber"].Value = string.Empty;
                                cmdUp.Parameters["@TranOrder"].Value = (dsFBom.Tables[0].Rows[mr]["GINumber"].ToString() == string.Empty ? dsFBom.Tables[0].Rows[mr]["PrdONumber"].ToString() : dsFBom.Tables[0].Rows[mr]["GINumber"].ToString());

                                cmdUp.Parameters["@TranQty"].Value = (Convert.ToDecimal(dsFBom.Tables[0].Rows[mr]["PrdQty"].ToString()) - Convert.ToDecimal(dsFBom.Tables[0].Rows[mr]["GIQty"].ToString()));
                                cmdUp.Parameters["@MaterialHeader"].Value = dsFBom.Tables[0].Rows[mr]["MaterialCode"].ToString();
                                cmdUp.Connection = oConn; cmdUp.CommandText = NP_Cls.SqlInsert; cmdUp.Transaction = Tr;
                                cmdUp.ExecuteNonQuery();
                            }
                        }
                        //
                    }
                    else
                    {
                        //

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


        }
        private DataSet GetDS4DGV(DataSet ds)
        {
            ds = new DataSet();
            ds.Tables.Add(new DataTable("dt"));
            ds.Tables[0].Columns.Add(new DataColumn("ItemNo", typeof(System.Int32)));
            ds.Tables[0].Columns.Add(new DataColumn("HeadBOMCode", typeof(System.String)));
            ds.Tables[0].Columns.Add(new DataColumn("FGQty", typeof(System.Double)));
            ds.Tables[0].Columns.Add(new DataColumn("ComponentCode", typeof(System.String)));
            ds.Tables[0].Columns.Add(new DataColumn("ComponentQty", typeof(System.Double)));
            ds.Tables[0].Columns.Add(new DataColumn("HeadBOMCode_Hide", typeof(System.String)));
            ds.Tables[0].Columns.Add(new DataColumn("FGUnit", typeof(System.String)));
            ds.Tables[0].Columns.Add(new DataColumn("CompUnit", typeof(System.String)));
            ds.AcceptChanges();
            return ds;
        }

        private void frmMRPRunningNew_Load(object sender, EventArgs e)
        {
            LoginSystem.frmMainMenu frm = ((LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"]);
            frm.menuStrip1.Enabled = true;

            this.MyTmpView = new DataSet();
            this.txtMatCode.Text = string.Empty; this.txtMatCode.Select(); 
        }
        private void txtMatCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnMRP_Click(sender, e);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if ((sender as DataGridView).RowCount == 0) { return; }

            //frmComponentRunning frm = new frmComponentRunning();
            //frm.lblCompCodeName.Text = (sender as DataGridView).SelectedRows[0].Cells["clnCompCode"].Value.ToString();
            //frm.MyCompRec = new DataSet();
            //frm.MyCompRec.Tables.Add(this.MyCompSend.Tables[0].Copy());
            //frm.ShowDialog();
            this.contextMenuStrip1.ShowImageMargin = true;
            this.contextMenuStrip1.Show();
        }

        private void componentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0) { return; }
            if (dataGridView1.SelectedCells.Count == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please select data first !!"); return; }

            frmComponentRunning frm = new frmComponentRunning();
            frm.lblCompCodeName.Text = dataGridView1["clnCompCode", dataGridView1.SelectedCells[0].RowIndex].Value.ToString().Trim();
            frm.pGradientPanel1.Caption = "Component Running";
            frm.label1.Text = "Component Code :";
            frm.Text = "[ Component ]";
            frm.pGradientPanel1.ColorTo = Color.PaleGreen;
            frm.pGradientPanel2.ColorFrom = Color.PaleGreen;
            frm.MyCompRec = new DataSet();
            frm.MyCompRec.Tables.Add(this.MyCompSend.Tables[0].Copy());
            frm.IsComp = 1;
            frm.ShowDialog();
        }
        private void fGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0) { return; }
            if (dataGridView1.SelectedCells.Count == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please select data first !!"); return; }

            frmComponentRunning frm = new frmComponentRunning();
            frm.lblCompCodeName.Text = dataGridView1["clnHeadBOMCode_Hide", dataGridView1.SelectedCells[0].RowIndex].Value.ToString();
            frm.pGradientPanel1.Caption = "FG Running";
            frm.label1.Text = "FG Code :";
            frm.Text = "[ FG ]";
            frm.pGradientPanel1.ColorTo = Color.Salmon;
            frm.pGradientPanel2.ColorFrom = Color.Salmon;
            frm.MyCompRec = new DataSet();
            frm.MyCompRec.Tables.Add(this.MyCompSend.Tables[0].Copy());
            frm.IsComp = 0;
            frm.ShowDialog();
        }
             
    }
}

