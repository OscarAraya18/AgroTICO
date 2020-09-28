using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAgroTICO
{
    class Venta
    {
        public int numeroCedulaComprador;
        public String codigoFactura;
        public int anioCompra;
        public int mesCompra;
        public int diaCompra;
        public int calificacionGeneral;
        public String direccionEntrega;

        public int montoTotal;

        public String[] productoVendido;


        public Venta()
        {
        }
    }
}
