using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;
using System.IO;

namespace WMS.BOM
{
    public partial class frmBOMNew : Form
    {
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection(); private string strVersion = string.Empty; 
        public frmBOMNew()
        {
            InitializeComponent();
        }
        private void frmBOMNew_Load(object sender, EventArgs e)
        {           
       
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;

            //if ((NP_Cls.dsAuth.Tables[0].Rows[0]["DepartmentCode"].ToString().ToUpper() == NP_Cls.pRD) && (NP_Cls.dsAuth.Tables[0].Rows[0]["AuthLevel"].ToString() == "5"))
            //{
            //    this.contextMenuStrip1.Items[0].Visible = true;
            //}
            
            //if ((NP_Cls.dsAuth.Tables[0].Rows[0]["DepartmentCode"].ToString().ToUpper() == NP_Cls.pAMT) && (NP_Cls.dsAuth.Tables[0].Rows[0]["AuthLevel"].ToString() == "5"))
            //{
            //    this.contextMenuStrip1.Items[0].Visible = true;
            //}

            if (NP_Cls.AppBOM == 1) { this.contextMenuStrip1.Items[0].Visible = true; }

            DataSet dsBT = new DataSet(); dsBT.ReadXml(NP_Cls.PathBT); DataRow dr = dsBT.Tables[0].NewRow();
            dr[0] = 0; dr[1] = "((( Select B.O.M Type )))";
            dsBT.Tables[0].Rows.InsertAt(dr, 0);
            dsBT.AcceptChanges();
            this.cbBOMType.DataSource = dsBT.Tables[0];
            this.cbBOMType.DisplayMember = "BTDesc"; this.cbBOMType.ValueMember = "BTCode";

            NP_Cls.SqlSelect = "SELECT MaterialCode, MaterialCode + ':' + MaterialName AS MaterialName FROM m_Material WHERE (FileStatus = '1')";
            NP.BindCB(this.cbMaterial, NP_Cls.SqlSelect, "MaterialCode", "MaterialName", "((( Select Material )))");
            this.cbMaterial.Text = string.Empty;

            NP_Cls.SqlSelect = "SELECT PlantCode, PlantName FROM m_Plant WHERE (FileStatus = '1')";
            NP.BindCB(this.cbPlant, NP_Cls.SqlSelect, "PlantCode", "PlantName", "((( Select Plant )))");

            NP_Cls.SqlSelect = "SELECT UnitCode, UnitName FROM m_Unit WHERE (FileStatus = '1')";
            NP.BindCB(this.cbUnit, NP_Cls.SqlSelect, "UnitCode", "UnitName", "((( Select Unit )))");

            Clear(); DGV(); this.btnEdit.Visible = false; this.cbMaterial.Select(); 
        }
        private void DGV()
        {
            NP_Cls.SqlSelect = "SELECT     0 AS ItemNo, t_BOM.BOMCode, t_BOM.MaterialCode, m_Material.MaterialName, m_Plant.PlantName, t_BOM.BOMVersion, t_BOM.Approve,  t_BOM.PlantCode, t_BOM.Quantity, m_Unit.UnitName, t_BOM.BOMType FROM         t_BOM INNER JOIN " +
                      "m_Material ON t_BOM.MaterialCode = m_Material.MaterialCode INNER JOIN "+
                      "m_Plant ON t_BOM.PlantCode = m_Plant.PlantCode INNER JOIN "+
                      "m_Unit ON t_BOM.UnitCode = m_Unit.UnitCode "+
"WHERE     (t_BOM.FileStatus = N'1') "+
"ORDER BY t_BOM.BOMVersion";
            DataSet ds = new DataSet();
            ds = NP.GetClientDataSet(NP_Cls.SqlSelect);
            ds.Tables[0].Columns.Add(new DataColumn("imgAppr", typeof(System.Byte[])));
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.contextMenuStrip1.Enabled = true;
                System.Drawing.Bitmap ImageApp = new System.Drawing.Bitmap(WMS.Properties.Resources.VerAp);
                System.Drawing.Bitmap ImageNot = new System.Drawing.Bitmap(WMS.Properties.Resources.NotAppr);
                MemoryStream stream = new MemoryStream(); MemoryStream stream2 = new MemoryStream();
                ImageApp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                ImageNot.Save(stream2, System.Drawing.Imaging.ImageFormat.Png);

                byte[] imgbyteApp; byte[] imgbyteNot;
                imgbyteApp = stream.ToArray(); imgbyteNot = stream2.ToArray();
                for (Int32 i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ds.Tables[0].Rows[i]["ItemNo"] = i + 1;
                    if (((bool)ds.Tables[0].Rows[i]["Approve"]))
                    {
                        ds.Tables[0].Rows[i]["imgAppr"] = imgbyteApp;
                    }
                    else
                    {
                        ds.Tables[0].Rows[i]["imgAppr"] = imgbyteNot;
                    }
                }
                //ds.Tables[0].Columns.Remove("Approve");
            }
            else
            {
                this.contextMenuStrip1.Enabled = false;
            }
            this.dgvView.DataSource = ds.Tables[0];
        }
        private void DGV(string strMaterial)
        {
            NP_Cls.SqlSelect = "SELECT     0 AS ItemNo, t_BOM.BOMCode, t_BOM.MaterialCode, m_Material.MaterialName, m_Plant.PlantName, t_BOM.BOMVersion, t_BOM.Approve,  t_BOM.PlantCode, t_BOM.Quantity, m_Unit.UnitName, t_BOM.BOMType FROM         t_BOM INNER JOIN " +
                        "m_Material ON t_BOM.MaterialCode = m_Material.MaterialCode INNER JOIN " +
                        "m_Plant ON t_BOM.PlantCode = m_Plant.PlantCode INNER JOIN " +
                        "m_Unit ON t_BOM.UnitCode = m_Unit.UnitCode " +
"WHERE     (t_BOM.FileStatus = N'1')  AND (t_BOM.MaterialCode = '"+ this.cbMaterial.SelectedValue +"') AND (t_BOM.PlantCode = '"+ this.cbPlant.SelectedValue +"') Order By BOMVersion";
            DataSet ds = new DataSet();
            ds = NP.GetClientDataSet(NP_Cls.SqlSelect); ds.Tables[0].Columns.Add(new DataColumn("imgAppr", typeof(System.Byte[])));
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.contextMenuStrip1.Enabled = true;
                System.Drawing.Bitmap ImageApp = new System.Drawing.Bitmap(WMS.Properties.Resources.VerAp);
                System.Drawing.Bitmap ImageNot = new System.Drawing.Bitmap(WMS.Properties.Resources.NotAppr);
                MemoryStream stream = new MemoryStream(); MemoryStream stream2 = new MemoryStream();
                ImageApp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                ImageNot.Save(stream2, System.Drawing.Imaging.ImageFormat.Png);

                byte[] imgbyteApp; byte[] imgbyteNot;
                imgbyteApp = stream.ToArray(); imgbyteNot = stream2.ToArray();
           
                for (Int32 i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ds.Tables[0].Rows[i]["ItemNo"] = i + 1;
                    if (((bool)ds.Tables[0].Rows[i]["Approve"]))
                    {
                        ds.Tables[0].Rows[i]["imgAppr"] = imgbyteApp;
                    }
                    else
                    {
                        ds.Tables[0].Rows[i]["imgAppr"] = imgbyteNot;
                    }
                }
                //ds.Tables[0].Columns.Remove("Approve");
            }
            else
            {
                this.contextMenuStrip1.Enabled = false;
            }
            this.dgvView.DataSource = ds.Tables[0]; 
        }
        private void Clear()
        {
           /* this.cbMaterial.SelectedIndex = 0;*/ this.cbPlant.SelectedIndex = 0; this.cbBOMType.SelectedIndex = 0; this.cbUnit.SelectedIndex = 0;
           this.txtQty.Text = string.Empty; this.cbMaterial.Text = string.Empty; this.txtRemark.Text = string.Empty; this.txtFor.Text = string.Empty;
        }

        private void BuildVersion()
        {
            try
            {
                NP_Cls.SqlSelect = "SELECT BOMVersion FROM t_BOM WHERE (MaterialCode = '"+ this.cbMaterial.SelectedValue +"') AND (PlantCode = '"+ this.cbPlant.SelectedValue +"') Order By BOMVersion DESC";
                DataSet ds = new DataSet(); ds = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.strVersion = (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) + 1).ToString();
                }
                else
                {
                    this.strVersion = "0";
                }
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Ver : " + ex.Message); return;
            }
        }  
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //if (NP.ReqField(this.cbMaterial, "Please enter Material: !!") == false) { return; }
            if ((string.IsNullOrEmpty((this.cbMaterial.Text.Trim()))) || (this.cbMaterial.Text.Trim() == "((( Select Material )))")) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please enter Material: !!"); this.cbMaterial.Select(); return; }
            if (NP.ReqField(this.cbPlant, "Please enter Plant: !!") == false) { return; }
            if (NP.ReqField(this.cbBOMType, "Please enter B.O.M Type: !!") == false) { return; }
            if (NP.ReqField(this.cbUnit, "Please enter Unit: !!") == false) { return; }
            if (NP.ReqField(this.txtQty, "Please enter Quantity: !!") == false) { return; }

            if (cbMaterial.Text.StartsWith("3"))
            {
                if (!NP.ReqField(this.txtFor, "please enter Formula No : !!")) { return; }
            }
            if (cbMaterial.Text.StartsWith("5") && cbBOMType.Text == "Mix")
            {
                if (!NP.ReqField(this.txtFor, "please enter Formula No : !!")) { return; }
            }
            if (ChkDup())
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Material & Plant Duplicated !!"); this.cbMaterial.Select(); return;
            }

            if (NP.MSGB("Do you want to Add BOM Data ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open();
                try
                {
                    SqlCommand cmdIns = new SqlCommand();
                   BuildVersion();
                    NP_Cls.SqlInsert = "INSERT INTO t_BOM " +
                      "(MaterialCode, PlantCode, BOMType, UnitCode, Quantity, BOMVersion, UserCreate, DateCreate, FileStatus, Approve, Remark, FormulaNo) " +
"VALUES     (@MaterialCode,@PlantCode,@BOMType,@UnitCode,@Quantity,@BOMVersion,@UC, GETDATE(),@St,@Appr, @Remark, @FormulaNo)";
                    //cmdIns.Parameters.Add("@BOMCode", SqlDbType.Int).Value = NP_Cls.strBOMCode;
                    cmdIns.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15).Value = this.cbMaterial.SelectedValue;
                    cmdIns.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 4).Value = this.cbPlant.SelectedValue;
                    cmdIns.Parameters.Add("@BOMType", SqlDbType.NVarChar, 1).Value = this.cbBOMType.SelectedValue;
                    cmdIns.Parameters.Add("@UnitCode", SqlDbType.NVarChar, 3).Value = this.cbUnit.SelectedValue;
                    cmdIns.Parameters.Add("@Quantity", SqlDbType.Decimal).Value = Convert.ToDouble(this.txtQty.Text.Trim());
                    cmdIns.Parameters.Add("@BOMVersion", SqlDbType.Int).Value = this.strVersion;
                    cmdIns.Parameters.Add("@UC", SqlDbType.NVarChar, 10).Value = NP_Cls.strUsr;
                    cmdIns.Parameters.Add("@St", SqlDbType.NVarChar, 1).Value = "1";
                    cmdIns.Parameters.Add("@Appr", SqlDbType.Bit).Value = 0;
                    cmdIns.Parameters.Add("@Remark", SqlDbType.NVarChar, 200).Value = this.txtRemark.Text.Trim();
                    cmdIns.Parameters.Add("@FormulaNo", SqlDbType.NVarChar, 200).Value = this.txtFor.Text.Trim();
                    cmdIns.Connection = oConn; cmdIns.CommandText = NP_Cls.SqlInsert; 
                    cmdIns.ExecuteNonQuery();

                    NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Add BOM Data Completed !!\n\n Please Add Component for this BOM ..");
                    this.cbUnit.Enabled = true;
                    NP_Cls.hBOM = new System.Collections.Hashtable();
                    NP_Cls.hBOM.Add("BOMCode", ((string)GenBOMCode()));
                    NP_Cls.hBOM.Add("Qty", Convert.ToDouble(this.txtQty.Text.Trim()));
                    NP_Cls.hBOM.Add("UnitName", ((string)this.cbUnit.Text));
                    NP_Cls.hBOM.Add("BOMType", ((string)this.cbBOMType.SelectedValue));
                    NP_Cls.hBOM.Add("Approve", Convert.ToBoolean(false));
                    NP_Cls.hBOM.Add("Material", this.cbMaterial.SelectedValue.ToString());

                    WMS.BOM.frmBOMNewDetail frm = new frmBOMNewDetail();

                    frm.lblSCode.Text = this.cbMaterial.SelectedValue.ToString();
                    frm.lblSName.Text = this.cbMaterial.Text.ToString().Split(':')[1].Trim();

                    frm.ShowDialog();
                    Clear(); DGV(); this.cbMaterial.Select();
                }
                catch (Exception ex)
                {
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

        private string GenBOMCode()
        {
            try
            {
                NP_Cls.SqlSelect = "SELECT BOMCode FROM t_BOM WHERE (MaterialCode = '"+ this.cbMaterial.SelectedValue +"') AND (PlantCode = '"+ this.cbPlant.SelectedValue +"') Order By BOMCode DESC";
                return NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0].Rows[0][0].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void GenBCode()
        {
            try
            {
                NP_Cls.SqlSelect = "SELECT TmpBOMCode FROM tmp_GenCode";
                Int64 iCode = Convert.ToInt64(NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0].Rows[0][0].ToString());
                iCode += 1; string strErr = string.Empty;
                if (NP.SqlCmd("UPDATE tmp_GenCode SET TmpBOMCode = " + iCode, ref strErr))
                {
                    NP_Cls.strBOMCode = iCode.ToString();
                }
                else
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, strErr);
                    return;
                }
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, ex.Message); return;
            }
        }
        private bool ChkDup()
        {
            try
            {
                //NP_Cls.SqlSelect = " SELECT BOMCode FROM t_BOM WHERE (PlantCode = '" + this.cbPlant.SelectedValue + "') AND (MaterialCode = N'" + this.cbMaterial.SelectedValue + "') AND (FileStatus = '1')";
                NP_Cls.SqlSelect = " SELECT BOMCode FROM t_BOM WHERE (MaterialCode = N'" + this.cbMaterial.SelectedValue + "') AND (FileStatus = '1')";
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

        private void cbBOMType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbBOMType.SelectedIndex == 0)
            {
                this.cbBOMType.Select();
            }
            else
            {
                if (this.cbBOMType.SelectedValue.ToString() == "M")
                {
                    this.txtQty.Text = "100"; this.cbUnit.SelectedValue = "KG"; this.txtQty.ReadOnly = true; this.cbUnit.Enabled = false;
                    this.txtFor.Enabled = true;
                }
                else
                {
                    this.txtQty.Text = string.Empty; this.txtQty.ReadOnly = false; this.cbUnit.Enabled = true;
                    this.txtFor.Enabled = false;
                }
            }
        }
        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            NP_Cls.myDecimal(sender, e);
        }
        private void cbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbMaterial.Text.StartsWith("3") || this.cbMaterial.Text.StartsWith("5"))
            {
                this.txtFor.Text = string.Empty;
                this.txtFor.Enabled = true;
                if (this.cbBOMType.Text != "Mix")
                {
                    this.txtFor.Enabled = false;
                }
            }
            else
            {
                this.txtFor.Text = string.Empty;
                this.txtFor.Enabled = false;
            }
            //if (this.cbMaterial.SelectedIndex == 0)
            //{
            //    this.cbMaterial.Select(); 
            //}
            //else
            //{
            //    if (this.cbPlant.SelectedIndex == 0)
            //    {
            //        this.cbPlant.Select(); 
            //    }
            //    else
            //    {
            //        //DGV(string.Empty);
            //    }
            //}
        }
        private void cbPlant_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (this.cbPlant.SelectedIndex == 0)
            //{
            //    this.cbPlant.Select(); 
            //}
            //else
            //{
            //    if (this.cbMaterial.SelectedIndex == 0)
            //    {
            //        this.cbMaterial.Select(); 
            //    }
            //    else
            //    {
            //        //DGV(string.Empty);
            //    }
            //}
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
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string strSelect = this.dgvView["clnMaterialCode", this.dgvView.CurrentRow.Index].Value.ToString();
                string strSelect2 = this.dgvView["clnPlantCode", this.dgvView.CurrentRow.Index].Value.ToString();
                NP_Cls.SqlSelect = "SELECT * FROM t_BOM WHERE (MaterialCode ='" + strSelect + "') AND (PlantCode = '"+ strSelect2 +"')";
                DataSet dsEdit = new DataSet(); dsEdit = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (dsEdit.Tables[0].Rows.Count > 0)
                {
                    this.cbMaterial.SelectedValue = dsEdit.Tables[0].Rows[0]["MaterialCode"].ToString();
                    this.cbPlant.SelectedValue = dsEdit.Tables[0].Rows[0]["PlantCode"].ToString();
                    this.cbBOMType.SelectedValue= dsEdit.Tables[0].Rows[0]["BOMType"].ToString();
                    this.cbUnit.SelectedValue = dsEdit.Tables[0].Rows[0]["UnitCode"].ToString();
                    this.txtQty.Text = dsEdit.Tables[0].Rows[0]["Quantity"].ToString();
                    //this.lblAppr.Text = dsEdit.Tables[0].Rows[0]["Approve"].ToString();
                    if (!(dsEdit.Tables[0].Rows[0]["MaterialCode"].ToString().StartsWith("3") || dsEdit.Tables[0].Rows[0]["MaterialCode"].ToString().StartsWith("5")))
                            txtFor.Enabled = false;
                    if (dsEdit.Tables[0].Rows[0]["MaterialCode"].ToString().StartsWith("5") && this.cbBOMType.Text != "Mix")
                        txtFor.Enabled = false;
                    this.txtFor.Text = dsEdit.Tables[0].Rows[0]["FormulaNo"].ToString();
                    this.txtRemark.Text = dsEdit.Tables[0].Rows[0]["Remark"].ToString();

                    this.cbMaterial.Enabled = false; this.cbPlant.Enabled = false; this.btnAdd.Visible = false; this.btnEdit.Visible = true; 
                    this.cbBOMType.Select(); this.cbBOMType.SelectAll();
                }
                else
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found !!"); return;
                }
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Edit : " + ex.Message); return;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty((this.cbMaterial.Text.Trim()))) || (this.cbMaterial.Text.Trim() == "((( Select Material )))"))
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please enter Material: !!"); this.cbMaterial.Select(); return;
            }
            if (NP.ReqField(this.cbPlant, "Please enter Plant: !!") == false) { return; }
            if (NP.ReqField(this.cbBOMType, "Please enter B.O.M Type: !!") == false) { return; }
            if (NP.ReqField(this.cbUnit, "Please enter Unit: !!") == false) { return; }
            if (NP.ReqField(this.txtQty, "Please enter Quantity: !!") == false) { return; }
            if (cbMaterial.Text.StartsWith("3"))
            {
                if (!NP.ReqField(this.txtFor, "please enter Formula No : !!")) { return; }
            }
            if (cbMaterial.Text.StartsWith("5") && cbBOMType.Text == "Mix")
            {
                if (!NP.ReqField(this.txtFor, "please enter Formula No : !!")) { return; }
            }
            if (NP.MSGB("Do you want to Edit BOM Data ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr; Tr = oConn.BeginTransaction();
                try
                {
                    SqlCommand cmdEdit = new SqlCommand();
                    NP_Cls.sqlUpdate = "UPDATE    t_BOM "+
"SET BOMType = @BOMType, UnitCode = @UnitCode, Quantity = @Qty, UserChange = @UC, DateChange = GETDATE(), Remark = @Remark, FormulaNo = @FormulaNo " +
"WHERE     (MaterialCode = @MaterialCode) AND (PlantCode = @PlantCode)";
                    cmdEdit.Parameters.Add("@MaterialCode", SqlDbType.NVarChar, 15).Value = this.cbMaterial.SelectedValue;
                    cmdEdit.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 4).Value = this.cbPlant.SelectedValue;
                    cmdEdit.Parameters.Add("@BOMType", SqlDbType.NVarChar, 1).Value = this.cbBOMType.SelectedValue;
                    cmdEdit.Parameters.Add("@UnitCode", SqlDbType.NVarChar, 3).Value = this.cbUnit.SelectedValue;
                    cmdEdit.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Convert.ToDouble(this.txtQty.Text.Trim());
                    cmdEdit.Parameters.Add("@UC", SqlDbType.NVarChar, 10).Value = NP_Cls.strUsr;
                    cmdEdit.Parameters.Add("@Remark", SqlDbType.NVarChar, 200).Value = this.txtRemark.Text.Trim();
                    cmdEdit.Parameters.Add("@FormulaNo", SqlDbType.NVarChar, 200).Value = this.txtFor.Text.Trim();
                    cmdEdit.Connection = oConn; cmdEdit.CommandText = NP_Cls.sqlUpdate; cmdEdit.Transaction = Tr;
                    cmdEdit.ExecuteNonQuery();

                    // Edit Detail
                    if (!BOMQtyChk(oConn, Tr))
                    {
                        Tr.Commit();
                        if (this.cbBOMType.SelectedValue.ToString().ToUpper() == "M")
                        {
                            NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Edit BOM Data Completed !!\n\n Please Edit Component for this BOM ..");

                            NP_Cls.hBOM = new System.Collections.Hashtable();
                            NP_Cls.hBOM.Add("BOMCode", ((string)GenBOMCode()));
                            NP_Cls.hBOM.Add("Qty", Convert.ToDouble(this.txtQty.Text.Trim()));
                            NP_Cls.hBOM.Add("UnitName", ((string)this.cbUnit.Text));
                            NP_Cls.hBOM.Add("BOMType", ((string)this.cbBOMType.SelectedValue));
                            NP_Cls.hBOM.Add("Approve", Convert.ToBoolean(this.dgvView["clnApprove", this.dgvView.CurrentRow.Index].ToString()));


                            WMS.BOM.frmBOMNewDetail frm = new frmBOMNewDetail();
                            frm.ShowDialog();
                        }
                        this.btnAdd.Visible = true; this.btnEdit.Visible = false; this.cbMaterial.Enabled = true; this.cbPlant.Enabled = true;
                        this.cbMaterial.Select(); this.cbUnit.Enabled = true;
                        Clear(); DGV(); this.cbMaterial.Select();
                    }
                    else
                    {
                        Tr.Commit();
                        Clear();
                        DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Edit BOM Data Completed !!"); this.cbMaterial.Select(); this.cbPlant.Enabled = true; this.cbUnit.Enabled = true;
                        this.btnAdd.Visible = true; this.btnEdit.Visible = false; this.cbMaterial.Enabled = true; this.cbMaterial.Select();
                    }
                    //                    
                }
                catch (Exception ex)
                {
                    if (oConn.State == ConnectionState.Open) { Tr.Rollback(); }
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
            if (NP.MSGB("Do you want to delete BOM ?") == DialogResult.Yes)
            {

                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr; Tr = oConn.BeginTransaction();
                try
                {
                    SqlCommand cmdDel = new SqlCommand();
                    NP_Cls.SqlDel = "DELETE FROM t_BOM WHERE (BOMCode = @BOMCode)";
                    cmdDel.Parameters.Add("@BOMCode", SqlDbType.Int).Value = Convert.ToInt32(this.dgvView["clnBOMCode", this.dgvView.CurrentRow.Index].Value.ToString());
                    cmdDel.Connection = oConn; cmdDel.CommandText = NP_Cls.SqlDel; cmdDel.Transaction = Tr;
                    cmdDel.ExecuteNonQuery();

                    NP_Cls.SqlDel = "DELETE FROM t_BOMDetail WHERE (BOMCode = @BOMCode)";
                    //cmdDel.Parameters.Add("@BOMCode", SqlDbType.Int).Value = Convert.ToInt32(this.dgvView["clnBOMCode", this.dgvView.CurrentRow.Index].Value.ToString());
                    cmdDel.Connection = oConn; cmdDel.CommandText = NP_Cls.SqlDel; cmdDel.Transaction = Tr;
                    cmdDel.ExecuteNonQuery();

                    if (NP._TRanSave(oConn, Tr, NP_Cls.NPTranType.Delete, "t_BOM:t_BOMDetail", NP_Cls.strUsr))
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
        private void dgvView_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvView.RowCount == 0) { this.contextMenuStrip1.Enabled = false; return; }
            this.contextMenuStrip1.Items[0].Enabled =  (!(bool)this.dgvView["clnApprove", this.dgvView.CurrentRow.Index].Value);
            this.contextMenuStrip1.Items[4].Enabled = (!(bool)this.dgvView["clnApprove", this.dgvView.CurrentRow.Index].Value);
            this.contextMenuStrip1.Items[5].Enabled = (!(bool)this.dgvView["clnApprove", this.dgvView.CurrentRow.Index].Value);
            this.btnNewVer.Visible = (bool)this.dgvView["clnApprove", this.dgvView.CurrentRow.Index].Value;
            this.btnReport.Visible = true;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (NP_Cls.AppPR == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "You have not Permission to Approve B.O.M. !!"); return; }

            if (this.dgvView.RowCount == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found to Approve !!"); return; }
            if (this.lblAppr.Text.Trim().ToUpper() == "TRUE") { NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "This BOM is Approve already !!"); return; }
          
            if (NP.MSGB("Do you want to Approve this BOM ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr; Tr = oConn.BeginTransaction();
                try
                {
                    SqlCommand cmdEdit = new SqlCommand(); 
                    NP_Cls.sqlUpdate = "UPDATE   t_BOM SET Approve = @Appr WHERE (BOMCode = @BOMCode)";
                    cmdEdit.Parameters.Add("@BOMCode", SqlDbType.Int).Value = Convert.ToInt32(this.dgvView["clnBOMCode", this.dgvView.CurrentRow.Index].Value);
                    cmdEdit.Parameters.Add("@Appr", SqlDbType.Bit).Value = 1;

                    cmdEdit.Connection = oConn; cmdEdit.CommandText = NP_Cls.sqlUpdate; cmdEdit.Transaction = Tr;
                    cmdEdit.ExecuteNonQuery();

                    if (NP._TRanSave(oConn, Tr, NP_Cls.NPTranType.Update, "t_BOM:Approve", NP_Cls.strUsr))
                    {
                        Tr.Commit(); Clear(); 
                        DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Approve Completed !!");
                        this.btnAdd.Visible = true; this.btnEdit.Visible = false; 
                    }
                    else
                    {
                        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Try Again !!"); return;
                    }
                }
                catch (Exception ex)
                {
                    if (oConn.State == ConnectionState.Open) { Tr.Rollback(); }
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Approve : " + ex.Message); return;
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
        private void setComponentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NP_Cls.hBOM = new System.Collections.Hashtable();
            NP_Cls.hBOM.Add("BOMCode", this.dgvView["clnBOMCode", this.dgvView.CurrentRow.Index].Value.ToString());
            NP_Cls.hBOM.Add("Qty", Convert.ToDouble(this.dgvView["clnQty", this.dgvView.CurrentRow.Index].Value.ToString()));
            NP_Cls.hBOM.Add("UnitName", this.dgvView["clnUnitName", this.dgvView.CurrentRow.Index].Value.ToString());
            NP_Cls.hBOM.Add("BOMType", this.dgvView["clnBOMType", this.dgvView.CurrentRow.Index].Value.ToString());
            NP_Cls.hBOM.Add("Approve", this.dgvView["clnApprove", this.dgvView.CurrentRow.Index].Value.ToString());
            NP_Cls.hBOM.Add("Material", this.dgvView["clnMaterialCode", this.dgvView.CurrentRow.Index].Value.ToString());

            WMS.BOM.frmBOMNewDetail frm = new frmBOMNewDetail();
            frm.lblSCode.Text = this.dgvView["clnMaterialCode", this.dgvView.CurrentRow.Index].Value.ToString();
            frm.FormBorderStyle = FormBorderStyle.Sizable; frm.ControlBox = true;
            frm.lblSName.Text = this.dgvView["clnMaterialName", this.dgvView.CurrentRow.Index].Value.ToString();
            frm.ShowDialog();
            Clear(); DGV(); this.cbMaterial.Select();
        }
        private void btnSetBOMType_Click(object sender, EventArgs e)
        {
            WMS.BOM.frmBOMTypeMaster frm = new frmBOMTypeMaster();
            frm.ShowDialog();
            DataSet dsBT = new DataSet(); dsBT.ReadXml(NP_Cls.PathBT); DataRow dr = dsBT.Tables[0].NewRow();
            dr[0] = 0; dr[1] = "((( Select B.O.M Type )))";
            dsBT.Tables[0].Rows.InsertAt(dr, 0);
            dsBT.AcceptChanges();
            this.cbBOMType.DataSource = dsBT.Tables[0];
            this.cbBOMType.DisplayMember = "BTDesc"; this.cbBOMType.ValueMember = "BTCode";
        }
        private void frmBOMNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            WMS.LoginSystem.frmMainMenu frm = (WMS.LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"];
            frm.menuStrip1.Enabled = true;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (NP_Cls.AppPR == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "You have not Permission to Approve B.O.M. !!"); return; }
            if (this.dgvView.RowCount == 0) { NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found to Approve !!"); return; }
            if (this.lblAppr.Text.Trim().ToUpper() == "TRUE") { NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "This BOM is Approve already !!"); return; }

            if (NP.MSGB("Do you want to Approve this BOM ?") == DialogResult.Yes)
            {
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr; Tr = oConn.BeginTransaction();
                try
                {
                    SqlCommand cmdEdit = new SqlCommand();
                    NP_Cls.sqlUpdate = "UPDATE   t_BOM SET Approve = @Appr, ApproveUser = @AUSER WHERE (BOMCode = @BOMCode)";
                    cmdEdit.Parameters.Add("@BOMCode", SqlDbType.Int).Value = Convert.ToInt32(this.dgvView["clnBOMCode", this.dgvView.CurrentRow.Index].Value);
                    cmdEdit.Parameters.Add("@Appr", SqlDbType.Bit).Value = 1; cmdEdit.Parameters.Add("@AUSER", SqlDbType.NVarChar, 10).Value = NP_Cls.strUsr;
 
                    cmdEdit.Connection = oConn; cmdEdit.CommandText = NP_Cls.sqlUpdate; cmdEdit.Transaction = Tr;
                    cmdEdit.ExecuteNonQuery();

                    if (NP._TRanSave(oConn, Tr, NP_Cls.NPTranType.Update, "t_BOM:Approve", NP_Cls.strUsr))
                    {
                        Tr.Commit(); Clear(); 
                        DGV(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Approve Completed !!");
                        this.btnAdd.Visible = true; this.btnEdit.Visible = false;
                    }
                    else
                    {
                        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Try Again !!"); return;
                    }
                }
                catch (Exception ex)
                {
                    if (oConn.State == ConnectionState.Open) { Tr.Rollback(); }
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Approve : " + ex.Message); return;
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
        private bool BOMQtyChk(SqlConnection oConn, SqlTransaction Tr)
        {
            NP_Cls.SqlSelect = "SELECT  ISNULL(SUM(Quantity),0) AS Quantity FROM t_BOMDetail WHERE     (BOMCode = '"+ this.dgvView["clnBOMCode",this.dgvView.CurrentRow.Index].Value.ToString() +"')";

            DataSet dsC = new DataSet(); dsC = NP.GetDataWithTran(NP_Cls.SqlSelect, Tr, oConn);
            if (dsC.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToDecimal(this.txtQty.Text.Trim()) != Convert.ToDecimal(dsC.Tables[0].Rows[0][0].ToString()))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private void btnNewVer_Click(object sender, EventArgs e)
        {
            if (NP.MSGB("Do you want to Create New Version ?") == DialogResult.Yes)
            {
                //this.txtVersion.Text = (Convert.ToInt16(this.txtVersion.Text.Trim()) + 1).ToString();
                //this.cbBOMType.SelectedIndex = 0; this.cbUnit.SelectedIndex = 0;
                //this.txtQty.Text = string.Empty; this.cbMaterial.Enabled = false; this.cbPlant.Enabled = false;

    //            NP_Cls.SqlSelect = "SELECT 0 as ItemNo,    m_Unit.UnitName, t_BOMDetail.Category, t_BOMDetail.MaterialCode, m_Material.MaterialName, t_BOMDetail.Quantity, t_BOM.BOMCode,  t_BOMDetail.BOMDetailCode, t_BOM.Approve, t_BOM.BOMVersion " +
    //            "FROM         t_BOM INNER JOIN " +
    //                      "m_Unit ON t_BOM.UnitCode = m_Unit.UnitCode INNER JOIN " +
    //                      "t_BOMDetail ON t_BOM.BOMCode = t_BOMDetail.BOMCode INNER JOIN " +
    //                      "m_Material ON t_BOMDetail.MaterialCode = m_Material.MaterialCode " +
    //"WHERE     (t_BOM.FileStatus = N'1') AND (t_BOM.PlantCode = N'') AND (t_BOM.MaterialCode = N'')";
    //            this.dgvView.DataSource = NP.GetClientDataSet(NP_Cls.SqlSelect).Tables[0]; this.btnVerAppr.Visible = false; this.btnVerNot.Visible = false;


                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
                oConn.Open(); SqlTransaction Tr; Tr = oConn.BeginTransaction();
                try
                {
                    SqlCommand cmdEdit = new SqlCommand();
                    NP_Cls.sqlUpdate = "INSERT INTO t_BOM " +
                      "(MaterialCode, PlantCode, BOMType, UnitCode, Quantity, BOMVersion, UserCreate, DateCreate, FileStatus, Approve, Remark) " +
"SELECT   MaterialCode, PlantCode, BOMType, UnitCode, Quantity, BOMVersion + 1 AS BOMVer, '" + NP_Cls.strUsr + "' AS UC, GETDATE(), FileStatus, 0 as Appr, Remark FROM t_BOM " +
"WHERE (BOMCode = @BOMCode)"; 
                    cmdEdit.Parameters.Add("@BOMCode", SqlDbType.Int).Value = this.dgvView["clnBOMCode", this.dgvView.CurrentRow.Index].Value.ToString();
                    cmdEdit.Connection = oConn; cmdEdit.CommandText = NP_Cls.sqlUpdate; cmdEdit.Transaction = Tr;
                    cmdEdit.ExecuteNonQuery();

                    NP_Cls.SqlSelect = "SELECT BOMCode FROM t_BOM WHERE (MaterialCode = '" + this.dgvView["clnMaterialCode", this.dgvView.CurrentRow.Index].Value.ToString() + "') AND (PlantCode = '" + this.dgvView["clnPlantCode", this.dgvView.CurrentRow.Index].Value.ToString() + "') Order By BOMCode DESC";
                    string sBOMCode = NP.GetDataWithTran(NP_Cls.SqlSelect, Tr, oConn).Tables[0].Rows[0][0].ToString();
                    NP_Cls.sqlUpdate = "INSERT INTO t_BOMDetail " +
                      "(BOMCode, Category, MaterialCode, Quantity, LossPercentage, UserCreate, DateCreate) " +
"SELECT   '" + sBOMCode + "' AS BC, Category, MaterialCode, Quantity, LossPercentage, '" + NP_Cls.strUsr + "' AS UC, GETDATE() FROM t_BOMDetail " +
"WHERE (BOMCode = @BOMCode)"; 
                    cmdEdit.Connection = oConn; cmdEdit.CommandText = NP_Cls.sqlUpdate; cmdEdit.Transaction = Tr;
                    cmdEdit.ExecuteNonQuery();

                    NP_Cls.sqlUpdate = "UPDATE  t_BOM SET FileStatus = @St WHERE (BOMCode = @BOMCode)";
                    //cmdEdit.Parameters.Add("@BOMCode", SqlDbType.Int).Value = this.dgvView["clnBOMCode",this.dgvView.CurrentRow.Index].Value.ToString();
                    cmdEdit.Parameters.Add("@St", SqlDbType.NVarChar, 1).Value = "D";

                    cmdEdit.Connection = oConn; cmdEdit.CommandText = NP_Cls.sqlUpdate; cmdEdit.Transaction = Tr;
                    cmdEdit.ExecuteNonQuery();

                    if (NP._TRanSave(oConn, Tr, NP_Cls.NPTranType.Update, "t_BOM:NewVersion", NP_Cls.strUsr))
                    {
                        Tr.Commit();
                        DGV(); Clear();
                        this.btnAdd.Visible = true; this.btnEdit.Visible = false; 
                    }
                    else
                    {
                        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Try Again !!"); return;
                    }
                }
                catch (Exception ex)
                {
                    if (oConn.State == ConnectionState.Open) { Tr.Rollback(); }
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Approve : " + ex.Message); return;
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
        private void btnReport_Click(object sender, EventArgs e)
        {
            NP_Cls.SqlSelect = "SELECT     0 AS ItemNo, t_BOM.BOMCode, t_BOM.MaterialCode, m_Material.MaterialName,t_BOM.FormulaNo, t_BOM.Remark, t_BOM.BOMVersion, t_BOM.Quantity, t_BOM.ApproveUser,                        CASE WHEN t_BOM.UserChange IS NULL THEN t_BOM.UserCreate ELSE t_BOM.UserChange END AS HUSER, CASE WHEN t_BOM.DateChange IS NULL                        THEN t_BOM.DateCreate ELSE t_BOM.DateChange END AS HDATE, t_BOMDetail.MaterialCode AS CompCode, t_BOMDetail.Quantity AS CompQty,                        t_BOMDetail.LossPercentage, t_BOMDetail.Remark AS DRemark, GetCreate.EmployeeFirstName AS FirstNameCreate, s_User.EmployeeFirstName AS FirstNameAppr,                        CompMaster.UnitCode AS CompUnitCode, CompUnit.UnitName AS CompUnitName, t_BOM.UnitCode, m_Unit.UnitName, m_Material.ProcurementType, CompMaster.MaterialName AS CompName, m_Material.MaterialTypeName  FROM         t_BOM INNER JOIN                       t_BOMDetail ON t_BOM.BOMCode = t_BOMDetail.BOMCode INNER JOIN                       m_Material ON t_BOM.MaterialCode = m_Material.MaterialCode INNER JOIN                       s_User AS GetCreate ON CASE WHEN t_BOM.UserChange IS NULL THEN t_BOM.UserCreate ELSE t_BOM.UserChange END = GetCreate.UserName INNER JOIN                       m_Material AS CompMaster ON t_BOMDetail.MaterialCode = CompMaster.MaterialCode INNER JOIN                       m_Unit AS CompUnit ON CompMaster.UnitCode = CompUnit.UnitCode INNER JOIN                       m_Unit ON t_BOM.UnitCode = m_Unit.UnitCode LEFT OUTER JOIN                       s_User ON t_BOM.ApproveUser = s_User.UserName WHERE (t_BOM.BOMCode = '" + this.dgvView["clnBOMCode", this.dgvView.CurrentRow.Index].Value.ToString() + "')  ORDER BY t_BOMDetail.SortIndex, CompCode";
            DataSet ds = new DataSet(); ds = NP.GetClientDataSet(NP_Cls.SqlSelect);
            if (ds.Tables[0].Rows.Count > 0)
            { 
                frmBOMViewer frm = new frmBOMViewer();
                if (ds.Tables[0].Rows[0]["MaterialTypeName"].ToString() != "FG")
                {
                    //if (!NP.ReqField(this.txtFor, "please enter Formula No : !!")) { return; }
                    frm.strFor = ds.Tables[0].Rows[0]["FormulaNo"].ToString();
                }
                frm.bType = Convert.ToByte(ds.Tables[0].Rows[0]["MaterialTypeName"].ToString() == "FG" ? 1 : 0);

                frm.dsReportA = ds.Copy();
                frm.WindowState = FormWindowState.Maximized;
                frm.ShowDialog();
            }
            else
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found !!"); return;
            }
        }

    }
}
