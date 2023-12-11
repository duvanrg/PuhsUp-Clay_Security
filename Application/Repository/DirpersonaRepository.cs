using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class DirpersonaRepository : GenericRepository<Dirpersona>, IDirpersona
{
        private readonly ApiContext _context;
        public DirpersonaRepository(ApiContext context) : base(context)
        {
                _context = context;
        }
}
