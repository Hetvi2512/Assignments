namespace SourceControlFinalAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifthmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Image", c => c.String(nullable: false));
            DropColumn("dbo.Users", "Imagepath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Imagepath", c => c.String(nullable: false));
            DropColumn("dbo.Users", "Image");
        }
    }
}
