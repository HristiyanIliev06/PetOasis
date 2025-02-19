using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetOasis.Data.Entities;
using PetOasis.ViewModel;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PetOasis.Controllers
{
    [Authorize(Roles = "Admin")] // Only allow Admins to manage users
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;

        public AdminController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var model = new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,

            };

            return View(model);
        }
        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                return NotFound();
            }

            // Актуализирайте полетата на потребителя
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            // Добавете други полета, ако е необходимо

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }

            // Ако има грешки при актуализацията, добавете ги към ModelState
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }
        /*public async Task<IActionResult> Create(UserViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    
                };

                _context.User.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }*/

    }
}
