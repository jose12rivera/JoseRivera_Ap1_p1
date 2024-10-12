using JoseRivera_Ap1_p1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace JoseRivera_Ap1_p1.DAL;
public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options)
    : base(options) { }
    public DbSet<Prestamos> Prestamos { get; set; }
    public DbSet<Deudores> Deudores { get; set; }
    public DbSet<Cobros> Cobros{ get; set; }
    public DbSet<CobroDetalle> cobroDetalle { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Deudores>().HasData(new List<Deudores>()
        {
            new Deudores() {DeudorId=1, Nombres="Jose"},
             new Deudores() {DeudorId=2, Nombres="Josue"},
              new Deudores() {DeudorId=3, Nombres="Juan"},
               new Deudores() {DeudorId=4, Nombres="Verde"},
                new Deudores() {DeudorId=5, Nombres="Pedro"}
        });
    }
}
