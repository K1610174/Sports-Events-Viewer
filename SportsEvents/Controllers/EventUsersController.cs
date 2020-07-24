using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SPEvents.Data;
using SPEvents.Models;

namespace SPEvents.Controllers
{
    public class EventUsersController : Controller
    {
        private readonly SPEventsContext _context;

        public EventUsersController(SPEventsContext context)
        {
            _context = context;
        }

        // GET: EventUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.EventUser.ToListAsync());
        }

        // GET: EventUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventUser = await _context.EventUser
                .FirstOrDefaultAsync(m => m.euid == id);
            if (eventUser == null)
            {
                return NotFound();
            }

            return View(eventUser);
        }

        // GET: EventUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("euid,firstname,lastname,contactnumber,workcontact,dob,address1,address2,postcode,city,workplace")] EventUser eventUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventUser);
        }

        // GET: EventUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventUser = await _context.EventUser.FindAsync(id);
            if (eventUser == null)
            {
                return NotFound();
            }
            return View(eventUser);
        }

        // POST: EventUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("euid,firstname,lastname,contactnumber,workcontact,dob,address1,address2,postcode,city,workplace")] EventUser eventUser)
        {
            if (id != eventUser.euid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventUserExists(eventUser.euid))
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
            return View(eventUser);
        }

        // GET: EventUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventUser = await _context.EventUser
                .FirstOrDefaultAsync(m => m.euid == id);
            if (eventUser == null)
            {
                return NotFound();
            }

            return View(eventUser);
        }

        // POST: EventUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventUser = await _context.EventUser.FindAsync(id);
            _context.EventUser.Remove(eventUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventUserExists(int id)
        {
            return _context.EventUser.Any(e => e.euid == id);
        }
    }
}
