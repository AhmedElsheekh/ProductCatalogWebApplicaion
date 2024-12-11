using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Product_Catalog_Web_Application.Core.Entities.Identity;
using Product_Catalog_Web_Application.Core.ViewModels;

namespace Product_Catalog_Web_Application.Presentation.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(ApplicationUserSignInInfo inputUser)
        {
            var user = await _userManager.FindByEmailAsync(inputUser.Email);
            if (user is null)
                return NotFound("Invalid email or password");

            var result = await _userManager.CheckPasswordAsync(user, inputUser.Password);
            if (!result)
                return NotFound("Invalid email or password");

            await _signInManager.SignInAsync(user, false);
            return RedirectToAction("Index", "Product");
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
