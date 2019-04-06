namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v101 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Recommendation_RecommendationId", "dbo.Recommendations");
            DropIndex("dbo.Users", new[] { "Recommendation_RecommendationId" });
            AddColumn("dbo.Recommendations", "Organizer_Id", c => c.Int());
            AlterColumn("dbo.Recommendations", "UserId", c => c.Int());
            CreateIndex("dbo.Recommendations", "Organizer_Id");
            AddForeignKey("dbo.Recommendations", "Organizer_Id", "dbo.Users", "Id");
            DropColumn("dbo.Users", "Recommendation_RecommendationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Recommendation_RecommendationId", c => c.Int());
            DropForeignKey("dbo.Recommendations", "Organizer_Id", "dbo.Users");
            DropIndex("dbo.Recommendations", new[] { "Organizer_Id" });
            AlterColumn("dbo.Recommendations", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Recommendations", "Organizer_Id");
            CreateIndex("dbo.Users", "Recommendation_RecommendationId");
            AddForeignKey("dbo.Users", "Recommendation_RecommendationId", "dbo.Recommendations", "RecommendationId");
        }
    }
}
