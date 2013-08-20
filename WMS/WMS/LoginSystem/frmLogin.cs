using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WMS.LoginSystem
{
    public partial class frmLogin : Form
    {
        NP_Cls NP = new NP_Cls(); SqlConnection oConn; 
        public frmLogin()
        {
            InitializeComponent();
            this.lblVer.Text = NP_Cls.Version;
        }
        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(this.txtUserName.Text.Trim()))
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please enter UserName: !!"); this.txtUserName.Select(); return;
                }
                else
                {
                    this.txtPassword.Select();
                }
            }
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            ConnectDB();
            this.txtUserName.Text = string.Empty; this.txtPassword.Text = string.Empty;
            this.txtUserName.Select();
            this.txtUserName.Text = "admin"; this.txtPassword.Text = "pass";
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(this.txtPassword.Text.Trim()))
                {
                    NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Please enter Password: !!"); this.txtPassword.Select(); return;
                }
                else
                {
                    this.btnLogin_Click(sender, e);
                }
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!NP.ReqField(this.txtUserName, "Please enter UserName: !!")) { return; }
            if (!NP.ReqField(this.txtPassword, "Please enter Password: !!")) { return; }

            NP_Cls.SqlSelect = "SELECT UserName, Password, UserIP FROM s_User WHERE (UserName = '" + this.txtUserName.Text.Trim().Replace("'", "") + "') AND (Password = '" + this.txtPassword.Text.Trim().Replace("'", "") + "')"; DataSet dsUser = new DataSet(); dsUser = NP.GetClientDataSet(NP_Cls.SqlSelect);
            if (dsUser.Tables[0].Rows.Count > 0)
            {
                string strIP = string.Empty; //NP.getip();
                if (string.IsNullOrEmpty(dsUser.Tables[0].Rows[0]["UserIP"].ToString()))
                {
                    //NP_Cls.sqlUpdate = "UPDATE s_User SET UserIP = '" + strIP + "' WHERE (UserName = '" + dsUser.Tables[0].Rows[0]["UserName"].ToString() + "')";
                    //string strErr = string.Empty;
                    //if (NP.SqlCmd(NP_Cls.sqlUpdate, ref strErr) == false)
                    //{
                        //NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Warning !! : " + strErr); return;
                    //}NP.MSGB(NP_Cls.NPMgsStyle.InfoType, "You are login !!"); 
                    NP_Cls.strUsr = dsUser.Tables[0].Rows[0]["UserName"].ToString();
                    ManageMenu(NP_Cls.strUsr); this.txtUserName.Text = string.Empty; this.txtPassword.Text = string.Empty;
                    this.txtUserName.Select();
                    frmMainMenu frmM = new frmMainMenu(); frmM.Show(); this.Hide();
                }
                else
                {
                    if (strIP == dsUser.Tables[0].Rows[0]["UserIP"].ToString())
                    {
                        NP_Cls.strUsr = dsUser.Tables[0].Rows[0]["UserName"].ToString();
                        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "You are login the same IP !!"); ManageMenu(NP_Cls.strUsr);
                        this.txtUserName.Text = string.Empty; this.txtPassword.Text = string.Empty; this.txtUserName.Select();
                        frmMainMenu frmM = new frmMainMenu(); frmM.Show(); this.Hide();
                    }
                    else
                    {
                        NP_Cls.strUsr = string.Empty;
                        NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "You can not login with multi user !!"); return;
                    }
                }
            }
            else
            {
                NP_Cls.strUsr = string.Empty;
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "Invalid UserName or Password !!"); return;
            }
        }
        private void ConnectDB()
        {
            try
            {
                oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
                oConn.Open(); oConn.Close();
            }
            catch (Exception)
            {
                if (NP.MSGB("Can not Connect Database, Try agian later !!\nor Setteing Configuration ?") == DialogResult.Yes)
                {
                    frmConfiguration frm = new frmConfiguration();
                    frm.ShowDialog(); ConnectDB();
                }
                else
                {
                    Application.Exit();
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (NP.MSGB("Do you want to exit program ?") == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }
        private void lkConfig_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmConfiguration frm = new frmConfiguration();
            frm.ShowDialog(); ConnectDB();
        }
        private void ManageMenu(string strUserName)
        {
            NP_Cls.SqlSelect = "SELECT     s_User.UserName, s_User.EmployeeFirstName, s_User.EmployeeLastName, s_User.DepartmentCode, s_User.AuthLevel, s_Level.Per, "+
                      "m_Department.DepartmentName FROM         s_User INNER JOIN "+
                      "s_Level ON s_User.DepartmentCode = s_Level.DepartmentCode AND s_User.AuthLevel = s_Level.AuthLevel INNER JOIN "+
                      "m_Department ON s_User.DepartmentCode = m_Department.DepartmentCode "+
"WHERE     (s_User.UserName = N'"+ strUserName +"')";
            NP_Cls.dsAuth = new DataSet(); NP_Cls.dsAuth = NP.GetClientDataSet(NP_Cls.SqlSelect);
        }

    }
}
