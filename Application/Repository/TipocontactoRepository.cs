using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class TipocontactoRepository : GenericRepository<Tipocontacto>, ITipocontacto
{
        private readonly ApiContext _context;
        public TipocontactoRepository(ApiContext context) : base(context)
        {
                _context = context;
        }
}
