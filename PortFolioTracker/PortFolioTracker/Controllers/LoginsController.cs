using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortFolioTracker.Models;

namespace PortFolioTracker.Controllers
{
    public class LoginsController : Controller
    {
        private readonly MvcPortFolioContext _context;

        public LoginsController(MvcPortFolioContext context)
        {
            _context = context;
        }

        // GET: Logins
        public async Task<IActionResult> Index()
        {
              return _context.Logins != null ? 
                          View(await _context.Logins.ToListAsync()) :
                          Problem("Entity set 'MvcPortFolioContext.Logins'  is null.");
        }

        // GET: Logins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Logins == null)
            {
                return NotFound();
            }

            var login = await _context.Logins
                .FirstOrDefaultAsync(m => m.ID == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // GET: Logins/Create
        public IActionResult Create()
        {
            ViewBag.Status = new List<SelectListItem>
            {
            new SelectListItem { Value = "0", Text = "False" },
            new SelectListItem { Value = "1", Text = "True" },
             };
             
            return View();
        }

        // POST: Logins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FIRSTNAME,MIDDLENAME,LASTNAME,USERNAME,PASSWORD,STATUS")] Login login)
        {
            if (ModelState.IsValid)
            {
                _context.Add(login);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(login);
        }

        // GET: Logins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Logins == null)
            {
                return NotFound();
            }

            var login = await _context.Logins.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }
            return View(login);
        }

        // POST: Logins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FIRSTNAME,MIDDLENAME,LASTNAME,USERNAME,PASSWORD,STATUS")] Login login)
        {
            if (id != login.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(login);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginExists(login.ID))
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
            return View(login);
        }

        // GET: Logins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Logins == null)
            {
                return NotFound();
            }

            var login = await _context.Logins
                .FirstOrDefaultAsync(m => m.ID == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // POST: Logins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Logins == null)
            {
                return Problem("Entity set 'MvcPortFolioContext.Logins'  is null.");
            }
            var login = await _context.Logins.FindAsync(id);
            if (login != null)
            {
                _context.Logins.Remove(login);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoginExists(int id)
        {
          return (_context.Logins?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
