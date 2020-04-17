namespace poc1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changasd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickers", "lastAmount", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickers", "lastAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
