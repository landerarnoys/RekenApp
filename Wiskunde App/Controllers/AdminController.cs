using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Wiskunde_App.App_Start;
using Wiskunde_App.DataAccess.Context;
using Wiskunde_App.DataAccess.Services;
using Wiskunde_App.Models;
using Wiskunde_App.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using System.IO;

namespace Wiskunde_App.Controllers
{
    public class AdminController : Controller
    {
        //Aanmaken instantie van de superuserservice
        private Iklasservice klasservice = null;
        private ILeerlingservice leerlingservice = null;
        private ApplicationUserManager _userManager;


        public AdminController()
            {

            }


        public AdminController(Iklasservice service, ApplicationUserManager userManager, ILeerlingservice lservice)
          {
            klasservice = service;
            UserManager = userManager;
            leerlingservice = lservice;
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

        public ActionResult Wijzigwachtwoord()
        {
            return View();
        }

        [Authorize(Roles = "Schooladmin")]
        public ActionResult Klassen()
        {
            var currentUser = UserManager.FindById(User.Identity.GetUserId());
            if (currentUser == null)
            {
                currentUser = UserManager.FindById(User.Identity.GetUserId());
            }
            List<LeerkrachtSchoolKlas> klassen = klasservice.Haalklassenvanschoolopmetleerkrachten(currentUser.SchoolID);
            return View(klassen);
        }

        public ActionResult Leerkrachten()
        {
            var currentUser = UserManager.FindById(User.Identity.GetUserId());
            if(currentUser != null)
            {
                currentUser = UserManager.FindById(User.Identity.GetUserId());
            }
            List<LeerkrachtSchoolKlas> leerkrachten = klasservice.Haalleerkrachtenop(currentUser.SchoolID);
            return View(leerkrachten);
        }


        public ActionResult Leerlingen()
        {
            //Haal klassen op en display ze in de view in een combobox. On submit verschijnt in de view een lijst met het geselecteerde
            //KlasID van de klas
            KlaskeuzeVM viewmodel = new KlaskeuzeVM();
            var currentUser = UserManager.FindById(User.Identity.GetUserId());
            if(currentUser != null)
            {
                currentUser = UserManager.FindById(User.Identity.GetUserId());
            }
            List<LeerkrachtSchoolKlas> klassen = klasservice.Haalklassenop(currentUser.SchoolID);
            viewmodel.klassen = klassen;
            return View(viewmodel);
        }

        //Partial view tonen om leerlingen van een bepaalde klas te zien
        public ActionResult Toonleerlingen()
        {
            String klasid = Request.Form["klaskeuze"];
            List<Leerling> Leerlingen = leerlingservice.Haalleerlingenvanschoolop(Convert.ToInt32(klasid));
            return PartialView("Overzichtleerlingen", Leerlingen);
        }

        //functie om nieuwe leerling toe te voegen
        public ActionResult Voegnieuweleerlingtoe()
        {
            Leerling leerling = new Leerling();
            var currentUser = UserManager.FindById(User.Identity.GetUserId());
            if (currentUser != null)
            {
                currentUser = UserManager.FindById(User.Identity.GetUserId());
            }
            leerling.klassen = klasservice.Haalklassenop(currentUser.SchoolID);
            return View(leerling);
        }


        //POSTFUNCTIE: nieuwe leerling ophalen uit het formulier + uploaden afbeelding nieuwe leerling
        [HttpPost]
        public ActionResult Voegnieuweleerlingtoe(Leerling leerling, HttpPostedFileBase FotoLeerling)
        {
            if (ModelState.IsValid)
            {
                var huidigegebruiker = UserManager.FindById(User.Identity.GetUserId());
                if (huidigegebruiker != null)
                {
                    leerling.SchoolID = huidigegebruiker.SchoolID;
                    leerling.KlasID = Convert.ToInt32(Request.Form["klaskeuze"]);
                    if (FotoLeerling.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(FotoLeerling.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images/Leerlingen"), fileName);
                        FotoLeerling.SaveAs(path);
                        leerling.FotoLeerling = fileName;
                    }
                }
                leerlingservice.Voegleerlingtoe(leerling);
                return RedirectToAction("Leerlingen");
            }
            else
            {
                return View(leerling);
            }
        }

        //Functie om leerling te wijzigen binnen de admin van de schoolomgeving
        public ActionResult Wijzigleerling(int id)
        {
            Leerling leerling = leerlingservice.HaalLeerlingopmetID(id);
            var currentUser = UserManager.FindById(User.Identity.GetUserId());
            if(currentUser != null)
            {
                currentUser = UserManager.FindById(User.Identity.GetUserId());
            }
            leerling.klassen = klasservice.Haalklassenop(currentUser.SchoolID);
            return View(leerling);
        }

        //POST Wijzig leerling
        [HttpPost]
        public ActionResult Wijzigleerling(Leerling leerling, HttpPostedFileBase FotoLeerling)
        {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    leerling.KlasID = Convert.ToInt32(Request.Form["klaskeuze"]);
                    var user = UserManager.FindById(User.Identity.GetUserId());
                    leerling.SchoolID = user.SchoolID;
                    //leerling.Level = 1;
                    //leerling.GemaakteOefeningen = 1;
                    if (FotoLeerling.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(FotoLeerling.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images/Leerlingen"), fileName);
                        FotoLeerling.SaveAs(path);
                        leerling.FotoLeerling = fileName;
                    }
                    leerlingservice.Updateleerling(leerling); 
                    return RedirectToAction("Leerlingen");
                }
                return View(leerling);    
            }

        
        //Leerling verwijderen
        public ActionResult Verwijderleerling(int id)
        {
            Leerling leerling = leerlingservice.HaalLeerlingopmetID(id);
            return View(leerling);
        }

        [HttpPost]
        [Authorize(Roles = "Schooladmin")]
        public ActionResult Verwijderleerling(int id, FormCollection collection)
        {
            try
            {
                Leerling leerling = leerlingservice.Verwijderleerling(id);
                return RedirectToAction("Leerlingen");
            }
            catch
            {
                return View();
            }
        }


        //Details leerling bekijken
        [Authorize(Roles="Schooladmin")]
        public ActionResult Detailsleerling(int id)
        {
            Leerling leerling = leerlingservice.HaalLeerlingopmetID(id);
            return View(leerling);
        }

       [Authorize(Roles = "Schooladmin")]
        public ActionResult Dashboard()
        {
           //1.User ophalen die geauthenticeerd is 
          //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new WiskundeContext()));
          var currentUser = UserManager.FindById(User.Identity.GetUserId());
          if (currentUser != null)
          {
              ViewBag.ingelogdegebruiker = currentUser.Voornaam + " " + currentUser.Familienaam;
          }
          else
          {
              ViewBag.ingelogdegebruiker = "schooladministrator";
          }
       
            return View();
        }

        //
        // GET: /Admin/Delete/5
        [Authorize(Roles = "Schooladmin")]
        public ActionResult DeleteKlas(int id)
        {
            LeerkrachtSchoolKlas slk = new LeerkrachtSchoolKlas();
            slk = klasservice.getLeerkrachtSchoolKlas(id);
            klasservice.removeClass(slk);
            return View("Dashboard");
        }

        //
        // POST: /Admin/Delete/5
        [HttpPost]
        [Authorize(Roles = "Schooladmin")]
        public ActionResult DeleteKlas(int id, FormCollection collection)
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

        
        [Authorize(Roles = "Schooladmin")]
        public ActionResult DetailsKlas(int id)
        {
            Klas klas = new Klas();
            klas = klasservice.getKlasById(id).First();

            return View(klas);
        }


        [HttpPost]
        [Authorize(Roles = "Schooladmin")]
        public ActionResult EditKlas(int id, FormCollection collection)
        {
            Klas klas = new Klas();
            klas.ID = id;
            klas.KlasNaam =  collection["KlasNaam"];
            klas.MaximumAantalLeerlingen = int.Parse(collection["MaximumAantalLeerlingen"]);
            klasservice.updateKlas(klas);
            try
            {
               

                return RedirectToAction("Dashboard");
            }
            catch
            {
                return View("Dashboard");
            }
        }


        [Authorize(Roles = "Schooladmin")]
        public ActionResult EditKlas(int id)
        {
            Klas klas = new Klas();
            klas = klasservice.getKlasById(id).First(); 
            return View(klas);
        }

        
        [Authorize(Roles = "Schooladmin")]
        public ActionResult DetailsLeerkracht(int id)
        {
            Leerkracht leerkracht = new Leerkracht();
            leerkracht = klasservice.getLeerkrachtById(id);
            return View(leerkracht);
        }

        [Authorize(Roles = "Schooladmin")]
        public ActionResult EditLeerkracht(int id)
        {
            Leerkracht leerkracht = new Leerkracht();
            leerkracht = klasservice.getLeerkrachtById(id);
            return View(leerkracht);
        }

        [HttpPost]
        [Authorize(Roles = "Schooladmin")]
        public ActionResult EditLeerkracht(int id, FormCollection collection)
        {
            Leerkracht leerkracht = new Leerkracht();
            leerkracht.VoorNaam = collection["VoorNaam"];
            leerkracht.FamilieNaam = collection["FamilieNaam"];
            leerkracht.ID = id;
            klasservice.updateLeerkracht(leerkracht);
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Dashboard");
            }
            catch
            {
                return View("Dashboard");
            }
        }

       
        [Authorize(Roles = "Schooladmin")]
        public ActionResult  DeleteLeerkracht(int id)
        {
            Leerkracht teVerwijderenLeerkracht = klasservice.getLeerkrachtById(id);
            klasservice.deleteLeerkracht(teVerwijderenLeerkracht);
            return View("Dashboard");
        }

    }
}
