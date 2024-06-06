using Papeleriaweb.Models;
using Microsoft.EntityFrameworkCore;

namespace Papeleriaweb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Producto> Producto { get; set; }

        public DbSet<Proovedor> Proovedor { get; set; }

    }
}
