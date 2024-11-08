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
using Newtonsoft.Json;
using System.Xml;

namespace CPCA
{
    public partial class FrmBonds : Form
    {
        private MySqlConnection AppConn = null;

        private MySqlTransaction MySqltr = null;

        private MySqlDataReader MySqlDr = null;

        private MySqlCommand MySqlCmd = null;

        private string code_bonds, name_bonds, emitent_code_bonds, date_maturity_bonds, ratings_bonds, created_date, revised_date, filename;

        private DataGridViewTextBoxColumn bcode, bname, bemitent_code, bdate_maturity, bratings, bcreated_date, brevised_date;

        public FrmBonds()
        {
            InitializeComponent();
            code_bonds = null;
            name_bonds = null;
            emitent_code_bonds = null;
            date_maturity_bonds = null;
            ratings_bonds = null;
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

        public bool Check_Bonds(string MysqlQry)
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

        private string EscapeXmlCharacters(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return input
                .Replace("&", "&amp;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;")
                .Replace("\"", "&quot;")
                .Replace("'", "&apos;");
        }
        //private void LoadList(string filename)
        //{
        //    try
        //    {
        //        XmlDataDocument xmlDataDocument = new XmlDataDocument();
        //        FileStream inStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
        //        xmlDataDocument.Load((Stream)inStream);
        //        XmlNodeList elementsByTagName = xmlDataDocument.GetElementsByTagName("record");
        //        this.DGVBond.Rows.Clear();
        //        for (int num = 0; num < elementsByTagName.Count; num++)
        //        {
        //            DGVBond.Rows.Add();
        //            // Safely retrieve each field, avoiding errors when data is missing
        //            var codeBonds = elementsByTagName[num].SelectSingleNode("code_bonds")?.InnerText ?? string.Empty;
        //            var nameBonds = elementsByTagName[num].SelectSingleNode("name_bonds")?.InnerText ?? string.Empty;
        //            var emitentCodeBonds = elementsByTagName[num].SelectSingleNode("emitent_code_bonds")?.InnerText ?? string.Empty;
        //            var dateMaturityBonds = elementsByTagName[num].SelectSingleNode("date_maturity_bonds")?.InnerText ?? string.Empty;
        //            var ratingsBonds = elementsByTagName[num].SelectSingleNode("ratings_bonds")?.InnerText ?? string.Empty;
        //            var createdDate = elementsByTagName[num].SelectSingleNode("created_date")?.InnerText ?? string.Empty;
        //            var revisedDate = elementsByTagName[num].SelectSingleNode("revised_date")?.InnerText ?? string.Empty;
        //            Encoding asciinameBond = Encoding.ASCII;
        //            Encoding unicodenameBond = Encoding.Unicode;

        //            byte[] unicodeBytes = unicodenameBond.GetBytes(nameBonds);
        //            byte[] asciiBytes = Encoding.Convert(asciinameBond, asciinameBond, unicodeBytes);
        //            char[] asciiChars = new char[asciinameBond.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
        //            asciinameBond.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
        //            string asciiString = new string(asciiChars);
        //            MessageBox.Show(asciiString);
        //            // Add data to DataGridView with escaped XML characters
        //            DGVBond.Rows[num].Cells["bcode"].Value = EscapeXmlCharacters(codeBonds);
        //            DGVBond.Rows[num].Cells["bname"].Value = EscapeXmlCharacters(nameBonds);
        //            DGVBond.Rows[num].Cells["bemitent_code"].Value = EscapeXmlCharacters(emitentCodeBonds);
        //            DGVBond.Rows[num].Cells["bdate_maturity"].Value = EscapeXmlCharacters(dateMaturityBonds);
        //            DGVBond.Rows[num].Cells["bratings"].Value = EscapeXmlCharacters(ratingsBonds);
        //            DGVBond.Rows[num].Cells["bcreated_date"].Value = EscapeXmlCharacters(createdDate);
        //            DGVBond.Rows[num].Cells["brevised_date"].Value = EscapeXmlCharacters(revisedDate);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        //    }
        //}

        private void LoadList(string filename)
        {
            try
            {
                XmlDataDocument xmlDataDocument = new XmlDataDocument();
                FileStream inStream = new FileStream(filename, FileMode.Open, FileAccess.Read);

                // Baca isi file sebagai string terlebih dahulu
                string xmlContent;
                using (StreamReader reader = new StreamReader(inStream))
                {
                    xmlContent = reader.ReadToEnd();
                }

                // Escape karakter khusus secara manual jika diperlukan
                xmlContent = xmlContent.Replace("&", "&amp;");

                // Load XML dari string yang sudah di-escape
                using (StringReader sReader = new StringReader(xmlContent))
                {
                    xmlDataDocument.Load(sReader);
                }

                XmlNodeList elementsByTagName = xmlDataDocument.GetElementsByTagName("record");
                this.DGVBond.Rows.Clear();
                for (int num = 0; num < elementsByTagName.Count; num++)
                {
                    DGVBond.Rows.Add();
                    // Safely retrieve each field, avoiding errors when data is missing
                    var codeBonds = elementsByTagName[num].SelectSingleNode("code_bonds")?.InnerText ?? string.Empty;
                    var nameBonds = elementsByTagName[num].SelectSingleNode("name_bonds")?.InnerText ?? string.Empty;
                    var emitentCodeBonds = elementsByTagName[num].SelectSingleNode("emitent_code_bonds")?.InnerText ?? string.Empty;
                    var dateMaturityBonds = elementsByTagName[num].SelectSingleNode("date_maturity_bonds")?.InnerText ?? string.Empty;
                    var ratingsBonds = elementsByTagName[num].SelectSingleNode("ratings_bonds")?.InnerText ?? string.Empty;
                    var createdDate = elementsByTagName[num].SelectSingleNode("created_date")?.InnerText ?? string.Empty;
                    var revisedDate = elementsByTagName[num].SelectSingleNode("revised_date")?.InnerText ?? string.Empty;

                    // Add data to DataGridView with escaped XML characters
                    DGVBond.Rows[num].Cells["bcode"].Value = EscapeXmlCharacters(codeBonds);
                    DGVBond.Rows[num].Cells["bname"].Value = EscapeXmlCharacters(nameBonds);
                    DGVBond.Rows[num].Cells["bemitent_code"].Value = EscapeXmlCharacters(emitentCodeBonds);
                    DGVBond.Rows[num].Cells["bdate_maturity"].Value = EscapeXmlCharacters(dateMaturityBonds);
                    DGVBond.Rows[num].Cells["bratings"].Value = EscapeXmlCharacters(ratingsBonds);
                    DGVBond.Rows[num].Cells["bcreated_date"].Value = EscapeXmlCharacters(createdDate);
                    DGVBond.Rows[num].Cells["brevised_date"].Value = EscapeXmlCharacters(revisedDate);
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

                for (int i = 0; i < DGVBond.RowCount; i++)
                {
                    if (Convert.ToString(DGVBond.Rows[i].Cells["bcode"].Value) != "")
                    {
                        code_bonds = MySQLEscape(Convert.ToString(DGVBond.Rows[i].Cells["bcode"].Value));
                        name_bonds = MySQLEscape(Convert.ToString(DGVBond.Rows[i].Cells["bname"].Value));
                        emitent_code_bonds = MySQLEscape(Convert.ToString(DGVBond.Rows[i].Cells["bemitent_code"].Value));
                        date_maturity_bonds = MySQLEscape(Convert.ToString(DGVBond.Rows[i].Cells["bdate_maturity"].Value));
                        ratings_bonds = MySQLEscape(Convert.ToString(DGVBond.Rows[i].Cells["bratings"].Value));
                        created_date = MySQLEscape(Convert.ToString(DGVBond.Rows[i].Cells["bcreated_date"].Value));
                        revised_date = MySQLEscape(Convert.ToString(DGVBond.Rows[i].Cells["brevised_date"].Value));

                        string MySqlQry;
                        if (this.Check_Bonds($"call sp_checkbonds('{code_bonds}')"))
                        {
                            // Jika ada, update data bond
                            MySqlQry = $"call sp_update_bonds('{code_bonds}', '{name_bonds}', '{emitent_code_bonds}', '{date_maturity_bonds}', '{ratings_bonds}', '{created_date}', '{revised_date}')";
                        }
                        else
                        {
                            // Gabungkan query menjadi satu string, sesuai dengan prosedur yang menerima satu parameter
                            string insertQuery = $"('{code_bonds}', '{name_bonds}', '{emitent_code_bonds}', '{date_maturity_bonds}', '{ratings_bonds}', '{created_date}', '{revised_date}')";

                            // Panggil prosedur dengan satu parameter
                            MySqlQry = $"call sp_insert_bonds('{insertQuery}')";
                        }
                    }

                    this.CloseDatabase();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Informasi Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                MessageBox.Show("BONDS Successfully Updated");
            }
        }


        private static string MySQLEscape(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            return str.Replace("\\", "\\\\")  // Escape backslash
                      .Replace("'", "\\'");   // Escape single quote
        }

        private void toolStripClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripCancel_Click(object sender, EventArgs e)
        {
            DGVBond.Rows.Clear();
            txtFileName.Clear();
        }
    }
}
