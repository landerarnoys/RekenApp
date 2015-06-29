using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Wiskunde_App.DataAccess.Repositories;
using Wiskunde_App.DataAccess.UOW;
using Wiskunde_App.Models;

namespace Wiskunde_App.DataAccess.Services
{
    public class OefeningService : Wiskunde_App.DataAccess.Services.IOefeningService
    {
        IUOW uow = null;
        IGenericRepository<Oefeningen> reposOef = null;
        IGenericRepository<Resultaten> reposRes = null;

        public OefeningService()
        {
        }

        public OefeningService(IUOW uow, IGenericRepository<Oefeningen> reposOef, IGenericRepository<Resultaten> reposRes)
        {
            this.uow = uow;
            this.reposOef = reposOef;
            this.reposRes = reposRes;
        }

        public Oefeningen getOefeningById(int id)
        {
            return reposOef.GetByID(id);
        }

        public List<Oefeningen> getAlleOefeningen()
        {
            return reposOef.All().ToList();
        }

        public Resultaten addResultaat(Resultaten resultaat){
            resultaat.Datum = DateTime.Now.ToString();

            reposRes.Insert(resultaat);
            
            uow.SaveChanges();

            return resultaat;
        }

    }
}