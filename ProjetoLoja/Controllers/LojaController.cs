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
    public class LojaController : ControllerBase
    {
        public readonly IServiceLoja _service;

        public LojaController(IServiceLoja service)
        {
            _service = service;
        }

        // GET: api/<LojaController>
        [HttpGet]
        public IEnumerable<Lojas> Get()
        {
            return _service.BuscarTodos();
        }

        // GET api/<LojaController>/5
        [HttpGet("BuscarId/{id}")]
        public Lojas Get(int id)
        {
            return _service.BuscarId(id);
        }

        // POST api/<LojaController>
        [HttpPost("Inserir/")]
        public void Post(Lojas loja)
        {
            _service.InserirLoja(loja);
        }

        // PUT api/<LojaController>/5
        [HttpPut("Alterar/{id}")]
        public void Put(Lojas loja)
        {
            _service.AlterarLoja(loja);
        }


    }
}
