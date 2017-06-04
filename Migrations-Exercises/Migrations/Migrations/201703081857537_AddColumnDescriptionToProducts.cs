namespace Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnDescriptionToProducts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        CreditCardNumber = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SaleId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Customer_CustomerId = c.Int(),
                        Product_ProductId = c.Int(),
                        StoreLocation_StoreLocationId = c.Int(),
                    })
                .PrimaryKey(t => t.SaleId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .ForeignKey("dbo.StoreLocations", t => t.StoreLocation_StoreLocationId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.Product_ProductId)
                .Index(t => t.StoreLocation_StoreLocationId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.Double(nullable: false, defaultValue: 1),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.StoreLocations",
                c => new
                    {
                        StoreLocationId = c.Int(nullable: false, identity: true),
                        LocationName = c.String(),
                    })
                .PrimaryKey(t => t.StoreLocationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "StoreLocation_StoreLocationId", "dbo.StoreLocations");
            DropForeignKey("dbo.Sales", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Sales", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.Sales", new[] { "StoreLocation_StoreLocationId" });
            DropIndex("dbo.Sales", new[] { "Product_ProductId" });
            DropIndex("dbo.Sales", new[] { "Customer_CustomerId" });
            DropTable("dbo.StoreLocations");
            DropTable("dbo.Products");
            DropTable("dbo.Sales");
            DropTable("dbo.Customers");
        }
    }
}
