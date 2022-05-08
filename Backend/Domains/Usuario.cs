using System;
using System.Collections.Generic;

#nullable disable

namespace LocadoraFilmes.Domains
{
    public partial class Usuario
    {
        public int IdUser { get; set; }
        public string Nome { get; set; }
        public int? Idade { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? IdTipo { get; set; }

        public virtual TipoUsuario IdTipoNavigation { get; set; }
    }
}
