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
        private readonly IUserService _userService;

        public UserController(ICurrentUserService currentUserService, IUserService userService)
        {
            _currentUserService = currentUserService;
            _userService = userService;
        }


        public async Task<IActionResult> GetPurchases()
        {
            //var userId = HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
            var userId = _currentUserService.UserId;
            var movieCards = await _userService.GetPurchaseMovies(userId);
            return View(movieCards);
        }


        public async Task<IActionResult> GetFavorites()
        {
            var userId = _currentUserService.UserId;
            var movieCards = await _userService.GetFavorites(userId);
            return View(movieCards);
        }


        public async Task<IActionResult> GetProfile()
        {
            var userId = _currentUserService.UserId;
            var movieCards = await _userService.GetPurchaseMovies(userId);
            return View(movieCards);
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
