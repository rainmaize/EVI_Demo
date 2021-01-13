using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvc.Models;
using mvcbasic.Data;

namespace mvc.Controllers
{
    public class Recruitment_planController : Controller
    {
        private readonly MvcBasicDbContext _context;

        public Recruitment_planController(MvcBasicDbContext context)
        {
            _context = context;
        }

        // GET: Recruitment_plan
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recruitment_Plans.ToListAsync());
        }

        // GET: Recruitment_plan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recruitment_plan = await _context.Recruitment_Plans
                .FirstOrDefaultAsync(m => m.ID == id);
            if (recruitment_plan == null)
            {
                return NotFound();
            }

            return View(recruitment_plan);
        }

        // GET: Recruitment_plan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recruitment_plan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NUMBER_EMPLOYEE,POSSION_ID,dateTime,SALARY,DESCRIPTION")] Recruitment_plan recruitment_plan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recruitment_plan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recruitment_plan);
        }

        // GET: Recruitment_plan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
                
            }

            var recruitment_plan = await _context.Recruitment_Plans.FindAsync(id);
            if (recruitment_plan == null)
            {
                return NotFound();
            }
            return View(recruitment_plan);
        }

        // POST: Recruitment_plan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NUMBER_EMPLOYEE,POSSION_ID,dateTime,SALARY,DESCRIPTION")] Recruitment_plan recruitment_plan)
        {
            if (id != recruitment_plan.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recruitment_plan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Recruitment_planExists(recruitment_plan.ID))
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
            return View(recruitment_plan);
        }

        // GET: Recruitment_plan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recruitment_plan = await _context.Recruitment_Plans
                .FirstOrDefaultAsync(m => m.ID == id);
            if (recruitment_plan == null)
            {
                return NotFound();
            }

            return View(recruitment_plan);
        }

        // POST: Recruitment_plan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recruitment_plan = await _context.Recruitment_Plans.FindAsync(id);
            _context.Recruitment_Plans.Remove(recruitment_plan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Recruitment_planExists(int id)
        {
            return _context.Recruitment_Plans.Any(e => e.ID == id);
        }
    }
}
