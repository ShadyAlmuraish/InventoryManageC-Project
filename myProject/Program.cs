using myProject.Ui;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
              Application.EnableVisualStyles();
              Application.SetCompatibleTextRenderingDefault(false);
             Application.Run(new frmLogin());
          /*
            string myConnection = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(myConnection))
            {
                string sql = "SELECT * FROM tbl_categories";
                SqlCommand cmd = new SqlCommand(sql, con);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}", reader[1], reader[2], reader[3]);
                    }
                    reader.Close();
                }
                catch (Exception)
                {

                    throw;
                }
                Console.ReadLine();
            }
            */    



















        }
    }
}
