using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG252_Project
{
    public partial class Administration_Portal : Form
    {
        public Administration_Portal()
        {
            InitializeComponent();
        }

        private void Administration_Portal_Load(object sender, EventArgs e)
        {

            dataGridView1.Columns.Clear();
        }

        DataHandler dh = new DataHandler();        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string name = txtName.Text;
            string surname = txtSurname.Text;
            string dob = txtBirth.Text;
            string gender = cbGender.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            string modulecode = cbModule.Text;
            string modulename = txtModName.Text;
            string moduleDescription = txtDescription.Text;
            string onlinelink = txtLink.Text;
            Image image = pictureBox1.Image; //Image creates a system exception error when inserted,so we have discovered that without inserting an image all information is saved to the database     

            dh.insertStudent(id, name, surname, dob, gender, phone, address, modulecode, modulename, moduleDescription, onlinelink, image);
            MessageBox.Show("Student Details Added Successfully");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string name = txtName.Text;
            string surname = txtSurname.Text;
            string dob = txtBirth.Text;
            string gender = cbGender.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            string modulecode = cbModule.Text;
            string modulename = txtModName.Text;
            string moduleDescription = txtDescription.Text;
            string onlinelink = txtLink.Text;
            Image image = pictureBox1.Image;

            dh.updateStudent(id, name, surname, dob, gender, phone, address, modulecode, modulename, moduleDescription, onlinelink, image);
            MessageBox.Show($"Successfully updated student's details");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            dh.deleteData(id.ToString());
            MessageBox.Show("You have successfully deleted student's details");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
          
            string id = txtSearch.Text;
            dataGridView1.DataSource = dh.SearchStudent(id);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Select image(*.Jpg;*.png;*.GIF;*.All files)|*.Jpg;*.png;*.GIF;*.All files)";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }
    }
}
