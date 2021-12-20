using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SHFSGAMES.Models;

namespace SHFSGAMES.Controllers
{
    public class ShippingAddressesController : Controller
    {
        private readonly CVGSContext _context;

        public ShippingAddressesController(CVGSContext context)
        {
            _context = context;
        }

        // GET: ShippingAddresses
        public async Task<IActionResult> Index()
        {
            int memberId = int.Parse(HttpContext.Session.GetString("memberId"));

            var addressExists = _context.ShippingAddresses.Where(a => a.MemberId.Equals(memberId)).FirstOrDefault();

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

        // GET: ShippingAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shippingAddresses = await _context.ShippingAddresses
                .Include(s => s.Members)
                .FirstOrDefaultAsync(m => m.ShippingAddressId == id);
            if (shippingAddresses == null)
            {
                return NotFound();
            }

            return View(shippingAddresses);
        }

        // GET: ShippingAddresses/Create
        public IActionResult Create()
        {
            //ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email");
            return View();
        }

        // POST: ShippingAddresses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShippingAddressId,MemberId,Address,City,PostalCode,Province,Country")] ShippingAddresses shippingAddresses)
        {
            if (ModelState.IsValid)
            {
                //validate postal/zip code
                var postalIsValid = ValidatePostal(shippingAddresses.PostalCode);

                if (postalIsValid)
                {
                    //memberID
                    int memberId = int.Parse(HttpContext.Session.GetString("memberId"));
                    shippingAddresses.MemberId = memberId;

                    _context.Add(shippingAddresses);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.error = "Enter correct Postal Code Format (X1X1X1)";
                }
            }
            //ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email", shippingAddresses.MemberId);
            return View(shippingAddresses);
        }

        // GET: ShippingAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shippingAddresses = await _context.ShippingAddresses.FindAsync(id);
            if (shippingAddresses == null)
            {
                return NotFound();
            }
            //ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email", shippingAddresses.MemberId);
            return View(shippingAddresses);
        }

        // POST: ShippingAddresses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShippingAddressId,MemberId,Address,City,PostalCode,Province,Country")] ShippingAddresses shippingAddresses)
        {
            if (id != shippingAddresses.ShippingAddressId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var postalIsValid = ValidatePostal(shippingAddresses.PostalCode);

                if (postalIsValid)
                {
                    //memberID
                    int memberId = int.Parse(HttpContext.Session.GetString("memberId"));
                    shippingAddresses.MemberId = memberId;

                    try
                    {
                        _context.Update(shippingAddresses);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ShippingAddressesExists(shippingAddresses.ShippingAddressId))
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
            //ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email", shippingAddresses.MemberId);
            return View(shippingAddresses);
        }

        // GET: ShippingAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shippingAddresses = await _context.ShippingAddresses
                .Include(s => s.Members)
                .FirstOrDefaultAsync(m => m.ShippingAddressId == id);
            if (shippingAddresses == null)
            {
                return NotFound();
            }

            return View(shippingAddresses);
        }

        // POST: ShippingAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shippingAddresses = await _context.ShippingAddresses.FindAsync(id);
            _context.ShippingAddresses.Remove(shippingAddresses);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShippingAddressesExists(int id)
        {
            return _context.ShippingAddresses.Any(e => e.ShippingAddressId == id);
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
