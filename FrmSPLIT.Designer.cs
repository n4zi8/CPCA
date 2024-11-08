//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CPCA
{
    partial class FrmSPLIT
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
            DGVSPLIT = new DataGridView();
            scode = new DataGridViewTextBoxColumn();
            sprev_price = new DataGridViewTextBoxColumn();
            scurr_price = new DataGridViewTextBoxColumn();
            sratio = new DataGridViewTextBoxColumn();
            shand_sks = new DataGridViewTextBoxColumn();
            snew_sks = new DataGridViewTextBoxColumn();
            strd_dt = new DataGridViewTextBoxColumn();
            screated_date = new DataGridViewTextBoxColumn();
            srevised_date = new DataGridViewTextBoxColumn();
            toolStrip1 = new ToolStrip();
            toolStripSave = new ToolStripButton();
            toolStripCancel = new ToolStripButton();
            toolStripClose = new ToolStripButton();
            label1 = new Label();
            txtFileName = new TextBox();
            Add = new Button();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)DGVSPLIT).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // DGVRVERS
            // 
            DGVSPLIT.AllowUserToAddRows = false;
            DGVSPLIT.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGVSPLIT.BackgroundColor = Color.AliceBlue;
            DGVSPLIT.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVSPLIT.Columns.AddRange(new DataGridViewColumn[] { scode, sprev_price, scurr_price, sratio, shand_sks, snew_sks, strd_dt, screated_date, srevised_date });
            DGVSPLIT.Location = new Point(12, 123);
            DGVSPLIT.Name = "DGVSPLIT";
            DGVSPLIT.RowTemplate.Height = 25;
            DGVSPLIT.Size = new Size(776, 403);
            DGVSPLIT.TabIndex = 0;
            // 
            // rcode
            // 
            scode.HeaderText = "code";
            scode.Name = "scode";
            // 
            // rold_ratio_share
            // 
            sprev_price.HeaderText = "prev_price";
            sprev_price.Name = "sprev_price";
            // 
            // rnew_ratio_share
            // 
            scurr_price.HeaderText = "curr_price";
            scurr_price.Name = "scurr_price";
            // 
            // rnew_par_value
            // 
            sratio.HeaderText = "ratio";
            sratio.Name = "sratio";
            // 
            // rtrade_dt
            // 
            shand_sks.HeaderText = "hand_sks";
            shand_sks.Name = "shand_sks";
            // 
            // rrecord_dt
            // 
            snew_sks.HeaderText = "new_sks";
            snew_sks.Name = "snew_sks";
            // 
            // rshare
            // 
            strd_dt.HeaderText = "trd_dt";
            strd_dt.Name = "strd_dt";
            // 
            // rcreated_date
            // 
            screated_date.HeaderText = "created_date";
            screated_date.Name = "screated_date";
            // 
            // rrevised_date
            // 
            srevised_date.HeaderText = "revised_date";
            srevised_date.Name = "srevised_date";
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
            toolStripSave.Image = Properties.Resources.Save;
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
            toolStripCancel.Image = Properties.Resources.undo_24;
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
            toolStripClose.Image = Properties.Resources.Close;
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
            Add.Image = Properties.Resources.add30x30;
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
            // FrmSPLIT
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
            Controls.Add(DGVSPLIT);
            Name = "FrmSPLIT";
            StartPosition = FormStartPosition.CenterParent;
            Text = "SPLIT";
            ((System.ComponentModel.ISupportInitialize)DGVSPLIT).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DGVSPLIT;
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