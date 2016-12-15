namespace Maturidade_Online.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adicionarnomeàtabelaprojeto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projeto", "Nome", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projeto", "Nome");
        }
    }
}
