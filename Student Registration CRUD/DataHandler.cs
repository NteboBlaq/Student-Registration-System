using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using PRG252_Project;
using Image = System.Drawing.Image;

namespace PRG252_Project
{
    class DataHandler
    {
        SqlConnection connection = new SqlConnection("Server=NTEBOBLAQ; Initial Catalog= BelgiumCampusDB; Integrated Security = SSPI");

        public DataHandler() { }

        public void Open()
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connection successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection Unsuccessful. \n" + ex.Message);
            }
        }

        public SqlDataReader viewData(string table)
        {
            Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Students", connection);
            cmd.Parameters.AddWithValue("Students", table);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public string getValue(string id, string category, string table)
        {
            Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Students WHERE StudentID = @ID", connection);
            cmd.Parameters.AddWithValue("@ID", id);
            SqlDataReader reader = cmd.ExecuteReader();
            cmd.ExecuteNonQuery();
            Close();
            return reader.ToString();
        }

        public void insertStudent(string id, string name, string surname, string dob, string gender, string phone, string address, string modulecode, string modulename, string moduleDescription, string onlinelink, Image image)
        {
            string conn = "Server=.; Initial Catalog= BelgiumCampusDB; Integrated Security = SSPI";
            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("spAddStudents", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentID", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Surname", surname);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@ModuleCode", modulecode);
                cmd.Parameters.AddWithValue("@ModuleName", modulename);
                cmd.Parameters.AddWithValue("@ModDescription", moduleDescription);
                cmd.Parameters.AddWithValue("@Onlinelink", onlinelink);
                //cmd.Parameters.AddWithValue("@Image", image);  //Image creates a system exception error when inserted,so we have discovered that without inserting an image all information is saved to the database     
                //cmd.Parameters.Add("@Image",SqlDbType.).Value= ImageToByte2(image);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void updateStudent(string id, string name, string surname, string dob, string gender, string phone, string address, string modulecode, string modulename, string moduleDescription, string onlinelink, Image image)
        {

            string conn = "Server=.; Initial Catalog= BelgiumCampusDB; Integrated Security = SSPI";
            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("spUpdateStudents", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentID", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Surname", surname);
                cmd.Parameters.AddWithValue("@DOB", dob);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@ModuleCode", modulecode);
                cmd.Parameters.AddWithValue("@ModuleName", modulename);
                cmd.Parameters.AddWithValue("@ModDescription", moduleDescription);
                cmd.Parameters.AddWithValue("@Onlinelink", onlinelink);
                //cmd.Parameters.AddWithValue("@Image", image);  //Image creates a system exception error when inserted,so we have discovered that without inserting an image all information is saved to the database     


                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void deleteData( string id)
        {
            string conn = "Server=.; Initial Catalog= BelgiumCampusDB; Integrated Security = SSPI";
            
            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("spDeleteStudents", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", id);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable SearchStudent(string id)
        {
            string conn = "Server=.; Initial Catalog= BelgiumCampusDB; Integrated Security = SSPI";
            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("spSearchStudents", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", id);

                connection.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);
                    return dt;
                }
            }
        }

        public void Close()
        {
            connection.Close();
        }
    }
}

