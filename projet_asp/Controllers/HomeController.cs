using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test_base_donnee_indemnite.Models;

namespace projet_asp.Controllers
{
    public class HomeController : Controller
    {
        DbContextIndimnite c = new DbContextIndimnite();
        public ActionResult Index()
        {
            //retourner le nombre de ligne de la table utilisateur
            var count_utilisateur = (from o in c.personnels select o).Count();
            ViewBag.count_utilisateur = count_utilisateur;
            //retourner le nombre de ligne de la table ordreVirement
            var count_virement = (from o in c.ordrevirement select o).Count();
            ViewBag.count_virement = count_virement;
            //retourner le nombre de ligne des mission approuvé la table ordremission
            var count_mission_approuve = c.ordremission.Count(t => t.etat == true);
            ViewBag.count_mission_approuve = count_mission_approuve;
            //retourner le nombre de ligne des mission approuvé la table ordremission
            var count_mission_non_approuve = c.ordremission.Count(t => t.etat == false);
            ViewBag.count_mission_non_approuve = count_mission_non_approuve;
            return View();
        }
        public ActionResult IndexPersonnel()
        {
            return View();
        }


    }
}