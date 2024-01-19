using CadastroCliente.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> usuarios { get; set; }
    }
}
