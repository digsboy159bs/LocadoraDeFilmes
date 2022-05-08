using System;
using System.Collections.Generic;

#nullable disable

namespace LocadoraFilmes.Domains
{
    public partial class Locacao
    {
        public int IdLocacao { get; set; }
        public DateTime? DataRetirada { get; set; }
        public DateTime? PrazoDevolucao { get; set; }
        public int? IdCliente { get; set; }
        public int? IdFilme { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Filme IdFilmeNavigation { get; set; }
    }
}
