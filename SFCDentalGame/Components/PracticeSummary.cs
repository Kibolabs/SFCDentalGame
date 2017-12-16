using System;
using Microsoft.AspNetCore.Mvc;
using SFCDentalGame.DAL;
using SFCDentalGame.Models;
using System.Reflection.Metadata.Ecma335;
namespace SFCDentalGame.Components
{
    public class PracticeSummary:ViewComponent
    {
        private readonly DentalPractice _practices;
        public PracticeSummary(DentalPractice practices)
        {
            _practices = practices;
        }
        public IViewComponentResult Invoke()
        {
            var items = _practices.GetDentalPracticeItems();
            _practices.PracticeItems = items;

            var practicesViewModel = new PracticeViewModel
            {
                DentalPractice = _practices,
                TotalPoints = _practices.GetTotolScore()
        };
            return View(practicesViewModel);
        }
    }
}
