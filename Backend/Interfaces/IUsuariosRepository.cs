using LocadoraFilmes.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraFilmes.Interfaces
{
    interface IUsuariosRepository
    {

        List<Usuario> Listar();
        Usuario BuscarPorId(int id);
        void Cadastrar(Usuario novoUsuario);
        void Atualizar(int id, Usuario usuarioAtualizado);
        void Deletar(int id);
        Usuario Login(string email, string senha);

    }
}
