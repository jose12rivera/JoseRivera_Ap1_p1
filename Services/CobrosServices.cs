using JoseRivera_Ap1_p1.DAL;
using JoseRivera_Ap1_p1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JoseRivera_Ap1_p1.Services;

public class CobrosServices
{
    private readonly Contexto _contexto;

    public CobrosServices(Contexto contexto)
    {
        _contexto = contexto;
    }

    // Método para verificar si existe un Cobro
    public async Task<bool> Existe(int cobroId)
    {
        return await _contexto.Cobros.AnyAsync(c => c.CobroId == cobroId);
    }

    // Método para insertar un nuevo Cobro
    private async Task<bool> Insertar(Cobros cobro)
    {
        _contexto.Cobros.Add(cobro);
        return await _contexto.SaveChangesAsync() > 0;
    }

    // Método para modificar un Cobro existente
    public async Task<bool> Modificar(Cobros cobro)
    {
        var cobroExistente = await _contexto.Cobros
            .Include(c => c.CobrosDetalle)
            .FirstOrDefaultAsync(c => c.CobroId == cobro.CobroId);

        if (cobroExistente != null)
        {
            // Eliminar detalles que ya no están presentes
            foreach (var detalleExistente in cobroExistente.CobrosDetalle.ToList())
            {
                if (!cobro.CobrosDetalle.Any(d => d.DetalleId == detalleExistente.DetalleId))
                {
                    _contexto.CobrosDetalle.Remove(detalleExistente);
                }
            }

            // Actualizar detalles existentes
            cobroExistente.CobrosDetalle = cobro.CobrosDetalle;
            _contexto.Entry(cobroExistente).CurrentValues.SetValues(cobro);
            return await _contexto.SaveChangesAsync() > 0;
        }

        return false;
    }

    public async Task<bool> Guardar(Cobros cobro)
    {
        if (!await Existe(cobro.CobroId))
            return await Insertar(cobro);
        else
            return await Modificar(cobro);
    }


    // Método para eliminar un Cobro
    public async Task<bool> Eliminar(int id)
    {
        var eliminado = await _contexto.Cobros
            .Where(c => c.CobroId == id)
            .ExecuteDeleteAsync();
        return eliminado > 0;
    }

    // Método para buscar un Cobro con sus detalles y deudor asociado
    public async Task<Cobros?> Buscar(int id)
    {
        return await _contexto.Cobros
            .Include(c => c.Deudor)
            .Include(c => c.CobrosDetalle)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.CobroId == id);
    }

    // Método para listar Cobros con un criterio específico, incluyendo deudor y detalles
    public async Task<List<Cobros>> Listar(Expression<Func<Cobros, bool>> criterio)
    {
        return await _contexto.Cobros
           .AsNoTracking()
           .Include(c => c.Deudor)
           .Include(c => c.CobrosDetalle)
           .Where(criterio)
           .ToListAsync();
    }

    // Método para obtener deudores que tienen préstamos
    public async Task<List<Deudores>> ObtenerDeudoresConPrestamos()
    {
        return await _contexto.Prestamos
             .AsNoTracking()
            .Include(p => p.Deudor)
            .Select(p => p.Deudor)
            .Distinct()
            .ToListAsync();
    }

    // Método para cargar los préstamos de un deudor específico
    public async Task<List<Prestamos>> CargarPrestamosPorDeudorAsync(int deudorId)
    {
        return await _contexto.Prestamos
            .Where(p => p.DeudorId == deudorId && p.Balance > 0)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Deudores>> ListarDeudore()
    {
        return await _contexto.Deudores.ToListAsync(); // Obtiene la lista de deudores
    }

}
