using Microsoft.AspNet.Identity;
using Wiskunde_App.DataAccess.Repositories;
using Wiskunde_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Wiskunde_App.DataAccess.Services {
    public class UserManagementService : IUserManagementService {

        private IIdentityManagerRepository identityRepository = null;

        public UserManagementService() {

        }

        public UserManagementService(IIdentityManagerRepository repo) {
            this.identityRepository = repo;
        }

        public ApplicationUser FindAsync(string userName, string password) {
            return identityRepository.FindAsync(userName, password);
        }

        public Task<ClaimsIdentity> CreateIdentityAsync(ApplicationUser user, string auth) {
            return identityRepository.CreateIdentityAsync(user, auth);
        }

        //Functie om paswoord aan te passen


        public IdentityResult Create(ApplicationUser user, string password) {
            return identityRepository.Create(user, password);
        }

        public bool AddUserToRoleUser(string userId) {
            return identityRepository.AddUserToRole(userId, "User");
        }

        public bool AddUserToRoleSchooladmin(string userId)
        {
            return identityRepository.AddUserToRole(userId, "Schooladmin");
        }

        public ApplicationUser GetUser(string userName) {
            return identityRepository.GetUser(userName);
        }
    }
}