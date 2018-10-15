namespace TrainTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodeAnswer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UrlParseDatas", "code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UrlParseDatas", "code");
        }
    }
}
