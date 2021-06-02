namespace projet_asp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ServiceEconomique", "IdPers", "dbo.Personnels");
            DropForeignKey("dbo.ServicePersonnel", "IdPers", "dbo.Personnels");
            DropIndex("dbo.ServiceEconomique", new[] { "IdPers" });
            DropIndex("dbo.ServicePersonnel", new[] { "IdPers" });
            CreateTable(
                "dbo.Parametre_paiement",
                c => new
                    {
                        id_param_paiement = c.Int(nullable: false, identity: true),
                        Art = c.Int(nullable: false),
                        num1 = c.Int(nullable: false),
                        num2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_param_paiement);
            
            CreateTable(
                "dbo.Parametre_voiture",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre_cheveau_min = c.Int(nullable: false),
                        nombre_cheveau_max = c.Int(nullable: false),
                        prix_par_km = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.OrdreMissions", "etat", c => c.Boolean(nullable: false));
            AddColumn("dbo.OrdreMissions", "montant_total", c => c.Single(nullable: false));
            AddColumn("dbo.Parameters", "valeur1", c => c.Int(nullable: false));
            AddColumn("dbo.Parameters", "valeur2", c => c.Int(nullable: false));
            AddColumn("dbo.Personnels", "Echelle", c => c.Int(nullable: false));
            AlterColumn("dbo.Personnels", "echelon", c => c.Int(nullable: false));
            DropColumn("dbo.OrdreMissions", "approvedByAdmin");
            DropColumn("dbo.OrdreMissions", "approvedBySP");
            DropColumn("dbo.Parameters", "valeur");
            DropTable("dbo.ServiceEconomique");
            DropTable("dbo.ServicePersonnel");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ServicePersonnel",
                c => new
                    {
                        IdPers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPers);
            
            CreateTable(
                "dbo.ServiceEconomique",
                c => new
                    {
                        IdPers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPers);
            
            AddColumn("dbo.Parameters", "valeur", c => c.String());
            AddColumn("dbo.OrdreMissions", "approvedBySP", c => c.Boolean(nullable: false));
            AddColumn("dbo.OrdreMissions", "approvedByAdmin", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Personnels", "echelon", c => c.String());
            DropColumn("dbo.Personnels", "Echelle");
            DropColumn("dbo.Parameters", "valeur2");
            DropColumn("dbo.Parameters", "valeur1");
            DropColumn("dbo.OrdreMissions", "montant_total");
            DropColumn("dbo.OrdreMissions", "etat");
            DropTable("dbo.Parametre_voiture");
            DropTable("dbo.Parametre_paiement");
            CreateIndex("dbo.ServicePersonnel", "IdPers");
            CreateIndex("dbo.ServiceEconomique", "IdPers");
            AddForeignKey("dbo.ServicePersonnel", "IdPers", "dbo.Personnels", "IdPers");
            AddForeignKey("dbo.ServiceEconomique", "IdPers", "dbo.Personnels", "IdPers");
        }
    }
}
