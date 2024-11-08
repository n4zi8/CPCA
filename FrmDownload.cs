using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using Chilkat;
using CPCA.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;
using System.Windows.Forms.Design;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Org.BouncyCastle.Asn1.Cmp;
using Mysqlx;


namespace CPCA
{
    public partial class FrmDownload : Form
    {
        public FrmDownload()
        {
            InitializeComponent();
        }
        //public string filename { get { return filename; } set {  filename = value; } }
        private void FrmDownload_Load(object sender, EventArgs e)
        {
            InitializeListView();
        }

        //private void getdata()
        //{

        //    Ftp2 ftp = new Ftp2();

        //    if (!ftp.UnlockComponent("AnythingWorksFor30DayTrial"))
        //    {
        //        MessageBox.Show(ftp.LastErrorText);
        //        return;
        //    }


        //    ftp.Hostname = "10.1.4.77";
        //    ftp.Username = "ftpadmin";
        //    ftp.Password = "Admincontrol1";


        //    if (!ftp.Connect())
        //    {
        //        MessageBox.Show(ftp.LastErrorText);
        //        return;
        //    }
        //    if (!ftp.ChangeRemoteDir("/home/cpcavalbury"))
        //    {
        //        MessageBox.Show(ftp.LastErrorText);
        //        return;
        //    }

        //    int numFilesAndDirs = ftp.NumFilesAndDirs;

        //    if (numFilesAndDirs < 0)
        //    {
        //        MessageBox.Show(ftp.LastErrorText);
        //        return;
        //    }
        //    if (numFilesAndDirs > 0)
        //    {
        //        LvwList.Items.Clear();
        //        for (int i = 0; i <= numFilesAndDirs - 1; i++)
        //        {
        //            if (ftp.GetLastModifiedTime(i).ToString("dd-MM-yyyy") == DtpTanggal.Value.ToString("dd-MM-yyyy"))
        //            {
        //                ListViewItem listViewItem = new ListViewItem(ftp.GetFilename(i) + "\r\n");

        //                int num = ftp.GetSize(i);
        //                string text = "B";
        //                if (num > 1024)
        //                {
        //                    num = ftp.GetSize(i) / 1024;
        //                    text = "KB";
        //                }
        //                listViewItem.SubItems.Add(num + text);
        //                listViewItem.SubItems.Add(ftp.GetLastModifiedTime(i).ToString("dd-MM-yyyy"));
        //                LvwList.Items.Add(listViewItem);
        //            }
        //        }
        //    }
        //    ftp.Disconnect();
        //}

        private void getdata()
        {
            Ftp2 ftp2 = new Ftp2();
            if (!ftp2.UnlockComponent("AnythingWorksFor30DayTrial"))
            {
                int num1 = (int)MessageBox.Show(ftp2.LastErrorText);
            }
            else
            {
                ftp2.Hostname = "103.23.28.102";
                ftp2.Username = "ftpadmin";
                ftp2.Password = "Admincontrol1";
                if (!ftp2.Connect())
                {
                    int num2 = (int)MessageBox.Show(ftp2.LastErrorText);
                }
                else if (!ftp2.ChangeRemoteDir("/home/cpcavalbury"))
                {
                    int num3 = (int)MessageBox.Show(ftp2.LastErrorText);
                }
                else
                {
                    int numFilesAndDirs = ftp2.NumFilesAndDirs;
                    if (numFilesAndDirs < 0)
                    {
                        int num4 = (int)MessageBox.Show(ftp2.LastErrorText);
                    }
                    else
                    {
                        if (numFilesAndDirs > 0)
                        {
                            this.LvwList.Items.Clear();
                            for (int index = 0; index <= numFilesAndDirs - 1; ++index)
                            {
                                if (ftp2.GetLastModifiedTime(index).ToString("dd-MM-yyyy") == this.DtpTanggal.Value.ToString("dd-MM-yyyy"))
                                {
                                    ListViewItem listViewItem = new ListViewItem(ftp2.GetFilename(index) + "\r\n");
                                    int num5 = ftp2.GetSize(index);
                                    string str = "B";
                                    if (num5 > 1024)
                                    {
                                        num5 = ftp2.GetSize(index) / 1024;
                                        str = "KB";
                                    }
                                    listViewItem.SubItems.Add(num5.ToString() + str);
                                    listViewItem.SubItems.Add(ftp2.GetLastModifiedTime(index).ToString("dd-MM-yyyy"));
                                    this.LvwList.Items.Add(listViewItem);
                                }
                            }
                        }
                        ftp2.Disconnect();
                    }
                }
            }
        }

        //private void toolStripDownload1_Click(object sender, EventArgs e)
        //{
        //    Ftp2 ftp = new Ftp2();
        //    if (!ftp.UnlockComponent("AnythingWorksFor30DayTrial"))
        //    {
        //        MessageBox.Show(ftp.LastErrorText);
        //        return;
        //    }
        //    ftp.Hostname = "10.1.4.77";
        //    ftp.Username = "ftpadmin";
        //    ftp.Password = "Admincontrol1";
        //    if (!ftp.Connect())
        //    {
        //        MessageBox.Show(ftp.LastErrorText);
        //        return;
        //    }
        //    if (!ftp.ChangeRemoteDir("/home/cpcavalbury"))
        //    {
        //        MessageBox.Show(ftp.LastErrorText);
        //        return;
        //    }
        //    foreach (object selectedItem in LvwList.SelectedItems)
        //    {
        //        string text = selectedItem.ToString().Replace("ListViewItem: {", string.Empty).Replace("}", string.Empty);
        //        string localFilename = "d:/cpcaxml/" + text;
        //        if (!ftp.GetFile(text, localFilename))
        //        {
        //            MessageBox.Show(ftp.LastErrorText);
        //            return;
        //        }
        //    }
        //    bool flag = ftp.Disconnect();
        //    MessageBox.Show("File Downloaded!");
        //}

        private void toolStripDownload1_Click(object sender, EventArgs e)
        {
            Ftp2 ftp2 = new Ftp2();
            if (!ftp2.UnlockComponent("AnythingWorksFor30DayTrial"))
            {
                int num1 = (int)MessageBox.Show(ftp2.LastErrorText);
            }
            else
            {
                ftp2.Hostname = "10.1.4.77";
                ftp2.Username = "ftpadmin";
                ftp2.Password = "Admincontrol1";
                if (!ftp2.Connect())
                {
                    int num2 = (int)MessageBox.Show(ftp2.LastErrorText);
                }
                else if (!ftp2.ChangeRemoteDir("/home/cpcavalbury"))
                {
                    int num3 = (int)MessageBox.Show(ftp2.LastErrorText);
                }
                else
                {
                    foreach (object selectedItem in this.LvwList.SelectedItems)
                    {
                        string remoteFilename = selectedItem.ToString().Replace("ListViewItem: {", string.Empty).Replace("}", string.Empty);
                        string localFilename = "d:/cpcaxml/" + remoteFilename;
                        if (!ftp2.GetFile(remoteFilename, localFilename))
                        {
                            int num4 = (int)MessageBox.Show(ftp2.LastErrorText);
                            return;
                        }
                    }
                    ftp2.Disconnect();
                    int num5 = (int)MessageBox.Show("File Downloaded!");
                }
            }
        }

        private void CmdBrowse_Click(object sender, EventArgs e)
        {
            getdata();


        }

        private void toolStripClose1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
