using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sistem_Point_Of_Sales.Models;

namespace Sistem_Point_Of_Sales.Controllers
{
    public class ProductTagsController : Controller
    {
        private readonly AppDbClass _context;

        public ProductTagsController(AppDbClass context)
        {
            _context = context;
        }

        // GET: ProductTags
        public async Task<IActionResult> Index()
        {
            var appDbClass = _context.ProductTags.Include(p => p.Products).Include(p => p.Tags);
            return View(await appDbClass.ToListAsync());
        }

        // GET: ProductTags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductTags == null)
            {
                return NotFound();
            }

            var productTags = await _context.ProductTags
                .Include(p => p.Products)
                .Include(p => p.Tags)
                .FirstOrDefaultAsync(m => m.ProductsId == id);
            if (productTags == null)
            {
                return NotFound();
            }

            return View(productTags);
        }

        // GET: ProductTags/Create
        public IActionResult Create()
        {
            ViewData["ProductsId"] = new SelectList(_context.Products, "Id", "Id");
            ViewData["TagsId"] = new SelectList(_context.Tags, "Id", "Id");
            return View();
        }

        // POST: ProductTags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductsId,TagsId")] ProductTags productTags)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productTags);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductsId"] = new SelectList(_context.Products, "Id", "Id", productTags.ProductsId);
            ViewData["TagsId"] = new SelectList(_context.Tags, "Id", "Id", productTags.TagsId);
            return View(productTags);
        }

        // GET: ProductTags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductTags == null)
            {
                return NotFound();
            }

            var productTags = await _context.ProductTags.FindAsync(id);
            if (productTags == null)
            {
                return NotFound();
            }
            ViewData["ProductsId"] = new SelectList(_context.Products, "Id", "Id", productTags.ProductsId);
            ViewData["TagsId"] = new SelectList(_context.Tags, "Id", "Id", productTags.TagsId);
            return View(productTags);
        }

        // POST: ProductTags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductsId,TagsId")] ProductTags productTags)
        {
            if (id != productTags.ProductsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productTags);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductTagsExists(productTags.ProductsId))
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
            ViewData["ProductsId"] = new SelectList(_context.Products, "Id", "Id", productTags.ProductsId);
            ViewData["TagsId"] = new SelectList(_context.Tags, "Id", "Id", productTags.TagsId);
            return View(productTags);
        }

        // GET: ProductTags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductTags == null)
            {
                return NotFound();
            }

            var productTags = await _context.ProductTags
                .Include(p => p.Products)
                .Include(p => p.Tags)
                .FirstOrDefaultAsync(m => m.ProductsId == id);
            if (productTags == null)
            {
                return NotFound();
            }

            return View(productTags);
        }

        // POST: ProductTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductTags == null)
            {
                return Problem("Entity set 'AppDbClass.ProductTags'  is null.");
            }
            var productTags = await _context.ProductTags.FindAsync(id);
            if (productTags != null)
            {
                _context.ProductTags.Remove(productTags);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductTagsExists(int id)
        {
          return (_context.ProductTags?.Any(e => e.ProductsId == id)).GetValueOrDefault();
        }
    }
}
