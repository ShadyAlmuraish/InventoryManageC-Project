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
    public partial class AdminDashBoard : Form
    {
        public AdminDashBoard()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

      

        private void panelfooter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUser user = new frmUser();
            user.Show();
        }

        private void AdminDashBoard_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
        }

        private void AdminDashBoard_Load(object sender, EventArgs e)
        {
            lblLoggedinUser.Text = frmLogin.LoggedInUserName;
        }

        private void catToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCatagories categ = new frmCatagories();
            categ.Show();
           
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduct product = new frmProduct();
            product.Show();
        }

        private void cutomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomer cutmomer = new frmCustomer();
            cutmomer.Show();
        }

        private void transactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTransactions transaction = new frmTransactions();
            transaction.Show();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInventory frmInvent = new frmInventory();
            frmInvent.Show();
        }
    }
}
