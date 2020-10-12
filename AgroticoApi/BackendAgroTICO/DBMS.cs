using System;
using System.IO;
using Newtonsoft.Json;

using System.Linq;

using Newtonsoft.Json.Linq;

using System.Collections.Generic;


namespace Backend.DBMS
{

    class DBMS
    {
        //Rutas de las diferentes tablas dentro de la base de datos. Se almacenan como constantes para ahorrar tiempo.
        private static String RUTA_EJECUCION = AppDomain.CurrentDomain.BaseDirectory;
        private static String RUTA_BASE_DE_DATOS = RUTA_EJECUCION + "BackendAgroTICO\\BaseDeDatos";

        private static String RUTA_CLIENTES = RUTA_BASE_DE_DATOS + "//Cliente.txt";
        private static String RUTA_PRODUCTORES = RUTA_BASE_DE_DATOS + "//Productor.txt";
        private static String RUTA_VENTAS = RUTA_BASE_DE_DATOS + "//Venta.txt";
        private static String RUTA_PRODUCTOS = RUTA_BASE_DE_DATOS + "//Producto.txt";
        private static String RUTA_ADMINISTRADORES = RUTA_BASE_DE_DATOS + "//Administrador.txt";
        private static String RUTA_CATEGORIAS = RUTA_BASE_DE_DATOS + "//Categoria.txt";
        private static String RUTA_AFILIACIONES = RUTA_BASE_DE_DATOS + "//Afiliacion.txt";
        private static String RUTA_CARRITO_DE_COMPRAS = RUTA_BASE_DE_DATOS + "//CarritoDeCompras.txt";


