using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CPCA
{
    public partial class FrmRVERS : Form
    {
        private MySqlConnection AppConn = null;

        private MySqlTransaction MySqltr = null;

        private MySqlDataReader MySqlDr = null;

        private MySqlCommand MySqlCmd = null;

        //private int rvers_id;

        private string  rvers_code, rvers_old_ratio_share, rvers_new_ratio_share, rvers_new_par_value, rvers_trade_dt, rvers_record_dt, rvers_share, rvers_remark, created_date, revised_date, filename;

        private DataGridViewTextBoxColumn rcode, rold_ratio_share, rnew_ratio_share, rnew_par_value, rtrade_dt, rrecord_dt, rshare, rremark, rcreated_date, rrevised_date;


        public FrmRVERS()
        {
            InitializeComponent();
            //rvers_id = null;
            rvers_code = null;
            rrevised_date = null;
            rvers_new_ratio_share = null;
            rvers_new_par_value = null;
            rvers_trade_dt = null;
            rvers_record_dt = null;
            rvers_share = null;
            rvers_remark = null;
            created_date = null;
            revised_date = null;
            filename = null;
        }

        private MySqlConnection OpenDatabase()
        {
            string connectionString = "data source=10.1.4.204;    database=cpca_profile;user id=cpcauser;password=cpc4u53r;Convert Zero Datetime=true;Pooling=false";
            AppConn = new MySqlConnection(connectionString);
            try
            {
                if (AppConn != null && AppConn.State == ConnectionState.Closed)
                {
                    AppConn.Open();
                }
            }
            catch
            {
            }
            return AppConn;
        }

        private void CloseDatabase()
        {
            if (AppConn != null && AppConn.State == ConnectionState.Open)
            {
                AppConn.Close();
                AppConn.Dispose();
            }
        }

        public bool Check_RVERS(string MysqlQry)
        {


            bool result = true;
            try
            {
                MySqlCmd = new MySqlCommand(MysqlQry, AppConn);
                MySqlCmd.CommandText = MysqlQry;
                MySqlCmd.CommandTimeout = 90;
                using (MySqlDr = MySqlCmd.ExecuteReader()) ;

                if (MySqlDr.Read())
                {
                    result = true;

                    bool res2 = result;

                }

                MySqlDr.Close();
                MySqlDr.Dispose();
                MySqlCmd.Dispose();
                MysqlQry = null;
            }
            catch
            {
            }
            return result;


        }

        private void PrepareSingle(string MySqlQry)
        {
            try
            {
                MySqltr = AppConn.BeginTransaction();
                MySqlCmd = new MySqlCommand();
                MySqlCmd.Connection = AppConn;
                MySqlCmd.Transaction = MySqltr;
                MySqlCmd.CommandText = MySqlQry;
                MySqlCmd.ExecuteNonQuery();
                MySqltr.Commit();
            }
            catch (MySqlException ex2)
            {
                try
                {
                    MySqltr.Rollback();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                MessageBox.Show(ex2.Message.ToString());
            }
        }
        private void LoadList(string filename)
        {
            try
            {
                XmlDataDocument xmlDataDocument = new XmlDataDocument();
                int num = 0;
                FileStream inStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                xmlDataDocument.Load(inStream);
                XmlNodeList elementsByTagName = xmlDataDocument.GetElementsByTagName("record");
                DGVRVERS.Rows.Clear();
                for (num = 0; num <= elementsByTagName.Count - 1; num++)
                {
                    DGVRVERS.Rows.Add();
                    //DGVRVERS.Rows[num].Cells["kid"].Value = elementsByTagName[num].ChildNodes.Item(1).InnerText.Trim();
                    DGVRVERS.Rows[num].Cells["rcode"].Value = elementsByTagName[num].ChildNodes.Item(1).InnerText.Trim();
                    DGVRVERS.Rows[num].Cells["rold_ratio_share"].Value = elementsByTagName[num].ChildNodes.Item(2).InnerText.Trim();
                    DGVRVERS.Rows[num].Cells["rnew_ratio_share"].Value = elementsByTagName[num].ChildNodes.Item(3).InnerText.Trim();
                    DGVRVERS.Rows[num].Cells["rnew_par_value"].Value = elementsByTagName[num].ChildNodes.Item(4).InnerText.Trim();
                    DGVRVERS.Rows[num].Cells["rtrade_dt"].Value = elementsByTagName[num].ChildNodes.Item(5).InnerText.Trim();
                    DGVRVERS.Rows[num].Cells["rrecord_dt"].Value = elementsByTagName[num].ChildNodes.Item(6).InnerText.Trim();
                    DGVRVERS.Rows[num].Cells["rshare"].Value = elementsByTagName[num].ChildNodes.Item(7).InnerText.Trim();
                    DGVRVERS.Rows[num].Cells["rremark"].Value = elementsByTagName[num].ChildNodes.Item(8).InnerText.Trim();
                    DGVRVERS.Rows[num].Cells["rcreated_date"].Value = elementsByTagName[num].ChildNodes.Item(9).InnerText.Trim();
                    DGVRVERS.Rows[num].Cells["rrevised_date"].Value = elementsByTagName[num].ChildNodes.Item(10).InnerText.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public void OpenDialogReq()
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.Title = "C# Corner Open File Dialog";
                opf.InitialDirectory = "D:\\cpcaxml";
                opf.Filter = "Xml File|*.xml";
                opf.FilterIndex = 2;
                opf.RestoreDirectory = true;
                if (opf.ShowDialog() == DialogResult.OK)
                {
                    txtFileName.Text = opf.FileName;
                    LoadList(txtFileName.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information is not valid", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            OpenDialogReq();
        }

        private void toolStripSave_Click(object sender, EventArgs e)
        {
            try
            {

                OpenDatabase();
                filename = txtFileName.Text;
                string[] array = filename.Split('\\');
                filename = array[array.Length - 1];
                for (int i = 0; i < DGVRVERS.RowCount; i++)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    if (Convert.ToString(DGVRVERS.Rows[i].Cells["rcode"].Value) != "")
                    {
                        //rvers_id = Convert.ToString(DGVRVERS.Rows[i].Cells["kid"].Value);
                        rvers_code = Convert.ToString(DGVRVERS.Rows[i].Cells["rcode"].Value);
                        rvers_old_ratio_share = Convert.ToString(DGVRVERS.Rows[i].Cells["rold_ratio_share"].Value);
                        rvers_new_ratio_share = Convert.ToString(DGVRVERS.Rows[i].Cells["rnew_ratio_share"].Value);
                        rvers_new_par_value = Convert.ToString(DGVRVERS.Rows[i].Cells["rnew_par_value"].Value);
                        rvers_trade_dt = Convert.ToString(DGVRVERS.Rows[i].Cells["rtrade_dt"].Value);
                        rvers_record_dt = Convert.ToString(DGVRVERS.Rows[i].Cells["rrecord_dt"].Value);
                        rvers_share = Convert.ToString(DGVRVERS.Rows[i].Cells["rshare"].Value);
                        rvers_remark = Convert.ToString(DGVRVERS.Rows[i].Cells["rremark"].Value);
                        created_date = Convert.ToString(DGVRVERS.Rows[i].Cells["rcreated_date"].Value);
                        revised_date = Convert.ToString(DGVRVERS.Rows[i].Cells["rrevised_date"].Value);
                    }
                    string str1 = "('" + rvers_code + "','" + rvers_old_ratio_share + "','" + rvers_new_ratio_share + "','" + rvers_new_par_value + "','" + rvers_trade_dt + "'," + "'" + rvers_record_dt + "','" + rvers_share + "','" + rvers_remark + "','" + created_date + "','" + revised_date + "')";
                    string str2 = str1;
                    string MySqlQry;
                    if (Check_RVERS("call sp_checkrvers('" + rvers_code + "')"))
                    {
                        FrmRVERS.MySQLEscape(str2);
                        MySqlQry = "call sp_update_rvers" + str1;
                    }
                    else
                        MySqlQry = "call sp_insert_rvers (\"" + FrmRVERS.MySQLEscape(str2) + "\")";
                    PrepareSingle(MySqlQry);
                }
                CloseDatabase();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message, "Informasi Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                int num = (int)MessageBox.Show("RVERS Succesfully Updated");
            }
        }
        private static string MySQLEscape(string str)
        {
            return Regex.Replace(str, "[\\x00'\"\\b\\n\\r\\t\\cZ\\\\%_]", (MatchEvaluator)(match =>
            {
                string str1 = match.Value;
                switch (str1)
                {
                    case "\0":
                        return "\\0";
                    case "\b":
                        return "\\b";
                    case "\n":
                        return "\\n";
                    case "\r":
                        return "\\r";
                    case "\t":
                        return "\\t";
                    case "\u001A":
                        return "\\Z";
                    default:
                        return "\\" + str1;
                }
            }));
        }

        private void toolStripClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripCancel_Click(object sender, EventArgs e)
        {
            DGVRVERS.Rows.Clear();
            txtFileName.Clear();
        }
    }
}
