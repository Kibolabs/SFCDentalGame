using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using SFCDentalGame.DAL;
using SFCDentalGame.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace SFCDentalGame.Components
{
    public class ChartView:ViewComponent
    {
        private readonly SFCContext _context;
        private readonly DentalPractice _practices;
        public ChartView(SFCContext context, DentalPractice practices)
        {
            _context = context;
            _practices = practices;
        }

        public IViewComponentResult Invoke()
        {
            var list = _context.DentalHealth.ToList().Take(5).OrderByDescending(s=>s.TotalScore);
            List<int> Occurances = new List<int>();
            var category = list.Select(x => x.TotalScore).Distinct();
            foreach (var item in category)
            {
                Occurances.Add(list.Count(x => x.TotalScore == item));
            }
            var oc = Occurances;
            ViewBag.Category = category;
            ViewBag.Occur = Occurances.ToList();

            return View();

        }
    }
}
