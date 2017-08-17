using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkCtis.Models
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public int ContatoId { get; set; }
        public virtual Contato Contato { get; set; }

    }
}