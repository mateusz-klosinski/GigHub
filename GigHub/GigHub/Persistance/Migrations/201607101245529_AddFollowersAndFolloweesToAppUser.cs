namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollowersAndFolloweesToAppUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Follows", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Follows", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            CreateIndex("dbo.Follows", "ApplicationUser_Id");
            CreateIndex("dbo.Follows", "ApplicationUser_Id1");
            AddForeignKey("dbo.Follows", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Follows", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Follows", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.Follows", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Follows", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.Follows", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Follows", "ApplicationUser_Id1");
            DropColumn("dbo.Follows", "ApplicationUser_Id");
        }
    }
}
