using myProject.BLL;
using myProject.DAL;
using myProject.Ui;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myProject
{
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }
        UserBll userBl = new UserBll();
        userDAL userDl = new userDAL();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void txtUserID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {   //Getting UserName of the loggedIn User
            string loggedUser=frmLogin.LoggedInUserName;

            //Getting the UserID basedon the UserNAme
            UserBll usr = userDl.GetIDFromUsername(loggedUser);

            //Getting data from UI
            userBl.firstName = txtFirstName.Text;
            userBl.lastName = txtLastName.Text;
            userBl.email = txtEmail.Text;
            userBl.userName = txtUserName.Text;
            userBl.passWord = txtpassword.Text;
            userBl.Contact = txtContact.Text;
            userBl.address = txtAdress.Text;
            userBl.gender = cmbGender.Text;
            userBl.user_type = cmbUserType.Text;
            userBl.addedDate = DateTime.Now;
            userBl.addedBy =usr.id ;

            //inserting Data into DATABASE
            bool success = userDl.Insert(userBl);
            //if the data SuccessFully inserted then Success will be True
            if (success == true)
            {
                MessageBox.Show("User SuccessFully Created");
                clear();
            }
            else
            {
                MessageBox.Show("Failed!!!! to Add User");
            }
            //Refreshing Data Grid View
            DataTable DT = userDl.Select();
            dgvUsers.DataSource = DT;

        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            DataTable DT = userDl.Select();
            dgvUsers.DataSource = DT;
        }

        private void clear()
        {
            txtUserID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtUserName.Text = "";
            txtpassword.Text = "";
            txtContact.Text = "";
            txtAdress.Text = "";
            cmbGender.Text = "";
            cmbUserType.Text = "";
        }

        private void dgvUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Geet index of the paticular Row
            int rowIndex = e.RowIndex;
            txtUserID.Text = dgvUsers.Rows[rowIndex].Cells[0].Value.ToString();
            txtFirstName.Text= dgvUsers.Rows[rowIndex].Cells[1].Value.ToString();
            txtLastName.Text = dgvUsers.Rows[rowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dgvUsers.Rows[rowIndex].Cells[3].Value.ToString();
            txtUserName.Text = dgvUsers.Rows[rowIndex].Cells[4].Value.ToString();
            txtpassword.Text = dgvUsers.Rows[rowIndex].Cells[5].Value.ToString();
            txtContact.Text = dgvUsers.Rows[rowIndex].Cells[6].Value.ToString();
            txtAdress.Text = dgvUsers.Rows[rowIndex].Cells[7].Value.ToString();
            cmbGender.Text = dgvUsers.Rows[rowIndex].Cells[8].Value.ToString();
            cmbUserType.Text = dgvUsers.Rows[rowIndex].Cells[9].Value.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Get the Values From User UI
            userBl.id = Convert.ToInt32(txtUserID.Text);
            userBl.firstName = txtFirstName.Text;
            userBl.lastName = txtLastName.Text;
            userBl.email = txtEmail.Text;
            userBl.userName = txtUserName.Text;
            userBl.passWord = txtpassword.Text;
            userBl.Contact = txtContact.Text;
            userBl.address = txtAdress.Text;
            userBl.gender = cmbGender.Text;
            userBl.user_type = cmbUserType.Text;
            userBl.addedDate = DateTime.Now;
            userBl.addedBy = 1;

            //Updating data in database 
            bool success = userDl.Update(userBl);
            if(success==true)
            {
                MessageBox.Show("Successfuly Updating Data  ");

            }
            else
            {
                MessageBox.Show("Failled!!!! TO Update Data");
            }
            //Refressing DataGGRid View
            DataTable DT = userDl.Select();
            dgvUsers.DataSource = DT;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Getting  User ID for Deleted A row
            userBl.id = Convert.ToInt32(txtUserID.Text);

            bool success = userDl.Delete(userBl);
            // Data is Deleted Successfully Success is True

            if(success==true)
            {
                MessageBox.Show("Successfuly  Deleting Row  ");

            }
            else
            {
                MessageBox.Show("Failled!!!! TO  Delete Data");
            }
            //Refressing DataGGRid View
            DataTable DT = userDl.Select();
            dgvUsers.DataSource = DT;

        }

        private void txtSeach_TextChanged(object sender, EventArgs e)
        {
            //GET KeyWORD FORM TEXT BOOks
            string keywords = txtSeach.Text;

            if(keywords!=null)
            {
                //SHow USer BAsed ON keyWords
                DataTable DT =  userDl.Saerch(keywords);
                dgvUsers.DataSource = DT;
            }
            else
            {
                //ELSE SHOW ALL USERS
                DataTable DT = userDl.Select();
                dgvUsers.DataSource = DT;
                 
            }
        }
    }
}
