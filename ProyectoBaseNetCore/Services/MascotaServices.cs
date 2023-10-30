using Microsoft.EntityFrameworkCore;
using ProyectoBaseNetCore.API.ViewModel;
using ProyectoBaseNetCore.Entities;

namespace ProyectoBaseNetCore.Services
{
    public class MascotaServices
    {
        private static string _usuario;
        private static string _ip;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        public MascotaServices(ApplicationDbContext context, IConfiguration configuration, string ip, string usuario)
        {
            _context = context;
            this.configuration = configuration;
            _ip = ip;
            _usuario = usuario;
        }

       

        public async Task<List<ClienteViewModel>> GetAllMascotasAsync()
        {
                var query = await _context.Mascota.Where(x => x.Activo).Select(x => new ClienteViewModel
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

        public async Task<ClienteViewModel> GetIdCliente(string Ruc)
        {
                var query = await _context.Cliente.Where(x => x.Activo && x.Identificacion == Ruc).Select(x => new ClienteViewModel
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

        public async Task<bool> SaveCliente(ClienteViewModel Cliente)
        {
            try
            {
                
                    var ClienteEncontrada = await _context.Cliente.Where(x => x.Activo && x.IdCliente == Cliente.IdCliente).FirstOrDefaultAsync();
                    if (ClienteEncontrada == null)
                    {
                        Cliente NewCliente = new Cliente();
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
                        _context.Cliente.Add(NewCliente);
                        _context.SaveChanges();
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
                        _context.SaveChanges();

                        return true;
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
                    var ClienteEncontrada = await _context.Cliente.Where(x => x.Activo && x.IdCliente == IdCliente).FirstOrDefaultAsync();
                    if (ClienteEncontrada != null)
                    {
                        ClienteEncontrada.Activo = false;
                        ClienteEncontrada.FechaEliminacion = DateTime.Now;
                        ClienteEncontrada.UsuarioEliminacion = _usuario;
                        ClienteEncontrada.IpEliminacion = _ip;
                        _context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}