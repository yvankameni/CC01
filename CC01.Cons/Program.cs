using CC01.BLL;
using CC01.BO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC01.Cons
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice = "y";
            do
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------Create Etudiant-------------------------------------");
                Console.Write("Enter Matricule:\t");
                string Matricule = Console.ReadLine();
                Console.Write("Enter First_Name:\t");
                string First_Name = Console.ReadLine();
                Console.Write("Enter Last_Name:\t");
                string Last_Name = Console.ReadLine();
                Console.Write("Enter DateNais:\t");
                string DateNais = Console.ReadLine();
                Console.Write("Enter LieuNais:\t");
                string LieuNais = Console.ReadLine();
                Console.Write("Enter Contact:\t");
                string Contact = Console.ReadLine();
                Console.Write("Enter Email:\t");
                string Email = Console.ReadLine();
              
                Etudiant etudiant = new Etudiant(First_Name, Last_Name, DateNais, LieuNais, Contact, Email, null, null);
                EtudiantBLO etudiantBLO = new EtudiantBLO(ConfigurationManager.AppSettings["DbFolder"]);
                etudiantBLO.CreateEtudiant(etudiant);
                IEnumerable<Etudiant> etudiants = etudiantBLO.GetAllEtudiants();
                foreach (Etudiant E in etudiants)
                {
                    Console.WriteLine($"{E.First_Name}\t{E.Last_Name}");
                }
                Console.WriteLine("Create another Etudiant ? [y/n]");
                choice = Console.ReadLine();

            } while (choice.ToLower() != "n");
            Console.WriteLine("Program end !");

            Console.ReadKey();
        }
    }
}
