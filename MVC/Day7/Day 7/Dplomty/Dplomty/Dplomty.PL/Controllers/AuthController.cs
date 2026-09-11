using Dplomty.DAL.Entities;
using Dplomty.PL.ViewModel.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dplomty.PL.Controllers
{
    public class AuthController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInM anager<ApplicationUser> _signInManager;
        public AuthController (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(CreateAccountVM accountVM)
        {
            var AppAccount = new ApplicationUser
            {
                Email = accountVM.Email,
                UserName = accountVM.UserName,
                PhoneNumber = accountVM.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(AppAccount, accountVM.Password);

            if (!result.Succeeded)
            {
                throw new Exception("");
            }

            return View();
        }
        [HttpGet]
        public IActionResult Login() {

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Login(LoginVM loginAccount)
        {

           var res = await _signInManager.PasswordSignInAsync(loginAccount.UserName, loginAccount.Password, false, false);

            return RedirectToAction("GetAll","Student");

        }
    }
}
