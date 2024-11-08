namespace CPCA
{
    partial class FrmProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProfile));
            DGVProfile = new DataGridView();
            cp_code = new DataGridViewTextBoxColumn();
            cp_title = new DataGridViewTextBoxColumn();
            cp_address = new DataGridViewTextBoxColumn();
            cp_background = new DataGridViewTextBoxColumn();
            cp_product = new DataGridViewTextBoxColumn();
            cp_affiliation = new DataGridViewTextBoxColumn();
            cp_commissioners = new DataGridViewTextBoxColumn();
            cp_directors = new DataGridViewTextBoxColumn();
            cp_underwriter = new DataGridViewTextBoxColumn();
            cp_registrar = new DataGridViewTextBoxColumn();
            cp_holders = new DataGridViewTextBoxColumn();
            cp_stocks = new DataGridViewTextBoxColumn();
            cp_infos = new DataGridViewTextBoxColumn();
            cp_created = new DataGridViewTextBoxColumn();
            cp_revised = new DataGridViewTextBoxColumn();
            toolStrip1 = new ToolStrip();
            toolStripSave = new ToolStripButton();
            toolStripCancel = new ToolStripButton();
            toolStripClose = new ToolStripButton();
            label1 = new Label();
            txtFileName = new TextBox();
            Add = new Button();
            ((System.ComponentModel.ISupportInitialize)DGVProfile).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // DGVProfile
            // 
            DGVProfile.AllowUserToAddRows = false;
            DGVProfile.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGVProfile.BackgroundColor = Color.AliceBlue;
            DGVProfile.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVProfile.Columns.AddRange(new DataGridViewColumn[] { cp_code, cp_title, cp_address, cp_background, cp_product, cp_affiliation, cp_commissioners, cp_directors, cp_underwriter, cp_registrar, cp_holders, cp_stocks, cp_infos, cp_created, cp_revised });
            DGVProfile.Location = new Point(12, 123);
            DGVProfile.Name = "DGVProfile";
            DGVProfile.RowTemplate.Height = 25;
            DGVProfile.Size = new Size(776, 403);
            DGVProfile.TabIndex = 0;
            // 
            // cp_code
            // 
            cp_code.Name = "cp_code";
            // 
            // cp_title
            // 
            cp_title.Name = "cp_title";
            // 
            // cp_address
            // 
            cp_address.Name = "cp_address";
            // 
            // cp_background
            // 
            cp_background.Name = "cp_background";
            // 
            // cp_product
            // 
            cp_product.Name = "cp_product";
            // 
            // cp_affiliation
            // 
            cp_affiliation.Name = "cp_affiliation";
            // 
            // cp_commissioners
            // 
            cp_commissioners.Name = "cp_commissioners";
            // 
            // cp_directors
            // 
            cp_directors.Name = "cp_directors";
            // 
            // cp_underwriter
            // 
            cp_underwriter.Name = "cp_underwriter";
            // 
            // cp_registrar
            // 
            cp_registrar.Name = "cp_registrar";
            // 
            // cp_holders
            // 
            cp_holders.Name = "cp_holders";
            // 
            // cp_stocks
            // 
            cp_stocks.Name = "cp_stocks";
            // 
            // cp_infos
            // 
            cp_infos.Name = "cp_infos";
            // 
            // cp_created
            // 
            cp_created.Name = "cp_created";
            // 
            // cp_revised
            // 
            cp_revised.Name = "cp_revised";
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
            Controls.Add(DGVProfile);
            Name = "FrmProfile";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Profile";
            ((System.ComponentModel.ISupportInitialize)DGVProfile).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DGVProfile;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripSave;
        private ToolStripButton toolStripCancel;
        private ToolStripButton toolStripClose;
        private Label label1;
        private TextBox txtFileName;
        private Button Add;
    }
}