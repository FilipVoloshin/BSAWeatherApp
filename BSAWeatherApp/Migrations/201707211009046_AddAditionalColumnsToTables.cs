namespace BSAWeatherApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAditionalColumnsToTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cities", "DateOfCreate", c => c.DateTime(nullable: false));
            AddColumn("dbo.CityHistory", "IsSuccess", c => c.Boolean(nullable: false));
            DropColumn("dbo.Cities", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cities", "Description", c => c.String());
            DropColumn("dbo.CityHistory", "IsSuccess");
            DropColumn("dbo.Cities", "DateOfCreate");
        }
    }
}
