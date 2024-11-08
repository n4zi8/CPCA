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
    public partial class FrmFinance : Form
    {
        private MySqlConnection AppConn = null;

        private MySqlTransaction MySqltr = null;

        private MySqlDataReader MySqlDr = null;

        private MySqlCommand MySqlCmd = null;

        private string code, dtFinSt, cFiscYear, tstamp, filename;
        private double nYear, nQrt, nMonthCover, nSumBalanceSheet, nParValueA, nParValueB, nReceivables, nInventories, nCurrAssets, nFixedAssets, nOtherAssets, nTotalAssets, nCurriabilities, nLTermLiabilities, nTotalLiabilities, nAuthorized, nPaidupCap, nPaidupCapShares, nParValueC, nParValueD, nSumIncomeStat, nRetainedEarn, nTotalEquity, nMinInterest, nTotalSales, nCostGoodSold, nGrossProfit, nOperatingProfit, nOtherIncome, nEarnBeforeTax, nTax, nNetIncome, nClosePrice, nPerShareDataRp, nFinRatios, nEps, nBookValue, nDebtEquityRatio, nRoaPct, nRoePct, nNpmPct, nOpmPct, nCashFlow, nCFOperateActs, nCFInvesActs, nCFFinActs, nNetIncrCashAndCashEq, nCashAndCashEqBeginYear, nCashAndCashEqEndYear, nUSDtoIDRRate, nCashAndCashEquivalents, nNonCurrentAssets, nGrossProfitMarginPct, nTotalAssetsTurnover, nReservedField6, nReservedField7, nReservedField8, nReservedField9, nReservedField10;
        private DataGridViewTextBoxColumn fcode, fnYear, fnQrt, fdtFinSt, fcFiscYear, fnMonthCover, fnSumBalanceSheet, fnReceivables, fnInventories, fnCurrAssets, fnFixedAssets, fnOtherAssets, fnTotalAssets, fnCurriabilities, fnLTermLiabilities, fnTotalLiabilities, fnAuthorized, fnPaidupCap, fnParValueA, fnParValueB, fnParValueC, fnParValueD, fnPaidupCapShares, fnRetainedEarn, fnTotalEquity, fnMinInterest, fnSumIncomeStat, fnTotalSales, fnCostGoodSold, fnGrossProfit, fnOperatingProfit, fnOtherIncome, fnEarnBeforeTax, fnTax, fnNetIncome, fnClosePrice, fnPerShareDataRp, fnEps, fnBookValue, fnFinRatios, fnDebtEquityRatio, fnRoaPct, fnRoePct, fnNpmPct, fnOpmPct, fnCashFlow, fnCFOperateActs, fnCFInvesActs, fnCFFinActs, fnNetIncrCashAndCashEq, fnCashAndCashEqBeginYear, fnCashAndCashEqEndYear, fnUSDtoIDRRate, fnCashAndCashEquivalents, fnNonCurrentAssets, fnGrossProfitMarginPct, fnTotalAssetsTurnover, fnReservedField6, fnReservedField7, fnReservedField8, fnReservedField9, fnReservedField10, ftstamp;
        
        public FrmFinance()
        {
            InitializeComponent();
            code = null;
            dtFinSt = null;
            cFiscYear = null;
            nYear = 0;
            nQrt = 0;
            nMonthCover = 0;
            nSumBalanceSheet = 0;
            nParValueA = 0;
            nParValueB = 0;
            nReceivables = 0.0;
            nInventories = 0.0;
            nCurrAssets = 0.0;
            nFixedAssets = 0.0;
            nOtherAssets = 0.0;
            nTotalAssets = 0.0;
            nCurriabilities = 0.0;
            nLTermLiabilities = 0.0;
            nTotalLiabilities = 0.0;
            nAuthorized = 0.0;
            nPaidupCap = 0.0;
            nPaidupCapShares = 0.0;
            nParValueC = 0;
            nParValueD = 0;
            nSumIncomeStat = 0;
            nRetainedEarn = 0.0;
            nTotalEquity = 0.0;
            nMinInterest = 0.0;
            nTotalSales = 0.0;
            nCostGoodSold = 0.0;
            nGrossProfit = 0.0;
            nOperatingProfit = 0.0;
            nOtherIncome = 0.0;
            nEarnBeforeTax = 0.0;
            nTax = 0.0;
            nNetIncome = 0.0;
            nClosePrice = 0.0;
            nPerShareDataRp = 0;
            nFinRatios = 0;
            nEps = 0.0;
            nBookValue = 0.0;
            nDebtEquityRatio = 0.0;
            nRoaPct = 0.0;
            nRoePct = 0.0;
            nNpmPct = 0.0;
            nOpmPct = 0.0;
            nCashFlow = 0.0;
            nCFOperateActs = 0.0;
            nCFInvesActs = 0.0;
            nCFFinActs = 0.0;
            nNetIncrCashAndCashEq = 0.0;
            nCashAndCashEqBeginYear = 0.0;
            nCashAndCashEqEndYear = 0.0;
            nUSDtoIDRRate = 0.0;
            nCashAndCashEquivalents = 0.0;
            nNonCurrentAssets = 0.0;
            nGrossProfitMarginPct = 0.0;
            nTotalAssetsTurnover = 0.0;
            nReservedField6 = 0.0;
            nReservedField7 = 0.0;
            nReservedField8 = 0.0;
            nReservedField9 = 0.0;
            nReservedField10 = 0.0;
            tstamp = null;
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

        public bool Check_Finance(string MysqlQry)
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
                DGVFinance.Rows.Clear();
                for (num = 0; num <= elementsByTagName.Count - 1; num++)
                {
                    DGVFinance.Rows.Add();
                    DGVFinance.Rows[num].Cells["fcode"].Value = elementsByTagName[num].ChildNodes.Item(0).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnYear"].Value = elementsByTagName[num].ChildNodes.Item(1).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnQrt"].Value = elementsByTagName[num].ChildNodes.Item(2).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fdtFinSt"].Value = elementsByTagName[num].ChildNodes.Item(3).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fcFiscYear"].Value = elementsByTagName[num].ChildNodes.Item(4).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnMonthCover"].Value = elementsByTagName[num].ChildNodes.Item(5).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnSumBalanceSheet"].Value = elementsByTagName[num].ChildNodes.Item(6).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnReceivables"].Value = elementsByTagName[num].ChildNodes.Item(7).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnInventories"].Value = elementsByTagName[num].ChildNodes.Item(8).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnCurrAssets"].Value = elementsByTagName[num].ChildNodes.Item(9).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnFixedAssets"].Value = elementsByTagName[num].ChildNodes.Item(10).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnOtherAssets"].Value = elementsByTagName[num].ChildNodes.Item(11).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnTotalAssets"].Value = elementsByTagName[num].ChildNodes.Item(12).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnCurriabilities"].Value = elementsByTagName[num].ChildNodes.Item(13).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnLTermLiabilities"].Value = elementsByTagName[num].ChildNodes.Item(14).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnTotalLiabilities"].Value = elementsByTagName[num].ChildNodes.Item(15).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnAuthorized"].Value = elementsByTagName[num].ChildNodes.Item(16).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnPaidupCap"].Value = elementsByTagName[num].ChildNodes.Item(17).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnParValueA"].Value = elementsByTagName[num].ChildNodes.Item(18).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnParValueB"].Value = elementsByTagName[num].ChildNodes.Item(19).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnParValueC"].Value = elementsByTagName[num].ChildNodes.Item(20).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnParValueD"].Value = elementsByTagName[num].ChildNodes.Item(21).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnPaidupCapShares"].Value = elementsByTagName[num].ChildNodes.Item(22).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnRetainedEarn"].Value = elementsByTagName[num].ChildNodes.Item(23).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnTotalEquity"].Value = elementsByTagName[num].ChildNodes.Item(24).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnMinInterest"].Value = elementsByTagName[num].ChildNodes.Item(25).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnSumIncomeStat"].Value = elementsByTagName[num].ChildNodes.Item(26).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnTotalSales"].Value = elementsByTagName[num].ChildNodes.Item(27).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnCostGoodSold"].Value = elementsByTagName[num].ChildNodes.Item(28).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnGrossProfit"].Value = elementsByTagName[num].ChildNodes.Item(29).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnOperatingProfit"].Value = elementsByTagName[num].ChildNodes.Item(30).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnOtherIncome"].Value = elementsByTagName[num].ChildNodes.Item(31).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnEarnBeforeTax"].Value = elementsByTagName[num].ChildNodes.Item(32).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnTax"].Value = elementsByTagName[num].ChildNodes.Item(33).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnNetIncome"].Value = elementsByTagName[num].ChildNodes.Item(34).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnClosePrice"].Value = elementsByTagName[num].ChildNodes.Item(35).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnPerShareDataRp"].Value = elementsByTagName[num].ChildNodes.Item(36).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnEps"].Value = elementsByTagName[num].ChildNodes.Item(37).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnBookValue"].Value = elementsByTagName[num].ChildNodes.Item(38).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnFinRatios"].Value = elementsByTagName[num].ChildNodes.Item(39).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnDebtEquityRatio"].Value = elementsByTagName[num].ChildNodes.Item(40).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnRoaPct"].Value = elementsByTagName[num].ChildNodes.Item(41).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnRoePct"].Value = elementsByTagName[num].ChildNodes.Item(42).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnNpmPct"].Value = elementsByTagName[num].ChildNodes.Item(43).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnOpmPct"].Value = elementsByTagName[num].ChildNodes.Item(44).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnCashFlow"].Value = elementsByTagName[num].ChildNodes.Item(45).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnCFOperateActs"].Value = elementsByTagName[num].ChildNodes.Item(46).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnCFInvesActs"].Value = elementsByTagName[num].ChildNodes.Item(47).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnCFFinActs"].Value = elementsByTagName[num].ChildNodes.Item(48).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnNetIncrCashAndCashEq"].Value = elementsByTagName[num].ChildNodes.Item(49).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnCashAndCashEqBeginYear"].Value = elementsByTagName[num].ChildNodes.Item(50).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnCashAndCashEqEndYear"].Value = elementsByTagName[num].ChildNodes.Item(51).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnUSDtoIDRRate"].Value = elementsByTagName[num].ChildNodes.Item(52).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnCashAndCashEquivalents"].Value = elementsByTagName[num].ChildNodes.Item(53).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnNonCurrentAssets"].Value = elementsByTagName[num].ChildNodes.Item(54).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnGrossProfitMarginPct"].Value = elementsByTagName[num].ChildNodes.Item(55).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnTotalAssetsTurnover"].Value = elementsByTagName[num].ChildNodes.Item(56).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnReservedField6"].Value = elementsByTagName[num].ChildNodes.Item(57).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnReservedField7"].Value = elementsByTagName[num].ChildNodes.Item(58).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnReservedField8"].Value = elementsByTagName[num].ChildNodes.Item(59).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnReservedField9"].Value = elementsByTagName[num].ChildNodes.Item(60).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["fnReservedField10"].Value = elementsByTagName[num].ChildNodes.Item(61).InnerText.Trim();
                    DGVFinance.Rows[num].Cells["ftstamp"].Value = elementsByTagName[num].ChildNodes.Item(62).InnerText.Trim();
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
                for (int i = 0; i < DGVFinance.RowCount; i++)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    if (Convert.ToString(DGVFinance.Rows[i].Cells["fcode"].Value) != "")
                    {
                        code = Convert.ToString(DGVFinance.Rows[i].Cells["fcode"].Value);
                        nYear = Convert.ToInt32(DGVFinance.Rows[i].Cells["fnYear"].Value);
                        nQrt = Convert.ToInt32(DGVFinance.Rows[i].Cells["fnQrt"].Value);
                        dtFinSt = Convert.ToString(DGVFinance.Rows[i].Cells["fdtFinSt"].Value);
                        cFiscYear = Convert.ToString(DGVFinance.Rows[i].Cells["fcFiscYear"].Value);
                        nMonthCover = Convert.ToInt32(DGVFinance.Rows[i].Cells["fnMonthCover"].Value);
                        nSumBalanceSheet = Convert.ToInt32(DGVFinance.Rows[i].Cells["fnSumBalanceSheet"].Value);
                        nReceivables = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnReceivables"].Value);
                        nInventories = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnInventories"].Value);
                        nCurrAssets = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnCurrAssets"].Value);
                        nFixedAssets = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnFixedAssets"].Value);
                        nOtherAssets = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnOtherAssets"].Value);
                        nTotalAssets = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnTotalAssets"].Value);
                        nCurriabilities = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnCurriabilities"].Value);
                        nLTermLiabilities = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnLTermLiabilities"].Value);
                        nTotalLiabilities = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnTotalLiabilities"].Value);
                        nAuthorized = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnAuthorized"].Value);
                        nPaidupCap = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnPaidupCap"].Value);
                        nParValueA = Convert.ToInt32(DGVFinance.Rows[i].Cells["fnParValueA"].Value);
                        nParValueB = Convert.ToInt32(DGVFinance.Rows[i].Cells["fnParValueB"].Value);
                        nParValueC = Convert.ToInt32(DGVFinance.Rows[i].Cells["fnParValueC"].Value);
                        nParValueD = Convert.ToInt32(DGVFinance.Rows[i].Cells["fnParValueD"].Value);
                        nPaidupCapShares = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnPaidupCapShares"].Value);
                        nRetainedEarn = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnRetainedEarn"].Value);
                        nTotalEquity = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnTotalEquity"].Value);
                        nMinInterest = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnMinInterest"].Value);
                        nSumIncomeStat = Convert.ToInt32(DGVFinance.Rows[i].Cells["fnSumIncomeStat"].Value);
                        nTotalSales = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnTotalSales"].Value);
                        nCostGoodSold = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnCostGoodSold"].Value);
                        nGrossProfit = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnGrossProfit"].Value);
                        nOperatingProfit = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnOperatingProfit"].Value);
                        nOtherIncome = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnOtherIncome"].Value);
                        nEarnBeforeTax = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnEarnBeforeTax"].Value);
                        nTax = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnTax"].Value);
                        nNetIncome = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnNetIncome"].Value);
                        nClosePrice = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnClosePrice"].Value);
                        nPerShareDataRp = Convert.ToInt32(DGVFinance.Rows[i].Cells["fnPerShareDataRp"].Value);
                        nEps = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnEps"].Value);
                        nBookValue = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnBookValue"].Value);
                        nFinRatios = Convert.ToInt32(DGVFinance.Rows[i].Cells["fnFinRatios"].Value);
                        nDebtEquityRatio = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnDebtEquityRatio"].Value);
                        nRoaPct = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnRoaPct"].Value);
                        nRoePct = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnRoePct"].Value);
                        nNpmPct = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnNpmPct"].Value);
                        nOpmPct = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnOpmPct"].Value);
                        nCashFlow = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnCashFlow"].Value);
                        nCFOperateActs = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnCFOperateActs"].Value);
                        nCFInvesActs = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnCFInvesActs"].Value);
                        nCFFinActs = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnCFFinActs"].Value);
                        nNetIncrCashAndCashEq = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnNetIncrCashAndCashEq"].Value);
                        nCashAndCashEqBeginYear = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnCashAndCashEqBeginYear"].Value);
                        nCashAndCashEqEndYear = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnCashAndCashEqEndYear"].Value);
                        nUSDtoIDRRate = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnUSDtoIDRRate"].Value);
                        nCashAndCashEquivalents = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnCashAndCashEquivalents"].Value);
                        nNonCurrentAssets = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnNonCurrentAssets"].Value);
                        nGrossProfitMarginPct = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnGrossProfitMarginPct"].Value);
                        nTotalAssetsTurnover = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnTotalAssetsTurnover"].Value);
                        nReservedField6 = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnReservedField6"].Value);
                        nReservedField7 = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnReservedField7"].Value);
                        nReservedField8 = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnReservedField8"].Value);
                        nReservedField9 = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnReservedField9"].Value);
                        nReservedField10 = Convert.ToDouble(DGVFinance.Rows[i].Cells["fnReservedField10"].Value);
                        tstamp = Convert.ToString(DGVFinance.Rows[i].Cells["ftstamp"].Value);
                    }
                    string text = "('" + code + "'," + nYear + "," + nQrt + ",'" + dtFinSt + "','" + cFiscYear + "'," + nMonthCover + "," + nSumBalanceSheet + "," + nReceivables + ",";
                    object obj = text;
                    text = string.Concat(obj, nInventories, ",", nCurrAssets, ",", nFixedAssets, ",", nOtherAssets, ",", nTotalAssets, ",", nCurriabilities, ",", nLTermLiabilities, ",");
                    obj = text;
                    text = string.Concat(obj, nTotalLiabilities, ",", nAuthorized, ",", nPaidupCap, ",", nParValueA, ",", nParValueB, ",", nParValueC, ",", nParValueD, ",");
                    obj = text;
                    text = string.Concat(obj, nPaidupCapShares, ",", nRetainedEarn, ",", nTotalEquity, ",", nMinInterest, ",", nSumIncomeStat, ",", nTotalSales, ",", nCostGoodSold, ",");
                    obj = text;
                    text = string.Concat(obj, nGrossProfit, ",", nOperatingProfit, ",", nOtherIncome, ",", nEarnBeforeTax, ",", nTax, ",", nNetIncome, ",", nClosePrice, ",");
                    obj = text;
                    text = string.Concat(obj, nPerShareDataRp, ",", nEps, ",", nBookValue, ",", nFinRatios, ",", nDebtEquityRatio, ",", nRoaPct, ",", nRoePct, ",", nNpmPct, ",");
                    obj = text;
                    text = string.Concat(obj, nOpmPct, ",", nCashFlow, ",", nCFOperateActs, ",", nCFInvesActs, ",", nCFFinActs, ",", nNetIncrCashAndCashEq, ",", nCashAndCashEqBeginYear, ",");
                    obj = text;
                    text = string.Concat(obj, nCashAndCashEqEndYear, ",", nUSDtoIDRRate, ",", nCashAndCashEquivalents, ",", nNonCurrentAssets, ",", nGrossProfitMarginPct, ",");
                    obj = text;
                    text = string.Concat(obj, nTotalAssetsTurnover, ",", nReservedField6, ",", nReservedField7, ",", nReservedField8, ",", nReservedField9, ",", nReservedField10, ",");
                    string text2 = text;
                    text = text2 + "'" + tstamp + "','" + filename + "')";
                    string str = text;
                    if (Check_Finance("call sp_checkfinance('" + code + "'," + nYear + "," + nQrt + ")"))
                    {
                        str = MySQLEscape(str);
                        str = "call sp_updatefinance" + text;
                    }
                    else
                    {
                        str = MySQLEscape(str);
                        str = "call sp_insert_finance (\"" + str + "\")";
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
                MessageBox.Show("Finance Succesfully Updated");
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
            DGVFinance.Rows.Clear();
            txtFileName.Clear();
        }
    }
}
