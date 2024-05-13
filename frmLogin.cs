using System;
using SDD2.models;
using SDD2.services;
using System.Windows.Forms;

namespace SDD2
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
           
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            UsuarioService usuario = new UsuarioService(new Usuario() {
                Id=0,
                Nombre = txtUsuario.Text,
                Clave = txtContrasenia.Text
            });

            string mensaje = usuario.authenticate();

            if(mensaje=="") {
                this.Hide();
                frmMenuPrincipal frmMenuPrincipal1 = new frmMenuPrincipal();
                frmMenuPrincipal1.Show();
            }
            else {
                MessageBox.Show(mensaje, "Acceso al Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
    }
}
