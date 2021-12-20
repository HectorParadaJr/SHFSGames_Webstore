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
    public class CartItemsController : Controller
    {
        private readonly CVGSContext _context;

        public CartItemsController(CVGSContext context)
        {
            _context = context;
        }

        // GET: CartItems
        public async Task<IActionResult> Index()
        {
            int memberId = int.Parse(HttpContext.Session.GetString("memberId"));

            var cVGSContext = _context.CartItems.Include(c => c.Carts).Include(c => c.Games).Where(a => a.Carts.MemberId == memberId).Include(a => a.Platforms);
            return View(await cVGSContext.ToListAsync());
        }

        // GET: CartItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartItems = await _context.CartItems
                .Include(c => c.Carts)
                .Include(c => c.Games)
                .FirstOrDefaultAsync(m => m.CartItemId == id);
            if (cartItems == null)
            {
                return NotFound();
            }

            return View(cartItems);
        }

        // GET: CartItems/Create
        public IActionResult Create(int id)
        {
            //send only platforms for that game
            var gamePlatforms = _context.GamePlatforms.Where(a => a.GameId == id).Include(a => a.Platforms);
            List<string> platformList = new List<string>();

            foreach (var item in gamePlatforms)
            {
                platformList.Add(item.Platforms.PlatformName);
            }

            ViewBag.PlatformNames = platformList;
            ViewBag.GameId = id;
            ViewBag.GameName = _context.Games.Where(a => a.GameId == id).FirstOrDefault().GameName;
            return View();
        }

        // POST: CartItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int Quantity, string PlatformName, int GameId)
        {
            if (ModelState.IsValid)
            {
                int memberId = int.Parse(HttpContext.Session.GetString("memberId"));

                //check if member has a cart yet, if not create cart
                var cart = _context.Carts.Where(a => a.MemberId == memberId);

                if (!cart.Any())
                {
                    //create cart for member
                    _context.Carts.Add(new Carts { MemberId = memberId });
                    await _context.SaveChangesAsync();
                }

                //cart ID
                var cartId = _context.Carts.Where(a => a.MemberId == memberId).AsNoTracking().FirstOrDefault().CartId;

                //Change platform name to ID
                var platformId = _context.Platforms.Where(a => a.PlatformName == PlatformName).FirstOrDefault().PlatformId;

                var alreadyInCart = _context.CartItems.Where(a => a.CartId == cartId && a.GameId == GameId && a.PlatformId == platformId).FirstOrDefault();

                //quantity - one or more
                if (Quantity > 0 && Quantity < 100000)
                {
                    //quantity is good

                    //find price
                    var price = _context.Games.Where(a => a.GameId == GameId).FirstOrDefault().Price;
                    
                    //check if this item is already in cart - same game and platform
                    if (alreadyInCart == null)
                    {
                        //add to cart
                        _context.CartItems.Add(new CartItems { CartId = cartId, GameId = GameId, Price = (double)price, Quantity = Quantity, PlatformId = platformId });

                        await _context.SaveChangesAsync();
                        ViewBag.cart = "Item added to cart";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.cartMsg = "This item is already in your cart";
                    }
                }
                else
                {
                    if (Quantity < 1)
                    {
                        ViewBag.QuantityMsg = "Quantity has to be at least 1";
                    }
                    else if (Quantity > 99999)
                    {
                        ViewBag.QuantityMsg = "Quantity cannot exceed 99,999";
                    }
                }
            }

            //send only platforms for that game
            //send back selected game platform
            var gamePlatforms = _context.GamePlatforms.Where(a => a.GameId == GameId).Include(a => a.Platforms);
            List<string> platformList = new List<string>();

            foreach (var item in gamePlatforms)
            {
                platformList.Add(item.Platforms.PlatformName);
            }

            ViewBag.SelectedPlatform = PlatformName;
            ViewBag.PlatformNames = platformList;
            ViewBag.GameId = GameId;
            ViewBag.GameName = _context.Games.Where(a => a.GameId == GameId).FirstOrDefault().GameName;
            return View();
        }

        // GET: CartItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartItems = _context.CartItems.Where(a => a.CartItemId == id).Include(a => a.Games).Include(a => a.Platforms).FirstOrDefault();
            if (cartItems == null)
            {
                return NotFound();
            }

            ViewBag.GameName = cartItems.Games.GameName;
            ViewBag.Platform = cartItems.Platforms.PlatformName;
            return View(cartItems);
        }

        // POST: CartItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int Quantity)
        {
            var cartItem = _context.CartItems.Where(a => a.CartItemId == id).Include(a => a.Games).Include(a => a.Platforms).FirstOrDefault();

            if (ModelState.IsValid)
            {
                //check quantity
                if (Quantity > 0 && Quantity < 100000)
                {
                    //quantity is good
                    cartItem.Quantity = Quantity;

                    try
                    {
                        _context.Update(cartItem);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CartItemsExists(cartItem.CartItemId))
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
                    if (Quantity < 1)
                    {
                        ViewBag.QuantityMsg = "Quantity has to be at least 1";
                    }
                    else if (Quantity > 99999)
                    {
                        ViewBag.QuantityMsg = "Quantity cannot exceed 99,999";
                    }
                }
            }

            ViewBag.GameName = cartItem.Games.GameName;
            ViewBag.Platform = cartItem.Platforms.PlatformName;
            return View(cartItem);
        }

        // GET: CartItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartItems = await _context.CartItems.FindAsync(id);

            if (cartItems == null)
            {
                return NotFound();
            }

            _context.CartItems.Remove(cartItems);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EmptyCart()
        {
            //empty cart based off member ID
            int memberId = int.Parse(HttpContext.Session.GetString("memberId"));

            var cart = _context.Carts.Where(a => a.MemberId == memberId).AsNoTracking().FirstOrDefault();

            if (cart != null)
            {
                var cartID = cart.CartId;

                var cartItems = _context.CartItems.Where(a => a.CartId == cartID).AsNoTracking();

                List<CartItems> toDelete = new List<CartItems>();
                
                foreach (var item in cartItems)
                {
                    toDelete.Add(item);
                }

                foreach (var item in toDelete)
                {
                    _context.CartItems.Remove(item);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> PlaceOrder()
        {
            int memberId = int.Parse(HttpContext.Session.GetString("memberId"));

            //check payment method
            //send only payment for that member
            var cards = _context.Payments.Where(a => a.MemberId == memberId);

            List<object> cardList = new List<object>();

            foreach (var item in cards)
            {
                cardList.Add(new
                {
                    Id = item.PaymentId,
                    NumberDate = item.CardNumber + " - exp: " + item.ExpirationMonth + "/" + item.ExpirationYear
                });
            }

            ViewData["PaymentId"] = new SelectList(cardList, "Id", "NumberDate");
            //ViewData["PaymentId"] = new SelectList(_context.Payments.Where(a => a.MemberId == memberId), "PaymentId", "CardNumber");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(int PaymentId)
        {
            int memberId = int.Parse(HttpContext.Session.GetString("memberId"));

            if (PaymentId != 0)
            {
                //create a new order:

                //calcualte total: get all cartItems related to member, multiply quantity by total, then add to total
                double total = 0;
                var cartId = _context.Carts.Where(a => a.MemberId == memberId).AsNoTracking().FirstOrDefault().CartId;
                var cartItems = _context.CartItems.Where(a => a.CartId == cartId).AsNoTracking();
                foreach (var item in cartItems)
                {
                    var add = item.Quantity * item.Price;
                    total += add;
                }

                var date = DateTime.Now;

                _context.Orders.Add(new Orders { MemberId = memberId, PaymentId = PaymentId, OrderDate = date, Status = "Received", Total = total });
                await _context.SaveChangesAsync();

                //find orderId
                var orderId = _context.Orders.Where(a => a.MemberId == memberId && a.PaymentId == PaymentId && a.OrderDate == date && a.Status == "Received" && a.Total == total).FirstOrDefault().OrderId;

                //put each cartitem into orderitem
                List<CartItems> cartList = new List<CartItems>();

                foreach (var item in cartItems)
                {
                    cartList.Add(item);
                }

                foreach (var item in cartList)
                {
                    _context.OrderItems.Add(new OrderItems { OrderId = orderId, GameId = item.GameId, PlatformId = item.PlatformId, Quantity = item.Quantity, Price = item.Price });
                    await _context.SaveChangesAsync();
                }

                //call empty cart to empty cart
                await EmptyCart();
                ViewBag.msg = "Order Successfully Placed";
                TempData["order"] = "Order Successfully Placed";
            }
            else
            {
                ViewBag.error = "Add a payment";
            }
            
            //ERROR:
            var cards = _context.Payments.Where(a => a.MemberId == memberId);

            List<object> cardList = new List<object>();

            foreach (var item in cards)
            {
                cardList.Add(new
                {
                    Id = item.PaymentId,
                    NumberDate = item.CardNumber + " - exp: " + item.ExpirationMonth + "/" + item.ExpirationYear
                });
            }

            ViewData["PaymentId"] = new SelectList(cardList, "Id", "NumberDate");
            return RedirectToAction(nameof(Index));
        }

        private bool CartItemsExists(int id)
        {
            return _context.CartItems.Any(e => e.CartItemId == id);
        }
    }
}
