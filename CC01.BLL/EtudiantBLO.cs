using CC01.BO;
using CC01.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC01.BLL
{
    public class EtudiantBLO
    {
        EtudiantDAO etudiantRepo;

        
        public EtudiantBLO(string dbfolder)
        {
            etudiantRepo = new EtudiantDAO(dbfolder);
        }
        public void CreateEtudiant(Etudiant etudiant)
        {
            etudiantRepo.add(etudiant);
        }

        internal void Add(Etudiant etudiant)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Etudiant etudiant)
        {
            etudiantRepo.Remove(etudiant);
        }
        public IEnumerable<Etudiant> GetAllEtudiants()
        {
            return etudiantRepo.Find();
        }

      
        public object GetBFirst_Name(string First_Name)
        {
            return etudiantRepo.Find(x => x.First_Name==First_Name);
        }


        public object GetBy(Func<Etudiant, bool> predicate)
        {
            return etudiantRepo.Find(predicate);
        }

       

        /* public object GetBy(Func<object, bool> p)
         {
             throw new NotImplementedException();
         }*/

        /*  public void Editproduct(Etudiant  oldproduct, Etudiant newProduct)
          {
              etudiantRepo.Set(oldetudiant, newEtudiant);
          }*/


    }
}
