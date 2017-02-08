namespace MyLiveStock.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_categorie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Categorie", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "Categorie");
        }
    }
}
