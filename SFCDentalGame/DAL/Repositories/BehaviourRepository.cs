using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SFCDentalGame.DAL.Entities;
using SFCDentalGame.DAL.Interfaces;

namespace SFCDentalGame.DAL.Repositories
{
    public class BehaviourRepository:IBehaviourRepository
    {
        private readonly SFCContext _context;

        public BehaviourRepository(SFCContext context)
        {
            _context = context;
        }

        public IEnumerable<Behaviour> Behaviours => _context.Behaviours.Include(c => c.Category);
        public Behaviour GetBehaviourById(int behaviourId) => _context.Behaviours.FirstOrDefault(s => s.BehaviourId == behaviourId);
    }
}
