using System;
using Microsoft.EntityFrameworkCore;
using AL.Aplicacion.Entidades;

namespace AL.Repositorios;

public class EntidadesContext : DbContext
{
#nullable disable
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<Alojamiento> Alojamientos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Tarjeta> Tarjetas { get; set; }
    public DbSet<FotoReserva> FotosReserva { get; set; }


#nullable enable
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=Entidades.sqlite");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Reserva>()
        .HasMany(r => r.ListaInformacionAdicional)
        .WithOne(f => f.Reserva)
        .HasForeignKey(f => f.ReservaId)
        .OnDelete(DeleteBehavior.Cascade);
}
}
