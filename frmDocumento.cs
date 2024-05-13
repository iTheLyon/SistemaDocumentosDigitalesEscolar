using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using PdfiumViewer;
using System.Data.Entity;
using SDD2.models;
using SDD2.services;

namespace SDD2
{
    public partial class frmDocumento : Form
    {
        private string filename;
        public frmDocumento()
        {
            InitializeComponent();
        }

        private void frmDocumento_Load(object sender, EventArgs e)
        {
            DataBase database = new DataBase();

            var tiposdocumentos = database.TiposDocumentos.ToList();
            cboTiposDocumentos.Items.Clear();
            cboTiposDocumentos.DataSource = tiposdocumentos;
            cboTiposDocumentos.DisplayMember = "Nombre";
            cboTiposDocumentos.ValueMember = "Id";

            var anos = database.AnosEscolar.ToList();
            cboAnos.Items.Clear();
            cboAnos.DataSource = anos;
            cboAnos.DisplayMember = "Ano";
            cboAnos.ValueMember = "Id";

            var niveles = database.Niveles.ToList();
            cboNiveles.Items.Clear();
            cboNiveles.DataSource = niveles;
            cboNiveles.DisplayMember = "Nombre";
            cboNiveles.ValueMember = "Id";
            cboNiveles.SelectedValue = 3;

            var grados = database.Grados.ToList();
            cboGrados.Items.Clear();
            cboGrados.DataSource = grados;
            cboGrados.DisplayMember = "Nombre";
            cboGrados.ValueMember = "Id";

            var secciones = database.Secciones.ToList();
            cboSecciones.Items.Clear();
            cboSecciones.DataSource = secciones;
            cboSecciones.DisplayMember = "Nombre";
            cboSecciones.ValueMember = "Id";


            var turnos = database.Turnos.ToList();
            cboTurnos.Items.Clear();
            cboTurnos.DataSource = turnos;
            cboTurnos.DisplayMember = "Nombre";
            cboTurnos.ValueMember = "Id";

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

     
        private void btnAdjuntar_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*";
            dialog.RestoreDirectory = true;
            dialog.Title = "Abrir Archivo PDF";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pdfViewer2.Document?.Dispose();
                pdfViewer2.Document = OpenDocument(dialog.FileName);
                lblNombreArchivo.Text = dialog.SafeFileName;
                this.filename = dialog.FileName;
            }
        }

        private void btnRotar_Click_1(object sender, EventArgs e)
        {
            if(pdfViewer2.Document !=null)
                pdfViewer2.Renderer.RotateRight();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            DocumentoService documento = new DocumentoService(new Documento
            {
                IdTipoDocumento = (int)cboTiposDocumentos.SelectedValue,
                Titulo = txtTitulo.Text,
                IdAnoEscolar = (int)cboAnos.SelectedValue,
                IdNivel = (int)cboNiveles.SelectedValue,
                IdGrado = (int)cboGrados.SelectedValue,
                IdSeccion = (int)cboSecciones.SelectedValue,
                IdTurno =(int)cboTurnos.SelectedValue,
                RutaArchivo = lblNombreArchivo.Text,
                Observaciones = txtObservaciones.Text,
                Estado = "1"
            });

            documento.fileNamePDF = this.filename;
            string mensaje = documento.save();
            if(string.IsNullOrEmpty(mensaje))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show(this, mensaje, "Error en registro documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
