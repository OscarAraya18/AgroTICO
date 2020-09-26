using DBManager;
using Newtonsoft.Json.Linq;
using System.Web.Http;

namespace AgroticoApi.Controllers
{
    public class AdministradorController : ApiController
    {
        DBMS _dbms = new DBMS();

       
        // GET api/Administrador
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok();
        }

        // GET api/Administrador/{id}
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(id);
        }

        // POST api/Administrador
        [HttpPost]
        public IHttpActionResult Post([FromBody] JObject nuevoCliente)
        {
            return Ok(nuevoCliente);
        }

        // PUT api/Administrador
        [HttpPut]
        public IHttpActionResult Put([FromBody] JObject objeto)
        {
            return Ok(objeto);
        }

        // DELETE api/Administrador/{id}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Ok(id);
        }
    }
}
