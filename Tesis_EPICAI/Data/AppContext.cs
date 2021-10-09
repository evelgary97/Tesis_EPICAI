using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppContext : IdentityDbContext
{
    public AppContext(DbContextOptions<AppContext> options)
        : base(options)
    {
    }
    public DbSet<Tesis_EPICAI.Models.Cargo> Cargo { get; set; }

    public DbSet<Tesis_EPICAI.Models.Instrumentos> Instrumentos { get; set; }

    public DbSet<Tesis_EPICAI.Models.Producto> Producto { get; set; }

    public DbSet<Tesis_EPICAI.Models.Trabajador> Trabajador { get; set; }
}
