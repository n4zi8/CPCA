namespace CPCA
{
    partial class FrmDownload
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDownload));
            toolStrip1 = new ToolStrip();
            toolStripDownload1 = new ToolStripButton();
            toolStripClose1 = new ToolStripButton();
            LvwList = new ListView();
            DtpTanggal = new DateTimePicker();
            label1 = new Label();
            CmdBrowse = new Button();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripDownload1, toolStripClose1 });
            resources.ApplyResources(toolStrip1, "toolStrip1");
            toolStrip1.Name = "toolStrip1";
            // 
            // toolStripDownload1
            // 
            resources.ApplyResources(toolStripDownload1, "toolStripDownload1");
            toolStripDownload1.Name = "toolStripDownload1";
            toolStripDownload1.Click += toolStripDownload1_Click;
            // 
            // toolStripClose1
            // 
            resources.ApplyResources(toolStripClose1, "toolStripClose1");
            toolStripClose1.Name = "toolStripClose1";
            toolStripClose1.Padding = new Padding(5, 0, 0, 0);
            toolStripClose1.Click += toolStripClose1_Click;
            // 
            // LvwList
            // 
            resources.ApplyResources(LvwList, "LvwList");
            LvwList.Name = "LvwList";
            LvwList.UseCompatibleStateImageBehavior = false;
            // 
            // DtpTanggal
            // 
            resources.ApplyResources(DtpTanggal, "DtpTanggal");
            DtpTanggal.Name = "DtpTanggal";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // CmdBrowse
            // 
            resources.ApplyResources(CmdBrowse, "CmdBrowse");
            CmdBrowse.Name = "CmdBrowse";
            CmdBrowse.UseVisualStyleBackColor = true;
            CmdBrowse.Click += CmdBrowse_Click;
            // 
            // FrmDownload
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            Controls.Add(CmdBrowse);
            Controls.Add(label1);
            Controls.Add(DtpTanggal);
            Controls.Add(LvwList);
            Controls.Add(toolStrip1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmDownload";
            Load += FrmDownload_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void InitializeListView()
        {
            LvwList.View = View.Details;
            LvwList.LabelEdit = true;
            LvwList.AllowColumnReorder = true;
            LvwList.FullRowSelect = true;
            LvwList.GridLines = true;
            LvwList.Sorting = SortOrder.Ascending;
            LvwList.Columns.Add("Filename", 250, HorizontalAlignment.Left);
            LvwList.Columns.Add("Size", 100, HorizontalAlignment.Left);
            LvwList.Columns.Add("Changed", 100, HorizontalAlignment.Left);
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton toolStripDownload1;
        private ToolStripButton toolStripClose1;
        private ListView LvwList;
        private DateTimePicker DtpTanggal;
        private Label label1;
        private Button CmdBrowse;
    }
}