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
    public class ReviewsController : Controller
    {
        private readonly CVGSContext _context;

        public ReviewsController(CVGSContext context)
        {
            _context = context;
        }

        // GET: Reviews
        public async Task<IActionResult> Index()
        {
            int memberId = int.Parse(HttpContext.Session.GetString("memberId"));

            var cVGSContext = _context.Reviews.Include(r => r.Games).Include(r => r.Members).Where(a => a.MemberId == memberId);
            return View(await cVGSContext.ToListAsync());
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews
                .Include(r => r.Games)
                .Include(r => r.Members)
                .FirstOrDefaultAsync(m => m.ReviewId == id);
            if (reviews == null)
            {
                return NotFound();
            }

            return View(reviews);
        }

        // GET: Reviews/Create
        public IActionResult Create()
        {
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameName");
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email");
            return View();
        }

        // POST: Reviews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReviewId,GameId,MemberId,ReviewTitle,ReviewDetails,Approved,ReviewDate")] Reviews reviews)
        {
            if (ModelState.IsValid)
            {
                //memberId
                int memberId = int.Parse(HttpContext.Session.GetString("memberId"));
                reviews.MemberId = memberId;

                //datetime now
                reviews.ReviewDate = DateTime.Now;

                //approved false
                reviews.Approved = false;

                //check if this member already has a review for this particular game
                var reviewExists = _context.Reviews.Where(a => a.MemberId == memberId && a.GameId == reviews.GameId);

                if (!reviewExists.Any())
                {
                    _context.Add(reviews);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.gameError = "You have already reviewed this game";
                }
            }
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameName", reviews.GameId);
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email", reviews.MemberId);
            return View(reviews);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews.FindAsync(id);
            if (reviews == null)
            {
                return NotFound();
            }
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameName", reviews.GameId);
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email", reviews.MemberId);
            return View(reviews);
        }

        // POST: Reviews/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReviewId,GameId,MemberId,ReviewTitle,ReviewDetails,Approved,ReviewDate")] Reviews reviews)
        {
            if (id != reviews.ReviewId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //memberId
                int memberId = int.Parse(HttpContext.Session.GetString("memberId"));
                reviews.MemberId = memberId;

                //set game ID
                //datetime now - make sure it's the same
                var game = _context.Reviews.Where(a => a.ReviewId == id).AsNoTracking().FirstOrDefault();
                if (game != null)
                {
                    var gameId = game.GameId;
                    reviews.GameId = gameId;
                    var reviewDate = game.ReviewDate;
                    reviews.ReviewDate = reviewDate;
                }

                //approved false
                reviews.Approved = false;

                try
                {
                    _context.Update(reviews);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewsExists(reviews.ReviewId))
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
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameName", reviews.GameId);
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email", reviews.MemberId);
            return View(reviews);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews
                .Include(r => r.Games)
                .Include(r => r.Members)
                .FirstOrDefaultAsync(m => m.ReviewId == id);
            if (reviews == null)
            {
                return NotFound();
            }

            return View(reviews);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reviews = await _context.Reviews.FindAsync(id);
            _context.Reviews.Remove(reviews);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Employee view for unapproved reviews
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> EmployeeIndex()
        {
            var cVGSContext = _context.Reviews.Include(r => r.Games).Include(r => r.Members).Where(a => a.Approved == false);
            return View(await cVGSContext.ToListAsync());
        }

        /// <summary>
        /// GET Approve
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Approve(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews
                .Include(r => r.Games)
                .Include(r => r.Members)
                .FirstOrDefaultAsync(m => m.ReviewId == id);
            if (reviews == null)
            {
                return NotFound();
            }

            return View(reviews);
        }

        /// <summary>
        /// POST approve
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Approve")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id)
        {
            var reviews = await _context.Reviews.FindAsync(id);
            reviews.Approved = true;
            _context.Reviews.Update(reviews);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(EmployeeIndex));
        }

        public async Task<IActionResult> Deny(int id)
        {
            var reviews = await _context.Reviews.FindAsync(id);
            _context.Reviews.Remove(reviews);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(EmployeeIndex));
        }

        /// <summary>
        /// View reviews for a certain game
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ViewReviewsForGame(int id)
        {
            var cVGSContext = _context.Reviews.Include(r => r.Games).Include(r => r.Members).Where(a => a.GameId == id && a.Approved == true);
            var gameName = _context.Games.Where(a => a.GameId == id).FirstOrDefault();

            ViewBag.gameName = gameName.GameName;
            ViewBag.gameId = gameName.GameId;

            return View(await cVGSContext.ToListAsync());
        }

        private bool ReviewsExists(int id)
        {
            return _context.Reviews.Any(e => e.ReviewId == id);
        }
    }
}
