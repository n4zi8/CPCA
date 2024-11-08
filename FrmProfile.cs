using MySql.Data.MySqlClient;
using HtmlAgilityPack;
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
using Newtonsoft.Json;
using System.IO;


namespace CPCA
{
    public partial class FrmProfile : Form
    {
        private MySqlConnection AppConn = null;

        private MySqlTransaction MySqltr = null;

        private MySqlDataReader MySqlDr = null;

        private MySqlCommand MySqlCmd = null;

        private string code, title, address, background, product, affiliation, commissioners, directors, underwriter, registrar, holders, stocks, infos, created, revised, filename;

        private DataGridViewTextBoxColumn cp_code, cp_title, cp_address, cp_background, cp_product, cp_affiliation, cp_commissioners, cp_directors, cp_underwriter, cp_registrar, cp_holders, cp_stocks, cp_infos, cp_created, cp_revised;

        public FrmProfile()
        {
            InitializeComponent();
            code = null;
            title = null;
            address = null;
            background = null;
            product = null;
            affiliation = null;
            commissioners = null;
            directors = null;
            underwriter = null;
            registrar = null;
            holders = null;
            stocks = null;
            infos = null;
            created = null;
            revised = null;
            filename = null;
        }

        private MySqlConnection OpenDatabase()
        {
            string connectionString = "data source=10.1.4.204;    database=cpca_new_dev;user id=cpcauser;password=cpc4u53r;Convert Zero Datetime=true;Pooling=false";
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

        public bool Check_profile(string MysqlQry)
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
                //FileStream inStream = new FileStream(filename, FileMode.Open, FileAccess.Read);

                //xmlDataDocument.Load(inStream);
                using (FileStream inStream = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    // Specify the correct encoding if necessary (e.g., UTF-8)
                    using (StreamReader reader = new StreamReader(inStream, Encoding.UTF8))
                    {
                        xmlDataDocument.Load(reader);
                    }
                }

                XmlNodeList elementsByTagName = xmlDataDocument.GetElementsByTagName("record");
                Form1 f = new Form1();
        
                DGVProfile.Rows.Clear();
                for (num = 0; num <= elementsByTagName.Count - 1; num++)
                {
                    DGVProfile.Rows.Add();
                    DGVProfile.Rows[num].Cells["cp_code"].Value = elementsByTagName[num].ChildNodes.Item(0).InnerText.Trim();
                    DGVProfile.Rows[num].Cells["cp_title"].Value = elementsByTagName[num].ChildNodes.Item(1).InnerText.Trim();
                    DGVProfile.Rows[num].Cells["cp_address"].Value = elementsByTagName[num].ChildNodes.Item(2).InnerText.Trim();
                    DGVProfile.Rows[num].Cells["cp_background"].Value = elementsByTagName[num].ChildNodes.Item(3).InnerText.Trim();
                    DGVProfile.Rows[num].Cells["cp_product"].Value = elementsByTagName[num].ChildNodes.Item(4).InnerText.Trim();
                    DGVProfile.Rows[num].Cells["cp_affiliation"].Value = elementsByTagName[num].ChildNodes.Item(5).InnerText.Trim();
                    DGVProfile.Rows[num].Cells["cp_commissioners"].Value = elementsByTagName[num].ChildNodes.Item(6).InnerText.Trim();
                    DGVProfile.Rows[num].Cells["cp_directors"].Value = elementsByTagName[num].ChildNodes.Item(7).InnerText.Trim();
                    DGVProfile.Rows[num].Cells["cp_underwriter"].Value = elementsByTagName[num].ChildNodes.Item(8).InnerText.Trim();
                    DGVProfile.Rows[num].Cells["cp_registrar"].Value = elementsByTagName[num].ChildNodes.Item(9).InnerText.Trim();
                    DGVProfile.Rows[num].Cells["cp_holders"].Value = elementsByTagName[num].ChildNodes.Item(10).InnerText.Trim();
                    DGVProfile.Rows[num].Cells["cp_stocks"].Value = elementsByTagName[num].ChildNodes.Item(11).InnerText.Trim();
                    DGVProfile.Rows[num].Cells["cp_infos"].Value = elementsByTagName[num].ChildNodes.Item(12).InnerText.Trim();
                    DGVProfile.Rows[num].Cells["cp_created"].Value = elementsByTagName[num].ChildNodes.Item(13).InnerText.Trim();
                    DGVProfile.Rows[num].Cells["cp_revised"].Value = elementsByTagName[num].ChildNodes.Item(14).InnerText.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        /*
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

                DGVProfile.Rows.Clear();
                for (int num = 0; num < elementsByTagName.Count; num++)
                {
                    DGVProfile.Rows.Add();

                    // Ambil setiap elemen data, gunakan null-coalescing untuk mencegah error jika elemen tidak ditemukan
                    code = elementsByTagName[num].SelectSingleNode("cp_code")?.InnerText.Trim() ?? string.Empty;
                    title = elementsByTagName[num].SelectSingleNode("cp_title")?.InnerText.Trim() ?? string.Empty;
                    address = elementsByTagName[num].SelectSingleNode("cp_address")?.InnerText.Trim() ?? string.Empty;
                    background = elementsByTagName[num].SelectSingleNode("cp_background")?.InnerText.Trim() ?? string.Empty;
                    product = elementsByTagName[num].SelectSingleNode("cp_product")?.InnerText.Trim() ?? string.Empty;
                    affiliation = elementsByTagName[num].SelectSingleNode("cp_affiliation")?.InnerText.Trim() ?? string.Empty;
                    commissioners = elementsByTagName[num].SelectSingleNode("cp_commissioners")?.InnerText.Trim() ?? string.Empty;
                    directors = elementsByTagName[num].SelectSingleNode("cp_directors")?.InnerText.Trim() ?? string.Empty;
                    underwriter = elementsByTagName[num].SelectSingleNode("cp_underwriter")?.InnerText.Trim() ?? string.Empty;
                    registrar = elementsByTagName[num].SelectSingleNode("cp_registrar")?.InnerText.Trim() ?? string.Empty;
                    holders = elementsByTagName[num].SelectSingleNode("cp_holders")?.InnerText.Trim() ?? string.Empty;
                    stocks = elementsByTagName[num].SelectSingleNode("cp_stocks")?.InnerText.Trim() ?? string.Empty;
                    infos = elementsByTagName[num].SelectSingleNode("cp_infos")?.InnerText.Trim() ?? string.Empty;
                    created = elementsByTagName[num].SelectSingleNode("cp_created")?.InnerText.Trim() ?? string.Empty;
                    revised = elementsByTagName[num].SelectSingleNode("cp_revised")?.InnerText.Trim() ?? string.Empty;

                    // Mengisi DataGridView dengan data yang sudah diambil dan di-escape
                    DGVProfile.Rows[num].Cells["cp_code"].Value = EscapeXmlCharacters(code);
                    DGVProfile.Rows[num].Cells["cp_title"].Value = EscapeXmlCharacters(title);
                    DGVProfile.Rows[num].Cells["cp_address"].Value = EscapeXmlCharacters(address);
                    DGVProfile.Rows[num].Cells["cp_background"].Value = EscapeXmlCharacters(background);
                    DGVProfile.Rows[num].Cells["cp_product"].Value = EscapeXmlCharacters(product);
                    DGVProfile.Rows[num].Cells["cp_affiliation"].Value = EscapeXmlCharacters(affiliation);
                    DGVProfile.Rows[num].Cells["cp_commissioners"].Value = EscapeXmlCharacters(commissioners);
                    DGVProfile.Rows[num].Cells["cp_directors"].Value = EscapeXmlCharacters(directors);
                    DGVProfile.Rows[num].Cells["cp_underwriter"].Value = EscapeXmlCharacters(underwriter);
                    DGVProfile.Rows[num].Cells["cp_registrar"].Value = EscapeXmlCharacters(registrar);
                    DGVProfile.Rows[num].Cells["cp_holders"].Value = EscapeXmlCharacters(holders);
                    DGVProfile.Rows[num].Cells["cp_stocks"].Value = EscapeXmlCharacters(stocks);
                    DGVProfile.Rows[num].Cells["cp_infos"].Value = EscapeXmlCharacters(infos);
                    DGVProfile.Rows[num].Cells["cp_created"].Value = EscapeXmlCharacters(created);
                    DGVProfile.Rows[num].Cells["cp_revised"].Value = EscapeXmlCharacters(revised);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        */
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

        //static string BeautifyJson(string jsonString)
        //{
        //    try
        //    {
        //        // Mengubah string JSON menjadi objek
        //        var jsonObj = JsonConvert.DeserializeObject(jsonString);

        //        // Mengubah objek kembali menjadi string JSON dengan format indented (beautified)
        //        string beautifiedJson = JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);

        //        return beautifiedJson;
        //    }
        //    catch (Exception ex)
        //    {
        //        return $"Error: {ex.Message}";
        //    }
        //}

        //private void toolStripSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        OpenDatabase();
        //        filename = txtFileName.Text;
        //        string[] array = filename.Split('\\');
        //        filename = array[array.Length - 1];
        //        for (int i = 0; i < DGVProfile.RowCount; i++)
        //        {
        //            if (Convert.ToString(DGVProfile.Rows[i].Cells["cp_code"].Value) != "")
        //            {
        //                code = Convert.ToString(DGVProfile.Rows[i].Cells["cp_code"].Value);
        //                title = Convert.ToString(DGVProfile.Rows[i].Cells["cp_title"].Value);
        //                address = MySQLEscape(Convert.ToString(DGVProfile.Rows[i].Cells["cp_address"].Value) ?? string.Empty);
        //                address = address?.Replace("\"", "'") ?? string.Empty;
        //                background = Convert.ToString(DGVProfile.Rows[i].Cells["cp_product"].Value);
        //                background = MySQLEscape(background ?? string.Empty);
        //                product = Convert.ToString(DGVProfile.Rows[i].Cells["cp_product"].Value);
        //                product = MySQLEscape(product ?? string.Empty);
        //                affiliation = Convert.ToString(DGVProfile.Rows[i].Cells["cp_affiliation"].Value);
        //                affiliation = MySQLEscape(affiliation ?? string.Empty);
        //                commissioners = Convert.ToString(DGVProfile.Rows[i].Cells["cp_commissioners"].Value);
        //                commissioners = MySQLEscape(commissioners ?? string.Empty);
        //                directors = Convert.ToString(DGVProfile.Rows[i].Cells["cp_directors"].Value);
        //                directors = MySQLEscape(directors ?? string.Empty);
        //                underwriter = Convert.ToString(DGVProfile.Rows[i].Cells["cp_underwriter"].Value);
        //                underwriter = MySQLEscape(underwriter ?? string.Empty);
        //                registrar = Convert.ToString(DGVProfile.Rows[i].Cells["cp_registrar"].Value);
        //                registrar = MySQLEscape(registrar ?? string.Empty);
        //                holders = Convert.ToString(DGVProfile.Rows[i].Cells["cp_holders"].Value);
        //                holders = MySQLEscape(holders ?? string.Empty);
        //                stocks = Convert.ToString(DGVProfile.Rows[i].Cells["cp_stocks"].Value);
        //                stocks = MySQLEscape(stocks ?? string.Empty);
        //                stocks = stocks?.Replace("\"", "'") ?? string.Empty;
        //                infos = Convert.ToString(DGVProfile.Rows[i].Cells["cp_infos"].Value);
        //                infos = MySQLEscape(infos ?? string.Empty);
        //                created = Convert.ToString(DGVProfile.Rows[i].Cells["cp_created"].Value);
        //                revised = Convert.ToString(DGVProfile.Rows[i].Cells["cp_revised"].Value);
        //            }
        //            string str1 = "('" + this.code + "','" + this.title + "','" + this.address + "','" + this.background + "','" + this.product + "','" + this.affiliation + "','" + this.commissioners + "'," + "'" + this.directors + "','" + this.underwriter + "','" + this.registrar + "','" + this.holders + "','" + this.stocks + "','" + this.infos + "','" + this.created + "','" + this.revised + "'," + "'" + this.filename + "')";
        //            string jsonstring = "{" +
        //                                    "\"code\":\"" + code + "\"," +
        //                                    "\"title\":\"" + title + "\"," +
        //                                    "\"address\":\"" + address + "\"," +
        //                                    "\"background\":\"" + background + "\"," +
        //                                    "\"product\":\"" + product + "\"," +
        //                                    "\"affiliation\":\"" + affiliation + "\"," +
        //                                    "\"commissioners\":\"" + commissioners + "\"," +
        //                                    "\"directors\":\"" + directors + "\"," +
        //                                    "\"underwriter\":\"" + underwriter + "\"," +
        //                                    "\"registrar\":\"" + registrar + "\"," +
        //                                    "\"holders\":\"" + holders + "\"," +
        //                                    "\"stocks\":\"" + stocks + "\"," +
        //                                    "\"infos\":\"" + infos + "\"," +
        //                                    "\"created\":\"" + created + "\"," +
        //                                    "\"revised\":\"" + revised + "\"," +
        //                                    "\"filename\":\"" + filename + "\"" +
        //                                "}";
        //            //string jsonstring2 = "{" + "\"code\":\"" + code + "\"," + "\"title\":\"" + title + "\"," + "\"address\":\"" + address + "\"" + "}";
        //            string beautifiedJson = BeautifyJson(jsonstring);
        //            //this.PrepareSingle(
        //            //!this.Check_profile("call sp_checkprofile('" + this.code + "')") ? "call sp_insert_profile (\"" + str1 + "\")" : "call sp_updateprofile" + str1 );
        //            bool profileExists = this.Check_profile("call sp_checkprofile('" + this.code + "')");

        //            if (!profileExists)
        //            {
        //                //MessageBox.Show("insert file");
        //                // Jika profil tidak ada, gunakan stored procedure 'sp_insert_profile'
        //                this.PrepareSingle("call sp_insert_profile (\"" + str1 + "\")");
        //            }
        //            else
        //            {
        //                //MessageBox.Show("update file");
        //                // Jika profil ada, gunakan stored procedure 'sp_updateprofile'
        //                this.PrepareSingle("call sp_updateprofile (\"" + str1 + "\")");
        //            }
        //            MessageBox.Show(beautifiedJson);
        //        }
        //        CloseDatabase();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Informasi Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        //    }
        //    finally
        //    {
        //        MessageBox.Show("Profile Succesfully Updated");
        //    }
        //}
        private void toolStripSave_Click(object sender, EventArgs e)
        {
            try
            {
                OpenDatabase();
                filename = txtFileName.Text.Split('\\').Last();

                for (int i = 0; i < DGVProfile.RowCount; i++)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(DGVProfile.Rows[i].Cells["cp_code"].Value)))
                    {
                        // Ambil nilai dari DataGridView dan escape untuk mencegah SQL injection
                         code = MySQLEscape(Convert.ToString(DGVProfile.Rows[i].Cells["cp_code"].Value));
                         title = MySQLEscape(Convert.ToString(DGVProfile.Rows[i].Cells["cp_title"].Value));
                         address = MySQLEscape(Convert.ToString(DGVProfile.Rows[i].Cells["cp_address"].Value));
                         background = MySQLEscape(Convert.ToString(DGVProfile.Rows[i].Cells["cp_background"].Value));
                         product = MySQLEscape(Convert.ToString(DGVProfile.Rows[i].Cells["cp_product"].Value));
                         affiliation = MySQLEscape(Convert.ToString(DGVProfile.Rows[i].Cells["cp_affiliation"].Value));
                         commissioners = MySQLEscape(Convert.ToString(DGVProfile.Rows[i].Cells["cp_commissioners"].Value));
                         directors = MySQLEscape(Convert.ToString(DGVProfile.Rows[i].Cells["cp_directors"].Value));
                         underwriter = MySQLEscape(Convert.ToString(DGVProfile.Rows[i].Cells["cp_underwriter"].Value));
                         registrar = MySQLEscape(Convert.ToString(DGVProfile.Rows[i].Cells["cp_registrar"].Value));
                         holders = MySQLEscape(Convert.ToString(DGVProfile.Rows[i].Cells["cp_holders"].Value));
                         stocks = MySQLEscape(Convert.ToString(DGVProfile.Rows[i].Cells["cp_stocks"].Value));
                         infos = MySQLEscape(Convert.ToString(DGVProfile.Rows[i].Cells["cp_infos"].Value));
                         created = MySQLEscape(Convert.ToString(DGVProfile.Rows[i].Cells["cp_created"].Value));
                         revised = MySQLEscape(Convert.ToString(DGVProfile.Rows[i].Cells["cp_revised"].Value));

                        // Siapkan query MySQL sesuai apakah profil sudah ada atau belum
                        string MySqlQry;
                        if (this.Check_profile($"call sp_checkprofile('{code}')"))
                        {
                            // Update jika profil sudah ada
                            MySqlQry = $"call sp_updateprofile('{code}', '{title}', '{address}', '{background}', '{product}', '{affiliation}', '{commissioners}', '{directors}', '{underwriter}', '{registrar}', '{holders}', '{stocks}', '{infos}', '{created}', '{revised}', '{filename}')";
                        }
                        else
                        {
                            // Insert jika profil belum ada                            
                            MySqlQry = $"call sp_insert_profile3('{code}', '{title}', '{address}', '{background}', '{product}', '{affiliation}', '{commissioners}', '{directors}', '{underwriter}', '{registrar}', '{holders}', '{stocks}', '{infos}', '{created}', '{revised}', '{filename}')";
                        }

                        // Eksekusi query MySQL
                        this.PrepareSingle(MySqlQry);
                    }
                }
                MessageBox.Show("Profile Successfully Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseDatabase();
            }
        }


