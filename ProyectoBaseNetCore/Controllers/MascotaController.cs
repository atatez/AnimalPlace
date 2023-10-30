using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProyectoBaseNetCore.Entities;
using ProyectoBaseNetCore.Services;

namespace ProyectoBaseNetCore.Controllers
{
    [ApiController]
    [Route("api/Mascota/")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MascotaController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly IAuthorizationService authorizationService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected ClienteService _service;
        private readonly ApplicationDbContext _context;

        public MascotaController(ApplicationDbContext context, 
            IConfiguration configuration, 
            IAuthorizationService Authorization, 
            UserManager<ApplicationUser> userManager, 
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this.authorizationService = Authorization;
            this.configuration = configuration;
            this.userManager = userManager;
            this._httpContextAccessor = httpContextAccessor;
            string userName = Task.Run(async () => await userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "email").Value)).Result.UserName;
            var ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress?.ToString();
            this._service = new ClienteService(_context,configuration, userName, ip);
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> GetCliente() =>Ok(await _service.GetCliente());

        [HttpPost("Crear")]
        public async Task<IActionResult> NuevoCliente(ClienteViewModel Cliente) =>Ok(await _service.SaveCliente(Cliente));
          

        [HttpDelete("Eliminar")]
        public async Task<IActionResult> EliminaCliente(long IdCliente) => Ok(await _service.DeleteCliente(IdCliente));
    }
}