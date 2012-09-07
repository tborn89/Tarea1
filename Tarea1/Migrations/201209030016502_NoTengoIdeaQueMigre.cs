namespace Tarea1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoTengoIdeaQueMigre : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Integrantes", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Integrantes", "Apellido", c => c.String(nullable: false));
            AlterColumn("dbo.Integrantes", "Rut", c => c.String(nullable: false));
            AlterColumn("dbo.Cargoes", "Titulo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cargoes", "Titulo", c => c.String());
            AlterColumn("dbo.Integrantes", "Rut", c => c.String());
            AlterColumn("dbo.Integrantes", "Apellido", c => c.String());
            AlterColumn("dbo.Integrantes", "Nombre", c => c.String());
        }
    }
}
