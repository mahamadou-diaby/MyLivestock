namespace MyLiveStock.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Evenements",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        Date = c.String(),
                        MatriculeRabbit = c.String(),
                        Saillie_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Saillies", t => t.Saillie_Id)
                .Index(t => t.Saillie_Id);
            
            CreateTable(
                "dbo.MiseBas",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        Portee = c.Int(nullable: false),
                        IdMaleSaillant = c.String(),
                        Observation = c.String(nullable: false),
                        IdSaillie = c.String(),
                        MatriculeMisebas = c.String(),
                        Evenement_Id = c.String(maxLength: 128),
                        Productrice_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Evenements", t => t.Evenement_Id)
                .ForeignKey("dbo.Rabbits", t => t.Productrice_Id)
                .Index(t => t.Evenement_Id)
                .Index(t => t.Productrice_Id);
            
            CreateTable(
                "dbo.Deaths",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        Cause = c.String(),
                        MiseBas_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MiseBas", t => t.MiseBas_Id)
                .Index(t => t.MiseBas_Id);
            
            CreateTable(
                "dbo.Rabbits",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Gender = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        Color = c.String(),
                        Matricule = c.String(),
                        IdPere = c.String(),
                        IdMere = c.String(),
                        PictureName = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Saillies",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        NextMiseBas = c.DateTime(nullable: false),
                        IdMaleSaillant = c.String(),
                        Observation = c.String(nullable: false),
                        status = c.Int(nullable: false),
                        MatriculeSaillie = c.String(),
                        Productrice_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rabbits", t => t.Productrice_Id)
                .Index(t => t.Productrice_Id);
            
            CreateTable(
                "dbo.Paiements",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        Montant = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Saillies", "Productrice_Id", "dbo.Rabbits");
            DropForeignKey("dbo.Evenements", "Saillie_Id", "dbo.Saillies");
            DropForeignKey("dbo.MiseBas", "Productrice_Id", "dbo.Rabbits");
            DropForeignKey("dbo.MiseBas", "Evenement_Id", "dbo.Evenements");
            DropForeignKey("dbo.Deaths", "MiseBas_Id", "dbo.MiseBas");
            DropIndex("dbo.Saillies", new[] { "Productrice_Id" });
            DropIndex("dbo.Deaths", new[] { "MiseBas_Id" });
            DropIndex("dbo.MiseBas", new[] { "Productrice_Id" });
            DropIndex("dbo.MiseBas", new[] { "Evenement_Id" });
            DropIndex("dbo.Evenements", new[] { "Saillie_Id" });
            DropTable("dbo.Paiements");
            DropTable("dbo.Saillies");
            DropTable("dbo.Rabbits");
            DropTable("dbo.Deaths");
            DropTable("dbo.MiseBas");
            DropTable("dbo.Evenements");
        }
    }
}
