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
    public class CompraController : ControllerBase
    {
        public readonly IServiceCompra _service;

        public CompraController(IServiceCompra service)
        {
            _service = service;
        }


        // GET: api/<CompraController>
        [HttpGet]
        public IEnumerable<Compra> Get()
        {
            return _service.BuscarTodos();
        }

        // GET api/<CompraController>/5
        [HttpGet("BuscaId/{id}")]
        public Compra Get(int id)
        {
            return _service.BuscarId(id);
        }

        // POST api/<CompraController>
        [HttpPost("InserirCompra/")]
        public void Post(Compra compra)
        {
            _service.InserirCompra(compra);
        }

        // PUT api/<CompraController>/5
        [HttpPut("AlterarCompra/{id}")]
        public void Put(Compra compra)
        {
            _service.AlterarCompra(compra);
        }
    }
}
