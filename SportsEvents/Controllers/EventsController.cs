using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SPEvents.Data;
using SPEvents.Models;

namespace SPEvents.Controllers
{
    //[Authorize]
    public class EventsController : Controller
    {
        private readonly SPEventsContext _context;
        private List<EventUser> evul;

        public EventsController(SPEventsContext context)
        {
            _context = context;
            evul = _context.EventUser.ToList();
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            return View(await _context.Event.ToListAsync());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .FirstOrDefaultAsync(m => m.id == id);
            if (@event == null)
            {
                return NotFound();
            }

            List<EventUser> leu = new List<EventUser>();

            foreach (var eventsusers in _context.EventsUsers.ToList())
            {
                if (eventsusers.EventId == id)
                {
                    EventUser eu = new EventUser(); 
                    eu = await _context.EventUser.FindAsync(eventsusers.userId);
                    leu.Add(eu);
                }
            }
            ViewData["users"] = leu;
            return View(@event);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,title,location,datetime,description,category")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            //CustomEventModel cem = new CustomEventModel();
            //cem.ev = @event;
            //cem.evul = evul;

            List<EventUser> leu = new List<EventUser>();

            foreach (var eventsusers in _context.EventsUsers.ToList())
            {
                if (eventsusers.EventId == id)
                {
                    EventUser eu = new EventUser();
                    eu = await _context.EventUser.FindAsync(eventsusers.userId);
                    leu.Add(eu);
                }
            }

            ViewData["sel_users"] = leu;
            ViewData["users"] = evul;
            return View(@event);
        }

        //POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // public async Task<IActionResult> Edit(string id, string[] user, [Bind("id,title,location,datetime,description,category")] CustomEventModel @event)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, string[] user, [Bind("id,title,location,datetime,description,category")] Event @event)
        {
            if (id != @event.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    List<EventsUsers> lst = new List<EventsUsers>();
                    var recs = _context.EventsUsers.Where(x => x.EventId == @event.id);

                    foreach ( var eu in recs)
                    {
                        _context.EventsUsers.Remove(eu);
                    }

                    foreach (var str in user)
                    {
                        EventsUsers eusrs = new EventsUsers();
                        eusrs.thisevent = @event;
                        eusrs.EventId = @event.id;
                        eusrs.eu = _context.EventUser.Find(int.Parse(str));
                        eusrs.userId = int.Parse(str);

                       
                        _context.Add(eusrs);
                        lst.Add(eusrs);
                    }

                   // @event.EventsUsers.Clear();
                    //@event.EventsUsers = lst;
                    _context.Update(@event);



                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.id))
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
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .FirstOrDefaultAsync(m => m.id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var @event = await _context.Event.FindAsync(id);
            _context.Event.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(string id)
        {
            return _context.Event.Any(e => e.id == id);
        }
    }
}
