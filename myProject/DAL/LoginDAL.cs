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
    class LoginDAL
    {
        //Static String to Connect to DataBase
        static string myConnection = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        public bool loginCheck(LoginBLL log)
        {
            //Create a bool variable and  set its value to false
            bool success = false;

            using (SqlConnection con = new SqlConnection(myConnection))
            {
                try
                {
                    // Sql Query TO check LOgin
                    string sql = "SELECT * FROM tbl_user WHERE username=@username AND password=@password AND user_type=@user_type";
                    // SQL COMMAND TO PASS VALUE to THE query using SQL COMMAND
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@username", log.userName);
                    cmd.Parameters.AddWithValue("@password", log.passWord);
                    cmd.Parameters.AddWithValue("@user_type", log.userType);
                    //we need SQL adapter to Temporary Show Data From DataBAse 
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    //DataTable to Hold the data from the Sql Adapter temporarly into our DataTable
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    //check if the user is in our database
                    if (dt.Rows.Count > 0)
                    {
                        //Login Successful
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

                return success;
            }


        }
    }
}
