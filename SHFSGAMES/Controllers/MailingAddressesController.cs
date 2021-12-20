using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using SHFSGAMES.Models;

namespace SHFSGAMES.Controllers
{
    public class MailingAddressesController : Controller
    {
        private readonly CVGSContext _context;

        public MailingAddressesController(CVGSContext context)
        {
            _context = context;
        }

        // GET: MailingAddresses
        public async Task<IActionResult> Index()
        {
            int memberId = int.Parse(HttpContext.Session.GetString("memberId"));

            var addressExists = _context.MailingAddresses.Where(a => a.MemberId.Equals(memberId)).FirstOrDefault();

            if (addressExists != null)
            {
                ViewBag.exists = true;
                return View(addressExists);
            }
            else
            {
                ViewBag.exists = false;
                return View();
            }
        }

        // GET: MailingAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mailingAddresses = await _context.MailingAddresses
                .Include(m => m.Members)
                .FirstOrDefaultAsync(m => m.MailingAddressId == id);
            if (mailingAddresses == null)
            {
                return NotFound();
            }

            return View(mailingAddresses);
        }

        // GET: MailingAddresses/Create
        public IActionResult Create()
        {
            //ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email");
            return View();
        }

        // POST: MailingAddresses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MailingAddressId,MemberId,Address,City,PostalCode,Province,Country")] MailingAddresses mailingAddresses)
        {
            if (ModelState.IsValid)
            {
                //validate postal/zip code
                var postalIsValid = ValidatePostal(mailingAddresses.PostalCode);

                if (postalIsValid)
                {
                    //memberID
                    int memberId = int.Parse(HttpContext.Session.GetString("memberId"));
                    mailingAddresses.MemberId = memberId;

                    _context.Add(mailingAddresses);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.error = "Enter correct Postal Code Format (X1X1X1)";
                }
            }
            //ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email", mailingAddresses.MemberId);
            return View(mailingAddresses);
        }

        // GET: MailingAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mailingAddresses = await _context.MailingAddresses.FindAsync(id);
            if (mailingAddresses == null)
            {
                return NotFound();
            }
            //ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email", mailingAddresses.MemberId);
            return View(mailingAddresses);
        }

        // POST: MailingAddresses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MailingAddressId,MemberId,Address,City,PostalCode,Province,Country")] MailingAddresses mailingAddresses)
        {
            if (id != mailingAddresses.MailingAddressId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //validate postal/zip code
                var postalIsValid = ValidatePostal(mailingAddresses.PostalCode);

                if (postalIsValid)
                {
                    //memberID
                    int memberId = int.Parse(HttpContext.Session.GetString("memberId"));
                    mailingAddresses.MemberId = memberId;

                    try
                    {
                        _context.Update(mailingAddresses);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!MailingAddressesExists(mailingAddresses.MailingAddressId))
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
                    ViewBag.error = "Enter correct Postal Code Format (X1X1X1)";
                }
            }
            //ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email", mailingAddresses.MemberId);
            return View(mailingAddresses);
        }

        // GET: MailingAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mailingAddresses = await _context.MailingAddresses
                .Include(m => m.Members)
                .FirstOrDefaultAsync(m => m.MailingAddressId == id);
            if (mailingAddresses == null)
            {
                return NotFound();
            }

            return View(mailingAddresses);
        }

        // POST: MailingAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mailingAddresses = await _context.MailingAddresses.FindAsync(id);
            _context.MailingAddresses.Remove(mailingAddresses);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MailingAddressesExists(int id)
        {
            return _context.MailingAddresses.Any(e => e.MailingAddressId == id);
        }

        public bool ValidatePostal(string postal)
        {
            var matchesCAD = new Regex(@"^[a-z]\d[a-z]\ ?\d[a-z]\d$");

            if (matchesCAD.IsMatch(postal.ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
