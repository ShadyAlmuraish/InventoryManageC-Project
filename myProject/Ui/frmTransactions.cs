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
    public partial class frmTransactions : Form
    {
        public frmTransactions()
        {
            InitializeComponent();
        }
        TransactionDAL transdal = new TransactionDAL();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataTable dt = transdal.DisplayAllTransaction();
            dgvTransactions.DataSource = dt;
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTransactions_Load(object sender, EventArgs e)
        {
            DataTable dt = transdal.DisplayAllTransaction();
            dgvTransactions.DataSource = dt;
        }

        private void cmbTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get value from the ComboBox
            string type = cmbTransactionType.Text;
            DataTable dt = transdal.DisplayTransactionType(type);
            dgvTransactions.DataSource = dt;
        }

        private void dgvTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
