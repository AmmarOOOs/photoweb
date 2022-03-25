using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlowerShop.Data;

namespace FlowerShop.Models
{
    public class BrunshesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BrunshesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Brunshes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Brunsh.ToListAsync());
        }

        // GET: Brunshes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brunsh = await _context.Brunsh
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brunsh == null)
            {
                return NotFound();
            }

            return View(brunsh);
        }

        // GET: Brunshes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Brunshes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Address,phone")] Brunsh brunsh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(brunsh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brunsh);
        }

        // GET: Brunshes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brunsh = await _context.Brunsh.FindAsync(id);
            if (brunsh == null)
            {
                return NotFound();
            }
            return View(brunsh);
        }

        // POST: Brunshes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Address,phone")] Brunsh brunsh)
        {
            if (id != brunsh.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brunsh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrunshExists(brunsh.Id))
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
            return View(brunsh);
        }

        // GET: Brunshes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brunsh = await _context.Brunsh
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brunsh == null)
            {
                return NotFound();
            }

            return View(brunsh);
        }

        // POST: Brunshes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var brunsh = await _context.Brunsh.FindAsync(id);
            _context.Brunsh.Remove(brunsh);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrunshExists(int id)
        {
            return _context.Brunsh.Any(e => e.Id == id);
        }
    }
}
