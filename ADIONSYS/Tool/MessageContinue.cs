using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ADIONSYS.Tool
{
    public partial class MessageContinue : Form
    {
        public MessageContinue(string text)
        {
            InitializeComponent();
            LBtextMessage.Text = text;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnok_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
