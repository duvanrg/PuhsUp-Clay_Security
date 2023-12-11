using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class CategoriaperRepository : GenericRepository<Categoriaper>, ICategoriaper
{
    private readonly ApiContext _context;
    public CategoriaperRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
}
