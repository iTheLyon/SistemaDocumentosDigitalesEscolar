using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SDD2.models
{
    public class Documento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdTipoDocumento { get; set; }
        public string Titulo { get; set; }
        public string RutaArchivo { get; set; }
        public string Observaciones { get; set; }
        public int IdAnoEscolar { get; set; }
        public int? IdNivel { get; set; }
        public int? IdGrado { get; set; }
        public int? IdSeccion { get; set; }
        public int? IdTurno { get; set; }
        public string Estado { get; set; }
    }
}
