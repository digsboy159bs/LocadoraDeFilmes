using LocadoraFilmes.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraFilmes.Interfaces
{
    interface IFilmesRepository
    {
        List<Filme> Listar();

        Filme BuscarPorId(int id);

        void Cadastrar(Filme novoFilme);

        void Atualizar(int id, Filme filmeAtualizado);

        void Deletar(int id);
    }
}
