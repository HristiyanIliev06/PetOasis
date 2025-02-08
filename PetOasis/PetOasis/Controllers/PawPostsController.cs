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
    public class PawPostsController : Controller
    {
        private readonly PetOasisContext _context;

        public PawPostsController(PetOasisContext context)
        {
            _context = context;
        }

        // GET: PawPosts
        public async Task<IActionResult> Index()
        {
            return View(await _context.PawPosts.ToListAsync());
        }

        // GET: PawPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pawPost = await _context.PawPosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pawPost == null)
            {
                return NotFound();
            }

            return View(pawPost);
        }

        // GET: PawPosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PawPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,When_uploaded,Additional_mentions")] PawPost pawPost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pawPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pawPost);
        }

        // GET: PawPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pawPost = await _context.PawPosts.FindAsync(id);
            if (pawPost == null)
            {
                return NotFound();
            }
            return View(pawPost);
        }

        // POST: PawPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,When_uploaded,Additional_mentions")] PawPost pawPost)
        {
            if (id != pawPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pawPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PawPostExists(pawPost.Id))
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
            return View(pawPost);
        }

        // GET: PawPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pawPost = await _context.PawPosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pawPost == null)
            {
                return NotFound();
            }

            return View(pawPost);
        }

        // POST: PawPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pawPost = await _context.PawPosts.FindAsync(id);
            if (pawPost != null)
            {
                _context.PawPosts.Remove(pawPost);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PawPostExists(int id)
        {
            return _context.PawPosts.Any(e => e.Id == id);
        }
    }
}
