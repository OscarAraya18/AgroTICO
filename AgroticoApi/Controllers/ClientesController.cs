using DBManager;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Http;

namespace AgroticoApi.Controllers
{
    public class ClientesController : ApiController
    {

        DBMS _dbms = new DBMS();

        // GET api/Clientes
        [HttpGet]
        public IHttpActionResult Get()
        {
            var listado = _dbms.SELECT(DBMS.RUTA_CLIENTES, 987654321);
            if (listado == "")
            {
                return NotFound();
            }

            return Ok(JObject.Parse(listado));

        }

        // GET api/Clientes/{id}
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var listado = _dbms.SELECT(DBMS.RUTA_CLIENTES, id);
            if (listado == "")
            {
                return NotFound();
            }

            return Ok(JObject.Parse(listado));

        }

        // POST api/Clientes
        [HttpPost]
        public IHttpActionResult Post([FromBody] JObject nuevoCliente)
        {
           _dbms.INSERT(DBMS.RUTA_CLIENTES, JsonConvert.SerializeObject(nuevoCliente));
            return Ok();
        }

        /*[HttpPost]
        public IHttpActionResult Post([FromBody] IFormFile image)
        {
            
            if (image != null)
            { 
                Console.WriteLine(image);
                dbms.WRITE(DBMS.RUTA_PRODUCTORES, new[] { image.ToString() });
                return Ok("La imagen llega");
            }
            return NotFound();
        }*/

        // DELETE api/Clientes/{id}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var res = _dbms.DELETE(DBMS.RUTA_CLIENTES, id);
            if (res == true)
            {
                return Ok();
            }
            return NotFound();
        }

        // PUT api/Clientes
        [HttpPut]
        public IHttpActionResult Put([FromBody] JObject objeto)
        {
            var atributoLlave = objeto["atributoLlave"];
            var atributoModificar = objeto["atributoModificar"];
            var nuevoValorTexto = objeto["nuevoValorTexto"];
            var nuevoValorNumerico = objeto["nuevoValorNumerico"];
            bool res = _dbms.UPDATE(DBMS.RUTA_CLIENTES, (int)atributoLlave, 
                (string)atributoModificar, (string)nuevoValorTexto, (int)nuevoValorNumerico);

            if (res == true)
            {
                return Ok();
            }
            return NotFound();
        }

    }
}
