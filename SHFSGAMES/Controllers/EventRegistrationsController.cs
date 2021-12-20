using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SHFSGAMES.Models;

namespace SHFSGAMES.Controllers
{
    public class EventRegistrationsController : Controller
    {
        private readonly CVGSContext _context;

        public EventRegistrationsController(CVGSContext context)
        {
            _context = context;
        }

        // GET: EventRegistrations
        public async Task<IActionResult> Index()
        {
            //find all event where this member has registered
            
            int memberId = int.Parse(HttpContext.Session.GetString("memberId"));

            var cVGSContext = _context.EventRegistrations.Include(e => e.Events).Include(e => e.Members).Where(a => a.Registered == true && a.MemberId == memberId);
            return View(await cVGSContext.ToListAsync());
        }

        //unregister from event
        public async Task<IActionResult> Unregister(int id)
        {
            int memberId = int.Parse(HttpContext.Session.GetString("memberId"));

            var eventRegistration = _context.EventRegistrations.Where(a => a.EventId == id && a.MemberId == memberId).FirstOrDefault();

            if (eventRegistration != null)
            {
                //just change registration to false
                eventRegistration.Registered = false;
                _context.EventRegistrations.Update(eventRegistration);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                //something went wrong
                ViewBag.error = "ERROR. Try again";
                return RedirectToAction(nameof(Index));

            }
        }

        /// <summary>
        /// View members who registered for this event
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> MembersRegistered(int id)
        {
            var members = _context.EventRegistrations.Include(a => a.Members).Where(a => a.EventId == id && a.Registered == true);
            var eventTitle = _context.Events.Where(a => a.EventId == id).FirstOrDefault();

            ViewBag.eventName = eventTitle.EventTitle;
            ViewBag.eventId = eventTitle.EventId;
            
            return View(await members.ToListAsync());
        }

        // GET: EventRegistrations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventRegistrations = await _context.EventRegistrations
                .Include(e => e.Events)
                .Include(e => e.Members)
                .FirstOrDefaultAsync(m => m.MemberId == id);
            if (eventRegistrations == null)
            {
                return NotFound();
            }

            return View(eventRegistrations);
        }

        // GET: EventRegistrations/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventDescription");
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email");
            return View();
        }

        // POST: EventRegistrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MemberId,EventId,Registered")] EventRegistrations eventRegistrations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventRegistrations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventDescription", eventRegistrations.EventId);
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email", eventRegistrations.MemberId);
            return View(eventRegistrations);
        }

        // GET: EventRegistrations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventRegistrations = await _context.EventRegistrations.FindAsync(id);
            if (eventRegistrations == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventDescription", eventRegistrations.EventId);
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email", eventRegistrations.MemberId);
            return View(eventRegistrations);
        }

        // POST: EventRegistrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MemberId,EventId,Registered")] EventRegistrations eventRegistrations)
        {
            if (id != eventRegistrations.MemberId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventRegistrations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventRegistrationsExists(eventRegistrations.MemberId))
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
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventDescription", eventRegistrations.EventId);
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email", eventRegistrations.MemberId);
            return View(eventRegistrations);
        }

        // GET: EventRegistrations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventRegistrations = await _context.EventRegistrations
                .Include(e => e.Events)
                .Include(e => e.Members)
                .FirstOrDefaultAsync(m => m.MemberId == id);
            if (eventRegistrations == null)
            {
                return NotFound();
            }

            return View(eventRegistrations);
        }

        // POST: EventRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventRegistrations = await _context.EventRegistrations.FindAsync(id);
            _context.EventRegistrations.Remove(eventRegistrations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventRegistrationsExists(int id)
        {
            return _context.EventRegistrations.Any(e => e.MemberId == id);
        }
    }
}
