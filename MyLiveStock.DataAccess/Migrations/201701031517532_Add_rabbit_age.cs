namespace MyLiveStock.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_rabbit_age : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rabbits", "Age", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rabbits", "Age");
        }
    }
}
