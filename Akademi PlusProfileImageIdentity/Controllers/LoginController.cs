using Akademi_PlusProfileImageIdentity.DAL;
using Akademi_PlusProfileImageIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Akademi_PlusProfileImageIdentity.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Index(LoginViewModel loginViewModel)
        {
            var result=await _signInManager.PasswordSignInAsync(loginViewModel.Username,loginViewModel.Password,false,false);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Myprofile");
            }
            return View();
        }
    }
}
