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
    class userDAL
    {
        
        static string myconnection = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        #region Select Data from Database
        public DataTable Select()
        {
            //Static Method to Connect Database
            SqlConnection con = new SqlConnection(myconnection);
            //TO Hold data From Database
            DataTable dtable = new DataTable();
            try
            {
                //SQL Query to Get Data From Database
                String sql = "SELECT * FROM tbl_user";
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
        #region    Insert Data In Database
        public bool Insert(UserBll u)
        {
            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconnection);
            try
            {
                String sql = "INSERT INTO tbl_user (first_name,last_name,email,username,password,contact,address,gender,user_type,added_date,added_by) VALUES(@first_name,@last_name,@email,@username,@password,@contact,@address,@gender,@user_type,@added_date,@added_by)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@first_name", u.firstName);
                cmd.Parameters.AddWithValue("@last_name", u.lastName);
                cmd.Parameters.AddWithValue("@email", u.email);
                cmd.Parameters.AddWithValue("@username", u.userName);
                cmd.Parameters.AddWithValue("@password", u.passWord);
                cmd.Parameters.AddWithValue("@contact", u.Contact);
                cmd.Parameters.AddWithValue("@address", u.address);
                cmd.Parameters.AddWithValue("@gender", u.gender);
                cmd.Parameters.AddWithValue("@user_type", u.user_type);
                cmd.Parameters.AddWithValue("@added_date", u.addedDate);
                cmd.Parameters.AddWithValue("@added_by", u.addedBy);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                // if the Query is Excuted then the value of the rows will be greater thean zero
                if(rows>0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
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
            return isSuccess;
        }
        #endregion
        #region Update data in Database
        public bool Update(UserBll u)
        {
            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconnection);
            try
            {
                string sql = "UPDATE tbl_user SET first_name=@first_name , last_name=@last_name, email=@email, username=@username, password=@password, contact=@contact, address=@address, gender=@gender, user_type=@user_type, added_date=@added_date, added_by=@added_by WHERE user_id=@user_id";
                SqlCommand cmd = new SqlCommand(sql,con);
                cmd.Parameters.AddWithValue("@first_name", u.firstName);
                cmd.Parameters.AddWithValue("@last_name", u.lastName);
                cmd.Parameters.AddWithValue("@email", u.email);
                cmd.Parameters.AddWithValue("@username", u.userName);
                cmd.Parameters.AddWithValue("@password", u.passWord);
                cmd.Parameters.AddWithValue("@contact", u.Contact);
                cmd.Parameters.AddWithValue("@address", u.address);
                cmd.Parameters.AddWithValue("@gender", u.gender);
                cmd.Parameters.AddWithValue("@user_type", u.user_type);
                cmd.Parameters.AddWithValue("@added_date", u.addedDate);
                cmd.Parameters.AddWithValue("@added_by", u.addedBy);
                cmd.Parameters.AddWithValue("@user_id", u.id);

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
        #region Delete Data From Database
        public bool Delete (UserBll u)
        {
            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconnection);
            try
            {
                string sql = "Delete FROM tbl_user WHERE user_id=@user_id";
                SqlCommand cmd = new SqlCommand(sql,con);
                cmd.Parameters.AddWithValue("@user_id", u.id);
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
        #region Search User From the dataBase
        public DataTable  Saerch(string KeySearch)
        {
            //Static Method to Connect Database
            SqlConnection con = new SqlConnection(myconnection);
            //TO Hold data From Database
            DataTable dtable = new DataTable();
            try
            {
                //SQL Query to  Search Data From Database Based Upon Id FIRST,LAST,Username
                String sql = "SELECT * FROM tbl_user WHERE user_id LIKE '%"+KeySearch+"%' OR first_name LIKE'%"+KeySearch+ "%' OR username LIKE'%" + KeySearch + "%'  OR last_name LIKE'%" + KeySearch + "%'";
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
        #region Getting UserID based on Username
        public UserBll  GetIDFromUsername (string username)
        {

            UserBll userbll = new UserBll();
            SqlConnection con = new SqlConnection(myconnection);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT user_id FROM tbl_user WHERE username='"+username+"'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dt);
                if(dt.Rows.Count>0)
                {
                    userbll.id = int.Parse(dt.Rows[0]["user_id"].ToString());

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
            return userbll;
        }

#endregion


    }
}
