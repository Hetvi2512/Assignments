namespace ProductManage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedloginmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoginModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        userName = c.String(nullable: false, maxLength: 50),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LoginModels");
        }
    }
}
