namespace CompendiumIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteredTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Todoes", "Feature_FeatureID", "dbo.Features");
            DropIndex("dbo.Todoes", new[] { "Feature_FeatureID" });
            RenameColumn(table: "dbo.Todoes", name: "Feature_FeatureID", newName: "featureID");
            AlterColumn("dbo.Todoes", "featureID", c => c.Int(nullable: false));
            CreateIndex("dbo.Todoes", "featureID");
            AddForeignKey("dbo.Todoes", "featureID", "dbo.Features", "FeatureID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Todoes", "featureID", "dbo.Features");
            DropIndex("dbo.Todoes", new[] { "featureID" });
            AlterColumn("dbo.Todoes", "featureID", c => c.Int());
            RenameColumn(table: "dbo.Todoes", name: "featureID", newName: "Feature_FeatureID");
            CreateIndex("dbo.Todoes", "Feature_FeatureID");
            AddForeignKey("dbo.Todoes", "Feature_FeatureID", "dbo.Features", "FeatureID");
        }
    }
}
