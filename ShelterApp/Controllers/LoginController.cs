using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ShelterApp.ViewModels;
using ShelterApp.Security;
using ShelterApp.Services;

namespace ShelterApp.Controllers
{

    [Route("api/[controller]")]
    [AllowAnonymous]
    public class LoginController : Controller
    {

        IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Login([FromBody]LoginViewModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Hibás felhasználónév vagy jelszó!");
            }

            var currentUser = _userService.getUserByName(inputModel.UserName);
            if (currentUser == null)
            {
                return NotFound("Nincs ilyen felhasználó regisztrálva!");
            }

            var token = new JwtTokenBuilder()
                                .AddSecurityKey(JwtSecurityKey.Create("Security key required for ShelterApp"))
                                .AddSubject(currentUser.Username)
                                .AddIssuer("ShelterServer")
                                .AddAudience("ShelterApp")
                                .AddClaim("MembershipId", currentUser.Id.ToString())
                                .AddExpiry(30)
                                .Build();

            //return Ok(token);
            return Ok(token.Value);
        }
    }
}
