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
    class TransactionDAL
    {
        //Creating A connection String
        static string myConnection = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        #region Insert Tranzaction Method

        public bool InsertTransaction(TransactionBLL u,out int transactionId)
        {
            bool isSuccess = false;
            transactionId = -1;
            //Static Method to Connect Database
            SqlConnection con = new SqlConnection(myConnection);

            try
            {

                String sql = "INSERT INTO tbl_transactions (type,customer_id,grandTotal,transaction_date,tax,discount,added_by) VALUES(@type,@customer_id,@grandTotal,@transaction_date,@tax,@discount,@added_by); SELECT @@IDENTITY;";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@type", u.type);
                cmd.Parameters.AddWithValue("@customer_id", u.CustomerID);
                cmd.Parameters.AddWithValue("@grandTotal", u.grandTotal);
                cmd.Parameters.AddWithValue("@transaction_date", u.transaction_date);
                cmd.Parameters.AddWithValue("@tax", u.tax);
                cmd.Parameters.AddWithValue("@discount", u.discount);
                cmd.Parameters.AddWithValue("@added_by", u.added_by);
                con.Open();
                object o = cmd.ExecuteScalar();
                // if the Query is Excuted then the value of the rows will be greater thean zero
                if (o!=null)
                {
                    isSuccess = true;
                    transactionId = int.Parse(o.ToString());
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

            }

                return isSuccess;

        }

        #endregion

        #region method to display all transaction 
        public DataTable DisplayAllTransaction()
        {
            SqlConnection con = new SqlConnection(myConnection);
            DataTable dt = new DataTable();
            // code to select all Cataories in data base fill it in dataTable
            try
            {
                string sql = "SELECT * FROM tbl_transactions";
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

        #region display all transactions based on transaction Type
       public DataTable DisplayTransactionType(string type)
        {
            SqlConnection con = new SqlConnection(myConnection);
            DataTable dt = new DataTable();
            // code to select all Cataories in data base fill it in dataTable
            try
            {
                string sql = "SELECT * FROM tbl_transactions WHERE type='"+type+"'";
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

    }
}
