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
    public class MemberFriendsFamilyListsController : Controller
    {
        private readonly CVGSContext _context;

        public MemberFriendsFamilyListsController(CVGSContext context)
        {
            _context = context;
        }

        // GET: MemberFriendsFamilyLists
        public async Task<IActionResult> Index()
        {
            int memberId = int.Parse(HttpContext.Session.GetString("memberId"));

            var membersFriends = _context.MemberFriendsFamilyLists.AsNoTracking().Include(a => a.FriendsFamilyLists).Where(a => a.FriendsFamilyLists.MemberId.Equals(memberId)).ToListAsync();
            return View(await membersFriends);
        }

        // GET: MemberFriendsFamilyLists
        public async Task<IActionResult> ListOfFriends()
        {
            int memberId = int.Parse(HttpContext.Session.GetString("memberId"));

            var memberFriends = _context.MemberFriendsFamilyLists
                .Include(a => a.FriendsFamilyLists)
                .ThenInclude(a => a.Members)
                .Where(a => a.MemberId == memberId)
                .ToListAsync();

            return View(await memberFriends);
        }

        public async Task<IActionResult> ViewMember(int id)
        {
            var member = _context.Members
                .Where(a => a.MemberId == id)
                .FirstOrDefault();

            return View(member);
        }

        public async Task<IActionResult> AddMember()
        {
            int memberId = int.Parse(HttpContext.Session.GetString("memberId"));

            var members = _context.Members.Where(a => a.MemberId != memberId);
            
            return View(await members.ToListAsync());
        }
        
        //[HttpPost]
        public async Task<IActionResult> SearchMember(string username2)
        {
            int memberId = int.Parse(HttpContext.Session.GetString("memberId"));

            //can't add yourself
            var memberUsername = _context.Members.Where(a => a.MemberId == memberId && a.Username.Trim().ToLower() == username2.Trim().ToLower()).FirstOrDefault();

            if (memberUsername != null && memberUsername.Username == username2)
            {
                ViewBag.search = "You can't add yourself";
            }
            else
            {
                //check if username is valid
                var memberExists = _context.Members.Where(a => a.Username.ToLower().Trim().Contains(username2.Trim().ToLower())).ToListAsync();

                if (memberExists != null)
                {
                    return View("AddMember", await memberExists);
                }
                else
                {
                    ViewBag.search = "A Member with this Username does not exist. Try Again.";
                }
            }

            await Index();
            return View("Index");
        }

        public async Task<IActionResult> AddToList(string username, int memberId)
        {
            //add to list
            int loggedInMemberId = int.Parse(HttpContext.Session.GetString("memberId"));

            var memberToAddId = memberId;

            //check if list for member is already made
            var listExists = _context.FriendsFamilyLists.Where(a => a.MemberId == loggedInMemberId).FirstOrDefault();

            if (listExists != null)
            {
                //list already made, find list ID
                var ffListID = listExists.FriendsFamilyListId;

                //check if username is already added
                var usernameFromatted = username.ToLower().Trim();
                var memberIsInList = _context.MemberFriendsFamilyLists.Where(a => a.Username.Trim().ToLower() == usernameFromatted && a.FriendsFamilyListId == ffListID).FirstOrDefault();

                if (memberIsInList != null)
                {
                    //member is already in wishlist
                    ViewBag.search = "Member is already in your Wishlist";
                }
                else
                {
                    //add member to wishlist
                    _context.MemberFriendsFamilyLists.Add(new MemberFriendsFamilyLists { FriendsFamilyListId = ffListID, Username = username, MemberId = memberToAddId });
                    await _context.SaveChangesAsync();
                    ViewBag.search = "Member added to Wishlist";
                    await Index();
                    return View("Index");
                }
            }
            else
            {
                //make list
                _context.FriendsFamilyLists.Add(new FriendsFamilyLists { MemberId = loggedInMemberId });
                await _context.SaveChangesAsync();

                //find list ID
                var ffList = _context.FriendsFamilyLists.Where(a => a.MemberId == loggedInMemberId).FirstOrDefault();

                if (ffList != null)
                {
                    var ffListId = ffList.FriendsFamilyListId;
                    //add member to wishlist
                    _context.MemberFriendsFamilyLists.Add(new MemberFriendsFamilyLists { FriendsFamilyListId = ffListId, Username = username, MemberId = memberToAddId });
                    await _context.SaveChangesAsync();
                    ViewBag.search = "Member added to Wishlist";
                    await Index();
                    return View("Index");
                }
                else
                {
                    ViewBag.search = "Error, try again";
                }
            }

            return RedirectToAction(nameof(Index));
        }

        //remove friend from list
        public async Task<IActionResult> DeleteFromList(int id, string username, int memberId)
        {
            //var member = _context.Members.Where(a => a.Username == username).FirstOrDefault();
            //var memberToDeleteId = member.MemberId;
            
            //delete using f&flistID and username && ID
            var memberToDelete = _context.MemberFriendsFamilyLists.Where(a => a.FriendsFamilyListId == id && a.Username == username && a.MemberId == memberId).FirstOrDefault();

            if (memberToDelete != null)
            {
                _context.MemberFriendsFamilyLists.Remove(memberToDelete);
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

        // GET: MemberFriendsFamilyLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberFriendsFamilyLists = await _context.MemberFriendsFamilyLists
                .Include(m => m.FriendsFamilyLists)
                .FirstOrDefaultAsync(m => m.FriendsFamilyListId == id);
            if (memberFriendsFamilyLists == null)
            {
                return NotFound();
            }

            return View(memberFriendsFamilyLists);
        }

        // GET: MemberFriendsFamilyLists/Create
        public IActionResult Create()
        {
            ViewData["FriendsFamilyListId"] = new SelectList(_context.FriendsFamilyLists, "FriendsFamilyListId", "FriendsFamilyListId");
            return View();
        }

        // POST: MemberFriendsFamilyLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FriendsFamilyListId,Username")] MemberFriendsFamilyLists memberFriendsFamilyLists)
        {
            if (ModelState.IsValid)
            {
                _context.Add(memberFriendsFamilyLists);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FriendsFamilyListId"] = new SelectList(_context.FriendsFamilyLists, "FriendsFamilyListId", "FriendsFamilyListId", memberFriendsFamilyLists.FriendsFamilyListId);
            return View(memberFriendsFamilyLists);
        }

        // GET: MemberFriendsFamilyLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberFriendsFamilyLists = await _context.MemberFriendsFamilyLists.FindAsync(id);
            if (memberFriendsFamilyLists == null)
            {
                return NotFound();
            }
            ViewData["FriendsFamilyListId"] = new SelectList(_context.FriendsFamilyLists, "FriendsFamilyListId", "FriendsFamilyListId", memberFriendsFamilyLists.FriendsFamilyListId);
            return View(memberFriendsFamilyLists);
        }

        // POST: MemberFriendsFamilyLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FriendsFamilyListId,Username")] MemberFriendsFamilyLists memberFriendsFamilyLists)
        {
            if (id != memberFriendsFamilyLists.FriendsFamilyListId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(memberFriendsFamilyLists);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberFriendsFamilyListsExists(memberFriendsFamilyLists.FriendsFamilyListId))
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
            ViewData["FriendsFamilyListId"] = new SelectList(_context.FriendsFamilyLists, "FriendsFamilyListId", "FriendsFamilyListId", memberFriendsFamilyLists.FriendsFamilyListId);
            return View(memberFriendsFamilyLists);
        }

        // GET: MemberFriendsFamilyLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberFriendsFamilyLists = await _context.MemberFriendsFamilyLists
                .Include(m => m.FriendsFamilyLists)
                .FirstOrDefaultAsync(m => m.FriendsFamilyListId == id);
            if (memberFriendsFamilyLists == null)
            {
                return NotFound();
            }

            return View(memberFriendsFamilyLists);
        }

        // POST: MemberFriendsFamilyLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var memberFriendsFamilyLists = await _context.MemberFriendsFamilyLists.FindAsync(id);
            _context.MemberFriendsFamilyLists.Remove(memberFriendsFamilyLists);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberFriendsFamilyListsExists(int id)
        {
            return _context.MemberFriendsFamilyLists.Any(e => e.FriendsFamilyListId == id);
        }
    }
}
