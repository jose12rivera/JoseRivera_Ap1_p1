using JoseRivera_Ap1_p1.DAL;
using JoseRivera_Ap1_p1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JoseRivera_Ap1_p1.Services;

public class DeudoresServices(Contexto _contexto)
{
    public async Task<List<Deudores>> Listar(Expression<Func<Deudores, bool>> criterio)
    {
        return await _contexto.Deudores
             .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<List<Deudores>> ListarDeudores()
    {
        return await _contexto.Deudores
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Deudores>> ObtenerDeudoresConPrestamos()
    {
        return await _contexto.Deudores
            .Include(d => d.Prestamos)
            .Where(d => d.Prestamos.Count() == 1)// Asegúrate de tener la relación definida
            .ToListAsync();
    }
}
