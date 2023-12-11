using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class CiudadRepository : GenericRepository<Ciudad>, ICiudad
{
    private readonly ApiContext _context;

    public CiudadRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
}
