namespace FindCarrier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gender : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Gender", c => c.String(nullable: false));
           
        }
        
        public override void Down()
        {
           
            DropColumn("dbo.AspNetUsers", "Gender");
        }
    }
}
