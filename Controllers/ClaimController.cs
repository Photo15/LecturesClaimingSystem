using Microsoft.AspNetCore.Mvc;
using LecturesClaimingSystem.Models;
using System.IO;
using System.Linq;
using LecturesClaimingSystem.Services;

namespace LecturesClaimingSystem.Controllers
{
    public class ClaimsController : Controller
    {
        private readonly EmployeeContext _context;

        public ClaimsController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult SubmitClaim()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitClaim(Claim model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.Length > 0)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", file.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    model.FileName = file.FileName;
                }

                model.SubmissionDate = DateTime.Now;
                model.Status = "Pending";
                _context.Claims.Add(model);
                _context.SaveChanges();

                TempData["Message"] = "Claim Successfully Submitted!";
                return RedirectToAction("ViewApprovedClaims");
            }

            return View(model);
        }

        public IActionResult ViewClaims()
        {
            var claims = _context.Claims.ToList();
            return View(claims);
        }

        public IActionResult ViewApprovedClaims()
        {
            var approvedClaims = _context.Claims.Where(c => c.Status == "Approved").ToList();
            return View(approvedClaims);
        }

        [HttpGet]
        public IActionResult ViewRejectedClaims()
        {
            var rejectedClaims = _context.Claims.Where(c => c.Status == "Rejected").ToList();
            return View(rejectedClaims);
        }
    }
}
