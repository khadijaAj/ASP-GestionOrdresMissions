using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using test_base_donnee_indemnite.Models;

namespace projet_asp.Controllers
{
    public class OrdreController : Controller
    {
        private DbContextIndimnite db = new DbContextIndimnite();


        // GET: Ordre/Index
        public ActionResult Index()
        {
            return View(db.ordremission.ToList());
        }
         
        public ActionResult Kilo(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdreMission ordreMission = db.ordremission.Find(id);
            if (ordreMission == null)
            {
                return HttpNotFound();
            }
            ViewData["mois"] = ordreMission.dateDepart.Month.ToString("MMMM");
            DateTime now = DateTime.Now;
            ViewData["date"] = now.ToString("MM/dd/yyyy"); 
            ViewData["taux"] = 1.2;
            if (ordreMission.nombreCheuvaux > 6 && ordreMission.nombreCheuvaux < 10)
            {
                ViewData["taux"] = 1.75;
            }
            else
            {
                ViewData["taux"] =2.30;
            }
            ViewData["total"] = (double)ViewData["taux"] * (int)ordreMission.trajet.distance * 2;
            return View(ordreMission);
        }

     

        // POST: Ordre/Create
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

        // GET: Ordre/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ordre/Edit/5
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

        // GET: Ordre/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ordre/Delete/5
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
