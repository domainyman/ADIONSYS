using ADIONSYS.Tool;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ADIONSYS.Plugin.POS.Warehose.Storage.Transfer
{
    public partial class BatchImport : Form
    {

        public int Row;
        public int lines = 1;
        public BatchImport(int tableRowCount)
        {
            InitializeComponent();
            Row = tableRowCount;

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void textSN_TextChanged(object sender, EventArgs e)
        {
            lines = textSN.Lines.Count();
            if (lines > Row)
            {
                MessageInfo MessageBox_text = new MessageInfo("Out Of Input Range ");
                MessageBox_text.ShowDialog();
                SendKeys.Send("{BACKSPACE}");
            }

        }
    }
}
