namespace Maturidade_Online.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarPermissao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Permissao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Usuario", "Permissao_Id", c => c.Int());
            CreateIndex("dbo.Usuario", "Permissao_Id");
            AddForeignKey("dbo.Usuario", "Permissao_Id", "dbo.Permissao", "Id");
            DropColumn("dbo.Usuario", "Permissao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "Permissao", c => c.Int(nullable: false));
            DropForeignKey("dbo.Usuario", "Permissao_Id", "dbo.Permissao");
            DropIndex("dbo.Usuario", new[] { "Permissao_Id" });
            DropColumn("dbo.Usuario", "Permissao_Id");
            DropTable("dbo.Permissao");
        }
    }
}
