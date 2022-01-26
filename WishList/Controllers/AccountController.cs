using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WishList.Models;
using WishList.Models.AccountViewModels;

namespace WishList.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
           _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
    
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if(ModelState.IsValid)
            {
                var User = new ApplicationUser
                {
                    Email = registerViewModel.Email,
                    UserName = registerViewModel.Email
                };
                var result = _userManager.CreateAsync(User, registerViewModel.Passowrd);
                if(result.Result.Succeeded)
                {
                }
                else
                {
                    foreach (var errors in result.Result.Errors)
                    {
                        ModelState.AddModelError(registerViewModel.Passowrd, errors.Description);
                    }
                }
                return RedirectToAction("Index", "Home");
            }


            //RedirectToAction("Index", "Home");
            return View(registerViewModel);

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
    }

}
