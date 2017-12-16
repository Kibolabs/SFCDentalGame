using System;
using SFCDentalGame.DAL.Interfaces;
using System.Collections;
using SFCDentalGame.DAL.Entities;
using System.Collections.Generic;

namespace SFCDentalGame.DAL.Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly SFCContext _context;
        public CategoryRepository(SFCContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> Categories => _context.Categories;
    }
}
