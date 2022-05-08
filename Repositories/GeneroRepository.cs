using LocadoraFilmes.Domains;
using LocadoraFilmes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraFilmes.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {

        LocadoraDeFilmesContext ctx = new LocadoraDeFilmesContext();
        public void Atualizar(int id, Genero GeneroAtualizado)
        {
            
            Genero GeneroBuscado = ctx.Generos.Find(id);

            
            if (GeneroBuscado != null)
            {
                
                if (GeneroAtualizado.NomeGenero != null)
                {
                    
                    GeneroBuscado.NomeGenero = GeneroAtualizado.NomeGenero;
                }

                ctx.Generos.Update(GeneroBuscado);

                
                ctx.SaveChanges();
            }
        }

        
        public Genero BuscarPorId(int id)
        {
            
            Genero GeneroBuscado = ctx.Generos
                
                .FirstOrDefault(e => e.IdGenero == id);

            
            if (GeneroBuscado != null)
            {
                
                return GeneroBuscado;
            }

            
            return null;
        }

        
        public void Cadastrar(Genero novoGenero)
        {
            
            ctx.Generos.Add(novoGenero);

            
            ctx.SaveChanges();
        }

        
        public void Deletar(int id)
        {
            
            ctx.Generos.Remove(BuscarPorId(id));

            
            ctx.SaveChanges();
        }

        
        public List<Genero> Listar()
        {
            return ctx.Generos.ToList();
        }
    }
}