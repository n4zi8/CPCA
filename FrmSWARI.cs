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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace CPCA
{
    public partial class FrmSWARI : Form
    {
        private MySqlConnection AppConn = null;

        private MySqlTransaction MySqltr = null;

        private MySqlDataReader MySqlDr = null;

        private MySqlCommand MySqlCmd = null;

        
        private string ISIN_code;
        private string Issuer_name;
        private string Code_efek;
        private string Underlying_wrant;
        private string Ratio_Konversi;
        private string Name_waran;
        private string Dist_dt;
        private string trading_periode;
        private string Type_wrant;
        private string Exercise_price;
        private string Due_dt;
        private string total_wrant;
        private string created_date;
        private string revised_date;
        private string filename;

        private DataGridViewTextBoxColumn swisin_code;
        private DataGridViewTextBoxColumn swissuer_name;
        private DataGridViewTextBoxColumn swcode_efek;
        private DataGridViewTextBoxColumn swunderlying_wrant;
        private DataGridViewTextBoxColumn swratio_konversi;
        private DataGridViewTextBoxColumn swname_waran;
        private DataGridViewTextBoxColumn swdist_dt;
        private DataGridViewTextBoxColumn swtrading_periode;
        private DataGridViewTextBoxColumn swtype_wrant;
        private DataGridViewTextBoxColumn swexercise_price;
        private DataGridViewTextBoxColumn swdue_dt;
        private DataGridViewTextBoxColumn swtotal_wrant;
        private DataGridViewTextBoxColumn swcreated_date;
        private DataGridViewTextBoxColumn swrevised_date;

        public FrmSWARI()
        {
            InitializeComponent();
            
          
            ISIN_code = null;
            Issuer_name = null;
            Code_efek = null;
            Underlying_wrant = null;
            Ratio_Konversi = null;
            Name_waran = null;
            Dist_dt = null;
            trading_periode = null;
            Type_wrant = null;
            Exercise_price = null;
            Due_dt = null;
            total_wrant = null;
            created_date = null;
            revised_date = null;
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
                DGVSWARI.Rows.Clear();
                for (num = 0; num <= elementsByTagName.Count - 1; num++)
                {
                    DGVSWARI.Rows.Add();
                    DGVSWARI.Rows[num].Cells["swisin_code"].Value = elementsByTagName[num].ChildNodes.Item(1).InnerText.Trim();
                    DGVSWARI.Rows[num].Cells["swissuer_name"].Value = elementsByTagName[num].ChildNodes.Item(2).InnerText.Trim();
                    DGVSWARI.Rows[num].Cells["swcode_efek"].Value = elementsByTagName[num].ChildNodes.Item(3).InnerText.Trim();
                    DGVSWARI.Rows[num].Cells["swunderlying_wrant"].Value = elementsByTagName[num].ChildNodes.Item(4).InnerText.Trim();
                    DGVSWARI.Rows[num].Cells["swratio_konversi"].Value = elementsByTagName[num].ChildNodes.Item(5).InnerText.Trim();
                    DGVSWARI.Rows[num].Cells["swname_waran"].Value = elementsByTagName[num].ChildNodes.Item(6).InnerText.Trim();
                    DGVSWARI.Rows[num].Cells["swdist_dt"].Value = elementsByTagName[num].ChildNodes.Item(7).InnerText.Trim();
                    DGVSWARI.Rows[num].Cells["swtrading_periode"].Value = elementsByTagName[num].ChildNodes.Item(8).InnerText.Trim();
                    DGVSWARI.Rows[num].Cells["swtype_wrant"].Value = elementsByTagName[num].ChildNodes.Item(9).InnerText.Trim();
                    DGVSWARI.Rows[num].Cells["swexercise_price"].Value = elementsByTagName[num].ChildNodes.Item(10).InnerText.Trim();
                    DGVSWARI.Rows[num].Cells["swdue_dt"].Value = elementsByTagName[num].ChildNodes.Item(11).InnerText.Trim();
                    DGVSWARI.Rows[num].Cells["swtotal_wrant"].Value = elementsByTagName[num].ChildNodes.Item(12).InnerText.Trim();
                    DGVSWARI.Rows[num].Cells["swcreated_date"].Value = elementsByTagName[num].ChildNodes.Item(13).InnerText.Trim();
                    DGVSWARI.Rows[num].Cells["swrevised_date"].Value = elementsByTagName[num].ChildNodes.Item(14).InnerText.Trim();
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
                for (int i = 0; i < DGVSWARI.RowCount; i++)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    if (Convert.ToString(DGVSWARI.Rows[i].Cells["swisin_code"].Value) != "")
                    {
                        ISIN_code = Convert.ToString(DGVSWARI.Rows[i].Cells["swisin_code"].Value);
                        Issuer_name = Convert.ToString(DGVSWARI.Rows[i].Cells["swissuer_name"].Value);
                        Code_efek = Convert.ToString(DGVSWARI.Rows[i].Cells["swcode_efek"].Value);
                        Underlying_wrant = Convert.ToString(DGVSWARI.Rows[i].Cells["swunderlying_wrant"].Value);
                        Ratio_Konversi = Convert.ToString(DGVSWARI.Rows[i].Cells["swratio_konversi"].Value);
                        Name_waran = Convert.ToString(DGVSWARI.Rows[i].Cells["swname_waran"].Value);
                        Dist_dt = Convert.ToString(DGVSWARI.Rows[i].Cells["swdist_dt"].Value);
                        trading_periode = Convert.ToString(DGVSWARI.Rows[i].Cells["swtrading_periode"].Value);
                        Type_wrant = Convert.ToString(DGVSWARI.Rows[i].Cells["swtype_wrant"].Value);
                        Exercise_price = Convert.ToString(DGVSWARI.Rows[i].Cells["swexercise_price"].Value);
                        Due_dt = Convert.ToString(DGVSWARI.Rows[i].Cells["swdue_dt"].Value);
                        total_wrant = Convert.ToString(DGVSWARI.Rows[i].Cells["swtotal_wrant"].Value);
                        created_date = Convert.ToString(DGVSWARI.Rows[i].Cells["swcreated_date"].Value);
                        revised_date = Convert.ToString(DGVSWARI.Rows[i].Cells["swrevised_date"].Value);
                    }
                    string str1 = "('" + ISIN_code + "','" + Issuer_name + "','" + Code_efek + "','" + Underlying_wrant + "','" + Ratio_Konversi + "','" + Name_waran + "','" + Dist_dt + "','" + trading_periode + "','" + Type_wrant + "','" + Exercise_price + "','" + Due_dt + "','" + total_wrant + "','" + created_date + "','" + revised_date + "')";
                    string str2 = str1;
                    string MySqlQry;
                    if (Check_Right("call sp_checkswari('" + ISIN_code + "','" + created_date + "')"))
                    {
                        FrmSWARI.MySQLEscape(str2);
                        MySqlQry = "call sp_update_swari" + str1;
                    }
                    else
                        MySqlQry = "call sp_insert_swari (\"" + FrmSWARI.MySQLEscape(str2) + "\")";
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
                int num = (int)MessageBox.Show("SWARI Succesfully Updated");
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
            DGVSWARI.Rows.Clear();
            txtFileName.Clear();
        }
    }
}
