using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using PassMaster;
using PassMaster.Properties;


namespace PassMaster
{
    public partial class frmMain : Form
    {
        public frmMain()
        {

            InitializeComponent();
            Initialize.checkTheme(this);
        }

        //function runs when main form reaches loading stage
        private void frmMain_Load(object sender, EventArgs e)
        {
            //binds the datagrid view to the dataset

            DBManager.createTable();
            //refreshes the datagrid to show newest information
            this.refreshDG();

        }

        //triggers on Button Add, creates new Add form and displays it
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAdd temp = new frmAdd(this);
            temp.Show();

        }

        //delete's selected datagrid object whenn delete button is clicked
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //selects the first value which is id
            try {
                int selectedRowIndex = dgPassword.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgPassword.Rows[selectedRowIndex];
                string id = selectedRow.Cells[0].Value.ToString();

                if (MessageBox.Show("Are you sure you want to delete?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    DBManager.DeleteId(id);
                //refreshes datagrid view
                this.refreshDG();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select a valid record to delete!", "Error");
                Console.WriteLine(ex);
            }
        }


        //rebinds data source to table
        public void refreshDG()
        {
            //creates dataset
            DBManager.createDS();
            dgPassword.AutoGenerateColumns = true;
            DataTable table = new DataTable();
            SQLiteDataAdapter temp = DBManager.DataAdapter;
            temp.Fill(table);
            BindingSource source = new BindingSource();
            source.DataSource = table;
            dgPassword.DataSource = source;
        }

        //activates when edit button is clicked, sends selected datagrid information to a new form
        private void btnEdit_Click(object sender, EventArgs e)
        {
            //catches the case when there is no id to select
            try { 
            int selectedrowindex = dgPassword.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgPassword.Rows[selectedrowindex];   
            string id = selectedRow.Cells[0].Value.ToString();
            string username = selectedRow.Cells[1].Value.ToString();
            string password = selectedRow.Cells[2].Value.ToString();
            string website = selectedRow.Cells[3].Value.ToString();
            frmEdit temp = new frmEdit(this, id, username, password, website);
            temp.Show();
            }

            catch(Exception ex)
            {
                MessageBox.Show("Please select a valid record to edit!", "Error");
                Console.WriteLine(ex);
            }
            
        }
        //exit button for toolstrip menu, exits application
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //about button for toolstrip menu, displays about form
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutBox about = new aboutBox();
            about.Show();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSettings setting = new frmSettings();
            setting.Show();
        }
    }
    }


