using EntityFrameworkCtis.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EntityFrameworkCtis.Map
{
    public class EnderecoMap : EntityTypeConfiguration<Endereco>
    {
        public EnderecoMap()
        {
            /*O método ToTable define qual o nome que será
          dado a tabela no banco de dados*/
            ToTable("Endereco");

            //Definimos a propriedade CursoId como chave primária
            HasKey(x => x.EnderecoId);

            //Descricao terá no máximo 150 caracteres e será um campo "NOT NULL"
            Property(x => x.Rua).HasMaxLength(150).IsRequired();

            Property(x => x.Complemento).HasMaxLength(150).IsRequired();

            Property(x => x.Bairro).HasMaxLength(50).IsRequired();

            Property(x => x.Numero).HasMaxLength(10).IsRequired();

            Property(x => x.Cidade).HasMaxLength(50).IsRequired();

            Property(x => x.Estado).HasMaxLength(2).IsRequired();

            Property(x => x.CEP).HasMaxLength(8).IsRequired();
        }
    }
}