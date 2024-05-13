using PdfiumViewer;
using SDD2.dtos;
using SDD2.models;
using SDD2.services;
using SDD2.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDD2
{
    public partial class frmBusquedaDocumento : Form
    {
        public frmBusquedaDocumento()
        {
            InitializeComponent();
        }

        private void frmBusquedaDocumento_Load(object sender, EventArgs e)
        {
            DataBase database = new DataBase();

            var tiposdocumentos = database.TiposDocumentos.ToList();
            tiposdocumentos.Add(new TipoDocumento { Id = 0, Nombre = "TODOS" });
            cboTiposDocumentos.Items.Clear();
            cboTiposDocumentos.DataSource = tiposdocumentos;
            cboTiposDocumentos.DisplayMember = "Nombre";
            cboTiposDocumentos.ValueMember = "Id";
            cboTiposDocumentos.SelectedValue = 0;
            
            var anos1 = database.AnosEscolar.ToList();
            var anos2 = database.AnosEscolar.ToList();
            cboAnoInicial.Items.Clear();
            cboAnoInicial.DataSource = anos1;
            cboAnoInicial.DisplayMember = "Ano";
            cboAnoInicial.ValueMember = "Id";

            cboAnoFinal.Items.Clear();
            cboAnoFinal.DataSource = anos2;
            cboAnoFinal.DisplayMember = "Ano";
            cboAnoFinal.ValueMember = "Id";

            var niveles = database.Niveles.ToList();
            cboNiveles.Items.Clear();
            cboNiveles.DataSource = niveles;
            cboNiveles.DisplayMember = "Nombre";
            cboNiveles.ValueMember = "Id";
            cboNiveles.SelectedValue = 3;
            
            var grados = database.Grados.ToList();
            grados.Add(new Grado { Id = 0, Nombre = "TODOS" });
            cboGrados.Items.Clear();
            cboGrados.DataSource = grados;
            cboGrados.DisplayMember = "Nombre";
            cboGrados.ValueMember = "Id";
            cboGrados.SelectedValue = 0;

            var secciones = database.Secciones.ToList();
            secciones.Add(new Seccion{ Id = 0, Nombre = "TODOS" });
            cboSecciones.Items.Clear();
            cboSecciones.DataSource = secciones;
            cboSecciones.DisplayMember = "Nombre";
            cboSecciones.ValueMember = "Id";
            cboSecciones.SelectedValue = 0;

            var turnos = database.Turnos.ToList();
            turnos.Add(new Turno { Id = 0, Nombre = "TODOS" });
            cboTurnos.Items.Clear();
            cboTurnos.DataSource = turnos;
            cboTurnos.DisplayMember = "Nombre";
            cboTurnos.ValueMember = "Id";
            cboTurnos.SelectedValue = 0;
        }
     

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            DocumentoService documentoService = new DocumentoService();

            int anoInicial = ((AnoEscolar)cboAnoInicial.SelectedItem).Ano;
            int anoFinal = ((AnoEscolar)cboAnoFinal.SelectedItem).Ano; 
            int idtipo = (int)cboTiposDocumentos.SelectedValue;
            string titulo = txtTitulo.Text;
            string obs = txtObservacion.Text;
            int idnivel = (int)cboNiveles.SelectedValue;
            int idgrado = (int)cboGrados.SelectedValue;
            int idseccion = (int)cboSecciones.SelectedValue;
            int idturno = (int)cboTurnos.SelectedValue;

            List<ResultadoDocumentoDTO> documentos;
            documentos = documentoService.search(anoInicial, anoFinal, idtipo,titulo,
                obs,idnivel,idgrado,idseccion, idturno);

            dgvDocumentos.Columns.Clear();
            dgvDocumentos.DataSource = documentos;

            dgvDocumentos.Columns["RutaArchivo"].Visible = false;
            dgvDocumentos.Columns["Id"].Visible = false;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtener la fila actual
                DataGridViewRow filaActual = dgvDocumentos.Rows[e.RowIndex];
                string nombre = filaActual.Cells["RutaArchivo"].Value.ToString();
                string id = filaActual.Cells["Id"].Value.ToString();
                string pathfolder = Path.Combine("docs", id);
                string ruta = Utils.getPath(pathfolder, nombre);
                pdfViewer2.Document?.Dispose();
                pdfViewer2.Document = OpenDocument(ruta);
            }
        }

      
        private PdfDocument OpenDocument(string fileName)
        {
            try
            {
                return PdfDocument.Load(this, fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void btnRotar_Click(object sender, EventArgs e)
        {
            pdfViewer2.Renderer.RotateRight();
        }
       
    }
}
