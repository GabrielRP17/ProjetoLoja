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
    public class ProdutoLojaController : ControllerBase
    {
        public readonly IServiceProdutoLoja _service;

        public ProdutoLojaController(IServiceProdutoLoja service)
        {
            _service = service;
        }


        // GET: api/<ProdutoController>
        [HttpGet]
        public IEnumerable<ProdutoLoja> Get()
        {
            return _service.BuscarTodos();
        }

        // GET api/<ProdutoController>/5
        [HttpGet("BuscarId{id}")]
        public ProdutoLoja Get(int id)
        {
            return _service.BuscarId(id);
        }

        // POST api/<ProdutoController>
        [HttpPost("InserirProduto/")]
        public void Post(ProdutoLoja produto)
        {
            _service.InserirProduto(produto);
        }

        // PUT api/<ProdutoController>/5
        [HttpPut("AlterarProduto/")]
        public void Put(ProdutoLoja produto)
        {
            _service.AlterarProduto(produto);
        }
    }
}
