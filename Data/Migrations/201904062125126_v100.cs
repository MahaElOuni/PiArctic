namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v100 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Reward_RewardId", "dbo.Rewards");
            DropIndex("dbo.Users", new[] { "Reward_RewardId" });
            AddColumn("dbo.Rewards", "UserId", c => c.Int());
            AddColumn("dbo.Rewards", "Organizer_Id", c => c.Int());
            CreateIndex("dbo.Rewards", "Organizer_Id");
            AddForeignKey("dbo.Rewards", "Organizer_Id", "dbo.Users", "Id");
            DropColumn("dbo.Users", "Reward_RewardId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Reward_RewardId", c => c.Int());
            DropForeignKey("dbo.Rewards", "Organizer_Id", "dbo.Users");
            DropIndex("dbo.Rewards", new[] { "Organizer_Id" });
            DropColumn("dbo.Rewards", "Organizer_Id");
            DropColumn("dbo.Rewards", "UserId");
            CreateIndex("dbo.Users", "Reward_RewardId");
            AddForeignKey("dbo.Users", "Reward_RewardId", "dbo.Rewards", "RewardId");
        }
    }
}
