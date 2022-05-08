using LocadoraFilmes.Domains;
using LocadoraFilmes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraFilmes.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {

        LocadoraDeFilmesContext ctx = new LocadoraDeFilmesContext();
        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);
          
            if (usuarioBuscado != null)
            {              
                if (usuarioAtualizado.Nome != null)
                {                   
                    usuarioBuscado.Nome = usuarioAtualizado.Nome;
                }
               
                if (usuarioAtualizado.Email != null)
                {                   
                    usuarioBuscado.Email = usuarioAtualizado.Email;
                }
               
                if (usuarioAtualizado.Senha != null)
                {                   
                    usuarioBuscado.Senha = usuarioAtualizado.Senha;
                }
               
                if (usuarioAtualizado.Idade != null)
                {                   
                    usuarioBuscado.Idade = usuarioAtualizado.Idade;
                }
               
                if (usuarioAtualizado.IdTipo != null)
                {                  
                    usuarioBuscado.IdTipo = usuarioAtualizado.IdTipo;
                }
             
                ctx.Usuarios.Update(usuarioBuscado);
              
                ctx.SaveChanges();
            }
        }

        public Usuario BuscarPorId(int id)
        {
            Usuario usuarioBuscado = ctx.Usuarios
             
              .Select(u => new Usuario()
              {
                  IdUser = u.IdUser,
                  Nome = u.Nome,
                  Email = u.Email,
                  Idade = u.Idade,
                  Senha = u.Senha,

                  IdTipoNavigation = new TipoUsuario()
                  {
                      IdTipo = u.IdTipoNavigation.IdTipo,
                      Tipo = u.IdTipoNavigation.Tipo
                  }
              })
              .FirstOrDefault(u => u.IdUser == id);
           
            if (usuarioBuscado != null)
            {              
                return usuarioBuscado;
            }
           
            return null;
        }


        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);
         
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Usuarios.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios              
               .Select(u => new Usuario()
               {
                   IdUser = u.IdUser,
                   Nome = u.Nome,
                   Email = u.Email,
                   Idade = u.Idade,
                   Senha = u.Senha,

                   IdTipoNavigation = new TipoUsuario()
                   {
                       IdTipo = u.IdTipoNavigation.IdTipo,
                       Tipo = u.IdTipoNavigation.Tipo
                   }
               })
               .ToList();
        }

        public Usuario Login(string email, string senha)
        {
            Usuario usuarioBuscado = ctx.Usuarios
                .Select(u => new Usuario()
                {
                    Email = u.Email,
                    Senha = u.Senha,
                    IdTipoNavigation = new TipoUsuario()
                    {
                        IdTipo = u.IdTipoNavigation.IdTipo,
                        Tipo = u.IdTipoNavigation.Tipo
                    }
                })

                .FirstOrDefault(u => u.Email == email && u.Senha == senha);
           
            if (usuarioBuscado != null)
            {               
                return usuarioBuscado;
            }            

            return null;
        }
    }
}
