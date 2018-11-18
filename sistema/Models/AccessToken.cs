using System;
using System.Collections.Generic;

namespace sistema.Models
{
    public partial class AccessToken
    {
        public int IdAccessToken { get; set; }
        public int PessoaFisica { get; set; }
        public byte[] AccessToken1 { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime Validade { get; set; }
        public int Origem { get; set; }

        public EntidadeAutenticadora OrigemNavigation { get; set; }
        public PessoaFisica PessoaFisicaNavigation { get; set; }
    }
}
