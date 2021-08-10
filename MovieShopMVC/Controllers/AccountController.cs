using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;
namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]   //get render page
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]  //when clicked button to login
        public IActionResult Login(LoginRequestModel model)
        {
            return View();
        }

        //create account
        [HttpGet]
        public IActionResult Register()
        {
            return View(); 
        }
        [HttpPost]
        public IActionResult Register(UserRegisterRequestModel model)
        {
            return View();
        }
    }
}   
