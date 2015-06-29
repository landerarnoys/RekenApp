using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wiskunde_App.DataAccess.Repositories;
using Wiskunde_App.DataAccess.UOW;
using Wiskunde_App.Models;

namespace Wiskunde_App.DataAccess.Services
{
    public class Superuserservice : ISuperuserservice
    {
        private IUOW uow = null;
        private IGenericRepository<School> SchoolRepository;
        private ISchoolRepository userRepository;

        public Superuserservice(IUOW uow, IGenericRepository<School> ScholenRepository,
            ISchoolRepository scholen2Repository)
        {
            this.uow = uow;
            this.SchoolRepository = ScholenRepository;
            this.userRepository = scholen2Repository;
        }

        public Superuserservice()
        {

        }

        public List<School> AllSchools()
        {
            return SchoolRepository.All().ToList<School>();
        }

        public School Voegschooltoe(School school)
        {
            SchoolRepository.Insert(school);
            uow.SaveChanges();
            return school;
        }

        public School HaalschoolopmetID(int id)
        {
            School school = SchoolRepository.GetByID(id);
            return school;
        }

        public School Updateschool(School school)
        {
            SchoolRepository.Update(school);
            uow.SaveChanges();
            return school;
        }

        public School Verwijderschool(int ID)
        {
            School school = SchoolRepository.GetByID(ID);
            SchoolRepository.Delete(school);
            uow.SaveChanges();
            return school;
        }


       



    }
}