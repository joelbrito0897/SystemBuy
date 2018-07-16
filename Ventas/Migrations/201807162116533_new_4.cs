namespace Ventas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Facturas", "ClienteName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Facturas", "ClienteName");
        }
    }
}
