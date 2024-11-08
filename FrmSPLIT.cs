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
    public partial class FrmSPLIT : Form
    {
        private MySqlConnection AppConn = null;

        private MySqlTransaction MySqltr = null;

        private MySqlDataReader MySqlDr = null;

        private MySqlCommand MySqlCmd = null;

        //private int rvers_id;

        private string split_code, split_prev_price, split_curr_price, split_ratio, split_hand_sks, split_new_sks, split_trd_dt, created_date, revised_date, filename;

        private DataGridViewTextBoxColumn scode, sprev_price, scurr_price, sratio, shand_sks, snew_sks, strd_dt, screated_date, srevised_date;


        public FrmSPLIT()
        {
            InitializeComponent();
            //rvers_id = null;
            split_code = null;
            split_prev_price = null;
            split_curr_price = null;
            split_ratio = null;
            split_hand_sks = null;
            split_new_sks = null;
            split_trd_dt = null;
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

        public bool Check_Split(string MysqlQry)
        {
            bool flag = false;
            try
            {
                this.MySqlCmd = new MySqlCommand(MysqlQry, this.AppConn);
                this.MySqlCmd.CommandText = MysqlQry;
                this.MySqlCmd.CommandTimeout = 90;
                this.MySqlDr = this.MySqlCmd.ExecuteReader();
                if (this.MySqlDr.Read())
                    flag = true;
                this.MySqlDr.Close();
                this.MySqlDr.Dispose();
                this.MySqlCmd.Dispose();
                MysqlQry = (string)null;
            }
            catch
            {
            }
            return flag;
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
                DGVSPLIT.Rows.Clear();
                for (num = 0; num <= elementsByTagName.Count - 1; num++)
                {
                    DGVSPLIT.Rows.Add();
                    //DGVSPLIT.Rows[num].Cells["kid"].Value = elementsByTagName[num].ChildNodes.Item(1).InnerText.Trim();
                    DGVSPLIT.Rows[num].Cells["scode"].Value = elementsByTagName[num].ChildNodes.Item(1).InnerText.Trim();
                    DGVSPLIT.Rows[num].Cells["sprev_price"].Value = elementsByTagName[num].ChildNodes.Item(2).InnerText.Trim();
                    DGVSPLIT.Rows[num].Cells["scurr_price"].Value = elementsByTagName[num].ChildNodes.Item(3).InnerText.Trim();
                    DGVSPLIT.Rows[num].Cells["sratio"].Value = elementsByTagName[num].ChildNodes.Item(4).InnerText.Trim();
                    DGVSPLIT.Rows[num].Cells["shand_sks"].Value = elementsByTagName[num].ChildNodes.Item(5).InnerText.Trim();
                    DGVSPLIT.Rows[num].Cells["snew_sks"].Value = elementsByTagName[num].ChildNodes.Item(6).InnerText.Trim();
                    DGVSPLIT.Rows[num].Cells["strd_dt"].Value = elementsByTagName[num].ChildNodes.Item(7).InnerText.Trim();
                    DGVSPLIT.Rows[num].Cells["screated_date"].Value = elementsByTagName[num].ChildNodes.Item(8).InnerText.Trim();
                    DGVSPLIT.Rows[num].Cells["srevised_date"].Value = elementsByTagName[num].ChildNodes.Item(9).InnerText.Trim();
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
                for (int i = 0; i < DGVSPLIT.RowCount; i++)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    if (Convert.ToString(DGVSPLIT.Rows[i].Cells["scode"].Value) != "")
                    {
                        //rvers_id = Convert.ToString(DGVSPLIT.Rows[i].Cells["kid"].Value);
                        split_code = Convert.ToString(DGVSPLIT.Rows[i].Cells["scode"].Value);
                        split_prev_price = Convert.ToString(DGVSPLIT.Rows[i].Cells["sprev_price"].Value);
                        split_curr_price = Convert.ToString(DGVSPLIT.Rows[i].Cells["scurr_price"].Value);
                        split_ratio = Convert.ToString(DGVSPLIT.Rows[i].Cells["sratio"].Value);
                        split_hand_sks = Convert.ToString(DGVSPLIT.Rows[i].Cells["shand_sks"].Value);
                        split_new_sks = Convert.ToString(DGVSPLIT.Rows[i].Cells["snew_sks"].Value);
                        split_trd_dt = Convert.ToString(DGVSPLIT.Rows[i].Cells["strd_dt"].Value);
                        created_date = Convert.ToString(DGVSPLIT.Rows[i].Cells["screated_date"].Value);
                        revised_date = Convert.ToString(DGVSPLIT.Rows[i].Cells["srevised_date"].Value);
                    }
                    string str1 = "('" + this.split_code + "','" + this.split_prev_price + "','" + this.split_curr_price + "','" + this.split_ratio + "','" + this.split_hand_sks + "','" + this.split_new_sks + "'," + "'" + this.split_trd_dt + "','" + this.created_date + "','" + this.revised_date + "')";
                    string str2 = str1;
                    string MySqlQry;
                    if (this.Check_Split("call sp_checksplit('" + this.split_code + "','" + this.created_date + "')"))
                    {
                        FrmSPLIT.MySQLEscape(str2);
                        MySqlQry = "call sp_update_split" + str1;
                    }
                    else
                        MySqlQry = "call sp_insert_split (\"" + FrmSPLIT.MySQLEscape(str2) + "\")";
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
                int num = (int)MessageBox.Show("SPLIT Succesfully Updated");
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
            DGVSPLIT.Rows.Clear();
            txtFileName.Clear();
        }
    }
}