        private void RESET()
        {
            if (Directory.Exists(RUTA_BASE_DE_DATOS))
            {
                if (File.Exists(RUTA_CLIENTES)) { File.Delete(RUTA_CLIENTES); }
                if (File.Exists(RUTA_PRODUCTORES)) { File.Delete(RUTA_PRODUCTORES); }
                if (File.Exists(RUTA_VENTAS)) { File.Delete(RUTA_VENTAS); }
                if (File.Exists(RUTA_PRODUCTOS)) { File.Delete(RUTA_PRODUCTOS); }
                if (File.Exists(RUTA_CATEGORIAS)) { File.Delete(RUTA_CATEGORIAS); }
                if (File.Exists(RUTA_AFILIACIONES)) { File.Delete(RUTA_AFILIACIONES); }
                if (File.Exists(RUTA_CARRITO_DE_COMPRAS)) { File.Delete(RUTA_CARRITO_DE_COMPRAS); }
                Directory.Delete(RUTA_BASE_DE_DATOS);
            }
            DirectoryInfo basesDeDatos = Directory.CreateDirectory(RUTA_BASE_DE_DATOS);
            File.CreateText(RUTA_CLIENTES);
            File.CreateText(RUTA_PRODUCTORES);
            File.CreateText(RUTA_VENTAS);
            File.CreateText(RUTA_PRODUCTOS);
            File.CreateText(RUTA_ADMINISTRADORES);
            File.CreateText(RUTA_CATEGORIAS);
            File.CreateText(RUTA_AFILIACIONES);
            File.Create(RUTA_CARRITO_DE_COMPRAS);

        }
        private void CLEAN(String rutaDelConjuntoEntidad)
        {
            File.Delete(rutaDelConjuntoEntidad);
            File.CreateText(rutaDelConjuntoEntidad);
        }
        private String SELECT(String rutaDelConjuntoEntidad, int atributoLlave)
        {
            Console.WriteLine("El DBMS ha iniciado un proceso de SELECT en el conjunto de entidad " + rutaDelConjuntoEntidad);
            String[] conjuntoEntidadActual = File.ReadAllLines(rutaDelConjuntoEntidad);
            JObject entidadAnalizar;

            for (int i = 0; i < conjuntoEntidadActual.Length; i++)
            {
                entidadAnalizar = JObject.Parse(conjuntoEntidadActual[i]);
                if (rutaDelConjuntoEntidad == RUTA_CLIENTES || rutaDelConjuntoEntidad == RUTA_PRODUCTORES)
                {
                    if ((int)entidadAnalizar["numeroCedula"] == atributoLlave)
                    {
                        Console.WriteLine("Se ha encontrado la entidad solicitada " + conjuntoEntidadActual[i]);
                        return conjuntoEntidadActual[i];
                    }
                }
                else if (rutaDelConjuntoEntidad == RUTA_PRODUCTOS || rutaDelConjuntoEntidad == RUTA_ADMINISTRADORES || rutaDelConjuntoEntidad == RUTA_CARRITO_DE_COMPRAS)
                {
                    if ((int)entidadAnalizar["codigo"] == atributoLlave)
                    {
                        Console.WriteLine("Se ha encontrado la entidad solicitada " + conjuntoEntidadActual[i]);
                        return conjuntoEntidadActual[i];
                    }
                }
                else if (rutaDelConjuntoEntidad == RUTA_VENTAS)
                {
                    if ((int)entidadAnalizar["codigoFactura"] == atributoLlave)
                    {
                        Console.WriteLine("Se ha encontrado la entidad solicitada " + conjuntoEntidadActual[i]);
                        return conjuntoEntidadActual[i];
                    }
                }
                else if (rutaDelConjuntoEntidad == RUTA_AFILIACIONES)
                {
                    if ((int)entidadAnalizar["codigoSolicitud"] == atributoLlave)
                    {
                        Console.WriteLine("Se ha encontrado la entidad solicitada " + conjuntoEntidadActual[i]);
                        return conjuntoEntidadActual[i];
                    }
                }
                else
                {
                    if ((int)entidadAnalizar["identificador"] == atributoLlave)
                    {
                        Console.WriteLine("Se ha encontrado la entidad solicitada " + conjuntoEntidadActual[i]);
                        return conjuntoEntidadActual[i];
                    }
                }
            }
            Console.WriteLine("No se ha encontrado a la entidad solicitada dentro del conjunto de entidad " + rutaDelConjuntoEntidad);
            return null;
        }
        private void INSERT(String rutaDelConjuntoEntidad, String nuevaEntidad)
        {
            Console.WriteLine("El DBMS ha iniciado un proceso de INSERT en el conjunto de entidad " + rutaDelConjuntoEntidad);
            String[] conjuntoEntidadActual = File.ReadAllLines(rutaDelConjuntoEntidad);
            StreamWriter escritor = new StreamWriter(rutaDelConjuntoEntidad);
            for (int i = 0; i < conjuntoEntidadActual.Length; i++)
            {
                escritor.WriteLine(conjuntoEntidadActual[i]);
            }
            escritor.WriteLine(nuevaEntidad);
            Console.WriteLine("Se ha colocado la nueva entidad " + nuevaEntidad);
            escritor.Close();
        }
        private void WRITE(String rutaDelConjuntoEntidad, String[] conjuntoEntidadNuevo)
        {
            Console.WriteLine("El DBMS ha iniciado un proceso de WRITE en el conjunto de entidad " + rutaDelConjuntoEntidad);
            StreamWriter escritor = new StreamWriter(rutaDelConjuntoEntidad);
            for (int i = 0; i < conjuntoEntidadNuevo.Length; i++)
            {
                escritor.WriteLine(conjuntoEntidadNuevo[i]);
            }
            Console.WriteLine("Se ha escrito el nuevo conjunto de entidad en " + rutaDelConjuntoEntidad);
            escritor.Close();
        }
        private bool DELETE(String rutaDelConjuntoEntidad, int atributoLlave)
        {
            Console.WriteLine("El DBMS ha iniciado un proceso de DELETE en el conjunto de entidad " + rutaDelConjuntoEntidad);
            String[] conjuntoEntidadActual = File.ReadAllLines(rutaDelConjuntoEntidad);
            String[] conjuntoEntidadNuevo = { };
            JObject entidadAnalizar;
            for (int i = 0; i < conjuntoEntidadActual.Length; i++)
            {
                entidadAnalizar = JObject.Parse(conjuntoEntidadActual[i]);
                if (rutaDelConjuntoEntidad == RUTA_CLIENTES || rutaDelConjuntoEntidad == RUTA_PRODUCTORES)
                {
                    if (!((int)entidadAnalizar["numeroCedula"] == atributoLlave))
                    {
                        conjuntoEntidadNuevo = conjuntoEntidadNuevo.Concat(new String[] { conjuntoEntidadActual[i] }).ToArray();
                    }
                    else { Console.WriteLine("Se ha eliminado la entidad solicitada " + conjuntoEntidadActual[i]); }
                }
                else if (rutaDelConjuntoEntidad == RUTA_PRODUCTOS || rutaDelConjuntoEntidad == RUTA_ADMINISTRADORES || rutaDelConjuntoEntidad == RUTA_CARRITO_DE_COMPRAS)
                {
                    if (!((int)entidadAnalizar["codigo"] == atributoLlave))
                    {
                        conjuntoEntidadNuevo = conjuntoEntidadNuevo.Concat(new String[] { conjuntoEntidadActual[i] }).ToArray();
                    }
                    else { Console.WriteLine("Se ha eliminado la entidad solicitada " + conjuntoEntidadActual[i]); }
                }
                else if (rutaDelConjuntoEntidad == RUTA_VENTAS)
                {
                    if (!((int)entidadAnalizar["codigoFactura"] == atributoLlave))
                    {
                        conjuntoEntidadNuevo = conjuntoEntidadNuevo.Concat(new String[] { conjuntoEntidadActual[i] }).ToArray();
                    }
                    else { Console.WriteLine("Se ha eliminado la entidad solicitada " + conjuntoEntidadActual[i]); }
                }
                else if (rutaDelConjuntoEntidad == RUTA_AFILIACIONES)
                {
                    if (!((int)entidadAnalizar["codigoSolicitud"] == atributoLlave))
                    {
                        conjuntoEntidadNuevo = conjuntoEntidadNuevo.Concat(new String[] { conjuntoEntidadActual[i] }).ToArray();
                    }
                    else { Console.WriteLine("Se ha eliminado la entidad solicitada " + conjuntoEntidadActual[i]); }
                }
                else
                {
                    if (!((int)entidadAnalizar["identificador"] == atributoLlave))
                    {
                        conjuntoEntidadNuevo = conjuntoEntidadNuevo.Concat(new String[] { conjuntoEntidadActual[i] }).ToArray();
                    }
                    else { Console.WriteLine("Se ha eliminado la entidad solicitada " + conjuntoEntidadActual[i]); }
                }
            }
            if (conjuntoEntidadActual.Length == conjuntoEntidadNuevo.Length)
            {
                Console.WriteLine("No se ha encontrado a la entidad solicitada dentro del conjunto de entidad " + rutaDelConjuntoEntidad);
                return false;
            }
            else
            {
                WRITE(rutaDelConjuntoEntidad, conjuntoEntidadNuevo);
                return true;
            }
        }
        private bool UPDATE(String rutaDelConjuntoEntidad, int atributoLlave, String atributoModificar, String nuevoValorTexto, int nuevoValorNumerico)
        {
            Console.WriteLine("El DBMS ha iniciado un proceso de UPDATE en el conjunto de entidad " + rutaDelConjuntoEntidad);
            String entidadModificar = SELECT(rutaDelConjuntoEntidad, atributoLlave);
            if (entidadModificar != null)
            {
                DELETE(rutaDelConjuntoEntidad, atributoLlave);
                JObject entidadModificada = JObject.Parse(entidadModificar);

                if (nuevoValorTexto != null)
                {
                    entidadModificada[atributoModificar] = nuevoValorTexto;
                }
                else
                {
                    entidadModificada[atributoModificar] = nuevoValorNumerico;
                }
                INSERT(rutaDelConjuntoEntidad, JsonConvert.SerializeObject(entidadModificada));
                Console.WriteLine("Se ha actualizado la entidad solicitada de " + entidadModificar + " a " + JsonConvert.SerializeObject(entidadModificada));
                return true;
            }
            else
            {
                Console.WriteLine("No se ha encontrado a la entidad solicitada dentro del conjunto de entidad " + rutaDelConjuntoEntidad);
                return false;
            }
        }
        public String[] FILTER(String rutaDelConjuntoEntidad, String atributoBuscar, String valorRequeridoTexto, int valorRequeridoNumerico)
        {
            Console.WriteLine("El DBMS ha iniciado un proceso de FILTER en el conjunto de entidad " + rutaDelConjuntoEntidad);
            String[] conjuntoEntidadActual = File.ReadAllLines(rutaDelConjuntoEntidad);
            String[] conjuntoEntidadFiltrado = { };
            JObject entidadAnalizar;
            for (int i = 0; i < conjuntoEntidadActual.Length; i++)
            {
                entidadAnalizar = JObject.Parse(conjuntoEntidadActual[i]);

                if (valorRequeridoTexto != null)
                {
                    if ((String)entidadAnalizar[atributoBuscar] == valorRequeridoTexto)
                    {
                        Console.WriteLine("Se ha encontrado a la entidad " + conjuntoEntidadActual[i]);
                        conjuntoEntidadFiltrado = conjuntoEntidadFiltrado.Concat(new String[] { conjuntoEntidadActual[i] }).ToArray();
                    }
                }
                else
                {
                    if ((int)entidadAnalizar[atributoBuscar] == valorRequeridoNumerico)
                    {
                        Console.WriteLine("Se ha encontrado a la entidad " + conjuntoEntidadActual[i]);
                        conjuntoEntidadFiltrado = conjuntoEntidadFiltrado.Concat(new String[] { conjuntoEntidadActual[i] }).ToArray();
                    }
                }
            }
            return conjuntoEntidadFiltrado;
        }
        private String[] SORT(String rutaDelConjuntoEntidad, String atributoOrdenar)
        {
            Console.WriteLine("El DBMS ha iniciado un proceso de SORT en el conjunto de entidad " + rutaDelConjuntoEntidad);
            String[] conjuntoEntidadActual = File.ReadAllLines(rutaDelConjuntoEntidad);
            String entidadTemporal;
            for (int i = 0; i < conjuntoEntidadActual.Length; i++)
            {
                for (int j = 0; j < conjuntoEntidadActual.Length - 1; j++)
                {
                    JObject entidad1 = JObject.Parse(conjuntoEntidadActual[j]);
                    JObject entidad2 = JObject.Parse(conjuntoEntidadActual[j + 1]);
                    if ((int)entidad1[atributoOrdenar] < (int)entidad2[atributoOrdenar])
                    {
                        entidadTemporal = conjuntoEntidadActual[j + 1];
                        conjuntoEntidadActual[j + 1] = conjuntoEntidadActual[j];
                        conjuntoEntidadActual[j] = entidadTemporal;
                    }
                }
            }
            return conjuntoEntidadActual;
        }
        private String[] READ(String rutaDelConjuntoEntidad)
        {
            return File.ReadAllLines(rutaDelConjuntoEntidad);
        }


