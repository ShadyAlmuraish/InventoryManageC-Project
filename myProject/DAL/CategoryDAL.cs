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
    class CategoryDAL
    {
        static string myConnection = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        #region Select Method
        public DataTable SelectCategory()
        {
            SqlConnection con = new SqlConnection(myConnection);
            DataTable dt = new DataTable();
            // code to select all Cataories in data base fill it in dataTable
            try
            {
                string sql = "SELECT * FROM tbl_categories";
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
        #region INsert New Category
        public bool InsertCategory(CategoryBLL cat)
        {
            bool success = false;
            SqlConnection con = new SqlConnection(myConnection);
            try
            {
                string sql = "INSERT INTO tbl_categories (title,description,added_date,added_by) VALUES(@title,@description,@added_date,@added_by)";
                //Sql Command to pass Values in Our query
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@title", cat.title);
                cmd.Parameters.AddWithValue("@description", cat.description);
                cmd.Parameters.AddWithValue("@added_date", cat.addedDate);
                cmd.Parameters.AddWithValue("@added_by", cat.added_by);
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
        #region UPDATE METHOD
        public bool UpdateCategory(CategoryBLL cat)
        {
            bool success = false;
            SqlConnection con = new SqlConnection(myConnection);
            try
            {
                string sql = "UPDATE tbl_categories SET title=@title,description=@description,added_date=@added_date,added_by=@added_by WHERE Id=@Id";

                //Sql Command to pass Values to The sql Query
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@title", cat.title);
                cmd.Parameters.AddWithValue("@description", cat.description);
                cmd.Parameters.AddWithValue("@added_date", cat.addedDate);
                cmd.Parameters.AddWithValue("@added_by", cat.added_by);
                cmd.Parameters.AddWithValue("@Id", cat.id);
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
        #region DELETE CATEGORY METHOD
        public bool DeleteCategory(CategoryBLL cat)
        {
            bool success = false;
            SqlConnection con = new SqlConnection(myConnection);
            try
            {
                string sql = "DELETE FROM tbl_categories WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql,con);
                cmd.Parameters.AddWithValue("@Id", cat.id);
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
        #region Search Category IN the data Base
        public DataTable Search(string Keywwords)
        {
            //SQL connection to Create a connection
            SqlConnection con = new SqlConnection(myConnection);
            DataTable dt = new DataTable();
            try
            {
                // string QUERY for Search
                string sql = "SELECT * FROM tbl_categories where Id LIKE '%" + Keywwords + "%' OR title LIKE '%" + Keywwords + "%'OR description LIKE'%" + Keywwords + "%'";
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

    }
}
