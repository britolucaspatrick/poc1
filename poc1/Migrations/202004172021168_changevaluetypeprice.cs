namespace poc1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changevaluetypeprice : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "buyPrice", c => c.String());
            AlterColumn("dbo.Books", "sellPrice", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "sellPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Books", "buyPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
