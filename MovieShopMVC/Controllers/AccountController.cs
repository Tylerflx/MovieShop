using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]   //get render page
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]  //when clicked button to login
        public async Task<IActionResult> Login(LoginRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userService.Login(model);

            if (user == null)
            {
                throw new Exception("Invalid Login");
            }

            // Cookies based authentication....
            return LocalRedirect("~/");
        }

        //create account
        [HttpGet]
        public IActionResult Register()
        {
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel model)
        {
            //call the service and repository to hash the pw with salt and saved to db
            if (!ModelState.IsValid)
            {
                return View();
            }
            var registeredUser = await _userService.RegisterUser(model);
            return RedirectToAction("Login");
        }
    }
}   
