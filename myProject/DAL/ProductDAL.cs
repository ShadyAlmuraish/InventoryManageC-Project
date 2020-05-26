using myProject.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myProject.DAL
{
    class ProductDAL
    {
        static string myConnection = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        #region Select method for Products
        public DataTable SelectProduct()
        {
            SqlConnection con = new SqlConnection(myConnection);
            DataTable dt = new DataTable();
            // code to select all Cataories in data base fill it in dataTable
            try
            {
                string sql = "SELECT * FROM tbl_products";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //we will have values from database in the adapter

                //we have to Open Connsection
                con.Open();

                //Adding value from adapter to DataTable
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dt;

        }
        #endregion 
        #region INsert New Product
        public bool InsertProduct(ProductBLL pro)
        {
            bool success = false;
            SqlConnection con = new SqlConnection(myConnection);
            try
            {
                string sql = "INSERT INTO tbl_products (name,category,description,rate,qty,added_date,added_by) VALUES(@name,@category,@description,@rate,@qty,@added_date,@added_by)";
                //Sql Command to pass Values in Our query
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@name", pro.name);
                cmd.Parameters.AddWithValue("@category", pro.category);
                cmd.Parameters.AddWithValue("@description", pro.description);
                cmd.Parameters.AddWithValue("@rate", pro.rate);
                cmd.Parameters.AddWithValue("@qty", pro.qty);
                cmd.Parameters.AddWithValue("@added_date", pro.added_date);
                cmd.Parameters.AddWithValue("@added_by", pro.added_by);
                //Open Connectiion0
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {

                    success = true;
                }
                else
                {

                    success = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return success;
        }

        #endregion
        #region UPDATE Product METHOD
        public bool UpdateProduuct(ProductBLL pro)
        {
            bool success = false;
            SqlConnection con = new SqlConnection(myConnection);
            try
            {
                string sql = "UPDATE tbl_products SET name=@name,category=@category,description=@description,rate=@rate,added_date=@added_date,added_by=@added_by WHERE Id=@Id";

                //Sql Command to pass Values to The sql Query
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@name", pro.name);
                cmd.Parameters.AddWithValue("@category", pro.category);
                cmd.Parameters.AddWithValue("@description", pro.description);
                cmd.Parameters.AddWithValue("@rate", pro.rate);
                cmd.Parameters.AddWithValue("@qty", pro.qty);
                cmd.Parameters.AddWithValue("@added_date", pro.added_date);
                cmd.Parameters.AddWithValue("@added_by", pro.added_by);
                cmd.Parameters.AddWithValue("@Id", pro.Id);

                //Open Connectiion0
                con.Open();

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    success = true;
                }
                else
                {
                    success = false;
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return success;


        }
        #endregion
        #region DELETE Product METHOD
        public bool DeleteProduct(ProductBLL pro)
        {
            bool success = false;
            SqlConnection con = new SqlConnection(myConnection);
            try
            {
                string sql = "DELETE FROM tbl_products WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Id", pro.Id);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                // if the Query is Excuted then the value of the rows will be greater thean zero
                if (rows > 0)
                {
                    success = true;
                }
                else
                {
                    success = false;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return success;
        }
        #endregion
        #region Search Product IN the data Base
        public DataTable Search(string Keywwords)
        {
            //SQL connection to Create a connection
            SqlConnection con = new SqlConnection(myConnection);
            DataTable dt = new DataTable();
            try
            {
                // string QUERY for Search
                string sql = "SELECT * FROM tbl_products where Id LIKE '%" + Keywwords + "%' OR name LIKE '%" + Keywwords + "%'OR category LIKE'%" + Keywwords + "%'";
                //Creating a command to Excute the Query 
                SqlCommand cmd = new SqlCommand(sql, con);
                //Getting Data from DataBAse
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //passing values from adapter to Data Table
                con.Open();

                adapter.Fill(dt);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return dt;
        }
        #endregion
        #region method to Get  Product Price name 
        public ProductBLL GetProduct(string KeySearch)
        {
            ProductBLL productbll = new ProductBLL();

            //Static Method to Connect Database
            SqlConnection con = new SqlConnection(myConnection);
            //TO Hold data From Database
            DataTable dtable = new DataTable();
            try
            {
                //SQL Query to  Search Data From Database Based Upon Id FIRST,LAST,Username
                String sql = "SELECT name,rate,qty FROM tbl_products WHERE Id LIKE '%" + KeySearch + "%' OR name LIKE'%" + KeySearch + "%'";
                //FOR Excuting Command
                SqlCommand cmd = new SqlCommand(sql, con);
                //GETTING Data From DataBase 
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Database Connection Open
                con.Open();
                //Fill DATA From DataBase in Our Data Table
                adapter.Fill(dtable);
                if (dtable.Rows.Count > 0)
                {
                    productbll.name = dtable.Rows[0]["name"].ToString();
                    productbll.rate = decimal.Parse(dtable.Rows[0]["rate"].ToString());
                    productbll.qty = decimal.Parse(dtable.Rows[0]["qty"].ToString());

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();

            }
            //Return Value In dataTable
            return productbll;

        }
        #endregion
        #region Get The Product Id Based on ProductName
        public ProductBLL GetProduuctIDFromName(string Name)
        {
            // first Create an Object of SellerCustomerBll and Return it
            ProductBLL productbll = new ProductBLL();


            //Static Method to Connect Database
            SqlConnection con = new SqlConnection(myConnection);

            //Static Method to Connect Database

            //TO Hold data From Database
            DataTable dtable = new DataTable();

            try
            {
                //SQL Query to get id based on Name
                string sql = "Select Id FROM tbl_products WHERE name='" + Name + "'";
                //Create the SqlDataAdapter to Excute the query
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);

                con.Open();

                //Passing the value from the adapter to the database
                adapter.Fill(dtable);

                // if the Query is Excuted then the value of the rows will be greater thean zero
                if (dtable.Rows.Count > 0)
                {
                    productbll.Id = int.Parse(dtable.Rows[0]["Id"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return productbll;
        }


            
            #endregion
        #region Get the current Quantity From the Product Id

            public decimal GetProductQty(int ProductID)
            {
                //Sql Connection First
                SqlConnection conn = new SqlConnection(myConnection);

                //Create a Decimal variable and set default value 0
                decimal qty = 0;

                //Create DataTable to save the data fom database
                DataTable dt = new DataTable();

                try
                {
                    string sql = "SELECT qty FROM tbl_products WHERE id='" + ProductID + "'";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    conn.Open();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        qty = decimal.Parse(dt.Rows[0]["qty"].ToString());
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                return qty;

            }
        #endregion
        #region Method to update quantity
        public bool UpdateQuantity(int ProductID,decimal qty)
        {

            bool Success = false;
            SqlConnection conn = new SqlConnection(myConnection);

            try
            {
                string sql = "Update tbl_products SET qty=@qty WHERE Id=@Id ";

                //Create Sql Command  to pass the value into Query 
                SqlCommand cmd =new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("Id", ProductID);
                cmd.Parameters.AddWithValue("qty", qty);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if(rows>0)
                {
                    Success = true;
                }
                else
                {
                    MessageBox.Show("Failed to Update  Quntity");
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }
            return Success;
        }

        #endregion
        #region Method to increase Product Quantity based on id
        public bool IncreaseProduct(int ProductID, decimal increaseQty)
        {

            bool Success = false;
            SqlConnection conn = new SqlConnection(myConnection);

            try
            {
                //get the current Qty from database Based on quantity
                decimal currentQuantity = GetProductQty(ProductID);

                //increase the current  Quantity by quantity purchased from the Seller
                decimal newQty = currentQuantity + increaseQty;

                // now we need to update quantity stored
                Success = UpdateQuantity(ProductID, newQty);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }
            return Success;
        }

        #endregion
        #region Method to decrease Product

        public bool DecreaseProduct(int ProductId,decimal qty)
        {
            bool Success = false;
            SqlConnection conn = new SqlConnection(myConnection);

            try
            {
                //get the current Qty from database Based on quantity
                decimal currentQuantity = GetProductQty(ProductId);

                //Decrease  the current  Quantity by quantity sold to the Customer
                decimal newQty = currentQuantity-qty;

                // now we need to update quantity stored
                Success = UpdateQuantity(ProductId, newQty);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }
            return Success;

        }
        #endregion

        #region Display Products Based on Categories
        public DataTable DisplayProductBasedonCategory(string category)
        {
            SqlConnection con = new SqlConnection(myConnection);
            DataTable dt = new DataTable();
            // code to select all Cataories in data base fill it in dataTable
            try
            {
                string sql = "SELECT * FROM tbl_products WHERE category='" + category + "'";

                SqlCommand cmd = new SqlCommand(sql, con);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con.Open();
                adapter.Fill(dt);
            }
             
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dt;

        }
#endregion


    }


}



