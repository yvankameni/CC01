using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC01.BO
{
    public class Etudiant
    {

     
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string DateNais { get; set; }
        public string LieuNais { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public byte [] Photo { get; set; }
        public string CodeBar { get; set; }

        public Etudiant( string first_Name, string last_Name, 
            string dateNais, string lieuNais, 
            string contact, string email, byte[] photo, string codeBar)
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

        

        public override bool Equals(object obj)
        {
            return obj is Etudiant etudiant &&
                   First_Name == etudiant.First_Name;
        }

        public override int GetHashCode()
        {
            return 797189699 + EqualityComparer<string>.Default.GetHashCode(First_Name);
        }
    }
}
