using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wiskunde_App.Controllers
{
    public class OefeningController : Controller
    {
        // GET: Oefening
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Level()
        {
            return View();
        }

        // GET: Oefening/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Oefening/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Oefening/Create
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

        // GET: Oefening/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Oefening/Edit/5
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

        // GET: Oefening/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Oefening/Delete/5
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
