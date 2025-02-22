using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetOasis.Data;
using PetOasis.Data.Entities;

namespace PetOasis.Controllers
{
    public class PetHotelsController : Controller
    {
        private readonly PetOasisContext _context;

        public PetHotelsController(PetOasisContext context)
        {
            _context = context;
        }

        // GET: PetHotels
        public async Task<IActionResult> Index()
        {
            return View(await _context.PetHotels.ToListAsync());
        }

        // GET: PetHotels/Details/5
        public async Task<IActionResult> Details(string city)
        {
            if (city == null)
            {
                return NotFound();
            }

            var petHotel = await _context.PetHotels
                .FirstOrDefaultAsync(m => m.City == city);
            if (petHotel == null)
            {
                return NotFound("Such a facility does not exist");
            }

            return View(petHotel);
        }

        // GET: PetHotels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PetHotels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,City,Street,Street_Number,Outside_View,Phone,Email,Description")] PetHotel petHotel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(petHotel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(petHotel);
        }

        // GET: PetHotels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petHotel = await _context.PetHotels.FindAsync(id);
            if (petHotel == null)
            {
                return NotFound();
            }
            return View(petHotel);
        }

        // POST: PetHotels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,City,Street,Street_Number,Outside_View,Phone,Email,Description")] PetHotel petHotel)
        {
            if (id != petHotel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(petHotel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetHotelExists(petHotel.Id))
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
            return View(petHotel);
        }

        // GET: PetHotels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petHotel = await _context.PetHotels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (petHotel == null)
            {
                return NotFound();
            }

            return View(petHotel);
        }

        // POST: PetHotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var petHotel = await _context.PetHotels.FindAsync(id);
            if (petHotel != null)
            {
                _context.PetHotels.Remove(petHotel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetHotelExists(int id)
        {
            return _context.PetHotels.Any(e => e.Id == id);
        }
    }
}
