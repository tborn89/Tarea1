namespace Tarea1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNullablePropertyToFechaSalidaInRegistroGuardia : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RegistroGuardias", "FechaSalida", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RegistroGuardias", "FechaSalida", c => c.DateTime(nullable: false));
        }
    }
}
