using DBManager;
using Newtonsoft.Json.Linq;
using System.Web.Http;

namespace AgroticoApi.Controllers
{
    public class VentasController : ApiController
    {
        DBMS _dbms = new DBMS();

        // GET api/Ventas
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok();
        }

        // GET api/Ventas/{id}
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(id);
        }

        // POST api/Ventas
        [HttpPost]
        public IHttpActionResult Post([FromBody] JObject nuevoCliente)
        {
            return Ok(nuevoCliente);
        }

        // PUT api/Ventas
        [HttpPut]
        public IHttpActionResult Put([FromBody] JObject objeto)
        {
            return Ok(objeto);
        }

        // DELETE api/Ventas/{id}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Ok(id);
        }
    }
}
