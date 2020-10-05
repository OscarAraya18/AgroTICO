using AgroticoApi.BackendAgroTICO;
using Backend.DBMS;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Linq;
using System.Web.Http;

namespace AgroticoApi.Controllers
{
    public class ClientesController : ApiController
    {

        DBMS _dbms = new DBMS();
        Reporte _reporte = new Reporte();


        // GET api/Clientes/Productor/distrito
        [HttpGet]
        [Route("api/Clientes/Productor/distrito")]
        public IHttpActionResult productorPorDistrito([FromUri] string distrito)
        {
            var resultado = _dbms.encontrarProductorPorDistrito(distrito);

            if(resultado == null)
            {
                return NotFound();
            }
            return Ok(resultado);
        }

        // GET api/Clientes/Productor/canton
        [HttpGet]
        [Route("api/Clientes/Productor/canton")]
        public IHttpActionResult productorPorCanton([FromUri] string canton)
        {
            var resultado = _dbms.encontrarProductorPorCanton(canton);

            if (resultado == null)
            {
                return NotFound();
            }
            return Ok(resultado);
        }

        // GET api/Clientes/Productor/provincia
        [HttpGet]
        [Route("api/Clientes/Productor/provincia")]
        public IHttpActionResult productorPorProvincia([FromUri] string provincia)
        {
            var resultado = _dbms.encontrarProductorPorProvincia(provincia);

            if (resultado == null)
            {
                return NotFound();
            }
            return Ok(resultado);
        }

        // GET api/Clientes/Productos/productor
        [HttpGet]
        [Route("api/Clientes/Productos/productor")]
        public IHttpActionResult productosPorProductor([FromUri] int id)
        {
            var resultado = _dbms.encontrarProductoPorProductor(id);

            if (resultado == null)
            {
                return NotFound();
            }
            return Ok(resultado);
        }

        // GET api/Clientes/MiInfo
        [HttpGet]
        [Route("api/Clientes/MiInfo")]
        public IHttpActionResult getComprobante([FromBody] string usuario)
        {
            string resultado = _dbms.SelectGeneral("clientes", usuario);
            if (resultado == null)
            {
                return NotFound();
            }
            JObject jcliente = JObject.Parse(resultado);
            return Ok(jcliente);
        }

        // GET api/Clientes/pdf
        [HttpGet]
        [Route("api/Clientes/pdf")]
        public IHttpActionResult getComprobante([FromBody] JObject reporte)
        {

            var pdf = _reporte.generarComprobante(
                (string)reporte["nombre"],
                (string)reporte["apellido"],
                (string)reporte["monto"]);
            

            if (pdf == null)
            {
                return NotFound();
            }
            return Ok(pdf);
        }

        // POST api/Clientes/login
        [HttpPost]
        [Route("api/Clientes/login")]
        public IHttpActionResult autorizarLogin([FromBody] JObject login)
        {
            bool resultado = _dbms.autorizarLoginCliente(
                (string)login["nombreUsuario"],
                (string)login["claveAcceso"]);

            if (resultado == true)
            {
                return Ok("Inicio de sesion exitoso");
            }
            return BadRequest("Usuario o contrasenia incorrectos");
         }

        // POST api/Clientes/new
        [HttpPost]
        [Route("api/Clientes/new")]
        public IHttpActionResult nuevoCliente([FromBody] JObject nuevoCliente)
        {
            bool resultado = _dbms.crearCliente(
                (int)nuevoCliente["numeroCedula"],
                (string)nuevoCliente["primerNombre"],
                (string)nuevoCliente["segundoNombre"],
                (string)nuevoCliente["primerApellido"],
                (string)nuevoCliente["segundoApellido"],
                (string)nuevoCliente["provinciaResidencia"],
                (string)nuevoCliente["cantonResidencia"],
                (string)nuevoCliente["distritoResidencia"],
                (int)nuevoCliente["anioNacimiento"],
                (int)nuevoCliente["mesNacimiento"],
                (int)nuevoCliente["diaNacimiento"],
                (int)nuevoCliente["numeroTelefono"],
                (string)nuevoCliente["nombreUsuario"],
                (string)nuevoCliente["claveAcceso"]);

            if(resultado == true)
            {
                return Ok("Cliente creado exitosamente");
            }
            return NotFound();
        }

        // POST api/Clientes/Carrito/new
        [HttpPost]
        [Route("api/Clientes/Carrito/new")]
        public IHttpActionResult agregarProductoCarrito([FromBody] JObject producto)
        {
            bool resultado = _dbms.agregarProductoCarrito(
                (int)producto["codigo"],
                5);

            if (resultado == true)
            {
                return Ok("Producto agregado exitosamente");
            }
            return NotFound();
        }

        // PUT api/Clientes/edit
        [HttpPut]
        [Route("api/Clientes/edit")]
        public IHttpActionResult actualizarCliente([FromBody] JObject cliente)
        {
            bool resultado = _dbms.actualizarCliente(
                (int)cliente["numeroCedula"],
                (string)cliente["primerNombre"],
                (string)cliente["segundoNombre"],
                (string)cliente["primerApellido"],
                (string)cliente["segundoApellido"],
                (string)cliente["provinciaResidencia"],
                (string)cliente["cantonResidencia"],
                (string)cliente["distritoResidencia"],
                (int)cliente["anioNacimiento"],
                (int)cliente["mesNacimiento"],
                (int)cliente["diaNacimiento"],
                (int)cliente["numeroTelefono"],
                (string)cliente["nombreUsuario"],
                (string)cliente["claveAcceso"]);

            if (resultado == true)
            {
                return Ok("Cliente actualizado exitosamente");
            }
            return NotFound();
        }

        // PUT api/Clientes/Carrito/mas
        [HttpPut]
        [Route("api/Clientes/Carrito/mas")]
        public IHttpActionResult aumentarCantidadProductoCarrito([FromBody] int codigo)
        {
            bool resultado = _dbms.aumentarCantidadProductoCarrito(codigo);

            if (resultado == true)
            {
                return Ok("Se aumento la cantidad exitosamente");
            }
            return BadRequest("Producto no encontrado");
        }

        // PUT api/Clientes/Carrito/edit-
        [HttpPut]
        [Route("api/Clientes/Carrito/menos")]
        public IHttpActionResult reducirCantidadProductoCarrito([FromBody] int codigo)
        {
            bool resultado = _dbms.reducirCantidadProductoCarrito(codigo);


            if (resultado == true)
            {
                return Ok("Se redujo la cantidad exitosamente");
            }
            return BadRequest("Ya tiene la cantidad minima del producto");
        }

        // DELETE api/Clientes/delete
        [HttpDelete]
        [Route("api/Clientes/delete")]
        public IHttpActionResult eliminarCliente([FromBody] int id)
        {
            bool res = _dbms.eliminarCliente(id);

            if (res == true)
            {
                return Ok("Cliente eliminado exitosamente");
            }
            return NotFound();
        }

        // DELETE api/Clientes/Carrito/delete
        [HttpDelete]
        [Route("api/Clientes/Carrito/delete")]
        public IHttpActionResult eliminarProductoCarrito([FromUri] int codigo)
        {
            bool res = _dbms.eliminarProductoCarrito(codigo);

            if (res == true)
            {
                return Ok("Producto eliminado del carrito exitosamente");
            }
            return NotFound();
        }

    }
}
