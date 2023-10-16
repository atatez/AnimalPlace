using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoBaseNetCore.Entities
{
    public class Clientes : CrudEntities
    {
        [Key]
        public long IdCliente{ get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        [MaxLength(350)]
        public string Direccion { get; set; }

        public List<Mascotas> Mascotas { get; set; }
    }
}
    
