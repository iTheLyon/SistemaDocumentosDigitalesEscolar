using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SDD2.dtos;
using SDD2.models;
using SDD2.utils;


namespace SDD2.services
{
    public class TipoDocumentoService : DataBase
    {
        private readonly TipoDocumento _tipoDocumento;
        public string fileNamePDF;
        public TipoDocumentoService()
        {
        }
        public TipoDocumentoService(TipoDocumento tipoDocumento)
        {
            _tipoDocumento = tipoDocumento;
        }

        public TipoDocumento ObtenerTipoDocumentoPorId(int id)
        {
            return this.TiposDocumentos.FirstOrDefault(d => d.Id == id);
        }

        public string EditarOGuardar()
        {
            try
            {
                string mensajes = valid();
                if (string.IsNullOrEmpty(mensajes))
                {
                    if (_tipoDocumento.Id == 0)
                    {
                        // Crear un nuevo documento
                        CrearTipoDocumento();
                    }
                    else
                    {
                        // Actualizar un documento existente
                        ActualizarTipoDocumento();
                    }
                    return "";
                }
                else
                {
                    return mensajes;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void CrearTipoDocumento()
        {
            // Lógica para crear un nuevo documento
            this.create(_tipoDocumento);
            // Guardar el documento pdf.
            string folder = Path.Combine("docs", _tipoDocumento.Id.ToString());
            Utils.SaveFileToFolder(fileNamePDF, folder);
        }

        private void ActualizarTipoDocumento()
        {
            // Lógica para actualizar un documento existente
            this.update<TipoDocumento>(
                c => c.Id == _tipoDocumento.Id,
                u =>
                {
                    
                    u.Nombre = _tipoDocumento.Nombre;
              
                    return u;
                });
        }

        public string save()
        {
            return EditarOGuardar();
        }

        public List<ResultadoTipoDocumentoDTO> search(string Nombre)
        {

            var resultado = from td in this.TiposDocumentos
                            where td.Nombre.Contains(Nombre)

                            select new ResultadoTipoDocumentoDTO
                            {
                                Id = td.Id,
                                Nombre = td.Nombre
                            };

            return resultado.ToList();
        }
        public string EliminarTipoDocumento(int tipoDocumentoId)
        {
            try
            {
                var documento = ObtenerTipoDocumentoPorId(tipoDocumentoId);
                if (documento == null)
                {
                    return "El documento no existe.";
                }
                this.TiposDocumentos.Remove(documento);
                this.SaveChanges();

                return "Tipo Documento eliminado exitosamente.";
            }
            catch (Exception ex)
            {
                return "Error al eliminar tipo documento: " + ex.Message;
            }
        }
        public string valid()
        {
            if (string.IsNullOrWhiteSpace(_tipoDocumento.Nombre))
            {
                return "Por favor, ingrese el nombre.";
            }
           
            return "";
        }
    }
}
