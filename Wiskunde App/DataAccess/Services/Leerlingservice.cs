using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wiskunde_App.DataAccess.Context;
using Wiskunde_App.DataAccess.Repositories;
using Wiskunde_App.DataAccess.UOW;
using Wiskunde_App.Models;
using System.Data.Entity;

namespace Wiskunde_App.DataAccess.Services
{
    public class Leerlingservice : ILeerlingservice
    {
        private IUOW uow = null;
        private IGenericRepository<Leerling> LeerlingRepository;
        private ILeerlingrepository lrepository;

        public Leerlingservice(IUOW uow, IGenericRepository<Leerling> LeerlingRepository, ILeerlingrepository repository)
        {
            this.uow = uow;
            this.LeerlingRepository = LeerlingRepository;
            this.lrepository = repository;
        }

        public Leerlingservice()
        {

        }

        public List<Leerling> Haalleerlingenvanschoolop(int LeerlingschoolID)
        {
            return lrepository.Haalleerlingenschoolop(LeerlingschoolID);
        }

        public Leerling HaalLeerlingopmetID(int id)
        {
            Leerling leerling = LeerlingRepository.GetByID(id);
            return leerling;
        }

        public Leerling Updateleerling(Leerling leerling)
        {
            LeerlingRepository.Update(leerling);
            uow.SaveChanges();
            return  leerling;
        }

        public Leerling Verwijderleerling(int id)
        {
            Leerling leerling = LeerlingRepository.GetByID(id);
            LeerlingRepository.Delete(leerling);
            uow.SaveChanges();
            return leerling;
        }

        public Leerling Voegleerlingtoe(Leerling leerling)
        {
            LeerlingRepository.Insert(leerling);
            uow.SaveChanges();
            return leerling;
        }



    }
}