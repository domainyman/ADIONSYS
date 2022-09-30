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

namespace ADIONSYS.Plugin.Setting.Upload
{
    public partial class UploadForm : Form
    {
        public UploadForm()
        {
            InitializeComponent();
        }

        private void FolderBrowserDialog_HelpRequest(object sender, EventArgs e)
        {

        }

        private void BtnPath_Click(object sender, EventArgs e)
        {

            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.textPath.Text = OpenFileDialog.FileName;
            }
        }

    }
}
