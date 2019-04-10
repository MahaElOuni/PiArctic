namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v100 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recommendations", "EventId", "dbo.Events");
            DropForeignKey("dbo.Rewards", "EventId", "dbo.Events");
            DropForeignKey("dbo.Satisfactions", "EventId", "dbo.Events");
            AddForeignKey("dbo.Recommendations", "EventId", "dbo.Events", "EventId", cascadeDelete: true);
            AddForeignKey("dbo.Rewards", "EventId", "dbo.Events", "EventId", cascadeDelete: true);
            AddForeignKey("dbo.Satisfactions", "EventId", "dbo.Events", "EventId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Satisfactions", "EventId", "dbo.Events");
            DropForeignKey("dbo.Rewards", "EventId", "dbo.Events");
            DropForeignKey("dbo.Recommendations", "EventId", "dbo.Events");
            AddForeignKey("dbo.Satisfactions", "EventId", "dbo.Events", "EventId");
            AddForeignKey("dbo.Rewards", "EventId", "dbo.Events", "EventId");
            AddForeignKey("dbo.Recommendations", "EventId", "dbo.Events", "EventId");
        }
    }
}
