using LocadoraFilmes.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraFilmes.Interfaces
{
    interface ILocacaoRepository
    {
        List<Locacao> Listar();

        Locacao BuscarPorId(int id);

        void Cadastrar(Locacao locacaoFilme);

        void Atualizar(int id, Locacao locacaoAtualizado);

        void Deletar(int id);
    }
}
