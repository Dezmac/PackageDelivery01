using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PackageDelivery01.Models;
using PackageDelivery01.Data;

namespace PackageDelivery01.Controllers
{
    public class HomeController(PackageDeliveryContext context) : Controller
    {
        private readonly PackageDeliveryContext _context = context;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(int packageNumber)
        {
            if (packageNumber <= 0)
            {
                ViewBag.Error = "Please enter a valid package number.";
                return View("Index");
            }

            try
            {
                Console.WriteLine($"Searching for package with ID: {packageNumber}"); // Log the packageNumber
              
                var package = _context.Packages
                    .Include(p => p.Customer)
                    .Include(p => p.Trackings)
                    .FirstOrDefault(p => p.PackageID == packageNumber);

                if (package == null)
                {
                    Console.WriteLine("Package not found");
                    ViewBag.Error = "No package found with that number.";
                    return View("Index");
                }
                Console.WriteLine($"Package found: {package.PackageID}, {package.ServiceType}, {package.Status}"); // Log the found package details

                return View("Results", package);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                ViewBag.Error = "An error occurred while retrieving the data.";
                return View("Index");
            }
        }
    }
}



