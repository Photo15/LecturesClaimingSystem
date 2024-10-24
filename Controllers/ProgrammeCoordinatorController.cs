using Microsoft.AspNetCore.Mvc;
using LecturesClaimingSystem.Models;
using LecturesClaimingSystem.Services; // Adjust according to your namespace

namespace LecturesClaimingSystem.Controllers
{
    public class ProgrammeCoordinatorController : Controller
    {
        private readonly EmployeeContext _context; // Your DbContext

        public ProgrammeCoordinatorController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: ProgrammeCoordinator/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View(); // This will look for Views/ProgrammeCoordinator/Login.cshtml
        }

        // POST: ProgrammeCoordinator/Login
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Perform login logic here
                return RedirectToAction("Dashboard"); // Redirect to dashboard on successful login
            }

            ViewBag.ErrorMessage = "Invalid login attempt";
            return View(model); // Return the login view with the error message if login fails
        }

        // GET: ProgrammeCoordinator/Dashboard
        public IActionResult Dashboard()
        {
            return View(); // This will look for Views/ProgrammeCoordinator/Dashboard.cshtml
        }

        // GET: ProgrammeCoordinator/ClaimSub
        [HttpGet]
        public IActionResult ClaimSub()
        {
            return View(); // This will look for Views/ProgrammeCoordinator/ClaimSub.cshtml
        }

        // POST: ProgrammeCoordinator/ClaimSub
        [HttpPost]
        public IActionResult ClaimSub(Claim claim)
        {
            if (ModelState.IsValid)
            {
                _context.Claims.Add(claim); // Add the claim to the context
                _context.SaveChanges(); // Save changes to the database

                return RedirectToAction("Dashboard"); // Redirect after successful submission
            }

            return View(claim); // Return the view with the claim model for validation errors
        }
    }
}
