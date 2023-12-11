using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class TurnoRepository : GenericRepository<Turno>, ITurno
{
        private readonly ApiContext _context;
        public TurnoRepository(ApiContext context) : base(context)
        {
                _context = context;
        }
}
