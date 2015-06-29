using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Wiskunde_App.App_Start;
using Wiskunde_App.DataAccess.Context;
using Wiskunde_App.DataAccess.Repositories;
using Wiskunde_App.DataAccess.Services;
using Wiskunde_App.Models;
using Wiskunde_App.ViewModels;
using Microsoft.AspNet.Identity.Owin;

namespace Wiskunde_App.Controllers
{
    public class SuperController : Controller
    {
        //Aanmaken instantie van de superuserservice
        private ISuperuserservice superuserservice = null;
        private IGebruikersservice gebruikerservice = null;
        private ApplicationUserManager _userManager;


        public SuperController()
            {

            }

        public SuperController(ISuperuserservice service, IGebruikersservice userservice, ApplicationUserManager userManager)
          {
            superuserservice = service;
            gebruikerservice = userservice;
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
       

       [Authorize(Roles="Superuser")]
        public ActionResult Dashboard()
        {
            List<School> Scholen = superuserservice.AllSchools();
            return View(Scholen);

        }

        public ActionResult Accountwijzigen()
        {
           return View();
        }

        //
        // GET: /Super/Details/5
         [Authorize(Roles = "Superuser")]
        public ActionResult Details(int id)
        {
            School school = superuserservice.HaalschoolopmetID(id);
            return View(school);
        }

        //
        // GET: /Super/Create
         [Authorize(Roles = "Superuser")]
        public ActionResult Nieuweschool()
        {
            return View();
        }

        //
        // POST: /Super/Create
        [HttpPost]
        [Authorize(Roles = "Superuser")]
        public ActionResult Nieuweschool(School school)
        {
            try
            {
                // TODO: Add insert logic here
                school.Naam = Request.Form["Naam"];
                school.Adres = Request.Form["Adres"];
                school.Huisnummer = Convert.ToInt32(Request.Form["Huisnummer"]);
                school.Postcode = Convert.ToInt32(Request.Form["Postcode"]);
                school.Gemeente = Request.Form["Gemeente"];
                if (Request.Form["LogoUrl"] != null)
                {
                    school.LogoUrl = Request.Form["LogoUrl"];
                }
                superuserservice.Voegschooltoe(school);
                return RedirectToAction("Dashboard");
            }
            catch
            {
                return View();
            }
        }

        //Wijzigen schooladministrator
        public ActionResult Wijzigadministrator(String id)
        {
            WiskundeContext context = new WiskundeContext();
            var user = context.Users.Find(id);
            Gebruikersrepository rep = new Gebruikersrepository();
            user.scholen = rep.GetScholen();
            return View(user);
        }

        //Wijzigen schooladministrator post-functie
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Wijzigadministrator(ApplicationUser user)
        {
                ApplicationUser gebruiker = UserManager.FindById(user.Id);
                if (gebruiker != null)
                {
                    gebruiker.Voornaam = Request.Form["Voornaam"];
                    gebruiker.Familienaam = Request.Form["Familienaam"];
                    gebruiker.SchoolID = Convert.ToInt32(Request.Form["schoolkeuze"]);
                    gebruiker.KlasID = 0;
                    gebruiker.UserName = Request.Form["UserName"];
                    String paswoord = Request.Form["wachtwoord"];
                    UserManager.RemovePassword(user.Id);
                    UserManager.AddPassword(user.Id, paswoord);

                    IdentityResult result = await UserManager.UpdateAsync(gebruiker);
                }
                else
                {
                    ModelState.AddModelError("", "Er is iets fout gelopen met de wijziging van de account.");
                    Gebruikersrepository rep = new Gebruikersrepository();
                    user.scholen = rep.GetScholen();
                    return View(user);
                }
                return RedirectToAction("overzichtadmins", "Super");
        }

        //Details schooladministrator bekijken
        public ActionResult Detailsadministrator(String id)
        {
            WiskundeContext context = new WiskundeContext();
            var user = context.Users.Find(id);
            return View(user);
        }

        //Delete schooladministrator
        public ActionResult Deleteadministrator(int id)
        {
            return View();
        }

        //POST-Functie delete schooladministrator
        [HttpPost]
        public ActionResult Deleteadministrator(int id, FormCollection collection)
        {
            return View();
        }

        //
        // GET: /Super/Edit/5
         [Authorize(Roles = "Superuser")]
        public ActionResult Wijzigschool(int id)
        {
            School school = superuserservice.HaalschoolopmetID(id);
            return View(school);
        }

        //
        // POST: /Super/Edit/5
        [HttpPost]
        [Authorize(Roles = "Superuser")]
        public ActionResult Wijzigschool(School school)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    superuserservice.Updateschool(school);
                    return RedirectToAction("Dashboard");
                }
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Onmogelijk om gegevens op te slaan. Als het probleem blijft bestaan, contacteer de administrator.");
            }
            return View(school);
        }

        //
        // GET: /Super/Delete/5
        [Authorize(Roles = "Superuser")]
        public ActionResult Delete(int id)
        {
            School school = superuserservice.HaalschoolopmetID(id);
            return View(school);
        }

        //
        // POST: /Super/Delete/5
        [HttpPost]
        [Authorize(Roles = "Superuser")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                School school = superuserservice.Verwijderschool(id);
                return RedirectToAction("Dashboard");
            }
            catch
            {
                return View();
            }
        }


        //Probeerfunctie om alle administrators weer te geven in een view 
        public ActionResult overzichtadmins()
        {
            List<ApplicationUser> users = gebruikerservice.Toonalleschooladministrators();
            return View(users);
        }
       
       
    }
}
