using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC01.WindowsForms
{
    class EtudiantListPrint
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string DateNais { get; set; }
        public string LieuNais { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public byte[] Photo { get; set; }
        public string CodeBar { get; set; }

        public EtudiantListPrint(string first_Name, string last_Name, 
            string dateNais, string lieuNais, string contact,
            string email, byte[] photo, string codeBar)
        {
            First_Name = first_Name;
            Last_Name = last_Name;
            DateNais = dateNais;
            LieuNais = lieuNais;
            Contact = contact;
            Email = email;
            Photo = photo;
            CodeBar = codeBar;
        }
    }
}
