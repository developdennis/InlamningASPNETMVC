namespace BeerWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnitsInStockDeliveryTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "UnitsInStock", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "DeliveryTime", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "DeliveryTime");
            DropColumn("dbo.Products", "UnitsInStock");
        }
    }
}
