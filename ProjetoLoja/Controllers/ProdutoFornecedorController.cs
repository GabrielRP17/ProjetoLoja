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
    public class ProdutoFornecedorController : ControllerBase
    {
        public readonly IServiceProdutoFornecedor _service;

        public ProdutoFornecedorController(IServiceProdutoFornecedor service)
        {
            _service = service;
        }



        // GET: api/<ProdutoFornecedorController>
        [HttpGet]
        public IEnumerable<ProdutoFornecedor> Get()
        {
            return _service.BuscarTodos();
        }

        // GET api/<ProdutoFornecedorController>/5
        [HttpGet("BuscarId/{id}")]
        public ProdutoFornecedor Get(int id)
        {
            return _service.BuscarId(id);
        }

        // POST api/<ProdutoFornecedorController>
        [HttpPost("Inserir/")]
        public void Post(ProdutoFornecedor ProdFornecedor)
        {
            _service.InserirProdutoFornecedor(ProdFornecedor);
        }

        // PUT api/<ProdutoFornecedorController>/5
        [HttpPut("Alterar/{id}")]
        public void Put(ProdutoFornecedor prodFornecedor)
        {
            _service.AlterarProdutoFornecedor(prodFornecedor);
        }
    }
}
