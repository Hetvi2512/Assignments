namespace Product_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductsInfo",
                c => new
                    {
                        product_Id = c.Int(nullable: false, identity: true),
                        product_name = c.String(nullable: false, maxLength: 50),
                        product_price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.product_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductsInfo");
        }
    }
}
