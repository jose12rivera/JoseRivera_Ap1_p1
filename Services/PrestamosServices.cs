using JoseRivera_Ap1_p1.DAL;
using JoseRivera_Ap1_p1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JoseRivera_Ap1_p1.Services;

public class PrestamosServices
{
    private readonly Contexto _contexto;
    public PrestamosServices(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task <bool>Existe(int prestamoId)
    {
        return await _contexto.Prestamos.AnyAsync(P=>P.PrestamoId == prestamoId);
    }

    private async Task <bool> Insertar(Prestamos prestamo)
    {
        _contexto.Prestamos.Add(prestamo);
        return await _contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(Prestamos prestamo)
    {
        _contexto.Prestamos.Update(prestamo);
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Guardar(Prestamos prestamo)
    {
        prestamo.Balance = prestamo.Monto;
        if(!await Existe(prestamo.PrestamoId)) 
            return await Insertar(prestamo);
        else
            return await  Modificar(prestamo);
    }
    public async Task<bool> Eliminar(int id)
    {
       var eliminado= await _contexto.Prestamos
            .Where(p=>p.PrestamoId==id)
            .ExecuteDeleteAsync();
        return eliminado > 0;
    }
    public async Task<Prestamos?> Buscar(int id)
    {
        return await _contexto.Prestamos
            .Include(d=>d.Deudor)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.PrestamoId == id);
    }


    public async Task<List<Prestamos>>Listar(Expression<Func<Prestamos, bool>> Criterio)
    {
        return await _contexto.Prestamos
           .AsNoTracking()
           .Include(d=>d.Deudor)
           .Where(Criterio) 
           .ToListAsync();
    }
    public async Task<List<Deudores>> ListarDeudore()
    {
        return await _contexto.Deudores
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Prestamos>> CargarPrestamosPorDeudorAsync(int deudorId)
    {
        return await _contexto.Prestamos.Where(p => p.DeudorId == deudorId).ToListAsync();
    }
}
