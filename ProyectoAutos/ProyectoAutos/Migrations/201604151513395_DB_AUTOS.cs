namespace ProyectoAutos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB_AUTOS : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pedidoes", "fecha");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pedidoes", "fecha", c => c.Int(nullable: false));
        }
    }
}
