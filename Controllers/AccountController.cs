using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Entities;
using BookStore.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Login([FromBody]User userDetails)
        {
            var user = _userService.Login(userDetails.Username, userDetails.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }


        [HttpPost("logout")]
        public IActionResult Logout()
        {
            int userDetailsID = getUserDetailsID();
            var isLoggedOut = _userService.Logout(userDetailsID);
            return Ok(isLoggedOut);
        }

        private int getUserDetailsID()
        {
            var loggedUser = HttpContext.User;
            int userDetailsID = Convert.ToInt32(loggedUser.Identity.Name);
            return userDetailsID;
        }
    }
}