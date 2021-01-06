namespace ProductManage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedshortdesc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductInfoes", "short_desc", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductInfoes", "short_desc");
        }
    }
}
