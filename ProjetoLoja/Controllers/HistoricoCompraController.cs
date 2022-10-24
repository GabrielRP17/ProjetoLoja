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
    public class HistoricoCompraController : ControllerBase
    {

        public readonly IServiceHistoricoCompra _service;
        public HistoricoCompraController(IServiceHistoricoCompra service)
        {
            _service = service;
        }


        // GET: api/<HistoricoVendaController>
        [HttpGet]
        public IEnumerable<HistoricoCompra> Get()
        {
            return _service.BuscarTodos();
        }

        // GET api/<HistoricoVendaController>/5
        [HttpGet("BuscaId/{id}")]
        public HistoricoCompra Get(int id)
        {
            return _service.BuscarId(id);
        }

        // POST api/<HistoricoVendaController>
        [HttpPost("Inserir/")]
        public void Post(HistoricoCompra historico)
        {
            _service.InserirHistoricoCompra(historico);
        }

        //PUT api/<HistoricoVendaController>
        [HttpPut("{id}")]
        public void Put(HistoricoCompra historico)
        {
            _service.AlterarHistoricoCompra(historico);
        }


    }
}
