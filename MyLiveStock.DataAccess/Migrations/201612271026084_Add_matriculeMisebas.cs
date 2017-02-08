namespace MyLiveStock.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_matriculeMisebas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rabbits", "matriculeMisebas", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rabbits", "matriculeMisebas");
        }
    }
}
