using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoBaseNetCore.Entities
{
    public class Resultado : CrudEntities
    {
        [Key]
        public long IdResultado { get; set; }
        public long? IdFicha { get; set; }
        public FichaSintoma FichaSintoma { get; set; }
        public DateTime FechaResultado { get; set; }
        public string Resultad { get; set; }
        public string Descripcion { get; set; }
        public string Tratamiento { get; set; }
        public string Observaciones { get; set; }
    }
}
