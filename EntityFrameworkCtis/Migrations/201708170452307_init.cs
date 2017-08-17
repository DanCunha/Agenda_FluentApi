namespace EntityFrameworkCtis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contato",
                c => new
                    {
                        ContatoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Telefone = c.String(nullable: false, maxLength: 11, unicode: false),
                        DataNascimento = c.DateTime(nullable: false),
                        email = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ContatoId);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        EnderecoId = c.Int(nullable: false, identity: true),
                        Rua = c.String(nullable: false, maxLength: 150, unicode: false),
                        Numero = c.String(nullable: false, maxLength: 10, unicode: false),
                        Complemento = c.String(nullable: false, maxLength: 150, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 50, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 50, unicode: false),
                        Estado = c.String(nullable: false, maxLength: 2, unicode: false),
                        CEP = c.String(nullable: false, maxLength: 8, unicode: false),
                        ContatoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnderecoId)
                .ForeignKey("dbo.Contato", t => t.ContatoId)
                .Index(t => t.ContatoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Endereco", "ContatoId", "dbo.Contato");
            DropIndex("dbo.Endereco", new[] { "ContatoId" });
            DropTable("dbo.Endereco");
            DropTable("dbo.Contato");
        }
    }
}
