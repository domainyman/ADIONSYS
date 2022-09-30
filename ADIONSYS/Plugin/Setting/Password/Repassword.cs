using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADIONSYS.Plugin.Setting
{
    public partial class Repassword : Form
    {
        public Repassword()
        {
            InitializeComponent();
        }


        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            if (textoldpassword.Text != string.Empty && textnewpassword.Text != string.Empty && textRePassword.Text != string.Empty)
            {
                try
                {
                    if (textoldpassword.Text == ApplicationSetting.Default.Admain_Password)
                    {
                        if (textnewpassword.Text == textRePassword.Text)
                        {
                            ApplicationSetting.Default.Admain_Password = textRePassword.Text;
                            ApplicationSetting.Default.Save();
                            this.LBMassegaBox.Text = "Password Changed!";
                            this.LBMassegaBox.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
                            this.LBMassegaBox.Image = global::ADIONSYS.Properties.Resources.check_mark_3_24;
                        }
                    }
                    else
                    {
                        this.LBMassegaBox.Text = "Not a vaild infomation!";
                        this.LBMassegaBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                        this.LBMassegaBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
                    }
                }
                catch
                {

                }
            }
        }

        private void Repassword_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