        public String[] encontrarProductoPorProductor(int numeroCedulaProductor)
        {
            return FILTER(RUTA_PRODUCTOS, "numeroCedulaProductor", null, numeroCedulaProductor);
        }

        public string encontrarProducto(int codigo)
        {
            return SELECT(RUTA_PRODUCTOS, codigo);
        }



        public String[] encontrarProductorPorProvincia(String provincia)
        {
            return FILTER(RUTA_PRODUCTORES, "provinciaResidencia", provincia, 0);
        }



        public String[] encontrarProductorPorCanton(String canton)
        {
            return FILTER(RUTA_PRODUCTORES, "cantonResidencia", canton, 0);
        }
        public String[] encontrarProductorPorDistrito(String distrito)
        {
            return FILTER(RUTA_PRODUCTORES, "distritoResidencia", distrito, 0);
        }
        public String[] encontrarProductoPorProvincia(String provincia)
        {
            String[] listaProductoresPorProvincia = encontrarProductorPorProvincia(provincia);
            String[] listaProductosPorProvincia = { };
            JObject productorAnalizar;
            for (int i = 0; i < listaProductoresPorProvincia.Length; i++)
            {
                productorAnalizar = JObject.Parse(listaProductoresPorProvincia[i]);
                String[] listaProductosPorProductorPorProvincia = encontrarProductoPorProductor((int)productorAnalizar["numeroCedula"]);

                for (int j = 0; j < listaProductosPorProductorPorProvincia.Length; j++)
                {
                    listaProductosPorProvincia = listaProductosPorProvincia.Concat(new String[] { listaProductosPorProductorPorProvincia[j] }).ToArray();
                }
            }
            for (int k = 0; k < listaProductosPorProvincia.Length; k++)
            {
                Console.WriteLine("Se ha encontrado el producto en la provincia " + provincia + " " + listaProductosPorProvincia[k]);
            }
            return listaProductosPorProvincia;
        }
        public String[] encontrarProductoPorCanton(String canton)
        {
            String[] listaProductoresPorCanton = encontrarProductorPorCanton(canton);
            String[] listaProductosPorCanton = { };
            JObject productorAnalizar;
            for (int i = 0; i < listaProductoresPorCanton.Length; i++)
            {
                productorAnalizar = JObject.Parse(listaProductoresPorCanton[i]);
                String[] listaProductosPorProductorPorCanton = encontrarProductoPorProductor((int)productorAnalizar["numeroCedula"]);

                for (int j = 0; j < listaProductosPorProductorPorCanton.Length; j++)
                {
                    listaProductosPorCanton = listaProductosPorCanton.Concat(new String[] { listaProductosPorProductorPorCanton[j] }).ToArray();
                }
            }
            for (int k = 0; k < listaProductosPorCanton.Length; k++)
            {
                Console.WriteLine("Se ha encontrado el producto en el canton " + canton + " " + listaProductosPorCanton[k]);
            }
            return listaProductosPorCanton;
        }
        public String[] encontrarProductoPorDistrito(String distrito)
        {
            String[] listaProductoresPorDistrito = encontrarProductorPorDistrito(distrito);
            String[] listaProductosPorDistrito = { };
            JObject productorAnalizar;
            for (int i = 0; i < listaProductoresPorDistrito.Length; i++)
            {
                productorAnalizar = JObject.Parse(listaProductoresPorDistrito[i]);
                String[] listaProductosPorProductorPorDistrito = encontrarProductoPorProductor((int)productorAnalizar["numeroCedula"]);

                for (int j = 0; j < listaProductosPorProductorPorDistrito.Length; j++)
                {
                    listaProductosPorDistrito = listaProductosPorDistrito.Concat(new String[] { listaProductosPorProductorPorDistrito[j] }).ToArray();
                }
            }
            for (int k = 0; k < listaProductosPorDistrito.Length; k++)
            {
                Console.WriteLine("Se ha encontrado el producto en el distrito " + distrito + " " + listaProductosPorDistrito[k]);
            }
            return listaProductosPorDistrito;
        }


