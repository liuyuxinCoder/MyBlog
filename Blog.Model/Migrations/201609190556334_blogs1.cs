namespace Blog.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blogs1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogInfos", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.BlogInfos", "UserId");
            AddForeignKey("dbo.BlogInfos", "UserId", "dbo.BlogUsers", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogInfos", "UserId", "dbo.BlogUsers");
            DropIndex("dbo.BlogInfos", new[] { "UserId" });
            DropColumn("dbo.BlogInfos", "UserId");
        }
    }
}
