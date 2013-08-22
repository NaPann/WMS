using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.Collections;
using System.Globalization;

namespace WMS
{
    class NP_Cls
    {
        public static string SqlSelect; public static string strUsr = string.Empty; public static CultureInfo cul = new CultureInfo("En-us");
        public static string PathDB = Application.StartupPath + @"\DB\DB.ini"; public static string strValidCode = string.Empty;
        public static string PathPG = Application.StartupPath + @"\Config\PG.xml"; public static string strBOMCode = string.Empty;
        public static string PathMT = Application.StartupPath + @"\Config\MT.xml"; public static bool bApprove = false; 
        public static string PathBT = Application.StartupPath + @"\Config\BT.xml";

        public static byte AppBOM = 0; public static byte AppPR = 0; public static byte AppPO = 0; public static byte AppSO = 0;

        public static string Version = "V.5.4.1";

        public static string SqlInsert; public static string SqlDel; public static string sqlUpdate;

        public static DataSet dsAuth; public static byte FromMRP = 0; public static string MRPTranOrder = string.Empty;
        public static string MRPFGSort = string.Empty; public static Decimal MRPFGQty = 0;
        public static string MRPSO = string.Empty; public static Double MRPQty = 0;
        public static string pRD = "RD"; public static string pAMT = "AMT"; public static string pLT = "LT"; public static string pCS = "CS";

        public static string nAutoID = string.Empty;

        public static string autoIDDO = "0";
        public static string SONumberForDO = "0";
        public static string QuantityDO = "";
        public static string MatCodeForDO = "";

        public static Hashtable hVendorInfo; public static Hashtable hBOM;

        public string AssignConnection(string Server, string BaseName, string UserName, string Password)
        {
            SqlConnection Conn = new SqlConnection();
            string strConn = "workstation id=PNBK;packet size=4096;user id=" + UserName + ";data source=" + Server + ";persist security info=True;initial catalog=" + BaseName + ";password=" + Password;
            Conn.ConnectionString = strConn;
            try
            {
                Conn.Open();
                Conn.Close();
                return Conn.ConnectionString;
            }
            catch
            {
                return "Disconnected";
            }
        }
        public DataSet GetClientDataSet(string Sql)
        {
            try
            {
                string strC = ReadFileDB(NP_Cls.PathDB);
                SqlConnection Conn = new SqlConnection(strC);
                if (Conn.State == ConnectionState.Open) { Conn.Close(); }
                Conn.Open();
                SqlDataAdapter DA = new SqlDataAdapter(Sql, Conn);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                Conn.Close();
                return DS;

            }
            catch
            {
                DataSet DSEx = new DataSet();
                DataTable DT = new DataTable();
                DT.Columns.Add(new DataColumn("Data Not Found", System.Type.GetType("System.String")));

                DSEx.Tables.Add(DT);
                DSEx.AcceptChanges();
                return DSEx;
            }
        }
        public DataSet GetClientDataSet(string Sql, string tableName)
        {
            try
            {
                string strC = ReadFileDB(NP_Cls.PathDB);
                SqlConnection Conn = new SqlConnection(strC);
                if (Conn.State == ConnectionState.Open) { Conn.Close(); }
                Conn.Open();
                SqlDataAdapter DA = new SqlDataAdapter(Sql, Conn);
                DataSet DS = new DataSet();
                DA.Fill(DS, tableName);
                Conn.Close();
                return DS;

            }
            catch
            {
                DataSet DSEx = new DataSet();
                DataTable DT = new DataTable();
                DT.Columns.Add(new DataColumn("Data Not Found", System.Type.GetType("System.String")));

                DSEx.Tables.Add(DT);
                DSEx.AcceptChanges();
                return DSEx;
            }
        }
        public DataSet GetClientDataSet(string Sql, string tableName, string dsName)
        {
            try
            {
                string strC = ReadFileDB(NP_Cls.PathDB);
                SqlConnection Conn = new SqlConnection(strC);
                if (Conn.State == ConnectionState.Open) { Conn.Close(); }
                Conn.Open();
                SqlDataAdapter DA = new SqlDataAdapter(Sql, Conn);
                DataSet DS = new DataSet(dsName);
                DA.Fill(DS, tableName);
                Conn.Close();
                return DS;

            }
            catch
            {
                DataSet DSEx = new DataSet();
                DataTable DT = new DataTable();
                DT.Columns.Add(new DataColumn("Data Not Found", System.Type.GetType("System.String")));

                DSEx.Tables.Add(DT);
                DSEx.AcceptChanges();
                return DSEx;
            }
        }

