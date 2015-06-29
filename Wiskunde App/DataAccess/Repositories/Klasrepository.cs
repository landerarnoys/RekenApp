using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wiskunde_App.DataAccess.Context;
using Wiskunde_App.Models;
using System.Data.Entity;

namespace Wiskunde_App.DataAccess.Repositories
{
    public class Klasrepository : GenericRepository<Klas>, IKlasRepository
    {
       private WiskundeContext context;
       private IGenericRepository<Leerling> leerlingrespos;

       public Klasrepository(WiskundeContext context, IGenericRepository<Leerling> leerlingrespos)
        {
            this.context = context;
            this.leerlingrespos = leerlingrespos;
        }

        public Klasrepository()
        {
            
        }


        public IEnumerable<Klas> Haalklassenopvanbepaaldeschool(int Gebruikersid)
        {
            var query = (from w in context.Klas where w.SchoolID == Gebruikersid select w);

            return query;
        }

        public List<Klas> getKlasById(int klasId)
        {
            using (WiskundeContext context = new WiskundeContext())
            {
                var query = (from w in context.Klas.Include(c => c.leerlingen)
                             where w.ID == klasId
                             select w);
                return query.ToList();
            }
        }

      

        

        public List<LeerkrachtSchoolKlas> Toonalleklassenmetleerkrachten(int schoolId)
        {
            using (WiskundeContext context = new WiskundeContext())
            {
                var query = (from w in context.LeerkrachtSchoolKlas.Include(c => c.leerkracht).Include(c => c.klas) where w.SchoolID == schoolId
                             select w);
                List<LeerkrachtSchoolKlas> yo = query.ToList();
                return query.ToList();
            }
        }


        public void deleteClass(LeerkrachtSchoolKlas leerkrachtSchoolKlas)
        {
            using (WiskundeContext context = new WiskundeContext())
            {
    
                LeerkrachtSchoolKlas lks = context.LeerkrachtSchoolKlas.Find(leerkrachtSchoolKlas.ID);
                //School school = context.School.Find(leerkrachtSchoolKlas.SchoolID);
                //Leerkracht leerkracht = context.Leerkracht.Find(leerkrachtSchoolKlas.LeerKrachtID);
                Klas klas = context.Klas.Find(leerkrachtSchoolKlas.KlasID);
            
                //
          
                List<Leerling> lln = new List<Leerling>();
                lln = HaalleerlingenvanschoolopViaKlasId((int)leerkrachtSchoolKlas.KlasID);

                foreach (Leerling leerling in lln)
                {
                    Leerling l = context.Leerling.Find(leerling.ID);
                    context.Leerling.Remove(l);
                }
          
                
                //deleten
                //context.Klas.Remove(klas);
                context.LeerkrachtSchoolKlas.Remove(lks);
                context.Klas.Remove(klas);
                
                context.SaveChanges();
            }
        }

        public List<LeerkrachtSchoolKlas> Toonalleleerkrachten(int gebruikersschoolID)
        {
            using (WiskundeContext context = new WiskundeContext())
            {
                List<LeerkrachtSchoolKlas> query = (from w in context.LeerkrachtSchoolKlas.Include(c => c.leerkracht) where w.SchoolID == gebruikersschoolID select w).ToList();
                List<LeerkrachtSchoolKlas> nonDuplicaten = new List<LeerkrachtSchoolKlas>();

                int vorignr = 0;
                foreach (LeerkrachtSchoolKlas lsk in query)
                {
                    if (lsk.LeerKrachtID != vorignr)
                    {
                        nonDuplicaten.Add(lsk);
                        vorignr = (int)lsk.LeerKrachtID;
                    }
              
                }


                
                return nonDuplicaten;
            }

        }

        public List<LeerkrachtSchoolKlas> Toonalleklassen(int schoolID)
        {
            using(WiskundeContext context = new WiskundeContext())
            {
                var query = (from w in context.LeerkrachtSchoolKlas.Include(c => c.klas) where w.SchoolID == schoolID select w);

                return query.ToList();
            }
        }



        public List<Leerling> HaalleerlingenvanschoolopViaKlasId(int klasID)
        {
            using (WiskundeContext context = new WiskundeContext())
            {
                var query = (from w in context.Leerling.Include(c => c.klas)
                             where w.KlasID == klasID
                             select w);

                return query.ToList();
            }
        }

        public void updateKlas(Klas klas)
        {
              using (WiskundeContext context = new WiskundeContext())
            {
                Klas k = context.Klas.First(c => c.ID == klas.ID);
                k.KlasNaam = klas.KlasNaam;
                k.MaximumAantalLeerlingen = klas.MaximumAantalLeerlingen;
                context.SaveChanges();
            }
        }

        public Leerkracht getLeerkrachtById(int id)
        {
            using (WiskundeContext context = new WiskundeContext())
            {
                Leerkracht k = context.Leerkracht.First(l => l.ID == id);
                k.klassen = getKlassenByLeerkrachtId(id);
                return k;
            }
        }

        public List<LeerkrachtSchoolKlas> getKlassenByLeerkrachtId(int id)
        {
            using (WiskundeContext context = new WiskundeContext())
            {
                var query = (from w in context.LeerkrachtSchoolKlas.Include(c => c.klas) where w.KlasID == id select w);
                return query.ToList();
            }
        }


        public void updateLeerkracht(Leerkracht teEditerenLk)
        {
            using (WiskundeContext context = new WiskundeContext())
            {
                Leerkracht leerkracht = context.Leerkracht.First(l => l.ID == teEditerenLk.ID);
                leerkracht.FamilieNaam = teEditerenLk.FamilieNaam;
                leerkracht.VoorNaam = teEditerenLk.VoorNaam;
                context.SaveChanges();
            }
        }




        public void deleteLeerkracht(Leerkracht leerkracht)
        {
            using (WiskundeContext context = new WiskundeContext())
            {

                List<LeerkrachtSchoolKlas> lks = getLKSByLeerkrachtId(leerkracht.ID);
                foreach(LeerkrachtSchoolKlas lk in lks)
                {
                    lk.LeerKrachtID = null;
                    context.SaveChanges();
                }
               
                Leerkracht teVerwijderenLeerkracht = context.Leerkracht.Find(leerkracht.ID);
                context.Leerkracht.Remove(teVerwijderenLeerkracht);
                context.SaveChanges();
            }
        }


        public List<LeerkrachtSchoolKlas> getLKSByLeerkrachtId(int id)
        {
            using (WiskundeContext context = new WiskundeContext())
            {
                var query = (from w in context.LeerkrachtSchoolKlas.Include(c => c.klas) where w.LeerKrachtID == id select w);
                return query.ToList();
            }
        }



    }
}