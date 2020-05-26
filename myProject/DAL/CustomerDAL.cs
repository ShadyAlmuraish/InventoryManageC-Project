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
    class CustomerDAL
    {
        static string myconnection = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        #region Select Customer Data from Database
        public DataTable SelectCustomer()
        {
            //Static Method to Connect Database
            SqlConnection con = new SqlConnection(myconnection);
            //TO Hold data From Database
            DataTable dtable = new DataTable();
            try
            {
                //SQL Query to Get Data From Database
                String sql = "SELECT * FROM tbl_customer";
                //FOR Excuting Command
                SqlCommand cmd = new SqlCommand(sql, con);
                //GETTING Data From DataBase 
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Database Connection Open
                con.Open();
                //Fill DATA From DataBase in Our Data Table
                adapter.Fill(dtable);

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
            return dtable;

        }
        #endregion
        #region    Insert Customer Data In Database
        public bool InsertCustomer(CustomerBLL u)
        {
            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconnection);
            try
            {
                String sql = "INSERT INTO tbl_customer (type,name,email,contact,address,added_date,added_by) VALUES(@type,@name,@email,@contact,@address,@added_date,@added_by)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@type", u.type);
                cmd.Parameters.AddWithValue("@name", u.name);
                cmd.Parameters.AddWithValue("@email", u.email);
                cmd.Parameters.AddWithValue("@contact", u.contact);
                cmd.Parameters.AddWithValue("@address", u.address);
                cmd.Parameters.AddWithValue("@added_date", u.added_date);
                cmd.Parameters.AddWithValue("@added_by", u.added_by);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                // if the Query is Excuted then the value of the rows will be greater thean zero
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
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
            return isSuccess;
        }
        #endregion
        #region Update Customer data in Database
        public bool UpdateCustomer(CustomerBLL u)
        {
            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconnection);
            try
            {
                string sql = "UPDATE tbl_customer SET type=@type ,name=@name, email=@email,contact=@contact, address=@address,added_date=@added_date, added_by=@added_by WHERE Id=@customer_id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@type", u.type);
                cmd.Parameters.AddWithValue("@name", u.name);
                cmd.Parameters.AddWithValue("@email", u.email);
                cmd.Parameters.AddWithValue("@contact", u.contact);
                cmd.Parameters.AddWithValue("@address", u.address);
                cmd.Parameters.AddWithValue("@added_date", u.added_date);
                cmd.Parameters.AddWithValue("@added_by", u.added_by);
                cmd.Parameters.AddWithValue("@customer_id", u.id);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                // if the Query is Excuted then the value of the rows will be greater thean zero
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
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

            return isSuccess;
        }
        #endregion
        #region Delete Customer Data From Database
        public bool DeleteCustomer(CustomerBLL u)
        {
            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconnection);
            try
            {
                string sql = "Delete FROM tbl_customer WHERE Id=@customer_id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@customer_id", u.id);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                // if the Query is Excuted then the value of the rows will be greater thean zero
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
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
            return isSuccess;
        }
        #endregion
        #region Search Customer From the dataBase
        public DataTable SearchCustomer(string KeySearch)
        {
            //Static Method to Connect Database
            SqlConnection con = new SqlConnection(myconnection);
            //TO Hold data From Database
            DataTable dtable = new DataTable();
            try
            {
                //SQL Query to  Search Data From Database Based Upon Id FIRST,LAST,Username
                String sql = "SELECT * FROM tbl_customer WHERE Id LIKE '%" + KeySearch + "%' OR name LIKE'%" + KeySearch + "%' OR type LIKE'%" + KeySearch + "%'";
                //FOR Excuting Command
                SqlCommand cmd = new SqlCommand(sql, con);
                //GETTING Data From DataBase 
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Database Connection Open
                con.Open();
                //Fill DATA From DataBase in Our Data Table
                adapter.Fill(dtable);

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
            return dtable;

        }
        #endregion

        #region method to Get  Seller or Customer
        public CustomerBLL GetSellerCustomer(string KeySearch)
        {
            CustomerBLL customerbll = new CustomerBLL();

            //Static Method to Connect Database
            SqlConnection con = new SqlConnection(myconnection);
            //TO Hold data From Database
            DataTable dtable = new DataTable();
            try
            {
                //SQL Query to  Search Data From Database Based Upon Id FIRST,LAST,Username
                String sql = "SELECT name,email,contact,address  FROM tbl_customer WHERE Id LIKE '%" + KeySearch + "%' OR name LIKE'%" + KeySearch + "%'";
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
                    customerbll.name = dtable.Rows[0]["name"].ToString();
                    customerbll.email = dtable.Rows[0]["email"].ToString();
                    customerbll.contact = dtable.Rows[0]["contact"].ToString();
                    customerbll.address = dtable.Rows[0]["address"].ToString();
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
            return customerbll;

        }
        #endregion

        #region Method to Get the Id of THE SELLER OR CUSTOMER
        public CustomerBLL GetCustomerOrSellerIDFromName (string Name)
        {
            // first Create an Object of SellerCustomerBll and Return it
            CustomerBLL customerbll = new CustomerBLL();


            //Static Method to Connect Database
            SqlConnection con = new SqlConnection(myconnection);

            //Static Method to Connect Database
            
            //TO Hold data From Database
            DataTable dtable = new DataTable();

            try
            {
                //SQL Query to get id based on Name
                string sql = "Select Id FROM tbl_customer WHERE name='" + Name + "'";
                //Create the SqlDataAdapter to Excute the query
                SqlDataAdapter adapter = new SqlDataAdapter(sql,con);

                con.Open();

                //Passing the value from the adapter to the database
                adapter.Fill(dtable);
                
                // if the Query is Excuted then the value of the rows will be greater thean zero
                if (dtable.Rows.Count > 0)
                {
                    customerbll.id = int.Parse(dtable.Rows[0]["Id"].ToString());
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }



            return customerbll;
        }
#endregion


    }
}
