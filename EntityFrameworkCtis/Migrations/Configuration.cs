namespace EntityFrameworkCtis.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EntityFrameworkCtis.Models.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EntityFrameworkCtis.Models.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            Endereco endereco = new Endereco();
            endereco.Rua = "Jorge Luiz Milani";
            endereco.Numero = "150";
            endereco.Complemento = "Próximo posto Ipiranga";
            endereco.Bairro = "Da Paz";
            endereco.CEP = "69049072";
            endereco.Cidade = "Manaus";
            endereco.Estado = "AM";

            Endereco endereco2 = new Endereco();
            endereco2.Rua = "Rua do comercio";
            endereco2.Numero = "150";
            endereco2.Complemento = "Próximo posto Ipiranga";
            endereco2.Bairro = "Parque Dez";
            endereco2.CEP = "69049072";
            endereco2.Cidade = "Manaus";
            endereco2.Estado = "AM";


            Contato contato = new Contato();
            contato.Nome = "Daniel";
            contato.email = "cunhacdaniel@gmail.com";
            contato.Telefone = "984222929";
            contato.DataNascimento = Convert.ToDateTime("1982-05-01");
            contato.Enderecos.Add(endereco);
            contato.Enderecos.Add(endereco2);

            context.Contato.Add(contato);
        }
    }
}
