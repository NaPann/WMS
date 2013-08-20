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
    public partial class frmPrdOrder : Form
    {
        public frmPrdOrder()
        {
            InitializeComponent();
        }
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection();
        private byte bView = 0; private string strCurr = string.Empty; private string strGNumber = string.Empty; private string strPlantCode = string.Empty; private string strLocCode = string.Empty; private string strMatCode = string.Empty;
        Hashtable hsTmp = new Hashtable();
        private void MyGrid(DataGridView grid)
        {
            NP_Cls.SqlSelect = "SELECT     1 AS ItemNo, t_BOMDetail.MaterialCode, m_Material.MaterialName, t_BOMDetail.Quantity AS Qty, m_Material.UnitCode, m_Unit.UnitName,                  m_Location.LocName, m_Plant.PlantName, m_Material.PlantCode, m_Material.LocCode  FROM m_Location RIGHT OUTER JOIN t_BOM INNER JOIN t_BOMDetail ON t_BOM.BOMCode = t_BOMDetail.BOMCode LEFT OUTER JOIN              m_Plant RIGHT OUTER JOIN  m_Material ON m_Plant.PlantCode = m_Material.PlantCode LEFT OUTER JOIN m_Unit ON m_Material.UnitCode = m_Unit.UnitCode ON t_BOMDetail.MaterialCode = m_Material.MaterialCode ON     m_Location.LocCode = m_Material.LocCode WHERE     (t_BOM.MaterialCode = N'') AND (t_BOM.FileStatus = N'1') AND (t_BOM.Approve = 1)";
            grid.DataSource = NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0];
        }
        private void frmPrdOrder_Load(object sender, EventArgs e)
        {
            try
            {
                WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
                frm.menuStrip1.Enabled = true;

                this.txtPrdOrder.Text = GetNumber(); this.txtDocDate.Text = NP.GetDateServer().ToString("dd/MM/yyyy");
                this.MyGrid(dgvView);
                if (NP_Cls.FromMRP == 0)
                {
                    BindMat();
                    this.txtQty.Enabled = true;
                }
                else
                {
                    NP_Cls.SqlSelect = "SELECT     MaterialName, MaterialCode FROM m_Material WHERE  (FileStatus = N'1') AND (ProcurementType = N'E') AND (MaterialCode = '" + NP_Cls.MRPFGSort + "')";
                    NP.BindCB(this.cbMaterialCode, NP_Cls.SqlSelect, "MaterialName", "MaterialCode", "((( Select Material )))");
                    this.cbMaterialCode.SelectedIndex = 1; this.txtQty.Text = NP_Cls.MRPQty.ToString();
                    this.txtQty.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Load : " + ex.Message); return;
            }
        }

        private void BindMat()
        {
            NP_Cls.SqlSelect = "SELECT     MaterialName, MaterialCode FROM m_Material WHERE  (FileStatus = N'1') AND (ProcurementType = N'E')";
            NP.BindCB(this.cbMaterialCode, NP_Cls.SqlSelect, "MaterialName", "MaterialCode", "((( Select Material )))"); Clear(); this.cbMaterialCode.Text = string.Empty; this.cbMaterialCode.Select();
        }
        private void Clear()
        {
            this.lblMaterial.Text = string.Empty; this.lblPlant.Text = string.Empty; this.lblLocation.Text = string.Empty; this.lblBOMVer.Text = string.Empty;
            this.txtQty.Text = "0"; this.btnPicking.Visible = false; this.lblAl.Visible = false;
        }
        private string GetNumber()
        {
            try
            {
                bView = 0;
                NP_Cls.SqlSelect = "SELECT top (1) CONVERT(int, RIGHT(PrdONumber, 4)) AS SS, RIGHT(CONVERT(nvarchar, GETDATE(), 112), 6) AS s FROM   t_PrdOrder WHERE (RIGHT(CONVERT(nvarchar, GETDATE(), 112), 6) = LEFT(RIGHT(PrdONumber, 10), 6)) ORDER BY SS DESC";
                DataSet dsGen = new DataSet(); dsGen = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (dsGen.Tables[0].Rows.Count == 0)
                {
                    NP_Cls.SqlSelect = "SELECT  TOP (1) RIGHT(CONVERT(nvarchar, GETDATE(), 112), 6) AS s";
                    return "PD" + NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0].Rows[0][0].ToString() + "0001";
                }
                else
                {
                    //string strCode = (Convert.ToInt16(dsGen.Tables[0].Rows[0][0].ToString()) + 1).ToString().PadLeft(5 - (Convert.ToInt16(dsGen.Tables[0].Rows[0][0].ToString()) + 1).ToString().Length, '0');
                    string strCode = (Convert.ToInt16(dsGen.Tables[0].Rows[0][0].ToString()) + 1).ToString().PadLeft(4, '0');
                    return "PD" + dsGen.Tables[0].Rows[0][1].ToString() + strCode;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void cbMaterialCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.cbMaterialCode.SelectedIndex != 0) && (!string.IsNullOrEmpty(this.cbMaterialCode.Text.Trim())))
            {
                this.lblMaterial.Text = this.cbMaterialCode.SelectedValue.ToString(); hsTmp.Clear();
                DataSet dsDetail = new DataSet();

                NP_Cls.SqlSelect = "SELECT  t_BOM.BOMType, m_Material.MaterialName, m_Material.MaterialCode, m_Location.LocName, m_Plant.PlantName, t_BOM.BOMVersion, m_Location.LocCode,         m_Plant.PlantCode  FROM  m_Material INNER JOIN  t_BOM ON m_Material.MaterialCode = t_BOM.MaterialCode LEFT OUTER JOIN m_Plant ON t_BOM.PlantCode = m_Plant.PlantCode LEFT OUTER JOIN m_Location ON m_Material.LocCode = m_Location.LocCode WHERE (m_Material.MaterialCode = N'" + this.cbMaterialCode.Text.Trim() + "') AND (t_BOM.FileStatus = N'1') AND (t_BOM.Approve = 1)";
                dsDetail = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (dsDetail.Tables[0].Rows.Count == 0)
                {
                    //NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "This material code have not BOM yet !!\nTry to create BOM first .."); Clear(); MyGrid(this.dgvView);
                    this.btnSave.Visible = false; this.cbMaterialCode.Select(); this.cbMaterialCode.SelectAll(); return;
                }
                this.lblPlant.Text = dsDetail.Tables[0].Rows[0]["PlantName"].ToString(); hsTmp.Add("LocCode", dsDetail.Tables[0].Rows[0]["LocCode"].ToString());
                this.lblLocation.Text = dsDetail.Tables[0].Rows[0]["LocName"].ToString(); hsTmp.Add("PlantCode", dsDetail.Tables[0].Rows[0]["PlantCode"].ToString());
                this.lblBOMVer.Text = dsDetail.Tables[0].Rows[0]["BOMVersion"].ToString(); this.txtQty.Select(); this.txtQty.SelectAll();
                // Check Bom Type IsType Pack
                if (dsDetail.Tables[0].Rows[0]["BOMType"].ToString() == "P")
                {
                    dgvView.Columns["clnQuantity"].ReadOnly = false;
                }
                else
                {
                    dgvView.Columns["clnQuantity"].ReadOnly = true;
                }
            }
            else
            {
                Clear(); hsTmp.Clear(); MyGrid(this.dgvView);
                this.cbMaterialCode.Focus();
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
        private void frmPrdOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (NP_Cls.FromMRP == 0)
            {
                WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
                frm.menuStrip1.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (NP.MSGB("Do you to Save Production Order ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(Application.StartupPath + @"\DB\DB.ini"));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr;
                Tr = oConn.BeginTransaction();

                try
                {
                    if (!Convert.ToBoolean(bView))
                    {
                        SqlCommand cmdIns = new SqlCommand();
                        NP_Cls.SqlInsert = "INSERT INTO t_PrdOrder   (PrdONumber, PrdODate, MaterialCode, MaterialName, PrdQuantity, PlantCode, PlantName, BOMVersion, LocCode, LocName, Remark, UserCreate, DateCreate, MRPOrder) VALUES (@PrdONumber,GETDATE(),@MaterialCode,@MaterialName,@PrdQuantity,@PlantCode,@PlantName,@BOMVersion,@LocCode,@LocName,@Remark,@UserCreate,  GETDATE(), @MRPOrder)";
                        cmdIns.Parameters.Add("@PrdONumber", SqlDbType.NVarChar, 12).Value = this.txtPrdOrder.Text.Trim();
                        cmdIns.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15).Value = this.cbMaterialCode.Text.Trim();
                        cmdIns.Parameters.Add("@MaterialName", SqlDbType.NVarChar, 60).Value = this.lblMaterial.Text.Trim();
                        cmdIns.Parameters.Add("@PrdQuantity", SqlDbType.Decimal).Value = Convert.ToDecimal(this.txtQty.Text.Trim());
                        cmdIns.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 4).Value = hsTmp["PlantCode"].ToString();
                        cmdIns.Parameters.Add("@PlantName", SqlDbType.NVarChar, 20).Value = this.lblPlant.Text.Trim();
                        cmdIns.Parameters.Add("@BOMVersion", SqlDbType.Int).Value = Convert.ToInt32(this.lblBOMVer.Text.Trim());
                        cmdIns.Parameters.Add("@LocCode", SqlDbType.NVarChar, 2).Value = hsTmp["LocCode"].ToString();
                        cmdIns.Parameters.Add("@LocName", SqlDbType.NVarChar, 20).Value = this.lblLocation.Text.Trim();
                        cmdIns.Parameters.Add("@Remark", SqlDbType.NVarChar, 255).Value = this.txtRemark.Text.Trim();
                        cmdIns.Parameters.Add("@UserCreate", SqlDbType.NVarChar, 50).Value = NP_Cls.strUsr;
                        cmdIns.Parameters.Add("@MRPOrder", SqlDbType.NVarChar, 12).Value = (NP_Cls.FromMRP == 1 ? NP_Cls.MRPSO : string.Empty);
                        cmdIns.Connection = oConn; cmdIns.Transaction = Tr; cmdIns.CommandText = NP_Cls.SqlInsert;
                        cmdIns.ExecuteNonQuery();

                        SqlCommand cmdInsDetail = new SqlCommand();
                        NP_Cls.SqlInsert = "INSERT INTO t_PrdOrderDetail (PrdONumber, ComponentCode, ComponentName, PrdOQuantity, UnitCode, UnitName, PlantCode, PlantName, LocCode, LocName, CurrentUser) VALUES     (@PrdONumber,@ComponentCode,@ComponentName,@PrdOQuantity,@UnitCode,@UnitName,@PlantCode,@PlantName,@LocCode,@LocName,@CurrentUser)";
                        cmdInsDetail.Parameters.Add("@PrdONumber", SqlDbType.NVarChar, 12);
                        cmdInsDetail.Parameters.Add("@ComponentCode", SqlDbType.NVarChar, 15);
                        cmdInsDetail.Parameters.Add("@ComponentName", SqlDbType.NVarChar, 60);
                        cmdInsDetail.Parameters.Add("@PrdOQuantity", SqlDbType.Decimal);
                        cmdInsDetail.Parameters.Add("@UnitCode", SqlDbType.NVarChar, 3);
                        cmdInsDetail.Parameters.Add("@UnitName", SqlDbType.NVarChar, 20);
                        cmdInsDetail.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 4);
                        cmdInsDetail.Parameters.Add("@PlantName", SqlDbType.NVarChar, 20);
                        cmdInsDetail.Parameters.Add("@LocCode", SqlDbType.NVarChar, 2);
                        cmdInsDetail.Parameters.Add("@LocName", SqlDbType.NVarChar, 20);
                        cmdInsDetail.Parameters.Add("@CurrentUser", SqlDbType.NVarChar, 50);

                        for (byte ins = 0; ins < this.dgvView.RowCount; ins++)
                        {
                            cmdInsDetail.Parameters["@PrdONumber"].Value = this.txtPrdOrder.Text.Trim();
                            cmdInsDetail.Parameters["@ComponentCode"].Value = this.dgvView["clnMaterialCode", ins].Value.ToString();
                            cmdInsDetail.Parameters["@ComponentName"].Value = this.dgvView["clnMaterialName", ins].Value.ToString();
                            cmdInsDetail.Parameters["@PrdOQuantity"].Value = Convert.ToDecimal(this.dgvView["clnQuantity", ins].Value);
                            cmdInsDetail.Parameters["@UnitCode"].Value = this.dgvView["clnUnitCode", ins].Value.ToString();
                            cmdInsDetail.Parameters["@UnitName"].Value = this.dgvView["clnUnitName", ins].Value.ToString();
                            cmdInsDetail.Parameters["@CurrentUser"].Value = NP_Cls.strUsr;
                            cmdInsDetail.Parameters["@PlantCode"].Value = this.dgvView["clnPlantCode", ins].Value.ToString();
                            cmdInsDetail.Parameters["@PlantName"].Value = this.dgvView["clnPlantName", ins].Value.ToString();
                            cmdInsDetail.Parameters["@LocCode"].Value = this.dgvView["clnLocCode", ins].Value.ToString();
                            cmdInsDetail.Parameters["@LocName"].Value = this.dgvView["clnLocName", ins].Value.ToString();

                            cmdInsDetail.Connection = oConn; cmdInsDetail.CommandText = NP_Cls.SqlInsert; cmdInsDetail.Transaction = Tr;
                            cmdInsDetail.ExecuteNonQuery();
                        }

                        //TODO 14.11.10 Prd Order from MRP
                        if (NP_Cls.FromMRP == 1)
                        {
                            SqlCommand cmdMRP = new SqlCommand();
                            cmdMRP.Parameters.Add("@MatCode", SqlDbType.NVarChar, 15).Value = NP_Cls.MRPFGSort;
                            cmdMRP.Parameters.Add("@TranOrder", SqlDbType.NVarChar, 50).Value = this.txtPrdOrder.Text.Trim();
                            cmdMRP.Parameters.Add("@TranQty", SqlDbType.Decimal).Value = Convert.ToDecimal(this.txtQty.Text.Trim());
                            cmdMRP.Parameters.Add("@SONumber", SqlDbType.NVarChar, 50).Value = NP_Cls.MRPSO;

                            NP_Cls.SqlInsert = "INSERT INTO t_MRPTranOrder (MaterialCode,TranOrder,TranQty,SONumber,MaterialHeader) VALUES (@MatCode,@TranOrder,@TranQty,@SONumber,@MatCode)";
                            cmdMRP.CommandText = NP_Cls.SqlInsert; cmdMRP.Connection = oConn;
                            cmdMRP.Transaction = Tr; cmdMRP.ExecuteNonQuery();

                            Tr.Commit();
                            NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Save Prd Order Completed !! this screen will be close ..");
                            NP_Cls.MRPTranOrder = this.txtPrdOrder.Text.Trim(); this.Close(); return;
                        }
                        //

                        Tr.Commit(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Save Production Order Completed !!");
                        Clear(); this.btnSave.Visible = false;
                        this.MyGrid(dgvView); this.txtPrdOrder.DropDownStyle = ComboBoxStyle.Simple;
                        BindMat();
                        this.cbMaterialCode.Enabled = true; this.txtPrdOrder.Text = GetNumber();
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
        private void btnGenNew_Click(object sender, EventArgs e)
        {
            Clear(); this.txtPrdOrder.DropDownStyle = ComboBoxStyle.Simple; this.cbMaterialCode.Enabled = true; this.txtQty.Enabled = true; this.txtRemark.Enabled = true; this.btnPicking.Visible = false;
            this.btnSave.Visible = false; this.MyGrid(dgvView); this.txtPrdOrder.Text = GetNumber(); this.btnRunProd.Visible = true; this.btnSave.Visible = false; this.btnUpdate.Visible = false; this.btnCancel.Visible = false;
            this.cbMaterialCode.Text = string.Empty; this.cbMaterialCode.Select();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Clear(); this.txtPrdOrder.DropDownStyle = ComboBoxStyle.DropDownList; this.txtPrdOrder.Text = string.Empty; this.cbMaterialCode.Text = string.Empty; this.btnPicking.Visible = false;
            cbMaterialCode.Enabled = true; NP_Cls.SqlSelect = "SELECT PrdONumber, PrdONumber AS PrdODis FROM t_PrdOrder where OrderStatus Is Null";
            NP.BindCB(this.txtPrdOrder, NP_Cls.SqlSelect, "PrdONumber", "PrdODis", "( Select PrdOrder Number )"); this.btnUpdate.Visible = false;
            this.btnSave.Visible = false; this.MyGrid(dgvView); this.txtPrdOrder.Text = GetNumber(); this.txtPrdOrder.SelectedIndex = 0;
        }

        private void txtPrdOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.txtPrdOrder.SelectedIndex != 0)
            {
                //NP_Cls.SqlSelect = "SELECT     1 AS ItemNo, t_PrdOrder.PrdODate, t_PrdOrder.MaterialCode AS HMatCode, t_PrdOrder.MaterialName AS HMatName, t_PrdOrder.PrdQuantity,  t_PrdOrder.PlantCode AS HPlantCode,  t_PrdOrder.PlantName AS HPlant, t_PrdOrder.BOMVersion, t_PrdOrder.LocCode AS HLocCode,t_PrdOrder.LocName AS HLoc, t_PrdOrderDetail.ComponentCode AS MaterialCode,  t_PrdOrderDetail.ComponentName AS MaterialName, CAST(ROUND((t_PrdOrderDetail.PrdOQuantity / isnull(t_VendorInfoRecord.QtyConversion,1)),3)as Decimal(18,3)) AS Qty, isnull(t_VendorInfoRecord.UnitCode,t_PrdOrderDetail.UnitCode) as UnitCode, isnull(m_Unit.UnitName, t_PrdOrderDetail.UnitName) as UnitName, t_PrdOrderDetail.PlantCode, t_PrdOrderDetail.PlantName, t_PrdOrderDetail.LocCode, t_PrdOrderDetail.LocName, t_PrdOrder.Remark, t_PrdOrder.IsPicking FROM  t_PrdOrder INNER JOIN  t_PrdOrderDetail ON t_PrdOrder.PrdONumber = t_PrdOrderDetail.PrdONumber LEFT OUTER JOIN t_VendorInfoRecord ON t_VendorInfoRecord.MaterialCode = t_PrdOrderDetail.ComponentCode left outer join m_Unit on  m_Unit.UnitCode = t_VendorInfoRecord.UnitCode WHERE     (t_PrdOrder.PrdONumber = N'" + this.txtPrdOrder.Text.Trim() + "')";
                NP_Cls.SqlSelect = "SELECT   DISTINCT  1 AS ItemNo, t_PrdOrder.PrdODate, t_PrdOrder.MaterialCode AS HMatCode, t_PrdOrder.MaterialName AS HMatName, t_PrdOrder.PrdQuantity,  t_PrdOrder.PlantCode AS HPlantCode,  t_PrdOrder.PlantName AS HPlant, t_PrdOrder.BOMVersion, t_PrdOrder.LocCode AS HLocCode,t_PrdOrder.LocName AS HLoc, t_PrdOrderDetail.ComponentCode AS MaterialCode,  t_PrdOrderDetail.ComponentName AS MaterialName, CAST(ROUND(t_PrdOrderDetail.PrdOQuantity,3)as Decimal(18,3)) AS Qty, isnull(t_VendorInfoRecord.UnitCode,t_PrdOrderDetail.UnitCode) as UnitCode, isnull(m_Unit.UnitName, t_PrdOrderDetail.UnitName) as UnitName, t_PrdOrderDetail.PlantCode, t_PrdOrderDetail.PlantName, t_PrdOrderDetail.LocCode, t_PrdOrderDetail.LocName, t_PrdOrder.Remark, t_PrdOrder.IsPicking FROM  t_PrdOrder INNER JOIN  t_PrdOrderDetail ON t_PrdOrder.PrdONumber = t_PrdOrderDetail.PrdONumber LEFT OUTER JOIN t_VendorInfoRecord ON t_VendorInfoRecord.MaterialCode = t_PrdOrderDetail.ComponentCode left outer join m_Unit on  m_Unit.UnitCode = t_VendorInfoRecord.UnitCode WHERE     (t_PrdOrder.PrdONumber = N'" + this.txtPrdOrder.Text.Trim() + "')";
                DataSet dsTmp = new DataSet(); dsTmp = NP.GetClientDataSet(NP_Cls.SqlSelect); this.cbMaterialCode.SelectedIndex = 0;
                this.cbMaterialCode.SelectedValue = dsTmp.Tables[0].Rows[0]["HMatName"].ToString();
                this.lblMaterial.Text = dsTmp.Tables[0].Rows[0]["HMatName"].ToString(); this.txtRemark.Text = dsTmp.Tables[0].Rows[0]["Remark"].ToString();
                this.lblLocation.Text = dsTmp.Tables[0].Rows[0]["HLoc"].ToString(); this.lblPlant.Text = dsTmp.Tables[0].Rows[0]["HPlant"].ToString();
                this.lblBOMVer.Text = dsTmp.Tables[0].Rows[0]["BOMVersion"].ToString(); this.txtQty.Text = Convert.ToDouble(dsTmp.Tables[0].Rows[0]["PrdQuantity"]).ToString();
                this.txtDocDate.Text = Convert.ToDateTime(dsTmp.Tables[0].Rows[0]["PrdODate"]).ToString("dd/MM/yyyy");

                this.strLocCode = dsTmp.Tables[0].Rows[0]["HLocCode"].ToString(); this.strMatCode = dsTmp.Tables[0].Rows[0]["HMatCode"].ToString();
                this.strPlantCode = dsTmp.Tables[0].Rows[0]["HPlantCode"].ToString();

                this.cbMaterialCode.Enabled = false; this.txtQty.Enabled = false; this.txtRemark.Enabled = false; this.btnRunProd.Visible = false; this.btnSave.Visible = false; this.btnUpdate.Visible = true;
                dsTmp.Tables[0].Columns.Remove("HMatCode"); dsTmp.Tables[0].Columns.Remove("HMatName");
                dsTmp.Tables[0].Columns.Remove("Remark"); dsTmp.Tables[0].Columns.Remove("HLoc"); dsTmp.Tables[0].Columns.Remove("HLocCode");
                dsTmp.Tables[0].Columns.Remove("BOMVersion"); dsTmp.Tables[0].Columns.Remove("HPlant"); dsTmp.Tables[0].Columns.Remove("HPlantCode");
                dsTmp.Tables[0].Columns.Remove("PrdQuantity"); dsTmp.Tables[0].Columns.Remove("PrdODate");
                for (byte ii = 0; ii < dsTmp.Tables[0].Rows.Count; ii++)
                {
                    dsTmp.Tables[0].Rows[ii]["ItemNo"] = Convert.ToInt32(ii + 1);
                }
                //ToDo 0510 IsPicking
                this.btnPicking.Visible = !Convert.ToBoolean(dsTmp.Tables[0].Rows[0]["IsPicking"]);
                this.btnCancel.Visible = Convert.ToBoolean(dsTmp.Tables[0].Rows[0]["IsPicking"]);
                this.lblAl.Visible = Convert.ToBoolean(dsTmp.Tables[0].Rows[0]["IsPicking"]);
                this.btnUpdate.Visible = !lblAl.Visible;
                this.btnCancel.Visible = !lblAl.Visible;
                this.btnReport.Visible = Convert.ToBoolean(dsTmp.Tables[0].Rows[0]["IsPicking"]);
                this.dgvView.DataSource = dsTmp.Tables[0];
            }
            else
            {
                this.MyGrid(this.dgvView); this.btnPicking.Visible = false; Clear();
            }
        }
        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            NP_Cls.myDecimal(sender, e);
        }
        private void btnRunProd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.txtQty.Text.Trim()))
                {
                    if (Convert.ToDouble(this.txtQty.Text.Trim()) <= 0)
                    {
                        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please enter Qty: greater than 0 !!"); this.txtQty.Select(); this.txtQty.SelectAll(); return;
                    }
                    //NP_Cls.SqlSelect = "SELECT     1 AS ItemNo, t_MRPBOM.ComponentCode AS MaterialCode, m_Material.MaterialName, t_MRPBOM.ComponentQty AS Qty, m_Material.UnitCode, m_Unit.UnitName, m_Material.PlantCode, m_Plant.PlantName, m_Material.LocCode, m_Location.LocName FROM t_MRPBOM LEFT OUTER JOIN  m_Material ON t_MRPBOM.ComponentCode = m_Material.MaterialCode LEFT OUTER JOIN  m_Location ON m_Material.LocCode = m_Location.LocCode LEFT OUTER JOIN m_Plant ON m_Material.PlantCode = m_Plant.PlantCode LEFT OUTER JOIN  m_Unit ON m_Material.UnitCode = m_Unit.UnitCode WHERE (t_MRPBOM.HeadBomCode = N'" + this.cbMaterialCode.Text.Trim() + "')"; 
                    NP_Cls.SqlSelect = "SELECT DISTINCT 1 AS ItemNo,isnull(t_VendorInfoRecord.QtyConversion,1) as QtyConversion, t_BOMDetail.MaterialCode, m_Material.MaterialName, t_BOMDetail.Quantity AS Qty, isnull(t_VendorInfoRecord.UnitCode,m_Material.UnitCode) as UnitCode , isnull(m_Unit2.UnitName,m_Unit.UnitName) as UnitName ,                  m_Location.LocName, m_Plant.PlantName,t_BOMDetail.LossPercentage,t_BOM.Quantity, m_Material.PlantCode, m_Material.LocCode  FROM m_Location RIGHT OUTER JOIN t_BOM INNER JOIN t_BOMDetail ON t_BOM.BOMCode = t_BOMDetail.BOMCode LEFT OUTER JOIN t_VendorInfoRecord ON t_VendorInfoRecord.MaterialCode = t_BOMDetail.MaterialCode LEFT OUTER JOIN              m_Plant RIGHT OUTER JOIN  m_Material ON m_Plant.PlantCode = m_Material.PlantCode LEFT OUTER JOIN m_Unit ON m_Material.UnitCode = m_Unit.UnitCode ON t_BOMDetail.MaterialCode = m_Material.MaterialCode ON     m_Location.LocCode = m_Material.LocCode left outer join m_Unit as m_Unit2 on  m_Unit2.UnitCode = t_VendorInfoRecord.UnitCode WHERE     (t_BOM.MaterialCode = N'" + this.cbMaterialCode.Text.Trim() + "') AND (t_BOM.FileStatus = N'1') AND (t_BOM.Approve = 1)";
                    DataSet dsTmp = new DataSet(); dsTmp = NP.GetClientDataSet(NP_Cls.SqlSelect);
                    if (dsTmp.Tables[0].Rows.Count == 0)
                    {
                        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "This BOM is inactive !!");
                        this.btnSave.Visible = false; this.cbMaterialCode.Select(); this.cbMaterialCode.SelectAll(); return;
                    }
                    else
                    {
                        this.btnSave.Visible = true; this.btnUpdate.Visible = false;
                    }
                    for (byte ii = 0; ii < dsTmp.Tables[0].Rows.Count; ii++)
                    {
                        // Trimatic
                        double dBomQty = Convert.ToDouble(this.txtQty.Text.Trim());
                        double dLoss = Convert.ToDouble(dsTmp.Tables[0].Rows[ii]["LossPercentage"]);
                        double dQty = Convert.ToDouble(dsTmp.Tables[0].Rows[ii]["Qty"]);
                        double dMLoss = dQty + ((dQty * dLoss) / 100);
                        double dBomMasterQty = Convert.ToDouble(dsTmp.Tables[0].Rows[ii]["Quantity"]);
                        double dComReq = (dBomQty * dMLoss) / dBomMasterQty;
                        double dQtyConversion = Convert.ToDouble(dsTmp.Tables[0].Rows[ii]["QtyConversion"]);
                        double dResult = dComReq / dQtyConversion;
                        dsTmp.Tables[0].Rows[ii]["Qty"] = Math.Round(dResult, 3);
                        dsTmp.Tables[0].Rows[ii]["ItemNo"] = Convert.ToInt32(ii + 1);
                    }
                    dsTmp.Tables[0].Columns.Remove("LossPercentage"); dsTmp.Tables[0].Columns.Remove("Quantity");
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
                        this.btnRunProd_Click(sender, e);
                    }
                }
                else
                {
                    this.txtQty.Select(); this.txtQty.SelectAll();
                }
            }
        }
        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtQty.Text.Trim()))
            {
                if (Convert.ToDecimal(this.txtQty.Text.Trim()) > 0)
                {
                    this.MyGrid(this.dgvView);
                    this.btnRunProd_Click(sender, e);
                }
                else { this.MyGrid(this.dgvView); }
            }
            else { this.MyGrid(this.dgvView); }
        }

        private void btnPicking_Click(object sender, EventArgs e)
        {
            frmPicking frm = new frmPicking(); frm.Width = 750;
            frm.txtProdOrder.Text = this.txtPrdOrder.Text.Trim(); frm.lblMatName.Text = this.lblMaterial.Text.Trim();
            frm.lblLoc.Text = this.lblLocation.Text.Trim(); frm.lblPlant.Text = this.lblPlant.Text.Trim(); frm.lblBOMVer.Text = this.lblBOMVer.Text.Trim();
            frm.lblLocCode.Text = this.strLocCode; frm.lblPlantCode.Text = strPlantCode; frm.lblMatCode.Text = strMatCode; frm.lblPrdQty.Text = this.txtQty.Text.Trim();
            frm.ShowDialog(); frm.Dispose();

            //ToDo 0710
            NP_Cls.SqlSelect = "SELECT  DISTINCT   1 AS ItemNo, t_PrdOrder.PrdODate, t_PrdOrder.MaterialCode AS HMatCode, t_PrdOrder.MaterialName AS HMatName, t_PrdOrder.PrdQuantity,  t_PrdOrder.PlantCode AS HPlantCode,  t_PrdOrder.PlantName AS HPlant, t_PrdOrder.BOMVersion, t_PrdOrder.LocCode AS HLocCode,t_PrdOrder.LocName AS HLoc, t_PrdOrderDetail.ComponentCode AS MaterialCode,  t_PrdOrderDetail.ComponentName AS MaterialName, t_PrdOrderDetail.PrdOQuantity AS Qty, t_PrdOrderDetail.UnitCode, t_PrdOrderDetail.UnitName, t_PrdOrderDetail.PlantCode, t_PrdOrderDetail.PlantName, t_PrdOrderDetail.LocCode, t_PrdOrderDetail.LocName, t_PrdOrder.Remark, t_PrdOrder.IsPicking FROM  t_PrdOrder INNER JOIN  t_PrdOrderDetail ON t_PrdOrder.PrdONumber = t_PrdOrderDetail.PrdONumber WHERE     (t_PrdOrder.PrdONumber = N'" + this.txtPrdOrder.Text.Trim() + "')";
            DataSet dsTmp = new DataSet(); dsTmp = NP.GetClientDataSet(NP_Cls.SqlSelect); this.cbMaterialCode.SelectedIndex = 0;
            this.cbMaterialCode.SelectedValue = dsTmp.Tables[0].Rows[0]["HMatName"].ToString();
            this.lblMaterial.Text = dsTmp.Tables[0].Rows[0]["HMatName"].ToString(); this.txtRemark.Text = dsTmp.Tables[0].Rows[0]["Remark"].ToString();
            this.lblLocation.Text = dsTmp.Tables[0].Rows[0]["HLoc"].ToString(); this.lblPlant.Text = dsTmp.Tables[0].Rows[0]["HPlant"].ToString();
            this.lblBOMVer.Text = dsTmp.Tables[0].Rows[0]["BOMVersion"].ToString(); this.txtQty.Text = Convert.ToDouble(dsTmp.Tables[0].Rows[0]["PrdQuantity"]).ToString();
            this.txtDocDate.Text = Convert.ToDateTime(dsTmp.Tables[0].Rows[0]["PrdODate"]).ToString("dd/MM/yyyy");

            this.strLocCode = dsTmp.Tables[0].Rows[0]["HLocCode"].ToString(); this.strMatCode = dsTmp.Tables[0].Rows[0]["HMatCode"].ToString();
            this.strPlantCode = dsTmp.Tables[0].Rows[0]["HPlantCode"].ToString();

            this.cbMaterialCode.Enabled = false; this.txtQty.Enabled = false; this.txtRemark.Enabled = false; this.btnRunProd.Visible = false; this.btnSave.Visible = false;
            dsTmp.Tables[0].Columns.Remove("HMatCode"); dsTmp.Tables[0].Columns.Remove("HMatName");
            dsTmp.Tables[0].Columns.Remove("Remark"); dsTmp.Tables[0].Columns.Remove("HLoc"); dsTmp.Tables[0].Columns.Remove("HLocCode");
            dsTmp.Tables[0].Columns.Remove("BOMVersion"); dsTmp.Tables[0].Columns.Remove("HPlant"); dsTmp.Tables[0].Columns.Remove("HPlantCode");
            dsTmp.Tables[0].Columns.Remove("PrdQuantity"); dsTmp.Tables[0].Columns.Remove("PrdODate");
            for (byte ii = 0; ii < dsTmp.Tables[0].Rows.Count; ii++)
            {
                dsTmp.Tables[0].Rows[ii]["ItemNo"] = Convert.ToInt32(ii + 1);
            }
            //ToDo 0510 IsPicking
            this.btnPicking.Visible = !Convert.ToBoolean(dsTmp.Tables[0].Rows[0]["IsPicking"]);
            this.lblAl.Visible = Convert.ToBoolean(dsTmp.Tables[0].Rows[0]["IsPicking"]);
            this.btnUpdate.Visible = !lblAl.Visible;
            this.btnCancel.Visible = !lblAl.Visible;
            dsTmp.Tables[0].Columns.Remove("IsPicking");

            this.dgvView.DataSource = dsTmp.Tables[0];
        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            //TODO Picking 2809
            //Report
            NP_Cls.SqlSelect = "SELECT 0 AS ItemNo,     t_Picking.PrdONumber, t_Picking.PickingDate, t_Picking.MaterialCode, t_Picking.MaterialName, t_Picking.PrdQuantity, t_Picking.PlantCode, t_Picking.PlantName,                        t_Picking.BOMVersion, t_Picking.LocCode, t_Picking.LocName, t_Picking.PickingID, t_PickingDetail.PickingDetailID, t_PickingDetail.ComponentCode,                        t_PickingDetail.ComponentName, t_PickingDetail.PickingQuantity, t_PickingDetail.ShortQuantity, t_PickingDetail.UnitCode, t_PickingDetail.UnitName,                        t_PickingDetail.PlantCode AS cPlantCode, t_PickingDetail.PlantName AS cPlantName, t_PickingDetail.LocCode AS cLocCode, t_PickingDetail.LocName AS cLocName,                        t_PickingDetail.BatchNumber, CASE WHEN t_PickingDetail.ShortQuantity = 0 THEN '' WHEN t_PickingDetail.ShortQuantity > 0 THEN '***' END AS SH FROM         t_Picking INNER JOIN                       t_PickingDetail ON t_Picking.PickingID = t_PickingDetail.PickingID WHERE  (t_Picking.PrdONumber = N'" + this.txtPrdOrder.Text.Trim() + "')";
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

                NP_Cls.SqlSelect = "SELECT        t_Picking.PrdONumber, t_Picking.PickingDate, t_Picking.MaterialCode, t_Picking.MaterialName, t_Picking.PrdQuantity, t_Picking.PlantCode, t_Picking.PlantName,                           t_Picking.BOMVersion, t_Picking.LocCode, t_Picking.LocName, t_Picking.PickingID, t_PickingDetail.PickingDetailID, t_PickingDetail.ComponentCode,                           t_PickingDetail.ComponentName, t_PickingDetail.PickingQuantity, t_PickingDetail.ShortQuantity, t_PickingDetail.UnitCode, t_PickingDetail.UnitName,                           t_PickingDetail.PlantCode AS cPlantCode, t_PickingDetail.PlantName AS cPlantName, t_PickingDetail.LocCode AS cLocCode, t_PickingDetail.LocName AS cLocName,                           t_PickingDetail.BatchNumber, CASE WHEN t_PickingDetail.ShortQuantity = 0 THEN '' WHEN t_PickingDetail.ShortQuantity > 0 THEN '***' END AS SH,                           t_RoutingDetail.WorkCenterCode FROM            t_Picking INNER JOIN                          t_PickingDetail ON t_Picking.PickingID = t_PickingDetail.PickingID INNER JOIN                          t_RoutingDetail ON t_Picking.MaterialCode = t_RoutingDetail.MaterialCode WHERE  (t_Picking.PrdONumber = N'" + this.txtPrdOrder.Text.Trim() + "')";
                ds = new DataSet();
                ds = NP.GetClientDataSet(NP_Cls.SqlSelect);
                rptV.dsReportB = ds.Copy();

                rptV.ShowDialog();
            }
            else
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found !! Report !!"); return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (NP.MSGB("Do you want to Cancel this Order ?") == DialogResult.Yes)
            {
                NP_Cls.SqlSelect = "UPDATE t_PrdOrder SET OrderStatus = 'Cancel' WHERE (PrdONumber = @PrdOrder)";
                oConn = new SqlConnection(NP.ReadFileDB(Application.StartupPath + @"\DB\DB.ini"));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlCommand cmd = new SqlCommand();
                try
                {
                    cmd.Parameters.Add("@PrdOrder", SqlDbType.NVarChar, 12).Value = this.txtPrdOrder.Text.Trim();
                    cmd.CommandText = NP_Cls.SqlSelect;
                    cmd.Connection = oConn; cmd.ExecuteNonQuery();

                    NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Cancel Production Order Completed !!");
                    Clear(); this.btnSave.Visible = false; this.btnUpdate.Visible = false;
                    this.MyGrid(dgvView); this.txtPrdOrder.DropDownStyle = ComboBoxStyle.Simple; this.btnCancel.Visible = false;
                    BindMat();
                    this.cbMaterialCode.Enabled = true; this.txtPrdOrder.Text = GetNumber();
                    this.cbMaterialCode.Text = string.Empty; this.cbMaterialCode.Select(); this.cbMaterialCode.SelectAll();
                }
                catch (Exception ex)
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, ex.Message); return;
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (NP.MSGB("Do you want to Save this Order ?") == DialogResult.Yes)
            {
                try
                {
                    NP_Cls.sqlUpdate = "UPDATE t_PrdOrderDetail SET PrdOQuantity = @PrdOQuantity WHERE (PrdONumber = @PrdONumber) AND (ComponentCode = @ComponentCode)";
                    oConn = new SqlConnection(NP.ReadFileDB(Application.StartupPath + @"\DB\DB.ini"));
                    if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                    oConn.Open(); SqlCommand cmd = new SqlCommand();

                    cmd.Parameters.Add("@PrdONumber", SqlDbType.NVarChar, 12);
                    cmd.Parameters.Add("@ComponentCode", SqlDbType.NVarChar, 15);
                    cmd.Parameters.Add("@PrdOQuantity", SqlDbType.Decimal);

                    for (byte ins = 0; ins < this.dgvView.RowCount; ins++)
                    {
                        cmd.Parameters["@PrdONumber"].Value = this.txtPrdOrder.Text.Trim();
                        cmd.Parameters["@ComponentCode"].Value = this.dgvView["clnMaterialCode", ins].Value.ToString();
                        cmd.Parameters["@PrdOQuantity"].Value = Convert.ToDecimal(this.dgvView["clnQuantity", ins].Value);

                        cmd.CommandText = NP_Cls.sqlUpdate;
                        cmd.Connection = oConn; cmd.ExecuteNonQuery();
                    }

                    NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Save Production Order Completed !!");
                }
                catch (Exception ex)
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, ex.Message); return;
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
