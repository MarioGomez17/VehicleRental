using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using VEHICLE_RENTAL.Models;

namespace VEHICLE_RENTAL.Controllers
{
    public class VehicleController : Controller
    {
        private UserModel UserSessionData()
        {
            var Identity = HttpContext.User.Identity as ClaimsIdentity;
            var UserSessionData = Identity.FindFirst(ClaimTypes.UserData).Value;
            return JsonConvert.DeserializeObject<UserModel>(UserSessionData);
        }

        [Authorize]
        public IActionResult RegisterVehicle()
        {
            return View();
        }

        [Authorize]
        public IActionResult VehiclesInfo()
        {
            return View();
        }

        [Authorize]
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

