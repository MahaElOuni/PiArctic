namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Schedulers", name: "Event_EventId", newName: "EventId");
            RenameIndex(table: "dbo.Schedulers", name: "IX_Event_EventId", newName: "IX_EventId");
            AddColumn("dbo.Users", "Etat", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Etat");
            RenameIndex(table: "dbo.Schedulers", name: "IX_EventId", newName: "IX_Event_EventId");
            RenameColumn(table: "dbo.Schedulers", name: "EventId", newName: "Event_EventId");
        }
    }
}
