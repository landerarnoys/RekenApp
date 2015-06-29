using Microsoft.AspNet.Identity;
using System;
using Wiskunde_App.Models;

namespace Wiskunde_App.DataAccess.Services {
    public interface IUserManagementService {
        IdentityResult Create(ApplicationUser user, string password);
        System.Threading.Tasks.Task<System.Security.Claims.ClaimsIdentity> CreateIdentityAsync(Wiskunde_App.Models.ApplicationUser user, string auth);
        Wiskunde_App.Models.ApplicationUser FindAsync(string userName, string password);
        bool AddUserToRoleUser(string userId);
        bool AddUserToRoleSchooladmin(string userId);
        ApplicationUser GetUser(string userName);
    }
}
