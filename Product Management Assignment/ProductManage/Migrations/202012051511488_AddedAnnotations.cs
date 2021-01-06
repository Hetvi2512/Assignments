namespace ProductManage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductInfoes", "product_category", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductInfoes", "product_category", c => c.String());
        }
    }
}
