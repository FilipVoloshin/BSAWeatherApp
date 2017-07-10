namespace BSAWeatherApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedColumnDesriptionToCities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cities", "Description", c => c.String());
            AlterColumn("dbo.Cities", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cities", "Name", c => c.String());
            DropColumn("dbo.Cities", "Description");
        }
    }
}
