﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projet_asp.Controllers
{
    public class OrdreController : Controller
    {
        // GET: Ordre/Index

        public ActionResult Index()
        {
            return View();
        }
        // GET: Ordre/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ordre/Create
        public ActionResult Create()
        {
            return View();
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
