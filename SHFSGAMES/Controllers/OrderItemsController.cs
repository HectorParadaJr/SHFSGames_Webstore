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
    public class OrderItemsController : Controller
    {
        private readonly CVGSContext _context;

        public OrderItemsController(CVGSContext context)
        {
            _context = context;
        }

        // GET: OrderItems
        public async Task<IActionResult> Index(int id)
        {
            var cVGSContext = _context.OrderItems.Include(o => o.Games).Include(o => o.Orders).Include(a => a.Platforms).Where(a => a.OrderId == id);
            return View(await cVGSContext.ToListAsync());
        }

        public async Task<IActionResult> EmployeeIndex(int id)
        {
            var cVGSContext = _context.OrderItems.Include(o => o.Games).Include(o => o.Orders).Include(a => a.Platforms).Where(a => a.OrderId == id);
            return View(await cVGSContext.ToListAsync());
        }

        public async Task<IActionResult> SalesReport()
        {
            var cVGSContext = _context.OrderItems.Include(o => o.Games).Include(o => o.Orders).ThenInclude(a => a.Members);
            return View(await cVGSContext.ToListAsync()); 
        }

        // GET: OrderItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItems = await _context.OrderItems
                .Include(o => o.Games)
                .Include(o => o.Orders)
                .FirstOrDefaultAsync(m => m.OrderItemsId == id);
            if (orderItems == null)
            {
                return NotFound();
            }

            return View(orderItems);
        }

        // GET: OrderItems/Create
        public IActionResult Create()
        {
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameDescription");
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "Status");
            return View();
        }

        // POST: OrderItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderItemsId,OrderId,GameId,Quantity,Price")] OrderItems orderItems)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderItems);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameDescription", orderItems.GameId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "Status", orderItems.OrderId);
            return View(orderItems);
        }

        // GET: OrderItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItems = await _context.OrderItems.FindAsync(id);
            if (orderItems == null)
            {
                return NotFound();
            }
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameDescription", orderItems.GameId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "Status", orderItems.OrderId);
            return View(orderItems);
        }

        // POST: OrderItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderItemsId,OrderId,GameId,Quantity,Price")] OrderItems orderItems)
        {
            if (id != orderItems.OrderItemsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderItems);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderItemsExists(orderItems.OrderItemsId))
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
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameDescription", orderItems.GameId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "Status", orderItems.OrderId);
            return View(orderItems);
        }

        // GET: OrderItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItems = await _context.OrderItems
                .Include(o => o.Games)
                .Include(o => o.Orders)
                .FirstOrDefaultAsync(m => m.OrderItemsId == id);
            if (orderItems == null)
            {
                return NotFound();
            }

            return View(orderItems);
        }

        // POST: OrderItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderItems = await _context.OrderItems.FindAsync(id);
            _context.OrderItems.Remove(orderItems);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderItemsExists(int id)
        {
            return _context.OrderItems.Any(e => e.OrderItemsId == id);
        }
    }
}
