using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoBaseNetCore.Entities
{
    public class Detalle : CrudEntities
    {
        [Key]
        public long IdDetalle { get; set; }
        public long? IdFicha { get; set; }
        public FichaSintoma FichaSintomas { get; set; }
        public int Fiebre { get; set; }
        public int DebilidadTrenInf { get; set; }
        public int Alopecia { get; set; } 
        public int Anemia { get; set; }
    }
}
