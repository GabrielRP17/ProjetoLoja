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
    public class ClienteController : ControllerBase
    {

        public readonly IServiceCliente _service;

        public ClienteController(IServiceCliente service)
        {
            _service = service;
        }


        // GET: api/<ClienteController>
        [HttpGet("BuscarTodos/")]
        public IEnumerable<Cliente> Get()
        {
            return _service.BuscarTodos();
        }

        // GET api/<ClienteController>/5
        [HttpGet("BuscaId/{id}")]
        public Cliente Get(int id)
        {
            return _service.BuscarId(id);
        }

        [HttpGet("BuscaCPF/{cpf}")]
        public Cliente CPF(string cpf)
        {
            return _service.BuscarCPF(cpf);
        }

        [HttpGet("BuscaRG/{rg}")]
        public Cliente RG(string rg)
        {
            return _service.BuscarRG(rg);
        }
        // POST api/<ClienteController>
        [HttpPost("InserirCliente/")]
        public void Post(Cliente cliente)
        {
            _service.InserirCliente(cliente);
        }

        // POST api/<ClienteController>
        [HttpGet("BuscarCliente/{email},{senha}")]
        public Cliente BuscarCliente(string email, string senha)
        {
            return _service.BuscarCliente(email, senha);
        }

        // PUT api/<ClienteController>/5
        [HttpPut("AlterarCliente/")]
        public void Put(Cliente cliente)
        {
            _service.AlterarCliente(cliente);
        }

        [HttpGet("VerificarUsuario/{Email}/{senha}")]
        public bool VerificarLogin(string email, string senha)
        {
            bool retorno = false;

            if (_service.VerificarLogin(email, senha) != 0)
                retorno = true;

            return retorno;
        }

    }
}
