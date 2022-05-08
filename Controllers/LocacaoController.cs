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
    public class LocacaoController : ControllerBase
    {

        private ILocacaoRepository _locacaoRepository;

        public LocacaoController()
        {
            _locacaoRepository = new LocacaoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retora a resposta da requisição 200 - OK fazendo a chamada para o método e trazendo a lista
                return Ok(_locacaoRepository.Listar());
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
                // Faz a chamada para o método e armazena em um objeto locacaoBuscado
                Locacao locacaoBuscado = _locacaoRepository.BuscarPorId(id);

                // Verifica se o usuário foi encontrado
                if (locacaoBuscado != null)
                {
                    // Retora a resposta da requisição 200 - OK e o usuário que foi encontrado
                    return Ok(locacaoBuscado);
                }

                // Retorna a resposta da requisição 404 - Not Found com uma mensagem
                return NotFound("Nenhum locacao encontrado para o ID informado");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        [HttpPatch("{id}")]
        public IActionResult Put(int id, Locacao locacaoAtualizado)
        {
            try
            {
                // Faz a chamada para o método e armazena em um objeto locacaoBuscado
                Locacao locacaoBuscado = _locacaoRepository.BuscarPorId(id);

                // Verifica se o usuário foi encontrado
                if (locacaoBuscado != null)
                {
                    // Faz a chamada para o método
                    _locacaoRepository.Atualizar(id, locacaoAtualizado);

                    // Retora a resposta da requisição 204 - No Content
                    return StatusCode(204);
                }

                // Retorna a resposta da requisição 404 - Not Found com uma mensagem
                return NotFound("Nenhum locacao encontrado para o ID informado");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        [HttpPost]
        public IActionResult Post(Locacao novoLocacao)
        {
            try
            {
                // Faz a chamada para o método
                _locacaoRepository.Cadastrar(novoLocacao);

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
                // Faz a chamada para o método e armazena em um objeto locacaoBuscado
                Locacao locacaoBuscado = _locacaoRepository.BuscarPorId(id);

                // Verifica se o usuário foi encontrado
                if (locacaoBuscado != null)
                {
                    // Faz a chamada para o método
                    _locacaoRepository.Deletar(id);

                    // Retora a resposta da requisição 202 - Accepted
                    return StatusCode(202);
                }

                // Retorna a resposta da requisição 404 - Not Found com uma mensagem
                return NotFound("Nenhum locacao encontrado para o ID informado");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }
    }
}