        private static string MySQLEscape(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            // Replace MySQL-specific and HTML characters
            return Regex.Replace(str, "[\\x00'\"\\b\\n\\r\\t\\cZ\\\\&<>]", match =>
            {
                return match.Value switch
                {
                    "\0" => "\\0",
                    "\b" => "\\b",
                    "\n" => "\\n",
                    "\r" => "\\r",
                    "\t" => "\\t",
                    "\u001a" => "\\Z",
                    "\\" => "\\\\",
                    "'" => "\\'",
                    "\"" => "\\\"",
                    "&" => "&amp;",
                    "<" => "&lt;",
                    ">" => "&gt;",
                    "%" => "\\%",
                    "_" => "\\_",
                    _ => "\\" + match.Value
                };
            });
        }

        private string GetPlainTextFromHtml(string htmlContent)
        {
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(htmlContent);
            return htmlDoc.DocumentNode.InnerText.Trim(); // Extract plain text, removing HTML tags
        }

        private string BuildProfileJson(string code, string title, string address, string background, string product,
                                string affiliation, string commissioners, string directors, string underwriter,
                                string registrar, string holders, string stocks, string infos, string created,
                                string revised, string filename)
        {
            var profile = new
            {
                code,
                title,
                address,
                background,
                product,
                affiliation,
                commissioners,
                directors,
                underwriter,
                registrar,
                holders,
                stocks,
                infos,
                created,
                revised,
                filename
            };

            // Convert the object to a JSON string
            return JsonConvert.SerializeObject(profile);
        }
        private void toolStripClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripCancel_Click(object sender, EventArgs e)
        {
            DGVProfile.Rows.Clear();
            txtFileName.Clear();
        }
    }
}
