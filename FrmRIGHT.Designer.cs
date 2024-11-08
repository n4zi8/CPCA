namespace CPCA
{
    partial class FrmRIGHT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRIGHT));
            DGVRIGHT = new DataGridView();
            rcode = new DataGridViewTextBoxColumn();
            rratio = new DataGridViewTextBoxColumn();
            rcum_dt = new DataGridViewTextBoxColumn();
            rex_dt = new DataGridViewTextBoxColumn();
            rdps_dt = new DataGridViewTextBoxColumn();
            rprice = new DataGridViewTextBoxColumn();
            rtrading_period = new DataGridViewTextBoxColumn();
            rindicator = new DataGridViewTextBoxColumn();
            rcreated_date = new DataGridViewTextBoxColumn();
            rrevised_date = new DataGridViewTextBoxColumn();
            toolStrip1 = new ToolStrip();
            toolStripSave = new ToolStripButton();
            toolStripCancel = new ToolStripButton();
            toolStripClose = new ToolStripButton();
            label1 = new Label();
            txtFileName = new TextBox();
            Add = new Button();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)DGVRIGHT).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // DGVRIGHT
            // 
            DGVRIGHT.AllowUserToAddRows = false;
            DGVRIGHT.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGVRIGHT.BackgroundColor = Color.AliceBlue;
            DGVRIGHT.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVRIGHT.Columns.AddRange(new DataGridViewColumn[] { rcode, rratio, rcum_dt, rex_dt, rdps_dt, rprice,  rtrading_period, rindicator, rcreated_date, rrevised_date });
            DGVRIGHT.Location = new Point(12, 123);
            DGVRIGHT.Name = "DGVRIGHT";
            DGVRIGHT.RowTemplate.Height = 25;
            DGVRIGHT.Size = new Size(776, 403);
            DGVRIGHT.TabIndex = 0;
            // 
            // rcode
            // 
            rcode.HeaderText = "code";
            rcode.Name = "rcode";
            // 
            // rratio
            // 
            rratio.HeaderText = "ratio";
            rratio.Name = "rratio";
            // 
            // rcum_dt
            // 
            rcum_dt.HeaderText = "cum_dt";
            rcum_dt.Name = "rcum_dt";
            // 
            // rex_dt
            // 
            rex_dt.HeaderText = "ex_dt";
            rex_dt.Name = "rex_dt";
            // 
            // rdps_dt
            // 
            rdps_dt.HeaderText = "dps_dt";
            rdps_dt.Name = "rdps_dt";
            // 
            // rprice
            // 
            rprice.HeaderText = "price";
            rprice.Name = "rprice";
            // 
            // rtrading_period
            // 
            rtrading_period.HeaderText = "shares";
            rtrading_period.Name = "rtrading_period";
            // 
            // rindicator
            // 
            rindicator.HeaderText = "trading_period";
            rindicator.Name = "rindicator";
            // 
            // rcreated_date
            // 
            rcreated_date.HeaderText = "created_date";
            rcreated_date.Name = "rcreated_date";
            // 
            // rrevised_date
            // 
            rrevised_date.HeaderText = "revised_date";
            rrevised_date.Name = "rrevised_date";
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
            // FrmRIGHT
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
            Controls.Add(DGVRIGHT);
            Name = "FrmRIGHT";
            StartPosition = FormStartPosition.CenterParent;
            Text = "RIGHT";
            ((System.ComponentModel.ISupportInitialize)DGVRIGHT).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DGVRIGHT;
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