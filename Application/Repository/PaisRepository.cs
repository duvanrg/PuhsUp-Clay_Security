using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class PaisRepository : GenericRepository<Pais>, IPais
{
        private readonly ApiContext _context;
        public PaisRepository(ApiContext context) : base(context)
        {
                _context = context;
        }
        public override async Task<(int totalRegistros, IEnumerable<Pais> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {

                var query = _context.Pais as IQueryable<Pais>;
                if (!string.IsNullOrEmpty(search))
                {
                        query = query.Where(p => p.NombrePais.ToLower().Contains(search));
                }
                var totalRegistros = await query.CountAsync();
                var registros = await query
                        .Include(u => u.Departamentos)
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
                return (totalRegistros, registros);
        }
}
