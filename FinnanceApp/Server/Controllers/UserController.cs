using FinnanceApp.Server.Data;
using FinnanceApp.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinnanceApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthRepo _authRepo;
        

        public UserController(IAuthRepo authRepo)
        {
            _authRepo = authRepo;
         
        }
        [HttpPost("registeruser")]
        public async Task<IActionResult> register(UserRegister request)
        {
            var response = await _authRepo.Register(
                new User
                {
                    Username = request.Username,
                    Email = request.Email,

                }, request.Password
                  );
            if(!response.isSuccess)
            {
                return BadRequest(response);
            }
            
            return Ok(response);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login (UserLogin request)
        {
            var response = await _authRepo.Login(request.Email,request.Password);
            if (!response.isSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        
        [HttpPost("activate")]
        public async Task<IActionResult> Activate ([FromBody]string key)
        {
            var response = await _authRepo.activatte(key);
            if (!response.isSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
