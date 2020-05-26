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
    public partial class UserDashBoard : Form
    {
        public UserDashBoard()
        {
            InitializeComponent();
        }

        // set a public static method to specify whether  the form is purchase or sales
        public static string transactionType;

        private void UserDashBoard_Load(object sender, EventArgs e)
        {
            lblLoggedinUser.Text = frmLogin.LoggedInUserName;
        }

        private void salesFormsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //set the value of the transaction type String
            transactionType = "Sales";

            frmPurchaseSales Sales = new frmPurchaseSales();
            Sales.Show();

            
        }

        private void purhcaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //set the value of the transaction type String
            transactionType = "Purchase";

            frmPurchaseSales purchase = new frmPurchaseSales();
            purchase.Show();

           
        }

        private void UserDashBoard_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomer customer = new frmCustomer();
            customer.Show();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInventory frmInvent = new frmInventory();
            frmInvent.Show();
        }
    }
}
