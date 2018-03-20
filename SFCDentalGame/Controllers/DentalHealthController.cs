using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SFCDentalGame.DAL;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using SFCDentalGame.DAL.Interfaces;
using SFCDentalGame.Models;
using Microsoft.EntityFrameworkCore;
using SFCDentalGame.DAL.Entities;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using SQLitePCL;
using System.ComponentModel;

namespace SFCDentalGame.Controllers
{
    public class DentalHealthController : Controller
    {
        private readonly DentalPractice _practices;
        private readonly SFCContext _context;

        public DentalHealthController(SFCContext context, DentalPractice practices)
        {
            _context = context;
            _practices = practices;
        }

        //[Authorize]
        // GET: /<controller>/
        public IActionResult SubmitPractices()
        {
            return View();
        }
        //[Authorize]
        [HttpPost]
        public IActionResult SubmitPractices(DentalHealth dentalHealth)
        {
            var items = _practices.GetDentalPracticeItems();
            _practices.PracticeItems = items;
            if (_practices.PracticeItems.Count == 0)
            {
                ModelState.AddModelError("", "Your practice is empty, add some Behaviours first");
            }

            if (ModelState.IsValid)
            {
                dentalHealth.PracticeSubmitTime = DateTime.Now;
                dentalHealth.TotalScore = _practices.GetTotolScore();
                _context.DentalHealth.Add(dentalHealth);

                var practiceItems = _practices.PracticeItems;
                foreach (var item in practiceItems)
                {
                    var healthDetail = new DentalHealthDetail()
                    {
                        Points = item.Behaviour.Points,
                        BehaviourId = item.Behaviour.BehaviourId,
                        DentalHealthId = dentalHealth.DentalHealthId,

                    };
                    _context.DentalHealthDetails.Add(healthDetail);
                }
                _context.SaveChanges();
                //_practices.ClearPractices();
                return RedirectToAction("PracticesComplete");
            }

            return View(dentalHealth);  
        }

        public IActionResult PracticesComplete()
        {
            var items = _practices.GetDentalPracticeItems();
            _practices.PracticeItems = items;

            ViewBag.MyPractice = items;

            _practices.ClearPractices();

            return View();


        }
    }
}
