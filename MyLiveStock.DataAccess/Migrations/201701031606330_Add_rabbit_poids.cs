namespace MyLiveStock.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_rabbit_poids : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rabbits", "Poids", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rabbits", "Poids");
        }
    }
}
