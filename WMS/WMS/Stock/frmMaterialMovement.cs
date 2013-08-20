using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WMS.Stock
{
    public partial class frmMaterialMovement : Form
    {
        public DataSet MyGridSet { get; set; }
        public DataSet MyTmpView { get; set; }
        public byte MyAtFirstRow { get; set; }
        NP_Cls NP = new NP_Cls(); SqlConnection oConn = new SqlConnection();
        public frmMaterialMovement()
        {
            InitializeComponent();
        }

        private void frmMaterialMovement_Load(object sender, EventArgs e)
        {
            LoginSystem.frmMainMenu frm = ((LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"]);
            frm.menuStrip1.Enabled = true; this.txtMatCode.Select();
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
        private void frmMaterialMovement_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoginSystem.frmMainMenu frm = ((LoginSystem.frmMainMenu)Application.OpenForms["frmMainMenu"]);
            frm.menuStrip1.Enabled = true;
        }

        private void btnOverview_Click(object sender, EventArgs e)
        {
            if (!NP.ReqField(this.txtMatCode, "Please enter Material Code !!")) { return; }
            NP_Cls.SqlSelect = "SELECT     t_StockMovement.DocNumber, t_StockMovement.TranDate, t_StockMovement.MovementType, t_StockMovementDetail.MaterialCode,                       t_StockMovementDetail.MaterialName, t_StockMovementDetail.Quantity, t_StockMovementDetail.UnitCode,  t_StockMovementDetail.RefNumber, '' AS CL FROM         t_StockMovement INNER JOIN          t_StockMovementDetail ON t_StockMovement.DocNumber = t_StockMovementDetail.DocNumber WHERE     (t_StockMovementDetail.MaterialCode = N'" + this.txtMatCode.Text.Trim() + "' AND t_StockMovementDetail.RefNumber not like '%X%') ORDER BY t_StockMovement.TranDate"; 
            DataSet ds = new DataSet(); ds = NP.GetClientDataSet(NP_Cls.SqlSelect);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["DocNumber"].ToString().Contains("TR"))
                    {
                        if (ds.Tables[0].Rows[i]["RefNumber"].ToString().Contains("X"))
                        {
                            ds.Tables[0].Rows[i]["CL"] = "red";                            
                        }
                        else
                        {
                            ds.Tables[0].Rows[i]["CL"] = "green";
                        }
                    }
                    else if (ds.Tables[0].Rows[i]["DocNumber"].ToString().Contains("GR"))
                    {
                        ds.Tables[0].Rows[i]["CL"] = "green";
                    }
                    else if (ds.Tables[0].Rows[i]["DocNumber"].ToString().Contains("PD"))
                    {
                        ds.Tables[0].Rows[i]["CL"] = "red";
                    }
                }         
                this.pDesc.Visible = true; this.lblMatName.Text = ds.Tables[0].Rows[0]["MaterialName"].ToString();

                this.dataGridView1.DataSource = ds.Tables[0]; this.dataGridView1.ClearSelection();

                for (int d = 0; d < this.dataGridView1.RowCount; d++)
                {
                    if (this.dataGridView1["clnCL", d].Value.ToString().IndexOf("red") > -1)
                    {
                        this.dataGridView1.Rows[d].DefaultCellStyle.BackColor = Color.LightCoral;
                    }
                    else if (this.dataGridView1["clnCL", d].Value.ToString().IndexOf("green") > -1)
                    {
                        this.dataGridView1.Rows[d].DefaultCellStyle.BackColor = Color.PaleGreen;
                    }
                }
                this.dataGridView1.Columns["clnCL"].Visible = false;
            }
            else
            {
                this.pDesc.Visible = false;
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found !!"); this.txtMatCode.Select(); this.txtMatCode.SelectAll(); return;
            }
        }
        private void txtMatCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnOverview_Click(sender, e);
            }
        }

    }
}
