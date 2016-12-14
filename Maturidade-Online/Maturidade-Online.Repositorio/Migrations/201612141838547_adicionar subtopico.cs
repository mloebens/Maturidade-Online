namespace Maturidade_Online.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adicionarsubtopico : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subtopico",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Pontuacao = c.Int(nullable: false),
                        PilarEntidadeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pilar", t => t.PilarEntidadeId, cascadeDelete: true)
                .Index(t => t.PilarEntidadeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subtopico", "PilarEntidadeId", "dbo.Pilar");
            DropIndex("dbo.Subtopico", new[] { "PilarEntidadeId" });
            DropTable("dbo.Subtopico");
        }
    }
}