        /*-------------------------------------------------------------VISTA DE ADMINISTRACION-----------------------------------------------------------------*/
        public bool crearProductor(int numeroCedula, String primerNombre, String segundoNombre, String primerApellido, String segundoApellido, String provinciaResidencia,
                                    String cantonResidencia, String distritoResidencia, int numeroTelefono, int numeroSINPE, String fechaNacimiento, String claveAcceso)
        {
            if (SELECT(RUTA_PRODUCTORES, numeroCedula) == null)
            {
                BackendAgroTICO.Productor nuevoProductor = new BackendAgroTICO.Productor();
                nuevoProductor.numeroCedula = numeroCedula;
                nuevoProductor.primerNombre = primerNombre;
                nuevoProductor.segundoNombre = segundoNombre;
                nuevoProductor.primerApellido = primerApellido;
                nuevoProductor.segundoApellido = segundoApellido;
                nuevoProductor.provinciaResidencia = provinciaResidencia;
                nuevoProductor.cantonResidencia = cantonResidencia;
                nuevoProductor.distritoResidencia = distritoResidencia;
                nuevoProductor.numeroTelefono = numeroTelefono;
                nuevoProductor.numeroSINPE = numeroSINPE;
                nuevoProductor.fechaNacimiento = fechaNacimiento;
                nuevoProductor.claveAcceso = claveAcceso;
                INSERT(RUTA_PRODUCTORES, JsonConvert.SerializeObject(nuevoProductor));
                return true;
            }
            return false;
        }

        public string encontrarProductor(int cedula)
        {
            return SELECT(RUTA_PRODUCTORES, cedula);
        }

        public string encontrarCategoria(int identificador)
        {
            return SELECT(RUTA_CATEGORIAS, identificador);
        }

