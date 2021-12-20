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
    public class PaymentsController : Controller
    {
        private readonly CVGSContext _context;

        public PaymentsController(CVGSContext context)
        {
            _context = context;
        }

        // GET: Payments
        public async Task<IActionResult> Index()
        {
            int memberId = int.Parse(HttpContext.Session.GetString("memberId"));

            var cVGSContext = _context.Payments.Include(p => p.Members).Where(a => a.MemberId.Equals(memberId));
            return View(await cVGSContext.ToListAsync());
        }

        // GET: Payments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payments = await _context.Payments
                .Include(p => p.Members)
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (payments == null)
            {
                return NotFound();
            }

            return View(payments);
        }

        // GET: Payments/Create
        public IActionResult Create()
        {
            //ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email");
            return View();
        }

        // POST: Payments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentId,MemberId,CardNumber,Name,ExpirationMonth,ExpirationYear")] Payments payments)
        {
            if (ModelState.IsValid)
            {
                int memberId = int.Parse(HttpContext.Session.GetString("memberId"));
                payments.MemberId = memberId;

                var ccDatesValid = ValidateCCDates(payments.ExpirationMonth, payments.ExpirationYear);
                var ccNumberValid = ValidateCCNumber(payments.CardNumber);

                if (ccDatesValid && ccNumberValid)
                {
                    _context.Add(payments);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    if (!ccDatesValid)
                    {
                        ViewBag.error = "Credit Card Expiration Dates Invalid";

                    }
                    if (!ccNumberValid)
                    {
                        ViewBag.Lerror = "Credit Card Number Invalid";
                    }
                }
            }
            //ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email", payments.MemberId);
            return View(payments);
        }

        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payments = await _context.Payments.FindAsync(id);
            if (payments == null)
            {
                return NotFound();
            }
            //ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email", payments.MemberId);
            return View(payments);
        }

        // POST: Payments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentId,MemberId,CardNumber,Name,ExpirationMonth,ExpirationYear")] Payments payments)
        {
            if (id != payments.PaymentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var ccDatesValid = ValidateCCDates(payments.ExpirationMonth, payments.ExpirationYear);
                var ccNumberValid = ValidateCCNumber(payments.CardNumber);

                if (ccDatesValid && ccNumberValid)
                {
                    try
                    {
                        int memberId = int.Parse(HttpContext.Session.GetString("memberId"));
                        payments.MemberId = memberId;

                        _context.Update(payments);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!PaymentsExists(payments.PaymentId))
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
                    if (!ccDatesValid)
                    {
                        ViewBag.error = "Credit Card Expiration Dates Invalid";
                    }
                    if (!ccNumberValid)
                    {
                        ViewBag.Lerror = "Credit Card Number Invalid";
                    }
                }
            }
            //ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email", payments.MemberId);
            return View(payments);
        }

        // GET: Payments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payments = await _context.Payments
                .Include(p => p.Members)
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (payments == null)
            {
                return NotFound();
            }

            return View(payments);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payments = await _context.Payments.FindAsync(id);
            _context.Payments.Remove(payments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentsExists(int id)
        {
            return _context.Payments.Any(e => e.PaymentId == id);
        }

        public bool ValidateCCDates(int month, int year)
        {
            var currentMonth = DateTime.Now.Month.ToString("d2");
            var currentYear = DateTime.Now.Year;

            if (currentYear <= year)
            {
                if (year == currentYear)
                {
                    //check if month is possible
                    //current month and under
                    if (month < int.Parse(currentMonth))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public bool ValidateCCNumber(string ccNumber)
        {
            var creditCardValid = new Regex(@"^\d{16}$");

            if (ccNumber.Length == 16)
            {
                if (creditCardValid.IsMatch(ccNumber))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
