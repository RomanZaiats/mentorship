using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LateBindingWordSaveAs
{
    public partial class MainForm : Form
    {
        private object _wordApplication = null;
        private object _wordDocument = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            WordWrapper automation = new WordWrapper();
            if (_wordApplication == null)
            {
                _wordApplication = automation.CreateWordApplication();
            }
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All word documents(*.docx)|*.docx|Old word documents(*.doc)|*.doc";
            if (DialogResult.OK == dlg.ShowDialog(this))
            {
                if (File.Exists(dlg.FileName))
                {
                    if (_wordDocument != null)
                    {
                        automation.CloseWordDoc(_wordDocument, true);
                    }
                    _wordDocument = automation.CreateWordDoc(
                        dlg.FileName, _wordApplication, false);
                    txtFileName.Text = dlg.FileName;
                }
            }
        }

        private void SaveAsButton_Click(object sender, EventArgs e)
        {
            new WordWrapper().SaveAs(_wordDocument, savePathTextBox.Text, resultNameTextBox.Text, (Formats)formatsList.SelectedItem);
            MessageBox.Show("Done!");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_wordDocument != null)
            {
                new WordWrapper().CloseWordDoc(_wordDocument, true);
            }
            if (_wordApplication != null)
            {
                new WordWrapper().CloseWordApp(_wordApplication);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            {
                foreach (var item in Enum.GetValues(typeof(Formats)))
                {
                    formatsList.Items.Add(item);
                }
            }
        }

        private void BrowseSaveButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (DialogResult.OK == dlg.ShowDialog(this))
            {
                if (Directory.Exists(dlg.SelectedPath))
                {
                    savePathTextBox.Text = dlg.SelectedPath;
                }
            }
        }
    }
}
