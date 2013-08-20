using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace WMS.LoginSystem
{
    public partial class frmConfiguration : Form
    {
        NP_Cls NP = new NP_Cls(); SqlConnection oConn;
        public frmConfiguration()
        {
            InitializeComponent();
        }
        private void frmConfiguration_Load(object sender, EventArgs e)
        {
            StreamReader st = new StreamReader(NP_Cls.PathDB);
            string strDB = st.ReadLine(); st.Close();
            string[] spDB = strDB.Split(';');
            this.txtServerName.Text = spDB[2].Substring(spDB[2].IndexOf("=") + 1);
            this.txtDBName.Text = spDB[1].Substring(spDB[1].IndexOf("=") + 1);
            this.txtLogin.Text = spDB[3].Substring(spDB[3].IndexOf("=") + 1);
            this.txtPassword.Text = spDB[4].Substring(spDB[4].IndexOf("=") + 1);
        }
        private void btnCancel_Click(object sender, EventArgs e)
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

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string strDB = @"Persist Security Info=False;Initial Catalog=" + this.txtDBName.Text.Trim() + ";Data Source=" + this.txtServerName.Text.Trim() + ";User ID=" + this.txtLogin.Text.Trim() + ";Password=" + this.txtPassword.Text.Trim();
            oConn = new SqlConnection(strDB);
            try
            {
                oConn.Open(); oConn.Close(); NP.WriteFileDB(NP_Cls.PathDB, strDB);
                NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "Database Connected !!"); this.Close();   
            }
            catch
            {
                NP.MSGB(NP_Cls.NPMgsStyle.ErrorType, "Can not Connect Database, Try Again !!"); return;
            }
            finally
            {
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
            }
        }
    }
}
