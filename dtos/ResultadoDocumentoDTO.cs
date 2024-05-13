using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDD2.dtos
{
    public class ResultadoDocumentoDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Ano {  get; set; }
        public string NombreGrado { get; set;}
        public string NombreSeccion { get; set; }
        public string Observaciones { get; set; }
        public string RutaArchivo { get; set; }
    }
}

