namespace CPCA
{
    partial class FrmBonus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPCA.FrmBonus));
            DGVBonus = new System.Windows.Forms.DataGridView();
            this.bcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bratio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bcum_bonus_dt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bex_bonus_dt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brecording_dt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdistribution_dt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bcreated_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brevised_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            toolStrip1 = new ToolStrip();
            toolStripSave = new ToolStripButton();
            toolStripCancel = new ToolStripButton();
            toolStripClose = new ToolStripButton();
            label1 = new Label();
            txtFileName = new TextBox();
            Add = new Button();
            this.bcode.HeaderText = "code";
            this.bcode.Name = "bcode";
            this.bratio.HeaderText = "ratio";
            this.bratio.Name = "bratio";
            this.bcum_bonus_dt.HeaderText = "cum_bonus_dt";
            this.bcum_bonus_dt.Name = "bcum_bonus_dt";
            this.bex_bonus_dt.HeaderText = "ex_bonus_dt";
            this.bex_bonus_dt.Name = "bex_bonus_dt";
            this.brecording_dt.HeaderText = "recording_dt";
            this.brecording_dt.Name = "brecording_dt";
            this.bdistribution_dt.HeaderText = "distribution_dt";
            this.bdistribution_dt.Name = "bdistribution_dt";
            this.bcreated_date.HeaderText = "created_date";
            this.bcreated_date.Name = "bcreated_date";
            this.brevised_date.HeaderText = "revised_date";
            this.brevised_date.Name = "brevised_date";
            ((System.ComponentModel.ISupportInitialize)DGVBonus).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // DGVBonus
            // 
            DGVBonus.AllowUserToAddRows = false;
            DGVBonus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGVBonus.BackgroundColor = Color.AliceBlue;
            DGVBonus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVBonus.Columns.AddRange(new DataGridViewColumn[] { this.bcode, this.bratio, this.bcum_bonus_dt, this.bex_bonus_dt, this.brecording_dt, this.bdistribution_dt, this.bcreated_date, this.brevised_date });
            DGVBonus.Location = new Point(12, 123);
            DGVBonus.Name = "DGVBonus";
            DGVBonus.RowTemplate.Height = 25;
            DGVBonus.Size = new Size(776, 403);
            DGVBonus.TabIndex = 0;
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
            Controls.Add(DGVBonus);
            Name = "FrmBonus";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bonus";
            ((System.ComponentModel.ISupportInitialize)DGVBonus).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DGVBonus;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripSave;
        private ToolStripButton toolStripCancel;
        private ToolStripButton toolStripClose;
        private Label label1;
        private TextBox txtFileName;
        private Button Add;
    }
}