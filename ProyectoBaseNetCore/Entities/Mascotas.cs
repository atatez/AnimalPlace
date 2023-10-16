using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoBaseNetCore.Entities
{
    public class Mascotas : CrudEntities
    {
        [Key]
        public long IdMascotas { get; set; }
        public string NombreMascota { get; set; }
        public string Raza { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }

        [MaxLength(350)]
        public string Direccion { get; set; }
        public long? IdCliente { get; set; }
        public Clientes Cliente { get; set; }
    }
}