        public string[] encontrarCategorias()
        {
            return READ(RUTA_CATEGORIAS);
        }
        public bool actualizarProductor(int numeroCedula, String primerNombre, String segundoNombre, String primerApellido, String segundoApellido, String provinciaResidencia,
                                        String cantonResidencia, String distritoResidencia, int numeroTelefono, int numeroSINPE, String fechaNacimiento , String claveAcceso)
        {
            if (DELETE(RUTA_PRODUCTORES, numeroCedula))
            {
                return crearProductor(numeroCedula, primerNombre, segundoNombre, primerApellido, segundoApellido, provinciaResidencia, cantonResidencia, distritoResidencia,
                            numeroTelefono, numeroSINPE, fechaNacimiento, claveAcceso);
            }
            return false;
        }
        public bool eliminarProductor(int numeroCedulaProductor)
        {
            if (SELECT(RUTA_PRODUCTORES, numeroCedulaProductor) != null)
            {
                String[] productosAsociadosProductor = FILTER(RUTA_PRODUCTOS, "numeroCedulaProductor", null, numeroCedulaProductor);
                JObject producto;
                foreach (String productoAsociado in productosAsociadosProductor)
                {
                    producto = JObject.Parse(productoAsociado);
                    DELETE(RUTA_PRODUCTOS, (int)producto["codigo"]);
                }
                DELETE(RUTA_PRODUCTORES, numeroCedulaProductor);
                return true;
            }
            return false;
        }
        public bool actualizarSolicitudAfiliacion(int codigoSolicitud, string estado, string fechaRespuesta, String motivoDenegacion)
        {
            String[] solicitudesSinRespuesta = FILTER(RUTA_AFILIACIONES, "estado", "Sin respuesta", 0);
            JObject posibleProductor;
            JObject productorAceptado = null;
            foreach (String solicitud in solicitudesSinRespuesta)
            {
                posibleProductor = JObject.Parse(solicitud);
                if ((int)posibleProductor["numeroCedula"] == codigoSolicitud)
                {
                    productorAceptado = posibleProductor;
                }
            }
            if (productorAceptado == null)
            {
                return false;
            }
            if (estado.Equals("Aceptado"))
            {
                UPDATE(RUTA_AFILIACIONES, codigoSolicitud, "estado", "Aceptado", 0);
                UPDATE(RUTA_AFILIACIONES, codigoSolicitud, "motivoDenegacion", "Ha sigo aceptado en AgroTICO", 0);

                crearProductor(codigoSolicitud, (String)productorAceptado["primerNombre"], (String)productorAceptado["segundoNombre"],
                       (String)productorAceptado["primerApellido"], (String)productorAceptado["segundoApellido"],
                       (String)productorAceptado["provinciaResidencia"], (String)productorAceptado["cantonResidencia"],
                       (String)productorAceptado["distritoResidencia"], (int)productorAceptado["numeroTelefono"],
                       (int)productorAceptado["numeroSINPE"], (String)productorAceptado["fechaNacimiento"],
                       (String)productorAceptado["claveAcceso"]);
            }
            else
            {
                UPDATE(RUTA_AFILIACIONES, codigoSolicitud, "estado", "Denegado", 0);
                UPDATE(RUTA_AFILIACIONES, codigoSolicitud, "motivoDenegacion", motivoDenegacion, 0);
            }
            UPDATE(RUTA_AFILIACIONES, codigoSolicitud, "fechaRespuesta", fechaRespuesta, 0);
            
            return true;
        }
        public bool crearCategoria(int identificador, String nombre)
        {
            if (SELECT(RUTA_CATEGORIAS, identificador) == null)
            {
                JObject nuevaCategoria = new JObject();
                nuevaCategoria["identificador"] = identificador;
                nuevaCategoria["nombre"] = nombre;
                INSERT(RUTA_CATEGORIAS, JsonConvert.SerializeObject(nuevaCategoria));
                return true;
            }
            return false;
        }
        public bool actualizarCategoria(int identificador, String nombre)
        {
            if (SELECT(RUTA_CATEGORIAS, identificador) != null)
            {
                UPDATE(RUTA_CATEGORIAS, identificador, "nombre", nombre, 0);
                return true;
            }
            return false;
        }
        public bool eliminarCategoria(int identificador)
        {
            if (SELECT(RUTA_CATEGORIAS, identificador) != null)
            {
                DELETE(RUTA_CATEGORIAS, identificador);
                String[] productosModificar = FILTER(RUTA_PRODUCTOS, "identificadorCategoria", null, identificador);
                JObject productoAnalizar;
                foreach (String producto in productosModificar)
                {
                    productoAnalizar = JObject.Parse(producto);
                    UPDATE(RUTA_PRODUCTOS, (int)productoAnalizar["codigo"], "identificadorCategoria", null, 000);
                }
                return true;
            }
            return false;
        }
        public String[] encontrarSolicitudesSinResponder()
        {
            return FILTER(RUTA_AFILIACIONES, "estado", "Sin respuesta", 0);
        }
        public String[] encontrarPrimerosDiezElementos(String[] listaElementos)
        {
            if (listaElementos.Length > 10)
            {
                String[] primerosDiezElementos = { };
                for (int i = 0; i <= 9; i++)
                {
                    primerosDiezElementos = primerosDiezElementos.Concat(new String[] { listaElementos[i] }).ToArray();
                }
                return primerosDiezElementos;
            }
            return listaElementos;
        }
        public String[] encontrarProductosMasVendidos()
        {
            return encontrarPrimerosDiezElementos(SORT(RUTA_PRODUCTOS, "cantidadVendida"));
        }
        public String[] encontrarProductosMasVendidosPorProductor(int numeroCedulaProductor)
        {
            String[] productosSegunProductor = encontrarProductoPorProductor(numeroCedulaProductor);
            String entidadTemporal;
            for (int i = 0; i < productosSegunProductor.Length; i++)
            {
                for (int j = 0; j < productosSegunProductor.Length - 1; j++)
                {
                    JObject entidad1 = JObject.Parse(productosSegunProductor[j]);
                    JObject entidad2 = JObject.Parse(productosSegunProductor[j + 1]);
                    if ((int)entidad1["cantidadVendida"] < (int)entidad2["cantidadVendida"])
                    {
                        entidadTemporal = productosSegunProductor[j + 1];
                        productosSegunProductor[j + 1] = productosSegunProductor[j];
                        productosSegunProductor[j] = entidadTemporal;
                    }
                }
            }
            return encontrarPrimerosDiezElementos(productosSegunProductor);
        }
        public String[] encontrarProductosMasGanancias()
        {
            String[] productosSegunGanancias = File.ReadAllLines(RUTA_PRODUCTOS);
            String entidadTemporal;
            for (int i = 0; i < productosSegunGanancias.Length; i++)
            {
                for (int j = 0; j < productosSegunGanancias.Length - 1; j++)
                {
                    JObject entidad1 = JObject.Parse(productosSegunGanancias[j]);
                    JObject entidad2 = JObject.Parse(productosSegunGanancias[j + 1]);
                    if (((int)entidad1["cantidadVendida"] * (int)entidad1["precio"]) < ((int)entidad2["cantidadVendida"] * (int)entidad2["precio"]))
                    {
                        entidadTemporal = productosSegunGanancias[j + 1];
                        productosSegunGanancias[j + 1] = productosSegunGanancias[j];
                        productosSegunGanancias[j] = entidadTemporal;
                    }
                }
            }
            return encontrarPrimerosDiezElementos(productosSegunGanancias);
        }
        public String[] encontrarClientesMasCompras()
        {
            String[] clientesSegunCompras = SORT(RUTA_CLIENTES, "cantidadCompras");
            return encontrarPrimerosDiezElementos(clientesSegunCompras);
        }


