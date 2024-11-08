using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Xml;
using MySql;
using MySql.Data.MySqlClient;


namespace CPCA
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            //toolStripProfile.Click -= toolStripProfile_Click;

        }

        public bool IsMdiContainer { get; set; }

        public DataGridView Dgv { get; set; }

        private void toolStripDownload_Click(object sender, EventArgs e)
        {
            var frmDownload = new FrmDownload();
            IsMdiContainer = true;
            frmDownload.MdiParent = this.MdiParent;
            frmDownload.Show(this);

        }

        private void toolStripProfile_Click(object sender, EventArgs e)
        {
            var frmProfile = new FrmProfile();
            IsMdiContainer = true;
            frmProfile.MdiParent = this.MdiParent;
            frmProfile.Show(this);
        }

        private void toolStripBonds_Click(object sender, EventArgs e)
        {
            var frmBonds = new FrmBonds();
            IsMdiContainer = true;
            frmBonds.MdiParent = this.MdiParent;
            frmBonds.Show(this);
        }

        private void toolStripFinance_Click(object sender, EventArgs e)
        {
            var frmFinance = new FrmFinance();
            IsMdiContainer = true;
            frmFinance.MdiParent = this.MdiParent;
            frmFinance.Show(this);
        }

        private void toolStripBonus_Click(object sender, EventArgs e)
        {
            var frmBonus = new FrmBonus();
            IsMdiContainer = true;
            frmBonus.MdiParent = this.MdiParent;
            frmBonus.Show(this);
        }

        private void toolStripDeviden_Click(object sender, EventArgs e)
        {
            var frmDeviden = new FrmDeviden();
            IsMdiContainer = true;
            frmDeviden.MdiParent = this.MdiParent;
            frmDeviden.Show(this);
        }

        private void toolStripIPO_Click(object sender, EventArgs e)
        {
            var frmJDIPO = new FrmJDIPO();
            IsMdiContainer = true;
            frmJDIPO.MdiParent = this.MdiParent;
            frmJDIPO.Show(this);
        }

        private void toolStripPUExp_Click(object sender, EventArgs e)
        {
            var frmPUEXP = new FrmPUEXP();
            IsMdiContainer = true;
            frmPUEXP.MdiParent = this.MdiParent;
            frmPUEXP.Show(this);
        }

        private void toolStripRight_Click(object sender, EventArgs e)
        {
            var frmRIGHT = new FrmRIGHT();
            IsMdiContainer = true;
            frmRIGHT.MdiParent = this.MdiParent;
            frmRIGHT.Show(this);
        }

        private void toolStripRvers_Click(object sender, EventArgs e)
        {
            var frmRVERS = new FrmRVERS();
            IsMdiContainer = true;
            frmRVERS.MdiParent = this.MdiParent;
            frmRVERS.Show(this);
        }

        private void toolStripSplit_Click(object sender, EventArgs e)
        {
            var frmSPLIT = new FrmSPLIT();
            IsMdiContainer = true;
            frmSPLIT.MdiParent = this.MdiParent;
            frmSPLIT.Show(this);
        }

        private void toolStripWarrant_Click(object sender, EventArgs e)
        {
            var frmWRANT = new FrmWRANT();
            IsMdiContainer = true;
            frmWRANT.MdiParent = this.MdiParent;
            frmWRANT.Show(this);
        }

        private void toolStripWarrantTerstrktr_Click(object sender, EventArgs e)
        {
            var frmSWARI = new FrmSWARI();
            IsMdiContainer = true;
            frmSWARI.MdiParent = this.MdiParent;
            frmSWARI.Show(this);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}