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
        public string Resultados { get; set; }
        public string Descripcion { get; set; }
        public string IdEnfermedad { get; set; }
        public Enfermedad Enfermedad { get; set; }
        public List<FichaSintoma> FichaSintomas { get; set; }
        public List<HistoriaClinica> HistoriaClinicas { get; set; }
    }
}
