using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wiskunde_App.DataAccess.Repositories;
using Wiskunde_App.DataAccess.UOW;
using Wiskunde_App.Models;

namespace Wiskunde_App.DataAccess.Services
{
    public class Klasservice : Iklasservice
    {
        private IUOW uow = null;
        private IGenericRepository<Klas> KlasRepository;
        private IGenericRepository<LeerkrachtSchoolKlas> lskRepos;
        private IKlasRepository klasrepository;
 

        public Klasservice(IUOW uow, IGenericRepository<Klas> KlasRepository,  IGenericRepository<LeerkrachtSchoolKlas> lskRepos, IKlasRepository repository)
        {
            this.uow = uow;
            this.KlasRepository = KlasRepository;
            this.klasrepository = repository;
            this.lskRepos = lskRepos;
        }

        public Klasservice()
        {

        }

        public List<LeerkrachtSchoolKlas> Haalklassenvanschoolopmetleerkrachten(int schoolID)
        {
            //return klasrepository.Haalklassenopvanbepaaldeschool(schoolID).ToList<Klas>();
            return klasrepository.Toonalleklassenmetleerkrachten(schoolID);
        }

        public List<LeerkrachtSchoolKlas> Haalleerkrachtenop(int gebruikersid)
        {
            return klasrepository.Toonalleleerkrachten(gebruikersid);
        }

        public List<LeerkrachtSchoolKlas> Haalklassenop(int schoolid)
        {
            return klasrepository.Toonalleklassen(schoolid);
        }

        public void removeClass(LeerkrachtSchoolKlas slk)
        {
            klasrepository.deleteClass(slk);
        }

        public LeerkrachtSchoolKlas getLeerkrachtSchoolKlas(int id)
        {
            return lskRepos.GetByID(id);
        }
        
        public List<Klas> getKlasById(int id){
            return klasrepository.getKlasById(id);
        }

        public void updateKlas(Klas klas)
        {
            klasrepository.updateKlas(klas);
        }

        public Leerkracht getLeerkrachtById(int id)
        {
            return klasrepository.getLeerkrachtById(id);
        }

        public void updateLeerkracht(Leerkracht teEditerenLk)
        {
            klasrepository.updateLeerkracht(teEditerenLk);
        }

        public void deleteLeerkracht(Leerkracht leerkracht)
        {
            klasrepository.deleteLeerkracht(leerkracht);
        }
   
    }
}