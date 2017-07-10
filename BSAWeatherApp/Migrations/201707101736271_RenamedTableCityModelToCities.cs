namespace BSAWeatherApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedTableCityModelToCities : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CityModels", newName: "Cities");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Cities", newName: "CityModels");
        }
    }
}
