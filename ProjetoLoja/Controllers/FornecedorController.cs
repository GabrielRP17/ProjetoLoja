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
    public class FornecedorController : ControllerBase
    {

        public readonly IServiceFornecedor _service;

        public FornecedorController(IServiceFornecedor service)
        {
            _service = service;
        }

        // GET: api/<FornecedorController>
        [HttpGet]
        public IEnumerable<Fornecedor> Get()
        {
            return _service.BuscarTodos();
        }

        // GET api/<FornecedorController>/5
        [HttpGet("BuscarId/{id}")]
        public Fornecedor Get(int id)
        {
            return _service.BuscarId(id);
        }

        // POST api/<FornecedorController>
        [HttpPost("InserirFornecedor/")]
        public void Post(Fornecedor fornecedor)
        {
            _service.InserirFornecedor(fornecedor);
        }

        // PUT api/<FornecedorController>/5
        [HttpPut("AlterarFornecedor/{id}")]
        public void Put(Fornecedor fornecedor)
        {
            _service.AlterarFornecedor(fornecedor);
        }


    }
}
