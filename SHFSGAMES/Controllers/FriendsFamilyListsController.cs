using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SHFSGAMES.Models;

namespace SHFSGAMES.Controllers
{
    public class FriendsFamilyListsController : Controller
    {
        private readonly CVGSContext _context;

        public FriendsFamilyListsController(CVGSContext context)
        {
            _context = context;
        }

        // GET: FriendsFamilyLists
        public async Task<IActionResult> Index()
        {
            var cVGSContext = _context.FriendsFamilyLists.Include(f => f.Members);
            return View(await cVGSContext.ToListAsync());
        }

        // GET: FriendsFamilyLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friendsFamilyLists = await _context.FriendsFamilyLists
                .Include(f => f.Members)
                .FirstOrDefaultAsync(m => m.FriendsFamilyListId == id);
            if (friendsFamilyLists == null)
            {
                return NotFound();
            }

            return View(friendsFamilyLists);
        }

        // GET: FriendsFamilyLists/Create
        public IActionResult Create()
        {
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email");
            return View();
        }

        // POST: FriendsFamilyLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FriendsFamilyListId,MemberId")] FriendsFamilyLists friendsFamilyLists)
        {
            if (ModelState.IsValid)
            {
                _context.Add(friendsFamilyLists);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email", friendsFamilyLists.MemberId);
            return View(friendsFamilyLists);
        }

        // GET: FriendsFamilyLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friendsFamilyLists = await _context.FriendsFamilyLists.FindAsync(id);
            if (friendsFamilyLists == null)
            {
                return NotFound();
            }
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email", friendsFamilyLists.MemberId);
            return View(friendsFamilyLists);
        }

        // POST: FriendsFamilyLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FriendsFamilyListId,MemberId")] FriendsFamilyLists friendsFamilyLists)
        {
            if (id != friendsFamilyLists.FriendsFamilyListId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(friendsFamilyLists);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FriendsFamilyListsExists(friendsFamilyLists.FriendsFamilyListId))
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
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email", friendsFamilyLists.MemberId);
            return View(friendsFamilyLists);
        }

        // GET: FriendsFamilyLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friendsFamilyLists = await _context.FriendsFamilyLists
                .Include(f => f.Members)
                .FirstOrDefaultAsync(m => m.FriendsFamilyListId == id);
            if (friendsFamilyLists == null)
            {
                return NotFound();
            }

            return View(friendsFamilyLists);
        }

        // POST: FriendsFamilyLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var friendsFamilyLists = await _context.FriendsFamilyLists.FindAsync(id);
            _context.FriendsFamilyLists.Remove(friendsFamilyLists);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FriendsFamilyListsExists(int id)
        {
            return _context.FriendsFamilyLists.Any(e => e.FriendsFamilyListId == id);
        }
    }
}
