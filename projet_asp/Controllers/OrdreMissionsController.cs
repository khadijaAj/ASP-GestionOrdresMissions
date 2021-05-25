using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using test_base_donnee_indemnite.Models;

namespace projet_asp.Controllers
{
    public class OrdreMissionsController : Controller
    {
        private DbContextIndimnite db = new DbContextIndimnite();

        // GET: OrdreMissions
        public ActionResult Index()
        {
            return View(db.ordremission.ToList());
        }

        
    }
}
