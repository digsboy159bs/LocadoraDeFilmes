using LocadoraFilmes.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraFilmes.Interfaces
{
    interface IGeneroRepository
    {
        List<Genero> Listar();
        
        Genero BuscarPorId(int id);
        
        void Cadastrar(Genero novoGenero);
        
        void Atualizar(int id, Genero generoAtualizado);

        void Deletar(int id);
    }
}
