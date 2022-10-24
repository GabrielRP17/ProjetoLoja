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
    public class FornecedorLojaController : ControllerBase
    {
        public IServiceFornecedorLoja _service;
        public FornecedorLojaController(IServiceFornecedorLoja service)
        {
            _service = service;
        }

        // GET: api/<FornecedorLojaController>
        [HttpGet]
        public IEnumerable<FornecedorLoja> Get()
        {
            return _service.BuscarTodos();
        }

        // GET api/<FornecedorLojaController>/5
        [HttpGet("{id}")]
        public FornecedorLoja Get(int id)
        {
            return _service.BuscarId(id);
        }

        // POST api/<FornecedorLojaController>
        [HttpPost]
        public void Post(FornecedorLoja FL)
        {
            _service.InserirFornecedoLoja(FL);
        }

        // PUT api/<FornecedorLojaController>/5
        [HttpPut("{id}")]
        public void Put(FornecedorLoja FL)
        {
            _service.AlterarFornecedorLoja(FL);
        }
    }
}
