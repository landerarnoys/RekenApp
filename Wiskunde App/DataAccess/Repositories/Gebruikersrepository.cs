using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wiskunde_App.DataAccess.Context;
using Wiskunde_App.Models;
using System.Data.Entity;
using Wiskunde_App.ViewModels;

namespace Wiskunde_App.DataAccess.Repositories
{
    public class Gebruikersrepository : GenericRepository<ApplicationUser>, IGebruikersrepository
    {
        private WiskundeContext context;

        public Gebruikersrepository(WiskundeContext context)
        {
            this.context = context;
        }

        public Gebruikersrepository()
        {

        }

        public List<School> GetScholen()
        {
            using (WiskundeContext context = new WiskundeContext())
            {
                var query = (from c in context.School
                             select c);
                return query.ToList<School>();
            }
        }


        public IEnumerable<LeerkrachtSchoolKlas> Toonalleklassenmetleerkrachten(int gebruikersnaam)
        {
            using (WiskundeContext context = new WiskundeContext())
            {
                var query = (from w in context.LeerkrachtSchoolKlas.Include(c => c.leerkracht).Include(c => c.school).Include(c => c.klas) select w);

                return query;
            }
        }

        //public List<ApplicationUser> Toonalleschooladministrators()
        public List<ApplicationUser> Toonalleschooladministrators()
        {
            using(WiskundeContext context = new WiskundeContext())
            {
                var query = (from w in context.Users.Include(c => c.school) where w.Roles.Any(c => c.Role.Name == "Schooladmin")
                             select w);

                return query.ToList();
            }
        }
        

        

        
    }
}