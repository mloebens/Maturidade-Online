namespace Maturidade_Online.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarCaracteristica : DbMigration
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
                "dbo.SubtopicoEntidadeCaracteristicaEntidade",
                c => new
                    {
                        SubtopicoEntidade_Id = c.Int(nullable: false),
                        CaracteristicaEntidade_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubtopicoEntidade_Id, t.CaracteristicaEntidade_Id })
                .ForeignKey("dbo.Subtopico", t => t.SubtopicoEntidade_Id, cascadeDelete: true)
                .ForeignKey("dbo.Caracteristica", t => t.CaracteristicaEntidade_Id, cascadeDelete: true)
                .Index(t => t.SubtopicoEntidade_Id)
                .Index(t => t.CaracteristicaEntidade_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubtopicoEntidadeCaracteristicaEntidade", "CaracteristicaEntidade_Id", "dbo.Caracteristica");
            DropForeignKey("dbo.SubtopicoEntidadeCaracteristicaEntidade", "SubtopicoEntidade_Id", "dbo.Subtopico");
            DropIndex("dbo.SubtopicoEntidadeCaracteristicaEntidade", new[] { "CaracteristicaEntidade_Id" });
            DropIndex("dbo.SubtopicoEntidadeCaracteristicaEntidade", new[] { "SubtopicoEntidade_Id" });
            DropTable("dbo.SubtopicoEntidadeCaracteristicaEntidade");
            DropTable("dbo.Caracteristica");
        }
    }
}
