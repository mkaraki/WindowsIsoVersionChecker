using WindowsIsoVersionChecker;

namespace WindowsIsoVersionChecker.GUI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            if (ofd_iso.ShowDialog() == DialogResult.OK)
                tbox_path.Text = ofd_iso.FileName;
        }

        private void btn_browsedir_Click(object sender, EventArgs e)
        {
            if (fbd_dir.ShowDialog() == DialogResult.OK)
                tbox_path.Text = fbd_dir.SelectedPath;
        }

        private async void btn_analyze_Click(object sender, EventArgs e)
        {
            lbl_result.Text = "Analyzing";

            string fpath = tbox_path.Text;

            btn_analyze.Enabled = false;
            btn_browse.Enabled = false;
            btn_browsedir.Enabled = false;
            tbox_path.Enabled = false;

            Extractor extractor = new();


            try
            {
                if (File.Exists(fpath))
                {
                    await Task.Run(() => extractor.ExtractFromIso(fpath));
                }
                else if (Directory.Exists(fpath))
                {
                    await Task.Run(() => extractor.ExtractFromDirectory(fpath));
                }
                else
                {
                    Console.WriteLine("No file/directory selected");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Windows ISO Version Checker", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btn_analyze.Enabled = true;
            btn_browse.Enabled = true;
            btn_browsedir.Enabled = true;
            tbox_path.Enabled = true;

            if (extractor.ProductName == null)
            { 
                lbl_result.Text = "Standby";
                return;
            }

            lbl_result.Text = $"Product Name: {extractor.ProductName}";
            
            if (extractor.Architectures.Length > 0)
            { 
                lbl_result.Text += "\nArchitecture: ";
                foreach (var i in extractor.Architectures)
                    lbl_result.Text += i + ' ';
            }

            if (extractor.ProductVersion != null)
                lbl_result.Text += $"\nVersion: {extractor.ProductVersion}";

            if (extractor.Build != null)
                lbl_result.Text += $"\nBuild: {extractor.Build}";

            if (extractor.BuildInfo != null)
                lbl_result.Text += $"\nBuildLabEx: {extractor.BuildInfo}";
        }
    }
}