using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.IO;

namespace AgroticoApi.BackendAgroTICO
{
    public class Reporte
    {
        // Funcion para generar un reporte pdf mediante la herramienta 
        // Crystal Reports
        public string generarComprobante(string nombre, string apellido1, string apellido2,
            string monto, string codigo)
        {
            Sinpe cr = new Sinpe();

            // Se acceden a los atributos del reporte
            TextObject codigoTx = (TextObject)cr.ReportDefinition.
                Sections["Section1"].ReportObjects["codigo"];
            TextObject nombreTx = (TextObject)cr.ReportDefinition.
                Sections["Section3"].ReportObjects["nombre"];
            TextObject apellido1Tx = (TextObject)cr.ReportDefinition.
                Sections["Section3"].ReportObjects["apellido1"];
            TextObject apellido2Tx = (TextObject)cr.ReportDefinition.
                Sections["Section3"].ReportObjects["apellido2"];
            TextObject montoTx = (TextObject)cr.ReportDefinition.
                Sections["Section4"].ReportObjects["monto"];

            // Se actualizan los atributos del reporte
            codigoTx.Text = codigo;
            nombreTx.Text = nombre;
            apellido1Tx.Text = apellido1;
            apellido2Tx.Text = apellido2;
            montoTx.Text = monto;

            // Se pasa el pdf a un string formato base64
            Stream stream = cr.ExportToStream(ExportFormatType.PortableDocFormat);
            var bytes = new Byte[(int)stream.Length];

            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(bytes, 0, (int)stream.Length);

            return Convert.ToBase64String(bytes);

        }
    }
}