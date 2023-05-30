﻿using Akademi_PlusProfileImageIdentity.DAL;
using Akademi_PlusProfileImageIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Akademi_PlusProfileImageIdentity.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Index(RegisterViewModel registerViewModel)
        {
            AppUser appUser = new AppUser()
            {
                Name= registerViewModel.Name,
                Email= registerViewModel.Email,
                Surname=registerViewModel.Surname,
                UserName=registerViewModel.Username,
                City=registerViewModel.City,
            };
            var result=await _userManager.CreateAsync(appUser,registerViewModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
