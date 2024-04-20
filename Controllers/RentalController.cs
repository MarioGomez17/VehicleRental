using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using VEHICLE_RENTAL.Models;

namespace VEHICLE_RENTAL.Controllers
{
    public class RentalController : Controller
    {
        private UserModel UserSessionData()
        {
            var Identity = HttpContext.User.Identity as ClaimsIdentity;
            var UserSessionData = Identity.FindFirst(ClaimTypes.UserData).Value;
            return JsonConvert.DeserializeObject<UserModel>(UserSessionData);
        }

        [Authorize]
        public IActionResult MakeRental()
        {
            return View();
        }

        [Authorize]
        public IActionResult RentalInfo()
        {
            return View();
        }

        [Authorize]
        public IActionResult RateRental()
        {
            return View();
        }

        [Authorize]
        public IActionResult RentalHistory()
        {
            return View();
        }
    }
}
