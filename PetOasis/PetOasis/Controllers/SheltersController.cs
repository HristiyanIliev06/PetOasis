using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetOasis.Data;
using PetOasis.Models;

namespace PetOasis.Controllers
{
    public class SheltersController : Controller
    {
        private readonly PetOasisContext _context;

        public SheltersController(PetOasisContext context)
        {
            _context = context;
        }

        // GET: Shelters
        public async Task<IActionResult> Index()
        {
            var petOasisContext = _context.Shelters.Include(s => s.Pet).Include(s => s.PetHotel);
            return View(await petOasisContext.ToListAsync());
        }

        // GET: Shelters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shelter = await _context.Shelters
                .Include(s => s.Pet)
                .Include(s => s.PetHotel)
                .FirstOrDefaultAsync(m => m.PetHotelId == id);
            if (shelter == null)
            {
                return NotFound();
            }

            return View(shelter);
        }

        // GET: Shelters/Create
        public IActionResult Create()
        {
            ViewData["PetId"] = new SelectList(_context.Pets, "Id", "Breed");
            ViewData["PetHotelId"] = new SelectList(_context.PetHotels, "Id", "City");
            return View();
        }

        // POST: Shelters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PetHotelId,PetId")] Shelter shelter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shelter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PetId"] = new SelectList(_context.Pets, "Id", "Breed", shelter.PetId);
            ViewData["PetHotelId"] = new SelectList(_context.PetHotels, "Id", "City", shelter.PetHotelId);
            return View(shelter);
        }

        // GET: Shelters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shelter = await _context.Shelters.FindAsync(id);
            if (shelter == null)
            {
                return NotFound();
            }
            ViewData["PetId"] = new SelectList(_context.Pets, "Id", "Breed", shelter.PetId);
            ViewData["PetHotelId"] = new SelectList(_context.PetHotels, "Id", "City", shelter.PetHotelId);
            return View(shelter);
        }

        // POST: Shelters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PetHotelId,PetId")] Shelter shelter)
        {
            if (id != shelter.PetHotelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shelter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShelterExists(shelter.PetHotelId))
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
            ViewData["PetId"] = new SelectList(_context.Pets, "Id", "Breed", shelter.PetId);
            ViewData["PetHotelId"] = new SelectList(_context.PetHotels, "Id", "City", shelter.PetHotelId);
            return View(shelter);
        }

        // GET: Shelters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shelter = await _context.Shelters
                .Include(s => s.Pet)
                .Include(s => s.PetHotel)
                .FirstOrDefaultAsync(m => m.PetHotelId == id);
            if (shelter == null)
            {
                return NotFound();
            }

            return View(shelter);
        }

        // POST: Shelters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shelter = await _context.Shelters.FindAsync(id);
            if (shelter != null)
            {
                _context.Shelters.Remove(shelter);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShelterExists(int id)
        {
            return _context.Shelters.Any(e => e.PetHotelId == id);
        }
    }
}
