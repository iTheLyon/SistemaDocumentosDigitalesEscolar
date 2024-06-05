using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDD2.models;
using SDD2.services;

namespace SDD2
{
    public partial class frmTipoDocumento : Form
    {
        private TipoDocumento _tipoDocumento;
        public string fileNamePDF;
        public frmTipoDocumento()
        {
            InitializeComponent();
        }
        public frmTipoDocumento(TipoDocumento tipoDocumento) : this()
        {
            _tipoDocumento = tipoDocumento;
            txtNombre.Text = tipoDocumento.Nombre;
            this.lblTitulo.Text = "Editar Nombre Tipo Documento";
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_tipoDocumento == null)
            {
                _tipoDocumento = new TipoDocumento();
            }

            _tipoDocumento.Nombre = txtNombre.Text;


            TipoDocumentoService tipoDocumentoService = new TipoDocumentoService(_tipoDocumento);
            // tipodocumentoService.fileNamePDF = this.filename;
            tipoDocumentoService.fileNamePDF = this.fileNamePDF;
            string mensaje = tipoDocumentoService.save();
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
