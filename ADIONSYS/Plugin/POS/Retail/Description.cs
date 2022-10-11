using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADIONSYS.Plugin.POS.Retail
{
    public partial class Description : Form
    {
        public Description()
        {
            InitializeComponent();
        }
        public List<string>? List { set; get; }
        private void BtnImport_Click(object sender, EventArgs e)
        {
            if (textSN.Text != string.Empty)
            {
                List<string> list_in = new List<string>();
                list_in.AddRange(textSN.Lines.ToList());
                list_in.RemoveAll(s => s == string.Empty);
                list_in.RemoveAll(s => s == null);
                List = list_in;
                this.Close();
            }
        }
    }
}
