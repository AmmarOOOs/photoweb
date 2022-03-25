using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlowerShop.Data;
using FlowerShop.Models;

namespace FlowerShop.Controllers
{
    public class OrderProdsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderProdsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrderProds
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrderProd.ToListAsync());
        }

        // GET: OrderProds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderProd = await _context.OrderProd
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderProd == null)
            {
                return NotFound();
            }

            return View(orderProd);
        }

        // GET: OrderProds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderProds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Order_Id,FlowerBou_Id")] OrderProd orderProd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderProd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderProd);
        }

        // GET: OrderProds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderProd = await _context.OrderProd.FindAsync(id);
            if (orderProd == null)
            {
                return NotFound();
            }
            return View(orderProd);
        }

        // POST: OrderProds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Order_Id,FlowerBou_Id")] OrderProd orderProd)
        {
            if (id != orderProd.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderProd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderProdExists(orderProd.Id))
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
            return View(orderProd);
        }

        // GET: OrderProds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderProd = await _context.OrderProd
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderProd == null)
            {
                return NotFound();
            }

            return View(orderProd);
        }

        // POST: OrderProds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderProd = await _context.OrderProd.FindAsync(id);
            _context.OrderProd.Remove(orderProd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderProdExists(int id)
        {
            return _context.OrderProd.Any(e => e.Id == id);
        }
    }
}
