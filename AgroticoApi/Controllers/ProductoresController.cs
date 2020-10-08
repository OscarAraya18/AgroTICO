using Backend.DBMS;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AgroticoApi.Controllers
{
    [EnableCors(origins: "http://localhost:4200/", headers: "*", methods: "*")]
    public class ProductoresController : ApiController
    {
        DBMS _dbms = new DBMS();


        // GET api/Productores/Afiliacion
        [HttpGet]
        [Route("api/Productores/Afiliacion")]
        public IHttpActionResult solicitudAfiliacion([FromUri] int id)
        {
            var resultado = _dbms.encontrarSolicitudAfiliacion(id);

            if (resultado == null)
            {
                return BadRequest("Ocurrio un error");
            }
            return Ok(JObject.Parse(resultado));
        }

        // GET api/Productores/pedidos
        [HttpGet]
        [Route("api/Productores/pedidos")]
        public IHttpActionResult encontrarPedidos([FromUri] int id)
        {
            var resultado = _dbms.encontrarPedidos(id);

            if (resultado == null)
            {
                return BadRequest("No se pudo obtener resultados");
            }
            List<JObject> lista = new List<JObject>();
            foreach (string element in resultado)
            {
                lista.Add(JObject.Parse(element));
            }
            return Ok(lista);
        }

        // POST api/Productores/Afiliacion/new
        [HttpPost]
        [Route("api/Productores/Afiliacion/new")]
        public IHttpActionResult crearSolicitudAfiliacion([FromBody] JObject nuevoCliente)
        {
            bool resultado = _dbms.crearSolicitudAfiliacion(
                (int)nuevoCliente["numeroCedula"],
                (string)nuevoCliente["primerNombre"],
                (string)nuevoCliente["segundoNombre"],
                (string)nuevoCliente["primerApellido"],
                (string)nuevoCliente["segundoApellido"],
                (string)nuevoCliente["provinciaResidencia"],
                (string)nuevoCliente["cantonResidencia"],
                (string)nuevoCliente["distritoResidencia"],
                (int)nuevoCliente["numeroTelefono"],
                (int)nuevoCliente["numeroSINPE"],
                (string)nuevoCliente["fechanacimiento"],
                nuevoCliente.SelectToken("lugarEntrega")?.ToObject<string[]>(),
                (string)nuevoCliente["claveAcceso"],
                (string)nuevoCliente["fechaSolicitud"]);

            if (resultado == true)
            {
                return Ok("Solicitud creada con exito");
            }
            return NotFound();

        }

        // POST api/Productores/Producto/new
        [HttpPost]
        [Route("api/Productores/Producto/new")]
        public IHttpActionResult crearProducto([FromBody] JObject producto)
        {
            bool resultado = _dbms.crearProducto(
                (int)producto["codigo"],
                (int)producto["numeroCedulaProductor"],
                (string)producto["nombre"],
                (string)producto["modoVenta"],
                (int)producto["disponibilidad"],
                (int)producto["precio"],
                (int)producto["identificadorCategoria"],
                (string)producto["foto"]);

            if (resultado == false)
            {
                return NotFound();
            }
            return Ok("Producto creado correctamente");
        }

        // POST api/Productores/login
        [HttpPost]
        [Route("api/Productores/login")]
        public IHttpActionResult autorizarLogin([FromBody] JObject login)
        {
            bool resultado = _dbms.autorizarLoginProductor(
                (int)login["numeroCedula"],
                (string)login["claveAcceso"]);

            if (resultado == true)
            {
                return Ok("Inicio de sesion exitoso");
            }
            return BadRequest("Usuario o contrasenia incorrectos");
        }

        // PUT api/Productores/Producto/edit
        [HttpPut]
        [Route("api/Productores/Producto/edit")]
        public IHttpActionResult actualizarProducto([FromBody] JObject producto)
        {
            bool resultado = _dbms.actualizarProducto(
                (int)producto["codigo"],
                (string)producto["nombre"],
                (string)producto["modoVenta"],
                (int)producto["disponibilidad"],
                (int)producto["precio"],
                (int)producto["identificadorCategoria"],
                (string)producto["foto"]);

            if (resultado == false)
            {
                return NotFound();
            }
            return Ok("Producto creado correctamente");
        }

        // DELETE api/Productores/Producto/delete
        [HttpDelete]
        [Route("api/Productores/Producto/delete")]
        public IHttpActionResult eliminarProducto([FromUri] int id)
        {
            bool resultado = _dbms.eliminarProducto(id);

            if(resultado == true)
            {
                return Ok("Producto eliminado exitosamente");
            }
            return BadRequest("Ha ocurrido un error");
        }
    }
}
