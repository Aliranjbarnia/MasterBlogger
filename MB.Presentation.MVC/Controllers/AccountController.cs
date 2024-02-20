using MB.Presentation.MVC.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MB.Presentation.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _sighInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> sighInManager)
        {
            _userManager = userManager;
            _sighInManager = sighInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = register.Username,
                    Email = register.Email,
                    EmailConfirmed = true
                };
                var result = await _userManager.CreateAsync(user, register.Password);

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

            }

            return View(register);
        }

        [HttpGet]
        public  IActionResult Login(string returnUrl = null)
        {
            if (_sighInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }
            ViewData["returnUrl"] = returnUrl;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login, string returnUrl = null)
        {
            if (_sighInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index","Home");
            }

            ViewData["returnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var result = await _sighInManager.PasswordSignInAsync(login.Username, login.Password, login.RememberMe, true);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index","Home");
                }

                if (result.IsLockedOut)
                {
                    ViewData["ErrorMessage"] = "Your account has been locked for five minutes because you failed to login five times\r\n";
                    return View(login);
                }

                ModelState.AddModelError("", "Username or password is wrong");
            }
            return View(login);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await _sighInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
