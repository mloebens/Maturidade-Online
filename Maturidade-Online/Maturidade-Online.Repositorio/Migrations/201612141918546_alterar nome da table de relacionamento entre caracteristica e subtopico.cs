namespace Maturidade_Online.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterarnomedatablederelacionamentoentrecaracteristicaesubtopico : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SubtopicoEntidadeCaracteristicaEntidade", newName: "CaracteristicaSubtopico");
            RenameColumn(table: "dbo.CaracteristicaSubtopico", name: "SubtopicoEntidade_Id", newName: "SubtopicoId");
            RenameColumn(table: "dbo.CaracteristicaSubtopico", name: "CaracteristicaEntidade_Id", newName: "CaracteristicaId");
            RenameIndex(table: "dbo.CaracteristicaSubtopico", name: "IX_CaracteristicaEntidade_Id", newName: "IX_CaracteristicaId");
            RenameIndex(table: "dbo.CaracteristicaSubtopico", name: "IX_SubtopicoEntidade_Id", newName: "IX_SubtopicoId");
            DropPrimaryKey("dbo.CaracteristicaSubtopico");
            AddPrimaryKey("dbo.CaracteristicaSubtopico", new[] { "CaracteristicaId", "SubtopicoId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CaracteristicaSubtopico");
            AddPrimaryKey("dbo.CaracteristicaSubtopico", new[] { "SubtopicoEntidade_Id", "CaracteristicaEntidade_Id" });
            RenameIndex(table: "dbo.CaracteristicaSubtopico", name: "IX_SubtopicoId", newName: "IX_SubtopicoEntidade_Id");
            RenameIndex(table: "dbo.CaracteristicaSubtopico", name: "IX_CaracteristicaId", newName: "IX_CaracteristicaEntidade_Id");
            RenameColumn(table: "dbo.CaracteristicaSubtopico", name: "CaracteristicaId", newName: "CaracteristicaEntidade_Id");
            RenameColumn(table: "dbo.CaracteristicaSubtopico", name: "SubtopicoId", newName: "SubtopicoEntidade_Id");
            RenameTable(name: "dbo.CaracteristicaSubtopico", newName: "SubtopicoEntidadeCaracteristicaEntidade");
        }
    }
}
