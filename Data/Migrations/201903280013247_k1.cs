namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class k1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Address = c.String(),
                        NumberPlaces = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        Description = c.String(),
                        Start = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        End = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ThemeColor = c.String(),
                        IsFullDay = c.Boolean(nullable: false),
                        OrganizedBy = c.String(),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.Forms",
                c => new
                    {
                        FormId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        Sex = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        Profession = c.String(),
                        Mail = c.String(),
                        Countrie = c.Int(nullable: false),
                        Address = c.String(),
                        Participant_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.FormId, t.UserId, t.EventId })
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Participant_Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.EventId)
                .Index(t => t.Participant_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CIN = c.String(maxLength: 8),
                        FName = c.String(),
                        LName = c.String(),
                        StreetName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        City = c.String(),
                        Role = c.String(),
                        BirthDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Photo = c.String(),
                        EntrepriseTranscripts = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 7, storeType: "datetime2"),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        ParicipantId = c.Int(),
                        Recommendation = c.String(),
                        Logo = c.String(),
                        PresidentName = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Contenu = c.String(),
                        Titre = c.String(),
                        Photo = c.String(),
                        DatePost = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.BlogId)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.CustomUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CustomUserLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CustomUserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Id = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.Id, cascadeDelete: true)
                .ForeignKey("dbo.CustomRoles", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Recommendations",
                c => new
                    {
                        RecommendationNum = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        State = c.Int(nullable: false),
                        Participant_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.RecommendationNum, t.UserId, t.EventId })
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Participant_Id)
                .Index(t => t.EventId)
                .Index(t => t.Participant_Id);
            
            CreateTable(
                "dbo.Schedulers",
                c => new
                    {
                        SchedulerId = c.Int(nullable: false, identity: true),
                        ProgramName = c.String(),
                        Duration = c.String(),
                        Event_EventId = c.Int(),
                    })
                .PrimaryKey(t => t.SchedulerId)
                .ForeignKey("dbo.Events", t => t.Event_EventId)
                .Index(t => t.Event_EventId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        Method = c.Int(nullable: false),
                        Event_EventId = c.Int(),
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.Events", t => t.Event_EventId)
                .Index(t => t.Event_EventId);
            
            CreateTable(
                "dbo.Rewards",
                c => new
                    {
                        IdReward = c.Int(nullable: false, identity: true),
                        Price = c.Int(nullable: false),
                        titre = c.String(),
                        Event_EventId = c.Int(),
                    })
                .PrimaryKey(t => t.IdReward)
                .ForeignKey("dbo.Events", t => t.Event_EventId)
                .Index(t => t.Event_EventId);
            
            CreateTable(
                "dbo.CustomRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomUserRoles", "Id", "dbo.CustomRoles");
            DropForeignKey("dbo.Rewards", "Event_EventId", "dbo.Events");
            DropForeignKey("dbo.Tickets", "Event_EventId", "dbo.Events");
            DropForeignKey("dbo.Schedulers", "Event_EventId", "dbo.Events");
            DropForeignKey("dbo.Forms", "UserId", "dbo.Users");
            DropForeignKey("dbo.Recommendations", "Participant_Id", "dbo.Users");
            DropForeignKey("dbo.Recommendations", "EventId", "dbo.Events");
            DropForeignKey("dbo.Forms", "Participant_Id", "dbo.Users");
            DropForeignKey("dbo.CustomUserRoles", "Id", "dbo.Users");
            DropForeignKey("dbo.CustomUserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.CustomUserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.Blogs", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Forms", "EventId", "dbo.Events");
            DropIndex("dbo.Rewards", new[] { "Event_EventId" });
            DropIndex("dbo.Tickets", new[] { "Event_EventId" });
            DropIndex("dbo.Schedulers", new[] { "Event_EventId" });
            DropIndex("dbo.Recommendations", new[] { "Participant_Id" });
            DropIndex("dbo.Recommendations", new[] { "EventId" });
            DropIndex("dbo.CustomUserRoles", new[] { "Id" });
            DropIndex("dbo.CustomUserLogins", new[] { "UserId" });
            DropIndex("dbo.CustomUserClaims", new[] { "UserId" });
            DropIndex("dbo.Blogs", new[] { "User_Id" });
            DropIndex("dbo.Forms", new[] { "Participant_Id" });
            DropIndex("dbo.Forms", new[] { "EventId" });
            DropIndex("dbo.Forms", new[] { "UserId" });
            DropTable("dbo.CustomRoles");
            DropTable("dbo.Rewards");
            DropTable("dbo.Tickets");
            DropTable("dbo.Schedulers");
            DropTable("dbo.Recommendations");
            DropTable("dbo.CustomUserRoles");
            DropTable("dbo.CustomUserLogins");
            DropTable("dbo.CustomUserClaims");
            DropTable("dbo.Blogs");
            DropTable("dbo.Users");
            DropTable("dbo.Forms");
            DropTable("dbo.Events");
        }
    }
}
