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
    public partial class frmCatagories : Form
    {
        public frmCatagories()
        {
            InitializeComponent();
        }
        CategoryBLL catbll = new CategoryBLL();
        CategoryDAL catdal = new CategoryDAL();
        userDAL userdal = new userDAL();

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            //Get the KEyWord first
            string keywords = txtSearch.Text;
            if(keywords!=null)
            {
                // Use Search MEthod to Search Categories
                DataTable dt = catdal.Search(keywords);
                dataGridView1.DataSource = dt;
            }
            else
            {
                DataTable dt = catdal.SelectCategory();
                dataGridView1.DataSource = dt;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //get the Values FROM CATEGORY from
            catbll.title = txtTitle.Text;
            catbll.description = txtDescription.Text;
            catbll.addedDate = DateTime.Now;

            //Getting id in the added by field
            string LoggedUser = frmLogin.LoggedInUserName;
            UserBll usr = userdal.GetIDFromUsername(LoggedUser);
            catbll.added_by = usr.id;


            bool success = catdal.InsertCategory(catbll);
            if (success==true)
            {
                MessageBox.Show("Adding Category SUCCESSFULLY");
                Clear();

                // Refresh The DataGRID vieww

                DataTable dt = catdal.SelectCategory();
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed!!!! ADDING Category");
            }

        }
        public void Clear()
        {
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtCategoryID.Text = "";
            txtSearch.Text = "";

        }

        private void frmCatagories_Load(object sender, EventArgs e)
        {
            //Write the code to Display all the Catagories
            DataTable dt = catdal.SelectCategory();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Finding the row Index OF the ROW Cliccked On DataGrid
            int rowIndex = e.RowIndex;
            txtCategoryID.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            txtTitle.Text= dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            txtDescription.Text= dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
         
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            catbll.id = int.Parse(txtCategoryID.Text);
            catbll.title = txtTitle.Text;
            catbll.description = txtDescription.Text;
            catbll.addedDate = DateTime.Now;

            //Getting id in the added by field
            string LoggedUser = frmLogin.LoggedInUserName;
            UserBll usr = userdal.GetIDFromUsername(LoggedUser);
            catbll.added_by = usr.id;

            //now Update and Check
            bool success = catdal.UpdateCategory(catbll);
            if (success == true)
            {
                MessageBox.Show("SuccesFul Update");
                Clear();
                //Write the code to Display all the Catagories
                DataTable dt = catdal.SelectCategory();
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failled!!!!! to Update");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // get the id of Cataegory which we ant to Delete
            catbll.id = int.Parse(txtCategoryID.Text);
            //Cerating bool Variable to Delete The Category
            bool success = catdal.DeleteCategory(catbll);

            if(success==true)
            {
                MessageBox.Show("CAtegory DELETED Successfully");
                Clear();
                //Refreshing DataGrid View
                DataTable dt = catdal.SelectCategory();
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed to Delete Category");
            }
        }
    }
}