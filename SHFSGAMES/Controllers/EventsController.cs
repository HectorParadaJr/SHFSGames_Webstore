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
    public class EventsController : Controller
    {
        private readonly CVGSContext _context;

        public EventsController(CVGSContext context)
        {
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            return View(await _context.Events.Include(a => a.Employees).ToListAsync());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var events = await _context.Events
                .Include(a => a.Employees)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (events == null)
            {
                return NotFound();
            }

            return View(events);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FullName");
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,EmployeeId,EventTitle,EventDescription,EventDate,EventTime,EventLocation")] Events events)
        {
            if (ModelState.IsValid)
            {
                _context.Add(events);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FullName");
            return View(events);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var events = await _context.Events.FindAsync(id);
            if (events == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FullName");
            return View(events);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,EmployeeId,EventTitle,EventDescription,EventDate,EventTime,EventLocation")] Events events)
        {
            if (id != events.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(events);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventsExists(events.EventId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FullName");
            return View(events);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var events = await _context.Events
                .Include(a => a.Employees)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (events == null)
            {
                return NotFound();
            }

            return View(events);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var events = await _context.Events.FindAsync(id);
            _context.Events.Remove(events);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// GET list of events, with dates greater than today
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> EventsListView()
        {
            return View(await _context.Events.Include(a => a.Employees).Where(a => a.EventDate > DateTime.Now).ToListAsync());
        }

        /// <summary>
        /// View details for an event/ member view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> MemberDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var events = await _context.Events
                .Include(a => a.Employees)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (events == null)
            {
                return NotFound();
            }

            return View(events);
        }

        /// <summary>
        /// Register member for event
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Register(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int eventId = (int)id;

            int memberId = int.Parse(HttpContext.Session.GetString("memberId"));

            //check if member is already rigstered for this event/ if not register
            var registrationsExists = _context.EventRegistrations.Where(a => a.MemberId == memberId && a.EventId == eventId).FirstOrDefault();

            if (registrationsExists == null)
            {
                //create whole event registration
                _context.EventRegistrations.Add(new EventRegistrations { EventId = eventId, MemberId = memberId, Registered = true });
                await _context.SaveChangesAsync();

                ViewBag.msg = "Successfully Registered for Event";
                await MemberDetails(id);
                return View("MemberDetails");
            }
            else if (registrationsExists != null && registrationsExists.Registered == false)
            {
                //registration exists, change reigtered to true
                registrationsExists.Registered = true;
                _context.EventRegistrations.Update(registrationsExists);
                await _context.SaveChangesAsync();

                ViewBag.msg = "Successfully Registered for Event";
                await MemberDetails(id);
                return View("MemberDetails");
            }
            else
            {
                //already registered
                ViewBag.msg = "You have already registered for this event";
            }

            await MemberDetails(id);
            return View("MemberDetails");
        }

        private bool EventsExists(int id)
        {
            return _context.Events.Any(e => e.EventId == id);
        }
    }
}
