namespace poc1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolumndaterequisedticker : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickers", "dateRequised", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickers", "dateRequised");
        }
    }
}
