using LocadoraFilmes.Domains;
using LocadoraFilmes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraFilmes.Repositories
{
    public class LocacaoRepository : ILocacaoRepository
    {
        LocadoraDeFilmesContext ctx = new LocadoraDeFilmesContext();
        public void Atualizar(int id, Locacao locacaoAtualizado)
        {
            Locacao locacaoBuscado = ctx.Locacaos.Find(id);

            
                if (locacaoBuscado != null)
            {               
                if (locacaoAtualizado.DataRetirada != null)
                {                   
                    locacaoBuscado.DataRetirada = locacaoAtualizado.DataRetirada;
                }
               
                if (locacaoAtualizado.PrazoDevolucao != null)
                {                   
                    locacaoBuscado.PrazoDevolucao = locacaoAtualizado.PrazoDevolucao;
                }

                if (locacaoAtualizado.IdFilme != null)
                {                  
                    locacaoBuscado.IdFilme = locacaoAtualizado.IdFilme;
                }

                if (locacaoAtualizado.IdCliente != null)
                {                   
                    locacaoBuscado.IdCliente = locacaoAtualizado.IdCliente;
                }
                
                ctx.Locacaos.Update(locacaoBuscado);
               
                ctx.SaveChanges();
            }
        }

        public Locacao BuscarPorId(int id)
        {
            Locacao locacaoBuscado = ctx.Locacaos
             
              .Select(l => new Locacao()
              {
                  IdLocacao = l.IdLocacao,
                  DataRetirada = l.DataRetirada,
                  PrazoDevolucao = l.PrazoDevolucao,
                 
                  IdFilmeNavigation = new Filme()
                  {
                      IdFilme = l.IdFilmeNavigation.IdFilme,
                      Nome = l.IdFilmeNavigation.Nome
                  },
                  IdClienteNavigation = new Cliente()
                  {
                      IdCliente = l.IdClienteNavigation.IdCliente,
                      Nome = l.IdClienteNavigation.Nome
                  }
              })
              .FirstOrDefault(l => l.IdLocacao == id);
           
            if (locacaoBuscado != null)
            {               
                return locacaoBuscado;
            }
           
            return null;
        }


        public void Cadastrar(Locacao novoLocacao)
        {
            ctx.Locacaos.Add(novoLocacao);
           
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Locacaos.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Locacao> Listar()
        {
            return ctx.Locacaos
               
               .Select(l => new Locacao()
               {
                   IdLocacao = l.IdLocacao,
                   DataRetirada = l.DataRetirada,
                   PrazoDevolucao = l.PrazoDevolucao,

                   IdFilmeNavigation = new Filme()
                   {
                       IdFilme = l.IdFilmeNavigation.IdFilme,
                       Nome = l.IdFilmeNavigation.Nome
                   },
                   IdClienteNavigation = new Cliente()
                   {
                       IdCliente = l.IdClienteNavigation.IdCliente,
                       Nome = l.IdClienteNavigation.Nome,
                       Email = l.IdClienteNavigation.Email
                   }
               })
               .ToList();
        }
    }
}