        /*-------------------------------------------------------------VISTA DE PRODUCTOR-----------------------------------------------------------------*/
        public bool crearSolicitudAfiliacion(int numeroCedula, String primerNombre, String segundoNombre, String primerApellido, String segundoApellido, String provinciaResidencia,
                                            String cantonResidencia, String distritoResidencia, int numeroTelefono, int numeroSINPE, String fechaNacimiento , 
                                            String claveAcceso, string fechaSolicitud)
        {
            String[] solicitudesRealizadas = FILTER(RUTA_AFILIACIONES, "codigoSolicitud", null, numeroCedula);
            String[] solicitudesAceptadas = FILTER(RUTA_PRODUCTORES, "numeroCedula", null, numeroCedula);
            if (solicitudesAceptadas.Length != 0)
            {
                return false;
            }
            JObject solicitudAnalizar;
            for (int i = 0; i < solicitudesRealizadas.Length; i++)
            {
                solicitudAnalizar = JObject.Parse(solicitudesRealizadas[i]);
                if ((String)solicitudAnalizar["estado"] == "Sin respuesta")
                {
                    return false;
                }
            }
            BackendAgroTICO.Afiliacion nuevaAfiliacion = new BackendAgroTICO.Afiliacion();
            nuevaAfiliacion.codigoSolicitud = numeroCedula;
            nuevaAfiliacion.primerNombre = primerNombre;
            nuevaAfiliacion.segundoNombre = segundoNombre;
            nuevaAfiliacion.primerApellido = primerApellido;
            nuevaAfiliacion.segundoApellido = segundoApellido;
            nuevaAfiliacion.provinciaResidencia = provinciaResidencia;
            nuevaAfiliacion.cantonResidencia = cantonResidencia;
            nuevaAfiliacion.distritoResidencia = distritoResidencia;
            nuevaAfiliacion.numeroTelefono = numeroTelefono;
            nuevaAfiliacion.numeroSINPE = numeroSINPE;
            nuevaAfiliacion.numeroCedula = numeroCedula;
            nuevaAfiliacion.fechaNacimiento = fechaNacimiento;
            nuevaAfiliacion.claveAcceso = claveAcceso;
            nuevaAfiliacion.fechaSolicitud = fechaSolicitud;
            nuevaAfiliacion.estado = "Sin respuesta";
            nuevaAfiliacion.motivoDenegacion = "Sin respuesta";
            nuevaAfiliacion.fechaRespuesta = null;
            INSERT(RUTA_AFILIACIONES, JsonConvert.SerializeObject(nuevaAfiliacion));
            return true;
        }
        public String encontrarSolicitudAfiliacion(int numeroCedula)
        {
            String[] solicitudesProductor = FILTER(RUTA_AFILIACIONES, "codigoSolicitud", null, numeroCedula);
            JObject posibleSolicitud;
            JObject solicitudPendiente = null;
            foreach (String solicitud in solicitudesProductor)
            {
                posibleSolicitud = JObject.Parse(solicitud);
                if ((String)posibleSolicitud["estado"] == "Sin respuesta")
                {
                    solicitudPendiente = posibleSolicitud;
                }
            }
            if (solicitudPendiente == null)
            {
                return null;
            }
            return solicitudPendiente.ToString();
        }


        public bool crearProducto(int codigo, int numeroCedulaProductor, String nombre, String modoVenta, int disponibilidad, int precio,
                                    int identificadorCategoria, String foto)
        {
            if (SELECT(RUTA_PRODUCTOS, codigo) == null)
            {
                if (SELECT(RUTA_CATEGORIAS, identificadorCategoria) != null)
                {
                    JObject nuevoProducto = new JObject();

                    nuevoProducto["codigo"] = codigo;
                    nuevoProducto["numeroCedulaProductor"] = numeroCedulaProductor;
                    nuevoProducto["nombre"] = nombre;
                    nuevoProducto["modoVenta"] = modoVenta;
                    nuevoProducto["disponibilidad"] = disponibilidad;
                    nuevoProducto["precio"] = precio;
                    nuevoProducto["identificadorCategoria"] = identificadorCategoria;
                    nuevoProducto["cantidadVendida"] = 0;
                    nuevoProducto["foto"] = foto;

                    INSERT(RUTA_PRODUCTOS, JsonConvert.SerializeObject(nuevoProducto));
                    return true;
                }
                return false;
            }
            return false;
        }



