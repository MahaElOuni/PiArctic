namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Forms",
                c => new
                    {
                        FormId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        ParicipantId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Participant_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.FormId, t.EventId, t.ParicipantId })
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Participant_Id)
                .Index(t => t.EventId)
                .Index(t => t.Participant_Id);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Contenu = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.BlogId)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Events", "Address", c => c.String());
            AddColumn("dbo.Events", "NumberPlaces", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "Price", c => c.Single(nullable: false));
            AddColumn("dbo.Events", "Description", c => c.String());
            AddColumn("dbo.Events", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "OrganizedBy", c => c.String());
            AddColumn("dbo.Users", "ParicipantId", c => c.Int());
            AddColumn("dbo.Users", "Logo", c => c.String());
            AddColumn("dbo.Users", "PresidentName", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Forms", "Participant_Id", "dbo.Users");
            DropForeignKey("dbo.Blogs", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Forms", "EventId", "dbo.Events");
            DropIndex("dbo.Blogs", new[] { "User_Id" });
            DropIndex("dbo.Forms", new[] { "Participant_Id" });
            DropIndex("dbo.Forms", new[] { "EventId" });
            DropColumn("dbo.Users", "PresidentName");
            DropColumn("dbo.Users", "Logo");
            DropColumn("dbo.Users", "ParicipantId");
            DropColumn("dbo.Events", "OrganizedBy");
            DropColumn("dbo.Events", "Date");
            DropColumn("dbo.Events", "Description");
            DropColumn("dbo.Events", "Price");
            DropColumn("dbo.Events", "NumberPlaces");
            DropColumn("dbo.Events", "Address");
            DropTable("dbo.Blogs");
            DropTable("dbo.Forms");
        }
    }
}
