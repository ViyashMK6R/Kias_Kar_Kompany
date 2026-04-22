using Kias_Kar_Kompany.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kias_Kar_Kompany.Models;

namespace Kias_Kar_Kompany.Controllers
{
    public class ManufacturersController : Controller
    {

        private readonly Kias_Kar_KompanyContext _context;

        public ManufacturersController(Kias_Kar_KompanyContext context)
        {
            _context = context;
        }

        // GET: ManufacturersController
        public async Task<ActionResult> Index()
        {
            return View(await _context.Manufacturer.ToListAsync());
        }

        
        // GET: ManufacturersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManufacturersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manufacturer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(manufacturer);
            
        }

        // GET: ManufacturersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Manufacturer manufacturer)
        {
            if (id != manufacturer.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manufacturer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManufacturerExists(manufacturer.Id))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(manufacturer);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var manufacturer = await _context.Manufacturer.FindAsync(id);

            if (manufacturer == null)
                return NotFound();

            return View(manufacturer);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var manufacturer = await _context.Manufacturer
                .FirstOrDefaultAsync(m => m.Id == id);

            if (manufacturer == null)
                return NotFound();

            return View(manufacturer);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var manufacturer = await _context.Manufacturer.FindAsync(id);

            if (manufacturer != null)
            {
                _context.Manufacturer.Remove(manufacturer);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ManufacturerExists(int id)
        {
            return _context.Manufacturer.Any(e => e.Id == id);
        }
    }
}
