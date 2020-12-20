namespace SourceControlFinalAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyFirstMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "City", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Image", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Image");
            DropColumn("dbo.Users", "City");
        }
    }
}
