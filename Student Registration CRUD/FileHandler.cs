using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRG252_Project;

namespace PRG252_Project
{
    class FileHandler
    {
        private string path = AppDomain.CurrentDomain.BaseDirectory + "Login.txt";

        public FileHandler() { }

        public void CheckCreateFile()
        {
            if (!File.Exists(path))
            {
                StreamWriter file = File.CreateText(path);
                file.Close();
            }
        }

        public List<string> FileList()
        {
            using (TextReader file = File.OpenText(path))
            {
                return file.ReadToEnd().Split('\n').ToList();
            }
        }

        public bool Login(string user, string pass)
        {
            CheckCreateFile();
            List<string> logins = FileList();
            string details = user + "," + pass + "\r";
            using (FileStream file = File.Open(path, FileMode.Open))
            {
                if (logins.Contains(details))
                {
                    return true;
                }
                return false;
            }
        }

        public string Register(string name, string surname, string email ,string user, string pass, string confirm)
        {
            CheckCreateFile();
            using (StreamWriter file = File.AppendText(path))
            {
                file.WriteLine(user + "," + pass);

            }
            return "True";
        }

    }
}
