using DGVPrinterHelper;
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
using System.Transactions;
using System.Windows.Forms;

namespace myProject.Ui
{
    public partial class frmPurchaseSales : Form
    {
        public frmPurchaseSales()
        {
            InitializeComponent();
        }

        CustomerDAL customerdal = new CustomerDAL();
        ProductDAL productdal = new ProductDAL();
        DataTable transactionDT = new DataTable();
        userDAL userdal = new userDAL();
        TransactionDAL transDal = new TransactionDAL();
        TransactionDetailDAL transDetailDal = new TransactionDetailDAL();
        private void pnlProduct_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnlCustomer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPurchaseSales_Load(object sender, EventArgs e)
        {
            string type = UserDashBoard.transactionType;
            //set the value of Title of the form to the respective value
            lblTop.Text = type;

            //when we load the form we need to specify the columns for our Transaction Data Table
            transactionDT.Columns.Add("Product Name");
            transactionDT.Columns.Add("Price");
            transactionDT.Columns.Add("Quantity");
            transactionDT.Columns.Add("Total");
        }

        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            //get the keyword from the text box
            string keyword = txtCustomerSearch.Text;
           
            if(keyword=="")
            {
                //clear all textBoxes
                txtContact.Text = "";
                txtAddress.Text = "";
                txtName.Text = "";
                txtEmail.Text = "";

            }
            else
            {

                CustomerBLL customerbll = customerdal.GetSellerCustomer(keyword);
                txtName.Text = customerbll.name;
                txtEmail.Text = customerbll.email;
                txtContact.Text = customerbll.contact;
                txtAddress.Text = customerbll.address;

            }
        }

