using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRG252_Project;

namespace PRG252_Project
{
    public partial class Login : Form
    {
        FileHandler file = new FileHandler();
        static int attempt = 3;
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (file.Login(txtUsername.Text, txtPassword.Text) == true)
            {
                attempt = 0;
                Administration_Portal admin = new Administration_Portal();
                this.Hide();
                admin.Show();
            }
            else if ((attempt == 3) && (attempt > 0))
            {
                MessageBox.Show("Incorrect user login credentials. "+ Convert.ToString(attempt) + " attempts left.");
                --attempt;
            }
           
        }

        private void lblSignUp_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            this.Hide();
            registration.Show();
        }      
    }
}
