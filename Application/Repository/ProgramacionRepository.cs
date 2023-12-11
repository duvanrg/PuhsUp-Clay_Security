using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class ProgramacionRepository : GenericRepository<Programacion>, IProgramacion
{
        private readonly ApiContext _context;
        public ProgramacionRepository(ApiContext context) : base(context)
        {
                _context = context;
        }
}
