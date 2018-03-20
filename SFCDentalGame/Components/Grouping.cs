using System;
using Microsoft.AspNetCore.Mvc;
using SFCDentalGame.DAL;
using System.Linq;
using SQLitePCL;
using SFCDentalGame.DAL.Entities;
using System.Collections.Generic;

namespace SFCDentalGame.Components
{
    public class Grouping:ViewComponent
    {
        private readonly SFCContext _context;
        public Grouping(SFCContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var query = _context.Behaviours.GroupBy(pet => pet.BehaviourType, pet => pet.BehaviourName);

            //var groups = _context.Behaviours.GroupBy(c => c.BehaviourType, c=>c.BehaviourName).Select(c=>c.First()).ToList();
            ViewBag.gr = query;
            return View();
        }
    }
}
