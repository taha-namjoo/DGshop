using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Degishop.Data;
using Degishop.Models;

namespace Degishop.Controllers
{
    public class PC_AND_LaptopController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PC_AND_LaptopController(ApplicationDbContext context) => _context = context;
        
        public async Task<IActionResult> Index(string sortCost)
        {
            ViewData["CostSortParam"] = sortCost == "Cost" ? "cost_desc" : "Cost";

            var pls = from Cost in _context.PC_AND_Laptop.Include(c=>c.Brands) select Cost;

            switch (sortCost)
            {
                case "cost_desc":
                    pls = pls.OrderByDescending(pl => pl.Cost);
                    break;
                case "Cost":
                    pls = pls.OrderBy(pl => pl.Cost);
                    break;
                default:
                    pls = pls.OrderBy(pl => pl.Cost);
                    break;
            }
            return View(await pls.AsNoTracking().ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pC_AND_Laptop = await _context.PC_AND_Laptop
                .Include(p => p.Brands)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pC_AND_Laptop == null)
            {
                return NotFound();
            }

            return View(pC_AND_Laptop);
        }

        public IActionResult Create()
        {
            ViewData["BrandsId"] = new SelectList(_context.Brands, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,model_name,Cost,details,CPU,RAM,Graphic,BrandsId")] PC_AND_Laptop pC_AND_Laptop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pC_AND_Laptop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandsId"] = new SelectList(_context.Brands, "Id", "Id", pC_AND_Laptop.BrandsId);
            return View(pC_AND_Laptop);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pC_AND_Laptop = await _context.PC_AND_Laptop.FindAsync(id);
            if (pC_AND_Laptop == null)
            {
                return NotFound();
            }
            ViewData["BrandsId"] = new SelectList(_context.Brands, "Id", "Name", pC_AND_Laptop.BrandsId);
            return View(pC_AND_Laptop);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,model_name,Cost,details,CPU,RAM,Graphic,BrandsId")] PC_AND_Laptop pC_AND_Laptop)
        {
            if (id != pC_AND_Laptop.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pC_AND_Laptop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PC_AND_LaptopExists(pC_AND_Laptop.Id))
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
            ViewData["BrandsId"] = new SelectList(_context.Brands, "Id", "Id", pC_AND_Laptop.BrandsId);
            return View(pC_AND_Laptop);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pC_AND_Laptop = await _context.PC_AND_Laptop
                .Include(p => p.Brands)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pC_AND_Laptop == null)
            {
                return NotFound();
            }

            return View(pC_AND_Laptop);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pCandlaptop = await _context.PC_AND_Laptop.FindAsync(id);
            _context.PC_AND_Laptop.Remove(pCandlaptop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> search(string searchPhrase)
        {
            ViewData["CurrentSearch"] = searchPhrase;
            var pc_laptops = from model_name in this._context.PC_AND_Laptop select model_name;

            if (!searchPhrase.Equals(null))
            {
                pc_laptops = pc_laptops.Where(pl => pl.model_name.Contains(searchPhrase));
            }
            return View("Index", await pc_laptops.AsNoTracking().ToListAsync());
        }

        private bool PC_AND_LaptopExists(int id)
        {
            return _context.PC_AND_Laptop.Any(e => e.Id == id);
        }
    }
}
