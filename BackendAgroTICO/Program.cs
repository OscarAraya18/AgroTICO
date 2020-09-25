using System;
using System.IO;
using Newtonsoft.Json;

using System.Linq;

using Newtonsoft.Json.Linq;


namespace DBMS
{

    class DBMS
    {
        //Rutas de las diferentes tablas dentro de la base de datos. Se almacenan como constantes para ahorrar tiempo.
        private static String RUTA_EJECUCION = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).FullName).FullName;
        private static String RUTA_BASE_DE_DATOS = RUTA_EJECUCION + "\\BaseDeDatos";

        private static String RUTA_CLIENTES = RUTA_BASE_DE_DATOS + "//Cliente.txt";
        private static String RUTA_PRODUCTORES = RUTA_BASE_DE_DATOS + "//Productor.txt";
        private static String RUTA_VENTAS = RUTA_BASE_DE_DATOS + "//Venta.txt";
        private static String RUTA_PRODUCTOS = RUTA_BASE_DE_DATOS + "//Producto.txt";
        private static String RUTA_ADMINISTRADORES = RUTA_BASE_DE_DATOS + "//Administrador.txt";
        private static String RUTA_CATEGORIAS = RUTA_BASE_DE_DATOS + "//Categoria.txt";
        private static String RUTA_AFILIACIONES = RUTA_BASE_DE_DATOS + "//Afiliacion.txt";


        private void reiniciarBaseDeDatos()
        {
            if (Directory.Exists(RUTA_BASE_DE_DATOS))
            {
                if (File.Exists(RUTA_CLIENTES))
                {
                    File.Delete(RUTA_CLIENTES);
                }
                if (File.Exists(RUTA_PRODUCTORES))
                {
                    File.Delete(RUTA_PRODUCTORES);
                }
                if (File.Exists(RUTA_VENTAS))
                {
                    File.Delete(RUTA_VENTAS);
                }
                if (File.Exists(RUTA_PRODUCTOS))
                {
                    File.Delete(RUTA_PRODUCTOS);
                }
                if (File.Exists(RUTA_ADMINISTRADORES))
                {
                    File.Delete(RUTA_ADMINISTRADORES);
                }
                if (File.Exists(RUTA_CATEGORIAS))
                {
                    File.Delete(RUTA_CATEGORIAS);
                }
                if (File.Exists(RUTA_AFILIACIONES))
                {
                    File.Delete(RUTA_AFILIACIONES);
                }

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
            return "";
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
        private void DELETE(String rutaDelConjuntoEntidad, int atributoLlave)
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
                    else
                    {
                        Console.WriteLine("Se ha eliminado la entidad solicitada " + conjuntoEntidadActual[i]);

                    }
                }
                else if (rutaDelConjuntoEntidad == RUTA_PRODUCTOS || rutaDelConjuntoEntidad == RUTA_ADMINISTRADORES)
                {
                    if (!((int)entidadAnalizar["codigo"] == atributoLlave))
                    {
                        conjuntoEntidadNuevo = conjuntoEntidadNuevo.Concat(new String[] { conjuntoEntidadActual[i] }).ToArray();
                    }
                    else
                    {
                        Console.WriteLine("Se ha eliminado la entidad solicitada " + conjuntoEntidadActual[i]);

                    }
                }
                else if (rutaDelConjuntoEntidad == RUTA_VENTAS)
                {
                    if (!((int)entidadAnalizar["codigoFactura"] == atributoLlave))
                    {
                        conjuntoEntidadNuevo = conjuntoEntidadNuevo.Concat(new String[] { conjuntoEntidadActual[i] }).ToArray();
                    }
                    else
                    {
                        Console.WriteLine("Se ha eliminado la entidad solicitada " + conjuntoEntidadActual[i]);

                    }
                }
                else if (rutaDelConjuntoEntidad == RUTA_AFILIACIONES)
                {
                    if (!((int)entidadAnalizar["codigoSolicitud"] == atributoLlave))
                    {
                        conjuntoEntidadNuevo = conjuntoEntidadNuevo.Concat(new String[] { conjuntoEntidadActual[i] }).ToArray();
                    }
                    else
                    {
                        Console.WriteLine("Se ha eliminado la entidad solicitada " + conjuntoEntidadActual[i]);

                    }
                }
                else
                {
                    if (!((int)entidadAnalizar["identificador"] == atributoLlave))
                    {
                        conjuntoEntidadNuevo = conjuntoEntidadNuevo.Concat(new String[] { conjuntoEntidadActual[i] }).ToArray();
                    }
                    else
                    {
                        Console.WriteLine("Se ha eliminado la entidad solicitada " + conjuntoEntidadActual[i]);

                    }
                }
            }

            if (conjuntoEntidadActual.Length == conjuntoEntidadNuevo.Length)
            {
                Console.WriteLine("No se ha encontrado a la entidad solicitada dentro del conjunto de entidad " + rutaDelConjuntoEntidad);
            }
            else
            {
                WRITE(rutaDelConjuntoEntidad, conjuntoEntidadNuevo);
            }

        }
        private void UPDATE(String rutaDelConjuntoEntidad, int atributoLlave, String atributoModificar, String nuevoValorTexto, int nuevoValorNumerico)
        {
            Console.WriteLine("El DBMS ha iniciado un proceso de UPDATE en el conjunto de entidad " + rutaDelConjuntoEntidad);
            String entidadModificar = SELECT(rutaDelConjuntoEntidad, atributoLlave);
            if (entidadModificar != "")
            {
                DELETE(rutaDelConjuntoEntidad, atributoLlave);
                JObject entidadModificada = JObject.Parse(entidadModificar);

                if (nuevoValorTexto != "")
                {
                    entidadModificada[atributoModificar] = nuevoValorTexto;
                }
                else
                {
                    entidadModificada[atributoModificar] = nuevoValorNumerico;
                }
                INSERT(rutaDelConjuntoEntidad, JsonConvert.SerializeObject(entidadModificada));
                Console.WriteLine("Se ha actualizado la entidad solicitada de " + entidadModificar + " a " + JsonConvert.SerializeObject(entidadModificada));
            }
            else
            {
                Console.WriteLine("No se ha encontrado a la entidad solicitada dentro del conjunto de entidad " + rutaDelConjuntoEntidad);
            }

        }



        private void crearNuevoCliente()
        {
            JObject nuevoCliente = new JObject();
            nuevoCliente["numeroCedula"] = 19897969;
            nuevoCliente["nombreUsuario"] = "OscarArayaX";
            nuevoCliente["primerNombre"] = "Oscar";
            nuevoCliente["segundoNombre"] = "Fernando";
            nuevoCliente["primerApellido"] = "Araya";
            nuevoCliente["segundoApellido"] = "Garbanzo";
            nuevoCliente["provinciaResidencia"] = "Limon";
            nuevoCliente["cantonResidencia"] = "Parrita";
            nuevoCliente["distritoResidencia"] = "San Juan";
            nuevoCliente["numeroTelefono"] = 89635241;
            nuevoCliente["contrasena"] = "test";
            nuevoCliente["anioNacimiento"] = 1998;
            nuevoCliente["mesNacimiento"] = 1;
            nuevoCliente["diaNacimiento"] = 3;

            INSERT(RUTA_CLIENTES, JsonConvert.SerializeObject(nuevoCliente));
        }





        static void Main(string[] args)
        {
            DBMS dbms = new DBMS();



            dbms.UPDATE(RUTA_CLIENTES, 117770329, "numeroTelefono", "", 87430934);
            //dbms.DELETE(RUTA_CLIENTES, 117770329);
            //String entidad = dbms.SELECT(RUTA_CLIENTES, 117770329);


            //dbms.crearNuevoCliente();



        }
    }
}
