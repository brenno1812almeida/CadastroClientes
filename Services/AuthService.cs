using CadastroCliente.Data;

namespace CadastroCliente.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AuthenticateUser(string email, string senha)
        {
            var user = _context.usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);

            return user != null;
        }
    }
}
