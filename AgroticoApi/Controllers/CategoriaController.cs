using DBManager;
using Newtonsoft.Json.Linq;
using System.Web.Http;

namespace AgroticoApi.Controllers
{
    public class CategoriaController : ApiController
    {
        DBMS _dbms = new DBMS();

        // GET api/Categoria
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok();
        }

        // GET api/Categoria/{id}
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(id);
        }

        // POST api/Categoria
        [HttpPost]
        public IHttpActionResult Post([FromBody] JObject nuevoCliente)
        {
            return Ok(nuevoCliente);
        }

        // PUT api/Categoria
        [HttpPut]
        public IHttpActionResult Put([FromBody] JObject objeto)
        {
            return Ok(objeto);
        }

        // DELETE api/Categoria/{id}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Ok(id);
        }
    }
}
