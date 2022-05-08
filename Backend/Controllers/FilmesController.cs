using LocadoraFilmes.Domains;
using LocadoraFilmes.Interfaces;
using LocadoraFilmes.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraFilmes.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class FilmesController : ControllerBase
    {

        private IFilmesRepository _filmeRepository;

        public FilmesController()
        {
            _filmeRepository = new FilmesRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retora a resposta da requisição 200 - OK fazendo a chamada para o método e trazendo a lista
                return Ok(_filmeRepository.Listar());
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                // Faz a chamada para o método e armazena em um objeto filmeBuscado
                Filme filmeBuscado = _filmeRepository.BuscarPorId(id);

                // Verifica se o usuário foi encontrado
                if (filmeBuscado != null)
                {
                    // Retora a resposta da requisição 200 - OK e o usuário que foi encontrado
                    return Ok(filmeBuscado);
                }

                // Retorna a resposta da requisição 404 - Not Found com uma mensagem
                return NotFound("Nenhum filme encontrado para o ID informado");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        [HttpPatch("{id}")]
        public IActionResult Put(int id, Filme filmeAtualizado)
        {
            try
            {
                // Faz a chamada para o método e armazena em um objeto filmeBuscado
                Filme filmeBuscado = _filmeRepository.BuscarPorId(id);

                // Verifica se o usuário foi encontrado
                if (filmeBuscado != null)
                {
                    // Faz a chamada para o método
                    _filmeRepository.Atualizar(id, filmeAtualizado);

                    // Retora a resposta da requisição 204 - No Content
                    return StatusCode(204);
                }

                // Retorna a resposta da requisição 404 - Not Found com uma mensagem
                return NotFound("Nenhum filme encontrado para o ID informado");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        [HttpPost]
        public IActionResult Post(Filme novoFilme)
        {
            try
            {
                // Faz a chamada para o método
                _filmeRepository.Cadastrar(novoFilme);

                // Retora a resposta da requisição 201 - Created
                return StatusCode(201);
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada para o método e armazena em um objeto filmeBuscado
                Filme filmeBuscado = _filmeRepository.BuscarPorId(id);

                // Verifica se o usuário foi encontrado
                if (filmeBuscado != null)
                {
                    // Faz a chamada para o método
                    _filmeRepository.Deletar(id);

                    // Retora a resposta da requisição 202 - Accepted
                    return StatusCode(202);
                }

                // Retorna a resposta da requisição 404 - Not Found com uma mensagem
                return NotFound("Nenhum filme encontrado para o ID informado");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }
    }
}

