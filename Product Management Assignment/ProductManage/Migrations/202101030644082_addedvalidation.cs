namespace ProductManage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedvalidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductInfoes", "ImagePath", c => c.String(nullable: false));
            AlterColumn("dbo.ProductInfoes", "BigImagePath", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductInfoes", "BigImagePath", c => c.String());
            AlterColumn("dbo.ProductInfoes", "ImagePath", c => c.String());
        }
    }
}
