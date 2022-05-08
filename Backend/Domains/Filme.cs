using System;
using System.Collections.Generic;

#nullable disable

namespace LocadoraFilmes.Domains
{
    public partial class Filme
    {
        public Filme()
        {
            Locacaos = new HashSet<Locacao>();
        }

        public int IdFilme { get; set; }
        public string Nome { get; set; }
        public DateTime? AnoLancamento { get; set; }
        public string Resumo { get; set; }
        public int? IdGenero { get; set; }

        public virtual Genero IdGeneroNavigation { get; set; }
        public virtual ICollection<Locacao> Locacaos { get; set; }
    }
}
