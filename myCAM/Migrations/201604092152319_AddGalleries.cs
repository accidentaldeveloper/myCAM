namespace myCAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGalleries : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        GalleryId = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 256),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.GalleryId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.GalleryItems",
                c => new
                    {
                        GalleryItemId = c.Int(nullable: false, identity: true),
                        GalleryId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.GalleryItemId)
                .ForeignKey("dbo.Galleries", t => t.GalleryId, cascadeDelete: true)
                .Index(t => t.GalleryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GalleryItems", "GalleryId", "dbo.Galleries");
            DropForeignKey("dbo.Galleries", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.GalleryItems", new[] { "GalleryId" });
            DropIndex("dbo.Galleries", new[] { "ApplicationUserId" });
            DropTable("dbo.GalleryItems");
            DropTable("dbo.Galleries");
        }
    }
}
