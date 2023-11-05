﻿using System.ComponentModel.DataAnnotations;

namespace ProyectoBaseNetCore.DTOs
{
    public class ClienteDTO
    {
        public long IdCliente { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        [MaxLength(350)]
        public string Direccion { get; set; }
    }
    
}
