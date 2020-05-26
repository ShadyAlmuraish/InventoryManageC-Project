using myProject.BLL;
using myProject.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myProject.Ui
{
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }
        CustomerBLL cutomrbll = new CustomerBLL();
        CustomerDAL customrdal = new CustomerDAL();
        userDAL userdal = new userDAL();
        private void frmCustomer_Load(object sender, EventArgs e)
        {
            DataTable DT = customrdal.SelectCustomer();
            dgvCustomer.DataSource = DT;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Getting data from UI

            cutomrbll.type = cmbCustomerType.Text;
            cutomrbll.email = txtEmail.Text;
            cutomrbll.name = txtName.Text;
            cutomrbll.contact = txtContact.Text;
            cutomrbll.address = txtAddress.Text;
            cutomrbll.added_date = DateTime.Now;

            //Getting UserName of the loggedIn User
            string loggedUser = frmLogin.LoggedInUserName;

            //Getting the UserID basedon the UserNAme
           UserBll usr = userdal.GetIDFromUsername(loggedUser);
            cutomrbll.added_by = usr.id;

            //inserting Data into DATABASE
            bool success = customrdal.InsertCustomer(cutomrbll);
            //if the data SuccessFully inserted then Success will be True
            if (success == true)
            {
                MessageBox.Show("Customer SuccessFully Created");
                clear();
            }
            else
            {
                MessageBox.Show("Failed!!!! to Add Customer");
            }
            //Refreshing Data Grid View
            DataTable DT = customrdal.SelectCustomer();
           dgvCustomer.DataSource = DT;

        }

        private void clear()
        {
            txtCustomID.Text = "";
            txtName.Text = "";
            cmbCustomerType.Text = "";
            txtEmail.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
            txtSearch.Text = "";
        }

        private void dgvCustomer_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Geet index of the paticular Row
            int rowIndex = e.RowIndex;
            txtCustomID.Text = dgvCustomer.Rows[rowIndex].Cells[0].Value.ToString();
           cmbCustomerType.Text = dgvCustomer.Rows[rowIndex].Cells[1].Value.ToString();
            txtName.Text = dgvCustomer.Rows[rowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dgvCustomer.Rows[rowIndex].Cells[3].Value.ToString();
            txtContact.Text = dgvCustomer.Rows[rowIndex].Cells[4].Value.ToString();
            txtAddress.Text = dgvCustomer.Rows[rowIndex].Cells[5].Value.ToString();
       
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            cutomrbll.id = int.Parse(txtCustomID.Text);
            cutomrbll.type = cmbCustomerType.Text;
            cutomrbll.email = txtEmail.Text;
            cutomrbll.name = txtName.Text;
            cutomrbll.contact = txtContact.Text;
            cutomrbll.address = txtAddress.Text;
            cutomrbll.added_date = DateTime.Now;

            //Getting UserName of the loggedIn User
            string loggedUser = frmLogin.LoggedInUserName;

            //Getting the UserID basedon the UserNAme
            UserBll usr = userdal.GetIDFromUsername(loggedUser);
            cutomrbll.added_by = usr.id;

            //Updating data in database 
            bool success = customrdal.UpdateCustomer(cutomrbll);
            if (success == true)
            {
                MessageBox.Show("Successfuly Updating Data  ");
                clear();
                //Refressing DataGGRid View
                DataTable DT = customrdal.SelectCustomer();
                dgvCustomer.DataSource = DT;

            }
            else
            {
                MessageBox.Show("Failled!!!! TO Update Data");
            }
           

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Getting  User ID for Deleted A row
            cutomrbll.id = int.Parse(txtCustomID.Text);

            bool success = customrdal.DeleteCustomer(cutomrbll);
            // Data is Deleted Successfully Success is True

            if (success == true)
            {
                MessageBox.Show("Successfuly  Deleting Row  ");
                

            }
            else
            {
                MessageBox.Show("Failled!!!! TO  Delete Data");
            }
            //Refressing DataGGRid View
            clear();
            DataTable DT = customrdal.SelectCustomer();
            dgvCustomer.DataSource = DT;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //get the keyword from text box

            string keyword = txtSearch.Text;
            if(keyword!=null)
            {
                // Search
                DataTable dt = customrdal.SearchCustomer(keyword);
                dgvCustomer.DataSource = dt;
            }
            else
            {
                DataTable dt = customrdal.SelectCustomer();
                dgvCustomer.DataSource = dt;
            }
        }
    }
}
