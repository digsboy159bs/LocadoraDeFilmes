using LocadoraFilmes.Domains;
using LocadoraFilmes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraFilmes.Repositories
{
    public class FilmesRepository : IFilmesRepository
    {
        LocadoraDeFilmesContext ctx = new LocadoraDeFilmesContext();

        public void Atualizar(int id, Filme FilmeAtualizado)
        {
           
            Filme FilmeBuscado = ctx.Filmes.Find(id);
           
            if (FilmeBuscado != null)
            {               
                if (FilmeAtualizado.Nome != null)
                {                   
                    FilmeBuscado.Nome = FilmeAtualizado.Nome;
                }
               
                if (FilmeAtualizado.AnoLancamento != null)
                {                   
                    FilmeBuscado.AnoLancamento = FilmeAtualizado.AnoLancamento;
                }
              
                if (FilmeAtualizado.Resumo != null)
                {                  
                    FilmeBuscado.Resumo = FilmeAtualizado.Resumo;
                }
               
                if (FilmeAtualizado.IdGenero > 0)
                {                   
                    FilmeBuscado.IdGenero = FilmeAtualizado.IdGenero;
                }
               
                ctx.Filmes.Update(FilmeBuscado);
              
                ctx.SaveChanges();
            }
        }
      
        public Filme BuscarPorId(int id)
        {           
            Filme filmeBuscado = ctx.Filmes             
              .Select(f => new Filme()
              {
                  IdFilme = f.IdFilme,
                  Nome = f.Nome,
                  AnoLancamento = f.AnoLancamento,
                  Resumo = f.Resumo,

                  IdGeneroNavigation = new Genero()
                  {
                      IdGenero = f.IdGeneroNavigation.IdGenero,
                      NomeGenero = f.IdGeneroNavigation.NomeGenero
                  }
              })
              .FirstOrDefault(u => u.IdFilme == id);

            if (filmeBuscado != null)
            {               
                return filmeBuscado;
            }
          
            return null;
        }
      
        public void Cadastrar(Filme novoFilme)
        {            
            ctx.Filmes.Add(novoFilme);
           
            ctx.SaveChanges();
        }
       
        public void Deletar(int id)
        {           
            ctx.Filmes.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }
       
        public List<Filme> Listar()
        {           
            return ctx.Filmes
                .Select(f => new Filme()
                {
                    IdFilme = f.IdFilme,
                    Nome = f.Nome,
                    AnoLancamento = f.AnoLancamento,
                    Resumo = f.Resumo,

                    IdGeneroNavigation = new Genero()
                    {
                        IdGenero = f.IdGeneroNavigation.IdGenero,
                        NomeGenero = f.IdGeneroNavigation.NomeGenero
                    }
                })

                .ToList();
        }
    }
}
