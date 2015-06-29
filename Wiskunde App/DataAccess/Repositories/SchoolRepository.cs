using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wiskunde_App.DataAccess.Context;
using Wiskunde_App.Models;
using System.Data.Entity;

namespace Wiskunde_App.DataAccess.Repositories
{
    public class SchoolRepository : GenericRepository<School> , ISchoolRepository
    {
        private WiskundeContext context;

        public SchoolRepository(WiskundeContext context)
        {
            this.context = context;
        }

        public SchoolRepository()
        {

        }

        public override IEnumerable<School> All()
        {
            //volledig opbject ophalen, niet enkel naam
            
            return this.context.School;
        }



        

        
        

    }
 }
