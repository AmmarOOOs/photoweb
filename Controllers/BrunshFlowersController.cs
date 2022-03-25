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
    public class BrunshFlowersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BrunshFlowersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BrunshFlowers
        public async Task<IActionResult> Index()
        {
            return View(await _context.BrunshFlower.ToListAsync());
        }

        // GET: BrunshFlowers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brunshFlower = await _context.BrunshFlower
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brunshFlower == null)
            {
                return NotFound();
            }

            return View(brunshFlower);
        }

        // GET: BrunshFlowers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BrunshFlowers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brunsh_Id,FlowerBou_Id")] BrunshFlower brunshFlower)
        {
            if (ModelState.IsValid)
            {
                _context.Add(brunshFlower);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brunshFlower);
        }

        // GET: BrunshFlowers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brunshFlower = await _context.BrunshFlower.FindAsync(id);
            if (brunshFlower == null)
            {
                return NotFound();
            }
            return View(brunshFlower);
        }

        // POST: BrunshFlowers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brunsh_Id,FlowerBou_Id")] BrunshFlower brunshFlower)
        {
            if (id != brunshFlower.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brunshFlower);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrunshFlowerExists(brunshFlower.Id))
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
            return View(brunshFlower);
        }

        // GET: BrunshFlowers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brunshFlower = await _context.BrunshFlower
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brunshFlower == null)
            {
                return NotFound();
            }

            return View(brunshFlower);
        }

        // POST: BrunshFlowers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var brunshFlower = await _context.BrunshFlower.FindAsync(id);
            _context.BrunshFlower.Remove(brunshFlower);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrunshFlowerExists(int id)
        {
            return _context.BrunshFlower.Any(e => e.Id == id);
        }
    }
}
