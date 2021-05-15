using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projet_asp.Controllers
{
    public class VirementController : Controller
    {
        // GET: Virement

        public ActionResult ListVirement()
        {
            return View();
        }
    }
}