using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using ProyectoBaseNetCore.API.ViewModel;
using ProyectoBaseNetCore.DTOs.SecurityDTOs;
using ProyectoBaseNetCore.Entities;
using System.Security.Cryptography;

namespace ProyectoBaseNetCore.Services
{
    public class ClienteService
    {
        private static string _usuario;
        private static string _ip;

        public ClienteService()
        {
        }

        public ClienteService(string usuario, string ip)
        {
            _ip = ip;
            _usuario = usuario;
        }

        public async Task<List<ClienteViewModel>> GetCliente()
        {
            using (var contexto = new ApplicationDbContext())
            {
                var query = await contexto.Clientes.Where(x => x.Activo).Select(x => new ClienteViewModel
                {
                    Identificacion = x.Identificacion,
                    Nombres = x.Nombres,
                    IdCliente = x.IdCliente,
                    Direccion = x.Direccion,
                    Telefono  = x.Telefono,
                    Apellidos = x.Apellidos,
                }).ToListAsync();

                return query;
            }
        }

        public async Task<ClienteViewModel> GetIdCliente(string Ruc)
        {
            using (var contexto = new ApplicationDbContext())
            {
                var query = await contexto.Clientes.Where(x => x.Activo && x.Identificacion == Ruc).Select(x => new ClienteViewModel
                {
                    IdCliente = x.IdCliente,
                    Identificacion = x.Identificacion,
                    Nombres = x.Nombres,
                    Apellidos= x.Apellidos,
                    Direccion= x.Direccion,
                    Telefono = x.Telefono,
                }).FirstOrDefaultAsync();

                return query;
            }
        }

        public async Task<bool> SaveCliente(ClienteViewModel Cliente)
        {
            try
            {
                using (var contexto = new ApplicationDbContext())
                {
                    var ClienteEncontrada = await contexto.Clientes.Where(x => x.Activo && x.IdCliente == Cliente.IdCliente).FirstOrDefaultAsync();
                    if (ClienteEncontrada == null)
                    {
                        Clientes NewCliente = new Clientes();
                        NewCliente.Identificacion = Cliente.Identificacion;
                        NewCliente.Nombres = Cliente.Nombres;
                        NewCliente.IdCliente = Cliente.IdCliente;
                        NewCliente.Apellidos = Cliente.Apellidos;
                        NewCliente.Direccion = Cliente.Direccion;
                        NewCliente.Telefono = Cliente.Telefono;
                        NewCliente.Activo = true;
                        NewCliente.FechaRegistro = DateTime.Now;
                        NewCliente.UsuarioRegistro = _usuario;
                        NewCliente.IpRegistro = _ip;
                        NewCliente.SistemaRegistro = "Vet Animal";
                        contexto.Clientes.Add(NewCliente);
                        contexto.SaveChanges();
                        return true;
                    }
                    else
                    {
                        ClienteEncontrada.Identificacion = Cliente.Identificacion;
                        ClienteEncontrada.Nombres = Cliente.Nombres;
                        ClienteEncontrada.Apellidos= Cliente.Apellidos;
                        ClienteEncontrada.Direccion = Cliente.Direccion;
                        ClienteEncontrada.Telefono = Cliente.Telefono;
                        ClienteEncontrada.Activo = true;
                        ClienteEncontrada.FechaModificacion = DateTime.Now;
                        ClienteEncontrada.UsuarioModificacion = _usuario;
                        ClienteEncontrada.IpModificacion = _ip;
                        ClienteEncontrada.SistemaModificacion = "Vet Animal";

                        contexto.SaveChanges();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteCliente(long IdCliente)
        {
            try
            {
                using (var contexto = new ApplicationDbContext())
                {
                    var ClienteEncontrada = await contexto.Clientes.Where(x => x.Activo && x.IdCliente == IdCliente).FirstOrDefaultAsync();
                    if (ClienteEncontrada != null)
                    {
                        ClienteEncontrada.Activo = false;
                        ClienteEncontrada.FechaEliminacion = DateTime.Now;
                        ClienteEncontrada.UsuarioEliminacion = _usuario;
                        ClienteEncontrada.IpEliminacion = _ip;
                        ClienteEncontrada.SistemaEliminacion = "Vet Animal";
                        contexto.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}