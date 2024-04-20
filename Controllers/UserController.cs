using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using VEHICLE_RENTAL.Models;
using Microsoft.AspNetCore.Authorization;

namespace VEHICLE_RENTAL.Controllers
{
    public class UserController : Controller
    {
        private UserModel UserSessionData()
        {
            var Identity = HttpContext.User.Identity as ClaimsIdentity;
            var UserSessionData = Identity.FindFirst(ClaimTypes.UserData).Value;
            return JsonConvert.DeserializeObject<UserModel>(UserSessionData);
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [Authorize]
        public IActionResult UserInfo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogInAction(string UserEmail, string UserPassword, string KeepSession)
        {
            UserModel UserModel = new();
            UserModel = UserModel.GetUser(UserEmail, UserPassword);
            if (User != null)
            {
                if (UserModel.UserState_User == "Activo")
                {
                    var Claims = new List<Claim> {
                        new (ClaimTypes.Name, UserModel.Name_User),
                        new ("Email", UserModel.Email_User)
                    };
                    ClaimsIdentity ClaimsIdentity = new(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    Claim DatosUsuario = new(ClaimTypes.UserData, JsonConvert.SerializeObject(User));
                    ClaimsIdentity.AddClaim(DatosUsuario);
                    AuthenticationProperties AuthenticationProperties = new()
                    {
                        AllowRefresh = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(KeepSession == "on" ? 30 : 5)
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ClaimsIdentity), AuthenticationProperties);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Correo o Contraseña Equivocados";
                    return View("LogIn");
                }
            }
            else
            {
                ViewBag.Message = "Correo o Contraseña Incorrectos";
                return View("LogIn");
            }
        }

        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View("LogIn");
        }
    }
}
