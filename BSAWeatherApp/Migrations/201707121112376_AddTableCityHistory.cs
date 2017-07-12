namespace BSAWeatherApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableCityHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CityHistory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false),
                        DateTimeOfSearch = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CityHistory");
        }
    }
}
