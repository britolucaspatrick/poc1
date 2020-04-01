namespace poc1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class heheh : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderKucoins",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        symbol = c.String(),
                        dealPrice = c.String(),
                        dealValue = c.String(),
                        amount = c.String(),
                        fee = c.String(),
                        side = c.String(),
                        createdAt = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OrderKucoins");
        }
    }
}
