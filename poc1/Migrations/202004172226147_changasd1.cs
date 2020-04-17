namespace poc1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changasd1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickers", "tradeTimeSpan", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickers", "tradeTimeSpan");
        }
    }
}
