using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SHFSGAMES.Models;

namespace SHFSGAMES.Controllers
{
    public class WishlistGamesController : Controller
    {
        private readonly CVGSContext _context;

        public WishlistGamesController(CVGSContext context)
        {
            _context = context;
        }

        // GET: WishlistGames
        public async Task<IActionResult> Index()
        {
            //show game title related to member
            int memberId = int.Parse(HttpContext.Session.GetString("memberId"));

            var memberGames = _context.WishlistGames.Include(a => a.Games).Where(a => a.Wishlists.MemberId == memberId);

            return View(await memberGames.ToListAsync());
        }

        public async Task<IActionResult> ViewFriendWishlist(int friendId)
        {
            var memberGames = _context.WishlistGames.Include(a => a.Games).Where(a => a.Wishlists.MemberId == friendId);

            return View(await memberGames.ToListAsync());
        }

        //delete from wishlist
        // POST: WishlistGames/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteFromWishlist(int id, int gameId)
        {
            //delete using wishlistid and game id
            var gameToDelete = _context.WishlistGames.Where(a => a.WishlistId == id && a.GameId == gameId).FirstOrDefault();

            if (gameToDelete != null)
            {
                _context.WishlistGames.Remove(gameToDelete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                //something went wrong
                ViewBag.error = "ERROR. Try again";
                return View("Index");
            }
        }

        //report
        public async Task<IActionResult> ViewWishlists()
        {
            //reutrn game name and the number of times it appears in wishlists
            var wishlistGames = _context.WishlistGames.Include(a => a.Games);
            return View(await wishlistGames.ToListAsync());
        }

        // GET: WishlistGames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishlistGames = await _context.WishlistGames
                .FirstOrDefaultAsync(m => m.WishlistId == id);
            if (wishlistGames == null)
            {
                return NotFound();
            }

            return View(wishlistGames);
        }

        // GET: WishlistGames/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WishlistGames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WishlistId,GameId")] WishlistGames wishlistGames)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wishlistGames);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wishlistGames);
        }

        // GET: WishlistGames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishlistGames = await _context.WishlistGames.FindAsync(id);
            if (wishlistGames == null)
            {
                return NotFound();
            }
            return View(wishlistGames);
        }

        // POST: WishlistGames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WishlistId,GameId")] WishlistGames wishlistGames)
        {
            if (id != wishlistGames.WishlistId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wishlistGames);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WishlistGamesExists(wishlistGames.WishlistId))
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
            return View(wishlistGames);
        }

        // GET: WishlistGames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishlistGames = await _context.WishlistGames
                .FirstOrDefaultAsync(m => m.WishlistId == id);
            if (wishlistGames == null)
            {
                return NotFound();
            }

            return View(wishlistGames);
        }

        // POST: WishlistGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wishlistGames = await _context.WishlistGames.FindAsync(id);
            _context.WishlistGames.Remove(wishlistGames);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WishlistGamesExists(int id)
        {
            return _context.WishlistGames.Any(e => e.WishlistId == id);
        }
    }
}
