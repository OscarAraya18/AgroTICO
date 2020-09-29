using Backend.DBMS;
using Newtonsoft.Json.Linq;
using System.Web.Http;

namespace AgroticoApi.Controllers
{
    public class AdministradorController : ApiController
    {
        DBMS _dbms = new DBMS();


        // GET api/Administrador/Afiliaciones
        [HttpGet]
        [Route("api/Administrador/Afiliaciones")]
        public IHttpActionResult GetAfiliaciones()
        {
            var solicitudes = _dbms.encontrarSolicitudesSinResponder();
            return Ok(solicitudes);
        }

        // GET api/Administrador/Productos/+vendidos
        [HttpGet]
        [Route("api/Administrador/Productos/+vendidos")]
        public IHttpActionResult masVendidos()
        {
            var resultado = _dbms.encontrarProductosMasVendidos();

            if(resultado == null)
            {
                return NotFound();
            }
            return Ok(resultado);
        }

        // GET api/Administrador/Productos/+ganancia
        [HttpGet]
        [Route("api/Administrador/Productos/+ganancia")]
        public IHttpActionResult masGanancia()
        {
            var resultado = _dbms.encontrarProductosMasGanancias();

            if (resultado == null)
            {
                return NotFound();
            }
            return Ok(resultado);
        }

        // GET api/Administrador/Productos/+vendidosProductor
        [HttpGet]
        [Route("api/Administrador/Productos/+vendidosProductor")]
        public IHttpActionResult masVendidosPorProductor([FromUri] int id)
        {
            var resultado = _dbms.encontrarProductosMasVendidosPorProductor(id);

            if (resultado == null)
            {
                return NotFound();
            }
            return Ok(resultado);
        }

        // GET api/Administrador/Clientes/+compras
        [HttpGet]
        [Route("api/Administrador/Clientes/+compras")]
        public IHttpActionResult masCompras()
        {
            var resultado = _dbms.encontrarClientesMasCompras();

            if (resultado == null)
            {
                return NotFound();
            }
            return Ok(resultado);
        }

        // POST api/Administrador/Afiliacion/edit
        [HttpPost]
        [Route("api/Administrador/Afiliacion/edit")]
        public IHttpActionResult actualizarSolicitudAfiliacion([FromBody] JObject afiliacion)
        {
            bool resultado = _dbms.actualizarSolicitudAfiliacion(
                (int)afiliacion["codigoSolicitud"],
                (bool)afiliacion["estado"],
                (int)afiliacion["anioRespuesta"],
                (int)afiliacion["mesRespuesta"],
                (int)afiliacion["diaRespuesta"],
                (string)afiliacion["MotivoDenegacion"]) ;

            if(resultado == true)
            {
                return Ok("Actualizacion de afiliacion realizada correctamente");
            }
            return NotFound();
        }


        // POST api/Administrador/Productor/new
        [HttpPost]
        [Route("api/Administrador/Productor/new")]
        public IHttpActionResult nuevoProductor([FromBody] JObject nuevoProductor)
        {
            bool resultado = _dbms.crearProductor(
                (int)nuevoProductor["numeroCedula"],
                (string)nuevoProductor["primerNombre"],
                (string)nuevoProductor["segundoNombre"],
                (string)nuevoProductor["primerApellido"],
                (string)nuevoProductor["segundoApellido"],
                (string)nuevoProductor["provinciaResidencia"],
                (string)nuevoProductor["cantonResidencia"],
                (string)nuevoProductor["distritoResidencia"],
                (int)nuevoProductor["numeroTelefono"],
                (int)nuevoProductor["numeroSINPE"],
                (int)nuevoProductor["anioNacimiento"],
                (int)nuevoProductor["mesNacimiento"],
                (int)nuevoProductor["diaNacimiento"],
                nuevoProductor.SelectToken("lugarEntrega")?.ToObject<string[]>()
                );

            if (resultado == true)
            {
                return Ok(nuevoProductor);
            }
            return NotFound();
        }

        // POST api/Administrador/Categoria/new
        [HttpPost]
        [Route("api/Administrador/Categoria/new")]
        public IHttpActionResult crearCategoria([FromBody] JObject nuevaCategoria)
        {
            bool resultado = _dbms.crearCategoria(
                (int)nuevaCategoria["identificador"],
                (string)nuevaCategoria["nombre"]);

            if(resultado == true)
            {
                return Ok("Categoria creada correctamente");
            }
            return NotFound();
        }



        // PUT api/Administrador/Productor/edit
        [HttpPut]
        [Route("api/Administrador/Productor/edit")]
        public IHttpActionResult actualizarProductor([FromBody] JObject objeto)
        {
            bool resultado = _dbms.actualizarProductor(
                (int)objeto["numeroCedula"],
                (string)objeto["primerNombre"],
                (string)objeto["segundoNombre"],
                (string)objeto["primerApellido"],
                (string)objeto["segundoApellido"],
                (string)objeto["provinciaResidencia"],
                (string)objeto["cantonResidencia"],
                (string)objeto["distritoResidencia"],
                (int)objeto["numeroTelefono"],
                (int)objeto["numeroSINPE"],
                (int)objeto["anioNacimiento"],
                (int)objeto["mesNacimiento"],
                (int)objeto["diaNacimiento"],
                objeto.SelectToken("lugarEntrega")?.ToObject<string[]>()
                );

            if (resultado == true)
            {
                return Ok(objeto);
            }
            return NotFound();
        }

        // PUT api/Administrador/Categoria/edit
        [HttpPut]
        [Route("api/Administrador/Categoria/edit")]
        public IHttpActionResult actualizarCategoria([FromBody] JObject categoria)
        {
            bool resultado = _dbms.actualizarCategoria(
                (int)categoria["identificador"],
                (string)categoria["nombre"]);

            if (resultado == true)
            {
                return Ok("Categoria actualizada correctamente");
            }
            return NotFound();
        }

        // DELETE api/Administrador/Productor/delete
        [HttpDelete]
        [Route("api/Administrador/Productor/delete")]
        public IHttpActionResult eliminarProductor([FromUri] int id)
        {
            bool resultado = _dbms.eliminarProductor(id);

            if(resultado == true)
            {
                return Ok("Productor eliminado con exito");
            }
            return NotFound();
        }

        // DELETE api/Administrador/Categoria/delete
        [HttpDelete]
        [Route("api/Administrador/Categoria/delete")]
        public IHttpActionResult eliminarCategoria([FromUri] int id)
        {
            bool resultado = _dbms.eliminarCategoria(id);

            if (resultado == true)
            {
                return Ok("Categoria eliminada correctamente");
            }
            return NotFound();
        }
    }
}
