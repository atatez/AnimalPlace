using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoBaseNetCore.Entities
{
    public class UserRol : CrudEntities
    {
        [Key]
        public long IdUserRol { get; set; }
        public long? IdUser { get; set; }
        public User User { get; set; }
        public long? IdRol { get; set; }
        public Rol Rol { get; set; }
    }
}
