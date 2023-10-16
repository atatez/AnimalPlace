using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProyectoBaseNetCore.Entities
{
    public class Rol : CrudEntities
    {

        [Key]
        public long IdRol { get; set; }
        public string NombreRol { get; set; }
        public string Descripcion { get; set; }
        public List<UserRol> UserRoles { get; set; }
    }
}
