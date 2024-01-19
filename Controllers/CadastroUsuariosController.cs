using CadastroCliente.Data;
using CadastroCliente.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CadastroCliente.Controllers
{
    [ApiController]
    [Route("api")]
    public class CadastroUsuariosController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public CadastroUsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("cadastro-usuarios")]
        public IActionResult CadastrarUsuario([FromForm] UsuarioViewModel usuarioViewModel)
        {
            try
            {
                var usuario = new User
                {
                    Email = usuarioViewModel.Email,
                    Senha = usuarioViewModel.Senha,
                    Username = usuarioViewModel.Username,
                    Telefone = usuarioViewModel.Telefone,
                };

                if (usuarioViewModel.Foto != null && usuarioViewModel.Foto.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        usuarioViewModel.Foto.CopyTo(memoryStream);
                        usuario.Foto = memoryStream.ToArray();
                    }
                }

                _context.usuarios.Add(usuario);
                _context.SaveChanges();

                return Ok(new { Message = "Usuário cadastrado com sucesso." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro ao cadastrar usuário.", Error = ex.Message });
            }
        }
    }
}
