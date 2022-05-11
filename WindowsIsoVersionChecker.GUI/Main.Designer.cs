namespace WindowsIsoVersionChecker.GUI
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_analyze = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_browse = new System.Windows.Forms.Button();
            this.tbox_path = new System.Windows.Forms.TextBox();
            this.btn_browsedir = new System.Windows.Forms.Button();
            this.lbl_result = new System.Windows.Forms.Label();
            this.ofd_iso = new System.Windows.Forms.OpenFileDialog();
            this.fbd_dir = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btn_analyze, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_result, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(462, 322);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btn_analyze
            // 
            this.btn_analyze.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_analyze.Location = new System.Drawing.Point(3, 38);
            this.btn_analyze.Name = "btn_analyze";
            this.btn_analyze.Size = new System.Drawing.Size(456, 29);
            this.btn_analyze.TabIndex = 0;
            this.btn_analyze.Text = "Analyze";
            this.btn_analyze.UseVisualStyleBackColor = true;
            this.btn_analyze.Click += new System.EventHandler(this.btn_analyze_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.Controls.Add(this.btn_browse, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbox_path, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_browsedir, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(456, 29);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btn_browse
            // 
            this.btn_browse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_browse.Location = new System.Drawing.Point(299, 3);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(74, 23);
            this.btn_browse.TabIndex = 0;
            this.btn_browse.Text = "Browse ISO";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // tbox_path
            // 
            this.tbox_path.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbox_path.Location = new System.Drawing.Point(3, 3);
            this.tbox_path.Name = "tbox_path";
            this.tbox_path.Size = new System.Drawing.Size(290, 23);
            this.tbox_path.TabIndex = 1;
            // 
            // btn_browsedir
            // 
            this.btn_browsedir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_browsedir.Location = new System.Drawing.Point(379, 3);
            this.btn_browsedir.Name = "btn_browsedir";
            this.btn_browsedir.Size = new System.Drawing.Size(74, 23);
            this.btn_browsedir.TabIndex = 2;
            this.btn_browsedir.Text = "Browse Dir";
            this.btn_browsedir.UseVisualStyleBackColor = true;
            this.btn_browsedir.Click += new System.EventHandler(this.btn_browsedir_Click);
            // 
            // lbl_result
            // 
            this.lbl_result.AutoSize = true;
            this.lbl_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_result.Location = new System.Drawing.Point(3, 70);
            this.lbl_result.Name = "lbl_result";
            this.lbl_result.Size = new System.Drawing.Size(456, 252);
            this.lbl_result.TabIndex = 2;
            this.lbl_result.Text = "Standby";
            // 
            // ofd_iso
            // 
            this.ofd_iso.FileName = "ofd_file";
            this.ofd_iso.Filter = "ISO file|*.iso|All files|*";
            // 
            // fbd_dir
            // 
            this.fbd_dir.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 322);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Main";
            this.Text = "Windows ISO Version Checker";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button btn_analyze;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btn_browse;
        private TextBox tbox_path;
        private Button btn_browsedir;
        private OpenFileDialog ofd_iso;
        private FolderBrowserDialog fbd_dir;
        private Label lbl_result;
    }
}