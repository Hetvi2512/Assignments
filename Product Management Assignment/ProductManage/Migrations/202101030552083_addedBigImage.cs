namespace ProductManage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedBigImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductInfoes", "BigImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductInfoes", "BigImagePath");
        }
    }
}
