namespace CPCA
{
    partial class FrmDeviden
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPCA.FrmDeviden));
            DGVDeviden = new System.Windows.Forms.DataGridView();
            this.dcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dper_share = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dpayment_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dcum_dt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dex_dt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drecord_dt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ddist_dt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dcreated_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drevised_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            toolStrip1 = new ToolStrip();
            toolStripSave = new ToolStripButton();
            toolStripCancel = new ToolStripButton();
            toolStripClose = new ToolStripButton();
            label1 = new Label();
            txtFileName = new TextBox();
            Add = new Button();
            this.dcode.HeaderText = "code";
            this.dcode.Name = "dcode";
            this.dstatus.HeaderText = "status";
            this.dstatus.Name = "dstatus";
            this.dper_share.HeaderText = "per_share";
            this.dper_share.Name = "dper_share";
            this.dpayment_type.HeaderText = "payment_type";
            this.dpayment_type.Name = "dpayment_type";
            this.dcum_dt.HeaderText = "cum_dt";
            this.dcum_dt.Name = "dcum_dt";
            this.dex_dt.HeaderText = "ex_dt";
            this.dex_dt.Name = "dex_dt";
            this.drecord_dt.HeaderText = "record_dt";
            this.drecord_dt.Name = "drecord_dt";
            this.ddist_dt.HeaderText = "dist_dt";
            this.ddist_dt.Name = "ddist_dt";
            this.dcreated_date.HeaderText = "created_date";
            this.dcreated_date.Name = "dcreated_date";
            this.drevised_date.HeaderText = "revised_date";
            this.drevised_date.Name = "drevised_date";
            this.dtotal.HeaderText = "total";
            this.dtotal.Name = "dtotal";
            ((System.ComponentModel.ISupportInitialize)DGVDeviden).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // DGVDeviden
            // 
            DGVDeviden.AllowUserToAddRows = false;
            DGVDeviden.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGVDeviden.BackgroundColor = Color.AliceBlue;
            DGVDeviden.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVDeviden.Columns.AddRange(new DataGridViewColumn[] { this.dcode, this.dstatus, this.dper_share, this.dpayment_type, this.dcum_dt, this.dex_dt, this.drecord_dt, this.ddist_dt, this.dcreated_date, this.drevised_date, this.dtotal });
            DGVDeviden.Location = new Point(12, 123);
            DGVDeviden.Name = "DGVDeviden";
            DGVDeviden.RowTemplate.Height = 25;
            DGVDeviden.Size = new Size(776, 403);
            DGVDeviden.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.AutoSize = false;
            toolStrip1.BackColor = Color.AliceBlue;
            toolStrip1.ImageScalingSize = new Size(65, 65);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripSave, toolStripCancel, toolStripClose });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 73);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSave
            // 
            toolStripSave.AutoSize = false;
            toolStripSave.Image = (Image)resources.GetObject("toolStripSave.Image");
            toolStripSave.ImageTransparentColor = Color.Magenta;
            toolStripSave.Margin = new Padding(5, 5, 5, 2);
            toolStripSave.Name = "toolStripSave";
            toolStripSave.Padding = new Padding(5, 5, 5, 0);
            toolStripSave.Size = new Size(60, 60);
            toolStripSave.Text = "Save";
            toolStripSave.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripSave.Click += toolStripSave_Click;
            // 
            // toolStripCancel
            // 
            toolStripCancel.AutoSize = false;
            toolStripCancel.Image = (Image)resources.GetObject("toolStripCancel.Image");
            toolStripCancel.ImageTransparentColor = Color.Magenta;
            toolStripCancel.Margin = new Padding(5, 5, 5, 2);
            toolStripCancel.Name = "toolStripCancel";
            toolStripCancel.Padding = new Padding(5, 5, 5, 0);
            toolStripCancel.Size = new Size(60, 60);
            toolStripCancel.Text = "Cancel";
            toolStripCancel.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripCancel.Click += toolStripCancel_Click;
            // 
            // toolStripClose
            // 
            toolStripClose.AutoSize = false;
            toolStripClose.Image = (Image)resources.GetObject("toolStripClose.Image");
            toolStripClose.ImageTransparentColor = Color.Magenta;
            toolStripClose.Margin = new Padding(5, 5, 5, 2);
            toolStripClose.Name = "toolStripClose";
            toolStripClose.Padding = new Padding(5, 5, 5, 0);
            toolStripClose.Size = new Size(60, 60);
            toolStripClose.Text = "Close";
            toolStripClose.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripClose.Click += toolStripClose_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 90);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 2;
            label1.Text = "File Name";
            // 
            // txtFileName
            // 
            txtFileName.BackColor = Color.AliceBlue;
            txtFileName.Location = new Point(91, 86);
            txtFileName.Name = "txtFileName";
            txtFileName.Size = new Size(206, 23);
            txtFileName.TabIndex = 3;
            // 
            // Add
            // 
            Add.Image = (Image)resources.GetObject("Add.Image");
            Add.Location = new Point(305, 83);
            Add.Name = "Add";
            Add.Size = new Size(30, 30);
            Add.TabIndex = 4;
            Add.UseVisualStyleBackColor = true;
            Add.Click += Add_Click;
            // 
            // FrmProfile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(800, 538);
            Controls.Add(Add);
            Controls.Add(txtFileName);
            Controls.Add(label1);
            Controls.Add(toolStrip1);
            Controls.Add(DGVDeviden);
            Name = "FrmDeviden";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Deviden";
            ((System.ComponentModel.ISupportInitialize)DGVDeviden).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DGVDeviden;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripSave;
        private ToolStripButton toolStripCancel;
        private ToolStripButton toolStripClose;
        private Label label1;
        private TextBox txtFileName;
        private Button Add;
    }
}