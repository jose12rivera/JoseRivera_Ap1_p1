using JoseRivera_Ap1_p1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace JoseRivera_Ap1_p1.DAL;
public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options)
    : base(options) { }

    public DbSet<Registros> Registros { get; set; }
}
