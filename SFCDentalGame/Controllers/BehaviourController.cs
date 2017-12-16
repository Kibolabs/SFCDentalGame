using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SFCDentalGame.DAL;
using SFCDentalGame.DAL.Entities;
using SFCDentalGame.Models;

namespace SFCDentalGame.Controllers
{
    public class BehaviourController : Controller
    {
        private readonly SFCContext _context;

        public BehaviourController(SFCContext context)
        {
            _context = context;
        }
      //Returm List of Behaviours to player.
        public ViewResult List(string category){

            BehaviourListViewModel behaviour = new BehaviourListViewModel
            {
                Behaviours = _context.Behaviours
                                     .Where(b => category == null || b.Category.CategoryName==category)
                                     .OrderBy(b=>b.BehaviourId), CurrentCategory=category
            };
            return View(behaviour);

        }
        // GET: Behaviour
        public async Task<IActionResult> Index()
        {
            var sFCContext = _context.Behaviours.Include(b => b.Category);
            return View(await sFCContext.ToListAsync());
        }

        // GET: Behaviour/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var behaviour = await _context.Behaviours
                .Include(b => b.Category)
                .SingleOrDefaultAsync(m => m.BehaviourId == id);
            if (behaviour == null)
            {
                return NotFound();
            }

            return View(behaviour);
        }

        // GET: Behaviour/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            return View();
        }

        // POST: Behaviour/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BehaviourId,BehaviourName,BehaviourDescription,BehaviourType,Points,InPractice,value,CategoryId,Frequency")] Behaviour behaviour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(behaviour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", behaviour.CategoryId);
            return View(behaviour);
        }

        // GET: Behaviour/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var behaviour = await _context.Behaviours.SingleOrDefaultAsync(m => m.BehaviourId == id);
            if (behaviour == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", behaviour.CategoryId);
            return View(behaviour);
        }

        // POST: Behaviour/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BehaviourId,BehaviourName,BehaviourDescription,BehaviourType,Points,InPractice,value,CategoryId,Frequency")] Behaviour behaviour)
        {
            if (id != behaviour.BehaviourId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(behaviour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BehaviourExists(behaviour.BehaviourId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", behaviour.CategoryId);
            return View(behaviour);
        }

        // GET: Behaviour/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var behaviour = await _context.Behaviours
                .Include(b => b.Category)
                .SingleOrDefaultAsync(m => m.BehaviourId == id);
            if (behaviour == null)
            {
                return NotFound();
            }

            return View(behaviour);
        }

        // POST: Behaviour/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var behaviour = await _context.Behaviours.SingleOrDefaultAsync(m => m.BehaviourId == id);
            _context.Behaviours.Remove(behaviour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BehaviourExists(int id)
        {
            return _context.Behaviours.Any(e => e.BehaviourId == id);
        }
    }
}
