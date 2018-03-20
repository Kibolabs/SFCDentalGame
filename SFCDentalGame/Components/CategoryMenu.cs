using System;
using Microsoft.AspNetCore.Mvc;
using SFCDentalGame.DAL;
using System.Linq;
namespace SFCDentalGame.Components
{
    public class CategoryMenu:ViewComponent
    {
        private readonly SFCContext  _context;
        public CategoryMenu(SFCContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke(){
            var categories = _context.Categories.OrderBy(c => c.CategoryId);
            return View(categories);
        }
    }
}
