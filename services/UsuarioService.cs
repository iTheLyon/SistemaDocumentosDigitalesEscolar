using SDD2.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDD2.services
{
    public class UsuarioService : DataBase
    {
        private readonly Usuario _usuario;
        public UsuarioService(Usuario usuario) {
            _usuario = usuario;
        }

        public int save()
        {
            if(_usuario.Id == 0)
                return this.create(_usuario);
            else
                return this.update<Usuario>(
                c =>c.Id == _usuario.Id,
                u => {
                    u.Nombre =_usuario.Nombre;
                    u.Clave = _usuario.Clave;
                    return u;
                });
        }

        public bool exist()
        {
           var objeto = this.get<Usuario>(
                u => u.Nombre.ToUpper() == _usuario.Nombre.ToUpper() 
                && u.Clave.ToUpper() == _usuario.Clave.ToUpper()
           );
           if(objeto!=null)
           {
                return true;
           }
           else
           {
                return false;
           }
        }

        public string valid()
        {
            if (string.IsNullOrWhiteSpace(_usuario.Nombre) 
                || string.IsNullOrWhiteSpace(_usuario.Clave))
            {
                return "Por favor, ingrese usuario y contraseña.";                
            }

            return "";
        }

        public string authenticate()
        {
            string mensaje = this.valid();
            if(string.IsNullOrEmpty(mensaje))
            {
                if(this.exist()) 
                {
                    return "";
                }
                else
                {
                    return "Usuario o contraseña incorrectos. Intenta nuevamente.";
                }
            }
           else
           {
                return mensaje;
           }
        }
    }
}
