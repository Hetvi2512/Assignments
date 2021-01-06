namespace ProductManage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedImagepath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductInfoes", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductInfoes", "ImagePath");
        }
    }
}
