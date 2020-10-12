using Backend.DBMS;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AgroticoApi.Controllers
{
    [EnableCors(origins: "http://localhost:4200/", headers: "*", methods: "*")]
    public class AdministradorController : ApiController
    {
        DBMS _dbms = new DBMS();

        /// <summary>
        /// Peticion para acceder a todas las afiliaciones que se encuentran sin responder
        /// </summary>
        /// <returns>Una lista de objetos tipo solicitud</returns>
        // GET api/Administrador/Afiliaciones
        [HttpGet]
        [Route("api/Administrador/Afiliaciones")]
        public IHttpActionResult GetAfiliaciones()
        {
            var solicitudes = _dbms.encontrarSolicitudesSinResponder();

            if (solicitudes == null)
            {
                return BadRequest("No se ha encontrado nada");
            }
            List<JObject> lista = new List<JObject>();
            foreach (string element in solicitudes)
            {
                lista.Add(JObject.Parse(element));
            }
            return Ok(lista);
        }

        /// <summary>
        /// Peticion para encontrar a los primeros 10 productos mas vendidos
        /// </summary>
        /// <returns>Una lista de productos</returns>
        // GET api/Administrador/Productos/masVendidos
        [HttpGet]
        [Route("api/Administrador/Productos/masVendidos")]
        public IHttpActionResult masVendidos()
        {
            var resultado = _dbms.encontrarProductosMasVendidos();

            if (resultado == null)
            {
                return BadRequest("No se ha encontrado nada");
            }
            List<JObject> lista = new List<JObject>();
            foreach (string element in resultado)
            {
                lista.Add(JObject.Parse(element));
            }
            return Ok(lista);
        }

        /// <summary>
        /// Peticion para acceder a los 10 primeros productos con más ganancia
        /// </summary>
        /// <returns>Una lista de productos</returns>
        // GET api/Administrador/Productos/masGanancia
        [HttpGet]
        [Route("api/Administrador/Productos/masGanancia")]
        public IHttpActionResult masGanancia()
        {
            var resultado = _dbms.encontrarProductosMasGanancias();

            if (resultado == null)
            {
                return BadRequest("No se ha encontrado nada");
            }
            List<JObject> lista = new List<JObject>();
            foreach (string element in resultado)
            {
                lista.Add(JObject.Parse(element));
            }
            return Ok(lista);
        }

        /// <summary>
        /// Peticion para acceder a los productos más vendidos por productor
        /// </summary>
        /// <param name="cedula">La identificacion del productor a consultar</param>
        /// <returns>Una lista de productos</returns>
        // GET api/Administrador/Productos/masVendidosProductor
        [HttpGet]
        [Route("api/Administrador/Productos/masVendidosProductor")]
        public IHttpActionResult masVendidosPorProductor([FromUri] int cedula)
        {
            var resultado = _dbms.encontrarProductosMasVendidosPorProductor(cedula);

            if (resultado == null)
            {
                return BadRequest("No se ha encontrado nada");
            }
            List<JObject> lista = new List<JObject>();
            foreach (string element in resultado)
            {
                lista.Add(JObject.Parse(element));
            }
            return Ok(lista);
        }

        /// <summary>
        /// Peticion para acceder a los clientes con más compras
        /// </summary>
        /// <returns>Una lista de clientes</returns>
        // GET api/Administrador/Clientes/masCompras
        [HttpGet]
        [Route("api/Administrador/Clientes/masCompras")]
        public IHttpActionResult masCompras()
        {
            var resultado = _dbms.encontrarClientesMasCompras();

            if (resultado == null)
            {
                return BadRequest("No se ha encontrado nada");
            }
            List<JObject> lista = new List<JObject>();
            foreach (string element in resultado)
            {
                lista.Add(JObject.Parse(element));
            }
            return Ok(lista);
        }

        /// <summary>
        /// Peticion para acceder a una afiliacion en especifico
        /// </summary>
        /// <param name="cedula">Identificador del productor a consultar</param>
        /// <returns>La afiliacion en caso de tener exito</returns>
        // GET api/Administrador/Afiliacion
        [HttpGet]
        [Route("api/Administrador/Afiliacion")]
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
        /// Peticion para acceder a un productor en específico
        /// </summary>
        /// <param name="cedula">El identificador del productor a consultar</param>
        /// <returns>El productor encontrado</returns>
        // GET api/Administrador/Productor
        [HttpGet]
        [Route("api/Administrador/Productor")]
        public IHttpActionResult encontrarProductor([FromUri] int cedula)
        {
            var resultado = _dbms.encontrarProductor(cedula);

            if (resultado == null)
            {
                return BadRequest("Ocurrio un error");
            }
            return Ok(JObject.Parse(resultado));
        }

        /// <summary>
        /// Peticion para acceder a una categoria en especifico
        /// </summary>
        /// <param name="identificador">Identificador para saber a que categoria acceder</param>
        /// <returns></returns>
        // GET api/Administrador/categoria
        [HttpGet]
        [Route("api/Administrador/categoria")]
        public IHttpActionResult encontrarCategoria([FromUri] int identificador)
        {
            var resultado = _dbms.encontrarCategoria(identificador);

            if (resultado == null)
            {
                return BadRequest("No se pudo obtener resultados");
            }

            return Ok(JObject.Parse(resultado));
        }

        /// <summary>
        /// Peticion para acceder a todas las categorias existentes
        /// </summary>
        /// <returns>Todas las categorias que encuentre</returns>
        // GET api/Administrador/categorias
        [HttpGet]
        [Route("api/Administrador/categorias")]
        public IHttpActionResult encontrarCategorias()
        {
            string[] resultado = _dbms.encontrarCategorias();

            // Valida si existen categorias
            if (resultado.Length == 0)
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
        /// Peticion para 
        /// </summary>
        /// <param name="afiliacion"></param>
        /// <returns></returns>
        // POST api/Administrador/Afiliacion/edit
        [HttpPost]
        [Route("api/Administrador/Afiliacion/edit")]
        public IHttpActionResult actualizarSolicitudAfiliacion([FromBody] JObject afiliacion)
        {
            bool resultado = _dbms.actualizarSolicitudAfiliacion(
                (int)afiliacion["codigoSolicitud"],
                (string)afiliacion["estado"],
                (string)afiliacion["fechaRespuesta"],
                (string)afiliacion["motivoDenegacion"]);

            if(resultado == true)
            {
                return Ok("Actualizacion de afiliacion realizada correctamente");
            }
            return NotFound();
        }

        /// <summary>
        /// Peticion para crear un nuevo productor
        /// </summary>
        /// <param name="nuevoProductor">Un objeto json con toda la informacion del productor</param>
        /// <returns>Un ok en caso de exito</returns>
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
                (string)nuevoProductor["fechaNacimiento"],
                (string)nuevoProductor["claveAcceso"]);

            if (resultado == true)
            {
                return Ok("El productor se ha creado correctamente");
            }
            return NotFound();
        }

        /// <summary>
        /// Peticion para crear una nueva categoria
        /// </summary>
        /// <param name="nuevaCategoria">Ub objeto json con la informacion de la categoria</param>
        /// <returns>Un ok en caso de exito</returns>
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
        
        /// <summary>
        /// Peticion para editar la informacion de un productor
        /// </summary>
        /// <param name="productor">Un objeto json con la informacion del productor
        /// ya sea modificada o no</param>
        /// <returns>Un ok en caso de exito</returns>
        // PUT api/Administrador/Productor/edit
        [HttpPut]
        [Route("api/Administrador/Productor/edit")]
        public IHttpActionResult actualizarProductor([FromBody] JObject productor)
        {
            bool resultado = _dbms.actualizarProductor(
                (int)productor["numeroCedula"],
                (string)productor["primerNombre"],
                (string)productor["segundoNombre"],
                (string)productor["primerApellido"],
                (string)productor["segundoApellido"],
                (string)productor["provinciaResidencia"],
                (string)productor["cantonResidencia"],
                (string)productor["distritoResidencia"],
                (int)productor["numeroTelefono"],
                (int)productor["numeroSINPE"],
                (string)productor["distritoResidencia"],
                (string)productor["claveAcceso"]);

            if (resultado == true)
            {
                return Ok("Actualizacion de productor realizada correctamente");
            }
            return NotFound();
        }

        /// <summary>
        /// Peticion para editar una categoria
        /// </summary>
        /// <param name="categoria">Un objeto json con la informacion de la categoria</param>
        /// <returns>Un ok en caso de exito</returns>
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

        /// <summary>
        /// Peticion para eliminar un productor específico
        /// </summary>
        /// <param name="cedula">El identificador del productor a eliminar</param>
        /// <returns>Un ok en caso de exito</returns>
        // DELETE api/Administrador/Productor/delete
        [HttpDelete]
        [Route("api/Administrador/Productor/delete")]
        public IHttpActionResult eliminarProductor([FromUri] int cedula)
        {
            bool resultado = _dbms.eliminarProductor(cedula);

            if(resultado == true)
            {
                return Ok("Productor eliminado con exito");
            }
            return NotFound();
        }

        /// <summary>
        /// Peticion para eliminar una categoria en especifico
        /// </summary>
        /// <param name="identificador">El identificador de la categoria a eliminar</param>
        /// <returns>Un ok en caso de exito</returns>
        // DELETE api/Administrador/Categoria/delete
        [HttpDelete]
        [Route("api/Administrador/Categoria/delete")]
        public IHttpActionResult eliminarCategoria([FromUri] int identificador)
        {
            bool resultado = _dbms.eliminarCategoria(identificador);

            if (resultado == true)
            {
                return Ok("Categoria eliminada correctamente");
            }
            return NotFound();
        }
    }
}
