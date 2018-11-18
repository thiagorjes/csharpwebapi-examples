using System;
using System.Collections.Generic;

namespace sistema.Models
{
    public partial class PessoaFisica
    {
        public PessoaFisica()
        {
            AccessToken = new HashSet<AccessToken>();
        }

        public int IdPessoaFisica { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string NickName { get; set; }
        public DateTime Nascimento { get; set; }
        public byte? Maior { get; set; }

        public ICollection<AccessToken> AccessToken { get; set; }
    }
}
