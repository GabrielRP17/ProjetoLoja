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
    public class EstoqueFornecedorController : ControllerBase
    {
        public readonly IServiceEstoqueFornecedor _service;
        public EstoqueFornecedorController(IServiceEstoqueFornecedor service)
        {
            _service = service;
        }

        // GET: api/<EstoqueFornecedorController>
        [HttpGet("BuscarTodos/")]
        public IEnumerable<EstoqueFornecedor> Get()
        {
            return _service.BuscarTodos();
        }

        // GET api/<EstoqueFornecedorController>/5
        [HttpGet("BuscarId/{id}")]
        public EstoqueFornecedor Get(int id)
        {
            return _service.BuscarId(id);
        }

        // POST api/<EstoqueFornecedorController>
        [HttpPost("Inserir/")]
        public void Post(EstoqueFornecedor EF)
        {
            _service.InserirEstoque(EF);
        }

        // PUT api/<EstoqueFornecedorController>/5
        [HttpPut("Alterar/{id}")]
        public void Put(EstoqueFornecedor EF)
        {
            _service.AlterarEstoque(EF);
        }


    }
}
