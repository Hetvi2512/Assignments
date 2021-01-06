namespace ProductManage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addednewfields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductInfoes", "product_qnty", c => c.Int(nullable: false));
            AddColumn("dbo.ProductInfoes", "product_category", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductInfoes", "product_category");
            DropColumn("dbo.ProductInfoes", "product_qnty");
        }
    }
}
