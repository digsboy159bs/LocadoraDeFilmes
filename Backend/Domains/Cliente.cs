using System;
using System.Collections.Generic;

#nullable disable

namespace LocadoraFilmes.Domains
{
    public partial class Cliente
    {
        public Cliente()
        {
            Locacaos = new HashSet<Locacao>();
        }

        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Locacao> Locacaos { get; set; }
    }
}
