namespace MyLiveStock.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_is_sevrate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MiseBas", "IsSevrate", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MiseBas", "IsSevrate");
        }
    }
}
