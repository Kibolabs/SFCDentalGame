using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SFCDentalGame.DAL;

namespace SFCDentalGame.Components
{
    public class LeaderBoard:ViewComponent
    {
        private readonly SFCContext _context;
        public LeaderBoard(SFCContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var items = _context.DentalHealth
                       .OrderByDescending(sc => sc.TotalScore)
                       .ThenBy(lb => lb.PracticeSubmitTime)
                       .Take(5).ToList();
            ViewBag.lb = items;
            return View();
        }
    }
}
