using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using SFCDentalGame.Models;
using SFCDentalGame.DAL;

namespace SFCDentalGame.Controllers
{
    public class PracticeController : Controller
    {
        private readonly DentalPractice _dentalPractice;
        private readonly SFCContext _context;

        public PracticeController(DentalPractice dentalPractice, SFCContext context){
            _context = context;
            _dentalPractice = dentalPractice;
        }
        public ViewResult Index()
        {
            var Items = _dentalPractice.GetDentalPracticeItems();
            _dentalPractice.PracticeItems = Items;
            var dPVM = new PracticeViewModel
            {
                DentalPractice = _dentalPractice,
                TotalPoints = _dentalPractice.GetTotolScore()
            };
            return View(dPVM);
        }
        public RedirectToActionResult AddToDentalPractice(int behaviourId){
            var selectedBehaviour = _context.Behaviours.FirstOrDefault(p => p.BehaviourId == behaviourId);
            if(selectedBehaviour!=null){
                _dentalPractice.AddToPractice(selectedBehaviour, 1);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromPractice(int behaviourId){
            var selectedBehaviour = _context.Behaviours.FirstOrDefault(p => p.BehaviourId == behaviourId);
            if(selectedBehaviour!=null){
                _dentalPractice.RemoveFromPractice(selectedBehaviour);
            }
            return RedirectToAction("Index");
        }
        
    }
}
