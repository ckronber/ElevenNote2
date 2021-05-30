namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Note", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.Note", "CreateUTC");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Note", "CreateUTC", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.Note", "CreatedUtc");
        }
    }
}
