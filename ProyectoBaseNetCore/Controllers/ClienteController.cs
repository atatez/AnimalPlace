using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProyectoBaseNetCore.API.ViewModel;
using ProyectoBaseNetCore.Entities;
using ProyectoBaseNetCore.Services;

namespace ProyectoBaseNetCore.Controllers
{
    [ApiController]
    [Route("api/Cliente/")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClienteController : Controller
    {
        private readonly IConfiguration configuration;

        //copiar esto -------------------------
        private readonly IAuthorizationService authorizationService;

        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        protected ClienteService _service;

        public ClienteController(IConfiguration configuration, IAuthorizationService Authorization, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            this.authorizationService = Authorization;
            this.configuration = configuration;
            this.userManager = userManager;
            this._httpContextAccessor = httpContextAccessor;
            string userName = Task.Run(async () => await userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "email").Value)).Result.UserName;
            var ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress?.ToString();
            this._service = new ClienteService(userName, ip);
        }

        [HttpGet("ListarClientes")]
        public async Task<IActionResult> GetCliente()
        {
            try
            {
                var listadoCliente = await _service.GetCliente();
                return Ok(listadoCliente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("NuevoCliente")]
        public async Task<IActionResult> NuevaChofer(ClienteViewModel Cliente)
        {
            try
            {
                var empresa = await _service.SaveCliente(Cliente);
                return Ok(empresa);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("EliminaCliente")]
        public async Task<IActionResult> EliminaCliente(long IdCliente)
        {
            try
            {
                var empresa = await _service.DeleteCliente(IdCliente);
                return Ok(empresa);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}