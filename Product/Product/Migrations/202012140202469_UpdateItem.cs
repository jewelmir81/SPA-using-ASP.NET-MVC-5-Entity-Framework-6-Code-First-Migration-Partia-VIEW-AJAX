namespace Product.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "EntryDate", c => c.DateTime(nullable: false, storeType: "date"));
            AddColumn("dbo.Item", "Quantity", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Item", "Quantity");
            DropColumn("dbo.Item", "EntryDate");
        }
    }
}
