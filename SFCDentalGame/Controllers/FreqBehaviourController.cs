using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SFCDentalGame.DAL;
using SFCDentalGame.DAL.Entities;

namespace SFCDentalGame.Controllers
{
    public class FreqBehaviourController : Controller
    {
        private readonly SFCContext _context;

        public FreqBehaviourController(SFCContext context)
        {
            _context = context;
        }

        // GET: FreqBehaviour
        public async Task<IActionResult> Index()
        {
            var sFCContext = _context.FrequencyBehaviours.Include(f => f.Category);
            return View(await sFCContext.ToListAsync());
        }

        // GET: FreqBehaviour/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freqBehaviour = await _context.FrequencyBehaviours
                .Include(f => f.Category)
                .SingleOrDefaultAsync(m => m.BehaviourId == id);
            if (freqBehaviour == null)
            {
                return NotFound();
            }

            return View(freqBehaviour);
        }

        // GET: FreqBehaviour/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            return View();
        }

        // POST: FreqBehaviour/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsageBehaviour,OtherSupporting,LongerPractices,BehaviourId,BehaviourName,BehaviourDescription,BehaviourType,Points,ratings,ProffesionalComment,ImageUrl,CategoryId")] FreqBehaviour freqBehaviour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(freqBehaviour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", freqBehaviour.CategoryId);
            return View(freqBehaviour);
        }

        // GET: FreqBehaviour/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freqBehaviour = await _context.FrequencyBehaviours.SingleOrDefaultAsync(m => m.BehaviourId == id);
            if (freqBehaviour == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", freqBehaviour.CategoryId);
            return View(freqBehaviour);
        }

        // POST: FreqBehaviour/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsageBehaviour,OtherSupporting,LongerPractices,BehaviourId,BehaviourName,BehaviourDescription,BehaviourType,Points,ratings,ProffesionalComment,ImageUrl,CategoryId")] FreqBehaviour freqBehaviour)
        {
            if (id != freqBehaviour.BehaviourId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(freqBehaviour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FreqBehaviourExists(freqBehaviour.BehaviourId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", freqBehaviour.CategoryId);
            return View(freqBehaviour);
        }

        // GET: FreqBehaviour/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freqBehaviour = await _context.FrequencyBehaviours
                .Include(f => f.Category)
                .SingleOrDefaultAsync(m => m.BehaviourId == id);
            if (freqBehaviour == null)
            {
                return NotFound();
            }

            return View(freqBehaviour);
        }

        // POST: FreqBehaviour/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var freqBehaviour = await _context.FrequencyBehaviours.SingleOrDefaultAsync(m => m.BehaviourId == id);
            _context.FrequencyBehaviours.Remove(freqBehaviour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FreqBehaviourExists(int id)
        {
            return _context.FrequencyBehaviours.Any(e => e.BehaviourId == id);
        }
    }
}
