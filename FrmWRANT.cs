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
    public partial class FrmWRANT : Form
    {
        private MySqlConnection AppConn = null;

        private MySqlTransaction MySqltr = null;

        private MySqlDataReader MySqlDr = null;

        private MySqlCommand MySqlCmd = null;

        //private int rvers_id;

        private string wrant_code, wrant_serie, wrant_exc_price, wrant_trading_period, wrant_exc_period, wrant_total, created_date, revised_date, filename;

        private DataGridViewTextBoxColumn wcode, wserie, wexc_price, wtrading_period, wexc_period, wtotal, wcreated_date, wrevised_date;


        public FrmWRANT()
        {
            InitializeComponent();
            //rvers_id = null;
            wrant_code = null;
            wrant_serie = null;
            wrant_exc_price = null;
            wrant_trading_period = null;
            wrant_exc_period = null;
            wrant_total = null;
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

        public bool Check_Wrant(string MysqlQry)
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
                DGVWRANT.Rows.Clear();
                for (num = 0; num <= elementsByTagName.Count - 1; num++)
                {
                    DGVWRANT.Rows.Add();
                    //DGVWRANT.Rows[num].Cells["kid"].Value = elementsByTagName[num].ChildNodes.Item(1).InnerText.Trim();
                    DGVWRANT.Rows[num].Cells["wcode"].Value = elementsByTagName[num].ChildNodes.Item(1).InnerText.Trim();
                    DGVWRANT.Rows[num].Cells["wserie"].Value = elementsByTagName[num].ChildNodes.Item(2).InnerText.Trim();
                    DGVWRANT.Rows[num].Cells["wexc_price"].Value = elementsByTagName[num].ChildNodes.Item(3).InnerText.Trim();
                    DGVWRANT.Rows[num].Cells["wtrading_period"].Value = elementsByTagName[num].ChildNodes.Item(4).InnerText.Trim();
                    DGVWRANT.Rows[num].Cells["wexc_period"].Value = elementsByTagName[num].ChildNodes.Item(5).InnerText.Trim();
                    DGVWRANT.Rows[num].Cells["wtotal"].Value = elementsByTagName[num].ChildNodes.Item(6).InnerText.Trim();
                    DGVWRANT.Rows[num].Cells["wcreated_date"].Value = elementsByTagName[num].ChildNodes.Item(7).InnerText.Trim();
                    DGVWRANT.Rows[num].Cells["wrevised_date"].Value = elementsByTagName[num].ChildNodes.Item(8).InnerText.Trim();
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
                for (int i = 0; i < DGVWRANT.RowCount; i++)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    if (Convert.ToString(DGVWRANT.Rows[i].Cells["wcode"].Value) != "")
                    {
                        //rvers_id = Convert.ToString(DGVWRANT.Rows[i].Cells["kid"].Value);
                        wrant_code = Convert.ToString(DGVWRANT.Rows[i].Cells["wcode"].Value);
                        wrant_serie = Convert.ToString(DGVWRANT.Rows[i].Cells["wserie"].Value);
                        wrant_exc_price = Convert.ToString(DGVWRANT.Rows[i].Cells["wexc_price"].Value);
                        wrant_trading_period = Convert.ToString(DGVWRANT.Rows[i].Cells["wtrading_period"].Value);
                        wrant_exc_period = Convert.ToString(DGVWRANT.Rows[i].Cells["wexc_period"].Value);
                        wrant_total = Convert.ToString(DGVWRANT.Rows[i].Cells["wtotal"].Value);
                        created_date = Convert.ToString(DGVWRANT.Rows[i].Cells["wcreated_date"].Value);
                        revised_date = Convert.ToString(DGVWRANT.Rows[i].Cells["wrevised_date"].Value);
                    }
                    string str1 = "('" + this.wrant_code + "','" + this.wrant_serie + "','" + this.wrant_exc_price + "','" + this.wrant_trading_period + "','" + this.wrant_exc_period + "','" + this.wrant_total + "'," + "'" + this.created_date + "','" + this.revised_date + "')";
                    string str2 = str1;
                    string MySqlQry;
                    if (this.Check_Wrant("call sp_checkwrant('" + this.wrant_code + "')"))
                    {
                        FrmWRANT.MySQLEscape(str2);
                        MySqlQry = "call sp_update_wrant" + str1;
                    }
                    else
                        MySqlQry = "call sp_insert_wrant (\"" + FrmWRANT.MySQLEscape(str2) + "\")";
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
                int num = (int)MessageBox.Show("WRANT Succesfully Updated");
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
            DGVWRANT.Rows.Clear();
            txtFileName.Clear();
        }
    }
}