        public bool actualizarProducto(int codigo, String nombre, String modoVenta, int disponibilidad, int precio,
                                        int identificadorCategoria, String foto)
        {
            if (SELECT(RUTA_PRODUCTOS, codigo) != null)
            {
                if (SELECT(RUTA_CATEGORIAS, identificadorCategoria) != null)
                {
                    UPDATE(RUTA_PRODUCTOS, codigo, "nombre", nombre, 0);
                    UPDATE(RUTA_PRODUCTOS, codigo, "modoVenta", modoVenta, 0);
                    UPDATE(RUTA_PRODUCTOS, codigo, "disponibilidad", null, disponibilidad);
                    UPDATE(RUTA_PRODUCTOS, codigo, "precio", null, precio);
                    UPDATE(RUTA_PRODUCTOS, codigo, "identificadorCategoria", null, identificadorCategoria);
                    UPDATE(RUTA_PRODUCTOS, codigo, "foto", foto, 0);
                    return true;
                }
                return false;
            }
            return false;
        }

        public bool eliminarProducto(int codigo)
        {
            return DELETE(RUTA_PRODUCTOS, codigo);
        }
        public String[] encontrarPedidos(int numeroCedula)
        {
            String[] productosEntregar = { };
            String[] listaVentas = READ(RUTA_VENTAS);

            JObject ventaAnalizar;
            JObject productoAnalizar;

            JObject productoVendido;

            foreach (String venta in listaVentas)
            {
                ventaAnalizar = JObject.Parse(venta);
                String[] listaProductosPorVenta = ventaAnalizar["productoVendido"].Values<String>().ToArray();

                foreach (String producto in listaProductosPorVenta)
                {
                    productoAnalizar = JObject.Parse(SELECT(RUTA_PRODUCTOS, (int)JObject.Parse(producto)["codigo"]));

                    if ((int)productoAnalizar["numeroCedulaProductor"] == numeroCedula)
                    {
                        productoVendido = new JObject();
                        productoVendido["codigo"] = (int)productoAnalizar["codigo"];
                        productoVendido["nombre"] = (String)productoAnalizar["nombre"];
                        productoVendido["cantidad"] = (int)JObject.Parse(producto)["cantidad"];
                        productoVendido["precioUnitario"] = (int)productoAnalizar["precio"];
                        productoVendido["montoTotal"] = (int)ventaAnalizar["montoTotal"];
                        productoVendido["numeroCedulaCliente"] = (String)ventaAnalizar["numeroCedulaComprador"];
                        productoVendido["direccionEntrega"] = (String)ventaAnalizar["direccionEntrega"];
                        productoVendido["codigoFactura"] = (String)ventaAnalizar["codigoFactura"];

                        productosEntregar = productosEntregar.Concat(new String[] { JsonConvert.SerializeObject(productoVendido) }).ToArray();
                    }
                }
            }
            return productosEntregar;
        }
        public bool autorizarLoginProductor(int numeroCedula, String claveAcceso)
        {
            if (SELECT(RUTA_PRODUCTORES, numeroCedula) != null)
            {
                JObject productorIngresado = JObject.Parse(SELECT(RUTA_PRODUCTORES, numeroCedula));
                if ((String)productorIngresado["claveAcceso"] == claveAcceso)
                {
                    return true;
                }
                return false;
            }
            return false;
        }



        /*-------------------------------------------------------------VISTA DEL CLIENTE-----------------------------------------------------------------*/

        public bool crearCliente(int numeroCedula, String primerNombre, String segundoNombre, String primerApellido, String segundoApellido,
                                String provinciaResidencia, String cantonResidencia, String distritoResidencia, String fechaNacimiento, int numeroTelefono, String nombreUsuario, String claveAcceso)
        {
            if (SELECT(RUTA_CLIENTES, numeroCedula) == null && FILTER(RUTA_CLIENTES, "nombreUsuario", nombreUsuario, 0).Length == 0)
            {
                JObject nuevoCliente = new JObject();
                nuevoCliente["numeroCedula"] = numeroCedula;
                nuevoCliente["primerNombre"] = primerNombre;
                nuevoCliente["segundoNombre"] = segundoNombre;
                nuevoCliente["primerApellido"] = primerApellido;
                nuevoCliente["segundoApellido"] = segundoApellido;
                nuevoCliente["provinciaResidencia"] = provinciaResidencia;
                nuevoCliente["cantonResidencia"] = cantonResidencia;
                nuevoCliente["distritoResidencia"] = distritoResidencia;
                nuevoCliente["fechaNacimiento"] = fechaNacimiento;
                nuevoCliente["numeroTelefono"] = numeroTelefono;
                nuevoCliente["nombreUsuario"] = nombreUsuario;
                nuevoCliente["claveAcceso"] = claveAcceso;
                nuevoCliente["cantidadCompras"] = 0;

                INSERT(RUTA_CLIENTES, JsonConvert.SerializeObject(nuevoCliente));
                return true;
            }

            return false;
        }

        public bool actualizarCliente(int numeroCedula, String primerNombre, String segundoNombre, String primerApellido, String segundoApellido,
                                String provinciaResidencia, String cantonResidencia, String distritoResidencia, String fechaNacimiento, int numeroTelefono, String nombreUsuario, String claveAcceso)
        {
            JObject clienteModificar = JObject.Parse(FILTER(RUTA_CLIENTES, "nombreUsuario", nombreUsuario, 0)[0]);
            if ((int)clienteModificar["numeroCedula"] == numeroCedula)
            {
                if (DELETE(RUTA_CLIENTES, numeroCedula))
                {
                    return crearCliente(numeroCedula, primerNombre, segundoNombre, primerApellido, segundoApellido, provinciaResidencia, cantonResidencia,
                                        distritoResidencia, fechaNacimiento, numeroTelefono, nombreUsuario, claveAcceso);
                }
                return false;
            }
            return false;
        }

