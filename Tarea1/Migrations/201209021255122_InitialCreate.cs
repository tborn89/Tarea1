namespace Tarea1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Integrantes",
                c => new
                    {
                        IntegranteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Rut = c.String(),
                        CargoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IntegranteId)
                .ForeignKey("dbo.Cargoes", t => t.CargoId, cascadeDelete: true)
                .Index(t => t.CargoId);
            
            CreateTable(
                "dbo.Cargoes",
                c => new
                    {
                        CargoId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Prioridad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CargoId);
            
            CreateTable(
                "dbo.RegistroGuardias",
                c => new
                    {
                        RegistroGuardiaId = c.Int(nullable: false, identity: true),
                        IntegranteId = c.Int(nullable: false),
                        FechaIngreso = c.DateTime(nullable: false),
                        FechaSalida = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RegistroGuardiaId)
                .ForeignKey("dbo.Integrantes", t => t.IntegranteId, cascadeDelete: true)
                .Index(t => t.IntegranteId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.RegistroGuardias", new[] { "IntegranteId" });
            DropIndex("dbo.Integrantes", new[] { "CargoId" });
            DropForeignKey("dbo.RegistroGuardias", "IntegranteId", "dbo.Integrantes");
            DropForeignKey("dbo.Integrantes", "CargoId", "dbo.Cargoes");
            DropTable("dbo.RegistroGuardias");
            DropTable("dbo.Cargoes");
            DropTable("dbo.Integrantes");
        }
    }
}
