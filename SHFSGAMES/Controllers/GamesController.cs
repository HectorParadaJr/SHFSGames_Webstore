using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SHFSGAMES.Models;

namespace SHFSGAMES.Controllers
{
    public class GamesController : Controller
    {
        private readonly CVGSContext _context;

        public GamesController(CVGSContext context)
        {
            _context = context;
        }

        // GET: Games
        public async Task<IActionResult> Index()
        {
            var games = _context.Games
                .Include(a => a.GamePlatforms)
                .ThenInclude(ab => ab.Platforms)
                .Include(a => a.GameCategories)
                .ThenInclude(ab => ab.Categories)
                .OrderBy(a => a.GameName)
                .ThenBy(a => a.ReleaseDate)
                .ToListAsync();

            return View(await games);
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var games = await _context.Games
                .Include(a => a.GamePlatforms)
                .ThenInclude(ab => ab.Platforms)
                .Include(a => a.GameCategories)
                .ThenInclude(ab => ab.Categories)
                .FirstOrDefaultAsync(m => m.GameId == id);
            if (games == null)
            {
                return NotFound();
            }

            return View(games);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            ViewData["PlatformId"] = new MultiSelectList(_context.Platforms, "PlatformId", "PlatformName");
            ViewData["CategoryId"] = new MultiSelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Games/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GameId,GameName,GameDescription,RatingTotal,Price,GameDeveloper,ReleaseDate, Category_Id, Platform_Id")] Games games, int[] GamePlatforms, int[] GameCategories)
        {
            if (ModelState.IsValid)
            {
                //iterate through both platform and category arrays
               
                    //var platformId = GamePlatforms;
                    //var categoryId = GameCategories;
                    //_context.GamePlatforms.Add(new GamePlatforms { PlatformId = platformId, GameId = games.GameId });
                    //_context.GameCategories.Add(new GameCategories { CategoryId = categoryId, GameId = games.GameId });
                    _context.Add(games);
                    await _context.SaveChangesAsync();

                for (int i = 0; i < GamePlatforms.Length; i++)
                {
                    var platformId = GamePlatforms[i];
                    _context.GamePlatforms.Add(new GamePlatforms { PlatformId = platformId, GameId = games.GameId });
                    await _context.SaveChangesAsync();
                }


                for (int i = 0; i < GameCategories.Length; i++)
                {
                    var categoryId = GameCategories[i];
                    _context.GameCategories.Add(new GameCategories { CategoryId = categoryId, GameId = games.GameId });
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
        
                //else
                //{
                //    if (GamePlatforms.Length < 1)
                //    {
                //        ViewBag.Perror = "Select one or more platforms";
                //    }
                //    if (GameCategories.Length < 1)
                //    {
                //        ViewBag.Cerror = "Select one or more categories";
                //    }
                //}
                
            }
            ViewData["PlatformId"] = new MultiSelectList(_context.Platforms, "PlatformId", "PlatformName");
            ViewData["CategoryId"] = new MultiSelectList(_context.Categories, "CategoryId", "CategoryName");
            return View(games);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var games = await _context.Games.FindAsync(id);
            if (games == null)
            {
                return NotFound();
            }
            
            //platforms
            var platforms = _context.GamePlatforms.Where(a => a.GameId.Equals(id)).ToList();
            List<int> platformIDs = new List<int>();

            foreach (var item in platforms)
            {
                platformIDs.Add(item.PlatformId);
            }

            //categories
            var categories = _context.GameCategories.Where(a => a.GameId.Equals(id)).ToList();
            List<int> categoryIDs = new List<int>();

            foreach (var item in categories)
            {
                categoryIDs.Add(item.CategoryId);
            }

            ViewData["PlatformId"] = new MultiSelectList(_context.Platforms, "PlatformId", "PlatformName", platformIDs);
            ViewData["CategoryId"] = new MultiSelectList(_context.Categories, "CategoryId", "CategoryName", categoryIDs);
            return View(games);
        }

        // POST: Games/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GameId,GameName,GameDescription,RatingTotal,Price,GameDeveloper,ReleaseDate")] Games games, int[] GamePlatforms, int[] GameCategories)
        {
            if (id != games.GameId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (GamePlatforms.Length > 0 && GameCategories.Length > 0)
                    {
                        _context.Update(games);
                        await _context.SaveChangesAsync();

                        //delete old, create new

                        //old
                        var oldPlatforms = _context.GamePlatforms.Where(a => a.GameId.Equals(id)).AsNoTracking();
                        List<int> platformIDs = new List<int>();

                        foreach (var item in oldPlatforms)
                        {
                            platformIDs.Add(item.PlatformId);
                            
                        }

                        //delete
                        for (int i = 0; i < oldPlatforms.Count(); i++)
                        {
                            GamePlatforms deletePlatforms = _context.GamePlatforms.FirstOrDefault(a => a.GameId.Equals(id));
                            deletePlatforms.GameId = id;
                            deletePlatforms.PlatformId = platformIDs[i];
                            _context.GamePlatforms.Remove(deletePlatforms);
                            await _context.SaveChangesAsync();
                        }

                        //add new
                        for (int i = 0; i < GamePlatforms.Length; i++)
                        {
                            var platformId = GamePlatforms[i];
                            _context.GamePlatforms.Add(new GamePlatforms { PlatformId = platformId, GameId = id });
                            await _context.SaveChangesAsync();
                        }

                        //cateogires
                        //old
                        var oldCategories = _context.GameCategories.Where(a => a.GameId.Equals(id));
                        List<int> categoryIDs = new List<int>();

                        foreach (var item in oldCategories)
                        {
                            categoryIDs.Add(item.CategoryId);
                        }

                        //delete
                        for (int i = 0; i < oldCategories.Count(); i++)
                        {
                            GameCategories deleteCategories = _context.GameCategories.FirstOrDefault(a => a.GameId.Equals(id));
                            deleteCategories.GameId = id;
                            deleteCategories.CategoryId = categoryIDs[i];
                            _context.GameCategories.Remove(deleteCategories);
                            await _context.SaveChangesAsync();
                        }

                        //add new
                        for (int i = 0; i < GameCategories.Length; i++)
                        {
                            var categoryId = GameCategories[i];
                            _context.GameCategories.Add(new GameCategories { CategoryId = categoryId, GameId = id });
                            await _context.SaveChangesAsync();
                        }
                    }
                    else
                    {
                        if (GamePlatforms.Length < 1)
                        {
                            ViewBag.Perror = "Select one or more platforms";
                        }
                        if (GameCategories.Length < 1)
                        {
                            ViewBag.Cerror = "Select one or more categories";
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GamesExists(games.GameId))
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
            ViewData["PlatformId"] = new MultiSelectList(_context.Platforms, "PlatformId", "PlatformName");
            ViewData["CategoryId"] = new MultiSelectList(_context.Categories, "CategoryId", "CategoryName");
            return View(games);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var games = await _context.Games
                .Include(a => a.GamePlatforms)
                .ThenInclude(ab => ab.Platforms)
                .Include(a => a.GameCategories)
                .ThenInclude(ab => ab.Categories)
                .FirstOrDefaultAsync(m => m.GameId == id);
            if (games == null)
            {
                return NotFound();
            }

            return View(games);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                //delete platforms and categories first

                //platforms
                //old
                var oldPlatforms = _context.GamePlatforms.Where(a => a.GameId.Equals(id));
                List<int> platformIDs = new List<int>();

                foreach (var item in oldPlatforms)
                {
                    platformIDs.Add(item.PlatformId);

                }

                //delete
                for (int i = 0; i < oldPlatforms.Count(); i++)
                {
                    GamePlatforms deletePlatforms = _context.GamePlatforms.FirstOrDefault(a => a.GameId.Equals(id));
                    if (deletePlatforms != null)
                    {
                        deletePlatforms.GameId = id;
                        deletePlatforms.PlatformId = platformIDs[i];
                        _context.GamePlatforms.Remove(deletePlatforms);
                        await _context.SaveChangesAsync();
                    }
                }

                /////////////////////////////////////////

                //categories
                var oldCategories = _context.GameCategories.Where(a => a.GameId.Equals(id));
                List<int> categoryIDs = new List<int>();

                foreach (var item in oldCategories)
                {
                    categoryIDs.Add(item.CategoryId);
                }

                //delete
                for (int i = 0; i < oldCategories.Count(); i++)
                {
                    GameCategories deleteCategories = _context.GameCategories.FirstOrDefault(a => a.GameId.Equals(id));
                    if (deleteCategories != null)
                    {
                        deleteCategories.GameId = id;
                        deleteCategories.CategoryId = categoryIDs[i];
                        _context.GameCategories.Remove(deleteCategories);
                        await _context.SaveChangesAsync();
                    }
                }

                var games = await _context.Games.FindAsync(id);
                _context.Games.Remove(games);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch 
            {
                ViewBag.problem = "An error occured, please try again";
                return RedirectToAction(nameof(Index));
            }
        }

        private bool GamesExists(int id)
        {
            return _context.Games.Any(e => e.GameId == id);
        }

        //reports
        public async Task<IActionResult> ViewGamesList()
        {
            return View(await _context.Games.OrderBy(a => a.GameName).ToListAsync());
        }

        public async Task<IActionResult> ViewGameDetails()
        {
            var games = _context.Games
                .Include(a => a.GamePlatforms)
                .ThenInclude(ab => ab.Platforms)
                .Include(a => a.GameCategories)
                .ThenInclude(ab => ab.Categories)
                .OrderBy(a => a.GameName)
                .ThenBy(a => a.ReleaseDate)
                .ToListAsync();

            return View(await games);
        }

        // GET: Games
        public async Task<IActionResult> MemberIndex()
        {
            var games = _context.Games
                .Include(a => a.GamePlatforms)
                .ThenInclude(ab => ab.Platforms)
                .Include(a => a.GameCategories)
                .ThenInclude(ab => ab.Categories)
                .OrderBy(a => a.GameName)
                .ThenBy(a => a.ReleaseDate)
                .ToListAsync();

            return View(await games);
        }

        // GET: Games/Details/5
        public async Task<IActionResult> MemberDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var games = await _context.Games
                .Include(a => a.GamePlatforms)
                .ThenInclude(ab => ab.Platforms)
                .Include(a => a.GameCategories)
                .ThenInclude(ab => ab.Categories)
                .FirstOrDefaultAsync(m => m.GameId == id);
            if (games == null)
            {
                return NotFound();
            }

            return View(games);
        }

        // GET: Games
        public async Task<IActionResult> SearchGame(string gameName)
        {
            var games = _context.Games
                .Include(a => a.GamePlatforms)
                .ThenInclude(ab => ab.Platforms)
                .Include(a => a.GameCategories)
                .ThenInclude(ab => ab.Categories)
                .OrderBy(a => a.GameName)
                .ThenBy(a => a.ReleaseDate)
                .Where(a => a.GameName.Contains(gameName))
                .ToListAsync();

            return View("MemberIndex", await games);
        }

        // GET: Games/AddtoWIshlist/5
        public async Task<IActionResult> AddGameToWishlist(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int gameId = (int)id;

            int memberId = int.Parse(HttpContext.Session.GetString("memberId"));

            //check if wishlist for member exists
            var wishlistExists = _context.Wishlists.Where(a => a.MemberId == memberId).FirstOrDefault();

            if (wishlistExists != null)
            {
                //wishlist already has been created

                //check if game is in wishlist
                var wishlistId = wishlistExists.WishlistId;

                var gameIsInWishlist = _context.WishlistGames.Where(a => a.GameId == id && a.WishlistId == wishlistId).FirstOrDefault();

                if (gameIsInWishlist != null)
                {
                    //game is already in wishlist
                    ViewBag.wishlistMsg = "Game is already in your wishlist";
                    await MemberDetails(id);
                    return View("MemberDetails");
                }
                else
                {
                    //add game to wishlist
                    _context.WishlistGames.Add(new WishlistGames { GameId = gameId, WishlistId = wishlistId, DateAdded = DateTime.Now });
                    await _context.SaveChangesAsync();
                    ViewBag.wishlistMsg = "Game Added to Wishlist";
                    await MemberDetails(id);
                    return View("MemberDetails");
                }
            }
            else
            {
                //create a wishlist
                _context.Wishlists.Add(new Wishlists { MemberId = memberId });
                await _context.SaveChangesAsync();

                //find wishlistID
                var wishlistMember = _context.Wishlists.Where(a => a.MemberId == memberId).FirstOrDefault(); 

                if (wishlistMember != null)
                {
                    var wishlistId = wishlistMember.WishlistId;

                    var gameIsInWishlist = _context.WishlistGames.Where(a => a.GameId == id && a.WishlistId == wishlistId).FirstOrDefault();

                    if (gameIsInWishlist != null)
                    {
                        //game is already in wishlist
                        ViewBag.wishlistMsg = "Game is already in your wishlist";
                        await MemberDetails(id);
                        return View("MemberDetails");
                    }
                    else
                    {
                        //add game to wishlist
                        _context.WishlistGames.Add(new WishlistGames { GameId = gameId, WishlistId = wishlistId, DateAdded = DateTime.Now });
                        await _context.SaveChangesAsync();
                        ViewBag.wishlistMsg = "Game Added to Wishlist";
                        await MemberDetails(id);
                        return View("MemberDetails");
                    }
                }
            }
            await MemberDetails(id);
            return View("MemberDetails");
        }

        public IActionResult DownloadIndex()
        {
            return View();
        }

        public async Task<IActionResult> FreeGames()
        {
            var games = _context.Games.Where(a => a.Price <= 0);
            
            return View(await games.ToListAsync());
        }

        public async Task<IActionResult> PurchasedGames()
        {
            //return all games that member purchased on PC
            int memberId = int.Parse(HttpContext.Session.GetString("memberId"));
            var platformId = _context.Platforms.Where(a => a.PlatformName == "PC").FirstOrDefault().PlatformId;

            var games = _context.OrderItems.Where(a => a.Orders.MemberId == memberId && a.PlatformId == platformId).Include(a => a.Games);

            return View(await games.ToListAsync());
        }

        public IActionResult DownloadFree(int id)
        {
            var gameName = _context.Games.Where(a => a.GameId == id).FirstOrDefault().GameName;
            string fileName = gameName + "-Game.txt";

            try
            {
                string path = @"C:\Users\Public\" + fileName;
                using (StreamWriter sw = System.IO.File.CreateText(path))
                {
                    sw.WriteLine(gameName);
                }
            }
            catch 
            {
                return RedirectToAction(nameof(FreeGames));
            }

            TempData["download"] = gameName + " Successfully Downloaded in Users-Public folder (C:\\Users\\Public)";
            return RedirectToAction(nameof(FreeGames));
        }

        public IActionResult DownloadPurchased(int id)
        {
            var gameName = _context.Games.Where(a => a.GameId == id).FirstOrDefault().GameName;
            string fileName = gameName + "-Game.txt";

            try
            {
                string path = @"C:\Users\Public\" + fileName;
                using (StreamWriter sw = System.IO.File.CreateText(path))
                {
                    sw.WriteLine(gameName);
                }
            }
            catch (FileNotFoundException ex)
            {
                return RedirectToAction(nameof(PurchasedGames));
            }

            TempData["download"] = gameName + " Successfully Downloaded in Users folder (C:\\Users\\Public)";
            return RedirectToAction(nameof(PurchasedGames));
        }
    }
}
