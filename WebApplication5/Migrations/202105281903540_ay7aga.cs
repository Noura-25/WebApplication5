namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ay7aga : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "Editor_username", "dbo.Editors");
            DropForeignKey("dbo.Favorites", "Viewer_username", "dbo.Viewers");
            DropForeignKey("dbo.Questions", "Viewer_username", "dbo.Viewers");
            DropIndex("dbo.Favorites", new[] { "Viewer_username" });
            DropIndex("dbo.Questions", new[] { "Editor_username" });
            DropIndex("dbo.Questions", new[] { "Viewer_username" });
            RenameColumn(table: "dbo.Questions", name: "Editor_username", newName: "EditorID");
            RenameColumn(table: "dbo.Favorites", name: "Viewer_username", newName: "ViewerID");
            RenameColumn(table: "dbo.Questions", name: "Viewer_username", newName: "ViewerID");


            AlterColumn("dbo.Admins", "username", c => c.String(maxLength: 20));
            AlterColumn("dbo.Editors", "username", c => c.String(maxLength: 20));
            AlterColumn("dbo.Posts", "ArticleBody", c => c.String());
            AlterColumn("dbo.Favorites", "ViewerID", c => c.Int(nullable: false));
            AlterColumn("dbo.Questions", "EditorID", c => c.Int(nullable: false));
            AlterColumn("dbo.Questions", "ViewerID", c => c.Int(nullable: false));

            CreateIndex("dbo.Favorites", "ViewerID");
            CreateIndex("dbo.Questions", "ViewerID");
            CreateIndex("dbo.Questions", "EditorID");
            AddForeignKey("dbo.Questions", "EditorID", "dbo.Editors", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Favorites", "ViewerID", "dbo.Viewers", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "ViewerID", "dbo.Viewers", "ID", cascadeDelete: true);

        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "username_Editor", c => c.String(maxLength: 20));
            AddColumn("dbo.Questions", "username_Viewer", c => c.String(maxLength: 20));
            AddColumn("dbo.Favorites", "username_Viewer", c => c.String(maxLength: 20));
            DropForeignKey("dbo.Questions", "ViewerID", "dbo.Viewers");
            DropForeignKey("dbo.Favorites", "ViewerID", "dbo.Viewers");
            DropForeignKey("dbo.Questions", "EditorID", "dbo.Editors");
            DropIndex("dbo.Questions", new[] { "EditorID" });
            DropIndex("dbo.Questions", new[] { "ViewerID" });
            DropIndex("dbo.Favorites", new[] { "ViewerID" });
            DropPrimaryKey("dbo.Viewers");
            DropPrimaryKey("dbo.Editors");
            DropPrimaryKey("dbo.Admins");
            AlterColumn("dbo.Questions", "ViewerID", c => c.String(maxLength: 20));
            AlterColumn("dbo.Questions", "EditorID", c => c.String(maxLength: 20));
            AlterColumn("dbo.Favorites", "ViewerID", c => c.String(maxLength: 20));
            AlterColumn("dbo.Posts", "ArticleBody", c => c.String(maxLength: 20));
            AlterColumn("dbo.Editors", "username", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Admins", "username", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Viewers", "ID");
            DropColumn("dbo.Editors", "ID");
            DropColumn("dbo.Admins", "ID");
            AddPrimaryKey("dbo.Viewers", "username");
            AddPrimaryKey("dbo.Editors", "username");
            AddPrimaryKey("dbo.Admins", "username");
            RenameColumn(table: "dbo.Questions", name: "ViewerID", newName: "Viewer_username");
            RenameColumn(table: "dbo.Favorites", name: "ViewerID", newName: "Viewer_username");
            RenameColumn(table: "dbo.Questions", name: "EditorID", newName: "Editor_username");
            CreateIndex("dbo.Questions", "Viewer_username");
            CreateIndex("dbo.Questions", "Editor_username");
            CreateIndex("dbo.Favorites", "Viewer_username");
            AddForeignKey("dbo.Questions", "Viewer_username", "dbo.Viewers", "username");
            AddForeignKey("dbo.Favorites", "Viewer_username", "dbo.Viewers", "username");
            AddForeignKey("dbo.Questions", "Editor_username", "dbo.Editors", "username");
        }
    }
}
