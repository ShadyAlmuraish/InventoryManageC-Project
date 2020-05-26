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
using System.Windows.Forms;

namespace myProject.Ui
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        LoginBLL logBLL = new LoginBLL();
        LoginDAL logDAL = new LoginDAL();
        public static string LoggedInUserName;
        private void logPoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            logBLL.userName = txtUserName.Text.Trim();
            logBLL.passWord = txtPassord.Text.Trim();
            logBLL.userType = cmbUserType.Text.Trim();

            //Checking the Login
            bool success = logDAL.loginCheck(logBLL);
            if(success==true)
            {
                MessageBox.Show("Login SuccessFul");
                //stoer username
                LoggedInUserName = logBLL.userName;
                // We Need to Open Respective Form Based on User Type
                switch(logBLL.userType)
                {
                    case "Admin":
                        AdminDashBoard admin = new AdminDashBoard();
                        admin.Show();
                        this.Hide();
                        break;
                    case "User":
                          UserDashBoard userDash = new UserDashBoard();
                        userDash.Show();
                        this.Hide();
                        break;

                    default:
                        { 
                        MessageBox.Show("INVALID!!!!! USER");
                        }
                        break;
                }

            }
            else
            {
                MessageBox.Show("Login Failed!!!!!! try for the second time");
                txtUserName.Text = "";
                txtPassord.Text = "";
                cmbUserType.Text = "";

            }
        }
        
    }
}
