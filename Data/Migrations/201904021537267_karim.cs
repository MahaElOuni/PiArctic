namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class karim : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rewards", "Event_EventId", "dbo.Events");
            DropIndex("dbo.Rewards", new[] { "Event_EventId" });
            RenameColumn(table: "dbo.Rewards", name: "Event_EventId", newName: "Eventid");
            DropPrimaryKey("dbo.Recommendations");
            AddColumn("dbo.Users", "Reward_IdReward", c => c.Int());
            AddColumn("dbo.Recommendations", "RecommendationId", c => c.Int(nullable: false));
            AddColumn("dbo.Recommendations", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Recommendations", "EmailParticipent", c => c.String());
            AddColumn("dbo.Rewards", "Price1", c => c.Int(nullable: false));
            AddColumn("dbo.Rewards", "Price2", c => c.Int(nullable: false));
            AddColumn("dbo.Rewards", "Price3", c => c.Int(nullable: false));
            AlterColumn("dbo.Rewards", "Eventid", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Recommendations", new[] { "RecommendationId", "UserId", "EventId" });
            CreateIndex("dbo.Users", "Reward_IdReward");
            CreateIndex("dbo.Rewards", "Eventid");
            AddForeignKey("dbo.Users", "Reward_IdReward", "dbo.Rewards", "IdReward");
            AddForeignKey("dbo.Rewards", "Eventid", "dbo.Events", "EventId", cascadeDelete: true);
            DropColumn("dbo.Recommendations", "State");
            DropColumn("dbo.Rewards", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rewards", "Price", c => c.Int(nullable: false));
            AddColumn("dbo.Recommendations", "State", c => c.Int(nullable: false));
            DropForeignKey("dbo.Rewards", "Eventid", "dbo.Events");
            DropForeignKey("dbo.Users", "Reward_IdReward", "dbo.Rewards");
            DropIndex("dbo.Rewards", new[] { "Eventid" });
            DropIndex("dbo.Users", new[] { "Reward_IdReward" });
            DropPrimaryKey("dbo.Recommendations");
            AlterColumn("dbo.Rewards", "Eventid", c => c.Int());
            DropColumn("dbo.Rewards", "Price3");
            DropColumn("dbo.Rewards", "Price2");
            DropColumn("dbo.Rewards", "Price1");
            DropColumn("dbo.Recommendations", "EmailParticipent");
            DropColumn("dbo.Recommendations", "Status");
            DropColumn("dbo.Recommendations", "RecommendationId");
            DropColumn("dbo.Users", "Reward_IdReward");
            AddPrimaryKey("dbo.Recommendations", new[] { "RecommendationNum", "UserId", "EventId" });
            RenameColumn(table: "dbo.Rewards", name: "Eventid", newName: "Event_EventId");
            CreateIndex("dbo.Rewards", "Event_EventId");
            AddForeignKey("dbo.Rewards", "Event_EventId", "dbo.Events", "EventId");
        }
    }
}
