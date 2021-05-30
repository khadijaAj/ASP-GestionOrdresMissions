using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test_base_donnee_indemnite.Models;

namespace projet_asp.Controllers
{

    public class VirementController : Controller
    {
        private DbContextIndimnite db = new DbContextIndimnite();
        // GET: Virement

        public ActionResult ListVirement()
        {
            return View();
        }
    }
}