namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class faroukint : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        NbrLike = c.Int(nullable: false),
                        Contenu = c.String(),
                        BlogId = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.BlogId)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Blogs", "NbrLike", c => c.Int(nullable: false));
            AddColumn("dbo.Blogs", "NbrComment", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "BlogId", "dbo.Blogs");
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "BlogId" });
            DropColumn("dbo.Blogs", "NbrComment");
            DropColumn("dbo.Blogs", "NbrLike");
            DropTable("dbo.Comments");
        }
    }
}
