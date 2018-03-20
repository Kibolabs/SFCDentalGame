using System;
using Microsoft.AspNetCore.Mvc;
using SFCDentalGame.DAL;
using SFCDentalGame.Models;
using System.Collections.Generic;
using System.Linq;
using SFCDentalGame.DAL.Entities;

namespace SFCDentalGame.Components
{
    public class CustomChart: ViewComponent
    {
        private readonly DentalPractice _practices;
        public CustomChart(DentalPractice practices)
        {
            _practices = practices;
        }
        public IViewComponentResult Invoke()
        {
            var list = _practices.GetDentalPracticeItems().ToList();
            List<int> ocurances = new List<int>();
            var good = list.Select(c => c.Behaviour.ratings).Distinct();
            foreach(var item in good){
                ocurances.Add(list.Count(c=> c.Behaviour.ratings == item));
            }
            var oc = ocurances;
            ViewBag.GOOD = good;
            ViewBag.OCCURANCE = ocurances.ToList();
            return View();

        }
    }
}
