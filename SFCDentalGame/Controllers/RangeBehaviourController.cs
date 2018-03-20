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
    public class RangeBehaviourController : Controller
    {
        private readonly SFCContext _context;

        public RangeBehaviourController(SFCContext context)
        {
            _context = context;
        }

        // GET: RangeBehaviour
        public async Task<IActionResult> Index()
        {
            var sFCContext = _context.RangeBehaviours.Include(r => r.Category);
            return View(await sFCContext.ToListAsync());
        }

        // GET: RangeBehaviour/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rangeBehaviour = await _context.RangeBehaviours
                .Include(r => r.Category)
                .SingleOrDefaultAsync(m => m.BehaviourId == id);
            if (rangeBehaviour == null)
            {
                return NotFound();
            }

            return View(rangeBehaviour);
        }

        // GET: RangeBehaviour/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            return View();
        }

        // POST: RangeBehaviour/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Range,BehaviourId,BehaviourName,BehaviourDescription,BehaviourType,Points,ratings,ProffesionalComment,ImageUrl,CategoryId")] RangeBehaviour rangeBehaviour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rangeBehaviour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", rangeBehaviour.CategoryId);
            return View(rangeBehaviour);
        }

        // GET: RangeBehaviour/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rangeBehaviour = await _context.RangeBehaviours.SingleOrDefaultAsync(m => m.BehaviourId == id);
            if (rangeBehaviour == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", rangeBehaviour.CategoryId);
            return View(rangeBehaviour);
        }

        // POST: RangeBehaviour/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Range,BehaviourId,BehaviourName,BehaviourDescription,BehaviourType,Points,ratings,ProffesionalComment,ImageUrl,CategoryId")] RangeBehaviour rangeBehaviour)
        {
            if (id != rangeBehaviour.BehaviourId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rangeBehaviour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RangeBehaviourExists(rangeBehaviour.BehaviourId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", rangeBehaviour.CategoryId);
            return View(rangeBehaviour);
        }

        // GET: RangeBehaviour/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rangeBehaviour = await _context.RangeBehaviours
                .Include(r => r.Category)
                .SingleOrDefaultAsync(m => m.BehaviourId == id);
            if (rangeBehaviour == null)
            {
                return NotFound();
            }

            return View(rangeBehaviour);
        }

        // POST: RangeBehaviour/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rangeBehaviour = await _context.RangeBehaviours.SingleOrDefaultAsync(m => m.BehaviourId == id);
            _context.RangeBehaviours.Remove(rangeBehaviour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RangeBehaviourExists(int id)
        {
            return _context.RangeBehaviours.Any(e => e.BehaviourId == id);
        }
    }
}
