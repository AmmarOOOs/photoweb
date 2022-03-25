using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlowerShop.Data;
using Microsoft.AspNetCore.Authorization;

namespace FlowerShop.Models
{
    public class FlowerBousController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FlowerBousController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FlowerBous
        public async Task<IActionResult> Index()
        {




            return View(await _context.FlowerBou.ToListAsync());
        }







 

        public async Task<IActionResult> Search([FromQuery] int OccasionId = 0)
        {



            ViewBag.Occasions = _context.Occasion.Select(a =>
                                   new SelectListItem
                                   {
                                       Value = a.Id.ToString(),
                                       Text = a.Name
                                   }).ToList();



           

            if (OccasionId > 0)
            {
                //var BouIds = _context.FlowerBou.Where(x => x.Occasion_Id == Occasion_Id).Select(x => x.PhotographerId).ToListAsync();
            }





            return View(await _context.FlowerBou.ToListAsync());
        }



        // GET: FlowerBous/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flowerBou = await _context.FlowerBou
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flowerBou == null)
            {
                return NotFound();
            }

            return View(flowerBou);
        }

        // GET: FlowerBous/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Flower([FromQuery] int OccasionId = 0)
        {
            ViewBag.Occasions = _context.Occasion.Select(a =>
                                new SelectListItem
                                {
                                    Value = a.Id.ToString(),
                                    Text = a.Name
                                }).ToList();

           
            var flowers = _context.FlowerBou.ToList();

            if (OccasionId != 0) {
                flowers = flowers.Where(x => x.Occasion_Id == OccasionId).ToList();
            }

                return View(flowers);
        }
        // POST: FlowerBous/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImageUrl,Name,Code,Price,Description,Occasion_Id")] FlowerBou flowerBou)
        {
           

            if (ModelState.IsValid)
            {
                _context.Add(flowerBou);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flowerBou);
        }

        // GET: FlowerBous/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flowerBou = await _context.FlowerBou.FindAsync(id);
            if (flowerBou == null)
            {
                return NotFound();
            }
            return View(flowerBou);
        }

        // POST: FlowerBous/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImageUrl,Name,Code,Price,Description,Occasion_Id")] FlowerBou flowerBou)
        {
            if (id != flowerBou.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flowerBou);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlowerBouExists(flowerBou.Id))
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
            return View(flowerBou);
        }

        // GET: FlowerBous/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flowerBou = await _context.FlowerBou
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flowerBou == null)
            {
                return NotFound();
            }

            return View(flowerBou);
        }

        // POST: FlowerBous/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flowerBou = await _context.FlowerBou.FindAsync(id);
            _context.FlowerBou.Remove(flowerBou);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlowerBouExists(int id)
        {
            return _context.FlowerBou.Any(e => e.Id == id);
        }
    }
}
