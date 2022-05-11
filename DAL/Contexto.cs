using Microsoft.EntityFrameworkCore;
using Tarea_3_CrearOtroRegistroEnWpf.Entidades;

namespace Tarea_3_CrearOtroRegistroEnWpf.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Roles> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA\OtroRegistro.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Roles>().HasData(new Roles()
            {
                RollId = 1,
                Descripcion = "Administrador"
            });

            modelBuilder.Entity<Roles>().HasData(new Roles()
            {
                RollId = 2,
                Descripcion = "Usuario"
            });
        }
    }
}
