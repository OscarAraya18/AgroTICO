using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAgroTICO
{
    class Afiliacion : Productor
    {
        public int codigoSolicitud;

        public String motivoDenegacion;
        public String estado;
        public String fechaSolicitud;
        public String fechaRespuesta;

        public Afiliacion()
        {
        }
    }
}
