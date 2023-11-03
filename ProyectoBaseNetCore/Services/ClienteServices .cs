using Microsoft.EntityFrameworkCore;
using ProyectoBaseNetCore.DTOs;
using ProyectoBaseNetCore.Entities;

namespace ProyectoBaseNetCore.Services
{
    public class ClienteService
    {
        private static string _usuario;
        private static string _ip;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        public ClienteService(ApplicationDbContext context, IConfiguration configuration, string ip, string usuario)
        {
            _context = context;
            this.configuration = configuration;
            _ip = ip;
            _usuario = usuario;
        }
        public async Task<List<ClienteDTO>> GetCliente() => await _context.Cliente
            .Where(x => x.Activo).Select(x => new ClienteDTO
            {
                Identificacion = x.Identificacion,
                Nombres = x.Nombres,
                IdCliente = x.IdCliente,
                Direccion = x.Direccion,
                Telefono = x.Telefono,
                Apellidos = x.Apellidos,
            }).ToListAsync();


        public async Task<ClienteDTO> GetIdCliente(string Ruc) => await _context.Cliente
            .Where(x => x.Activo && x.Identificacion == Ruc).Select(x => new ClienteDTO
            {
                IdCliente = x.IdCliente,
                Identificacion = x.Identificacion,
                Nombres = x.Nombres,
                Apellidos = x.Apellidos,
                Direccion = x.Direccion,
                Telefono = x.Telefono,
            }).FirstOrDefaultAsync();

        public async Task<bool> SaveCliente(ClienteDTO Cliente)
        {
            try
            {

                Cliente ClienteEncontrada = await _context.Cliente.Where(x => x.Identificacion == Cliente.Identificacion.Trim()).FirstOrDefaultAsync();
                if (ClienteEncontrada == null)
                {
                    Cliente NewCliente = new Cliente();
                    NewCliente.Identificacion = Cliente.Identificacion;
                    NewCliente.Nombres = Cliente.Nombres;
                    NewCliente.IdCliente = Cliente.IdCliente;
                    NewCliente.Apellidos = Cliente.Apellidos;
                    NewCliente.Direccion = Cliente.Direccion;
                    NewCliente.Telefono = Cliente.Telefono;
                    NewCliente.FechaRegistro = DateTime.Now;
                    NewCliente.UsuarioRegistro = _usuario;
                    NewCliente.IpRegistro = _ip;
                    await _context.Cliente.AddAsync(NewCliente);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    ClienteEncontrada.Nombres = Cliente.Nombres;
                    ClienteEncontrada.Apellidos = Cliente.Apellidos;
                    ClienteEncontrada.Direccion = Cliente.Direccion;
                    ClienteEncontrada.Telefono = Cliente.Telefono;
                    ClienteEncontrada.FechaModificacion = DateTime.Now;
                    ClienteEncontrada.UsuarioModificacion = _usuario;
                    ClienteEncontrada.IpModificacion = _ip;
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteCliente(long IdCliente)
        {
            try
            {
                var ClienteEncontrada = await _context.Cliente.FindAsync(IdCliente);
                if (ClienteEncontrada != null)
                {
                    ClienteEncontrada.Activo = false;
                    ClienteEncontrada.FechaEliminacion = DateTime.Now;
                    ClienteEncontrada.UsuarioEliminacion = _usuario;
                    ClienteEncontrada.IpEliminacion = _ip;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}