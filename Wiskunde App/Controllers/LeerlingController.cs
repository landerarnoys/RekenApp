using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wiskunde_App.Controllers
{
    public class LeerlingController : Controller
    {
        // GET: Leerling
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Loginstap2()
        {
            return View();
        }

        public ActionResult Loginstap3()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        // GET: Leerling/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Leerling/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Leerling/Create
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

        // GET: Leerling/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Leerling/Edit/5
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

        // GET: Leerling/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Leerling/Delete/5
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
