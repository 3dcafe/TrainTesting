namespace TrainTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataReuests : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UrlParseDatas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        BaseRequestId = c.Int(nullable: false),
                        length = c.Long(nullable: false),
                        Time = c.Long(nullable: false),
                        DateAdd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.BaseRequests", t => t.BaseRequestId, cascadeDelete: true)
                .Index(t => t.BaseRequestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UrlParseDatas", "BaseRequestId", "dbo.BaseRequests");
            DropIndex("dbo.UrlParseDatas", new[] { "BaseRequestId" });
            DropTable("dbo.UrlParseDatas");
        }
    }
}
