namespace CompendiumIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedFeatureTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Features", "projectID", "dbo.Projects");
            DropForeignKey("dbo.Todoes", "featureID", "dbo.Features");
            DropIndex("dbo.Features", new[] { "projectID" });
            DropIndex("dbo.Todoes", new[] { "featureID" });
            RenameColumn(table: "dbo.Features", name: "projectID", newName: "Project_ProjectID");
            RenameColumn(table: "dbo.Todoes", name: "featureID", newName: "Feature_FeatureID");
            AlterColumn("dbo.Features", "Project_ProjectID", c => c.Int());
            AlterColumn("dbo.Todoes", "Feature_FeatureID", c => c.Int());
            CreateIndex("dbo.Features", "Project_ProjectID");
            CreateIndex("dbo.Todoes", "Feature_FeatureID");
            AddForeignKey("dbo.Features", "Project_ProjectID", "dbo.Projects", "ProjectID");
            AddForeignKey("dbo.Todoes", "Feature_FeatureID", "dbo.Features", "FeatureID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Todoes", "Feature_FeatureID", "dbo.Features");
            DropForeignKey("dbo.Features", "Project_ProjectID", "dbo.Projects");
            DropIndex("dbo.Todoes", new[] { "Feature_FeatureID" });
            DropIndex("dbo.Features", new[] { "Project_ProjectID" });
            AlterColumn("dbo.Todoes", "Feature_FeatureID", c => c.Int(nullable: false));
            AlterColumn("dbo.Features", "Project_ProjectID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Todoes", name: "Feature_FeatureID", newName: "featureID");
            RenameColumn(table: "dbo.Features", name: "Project_ProjectID", newName: "projectID");
            CreateIndex("dbo.Todoes", "featureID");
            CreateIndex("dbo.Features", "projectID");
            AddForeignKey("dbo.Todoes", "featureID", "dbo.Features", "FeatureID", cascadeDelete: true);
            AddForeignKey("dbo.Features", "projectID", "dbo.Projects", "ProjectID", cascadeDelete: true);
        }
    }
}
