using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntityFrameworkCtis.Models
{
    public class Contato
    {
        public Contato()
        {
            Enderecos = new List<Endereco>();
        }
        public int ContatoId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string email { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}