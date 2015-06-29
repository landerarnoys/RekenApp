using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wiskunde_App.DataAccess.Context;
using Wiskunde_App.Models;
using System.Data.Entity;

namespace Wiskunde_App.DataAccess.Repositories
{
    public class Leerlingrepository : GenericRepository<Leerling>, ILeerlingrepository
    {
        private WiskundeContext context;

        public Leerlingrepository(WiskundeContext context)
        {
            this.context = context;
        }

        public Leerlingrepository()
        {
            
        }

        public List<Leerling> Haalleerlingenschoolop(int LeerlingschoolID)
        {
            using (WiskundeContext context = new WiskundeContext())
            {
                var query = (from w in context.Leerling.Include(c => c.klas)
                             where w.KlasID == LeerlingschoolID
                             select w);

                return query.ToList();
            }
        }

    }
}