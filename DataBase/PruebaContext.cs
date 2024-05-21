using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class PruebaContext : DbContext
    {
        public PruebaContext(DbContextOptions<PruebaContext> options): base(options)
        {

        }

        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Departamento> Departamentos { get; set;}
        public DbSet<Users> Users { get; set; }
    }
}