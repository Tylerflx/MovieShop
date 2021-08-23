using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastController : ControllerBase
    {
        private readonly ICastService _castService;
        public CastController(ICastService castService)
        {
            _castService = castService;
        }

        //api/Cast
        [HttpGet]
        public async Task<IActionResult> GetAllCasts()
        {
            var casts = await _castService.GetAllCasts();
            if (!casts.Any())
            {
                return NotFound("No Cast Found.");
            }
            return Ok(casts);
        }        
        
        //api/Cast/{id}
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetCastById(int id)
        {
            var casts = await _castService.GetCastDetails(id);
            return Ok(casts);
        }

        
    }
}
