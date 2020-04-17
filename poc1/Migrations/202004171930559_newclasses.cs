namespace poc1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newclasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        exchange = c.Int(nullable: false),
                        market = c.String(),
                        dateTimeNow = c.DateTime(nullable: false),
                        order = c.Int(nullable: false),
                        buyPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        buyAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        sellPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        sellAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Tickers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        exchange = c.Int(nullable: false),
                        market = c.String(),
                        dateTimeNow = c.DateTime(nullable: false),
                        trade = c.Time(nullable: false, precision: 7),
                        lastPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        lastAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        changeRenew = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tickers");
            DropTable("dbo.Books");
        }
    }
}
