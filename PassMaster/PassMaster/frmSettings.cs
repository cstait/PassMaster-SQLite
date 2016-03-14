using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PassMaster.Properties;

namespace PassMaster
{
    //this form is the options menu that saves user settings throughout each application useage
    public partial class frmSettings : Form
    {
        private bool reqRestart = false;

        public frmSettings()
        {
            InitializeComponent();
            Initialize.checkTheme(this);
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            //changes the default value of the combo box depending on the current user setting
            if (Settings.Default["Theme"].ToString().Equals("0"))
                cmbTheme.Text = "White";
            else if ((Settings.Default["Theme"].ToString().Equals("1")))
                cmbTheme.Text = "Black";
        }

        //Apply button that applies the currently selected settings to the application options
        private void btnApply_Click(object sender, EventArgs e)
        {

            changeTheme();
            if (reqRestart)
                MessageBox.Show("The application requires a restart before the changes take full effect", "Notice");
            btnOk.Enabled = true;
        }

        //function that changes the theme based on the combo box value
        private void changeTheme()
        {
            if (cmbTheme.Text == "White")
                Settings.Default.Theme = 0;
            else if (cmbTheme.Text == "Black")
                Settings.Default.Theme = 1;

            MessageBox.Show(Settings.Default.Theme.ToString());
            Settings.Default.Save();
            reqRestart = true;
        }

        //closes the application
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //closes the application
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

