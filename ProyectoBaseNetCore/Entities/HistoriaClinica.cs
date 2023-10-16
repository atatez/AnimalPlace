using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoBaseNetCore.Entities
{
    public class HistoriaClinica : CrudEntities
    {
        [Key]
        public long IdHistoriaClinica { get; set; }
        public long? IdMascotas { get; set; }
        public Mascotas Mascotas { get; set; }
        public long? IdResultado { get; set; }
        public Resultado Resultado { get; set; }
        public string DiagnosticoGeneral { get; set; }
        public string Seguimiento { get; set; }
        public string Antecedentes { get; set; }
        public string Recetas { get; set; }
        public long? IdUser { get; set; }
        public User User { get; set; }

    }
}