        public bool eliminarCliente(int numeroCedula)
        {
            return DELETE(RUTA_CLIENTES, numeroCedula);
        }


        public bool autorizarLoginCliente(String nombreUsuario, String claveAcceso)
        {
            String[] usuariosPosibles = FILTER(RUTA_CLIENTES, "nombreUsuario", nombreUsuario, 0);
            if (usuariosPosibles.Length == 1)
            {
                if ((String)JObject.Parse(usuariosPosibles[0])["claveAcceso"] == claveAcceso)
                {

                    return true;
                }
            }
            return false;
        }



        //SISTEMA DEL CARRITO DE COMPRAS


        //Los productos que me lleguen del frontend tienen que tener la estructura {"codigo":123, "calificacion": 3}

        // IMPORTANTE! El sistema siempre agrega primero uno en la cantidad, ya luego en frontend la cantidad se actualiza


        public bool agregarProductoCarrito(int codigo, int calificacion)
        {
            if (SELECT(RUTA_CARRITO_DE_COMPRAS, codigo) == null)
            {

                JObject productoSolicitado = JObject.Parse(SELECT(RUTA_PRODUCTOS, codigo));
                if ((int)productoSolicitado["disponibilidad"] > 0)
                {
                    JObject nuevoProducto = new JObject();
                    nuevoProducto["codigo"] = codigo;
                    nuevoProducto["nombre"] = (String)productoSolicitado["nombre"];
                    nuevoProducto["precio"] = (int)productoSolicitado["precio"];
                    nuevoProducto["calificacion"] = calificacion;
                    nuevoProducto["cantidad"] = 1;
                    INSERT(RUTA_CARRITO_DE_COMPRAS, JsonConvert.SerializeObject(nuevoProducto));
                    return true;
                }
                return false;
            }
            return false;
        }


        public bool eliminarProductoCarrito(int codigo)
        {
            return DELETE(RUTA_CARRITO_DE_COMPRAS, codigo);
        }


        public bool aumentarCantidadProductoCarrito(int codigo)
        {
            JObject productoAumentar = JObject.Parse(SELECT(RUTA_CARRITO_DE_COMPRAS, codigo));
            return UPDATE(RUTA_CARRITO_DE_COMPRAS, codigo, "cantidad", null, (int)productoAumentar["cantidad"] + 1);
        }



        public bool reducirCantidadProductoCarrito(int codigo)
        {
            JObject productoReducir = JObject.Parse(SELECT(RUTA_CARRITO_DE_COMPRAS, codigo));
            if ((int)productoReducir["cantidad"] > 1)
            {
                return UPDATE(RUTA_CARRITO_DE_COMPRAS, codigo, "cantidad", null, (int)productoReducir["cantidad"] - 1);
            }
            return false;
        }


        public string finalizarCompra(int numeroCedulaComprador, String fechaCompra,
                                     int calificacionGeneral, String direccionEntrega, List<JObject> productos, int montoTotal)
        {
            int ventasPreviasCliente = FILTER(RUTA_VENTAS, "numeroCedulaComprador", null, numeroCedulaComprador).Length;
            BackendAgroTICO.Venta nuevaVenta = new BackendAgroTICO.Venta();
            UPDATE(RUTA_CLIENTES, numeroCedulaComprador, "cantidadCompras", null, ventasPreviasCliente + 1);
            nuevaVenta.numeroCedulaComprador = numeroCedulaComprador;
            nuevaVenta.codigoFactura = numeroCedulaComprador.ToString() + "-" + ventasPreviasCliente.ToString() + "-" + fechaCompra;
            nuevaVenta.fechaCompra = fechaCompra;
            nuevaVenta.calificacionGeneral = calificacionGeneral;
            nuevaVenta.direccionEntrega = direccionEntrega;
            List<string> lista = new List<string>();

            foreach (JObject productoAnalizar in productos)
            {
                lista.Add(JsonConvert.SerializeObject(productoAnalizar));
                int nuevaDisponibilidad = (int)(JObject.Parse(SELECT(RUTA_PRODUCTOS, (int)productoAnalizar["codigo"]))["disponibilidad"])
                    - (int)productoAnalizar["cantidad"];

                UPDATE(RUTA_PRODUCTOS, (int)productoAnalizar["codigo"], "disponibilidad", null, nuevaDisponibilidad);

                int cantidadVendidaPrevia = (int)(JObject.Parse(SELECT(RUTA_PRODUCTOS, (int)productoAnalizar["codigo"]))["cantidadVendida"]);
                UPDATE(RUTA_PRODUCTOS, (int)productoAnalizar["codigo"], "cantidadVendida", null, cantidadVendidaPrevia + (int)productoAnalizar["cantidad"]);
            }
            nuevaVenta.productoVendido = lista.ToArray();
            nuevaVenta.montoTotal = montoTotal;
            INSERT(RUTA_VENTAS, JsonConvert.SerializeObject(nuevaVenta));
            return nuevaVenta.codigoFactura;
        }

        // --------------- FUNCIONES UTILES --------------------------------


        public string SelectGeneral(string nombreRuta, string usuario)
        {
            int atributoLlave;

            if (nombreRuta.Equals("clientes")) {
                string[] resultado = FILTER(RUTA_CLIENTES, "nombreUsuario", usuario, 0);
                JObject cliente = JObject.Parse(resultado[0]);
                atributoLlave = (int)cliente["numeroCedula"];
                return SELECT(RUTA_CLIENTES, atributoLlave);
            }
            else
            {
                return null;
            }


        }
    }
}
