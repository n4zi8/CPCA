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
    public partial class FrmBonus : Form
    {
        private MySqlConnection AppConn = null;

        private MySqlTransaction MySqltr = null;

        private MySqlDataReader MySqlDr = null;

        private MySqlCommand MySqlCmd = null;

        private string code, ratio, cum_bonus_dt, ex_bonus_dt, recording_dt, distribution_dt, created_date, revised_date, filename;

        private DataGridViewTextBoxColumn bcode, bratio, bcum_bonus_dt, bex_bonus_dt, brecording_dt, bdistribution_dt, bcreated_date, brevised_date;


        public FrmBonus()
        {
            InitializeComponent();
            code = null;
            ratio = null;
            cum_bonus_dt = null;
            ex_bonus_dt = null;
            recording_dt = null;
            distribution_dt = null;
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

        public bool Check_Bonus(string MysqlQry)
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
                DGVBonus.Rows.Clear();
                for (num = 0; num <= elementsByTagName.Count - 1; num++)
                {
                    DGVBonus.Rows.Add();
                    DGVBonus.Rows[num].Cells["bcode"].Value = elementsByTagName[num].ChildNodes.Item(1).InnerText.Trim();
                    DGVBonus.Rows[num].Cells["bratio"].Value = elementsByTagName[num].ChildNodes.Item(2).InnerText.Trim();
                    DGVBonus.Rows[num].Cells["bcum_bonus_dt"].Value = elementsByTagName[num].ChildNodes.Item(3).InnerText.Trim();
                    DGVBonus.Rows[num].Cells["bex_bonus_dt"].Value = elementsByTagName[num].ChildNodes.Item(4).InnerText.Trim();
                    DGVBonus.Rows[num].Cells["brecording_dt"].Value = elementsByTagName[num].ChildNodes.Item(5).InnerText.Trim();
                    DGVBonus.Rows[num].Cells["bdistribution_dt"].Value = elementsByTagName[num].ChildNodes.Item(6).InnerText.Trim();
                    DGVBonus.Rows[num].Cells["bcreated_date"].Value = elementsByTagName[num].ChildNodes.Item(7).InnerText.Trim();
                    DGVBonus.Rows[num].Cells["brevised_date"].Value = elementsByTagName[num].ChildNodes.Item(8).InnerText.Trim();
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
                for (int i = 0; i < DGVBonus.RowCount; i++)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    if (Convert.ToString(DGVBonus.Rows[i].Cells["bcode"].Value) != "")
                    {
                        code = Convert.ToString(DGVBonus.Rows[i].Cells["bcode"].Value);
                        ratio = Convert.ToString(DGVBonus.Rows[i].Cells["bratio"].Value);
                        cum_bonus_dt = Convert.ToString(DGVBonus.Rows[i].Cells["bcum_bonus_dt"].Value);
                        ex_bonus_dt = Convert.ToString(DGVBonus.Rows[i].Cells["bex_bonus_dt"].Value);
                        recording_dt = Convert.ToString(DGVBonus.Rows[i].Cells["brecording_dt"].Value);
                        distribution_dt = Convert.ToString(DGVBonus.Rows[i].Cells["bdistribution_dt"].Value);
                        created_date = Convert.ToString(DGVBonus.Rows[i].Cells["bcreated_date"].Value);
                        revised_date = Convert.ToString(DGVBonus.Rows[i].Cells["brevised_date"].Value);
                    }
                    string text = "('" + code + "','" + ratio + "','" + cum_bonus_dt + "','" + ex_bonus_dt + "','" + recording_dt + "','" + distribution_dt + "',";
                    string text2 = text;
                    text = text2 + "'" + created_date + "','" + revised_date + "')";
                    string str = text;
                    if (Check_Bonus("call sp_checkbonus('" + code + "','" + created_date + "')"))
                    {
                        str = MySQLEscape(str);
                        str = "call sp_update_bonus" + text;
                    }
                    else
                    {
                        str = MySQLEscape(str);
                        str = "call sp_insert_bonus (\"" + str + "\")";
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
                MessageBox.Show("Bonus Succesfully Updated");
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
            DGVBonus.Rows.Clear();
            txtFileName.Clear();
        }
    }
}
