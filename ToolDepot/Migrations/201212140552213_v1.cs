namespace ToolDepot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UnderConstruction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailAddress = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BrandName = c.String(),
                        ProductImage = c.String(),
                        Category = c.Int(nullable: false),
                        IsFeaturedProduct = c.Boolean(nullable: false),
                        DayPrice = c.Int(nullable: false),
                        WeekPrice = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        IsFeaturedCategory = c.Boolean(nullable: false),
                        CategoryAvatar = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductDescription",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Description = c.String(),
                        ProductFeatures = c.String(),
                        ProductSpecs = c.String(),
                        OwnersManual = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProductDescription", new[] { "ProductId" });
            DropForeignKey("dbo.ProductDescription", "ProductId", "dbo.Products");
            DropTable("dbo.ProductDescription");
            DropTable("dbo.ProductCategory");
            DropTable("dbo.Products");
            DropTable("dbo.UnderConstruction");
        }
    }
}
