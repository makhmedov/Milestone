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
    public class UsersRolesMapsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersRolesMapsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UsersRolesMaps
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserRolesMap.ToListAsync());
        }

        // GET: UsersRolesMaps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersRolesMap = await _context.UserRolesMap
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usersRolesMap == null)
            {
                return NotFound();
            }

            return View(usersRolesMap);
        }

        // GET: UsersRolesMaps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UsersRolesMaps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,RoleId")] UsersRolesMap usersRolesMap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usersRolesMap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usersRolesMap);
        }

        // GET: UsersRolesMaps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersRolesMap = await _context.UserRolesMap.FindAsync(id);
            if (usersRolesMap == null)
            {
                return NotFound();
            }
            return View(usersRolesMap);
        }

        // POST: UsersRolesMaps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,RoleId")] UsersRolesMap usersRolesMap)
        {
            if (id != usersRolesMap.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usersRolesMap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersRolesMapExists(usersRolesMap.Id))
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
            return View(usersRolesMap);
        }

        // GET: UsersRolesMaps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersRolesMap = await _context.UserRolesMap
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usersRolesMap == null)
            {
                return NotFound();
            }

            return View(usersRolesMap);
        }

        // POST: UsersRolesMaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usersRolesMap = await _context.UserRolesMap.FindAsync(id);
            _context.UserRolesMap.Remove(usersRolesMap);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersRolesMapExists(int id)
        {
            return _context.UserRolesMap.Any(e => e.Id == id);
        }
    }
}
