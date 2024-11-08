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
    public partial class FrmPUEXP : Form
    {
        private MySqlConnection AppConn = null;

        private MySqlTransaction MySqltr = null;

        private MySqlDataReader MySqlDr = null;

        private MySqlCommand MySqlCmd = null;

        private string puexp_code, puexp_day, puexp_date, puexp_time, puexp_datetime, puexp_venue, created_date, revised_date, filename;

        private DataGridViewTextBoxColumn pcode, pday, pdate, ptime, pdatetime, pvenue, pcreated_date, prevised_date;


        public FrmPUEXP()
        {
            InitializeComponent();
            puexp_code = null;
            puexp_day = null;
            puexp_date = null;
            puexp_time = null;
            puexp_datetime = null;
            puexp_venue = null;
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

        public bool Check_Puexp(string MysqlQry)
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
                DGVPUEXP.Rows.Clear();
                for (num = 0; num <= elementsByTagName.Count - 1; num++)
                {
                    DGVPUEXP.Rows.Add();
                    DGVPUEXP.Rows[num].Cells["pcode"].Value = elementsByTagName[num].ChildNodes.Item(1).InnerText.Trim();
                    DGVPUEXP.Rows[num].Cells["pday"].Value = elementsByTagName[num].ChildNodes.Item(2).InnerText.Trim();
                    DGVPUEXP.Rows[num].Cells["pdate"].Value = elementsByTagName[num].ChildNodes.Item(3).InnerText.Trim();
                    DGVPUEXP.Rows[num].Cells["ptime"].Value = elementsByTagName[num].ChildNodes.Item(4).InnerText.Trim();
                    DGVPUEXP.Rows[num].Cells["pdatetime"].Value = elementsByTagName[num].ChildNodes.Item(5).InnerText.Trim();
                    DGVPUEXP.Rows[num].Cells["pvenue"].Value = elementsByTagName[num].ChildNodes.Item(6).InnerText.Trim();
                    DGVPUEXP.Rows[num].Cells["pcreated_date"].Value = elementsByTagName[num].ChildNodes.Item(7).InnerText.Trim();
                    DGVPUEXP.Rows[num].Cells["prevised_date"].Value = elementsByTagName[num].ChildNodes.Item(8).InnerText.Trim();
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
                for (int i = 0; i < DGVPUEXP.RowCount; i++)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    if (Convert.ToString(DGVPUEXP.Rows[i].Cells["pcode"].Value) != "")
                    {
                        puexp_code = Convert.ToString(DGVPUEXP.Rows[i].Cells["pcode"].Value);
                        puexp_day = Convert.ToString(DGVPUEXP.Rows[i].Cells["pday"].Value);
                        puexp_date = Convert.ToString(DGVPUEXP.Rows[i].Cells["pdate"].Value);
                        puexp_time = Convert.ToString(DGVPUEXP.Rows[i].Cells["ptime"].Value);
                        puexp_datetime = Convert.ToString(DGVPUEXP.Rows[i].Cells["pdatetime"].Value);
                        puexp_venue = Convert.ToString(DGVPUEXP.Rows[i].Cells["pvenue"].Value);
                        created_date = Convert.ToString(DGVPUEXP.Rows[i].Cells["pcreated_date"].Value);
                        revised_date = Convert.ToString(DGVPUEXP.Rows[i].Cells["prevised_date"].Value);
                    }
                    string text = "('" + puexp_code + "','" + puexp_day + "','" + puexp_date + "','" + puexp_time + "','" + puexp_datetime + "','" + puexp_venue + "',";
                    string text2 = text;
                    text = text2 + "'" + created_date + "','" + revised_date + "')";
                    string str = text;
                    if (Check_Puexp("call sp_checkpuexp('" + puexp_code + "')"))
                    {
                        str = MySQLEscape(str);
                        str = "call sp_update_puexp" + text;
                    }
                    else
                    {
                        str = MySQLEscape(str);
                        str = "call sp_insert_puexp (\"" + str + "\")";
                    }
                    PrepareSingle(str);
                }
            CloseDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information is not valid", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                MessageBox.Show("PUEXP Succesfully Updated");
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
            DGVPUEXP.Rows.Clear();
            txtFileName.Clear();
        }
    }
}
