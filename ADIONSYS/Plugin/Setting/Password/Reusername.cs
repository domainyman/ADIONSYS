using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADIONSYS.Plugin.Setting.Password
{
    public partial class Reusername : Form
    {
        public Reusername()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            if (textoldUserName.Text != string.Empty && textnewUserName.Text != string.Empty && textReUserName.Text != string.Empty)
            {
                try
                {


                    if (textoldUserName.Text == ApplicationSetting.Default.Admin_User)
                    {
                        if (textnewUserName.Text == textReUserName.Text)
                        {
                            ApplicationSetting.Default.Admin_User = textReUserName.Text;
                            ApplicationSetting.Default.Save();
                            this.LBMassegaBox.Text = "User Name Changed!";
                            this.LBMassegaBox.ForeColor = Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(190)))), ((int)(((byte)(140)))));
                            this.LBMassegaBox.Image = global::ADIONSYS.Properties.Resources.check_mark_3_24;
                        }
                        else
                        {
                            this.LBMassegaBox.Text = "Not a vaild infomation!";
                            this.LBMassegaBox.ForeColor = Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(97)))), ((int)(((byte)(106)))));
                            this.LBMassegaBox.Image = global::ADIONSYS.Properties.Resources.x_mark_24;
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
    }
}
