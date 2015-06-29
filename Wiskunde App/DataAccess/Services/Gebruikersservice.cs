using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wiskunde_App.DataAccess.Repositories;
using Wiskunde_App.DataAccess.UOW;
using Wiskunde_App.Models;
using Wiskunde_App.ViewModels;

namespace Wiskunde_App.DataAccess.Services
{
    public class Gebruikersservice : IGebruikersservice
    {
        IUOW uow = null;
        IGenericRepository<ApplicationUser> reposIdentity = null;
        IGebruikersrepository repository = null;

        public Gebruikersservice()
        {
        }

        public Gebruikersservice(IUOW uow, IGenericRepository<ApplicationUser> reposID, IGebruikersrepository repository)
        {
            this.uow = uow;
            this.reposIdentity = reposID;
            this.repository = repository;
        }

        public List<ApplicationUser> Toonalleschooladministrators()
        {
            return repository.Toonalleschooladministrators();
        }
    }
}