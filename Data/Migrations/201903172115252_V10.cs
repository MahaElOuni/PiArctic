namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.EventId);
            
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
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        FNom = c.String(),
                        LNom = c.String(),
                        StreetName = c.String(),
                        password = c.String(),
                        Email = c.String(),
                        City = c.String(),
                        role = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        UserId = c.Int(nullable: false, identity: true),
                        Id = c.Int(nullable: false),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CustomUserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Id = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.CustomRoles", t => t.Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
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
                "dbo.CustomRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        Etat = c.Int(nullable: false),
                        Organizer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.Users", t => t.Organizer_Id)
                .Index(t => t.Organizer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "Organizer_Id", "dbo.Users");
            DropForeignKey("dbo.CustomUserRoles", "Id", "dbo.Users");
            DropForeignKey("dbo.CustomUserLogins", "Id", "dbo.Users");
            DropForeignKey("dbo.CustomUserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.CustomUserRoles", "Id", "dbo.CustomRoles");
            DropForeignKey("dbo.Tickets", "Event_EventId", "dbo.Events");
            DropForeignKey("dbo.Recommendations", "Participant_Id", "dbo.Users");
            DropForeignKey("dbo.Recommendations", "EventId", "dbo.Events");
            DropIndex("dbo.Tasks", new[] { "Organizer_Id" });
            DropIndex("dbo.Tickets", new[] { "Event_EventId" });
            DropIndex("dbo.CustomUserRoles", new[] { "Id" });
            DropIndex("dbo.CustomUserLogins", new[] { "Id" });
            DropIndex("dbo.CustomUserClaims", new[] { "UserId" });
            DropIndex("dbo.Recommendations", new[] { "Participant_Id" });
            DropIndex("dbo.Recommendations", new[] { "EventId" });
            DropTable("dbo.Tasks");
            DropTable("dbo.CustomRoles");
            DropTable("dbo.Tickets");
            DropTable("dbo.CustomUserRoles");
            DropTable("dbo.CustomUserLogins");
            DropTable("dbo.CustomUserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Recommendations");
            DropTable("dbo.Events");
        }
    }
}
