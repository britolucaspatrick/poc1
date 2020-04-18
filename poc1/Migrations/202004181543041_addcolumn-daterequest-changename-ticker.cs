namespace poc1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolumndaterequestchangenameticker : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickers", "dateRequest", c => c.DateTime(nullable: false));
            DropColumn("dbo.Tickers", "dateRequised");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickers", "dateRequised", c => c.DateTime(nullable: false));
            DropColumn("dbo.Tickers", "dateRequest");
        }
    }
}
