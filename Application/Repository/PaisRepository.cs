using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class PaisRepository : GenericRepository<Pais>, IPais
{
        private readonly ApiContext _context;
        public PaisRepository(ApiContext context) : base(context)
        {
                _context = context;
        }
}
