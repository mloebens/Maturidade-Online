namespace Maturidade_Online.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterarrelacionamentoprojetocaracteristica : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Caracteristica", "ProjetoEntidade_Id", "dbo.Projeto");
            DropIndex("dbo.Caracteristica", new[] { "ProjetoEntidade_Id" });
            CreateTable(
                "dbo.ProjetoCaracteristica",
                c => new
                    {
                        ProjetoId = c.Int(nullable: false),
                        CaracteristicaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjetoId, t.CaracteristicaId })
                .ForeignKey("dbo.Projeto", t => t.ProjetoId, cascadeDelete: true)
                .ForeignKey("dbo.Caracteristica", t => t.CaracteristicaId, cascadeDelete: true)
                .Index(t => t.ProjetoId)
                .Index(t => t.CaracteristicaId);
            
            DropColumn("dbo.Caracteristica", "ProjetoEntidade_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Caracteristica", "ProjetoEntidade_Id", c => c.Int());
            DropForeignKey("dbo.ProjetoCaracteristica", "CaracteristicaId", "dbo.Caracteristica");
            DropForeignKey("dbo.ProjetoCaracteristica", "ProjetoId", "dbo.Projeto");
            DropIndex("dbo.ProjetoCaracteristica", new[] { "CaracteristicaId" });
            DropIndex("dbo.ProjetoCaracteristica", new[] { "ProjetoId" });
            DropTable("dbo.ProjetoCaracteristica");
            CreateIndex("dbo.Caracteristica", "ProjetoEntidade_Id");
            AddForeignKey("dbo.Caracteristica", "ProjetoEntidade_Id", "dbo.Projeto", "Id");
        }
    }
}
