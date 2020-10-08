using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.IO;

namespace AgroticoApi.BackendAgroTICO
{
    public class Reporte
    {
        public string generarComprobante(string nombre, string apellido1, string apellido2,
            string monto, string codigo)
        {
            Sinpe cr = new Sinpe();

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


            codigoTx.Text = codigo;
            nombreTx.Text = nombre;
            apellido1Tx.Text = apellido1;
            apellido2Tx.Text = apellido2;

            montoTx.Text = monto;

            Stream stream = cr.ExportToStream(ExportFormatType.PortableDocFormat);
            var bytes = new Byte[(int)stream.Length];

            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(bytes, 0, (int)stream.Length);

            return Convert.ToBase64String(bytes);

        }
    }
}