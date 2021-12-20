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
    public class OrdersController : Controller
    {
        private readonly CVGSContext _context;

        public OrdersController(CVGSContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            int memberId = int.Parse(HttpContext.Session.GetString("memberId"));

            var cVGSContext = _context.Orders.Include(o => o.Members).Include(o => o.Payments).Where(a => a.MemberId == memberId);
            return View(await cVGSContext.ToListAsync());
        }

        // GET: Orders
        public async Task<IActionResult> EmployeeIndex()
        {
            var cVGSContext = _context.Orders.Include(o => o.Members).Include(o => o.Payments).OrderByDescending(a => a.OrderDate);
            return View(await cVGSContext.ToListAsync());
        }

        /// <summary>
        /// Change order status to Processed
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<IActionResult> ChangeStatusProcessed(int id)
        {
            var order = _context.Orders.Where(a => a.OrderId == id).FirstOrDefault();

            order.Status = "Processed";
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(EmployeeIndex));
        }
        
        /// <summary>
        /// Change order status to shipped
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<IActionResult> ChangeStatusShipped(int id)
        {
            var order = _context.Orders.Where(a => a.OrderId == id).FirstOrDefault();

            order.Status = "Shipped";
            order.ShippedDate = DateTime.Now;
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(EmployeeIndex));
        }

        //report
        public async Task<IActionResult> SalesReport()
        {
            var cVGSContext = _context.Orders.Include(o => o.Members).Include(o => o.Payments).Include(a => a.OrderItems).OrderBy(a => a.OrderDate);
            return View(await cVGSContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .Include(o => o.Members)
                .Include(o => o.Payments)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email");
            ViewData["PaymentId"] = new SelectList(_context.Payments, "PaymentId", "Name");
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,MemberId,PaymentId,OrderDate,ShippedDate,Status,Total")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email", orders.MemberId);
            ViewData["PaymentId"] = new SelectList(_context.Payments, "PaymentId", "Name", orders.PaymentId);
            return View(orders);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email", orders.MemberId);
            ViewData["PaymentId"] = new SelectList(_context.Payments, "PaymentId", "Name", orders.PaymentId);
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,MemberId,PaymentId,OrderDate,ShippedDate,Status,Total")] Orders orders)
        {
            if (id != orders.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(orders.OrderId))
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
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Email", orders.MemberId);
            ViewData["PaymentId"] = new SelectList(_context.Payments, "PaymentId", "Name", orders.PaymentId);
            return View(orders);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .Include(o => o.Members)
                .Include(o => o.Payments)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //first delete all the order items using order id, then delete order
            var orderItems = _context.OrderItems.Where(a => a.OrderId == id);
            List<OrderItems> itemsToDelete = new List<OrderItems>();

            foreach (var item in orderItems)
            {
                itemsToDelete.Add(item);
            }

            foreach (var item in itemsToDelete)
            {
                _context.OrderItems.Remove(item);
                await _context.SaveChangesAsync();
            }

            var orders = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(orders);
            await _context.SaveChangesAsync();
            ViewBag.delete = "Order Deleted";
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
