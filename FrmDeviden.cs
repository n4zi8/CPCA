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
    public partial class FrmDeviden : Form
    {
        private MySqlConnection AppConn = null;

        private MySqlTransaction MySqltr = null;

        private MySqlDataReader MySqlDr = null;

        private MySqlCommand MySqlCmd = null;

        private string dvden_code, dvden_status, dvden_per_share, dvden_payment_type, ex_dvden_dt, dvden_record_dt, dvden_dist_dt, created_date, revised_date, total_dvden, filename, cum_dvden_dt;

        private DataGridViewTextBoxColumn dcode, dstatus, dper_share, dpayment_type, dcum_dt, dex_dt, drecord_dt, ddist_dt, dcreated_date, drevised_date, dtotal;


        public FrmDeviden()
        {
            InitializeComponent();
            dvden_code = null;
            dvden_status = null;
            dvden_per_share = null;
            dvden_payment_type = null;
            ex_dvden_dt = null;
            dvden_record_dt = null;
            dvden_dist_dt = null;
            created_date = null;
            revised_date = null;
            total_dvden = null;
            filename = null;
            cum_dvden_dt = null;
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

        public bool Check_Deviden(string MysqlQry)
        {
            bool result = false;
            try
            {
                MySqlCmd = new MySqlCommand(MysqlQry, AppConn);
                MySqlCmd.CommandText = MysqlQry;
                MySqlCmd.CommandTimeout = 90;
                MySqlDr = MySqlCmd.ExecuteReader();
                if (MySqlDr.Read())
                {
                    result = true;
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
                DGVDeviden.Rows.Clear();
                for (num = 0; num <= elementsByTagName.Count - 1; num++)
                {
                    DGVDeviden.Rows.Add();
                    DGVDeviden.Rows[num].Cells["dcode"].Value = elementsByTagName[num].ChildNodes.Item(1).InnerText.Trim();
                    DGVDeviden.Rows[num].Cells["dstatus"].Value = elementsByTagName[num].ChildNodes.Item(2).InnerText.Trim();
                    DGVDeviden.Rows[num].Cells["dper_share"].Value = elementsByTagName[num].ChildNodes.Item(3).InnerText.Trim();
                    DGVDeviden.Rows[num].Cells["dpayment_type"].Value = elementsByTagName[num].ChildNodes.Item(4).InnerText.Trim();
                    DGVDeviden.Rows[num].Cells["dcum_dt"].Value = elementsByTagName[num].ChildNodes.Item(5).InnerText.Trim();
                    DGVDeviden.Rows[num].Cells["dex_dt"].Value = elementsByTagName[num].ChildNodes.Item(6).InnerText.Trim();
                    DGVDeviden.Rows[num].Cells["drecord_dt"].Value = elementsByTagName[num].ChildNodes.Item(7).InnerText.Trim();
                    DGVDeviden.Rows[num].Cells["ddist_dt"].Value = elementsByTagName[num].ChildNodes.Item(8).InnerText.Trim();
                    DGVDeviden.Rows[num].Cells["dcreated_date"].Value = elementsByTagName[num].ChildNodes.Item(9).InnerText.Trim();
                    DGVDeviden.Rows[num].Cells["drevised_date"].Value = elementsByTagName[num].ChildNodes.Item(10).InnerText.Trim();
                    DGVDeviden.Rows[num].Cells["dtotal"].Value = elementsByTagName[num].ChildNodes.Item(11).InnerText.Trim();
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
                for (int i = 0; i < DGVDeviden.RowCount; i++)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    if (Convert.ToString(DGVDeviden.Rows[i].Cells["dcode"].Value) != "")
                    {
                        dvden_code = Convert.ToString(DGVDeviden.Rows[i].Cells["dcode"].Value);
                        dvden_status = Convert.ToString(DGVDeviden.Rows[i].Cells["dstatus"].Value);
                        dvden_per_share = Convert.ToString(DGVDeviden.Rows[i].Cells["dper_share"].Value);
                        dvden_payment_type = Convert.ToString(DGVDeviden.Rows[i].Cells["dpayment_type"].Value);
                        cum_dvden_dt = Convert.ToString(DGVDeviden.Rows[i].Cells["dcum_dt"].Value);
                        ex_dvden_dt = Convert.ToString(DGVDeviden.Rows[i].Cells["dex_dt"].Value);
                        dvden_record_dt = Convert.ToString(DGVDeviden.Rows[i].Cells["drecord_dt"].Value);
                        dvden_dist_dt = Convert.ToString(DGVDeviden.Rows[i].Cells["ddist_dt"].Value);
                        created_date = Convert.ToString(DGVDeviden.Rows[i].Cells["dcreated_date"].Value);
                        revised_date = Convert.ToString(DGVDeviden.Rows[i].Cells["drevised_date"].Value);
                        total_dvden = Convert.ToString(DGVDeviden.Rows[i].Cells["dtotal"].Value);
                    }
                    string str1 = "('" + this.dvden_code + "','" + this.dvden_status + "','" + this.dvden_per_share + "','" + this.dvden_payment_type + "','" + this.cum_dvden_dt + "','" + this.ex_dvden_dt + "'," + "'" + this.dvden_record_dt + "','" + this.dvden_dist_dt + "','" + this.created_date + "','" + this.revised_date + "','" + this.total_dvden + "')";
                    string str2 = str1;
                    string MySqlQry;
                    if (this.Check_Deviden("call sp_checkdvden('" + this.dvden_code + "','" + this.created_date + "')"))
                    {
                        MySQLEscape(str2);
                        MySqlQry = "call sp_update_dvden" + str1;
                    }
                    else
                        MySqlQry = "call sp_insert_dvden (\"" + MySQLEscape(str2) + "\")";
                    this.PrepareSingle(MySqlQry);
                }
                this.CloseDatabase();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message, "Informasi Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                int num = (int)MessageBox.Show("DVDEN Succesfully Updated");
            }
        }

        private static string MySQLEscape(string str)
        {
            return Regex.Replace(str, "[\\x00'\"\\b\\n\\r\\t\\cZ\\\\%_]", delegate (Match match)
            {
                string value = match.Value;
                return value switch
                {
                    "\0" => "\\0",
                    "\b" => "\\b",
                    "\n" => "\\n",
                    "\r" => "\\r",
                    "\t" => "\\t",
                    "\u001a" => "\\Z",
                    _ => "\\" + value,
                };
            });
        }

        private void toolStripClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripCancel_Click(object sender, EventArgs e)
        {
            DGVDeviden.Rows.Clear();
            txtFileName.Clear();
        }
    }
}
