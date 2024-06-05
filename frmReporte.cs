using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using SDD2.models;

namespace SDD2
{
    public partial class frmReporte : Form
    {
        public frmReporte()
        {
            InitializeComponent();
        }

        private void frmReporte_Load(object sender, EventArgs e)
        {
            using (var dbContext = new DataBase())
            {
                string Equipo = Environment.MachineName;
               // this.lblEquipo.Text = nombreEquipo;
                DateTime FechaRegistro = DateTime.Now;
                //this.lblFecha.Text = FechaRegistro.ToString();


                var query = from doc in dbContext.Documentos
                            join tipoDoc in dbContext.TiposDocumentos on doc.IdTipoDocumento equals tipoDoc.Id
                            select new
                            {
                                doc.Titulo,
                                doc.Observaciones,
                                doc.IdTipoDocumento,
                                doc.IdAnoEscolar,
                                TipoDocumento = tipoDoc.Nombre,
                            };
                
                // Especificar la ruta absoluta al archivo Report1.rdlc
                string reportPath = "C:\\Users\\Ryzen 5\\Music\\profesor2\\SistemaDocumentosDigitalesEscolar\\Report1.rdlc";

                /* // Verificación de la ruta en tiempo de ejecución
                 if (!System.IO.File.Exists(reportPath))
                 {
                     MessageBox.Show($"El archivo {reportPath} no se encuentra.");
                     return;
                 }*/

                this.reportViewer1.LocalReport.ReportPath = reportPath;
                this.reportViewer1.LocalReport.DataSources.Clear();
                var reportDataSource = new ReportDataSource("MyDataSet", query.ToList());
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                // Crear y configurar los parámetros
                var equipoParam = new ReportParameter("Equipo", Equipo);
                var fechaParam = new ReportParameter("FechaRegistro", FechaRegistro.ToString());

                // Agregar los parámetros al reporte
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { equipoParam, fechaParam });

                this.reportViewer1.RefreshReport();
            }
        }
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
           

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            
            
        }
    }
}
    

