using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProyectoBaseNetCore.DTOs.SecurityDTOs;
using ProyectoBaseNetCore.Entities;
using ProyectoBaseNetCore.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProyectoBaseNetCore.Controllers
{
    [ApiController]
    [Route("api/Security")]
    public class SecurityController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly HashService hashService;
        private readonly IDataProtector dataProtector;
        private string JWTKey { get; set; }

        public SecurityController(UserManager<ApplicationUser> userManager,
                                 IConfiguration configuration,
                                 SignInManager<ApplicationUser> signInManager,
                                 IDataProtectionProvider dataProtectionProvider,
                                 HashService hashService)
        {
            JWTKey = configuration["JWTKey"];
            this.userManager = userManager;
            this.configuration = configuration;
            this.signInManager = signInManager;
            this.hashService = hashService;
            dataProtector = dataProtectionProvider.CreateProtector(JWTKey);
        }

        [HttpGet("Encrypt")]
        public ActionResult Encriptar()
        {
            var textoPlano = "Geovanny Andrade";
            var textoCifrado = dataProtector.Protect(textoPlano);
            var textoDesencriptado = dataProtector.Unprotect(textoCifrado);
            return Ok(new
            {
                textoPlano,
                textoCifrado,
                textoDesencriptado
            });
        }

        [HttpGet("EncryptByTime")]
        public ActionResult EncriptarPorTiempo()
        {
            var protectoLimitadoPorTiempo = dataProtector.ToTimeLimitedDataProtector();

            var textoPlano = "Geovanny Andrade";
            var textoCifrado = protectoLimitadoPorTiempo.Protect(textoPlano, lifetime: TimeSpan.FromSeconds(5));
            Thread.Sleep(TimeSpan.FromSeconds(6));
            var textoDesencriptado = protectoLimitadoPorTiempo.Unprotect(textoCifrado);
            return Ok(new
            {
                textoPlano,
                textoCifrado,
                textoDesencriptado
            });
        }

        [HttpGet("hash/{textoPlano}")]
        public ActionResult RealizarHash(string textoPlano)
        {
            var result1 = hashService.Hash(textoPlano);
            var result2 = hashService.Hash(textoPlano);
            return Ok(new
            {
                textoPlano,
                hash1 = result1,
                hash2 = result2,
            });
        }

        [HttpPost("Register")]
        public async Task<ActionResult<AuthenticationResponse>> Registrar(DTOs.SecurityDTOs.RegisterInfo registerInfo)
        {
            var user = new ApplicationUser { UserName = registerInfo.Username, Email = registerInfo.Email };
            var result = await userManager.CreateAsync(user, registerInfo.Password);

            if (result.Succeeded)
            {
                return await CreateToken(registerInfo.Username);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthenticationResponse>> Login(DTOs.SecurityDTOs.UserLoginInfo userLoginInfo)
        {
            var result = await signInManager.PasswordSignInAsync(userLoginInfo.Username,
                                                                    userLoginInfo.Password,
                                                                    isPersistent: false,
                                                                    lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return await CreateToken(userLoginInfo.Username);
            }
            else
            {
                return BadRequest("Login incorrecto");
            }
        }

        [HttpGet("RenewToken")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<AuthenticationResponse>> Renovar()
        {
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault();
            var email = emailClaim.Value;
            return await CreateToken(email);
        }

        //Generar Hash y Token
        private async Task<AuthenticationResponse> CreateToken(string username)
        {
            var claims = new List<Claim>()
            {
                new Claim("email", username),
            };

            var user = await userManager.FindByNameAsync(username);
            var claimsDB = await userManager.GetClaimsAsync(user);

            claims.AddRange(claimsDB);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddYears(1);

            var securtityToken = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expiration, signingCredentials: creds);

            return new AuthenticationResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securtityToken),
                Expiracion = expiration,
            };
        }

        [HttpGet("ValidateToken")]
        public async Task<ActionResult> ValidateTokenUser(string token)
        {
            try
            {
                var validateToken = await ValidateToken(token);
                if (validateToken is null)
                {
                    return BadRequest("Token no valido");
                }
                return Ok(validateToken);
            }
            catch (Exception)
            {
                return BadRequest("Token no valido");
            }
        }

        private Task<string> ValidateToken(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JWTKey);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = jwtToken.Claims.First(x => x.Type == "email").Value;

                // return user id from JWT token if validation successful
                return Task.FromResult(userId);
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }

        [HttpPost("ChangePassword")]
        public async Task<ActionResult> ChangePassword(DTOs.SecurityDTOs.UserLoginInfo credencialesUsuario)
        {
            ApplicationUser user = await userManager.FindByNameAsync(credencialesUsuario.Username);
            if (user == null)
            {
                return NotFound();
            }
            user.PasswordHash = userManager.PasswordHasher.HashPassword(user, credencialesUsuario.Password);
            var result = await userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest("Ocurrio un error al cmabiar su contraseña");
            }
            return Ok("Contraseña actualizada con exito!");
        }
    }
}