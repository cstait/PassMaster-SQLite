
using System.Windows.Forms;
using PassMaster.Properties;

namespace PassMaster
{
    public partial class frmEdit : Form
    {
        private PassMaster.frmMain caller;
        private string id;


        public frmEdit(PassMaster.frmMain frmMain, string id, string username, string password, string website)
        {
            InitializeComponent();
            Initialize.checkTheme(this);
            caller = frmMain;
            this.id = id;
            txtUser.Text = username;
            txtPass.Text = password;
            txtWeb.Text = website;
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            //relays information to Database manager to insert text;

            string username = txtUser.Text;
            string password = txtPass.Text;
            string website = txtWeb.Text;

            //shows confirmation box to user
            if (MessageBox.Show("Are you sure you want to edit?", "Confirm edit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            PassMaster.DBManager.UpdateTable(id, username, password, website);


            //refreshes datagrid
            caller.refreshDG();
            this.Close();

        }
    }
}
