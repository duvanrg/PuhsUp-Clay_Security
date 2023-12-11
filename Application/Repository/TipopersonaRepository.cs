using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class TipopersonaRepository : GenericRepository<Tipopersona>, ITipopersona
{
        private readonly ApiContext _context;
        public TipopersonaRepository(ApiContext context) : base(context)
        {
                _context = context;
        }
}
