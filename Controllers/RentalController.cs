using Microsoft.AspNetCore.Mvc;

namespace VEHICLE_RENTAL.Controllers
{
    public class RentalController : Controller
    {
        public IActionResult MakeRental()
        {
            return View();
        }

        public IActionResult RentalInfo()
        {
            return View();
        }

        public IActionResult RateRental()
        {
            return View();
        }

        public IActionResult RentalHistory()
        {
            return View();
        }
    }
}
