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
        DbContextIndimnite db = new DbContextIndimnite();


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

        //login traitement 

        public ActionResult Login()
        {
            return View();

        }


        [HttpPost]
        public ActionResult Authorize(Personnel pers)
        {
            using (db)
            {
                Personnel userdetails = db.personnels.Where(a => a.Username == pers.Username && a.Password == pers.Password).FirstOrDefault();

                if (userdetails == null)
                {
                    ViewBag.error = "Entrer les informations !";

                    return View("Login");

                }
                else
                {

                    if (CheckRole(userdetails) == 1)
                    {
                        Session["nompersonnel"] = userdetails.Nom + " " + userdetails.Prenom;
                        Session["idpersonnel"] = userdetails.IdPers;


                        return RedirectToAction("IndexPersonnel", "Home");

                    }
                    else if (CheckRole(userdetails) == 0)
                    {
                        Session["nomeconomique"] = userdetails.Nom + " " + userdetails.Prenom; ;
                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        ViewBag.error = "les informations sont incorrect !";

                        return View("Login");
                    }


                }
            }

        }





        public int CheckRole(Personnel pers)
        {
            DbContextIndimnite db2 = new DbContextIndimnite();

            using (db2)
            {
                var userdetails = db2.personnels.Where(a => a.Username == pers.Username && a.Password == pers.Password).FirstOrDefault();

                if (userdetails.Role == "personnel")
                {
                    return 1;

                }
                else if (userdetails.Role == "economique")
                {
                    return 0;

                }
                else
                {
                    return -1;
                }


            }
        }



        //Afficher la liste des ordres de mission d'un personnel

        public ActionResult ListMesOrdresMissions()
        {
            DbContextIndimnite db1 = new DbContextIndimnite();
            int idperson = (int)Session["idpersonnel"];
            List<OrdreMission> listeordresmissions = db1.ordremission.Where(x => x.personel.IdPers == idperson).ToList();

            return View(listeordresmissions);

        }

        //Afficher la liste des ordres de virement d'un personnel


        public ActionResult ListOrdreVirement()
        {
            DbContextIndimnite db1 = new DbContextIndimnite();
            int personid = (int)Session["idpersonnel"];
            List<OrdreVirement> listeordresmissions = db.ordrevirement.Where(x => x.orderpaiment.ordermission.personel.IdPers == personid).ToList();

            return View(listeordresmissions);
        }







    }

 

 


  
}