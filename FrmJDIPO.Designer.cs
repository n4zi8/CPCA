namespace CPCA
{
    partial class FrmJDIPO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPCA.FrmJDIPO));
            DGVJIPO = new System.Windows.Forms.DataGridView();
            this.jcomp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jbusiness = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.junderwriter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.joffer_dt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jrecord_dt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jtotal_share = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jnom_share = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jval_share = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jcreated_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jrevised_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            toolStrip1 = new ToolStrip();
            toolStripSave = new ToolStripButton();
            toolStripCancel = new ToolStripButton();
            toolStripClose = new ToolStripButton();
            label1 = new Label();
            txtFileName = new TextBox();
            Add = new Button();
            this.jcomp.HeaderText = "comp";
            this.jcomp.Name = "jcomp";
            this.jbusiness.HeaderText = "business";
            this.jbusiness.Name = "jbusiness";
            this.junderwriter.HeaderText = "underwriter";
            this.junderwriter.Name = "junderwriter";
            this.joffer_dt.HeaderText = "offer_dt";
            this.joffer_dt.Name = "joffer_dt";
            this.jrecord_dt.HeaderText = "record_dt";
            this.jrecord_dt.Name = "jrecord_dt";
            this.jtotal_share.HeaderText = "total_share";
            this.jtotal_share.Name = "jtotal_share";
            this.jnom_share.HeaderText = "nom_share";
            this.jnom_share.Name = "jnom_share";
            this.jval_share.HeaderText = "val_share";
            this.jval_share.Name = "jval_share";
            this.jcreated_date.HeaderText = "created_date";
            this.jcreated_date.Name = "jcreated_date";
            this.jrevised_date.HeaderText = "revised_date";
            this.jrevised_date.Name = "jrevised_date";
            ((System.ComponentModel.ISupportInitialize)DGVJIPO).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // DGVJIPO
            // 
            DGVJIPO.AllowUserToAddRows = false;
            DGVJIPO.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGVJIPO.BackgroundColor = Color.AliceBlue;
            DGVJIPO.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVJIPO.Columns.AddRange(new DataGridViewColumn[] { this.jcomp, this.jbusiness, this.junderwriter, this.joffer_dt, this.jrecord_dt, this.jtotal_share, this.jnom_share, this.jval_share, this.jcreated_date, this.jrevised_date });
            DGVJIPO.Location = new Point(12, 123);
            DGVJIPO.Name = "DGVJIPO";
            DGVJIPO.RowTemplate.Height = 25;
            DGVJIPO.Size = new Size(776, 403);
            DGVJIPO.TabIndex = 0;
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
            Controls.Add(DGVJIPO);
            Name = "FrmJDIPO";
            StartPosition = FormStartPosition.CenterParent;
            Text = "JDIPO";
            ((System.ComponentModel.ISupportInitialize)DGVJIPO).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DGVJIPO;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripSave;
        private ToolStripButton toolStripCancel;
        private ToolStripButton toolStripClose;
        private Label label1;
        private TextBox txtFileName;
        private Button Add;
    }
}