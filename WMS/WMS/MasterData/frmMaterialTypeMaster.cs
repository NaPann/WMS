using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMS.MasterData
{
    public partial class frmMaterialTypeMaster : Form
    {
        NP_Cls NP = new NP_Cls(); DataSet dsMT = new DataSet();
        public frmMaterialTypeMaster()
        {
            InitializeComponent();
        }
        private void frmMaterialTypeMaster_Load(object sender, EventArgs e)
        {
            GetData(); Clear();
            this.txtMaterialType.Select(); this.txtMaterialType.SelectAll();
        }
        private void Clear()
        {
            this.txtMaterialType.Text = string.Empty;
        }
        private void GetData()
        {
            try
            {
                dsMT.ReadXml(NP_Cls.PathMT);
                this.dgvView.DataSource = dsMT.Tables[0];
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
            if (NP.ReqField(this.txtMaterialType, "Please enter Material Type: !!") == false) { return; }

            if (ChkDup())
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Code Duplicated !!"); this.txtMaterialType.Select(); this.txtMaterialType.SelectAll(); return;
            }

            if (NP.MSGB("Do you want to Add Data ?") == DialogResult.Yes)
            {
                try
                {
                    DataRow dr; dr = dsMT.Tables[0].NewRow();
                    dr[0] = this.txtMaterialType.Text.Trim();
                    dsMT.Tables[0].Rows.Add(dr); dsMT.WriteXml(NP_Cls.PathMT); dsMT.Clear();
                    Clear(); GetData(); NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Add Data Completed !!"); this.txtMaterialType.Focus();
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
            foreach (DataRow dr in dsMT.Tables[0].Rows)
            {
                if (dr[0].ToString() == this.txtMaterialType.Text.Trim()) { return true; }
            }
            return false;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NP.MSGB("Do you want to delete ?") == DialogResult.Yes)
            {
                this.dsMT.Tables[0].Rows.RemoveAt(this.dgvView.CurrentRow.Index); dsMT.WriteXml(NP_Cls.PathMT); dsMT.Clear();
                GetData();
            }
            else
            {
                return;
            }
        }
    
    }
}
