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
using SDD2.utils;

namespace SDD2
{
    public partial class frmDocumento : Form
    {
        private string filename;
        private int? documentId;

        public frmDocumento()
        {
            InitializeComponent();
        }
                public frmDocumento(int documentId) : this()
                {
                    this.documentId = documentId;
                    if (documentId != 0)
                    {
                        CargarDatosDocumento(documentId);
                        this.label4.Text = "Editar Documento Digital";
                    }
                }
        private void CargarDatosDocumento(int documentId)
        {
            DocumentoService documentoService = new DocumentoService();
            var documento = documentoService.ObtenerDocumentoPorId(documentId);

            cboTiposDocumentos.SelectedValue = documento.IdTipoDocumento;
            txtTitulo.Text = documento.Titulo;
            cboAnos.SelectedValue = documento.IdAnoEscolar;
            cboAnosFin.SelectedValue = documento.IdAnoEscolarFin;
            cboNiveles.SelectedValue = documento.IdNivel;
            cboGrados.SelectedValue = documento.IdGrado;
            cboGradosFin.SelectedValue = documento.IdGradoFin;
            cboSecciones.SelectedValue = documento.IdSeccion;
            cboSeccionesFin.SelectedValue = documento.IdSeccionFin;
            cboTurnos.SelectedValue = documento.IdTurno;
            lblNombreArchivo.Text = documento.RutaArchivo;
            txtObservaciones.Text = documento.Observaciones;

            if (!string.IsNullOrEmpty(documento.RutaArchivo))
            {
                string pathfolder = Path.Combine("docs", documentId.ToString());
                string ruta = Utils.getPath(pathfolder, documento.RutaArchivo);
                pdfViewer2.Document?.Dispose();
                pdfViewer2.Document = OpenDocument(ruta);
            }
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

            var anosfin = database.AnosEscolar.ToList();
            cboAnosFin.Items.Clear();
            cboAnosFin.DataSource = anosfin;
            cboAnosFin.DisplayMember = "Ano";
            cboAnosFin.ValueMember = "Id";

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

            var gradosfin = database.Grados.ToList();
            cboGradosFin.Items.Clear();
            cboGradosFin.DataSource = gradosfin;
            cboGradosFin.DisplayMember = "Nombre";
            cboGradosFin.ValueMember = "Id";

            var secciones = database.Secciones.ToList();
            cboSecciones.Items.Clear();
            cboSecciones.DataSource = secciones;
            cboSecciones.DisplayMember = "Nombre";
            cboSecciones.ValueMember = "Id";

            var seccionesfin = database.Secciones.ToList();
            cboSeccionesFin.Items.Clear();
            cboSeccionesFin.DataSource = seccionesfin;
            cboSeccionesFin.DisplayMember = "Nombre";
            cboSeccionesFin.ValueMember = "Id";

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
            if(cboTiposDocumentos.SelectedItem == null)
            {
                MessageBox.Show(this, "Vuelve a seleccionar correctamente el tipo de documento","Registro de Documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboAnos.SelectedItem == null)
            {
                MessageBox.Show(this, "Vuelve a seleccionar correctamente el año inicial", "Registro de Documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboAnosFin.SelectedItem == null)
            {
                MessageBox.Show(this, "Vuelve a seleccionar correctamente el año final","Registro de Documento" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboNiveles.SelectedItem == null)
            {
                MessageBox.Show(this, "Vuelve a seleccionar correctamente el nivel", "Registro de Documento" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboGrados.SelectedItem == null)
            {
                MessageBox.Show(this, "Vuelve a seleccionar correctamente el grado inicial","Registro de Documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (cboGradosFin.SelectedItem == null)
            {
                MessageBox.Show(this, "Vuelve a seleccionar correctamente el grado final", "Registro de Documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboSecciones.SelectedItem == null)
            {
                MessageBox.Show(this, "Vuelve a seleccionar correctamente el seccion inicial","Registro de Documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboSeccionesFin.SelectedItem == null)
            {
                MessageBox.Show(this, "Vuelve a seleccionar correctamente el seccion final", "Registro de Documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (cboTurnos.SelectedItem == null)
            {
                MessageBox.Show(this, "Vuelve a seleccionar correctamente el turno", "Registro de Documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(this.filename))
            {
                MessageBox.Show(this, "Por favor, adjunte un documento digital.", "Registro de Documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Documento documento = new Documento
            {
                Id = this.documentId ?? 0,
                IdTipoDocumento = (int)cboTiposDocumentos.SelectedValue,
                Titulo = txtTitulo.Text,
                IdAnoEscolar = (int)cboAnos.SelectedValue,
                IdAnoEscolarFin = (int)cboAnosFin.SelectedValue,
                IdNivel = (int)cboNiveles.SelectedValue,
                IdGrado = (int)cboGrados.SelectedValue,
                IdGradoFin = (int)cboGradosFin.SelectedValue,
                IdSeccion = (int)cboSecciones.SelectedValue,
                IdSeccionFin = (int)cboSeccionesFin.SelectedValue,
                IdTurno =(int)cboTurnos.SelectedValue,
                RutaArchivo = lblNombreArchivo.Text,
                Observaciones = txtObservaciones.Text,
                Estado = "1"
            };
            DocumentoService documentoService = new DocumentoService(documento);
            documentoService.fileNamePDF = this.filename;

            string mensaje = documentoService.save();
            if (string.IsNullOrEmpty(mensaje))
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
