using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace AgroticoApi.BackendAgroTICO
{
    public class Reporte
    {
        public string generarComprobante(string nombre, string apellido, string monto)
        {
            Sinpe cr = new Sinpe();
            TextObject nombreTx = (TextObject)cr.ReportDefinition.
                Sections["Section3"].ReportObjects["nombre"];
            TextObject apellidoTx = (TextObject)cr.ReportDefinition.
                Sections["Section3"].ReportObjects["apellido"];
            TextObject montoTx = (TextObject)cr.ReportDefinition.
                Sections["Section4"].ReportObjects["monto"];


            nombreTx.Text = nombre;

            apellidoTx.Text = apellido;

            montoTx.Text = monto;

            Stream stream = cr.ExportToStream(ExportFormatType.PortableDocFormat);
            var bytes = new Byte[(int)stream.Length];

            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(bytes, 0, (int)stream.Length);

            return Convert.ToBase64String(bytes);

        }
    }
}