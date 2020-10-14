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

        /// <summary>
        /// Peticion para acceder a una solicitud de afiliación en especifico
        /// </summary>
        /// <param name="cedula">es la identificacion del productor a consultar</param>
        /// <returns>la solicitud de afiliacion en caso de tener exito</returns>
        // GET api/Productores/Afiliacion
        [HttpGet]
        [Route("api/Productores/Afiliacion")]
        public IHttpActionResult solicitudAfiliacion([FromUri] int cedula)
        {
            var resultado = _dbms.encontrarSolicitudAfiliacion(cedula);

            if (resultado == null)
            {
                return BadRequest("Ocurrio un error");
            }
            return Ok(JObject.Parse(resultado));
        }

        /// <summary>
        /// Peticion para acceder a todos los pedidos que tiene un productor
        /// </summary>
        /// <param name="cedula">es la identificacion del productor a consultar</param>
        /// <returns>la lista de pedidos en caso de exito</returns>
        // GET api/Productores/pedidos
        [HttpGet]
        [Route("api/Productores/pedidos")]
        public IHttpActionResult encontrarPedidos([FromUri] int cedula)
        {
            var resultado = _dbms.encontrarPedidos(cedula);

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

        /// <summary>
        /// Peticion para encontrar un producto en específico
        /// </summary>
        /// <param name="codigo">es el identificador para encontrar el producto</param>
        /// <returns>el producto en caso de exito</returns>
        // GET api/Productores/producto
        [HttpGet]
        [Route("api/Productores/producto")]
        public IHttpActionResult encontrarProducto([FromUri] int codigo)
        {
            var resultado = _dbms.encontrarProducto(codigo);

            if (resultado == null)
            {
                return BadRequest("No se pudo obtener resultados");
            }
            
            return Ok(JObject.Parse(resultado));
        }

        /// <summary>
        /// Peticion para encontrar todos los productos de un productor
        /// </summary>
        /// <param name="cedula">es el identificador para saber el productor</param>
        /// <returns>el producto en caso de exito</returns>
        // GET api/Productores/TodosProductos
        [HttpGet]
        [Route("api/Productores/TodosProductos")]
        public IHttpActionResult encontrarTodosProductos([FromUri] int cedula)
        {
            string[] resultado = _dbms.encontrarTodosProductos(cedula);

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

        /// <summary>
        /// Peticion para crear una solicitud de afiliacion
        /// </summary>
        /// <param name="nuevaSolicitud">Un objeto json con toda la informacion necesaria
        /// para crear la peticion</param>
        /// <returns>Un ok en caso de exito</returns>
        // POST api/Productores/Afiliacion/new
        [HttpPost]
        [Route("api/Productores/Afiliacion/new")]
        public IHttpActionResult crearSolicitudAfiliacion([FromBody] JObject nuevaSolicitud)
        {
            bool resultado = _dbms.crearSolicitudAfiliacion(
                (int)nuevaSolicitud["numeroCedula"],
                (string)nuevaSolicitud["primerNombre"],
                (string)nuevaSolicitud["segundoNombre"],
                (string)nuevaSolicitud["primerApellido"],
                (string)nuevaSolicitud["segundoApellido"],
                (string)nuevaSolicitud["provinciaResidencia"],
                (string)nuevaSolicitud["cantonResidencia"],
                (string)nuevaSolicitud["distritoResidencia"],
                (int)nuevaSolicitud["numeroTelefono"],
                (int)nuevaSolicitud["numeroSINPE"],
                (string)nuevaSolicitud["fechaNacimiento"],
                (string)nuevaSolicitud["claveAcceso"],
                (string)nuevaSolicitud["fechaSolicitud"]);

            if (resultado == true)
            {
                return Ok("Solicitud creada con exito");
            }
            return NotFound();

        }

        /// <summary>
        /// Peticion para crear un nuevo producto
        /// </summary>
        /// <param name="producto">Un objeto json con toda la informacion necesaria para crear
        /// un producto</param>
        /// <returns>Un ok en caso de exito</returns>
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

        /// <summary>
        /// Peticion para verificar un inicio de sesion
        /// </summary>
        /// <param name="login">Un objeto json con toda la informacion necesaria 
        /// para autentificar al productor</param>
        /// <returns>Un ok en caso de tener exito</returns>
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

        /// <summary>
        /// Peticion para editar un producto
        /// </summary>
        /// <param name="producto">Un objeto json con toda la informacion necesaria
        /// para representar un producto, con algun atributo actualizado</param>
        /// <returns>Un ok en caso de exito</returns>
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
            return Ok("Producto actualizado correctamente");
        }

        /// <summary>
        /// Peticion para eliminar un producto
        /// </summary>
        /// <param name="codigo">El identificador del producto a eliminar</param>
        /// <returns>Un ok en caso de exito</returns>
        // DELETE api/Productores/Producto/delete
        [HttpDelete]
        [Route("api/Productores/Producto/delete")]
        public IHttpActionResult eliminarProducto([FromUri] int codigo)
        {
            bool resultado = _dbms.eliminarProducto(codigo);

            if(resultado == true)
            {
                return Ok("Producto eliminado exitosamente");
            }
            return BadRequest("Ha ocurrido un error");
        }
    }
}
