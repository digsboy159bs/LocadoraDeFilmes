using LocadoraFilmes.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraFilmes.Interfaces
{
    interface IClienteRepository
    {
        List<Cliente> Listar();

        Cliente BuscarPorId(int id);

        void Cadastrar(Cliente clienteFilme);

        void Atualizar(int id, Cliente clienteAtualizado);

        void Deletar(int id);
    }
}
