namespace ProductManage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedshortdesc1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductInfoes", "long_desc", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductInfoes", "long_desc");
        }
    }
}
