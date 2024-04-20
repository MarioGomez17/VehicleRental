using Microsoft.AspNetCore.Mvc;
using VEHICLE_RENTAL.Models;

namespace VEHICLE_RENTAL.Controllers
{
    public class VehicleController : Controller
    {
        public IActionResult RegisterVehicle()
        {
            return View();
        }

        public IActionResult VehiclesInfo()
        {
            return View();
        }

        public IActionResult VehicleInfo(int Id_Vehicle)
        {
            VehicleModel Vehicle = new();
            return View(Vehicle.GetVehicle(Id_Vehicle));
        }

        public IActionResult VehicleInfoRental(int Id_Vehicle)
        {
            VehicleModel Vehicle = new();
            return View(Vehicle.GetVehicle(Id_Vehicle));
        }
    }
}

