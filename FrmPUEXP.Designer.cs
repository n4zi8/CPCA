namespace CPCA
{
    partial class FrmPUEXP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPUEXP));
            DGVPUEXP = new DataGridView();
            pcode = new DataGridViewTextBoxColumn();
            pday = new DataGridViewTextBoxColumn();
            pdate = new DataGridViewTextBoxColumn();
            ptime = new DataGridViewTextBoxColumn();
            pdatetime = new DataGridViewTextBoxColumn();
            pvenue = new DataGridViewTextBoxColumn();
            pcreated_date = new DataGridViewTextBoxColumn();
            prevised_date = new DataGridViewTextBoxColumn();
            toolStrip1 = new ToolStrip();
            toolStripSave = new ToolStripButton();
            toolStripCancel = new ToolStripButton();
            toolStripClose = new ToolStripButton();
            label1 = new Label();
            txtFileName = new TextBox();
            Add = new Button();
            ((System.ComponentModel.ISupportInitialize)DGVPUEXP).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // DGVPUEXP
            // 
            DGVPUEXP.AllowUserToAddRows = false;
            DGVPUEXP.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGVPUEXP.BackgroundColor = Color.AliceBlue;
            DGVPUEXP.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVPUEXP.Columns.AddRange(new DataGridViewColumn[] { pcode, pday, pdate, ptime, pdatetime, pvenue, pcreated_date, prevised_date });
            DGVPUEXP.Location = new Point(12, 123);
            DGVPUEXP.Name = "DGVPUEXP";
            DGVPUEXP.RowTemplate.Height = 25;
            DGVPUEXP.Size = new Size(776, 403);
            DGVPUEXP.TabIndex = 0;
            // 
            // pcode
            // 
            pcode.HeaderText = "code";
            pcode.Name = "pcode";
            // 
            // pday
            // 
            pday.HeaderText = "day";
            pday.Name = "pday";
            // 
            // pdate
            // 
            pdate.HeaderText = "date";
            pdate.Name = "pdate";
            // 
            // ptime
            // 
            ptime.HeaderText = "time";
            ptime.Name = "ptime";
            // 
            // pdatetime
            // 
            pdatetime.HeaderText = "datetime";
            pdatetime.Name = "pdatetime";
            // 
            // pvenue
            // 
            pvenue.HeaderText = "venue";
            pvenue.Name = "pvenue";
            // 
            // pcreated_date
            // 
            pcreated_date.HeaderText = "created_date";
            pcreated_date.Name = "pcreated_date";
            // 
            // prevised_date
            // 
            prevised_date.HeaderText = "revised_date";
            prevised_date.Name = "prevised_date";
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
            // FrmPUEXP
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(800, 538);
            Controls.Add(Add);
            Controls.Add(txtFileName);
            Controls.Add(label1);
            Controls.Add(toolStrip1);
            Controls.Add(DGVPUEXP);
            Name = "FrmPUEXP";
            StartPosition = FormStartPosition.CenterParent;
            Text = "PUEXP";
            ((System.ComponentModel.ISupportInitialize)DGVPUEXP).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DGVPUEXP;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripSave;
        private ToolStripButton toolStripCancel;
        private ToolStripButton toolStripClose;
        private Label label1;
        private TextBox txtFileName;
        private Button Add;
    }
}