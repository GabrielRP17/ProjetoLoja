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
    public class EstoqueLojaController : ControllerBase
    {
        public readonly IServiceEstoqueLoja _service;
        public EstoqueLojaController(IServiceEstoqueLoja service)
        {
            _service = service;
        }

        // GET: api/<EstoqueController>
        [HttpGet]
        public IEnumerable<EstoqueLoja> Get()
        {
            return _service.BuscarTodos();
        }

        // GET api/<EstoqueController>/5
        [HttpGet("BuscarId/{id}")]
        public EstoqueLoja Get(int id)
        {
            return _service.BuscarId(id);
        }

        // POST api/<EstoqueController>
        [HttpPost("Inserir/")]
        public void Post(EstoqueLoja estoque)
        {
            _service.InserirEstoque(estoque);
        }

        // PUT api/<EstoqueController>/5
        [HttpPut("Alterar/{id}")]
        public void Put(EstoqueLoja estoque)
        {
            _service.AlterarEstoque(estoque);
        }


    }
}
