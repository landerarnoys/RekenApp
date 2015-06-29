using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Wiskunde_App.App_Start;
using Wiskunde_App.DataAccess.Context;
using Wiskunde_App.DataAccess.Services;
using Wiskunde_App.Models;
using Wiskunde_App.ViewModels;
using Microsoft.AspNet.Identity.Owin;

namespace Wiskunde_App.Controllers
{

    public class LeerkrachtController : Controller
    {
        //private IUserManagementService service = null;
        private ApplicationUserManager _userManager;

        public LeerkrachtController()
        {

        }

        //public LeerkrachtController(IUserManagementService service)
        public LeerkrachtController(ApplicationUserManager userManager)
        {
            //this.service = service;
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

        [AllowAnonymous]
        //Loginpagina leerkracht
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                AuthenticationManager.SignOut();
                return RedirectToAction("Login", "Leerkracht");
            }
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(SUViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.RememberMe = true;
                var user = await UserManager.FindAsync(model.Gebruikersnaam, model.Wachtwoord);
                if (user != null)
                {
                    await SignInAsync(user, model.RememberMe);
                    if (await UserManager.IsInRoleAsync(user.Id.ToString(), "Super"))
                    {
                        return RedirectToAction("Dashboard", "Superuser");
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

       private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, await user.GenerateUserIdentityAsync(UserManager));
        }

     private IAuthenticationManager AuthenticationManager
     {
         get
         {
             return HttpContext.GetOwinContext().Authentication;
         }
     }

        
        public ActionResult Dashboard()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new WiskundeContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            if (currentUser != null)
            {
                ViewBag.Leerkracht = currentUser.Voornaam + " " + currentUser.Familienaam;
            }
            else
            {
                ViewBag.Leerkracht = "schooladministrator";
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Uitloggen()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login", "Leerkracht");
        }

        // GET: Leerkracht/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Leerkracht/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Leerkracht/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Leerkracht/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Leerkracht/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Leerkracht/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Leerkracht/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
