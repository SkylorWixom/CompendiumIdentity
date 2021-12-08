namespace CompendiumIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Features", "Project_ProjectID", "dbo.Projects");
            DropIndex("dbo.Features", new[] { "Project_ProjectID" });
            RenameColumn(table: "dbo.Features", name: "Project_ProjectID", newName: "projectID");
            AlterColumn("dbo.Features", "projectID", c => c.Int(nullable: false));
            CreateIndex("dbo.Features", "projectID");
            AddForeignKey("dbo.Features", "projectID", "dbo.Projects", "ProjectID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Features", "projectID", "dbo.Projects");
            DropIndex("dbo.Features", new[] { "projectID" });
            AlterColumn("dbo.Features", "projectID", c => c.Int());
            RenameColumn(table: "dbo.Features", name: "projectID", newName: "Project_ProjectID");
            CreateIndex("dbo.Features", "Project_ProjectID");
            AddForeignKey("dbo.Features", "Project_ProjectID", "dbo.Projects", "ProjectID");
        }
    }
}
