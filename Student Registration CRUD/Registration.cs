using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRG252_Project;

namespace PRG252_Project
{
    public partial class Registration : Form
    {
        FileHandler fh = new FileHandler();
        public Registration()
        {
            InitializeComponent();
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {

            if (fh.Register(txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtName.Text, txtPassword1.Text, txtConfirm.Text) == "True")
            {
                MessageBox.Show("Successfull registration");
            }
            else
            {
                MessageBox.Show("Please try again");
            }

            Login Login = new Login();
            this.Close();
            Login.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Login Login = new Login();
            this.Close();
            Login.Show();
        }
    }
}
