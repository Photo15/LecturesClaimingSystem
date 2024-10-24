using LecturesClaimingSystem.Models; // Include models
using LecturesClaimingSystem.Services; // Ensure this line is included
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace LecturesClaimingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ClaimContext _context; // Your DbContext

        public HomeController(ILogger<HomeController> logger, ClaimContext context)
        {
            _logger = logger;
            _context = context; // Initialize the DbContext
        }

        // Default Index page
        public IActionResult Index()
        {
            return View();
        }

        // Privacy page
        public IActionResult Privacy()
        {
            return View();
        }

        // GET: Form to submit a new claim
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // POST: Submit a new claim
        [HttpPost]
        public IActionResult SubmitClaim(Claim claim)
        {
            if (ModelState.IsValid)
            {
                _context.Claims.Add(claim);
                _context.SaveChanges();
                ViewData["Message"] = "Claim Successfully Submitted!";
                return RedirectToAction("Add"); // Redirecting to the 'Add' action
            }
            return View("Add");
        }

        // GET: List pending claims
        [HttpGet]
        public IActionResult PendingClaims()
        {
            var claims = _context.Claims.Where(c => c.Status == "Pending").ToList(); // Fetch pending claims
            return View(claims); // Ensure you have a view to display the claims
        }

        // POST: Approve a claim
        [HttpPost]
        public IActionResult ApproveClaim(int claimId)
        {
            var claim = _context.Claims.FirstOrDefault(c => c.ID == claimId); // Use ID to fetch the claim
            if (claim != null)
            {
                claim.Status = "Approved";
                _context.SaveChanges();
            }
            return RedirectToAction("PendingClaims");
        }

        // POST: Reject a claim
        [HttpPost]
        public IActionResult RejectClaim(int claimId)
        {
            var claim = _context.Claims.FirstOrDefault(c => c.ID == claimId); // Use ID to fetch the claim
            if (claim != null)
            {
                claim.Status = "Rejected";
                _context.SaveChanges();
            }
            return RedirectToAction("PendingClaims");
        }

        // Handle errors
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
