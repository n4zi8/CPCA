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
    public partial class FrmJDIPO : Form
    {
        private MySqlConnection AppConn = null;

        private MySqlTransaction MySqltr = null;

        private MySqlDataReader MySqlDr = null;

        private MySqlCommand MySqlCmd = null;

        private string jdipo_comp, jdipo_business, jdipo_underwriter, jdipo_offer_dt, jdipo_record_dt, jdipo_total_share, jdipo_nom_share, jdipo_val_share, created_date, revised_date, filename;

        private DataGridViewTextBoxColumn jcomp, jbusiness, junderwriter, joffer_dt, jrecord_dt, jtotal_share, jnom_share, jval_share, jcreated_date, jrevised_date;


        public FrmJDIPO()
        {
            InitializeComponent();
            jdipo_comp = null;
            jdipo_business = null;
            jdipo_underwriter = null;
            jdipo_offer_dt = null;
            jdipo_record_dt = null;
            jdipo_total_share = null;
            jdipo_nom_share = null;
            jdipo_val_share = null;
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

        public bool Check_Jdipo(string MysqlQry)
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
                DGVJIPO.Rows.Clear();
                for (num = 0; num <= elementsByTagName.Count - 1; num++)
                {
                    DGVJIPO.Rows.Add();
                    DGVJIPO.Rows[num].Cells["jcomp"].Value = elementsByTagName[num].ChildNodes.Item(1).InnerText.Trim();
                    DGVJIPO.Rows[num].Cells["jbusiness"].Value = elementsByTagName[num].ChildNodes.Item(2).InnerText.Trim();
                    DGVJIPO.Rows[num].Cells["junderwriter"].Value = elementsByTagName[num].ChildNodes.Item(3).InnerText.Trim();
                    DGVJIPO.Rows[num].Cells["joffer_dt"].Value = elementsByTagName[num].ChildNodes.Item(4).InnerText.Trim();
                    DGVJIPO.Rows[num].Cells["jrecord_dt"].Value = elementsByTagName[num].ChildNodes.Item(5).InnerText.Trim();
                    DGVJIPO.Rows[num].Cells["jtotal_share"].Value = elementsByTagName[num].ChildNodes.Item(6).InnerText.Trim();
                    DGVJIPO.Rows[num].Cells["jnom_share"].Value = elementsByTagName[num].ChildNodes.Item(7).InnerText.Trim();
                    DGVJIPO.Rows[num].Cells["jval_share"].Value = elementsByTagName[num].ChildNodes.Item(8).InnerText.Trim();
                    DGVJIPO.Rows[num].Cells["jcreated_date"].Value = elementsByTagName[num].ChildNodes.Item(9).InnerText.Trim();
                    DGVJIPO.Rows[num].Cells["jrevised_date"].Value = elementsByTagName[num].ChildNodes.Item(10).InnerText.Trim();
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
                for (int i = 0; i < DGVJIPO.RowCount; i++)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    if (Convert.ToString(DGVJIPO.Rows[i].Cells["jcomp"].Value) != "")
                    {
                        jdipo_comp = Convert.ToString(DGVJIPO.Rows[i].Cells["jcomp"].Value);
                        jdipo_business = Convert.ToString(DGVJIPO.Rows[i].Cells["jbusiness"].Value);
                        jdipo_underwriter = Convert.ToString(DGVJIPO.Rows[i].Cells["junderwriter"].Value);
                        jdipo_offer_dt = Convert.ToString(DGVJIPO.Rows[i].Cells["joffer_dt"].Value);
                        jdipo_record_dt = Convert.ToString(DGVJIPO.Rows[i].Cells["jrecord_dt"].Value);
                        jdipo_total_share = Convert.ToString(DGVJIPO.Rows[i].Cells["jtotal_share"].Value);
                        jdipo_nom_share = Convert.ToString(DGVJIPO.Rows[i].Cells["jnom_share"].Value);
                        jdipo_val_share = Convert.ToString(DGVJIPO.Rows[i].Cells["jval_share"].Value);
                        created_date = Convert.ToString(DGVJIPO.Rows[i].Cells["jcreated_date"].Value);
                        revised_date = Convert.ToString(DGVJIPO.Rows[i].Cells["jrevised_date"].Value);
                    }
                    string text = "('" + jdipo_comp + "','" + jdipo_business + "','" + jdipo_underwriter + "','" + jdipo_offer_dt + "','" + jdipo_record_dt + "','" + jdipo_total_share + "',";
                    string text2 = text;
                    text = text2 + "'" + jdipo_nom_share + "','" + jdipo_val_share + "','" + created_date + "','" + revised_date + "')";
                    string str = text;
                    if (Check_Jdipo("call sp_checkjdipo('" + jdipo_comp + "')"))
                    {
                        str = MySQLEscape(str);
                        str = "call sp_update_jdipo" + text;
                    }
                    else
                    {
                        str = MySQLEscape(str);
                        str = "call sp_insert_jdipo (\"" + str + "\")";
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
                MessageBox.Show("JDIPO Succesfully Updated");
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
            DGVJIPO.Rows.Clear();
            txtFileName.Clear();
        }
    }
}
