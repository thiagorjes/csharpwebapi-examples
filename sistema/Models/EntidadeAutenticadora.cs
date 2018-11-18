using System;
using System.Collections.Generic;

namespace sistema.Models
{
    public partial class EntidadeAutenticadora
    {
        public EntidadeAutenticadora()
        {
            AccessToken = new HashSet<AccessToken>();
        }

        public int IdEntidadeAutenticadora { get; set; }
        public string Nome { get; set; }

        public ICollection<AccessToken> AccessToken { get; set; }
    }
}
