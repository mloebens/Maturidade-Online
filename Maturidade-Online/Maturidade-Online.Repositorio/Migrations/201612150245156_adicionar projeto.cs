namespace Maturidade_Online.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adicionarprojeto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projeto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Email = c.String(),
                        Senha = c.String(),
                        Permissao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjetoSubtopico",
                c => new
                    {
                        ProjetoId = c.Int(nullable: false),
                        SubtopicoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjetoId, t.SubtopicoId })
                .ForeignKey("dbo.Projeto", t => t.ProjetoId, cascadeDelete: true)
                .ForeignKey("dbo.Subtopico", t => t.SubtopicoId, cascadeDelete: true)
                .Index(t => t.ProjetoId)
                .Index(t => t.SubtopicoId);
            
            AddColumn("dbo.Caracteristica", "Projeto_Id", c => c.Int());
            CreateIndex("dbo.Caracteristica", "Projeto_Id");
            AddForeignKey("dbo.Caracteristica", "Projeto_Id", "dbo.Projeto", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjetoSubtopico", "SubtopicoId", "dbo.Subtopico");
            DropForeignKey("dbo.ProjetoSubtopico", "ProjetoId", "dbo.Projeto");
            DropForeignKey("dbo.Caracteristica", "Projeto_Id", "dbo.Projeto");
            DropIndex("dbo.ProjetoSubtopico", new[] { "SubtopicoId" });
            DropIndex("dbo.ProjetoSubtopico", new[] { "ProjetoId" });
            DropIndex("dbo.Caracteristica", new[] { "Projeto_Id" });
            DropColumn("dbo.Caracteristica", "Projeto_Id");
            DropTable("dbo.ProjetoSubtopico");
            DropTable("dbo.Usuario");
            DropTable("dbo.Projeto");
        }
    }
}
