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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace CPCA
{
    public partial class FrmRIGHT : Form
    {
        private MySqlConnection AppConn = null;

        private MySqlTransaction MySqltr = null;

        private MySqlDataReader MySqlDr = null;

        private MySqlCommand MySqlCmd = null;



        private string right_code, right_ratio, right_cum_dt, right_ex_dt, right_dps_dt, right_price, right_trading_period, right_indicator, created_date, revised_date, filename;

        private DataGridViewTextBoxColumn rcode, rratio, rcum_dt, rex_dt, rdps_dt, rprice, rtrading_period, rindicator, rcreated_date, rrevised_date;


        public FrmRIGHT()
        {
            InitializeComponent();
            right_code = null;
            right_ratio = null;
            right_cum_dt = null;
            right_ex_dt = null;
            right_dps_dt = null;
            right_price = null;
            right_trading_period = null;
            right_indicator = null;
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

        public bool Check_Right(string MysqlQry)
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
                DGVRIGHT.Rows.Clear();
                for (num = 0; num <= elementsByTagName.Count - 1; num++)
                {
                    DGVRIGHT.Rows.Add();
                    DGVRIGHT.Rows[num].Cells["rcode"].Value = elementsByTagName[num].ChildNodes.Item(1).InnerText.Trim();
                    DGVRIGHT.Rows[num].Cells["rratio"].Value = elementsByTagName[num].ChildNodes.Item(2).InnerText.Trim();
                    DGVRIGHT.Rows[num].Cells["rcum_dt"].Value = elementsByTagName[num].ChildNodes.Item(3).InnerText.Trim();
                    DGVRIGHT.Rows[num].Cells["rex_dt"].Value = elementsByTagName[num].ChildNodes.Item(4).InnerText.Trim();
                    DGVRIGHT.Rows[num].Cells["rdps_dt"].Value = elementsByTagName[num].ChildNodes.Item(5).InnerText.Trim();
                    DGVRIGHT.Rows[num].Cells["rprice"].Value = elementsByTagName[num].ChildNodes.Item(6).InnerText.Trim();
                    DGVRIGHT.Rows[num].Cells["rtrading_period"].Value = elementsByTagName[num].ChildNodes.Item(7).InnerText.Trim();
                    DGVRIGHT.Rows[num].Cells["rindicator"].Value = elementsByTagName[num].ChildNodes.Item(8).InnerText.Trim();
                    DGVRIGHT.Rows[num].Cells["rcreated_date"].Value = elementsByTagName[num].ChildNodes.Item(10).InnerText.Trim();
                    DGVRIGHT.Rows[num].Cells["rrevised_date"].Value = elementsByTagName[num].ChildNodes.Item(11).InnerText.Trim();
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
                for (int i = 0; i < DGVRIGHT.RowCount; i++)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    if (Convert.ToString(DGVRIGHT.Rows[i].Cells["rcode"].Value) != "")
                    {
                        right_code = Convert.ToString(DGVRIGHT.Rows[i].Cells["rcode"].Value);
                        right_ratio = Convert.ToString(DGVRIGHT.Rows[i].Cells["rratio"].Value);
                        right_cum_dt = Convert.ToString(DGVRIGHT.Rows[i].Cells["rcum_dt"].Value);
                        right_ex_dt = Convert.ToString(DGVRIGHT.Rows[i].Cells["rex_dt"].Value);
                        right_dps_dt = Convert.ToString(DGVRIGHT.Rows[i].Cells["rdps_dt"].Value);
                        right_price = Convert.ToString(DGVRIGHT.Rows[i].Cells["rprice"].Value);
                        right_trading_period = Convert.ToString(DGVRIGHT.Rows[i].Cells["rtrading_period"].Value);
                        right_indicator = Convert.ToString(DGVRIGHT.Rows[i].Cells["rindicator"].Value);
                        created_date = Convert.ToString(DGVRIGHT.Rows[i].Cells["rcreated_date"].Value);
                        revised_date = Convert.ToString(DGVRIGHT.Rows[i].Cells["rrevised_date"].Value);
                    }

                    string str1 = "('" + this.right_code + "','" + this.right_ratio + "','" + this.right_cum_dt + "','" + this.right_ex_dt + "','" + this.right_dps_dt + "','" + this.right_price + "','" + this.right_trading_period + "','" + this.right_indicator + "','" + this.created_date + "','" + this.revised_date + "')";
                    string str2 = str1;
                    string MySqlQry;
                    if (this.Check_Right("call sp_checkright('" + this.right_code + "','" + this.created_date + "')"))
                    {
                        MySQLEscape(str2);
                        MySqlQry = "call sp_update_right" + str1;
                       
                    }
                    else
                        MySqlQry = "call sp_insert_right (\"" + MySQLEscape(str2) + "\")";
                   
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
                int num = (int)MessageBox.Show("RIGHT Succesfully Updated");
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
            DGVRIGHT.Rows.Clear();
            txtFileName.Clear();
        }
    }
}
