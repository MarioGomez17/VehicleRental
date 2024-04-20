using Microsoft.AspNetCore.Mvc;
using VEHICLE_RENTAL.Models;

namespace VEHICLE_RENTAL.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            VehicleModel VehicleModel = new();
            return View(VehicleModel.GetAllVehicles());
        }

        public IActionResult IndexFiltered(string City)
        {
            VehicleModel VehicleModel = new();
            return View(VehicleModel.GetAllVehicles(City));
        }
    }
}
