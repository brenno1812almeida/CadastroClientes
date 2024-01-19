﻿namespace CadastroCliente.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Username { get; set; }
        public string Telefone { get; set; }
        public IFormFile Foto { get; set; }
    }
}
