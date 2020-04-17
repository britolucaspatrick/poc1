namespace poc1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changevaluetypeonclassticket : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickers", "trade", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tickers", "lastPrice", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickers", "lastPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Tickers", "trade", c => c.Time(nullable: false, precision: 7));
        }
    }
}
