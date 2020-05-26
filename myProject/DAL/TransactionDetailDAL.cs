using myProject.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myProject.DAL
{
    class TransactionDetailDAL
    {
        //Creating A connection String
        static string myConnection = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        #region insert Meetod for Transaction Details

        public bool InsertTransaction(TransactionDetailBLL u)
        {
            bool isSuccess = false;
            //Static Method to Connect Database
            SqlConnection con = new SqlConnection(myConnection);

            try
            {

                String sql = "INSERT INTO tbl_trasaction_detail (product_id,rate,qty,total,customer_id,added_date,added_by) VALUES(@product_id,@rate,@qty,@total,@customer_id,@added_date,@added_by)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@product_id", u.product_id);
                cmd.Parameters.AddWithValue("@rate", u.rate);
                cmd.Parameters.AddWithValue("@qty", u.qty);
                cmd.Parameters.AddWithValue("@total", u.total);
                cmd.Parameters.AddWithValue("@customer_id", u.customer_id);
                cmd.Parameters.AddWithValue("@added_date", u.added_date);
                cmd.Parameters.AddWithValue("@added_by", u.added_by);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                // if the Query is Excuted then the value of the rows will be greater thean zero
                if (rows >0)
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

            }

            return isSuccess;

        }

        #endregion

    }
}
