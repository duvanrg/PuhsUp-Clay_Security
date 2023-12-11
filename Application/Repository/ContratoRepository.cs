using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class ContratoRepository : GenericRepository<Contrato>, IContrato
{
        private readonly ApiContext _context;
        public ContratoRepository(ApiContext context) : base(context)
        {
                _context = context;
        }
}
