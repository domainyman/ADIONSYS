using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADIONSYS.Tool
{
    public partial class MessageInfo : Form
    {
        public MessageInfo(string text)
        {
            InitializeComponent();
            LBtextMessage.Text = text;
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
