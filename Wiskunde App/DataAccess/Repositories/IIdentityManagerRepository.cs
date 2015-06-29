using System;
using Wiskunde_App.Models;

namespace Wiskunde_App.DataAccess.Repositories {
    public interface IIdentityManagerRepository {
        bool AddUserToRole(string userId, string roleName);
        void ClearUserRoles(string userId);
        Microsoft.AspNet.Identity.IdentityResult Create(Wiskunde_App.Models.ApplicationUser user, string password);
        System.Threading.Tasks.Task<System.Security.Claims.ClaimsIdentity> CreateIdentityAsync(Wiskunde_App.Models.ApplicationUser user, string auth);
        bool CreateRole(string name, string description = "");
        Wiskunde_App.Models.ApplicationUser FindAsync(string userName, string password);
        bool RoleExists(string name);
        ApplicationUser GetUser(string userName);
    }
}
