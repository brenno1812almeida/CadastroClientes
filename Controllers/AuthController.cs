using CadastroCliente.Models;
using CadastroCliente.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCliente.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserCredentials credentials)
        {
            bool isAuthenticated = _authService.AuthenticateUser(credentials.Email, credentials.Password);

            if (isAuthenticated)
            {
                return Ok(new { message = "Autenticação bem-sucedida", redirectTo = "/cadastro-usuarios" });
            }
            else
            {
                return Unauthorized(new { message = "Usuário não encontrado" });
            }
        }
    }
}
