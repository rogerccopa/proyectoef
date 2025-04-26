using Microsoft.EntityFrameworkCore;
using proyecto.Models;

namespace proyectoef;

public class TareasContext : DbContext
{
    public DbSet<Tarea> Tareas { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

    public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarea>()
            .HasKey(t => t.TareaId);

        modelBuilder.Entity<Categoria>()
            .HasKey(c => c.CategoriaId);

        modelBuilder.Entity<Tarea>()
            .HasOne(t => t.Categoria)
            .WithMany(c => c.Tareas)
            .HasForeignKey(t => t.CategoriaId);
        
        modelBuilder.Entity<Categoria>()
            .Property(c => c.Nombre)
            .HasMaxLength(150)
            .IsRequired();
    }
}