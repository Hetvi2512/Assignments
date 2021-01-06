namespace ProductManage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingData : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into ProductInfoes (product_name, product_price) VALUES ('Chocolate',250)");
            Sql("Insert into ProductInfoes (product_name, product_price) VALUES ('Cream',100)");
            Sql("Insert into ProductInfoes (product_name, product_price) VALUES ('Milk',90)");
        }
        
        public override void Down()
        {
        }
    }
}
