using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WMS.BOM
{
    public partial class frmBOMNewDetail : Form
    {
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection(); private decimal dQtyChk = 0; private string exMaterial = string.Empty;
        public frmBOMNewDetail()
        {
            InitializeComponent();

            NP_Cls.strBOMCode = NP_Cls.hBOM["BOMCode"].ToString();
        }

        private void frmBOMNewDetail_Load(object sender, EventArgs e)
        {
            //WMS.BOM.frmBOMNew frm = (WMS.BOM.frmBOMNew)Application.OpenForms["frmBOMNew"];
            this.exMaterial = NP_Cls.hBOM["Material"].ToString();
            this.txtLoss.Text = "0";
            if (NP_Cls.hBOM["BOMType"].ToString().ToUpper() == "M")
            {
                NP_Cls.SqlSelect = "SELECT MaterialCode, MaterialCode + ':' + MaterialName AS MaterialName FROM m_Material WHERE (FileStatus = '1') AND (MaterialCode <> '" + this.exMaterial + "') AND (UnitCode IN (N'G', N'KG')) ";
            }
            else
            {
                NP_Cls.SqlSelect = "SELECT MaterialCode, MaterialCode + ':' + MaterialName AS MaterialName FROM m_Material WHERE (FileStatus = '1') AND (MaterialCode <> '" + this.exMaterial + "') ";
            }
            NP.BindCB(this.cbComponent, NP_Cls.SqlSelect, "MaterialCode", "MaterialName", "((( Select Component )))");

            Clear(); DGV(); this.btnEdit.Visible = false; this.cbComponent.Text = string.Empty; this.cbComponent.Select();
            if (Convert.ToBoolean(NP_Cls.hBOM["Approve"].ToString()))
            {
                this.flowLayoutPanel1.Visible = false; this.groupBox2.Enabled = false; this.contextMenuStrip1.Enabled = false; this.btnSuccess.Visible = false;
            }
            else
            {
                this.flowLayoutPanel1.Visible = true; this.groupBox2.Enabled = true; this.contextMenuStrip1.Enabled = true;
                if (NP_Cls.hBOM["BOMType"].ToString().ToUpper() == "M")
                {
                    DGV();
                }
                else
                {
                    this.btnSuccess.Visible = true;
                }
            }
        }
        private void DGV()
        {
            NP_Cls.SqlSelect = "SELECT     0 AS ItemNo, t_BOMDetail.BOMCode, t_BOMDetail.BOMDetailCode, t_BOMDetail.Category, t_BOMDetail.MaterialCode, t_BOMDetail.Quantity, m_Material.MaterialName, m_Unit.UnitName, m_Unit.UnitCode, t_BOMDetail.LossPercentage, t_BOMDetail.SortIndex  " +
"FROM         t_BOMDetail INNER JOIN "+
                      "m_Material ON t_BOMDetail.MaterialCode = m_Material.MaterialCode INNER JOIN "+
                      "t_BOM ON t_BOMDetail.BOMCode = t_BOM.BOMCode INNER JOIN "+
                      "m_Unit ON m_Material.UnitCode = m_Unit.UnitCode "+
"WHERE (t_BOMDetail.BOMCode = '" + NP_Cls.hBOM["BOMCode"].ToString() + "') ORDER BY t_BOMDetail.SortIndex";
            DataSet ds = new DataSet(); ds = NP.GetClientDataSet(NP_Cls.SqlSelect);
            this.dgvView.DataSource = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (NP_Cls.hBOM["BOMType"].ToString().ToUpper() == "M")
                {
                    Decimal bQty = 0;
                    for (byte i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ds.Tables[0].Rows[i]["ItemNo"] = i + 1;
                    }
                    for (byte i = 0; i < this.dgvView.RowCount; i++)
                    {
                        if (this.dgvView["clnQty", i].Value.ToString().ToUpper() == "G")
                        {
                            bQty += Convert.ToDecimal(this.dgvView["clnQty", i].Value) / 1000;
                        }
                        else
                        {
                            bQty += Convert.ToDecimal(this.dgvView["clnQty", i].Value);
                        }
                    }
                    this.dQtyChk = 100 - bQty; if (this.dQtyChk == 0) { this.btnSuccess.Visible = true; } else { this.btnSuccess.Visible = false; }
                    this.lblRemain.Text = "Remain: " + (100 - bQty).ToString() + " " + NP_Cls.hBOM["UnitName"].ToString() + " - BOM Type : " + NP_Cls.hBOM["BOMType"].ToString();
                    this.lblSum.Text = bQty.ToString(); this.lblSumUnit.Text = NP_Cls.hBOM["UnitName"].ToString();
                }
                else
                {
                    Decimal bQty = 0;
                    for (byte i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ds.Tables[0].Rows[i]["ItemNo"] = i + 1;
                    }
                    for (byte i = 0; i < this.dgvView.RowCount; i++)
                    {
                        bQty += Convert.ToDecimal(this.dgvView["clnQty", i].Value);
                    }
                    //this.dQtyChk = Convert.ToDecimal(NP_Cls.hBOM["Qty"].ToString()) - bQty; if (this.dQtyChk == 0) { this.btnSuccess.Visible = true; } else { this.btnSuccess.Visible = false; }
                    this.btnSuccess.Visible = true;
                    this.lblRemain.Text = "Remain: " + Convert.ToDecimal(NP_Cls.hBOM["Qty"]).ToString() + " " + NP_Cls.hBOM["UnitName"].ToString() + " - BOM Type : " + NP_Cls.hBOM["BOMType"].ToString();
                    this.lblSum.Text = bQty.ToString(); this.lblSumUnit.Text = NP_Cls.hBOM["UnitName"].ToString();
                }
            }
            else
            {
                if (NP_Cls.hBOM["BOMType"].ToString().ToUpper() == "M")
                {
                    this.dQtyChk = Convert.ToDecimal(NP_Cls.hBOM["Qty"].ToString()) - 0; if (this.dQtyChk == 0) { this.btnSuccess.Visible = true; } else { this.btnSuccess.Visible = false; }
                }
                else { this.btnSuccess.Visible = true; }
                this.lblRemain.Text = "Remain: " + NP_Cls.hBOM["Qty"].ToString() + " " + NP_Cls.hBOM["UnitName"].ToString() + " - BOM Type : " + NP_Cls.hBOM["BOMType"].ToString();
                this.lblSum.Text = "0"; this.lblSumUnit.Text = NP_Cls.hBOM["UnitName"].ToString();
            }

        }
        private void DGV(string strBOMDetail)
        {
            NP_Cls.SqlSelect = "SELECT     0 AS ItemNo, t_BOMDetail.BOMCode, t_BOMDetail.BOMDetailCode, t_BOMDetail.Category, t_BOMDetail.MaterialCode, t_BOMDetail.Quantity, m_Material.MaterialName, m_Unit.UnitName, m_Unit.UnitCode, t_BOMDetail.LossPercentage , t_BOMDetail.SortIndex " +
"FROM         t_BOMDetail INNER JOIN "+
                      "m_Material ON t_BOMDetail.MaterialCode = m_Material.MaterialCode INNER JOIN "+
                      "t_BOM ON t_BOMDetail.BOMCode = t_BOM.BOMCode INNER JOIN "+
                      "m_Unit ON m_Material.UnitCode = m_Unit.UnitCode "+
" WHERE (t_BOMDetail.BOMCode = '" + NP_Cls.hBOM["BOMCode"].ToString() + "') AND ( t_BOMDetail.BOMDetailCode <> '" + strBOMDetail + "') ORDER BY t_BOMDetail.SortIndex";
            DataSet ds = new DataSet(); ds = NP.GetClientDataSet(NP_Cls.SqlSelect);
            this.dgvView.DataSource = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (NP_Cls.hBOM["BOMType"].ToString().ToUpper() == "M")
                {
                    Decimal bQty = 0;
                    for (byte i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ds.Tables[0].Rows[i]["ItemNo"] = i + 1;
                    }
                    for (byte i = 0; i < this.dgvView.RowCount; i++)
                    {
                        if (this.dgvView["clnQty", i].Value.ToString().ToUpper() == "G")
                        {
                            bQty += Convert.ToDecimal(this.dgvView["clnQty", i].Value) / 1000;
                        }
                        else
                        {
                            bQty += Convert.ToDecimal(this.dgvView["clnQty", i].Value);
                        }
                    }
                    this.lblRemain.Text = "Remain: " + (100 - bQty).ToString() + " " + NP_Cls.hBOM["UnitName"].ToString() + " - BOM Type : " + NP_Cls.hBOM["BOMType"].ToString();
                    this.lblSum.Text = bQty.ToString(); this.lblSumUnit.Text = NP_Cls.hBOM["UnitName"].ToString();
                }
                else
                {
                    Decimal bQty = 0;
                    for (byte i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ds.Tables[0].Rows[i]["ItemNo"] = i + 1;
                    }
                    for (byte i = 0; i < this.dgvView.RowCount; i++)
                    {
                        bQty += Convert.ToDecimal(this.dgvView["clnQty", i].Value);
                    }
                    //this.dQtyChk = Convert.ToDecimal(NP_Cls.hBOM["Qty"].ToString()) - bQty; if (this.dQtyChk == 0) { this.btnSuccess.Visible = true; } else { this.btnSuccess.Visible = false; }
                    this.btnSuccess.Visible = true;
                    this.lblRemain.Text = "Remain: " + Convert.ToDecimal(NP_Cls.hBOM["Qty"]).ToString() + " " + NP_Cls.hBOM["UnitName"].ToString() + " - BOM Type : " + NP_Cls.hBOM["BOMType"].ToString();
                    this.lblSum.Text = bQty.ToString(); this.lblSumUnit.Text = NP_Cls.hBOM["UnitName"].ToString();
                }
            }
            else
            {
                if (NP_Cls.hBOM["BOMType"].ToString().ToUpper() == "M")
                {
                    this.dQtyChk = Convert.ToDecimal(NP_Cls.hBOM["Qty"].ToString()) - 0; if (this.dQtyChk == 0) { this.btnSuccess.Visible = true; } else { this.btnSuccess.Visible = false; }
                }
                else { this.btnSuccess.Visible = true; }
                this.lblRemain.Text = "Remain: " + NP_Cls.hBOM["Qty"].ToString() + " " + NP_Cls.hBOM["UnitName"].ToString() + " - BOM Type : " + NP_Cls.hBOM["BOMType"].ToString();
                this.lblSum.Text = "0"; this.lblSumUnit.Text = NP_Cls.hBOM["UnitName"].ToString();
            }

        }
        private void Clear()
        {
            this.cbComponent.SelectedIndex = 0; this.txtQtyComp.Text = string.Empty; this.txtLoss.Text = "0"; this.txtRemark.Text = string.Empty; this.txtIndex.Text = string.Empty;
        }
        private void txtQtyComp_KeyPress(object sender, KeyPressEventArgs e)
        {
            NP_Cls.myDecimal(sender, e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (this.dQtyChk != 0)
            {
                if (NP.MSGB("Qty of Component are not equal Qty of BOM !!\nThe transaction will be reject , Do you want to exit out of save ?") == DialogResult.Yes)
                {
                    // Delete all Transaction 
                    oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                    if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                    oConn.Open(); SqlTransaction Tr; Tr = oConn.BeginTransaction();
                    try
                    {
                        SqlCommand cmdDel = new SqlCommand();
                        NP_Cls.SqlSelect = "SELECT BOMDetailCode FROM t_BOMDetail WHERE (BOMCode = @BOMCode)";
                        cmdDel.Parameters.Add("@BOMCode", SqlDbType.Int).Value = Convert.ToInt32(NP_Cls.hBOM["BOMCode"].ToString());
                        cmdDel.Connection = oConn; cmdDel.CommandText = NP_Cls.SqlSelect; cmdDel.Transaction = Tr;
                        SqlDataAdapter da = new SqlDataAdapter(cmdDel); DataSet ds = new DataSet(); da.Fill(ds);

                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            NP_Cls.SqlDel = "DELETE FROM t_BOMDetail WHERE (BOMCode = @BOMCode)";
                            //cmdDel.Parameters.Add("@BOMCode", SqlDbType.Int).Value = this.dgvView["clnBOMCode", this.dgvView.CurrentRow.Index].Value;
                            cmdDel.Parameters.Add("@BOMDetailCode", SqlDbType.Int).Value = this.dgvView["clnBOMDetailCode", this.dgvView.CurrentRow.Index].Value;
                            cmdDel.Connection = oConn; cmdDel.CommandText = NP_Cls.SqlDel; cmdDel.Transaction = Tr;
                            cmdDel.ExecuteNonQuery();

                            NP_Cls.SqlDel = "DELETE FROM t_BOM WHERE (BOMCode = @BOMCode)";
                            cmdDel.Connection = oConn; cmdDel.CommandText = NP_Cls.SqlDel; cmdDel.Transaction = Tr;
                            cmdDel.ExecuteNonQuery();

                            if (NP._TRanSave(oConn, Tr, NP_Cls.NPTranType.Delete, "t_BOM:t_BOMDetail", NP_Cls.strUsr))
                            {
                                Tr.Commit();
                                this.Close();
                            }
                            else
                            {
                                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Try agian !!"); return;
                            }
                        }
                        else // Has Row
                        {
                            NP_Cls.SqlDel = "DELETE FROM t_BOM WHERE (BOMCode = @BOMCode)";
                            cmdDel.Connection = oConn; cmdDel.CommandText = NP_Cls.SqlDel; cmdDel.Transaction = Tr;
                            cmdDel.ExecuteNonQuery();

                            if (NP._TRanSave(oConn, Tr, NP_Cls.NPTranType.Delete, "t_BOM", NP_Cls.strUsr))
                            {
                                Tr.Commit();
                                this.Close();
                            }
                            else
                            {
                                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Try agian !!"); return;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        if (oConn.State == ConnectionState.Open) { Tr.Rollback(); }
                        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Delete : " + ex.Message); return;
                    }
                    finally
                    {
                        if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                    }
                    //
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
                    this.Close();
                }
                else
                {
                    return;
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (NP_Cls.hBOM["BOMType"].ToString().ToUpper() == "M")
            {
                if (this.dQtyChk == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Qty of Component are limite !!"); return; }
            }
            if ((string.IsNullOrEmpty((this.cbComponent.Text.Trim()))) || (this.cbComponent.Text.Trim() == "((( Select Component )))")) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please enter Component: !!"); this.cbComponent.Select(); return; }
            if (NP.ReqField(this.txtQtyComp, "Please enter Qty of Component: !!") == false) { return; }
            if (NP.ReqField(this.txtLoss, "Please enter %Loss: !!") == false) { return; }
       
            if (ChkDup())
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Component Duplicated !!"); this.cbComponent.Select(); return;
            }

            if (this.dgvView.RowCount != 0)
            {
                if (NP_Cls.hBOM["BOMType"].ToString().ToUpper() == "M")
                {
                    Decimal bChk = 0;
                    for (byte i = 0; i < this.dgvView.RowCount; i++)
                    {
                        if (this.dgvView["clnUnitCode", i].Value.ToString().ToUpper() == "G")
                        {
                            bChk += Convert.ToDecimal(this.dgvView["clnQty", i].Value) / 1000;
                        }
                        else
                        {
                            bChk += Convert.ToDecimal(this.dgvView["clnQty", i].Value);
                        }
                    }
                    if (bChk == 100) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Qty of Component is equal 100 !!\nCan not add component !!"); this.txtQtyComp.Select(); this.txtQtyComp.SelectAll(); return; }

                    if (this.lblCompUnitCode.Text.Trim().ToUpper() == "G")
                    {
                        if (((Convert.ToDecimal(this.txtQtyComp.Text.Trim()) / 1000) + bChk) > 100)
                        {
                            NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Qty of Component is over 100 !!"); this.txtQtyComp.Select(); this.txtQtyComp.SelectAll(); return;
                        }
                    }
                    else
                    {
                        if ((Convert.ToDecimal(this.txtQtyComp.Text.Trim()) + bChk) > 100)
                        {
                            NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Qty of Component is over 100 !!"); this.txtQtyComp.Select(); this.txtQtyComp.SelectAll(); return;
                        }
                    }
                }
                else
                {
                    Decimal bChk = 0;
                    for (byte i = 0; i < this.dgvView.RowCount; i++)
                    {
                        bChk += Convert.ToDecimal(this.dgvView["clnQty", i].Value);
                    }
                    //if (bChk == Convert.ToDecimal(NP_Cls.hBOM["Qty"].ToString())) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Qty of Component is equal " + NP_Cls.hBOM["Qty"].ToString() + " !!\nCan not add component !!"); this.txtQtyComp.Select(); this.txtQtyComp.SelectAll(); return; }
                    //if ((Convert.ToDecimal(this.txtQtyComp.Text.Trim()) + bChk) > Convert.ToDecimal(NP_Cls.hBOM["Qty"].ToString()))
                    //{
                    //    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Qty of Component is over " + Convert.ToDecimal(NP_Cls.hBOM["Qty"].ToString()) + " !!"); this.txtQtyComp.Select(); this.txtQtyComp.SelectAll(); return;
                    //}
                }
            }
            else
            {
                if (NP_Cls.hBOM["BOMType"].ToString().ToUpper() == "M")
                {
                    if (this.lblCompUnitCode.Text.Trim().ToUpper() == "G")
                    {
                        if ((Convert.ToDecimal(this.txtQtyComp.Text.Trim()) / 1000) > 100)
                        {
                            NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Qty of Component is over 100 !!"); this.txtQtyComp.Select(); this.txtQtyComp.SelectAll(); return;
                        }
                    }
                    else
                    {
                        if (Convert.ToDecimal(this.txtQtyComp.Text.Trim()) > 100)
                        {
                            NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Qty of Component is over 100 !!"); this.txtQtyComp.Select(); this.txtQtyComp.SelectAll(); return;
                        }
                    }
                }
                else
                {
                    //if (Convert.ToDecimal(this.txtQtyComp.Text.Trim()) > Convert.ToDecimal(NP_Cls.hBOM["Qty"].ToString()))
                    //{
                    //    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Qty of Component is over " + NP_Cls.hBOM["Qty"].ToString() + " !!"); this.txtQtyComp.Select(); this.txtQtyComp.SelectAll(); return;
                    //}
                }
            }

            if (NP.MSGB("Do you want to Add BOM Component Data ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr; Tr = oConn.BeginTransaction();
                try
                {
                    SqlCommand cmdIns = new SqlCommand();
                    NP_Cls.SqlInsert = "INSERT INTO t_BOMDetail "+
                      "(BOMCode, Category, MaterialCode, Quantity, LossPercentage, UserCreate, DateCreate, Remark, SortIndex) " +
"VALUES     (@BOMCode,@Category,@MaterialCode,@Quantity,@LP,@UC, GETDATE(), @Remark,@Sort)";
                    cmdIns.Parameters.Add("@BOMCode", SqlDbType.Int).Value = NP_Cls.hBOM["BOMCode"].ToString();
                    cmdIns.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15).Value = this.cbComponent.SelectedValue;
                    cmdIns.Parameters.Add("@Category", SqlDbType.NVarChar, 1).Value = ChkCategory(oConn, Tr, this.cbComponent.SelectedValue.ToString());
                    cmdIns.Parameters.Add("@Quantity", SqlDbType.Decimal).Value = ((this.lblCompUnitCode.Text.Trim().ToUpper() == "G") && ((NP_Cls.hBOM["BOMType"].ToString().ToUpper() == "M")) ? (Convert.ToDouble(this.txtQtyComp.Text.Trim()) / 1000) : Convert.ToDouble(this.txtQtyComp.Text.Trim()));
                    cmdIns.Parameters.Add("@LP", SqlDbType.Decimal).Value = Convert.ToDouble(this.txtLoss.Text.Trim());
                    cmdIns.Parameters.Add("@Sort", SqlDbType.Decimal).Value = Convert.ToDouble(this.txtIndex.Text.Trim());
                    cmdIns.Parameters.Add("@UC", SqlDbType.NVarChar, 10).Value = NP_Cls.strUsr;
                    cmdIns.Parameters.Add("@Remark", SqlDbType.NVarChar, 200).Value = this.txtRemark.Text.Trim();
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; cmdIns.Transaction = Tr;
                    cmdIns.ExecuteNonQuery();

                    Tr.Commit();
                    Clear();
                    DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Add BOM Component Data Completed !!"); this.cbComponent.Select();

                }
                catch (Exception ex)
                {
                    if (oConn.State == ConnectionState.Open) { Tr.Rollback(); }
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Add : " + ex.Message); return;
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
        private string ChkCategory(SqlConnection oConn, SqlTransaction Tr, string strComp)
        {
            try
            {
                SqlCommand cmdSe = new SqlCommand();
                //NP_Cls.SqlSelect = "SELECT MaterialCode FROM t_BOM WHERE (MaterialCode = @MaterialCode) AND (FileStatus = '1')";
                NP_Cls.SqlSelect = "SELECT ProcurementType FROM m_Material WHERE (MaterialCode = @MaterialCode) AND (FileStatus = '1')";
                cmdSe.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15).Value = this.cbComponent.SelectedValue;
                cmdSe.Connection = oConn; cmdSe.CommandText = NP_Cls.SqlSelect; cmdSe.Transaction = Tr;
                SqlDataAdapter da = new SqlDataAdapter(cmdSe); DataSet ds = new DataSet(); da.Fill(ds);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return string.Empty;
                }
                else
                {
                    if (ds.Tables[0].Rows[0][0].ToString().Trim().ToUpper() == "E")
                    {
                        return "M";
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private bool ChkDup()
        {
            try
            {
                NP_Cls.SqlSelect = " SELECT BOMCode, MaterialCode FROM t_BOMDetail WHERE (BOMCode = '" + NP_Cls.strBOMCode + "') AND (MaterialCode = N'" + this.cbComponent.SelectedValue + "')";
                if (NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string strSelect = this.dgvView["clnBOMCode", this.dgvView.CurrentRow.Index].Value.ToString();
                string strSelect2 = this.dgvView["clnBOMDetailCode", this.dgvView.CurrentRow.Index].Value.ToString();
                NP_Cls.SqlSelect = "SELECT     t_BOMDetail.BOMCode, t_BOMDetail.BOMDetailCode, t_BOMDetail.Category, t_BOMDetail.MaterialCode, t_BOMDetail.Quantity, t_BOMDetail.LossPercentage, t_BOMDetail.Remark, t_BOMDetail.SortIndex, t_BOMDetail.UserCreate, t_BOMDetail.DateCreate, t_BOMDetail.UserChange, t_BOMDetail.DateChage, m_Material.UnitCode FROM         t_BOMDetail INNER JOIN                      m_Material ON t_BOMDetail.MaterialCode = m_Material.MaterialCode WHERE (t_BOMDetail.BOMCode ='" + strSelect + "') AND (t_BOMDetail.BOMDetailCode = '" + strSelect2 + "')";
                DataSet dsEdit = new DataSet(); dsEdit = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (dsEdit.Tables[0].Rows.Count > 0)
                {
                    this.cbComponent.SelectedValue = dsEdit.Tables[0].Rows[0]["MaterialCode"].ToString();
                    this.txtQtyComp.Text = ((dsEdit.Tables[0].Rows[0]["UnitCode"].ToString().ToUpper() == "G") ? (Convert.ToDouble(dsEdit.Tables[0].Rows[0]["Quantity"].ToString()) * 1000).ToString() : dsEdit.Tables[0].Rows[0]["Quantity"].ToString());
                    this.txtLoss.Text = dsEdit.Tables[0].Rows[0]["LossPercentage"].ToString();
                    this.txtRemark.Text = dsEdit.Tables[0].Rows[0]["Remark"].ToString();
                    this.txtIndex.Text = dsEdit.Tables[0].Rows[0]["SortIndex"].ToString();
                    this.lblCode.Text = this.dgvView["clnBOMCode", this.dgvView.CurrentRow.Index].Value.ToString() + ":" + this.dgvView["clnBOMDetailCode", this.dgvView.CurrentRow.Index].Value.ToString();
                    this.cbComponent.Enabled = false; this.btnAdd.Visible = false; this.btnEdit.Visible = true; DGV(this.dgvView["clnBOMDetailCode", this.dgvView.CurrentRow.Index].Value.ToString());
                    this.txtQtyComp.Select(); this.txtQtyComp.SelectAll();
                }
                else
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found !!"); return;
                }
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found : " + ex.Message); return;
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty((this.cbComponent.Text.Trim()))) || (this.cbComponent.Text.Trim() == "((( Select Component )))")) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please enter Component: !!"); this.cbComponent.Select(); return; }
            if (NP.ReqField(this.txtQtyComp, "Please enter Qty of Component: !!") == false) { return; }
            if (NP.ReqField(this.txtLoss, "Please enter %Loss: !!") == false) { return; }

            if (this.dgvView.RowCount != 0)
            {
                if (NP_Cls.hBOM["BOMType"].ToString().ToUpper() == "M")
                {
                    Decimal bChk = 0;
                    for (byte i = 0; i < this.dgvView.RowCount; i++)
                    {
                        if (this.dgvView["clnUnitCode", i].Value.ToString().ToUpper() == "G")
                        {
                            bChk += Convert.ToDecimal(this.dgvView["clnQty", i].Value) / 1000;
                        }
                        else
                        {
                            bChk += Convert.ToDecimal(this.dgvView["clnQty", i].Value);
                        }
                    }
                    if (bChk == 100) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Qty of Component is equal 100 !!\nCan not add component !!"); this.txtQtyComp.Select(); this.txtQtyComp.SelectAll(); return; }
                    if (this.lblCompUnitCode.Text.Trim().ToUpper() == "G")
                    {
                        if (((Convert.ToDecimal(this.txtQtyComp.Text.Trim()) / 1000) + bChk) > 100)
                        {
                            NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Qty of Component is over 100 !!"); this.txtQtyComp.Select(); this.txtQtyComp.SelectAll(); return;
                        }
                    }
                    else
                    {
                        if ((Convert.ToDecimal(this.txtQtyComp.Text.Trim()) + bChk) > 100)
                        {
                            NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Qty of Component is over 100 !!"); this.txtQtyComp.Select(); this.txtQtyComp.SelectAll(); return;
                        }
                    }
                }
                else
                {
                    Decimal bChk = 0;
                    for (byte i = 0; i < this.dgvView.RowCount; i++)
                    {
                        bChk += Convert.ToDecimal(this.dgvView["clnQty", i].Value);
                    }
                    //if (bChk == Convert.ToDecimal(NP_Cls.hBOM["Qty"].ToString())) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Qty of Component is equal " + NP_Cls.hBOM["Qty"].ToString() + " !!\nCan not add component !!"); this.txtQtyComp.Select(); this.txtQtyComp.SelectAll(); return; }
                    //if ((Convert.ToDecimal(this.txtQtyComp.Text.Trim()) + bChk) > Convert.ToDecimal(NP_Cls.hBOM["Qty"].ToString()))
                    //{
                    //    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Qty of Component is over " + Convert.ToDecimal(NP_Cls.hBOM["Qty"].ToString()) + " !!"); this.txtQtyComp.Select(); this.txtQtyComp.SelectAll(); return;
                    //}
                }
            }
            else
            {
                if (NP_Cls.hBOM["BOMType"].ToString().ToUpper() == "M")
                {
                    if (this.lblCompUnitCode.Text.Trim().ToUpper() == "G")
                    {
                        if ((Convert.ToDecimal(this.txtQtyComp.Text.Trim()) / 1000) > 100)
                        {
                            NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Qty of Component is over 100 !!"); this.txtQtyComp.Select(); this.txtQtyComp.SelectAll(); return;
                        }
                    }
                    else
                    {
                        if (Convert.ToDecimal(this.txtQtyComp.Text.Trim()) > 100)
                        {
                            NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Qty of Component is over 100 !!"); this.txtQtyComp.Select(); this.txtQtyComp.SelectAll(); return;
                        }
                    }
                }
                else
                {
                    //if (Convert.ToDecimal(this.txtQtyComp.Text.Trim()) > Convert.ToDecimal(NP_Cls.hBOM["Qty"].ToString()))
                    //{
                    //    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Qty of Component is over " + NP_Cls.hBOM["Qty"].ToString() + " !!"); this.txtQtyComp.Select(); this.txtQtyComp.SelectAll(); return;
                    //}
                }
            }

            if (NP.MSGB("Do you want to Edit BOM Component Data ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open();
                try
                {
                    SqlCommand cmdEdit = new SqlCommand(); string[] strCode = this.lblCode.Text.Trim().Split(':');
                    NP_Cls.sqlUpdate = "UPDATE   t_BOMDetail " +
"SET    Quantity = @Qty, LossPercentage = @LP, UserChange = @UC, DateChage = GETDATE(), Remark = @Remark, SortIndex = @Sort WHERE  (BOMCode = @BOMCode) AND (BOMDetailCode = @BOMDetailCode)";
                    cmdEdit.Parameters.Add("@Qty", SqlDbType.Decimal).Value = ((this.lblCompUnitCode.Text.Trim().ToUpper() == "G") && ((NP_Cls.hBOM["BOMType"].ToString().ToUpper() == "M")) ? (Convert.ToDouble(this.txtQtyComp.Text.Trim()) / 1000) : Convert.ToDouble(this.txtQtyComp.Text.Trim()));
                    cmdEdit.Parameters.Add("@LP", SqlDbType.Decimal).Value = Convert.ToDouble(this.txtLoss.Text.Trim());
                    cmdEdit.Parameters.Add("@Sort", SqlDbType.Decimal).Value = Convert.ToDouble(this.txtIndex.Text.Trim());
                    cmdEdit.Parameters.Add("@BOMCode", SqlDbType.Int).Value = strCode[0].ToString();
                    cmdEdit.Parameters.Add("@BOMDetailCode", SqlDbType.Int).Value = strCode[1].ToString();
                    cmdEdit.Parameters.Add("@UC", SqlDbType.NVarChar, 10).Value = NP_Cls.strUsr;
                    cmdEdit.Parameters.Add("@Remark", SqlDbType.NVarChar, 200).Value = this.txtRemark.Text.Trim();
                    cmdEdit.Connection = oConn; cmdEdit.CommandText = NP_Cls.sqlUpdate;
                    cmdEdit.ExecuteNonQuery();

                    Clear();
                    DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Edit BOM Component Data Completed !!");
                    this.btnAdd.Visible = true; this.btnEdit.Visible = false; this.cbComponent.Enabled = true; this.cbComponent.Select();
                }
                catch (Exception ex)
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Edit : " + ex.Message); return;
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
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvView.RowCount == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found !!"); return; }
            if (NP.MSGB("Do you want to delete BOM Component ?") == DialogResult.Yes)
            {

                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr; Tr = oConn.BeginTransaction();
                try
                {
                    SqlCommand cmdDel = new SqlCommand();
                    NP_Cls.SqlDel = "DELETE FROM t_BOMDetail WHERE (BOMCode = @BOMCode) AND (BOMDetailCode = @BOMDetailCode)";
                    cmdDel.Parameters.Add("@BOMCode", SqlDbType.Int).Value = this.dgvView["clnBOMCode", this.dgvView.CurrentRow.Index].Value;
                    cmdDel.Parameters.Add("@BOMDetailCode", SqlDbType.Int).Value = this.dgvView["clnBOMDetailCode", this.dgvView.CurrentRow.Index].Value;
                    cmdDel.Connection = oConn; cmdDel.CommandText = NP_Cls.SqlDel; cmdDel.Transaction = Tr;
                    cmdDel.ExecuteNonQuery();

                    if (NP._TRanSave(oConn, Tr, NP_Cls.NPTranType.Delete, "t_BOMDetail", NP_Cls.strUsr))
                    {
                        Tr.Commit();
                        DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Delete Completed !!");
                    }
                    else
                    {
                        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Try agian !!"); return;
                    }

                }
                catch (Exception ex)
                {
                    if (oConn.State == ConnectionState.Open) { Tr.Rollback(); }
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Delete : " + ex.Message); return;
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
        private void btnSuccess_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtLoss_KeyPress(object sender, KeyPressEventArgs e)
        {
            NP_Cls.myDecimal(sender, e);
        }

        private void cbComponent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbComponent.SelectedIndex == 0)
            {
                this.lblCompUnit.Text = ". . ."; this.lblCompUnitCode.Text = string.Empty;
            }
            else
            {
                GetCompUnit();
            }
        }
        private void GetCompUnit()
        {
            NP_Cls.SqlSelect = "SELECT     m_Unit.UnitName, m_Material.UnitCode FROM  m_Material INNER JOIN  m_Unit ON m_Material.UnitCode = m_Unit.UnitCode " +
"WHERE     (m_Material.FileStatus = '1') AND (m_Material.MaterialCode = N'" + this.cbComponent.SelectedValue + "')";
            DataSet dsU = new DataSet(); dsU = NP.GetClientDataSet(NP_Cls.SqlSelect);
            this.lblCompUnitCode.Text = dsU.Tables[0].Rows[0][0].ToString(); this.lblCompUnit.Text = dsU.Tables[0].Rows[0][1].ToString();
        }
   
    }
}
