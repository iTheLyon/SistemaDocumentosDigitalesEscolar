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
using PdfiumViewer;
using SDD2.dtos;
using SDD2.models;
using SDD2.services;
using SDD2.utils;

namespace SDD2
{
    public partial class frmBusquedaTipoDocumento : Form
    {
        public frmBusquedaTipoDocumento()
        {
            InitializeComponent();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaActual = dgvTipoDocumentos.Rows[e.RowIndex];
                string nombre = filaActual.Cells["NOMBRE"].Value.ToString();
                string id = filaActual.Cells["ID"].Value.ToString();
                string pathfolder = Path.Combine("docs", id);
                string ruta = Utils.getPath(pathfolder, nombre);
               
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            TipoDocumentoService tipoDocumentoService = new TipoDocumentoService();


            if (txtNombre.Text == null)
            {
                MessageBox.Show(this, "Vuelve a seleccionar el tipo de documento correctamente", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
            string nombre = txtNombre.Text;

            List<ResultadoTipoDocumentoDTO> documentos;
            documentos = tipoDocumentoService.search(nombre);

            dgvTipoDocumentos.Columns.Clear();
            dgvTipoDocumentos.DataSource = documentos;
            dgvTipoDocumentos.Columns["Id"].Visible = true;

            dgvTipoDocumentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewButtonColumn btnColumn1 = new DataGridViewButtonColumn();
            btnColumn1.HeaderText = "ACCIONES";
            btnColumn1.Name = "btnEditar";
            btnColumn1.Text = "Editar";
            btnColumn1.UseColumnTextForButtonValue = true;
            dgvTipoDocumentos.Columns.Add(btnColumn1);

            DataGridViewButtonColumn btnColumn2 = new DataGridViewButtonColumn();
            btnColumn2.HeaderText = "";
            btnColumn2.Name = "btnEliminar";
            btnColumn2.Text = "Eliminar";
            btnColumn2.UseColumnTextForButtonValue = true;
            dgvTipoDocumentos.Columns.Add(btnColumn2);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmTipoDocumento frmTipoDocumento = new frmTipoDocumento();
            frmTipoDocumento.FormClosed += (s, args) => btnBuscar_Click(sender, e);
            frmTipoDocumento.ShowDialog();
        }

        private void dgvTipoDocumentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaActual = dgvTipoDocumentos.Rows[e.RowIndex];
                string id = filaActual.Cells[0].Value.ToString();

                string nombre = filaActual.Cells[1].Value.ToString();

                if (e.ColumnIndex == dgvTipoDocumentos.Columns["btnEditar"].Index)
                {
                    TipoDocumento tipoDocumento = new TipoDocumento
                    {
                        Id = int.Parse(id),
                        Nombre = nombre
                    };

                    frmTipoDocumento frm = new frmTipoDocumento(tipoDocumento);
                    frm.FormClosed += (s, args) => btnBuscar_Click(sender, e);
                    frm.ShowDialog();
                }

                if (e.ColumnIndex == dgvTipoDocumentos.Columns["btnEliminar"].Index)
                {
                    var confirmResult = MessageBox.Show("¿Está seguro de que desea eliminar este documento?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        TipoDocumentoService tipoDocumentoService = new TipoDocumentoService();
                        string mensaje = tipoDocumentoService.EliminarTipoDocumento(int.Parse(id));

                        if (mensaje == "Documento eliminado exitosamente.")
                        {
                            MessageBox.Show(mensaje, "Eliminar Documento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnBuscar_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void frmBusquedaTipoDocumento_Load(object sender, EventArgs e)
        {
            btnBuscar_Click(sender, e);
        }
    }
}