        private void txtProductSearch_TextChanged(object sender, EventArgs e)
        {

            //get the keyword from the text box
            string keyword = txtProductSearch.Text;

            if (keyword == "")
            {
                //clear all textBoxes
                txtProductName.Text = "";
                txtProdcutInventory.Text = "";
                txtProductPrice.Text = "";
                txtProdcutQTY.Text = "";
                return;

            }
            else
            {

                ProductBLL productbll = productdal.GetProduct(keyword);
                txtProductName.Text = productbll.name;
                txtProdcutInventory.Text = productbll.qty.ToString();
                txtProductPrice.Text = productbll.rate.ToString();

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //get fields from the textBoxes
            string productName = txtProductName.Text;
            decimal price = decimal.Parse(txtProductPrice.Text);
            if(txtProdcutQTY.Text=="")
            {
                MessageBox.Show("First You have to Enter Quantity Field");
                return;
            }
            decimal qty = decimal.Parse(txtProdcutQTY.Text);
            decimal totalprice = price * qty;

            //get the value of the total price for the product
            decimal rowTotal = decimal.Parse(txtRowTotal.Text);
            rowTotal = totalprice + rowTotal;

            //check whether product is Selected First
            if (productName=="")
            {
                MessageBox.Show("First Select a Product ");
            }
            else
            {
                //add product to data gridView
                transactionDT.Rows.Add(productName, price, qty, totalprice);

                //show on datagridview
                dgvAddedproducts.DataSource = transactionDT;
                //display RowTotal
                txtRowTotal.Text = rowTotal.ToString();
                txtTotalPPrice.Text = rowTotal.ToString();

                //Clear he TextBoxes
                txtProductSearch.Text = "";
                txtProductName.Text = "";
                txtProdcutInventory.Text = "0.00";
                txtProductPrice.Text = "0.00";
                txtProdcutQTY.Text = "";



            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            //get the vale from  discount TextBox
            string value = txtDiscount.Text;
            decimal rowtotal = decimal.Parse(txtRowTotal.Text);
            decimal totalPrice = rowtotal;
            if (value!="0" && value!="")
            {
                //no discount is added
                //get the discount in decimal value
               
                decimal discount = decimal.Parse(txtDiscount.Text);

                //Calculate the total after entring the discount
                totalPrice = ((100 - discount) / 100) * rowtotal;
                //display 
               
                
            }

            txtTotalPPrice.Text = totalPrice.ToString();
        }
        private void txtVAT_TextChanged(object sender, EventArgs e)
        {
            string check = txtVAT.Text;
            decimal previousTotalPrice = decimal.Parse(txtTotalPPrice.Text);
            if (check!="0"&& check!="")
            {
               
                decimal vat = decimal.Parse(txtVAT.Text);
                decimal totalPriceWithVAT;
                totalPriceWithVAT = ((100 + vat) / 100) * previousTotalPrice;
                txtTotalPPrice.Text = totalPriceWithVAT.ToString();
            }
        }

        private void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            // Get the Paid Amount and Grand Total
            decimal totalprice = decimal.Parse( txtTotalPPrice.Text);
            string check = txtPaidAmount.Text;
            if (check != "0" && check != "")
            {
                decimal paidAmount = decimal.Parse(txtPaidAmount.Text);
                decimal returnAmount = paidAmount - totalprice;
                // Display the return amount as will
                txtReturnAmount.Text = returnAmount.ToString();
            }
            else
            {
                txtReturnAmount.Text = "";
            }
            

          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //get the values from PurchaseSales from
            TransactionBLL transaction = new TransactionBLL();
            transaction.type = lblTop.Text;

            //Get the Id of the Customer here

            //lets get name of the customer first
            string CustomerOrSellerName = txtName.Text;
            CustomerBLL customerbll = customerdal.GetCustomerOrSellerIDFromName(CustomerOrSellerName);
            //getting the transactionID 
            transaction.CustomerID = customerbll.id;
            transaction.grandTotal = Math.Round(decimal.Parse(txtTotalPPrice.Text),2);
            transaction.transaction_date = DateTime.Now;
            transaction.tax =decimal.Parse(txtVAT.Text);
            transaction.discount = decimal.Parse(txtDiscount.Text);

            //Get the userName of loggedin User
            string username = frmLogin.LoggedInUserName;
            UserBll userbll = userdal.GetIDFromUsername(username);
            transaction.added_by = userbll.id;
            transaction.transactionDetails = transactionDT;

            //lets Create a boolean variable to check if successful
            bool success = false;

            using (TransactionScope scope = new TransactionScope())
            {
                int transactionID = -1;
                //create bool value and inset transaction
                bool w= transDal.InsertTransaction(transaction, out transactionID);
                for (int i = 0; i < transactionDT.Rows.Count; i++)
                {
                    //Get all the Details of the Product
                    TransactionDetailBLL transactionddetilbll = new TransactionDetailBLL();
                    //Get the productName and Conert it Id
                    string productname = transactionDT.Rows[i][0].ToString();
                    ProductBLL producbll = productdal.GetProduuctIDFromName(productname);

                    transactionddetilbll.product_id = producbll.Id;
                    transactionddetilbll.rate = decimal.Parse(transactionDT.Rows[i][1].ToString());
                    transactionddetilbll.qty = decimal.Parse(transactionDT.Rows[i][2].ToString());
                    transactionddetilbll.total = Math.Round(decimal.Parse(transactionDT.Rows[i][3].ToString()), 2);

                    //lets get id of the customer firt
                    transactionddetilbll.Id = customerbll.id;
                    transactionddetilbll.added_date = DateTime.Now;
                    transactionddetilbll.added_by = userbll.id;

                    //now before inserting we need to increasing or decrease Product Quantity Based on Purchase or Sales
                    string TransactionType = lblTop.Text;

                    //lets check whether we are on puchase o sales
                    bool xpursal=false;
                    if (TransactionType== "Purchase")
                    {
                        xpursal = productdal.IncreaseProduct(transactionddetilbll.product_id, transactionddetilbll.qty);
                        if(xpursal==true)
                        {
                            MessageBox.Show("Product Increase is Successful");
                        }
                        else
                        {
                            MessageBox.Show("Product Increase Falied !!!!!");
                        }
                    }
                    else if(TransactionType=="Sales")
                    {
                        xpursal = productdal.DecreaseProduct(transactionddetilbll.product_id, transactionddetilbll.qty);
                        if (xpursal == true)
                        {
                            MessageBox.Show("Product Decrease is Successful");
                        }
                        else
                        {
                            MessageBox.Show("Product Decrease Falied !!!!!");
                        }
                    }

                    //Finally insert TransactionDetails inside the DataBase
                    bool y = transDetailDal.InsertTransaction(transactionddetilbll);
                    success = w && y && xpursal;


                }
                if (success == true)
                {
                    scope.Complete();
                    //Code To print Bill
                    DGVPrinter print = new DGVPrinter();
                    print.Title = "\r\n\r\n SHADY'S Store Bill";
                    print.SubTitle = "Yemen,Taiz \r\n Phone:772816006";
                    print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                    print.PageNumbers = true;
                    print.PageNumberInHeader = false;
                    print.PorportionalColumns = true;
                    print.HeaderCellAlignment = StringAlignment.Near;
                    print.Footer = "Discount: " + txtDiscount.Text + "% \r\n ValueAddedTax: " + txtVAT.Text + "%\r\n" + "Total Price: " +txtTotalPPrice.Text+ "\r\n Thanks For Your Visit.";
                    print.FooterSpacing = 7;
                    print.PrintDataGridView(dgvAddedproducts);

                    //Transaction Compelte
                    MessageBox.Show(" Transaction Compeleted Successfully");
                    //Clear of the DataGrid view
                    dgvAddedproducts.DataSource = null;
                    dgvAddedproducts.Rows.Clear();

                    txtCustomerSearch.Text = "";
                    txtName.Text = "";
                    txtEmail.Text = "";
                    txtContact.Text = "";
                    txtAddress.Text = "";
                    txtProductSearch.Text = "";
                    txtProductName.Text = "";
                    txtProdcutInventory.Text = "0";
                    txtProdcutQTY.Text = "0";
                    txtRowTotal.Text = "0";
                    txtDiscount.Text = "0";
                    txtVAT.Text = "0";
                    txtTotalPPrice.Text = "0";
                    txtPaidAmount.Text = "";
                    txtReturnAmount.Text = "";


                }
                else
                {
                    //Transaction Failed
                    MessageBox.Show("Transaction Failed");
                }



            }



        }
    }
}
