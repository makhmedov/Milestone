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
    public class ServiceBookContentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceBookContentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ServiceBookContents
        public async Task<IActionResult> Index()
        {
            return View(await _context.ServiceBookContent.ToListAsync());
        }

        // GET: ServiceBookContents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceBookContent = await _context.ServiceBookContent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceBookContent == null)
            {
                return NotFound();
            }

            return View(serviceBookContent);
        }

        // GET: ServiceBookContents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceBookContents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MechanicsUserId,Content,duration,RaServiceBookIdtingId")] ServiceBookContent serviceBookContent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceBookContent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceBookContent);
        }

        // GET: ServiceBookContents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceBookContent = await _context.ServiceBookContent.FindAsync(id);
            if (serviceBookContent == null)
            {
                return NotFound();
            }
            return View(serviceBookContent);
        }

        // POST: ServiceBookContents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MechanicsUserId,Content,duration,RaServiceBookIdtingId")] ServiceBookContent serviceBookContent)
        {
            if (id != serviceBookContent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceBookContent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceBookContentExists(serviceBookContent.Id))
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
            return View(serviceBookContent);
        }

        // GET: ServiceBookContents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceBookContent = await _context.ServiceBookContent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceBookContent == null)
            {
                return NotFound();
            }

            return View(serviceBookContent);
        }

        // POST: ServiceBookContents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceBookContent = await _context.ServiceBookContent.FindAsync(id);
            _context.ServiceBookContent.Remove(serviceBookContent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceBookContentExists(int id)
        {
            return _context.ServiceBookContent.Any(e => e.Id == id);
        }
    }
}
