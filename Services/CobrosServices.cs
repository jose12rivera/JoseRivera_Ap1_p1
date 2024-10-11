﻿using JoseRivera_Ap1_p1.DAL;
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

    public async Task<bool> Existe(int CobroId)
    {
        return await _contexto.Cobros.AnyAsync(c => c.CobroId == CobroId);
    }

    private async Task<bool> Insertar(Cobros cobro)
    {
        _contexto.Cobros.Add(cobro);
        return await _contexto.SaveChangesAsync() > 0;
    }


    public async Task<bool> Modificar(Cobros cobro)
    {
        var cobroExistente = await _contexto.Cobros
        .Include(c => c.CobroDetalles)
        .FirstOrDefaultAsync(c => c.CobroId == cobro.CobroId);

        if (cobroExistente != null)
        {
            
            foreach (var detalleExistente in cobroExistente.CobroDetalles.ToList())
            {
                if (!cobro.CobroDetalles.Any(d => d.DetalleId == detalleExistente.DetalleId))
                {
                    _contexto.cobroDetalle.Remove(detalleExistente);
                }
            }

           
            cobroExistente.CobroDetalles = cobro.CobroDetalles;

          
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
    public async Task<bool> Eliminar(int id)
    {
        var eliminado = await _contexto.Cobros
            .Where(c => c.CobroId == id)
            .ExecuteDeleteAsync();
        return eliminado > 0;
    }
    public async Task<Cobros?> Buscar(int id)
    {
        return await _contexto.Cobros
            .Include(c => c.Deudor)
            .Include(c=>c.CobroDetalles)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.CobroId == id);
    }
    public async Task<Prestamos?> ObtenerPrestamoPorDeudorId(int deudorId)
    {
        return await _contexto.Prestamos
        .Where(p => p.DeudorId == deudorId)
        .OrderByDescending(p => p.PrestamoId) 
        .FirstOrDefaultAsync();
    }
    public async Task<List<Cobros>> Listar(Expression<Func<Cobros, bool>> Criterio)
    {
        return await _contexto.Cobros
           .AsNoTracking()
           .Include(c => c.Deudor)
           .Include(c => c.CobroDetalles)
           .Where(Criterio)
           .ToListAsync();
    }
    public async Task<List<Deudores>> ListarDeudore()
    {
        return await _contexto.Deudores
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Deudores>> ObtenerDeudoresConPrestamos()
    {
        var deudoresConPrestamos = _contexto.Prestamos
          .Include(p => p.Deudor)
          .Select(p => p.Deudor)
          .Distinct()
          .ToList();

        return deudoresConPrestamos;
    }
}