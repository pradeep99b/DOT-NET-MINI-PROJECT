using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MedLab.Data;
using MedLab.Models;

namespace MedLab.Controllers
{
    public class LabAssistantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LabAssistantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LabAssistants
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LabAssistant.Include(l => l.Department);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LabAssistants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labAssistant = await _context.LabAssistant
                .Include(l => l.Department)
                .FirstOrDefaultAsync(m => m.LabAssistantId == id);
            if (labAssistant == null)
            {
                return NotFound();
            }

            return View(labAssistant);
        }

        // GET: LabAssistants/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName");
            return View();
        }

        // POST: LabAssistants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LabAssistantId,Name,DepartmentId")] LabAssistant labAssistant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(labAssistant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName", labAssistant.DepartmentId);
            return View(labAssistant);
        }

        // GET: LabAssistants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labAssistant = await _context.LabAssistant.FindAsync(id);
            if (labAssistant == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName", labAssistant.DepartmentId);
            return View(labAssistant);
        }

        // POST: LabAssistants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LabAssistantId,Name,DepartmentId")] LabAssistant labAssistant)
        {
            if (id != labAssistant.LabAssistantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(labAssistant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabAssistantExists(labAssistant.LabAssistantId))
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
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName", labAssistant.DepartmentId);
            return View(labAssistant);
        }

        // GET: LabAssistants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labAssistant = await _context.LabAssistant
                .Include(l => l.Department)
                .FirstOrDefaultAsync(m => m.LabAssistantId == id);
            if (labAssistant == null)
            {
                return NotFound();
            }

            return View(labAssistant);
        }

        // POST: LabAssistants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var labAssistant = await _context.LabAssistant.FindAsync(id);
            if (labAssistant != null)
            {
                _context.LabAssistant.Remove(labAssistant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabAssistantExists(int id)
        {
            return _context.LabAssistant.Any(e => e.LabAssistantId == id);
        }
    }
}
