using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoBaseNetCore.Entities
{
    public class Enfermedad : CrudEntities
    {
        [Key]
        public long IdEnfermedad { get; set; }
        public string NombreEnfermedad { get; set; }
        public int ConteoDiagnosticoEnfermedad { get; set; }    ///Un campo numérico que se utiliza para llevar un registro del número de diagnósticos generales realizados para esta enfermedad.
    }
}
