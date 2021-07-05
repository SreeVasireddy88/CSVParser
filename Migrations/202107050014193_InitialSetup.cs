namespace CsvWebParser.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblProduct",
                c => new
                    {
                        AsIdn = c.String(nullable: false, maxLength: 20),
                        Title = c.String(maxLength: 100),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetMargin = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.AsIdn);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblProduct");
        }
    }
}
