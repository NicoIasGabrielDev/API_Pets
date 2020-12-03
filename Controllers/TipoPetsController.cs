using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIPETS.Domains;
using APIPETS.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPETS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPetsController : ControllerBase
    {

        TipoPetsRepository rep = new TipoPetsRepository();
        // GET: api/<TipoPetsController>
        [HttpGet]
        public List<TipoPets> Get()
        {
            return rep.LerTodos();
        }

        // GET api/<TipoPetsController>/5
        [HttpGet("{id}")]
        public TipoPets Get(int id)
        {
            return rep.BuscarPorID(id);
        }

        // POST api/<TipoPetsController>
        [HttpPost]
        public void Post([FromBody] TipoPets t)
        {
            rep.Cadastrar(t);   
        }

        // PUT api/<TipoPetsController>/5
        [HttpPut("{id}")]
        public TipoPets Put(int id, [FromBody] TipoPets t)
        {
            return rep.Alterar(id , t);
        }

        // DELETE api/<TipoPetsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            rep.Excluir(id);
        }
    }
}
