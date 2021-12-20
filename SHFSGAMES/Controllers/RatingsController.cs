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
    public class RatingsController : Controller
    {
        private readonly CVGSContext _context;

        public RatingsController(CVGSContext context)
        {
            _context = context;
        }

        // GET: Ratings
        public async Task<IActionResult> Index()
        {
            int memberId = int.Parse(HttpContext.Session.GetString("memberId"));

            var cVGSContext = _context.Ratings.Include(r => r.Games).Include(r => r.Members).Where(a => a.MemberId == memberId);
            return View(await cVGSContext.ToListAsync());
        }

        // GET: Ratings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ratings = await _context.Ratings
                .Include(r => r.Games)
                .Include(r => r.Members)
                .FirstOrDefaultAsync(m => m.RatingId == id);
            if (ratings == null)
            {
                return NotFound();
            }

            return View(ratings);
        }

        // GET: Ratings/Create
        public IActionResult Create()
        {
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameName");
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email");
            return View();
        }

        // POST: Ratings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RatingId,GameId,MemberId,Rate")] Ratings ratings)
        {
            if (ModelState.IsValid)
            {
                //validations:
                //add memberId
                int memberId = int.Parse(HttpContext.Session.GetString("memberId"));
                ratings.MemberId = memberId;

                //check if this game is already rated
                //rating 1-10
                var rateExists = _context.Ratings.Where(a => a.MemberId == memberId && a.GameId == ratings.GameId);

                if (!rateExists.Any() && ratings.Rate < 11 && ratings.Rate >= 0)
                {
                    //we gucci
                    _context.Add(ratings);
                    await _context.SaveChangesAsync();

                    //update rating
                    UpdateRating(ratings.GameId);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    if (rateExists.Any())
                    {
                        ViewBag.gameError = "A rating for this game already exists";
                    }
                    if (ratings.Rate > 10 || ratings.Rate < 0)
                    {
                        ViewBag.rateError = "Rating can only be between 0-10";
                    }
                }
            }
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameName", ratings.GameId);
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email", ratings.MemberId);
            return View(ratings);
        }

        // GET: Ratings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ratings = await _context.Ratings.FindAsync(id);
            if (ratings == null)
            {
                return NotFound();
            }
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameName", ratings.GameId);
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email", ratings.MemberId);
            return View(ratings);
        }

        // POST: Ratings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RatingId,GameId,MemberId,Rate")] Ratings ratings)
        {
            if (id != ratings.RatingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                int memberId = int.Parse(HttpContext.Session.GetString("memberId"));

                //member id
                ratings.MemberId = memberId;

                //make sure game id is the same
                var game = _context.Ratings.Where(a => a.RatingId == id).AsNoTracking().FirstOrDefault();
                if (game != null)
                {
                    var gameId = game.GameId;
                    ratings.GameId = gameId;
                }

                //make sure rating is between 0 - 10
                if (ratings.Rate < 11 && ratings.Rate >= 0)
                {
                    try
                    {
                        _context.Update(ratings);
                        await _context.SaveChangesAsync();

                        //update rating
                        UpdateRating(ratings.GameId);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!RatingsExists(ratings.RatingId))
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
                else
                {
                    if (ratings.Rate > 10 || ratings.Rate < 0)
                    {
                        ViewBag.rateError = "Rating can only be between 0-10";
                    }
                }
            }
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameName", ratings.GameId);
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email", ratings.MemberId);
            return View(ratings);
        }

        // GET: Ratings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ratings = await _context.Ratings
                .Include(r => r.Games)
                .Include(r => r.Members)
                .FirstOrDefaultAsync(m => m.RatingId == id);
            if (ratings == null)
            {
                return NotFound();
            }

            return View(ratings);
        }

        // POST: Ratings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ratings = await _context.Ratings.FindAsync(id);
            
            _context.Ratings.Remove(ratings);
            await _context.SaveChangesAsync();
            
            //update rating
            UpdateRating(ratings.GameId); 
            
            return RedirectToAction(nameof(Index));
        }

        private bool RatingsExists(int id)
        {
            return _context.Ratings.Any(e => e.RatingId == id);
        }

        /// <summary>
        /// Update total rating for game when creating/editing/deleting games
        /// </summary>
        /// <param name="rating"></param>
        public void UpdateRating(int gameId)
        {
            //find every single rating for a certain game
            //find count
            //add all ratings together and divide by count
            //update game rating to that number out of 10 (/10)

            double totalRating = 0;
            int totalCount = 0;

            var ratings = _context.Ratings.Where(a => a.GameId == gameId);
            if (ratings != null)
            {
                foreach (var item in ratings)
                {
                    totalRating += item.Rate;
                    totalCount++;
                }

                var total = Math.Round(totalRating / totalCount, 1);

                var game = _context.Games.Where(a => a.GameId == gameId).AsNoTracking().FirstOrDefault();

                if (game != null)
                {
                    //update rating for game
                    game.RatingTotal = total + "/10";
                    try
                    {
                        _context.Games.Update(game);
                        _context.SaveChanges();
                    }
                    catch
                    {
                        ViewBag.error = "An error occured, please try editing your rating";
                    }
                }
            }
        }
    }
}
