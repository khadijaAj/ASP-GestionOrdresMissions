using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using test_base_donnee_indemnite.Models;

namespace projet_asp.Models
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("name=DataBaseContext")
        {

        }



        public DbSet<Personnel> personnels { get; set; }
        public DbSet<Cadre> cadres { get; set; }
        public DbSet<Corps> corp { get; set; }
        public DbSet<Grades> grade { get; set; }
        public DbSet<OrdreMission> ordremission { get; set; }
        public DbSet<OrdrePaiement> ordrepaiement { get; set; }
        public DbSet<OrdreVirement> ordrevirement { get; set; }
        public DbSet<Trajet> trajet { get; set; }
        public DbSet<ServiceEconomique> serviceeconomique { get; set; }
        public DbSet<ServicePersonnel> servicepersonnel { get; set; }
        public DbSet<Parameter> parametre { get; set; }
    }
}