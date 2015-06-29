using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Wiskunde_App.DataAccess.Repositories;
using Microsoft.AspNet.Identity.EntityFramework;
using Wiskunde_App.DataAccess.Services;
using Wiskunde_App.Models;
using Wiskunde_App.ViewModels;
using Wiskunde_App.DataAccess.Context;
using Wiskunde_App.App_Start;
using Microsoft.AspNet.Identity.Owin;

namespace Wiskunde_App.Controllers
{
    [Authorize]
    public class BeheerController : Controller
    {

        private ApplicationUserManager _userManager;

        public BeheerController()
        {

        }


        public BeheerController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ??
                    HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Beheer
        [AllowAnonymous]
        public ActionResult Index( )
        {
            if(User.Identity.IsAuthenticated)
            {
                AuthenticationManager.SignOut();
                return RedirectToAction("Index", "Beheer");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //Functie van de controller waarmee de superuser en schooladministrator kunnen inloggen in de applicatie
        public async Task<ActionResult> Index(SUViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.RememberMe = true;
                var user = await UserManager.FindAsync(model.Gebruikersnaam, model.Wachtwoord);
                if (user != null)
                {
                        await SignInAsync(user, model.RememberMe);
                        if (UserManager.IsInRole(user.Id.ToString(), "Superuser"))
                        {
                            return RedirectToAction("Dashboard", "Super");
                        }
                        if (await UserManager.IsInRoleAsync(user.Id.ToString(), "Schooladmin"))
                        {
                            return RedirectToAction("Dashboard", "Admin");
                        }
                        if (await UserManager.IsInRoleAsync(user.Id.ToString(), "Leerkracht"))
                        {
                            return RedirectToAction("Dashboard", "Leerkracht");
                        }
                }
                    else
                    {
                        ModelState.AddModelError("", "Verkeerde gebruikersnaam of wachtwoord.");
                    }
            }
            return View(model);
        }

      //Partialview om wachtwoord te wijzigen
      public ActionResult Wachtwoordwijzigen()
       {
          return PartialView();
       }


      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<ActionResult> Wachtwoordwijzigen(WijzigWachtwoordVM model)
      {
          bool hasPassword = HasPassword();
          ViewBag.HasLocalPassword = hasPassword;
          if(hasPassword)
          {
              if(ModelState.IsValid)
              {
                  IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.NieuwPaswoord, model.HerhaalPaswoord);
                  if(result.Succeeded)
                  {
                      AuthenticationManager.SignOut();
                      return RedirectToAction("Index", "Beheer");
                  }
              }
          }
          return View();
      }

        //Bool hasPassword
        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if(user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }






        //Uitlogmechanisme
       [HttpPost]
       [ValidateAntiForgeryToken]
       public ActionResult Uitloggen()
       {
           AuthenticationManager.SignOut();
           return RedirectToAction("Index", "Beheer");
       }

       private IAuthenticationManager AuthenticationManager
       {
           get
           {
               return HttpContext.GetOwinContext().Authentication;
           }
       }

       //Deze methode dient om in de superuser administrators te kunnen toevoegen aan een school
       [Authorize(Roles = "Superuser")]
        public ActionResult VoegAdminUserToe()
        {
           SAViewModel model = new SAViewModel();
           Gebruikersrepository rep = new Gebruikersrepository();
           List<School> schoolnamen = new List<School>();
           schoolnamen = rep.GetScholen();
           model.scholen = schoolnamen;
           return View(model);
        }

       [HttpPost]
       public ActionResult VoegAdminUserToe(SAViewModel model)
       {
           if (ModelState.IsValid)
           {
               model.SchoolID = Convert.ToInt32(Request.Form["schoolkeuze"]);
               var user = new ApplicationUser() { UserName = model.Gebruikersnaam, Voornaam = model.Voornaam, Familienaam = model.Familienaam, SchoolID = model.SchoolID };
               var result = UserManager.Create(user, model.Wachtwoord);
               //service.AddUserToRoleSchooladmin(user.Id);
               if (result.Succeeded)
               { 
                   UserManager.AddToRole(user.Id, "Schooladmin");
                   return RedirectToAction("Dashboard", "Super");
               }
               else
               {
                   ModelState.AddModelError("", "De nieuwe schooladministrator werd niet geregistreerd. Probeer opnieuw.");
                   ModelState.AddModelError("Wachtwoord", "Het wachtwoord moet uit minstens 6 tekens bestaan.");
                   Gebruikersrepository rep = new Gebruikersrepository();
                   model.scholen = rep.GetScholen();
                   return View(model);
               }
           }
           Gebruikersrepository rep1 = new Gebruikersrepository();
           model.scholen = rep1.GetScholen();
           return View(model);
       }


        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, await user.GenerateUserIdentityAsync(UserManager));
        }

      


    }
}
