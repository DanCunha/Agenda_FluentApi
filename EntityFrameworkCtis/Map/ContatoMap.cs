using EntityFrameworkCtis.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EntityFrameworkCtis.Map
{
    public class ContatoMap : EntityTypeConfiguration<Contato>
    {
        public ContatoMap()
        {
            ToTable("Contato");
            HasKey(x => x.ContatoId);

            Property(x => x.Nome).HasMaxLength(150).IsRequired();

            Property(x => x.email).HasMaxLength(50).IsRequired();

            Property(x => x.Telefone).HasMaxLength(11).IsRequired();

            Property(x => x.DataNascimento).IsRequired();
        }
    }
}