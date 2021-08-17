using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieShopMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {

        private readonly ICurrentUserService _currentUserService;

        public UserController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }


        public async Task<IActionResult> GetAllPurchases()
        {
            var userId = _currentUserService.UserId;
            return View();
        }


        public async Task<IActionResult> GetFavorites()
        {
            return View();
        }


        public async Task<IActionResult> GetProfile()
        {
            return View();
        }


        public async Task<IActionResult> EditProfile()
        {
            return View();
        }


        public async Task<IActionResult> BuyMovie()
        {
            return View();
        }


        public async Task<IActionResult> FavoriteMovie()
        {
            return View();
        }
    }
}
