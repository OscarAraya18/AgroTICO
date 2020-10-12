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

        // Funcion para crear de nuevo las bases de datos
        private void RESET()
        {
            if (Directory.Exists(RUTA_BASE_DE_DATOS)) // verifica si existe y despues elimina
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
            //Se crean directorios nuevos
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

        // Funcion para limpiar un archivo especifico de la base de datos
        private void CLEAN(String rutaDelConjuntoEntidad)
        {
            File.Delete(rutaDelConjuntoEntidad);
            File.CreateText(rutaDelConjuntoEntidad);
        }

        // método utilizado para encontrar la información referente a una determinada 
        // entidad mediante su atributo llave 
        private String SELECT(String rutaDelConjuntoEntidad, int atributoLlave)
        {
            Console.WriteLine("El DBMS ha iniciado un proceso de SELECT en el conjunto de entidad " + rutaDelConjuntoEntidad);
            String[] conjuntoEntidadActual = File.ReadAllLines(rutaDelConjuntoEntidad);
            JObject entidadAnalizar;

            for (int i = 0; i < conjuntoEntidadActual.Length; i++)
            {
                entidadAnalizar = JObject.Parse(conjuntoEntidadActual[i]);
                if (rutaDelConjuntoEntidad == RUTA_CLIENTES || rutaDelConjuntoEntidad == RUTA_PRODUCTORES) //verifica por la cedula
                {
                    if ((int)entidadAnalizar["numeroCedula"] == atributoLlave)
                    {
                        Console.WriteLine("Se ha encontrado la entidad solicitada " + conjuntoEntidadActual[i]);
                        return conjuntoEntidadActual[i];
                    }
                }
                else if (rutaDelConjuntoEntidad == RUTA_PRODUCTOS || rutaDelConjuntoEntidad == RUTA_ADMINISTRADORES || rutaDelConjuntoEntidad == RUTA_CARRITO_DE_COMPRAS) // verifica por codigo
                {
                    if ((int)entidadAnalizar["codigo"] == atributoLlave)
                    {
                        Console.WriteLine("Se ha encontrado la entidad solicitada " + conjuntoEntidadActual[i]);
                        return conjuntoEntidadActual[i];
                    }
                }
                else if (rutaDelConjuntoEntidad == RUTA_VENTAS) // verifica por codigoFactura
                {
                    if ((int)entidadAnalizar["codigoFactura"] == atributoLlave) 
                    {
                        Console.WriteLine("Se ha encontrado la entidad solicitada " + conjuntoEntidadActual[i]);
                        return conjuntoEntidadActual[i];
                    }
                }
                else if (rutaDelConjuntoEntidad == RUTA_AFILIACIONES) // verifica por codigoSolicitud
                {
                    if ((int)entidadAnalizar["codigoSolicitud"] == atributoLlave)
                    {
                        Console.WriteLine("Se ha encontrado la entidad solicitada " + conjuntoEntidadActual[i]);
                        return conjuntoEntidadActual[i];
                    }
                }
                else // verifica por un identificador
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

        // método utilizado para almacenar la información de las entidades
        private void INSERT(String rutaDelConjuntoEntidad, String nuevaEntidad)
        {
            Console.WriteLine("El DBMS ha iniciado un proceso de INSERT en el conjunto de entidad " + rutaDelConjuntoEntidad);
            String[] conjuntoEntidadActual = File.ReadAllLines(rutaDelConjuntoEntidad);
            StreamWriter escritor = new StreamWriter(rutaDelConjuntoEntidad);
            for (int i = 0; i < conjuntoEntidadActual.Length; i++)
            {
                escritor.WriteLine(conjuntoEntidadActual[i]); // se escribe lo que ya existe
            }
            escritor.WriteLine(nuevaEntidad); //se escribe la nueva entidad
            Console.WriteLine("Se ha colocado la nueva entidad " + nuevaEntidad);
            escritor.Close();
        }

        // método utilizado para sobreescribir uno de los archivos de la 
        // base de datos con el conjunto de entidad nuevo. 
        private void WRITE(String rutaDelConjuntoEntidad, String[] conjuntoEntidadNuevo)
        {
            Console.WriteLine("El DBMS ha iniciado un proceso de WRITE en el conjunto de entidad " + rutaDelConjuntoEntidad);
            StreamWriter escritor = new StreamWriter(rutaDelConjuntoEntidad);
            for (int i = 0; i < conjuntoEntidadNuevo.Length; i++)
            {
                escritor.WriteLine(conjuntoEntidadNuevo[i]); // se escribe lo que existe
            }
            Console.WriteLine("Se ha escrito el nuevo conjunto de entidad en " + rutaDelConjuntoEntidad);
            escritor.Close();
        }

        // método utilizado para eliminar una de las entidades según su atributo 
        // llave en la ruta especificada en el parámetro
        private bool DELETE(String rutaDelConjuntoEntidad, int atributoLlave)
        {
            Console.WriteLine("El DBMS ha iniciado un proceso de DELETE en el conjunto de entidad " + rutaDelConjuntoEntidad);
            String[] conjuntoEntidadActual = File.ReadAllLines(rutaDelConjuntoEntidad);
            String[] conjuntoEntidadNuevo = { };
            JObject entidadAnalizar;
            for (int i = 0; i < conjuntoEntidadActual.Length; i++)
            {
                entidadAnalizar = JObject.Parse(conjuntoEntidadActual[i]);
                if (rutaDelConjuntoEntidad == RUTA_CLIENTES || rutaDelConjuntoEntidad == RUTA_PRODUCTORES) // verifica por cedula
                {
                    if (!((int)entidadAnalizar["numeroCedula"] == atributoLlave)) 
                    {
                        conjuntoEntidadNuevo = conjuntoEntidadNuevo.Concat(new String[] { conjuntoEntidadActual[i] }).ToArray();
                    }
                    else { Console.WriteLine("Se ha eliminado la entidad solicitada " + conjuntoEntidadActual[i]); }
                }
                else if (rutaDelConjuntoEntidad == RUTA_PRODUCTOS || rutaDelConjuntoEntidad == RUTA_ADMINISTRADORES || rutaDelConjuntoEntidad == RUTA_CARRITO_DE_COMPRAS) // verifica por codigo
                {
                    if (!((int)entidadAnalizar["codigo"] == atributoLlave))
                    {
                        conjuntoEntidadNuevo = conjuntoEntidadNuevo.Concat(new String[] { conjuntoEntidadActual[i] }).ToArray();
                    }
                    else { Console.WriteLine("Se ha eliminado la entidad solicitada " + conjuntoEntidadActual[i]); }
                }
                else if (rutaDelConjuntoEntidad == RUTA_VENTAS) // se verifica por codigoFactura
                {
                    if (!((int)entidadAnalizar["codigoFactura"] == atributoLlave))
                    {
                        conjuntoEntidadNuevo = conjuntoEntidadNuevo.Concat(new String[] { conjuntoEntidadActual[i] }).ToArray();
                    }
                    else { Console.WriteLine("Se ha eliminado la entidad solicitada " + conjuntoEntidadActual[i]); }
                }
                else if (rutaDelConjuntoEntidad == RUTA_AFILIACIONES) // se verifica por codigoSolicitud
                {
                    if (!((int)entidadAnalizar["codigoSolicitud"] == atributoLlave))
                    {
                        conjuntoEntidadNuevo = conjuntoEntidadNuevo.Concat(new String[] { conjuntoEntidadActual[i] }).ToArray();
                    }
                    else { Console.WriteLine("Se ha eliminado la entidad solicitada " + conjuntoEntidadActual[i]); }
                }
                else
                {
                    if (!((int)entidadAnalizar["identificador"] == atributoLlave)) // se verifica por identificador
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

        // método utilizado para modificar el valor de uno de los atributos dentro de las entidades.
        private bool UPDATE(String rutaDelConjuntoEntidad, int atributoLlave, String atributoModificar, String nuevoValorTexto, int nuevoValorNumerico)
        {
            Console.WriteLine("El DBMS ha iniciado un proceso de UPDATE en el conjunto de entidad " + rutaDelConjuntoEntidad);
            String entidadModificar = SELECT(rutaDelConjuntoEntidad, atributoLlave);
            if (entidadModificar != null)
            {
                DELETE(rutaDelConjuntoEntidad, atributoLlave);
                JObject entidadModificada = JObject.Parse(entidadModificar);

                if (nuevoValorTexto != null) // se verifica si lo que hay que cambiar es texto
                {
                    entidadModificada[atributoModificar] = nuevoValorTexto;
                }
                else // en caso contrario lo que hay que cambiar es un valor numerico
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

        // método utilizado para filtrar los archivos de la base de datos en función de un 
        // atributo atributoBuscar que cumpla con los valores específicos 
        // dados por valorRequeridoTexto o valorRequeridoNumerico.
        public String[] FILTER(String rutaDelConjuntoEntidad, String atributoBuscar, String valorRequeridoTexto, int valorRequeridoNumerico)
        {
            Console.WriteLine("El DBMS ha iniciado un proceso de FILTER en el conjunto de entidad " + rutaDelConjuntoEntidad);
            String[] conjuntoEntidadActual = File.ReadAllLines(rutaDelConjuntoEntidad);
            String[] conjuntoEntidadFiltrado = { };
            JObject entidadAnalizar;
            for (int i = 0; i < conjuntoEntidadActual.Length; i++)
            {
                entidadAnalizar = JObject.Parse(conjuntoEntidadActual[i]); // se accede a una entidad

                if (valorRequeridoTexto != null) // se valida si lo que se quiere cambiar es un texto
                {
                    if ((String)entidadAnalizar[atributoBuscar] == valorRequeridoTexto)
                    {
                        Console.WriteLine("Se ha encontrado a la entidad " + conjuntoEntidadActual[i]);
                        conjuntoEntidadFiltrado = conjuntoEntidadFiltrado.Concat(new String[] { conjuntoEntidadActual[i] }).ToArray();
                    }
                }
                else // sino significa que lo que se quiere cambiar es un numero
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

        // método utilizado para ordenar un conjunto de entidad en una ruta específica 
        // en función del nombre de algún atributo atributoOrdenar.
        private String[] SORT(String rutaDelConjuntoEntidad, String atributoOrdenar)
        {
            Console.WriteLine("El DBMS ha iniciado un proceso de SORT en el conjunto de entidad " + rutaDelConjuntoEntidad);
            String[] conjuntoEntidadActual = File.ReadAllLines(rutaDelConjuntoEntidad);
            String entidadTemporal;
            for (int i = 0; i < conjuntoEntidadActual.Length; i++) // se recorre el conjunto que se tiene
            {
                for (int j = 0; j < conjuntoEntidadActual.Length - 1; j++)
                {
                    JObject entidad1 = JObject.Parse(conjuntoEntidadActual[j]);
                    JObject entidad2 = JObject.Parse(conjuntoEntidadActual[j + 1]); // se accede al siguiente elemento
                    if ((int)entidad1[atributoOrdenar] < (int)entidad2[atributoOrdenar]) // se valida quien es mayor
                    {
                        // se realiza el cambio de posicion
                        entidadTemporal = conjuntoEntidadActual[j + 1];
                        conjuntoEntidadActual[j + 1] = conjuntoEntidadActual[j];
                        conjuntoEntidadActual[j] = entidadTemporal;
                    }
                }
            }
            return conjuntoEntidadActual;
        }

        // método utilizado para leer todas las entidades almacenadas en un archivo de la base de datos
        private String[] READ(String rutaDelConjuntoEntidad)
        {
            return File.ReadAllLines(rutaDelConjuntoEntidad);
        }

        // método utilizado para filtrar la base de datos de productos y retornar en un String[] que 
        // contiene solo aquellos que pertenezcan a un determinado productor
        public String[] encontrarProductoPorProductor(int numeroCedulaProductor)
        {
            return FILTER(RUTA_PRODUCTOS, "numeroCedulaProductor", null, numeroCedulaProductor);
        }

        // método utilizado para buscar un producto específico en la base de datos
        // mediante su codigo
        public string encontrarProducto(int codigo)
        {
            return SELECT(RUTA_PRODUCTOS, codigo);
        }

        // método utilizado para filtrar la base de datos de productores y 
        // retornar un String[] con solo los que viven en una determinada provincia.
        public String[] encontrarProductorPorProvincia(String provincia)
        {
            return FILTER(RUTA_PRODUCTORES, "provinciaResidencia", provincia, 0);
        }

        // método utilizado para filtrar la base de datos de productores y 
        // retornar un String[] con solo los que viven en una determinada canton.
        public String[] encontrarProductorPorCanton(String canton)
        {
            return FILTER(RUTA_PRODUCTORES, "cantonResidencia", canton, 0);
        }

        // método utilizado para filtrar la base de datos de productores y 
        // retornar un String[] con solo los que viven en una determinada distrito.
        public String[] encontrarProductorPorDistrito(String distrito)
        {
            return FILTER(RUTA_PRODUCTORES, "distritoResidencia", distrito, 0);
        }

        // método que encuentra todos los productos que se ofrecen para una provincia.
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

        // método que encuentra todos los productos que se ofrecen para un canton.
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

        // método que encuentra todos los productos que se ofrecen para un distrito.
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

        // método utilizado por el administrador para crear a los productores 
        // que podrán vender dentro del sistema
        public bool crearProductor(int numeroCedula, String primerNombre, String segundoNombre, String primerApellido, String segundoApellido, String provinciaResidencia,
                                    String cantonResidencia, String distritoResidencia, int numeroTelefono, int numeroSINPE, String fechaNacimiento, String claveAcceso)
        {
            if (SELECT(RUTA_PRODUCTORES, numeroCedula) == null) // verifica si no existe el productor
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

        // método para encontrar un productor específico mediante su numero de cedula
        public string encontrarProductor(int cedula)
        {
            return SELECT(RUTA_PRODUCTORES, cedula);
        }

        // método para encontrar una categoría específica mediante su identificador
        public string encontrarCategoria(int identificador)
        {
            return SELECT(RUTA_CATEGORIAS, identificador);
        }

        // método para encontrar todas las categorías existentes en la base de datos
        public string[] encontrarCategorias()
        {
            return READ(RUTA_CATEGORIAS);
        }

        // étodo que sirve para actualizar un productor, en función del numeroCedula
        public bool actualizarProductor(int numeroCedula, String primerNombre, String segundoNombre, String primerApellido, String segundoApellido, String provinciaResidencia,
                                        String cantonResidencia, String distritoResidencia, int numeroTelefono, int numeroSINPE, String fechaNacimiento , String claveAcceso)
        {
            if (DELETE(RUTA_PRODUCTORES, numeroCedula)) // primero se elimina el productor
            {
                // aquí se crea uno con los nuevos datos
                return crearProductor(numeroCedula, primerNombre, segundoNombre, primerApellido, segundoApellido, provinciaResidencia, cantonResidencia, distritoResidencia,
                            numeroTelefono, numeroSINPE, fechaNacimiento, claveAcceso);
            }
            return false;
        }

        // método utilizado para eliminar un productor de la base de datos en función de su numeroCedula
        public bool eliminarProductor(int numeroCedulaProductor)
        {
            if (SELECT(RUTA_PRODUCTORES, numeroCedulaProductor) != null) //verifica su existencia en la base de datos
            {
                String[] productosAsociadosProductor = FILTER(RUTA_PRODUCTOS, "numeroCedulaProductor", null, numeroCedulaProductor);
                JObject producto;
                foreach (String productoAsociado in productosAsociadosProductor) // se eliminan todos los productos de ese productor
                {
                    producto = JObject.Parse(productoAsociado);
                    DELETE(RUTA_PRODUCTOS, (int)producto["codigo"]);
                }
                DELETE(RUTA_PRODUCTORES, numeroCedulaProductor);
                return true;
            }
            return false;
        }

        // método utilizado para responder a las solicitudes de afiliación generadas por los productores
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
            if (productorAceptado == null) // si no existe el productor aceptado
            {
                return false;
            }
            if (estado.Equals("Aceptado")) // cuando el administrador acepta la solicitud
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
            else // cuando el administrador deniega la solicitud
            {
                UPDATE(RUTA_AFILIACIONES, codigoSolicitud, "estado", "Denegado", 0);
                UPDATE(RUTA_AFILIACIONES, codigoSolicitud, "motivoDenegacion", motivoDenegacion, 0);
            }
            UPDATE(RUTA_AFILIACIONES, codigoSolicitud, "fechaRespuesta", fechaRespuesta, 0);
            
            return true;
        }

        // método requerido por el administrador para crear una categoría
        public bool crearCategoria(int identificador, String nombre)
        {
            if (SELECT(RUTA_CATEGORIAS, identificador) == null) // verifica si no existe
            {
                JObject nuevaCategoria = new JObject();
                nuevaCategoria["identificador"] = identificador;
                nuevaCategoria["nombre"] = nombre;
                INSERT(RUTA_CATEGORIAS, JsonConvert.SerializeObject(nuevaCategoria));
                return true;
            }
            return false;
        }

        // método que actualiza el nombre de las categorías dentro de la base de datos.
        public bool actualizarCategoria(int identificador, String nombre)
        {
            if (SELECT(RUTA_CATEGORIAS, identificador) != null) // verifica si existe
            {
                UPDATE(RUTA_CATEGORIAS, identificador, "nombre", nombre, 0); // se actualiza el nombre
                return true;
            }
            return false;
        }

        // método empleado por el administrador para eliminar una categoría en función del identificador. 
        public bool eliminarCategoria(int identificador)
        {
            if (SELECT(RUTA_CATEGORIAS, identificador) != null)
            {
                DELETE(RUTA_CATEGORIAS, identificador);
                String[] productosModificar = FILTER(RUTA_PRODUCTOS, "identificadorCategoria", null, identificador);
                JObject productoAnalizar;
                foreach (String producto in productosModificar)
                {
                    // por cada producto asociado se cambia la categoria a una nula (000)
                    productoAnalizar = JObject.Parse(producto);
                    UPDATE(RUTA_PRODUCTOS, (int)productoAnalizar["codigo"], "identificadorCategoria", null, 000);
                }
                return true;
            }
            return false;
        }

        // método que retorna un String[] con todas las solicitudes de afiliación sin responder en formato JSON
        public String[] encontrarSolicitudesSinResponder()
        {
            return FILTER(RUTA_AFILIACIONES, "estado", "Sin respuesta", 0);
        }

        // método que encuentra los primeros diez elementos de una lista y los retorna en forma de un String[].
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

        // método que encuentra los diez productos más vendidos y los retorna en forma de un String[].
        public String[] encontrarProductosMasVendidos()
        {
            return encontrarPrimerosDiezElementos(SORT(RUTA_PRODUCTOS, "cantidadVendida"));
        }

        // étodo que encuentra y retorna los diez productos más vendidos de un determinado
        // productor en función del numeroCedulaProductor.
        public String[] encontrarProductosMasVendidosPorProductor(int numeroCedulaProductor)
        {
            String[] productosSegunProductor = encontrarProductoPorProductor(numeroCedulaProductor); // se acceden a los productos de ese productor
            String entidadTemporal;
            for (int i = 0; i < productosSegunProductor.Length; i++)
            {
                for (int j = 0; j < productosSegunProductor.Length - 1; j++)
                {
                    JObject entidad1 = JObject.Parse(productosSegunProductor[j]);
                    JObject entidad2 = JObject.Parse(productosSegunProductor[j + 1]);
                    if ((int)entidad1["cantidadVendida"] < (int)entidad2["cantidadVendida"]) // se valida quien es mayor
                    {
                        // se hace el cambio de posicion
                        entidadTemporal = productosSegunProductor[j + 1];
                        productosSegunProductor[j + 1] = productosSegunProductor[j];
                        productosSegunProductor[j] = entidadTemporal;
                    }
                }
            }
            return encontrarPrimerosDiezElementos(productosSegunProductor);
        }

        // método que retorna un String[] con los diez productos que más ganancias generan dentro del sistema
        public String[] encontrarProductosMasGanancias()
        {
            String[] productosSegunGanancias = File.ReadAllLines(RUTA_PRODUCTOS); // se accede a todos los productos
            String entidadTemporal;
            for (int i = 0; i < productosSegunGanancias.Length; i++)
            {
                for (int j = 0; j < productosSegunGanancias.Length - 1; j++)
                {
                    JObject entidad1 = JObject.Parse(productosSegunGanancias[j]);
                    JObject entidad2 = JObject.Parse(productosSegunGanancias[j + 1]);
                    // para ver la ganacia lo que se hace es multiplicar el precio por la cantidad ventida 
                    if (((int)entidad1["cantidadVendida"] * (int)entidad1["precio"]) < ((int)entidad2["cantidadVendida"] * (int)entidad2["precio"]))
                    {
                        // se realiza el cambio de posicion
                        entidadTemporal = productosSegunGanancias[j + 1];
                        productosSegunGanancias[j + 1] = productosSegunGanancias[j];
                        productosSegunGanancias[j] = entidadTemporal;
                    }
                }
            }
            return encontrarPrimerosDiezElementos(productosSegunGanancias);
        }

        // método utilizado para obtener, en forma de un String[], los diez clientes que más 
        //compras han realizado dentro del sistema, ordenados de mayor a menor cantidad.
        public String[] encontrarClientesMasCompras()
        {
            String[] clientesSegunCompras = SORT(RUTA_CLIENTES, "cantidadCompras");
            return encontrarPrimerosDiezElementos(clientesSegunCompras);
        }


        /*-------------------------------------------------------------VISTA DE PRODUCTOR-----------------------------------------------------------------*/

        // Funcion que genera una solicitud de afiliacion. Posteriormente el administrador va a poder accederla
        public bool crearSolicitudAfiliacion(int numeroCedula, String primerNombre, String segundoNombre, String primerApellido, String segundoApellido, String provinciaResidencia,
                                            String cantonResidencia, String distritoResidencia, int numeroTelefono, int numeroSINPE, String fechaNacimiento , 
                                            String claveAcceso, string fechaSolicitud)
        {
            String[] solicitudesRealizadas = FILTER(RUTA_AFILIACIONES, "codigoSolicitud", null, numeroCedula);
            String[] solicitudesAceptadas = FILTER(RUTA_PRODUCTORES, "numeroCedula", null, numeroCedula);
            if (solicitudesAceptadas.Length != 0) // verifica si ese productor no está aceptado
            {
                return false;
            }
            JObject solicitudAnalizar;
            for (int i = 0; i < solicitudesRealizadas.Length; i++)
            {
                // se busca que el productor no tenga solicitudes en espera
                solicitudAnalizar = JObject.Parse(solicitudesRealizadas[i]);
                if ((String)solicitudAnalizar["estado"] == "Sin respuesta")
                {
                    return false;
                }
            }
            // se crea la solicitud en la base de datos
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

        // Busca una solicitud de afiliacion por numero de cédula y la retorna
        public String encontrarSolicitudAfiliacion(int numeroCedula)
        {
            String[] solicitudesProductor = FILTER(RUTA_AFILIACIONES, "codigoSolicitud", null, numeroCedula);
            JObject posibleSolicitud;
            JObject solicitudPendiente = null;
            foreach (String solicitud in solicitudesProductor)
            {
                posibleSolicitud = JObject.Parse(solicitud);
                // verifica si existe una solicitud sin respuesta dentro de todas las solicitudes
                if ((String)posibleSolicitud["estado"] == "Sin respuesta")
                {
                    solicitudPendiente = posibleSolicitud;
                }
            }
            if (solicitudPendiente == null) // si ya esta aceptada la solicitud, devuelve null
            {
                return null;
            }
            return solicitudPendiente.ToString();
        }

        // Funcion para crear un producto.
        // Retorna true si se logra crear y false en caso contrario
        public bool crearProducto(int codigo, int numeroCedulaProductor, String nombre, String modoVenta, int disponibilidad, int precio,
                                    int identificadorCategoria, String foto)
        {
            if (SELECT(RUTA_PRODUCTOS, codigo) == null) // revisa si el producto no existe
            {
                if (SELECT(RUTA_CATEGORIAS, identificadorCategoria) != null) // verifica que la categoria exista
                {
                    // se crea el nuevo producto en la base de datos
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

        // Metodo para actualizar los datos correspondientes a un producto
        // Retorna true en caso de que se tenga exito, false en caso contrario
        public bool actualizarProducto(int codigo, String nombre, String modoVenta, int disponibilidad, int precio,
                                        int identificadorCategoria, String foto)
        {
            if (SELECT(RUTA_PRODUCTOS, codigo) != null) // verifica si el producto existe
            {
                if (SELECT(RUTA_CATEGORIAS, identificadorCategoria) != null) // verifica que la categoria exista
                {
                    // se actualiza el producto
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

        // Metodo para eliminar algun producto de acuerdo a su codigo
        public bool eliminarProducto(int codigo)
        {
            return DELETE(RUTA_PRODUCTOS, codigo);
        }

        // método que retorna un String[] de todos los pedidos que tiene un productor
        // de acuerdo a su numero de cedula
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
                // primero se acceden a los productos que existen en una venta
                String[] listaProductosPorVenta = ventaAnalizar["productoVendido"].Values<String>().ToArray();
                // se recorre esos productos vendidos
                foreach (String producto in listaProductosPorVenta)
                {
                    // se accede al producto mediante su codigo
                    productoAnalizar = JObject.Parse(SELECT(RUTA_PRODUCTOS, (int)JObject.Parse(producto)["codigo"]));

                    if ((int)productoAnalizar["numeroCedulaProductor"] == numeroCedula) // se seleccionan solo los correspondientes al productor
                    {
                        // se crea el pedido
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

        // Metodo para verificar el inicio de sesion de un productor
        // mediante su numero de cedula y clave de acceso
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
        
        // Funcion para crear un cliente.
        // Retorna true si se logra crear y false en caso contrario
        public bool crearCliente(int numeroCedula, String primerNombre, String segundoNombre, String primerApellido, String segundoApellido,
                                String provinciaResidencia, String cantonResidencia, String distritoResidencia, String fechaNacimiento, int numeroTelefono, String nombreUsuario, String claveAcceso)
        {
            // se valida que el cliente no exista y que el nombre de usuario esté dismponible
            if (SELECT(RUTA_CLIENTES, numeroCedula) == null && FILTER(RUTA_CLIENTES, "nombreUsuario", nombreUsuario, 0).Length == 0)
            {
                // se crea el cliente
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

        // Metodo para actualizar los datos de un cliente
        public bool actualizarCliente(int numeroCedula, String primerNombre, String segundoNombre, String primerApellido, String segundoApellido,
                                String provinciaResidencia, String cantonResidencia, String distritoResidencia, String fechaNacimiento, int numeroTelefono, String nombreUsuario, String claveAcceso)
        {
            JObject clienteModificar = JObject.Parse(FILTER(RUTA_CLIENTES, "nombreUsuario", nombreUsuario, 0)[0]);
            if ((int)clienteModificar["numeroCedula"] == numeroCedula) // se accede al cliente en especifico
            {
                if (DELETE(RUTA_CLIENTES, numeroCedula)) // primero se elimina
                {
                    // luego se crea uno con la nueva informacion
                    return crearCliente(numeroCedula, primerNombre, segundoNombre, primerApellido, segundoApellido, provinciaResidencia, cantonResidencia,
                                        distritoResidencia, fechaNacimiento, numeroTelefono, nombreUsuario, claveAcceso);
                }
                return false;
            }
            return false;
        }

        // Metodo para eliminar un cliente mediante su numero de cedula
        // Retorna true si se elimina, false en caso contrario
        public bool eliminarCliente(int numeroCedula)
        {
            return DELETE(RUTA_CLIENTES, numeroCedula);
        }

        // Metodo para verificar el inicio de sesion de un cliente
        // mediante su nombre de usuario y clave de acceso
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


        // ---------------- SISTEMA DEL CARRITO DE COMPRAS ----------------------------

        // Los productos que me lleguen del frontend tienen que tener la estructura {"codigo":123, "calificacion": 3}

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

        // Metodo para finalizar/procesar una compra y retornar el codigo de la factura correspondiente
        public string finalizarCompra(int numeroCedulaComprador, String fechaCompra,
                                     int calificacionGeneral, String direccionEntrega, List<JObject> productos, int montoTotal)
        {
            int ventasPreviasCliente = FILTER(RUTA_VENTAS, "numeroCedulaComprador", null, numeroCedulaComprador).Length;
            BackendAgroTICO.Venta nuevaVenta = new BackendAgroTICO.Venta();
            UPDATE(RUTA_CLIENTES, numeroCedulaComprador, "cantidadCompras", null, ventasPreviasCliente + 1); // se aumenta la cantidad de compras de ese cliente
            nuevaVenta.numeroCedulaComprador = numeroCedulaComprador;
            nuevaVenta.codigoFactura = numeroCedulaComprador.ToString() + "-" + ventasPreviasCliente.ToString() + "-" + fechaCompra; // se crea el codigo de factura
            nuevaVenta.fechaCompra = fechaCompra;
            nuevaVenta.calificacionGeneral = calificacionGeneral;
            nuevaVenta.direccionEntrega = direccionEntrega;
            List<string> lista = new List<string>();

            // se recorren todos los productos de esa compra
            foreach (JObject productoAnalizar in productos)
            {
                lista.Add(JsonConvert.SerializeObject(productoAnalizar));
                int nuevaDisponibilidad = (int)(JObject.Parse(SELECT(RUTA_PRODUCTOS, (int)productoAnalizar["codigo"]))["disponibilidad"])
                    - (int)productoAnalizar["cantidad"]; // se calcula la nueva disponibilidad del producto

                UPDATE(RUTA_PRODUCTOS, (int)productoAnalizar["codigo"], "disponibilidad", null, nuevaDisponibilidad); // se actualiza la disponibilidad del producto

                int cantidadVendidaPrevia = (int)(JObject.Parse(SELECT(RUTA_PRODUCTOS, (int)productoAnalizar["codigo"]))["cantidadVendida"]); // se accede a la cantidad de ventas de ese producto
                UPDATE(RUTA_PRODUCTOS, (int)productoAnalizar["codigo"], "cantidadVendida", null, cantidadVendidaPrevia + (int)productoAnalizar["cantidad"]); // se actualiza la cantidad vendida del producto
            }
            nuevaVenta.productoVendido = lista.ToArray();
            nuevaVenta.montoTotal = montoTotal;
            INSERT(RUTA_VENTAS, JsonConvert.SerializeObject(nuevaVenta));
            return nuevaVenta.codigoFactura;
        }

        // --------------- FUNCIONES UTILES --------------------------------

        //Funcion para asociar el nombre de usuario de un cliente con el numero de cedula del mismo.
        // Retorna toda la informacion de ese cliente en un string formato JSON
        public string SelectGeneral(string nombreRuta, string usuario)
        {
            int atributoLlave;

            if (nombreRuta.Equals("clientes")) {
                string[] resultado = FILTER(RUTA_CLIENTES, "nombreUsuario", usuario, 0); // se accede al cliente
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
