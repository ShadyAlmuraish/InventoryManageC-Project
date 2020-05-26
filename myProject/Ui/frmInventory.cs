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
    public partial class frmInventory : Form
    {
        public frmInventory()
        {
            InitializeComponent();
        }
        CategoryDAL cateDal = new CategoryDAL();
        ProductDAL proDal = new ProductDAL();

        private void frmInventory_Load(object sender, EventArgs e)
        {
            //Dispaly Categories DAL
            DataTable catdt = cateDal.SelectCategory();
            cmbCategory.DataSource = catdt;

            // give the value member
            cmbCategory.DisplayMember = "title";
            cmbCategory.ValueMember = "title";

            //Display All Product  In datagrid view

            DataTable prodt =proDal.SelectProduct();
            dgvInventory.DataSource = prodt;


        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Display All the Products BasedOn Selected Category
            string category = cmbCategory.Text;
            DataTable dt = proDal.DisplayProductBasedonCategory(category);
            dgvInventory.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Display all Products When This Button Is Clicked
            DataTable dt = proDal.SelectProduct();
            dgvInventory.DataSource = dt;

        }
    }
}
