using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Threading.Tasks;
using PRG252_Project;

namespace PRG252_Project
{
    class Students
    {
        
        string id, name, surname, dob, gender, phone, address, modulecode, moduleName, modDescription, onlinelink;
        Image image;// Tried using byes,bitmap still get errors

        public Students(string id, string name, string surname, string dob, string gender, string phone, string address, string modulecode, string moduleName, string modDescription, string onlinelink, Image image)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.dob = dob;
            this.gender = gender;
            this.phone = phone;
            this.address = address;
            this.modulecode = modulecode;
            this.moduleName = moduleName;
            this.modDescription = modDescription;
            this.onlinelink = onlinelink;
            this.image = image;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Dob { get => dob; set => dob = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public string Modulecode { get => modulecode; set => modulecode = value; }
        public string ModuleName { get => moduleName; set => moduleName = value; }
        public string ModDescription { get => modDescription; set => modDescription = value; }
        public string Onlinelink { get => onlinelink; set => onlinelink = value; }
        public Image Image { get => image; set => image = value; }
    }
}
