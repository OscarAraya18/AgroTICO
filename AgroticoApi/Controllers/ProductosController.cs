using DBManager;
using Newtonsoft.Json.Linq;
using System.Web.Http;

namespace AgroticoApi.Controllers
{
    public class ProductosController : ApiController
    {
        DBMS _dbms = new DBMS();


        // GET api/Productos
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok();
        }

        // GET api/Productos/{id}
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(id);
        }

        // POST api/Productos
        [HttpPost]
        public IHttpActionResult Post([FromBody] JObject nuevoCliente)
        {
            return Ok(nuevoCliente);
        }

        // PUT api/Productos
        [HttpPut]
        public IHttpActionResult Put([FromBody] JObject objeto)
        {
            return Ok(objeto);
        }

        // DELETE api/Productos/{id}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Ok(id);
        }
    }
}
