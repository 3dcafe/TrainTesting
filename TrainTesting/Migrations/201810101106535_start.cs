namespace TrainTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BaseRequests",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        url = c.String(),
                        DateAdd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BaseRequests");
        }
    }
}
