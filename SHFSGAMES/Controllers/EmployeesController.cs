using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SHFSGAMES.Models;

namespace SHFSGAMES.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly CVGSContext _context;

        public EmployeesController(CVGSContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employees = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employees == null)
            {
                return NotFound();
            }

            return View(employees);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,Password,FirstName,LastName")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employees);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employees);
        }

        //GET: Employees/Login
        [AllowAnonymous]
        public IActionResult EmployeeLogin()
        {
            return View();
        }

        //POST: Employee/Login
        [HttpPost]
        [AllowAnonymous]
        public ActionResult EmployeeLogin(string firstName, string password)
        {
            if (ModelState.IsValid)
            {
                var employees = _context.Employees.Where(r => r.FirstName.Equals(firstName) && r.Password.Equals(password));

                if (employees.Count() == 1)
                {
                    //set user or session to be employee. Before loggin in as employee or user and session == user (or employee), log in is not valid
                    //session type member or employee
                    //employee id
                    //user id 
                    if (HttpContext.Session.GetString("userType") == null || HttpContext.Session.GetString("userType") == "")
                    {
                        HttpContext.Session.SetString("userType", "employee");

                        if (HttpContext.Session.GetString("employeeId") == null || HttpContext.Session.GetString("employeeId") == "")
                        {
                            HttpContext.Session.SetString("employeeId", employees.FirstOrDefault().EmployeeId.ToString());
                            
                            return RedirectToAction("Index", "Games");
                        }
                    }
                }
                else
                {
                    ViewBag.error = "Please Try Again";
                }
            }

            return View();
        }

        //public IActionResult EmployeeLogout()
        //{
        //    //view home page with log in and create member layout options
        //    //set sessions usertype == null
        //    //set session userid == null or 0
        //    HttpContext.Session.SetString("userType", null);
        //    HttpContext.Session.SetString("employeeId", null);


        //    return RedirectToAction();
        //}

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employees = await _context.Employees.FindAsync(id);
            if (employees == null)
            {
                return NotFound();
            }
            return View(employees);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,Password,FirstName,LastName")] Employees employees)
        {
            if (id != employees.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employees);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeesExists(employees.EmployeeId))
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
            return View(employees);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employees = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employees == null)
            {
                return NotFound();
            }

            return View(employees);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employees = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employees);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeesExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
