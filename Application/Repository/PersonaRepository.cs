using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class PersonaRepository : GenericRepository<Persona>, IPersona
{
        private readonly ApiContext _context;
        public PersonaRepository(ApiContext context) : base(context)
        {
                _context = context;
        }
}
