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
    public partial class frmProduct : Form
    {
        public frmProduct()
        {
            InitializeComponent();
        }
        //GLobal values
        ProductBLL proBll = new ProductBLL();
        ProductDAL proDal = new ProductDAL();
        CategoryDAL catDal = new CategoryDAL();
        userDAL useDal = new userDAL();


        private void lblTop_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void frmProduct_Load(object sender, EventArgs e)
        {
            //Creating Data Table to hold the Categories from Database
            DataTable CategoriesDT = catDal.SelectCategory();
            // specify DataSource for Category ComboBox
            cmbCategory.DataSource = CategoriesDT;
            //Specify Display Member and value Member for ComboBox
            cmbCategory.DisplayMember = "title";
            cmbCategory.ValueMember = "title";

            //Load all the Products in the data grid view
            DataTable dt = proDal.SelectProduct();
            dGVProducts.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Get All values from Product Form
            proBll.name = txtName.Text;
            proBll.category = cmbCategory.Text;
            proBll.description = txtDescription.Text;
            proBll.rate = decimal.Parse(txtRate.Text);
            proBll.qty = 0;
            proBll.added_date = DateTime.Now;
            //Getting hte UserName of logged in user
            string loggedUsr = frmLogin.LoggedInUserName;
            UserBll usrBll = useDal.GetIDFromUsername(loggedUsr);
            proBll.added_by = usrBll.id;

            bool success = proDal.InsertProduct(proBll);
            if (success == true)
            {
                MessageBox.Show("Adding  Product SUCCESSFULLY");
                Clear();

                // Refresh The DataGRID vieww

                DataTable dt = proDal.SelectProduct();
                dGVProducts.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed!!!! ADDING  Product");
            }



        }

        private void Clear()
        {
            txtProductID.Text = "";
            txtName.Text = "";
            txtSearch.Text = "";
            txtDescription.Text = "";
            txtRate.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
             proBll.Id = int.Parse(txtProductID.Text);
            proBll.name = txtName.Text;
            proBll.category = cmbCategory.Text;
            proBll.description = txtDescription.Text;
            proBll.added_date = DateTime.Now;
            proBll.rate = decimal.Parse(txtRate.Text);

            //Getting id in the added by field
            string LoggedUser = frmLogin.LoggedInUserName;
            UserBll usr = useDal.GetIDFromUsername(LoggedUser);
             proBll.added_by = usr.id;

            //now Update and Check
            bool success = proDal.UpdateProduuct(proBll);
            if (success == true)
            {
                MessageBox.Show("SuccesFul Update");
                Clear();
                //Write the code to Display all the  Products
                DataTable dt = proDal.SelectProduct();
                dGVProducts.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failled!!!!! to Update");
            }
        }

        private void dGVProducts_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Finding the row Index OF the ROW Cliccked On DataGrid
            int rowIndex = e.RowIndex;
            txtProductID.Text = dGVProducts.Rows[rowIndex].Cells[0].Value.ToString();
            txtName.Text = dGVProducts.Rows[rowIndex].Cells[1].Value.ToString();
            cmbCategory.Text = dGVProducts.Rows[rowIndex].Cells[2].Value.ToString();
            txtDescription.Text = dGVProducts.Rows[rowIndex].Cells[3].Value.ToString();
            txtRate.Text = dGVProducts.Rows[rowIndex].Cells[4].Value.ToString();



        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            // get the id of  Products which we ant to Delete
            proBll.Id = int.Parse(txtProductID.Text);
            //Cerating bool Variable to Delete The  Product
            bool success = proDal.DeleteProduct(proBll);

            if (success == true)
            {
                MessageBox.Show(" Product DELETED Successfully");
                Clear();
                //Refreshing DataGrid View
                DataTable dt = proDal.SelectProduct();
                dGVProducts.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed to Delete  Product");
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Get the KEyWord first
            string keywords = txtSearch.Text;
            if (keywords != null)
            {
                // Use Search MEthod to Search Products
                DataTable dt = proDal.Search(keywords);
                dGVProducts.DataSource = dt;
            }
            else
            {
                DataTable dt = proDal.SelectProduct();
                 dGVProducts.DataSource = dt;
            }
        }
    }
}

