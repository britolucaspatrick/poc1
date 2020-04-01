namespace poc1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderBinances",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        price = c.String(),
                        qty = c.String(),
                        quoteQty = c.String(),
                        time = c.Long(nullable: false),
                        isBuyerMaker = c.Boolean(nullable: false),
                        isBestMatch = c.Boolean(nullable: false),
                        Symbol = c.String(),
                        ChangeRenew = c.Boolean(nullable: false),
                        LastAmout = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OrderBinances");
        }
    }
}
