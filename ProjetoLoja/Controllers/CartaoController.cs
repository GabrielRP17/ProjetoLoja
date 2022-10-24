using Microsoft.AspNetCore.Mvc;
using ProjetoLoja.Interfaces;
using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetoLoja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartaoController : ControllerBase
    {
        public readonly IServiceCartao _service;

        public CartaoController(IServiceCartao service)
        {
            _service = service;
        }

        // GET: api/<CartaoController>
        [HttpGet]
        public IEnumerable<Cartao> BuscarTodos()
        {
            return _service.BuscarTodos();
        }

        // GET api/<CartaoController>/5
        [HttpGet("BuscarID/{id}")]
        public Cartao Get(int id)
        {
            return _service.BuscarId(id);
        }

        // POST api/<CartaoController>
        [HttpPost("Inserir/")]
        public void Post(Cartao cartao)
        {
            //if (_service (cartao) != 0)
            //    retorno = true;

            _service.InserirCartao(cartao);
        }

        // PUT api/<CartaoController>/5
        [HttpPut("Alterar/{id}")]
        public void Put(Cartao cartao)
        {
            _service.AlterarCartao(cartao);
        }

    }
}
