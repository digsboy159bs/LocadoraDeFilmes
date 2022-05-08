using LocadoraFilmes.Domains;
using LocadoraFilmes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraFilmes.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        LocadoraDeFilmesContext ctx = new LocadoraDeFilmesContext();
        public void Atualizar(int id, Cliente ClienteAtualizado)
        {

            Cliente ClienteBuscado = ctx.Clientes.Find(id);


            if (ClienteBuscado != null)
            {

                if (ClienteAtualizado.Nome != null)
                {

                    ClienteBuscado.Nome = ClienteAtualizado.Nome;
                }

                ctx.Clientes.Update(ClienteBuscado);


                ctx.SaveChanges();
            }
        }


        public Cliente BuscarPorId(int id)
        {

            Cliente ClienteBuscado = ctx.Clientes

                .FirstOrDefault(e => e.IdCliente == id);


            if (ClienteBuscado != null)
            {

                return ClienteBuscado;
            }


            return null;
        }


        public void Cadastrar(Cliente novoCliente)
        {

            ctx.Clientes.Add(novoCliente);


            ctx.SaveChanges();
        }


        public void Deletar(int id)
        {

            ctx.Clientes.Remove(BuscarPorId(id));


            ctx.SaveChanges();
        }


        public List<Cliente> Listar()
        {
            return ctx.Clientes.ToList();
        }
    }
}
    

