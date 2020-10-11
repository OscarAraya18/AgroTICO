using AgroticoApi.BackendAgroTICO;
using Backend.DBMS;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AgroticoApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ClientesController : ApiController
    {

        DBMS _dbms = new DBMS();
        Reporte _reporte = new Reporte();


        // GET api/Clientes/Productor/distrito
        [HttpGet]
        [Route("api/Clientes/Productor/distrito")]
        public IHttpActionResult productorPorDistrito([FromUri] string usuario)
        {
            string cliente = _dbms.SelectGeneral("clientes", usuario);

            // Valida si el cliente existe
            if (cliente == null)
            {
                return BadRequest("No se pudo obtener resultados");
            }

            JObject jcliente = JObject.Parse(cliente);
            var resultado = _dbms.encontrarProductorPorDistrito((string)jcliente["distritoResidencia"]);
            List<JObject> lista = new List<JObject>();
            foreach (string element in resultado)
            {
                lista.Add(JObject.Parse(element));
            }
            return Ok(lista);

        }

        // GET api/Clientes/Productor/canton
        [HttpGet]
        [Route("api/Clientes/Productor/canton")]
        public IHttpActionResult productorPorCanton([FromUri] string usuario)
        {
            string cliente = _dbms.SelectGeneral("clientes", usuario);

            // Valida si el cliente existe
            if (cliente == null)
            {
                return BadRequest("No se pudo obtener resultados");
            }

            JObject jcliente = JObject.Parse(cliente);
            var resultado = _dbms.encontrarProductorPorCanton((string)jcliente["cantonResidencia"]);
            List<JObject> lista = new List<JObject>();
            foreach (string element in resultado)
            {
                lista.Add(JObject.Parse(element));
            }
            return Ok(lista);
        }

        // GET api/Clientes/Productor/provincia
        [HttpGet]
        [Route("api/Clientes/Productor/provincia")]
        public IHttpActionResult productorPorProvincia([FromUri] string usuario)
        {
            string cliente = _dbms.SelectGeneral("clientes", usuario);

            // Valida si el cliente existe
            if (cliente == null)
            {
                return BadRequest("No se pudo obtener resultados");
            }

            JObject jcliente = JObject.Parse(cliente);
            var resultado = _dbms.encontrarProductorPorProvincia((string)jcliente["provinciaResidencia"]);
            List<JObject> lista = new List<JObject>();
            foreach (string element in resultado)
            {
                lista.Add(JObject.Parse(element));
            }
            return Ok(lista);

        }

        // GET api/Clientes/Productos/productor
        [HttpGet]
        [Route("api/Clientes/Productos/productor")]
        public IHttpActionResult productosPorProductor([FromUri] int id)
        {
            var resultado = _dbms.encontrarProductoPorProductor(id);

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

        // GET api/Clientes/MiInfo
        [HttpGet]
        [Route("api/Clientes/MiInfo")]
        public IHttpActionResult getMiInfo([FromUri] string usuario)
        {
            string resultado = _dbms.SelectGeneral("clientes", usuario);
            if (resultado == null)
            {
                return NotFound();
            }
            JObject jcliente = JObject.Parse(resultado);
            return Ok(jcliente);
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
                (string)nuevoCliente["fechaNacimiento"],
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

        // POST api/Clientes/compra
        [HttpPost]
        [Route("api/Clientes/compra")]
        public IHttpActionResult crearCompra([FromBody] JObject compra)
        {
            string cliente = _dbms.SelectGeneral("clientes", (string)compra["nombreUsuario"]);

            // Valida si el cliente existe
            if (cliente == null)
            {
                return BadRequest("No se pudo realizar la compra");
            }
            JObject jcliente = JObject.Parse(cliente);
            var resultado = _dbms.finalizarCompra((int)jcliente["numeroCedula"],
                (string)compra["fechaCompra"],
                (int)compra["calificacionGeneral"],
                (string)jcliente["provinciaResidencia"] + ", " + (string)jcliente["cantonResidencia"] 
                + ", " + (string)jcliente["distritoResidencia"] + ", " + (string)compra["direccionEntrega"],
                compra["productos"].ToObject<List<JObject>>(),
                (int)compra["montoTotal"]
                );

            var pdf = _reporte.generarComprobante(
                (string)jcliente["primerNombre"],
                (string)jcliente["primerApellido"],
                (string)jcliente["segundoApellido"],
                (string)compra["montoTotal"],
                resultado);
            
            if (pdf != null)
            {
                return Ok(pdf);
            }
            return BadRequest("Ha ocurrido un error");
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
                (string)cliente["fechaNacimiento"],
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
        public IHttpActionResult eliminarCliente([FromUri] string usuario)
        {
            string resultado = _dbms.SelectGeneral("clientes", usuario);
            if (resultado == null)
            {
                return NotFound();
            }

            JObject cliente = JObject.Parse(resultado);
            bool res = _dbms.eliminarCliente((int)cliente["numeroCedula"]);

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
