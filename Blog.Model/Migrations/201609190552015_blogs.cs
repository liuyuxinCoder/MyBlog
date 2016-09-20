namespace Blog.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blogs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogInfos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlogTypes", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.BlogTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BlogUsers",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        NickName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Bio = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogInfos", "TypeId", "dbo.BlogTypes");
            DropIndex("dbo.BlogInfos", new[] { "TypeId" });
            DropTable("dbo.BlogUsers");
            DropTable("dbo.BlogTypes");
            DropTable("dbo.BlogInfos");
        }
    }
}
