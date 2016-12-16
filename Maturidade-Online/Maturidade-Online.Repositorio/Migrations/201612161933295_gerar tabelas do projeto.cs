namespace Maturidade_Online.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gerartabelasdoprojeto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Caracteristica",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projeto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Subtopico",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Pontuacao = c.Int(nullable: false),
                        PilarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pilar", t => t.PilarId, cascadeDelete: true)
                .Index(t => t.PilarId);
            
            CreateTable(
                "dbo.Pilar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
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
                "dbo.ProjetoCaracteristica",
                c => new
                    {
                        Projeto_Id = c.Int(nullable: false),
                        Caracteristica_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Projeto_Id, t.Caracteristica_Id })
                .ForeignKey("dbo.Projeto", t => t.Projeto_Id, cascadeDelete: true)
                .ForeignKey("dbo.Caracteristica", t => t.Caracteristica_Id, cascadeDelete: true)
                .Index(t => t.Projeto_Id)
                .Index(t => t.Caracteristica_Id);
            
            CreateTable(
                "dbo.SubtopicoCaracteristica",
                c => new
                    {
                        Subtopico_Id = c.Int(nullable: false),
                        Caracteristica_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subtopico_Id, t.Caracteristica_Id })
                .ForeignKey("dbo.Subtopico", t => t.Subtopico_Id, cascadeDelete: true)
                .ForeignKey("dbo.Caracteristica", t => t.Caracteristica_Id, cascadeDelete: true)
                .Index(t => t.Subtopico_Id)
                .Index(t => t.Caracteristica_Id);
            
            CreateTable(
                "dbo.SubtopicoProjeto",
                c => new
                    {
                        Subtopico_Id = c.Int(nullable: false),
                        Projeto_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subtopico_Id, t.Projeto_Id })
                .ForeignKey("dbo.Subtopico", t => t.Subtopico_Id, cascadeDelete: true)
                .ForeignKey("dbo.Projeto", t => t.Projeto_Id, cascadeDelete: true)
                .Index(t => t.Subtopico_Id)
                .Index(t => t.Projeto_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projeto", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.SubtopicoProjeto", "Projeto_Id", "dbo.Projeto");
            DropForeignKey("dbo.SubtopicoProjeto", "Subtopico_Id", "dbo.Subtopico");
            DropForeignKey("dbo.Subtopico", "PilarId", "dbo.Pilar");
            DropForeignKey("dbo.SubtopicoCaracteristica", "Caracteristica_Id", "dbo.Caracteristica");
            DropForeignKey("dbo.SubtopicoCaracteristica", "Subtopico_Id", "dbo.Subtopico");
            DropForeignKey("dbo.ProjetoCaracteristica", "Caracteristica_Id", "dbo.Caracteristica");
            DropForeignKey("dbo.ProjetoCaracteristica", "Projeto_Id", "dbo.Projeto");
            DropIndex("dbo.SubtopicoProjeto", new[] { "Projeto_Id" });
            DropIndex("dbo.SubtopicoProjeto", new[] { "Subtopico_Id" });
            DropIndex("dbo.SubtopicoCaracteristica", new[] { "Caracteristica_Id" });
            DropIndex("dbo.SubtopicoCaracteristica", new[] { "Subtopico_Id" });
            DropIndex("dbo.ProjetoCaracteristica", new[] { "Caracteristica_Id" });
            DropIndex("dbo.ProjetoCaracteristica", new[] { "Projeto_Id" });
            DropIndex("dbo.Subtopico", new[] { "PilarId" });
            DropIndex("dbo.Projeto", new[] { "UsuarioId" });
            DropTable("dbo.SubtopicoProjeto");
            DropTable("dbo.SubtopicoCaracteristica");
            DropTable("dbo.ProjetoCaracteristica");
            DropTable("dbo.Usuario");
            DropTable("dbo.Pilar");
            DropTable("dbo.Subtopico");
            DropTable("dbo.Projeto");
            DropTable("dbo.Caracteristica");
        }
    }
}
