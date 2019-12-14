using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoT.Data;
using AutoT.Models;

namespace AutoT.Controllers
{
    public class ServiceMaintancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceMaintancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ServiceMaintances
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ServiceMaintance.Include(s => s.Rating);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ServiceMaintances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceMaintance = await _context.ServiceMaintance
                .Include(s => s.Rating)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceMaintance == null)
            {
                return NotFound();
            }

            return View(serviceMaintance);
        }

        // GET: ServiceMaintances/Create
        public IActionResult Create()
        {
            ViewData["RatingId"] = new SelectList(_context.Rating, "Id", "Id");
            return View();
        }

        // POST: ServiceMaintances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Address,PhoneNumber,RatingId")] ServiceMaintance serviceMaintance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceMaintance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RatingId"] = new SelectList(_context.Rating, "Id", "Id", serviceMaintance.RatingId);
            return View(serviceMaintance);
        }

        // GET: ServiceMaintances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceMaintance = await _context.ServiceMaintance.FindAsync(id);
            if (serviceMaintance == null)
            {
                return NotFound();
            }
            ViewData["RatingId"] = new SelectList(_context.Rating, "Id", "Id", serviceMaintance.RatingId);
            return View(serviceMaintance);
        }

        // POST: ServiceMaintances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Address,PhoneNumber,RatingId")] ServiceMaintance serviceMaintance)
        {
            if (id != serviceMaintance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceMaintance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceMaintanceExists(serviceMaintance.Id))
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
            ViewData["RatingId"] = new SelectList(_context.Rating, "Id", "Id", serviceMaintance.RatingId);
            return View(serviceMaintance);
        }

        // GET: ServiceMaintances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceMaintance = await _context.ServiceMaintance
                .Include(s => s.Rating)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceMaintance == null)
            {
                return NotFound();
            }

            return View(serviceMaintance);
        }

        // POST: ServiceMaintances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceMaintance = await _context.ServiceMaintance.FindAsync(id);
            _context.ServiceMaintance.Remove(serviceMaintance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceMaintanceExists(int id)
        {
            return _context.ServiceMaintance.Any(e => e.Id == id);
        }
    }
}
