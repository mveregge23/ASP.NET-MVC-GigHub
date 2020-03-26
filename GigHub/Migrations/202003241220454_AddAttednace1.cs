namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttednace1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Follows", "FollowerId", "dbo.AspNetUsers");
            AddForeignKey("dbo.Follows", "FollowerId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Follows", "FollowerId", "dbo.AspNetUsers");
            AddForeignKey("dbo.Follows", "FollowerId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
