namespace CPCA
{
    partial class FrmSWARI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSWARI));
            DGVSWARI = new DataGridView();
            swisin_code = new DataGridViewTextBoxColumn();
            swissuer_name = new DataGridViewTextBoxColumn();
            swcode_efek = new DataGridViewTextBoxColumn();
            swunderlying_wrant = new DataGridViewTextBoxColumn();
            swratio_konversi = new DataGridViewTextBoxColumn();
            swname_waran = new DataGridViewTextBoxColumn();
            swdist_dt = new DataGridViewTextBoxColumn();
            swtrading_periode = new DataGridViewTextBoxColumn();
            swtype_wrant = new DataGridViewTextBoxColumn();
            swexercise_price = new DataGridViewTextBoxColumn();
            swdue_dt = new DataGridViewTextBoxColumn();
            swtotal_wrant = new DataGridViewTextBoxColumn();
            swcreated_date = new DataGridViewTextBoxColumn();
            swrevised_date = new DataGridViewTextBoxColumn();
            toolStrip1 = new ToolStrip();
            toolStripSave = new ToolStripButton();
            toolStripCancel = new ToolStripButton();
            toolStripClose = new ToolStripButton();
            label1 = new Label();
            txtFileName = new TextBox();
            Add = new Button();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)DGVSWARI).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // DGVSWARI
            // 
            DGVSWARI.AllowUserToAddRows = false;
            DGVSWARI.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGVSWARI.BackgroundColor = Color.AliceBlue;
            DGVSWARI.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVSWARI.Columns.AddRange(new DataGridViewColumn[] { swisin_code, swissuer_name, swcode_efek, swunderlying_wrant, swratio_konversi, swname_waran, swdist_dt, swtrading_periode, swtype_wrant, swexercise_price, swdue_dt, swtotal_wrant, swcreated_date, swrevised_date });
            DGVSWARI.Location = new Point(12, 123);
            DGVSWARI.Name = "DGVSWARI";
            DGVSWARI.RowTemplate.Height = 25;
            DGVSWARI.Size = new Size(776, 403);
            DGVSWARI.TabIndex = 0;
            swisin_code.HeaderText = "isin_code";
            swisin_code.Name = "swisin_code";

            swissuer_name.HeaderText = "issuer_name";
            swissuer_name.Name = "swissuer_name";

            swcode_efek.HeaderText = "code_efek";
            swcode_efek.Name = "swcode_efek";

            swunderlying_wrant.HeaderText = "underlying_wrant";
            swunderlying_wrant.Name = "swunderlying_wrant";

            swratio_konversi.HeaderText = "ratio_konversi";
            swratio_konversi.Name = "swratio_konversi";

            swname_waran.HeaderText = "name_waran";
            swname_waran.Name = "swname_waran";

            swdist_dt.HeaderText = "dist_dt";
            swdist_dt.Name = "swdist_dt";

            swtrading_periode.HeaderText = "trading_periode";
            swtrading_periode.Name = "swtrading_periode";

            swtype_wrant.HeaderText = "type_wrant";
            swtype_wrant.Name = "swtype_wrant";

            swexercise_price.HeaderText = "exercise_price";
            swexercise_price.Name = "swexercise_price";

            swdue_dt.HeaderText = "due_dt";
            swdue_dt.Name = "swdue_dt";

            swtotal_wrant.HeaderText = "total_wrant";
            swtotal_wrant.Name = "swtotal_wrant";

            swcreated_date.HeaderText = "created_date";
            swcreated_date.Name = "swcreated_date";

            swrevised_date.HeaderText = "revised_date";
            swrevised_date.Name = "swrevised_date";
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
            // textBox1
            // 
            textBox1.Location = new Point(442, 89);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(304, 23);
            textBox1.TabIndex = 5;
            // 
            // FrmSWARI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(800, 538);
            Controls.Add(textBox1);
            Controls.Add(Add);
            Controls.Add(txtFileName);
            Controls.Add(label1);
            Controls.Add(toolStrip1);
            Controls.Add(DGVSWARI);
            Name = "FrmSWARI";
            StartPosition = FormStartPosition.CenterParent;
            Text = "SWARI";
            ((System.ComponentModel.ISupportInitialize)DGVSWARI).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DGVSWARI;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripSave;
        private ToolStripButton toolStripCancel;
        private ToolStripButton toolStripClose;
        private Label label1;
        private TextBox txtFileName;
        private Button Add;
        private TextBox textBox1;
    }
}