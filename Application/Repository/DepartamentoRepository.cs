using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamento
{
        private readonly ApiContext _context;
        public DepartamentoRepository(ApiContext context) : base(context)
        {
                _context = context;
        }
}