        public DateTime GetDateServer()
        {
            try
            {
                string strC = ReadFileDB(NP_Cls.PathDB);
                SqlConnection Conn = new SqlConnection(strC);
                if (Conn.State == ConnectionState.Open) { Conn.Close(); }
                Conn.Open();
                SqlDataAdapter DA = new SqlDataAdapter("SELECT GETDATE() AS d", Conn);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                Conn.Close();
                return Convert.ToDateTime(DS.Tables[0].Rows[0][0]);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public string ReadFileDB(string sPath)
        {
            string sRead = string.Empty;
            try
            {
                StreamReader FileStm = new StreamReader(sPath);
                sRead = FileStm.ReadLine();
                FileStm.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return sRead;
        }
        public void WriteFileDB(string sPath,string ForWrite)
        {
            StreamWriter sw = new StreamWriter(sPath);
            sw.WriteLine(ForWrite);
            sw.Close();
        }
        public DataSet GetDataWithTran(string Sql, SqlTransaction Tran, SqlConnection Cn)
        {
            try
            {
                SqlCommand cmdSe = new SqlCommand();
                cmdSe.CommandText = Sql;
                cmdSe.Connection = Cn;
                cmdSe.Transaction = Tran;
                SqlDataAdapter da = new SqlDataAdapter(cmdSe);
                DataSet ds = new DataSet();
                da.Fill(ds, "SE");
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void BindCB(ComboBox objCB, string Sql, string Val, string Dis, string FirstRow)
        {
            DataSet ds = new DataSet(); ds = GetClientDataSet(Sql);
            DataRow dr = ds.Tables[0].NewRow();
            dr[0] = 0; dr[1] = FirstRow;
            ds.Tables[0].Rows.InsertAt(dr, 0);
            ds.AcceptChanges();
            objCB.DataSource = ds.Tables[0];
            objCB.DisplayMember = Dis; objCB.ValueMember = Val;
        }
        public bool ReqField(TextBox objText, string strText)
        {
            if (objText.Text.Trim() == string.Empty) { MessageBox.Show(strText, "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1); objText.Focus(); return false; }
            else
            { return true; }
        }
        public bool ReqField(ComboBox objCB, string strText)
        {
            if ((objCB.SelectedIndex == 0) || (objCB.SelectedIndex == -1)) { MessageBox.Show(strText, "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1); objCB.Focus(); return false; } else { return true; }
        }
        public bool SqlCmd(string Sql, ref string strErr)
        {
            string strC = ReadFileDB(NP_Cls.PathDB);
            SqlConnection Conn = new SqlConnection(strC);
            if (Conn.State == ConnectionState.Open) { Conn.Close(); }
            Conn.Open();
            try
            {
                SqlCommand cmdSe = new SqlCommand();
                cmdSe.CommandText = Sql;
                cmdSe.Connection = Conn;
                cmdSe.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                strErr = ex.Message;
                return false;
            }
            finally
            {
                if (Conn.State == ConnectionState.Open) { Conn.Close(); }
            }
        }
        public Int32 GenRunID()
        {
            try
            {
                string strYear = GetClientDataSet("select year(sysdate()) from t_runid").Tables[0].Rows[0][0].ToString();
                NP_Cls.SqlSelect = "SELECT sYear, iRunID FROM t_runid WHERE (sYear = '" + strYear + "')"; Int32 iRunID = 0;
                DataSet dsR = new DataSet(); dsR = GetClientDataSet(NP_Cls.SqlSelect);
                if (dsR.Tables[0].Rows.Count > 0)
                {
                    iRunID = Convert.ToInt32(dsR.Tables[0].Rows[0][1]) + 1; string strErr = string.Empty;
                    NP_Cls.sqlUpdate = "UPDATE t_runid SET iRunID = " + iRunID + " WHERE (sYear = '" + strYear + "')";
                    SqlCmd(NP_Cls.sqlUpdate, ref strErr);
                    return iRunID;
                }
                else
                {
                    NP_Cls.SqlInsert = "INSERT INTO t_runid (sYear, iRunID) VALUES ('" + strYear + "', 1)"; string strErr = string.Empty;
                    SqlCmd(NP_Cls.SqlInsert, ref strErr);
                    return 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void MSGB(NPMgsStyle NPStyle, string strWord)
        {
            switch (NPStyle)
            {
                case NPMgsStyle.WarningType:
                    MessageBox.Show(strWord, NPCaption.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case NPMgsStyle.InfoType:
                    MessageBox.Show(strWord, NPCaption.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case NPMgsStyle.ErrorType:
                    MessageBox.Show(strWord, NPCaption.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
        public DialogResult MSGB(string strWord)
        {
            if (MessageBox.Show(strWord, NPCaption.Question, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                return DialogResult.Yes;
            }
            else
            {
                return DialogResult.No;
            }
        }

        public static class NPCaption
        {
            public const string Warning = "Warning !!"; public const string Information = "Information !!";
            public const string Question = "Question !!"; public const string Error = "Error !!";
        }

        public static class NPTranType
        {
            public const string Insert = "Insert"; public const string Update = "Update";
            public const string Delete = "Delete"; 
        }
        public enum NPMgsStyle
        {
            WarningType,
            Invalid,
            ErrorType,
            InfoType
        }
        public string getip()
        {
            return Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
        }
        public static void myInteger(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            switch (e.KeyChar.ToString())
            {
                case "\b":
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    e.Handled = false;
                    break;
                default:
                    e.Handled = true;
                    break;
            }
        }
        public static void myDecimal(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            TextBox tb;
            tb = (TextBox)sender;
            if ((tb.Text == string.Empty) & (e.KeyChar.ToString() == "."))
            {
                e.Handled = true;
                tb.Text = "0.";
                tb.Select(2, 0);
                return;
            }
            if ((e.KeyChar.ToString() == "\b"))
            {
                e.Handled = false;
                return;
            }
            if (!IsNumeric(tb.Text + e.KeyChar.ToString()))
            {
                e.Handled = true;
                return;
            }
            switch (e.KeyChar.ToString())
            {
                case ".":
                case "\b":
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    e.Handled = false;
                    break;
                default:
                    e.Handled = true;
                    break;
            }
        }
        private static bool IsNumeric(object value)
        {
            try
            {
                double i = Convert.ToDouble(value.ToString());
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public bool _TRanSave(SqlConnection oConn, SqlTransaction Tr, string TranType, string TranTable, string TranUser)
        {
            try
            {
                SqlCommand cmdTran = new SqlCommand();
                NP_Cls.sqlUpdate = "INSERT INTO t_History (TranType, TranTable, TranUser) VALUES (@TranType, @TranTable, @TranUser)";
                cmdTran.Parameters.Add("@TranType", SqlDbType.NVarChar, 255).Value = TranType;
                cmdTran.Parameters.Add("@TranTable", SqlDbType.NVarChar, 255).Value = TranTable;
                cmdTran.Parameters.Add("@TranUser", SqlDbType.NVarChar, 255).Value = TranUser;
                cmdTran.Connection = oConn; cmdTran.CommandText = NP_Cls.sqlUpdate; cmdTran.Transaction = Tr;
                cmdTran.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string _genBatch(string strMaterial, SqlConnection oConnTmp, SqlTransaction TrTmp)
        {
            try
            {
                NP_Cls NP = new NP_Cls(); string strTmp = string.Empty;
                NP_Cls.SqlSelect = "SELECT MaterialTypeName, RIGHT(YEAR(GETDATE()), 1) AS y, MONTH(GETDATE()) AS m FROM   m_Material WHERE (FileStatus = N'1') AND (MaterialCode = N'" + strMaterial + "')";

                DataSet tmpDs = new DataSet();
                tmpDs = NP.GetDataWithTran(NP_Cls.SqlSelect, TrTmp, oConnTmp);
                if (tmpDs.Tables[0].Rows.Count > 0)
                {
                    string tmpStr = string.Empty; 
                    string tmpYear = tmpDs.Tables[0].Rows[0][1].ToString();
                    string tmpMonth = tmpDs.Tables[0].Rows[0][2].ToString(); 
                    string tmpRunning = string.Empty;

                    if (tmpMonth.Length > 1)
                    {
                        switch (tmpMonth.ToString())
                        {
                            case "10":
                                tmpMonth = "A";
                                break;
                            case "11":
                                tmpMonth = "B";
                                break;
                            case "12":
                                tmpMonth = "C";
                                break;
                        }
                    }

                    // Find exist rows 
                    DataSet tmpDsExist = new DataSet();
                    NP_Cls.SqlSelect = "SELECT sMatType, sYear, sMonth, Running FROM   t_BatchRunning WHERE (MaterialTypeName = N'" + tmpDs.Tables[0].Rows[0][0].ToString().ToUpper() + "') AND (sYear = N'" + tmpYear + "') AND (sMonth = N'" + tmpMonth + "')"; tmpDsExist = NP.GetDataWithTran(NP_Cls.SqlSelect, TrTmp, oConnTmp);
                    if (tmpDsExist.Tables[0].Rows.Count > 0)
                    {
                        tmpDsExist.Tables[0].Rows[0]["Running"] = (Convert.ToInt32(tmpDsExist.Tables[0].Rows[0]["Running"].ToString()) + 1).ToString().PadLeft(7, '0');
                        strTmp = "UPDATE  t_BatchRunning SET Running = '" + tmpDsExist.Tables[0].Rows[0]["Running"].ToString() + "' WHERE  (MaterialTypeName = '" + tmpDs.Tables[0].Rows[0][0].ToString().ToUpper() + "') AND (sMatType = '" + tmpDsExist.Tables[0].Rows[0]["sMatType"].ToString() + "') AND (sYear = '" + tmpYear + "') AND (sMonth = '" + tmpMonth + "' )"; string strErrUp = string.Empty;
                        SqlCommand cmdTmp = new SqlCommand(strTmp, oConnTmp, TrTmp);
                        cmdTmp.ExecuteNonQuery();
                        return tmpDsExist.Tables[0].Rows[0]["sMatType"].ToString() + tmpYear + tmpMonth + tmpDsExist.Tables[0].Rows[0]["Running"].ToString();
                    }
                    else
                    {
                        switch (tmpDs.Tables[0].Rows[0][0].ToString().ToUpper())
                        {
                            case "RM":
                                tmpStr = "1";
                                break;
                            case "PK":
                                tmpStr = "2";
                                break;
                            case "WIP":
                                tmpStr = "3";
                                break;
                            case "FG":
                                tmpStr = "4";
                                break;
                            case "SET":
                                tmpStr = "5";
                                break;
                        }

                   

                        strTmp = "INSERT INTO t_BatchRunning (MaterialTypeName, sMatType, sYear, sMonth, Running) VALUES ('" + tmpDs.Tables[0].Rows[0][0].ToString().ToUpper() + "', '" + tmpStr + "', '" + tmpYear + "', '" + tmpMonth + "', '0000001')"; string strErr = string.Empty;
                        SqlCommand cmdTmp = new SqlCommand(strTmp, oConnTmp, TrTmp);
                        cmdTmp.ExecuteNonQuery();
                        return tmpStr + tmpYear + tmpMonth + "0000001";
                    }               

                 }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string _genBatch(string strMaterial)
        {
            SqlConnection oConn; NP_Cls NP = new NP_Cls(); 
            oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
            if (oConn.State == ConnectionState.Open) { oConn.Close(); }
            oConn.Open();

            try
            {
               string strTmp = string.Empty;
                NP_Cls.SqlSelect = "SELECT MaterialTypeName, RIGHT(YEAR(GETDATE()), 1) AS y, MONTH(GETDATE()) AS m FROM   m_Material WHERE (FileStatus = N'1') AND (MaterialCode = N'" + strMaterial + "')";

                DataSet tmpDs = new DataSet();
                tmpDs = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (tmpDs.Tables[0].Rows.Count > 0)
                {
                    string tmpStr = string.Empty; string tmpYear = tmpDs.Tables[0].Rows[0][1].ToString();
                    string tmpMonth = tmpDs.Tables[0].Rows[0][2].ToString(); string tmpRunning = string.Empty;
                 
                    // Find exist rows 
                    DataSet tmpDsExist = new DataSet();
                    NP_Cls.SqlSelect = "SELECT sMatType, sYear, sMonth, Running FROM   t_BatchRunning WHERE (MaterialTypeName = N'" + tmpDs.Tables[0].Rows[0][0].ToString().ToUpper() + "') AND (sYear = N'" + tmpYear + "') AND (sMonth = N'" + tmpMonth + "')"; tmpDsExist = NP.GetClientDataSet(NP_Cls.SqlSelect);
                    if (tmpDsExist.Tables[0].Rows.Count > 0)
                    {
                        tmpDsExist.Tables[0].Rows[0]["Running"] = (Convert.ToInt32(tmpDsExist.Tables[0].Rows[0]["Running"].ToString()) + 1).ToString().PadLeft(7, '0');
                        strTmp = "UPDATE  t_BatchRunning SET Running = '" + tmpDsExist.Tables[0].Rows[0]["Running"].ToString() + "' WHERE  (MaterialTypeName = '" + tmpDs.Tables[0].Rows[0][0].ToString().ToUpper() + "') AND (sMatType = '" + tmpDsExist.Tables[0].Rows[0]["sMatType"].ToString() + "') AND (sYear = '" + tmpYear + "') AND (sMonth = '" + tmpMonth + "' )"; string strErrUp = string.Empty;
                        SqlCommand cmdTmp = new SqlCommand(strTmp, oConn);
                        cmdTmp.ExecuteNonQuery();
                        return tmpDsExist.Tables[0].Rows[0]["sMatType"].ToString() + tmpYear + tmpMonth + tmpDsExist.Tables[0].Rows[0]["Running"].ToString();
                    }
                    else
                    {
                        switch (tmpDs.Tables[0].Rows[0][0].ToString().ToUpper())
                        {
                            case "RM":
                                tmpStr = "1";
                                break;
                            case "PK":
                                tmpStr = "2";
                                break;
                            case "WIP":
                                tmpStr = "3";
                                break;
                            case "FG":
                                tmpStr = "4";
                                break;
                            case "SET":
                                tmpStr = "5";
                                break;
                        }

                        if (tmpMonth.Length > 1)
                        {
                            switch (tmpMonth.ToString())
                            {
                                case "10":
                                    tmpMonth = "A";
                                    break;
                                case "11":
                                    tmpMonth = "B";
                                    break;
                                case "12":
                                    tmpMonth = "C";
                                    break;
                            }
                        }

                        strTmp = "INSERT INTO t_BatchRunning (MaterialTypeName, sMatType, sYear, sMonth, Running) VALUES ('" + tmpDs.Tables[0].Rows[0][0].ToString().ToUpper() + "', '" + tmpStr + "', '" + tmpYear + "', '" + tmpMonth + "', '0000001')"; string strErr = string.Empty;
                        SqlCommand cmdTmp = new SqlCommand(strTmp, oConn);
                        cmdTmp.ExecuteNonQuery();
                        return tmpStr + tmpYear + tmpMonth + "0000001";
                    }

                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
            }
        }

        public static string _genSelectBatch(string strMaterial)
        {
            SqlConnection oConn; NP_Cls NP = new NP_Cls();
            oConn = new SqlConnection(NP.ReadFileDB(NP_Cls.PathDB));
            if (oConn.State == ConnectionState.Open) { oConn.Close(); }
            oConn.Open();

            try
            {
                string strTmp = string.Empty;
                NP_Cls.SqlSelect = "SELECT MaterialTypeName, RIGHT(YEAR(GETDATE()), 1) AS y, MONTH(GETDATE()) AS m FROM   m_Material WHERE (FileStatus = N'1') AND (MaterialCode = N'" + strMaterial + "')";

                DataSet tmpDs = new DataSet();
                tmpDs = NP.GetClientDataSet(NP_Cls.SqlSelect);
                if (tmpDs.Tables[0].Rows.Count > 0)
                {
                    string tmpStr = string.Empty; string tmpYear = tmpDs.Tables[0].Rows[0][1].ToString();
                    string tmpMonth = tmpDs.Tables[0].Rows[0][2].ToString(); string tmpRunning = string.Empty;

                    // Find exist rows 
                    DataSet tmpDsExist = new DataSet();
                    NP_Cls.SqlSelect = "SELECT sMatType, sYear, sMonth, Running FROM   t_BatchRunning WHERE (MaterialTypeName = N'" + tmpDs.Tables[0].Rows[0][0].ToString().ToUpper() + "') AND (sYear = N'" + tmpYear + "') AND (sMonth = N'" + tmpMonth + "')"; tmpDsExist = NP.GetClientDataSet(NP_Cls.SqlSelect);
                    if (tmpDsExist.Tables[0].Rows.Count > 0)
                    {
                        tmpDsExist.Tables[0].Rows[0]["Running"] = (Convert.ToInt32(tmpDsExist.Tables[0].Rows[0]["Running"].ToString()) + 1).ToString().PadLeft(7, '0');
                        return tmpDsExist.Tables[0].Rows[0]["sMatType"].ToString() + tmpYear + tmpMonth + tmpDsExist.Tables[0].Rows[0]["Running"].ToString();
                    }
                    else
                    {
                        switch (tmpDs.Tables[0].Rows[0][0].ToString().ToUpper())
                        {
                            case "RM":
                                tmpStr = "1";
                                break;
                            case "PK":
                                tmpStr = "2";
                                break;
                            case "WIP":
                                tmpStr = "3";
                                break;
                            case "FG":
                                tmpStr = "4";
                                break;
                            case "SET":
                                tmpStr = "5";
                                break;
                        }

                        if (tmpMonth.Length > 1)
                        {
                            switch (tmpMonth.ToString())
                            {
                                case "10":
                                    tmpMonth = "A";
                                    break;
                                case "11":
                                    tmpMonth = "B";
                                    break;
                                case "12":
                                    tmpMonth = "C";
                                    break;
                            }
                        }

                        return tmpStr + tmpYear + tmpMonth + "0000001";
                    }

                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (oConn.State == ConnectionState.Open) { oConn.Close(); }
            }
        }       
    }
}
