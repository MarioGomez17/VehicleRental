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
            ClaimsPrincipal ClaimsPrincipal = HttpContext.User;
            if (ClaimsPrincipal != null)
            {
                if (ClaimsPrincipal.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();

        }

        public IActionResult SignIn()
        {
            UserIdentificationType UserIdentificationType = new();
            return View(UserIdentificationType.GetAllUserIdentificationTypes());
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
            if (UserModel != null)
            {
                if (UserModel.UserState_User == "Activo")
                {
                    var Claims = new List<Claim> {
                        new (ClaimTypes.Name, UserModel.Name_User),
                        new ("Email", UserModel.Email_User)
                    };
                    ClaimsIdentity ClaimsIdentity = new(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    Claim UserData = new(ClaimTypes.UserData, JsonConvert.SerializeObject(UserModel));
                    ClaimsIdentity.AddClaim(UserData);
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

        public IActionResult SignInAction(string Name_User, string LastName_User, int UserIdentificationType_User, string IdentificationNumber_User, string Phone_User, string Email_User, string Password_User)
        {
            UserModel UserModel = new();
            if (UserModel.ValidateUser(IdentificationNumber_User))
            {
                if (UserModel.RegisterUser(Name_User, LastName_User, UserIdentificationType_User, IdentificationNumber_User, Phone_User, Email_User, Password_User))
                {
                    return View("LogIn");
                }
                else
                {
                    ViewBag.Message = "Complete los campos del formulario correctamente";
                    SignIn();
                    return View("SignIn");
                }
            }
            else
            {
                ViewBag.Message = "El usuario ya existe";
                SignIn();
                return View("SignIn");
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
