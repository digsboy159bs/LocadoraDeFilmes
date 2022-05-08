using System;
using System.Collections.Generic;

#nullable disable

namespace LocadoraFilmes.Domains
{
    public partial class Genero
    {
        public Genero()
        {
            Filmes = new HashSet<Filme>();
        }

        public int IdGenero { get; set; }
        public string NomeGenero { get; set; }

        public virtual ICollection<Filme> Filmes { get; set; }
    }
}
