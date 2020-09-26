using DBManager;
using Newtonsoft.Json.Linq;
using System.Web.Http;

namespace AgroticoApi.Controllers
{
    public class AfiliacionesController : ApiController
    {
        DBMS _dbms = new DBMS();

        // GET api/Afiliaciones
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok();
        }

        // GET api/Afiliaciones/{id}
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(id);
        }

        // POST api/Afiliaciones
        [HttpPost]
        public IHttpActionResult Post([FromBody] JObject nuevoCliente)
        {
            return Ok(nuevoCliente);
        }

        // PUT api/Afiliaciones
        [HttpPut]
        public IHttpActionResult Put([FromBody] JObject objeto)
        {
            return Ok(objeto);
        }

        // DELETE api/Afiliaciones/{id}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Ok(id);
        }
    }
}
