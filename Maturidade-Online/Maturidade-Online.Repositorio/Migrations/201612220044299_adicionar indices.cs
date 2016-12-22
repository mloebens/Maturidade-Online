namespace Maturidade_Online.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adicionarindices : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Projeto", new[] { "UsuarioId" });
            DropIndex("dbo.Subtopico", new[] { "PilarId" });
            CreateIndex("dbo.Caracteristica", "Id");
            CreateIndex("dbo.Projeto", "Id");
            CreateIndex("dbo.Projeto", "UsuarioId");
            CreateIndex("dbo.Subtopico", "Id");
            CreateIndex("dbo.Subtopico", "PilarId");
            CreateIndex("dbo.Pilar", "Id");
            CreateIndex("dbo.Usuario", "Id");
            CreateIndex("dbo.Permissao", "Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Permissao", new[] { "Id" });
            DropIndex("dbo.Usuario", new[] { "Id" });
            DropIndex("dbo.Pilar", new[] { "Id" });
            DropIndex("dbo.Subtopico", new[] { "PilarId" });
            DropIndex("dbo.Subtopico", new[] { "Id" });
            DropIndex("dbo.Projeto", new[] { "UsuarioId" });
            DropIndex("dbo.Projeto", new[] { "Id" });
            DropIndex("dbo.Caracteristica", new[] { "Id" });
            CreateIndex("dbo.Subtopico", "PilarId");
            CreateIndex("dbo.Projeto", "UsuarioId");
        }
    }
}
