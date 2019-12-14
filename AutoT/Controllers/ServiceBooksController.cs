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
    public class ServiceBooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceBooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ServiceBooks
        public async Task<IActionResult> Index()
        {
            return View(await _context.ServiceBook.ToListAsync());
        }

        // GET: ServiceBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceBook = await _context.ServiceBook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceBook == null)
            {
                return NotFound();
            }

            return View(serviceBook);
        }

        // GET: ServiceBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Name,UserId")] ServiceBook serviceBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceBook);
        }

        // GET: ServiceBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceBook = await _context.ServiceBook.FindAsync(id);
            if (serviceBook == null)
            {
                return NotFound();
            }
            return View(serviceBook);
        }

        // POST: ServiceBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Name,UserId")] ServiceBook serviceBook)
        {
            if (id != serviceBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceBookExists(serviceBook.Id))
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
            return View(serviceBook);
        }

        // GET: ServiceBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceBook = await _context.ServiceBook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceBook == null)
            {
                return NotFound();
            }

            return View(serviceBook);
        }

        // POST: ServiceBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceBook = await _context.ServiceBook.FindAsync(id);
            _context.ServiceBook.Remove(serviceBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceBookExists(int id)
        {
            return _context.ServiceBook.Any(e => e.Id == id);
        }
    }
}
