namespace Maturidade_Online.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adicionarusuarioaoprojeto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projeto", "UsuarioId", c => c.Int(nullable: false));
            CreateIndex("dbo.Projeto", "UsuarioId");
            AddForeignKey("dbo.Projeto", "UsuarioId", "dbo.Usuario", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projeto", "UsuarioId", "dbo.Usuario");
            DropIndex("dbo.Projeto", new[] { "UsuarioId" });
            DropColumn("dbo.Projeto", "UsuarioId");
        }
    }
}
