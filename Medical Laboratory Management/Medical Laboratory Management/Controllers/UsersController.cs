using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Medical_Laboratory_Management.Data;
using Medical_Laboratory_Management.Models;

namespace Medical_Laboratory_Management.Controllers
{
    public class UsersController : Controller
    {
        private readonly LabDbContext _context;

        public UsersController(LabDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult GetCities(int stateId)
        {
            var cities = _context.Cities
                                 .Where(c => c.StateId == stateId)
                                 .Select(c => new { c.CityId, c.CityName })
                                 .ToList();
            return Json(cities);
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var labDbContext = _context.Users.Include(u => u.City).Include(u => u.State);
            return View(await labDbContext.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.City)
                .Include(u => u.State)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewBag.States = new SelectList(_context.States, "StateId", "StateName");
            ViewBag.Genders = new SelectList(Enum.GetValues(typeof(Gender)).Cast<Gender>().Select(g => new
            {
                Value = (int)g,
                Text = g.ToString()
            }).ToList(), "Value", "Text");
            ViewBag.BloodGroups = new SelectList(Enum.GetValues(typeof(BloodGroup)).Cast<BloodGroup>().Select(bg => new
            {
                Value = (int)bg,
                Text = bg.ToString()
            }).ToList(), "Value", "Text");
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Age,Gender,PhoneNumber,Email,Password,Address,StateId,CityId,BloodGroup")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.States = new SelectList(_context.States, "StateId", "StateName", user.StateId);

            ViewBag.Genders = new SelectList(Enum.GetValues(typeof(Gender)).Cast<Gender>().Select(g => new
            {
                Value = (int)g,
                Text = g.ToString()
            }).ToList(), "Value", "Text");
            ViewBag.BloodGroups = new SelectList(Enum.GetValues(typeof(BloodGroup)).Cast<BloodGroup>().Select(bg => new
            {
                Value = (int)bg,
                Text = bg.ToString()
            }).ToList(), "Value", "Text");
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewBag.States = new SelectList(_context.States, "StateId", "StateName", user.StateId);

            ViewBag.Genders = new SelectList(Enum.GetValues(typeof(Gender)).Cast<Gender>().Select(g => new
            {
                Value = (int)g,
                Text = g.ToString()
            }).ToList(), "Value", "Text");
            ViewBag.BloodGroups = new SelectList(Enum.GetValues(typeof(BloodGroup)).Cast<BloodGroup>().Select(bg => new
            {
                Value = (int)bg,
                Text = bg.ToString()
            }).ToList(), "Value", "Text");
            return View(user);

        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Age,Gender,PhoneNumber,Email,Password,Address,StateId,CityId,BloodGroup")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            ViewBag.States = new SelectList(_context.States, "StateId", "StateName", user.StateId);
            ViewBag.Genders = new SelectList(Enum.GetValues(typeof(Gender)).Cast<Gender>().Select(g => new
            {
                Value = (int)g,
                Text = g.ToString()
            }).ToList(), "Value", "Text");
            ViewBag.BloodGroups = new SelectList(Enum.GetValues(typeof(BloodGroup)).Cast<BloodGroup>().Select(bg => new
            {
                Value = (int)bg,
                Text = bg.ToString()
            }).ToList(), "Value", "Text");
            return View(user);

        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.City)
                .Include(u => u.State)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
