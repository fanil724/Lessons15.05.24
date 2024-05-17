using Lessons15._05._24.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lessons15._05._24.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext _context;

        public HomeController(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                User user = new User { Id = id.Value };
                _context.Entry(user).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return NotFound();
        }

        public async Task<IActionResult> EditAsync(int? id)
        {
            User? us = await _context.Users.FirstOrDefaultAsync(p => p.Id == id);
            if (us != null)
            {
                return View(us);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            if (user != null)
            {
                User? us = await _context.Users.FirstOrDefaultAsync(p => p.Id == user.Id);
                if (us != null)
                {
                    us.Name = user.Name;
                    us.Age = user.Age;

                    _context.Users.Update(us);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

    }
}
