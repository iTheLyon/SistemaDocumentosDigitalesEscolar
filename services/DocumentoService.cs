using SDD2.models;
using SDD2.utils;
using System.Collections.Generic;
using SDD2.dtos;
using System.Linq;
using System.IO;
using System;

namespace SDD2.services
{
    public class DocumentoService : DataBase
    {
        private readonly Documento _documento;
        public string fileNamePDF;
        public DocumentoService()
        {            
        }
        public DocumentoService(Documento documento) {
            _documento = documento;
        }

        public string save()
        {
            try
            {
                string mensajes = valid();
                if (string.IsNullOrEmpty(mensajes))
                {
                    if (_documento.Id == 0)
                    {
                        this.create(_documento);
                        //guardar el documento pdf.
                        string folder = Path.Combine("docs", _documento.Id.ToString());
                        Utils.SaveFileToFolder(fileNamePDF, folder);

                    }
                    else
                        this.update<Documento>(
                        c => c.Id == _documento.Id,
                        u =>
                        {
                            u.IdTipoDocumento = _documento.IdTipoDocumento;
                            u.Titulo = _documento.Titulo;
                            u.RutaArchivo = _documento.RutaArchivo;
                            u.Observaciones = _documento.Observaciones;
                            u.IdAnoEscolar = _documento.IdAnoEscolar;
                            u.IdNivel = _documento.IdNivel;
                            u.IdGrado = _documento.IdGrado;
                            u.IdSeccion = _documento.IdSeccion;
                            u.IdTurno = _documento.IdTurno;
                            u.Estado = _documento.Estado;
                            return u;
                        });

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

        public List<ResultadoDocumentoDTO> search(int anoInicio,int anoFin,
            int idTipoDocumento,string titulo,string observaciones,
            int idNivel,int idGrado,
            int idSeccion,int idTurno) {

            var resultado = from d in this.Documentos
                           join td in this.TiposDocumentos
                           on d.IdTipoDocumento equals td.Id                           
                           join a in this.AnosEscolar
                           on d.IdAnoEscolar equals a.Id
                           join af in this.AnosEscolar
                           on d.IdAnoEscolarFin equals af.Id
                           join n in this.Niveles
                           on d.IdNivel equals n.Id
                           join g in this.Grados
                           on d.IdGrado equals g.Id
                           join s in this.Secciones
                           on d.IdSeccion equals s.Id
                           join t in this.Turnos
                           on d.IdTurno equals t.Id
                           where (anoInicio <= a.Ano && a.Ano <=anoFin && anoInicio<= af.Ano && af.Ano <= anoFin)
                           && (d.IdTipoDocumento==idTipoDocumento || idTipoDocumento ==0)
                           && d.Titulo.Contains(titulo)
                           && d.Observaciones.Contains(observaciones)
                           && (d.IdNivel == idNivel || idNivel == 0)
                           && ((d.IdGrado <= idGrado && idGrado <= d.IdGradoFin) || idGrado == 0)
                           && ((d.IdSeccion <= idSeccion && idSeccion <=d.IdSeccionFin) || idSeccion == 0)
                           && (d.IdTurno == idTurno || idTurno == 0)
                           select new ResultadoDocumentoDTO
                           {
                            Id = d.Id,
                            Titulo = d.Titulo,
                            Ano = a.Ano,
                            NombreGrado = g.Nombre,
                            NombreSeccion = s.Nombre,
                            Observaciones = d.Observaciones,
                            RutaArchivo = d.RutaArchivo
                           };

            return resultado.ToList();
        }
     
        public string valid()
        {
            if (string.IsNullOrWhiteSpace(_documento.Titulo))       
            {
                return "Por favor, ingrese el titulo.";                
            }
            if (string.IsNullOrWhiteSpace(_documento.RutaArchivo))
            {
                return "Por favor, adjuntar su documento.";
            }
            return "";
        }

    }
}
