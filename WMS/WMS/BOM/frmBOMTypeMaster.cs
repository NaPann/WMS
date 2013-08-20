using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMS.BOM
{
    public partial class frmBOMTypeMaster : Form
    {
        NP_Cls NP = new NP_Cls(); DataSet dsBT = new DataSet();
        public frmBOMTypeMaster()
        {
            InitializeComponent();
        }
        private void frmBOMTypeMaster_Load(object sender, EventArgs e)
        {
            GetData(); Clear();
            this.txtCode.Select(); this.txtCode.SelectAll();
        }
        private void Clear()
        {
            this.txtCode.Text = string.Empty; this.txtDescription.Text = string.Empty;
        }
        private void GetData()
        {
            try
            {
                dsBT.ReadXml(NP_Cls.PathBT);
                this.dgvView.DataSource = dsBT.Tables[0];
            }
            catch (Exception ex)
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Get Data :" + ex.Message); return;
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (NP.ReqField(this.txtCode, "Please enter B.O.M Type Code: !!") == false) { return; }
            if (NP.ReqField(this.txtDescription, "Please enter B.O.M Type Description: !!") == false) { return; }

            if (ChkDup())
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Code Duplicated !!"); this.txtCode.Select(); this.txtCode.SelectAll(); return;
            }

            if (NP.MSGB("Do you want to Add Data ?") == DialogResult.Yes)
            {
                try
                {
                    DataRow dr; dr = dsBT.Tables[0].NewRow();
                    dr[0] = this.txtCode.Text.Trim(); dr[1] = this.txtDescription.Text.Trim();
                    dsBT.Tables[0].Rows.Add(dr); dsBT.WriteXml(NP_Cls.PathBT); dsBT.Clear();
                    Clear(); GetData(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Add Data Completed !!"); this.txtCode.Focus();
                }
                catch (Exception ex)
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Add : " + ex.Message); return;
                }
            }
            else
            {
                return;
            }
        }

        private bool ChkDup()
        {
            foreach (DataRow dr in dsBT.Tables[0].Rows)
            {
                if (dr[0].ToString() == this.txtCode.Text.Trim()) { return true; }
            }
            return false;
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 i = this.dgvView.CurrentRow.Index;
                this.txtCode.Text = dsBT.Tables[0].Rows[i][0].ToString(); this.txtDescription.Text = dsBT.Tables[0].Rows[i][1].ToString();
                this.txtCode.Enabled = false; this.btnAdd.Visible = false; this.btnEdit.Visible = true;
                this.txtDescription.Select(); this.txtDescription.SelectAll();
            }
            catch
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Data Not Found !!"); return;
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (NP.ReqField(this.txtCode, "Please enter Code: !!") == false) { return; }
            if (NP.ReqField(this.txtDescription, "Please enter Description: !!") == false) { return; }

            if (NP.MSGB("Do you want to Edit Data ?") == DialogResult.Yes)
            {
                try
                {
                    for (Int32 i = 0; i < dsBT.Tables[0].Rows.Count; i++)
                    {
                        if (this.txtCode.Text.Trim() == dsBT.Tables[0].Rows[i][0].ToString())
                        {
                            dsBT.Tables[0].Rows[i][1] = this.txtDescription.Text.Trim();
                        }
                    }

                    dsBT.WriteXml(NP_Cls.PathBT); dsBT.Clear();
                    Clear(); GetData(); this.txtCode.Enabled = true; this.btnEdit.Visible = false; this.btnAdd.Visible = true;
                    NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Edit Data Completed !!"); this.txtCode.Focus();
                }
                catch (Exception ex)
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Edit : " + ex.Message); return;
                }
            }
            else
            {
                return;
            }
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NP.MSGB("Do you want to delete ?") == DialogResult.Yes)
            {
                this.dsBT.Tables[0].Rows.RemoveAt(this.dgvView.CurrentRow.Index); dsBT.WriteXml(NP_Cls.PathBT); dsBT.Clear();
                GetData(); this.txtCode.Enabled = true; this.btnEdit.Visible = false; this.btnAdd.Visible = true; this.txtCode.Select();
            }
            else
            {
                return;
            }
        }
    }
}
