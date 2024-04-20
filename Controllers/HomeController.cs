using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using VEHICLE_RENTAL.Models;

namespace VEHICLE_RENTAL.Controllers
{
    public class HomeController : Controller
    {
        private UserModel UserSessionData()
        {
            var Identity = HttpContext.User.Identity as ClaimsIdentity;
            var UserSessionData = Identity.FindFirst(ClaimTypes.UserData).Value;
            return JsonConvert.DeserializeObject<UserModel>(UserSessionData);
        }
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
