using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class ContactoperRepository : GenericRepository<Contactoper>, IContactoper
{
        private readonly ApiContext _context;
        public ContactoperRepository(ApiContext context) : base(context)
        {
                _context = context;
        }
}
