using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace DBMS
{
    class DBMS
    {
        private static String RUTA_EJECUCION = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).FullName).FullName;
        private static String RUTA_BASE_DE_DATOS = RUTA_EJECUCION + "\\BaseDeDatos";
        private static String RUTA_CLIENTES = RUTA_BASE_DE_DATOS + "//Cliente.txt";
        private static String RUTA_PRODUCTORES = RUTA_BASE_DE_DATOS + "//Productor.txt";
        private static String RUTA_VENTAS = RUTA_BASE_DE_DATOS + "//Venta.txt";
        private static String RUTA_PRODUCTOS = RUTA_BASE_DE_DATOS + "//Producto.txt";
        private static String RUTA_ADMINISTRADORES = RUTA_BASE_DE_DATOS + "//Administrador.txt";
        private static String RUTA_CATEGORIAS = RUTA_BASE_DE_DATOS + "//Categoria.txt";
        private static String RUTA_AFILIACIONES = RUTA_BASE_DE_DATOS + "//Afiliacion.txt";


        private void RESET()
        {
            if (Directory.Exists(RUTA_BASE_DE_DATOS))
            {
                if (File.Exists(RUTA_CLIENTES)){File.Delete(RUTA_CLIENTES);}
                if (File.Exists(RUTA_PRODUCTORES)){File.Delete(RUTA_PRODUCTORES);}
                if (File.Exists(RUTA_VENTAS)){File.Delete(RUTA_VENTAS);}
                if (File.Exists(RUTA_PRODUCTOS)){File.Delete(RUTA_PRODUCTOS);}    
                if (File.Exists(RUTA_CATEGORIAS)){File.Delete(RUTA_CATEGORIAS);}
                if (File.Exists(RUTA_AFILIACIONES)){File.Delete(RUTA_AFILIACIONES);}
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
                else if (rutaDelConjuntoEntidad == RUTA_PRODUCTOS || rutaDelConjuntoEntidad == RUTA_ADMINISTRADORES)
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
                    else{Console.WriteLine("Se ha eliminado la entidad solicitada " + conjuntoEntidadActual[i]);}
                }
                else if (rutaDelConjuntoEntidad == RUTA_PRODUCTOS || rutaDelConjuntoEntidad == RUTA_ADMINISTRADORES)
                {
                    if (!((int)entidadAnalizar["codigo"] == atributoLlave))
                    {
                        conjuntoEntidadNuevo = conjuntoEntidadNuevo.Concat(new String[] { conjuntoEntidadActual[i] }).ToArray();
                    }
                    else{Console.WriteLine("Se ha eliminado la entidad solicitada " + conjuntoEntidadActual[i]);}
                }
                else if (rutaDelConjuntoEntidad == RUTA_VENTAS)
                {
                    if (!((int)entidadAnalizar["codigoFactura"] == atributoLlave))
                    {
                        conjuntoEntidadNuevo = conjuntoEntidadNuevo.Concat(new String[] { conjuntoEntidadActual[i] }).ToArray();
                    }
                    else{Console.WriteLine("Se ha eliminado la entidad solicitada " + conjuntoEntidadActual[i]);}
                }
                else if (rutaDelConjuntoEntidad == RUTA_AFILIACIONES)
                {
                    if (!((int)entidadAnalizar["codigoSolicitud"] == atributoLlave))
                    {
                        conjuntoEntidadNuevo = conjuntoEntidadNuevo.Concat(new String[] { conjuntoEntidadActual[i] }).ToArray();
                    }
                    else{Console.WriteLine("Se ha eliminado la entidad solicitada " + conjuntoEntidadActual[i]);}
                }
                else
                {
                    if (!((int)entidadAnalizar["identificador"] == atributoLlave))
                    {
                        conjuntoEntidadNuevo = conjuntoEntidadNuevo.Concat(new String[] { conjuntoEntidadActual[i] }).ToArray();
                    }
                    else{Console.WriteLine("Se ha eliminado la entidad solicitada " + conjuntoEntidadActual[i]);}
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
        private String[] FILTER(String rutaDelConjuntoEntidad, String atributoBuscar, String valorRequeridoTexto, int valorRequeridoNumerico)
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


        private String[] encontrarProductoPorProductor(int numeroCedulaProductor)
        {
            return FILTER(RUTA_PRODUCTOS, "numeroCedulaProductor", null, numeroCedulaProductor);
        }
        private String[] encontrarProductorPorProvincia(String provincia)
        {
            return FILTER(RUTA_PRODUCTORES, "provincia", provincia, 0);
        }
        private String[] encontrarProductorPorCanton(String canton)
        {
            return FILTER(RUTA_PRODUCTORES, "canton", canton, 0);
        }
        private String[] encontrarProductorPorDistrito(String distrito)
        {
            return FILTER(RUTA_PRODUCTORES, "distrito", distrito, 0);
        }
        private String[] encontrarProductoPorProvincia(String provincia)
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
        private String[] encontrarProductoPorCanton(String canton)
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
        private String[] encontrarProductoPorDistrito(String distrito)
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
        private bool crearProductor(int numeroCedula, String primerNombre, String segundoNombre, String primerApellido, String segundoApellido, String provinciaResidencia, 
                                    String cantonResidencia, String distritoResidencia, int numeroTelefono, int numeroSINPE, int anioNacimiento, int mesNacimiento, 
                                    int diaNacimiento, String[] lugarEntrega, String claveAcceso)
        {
            if (SELECT(RUTA_PRODUCTORES, numeroCedula) == null)
            {
                BackendAgroTICO.Productor nuevoProductor = new BackendAgroTICO.Productor();
                nuevoProductor.lugarEntrega = lugarEntrega;
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
                nuevoProductor.anioNacimiento = anioNacimiento;
                nuevoProductor.mesNacimiento = mesNacimiento;
                nuevoProductor.diaNacimiento = diaNacimiento;
                nuevoProductor.lugarEntrega = lugarEntrega;
                nuevoProductor.claveAcceso = claveAcceso;
                INSERT(RUTA_PRODUCTORES, JsonConvert.SerializeObject(nuevoProductor));
                return true;
            }
            return false;
        }
        private bool actualizarProductor(int numeroCedula, String primerNombre, String segundoNombre, String primerApellido, String segundoApellido, String provinciaResidencia,
                                        String cantonResidencia, String distritoResidencia, int numeroTelefono, int numeroSINPE, int anioNacimiento, int mesNacimiento,
                                        int diaNacimiento, String[] lugarEntrega, String claveAcceso)
        {
            if(DELETE(RUTA_PRODUCTORES, numeroCedula))
            {
                return crearProductor(numeroCedula, primerNombre, segundoNombre, primerApellido, segundoApellido, provinciaResidencia, cantonResidencia, distritoResidencia,
                            numeroTelefono, numeroSINPE, anioNacimiento, mesNacimiento, diaNacimiento, lugarEntrega, claveAcceso);
            }
            return false;
        }
        private bool eliminarProductor(int numeroCedulaProductor)
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
        private bool actualizarSolicitudAfiliacion(int codigoSolicitud, bool estado, int anioRespuesta, int mesRespuesta, int diaRespuesta, String motivoDenegacion)
        {
            String[] solicitudesSinRespuesta = FILTER(RUTA_AFILIACIONES, "estado", "Sin respuesta", 0);
            JObject posibleProductor;
            JObject productorAceptado = null;
            foreach(String solicitud in solicitudesSinRespuesta)
            {
                posibleProductor = JObject.Parse(solicitud);
                if((int)posibleProductor["numeroCedula"] == codigoSolicitud)
                {
                    productorAceptado = posibleProductor;
                }
            }
            if (productorAceptado == null)
            {
                return false;
            }
            if (estado == true)
            {
                UPDATE(RUTA_AFILIACIONES, codigoSolicitud, "estado", "Aceptado", 0);
                UPDATE(RUTA_AFILIACIONES, codigoSolicitud, "motivoDenegacion", "Ha sigo aceptado en AgroTICO", 0);

                crearProductor(codigoSolicitud, (String)productorAceptado["primerNombre"], (String)productorAceptado["segundoNombre"],
                       (String)productorAceptado["primerApellido"], (String)productorAceptado["segundoApellido"],
                       (String)productorAceptado["provinciaResidencia"], (String)productorAceptado["cantonResidencia"],
                       (String)productorAceptado["distritoResidencia"], (int)productorAceptado["numeroTelefono"],
                       (int)productorAceptado["numeroSINPE"], (int)productorAceptado["anioNacimiento"],
                       (int)productorAceptado["mesNacimiento"], (int)productorAceptado["diaNacimiento"],
                       productorAceptado["lugarEntrega"].Values<String>().ToArray());
            }
            else
            {
                UPDATE(RUTA_AFILIACIONES, codigoSolicitud, "estado", "Denegado", 0);
                UPDATE(RUTA_AFILIACIONES, codigoSolicitud, "motivoDenegacion", motivoDenegacion, 0);
            }
            UPDATE(RUTA_AFILIACIONES, codigoSolicitud, "anioRespuesta", null, anioRespuesta);
            UPDATE(RUTA_AFILIACIONES, codigoSolicitud, "mesRespuesta", null, mesRespuesta);
            UPDATE(RUTA_AFILIACIONES, codigoSolicitud, "diaRespuesta", null, diaRespuesta);
            return true;
        }
        private bool crearCategoria(int identificador, String nombre)
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
        private bool actualizarCategoria(int identificador, String nombre)
        {
            if (SELECT(RUTA_CATEGORIAS, identificador) != null)
            {
                UPDATE(RUTA_CATEGORIAS, identificador, "nombre", nombre, 0);
                return true;
            }
            return false;
        }
        private bool eliminarCategoria(int identificador)
        {
            if (SELECT(RUTA_CATEGORIAS, identificador)!=null)
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
        private String[] encontrarSolicitudesSinResponder()
        {
            return FILTER(RUTA_AFILIACIONES, "Estado", "Sin respuesta", 0);
        }
        private String[] encontrarPrimerosDiezElementos(String[] listaElementos)
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
        private String[] encontrarProductosMasVendidos()
        {
            return encontrarPrimerosDiezElementos(SORT(RUTA_PRODUCTOS, "cantidadVendida"));          
        }
        private String[] encontrarProductosMasVendidosPorProductor(int numeroCedulaProductor)
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
        private String[] encontrarProductosMasGanancias()
        {
            String[] productosSegunGanancias = File.ReadAllLines(RUTA_PRODUCTOS);
            String entidadTemporal;
            for (int i = 0; i < productosSegunGanancias.Length; i++)
            {
                for (int j = 0; j < productosSegunGanancias.Length - 1; j++)
                {
                    JObject entidad1 = JObject.Parse(productosSegunGanancias[j]);
                    JObject entidad2 = JObject.Parse(productosSegunGanancias[j + 1]);
                    if (((int)entidad1["cantidadVendida"]* (int)entidad1["precio"]) < ((int)entidad2["cantidadVendida"] * (int)entidad2["precio"]))
                    {
                        entidadTemporal = productosSegunGanancias[j + 1];
                        productosSegunGanancias[j + 1] = productosSegunGanancias[j];
                        productosSegunGanancias[j] = entidadTemporal;
                    }
                }
            }
            return encontrarPrimerosDiezElementos(productosSegunGanancias);
        }
        private String[] encontrarClientesMasCompras()
        {
            String[] clientesSegunCompras = SORT(RUTA_CLIENTES, "cantidadCompras");
            return encontrarPrimerosDiezElementos(clientesSegunCompras);
        }


        /*-------------------------------------------------------------VISTA DE PRODUCTOR-----------------------------------------------------------------*/
        private bool crearSolicitudAfiliacion(int numeroCedula, String primerNombre, String segundoNombre, String primerApellido, String segundoApellido, String provinciaResidencia,
                                            String cantonResidencia, String distritoResidencia, int numeroTelefono, int numeroSINPE, int anioNacimiento, int mesNacimiento,
                                            int diaNacimiento, String[] lugarEntrega, String claveAcceso, int anioSolicitud, int mesSolicitud, int diaSolicitud)
        {
            String[] solicitudesRealizadas = FILTER(RUTA_AFILIACIONES, "codigoSolicitud", null, numeroCedula);
            String[] solicitudesAceptadas = FILTER(RUTA_PRODUCTORES, "numeroCedula", null, numeroCedula);
            if (solicitudesAceptadas.Length != 0)
            {
                return false;
            }
            JObject solicitudAnalizar;
            for(int i=0; i<solicitudesRealizadas.Length; i++)
            {
                solicitudAnalizar = JObject.Parse(solicitudesRealizadas[i]);
                if((String)solicitudAnalizar["estado"] == "Sin respuesta")
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
            nuevaAfiliacion.anioNacimiento = anioNacimiento;
            nuevaAfiliacion.mesNacimiento = mesNacimiento;
            nuevaAfiliacion.diaNacimiento = diaNacimiento;
            nuevaAfiliacion.lugarEntrega = lugarEntrega;
            nuevaAfiliacion.claveAcceso = claveAcceso;
            nuevaAfiliacion.anioSolicitud = anioSolicitud;
            nuevaAfiliacion.mesSolicitud = mesSolicitud;
            nuevaAfiliacion.diaSolicitud = diaSolicitud;
            nuevaAfiliacion.estado = "Sin respuesta";
            nuevaAfiliacion.motivoDenegacion = "Sin respuesta";
            nuevaAfiliacion.anioRespuesta = 0;
            nuevaAfiliacion.mesRespuesta = 0;
            nuevaAfiliacion.diaRespuesta = 0;
            INSERT(RUTA_AFILIACIONES, JsonConvert.SerializeObject(nuevaAfiliacion));
            return true; 
        }
        private String encontrarSolicitudAfiliacion(int numeroCedula)
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
            if(solicitudPendiente == null)
            {
                return null;
            }
            return solicitudPendiente.ToString();
        }

        private bool crearProducto(int codigo, int numeroCedulaProductor, String nombre, String modoVenta, String disponibilidad, int precio,
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


        private bool actualizarProducto(int codigo, String nombre, String modoVenta, String disponibilidad, int precio,
                                        int identificadorCategoria, String foto)
        {
            if (SELECT(RUTA_PRODUCTOS, codigo) != null)
            {
                if(SELECT(RUTA_CATEGORIAS,codigo) != null)
                {
                    UPDATE(RUTA_PRODUCTOS, codigo, "nombre", nombre, 0);
                    UPDATE(RUTA_PRODUCTOS, codigo, "modoVenta", modoVenta, 0);
                    UPDATE(RUTA_PRODUCTOS, codigo, "disponibilidad", disponibilidad, 0);
                    UPDATE(RUTA_PRODUCTOS, codigo, "precio", null, precio);
                    UPDATE(RUTA_PRODUCTOS, codigo, "identificadorCategoria", null, identificadorCategoria);
                    UPDATE(RUTA_PRODUCTOS, codigo, "foto", foto, 0);
                    return true;
                }
                return false;
            }
            return false;
        }
        private bool eliminarProducto(int codigo)
        {
            return DELETE(RUTA_PRODUCTOS, codigo);
        }




        private String[] encontrarPedidos(int numeroCedula)
        {
            String[] productosEntregar = { };
            String[] listaVentas = READ(RUTA_VENTAS);

            JObject ventaAnalizar;
            JObject productoAnalizar;

            JObject productoVendido;

            foreach(String venta in listaVentas)
            {
                ventaAnalizar = JObject.Parse(venta);
                String[] listaProductosPorVenta = ventaAnalizar["productoVendido"].Values<String>().ToArray();
                
                foreach(String producto in listaProductosPorVenta)
                {              
                    productoAnalizar = JObject.Parse(SELECT(RUTA_PRODUCTOS, (int)JObject.Parse(producto)["codigo"]));
                    
                    if((int)productoAnalizar["numeroCedulaProductor"] == numeroCedula)
                    {
                        productoVendido = new JObject();
                        productoVendido["codigo"] = (int)productoAnalizar["codigo"];
                        productoVendido["nombre"] = (String)productoAnalizar["nombre"];
                        productoVendido["cantidad"] = (int)JObject.Parse(producto)["cantidad"];
                        productoVendido["precioUnitario"] = (int)JObject.Parse(producto)["precio"];
                        productoVendido["montoTotal"] = (int)JObject.Parse(producto)["cantidad"] * (int)JObject.Parse(producto)["precio"];
                        productoVendido["numeroCedulaCliente"] = (String)ventaAnalizar["numeroCedulaComprador"];
                        productoVendido["direccionEntrega"] = (String)ventaAnalizar["direccionEntrega"];

                        productosEntregar = productosEntregar.Concat(new String[] {JsonConvert.ToString(productoVendido)}).ToArray();
                    }
                    

                }
            }
            return productosEntregar;
        }


        private bool autorizarLoginProductor(int numeroCedula, String claveAcceso)
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

        private bool crearCliente(int numeroCedula, String primerNombre, String segundoNombre, String primerApellido, String segundoApellido,
                                String provinciaResidencia, String cantonResidencia, String distritoResidencia, int anioNacimiento,
                                int mesNacimiento, int diaNacimiento, int numeroTelefono, String nombreUsuario, String claveAcceso)
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
                nuevoCliente["anioNacimiento"] = anioNacimiento;
                nuevoCliente["mesNacimiento"] = mesNacimiento;
                nuevoCliente["diaNacimiento"] = diaNacimiento;
                nuevoCliente["numeroTelefono"] = numeroTelefono;
                nuevoCliente["nombreUsuario"] = nombreUsuario;
                nuevoCliente["claveAcceso"] = claveAcceso;
                nuevoCliente["cantidadCompras"] = 0;

                INSERT(RUTA_CLIENTES, JsonConvert.SerializeObject(nuevoCliente));
                return true;
            }

            return false;
        }

        private bool actualizarCliente(int numeroCedula, String primerNombre, String segundoNombre, String primerApellido, String segundoApellido,
                                String provinciaResidencia, String cantonResidencia, String distritoResidencia, int anioNacimiento,
                                int mesNacimiento, int diaNacimiento, int numeroTelefono, String nombreUsuario, String claveAcceso)
        {
            JObject clienteModificar = JObject.Parse(FILTER(RUTA_CLIENTES, "nombreUsuario", nombreUsuario, 0)[0]);
            if ((int)clienteModificar["numeroCedula"] == numeroCedula)
            {
                if (DELETE(RUTA_CLIENTES, numeroCedula))
                {
                    return crearCliente(numeroCedula, primerNombre, segundoNombre, primerApellido, segundoApellido, provinciaResidencia, cantonResidencia,
                                        distritoResidencia, anioNacimiento, mesNacimiento, diaNacimiento, numeroTelefono, nombreUsuario, claveAcceso);
                }
                return false;
            }
            return false;
        }

        private bool eliminarCliente(int numeroCedula)
        {
            return DELETE(RUTA_CLIENTES, numeroCedula);
        }




        private bool autorizarLoginCliente(String nombreUsuario, String claveAcceso)
        {
            String[] usuariosPosibles = FILTER(RUTA_CLIENTES, "nombreUsuario", nombreUsuario, 0);
            if (usuariosPosibles.Length == 1)
            {
                return ((String)JObject.Parse(usuariosPosibles[0])["claveAcceso"] == claveAcceso);
            }
            return false;      
        }


        private bool crearVenta(int numeroCedulaComprador, int anioCompra, int mesCompra, int diaCompra, int calificacionGeneral, String direccionEntrega,
                                String[] productoVendido)
        {
            int ventasPreviasCliente = FILTER(RUTA_VENTAS, "numeroCedulaComprador", null, numeroCedulaComprador).Length;

            BackendAgroTICO.Venta nuevaVenta = new BackendAgroTICO.Venta();

            UPDATE(RUTA_CLIENTES, numeroCedulaComprador, "cantidadCompras", null, (int)JObject.Parse(SELECT(RUTA_CLIENTES, numeroCedulaComprador))["cantidadCompras"] + 1);  

            nuevaVenta.numeroCedulaComprador = numeroCedulaComprador;
            nuevaVenta.codigoFactura = numeroCedulaComprador.ToString() + "-" + ventasPreviasCliente.ToString() + "-" + diaCompra.ToString() + mesCompra.ToString() + anioCompra.ToString();
            nuevaVenta.anioCompra = anioCompra;
            nuevaVenta.mesCompra = mesCompra;
            nuevaVenta.diaCompra = diaCompra;
            nuevaVenta.calificacionGeneral = calificacionGeneral;
            nuevaVenta.direccionEntrega = direccionEntrega;
            nuevaVenta.productoVendido = productoVendido;

            int montoTotal = 0;

            JObject productoAnalizar;
            foreach(String producto in productoVendido)
            {
                
                productoAnalizar = JObject.Parse(producto);
                montoTotal = montoTotal + (int)productoAnalizar["cantidad"] *(int)productoAnalizar["precio"];

                int cantidadVendidaPrevia = (int)(JObject.Parse(SELECT(RUTA_PRODUCTOS, (int)productoAnalizar["codigo"]))["cantidadVendida"]);

                UPDATE(RUTA_PRODUCTOS, (int)productoAnalizar["codigo"], "cantidadVendida", null, cantidadVendidaPrevia + (int)productoAnalizar["cantidad"]);
            }
            nuevaVenta.montoTotal = montoTotal;

            INSERT(RUTA_VENTAS, JsonConvert.SerializeObject(nuevaVenta));

            return true;
        }




        static void Main(string[] args)
        {
            DBMS dbms = new DBMS();




            dbms.RESET();

        }
    }
}
